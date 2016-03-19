using Microsoft.SPOT;

namespace UserApp
{
	public class UserApp
	{
		public static class SharedVars
		{
			public static int First = 1;
			public static uint Second = 2;
			public static byte[] Third = { 100, 101, 102 };
		}

		public static void MainX()
		{
			Debug.Print(Resources.GetString(Resources.StringResources.String1));
		}
	}
}
