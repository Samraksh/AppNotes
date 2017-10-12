// Updated Ultimate WPF Event Method Binding implementation by Mike Marynowski
// https://gist.github.com/mikernet/4336eaa8ad71cb0f2e35d65ac8e8e161
// Article: http://www.singulink.com/CodeIndex/post/building-the-ultimate-wpf-event-method-binding-extension
// Article: http://www.singulink.com/CodeIndex/post/updated-ultimate-wpf-event-method-binding

// Licensed under the Code Project Open License: http://www.codeproject.com/info/cpol10.aspx

/*
	With new approach (see http://www.singulink.com/CodeIndex/post/updated-ultimate-wpf-event-method-binding) that includes target
		<button click="{data:MethodBinding {Binding}, OpenFromFile}" content="Open"/>
	assumes a signature of
		public void OpenFromFile(object target);
	
	However, the original approach works by defining additional constructors below. Hence 
			<button click="{data:MethodBinding OpenFromFile}" content="Open"/>
	where OpenFromFile has signature 
		public void OpenFromFile(); 
*/

/* Examples of method binding:

	<!--  Basic usage  -->
	<Button Click="{data:MethodBinding OpenFromFile}" Content="Open" /> 

	<!--  Pass in a binding as a method argument  -->
	<Button Click="{data:MethodBinding Save, {Binding CurrentItem}}" Content="Save" /> 

	<!-- Pass in multiple arguments, resolve method based on argument count and convert XAML string argument to propery bool type automatically -->
	<Button Click="{data:MethodBinding Save, {Binding CurrentItem}, {Binding SaveAsPath}, True}" Content="Save As" />

	<!--  Another example of a binding, but this time to a property on another element  -->
	<ComboBox x:Name="ExistingItems" ItemsSource="{Binding ExistingItems}" />
	<Button Click="{data:MethodBinding Edit, {Binding SelectedItem, ElementName=ExistingItems}}" /> 

	<!--  Pass in a hard-coded method argument, XAML string automatically converted to the proper type  -->
	<ToggleButton Checked="{data:MethodBinding SetWebServiceState, True}"
				  Content="Web Service"
				  Unchecked="{data:MethodBinding SetWebServiceState, False}" /> 

	<!--  Pass in sender, and match method signature automatically -->
	<Canvas PreviewMouseDown="{data:MethodBinding SetCurrentElement, {data:EventSender}, ThrowOnMethodMissing=False}">    
		<controls:DesignerElementTypeA />    
		<controls:DesignerElementTypeB />    
		<controls:DesignerElementTypeC />
	</Canvas>  

	<!--  Pass in EventArgs  -->
	<Canvas MouseDown="{data:MethodBinding StartDrawing, {data:EventArgs}}"
			MouseMove="{data:MethodBinding AddDrawingPoint, {data:EventArgs}}"
			MouseUp="{data:MethodBinding EndDrawing, {data:EventArgs}}" /> 

	<!-- Support binding to methods further in a property path -->
	<Button Content="SaveDocument" Click="{data:MethodBinding CurrentDocument.DocumentService.Save, {Binding CurrentDocument}}" /> 

Pseudo signatures on the view model:
	public void OpenFromFile(); 
	public void Save(DocumentModel model);
	public void Save(DocumentModel model, string path, bool overwrite);
	public void Edit(DocumentModel model); 
	public void SetWebServiceState(bool state); 
	public void SetCurrentElement(DesignerElementTypeA element);
	public void SetCurrentElement(DesignerElementTypeB element);
	public void SetCurrentElement(DesignerElementTypeC element); 
	public void StartDrawing(MouseEventArgs e);
	public void AddDrawingPoint(MouseEventArgs e);
	public void EndDrawing(MouseEventArgs e); 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Visualizer
{
	public class MethodBindingExtension : MarkupExtension
	{
		private static readonly List<DependencyProperty> StorageProperties = new List<DependencyProperty>();

		[ConstructorArgument("target")]
		public object Target { get; private set; }

		[ConstructorArgument("methodName")]
		public object MethodName { get; private set; }

		private DependencyProperty _methodTargetProperty;
		private DependencyProperty _methodNameProperty;
		private readonly object[] _methodArguments;
		private readonly List<DependencyProperty> _argumentProperties = new List<DependencyProperty>();

		public MethodBindingExtension(object methodName) : this(new Binding(), methodName, null) { }
		public MethodBindingExtension(object target, object methodName) : this(target, methodName, null) { }
		public MethodBindingExtension(object target, object methodName, object argument) : this(target, methodName, new[] { argument }) { }
		public MethodBindingExtension(object target, object methodName, object arg0, object arg1) : this(target, methodName, new[] { arg0, arg1 }) { }
		public MethodBindingExtension(object target, object methodName, object arg0, object arg1, object arg2) : this(target, methodName, new[] { arg0, arg1, arg2 }) { }
		public MethodBindingExtension(object target, object methodName, object arg0, object arg1, object arg2, object arg3) : this(target, methodName, new[] { arg0, arg1, arg2, arg3 }) { }
		public MethodBindingExtension(object target, object methodName, object arg0, object arg1, object arg2, object arg3, object arg4) : this(target, methodName, new[] { arg0, arg1, arg2, arg3, arg4 }) { }

		private MethodBindingExtension(object target, object methodName, object[] arguments)
		{
			if (target is string)
			{
				Target = new Binding((string)target);
			}
			else
			{
				Target = target;
			}

			MethodName = methodName;
			_methodArguments = arguments ?? new object[0];
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var provideValueTarget = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
			var target = provideValueTarget.TargetObject as FrameworkElement;
			var eventInfo = provideValueTarget.TargetProperty as EventInfo;

			if (target == null || eventInfo == null)
			{
				return this;
			}

			_methodTargetProperty = SetUnusedStorageProperty(target, Target);
			_methodNameProperty = SetUnusedStorageProperty(target, MethodName);

			foreach (var argument in _methodArguments)
			{
				var argumentProperty = SetUnusedStorageProperty(target, argument);
				_argumentProperties.Add(argumentProperty);
			}

			return CreateEventHandler(target, eventInfo);
		}

		private Delegate CreateEventHandler(FrameworkElement target, EventInfo eventInfo)
		{
			EventHandler handler = (sender, eventArgs) =>
			{
				var methodTarget = target.GetValue(_methodTargetProperty);

				if (methodTarget == null)
				{
					Debug.WriteLine("\n[MethodBinding] Target {could not be resolved.\n");
					return;
				}

				string methodName = null;

				try
				{
					methodName = (string)target.GetValue(_methodNameProperty);
				}
				catch (Exception ex)
				{
					Debug.WriteLine("\n[MethodBinding] Method name must resolve to a string value: {0}\n",ex.Message);
					return;
				}

				if (methodName == null)
				{
					Debug.WriteLine("\n[MethodBinding] Method name could not be resolved.\n");
					return;
				}

				var arguments = new object[_argumentProperties.Count];

				for (int i = 0; i < _argumentProperties.Count; i++)
				{
					var argValue = target.GetValue(_argumentProperties[i]);

					if (argValue is EventSenderExtension)
					{
						argValue = sender;
					}
					else if (argValue is EventArgsExtension)
					{
						argValue = eventArgs;
					}

					arguments[i] = argValue;
				}

				var methodTargetType = methodTarget.GetType();

				// Try invoking the method by resolving it based on the arguments provided

				try
				{
					methodTargetType.InvokeMember(methodName, BindingFlags.InvokeMethod, null, methodTarget, arguments);
					return;
				}
				catch (MissingMethodException) { }

				// Couldn't match a method with the raw arguments, so check if we can find a method with the same name
				// and parameter count and try to convert any XAML string arguments to match the method parameter types

				var method = methodTargetType.GetMethods().SingleOrDefault(m => m.Name == methodName && m.GetParameters().Length == arguments.Length);

				if (method != null)
				{
					var parameters = method.GetParameters();

					for (int i = 0; i < _methodArguments.Length; i++)
					{
						if (arguments[i] == null)
						{
							if (parameters[i].ParameterType.IsValueType)
							{
								method = null;
								break;
							}
						}
						else if (_methodArguments[i] is string && parameters[i].ParameterType != typeof(string))
						{
							// The original value provided for this argument was a XAML string so try to convert it

							arguments[i] = TypeDescriptor.GetConverter(parameters[i].ParameterType).ConvertFromString((string)_methodArguments[i]);
						}
						else if (!parameters[i].ParameterType.IsInstanceOfType(arguments[i]))
						{
							method = null;
							break;
						}
					}

					if (method != null)
					{
						method.Invoke(methodTarget, arguments);
					}
				}

				if (method == null)
				{
					Debug.WriteLine("\n[MethodBinding] Could not find a method that accepts the parameters provided.\n");
				}
			};

			return Delegate.CreateDelegate(eventInfo.EventHandlerType, handler.Target, handler.Method);
		}

		private DependencyProperty SetUnusedStorageProperty(DependencyObject obj, object value)
		{
			var property = StorageProperties.FirstOrDefault(p => obj.ReadLocalValue(p) == DependencyProperty.UnsetValue);

			if (property == null)
			{
				property = DependencyProperty.RegisterAttached("Storage" + StorageProperties.Count, typeof(object), typeof(MethodBindingExtension), new PropertyMetadata());
				StorageProperties.Add(property);
			}

			var markupExtension = value as MarkupExtension;

			if (markupExtension != null)
			{
				var resolvedValue = markupExtension.ProvideValue(new ServiceProvider(obj, property));
				obj.SetValue(property, resolvedValue);
			}
			else
			{
				obj.SetValue(property, value);
			}

			return property;
		}

		private class ServiceProvider : IServiceProvider, IProvideValueTarget
		{
			public object TargetObject { get; private set; }
			public object TargetProperty { get; private set; }

			public ServiceProvider(object targetObject, object targetProperty)
			{
				TargetObject = targetObject;
				TargetProperty = targetProperty;
			}

			public object GetService(Type serviceType)
			{
				return serviceType.IsInstanceOfType(this) ? this : null;
			}
		}
	}

	public class EventSenderExtension : MarkupExtension
	{
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}

	public class EventArgsExtension : MarkupExtension
	{
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
