<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<?xml-stylesheet type="text/xsl" href="is.xsl" ?>
<!DOCTYPE msi [
   <!ELEMENT msi   (summary,table*)>
   <!ATTLIST msi version    CDATA #REQUIRED>
   <!ATTLIST msi xmlns:dt   CDATA #IMPLIED
                 codepage   CDATA #IMPLIED
                 compression (MSZIP|LZX|none) "LZX">
   
   <!ELEMENT summary       (codepage?,title?,subject?,author?,keywords?,comments?,
                            template,lastauthor?,revnumber,lastprinted?,
                            createdtm?,lastsavedtm?,pagecount,wordcount,
                            charcount?,appname?,security?)>
                            
   <!ELEMENT codepage      (#PCDATA)>
   <!ELEMENT title         (#PCDATA)>
   <!ELEMENT subject       (#PCDATA)>
   <!ELEMENT author        (#PCDATA)>
   <!ELEMENT keywords      (#PCDATA)>
   <!ELEMENT comments      (#PCDATA)>
   <!ELEMENT template      (#PCDATA)>
   <!ELEMENT lastauthor    (#PCDATA)>
   <!ELEMENT revnumber     (#PCDATA)>
   <!ELEMENT lastprinted   (#PCDATA)>
   <!ELEMENT createdtm     (#PCDATA)>
   <!ELEMENT lastsavedtm   (#PCDATA)>
   <!ELEMENT pagecount     (#PCDATA)>
   <!ELEMENT wordcount     (#PCDATA)>
   <!ELEMENT charcount     (#PCDATA)>
   <!ELEMENT appname       (#PCDATA)>
   <!ELEMENT security      (#PCDATA)>                            
                                
   <!ELEMENT table         (col+,row*)>
   <!ATTLIST table
                name        CDATA #REQUIRED>

   <!ELEMENT col           (#PCDATA)>
   <!ATTLIST col
                 key       (yes|no) #IMPLIED
                 def       CDATA #IMPLIED>
                 
   <!ELEMENT row            (td+)>
   
   <!ELEMENT td             (#PCDATA)>
   <!ATTLIST td
                 href       CDATA #IMPLIED
                 dt:dt     (string|bin.base64) #IMPLIED
                 md5        CDATA #IMPLIED>
]>
<msi version="2.0" xmlns:dt="urn:schemas-microsoft-com:datatypes" codepage="65001">
	
	<summary>
		<codepage>1252</codepage>
		<title>Installation Database</title>
		<subject>eMote</subject>
		<author>##ID_STRING2##</author>
		<keywords>Installer,MSI,Database</keywords>
		<comments>Contact:  Your local administrator</comments>
		<template>Intel;1033</template>
		<lastauthor>Administrator</lastauthor>
		<revnumber>{126CB84A-9316-4F7C-B488-B9E706DD87BE}</revnumber>
		<lastprinted/>
		<createdtm>06/21/1999 08:00</createdtm>
		<lastsavedtm>07/14/2000 11:50</lastsavedtm>
		<pagecount>200</pagecount>
		<wordcount>0</wordcount>
		<charcount/>
		<appname>InstallShield Express</appname>
		<security>1</security>
	</summary>
	
	<table name="ActionText">
		<col key="yes" def="s72">Action</col>
		<col def="L64">Description</col>
		<col def="L128">Template</col>
		<row><td>Advertise</td><td>##IDS_ACTIONTEXT_Advertising##</td><td/></row>
		<row><td>AllocateRegistrySpace</td><td>##IDS_ACTIONTEXT_AllocatingRegistry##</td><td>##IDS_ACTIONTEXT_FreeSpace##</td></row>
		<row><td>AppSearch</td><td>##IDS_ACTIONTEXT_SearchInstalled##</td><td>##IDS_ACTIONTEXT_PropertySignature##</td></row>
		<row><td>BindImage</td><td>##IDS_ACTIONTEXT_BindingExes##</td><td>##IDS_ACTIONTEXT_File##</td></row>
		<row><td>CCPSearch</td><td>##IDS_ACTIONTEXT_UnregisterModules##</td><td/></row>
		<row><td>CostFinalize</td><td>##IDS_ACTIONTEXT_ComputingSpace3##</td><td/></row>
		<row><td>CostInitialize</td><td>##IDS_ACTIONTEXT_ComputingSpace##</td><td/></row>
		<row><td>CreateFolders</td><td>##IDS_ACTIONTEXT_CreatingFolders##</td><td>##IDS_ACTIONTEXT_Folder##</td></row>
		<row><td>CreateShortcuts</td><td>##IDS_ACTIONTEXT_CreatingShortcuts##</td><td>##IDS_ACTIONTEXT_Shortcut##</td></row>
		<row><td>DeleteServices</td><td>##IDS_ACTIONTEXT_DeletingServices##</td><td>##IDS_ACTIONTEXT_Service##</td></row>
		<row><td>DuplicateFiles</td><td>##IDS_ACTIONTEXT_CreatingDuplicate##</td><td>##IDS_ACTIONTEXT_FileDirectorySize##</td></row>
		<row><td>FileCost</td><td>##IDS_ACTIONTEXT_ComputingSpace2##</td><td/></row>
		<row><td>FindRelatedProducts</td><td>##IDS_ACTIONTEXT_SearchForRelated##</td><td>##IDS_ACTIONTEXT_FoundApp##</td></row>
		<row><td>GenerateScript</td><td>##IDS_ACTIONTEXT_GeneratingScript##</td><td>##IDS_ACTIONTEXT_1##</td></row>
		<row><td>ISLockPermissionsCost</td><td>##IDS_ACTIONTEXT_ISLockPermissionsCost##</td><td/></row>
		<row><td>ISLockPermissionsInstall</td><td>##IDS_ACTIONTEXT_ISLockPermissionsInstall##</td><td/></row>
		<row><td>InstallAdminPackage</td><td>##IDS_ACTIONTEXT_CopyingNetworkFiles##</td><td>##IDS_ACTIONTEXT_FileDirSize##</td></row>
		<row><td>InstallFiles</td><td>##IDS_ACTIONTEXT_CopyingNewFiles##</td><td>##IDS_ACTIONTEXT_FileDirSize2##</td></row>
		<row><td>InstallODBC</td><td>##IDS_ACTIONTEXT_InstallODBC##</td><td/></row>
		<row><td>InstallSFPCatalogFile</td><td>##IDS_ACTIONTEXT_InstallingSystemCatalog##</td><td>##IDS_ACTIONTEXT_FileDependencies##</td></row>
		<row><td>InstallServices</td><td>##IDS_ACTIONTEXT_InstallServices##</td><td>##IDS_ACTIONTEXT_Service2##</td></row>
		<row><td>InstallValidate</td><td>##IDS_ACTIONTEXT_Validating##</td><td/></row>
		<row><td>LaunchConditions</td><td>##IDS_ACTIONTEXT_EvaluateLaunchConditions##</td><td/></row>
		<row><td>MigrateFeatureStates</td><td>##IDS_ACTIONTEXT_MigratingFeatureStates##</td><td>##IDS_ACTIONTEXT_Application##</td></row>
		<row><td>MoveFiles</td><td>##IDS_ACTIONTEXT_MovingFiles##</td><td>##IDS_ACTIONTEXT_FileDirSize3##</td></row>
		<row><td>PatchFiles</td><td>##IDS_ACTIONTEXT_PatchingFiles##</td><td>##IDS_ACTIONTEXT_FileDirSize4##</td></row>
		<row><td>ProcessComponents</td><td>##IDS_ACTIONTEXT_UpdateComponentRegistration##</td><td/></row>
		<row><td>PublishComponents</td><td>##IDS_ACTIONTEXT_PublishingQualifiedComponents##</td><td>##IDS_ACTIONTEXT_ComponentIDQualifier##</td></row>
		<row><td>PublishFeatures</td><td>##IDS_ACTIONTEXT_PublishProductFeatures##</td><td>##IDS_ACTIONTEXT_FeatureColon##</td></row>
		<row><td>PublishProduct</td><td>##IDS_ACTIONTEXT_PublishProductInfo##</td><td/></row>
		<row><td>RMCCPSearch</td><td>##IDS_ACTIONTEXT_SearchingQualifyingProducts##</td><td/></row>
		<row><td>RegisterClassInfo</td><td>##IDS_ACTIONTEXT_RegisterClassServer##</td><td>##IDS_ACTIONTEXT_ClassId##</td></row>
		<row><td>RegisterComPlus</td><td>##IDS_ACTIONTEXT_RegisteringComPlus##</td><td>##IDS_ACTIONTEXT_AppIdAppTypeRSN##</td></row>
		<row><td>RegisterExtensionInfo</td><td>##IDS_ACTIONTEXT_RegisterExtensionServers##</td><td>##IDS_ACTIONTEXT_Extension2##</td></row>
		<row><td>RegisterFonts</td><td>##IDS_ACTIONTEXT_RegisterFonts##</td><td>##IDS_ACTIONTEXT_Font##</td></row>
		<row><td>RegisterMIMEInfo</td><td>##IDS_ACTIONTEXT_RegisterMimeInfo##</td><td>##IDS_ACTIONTEXT_ContentTypeExtension##</td></row>
		<row><td>RegisterProduct</td><td>##IDS_ACTIONTEXT_RegisteringProduct##</td><td>##IDS_ACTIONTEXT_1b##</td></row>
		<row><td>RegisterProgIdInfo</td><td>##IDS_ACTIONTEXT_RegisteringProgIdentifiers##</td><td>##IDS_ACTIONTEXT_ProgID2##</td></row>
		<row><td>RegisterTypeLibraries</td><td>##IDS_ACTIONTEXT_RegisterTypeLibs##</td><td>##IDS_ACTIONTEXT_LibId##</td></row>
		<row><td>RegisterUser</td><td>##IDS_ACTIONTEXT_RegUser##</td><td>##IDS_ACTIONTEXT_1c##</td></row>
		<row><td>RemoveDuplicateFiles</td><td>##IDS_ACTIONTEXT_RemovingDuplicates##</td><td>##IDS_ACTIONTEXT_FileDir##</td></row>
		<row><td>RemoveEnvironmentStrings</td><td>##IDS_ACTIONTEXT_UpdateEnvironmentStrings##</td><td>##IDS_ACTIONTEXT_NameValueAction2##</td></row>
		<row><td>RemoveExistingProducts</td><td>##IDS_ACTIONTEXT_RemoveApps##</td><td>##IDS_ACTIONTEXT_AppCommandLine##</td></row>
		<row><td>RemoveFiles</td><td>##IDS_ACTIONTEXT_RemovingFiles##</td><td>##IDS_ACTIONTEXT_FileDir2##</td></row>
		<row><td>RemoveFolders</td><td>##IDS_ACTIONTEXT_RemovingFolders##</td><td>##IDS_ACTIONTEXT_Folder1##</td></row>
		<row><td>RemoveIniValues</td><td>##IDS_ACTIONTEXT_RemovingIni##</td><td>##IDS_ACTIONTEXT_FileSectionKeyValue##</td></row>
		<row><td>RemoveODBC</td><td>##IDS_ACTIONTEXT_RemovingODBC##</td><td/></row>
		<row><td>RemoveRegistryValues</td><td>##IDS_ACTIONTEXT_RemovingRegistry##</td><td>##IDS_ACTIONTEXT_KeyName##</td></row>
		<row><td>RemoveShortcuts</td><td>##IDS_ACTIONTEXT_RemovingShortcuts##</td><td>##IDS_ACTIONTEXT_Shortcut1##</td></row>
		<row><td>Rollback</td><td>##IDS_ACTIONTEXT_RollingBack##</td><td>##IDS_ACTIONTEXT_1d##</td></row>
		<row><td>RollbackCleanup</td><td>##IDS_ACTIONTEXT_RemovingBackup##</td><td>##IDS_ACTIONTEXT_File2##</td></row>
		<row><td>SelfRegModules</td><td>##IDS_ACTIONTEXT_RegisteringModules##</td><td>##IDS_ACTIONTEXT_FileFolder##</td></row>
		<row><td>SelfUnregModules</td><td>##IDS_ACTIONTEXT_UnregisterModules##</td><td>##IDS_ACTIONTEXT_FileFolder2##</td></row>
		<row><td>SetODBCFolders</td><td>##IDS_ACTIONTEXT_InitializeODBCDirs##</td><td/></row>
		<row><td>StartServices</td><td>##IDS_ACTIONTEXT_StartingServices##</td><td>##IDS_ACTIONTEXT_Service3##</td></row>
		<row><td>StopServices</td><td>##IDS_ACTIONTEXT_StoppingServices##</td><td>##IDS_ACTIONTEXT_Service4##</td></row>
		<row><td>UnmoveFiles</td><td>##IDS_ACTIONTEXT_RemovingMoved##</td><td>##IDS_ACTIONTEXT_FileDir3##</td></row>
		<row><td>UnpublishComponents</td><td>##IDS_ACTIONTEXT_UnpublishQualified##</td><td>##IDS_ACTIONTEXT_ComponentIdQualifier2##</td></row>
		<row><td>UnpublishFeatures</td><td>##IDS_ACTIONTEXT_UnpublishProductFeatures##</td><td>##IDS_ACTIONTEXT_Feature##</td></row>
		<row><td>UnpublishProduct</td><td>##IDS_ACTIONTEXT_UnpublishingProductInfo##</td><td/></row>
		<row><td>UnregisterClassInfo</td><td>##IDS_ACTIONTEXT_UnregisterClassServers##</td><td>##IDS_ACTIONTEXT_ClsID##</td></row>
		<row><td>UnregisterComPlus</td><td>##IDS_ACTIONTEXT_UnregisteringComPlus##</td><td>##IDS_ACTIONTEXT_AppId##</td></row>
		<row><td>UnregisterExtensionInfo</td><td>##IDS_ACTIONTEXT_UnregisterExtensionServers##</td><td>##IDS_ACTIONTEXT_Extension##</td></row>
		<row><td>UnregisterFonts</td><td>##IDS_ACTIONTEXT_UnregisteringFonts##</td><td>##IDS_ACTIONTEXT_Font2##</td></row>
		<row><td>UnregisterMIMEInfo</td><td>##IDS_ACTIONTEXT_UnregisteringMimeInfo##</td><td>##IDS_ACTIONTEXT_ContentTypeExtension2##</td></row>
		<row><td>UnregisterProgIdInfo</td><td>##IDS_ACTIONTEXT_UnregisteringProgramIds##</td><td>##IDS_ACTIONTEXT_ProgID##</td></row>
		<row><td>UnregisterTypeLibraries</td><td>##IDS_ACTIONTEXT_UnregTypeLibs##</td><td>##IDS_ACTIONTEXT_Libid2##</td></row>
		<row><td>WriteEnvironmentStrings</td><td>##IDS_ACTIONTEXT_EnvironmentStrings##</td><td>##IDS_ACTIONTEXT_NameValueAction##</td></row>
		<row><td>WriteIniValues</td><td>##IDS_ACTIONTEXT_WritingINI##</td><td>##IDS_ACTIONTEXT_FileSectionKeyValue2##</td></row>
		<row><td>WriteRegistryValues</td><td>##IDS_ACTIONTEXT_WritingRegistry##</td><td>##IDS_ACTIONTEXT_KeyNameValue##</td></row>
	</table>

	<table name="AdminExecuteSequence">
		<col key="yes" def="s72">Action</col>
		<col def="S255">Condition</col>
		<col def="I2">Sequence</col>
		<col def="S255">ISComments</col>
		<col def="I4">ISAttributes</col>
		<row><td>CostFinalize</td><td/><td>1000</td><td>CostFinalize</td><td/></row>
		<row><td>CostInitialize</td><td/><td>800</td><td>CostInitialize</td><td/></row>
		<row><td>FileCost</td><td/><td>900</td><td>FileCost</td><td/></row>
		<row><td>InstallAdminPackage</td><td/><td>3900</td><td>InstallAdminPackage</td><td/></row>
		<row><td>InstallFiles</td><td/><td>4000</td><td>InstallFiles</td><td/></row>
		<row><td>InstallFinalize</td><td/><td>6600</td><td>InstallFinalize</td><td/></row>
		<row><td>InstallInitialize</td><td/><td>1500</td><td>InstallInitialize</td><td/></row>
		<row><td>InstallValidate</td><td/><td>1400</td><td>InstallValidate</td><td/></row>
		<row><td>ScheduleReboot</td><td>ISSCHEDULEREBOOT</td><td>4010</td><td>ScheduleReboot</td><td/></row>
	</table>

	<table name="AdminUISequence">
		<col key="yes" def="s72">Action</col>
		<col def="S255">Condition</col>
		<col def="I2">Sequence</col>
		<col def="S255">ISComments</col>
		<col def="I4">ISAttributes</col>
		<row><td>AdminWelcome</td><td/><td>1010</td><td>AdminWelcome</td><td/></row>
		<row><td>CostFinalize</td><td/><td>1000</td><td>CostFinalize</td><td/></row>
		<row><td>CostInitialize</td><td/><td>800</td><td>CostInitialize</td><td/></row>
		<row><td>ExecuteAction</td><td/><td>1300</td><td>ExecuteAction</td><td/></row>
		<row><td>FileCost</td><td/><td>900</td><td>FileCost</td><td/></row>
		<row><td>SetupCompleteError</td><td/><td>-3</td><td>SetupCompleteError</td><td/></row>
		<row><td>SetupCompleteSuccess</td><td/><td>-1</td><td>SetupCompleteSuccess</td><td/></row>
		<row><td>SetupInitialization</td><td/><td>50</td><td>SetupInitialization</td><td/></row>
		<row><td>SetupInterrupted</td><td/><td>-2</td><td>SetupInterrupted</td><td/></row>
		<row><td>SetupProgress</td><td/><td>1020</td><td>SetupProgress</td><td/></row>
	</table>

	<table name="AdvtExecuteSequence">
		<col key="yes" def="s72">Action</col>
		<col def="S255">Condition</col>
		<col def="I2">Sequence</col>
		<col def="S255">ISComments</col>
		<col def="I4">ISAttributes</col>
		<row><td>CostFinalize</td><td/><td>1000</td><td>CostFinalize</td><td/></row>
		<row><td>CostInitialize</td><td/><td>800</td><td>CostInitialize</td><td/></row>
		<row><td>CreateShortcuts</td><td/><td>4500</td><td>CreateShortcuts</td><td/></row>
		<row><td>InstallFinalize</td><td/><td>6600</td><td>InstallFinalize</td><td/></row>
		<row><td>InstallInitialize</td><td/><td>1500</td><td>InstallInitialize</td><td/></row>
		<row><td>InstallValidate</td><td/><td>1400</td><td>InstallValidate</td><td/></row>
		<row><td>MsiPublishAssemblies</td><td/><td>6250</td><td>MsiPublishAssemblies</td><td/></row>
		<row><td>PublishComponents</td><td/><td>6200</td><td>PublishComponents</td><td/></row>
		<row><td>PublishFeatures</td><td/><td>6300</td><td>PublishFeatures</td><td/></row>
		<row><td>PublishProduct</td><td/><td>6400</td><td>PublishProduct</td><td/></row>
		<row><td>RegisterClassInfo</td><td/><td>4600</td><td>RegisterClassInfo</td><td/></row>
		<row><td>RegisterExtensionInfo</td><td/><td>4700</td><td>RegisterExtensionInfo</td><td/></row>
		<row><td>RegisterMIMEInfo</td><td/><td>4900</td><td>RegisterMIMEInfo</td><td/></row>
		<row><td>RegisterProgIdInfo</td><td/><td>4800</td><td>RegisterProgIdInfo</td><td/></row>
		<row><td>RegisterTypeLibraries</td><td/><td>4910</td><td>RegisterTypeLibraries</td><td/></row>
		<row><td>ScheduleReboot</td><td>ISSCHEDULEREBOOT</td><td>6410</td><td>ScheduleReboot</td><td/></row>
	</table>

	<table name="AdvtUISequence">
		<col key="yes" def="s72">Action</col>
		<col def="S255">Condition</col>
		<col def="I2">Sequence</col>
		<col def="S255">ISComments</col>
		<col def="I4">ISAttributes</col>
	</table>

	<table name="AppId">
		<col key="yes" def="s38">AppId</col>
		<col def="S255">RemoteServerName</col>
		<col def="S255">LocalService</col>
		<col def="S255">ServiceParameters</col>
		<col def="S255">DllSurrogate</col>
		<col def="I2">ActivateAtStorage</col>
		<col def="I2">RunAsInteractiveUser</col>
	</table>

	<table name="AppSearch">
		<col key="yes" def="s72">Property</col>
		<col key="yes" def="s72">Signature_</col>
	</table>

	<table name="BBControl">
		<col key="yes" def="s50">Billboard_</col>
		<col key="yes" def="s50">BBControl</col>
		<col def="s50">Type</col>
		<col def="i2">X</col>
		<col def="i2">Y</col>
		<col def="i2">Width</col>
		<col def="i2">Height</col>
		<col def="I4">Attributes</col>
		<col def="L50">Text</col>
	</table>

	<table name="Billboard">
		<col key="yes" def="s50">Billboard</col>
		<col def="s38">Feature_</col>
		<col def="S50">Action</col>
		<col def="I2">Ordering</col>
	</table>

	<table name="Binary">
		<col key="yes" def="s72">Name</col>
		<col def="V0">Data</col>
		<col def="S255">ISBuildSourcePath</col>
		<row><td>ISExpHlp.dll</td><td/><td>&lt;ISRedistPlatformDependentFolder&gt;\ISExpHlp.dll</td></row>
		<row><td>ISSELFREG.DLL</td><td/><td>&lt;ISRedistPlatformDependentFolder&gt;\isregsvr.dll</td></row>
		<row><td>NewBinary1</td><td/><td>&lt;ISProductFolder&gt;\Support\Themes\InstallShield Blue Theme\banner.jpg</td></row>
		<row><td>NewBinary10</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\CompleteSetupIco.ibd</td></row>
		<row><td>NewBinary11</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\CustomSetupIco.ibd</td></row>
		<row><td>NewBinary12</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\DestIcon.ibd</td></row>
		<row><td>NewBinary13</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\NetworkInstall.ico</td></row>
		<row><td>NewBinary14</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\DontInstall.ico</td></row>
		<row><td>NewBinary15</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\Install.ico</td></row>
		<row><td>NewBinary16</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\InstallFirstUse.ico</td></row>
		<row><td>NewBinary17</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\InstallPartial.ico</td></row>
		<row><td>NewBinary18</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\InstallStateMenu.ico</td></row>
		<row><td>NewBinary2</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\New.ibd</td></row>
		<row><td>NewBinary3</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\Up.ibd</td></row>
		<row><td>NewBinary4</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\WarningIcon.ibd</td></row>
		<row><td>NewBinary5</td><td/><td>&lt;ISProductFolder&gt;\Support\Themes\InstallShield Blue Theme\welcome.jpg</td></row>
		<row><td>NewBinary6</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\CustomSetupIco.ibd</td></row>
		<row><td>NewBinary7</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\ReinstIco.ibd</td></row>
		<row><td>NewBinary8</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\RemoveIco.ibd</td></row>
		<row><td>NewBinary9</td><td/><td>&lt;ISProductFolder&gt;\Redist\Language Independent\OS Independent\SetupIcon.ibd</td></row>
		<row><td>SetAllUsers.dll</td><td/><td>&lt;ISRedistPlatformDependentFolder&gt;\SetAllUsers.dll</td></row>
	</table>

	<table name="BindImage">
		<col key="yes" def="s72">File_</col>
		<col def="S255">Path</col>
	</table>

	<table name="CCPSearch">
		<col key="yes" def="s72">Signature_</col>
	</table>

	<table name="CheckBox">
		<col key="yes" def="s72">Property</col>
		<col def="S64">Value</col>
		<row><td>ISCHECKFORPRODUCTUPDATES</td><td>1</td></row>
		<row><td>LAUNCHPROGRAM</td><td>1</td></row>
		<row><td>LAUNCHREADME</td><td>1</td></row>
	</table>

	<table name="Class">
		<col key="yes" def="s38">CLSID</col>
		<col key="yes" def="s32">Context</col>
		<col key="yes" def="s72">Component_</col>
		<col def="S255">ProgId_Default</col>
		<col def="L255">Description</col>
		<col def="S38">AppId_</col>
		<col def="S255">FileTypeMask</col>
		<col def="S72">Icon_</col>
		<col def="I2">IconIndex</col>
		<col def="S32">DefInprocHandler</col>
		<col def="S255">Argument</col>
		<col def="s38">Feature_</col>
		<col def="I2">Attributes</col>
	</table>

	<table name="ComboBox">
		<col key="yes" def="s72">Property</col>
		<col key="yes" def="i2">Order</col>
		<col def="s64">Value</col>
		<col def="L64">Text</col>
	</table>

	<table name="CompLocator">
		<col key="yes" def="s72">Signature_</col>
		<col def="s38">ComponentId</col>
		<col def="I2">Type</col>
	</table>

	<table name="Complus">
		<col key="yes" def="s72">Component_</col>
		<col key="yes" def="I2">ExpType</col>
	</table>

	<table name="Component">
		<col key="yes" def="s72">Component</col>
		<col def="S38">ComponentId</col>
		<col def="s72">Directory_</col>
		<col def="i2">Attributes</col>
		<col def="S255">Condition</col>
		<col def="S72">KeyPath</col>
		<col def="I4">ISAttributes</col>
		<col def="S255">ISComments</col>
		<col def="S255">ISScanAtBuildFile</col>
		<col def="S255">ISRegFileToMergeAtBuild</col>
		<col def="S0">ISDotNetInstallerArgsInstall</col>
		<col def="S0">ISDotNetInstallerArgsCommit</col>
		<col def="S0">ISDotNetInstallerArgsUninstall</col>
		<col def="S0">ISDotNetInstallerArgsRollback</col>
		<row><td>ISX_DEFAULTCOMPONENT</td><td>{F14556BC-31C9-4CEB-8109-1E56B05B1048}</td><td>EMOTE_.NOW</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT1</td><td>{307C63CC-7138-4776-920E-16EF582B289C}</td><td>CLRANDBOOTER</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT10</td><td>{F8A48979-2174-4BB0-8C3A-11D66F907A4B}</td><td>BE2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT100</td><td>{A9626084-D0BB-4C96-9917-88BB83E5705F}</td><td>SAMRAKSH_EMOTE_NET2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT101</td><td>{769F1D38-EA96-4D18-870C-EE6BBAE2477F}</td><td>BE25</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT102</td><td>{8FADB587-90FA-48B4-8094-8447CD81EE51}</td><td>LE25</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT103</td><td>{917E159C-B150-44DA-9073-56ED0A77FE94}</td><td>SAMRAKSH_EMOTE_REALTIME2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT104</td><td>{08F54719-FBA2-47F3-B432-37A023166137}</td><td>BE26</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT105</td><td>{36CCFE42-834F-4CE8-9E60-FC94C5C8940F}</td><td>LE26</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT106</td><td>{1B79AA5F-A96C-4504-B827-2DB2311CBDF5}</td><td>SIMPLECSMA1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT107</td><td>{C043FAB1-BC81-43C0-B684-721C455E0369}</td><td>BIN3</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT108</td><td>{EB4412F5-84A4-4C09-ABFE-6C88DD206B21}</td><td>DEBUG3</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT109</td><td>{F23DF6FA-6A5A-4101-AA4C-2BDEFECDABC2}</td><td>BE27</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT11</td><td>{61A51F86-EF45-48AF-B00D-B1C47C4F6B17}</td><td>LE2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT110</td><td>{217B9CA0-C1B8-42A6-B399-E88115167F09}</td><td>LE27</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT111</td><td>{CD7060E4-84D9-425F-9F37-D4282035DD2F}</td><td>RELEASE</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT112</td><td>{F49DE5D8-9EDF-48ED-9C77-BFC3DC51CFE0}</td><td>OBJ2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT113</td><td>{FA2BEEF8-359A-4C7F-A0BD-8EA6FA73AE96}</td><td>DEBUG4</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT114</td><td>{DD3E3F96-3B30-4CDD-A54C-89BE9B7E0D6A}</td><td>BE28</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT115</td><td>{92CF21A4-3AB2-49E2-9DFF-80411A8D7EA5}</td><td>LE28</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT116</td><td>{82257324-1F70-48BF-92AC-8190BBE951F0}</td><td>TEMPPE2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT117</td><td>{A42A58FE-4322-44E0-B940-4FB96856F424}</td><td>PROPERTIES2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT118</td><td>{9A05C656-5377-4207-B6DC-2A29A0B93F89}</td><td>GENERAL</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT119</td><td>{B964565C-6DC4-414A-9EEF-B59C2CCCA82A}</td><td>BITCONVERTER</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT12</td><td>{A6C903E5-4D00-4B1D-9335-DA418A61E5E7}</td><td>SAMRAKSH_EMOTE_DSP</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT120</td><td>{CEFA4619-3D0F-4594-A8F1-77EE7C6A1734}</td><td>BIN4</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT121</td><td>{19B4803F-029F-4061-82C5-56E22410F120}</td><td>BE29</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT122</td><td>{15778274-E4E9-4DB1-8E04-1CCAAE50A236}</td><td>LE29</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT123</td><td>{0D3D95EA-4DA2-46AC-8309-7462976B8F6C}</td><td>BITCONVERTER1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT124</td><td>{4904C764-65E4-4DA4-9184-5ADDFC9BBF4D}</td><td>BIN5</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT125</td><td>{535A70C6-9E0B-46B0-9762-5576348739D8}</td><td>RELEASE1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT126</td><td>{4983A5C2-FAA9-4D74-B0CA-DD7F7F4D668A}</td><td>OBJ3</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT127</td><td>{6B16AB41-8BEC-4691-B67D-926E043706DE}</td><td>DEBUG5</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT128</td><td>{A2B0E05B-C51F-4837-86CE-7561401C6237}</td><td>BE30</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT129</td><td>{F576639D-3F4A-42B1-84EA-EB8448F55610}</td><td>LE30</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT13</td><td>{177296A8-1B50-41E9-8A35-188C8591334A}</td><td>BE3</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT130</td><td>{3ABD9BDD-9342-41AF-AA13-EBA8B1F37B8C}</td><td>TEMPPE3</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT131</td><td>{AC36D89A-0A5E-4036-AC55-F30C17BC1F82}</td><td>PROPERTIES3</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT132</td><td>{EAE00740-5F0C-47A8-8EB4-672207617FE7}</td><td>SERIALCOMM</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT133</td><td>{7658901C-944C-4713-BCC1-A80C9CCB21A6}</td><td>BIN6</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT134</td><td>{BF5B2F63-79D7-471E-8F5D-2451807FA843}</td><td>BE31</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT135</td><td>{BFB19840-2224-49EE-B8B7-C967763AA0E9}</td><td>LE31</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT136</td><td>{83D32699-C988-43F6-9C02-E8C049471987}</td><td>SERIALCOMM1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT137</td><td>{FCD2F354-22A9-4987-A23D-DA320FFFEDEA}</td><td>OBJ4</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT138</td><td>{D187576F-BEAB-48C5-974C-A36B14D74E84}</td><td>DEBUG6</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT139</td><td>{FF02DA9F-ED5B-47D0-BC1C-A4DADF5FBC91}</td><td>BE32</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT14</td><td>{DE7CE544-EAB0-478D-9D0E-6626344BF3EB}</td><td>LE3</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT140</td><td>{85AEBEB3-7DC8-40B3-9B8F-A2D6FEA98622}</td><td>LE32</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT141</td><td>{BDE55165-06CC-4B42-9755-25240903D4D1}</td><td>TEMPPE4</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT142</td><td>{ADF80368-F10E-4B43-BB1D-A7D104E204AC}</td><td>PROPERTIES4</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT143</td><td>{2A241714-1900-4623-ABDA-4EC082EEA9A1}</td><td>SIMPLETIMER</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT144</td><td>{347A84C4-A43D-4303-8B49-DB8D3C677625}</td><td>BIN7</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT145</td><td>{E0985F1D-2B03-45FD-9CA5-D49F2950D6DA}</td><td>BE33</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT146</td><td>{734EA36D-C261-47E4-A4C7-9D149D319F58}</td><td>LE33</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT147</td><td>{53579E65-4DD8-4ED8-8ADE-697CCC2AAF2D}</td><td>SIMPLETIMER1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT148</td><td>{3D2D11B5-4B41-4260-AE15-0340716A4C80}</td><td>OBJ5</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT149</td><td>{0A97C59C-6D8C-4FC5-867F-77CF881E3689}</td><td>DEBUG7</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT15</td><td>{FF050704-D1AB-4DE2-B616-D359B5B6F3BC}</td><td>SAMRAKSH_EMOTE_KIWI</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT150</td><td>{ADE42DBA-47BF-4341-8719-C47DEA43079A}</td><td>BE34</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT151</td><td>{8534F35C-E030-44EF-8379-B8EA6044238D}</td><td>LE34</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT152</td><td>{F7212D7D-B0FF-4577-BCB3-14A2B6A993C6}</td><td>TEMPPE5</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT153</td><td>{3258B850-E17D-4289-A457-E6DC95422C1C}</td><td>PROPERTIES5</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT154</td><td>{15EDFD81-0BAF-46BD-B373-6E2EB984A210}</td><td>SQRT</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT155</td><td>{2314C502-0F40-493C-B451-B52295096490}</td><td>BIN8</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT156</td><td>{5CF0D4D4-8EF6-4145-A8C0-855F6DFE089D}</td><td>BE35</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT157</td><td>{89CB2164-8691-4BB1-8C0C-4B2A3FC0EF06}</td><td>LE35</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT158</td><td>{B6BA15F5-6344-4D09-9C1D-B2828436D916}</td><td>SQRT1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT159</td><td>{8FAB8276-880D-4BC1-A0BE-0BFC8A10FB22}</td><td>OBJ6</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT16</td><td>{AD7743DF-BE58-4F78-81CB-1D08BD6D0F40}</td><td>BE4</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT160</td><td>{D7B2899A-CACE-4E2C-B798-FF347A685FB3}</td><td>DEBUG8</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT161</td><td>{29673AD9-0007-4680-886C-18B39E75E32E}</td><td>BE36</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT162</td><td>{E9FE161A-67A5-47BA-935B-B2734EA78B1D}</td><td>LE36</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT163</td><td>{E825512E-1654-4794-B8AB-1EA8D4B8C56F}</td><td>TEMPPE6</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT164</td><td>{9CFF1509-2EF2-45C3-BA4D-0784EDD36144}</td><td>PROPERTIES6</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT165</td><td>{40C4B8CD-E203-4761-82DD-BEE3692CA540}</td><td>VERSIONINFO1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT166</td><td>{9C6DE2FD-CB6C-4125-8AE4-9137BCEB5684}</td><td>BIN9</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT167</td><td>{0EADF7B2-FAC7-4AEF-B0C2-240B2E3F737E}</td><td>BE37</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT168</td><td>{094BFC58-D493-403F-BDBD-EB081626D9F8}</td><td>LE37</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT169</td><td>{3C311FDD-AC27-4E79-94C4-6279B3B22D5B}</td><td>VERSIONINFO2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT17</td><td>{72B81B93-E324-4C53-A89B-A95A2178D43B}</td><td>LE4</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT170</td><td>{08ABFE2A-FC74-4C48-B0E4-6D8E893FC4E4}</td><td>BIN10</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT171</td><td>{5FE78026-10B9-4129-AD56-49DD4FAFAB6E}</td><td>DEBUG9</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT172</td><td>{6B4FA517-E267-4B17-9F37-7C8F700133BE}</td><td>OBJ7</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT173</td><td>{B3018CDA-8136-498C-836B-686C73F73812}</td><td>DEBUG10</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT174</td><td>{94BD78E0-8D78-4BD7-A958-ABE659816E69}</td><td>BE38</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT175</td><td>{F1802E45-1243-4FC1-8C2B-1D269CE96581}</td><td>LE38</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT176</td><td>{10DF349E-9AC4-43A2-8EB9-422322702827}</td><td>TEMPPE7</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT177</td><td>{97A4C0E3-63C9-4259-8656-24EA665009F5}</td><td>PROPERTIES7</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT18</td><td>{0D7E2AA4-BACF-4C56-AA08-DDC3D8BE9853}</td><td>SAMRAKSH_EMOTE_NET</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT19</td><td>{BFA1DDD3-A758-424A-887D-F2FADE3836E5}</td><td>BE5</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT2</td><td>{0CBF6FB8-AB2C-4FDA-8806-55A980C9B675}</td><td>EMOTE_TINYCLR_V14.HEX</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT20</td><td>{3E02BE5D-F74F-4EF0-A392-9EB1191D81EE}</td><td>LE5</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT21</td><td>{92B37AF8-580E-4789-8D99-280557446284}</td><td>SAMRAKSH_EMOTE_REALTIME</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT22</td><td>{7FB25530-4D9B-4B45-B04D-1ED620D1F494}</td><td>BE6</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT23</td><td>{4C6670C6-368D-4721-B8F1-2074DF92F670}</td><td>LE6</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT24</td><td>{9E4ABD5C-BFF1-4C06-B384-12C6A537341E}</td><td>UTILITY_CLASSES</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT25</td><td>{0B9ED260-9EDB-439B-AC09-954C999D4B64}</td><td>DOTNOW</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT26</td><td>{761C92CB-2E40-4226-8342-376CDEE99E94}</td><td>ENHANCEDEMOTELCD</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT27</td><td>{A1D47D2C-4D71-4787-AD1C-CAD56251FA83}</td><td>BIN</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT28</td><td>{0A62307B-940B-45FD-89A2-4935E529838F}</td><td>BE7</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT29</td><td>{11DB7A5F-936B-4213-8218-C3AF0F220CF6}</td><td>LE7</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT3</td><td>{258BB15A-D30A-4A14-9EDE-E246D39CFE04}</td><td>SAMRAKSH_EMOTE</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT30</td><td>{7C739D5F-E8EB-49B2-A429-3691B8BB8DE8}</td><td>EMOTE_.NOW_RELEASE_4.3.0.14</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT31</td><td>{7B6DAEB9-C222-435A-96D6-A8C9965751B6}</td><td>CLRANDBOOTER1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT32</td><td>{FEB43C6D-55A7-4F5F-AB00-F3B9C3C34FD1}</td><td>EMOTE_TINYCLR_V14.HEX1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT33</td><td>{9A1488B4-6AB4-4402-B353-55178333102D}</td><td>SAMRAKSH_EMOTE1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT34</td><td>{64155621-3B99-4716-960C-89BA41616E2C}</td><td>BE8</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT35</td><td>{0D452310-0ADF-46CA-B8DB-3C886D361CCD}</td><td>LE8</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT36</td><td>{35F740D8-12F4-4640-AC32-AEE0CB66A3D9}</td><td>SAMRAKSH_EMOTE_ADAPT1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT37</td><td>{D73736C9-4717-439F-B9CB-145522CAF2D4}</td><td>BE9</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT38</td><td>{0B00D6F2-C0C8-463B-8B1F-06FD3A037598}</td><td>LE9</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT39</td><td>{E7E45ECF-7D90-4207-92CD-30E21695AAE4}</td><td>SAMRAKSH_EMOTE_DOTNOW1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT4</td><td>{B4D937C4-7487-4728-81D3-D188B8D263C7}</td><td>BE</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT40</td><td>{8C37983A-B640-4C99-B938-C50EF1510BF9}</td><td>BE10</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT41</td><td>{10F19E68-4762-4EB0-A786-4802555AED73}</td><td>LE10</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT42</td><td>{4EA89836-F443-4283-94AF-C642338CF0CB}</td><td>SAMRAKSH_EMOTE_DSP1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT43</td><td>{C43917B4-1EFE-44F5-9A8F-85E218B01CBF}</td><td>BE11</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT44</td><td>{2ECFDF84-EA96-4796-A1D3-3AACB2B8C0DA}</td><td>LE11</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT45</td><td>{ABA6F151-E0D9-4FFB-BD14-AEFEF23397DF}</td><td>SAMRAKSH_EMOTE_KIWI1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT46</td><td>{15791969-9528-4F97-91E0-8601C7060FC6}</td><td>BE12</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT47</td><td>{A6E7F8D5-DC8D-4782-A592-85188D7B4FA5}</td><td>LE12</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT48</td><td>{93CEED38-A652-41E7-9C52-7AE560AF7960}</td><td>SAMRAKSH_EMOTE_NET1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT49</td><td>{77F9D4D6-DA9B-43F0-B90B-0327975F7F7B}</td><td>BE13</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT5</td><td>{21DC9844-5470-4701-BCD9-2316A3DB1585}</td><td>LE</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT50</td><td>{6EF98053-6AA2-4ECA-81D5-43EA33B82021}</td><td>LE13</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT51</td><td>{099F7614-5854-4C6A-9341-6AC8EF10A1F2}</td><td>SAMRAKSH_EMOTE_REALTIME1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT52</td><td>{A4751511-2FEC-4023-96BF-D1E83473B5D9}</td><td>BE14</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT53</td><td>{2DFA6D55-37CF-4FEA-971A-F57CEAA1677C}</td><td>LE14</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT54</td><td>{432BFFF7-B4D0-42A8-AF30-21AC7D8A0315}</td><td>ENHANCEDEMOTELCD1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT55</td><td>{59D999C0-FCEC-4EE9-8E01-A5599DCB6611}</td><td>OBJ</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT56</td><td>{361148F8-CAD7-47EB-A77D-C1C84DAFD683}</td><td>DEBUG</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT57</td><td>{8F41F7D2-6518-4E6D-B70B-877FA0E5513B}</td><td>BE15</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT58</td><td>{A5D9628D-A9FF-4ABF-91D9-3D4499714841}</td><td>LE15</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT59</td><td>{3BCD40E9-AEAF-4DD5-9470-4225032AE221}</td><td>TEMPPE</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT6</td><td>{9C39C154-C228-4BC0-BE8E-A8D74EB5642F}</td><td>SAMRAKSH_EMOTE_ADAPT</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT60</td><td>{49C91F49-9F23-4410-A868-6130063DDD31}</td><td>PROPERTIES</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT61</td><td>{50B6BB9A-9E47-4C6A-A882-27037A698E51}</td><td>TESTENHANCEDEMOTELCD</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT62</td><td>{9E6D6B3C-BD47-442C-89EA-1EC9CB1BACB7}</td><td>BIN1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT63</td><td>{1952C0A3-D5CB-4925-8888-065E70161CB1}</td><td>DEBUG1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT64</td><td>{2E8730D5-EB6B-44D4-B987-BECA9F779868}</td><td>BE16</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT65</td><td>{BFF94864-F1BB-4778-B6B4-459FF1EC3899}</td><td>LE16</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT66</td><td>{CD616BFB-0F66-45E0-A038-5F9D69F103F5}</td><td>DOTNETMF_FS_EMULATION</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT67</td><td>{B1231BFF-51DF-4198-8D86-8272FFA87923}</td><td>WINFS</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT68</td><td>{F19560F7-F0BC-49C4-A378-25CC84783D60}</td><td>OBJ1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT69</td><td>{714769E5-A0FE-41E5-8A67-EF672FDE9B6A}</td><td>DEBUG2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT7</td><td>{1D526F56-7952-4A55-9F68-9A12C73663AE}</td><td>BE1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT70</td><td>{D6317FF0-4E20-48A5-B0A0-841CF2731C39}</td><td>BE17</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT71</td><td>{0314D555-E27F-4A21-8B44-7415EC3C12C3}</td><td>LE17</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT72</td><td>{F2E4349A-C5C8-40A7-9DE6-2B0FE8D110E7}</td><td>TEMPPE1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT73</td><td>{E8EF00E9-667E-4669-9B99-457A44196BA5}</td><td>PROPERTIES1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT74</td><td>{DE345C31-A59A-48BB-A0F3-7CB309E4CA18}</td><td>UTILITY_CLASSES1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT75</td><td>{3D8CE59E-CE58-499C-8C82-91A4B53D2377}</td><td>VERSIONINFO</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT76</td><td>{2F4DABA0-3B01-4F61-B7EA-B7AD7E29D390}</td><td>BE18</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT77</td><td>{D3C2BE04-C77F-4C90-BCD2-DCED84D3FC30}</td><td>LE18</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT78</td><td>{BAE7167F-DA2A-42AC-9304-EDF2B0E82D24}</td><td>SIMPLECSMA</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT79</td><td>{B4CBDB48-0810-4827-A593-0DFBF3A99B99}</td><td>BIN2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT8</td><td>{3FF3C35F-584F-49A7-B413-2C73614C29D1}</td><td>LE1</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT80</td><td>{D8E54959-0FE5-4749-ACB1-E3A00802291D}</td><td>BE19</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT81</td><td>{C65E3547-BF1E-47F0-90B6-0D5905E7E89B}</td><td>LE19</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT82</td><td>{8246A4F4-5DEC-4BB1-8719-743404CDD7D9}</td><td>EMOTE_.NOW_RELEASE_4.3.0.141</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT83</td><td>{B0A60503-4239-46E6-BB8D-1F9064729269}</td><td>CLRANDBOOTER2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT84</td><td>{19233C1C-E278-4237-ABE2-72030FB01E37}</td><td>EMOTE_TINYCLR_V14.HEX2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT85</td><td>{B45B3D9D-40E2-4546-AB20-4C031AC4994A}</td><td>SAMRAKSH_EMOTE2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT86</td><td>{8DD44455-A228-4C4A-8973-6C667A6A63EC}</td><td>BE20</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT87</td><td>{2A5702EF-0FA9-48E6-80A9-F57F65A12081}</td><td>LE20</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT88</td><td>{C3935373-FC5B-4770-9CBC-ABC6FB675D7B}</td><td>SAMRAKSH_EMOTE_ADAPT2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT89</td><td>{FDCC75C7-DEDE-4030-8604-4A374F04C6F4}</td><td>BE21</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT9</td><td>{73300E6F-A272-43E6-A67E-D104357AD65B}</td><td>SAMRAKSH_EMOTE_DOTNOW</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT90</td><td>{DCE15D8D-781D-4E62-BFFC-B0EEA8FC78F0}</td><td>LE21</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT91</td><td>{D9B5E3AE-944B-4645-BA02-868A3A635761}</td><td>SAMRAKSH_EMOTE_DOTNOW2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT92</td><td>{D0F00255-BEAD-41A5-8837-4EC905EC0DBF}</td><td>BE22</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT93</td><td>{BBD3650C-00EF-49DD-B1EC-6E0645FD4568}</td><td>LE22</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT94</td><td>{CBEC1E9D-2784-4806-8EA9-9BE1C2C662D2}</td><td>SAMRAKSH_EMOTE_DSP2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT95</td><td>{60421B1B-E30F-4E84-86DA-71E5685A31C8}</td><td>BE23</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT96</td><td>{B6E13397-A0E3-4930-8393-7E48A3737D62}</td><td>LE23</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT97</td><td>{85C71FA6-3AE4-4CF7-8848-9BF01ABC4E61}</td><td>SAMRAKSH_EMOTE_KIWI2</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT98</td><td>{84B0111B-E3DC-473F-A850-790A5482E824}</td><td>BE24</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>ISX_DEFAULTCOMPONENT99</td><td>{489E9CB2-55AA-4933-9D6D-1E8F18806A71}</td><td>LE24</td><td>2</td><td/><td/><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.BitConverter.dll</td><td>{7724995B-AC1F-44BD-8AB2-28FC7B641CFA}</td><td>BE29</td><td>2</td><td/><td>samraksh.appnote.utility.bit</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.BitConverter.dll1</td><td>{3A68A9C4-933D-4569-AF31-6E5E44354B3C}</td><td>LE29</td><td>2</td><td/><td>samraksh.appnote.utility.bit4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.BitConverter.dll2</td><td>{84C2421B-AA2F-4400-8DE5-92910ECDA66C}</td><td>BIN4</td><td>2</td><td/><td>samraksh.appnote.utility.bit8</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.BitConverter.dll3</td><td>{3F1E3916-7D88-40B6-9D31-321F3777D5D3}</td><td>DEBUG5</td><td>2</td><td/><td>samraksh.appnote.utility.bit15</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td><td>{9B2D8889-3B87-4C65-B41B-4EC76D292DF0}</td><td>BE7</td><td>2</td><td/><td>samraksh.appnote.utility.enh</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll1</td><td>{9A856AD3-F8AF-471C-90A6-01A5338BDE81}</td><td>LE7</td><td>2</td><td/><td>samraksh.appnote.utility.enh4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll2</td><td>{136A3371-3D21-4020-9236-940C55F0C944}</td><td>BIN</td><td>2</td><td/><td>samraksh.appnote.utility.enh8</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll3</td><td>{F00230C2-2936-4B20-82DA-97AE20568BF3}</td><td>DEBUG</td><td>2</td><td/><td>samraksh.appnote.utility.enh15</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.EnhancedeMoteLcd.dll</td><td>{E2098C48-3AA6-4F60-9A69-8F2845CC0D86}</td><td>DEBUG1</td><td>2</td><td/><td>samraksh.appnote.utility.enh21</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SerialComm.dll</td><td>{72D205A0-A976-44D4-85D4-BDADA6C2FCB3}</td><td>BE31</td><td>2</td><td/><td>samraksh.appnote.utility.ser</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SerialComm.dll1</td><td>{F55F8955-5C55-4D9C-AF59-0337F7335F70}</td><td>LE31</td><td>2</td><td/><td>samraksh.appnote.utility.ser4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SerialComm.dll2</td><td>{AEC74976-CD54-4F95-AAF6-F8519F0ABEE5}</td><td>BIN6</td><td>2</td><td/><td>samraksh.appnote.utility.ser8</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SerialComm.dll3</td><td>{B5ABF469-6D0A-464D-BABF-F75737E03FBA}</td><td>DEBUG6</td><td>2</td><td/><td>samraksh.appnote.utility.ser15</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>{9C5042AB-D6C4-43E7-BBCE-3301036EF22B}</td><td>BE19</td><td>2</td><td/><td>samraksh.appnote.utility.sim</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll1</td><td>{3E1C06C6-6FB3-4CDB-ACF1-A7CDFA6895D2}</td><td>LE19</td><td>2</td><td/><td>samraksh.appnote.utility.sim4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll2</td><td>{544ABED3-E9BD-45EE-8DAB-AF0081157C3B}</td><td>BIN2</td><td>2</td><td/><td>samraksh.appnote.utility.sim8</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll3</td><td>{E0401356-AE47-494D-9029-F5175A012F05}</td><td>BE27</td><td>2</td><td/><td>samraksh.appnote.utility.sim11</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll4</td><td>{87550A17-82A2-49D3-9B7C-707E7681AA3E}</td><td>LE27</td><td>2</td><td/><td>samraksh.appnote.utility.sim19</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll5</td><td>{1B2E9DEC-D9AB-49F0-A14B-E9A57C0C70A6}</td><td>DEBUG3</td><td>2</td><td/><td>samraksh.appnote.utility.sim27</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll6</td><td>{0EECA84F-C65E-4697-9303-3F0D7811F6BC}</td><td>DEBUG4</td><td>2</td><td/><td>samraksh.appnote.utility.sim41</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td><td>{069B15E5-7680-43F8-94FD-796569847108}</td><td>BE27</td><td>2</td><td/><td>samraksh.appnote.utility.sim15</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll1</td><td>{1DC3A49A-7686-40C5-87FE-AAFA8C5B093F}</td><td>LE27</td><td>2</td><td/><td>samraksh.appnote.utility.sim23</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll2</td><td>{EA16D082-2353-4A58-86C4-A572465BC20C}</td><td>DEBUG3</td><td>2</td><td/><td>samraksh.appnote.utility.sim30</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll3</td><td>{34548D89-49C7-44CF-8055-2C7B54FD55DC}</td><td>DEBUG4</td><td>2</td><td/><td>samraksh.appnote.utility.sim43</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleTimer.dll</td><td>{7906275F-CC26-4D39-A085-F8B5D4DC5849}</td><td>BE33</td><td>2</td><td/><td>samraksh.appnote.utility.sim45</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleTimer.dll1</td><td>{DC74CB44-C36E-421A-A719-3278A721776E}</td><td>LE33</td><td>2</td><td/><td>samraksh.appnote.utility.sim49</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleTimer.dll2</td><td>{AC7FFC52-4AB2-4B29-B056-F49B5ACBB3C6}</td><td>BIN7</td><td>2</td><td/><td>samraksh.appnote.utility.sim53</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.SimpleTimer.dll3</td><td>{9939012B-C169-4E02-9DE3-FC9E72DBA135}</td><td>DEBUG7</td><td>2</td><td/><td>samraksh.appnote.utility.sim60</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.Sqrt.dll</td><td>{9E8EBBED-B568-4B92-BDDE-09FAB5E2CDEE}</td><td>BE35</td><td>2</td><td/><td>samraksh.appnote.utility.sqr</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.Sqrt.dll1</td><td>{5C3BE2BA-F07C-4B76-9775-C33AE51EE0F6}</td><td>LE35</td><td>2</td><td/><td>samraksh.appnote.utility.sqr4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.Sqrt.dll2</td><td>{D19E6DD5-EFE8-4D3C-AFC8-AF2ADCF76741}</td><td>BIN8</td><td>2</td><td/><td>samraksh.appnote.utility.sqr8</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.Sqrt.dll3</td><td>{F82B70F8-A35C-4648-A382-EC606A00CE79}</td><td>DEBUG8</td><td>2</td><td/><td>samraksh.appnote.utility.sqr15</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll</td><td>{82B3CF30-3284-497D-8814-2F84230CD5D8}</td><td>BIN</td><td>2</td><td/><td>samraksh.appnote.utility.ver4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll1</td><td>{03C99E2C-C988-4020-9F0B-453A540BB245}</td><td>DEBUG1</td><td>2</td><td/><td>samraksh.appnote.utility.ver11</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll2</td><td>{2292E454-750F-40B8-8BE2-3199F81894AB}</td><td>BE18</td><td>2</td><td/><td>samraksh.appnote.utility.ver14</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll3</td><td>{8CDAB8F8-7F16-4F84-BF0C-581A838DBEA6}</td><td>LE18</td><td>2</td><td/><td>samraksh.appnote.utility.ver18</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll4</td><td>{92DF9D0A-4196-4534-85E5-8BA779348981}</td><td>VERSIONINFO</td><td>2</td><td/><td>samraksh.appnote.utility.ver22</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll5</td><td>{56D35FBC-2B84-4769-B22F-FCCE99595671}</td><td>BE37</td><td>2</td><td/><td>samraksh.appnote.utility.ver25</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll6</td><td>{4189234E-3466-4B07-972A-E20DBDA6EBAC}</td><td>LE37</td><td>2</td><td/><td>samraksh.appnote.utility.ver29</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll7</td><td>{5EB4A21A-ACEC-49D3-BF9A-FAAA5BBC6792}</td><td>BIN9</td><td>2</td><td/><td>samraksh.appnote.utility.ver33</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll8</td><td>{AE3947CF-6B12-4607-9ABE-11EAC301C76C}</td><td>DEBUG10</td><td>2</td><td/><td>samraksh.appnote.utility.ver41</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote.dll</td><td>{7761E3BF-34E1-44E9-AC9B-A488E5C02B15}</td><td>BE</td><td>2</td><td/><td>samraksh_emote.dll</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote.dll1</td><td>{A351DFE4-8B14-4AFD-84CD-E3A2C84CCC18}</td><td>LE</td><td>2</td><td/><td>samraksh_emote.dll1</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote.dll2</td><td>{D2A640F4-B493-41D5-B243-CAC422D4B19A}</td><td>SAMRAKSH_EMOTE</td><td>2</td><td/><td>samraksh_emote.dll2</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote.dll3</td><td>{BF0B529A-DCB0-4FA8-A4F2-9B63A8CC8F9E}</td><td>BE8</td><td>2</td><td/><td>samraksh_emote.dll3</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote.dll4</td><td>{239043EE-DCBF-4563-8821-6573B6B63ADC}</td><td>LE8</td><td>2</td><td/><td>samraksh_emote.dll4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote.dll5</td><td>{FA24EB57-7C61-43E0-A198-CA711B256D8F}</td><td>SAMRAKSH_EMOTE1</td><td>2</td><td/><td>samraksh_emote.dll5</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote.dll6</td><td>{2982CC6E-C9CE-4DB0-91A2-53918C46736D}</td><td>BE20</td><td>2</td><td/><td>samraksh_emote.dll6</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote.dll7</td><td>{896B027A-4181-4891-9FEC-253A6E513D19}</td><td>LE20</td><td>2</td><td/><td>samraksh_emote.dll7</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote.dll8</td><td>{87D4CCC3-8CC9-4F0B-9219-E3AA777F731F}</td><td>SAMRAKSH_EMOTE2</td><td>2</td><td/><td>samraksh_emote.dll8</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Adapt.dll</td><td>{96671C91-D8BE-439D-95AD-CF39569AB770}</td><td>BE1</td><td>2</td><td/><td>samraksh_emote_adapt.dll</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Adapt.dll1</td><td>{8960FF47-DC9A-4A38-A5D7-D811450CAB12}</td><td>LE1</td><td>2</td><td/><td>samraksh_emote_adapt.dll1</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Adapt.dll2</td><td>{A306FF29-EC24-4A45-8194-95DBFD676FEF}</td><td>SAMRAKSH_EMOTE_ADAPT</td><td>2</td><td/><td>samraksh_emote_adapt.dll2</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Adapt.dll3</td><td>{3071A986-2A2A-4AC7-B968-C708C5DFB409}</td><td>BE9</td><td>2</td><td/><td>samraksh_emote_adapt.dll3</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Adapt.dll4</td><td>{48F4EB24-F2A8-4AFE-A947-F0AAF4E6C97E}</td><td>LE9</td><td>2</td><td/><td>samraksh_emote_adapt.dll4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Adapt.dll5</td><td>{5E510689-D4AC-4EB2-8A50-DEBEED0CCD41}</td><td>SAMRAKSH_EMOTE_ADAPT1</td><td>2</td><td/><td>samraksh_emote_adapt.dll5</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Adapt.dll6</td><td>{D5311428-49AB-40BB-AC72-2E0592619244}</td><td>BE21</td><td>2</td><td/><td>samraksh_emote_adapt.dll6</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Adapt.dll7</td><td>{6AA8987B-A47D-4687-9131-CCA14D851994}</td><td>LE21</td><td>2</td><td/><td>samraksh_emote_adapt.dll7</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Adapt.dll8</td><td>{2BA1427E-59AB-4344-8B84-78B6327034D5}</td><td>SAMRAKSH_EMOTE_ADAPT2</td><td>2</td><td/><td>samraksh_emote_adapt.dll8</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DSP.dll</td><td>{18436F61-70F0-4C02-AAD9-E7FA1052563D}</td><td>BE3</td><td>2</td><td/><td>samraksh_emote_dsp.dll</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DSP.dll1</td><td>{FEF37C1D-3E8F-4298-8D25-9049C14DD065}</td><td>LE3</td><td>2</td><td/><td>samraksh_emote_dsp.dll1</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DSP.dll2</td><td>{10F208D5-C115-407E-8CC6-CBE7C68CE1BD}</td><td>SAMRAKSH_EMOTE_DSP</td><td>2</td><td/><td>samraksh_emote_dsp.dll2</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DSP.dll3</td><td>{EADBD694-E992-4E23-A864-9466976B5523}</td><td>BE11</td><td>2</td><td/><td>samraksh_emote_dsp.dll3</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DSP.dll4</td><td>{3F40CB2E-6110-445D-852B-29E4A559E424}</td><td>LE11</td><td>2</td><td/><td>samraksh_emote_dsp.dll4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DSP.dll5</td><td>{3745F182-C87A-4C0A-8B21-27029DEFE6F6}</td><td>SAMRAKSH_EMOTE_DSP1</td><td>2</td><td/><td>samraksh_emote_dsp.dll5</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DSP.dll6</td><td>{8221033C-559E-4AAB-AE82-21ADA638E28A}</td><td>BE23</td><td>2</td><td/><td>samraksh_emote_dsp.dll6</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DSP.dll7</td><td>{AB9B47EF-6209-43CA-B827-ACACBF8949E3}</td><td>LE23</td><td>2</td><td/><td>samraksh_emote_dsp.dll7</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DSP.dll8</td><td>{63EC6075-0CCC-4D46-A6CA-744FBDE7AF04}</td><td>SAMRAKSH_EMOTE_DSP2</td><td>2</td><td/><td>samraksh_emote_dsp.dll8</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DotNow.dll</td><td>{8F305C03-8395-46E5-B34B-7AFAF39029DB}</td><td>BE2</td><td>2</td><td/><td>samraksh_emote_dotnow.dll</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DotNow.dll1</td><td>{3EB2C71E-5301-44F3-A9B6-8BC7377569D2}</td><td>LE2</td><td>2</td><td/><td>samraksh_emote_dotnow.dll1</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DotNow.dll10</td><td>{A8B5A29E-C197-4A7D-8756-5E043BA5C563}</td><td>SAMRAKSH_EMOTE_DOTNOW2</td><td>2</td><td/><td>samraksh_emote_dotnow.dll10</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DotNow.dll2</td><td>{BCE408FE-C91D-4D48-B88C-3707D748C0F5}</td><td>SAMRAKSH_EMOTE_DOTNOW</td><td>2</td><td/><td>samraksh_emote_dotnow.dll2</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DotNow.dll3</td><td>{82648B6C-FBD6-4113-BE82-3D28421A2A83}</td><td>BIN</td><td>2</td><td/><td>samraksh_emote_dotnow.dll3</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DotNow.dll4</td><td>{C2354975-041B-416A-B74D-BEEAF2FF9794}</td><td>BE10</td><td>2</td><td/><td>samraksh_emote_dotnow.dll4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DotNow.dll5</td><td>{5513D83A-3E96-42E8-9E71-3B9950F60991}</td><td>LE10</td><td>2</td><td/><td>samraksh_emote_dotnow.dll5</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DotNow.dll6</td><td>{0D4FAAAB-ABD5-493A-97F6-82E341482D6A}</td><td>SAMRAKSH_EMOTE_DOTNOW1</td><td>2</td><td/><td>samraksh_emote_dotnow.dll6</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DotNow.dll7</td><td>{834287BE-4CB7-44B9-BADE-E663D8EB8B74}</td><td>DEBUG1</td><td>2</td><td/><td>samraksh_emote_dotnow.dll7</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DotNow.dll8</td><td>{A9FEABAB-BCEF-43E6-9261-27DC90E1844F}</td><td>BE22</td><td>2</td><td/><td>samraksh_emote_dotnow.dll8</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_DotNow.dll9</td><td>{664FF86F-0C95-4B32-8812-D4CB3B95796F}</td><td>LE22</td><td>2</td><td/><td>samraksh_emote_dotnow.dll9</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Kiwi.dll</td><td>{83087995-DC55-40F9-A63A-66ACA8BC9226}</td><td>BE4</td><td>2</td><td/><td>samraksh_emote_kiwi.dll</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Kiwi.dll1</td><td>{99689DAE-0D06-402B-B1A0-91CFDFC4B837}</td><td>LE4</td><td>2</td><td/><td>samraksh_emote_kiwi.dll1</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Kiwi.dll2</td><td>{D17503FA-5467-4205-A7C0-134B011750B5}</td><td>SAMRAKSH_EMOTE_KIWI</td><td>2</td><td/><td>samraksh_emote_kiwi.dll2</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Kiwi.dll3</td><td>{24DB54C0-08C1-4B77-B43F-856559AC6F31}</td><td>BE12</td><td>2</td><td/><td>samraksh_emote_kiwi.dll3</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Kiwi.dll4</td><td>{9826F052-A2C3-4845-9C8C-9E7F05D8DBD1}</td><td>LE12</td><td>2</td><td/><td>samraksh_emote_kiwi.dll4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Kiwi.dll5</td><td>{A234E4EA-3A1E-49CD-8211-CFC166BE2419}</td><td>SAMRAKSH_EMOTE_KIWI1</td><td>2</td><td/><td>samraksh_emote_kiwi.dll5</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Kiwi.dll6</td><td>{3539EE4F-A8C2-4075-A5CE-3FDE2AC002C4}</td><td>BE24</td><td>2</td><td/><td>samraksh_emote_kiwi.dll6</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Kiwi.dll7</td><td>{8F766230-9430-4CDC-859B-2BD127F1991A}</td><td>LE24</td><td>2</td><td/><td>samraksh_emote_kiwi.dll7</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Kiwi.dll8</td><td>{ED84F4F0-5667-4FA4-B826-02180C80EE3F}</td><td>SAMRAKSH_EMOTE_KIWI2</td><td>2</td><td/><td>samraksh_emote_kiwi.dll8</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Net.dll</td><td>{9F1C7412-9C2F-4B68-9059-1B9C733339F3}</td><td>BE5</td><td>2</td><td/><td>samraksh_emote_net.dll</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Net.dll1</td><td>{F4B2170E-67C8-424F-B079-1FAD8062CE1B}</td><td>LE5</td><td>2</td><td/><td>samraksh_emote_net.dll1</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Net.dll10</td><td>{D2572D96-B58A-4E40-A64B-86790105ADA7}</td><td>DEBUG3</td><td>2</td><td/><td>samraksh_emote_net.dll10</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Net.dll2</td><td>{37428FBA-5241-4365-89A4-50386A513991}</td><td>SAMRAKSH_EMOTE_NET</td><td>2</td><td/><td>samraksh_emote_net.dll2</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Net.dll3</td><td>{16A3CD15-56F5-4FF1-BFB9-EC69C12846C7}</td><td>BE13</td><td>2</td><td/><td>samraksh_emote_net.dll3</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Net.dll4</td><td>{2C17F07E-82FB-4F22-A813-CA92CC473C88}</td><td>LE13</td><td>2</td><td/><td>samraksh_emote_net.dll4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Net.dll5</td><td>{D41661CC-2939-4DCA-88E5-BBFA0D79CA34}</td><td>SAMRAKSH_EMOTE_NET1</td><td>2</td><td/><td>samraksh_emote_net.dll5</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Net.dll6</td><td>{CCF33F2E-7FE1-445E-990B-2BAD7BC2048A}</td><td>BIN2</td><td>2</td><td/><td>samraksh_emote_net.dll6</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Net.dll7</td><td>{ADFD41ED-C7EE-4EF8-BCB4-39FD4AAD287B}</td><td>BE25</td><td>2</td><td/><td>samraksh_emote_net.dll7</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Net.dll8</td><td>{8B06148A-CC6D-46BB-BC0B-5CCF74FF121A}</td><td>LE25</td><td>2</td><td/><td>samraksh_emote_net.dll8</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_Net.dll9</td><td>{FA22374F-3A7D-447A-B618-15DF81274712}</td><td>SAMRAKSH_EMOTE_NET2</td><td>2</td><td/><td>samraksh_emote_net.dll9</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_RealTime.dll</td><td>{31313664-2404-41D6-ABDB-DD2B8BC07D1E}</td><td>BE6</td><td>2</td><td/><td>samraksh_emote_realtime.dll</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_RealTime.dll1</td><td>{FD5FA962-F406-496D-A2C2-0211E31A7577}</td><td>LE6</td><td>2</td><td/><td>samraksh_emote_realtime.dll1</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_RealTime.dll2</td><td>{CDD6AF78-5E29-4B61-8E16-877788208E6A}</td><td>SAMRAKSH_EMOTE_REALTIME</td><td>2</td><td/><td>samraksh_emote_realtime.dll2</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_RealTime.dll3</td><td>{364F4BDC-F086-4300-8812-65D30C5CCB45}</td><td>BE14</td><td>2</td><td/><td>samraksh_emote_realtime.dll3</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_RealTime.dll4</td><td>{49F78F2D-E2AB-40B8-9A32-3CB950606C37}</td><td>LE14</td><td>2</td><td/><td>samraksh_emote_realtime.dll4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_RealTime.dll5</td><td>{9BF826DC-1921-4FE8-847D-EAF696B84BB5}</td><td>SAMRAKSH_EMOTE_REALTIME1</td><td>2</td><td/><td>samraksh_emote_realtime.dll5</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_RealTime.dll6</td><td>{6BF7D22C-DE6B-4F31-AB66-BFC6FCB7CDA8}</td><td>BE26</td><td>2</td><td/><td>samraksh_emote_realtime.dll6</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_RealTime.dll7</td><td>{827CA685-C945-40CB-98C1-D2A28CAF6105}</td><td>LE26</td><td>2</td><td/><td>samraksh_emote_realtime.dll7</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>Samraksh_eMote_RealTime.dll8</td><td>{70F6068C-B923-475B-BF39-8CB2C6F45BCB}</td><td>SAMRAKSH_EMOTE_REALTIME2</td><td>2</td><td/><td>samraksh_emote_realtime.dll8</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>TestEnhancedeMoteLCD.exe</td><td>{D65B5892-891C-48E6-9B92-988F83A3770F}</td><td>BE7</td><td>2</td><td/><td>testenhancedemotelcd.exe</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>TestEnhancedeMoteLCD.exe1</td><td>{39A756DB-DD5D-47F8-9946-AE6E91029DD1}</td><td>LE7</td><td>2</td><td/><td>testenhancedemotelcd.exe1</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>TestEnhancedeMoteLCD.exe2</td><td>{DE3D4B09-8C86-4E2E-95BE-7A7A99DDA372}</td><td>BIN</td><td>2</td><td/><td>testenhancedemotelcd.exe2</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>TestEnhancedeMoteLCD.exe3</td><td>{AB82EFEB-38B1-47D3-B41B-4A7BA833018F}</td><td>BE16</td><td>2</td><td/><td>testenhancedemotelcd.exe3</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>TestEnhancedeMoteLCD.exe4</td><td>{44086288-FCA3-4F78-8EE8-A83827789358}</td><td>LE16</td><td>2</td><td/><td>testenhancedemotelcd.exe4</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>TestEnhancedeMoteLCD.exe5</td><td>{86305A46-074F-419C-BB1B-9CB095CAB7DF}</td><td>DEBUG1</td><td>2</td><td/><td>testenhancedemotelcd.exe5</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
		<row><td>TestEnhancedeMoteLCD.exe6</td><td>{33D56D37-790D-41AF-A9E6-44D6590846C5}</td><td>DEBUG2</td><td>2</td><td/><td>testenhancedemotelcd.exe6</td><td>17</td><td/><td/><td/><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td><td>/LogFile=</td></row>
	</table>

	<table name="Condition">
		<col key="yes" def="s38">Feature_</col>
		<col key="yes" def="i2">Level</col>
		<col def="S255">Condition</col>
	</table>

	<table name="Control">
		<col key="yes" def="s72">Dialog_</col>
		<col key="yes" def="s50">Control</col>
		<col def="s20">Type</col>
		<col def="i2">X</col>
		<col def="i2">Y</col>
		<col def="i2">Width</col>
		<col def="i2">Height</col>
		<col def="I4">Attributes</col>
		<col def="S72">Property</col>
		<col def="L0">Text</col>
		<col def="S50">Control_Next</col>
		<col def="L50">Help</col>
		<col def="I4">ISWindowStyle</col>
		<col def="I4">ISControlId</col>
		<col def="S255">ISBuildSourcePath</col>
		<col def="S72">Binary_</col>
		<row><td>AdminChangeFolder</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>AdminChangeFolder</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminChangeFolder</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminChangeFolder</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminChangeFolder</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>ComboText</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminChangeFolder</td><td>Combo</td><td>DirectoryCombo</td><td>21</td><td>64</td><td>277</td><td>80</td><td>458755</td><td>TARGETDIR</td><td>##IDS__IsAdminInstallBrowse_4##</td><td>Up</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminChangeFolder</td><td>ComboText</td><td>Text</td><td>21</td><td>50</td><td>99</td><td>14</td><td>3</td><td/><td>##IDS__IsAdminInstallBrowse_LookIn##</td><td>Combo</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminChangeFolder</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsAdminInstallBrowse_BrowseDestination##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminChangeFolder</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminChangeFolder</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsAdminInstallBrowse_ChangeDestination##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminChangeFolder</td><td>List</td><td>DirectoryList</td><td>21</td><td>90</td><td>332</td><td>97</td><td>7</td><td>TARGETDIR</td><td>##IDS__IsAdminInstallBrowse_8##</td><td>TailText</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminChangeFolder</td><td>NewFolder</td><td>PushButton</td><td>335</td><td>66</td><td>19</td><td>19</td><td>3670019</td><td/><td/><td>List</td><td>##IDS__IsAdminInstallBrowse_CreateFolder##</td><td>0</td><td/><td/><td>NewBinary2</td></row>
		<row><td>AdminChangeFolder</td><td>OK</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_OK##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminChangeFolder</td><td>Tail</td><td>PathEdit</td><td>21</td><td>207</td><td>332</td><td>17</td><td>3</td><td>TARGETDIR</td><td>##IDS__IsAdminInstallBrowse_11##</td><td>OK</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminChangeFolder</td><td>TailText</td><td>Text</td><td>21</td><td>193</td><td>99</td><td>13</td><td>3</td><td/><td>##IDS__IsAdminInstallBrowse_FolderName##</td><td>Tail</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminChangeFolder</td><td>Up</td><td>PushButton</td><td>310</td><td>66</td><td>19</td><td>19</td><td>3670019</td><td/><td/><td>NewFolder</td><td>##IDS__IsAdminInstallBrowse_UpOneLevel##</td><td>0</td><td/><td/><td>NewBinary3</td></row>
		<row><td>AdminNetworkLocation</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_BACK##</td><td>InstallNow</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminNetworkLocation</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>AdminNetworkLocation</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminNetworkLocation</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminNetworkLocation</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminNetworkLocation</td><td>Browse</td><td>PushButton</td><td>286</td><td>124</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsAdminInstallPoint_Change##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminNetworkLocation</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>SetupPathEdit</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminNetworkLocation</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsAdminInstallPoint_SpecifyNetworkLocation##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminNetworkLocation</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminNetworkLocation</td><td>DlgText</td><td>Text</td><td>21</td><td>51</td><td>326</td><td>40</td><td>131075</td><td/><td>##IDS__IsAdminInstallPoint_EnterNetworkLocation##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminNetworkLocation</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsAdminInstallPoint_NetworkLocationFormatted##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminNetworkLocation</td><td>InstallNow</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsAdminInstallPoint_Install##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminNetworkLocation</td><td>LBBrowse</td><td>Text</td><td>21</td><td>90</td><td>100</td><td>10</td><td>3</td><td/><td>##IDS__IsAdminInstallPoint_NetworkLocation##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminNetworkLocation</td><td>SetupPathEdit</td><td>PathEdit</td><td>21</td><td>102</td><td>330</td><td>17</td><td>3</td><td>TARGETDIR</td><td/><td>Browse</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminWelcome</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminWelcome</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminWelcome</td><td>DlgLine</td><td>Line</td><td>0</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminWelcome</td><td>Image</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>234</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary5</td></row>
		<row><td>AdminWelcome</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminWelcome</td><td>TextLine1</td><td>Text</td><td>135</td><td>8</td><td>225</td><td>45</td><td>196611</td><td/><td>##IDS__IsAdminInstallPointWelcome_Wizard##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>AdminWelcome</td><td>TextLine2</td><td>Text</td><td>135</td><td>55</td><td>228</td><td>45</td><td>196611</td><td/><td>##IDS__IsAdminInstallPointWelcome_ServerImage##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CancelSetup</td><td>Icon</td><td>Icon</td><td>15</td><td>15</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary4</td></row>
		<row><td>CancelSetup</td><td>No</td><td>PushButton</td><td>135</td><td>57</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsCancelDlg_No##</td><td>Yes</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CancelSetup</td><td>Text</td><td>Text</td><td>48</td><td>15</td><td>194</td><td>30</td><td>131075</td><td/><td>##IDS__IsCancelDlg_ConfirmCancel##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CancelSetup</td><td>Yes</td><td>PushButton</td><td>62</td><td>57</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsCancelDlg_Yes##</td><td>No</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>CustomSetup</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>Tree</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>ChangeFolder</td><td>PushButton</td><td>301</td><td>203</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsCustomSelectionDlg_Change##</td><td>Help</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>Details</td><td>PushButton</td><td>93</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsCustomSelectionDlg_Space##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>DlgDesc</td><td>Text</td><td>17</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsCustomSelectionDlg_SelectFeatures##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>DlgText</td><td>Text</td><td>9</td><td>51</td><td>360</td><td>10</td><td>3</td><td/><td>##IDS__IsCustomSelectionDlg_ClickFeatureIcon##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>DlgTitle</td><td>Text</td><td>9</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsCustomSelectionDlg_CustomSetup##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>FeatureGroup</td><td>GroupBox</td><td>235</td><td>67</td><td>131</td><td>120</td><td>1</td><td/><td>##IDS__IsCustomSelectionDlg_FeatureDescription##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>Help</td><td>PushButton</td><td>22</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsCustomSelectionDlg_Help##</td><td>Details</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>InstallLabel</td><td>Text</td><td>8</td><td>190</td><td>360</td><td>10</td><td>3</td><td/><td>##IDS__IsCustomSelectionDlg_InstallTo##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>ItemDescription</td><td>Text</td><td>241</td><td>80</td><td>120</td><td>50</td><td>3</td><td/><td>##IDS__IsCustomSelectionDlg_MultilineDescription##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>Location</td><td>Text</td><td>8</td><td>203</td><td>291</td><td>20</td><td>3</td><td/><td>##IDS__IsCustomSelectionDlg_FeaturePath##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>Size</td><td>Text</td><td>241</td><td>133</td><td>120</td><td>50</td><td>3</td><td/><td>##IDS__IsCustomSelectionDlg_FeatureSize##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetup</td><td>Tree</td><td>SelectionTree</td><td>8</td><td>70</td><td>220</td><td>118</td><td>7</td><td>_BrowseProperty</td><td/><td>ChangeFolder</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetupTips</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>CustomSetupTips</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetupTips</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetupTips</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetupTips</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS_SetupTips_CustomSetupDescription##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetupTips</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetupTips</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS_SetupTips_CustomSetup##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetupTips</td><td>DontInstall</td><td>Icon</td><td>21</td><td>155</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary14</td></row>
		<row><td>CustomSetupTips</td><td>DontInstallText</td><td>Text</td><td>60</td><td>155</td><td>300</td><td>20</td><td>3</td><td/><td>##IDS_SetupTips_WillNotBeInstalled##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetupTips</td><td>FirstInstallText</td><td>Text</td><td>60</td><td>180</td><td>300</td><td>20</td><td>3</td><td/><td>##IDS_SetupTips_Advertise##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetupTips</td><td>Install</td><td>Icon</td><td>21</td><td>105</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary15</td></row>
		<row><td>CustomSetupTips</td><td>InstallFirstUse</td><td>Icon</td><td>21</td><td>180</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary16</td></row>
		<row><td>CustomSetupTips</td><td>InstallPartial</td><td>Icon</td><td>21</td><td>130</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary17</td></row>
		<row><td>CustomSetupTips</td><td>InstallStateMenu</td><td>Icon</td><td>21</td><td>52</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary18</td></row>
		<row><td>CustomSetupTips</td><td>InstallStateText</td><td>Text</td><td>21</td><td>91</td><td>300</td><td>10</td><td>3</td><td/><td>##IDS_SetupTips_InstallState##</td><td/><td/><td>0</td><td>0</td><td/><td/></row>
		<row><td>CustomSetupTips</td><td>InstallText</td><td>Text</td><td>60</td><td>105</td><td>300</td><td>20</td><td>3</td><td/><td>##IDS_SetupTips_AllInstalledLocal##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetupTips</td><td>MenuText</td><td>Text</td><td>50</td><td>52</td><td>300</td><td>36</td><td>3</td><td/><td>##IDS_SetupTips_IconInstallState##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetupTips</td><td>NetworkInstall</td><td>Icon</td><td>21</td><td>205</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary13</td></row>
		<row><td>CustomSetupTips</td><td>NetworkInstallText</td><td>Text</td><td>60</td><td>205</td><td>300</td><td>20</td><td>3</td><td/><td>##IDS_SetupTips_Network##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetupTips</td><td>OK</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_SetupTips_OK##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomSetupTips</td><td>PartialText</td><td>Text</td><td>60</td><td>130</td><td>300</td><td>20</td><td>3</td><td/><td>##IDS_SetupTips_SubFeaturesInstalledLocal##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>CustomerInformation</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>NameLabel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>CompanyEdit</td><td>Edit</td><td>21</td><td>100</td><td>237</td><td>17</td><td>3</td><td>COMPANYNAME</td><td>##IDS__IsRegisterUserDlg_Tahoma80##</td><td>SerialLabel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>CompanyLabel</td><td>Text</td><td>21</td><td>89</td><td>75</td><td>10</td><td>3</td><td/><td>##IDS__IsRegisterUserDlg_Organization##</td><td>CompanyEdit</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsRegisterUserDlg_PleaseEnterInfo##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>DlgRadioGroupText</td><td>Text</td><td>21</td><td>161</td><td>300</td><td>14</td><td>2</td><td/><td>##IDS__IsRegisterUserDlg_InstallFor##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsRegisterUserDlg_CustomerInformation##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>NameEdit</td><td>Edit</td><td>21</td><td>63</td><td>237</td><td>17</td><td>3</td><td>USERNAME</td><td>##IDS__IsRegisterUserDlg_Tahoma50##</td><td>CompanyLabel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>NameLabel</td><td>Text</td><td>21</td><td>52</td><td>75</td><td>10</td><td>3</td><td/><td>##IDS__IsRegisterUserDlg_UserName##</td><td>NameEdit</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>RadioGroup</td><td>RadioButtonGroup</td><td>63</td><td>170</td><td>300</td><td>50</td><td>2</td><td>ApplicationUsers</td><td>##IDS__IsRegisterUserDlg_16##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>SerialLabel</td><td>Text</td><td>21</td><td>127</td><td>109</td><td>10</td><td>2</td><td/><td>##IDS__IsRegisterUserDlg_SerialNumber##</td><td>SerialNumber</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>CustomerInformation</td><td>SerialNumber</td><td>MaskedEdit</td><td>21</td><td>138</td><td>237</td><td>17</td><td>2</td><td>ISX_SERIALNUM</td><td/><td>RadioGroup</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>DatabaseFolder</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>DatabaseFolder</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>DatabaseFolder</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DatabaseFolder</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DatabaseFolder</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DatabaseFolder</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>ChangeFolder</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>DatabaseFolder</td><td>ChangeFolder</td><td>PushButton</td><td>301</td><td>65</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CHANGE##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>DatabaseFolder</td><td>DatabaseFolder</td><td>Icon</td><td>21</td><td>52</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary12</td></row>
		<row><td>DatabaseFolder</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__DatabaseFolder_ChangeFolder##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DatabaseFolder</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DatabaseFolder</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__DatabaseFolder_DatabaseFolder##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DatabaseFolder</td><td>LocLabel</td><td>Text</td><td>57</td><td>52</td><td>290</td><td>10</td><td>131075</td><td/><td>##IDS_DatabaseFolder_InstallDatabaseTo##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DatabaseFolder</td><td>Location</td><td>Text</td><td>57</td><td>65</td><td>240</td><td>40</td><td>3</td><td>_BrowseProperty</td><td>##IDS__DatabaseFolder_DatabaseDir##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DatabaseFolder</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>DestinationFolder</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>DestinationFolder</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>DestinationFolder</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DestinationFolder</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DestinationFolder</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DestinationFolder</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>ChangeFolder</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>DestinationFolder</td><td>ChangeFolder</td><td>PushButton</td><td>301</td><td>65</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__DestinationFolder_Change##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>DestinationFolder</td><td>DestFolder</td><td>Icon</td><td>21</td><td>52</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary12</td></row>
		<row><td>DestinationFolder</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__DestinationFolder_ChangeFolder##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DestinationFolder</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DestinationFolder</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__DestinationFolder_DestinationFolder##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DestinationFolder</td><td>LocLabel</td><td>Text</td><td>57</td><td>52</td><td>290</td><td>10</td><td>131075</td><td/><td>##IDS__DestinationFolder_InstallTo##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DestinationFolder</td><td>Location</td><td>Text</td><td>57</td><td>65</td><td>240</td><td>40</td><td>3</td><td>_BrowseProperty</td><td>##IDS_INSTALLDIR##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DestinationFolder</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>DiskSpaceRequirements</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>DiskSpaceRequirements</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DiskSpaceRequirements</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DiskSpaceRequirements</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DiskSpaceRequirements</td><td>DlgDesc</td><td>Text</td><td>17</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsFeatureDetailsDlg_SpaceRequired##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DiskSpaceRequirements</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DiskSpaceRequirements</td><td>DlgText</td><td>Text</td><td>10</td><td>185</td><td>358</td><td>41</td><td>3</td><td/><td>##IDS__IsFeatureDetailsDlg_VolumesTooSmall##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DiskSpaceRequirements</td><td>DlgTitle</td><td>Text</td><td>9</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsFeatureDetailsDlg_DiskSpaceRequirements##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DiskSpaceRequirements</td><td>List</td><td>VolumeCostList</td><td>8</td><td>55</td><td>358</td><td>125</td><td>393223</td><td/><td>##IDS__IsFeatureDetailsDlg_Numbers##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>DiskSpaceRequirements</td><td>OK</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsFeatureDetailsDlg_OK##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>FilesInUse</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>FilesInUse</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>FilesInUse</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>FilesInUse</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>FilesInUse</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsFilesInUse_FilesInUseMessage##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>FilesInUse</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>FilesInUse</td><td>DlgText</td><td>Text</td><td>21</td><td>51</td><td>348</td><td>33</td><td>3</td><td/><td>##IDS__IsFilesInUse_ApplicationsUsingFiles##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>FilesInUse</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsFilesInUse_FilesInUse##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>FilesInUse</td><td>Exit</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsFilesInUse_Exit##</td><td>List</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>FilesInUse</td><td>Ignore</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsFilesInUse_Ignore##</td><td>Exit</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>FilesInUse</td><td>List</td><td>ListBox</td><td>21</td><td>87</td><td>331</td><td>135</td><td>7</td><td>FileInUseProcess</td><td/><td>Retry</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>FilesInUse</td><td>Retry</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsFilesInUse_Retry##</td><td>Ignore</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>InstallChangeFolder</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>ComboText</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>Combo</td><td>DirectoryCombo</td><td>21</td><td>64</td><td>277</td><td>80</td><td>4128779</td><td>_BrowseProperty</td><td>##IDS__IsBrowseFolderDlg_4##</td><td>Up</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>ComboText</td><td>Text</td><td>21</td><td>50</td><td>99</td><td>14</td><td>3</td><td/><td>##IDS__IsBrowseFolderDlg_LookIn##</td><td>Combo</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsBrowseFolderDlg_BrowseDestFolder##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsBrowseFolderDlg_ChangeCurrentFolder##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>List</td><td>DirectoryList</td><td>21</td><td>90</td><td>332</td><td>97</td><td>15</td><td>_BrowseProperty</td><td>##IDS__IsBrowseFolderDlg_8##</td><td>TailText</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>NewFolder</td><td>PushButton</td><td>335</td><td>66</td><td>19</td><td>19</td><td>3670019</td><td/><td/><td>List</td><td>##IDS__IsBrowseFolderDlg_CreateFolder##</td><td>0</td><td/><td/><td>NewBinary2</td></row>
		<row><td>InstallChangeFolder</td><td>OK</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsBrowseFolderDlg_OK##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>Tail</td><td>PathEdit</td><td>21</td><td>207</td><td>332</td><td>17</td><td>15</td><td>_BrowseProperty</td><td>##IDS__IsBrowseFolderDlg_11##</td><td>OK</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>TailText</td><td>Text</td><td>21</td><td>193</td><td>99</td><td>13</td><td>3</td><td/><td>##IDS__IsBrowseFolderDlg_FolderName##</td><td>Tail</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallChangeFolder</td><td>Up</td><td>PushButton</td><td>310</td><td>66</td><td>19</td><td>19</td><td>3670019</td><td/><td/><td>NewFolder</td><td>##IDS__IsBrowseFolderDlg_UpOneLevel##</td><td>0</td><td/><td/><td>NewBinary3</td></row>
		<row><td>InstallWelcome</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_BACK##</td><td>Copyright</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallWelcome</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallWelcome</td><td>Copyright</td><td>Text</td><td>135</td><td>144</td><td>228</td><td>73</td><td>65539</td><td/><td>##IDS__IsWelcomeDlg_WarningCopyright##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallWelcome</td><td>DlgLine</td><td>Line</td><td>0</td><td>234</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallWelcome</td><td>Image</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>234</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary5</td></row>
		<row><td>InstallWelcome</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallWelcome</td><td>TextLine1</td><td>Text</td><td>135</td><td>8</td><td>225</td><td>45</td><td>196611</td><td/><td>##IDS__IsWelcomeDlg_WelcomeProductName##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>InstallWelcome</td><td>TextLine2</td><td>Text</td><td>135</td><td>55</td><td>228</td><td>45</td><td>196611</td><td/><td>##IDS__IsWelcomeDlg_InstallProductName##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>LicenseAgreement</td><td>Agree</td><td>RadioButtonGroup</td><td>8</td><td>190</td><td>291</td><td>40</td><td>3</td><td>AgreeToLicense</td><td/><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>LicenseAgreement</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>LicenseAgreement</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>LicenseAgreement</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>LicenseAgreement</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>LicenseAgreement</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>LicenseAgreement</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>ISPrintButton</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>LicenseAgreement</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsLicenseDlg_ReadLicenseAgreement##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>LicenseAgreement</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>LicenseAgreement</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsLicenseDlg_LicenseAgreement##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>LicenseAgreement</td><td>ISPrintButton</td><td>PushButton</td><td>301</td><td>188</td><td>65</td><td>17</td><td>3</td><td/><td>##IDS_PRINT_BUTTON##</td><td>Agree</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>LicenseAgreement</td><td>Memo</td><td>ScrollableText</td><td>8</td><td>55</td><td>358</td><td>130</td><td>7</td><td/><td/><td/><td/><td>0</td><td/><td>&lt;ISProductFolder&gt;\Redist\0409\Eula.rtf</td><td/></row>
		<row><td>LicenseAgreement</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceType</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceType</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>MaintenanceType</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceType</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceType</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceType</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>RadioGroup</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceType</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsMaintenanceDlg_MaitenanceOptions##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceType</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceType</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsMaintenanceDlg_ProgramMaintenance##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceType</td><td>Ico1</td><td>Icon</td><td>35</td><td>75</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary6</td></row>
		<row><td>MaintenanceType</td><td>Ico2</td><td>Icon</td><td>35</td><td>135</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary7</td></row>
		<row><td>MaintenanceType</td><td>Ico3</td><td>Icon</td><td>35</td><td>195</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary8</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceType</td><td>RadioGroup</td><td>RadioButtonGroup</td><td>21</td><td>55</td><td>290</td><td>170</td><td>3</td><td>_IsMaintenance</td><td/><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceType</td><td>Text1</td><td>Text</td><td>80</td><td>72</td><td>260</td><td>35</td><td>3</td><td/><td>##IDS__IsMaintenanceDlg_ChangeFeatures##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceType</td><td>Text2</td><td>Text</td><td>80</td><td>135</td><td>260</td><td>35</td><td>3</td><td/><td>##IDS__IsMaintenanceDlg_RepairMessage##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceType</td><td>Text3</td><td>Text</td><td>80</td><td>192</td><td>260</td><td>35</td><td>131075</td><td/><td>##IDS__IsMaintenanceDlg_RemoveProductName##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceWelcome</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceWelcome</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceWelcome</td><td>DlgLine</td><td>Line</td><td>0</td><td>234</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceWelcome</td><td>Image</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>234</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary5</td></row>
		<row><td>MaintenanceWelcome</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceWelcome</td><td>TextLine1</td><td>Text</td><td>135</td><td>8</td><td>225</td><td>45</td><td>196611</td><td/><td>##IDS__IsMaintenanceWelcome_WizardWelcome##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MaintenanceWelcome</td><td>TextLine2</td><td>Text</td><td>135</td><td>55</td><td>228</td><td>50</td><td>196611</td><td/><td>##IDS__IsMaintenanceWelcome_MaintenanceOptionsDescription##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MsiRMFilesInUse</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>MsiRMFilesInUse</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MsiRMFilesInUse</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MsiRMFilesInUse</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MsiRMFilesInUse</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>Restart</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>MsiRMFilesInUse</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsFilesInUse_FilesInUseMessage##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MsiRMFilesInUse</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MsiRMFilesInUse</td><td>DlgText</td><td>Text</td><td>21</td><td>51</td><td>348</td><td>14</td><td>3</td><td/><td>##IDS__IsMsiRMFilesInUse_ApplicationsUsingFiles##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MsiRMFilesInUse</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsFilesInUse_FilesInUse##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>MsiRMFilesInUse</td><td>List</td><td>ListBox</td><td>21</td><td>66</td><td>331</td><td>130</td><td>3</td><td>FileInUseProcess</td><td/><td>OK</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>MsiRMFilesInUse</td><td>OK</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_OK##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>MsiRMFilesInUse</td><td>Restart</td><td>RadioButtonGroup</td><td>19</td><td>187</td><td>343</td><td>40</td><td>3</td><td>RestartManagerOption</td><td/><td>List</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>OutOfSpace</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>OutOfSpace</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>OutOfSpace</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>OutOfSpace</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>OutOfSpace</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsDiskSpaceDlg_DiskSpace##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>OutOfSpace</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>OutOfSpace</td><td>DlgText</td><td>Text</td><td>21</td><td>51</td><td>326</td><td>43</td><td>3</td><td/><td>##IDS__IsDiskSpaceDlg_HighlightedVolumes##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>OutOfSpace</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsDiskSpaceDlg_OutOfDiskSpace##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>OutOfSpace</td><td>List</td><td>VolumeCostList</td><td>21</td><td>95</td><td>332</td><td>120</td><td>393223</td><td/><td>##IDS__IsDiskSpaceDlg_Numbers##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>OutOfSpace</td><td>Resume</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsDiskSpaceDlg_OK##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>PatchWelcome</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>PatchWelcome</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>PatchWelcome</td><td>DlgLine</td><td>Line</td><td>0</td><td>234</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>PatchWelcome</td><td>Image</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>234</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary5</td></row>
		<row><td>PatchWelcome</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsPatchDlg_Update##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>PatchWelcome</td><td>TextLine1</td><td>Text</td><td>135</td><td>8</td><td>225</td><td>45</td><td>196611</td><td/><td>##IDS__IsPatchDlg_WelcomePatchWizard##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>PatchWelcome</td><td>TextLine2</td><td>Text</td><td>135</td><td>54</td><td>228</td><td>45</td><td>196611</td><td/><td>##IDS__IsPatchDlg_PatchClickUpdate##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadmeInformation</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>1048579</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadmeInformation</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>3</td><td/><td/><td>DlgTitle</td><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>ReadmeInformation</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td>0</td><td/><td/></row>
		<row><td>ReadmeInformation</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td>0</td><td/><td/></row>
		<row><td>ReadmeInformation</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>1048579</td><td/><td>##IDS__IsReadmeDlg_Cancel##</td><td>Readme</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadmeInformation</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>232</td><td>16</td><td>65539</td><td/><td>##IDS__IsReadmeDlg_PleaseReadInfo##</td><td>Back</td><td/><td>0</td><td>0</td><td/><td/></row>
		<row><td>ReadmeInformation</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>3</td><td/><td/><td/><td/><td>0</td><td>0</td><td/><td/></row>
		<row><td>ReadmeInformation</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>193</td><td>13</td><td>65539</td><td/><td>##IDS__IsReadmeDlg_ReadMeInfo##</td><td>DlgDesc</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadmeInformation</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>1048579</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadmeInformation</td><td>Readme</td><td>ScrollableText</td><td>10</td><td>55</td><td>353</td><td>166</td><td>3</td><td/><td/><td>Banner</td><td/><td>0</td><td/><td>&lt;ISProductFolder&gt;\Redist\0409\Readme.rtf</td><td/></row>
		<row><td>ReadyToInstall</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_BACK##</td><td>GroupBox1</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>ReadyToInstall</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>CompanyNameText</td><td>Text</td><td>38</td><td>198</td><td>211</td><td>9</td><td>3</td><td/><td>##IDS__IsVerifyReadyDlg_Company##</td><td>SerialNumberText</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>CurrentSettingsText</td><td>Text</td><td>19</td><td>80</td><td>81</td><td>10</td><td>3</td><td/><td>##IDS__IsVerifyReadyDlg_CurrentSettings##</td><td>InstallNow</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsVerifyReadyDlg_WizardReady##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td>0</td><td/><td/></row>
		<row><td>ReadyToInstall</td><td>DlgText1</td><td>Text</td><td>21</td><td>54</td><td>330</td><td>24</td><td>3</td><td/><td>##IDS__IsVerifyReadyDlg_BackOrCancel##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>DlgText2</td><td>Text</td><td>21</td><td>99</td><td>330</td><td>20</td><td>2</td><td/><td>##IDS__IsRegisterUserDlg_InstallFor##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65538</td><td/><td>##IDS__IsVerifyReadyDlg_ModifyReady##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>DlgTitle2</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65538</td><td/><td>##IDS__IsVerifyReadyDlg_ReadyRepair##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>DlgTitle3</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65538</td><td/><td>##IDS__IsVerifyReadyDlg_ReadyInstall##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>GroupBox1</td><td>Text</td><td>19</td><td>92</td><td>330</td><td>133</td><td>65541</td><td/><td/><td>SetupTypeText1</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>InstallNow</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>8388611</td><td/><td>##IDS__IsVerifyReadyDlg_Install##</td><td>InstallPerMachine</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>InstallPerMachine</td><td>PushButton</td><td>63</td><td>123</td><td>248</td><td>17</td><td>8388610</td><td/><td>##IDS__IsRegisterUserDlg_Anyone##</td><td>InstallPerUser</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>InstallPerUser</td><td>PushButton</td><td>63</td><td>143</td><td>248</td><td>17</td><td>2</td><td/><td>##IDS__IsRegisterUserDlg_OnlyMe##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>SerialNumberText</td><td>Text</td><td>38</td><td>211</td><td>306</td><td>9</td><td>3</td><td/><td>##IDS__IsVerifyReadyDlg_Serial##</td><td>CurrentSettingsText</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>SetupTypeText1</td><td>Text</td><td>23</td><td>97</td><td>306</td><td>13</td><td>3</td><td/><td>##IDS__IsVerifyReadyDlg_SetupType##</td><td>SetupTypeText2</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>SetupTypeText2</td><td>Text</td><td>37</td><td>114</td><td>306</td><td>14</td><td>3</td><td/><td>##IDS__IsVerifyReadyDlg_SelectedSetupType##</td><td>TargetFolderText1</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>TargetFolderText1</td><td>Text</td><td>24</td><td>136</td><td>306</td><td>11</td><td>3</td><td/><td>##IDS__IsVerifyReadyDlg_DestFolder##</td><td>TargetFolderText2</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>TargetFolderText2</td><td>Text</td><td>37</td><td>151</td><td>306</td><td>13</td><td>3</td><td/><td>##IDS__IsVerifyReadyDlg_Installdir##</td><td>UserInformationText</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>UserInformationText</td><td>Text</td><td>23</td><td>171</td><td>306</td><td>13</td><td>3</td><td/><td>##IDS__IsVerifyReadyDlg_UserInfo##</td><td>UserNameText</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToInstall</td><td>UserNameText</td><td>Text</td><td>38</td><td>184</td><td>306</td><td>9</td><td>3</td><td/><td>##IDS__IsVerifyReadyDlg_UserName##</td><td>CompanyNameText</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToRemove</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_BACK##</td><td>RemoveNow</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToRemove</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>ReadyToRemove</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToRemove</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToRemove</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToRemove</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToRemove</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsVerifyRemoveAllDlg_ChoseRemoveProgram##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToRemove</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToRemove</td><td>DlgText</td><td>Text</td><td>21</td><td>51</td><td>326</td><td>24</td><td>131075</td><td/><td>##IDS__IsVerifyRemoveAllDlg_ClickRemove##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToRemove</td><td>DlgText1</td><td>Text</td><td>21</td><td>79</td><td>330</td><td>23</td><td>3</td><td/><td>##IDS__IsVerifyRemoveAllDlg_ClickBack##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToRemove</td><td>DlgText2</td><td>Text</td><td>21</td><td>102</td><td>330</td><td>24</td><td>3</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToRemove</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsVerifyRemoveAllDlg_RemoveProgram##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>ReadyToRemove</td><td>RemoveNow</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>8388611</td><td/><td>##IDS__IsVerifyRemoveAllDlg_Remove##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteError</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_BACK##</td><td>Finish</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteError</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_CANCEL##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteError</td><td>CheckShowMsiLog</td><td>CheckBox</td><td>151</td><td>172</td><td>10</td><td>9</td><td>2</td><td>ISSHOWMSILOG</td><td/><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteError</td><td>DlgLine</td><td>Line</td><td>0</td><td>234</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteError</td><td>Finish</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsFatalError_Finish##</td><td>Image</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteError</td><td>FinishText1</td><td>Text</td><td>135</td><td>80</td><td>228</td><td>50</td><td>65539</td><td/><td>##IDS__IsFatalError_NotModified##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteError</td><td>FinishText2</td><td>Text</td><td>135</td><td>135</td><td>228</td><td>25</td><td>65539</td><td/><td>##IDS__IsFatalError_ClickFinish##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteError</td><td>Image</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>234</td><td>1</td><td/><td/><td>CheckShowMsiLog</td><td/><td>0</td><td/><td/><td>NewBinary5</td></row>
		<row><td>SetupCompleteError</td><td>RestContText1</td><td>Text</td><td>135</td><td>80</td><td>228</td><td>50</td><td>65539</td><td/><td>##IDS__IsFatalError_KeepOrRestore##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteError</td><td>RestContText2</td><td>Text</td><td>135</td><td>135</td><td>228</td><td>25</td><td>65539</td><td/><td>##IDS__IsFatalError_RestoreOrContinueLater##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteError</td><td>ShowMsiLogText</td><td>Text</td><td>164</td><td>172</td><td>198</td><td>10</td><td>65538</td><td/><td>##IDS__IsSetupComplete_ShowMsiLog##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteError</td><td>TextLine1</td><td>Text</td><td>135</td><td>8</td><td>225</td><td>45</td><td>65539</td><td/><td>##IDS__IsFatalError_WizardCompleted##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteError</td><td>TextLine2</td><td>Text</td><td>135</td><td>55</td><td>228</td><td>25</td><td>196611</td><td/><td>##IDS__IsFatalError_WizardInterrupted##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_BACK##</td><td>OK</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_CANCEL##</td><td>Image</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>CheckBoxUpdates</td><td>CheckBox</td><td>135</td><td>164</td><td>10</td><td>9</td><td>2</td><td>ISCHECKFORPRODUCTUPDATES</td><td>CheckBox1</td><td>CheckShowMsiLog</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>CheckForUpdatesText</td><td>Text</td><td>152</td><td>162</td><td>190</td><td>30</td><td>65538</td><td/><td>##IDS__IsExitDialog_Update_YesCheckForUpdates##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>CheckLaunchProgram</td><td>CheckBox</td><td>151</td><td>114</td><td>10</td><td>9</td><td>2</td><td>LAUNCHPROGRAM</td><td/><td>CheckLaunchReadme</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>CheckLaunchReadme</td><td>CheckBox</td><td>151</td><td>148</td><td>10</td><td>9</td><td>2</td><td>LAUNCHREADME</td><td/><td>CheckBoxUpdates</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>CheckShowMsiLog</td><td>CheckBox</td><td>151</td><td>182</td><td>10</td><td>9</td><td>2</td><td>ISSHOWMSILOG</td><td/><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>DlgLine</td><td>Line</td><td>0</td><td>234</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>Image</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>234</td><td>1</td><td/><td/><td>CheckLaunchProgram</td><td/><td>0</td><td/><td/><td>NewBinary5</td></row>
		<row><td>SetupCompleteSuccess</td><td>LaunchProgramText</td><td>Text</td><td>164</td><td>112</td><td>98</td><td>15</td><td>65538</td><td/><td>##IDS__IsExitDialog_LaunchProgram##</td><td/><td/><td>0</td><td>0</td><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>LaunchReadmeText</td><td>Text</td><td>164</td><td>148</td><td>120</td><td>13</td><td>65538</td><td/><td>##IDS__IsExitDialog_ShowReadMe##</td><td/><td/><td>0</td><td>0</td><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>OK</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsExitDialog_Finish##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>ShowMsiLogText</td><td>Text</td><td>164</td><td>182</td><td>198</td><td>10</td><td>65538</td><td/><td>##IDS__IsSetupComplete_ShowMsiLog##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>TextLine1</td><td>Text</td><td>135</td><td>8</td><td>225</td><td>45</td><td>65539</td><td/><td>##IDS__IsExitDialog_WizardCompleted##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>TextLine2</td><td>Text</td><td>135</td><td>55</td><td>228</td><td>45</td><td>196610</td><td/><td>##IDS__IsExitDialog_InstallSuccess##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>TextLine3</td><td>Text</td><td>135</td><td>55</td><td>228</td><td>45</td><td>196610</td><td/><td>##IDS__IsExitDialog_UninstallSuccess##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>UpdateTextLine1</td><td>Text</td><td>135</td><td>30</td><td>228</td><td>45</td><td>196610</td><td/><td>##IDS__IsExitDialog_Update_SetupFinished##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>UpdateTextLine2</td><td>Text</td><td>135</td><td>80</td><td>228</td><td>45</td><td>196610</td><td/><td>##IDS__IsExitDialog_Update_PossibleUpdates##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupCompleteSuccess</td><td>UpdateTextLine3</td><td>Text</td><td>135</td><td>120</td><td>228</td><td>45</td><td>65538</td><td/><td>##IDS__IsExitDialog_Update_InternetConnection##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupError</td><td>A</td><td>PushButton</td><td>192</td><td>80</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsErrorDlg_Abort##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupError</td><td>C</td><td>PushButton</td><td>192</td><td>80</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL2##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupError</td><td>ErrorIcon</td><td>Icon</td><td>15</td><td>15</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary4</td></row>
		<row><td>SetupError</td><td>ErrorText</td><td>Text</td><td>50</td><td>15</td><td>200</td><td>50</td><td>131075</td><td/><td>##IDS__IsErrorDlg_ErrorText##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupError</td><td>I</td><td>PushButton</td><td>192</td><td>80</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsErrorDlg_Ignore##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupError</td><td>N</td><td>PushButton</td><td>192</td><td>80</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsErrorDlg_NO##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupError</td><td>O</td><td>PushButton</td><td>192</td><td>80</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsErrorDlg_OK##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupError</td><td>R</td><td>PushButton</td><td>192</td><td>80</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsErrorDlg_Retry##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupError</td><td>Y</td><td>PushButton</td><td>192</td><td>80</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsErrorDlg_Yes##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInitialization</td><td>ActionData</td><td>Text</td><td>135</td><td>125</td><td>228</td><td>12</td><td>65539</td><td/><td>##IDS__IsInitDlg_1##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInitialization</td><td>ActionText</td><td>Text</td><td>135</td><td>109</td><td>220</td><td>36</td><td>65539</td><td/><td>##IDS__IsInitDlg_2##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInitialization</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_BACK##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInitialization</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInitialization</td><td>DlgLine</td><td>Line</td><td>0</td><td>234</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInitialization</td><td>Image</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>234</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary5</td></row>
		<row><td>SetupInitialization</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_NEXT##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInitialization</td><td>TextLine1</td><td>Text</td><td>135</td><td>8</td><td>225</td><td>45</td><td>196611</td><td/><td>##IDS__IsInitDlg_WelcomeWizard##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInitialization</td><td>TextLine2</td><td>Text</td><td>135</td><td>55</td><td>228</td><td>30</td><td>196611</td><td/><td>##IDS__IsInitDlg_PreparingWizard##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInterrupted</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_BACK##</td><td>Finish</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInterrupted</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_CANCEL##</td><td>Image</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInterrupted</td><td>CheckShowMsiLog</td><td>CheckBox</td><td>151</td><td>172</td><td>10</td><td>9</td><td>2</td><td>ISSHOWMSILOG</td><td/><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInterrupted</td><td>DlgLine</td><td>Line</td><td>0</td><td>234</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInterrupted</td><td>Finish</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS__IsUserExit_Finish##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInterrupted</td><td>FinishText1</td><td>Text</td><td>135</td><td>80</td><td>228</td><td>50</td><td>65539</td><td/><td>##IDS__IsUserExit_NotModified##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInterrupted</td><td>FinishText2</td><td>Text</td><td>135</td><td>135</td><td>228</td><td>25</td><td>65539</td><td/><td>##IDS__IsUserExit_ClickFinish##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInterrupted</td><td>Image</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>234</td><td>1</td><td/><td/><td>CheckShowMsiLog</td><td/><td>0</td><td/><td/><td>NewBinary5</td></row>
		<row><td>SetupInterrupted</td><td>RestContText1</td><td>Text</td><td>135</td><td>80</td><td>228</td><td>50</td><td>65539</td><td/><td>##IDS__IsUserExit_KeepOrRestore##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInterrupted</td><td>RestContText2</td><td>Text</td><td>135</td><td>135</td><td>228</td><td>25</td><td>65539</td><td/><td>##IDS__IsUserExit_RestoreOrContinue##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInterrupted</td><td>ShowMsiLogText</td><td>Text</td><td>164</td><td>172</td><td>198</td><td>10</td><td>65538</td><td/><td>##IDS__IsSetupComplete_ShowMsiLog##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInterrupted</td><td>TextLine1</td><td>Text</td><td>135</td><td>8</td><td>225</td><td>45</td><td>65539</td><td/><td>##IDS__IsUserExit_WizardCompleted##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupInterrupted</td><td>TextLine2</td><td>Text</td><td>135</td><td>55</td><td>228</td><td>25</td><td>196611</td><td/><td>##IDS__IsUserExit_WizardInterrupted##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>ActionProgress95</td><td>ProgressBar</td><td>59</td><td>113</td><td>275</td><td>12</td><td>65537</td><td/><td>##IDS__IsProgressDlg_ProgressDone##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>ActionText</td><td>Text</td><td>59</td><td>100</td><td>275</td><td>12</td><td>3</td><td/><td>##IDS__IsProgressDlg_2##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>SetupProgress</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65538</td><td/><td>##IDS__IsProgressDlg_UninstallingFeatures2##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>DlgDesc2</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65538</td><td/><td>##IDS__IsProgressDlg_UninstallingFeatures##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>DlgText</td><td>Text</td><td>59</td><td>51</td><td>275</td><td>30</td><td>196610</td><td/><td>##IDS__IsProgressDlg_WaitUninstall2##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>DlgText2</td><td>Text</td><td>59</td><td>51</td><td>275</td><td>30</td><td>196610</td><td/><td>##IDS__IsProgressDlg_WaitUninstall##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>196610</td><td/><td>##IDS__IsProgressDlg_InstallingProductName##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>DlgTitle2</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>196610</td><td/><td>##IDS__IsProgressDlg_Uninstalling##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>LbSec</td><td>Text</td><td>192</td><td>139</td><td>32</td><td>12</td><td>2</td><td/><td>##IDS__IsProgressDlg_SecHidden##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>LbStatus</td><td>Text</td><td>59</td><td>85</td><td>70</td><td>12</td><td>3</td><td/><td>##IDS__IsProgressDlg_Status##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>SetupIcon</td><td>Icon</td><td>21</td><td>51</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary9</td></row>
		<row><td>SetupProgress</td><td>ShowTime</td><td>Text</td><td>170</td><td>139</td><td>17</td><td>12</td><td>2</td><td/><td>##IDS__IsProgressDlg_Hidden##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupProgress</td><td>TextTime</td><td>Text</td><td>59</td><td>139</td><td>110</td><td>12</td><td>2</td><td/><td>##IDS__IsProgressDlg_HiddenTimeRemaining##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupResume</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupResume</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupResume</td><td>DlgLine</td><td>Line</td><td>0</td><td>234</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupResume</td><td>Image</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>234</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary5</td></row>
		<row><td>SetupResume</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupResume</td><td>PreselectedText</td><td>Text</td><td>135</td><td>55</td><td>228</td><td>45</td><td>196611</td><td/><td>##IDS__IsResumeDlg_WizardResume##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupResume</td><td>ResumeText</td><td>Text</td><td>135</td><td>46</td><td>228</td><td>45</td><td>196611</td><td/><td>##IDS__IsResumeDlg_ResumeSuspended##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupResume</td><td>TextLine1</td><td>Text</td><td>135</td><td>8</td><td>225</td><td>45</td><td>196611</td><td/><td>##IDS__IsResumeDlg_Resuming##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupType</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupType</td><td>Banner</td><td>Bitmap</td><td>0</td><td>0</td><td>374</td><td>44</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary1</td></row>
		<row><td>SetupType</td><td>BannerLine</td><td>Line</td><td>0</td><td>44</td><td>374</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupType</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupType</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupType</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>RadioGroup</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupType</td><td>CompText</td><td>Text</td><td>80</td><td>80</td><td>246</td><td>30</td><td>3</td><td/><td>##IDS__IsSetupTypeMinDlg_AllFeatures##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupType</td><td>CompleteIco</td><td>Icon</td><td>34</td><td>80</td><td>24</td><td>24</td><td>5242881</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary10</td></row>
		<row><td>SetupType</td><td>CustText</td><td>Text</td><td>80</td><td>171</td><td>246</td><td>30</td><td>2</td><td/><td>##IDS__IsSetupTypeMinDlg_ChooseFeatures##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupType</td><td>CustomIco</td><td>Icon</td><td>34</td><td>171</td><td>24</td><td>24</td><td>5242880</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary11</td></row>
		<row><td>SetupType</td><td>DlgDesc</td><td>Text</td><td>21</td><td>23</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsSetupTypeMinDlg_ChooseSetupType##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupType</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupType</td><td>DlgText</td><td>Text</td><td>22</td><td>49</td><td>326</td><td>10</td><td>3</td><td/><td>##IDS__IsSetupTypeMinDlg_SelectSetupType##</td><td/><td/><td>0</td><td>0</td><td/><td/></row>
		<row><td>SetupType</td><td>DlgTitle</td><td>Text</td><td>13</td><td>6</td><td>292</td><td>25</td><td>65539</td><td/><td>##IDS__IsSetupTypeMinDlg_SetupType##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupType</td><td>MinIco</td><td>Icon</td><td>34</td><td>125</td><td>24</td><td>24</td><td>5242880</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary11</td></row>
		<row><td>SetupType</td><td>MinText</td><td>Text</td><td>80</td><td>125</td><td>246</td><td>30</td><td>2</td><td/><td>##IDS__IsSetupTypeMinDlg_MinimumFeatures##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupType</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SetupType</td><td>RadioGroup</td><td>RadioButtonGroup</td><td>20</td><td>59</td><td>264</td><td>139</td><td>1048579</td><td>_IsSetupTypeMin</td><td/><td>Back</td><td/><td>0</td><td>0</td><td/><td/></row>
		<row><td>SplashBitmap</td><td>Back</td><td>PushButton</td><td>164</td><td>243</td><td>66</td><td>17</td><td>1</td><td/><td>##IDS_BACK##</td><td>Next</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SplashBitmap</td><td>Branding1</td><td>Text</td><td>4</td><td>229</td><td>50</td><td>13</td><td>3</td><td/><td>##IDS_INSTALLSHIELD_FORMATTED##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SplashBitmap</td><td>Branding2</td><td>Text</td><td>3</td><td>228</td><td>50</td><td>13</td><td>65537</td><td/><td>##IDS_INSTALLSHIELD##</td><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SplashBitmap</td><td>Cancel</td><td>PushButton</td><td>301</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_CANCEL##</td><td>Back</td><td/><td>0</td><td/><td/><td/></row>
		<row><td>SplashBitmap</td><td>DlgLine</td><td>Line</td><td>48</td><td>234</td><td>326</td><td>0</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td/></row>
		<row><td>SplashBitmap</td><td>Image</td><td>Bitmap</td><td>13</td><td>12</td><td>349</td><td>211</td><td>1</td><td/><td/><td/><td/><td>0</td><td/><td/><td>NewBinary5</td></row>
		<row><td>SplashBitmap</td><td>Next</td><td>PushButton</td><td>230</td><td>243</td><td>66</td><td>17</td><td>3</td><td/><td>##IDS_NEXT##</td><td>Cancel</td><td/><td>0</td><td/><td/><td/></row>
	</table>

	<table name="ControlCondition">
		<col key="yes" def="s72">Dialog_</col>
		<col key="yes" def="s50">Control_</col>
		<col key="yes" def="s50">Action</col>
		<col key="yes" def="s255">Condition</col>
		<row><td>CustomSetup</td><td>ChangeFolder</td><td>Hide</td><td>Installed</td></row>
		<row><td>CustomSetup</td><td>Details</td><td>Hide</td><td>Installed</td></row>
		<row><td>CustomSetup</td><td>InstallLabel</td><td>Hide</td><td>Installed</td></row>
		<row><td>CustomerInformation</td><td>DlgRadioGroupText</td><td>Hide</td><td>NOT Privileged</td></row>
		<row><td>CustomerInformation</td><td>DlgRadioGroupText</td><td>Hide</td><td>ProductState &gt; 0</td></row>
		<row><td>CustomerInformation</td><td>DlgRadioGroupText</td><td>Hide</td><td>Version9X</td></row>
		<row><td>CustomerInformation</td><td>DlgRadioGroupText</td><td>Hide</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>CustomerInformation</td><td>RadioGroup</td><td>Hide</td><td>NOT Privileged</td></row>
		<row><td>CustomerInformation</td><td>RadioGroup</td><td>Hide</td><td>ProductState &gt; 0</td></row>
		<row><td>CustomerInformation</td><td>RadioGroup</td><td>Hide</td><td>Version9X</td></row>
		<row><td>CustomerInformation</td><td>RadioGroup</td><td>Hide</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>CustomerInformation</td><td>SerialLabel</td><td>Show</td><td>SERIALNUMSHOW</td></row>
		<row><td>CustomerInformation</td><td>SerialNumber</td><td>Show</td><td>SERIALNUMSHOW</td></row>
		<row><td>InstallWelcome</td><td>Copyright</td><td>Hide</td><td>SHOWCOPYRIGHT="No"</td></row>
		<row><td>InstallWelcome</td><td>Copyright</td><td>Show</td><td>SHOWCOPYRIGHT="Yes"</td></row>
		<row><td>LicenseAgreement</td><td>Next</td><td>Disable</td><td>AgreeToLicense &lt;&gt; "Yes"</td></row>
		<row><td>LicenseAgreement</td><td>Next</td><td>Enable</td><td>AgreeToLicense = "Yes"</td></row>
		<row><td>ReadyToInstall</td><td>CompanyNameText</td><td>Hide</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>ReadyToInstall</td><td>CurrentSettingsText</td><td>Hide</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>ReadyToInstall</td><td>DlgText2</td><td>Hide</td><td>VersionNT &lt; "601" OR NOT ISSupportPerUser OR Installed</td></row>
		<row><td>ReadyToInstall</td><td>DlgText2</td><td>Show</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>ReadyToInstall</td><td>DlgTitle</td><td>Show</td><td>ProgressType0="Modify"</td></row>
		<row><td>ReadyToInstall</td><td>DlgTitle2</td><td>Show</td><td>ProgressType0="Repair"</td></row>
		<row><td>ReadyToInstall</td><td>DlgTitle3</td><td>Show</td><td>ProgressType0="install"</td></row>
		<row><td>ReadyToInstall</td><td>GroupBox1</td><td>Hide</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>ReadyToInstall</td><td>InstallNow</td><td>Disable</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>ReadyToInstall</td><td>InstallNow</td><td>Enable</td><td>VersionNT &lt; "601" OR NOT ISSupportPerUser OR Installed</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerMachine</td><td>Hide</td><td>VersionNT &lt; "601" OR NOT ISSupportPerUser OR Installed</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerMachine</td><td>Show</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerUser</td><td>Hide</td><td>VersionNT &lt; "601" OR NOT ISSupportPerUser OR Installed</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerUser</td><td>Show</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>ReadyToInstall</td><td>SerialNumberText</td><td>Hide</td><td>NOT SERIALNUMSHOW</td></row>
		<row><td>ReadyToInstall</td><td>SerialNumberText</td><td>Hide</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>ReadyToInstall</td><td>SetupTypeText1</td><td>Hide</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>ReadyToInstall</td><td>SetupTypeText2</td><td>Hide</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>ReadyToInstall</td><td>TargetFolderText1</td><td>Hide</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>ReadyToInstall</td><td>TargetFolderText2</td><td>Hide</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>ReadyToInstall</td><td>UserInformationText</td><td>Hide</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>ReadyToInstall</td><td>UserNameText</td><td>Hide</td><td>VersionNT &gt;= "601" AND ISSupportPerUser AND NOT Installed</td></row>
		<row><td>SetupCompleteError</td><td>Back</td><td>Default</td><td>UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>Back</td><td>Disable</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>Back</td><td>Enable</td><td>UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>Cancel</td><td>Disable</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>Cancel</td><td>Enable</td><td>UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>CheckShowMsiLog</td><td>Show</td><td>MsiLogFileLocation</td></row>
		<row><td>SetupCompleteError</td><td>Finish</td><td>Default</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>FinishText1</td><td>Hide</td><td>UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>FinishText1</td><td>Show</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>FinishText2</td><td>Hide</td><td>UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>FinishText2</td><td>Show</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>RestContText1</td><td>Hide</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>RestContText1</td><td>Show</td><td>UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>RestContText2</td><td>Hide</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>RestContText2</td><td>Show</td><td>UpdateStarted</td></row>
		<row><td>SetupCompleteError</td><td>ShowMsiLogText</td><td>Show</td><td>MsiLogFileLocation</td></row>
		<row><td>SetupCompleteSuccess</td><td>CheckBoxUpdates</td><td>Show</td><td>ISENABLEDWUSFINISHDIALOG And NOT Installed And ACTION="INSTALL"</td></row>
		<row><td>SetupCompleteSuccess</td><td>CheckForUpdatesText</td><td>Show</td><td>ISENABLEDWUSFINISHDIALOG And NOT Installed And ACTION="INSTALL"</td></row>
		<row><td>SetupCompleteSuccess</td><td>CheckLaunchProgram</td><td>Show</td><td>SHOWLAUNCHPROGRAM="-1" And PROGRAMFILETOLAUNCHATEND &lt;&gt; "" And NOT Installed And NOT ISENABLEDWUSFINISHDIALOG</td></row>
		<row><td>SetupCompleteSuccess</td><td>CheckLaunchReadme</td><td>Show</td><td>SHOWLAUNCHREADME="-1"  And READMEFILETOLAUNCHATEND &lt;&gt; "" And NOT Installed And NOT ISENABLEDWUSFINISHDIALOG</td></row>
		<row><td>SetupCompleteSuccess</td><td>CheckShowMsiLog</td><td>Show</td><td>MsiLogFileLocation And NOT ISENABLEDWUSFINISHDIALOG</td></row>
		<row><td>SetupCompleteSuccess</td><td>LaunchProgramText</td><td>Show</td><td>SHOWLAUNCHPROGRAM="-1" And PROGRAMFILETOLAUNCHATEND &lt;&gt; "" And NOT Installed And NOT ISENABLEDWUSFINISHDIALOG</td></row>
		<row><td>SetupCompleteSuccess</td><td>LaunchReadmeText</td><td>Show</td><td>SHOWLAUNCHREADME="-1"  And READMEFILETOLAUNCHATEND &lt;&gt; "" And NOT Installed And NOT ISENABLEDWUSFINISHDIALOG</td></row>
		<row><td>SetupCompleteSuccess</td><td>ShowMsiLogText</td><td>Show</td><td>MsiLogFileLocation And NOT ISENABLEDWUSFINISHDIALOG</td></row>
		<row><td>SetupCompleteSuccess</td><td>TextLine2</td><td>Show</td><td>ProgressType2="installed" And ((ACTION&lt;&gt;"INSTALL") OR (NOT ISENABLEDWUSFINISHDIALOG) OR (ISENABLEDWUSFINISHDIALOG And Installed))</td></row>
		<row><td>SetupCompleteSuccess</td><td>TextLine3</td><td>Show</td><td>ProgressType2="uninstalled" And ((ACTION&lt;&gt;"INSTALL") OR (NOT ISENABLEDWUSFINISHDIALOG) OR (ISENABLEDWUSFINISHDIALOG And Installed))</td></row>
		<row><td>SetupCompleteSuccess</td><td>UpdateTextLine1</td><td>Show</td><td>ISENABLEDWUSFINISHDIALOG And NOT Installed And ACTION="INSTALL"</td></row>
		<row><td>SetupCompleteSuccess</td><td>UpdateTextLine2</td><td>Show</td><td>ISENABLEDWUSFINISHDIALOG And NOT Installed And ACTION="INSTALL"</td></row>
		<row><td>SetupCompleteSuccess</td><td>UpdateTextLine3</td><td>Show</td><td>ISENABLEDWUSFINISHDIALOG And NOT Installed And ACTION="INSTALL"</td></row>
		<row><td>SetupInterrupted</td><td>Back</td><td>Default</td><td>UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>Back</td><td>Disable</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>Back</td><td>Enable</td><td>UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>Cancel</td><td>Disable</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>Cancel</td><td>Enable</td><td>UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>CheckShowMsiLog</td><td>Show</td><td>MsiLogFileLocation</td></row>
		<row><td>SetupInterrupted</td><td>Finish</td><td>Default</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>FinishText1</td><td>Hide</td><td>UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>FinishText1</td><td>Show</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>FinishText2</td><td>Hide</td><td>UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>FinishText2</td><td>Show</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>RestContText1</td><td>Hide</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>RestContText1</td><td>Show</td><td>UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>RestContText2</td><td>Hide</td><td>NOT UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>RestContText2</td><td>Show</td><td>UpdateStarted</td></row>
		<row><td>SetupInterrupted</td><td>ShowMsiLogText</td><td>Show</td><td>MsiLogFileLocation</td></row>
		<row><td>SetupProgress</td><td>DlgDesc</td><td>Show</td><td>ProgressType2="installed"</td></row>
		<row><td>SetupProgress</td><td>DlgDesc2</td><td>Show</td><td>ProgressType2="uninstalled"</td></row>
		<row><td>SetupProgress</td><td>DlgText</td><td>Show</td><td>ProgressType3="installs"</td></row>
		<row><td>SetupProgress</td><td>DlgText2</td><td>Show</td><td>ProgressType3="uninstalls"</td></row>
		<row><td>SetupProgress</td><td>DlgTitle</td><td>Show</td><td>ProgressType1="Installing"</td></row>
		<row><td>SetupProgress</td><td>DlgTitle2</td><td>Show</td><td>ProgressType1="Uninstalling"</td></row>
		<row><td>SetupResume</td><td>PreselectedText</td><td>Hide</td><td>RESUME</td></row>
		<row><td>SetupResume</td><td>PreselectedText</td><td>Show</td><td>NOT RESUME</td></row>
		<row><td>SetupResume</td><td>ResumeText</td><td>Hide</td><td>NOT RESUME</td></row>
		<row><td>SetupResume</td><td>ResumeText</td><td>Show</td><td>RESUME</td></row>
	</table>

	<table name="ControlEvent">
		<col key="yes" def="s72">Dialog_</col>
		<col key="yes" def="s50">Control_</col>
		<col key="yes" def="s50">Event</col>
		<col key="yes" def="s255">Argument</col>
		<col key="yes" def="S255">Condition</col>
		<col def="I2">Ordering</col>
		<row><td>AdminChangeFolder</td><td>Cancel</td><td>EndDialog</td><td>Return</td><td>1</td><td>2</td></row>
		<row><td>AdminChangeFolder</td><td>Cancel</td><td>Reset</td><td>0</td><td>1</td><td>1</td></row>
		<row><td>AdminChangeFolder</td><td>NewFolder</td><td>DirectoryListNew</td><td>0</td><td>1</td><td>0</td></row>
		<row><td>AdminChangeFolder</td><td>OK</td><td>EndDialog</td><td>Return</td><td>1</td><td>0</td></row>
		<row><td>AdminChangeFolder</td><td>OK</td><td>SetTargetPath</td><td>TARGETDIR</td><td>1</td><td>1</td></row>
		<row><td>AdminChangeFolder</td><td>Up</td><td>DirectoryListUp</td><td>0</td><td>1</td><td>0</td></row>
		<row><td>AdminNetworkLocation</td><td>Back</td><td>NewDialog</td><td>AdminWelcome</td><td>1</td><td>0</td></row>
		<row><td>AdminNetworkLocation</td><td>Browse</td><td>SpawnDialog</td><td>AdminChangeFolder</td><td>1</td><td>0</td></row>
		<row><td>AdminNetworkLocation</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>AdminNetworkLocation</td><td>InstallNow</td><td>EndDialog</td><td>Return</td><td>OutOfNoRbDiskSpace &lt;&gt; 1</td><td>3</td></row>
		<row><td>AdminNetworkLocation</td><td>InstallNow</td><td>NewDialog</td><td>OutOfSpace</td><td>OutOfNoRbDiskSpace = 1</td><td>2</td></row>
		<row><td>AdminNetworkLocation</td><td>InstallNow</td><td>SetTargetPath</td><td>TARGETDIR</td><td>1</td><td>1</td></row>
		<row><td>AdminWelcome</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>AdminWelcome</td><td>Next</td><td>NewDialog</td><td>AdminNetworkLocation</td><td>1</td><td>0</td></row>
		<row><td>CancelSetup</td><td>No</td><td>EndDialog</td><td>Return</td><td>1</td><td>0</td></row>
		<row><td>CancelSetup</td><td>Yes</td><td>DoAction</td><td>CleanUp</td><td>ISSCRIPTRUNNING="1"</td><td>1</td></row>
		<row><td>CancelSetup</td><td>Yes</td><td>EndDialog</td><td>Exit</td><td>1</td><td>2</td></row>
		<row><td>CustomSetup</td><td>Back</td><td>NewDialog</td><td>MaintenanceType</td><td>Installed</td><td>0</td></row>
		<row><td>CustomSetup</td><td>Back</td><td>NewDialog</td><td>SetupType</td><td>NOT Installed</td><td>0</td></row>
		<row><td>CustomSetup</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>CustomSetup</td><td>ChangeFolder</td><td>SelectionBrowse</td><td>InstallChangeFolder</td><td>1</td><td>0</td></row>
		<row><td>CustomSetup</td><td>Details</td><td>SelectionBrowse</td><td>DiskSpaceRequirements</td><td>1</td><td>1</td></row>
		<row><td>CustomSetup</td><td>Help</td><td>SpawnDialog</td><td>CustomSetupTips</td><td>1</td><td>1</td></row>
		<row><td>CustomSetup</td><td>Next</td><td>NewDialog</td><td>OutOfSpace</td><td>OutOfNoRbDiskSpace = 1</td><td>0</td></row>
		<row><td>CustomSetup</td><td>Next</td><td>NewDialog</td><td>ReadyToInstall</td><td>OutOfNoRbDiskSpace &lt;&gt; 1</td><td>0</td></row>
		<row><td>CustomSetup</td><td>Next</td><td>[_IsSetupTypeMin]</td><td>Custom</td><td>1</td><td>0</td></row>
		<row><td>CustomSetupTips</td><td>OK</td><td>EndDialog</td><td>Return</td><td>1</td><td>1</td></row>
		<row><td>CustomerInformation</td><td>Back</td><td>NewDialog</td><td>InstallWelcome</td><td>NOT Installed</td><td>1</td></row>
		<row><td>CustomerInformation</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>CustomerInformation</td><td>Next</td><td>EndDialog</td><td>Exit</td><td>(SERIALNUMVALRETRYLIMIT) And (SERIALNUMVALRETRYLIMIT&lt;0) And (SERIALNUMVALRETURN&lt;&gt;SERIALNUMVALSUCCESSRETVAL)</td><td>2</td></row>
		<row><td>CustomerInformation</td><td>Next</td><td>NewDialog</td><td>DestinationFolder</td><td>(Not SERIALNUMVALRETURN) OR (SERIALNUMVALRETURN=SERIALNUMVALSUCCESSRETVAL)</td><td>3</td></row>
		<row><td>CustomerInformation</td><td>Next</td><td>[ALLUSERS]</td><td>1</td><td>ApplicationUsers = "AllUsers" And Privileged</td><td>1</td></row>
		<row><td>CustomerInformation</td><td>Next</td><td>[ALLUSERS]</td><td>{}</td><td>ApplicationUsers = "OnlyCurrentUser" And Privileged</td><td>2</td></row>
		<row><td>DatabaseFolder</td><td>Back</td><td>NewDialog</td><td>CustomerInformation</td><td>1</td><td>1</td></row>
		<row><td>DatabaseFolder</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>1</td></row>
		<row><td>DatabaseFolder</td><td>ChangeFolder</td><td>SpawnDialog</td><td>InstallChangeFolder</td><td>1</td><td>1</td></row>
		<row><td>DatabaseFolder</td><td>ChangeFolder</td><td>[_BrowseProperty]</td><td>DATABASEDIR</td><td>1</td><td>2</td></row>
		<row><td>DatabaseFolder</td><td>Next</td><td>NewDialog</td><td>SetupType</td><td>1</td><td>1</td></row>
		<row><td>DestinationFolder</td><td>Back</td><td>NewDialog</td><td>InstallWelcome</td><td>NOT Installed</td><td>0</td></row>
		<row><td>DestinationFolder</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>1</td></row>
		<row><td>DestinationFolder</td><td>ChangeFolder</td><td>SpawnDialog</td><td>InstallChangeFolder</td><td>1</td><td>1</td></row>
		<row><td>DestinationFolder</td><td>ChangeFolder</td><td>[_BrowseProperty]</td><td>INSTALLDIR</td><td>1</td><td>2</td></row>
		<row><td>DestinationFolder</td><td>Next</td><td>NewDialog</td><td>ReadyToInstall</td><td>1</td><td>0</td></row>
		<row><td>DiskSpaceRequirements</td><td>OK</td><td>EndDialog</td><td>Return</td><td>1</td><td>0</td></row>
		<row><td>FilesInUse</td><td>Exit</td><td>EndDialog</td><td>Exit</td><td>1</td><td>0</td></row>
		<row><td>FilesInUse</td><td>Ignore</td><td>EndDialog</td><td>Ignore</td><td>1</td><td>0</td></row>
		<row><td>FilesInUse</td><td>Retry</td><td>EndDialog</td><td>Retry</td><td>1</td><td>0</td></row>
		<row><td>InstallChangeFolder</td><td>Cancel</td><td>EndDialog</td><td>Return</td><td>1</td><td>2</td></row>
		<row><td>InstallChangeFolder</td><td>Cancel</td><td>Reset</td><td>0</td><td>1</td><td>1</td></row>
		<row><td>InstallChangeFolder</td><td>NewFolder</td><td>DirectoryListNew</td><td>0</td><td>1</td><td>0</td></row>
		<row><td>InstallChangeFolder</td><td>OK</td><td>EndDialog</td><td>Return</td><td>1</td><td>3</td></row>
		<row><td>InstallChangeFolder</td><td>OK</td><td>SetTargetPath</td><td>[_BrowseProperty]</td><td>1</td><td>2</td></row>
		<row><td>InstallChangeFolder</td><td>Up</td><td>DirectoryListUp</td><td>0</td><td>1</td><td>0</td></row>
		<row><td>InstallWelcome</td><td>Back</td><td>NewDialog</td><td>SplashBitmap</td><td>Display_IsBitmapDlg</td><td>0</td></row>
		<row><td>InstallWelcome</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>InstallWelcome</td><td>Next</td><td>NewDialog</td><td>DestinationFolder</td><td>1</td><td>0</td></row>
		<row><td>LicenseAgreement</td><td>Back</td><td>NewDialog</td><td>InstallWelcome</td><td>1</td><td>0</td></row>
		<row><td>LicenseAgreement</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>LicenseAgreement</td><td>ISPrintButton</td><td>DoAction</td><td>ISPrint</td><td>1</td><td>0</td></row>
		<row><td>LicenseAgreement</td><td>Next</td><td>NewDialog</td><td>CustomerInformation</td><td>AgreeToLicense = "Yes"</td><td>0</td></row>
		<row><td>MaintenanceType</td><td>Back</td><td>NewDialog</td><td>MaintenanceWelcome</td><td>1</td><td>0</td></row>
		<row><td>MaintenanceType</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>NewDialog</td><td>CustomSetup</td><td>_IsMaintenance = "Change"</td><td>12</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>NewDialog</td><td>ReadyToInstall</td><td>_IsMaintenance = "Reinstall"</td><td>13</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>NewDialog</td><td>ReadyToRemove</td><td>_IsMaintenance = "Remove"</td><td>11</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>Reinstall</td><td>ALL</td><td>_IsMaintenance = "Reinstall"</td><td>10</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>ReinstallMode</td><td>[ReinstallModeText]</td><td>_IsMaintenance = "Reinstall"</td><td>9</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>[ProgressType0]</td><td>Modify</td><td>_IsMaintenance = "Change"</td><td>2</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>[ProgressType0]</td><td>Repair</td><td>_IsMaintenance = "Reinstall"</td><td>1</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>[ProgressType1]</td><td>Modifying</td><td>_IsMaintenance = "Change"</td><td>3</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>[ProgressType1]</td><td>Repairing</td><td>_IsMaintenance = "Reinstall"</td><td>4</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>[ProgressType2]</td><td>modified</td><td>_IsMaintenance = "Change"</td><td>6</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>[ProgressType2]</td><td>repairs</td><td>_IsMaintenance = "Reinstall"</td><td>5</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>[ProgressType3]</td><td>modifies</td><td>_IsMaintenance = "Change"</td><td>7</td></row>
		<row><td>MaintenanceType</td><td>Next</td><td>[ProgressType3]</td><td>repairs</td><td>_IsMaintenance = "Reinstall"</td><td>8</td></row>
		<row><td>MaintenanceWelcome</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>MaintenanceWelcome</td><td>Next</td><td>NewDialog</td><td>MaintenanceType</td><td>1</td><td>0</td></row>
		<row><td>MsiRMFilesInUse</td><td>Cancel</td><td>EndDialog</td><td>Exit</td><td>1</td><td>1</td></row>
		<row><td>MsiRMFilesInUse</td><td>OK</td><td>EndDialog</td><td>Return</td><td>1</td><td>1</td></row>
		<row><td>MsiRMFilesInUse</td><td>OK</td><td>RMShutdownAndRestart</td><td>0</td><td>RestartManagerOption="CloseRestart"</td><td>2</td></row>
		<row><td>OutOfSpace</td><td>Resume</td><td>NewDialog</td><td>AdminNetworkLocation</td><td>ACTION = "ADMIN"</td><td>0</td></row>
		<row><td>OutOfSpace</td><td>Resume</td><td>NewDialog</td><td>DestinationFolder</td><td>ACTION &lt;&gt; "ADMIN"</td><td>0</td></row>
		<row><td>PatchWelcome</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>1</td></row>
		<row><td>PatchWelcome</td><td>Next</td><td>EndDialog</td><td>Return</td><td>1</td><td>3</td></row>
		<row><td>PatchWelcome</td><td>Next</td><td>Reinstall</td><td>ALL</td><td>PATCH And REINSTALL=""</td><td>1</td></row>
		<row><td>PatchWelcome</td><td>Next</td><td>ReinstallMode</td><td>omus</td><td>PATCH And REINSTALLMODE=""</td><td>2</td></row>
		<row><td>ReadmeInformation</td><td>Back</td><td>NewDialog</td><td>LicenseAgreement</td><td>1</td><td>1</td></row>
		<row><td>ReadmeInformation</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>1</td></row>
		<row><td>ReadmeInformation</td><td>Next</td><td>NewDialog</td><td>CustomerInformation</td><td>1</td><td>1</td></row>
		<row><td>ReadyToInstall</td><td>Back</td><td>NewDialog</td><td>CustomSetup</td><td>Installed OR _IsSetupTypeMin = "Custom"</td><td>2</td></row>
		<row><td>ReadyToInstall</td><td>Back</td><td>NewDialog</td><td>DestinationFolder</td><td>NOT Installed</td><td>1</td></row>
		<row><td>ReadyToInstall</td><td>Back</td><td>NewDialog</td><td>MaintenanceType</td><td>Installed AND _IsMaintenance = "Reinstall"</td><td>3</td></row>
		<row><td>ReadyToInstall</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallNow</td><td>EndDialog</td><td>Return</td><td>OutOfNoRbDiskSpace &lt;&gt; 1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallNow</td><td>NewDialog</td><td>OutOfSpace</td><td>OutOfNoRbDiskSpace = 1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallNow</td><td>[ProgressType1]</td><td>Installing</td><td>1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallNow</td><td>[ProgressType2]</td><td>installed</td><td>1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallNow</td><td>[ProgressType3]</td><td>installs</td><td>1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerMachine</td><td>EndDialog</td><td>Return</td><td>OutOfNoRbDiskSpace &lt;&gt; 1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerMachine</td><td>NewDialog</td><td>OutOfSpace</td><td>OutOfNoRbDiskSpace = 1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerMachine</td><td>[ALLUSERS]</td><td>1</td><td>1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerMachine</td><td>[MSIINSTALLPERUSER]</td><td>{}</td><td>1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerMachine</td><td>[ProgressType1]</td><td>Installing</td><td>1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerMachine</td><td>[ProgressType2]</td><td>installed</td><td>1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerMachine</td><td>[ProgressType3]</td><td>installs</td><td>1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerUser</td><td>EndDialog</td><td>Return</td><td>OutOfNoRbDiskSpace &lt;&gt; 1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerUser</td><td>NewDialog</td><td>OutOfSpace</td><td>OutOfNoRbDiskSpace = 1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerUser</td><td>[ALLUSERS]</td><td>2</td><td>1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerUser</td><td>[MSIINSTALLPERUSER]</td><td>1</td><td>1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerUser</td><td>[ProgressType1]</td><td>Installing</td><td>1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerUser</td><td>[ProgressType2]</td><td>installed</td><td>1</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>InstallPerUser</td><td>[ProgressType3]</td><td>installs</td><td>1</td><td>0</td></row>
		<row><td>ReadyToRemove</td><td>Back</td><td>NewDialog</td><td>MaintenanceType</td><td>1</td><td>0</td></row>
		<row><td>ReadyToRemove</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>ReadyToRemove</td><td>RemoveNow</td><td>EndDialog</td><td>Return</td><td>OutOfNoRbDiskSpace &lt;&gt; 1</td><td>2</td></row>
		<row><td>ReadyToRemove</td><td>RemoveNow</td><td>NewDialog</td><td>OutOfSpace</td><td>OutOfNoRbDiskSpace = 1</td><td>2</td></row>
		<row><td>ReadyToRemove</td><td>RemoveNow</td><td>Remove</td><td>ALL</td><td>1</td><td>1</td></row>
		<row><td>ReadyToRemove</td><td>RemoveNow</td><td>[ProgressType1]</td><td>Uninstalling</td><td>1</td><td>0</td></row>
		<row><td>ReadyToRemove</td><td>RemoveNow</td><td>[ProgressType2]</td><td>uninstalled</td><td>1</td><td>0</td></row>
		<row><td>ReadyToRemove</td><td>RemoveNow</td><td>[ProgressType3]</td><td>uninstalls</td><td>1</td><td>0</td></row>
		<row><td>SetupCompleteError</td><td>Back</td><td>EndDialog</td><td>Return</td><td>1</td><td>2</td></row>
		<row><td>SetupCompleteError</td><td>Back</td><td>[Suspend]</td><td>{}</td><td>1</td><td>1</td></row>
		<row><td>SetupCompleteError</td><td>Cancel</td><td>EndDialog</td><td>Return</td><td>1</td><td>2</td></row>
		<row><td>SetupCompleteError</td><td>Cancel</td><td>[Suspend]</td><td>1</td><td>1</td><td>1</td></row>
		<row><td>SetupCompleteError</td><td>Finish</td><td>DoAction</td><td>CleanUp</td><td>ISSCRIPTRUNNING="1"</td><td>1</td></row>
		<row><td>SetupCompleteError</td><td>Finish</td><td>DoAction</td><td>ShowMsiLog</td><td>MsiLogFileLocation And (ISSHOWMSILOG="1")</td><td>3</td></row>
		<row><td>SetupCompleteError</td><td>Finish</td><td>EndDialog</td><td>Exit</td><td>1</td><td>2</td></row>
		<row><td>SetupCompleteSuccess</td><td>OK</td><td>DoAction</td><td>CleanUp</td><td>ISSCRIPTRUNNING="1"</td><td>1</td></row>
		<row><td>SetupCompleteSuccess</td><td>OK</td><td>DoAction</td><td>ShowMsiLog</td><td>MsiLogFileLocation And (ISSHOWMSILOG="1") And NOT ISENABLEDWUSFINISHDIALOG</td><td>6</td></row>
		<row><td>SetupCompleteSuccess</td><td>OK</td><td>EndDialog</td><td>Exit</td><td>1</td><td>2</td></row>
		<row><td>SetupError</td><td>A</td><td>EndDialog</td><td>ErrorAbort</td><td>1</td><td>0</td></row>
		<row><td>SetupError</td><td>C</td><td>EndDialog</td><td>ErrorCancel</td><td>1</td><td>0</td></row>
		<row><td>SetupError</td><td>I</td><td>EndDialog</td><td>ErrorIgnore</td><td>1</td><td>0</td></row>
		<row><td>SetupError</td><td>N</td><td>EndDialog</td><td>ErrorNo</td><td>1</td><td>0</td></row>
		<row><td>SetupError</td><td>O</td><td>EndDialog</td><td>ErrorOk</td><td>1</td><td>0</td></row>
		<row><td>SetupError</td><td>R</td><td>EndDialog</td><td>ErrorRetry</td><td>1</td><td>0</td></row>
		<row><td>SetupError</td><td>Y</td><td>EndDialog</td><td>ErrorYes</td><td>1</td><td>0</td></row>
		<row><td>SetupInitialization</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>SetupInterrupted</td><td>Back</td><td>EndDialog</td><td>Exit</td><td>1</td><td>2</td></row>
		<row><td>SetupInterrupted</td><td>Back</td><td>[Suspend]</td><td>{}</td><td>1</td><td>1</td></row>
		<row><td>SetupInterrupted</td><td>Cancel</td><td>EndDialog</td><td>Exit</td><td>1</td><td>2</td></row>
		<row><td>SetupInterrupted</td><td>Cancel</td><td>[Suspend]</td><td>1</td><td>1</td><td>1</td></row>
		<row><td>SetupInterrupted</td><td>Finish</td><td>DoAction</td><td>CleanUp</td><td>ISSCRIPTRUNNING="1"</td><td>1</td></row>
		<row><td>SetupInterrupted</td><td>Finish</td><td>DoAction</td><td>ShowMsiLog</td><td>MsiLogFileLocation And (ISSHOWMSILOG="1")</td><td>3</td></row>
		<row><td>SetupInterrupted</td><td>Finish</td><td>EndDialog</td><td>Exit</td><td>1</td><td>2</td></row>
		<row><td>SetupProgress</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>SetupResume</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>SetupResume</td><td>Next</td><td>EndDialog</td><td>Return</td><td>OutOfNoRbDiskSpace &lt;&gt; 1</td><td>0</td></row>
		<row><td>SetupResume</td><td>Next</td><td>NewDialog</td><td>OutOfSpace</td><td>OutOfNoRbDiskSpace = 1</td><td>0</td></row>
		<row><td>SetupType</td><td>Back</td><td>NewDialog</td><td>CustomerInformation</td><td>1</td><td>1</td></row>
		<row><td>SetupType</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>SetupType</td><td>Next</td><td>NewDialog</td><td>CustomSetup</td><td>_IsSetupTypeMin = "Custom"</td><td>2</td></row>
		<row><td>SetupType</td><td>Next</td><td>NewDialog</td><td>ReadyToInstall</td><td>_IsSetupTypeMin &lt;&gt; "Custom"</td><td>1</td></row>
		<row><td>SetupType</td><td>Next</td><td>SetInstallLevel</td><td>100</td><td>_IsSetupTypeMin="Minimal"</td><td>0</td></row>
		<row><td>SetupType</td><td>Next</td><td>SetInstallLevel</td><td>200</td><td>_IsSetupTypeMin="Typical"</td><td>0</td></row>
		<row><td>SetupType</td><td>Next</td><td>SetInstallLevel</td><td>300</td><td>_IsSetupTypeMin="Custom"</td><td>0</td></row>
		<row><td>SetupType</td><td>Next</td><td>[ISRUNSETUPTYPEADDLOCALEVENT]</td><td>1</td><td>1</td><td>0</td></row>
		<row><td>SetupType</td><td>Next</td><td>[SelectedSetupType]</td><td>[DisplayNameCustom]</td><td>_IsSetupTypeMin = "Custom"</td><td>0</td></row>
		<row><td>SetupType</td><td>Next</td><td>[SelectedSetupType]</td><td>[DisplayNameMinimal]</td><td>_IsSetupTypeMin = "Minimal"</td><td>0</td></row>
		<row><td>SetupType</td><td>Next</td><td>[SelectedSetupType]</td><td>[DisplayNameTypical]</td><td>_IsSetupTypeMin = "Typical"</td><td>0</td></row>
		<row><td>SplashBitmap</td><td>Cancel</td><td>SpawnDialog</td><td>CancelSetup</td><td>1</td><td>0</td></row>
		<row><td>SplashBitmap</td><td>Next</td><td>NewDialog</td><td>InstallWelcome</td><td>1</td><td>0</td></row>
	</table>

	<table name="CreateFolder">
		<col key="yes" def="s72">Directory_</col>
		<col key="yes" def="s72">Component_</col>
		<row><td>BE</td><td>ISX_DEFAULTCOMPONENT4</td></row>
		<row><td>BE</td><td>Samraksh_eMote.dll</td></row>
		<row><td>BE1</td><td>ISX_DEFAULTCOMPONENT7</td></row>
		<row><td>BE1</td><td>Samraksh_eMote_Adapt.dll</td></row>
		<row><td>BE10</td><td>ISX_DEFAULTCOMPONENT40</td></row>
		<row><td>BE10</td><td>Samraksh_eMote_DotNow.dll4</td></row>
		<row><td>BE11</td><td>ISX_DEFAULTCOMPONENT43</td></row>
		<row><td>BE11</td><td>Samraksh_eMote_DSP.dll3</td></row>
		<row><td>BE12</td><td>ISX_DEFAULTCOMPONENT46</td></row>
		<row><td>BE12</td><td>Samraksh_eMote_Kiwi.dll3</td></row>
		<row><td>BE13</td><td>ISX_DEFAULTCOMPONENT49</td></row>
		<row><td>BE13</td><td>Samraksh_eMote_Net.dll3</td></row>
		<row><td>BE14</td><td>ISX_DEFAULTCOMPONENT52</td></row>
		<row><td>BE14</td><td>Samraksh_eMote_RealTime.dll3</td></row>
		<row><td>BE15</td><td>ISX_DEFAULTCOMPONENT57</td></row>
		<row><td>BE16</td><td>ISX_DEFAULTCOMPONENT64</td></row>
		<row><td>BE16</td><td>TestEnhancedeMoteLCD.exe3</td></row>
		<row><td>BE17</td><td>ISX_DEFAULTCOMPONENT70</td></row>
		<row><td>BE18</td><td>ISX_DEFAULTCOMPONENT76</td></row>
		<row><td>BE18</td><td>Samraksh.AppNote.Utility.VersionInfo.dll2</td></row>
		<row><td>BE19</td><td>ISX_DEFAULTCOMPONENT80</td></row>
		<row><td>BE19</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll</td></row>
		<row><td>BE2</td><td>ISX_DEFAULTCOMPONENT10</td></row>
		<row><td>BE2</td><td>Samraksh_eMote_DotNow.dll</td></row>
		<row><td>BE20</td><td>ISX_DEFAULTCOMPONENT86</td></row>
		<row><td>BE20</td><td>Samraksh_eMote.dll6</td></row>
		<row><td>BE21</td><td>ISX_DEFAULTCOMPONENT89</td></row>
		<row><td>BE21</td><td>Samraksh_eMote_Adapt.dll6</td></row>
		<row><td>BE22</td><td>ISX_DEFAULTCOMPONENT92</td></row>
		<row><td>BE22</td><td>Samraksh_eMote_DotNow.dll8</td></row>
		<row><td>BE23</td><td>ISX_DEFAULTCOMPONENT95</td></row>
		<row><td>BE23</td><td>Samraksh_eMote_DSP.dll6</td></row>
		<row><td>BE24</td><td>ISX_DEFAULTCOMPONENT98</td></row>
		<row><td>BE24</td><td>Samraksh_eMote_Kiwi.dll6</td></row>
		<row><td>BE25</td><td>ISX_DEFAULTCOMPONENT101</td></row>
		<row><td>BE25</td><td>Samraksh_eMote_Net.dll7</td></row>
		<row><td>BE26</td><td>ISX_DEFAULTCOMPONENT104</td></row>
		<row><td>BE26</td><td>Samraksh_eMote_RealTime.dll6</td></row>
		<row><td>BE27</td><td>ISX_DEFAULTCOMPONENT109</td></row>
		<row><td>BE27</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll3</td></row>
		<row><td>BE27</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td></row>
		<row><td>BE28</td><td>ISX_DEFAULTCOMPONENT114</td></row>
		<row><td>BE29</td><td>ISX_DEFAULTCOMPONENT121</td></row>
		<row><td>BE29</td><td>Samraksh.AppNote.Utility.BitConverter.dll</td></row>
		<row><td>BE3</td><td>ISX_DEFAULTCOMPONENT13</td></row>
		<row><td>BE3</td><td>Samraksh_eMote_DSP.dll</td></row>
		<row><td>BE30</td><td>ISX_DEFAULTCOMPONENT128</td></row>
		<row><td>BE31</td><td>ISX_DEFAULTCOMPONENT134</td></row>
		<row><td>BE31</td><td>Samraksh.AppNote.Utility.SerialComm.dll</td></row>
		<row><td>BE32</td><td>ISX_DEFAULTCOMPONENT139</td></row>
		<row><td>BE33</td><td>ISX_DEFAULTCOMPONENT145</td></row>
		<row><td>BE33</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll</td></row>
		<row><td>BE34</td><td>ISX_DEFAULTCOMPONENT150</td></row>
		<row><td>BE35</td><td>ISX_DEFAULTCOMPONENT156</td></row>
		<row><td>BE35</td><td>Samraksh.AppNote.Utility.Sqrt.dll</td></row>
		<row><td>BE36</td><td>ISX_DEFAULTCOMPONENT161</td></row>
		<row><td>BE37</td><td>ISX_DEFAULTCOMPONENT167</td></row>
		<row><td>BE37</td><td>Samraksh.AppNote.Utility.VersionInfo.dll5</td></row>
		<row><td>BE38</td><td>ISX_DEFAULTCOMPONENT174</td></row>
		<row><td>BE4</td><td>ISX_DEFAULTCOMPONENT16</td></row>
		<row><td>BE4</td><td>Samraksh_eMote_Kiwi.dll</td></row>
		<row><td>BE5</td><td>ISX_DEFAULTCOMPONENT19</td></row>
		<row><td>BE5</td><td>Samraksh_eMote_Net.dll</td></row>
		<row><td>BE6</td><td>ISX_DEFAULTCOMPONENT22</td></row>
		<row><td>BE6</td><td>Samraksh_eMote_RealTime.dll</td></row>
		<row><td>BE7</td><td>ISX_DEFAULTCOMPONENT28</td></row>
		<row><td>BE7</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td></row>
		<row><td>BE7</td><td>TestEnhancedeMoteLCD.exe</td></row>
		<row><td>BE8</td><td>ISX_DEFAULTCOMPONENT34</td></row>
		<row><td>BE8</td><td>Samraksh_eMote.dll3</td></row>
		<row><td>BE9</td><td>ISX_DEFAULTCOMPONENT37</td></row>
		<row><td>BE9</td><td>Samraksh_eMote_Adapt.dll3</td></row>
		<row><td>BIN</td><td>ISX_DEFAULTCOMPONENT27</td></row>
		<row><td>BIN</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll2</td></row>
		<row><td>BIN</td><td>Samraksh.AppNote.Utility.VersionInfo.dll</td></row>
		<row><td>BIN</td><td>Samraksh_eMote_DotNow.dll3</td></row>
		<row><td>BIN</td><td>TestEnhancedeMoteLCD.exe2</td></row>
		<row><td>BIN1</td><td>ISX_DEFAULTCOMPONENT62</td></row>
		<row><td>BIN10</td><td>ISX_DEFAULTCOMPONENT170</td></row>
		<row><td>BIN2</td><td>ISX_DEFAULTCOMPONENT79</td></row>
		<row><td>BIN2</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll2</td></row>
		<row><td>BIN2</td><td>Samraksh_eMote_Net.dll6</td></row>
		<row><td>BIN3</td><td>ISX_DEFAULTCOMPONENT107</td></row>
		<row><td>BIN4</td><td>ISX_DEFAULTCOMPONENT120</td></row>
		<row><td>BIN4</td><td>Samraksh.AppNote.Utility.BitConverter.dll2</td></row>
		<row><td>BIN5</td><td>ISX_DEFAULTCOMPONENT124</td></row>
		<row><td>BIN6</td><td>ISX_DEFAULTCOMPONENT133</td></row>
		<row><td>BIN6</td><td>Samraksh.AppNote.Utility.SerialComm.dll2</td></row>
		<row><td>BIN7</td><td>ISX_DEFAULTCOMPONENT144</td></row>
		<row><td>BIN7</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll2</td></row>
		<row><td>BIN8</td><td>ISX_DEFAULTCOMPONENT155</td></row>
		<row><td>BIN8</td><td>Samraksh.AppNote.Utility.Sqrt.dll2</td></row>
		<row><td>BIN9</td><td>ISX_DEFAULTCOMPONENT166</td></row>
		<row><td>BIN9</td><td>Samraksh.AppNote.Utility.VersionInfo.dll7</td></row>
		<row><td>BITCONVERTER</td><td>ISX_DEFAULTCOMPONENT119</td></row>
		<row><td>BITCONVERTER1</td><td>ISX_DEFAULTCOMPONENT123</td></row>
		<row><td>CLRANDBOOTER</td><td>ISX_DEFAULTCOMPONENT1</td></row>
		<row><td>CLRANDBOOTER1</td><td>ISX_DEFAULTCOMPONENT31</td></row>
		<row><td>CLRANDBOOTER2</td><td>ISX_DEFAULTCOMPONENT83</td></row>
		<row><td>DEBUG</td><td>ISX_DEFAULTCOMPONENT56</td></row>
		<row><td>DEBUG</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll3</td></row>
		<row><td>DEBUG1</td><td>ISX_DEFAULTCOMPONENT63</td></row>
		<row><td>DEBUG1</td><td>Samraksh.AppNote.Utility.EnhancedeMoteLcd.dll</td></row>
		<row><td>DEBUG1</td><td>Samraksh.AppNote.Utility.VersionInfo.dll1</td></row>
		<row><td>DEBUG1</td><td>Samraksh_eMote_DotNow.dll7</td></row>
		<row><td>DEBUG1</td><td>TestEnhancedeMoteLCD.exe5</td></row>
		<row><td>DEBUG10</td><td>ISX_DEFAULTCOMPONENT173</td></row>
		<row><td>DEBUG10</td><td>Samraksh.AppNote.Utility.VersionInfo.dll8</td></row>
		<row><td>DEBUG2</td><td>ISX_DEFAULTCOMPONENT69</td></row>
		<row><td>DEBUG2</td><td>TestEnhancedeMoteLCD.exe6</td></row>
		<row><td>DEBUG3</td><td>ISX_DEFAULTCOMPONENT108</td></row>
		<row><td>DEBUG3</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll5</td></row>
		<row><td>DEBUG3</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll2</td></row>
		<row><td>DEBUG3</td><td>Samraksh_eMote_Net.dll10</td></row>
		<row><td>DEBUG4</td><td>ISX_DEFAULTCOMPONENT113</td></row>
		<row><td>DEBUG4</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll6</td></row>
		<row><td>DEBUG4</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll3</td></row>
		<row><td>DEBUG5</td><td>ISX_DEFAULTCOMPONENT127</td></row>
		<row><td>DEBUG5</td><td>Samraksh.AppNote.Utility.BitConverter.dll3</td></row>
		<row><td>DEBUG6</td><td>ISX_DEFAULTCOMPONENT138</td></row>
		<row><td>DEBUG6</td><td>Samraksh.AppNote.Utility.SerialComm.dll3</td></row>
		<row><td>DEBUG7</td><td>ISX_DEFAULTCOMPONENT149</td></row>
		<row><td>DEBUG7</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll3</td></row>
		<row><td>DEBUG8</td><td>ISX_DEFAULTCOMPONENT160</td></row>
		<row><td>DEBUG8</td><td>Samraksh.AppNote.Utility.Sqrt.dll3</td></row>
		<row><td>DEBUG9</td><td>ISX_DEFAULTCOMPONENT171</td></row>
		<row><td>DOTNETMF_FS_EMULATION</td><td>ISX_DEFAULTCOMPONENT66</td></row>
		<row><td>DOTNOW</td><td>ISX_DEFAULTCOMPONENT25</td></row>
		<row><td>EMOTE_.NOW</td><td>ISX_DEFAULTCOMPONENT</td></row>
		<row><td>EMOTE_.NOW_RELEASE_4.3.0.14</td><td>ISX_DEFAULTCOMPONENT30</td></row>
		<row><td>EMOTE_.NOW_RELEASE_4.3.0.141</td><td>ISX_DEFAULTCOMPONENT82</td></row>
		<row><td>EMOTE_TINYCLR_V14.HEX</td><td>ISX_DEFAULTCOMPONENT2</td></row>
		<row><td>EMOTE_TINYCLR_V14.HEX1</td><td>ISX_DEFAULTCOMPONENT32</td></row>
		<row><td>EMOTE_TINYCLR_V14.HEX2</td><td>ISX_DEFAULTCOMPONENT84</td></row>
		<row><td>ENHANCEDEMOTELCD</td><td>ISX_DEFAULTCOMPONENT26</td></row>
		<row><td>ENHANCEDEMOTELCD1</td><td>ISX_DEFAULTCOMPONENT54</td></row>
		<row><td>GENERAL</td><td>ISX_DEFAULTCOMPONENT118</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT1</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT10</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT100</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT101</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT102</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT103</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT104</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT105</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT106</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT107</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT108</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT109</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT11</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT110</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT111</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT112</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT113</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT114</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT115</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT116</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT117</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT118</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT119</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT12</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT120</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT121</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT122</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT123</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT124</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT125</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT126</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT127</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT128</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT129</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT13</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT130</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT131</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT132</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT133</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT134</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT135</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT136</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT137</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT138</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT139</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT14</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT140</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT141</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT142</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT143</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT144</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT145</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT146</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT147</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT148</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT149</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT15</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT150</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT151</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT152</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT153</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT154</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT155</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT156</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT157</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT158</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT159</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT16</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT160</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT161</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT162</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT163</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT164</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT165</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT166</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT167</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT168</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT169</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT17</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT170</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT171</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT172</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT173</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT174</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT175</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT176</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT177</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT18</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT19</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT2</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT20</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT21</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT22</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT23</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT24</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT25</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT26</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT27</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT28</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT29</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT3</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT30</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT31</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT32</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT33</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT34</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT35</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT36</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT37</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT38</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT39</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT4</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT40</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT41</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT42</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT43</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT44</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT45</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT46</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT47</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT48</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT49</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT5</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT50</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT51</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT52</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT53</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT54</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT55</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT56</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT57</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT58</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT59</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT6</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT60</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT61</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT62</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT63</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT64</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT65</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT66</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT67</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT68</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT69</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT7</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT70</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT71</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT72</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT73</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT74</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT75</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT76</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT77</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT78</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT79</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT8</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT80</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT81</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT82</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT83</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT84</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT85</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT86</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT87</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT88</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT89</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT9</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT90</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT91</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT92</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT93</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT94</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT95</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT96</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT97</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT98</td></row>
		<row><td>INSTALLDIR</td><td>ISX_DEFAULTCOMPONENT99</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.BitConverter.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.BitConverter.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.BitConverter.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.BitConverter.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.EnhancedeMoteLcd.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SerialComm.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SerialComm.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SerialComm.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SerialComm.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll4</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll5</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll6</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.Sqrt.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.Sqrt.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.Sqrt.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.Sqrt.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.VersionInfo.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.VersionInfo.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.VersionInfo.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.VersionInfo.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.VersionInfo.dll4</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.VersionInfo.dll5</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.VersionInfo.dll6</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.VersionInfo.dll7</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh.AppNote.Utility.VersionInfo.dll8</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote.dll4</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote.dll5</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote.dll6</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote.dll7</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote.dll8</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Adapt.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Adapt.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Adapt.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Adapt.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Adapt.dll4</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Adapt.dll5</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Adapt.dll6</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Adapt.dll7</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Adapt.dll8</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DSP.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DSP.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DSP.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DSP.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DSP.dll4</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DSP.dll5</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DSP.dll6</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DSP.dll7</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DSP.dll8</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DotNow.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DotNow.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DotNow.dll10</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DotNow.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DotNow.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DotNow.dll4</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DotNow.dll5</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DotNow.dll6</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DotNow.dll7</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DotNow.dll8</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_DotNow.dll9</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Kiwi.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Kiwi.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Kiwi.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Kiwi.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Kiwi.dll4</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Kiwi.dll5</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Kiwi.dll6</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Kiwi.dll7</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Kiwi.dll8</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Net.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Net.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Net.dll10</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Net.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Net.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Net.dll4</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Net.dll5</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Net.dll6</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Net.dll7</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Net.dll8</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_Net.dll9</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_RealTime.dll</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_RealTime.dll1</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_RealTime.dll2</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_RealTime.dll3</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_RealTime.dll4</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_RealTime.dll5</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_RealTime.dll6</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_RealTime.dll7</td></row>
		<row><td>INSTALLDIR</td><td>Samraksh_eMote_RealTime.dll8</td></row>
		<row><td>INSTALLDIR</td><td>TestEnhancedeMoteLCD.exe</td></row>
		<row><td>INSTALLDIR</td><td>TestEnhancedeMoteLCD.exe1</td></row>
		<row><td>INSTALLDIR</td><td>TestEnhancedeMoteLCD.exe2</td></row>
		<row><td>INSTALLDIR</td><td>TestEnhancedeMoteLCD.exe3</td></row>
		<row><td>INSTALLDIR</td><td>TestEnhancedeMoteLCD.exe4</td></row>
		<row><td>INSTALLDIR</td><td>TestEnhancedeMoteLCD.exe5</td></row>
		<row><td>INSTALLDIR</td><td>TestEnhancedeMoteLCD.exe6</td></row>
		<row><td>LE</td><td>ISX_DEFAULTCOMPONENT5</td></row>
		<row><td>LE</td><td>Samraksh_eMote.dll1</td></row>
		<row><td>LE1</td><td>ISX_DEFAULTCOMPONENT8</td></row>
		<row><td>LE1</td><td>Samraksh_eMote_Adapt.dll1</td></row>
		<row><td>LE10</td><td>ISX_DEFAULTCOMPONENT41</td></row>
		<row><td>LE10</td><td>Samraksh_eMote_DotNow.dll5</td></row>
		<row><td>LE11</td><td>ISX_DEFAULTCOMPONENT44</td></row>
		<row><td>LE11</td><td>Samraksh_eMote_DSP.dll4</td></row>
		<row><td>LE12</td><td>ISX_DEFAULTCOMPONENT47</td></row>
		<row><td>LE12</td><td>Samraksh_eMote_Kiwi.dll4</td></row>
		<row><td>LE13</td><td>ISX_DEFAULTCOMPONENT50</td></row>
		<row><td>LE13</td><td>Samraksh_eMote_Net.dll4</td></row>
		<row><td>LE14</td><td>ISX_DEFAULTCOMPONENT53</td></row>
		<row><td>LE14</td><td>Samraksh_eMote_RealTime.dll4</td></row>
		<row><td>LE15</td><td>ISX_DEFAULTCOMPONENT58</td></row>
		<row><td>LE16</td><td>ISX_DEFAULTCOMPONENT65</td></row>
		<row><td>LE16</td><td>TestEnhancedeMoteLCD.exe4</td></row>
		<row><td>LE17</td><td>ISX_DEFAULTCOMPONENT71</td></row>
		<row><td>LE18</td><td>ISX_DEFAULTCOMPONENT77</td></row>
		<row><td>LE18</td><td>Samraksh.AppNote.Utility.VersionInfo.dll3</td></row>
		<row><td>LE19</td><td>ISX_DEFAULTCOMPONENT81</td></row>
		<row><td>LE19</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll1</td></row>
		<row><td>LE2</td><td>ISX_DEFAULTCOMPONENT11</td></row>
		<row><td>LE2</td><td>Samraksh_eMote_DotNow.dll1</td></row>
		<row><td>LE20</td><td>ISX_DEFAULTCOMPONENT87</td></row>
		<row><td>LE20</td><td>Samraksh_eMote.dll7</td></row>
		<row><td>LE21</td><td>ISX_DEFAULTCOMPONENT90</td></row>
		<row><td>LE21</td><td>Samraksh_eMote_Adapt.dll7</td></row>
		<row><td>LE22</td><td>ISX_DEFAULTCOMPONENT93</td></row>
		<row><td>LE22</td><td>Samraksh_eMote_DotNow.dll9</td></row>
		<row><td>LE23</td><td>ISX_DEFAULTCOMPONENT96</td></row>
		<row><td>LE23</td><td>Samraksh_eMote_DSP.dll7</td></row>
		<row><td>LE24</td><td>ISX_DEFAULTCOMPONENT99</td></row>
		<row><td>LE24</td><td>Samraksh_eMote_Kiwi.dll7</td></row>
		<row><td>LE25</td><td>ISX_DEFAULTCOMPONENT102</td></row>
		<row><td>LE25</td><td>Samraksh_eMote_Net.dll8</td></row>
		<row><td>LE26</td><td>ISX_DEFAULTCOMPONENT105</td></row>
		<row><td>LE26</td><td>Samraksh_eMote_RealTime.dll7</td></row>
		<row><td>LE27</td><td>ISX_DEFAULTCOMPONENT110</td></row>
		<row><td>LE27</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll4</td></row>
		<row><td>LE27</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll1</td></row>
		<row><td>LE28</td><td>ISX_DEFAULTCOMPONENT115</td></row>
		<row><td>LE29</td><td>ISX_DEFAULTCOMPONENT122</td></row>
		<row><td>LE29</td><td>Samraksh.AppNote.Utility.BitConverter.dll1</td></row>
		<row><td>LE3</td><td>ISX_DEFAULTCOMPONENT14</td></row>
		<row><td>LE3</td><td>Samraksh_eMote_DSP.dll1</td></row>
		<row><td>LE30</td><td>ISX_DEFAULTCOMPONENT129</td></row>
		<row><td>LE31</td><td>ISX_DEFAULTCOMPONENT135</td></row>
		<row><td>LE31</td><td>Samraksh.AppNote.Utility.SerialComm.dll1</td></row>
		<row><td>LE32</td><td>ISX_DEFAULTCOMPONENT140</td></row>
		<row><td>LE33</td><td>ISX_DEFAULTCOMPONENT146</td></row>
		<row><td>LE33</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll1</td></row>
		<row><td>LE34</td><td>ISX_DEFAULTCOMPONENT151</td></row>
		<row><td>LE35</td><td>ISX_DEFAULTCOMPONENT157</td></row>
		<row><td>LE35</td><td>Samraksh.AppNote.Utility.Sqrt.dll1</td></row>
		<row><td>LE36</td><td>ISX_DEFAULTCOMPONENT162</td></row>
		<row><td>LE37</td><td>ISX_DEFAULTCOMPONENT168</td></row>
		<row><td>LE37</td><td>Samraksh.AppNote.Utility.VersionInfo.dll6</td></row>
		<row><td>LE38</td><td>ISX_DEFAULTCOMPONENT175</td></row>
		<row><td>LE4</td><td>ISX_DEFAULTCOMPONENT17</td></row>
		<row><td>LE4</td><td>Samraksh_eMote_Kiwi.dll1</td></row>
		<row><td>LE5</td><td>ISX_DEFAULTCOMPONENT20</td></row>
		<row><td>LE5</td><td>Samraksh_eMote_Net.dll1</td></row>
		<row><td>LE6</td><td>ISX_DEFAULTCOMPONENT23</td></row>
		<row><td>LE6</td><td>Samraksh_eMote_RealTime.dll1</td></row>
		<row><td>LE7</td><td>ISX_DEFAULTCOMPONENT29</td></row>
		<row><td>LE7</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll1</td></row>
		<row><td>LE7</td><td>TestEnhancedeMoteLCD.exe1</td></row>
		<row><td>LE8</td><td>ISX_DEFAULTCOMPONENT35</td></row>
		<row><td>LE8</td><td>Samraksh_eMote.dll4</td></row>
		<row><td>LE9</td><td>ISX_DEFAULTCOMPONENT38</td></row>
		<row><td>LE9</td><td>Samraksh_eMote_Adapt.dll4</td></row>
		<row><td>OBJ</td><td>ISX_DEFAULTCOMPONENT55</td></row>
		<row><td>OBJ1</td><td>ISX_DEFAULTCOMPONENT68</td></row>
		<row><td>OBJ2</td><td>ISX_DEFAULTCOMPONENT112</td></row>
		<row><td>OBJ3</td><td>ISX_DEFAULTCOMPONENT126</td></row>
		<row><td>OBJ4</td><td>ISX_DEFAULTCOMPONENT137</td></row>
		<row><td>OBJ5</td><td>ISX_DEFAULTCOMPONENT148</td></row>
		<row><td>OBJ6</td><td>ISX_DEFAULTCOMPONENT159</td></row>
		<row><td>OBJ7</td><td>ISX_DEFAULTCOMPONENT172</td></row>
		<row><td>PROPERTIES</td><td>ISX_DEFAULTCOMPONENT60</td></row>
		<row><td>PROPERTIES1</td><td>ISX_DEFAULTCOMPONENT73</td></row>
		<row><td>PROPERTIES2</td><td>ISX_DEFAULTCOMPONENT117</td></row>
		<row><td>PROPERTIES3</td><td>ISX_DEFAULTCOMPONENT131</td></row>
		<row><td>PROPERTIES4</td><td>ISX_DEFAULTCOMPONENT142</td></row>
		<row><td>PROPERTIES5</td><td>ISX_DEFAULTCOMPONENT153</td></row>
		<row><td>PROPERTIES6</td><td>ISX_DEFAULTCOMPONENT164</td></row>
		<row><td>PROPERTIES7</td><td>ISX_DEFAULTCOMPONENT177</td></row>
		<row><td>RELEASE</td><td>ISX_DEFAULTCOMPONENT111</td></row>
		<row><td>RELEASE1</td><td>ISX_DEFAULTCOMPONENT125</td></row>
		<row><td>SAMRAKSH_EMOTE</td><td>ISX_DEFAULTCOMPONENT3</td></row>
		<row><td>SAMRAKSH_EMOTE</td><td>Samraksh_eMote.dll2</td></row>
		<row><td>SAMRAKSH_EMOTE1</td><td>ISX_DEFAULTCOMPONENT33</td></row>
		<row><td>SAMRAKSH_EMOTE1</td><td>Samraksh_eMote.dll5</td></row>
		<row><td>SAMRAKSH_EMOTE2</td><td>ISX_DEFAULTCOMPONENT85</td></row>
		<row><td>SAMRAKSH_EMOTE2</td><td>Samraksh_eMote.dll8</td></row>
		<row><td>SAMRAKSH_EMOTE_ADAPT</td><td>ISX_DEFAULTCOMPONENT6</td></row>
		<row><td>SAMRAKSH_EMOTE_ADAPT</td><td>Samraksh_eMote_Adapt.dll2</td></row>
		<row><td>SAMRAKSH_EMOTE_ADAPT1</td><td>ISX_DEFAULTCOMPONENT36</td></row>
		<row><td>SAMRAKSH_EMOTE_ADAPT1</td><td>Samraksh_eMote_Adapt.dll5</td></row>
		<row><td>SAMRAKSH_EMOTE_ADAPT2</td><td>ISX_DEFAULTCOMPONENT88</td></row>
		<row><td>SAMRAKSH_EMOTE_ADAPT2</td><td>Samraksh_eMote_Adapt.dll8</td></row>
		<row><td>SAMRAKSH_EMOTE_DOTNOW</td><td>ISX_DEFAULTCOMPONENT9</td></row>
		<row><td>SAMRAKSH_EMOTE_DOTNOW</td><td>Samraksh_eMote_DotNow.dll2</td></row>
		<row><td>SAMRAKSH_EMOTE_DOTNOW1</td><td>ISX_DEFAULTCOMPONENT39</td></row>
		<row><td>SAMRAKSH_EMOTE_DOTNOW1</td><td>Samraksh_eMote_DotNow.dll6</td></row>
		<row><td>SAMRAKSH_EMOTE_DOTNOW2</td><td>ISX_DEFAULTCOMPONENT91</td></row>
		<row><td>SAMRAKSH_EMOTE_DOTNOW2</td><td>Samraksh_eMote_DotNow.dll10</td></row>
		<row><td>SAMRAKSH_EMOTE_DSP</td><td>ISX_DEFAULTCOMPONENT12</td></row>
		<row><td>SAMRAKSH_EMOTE_DSP</td><td>Samraksh_eMote_DSP.dll2</td></row>
		<row><td>SAMRAKSH_EMOTE_DSP1</td><td>ISX_DEFAULTCOMPONENT42</td></row>
		<row><td>SAMRAKSH_EMOTE_DSP1</td><td>Samraksh_eMote_DSP.dll5</td></row>
		<row><td>SAMRAKSH_EMOTE_DSP2</td><td>ISX_DEFAULTCOMPONENT94</td></row>
		<row><td>SAMRAKSH_EMOTE_DSP2</td><td>Samraksh_eMote_DSP.dll8</td></row>
		<row><td>SAMRAKSH_EMOTE_KIWI</td><td>ISX_DEFAULTCOMPONENT15</td></row>
		<row><td>SAMRAKSH_EMOTE_KIWI</td><td>Samraksh_eMote_Kiwi.dll2</td></row>
		<row><td>SAMRAKSH_EMOTE_KIWI1</td><td>ISX_DEFAULTCOMPONENT45</td></row>
		<row><td>SAMRAKSH_EMOTE_KIWI1</td><td>Samraksh_eMote_Kiwi.dll5</td></row>
		<row><td>SAMRAKSH_EMOTE_KIWI2</td><td>ISX_DEFAULTCOMPONENT97</td></row>
		<row><td>SAMRAKSH_EMOTE_KIWI2</td><td>Samraksh_eMote_Kiwi.dll8</td></row>
		<row><td>SAMRAKSH_EMOTE_NET</td><td>ISX_DEFAULTCOMPONENT18</td></row>
		<row><td>SAMRAKSH_EMOTE_NET</td><td>Samraksh_eMote_Net.dll2</td></row>
		<row><td>SAMRAKSH_EMOTE_NET1</td><td>ISX_DEFAULTCOMPONENT48</td></row>
		<row><td>SAMRAKSH_EMOTE_NET1</td><td>Samraksh_eMote_Net.dll5</td></row>
		<row><td>SAMRAKSH_EMOTE_NET2</td><td>ISX_DEFAULTCOMPONENT100</td></row>
		<row><td>SAMRAKSH_EMOTE_NET2</td><td>Samraksh_eMote_Net.dll9</td></row>
		<row><td>SAMRAKSH_EMOTE_REALTIME</td><td>ISX_DEFAULTCOMPONENT21</td></row>
		<row><td>SAMRAKSH_EMOTE_REALTIME</td><td>Samraksh_eMote_RealTime.dll2</td></row>
		<row><td>SAMRAKSH_EMOTE_REALTIME1</td><td>ISX_DEFAULTCOMPONENT51</td></row>
		<row><td>SAMRAKSH_EMOTE_REALTIME1</td><td>Samraksh_eMote_RealTime.dll5</td></row>
		<row><td>SAMRAKSH_EMOTE_REALTIME2</td><td>ISX_DEFAULTCOMPONENT103</td></row>
		<row><td>SAMRAKSH_EMOTE_REALTIME2</td><td>Samraksh_eMote_RealTime.dll8</td></row>
		<row><td>SERIALCOMM</td><td>ISX_DEFAULTCOMPONENT132</td></row>
		<row><td>SERIALCOMM1</td><td>ISX_DEFAULTCOMPONENT136</td></row>
		<row><td>SIMPLECSMA</td><td>ISX_DEFAULTCOMPONENT78</td></row>
		<row><td>SIMPLECSMA1</td><td>ISX_DEFAULTCOMPONENT106</td></row>
		<row><td>SIMPLETIMER</td><td>ISX_DEFAULTCOMPONENT143</td></row>
		<row><td>SIMPLETIMER1</td><td>ISX_DEFAULTCOMPONENT147</td></row>
		<row><td>SQRT</td><td>ISX_DEFAULTCOMPONENT154</td></row>
		<row><td>SQRT1</td><td>ISX_DEFAULTCOMPONENT158</td></row>
		<row><td>TEMPPE</td><td>ISX_DEFAULTCOMPONENT59</td></row>
		<row><td>TEMPPE1</td><td>ISX_DEFAULTCOMPONENT72</td></row>
		<row><td>TEMPPE2</td><td>ISX_DEFAULTCOMPONENT116</td></row>
		<row><td>TEMPPE3</td><td>ISX_DEFAULTCOMPONENT130</td></row>
		<row><td>TEMPPE4</td><td>ISX_DEFAULTCOMPONENT141</td></row>
		<row><td>TEMPPE5</td><td>ISX_DEFAULTCOMPONENT152</td></row>
		<row><td>TEMPPE6</td><td>ISX_DEFAULTCOMPONENT163</td></row>
		<row><td>TEMPPE7</td><td>ISX_DEFAULTCOMPONENT176</td></row>
		<row><td>TESTENHANCEDEMOTELCD</td><td>ISX_DEFAULTCOMPONENT61</td></row>
		<row><td>UTILITY_CLASSES</td><td>ISX_DEFAULTCOMPONENT24</td></row>
		<row><td>UTILITY_CLASSES1</td><td>ISX_DEFAULTCOMPONENT74</td></row>
		<row><td>VERSIONINFO</td><td>ISX_DEFAULTCOMPONENT75</td></row>
		<row><td>VERSIONINFO</td><td>Samraksh.AppNote.Utility.VersionInfo.dll4</td></row>
		<row><td>VERSIONINFO1</td><td>ISX_DEFAULTCOMPONENT165</td></row>
		<row><td>VERSIONINFO2</td><td>ISX_DEFAULTCOMPONENT169</td></row>
		<row><td>WINFS</td><td>ISX_DEFAULTCOMPONENT67</td></row>
	</table>

	<table name="CustomAction">
		<col key="yes" def="s72">Action</col>
		<col def="i2">Type</col>
		<col def="S64">Source</col>
		<col def="S0">Target</col>
		<col def="I4">ExtendedType</col>
		<col def="S255">ISComments</col>
		<row><td>ISPreventDowngrade</td><td>19</td><td/><td>[IS_PREVENT_DOWNGRADE_EXIT]</td><td/><td>Exits install when a newer version of this product is found</td></row>
		<row><td>ISPrint</td><td>1</td><td>SetAllUsers.dll</td><td>PrintScrollableText</td><td/><td>Prints the contents of a ScrollableText control on a dialog.</td></row>
		<row><td>ISRunSetupTypeAddLocalEvent</td><td>1</td><td>ISExpHlp.dll</td><td>RunSetupTypeAddLocalEvent</td><td/><td>Run the AddLocal events associated with the Next button on the Setup Type dialog.</td></row>
		<row><td>ISSelfRegisterCosting</td><td>1</td><td>ISSELFREG.DLL</td><td>ISSelfRegisterCosting</td><td/><td/></row>
		<row><td>ISSelfRegisterFiles</td><td>3073</td><td>ISSELFREG.DLL</td><td>ISSelfRegisterFiles</td><td/><td/></row>
		<row><td>ISSelfRegisterFinalize</td><td>1</td><td>ISSELFREG.DLL</td><td>ISSelfRegisterFinalize</td><td/><td/></row>
		<row><td>ISUnSelfRegisterFiles</td><td>3073</td><td>ISSELFREG.DLL</td><td>ISUnSelfRegisterFiles</td><td/><td/></row>
		<row><td>SetARPINSTALLLOCATION</td><td>51</td><td>ARPINSTALLLOCATION</td><td>[INSTALLDIR]</td><td/><td/></row>
		<row><td>SetAllUsersProfileNT</td><td>51</td><td>ALLUSERSPROFILE</td><td>[%SystemRoot]\Profiles\All Users</td><td/><td/></row>
		<row><td>ShowMsiLog</td><td>226</td><td>SystemFolder</td><td>[SystemFolder]notepad.exe "[MsiLogFileLocation]"</td><td/><td>Shows Property-driven MSI Log</td></row>
		<row><td>setAllUsersProfile2K</td><td>51</td><td>ALLUSERSPROFILE</td><td>[%ALLUSERSPROFILE]</td><td/><td/></row>
		<row><td>setUserProfileNT</td><td>51</td><td>USERPROFILE</td><td>[%USERPROFILE]</td><td/><td/></row>
	</table>

	<table name="Dialog">
		<col key="yes" def="s72">Dialog</col>
		<col def="i2">HCentering</col>
		<col def="i2">VCentering</col>
		<col def="i2">Width</col>
		<col def="i2">Height</col>
		<col def="I4">Attributes</col>
		<col def="L128">Title</col>
		<col def="s50">Control_First</col>
		<col def="S50">Control_Default</col>
		<col def="S50">Control_Cancel</col>
		<col def="S255">ISComments</col>
		<col def="S72">TextStyle_</col>
		<col def="I4">ISWindowStyle</col>
		<col def="I4">ISResourceId</col>
		<row><td>AdminChangeFolder</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Tail</td><td>OK</td><td>Cancel</td><td>Install Point Browse</td><td/><td>0</td><td/></row>
		<row><td>AdminNetworkLocation</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>InstallNow</td><td>InstallNow</td><td>Cancel</td><td>Network Location</td><td/><td>0</td><td/></row>
		<row><td>AdminWelcome</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Next</td><td>Next</td><td>Cancel</td><td>Administration Welcome</td><td/><td>0</td><td/></row>
		<row><td>CancelSetup</td><td>50</td><td>50</td><td>260</td><td>85</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>No</td><td>No</td><td>No</td><td>Cancel</td><td/><td>0</td><td/></row>
		<row><td>CustomSetup</td><td>50</td><td>50</td><td>374</td><td>266</td><td>35</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Tree</td><td>Next</td><td>Cancel</td><td>Custom Selection</td><td/><td>0</td><td/></row>
		<row><td>CustomSetupTips</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>OK</td><td>OK</td><td>OK</td><td>Custom Setup Tips</td><td/><td>0</td><td/></row>
		<row><td>CustomerInformation</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>NameEdit</td><td>Next</td><td>Cancel</td><td>Identification</td><td/><td>0</td><td/></row>
		<row><td>DatabaseFolder</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Next</td><td>Next</td><td>Cancel</td><td>Database Folder</td><td/><td>0</td><td/></row>
		<row><td>DestinationFolder</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Next</td><td>Next</td><td>Cancel</td><td>Destination Folder</td><td/><td>0</td><td/></row>
		<row><td>DiskSpaceRequirements</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>OK</td><td>OK</td><td>OK</td><td>Feature Details</td><td/><td>0</td><td/></row>
		<row><td>FilesInUse</td><td>50</td><td>50</td><td>374</td><td>266</td><td>19</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Retry</td><td>Retry</td><td>Exit</td><td>Files in Use</td><td/><td>0</td><td/></row>
		<row><td>InstallChangeFolder</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Tail</td><td>OK</td><td>Cancel</td><td>Browse</td><td/><td>0</td><td/></row>
		<row><td>InstallWelcome</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Next</td><td>Next</td><td>Cancel</td><td>Welcome Panel</td><td/><td>0</td><td/></row>
		<row><td>LicenseAgreement</td><td>50</td><td>50</td><td>374</td><td>266</td><td>2</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Agree</td><td>Next</td><td>Cancel</td><td>License Agreement</td><td/><td>0</td><td/></row>
		<row><td>MaintenanceType</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>RadioGroup</td><td>Next</td><td>Cancel</td><td>Change, Reinstall, Remove</td><td/><td>0</td><td/></row>
		<row><td>MaintenanceWelcome</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Next</td><td>Next</td><td>Cancel</td><td>Maintenance Welcome</td><td/><td>0</td><td/></row>
		<row><td>MsiRMFilesInUse</td><td>50</td><td>50</td><td>374</td><td>266</td><td>19</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>OK</td><td>OK</td><td>Cancel</td><td>RestartManager Files in Use</td><td/><td>0</td><td/></row>
		<row><td>OutOfSpace</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Resume</td><td>Resume</td><td>Resume</td><td>Out Of Disk Space</td><td/><td>0</td><td/></row>
		<row><td>PatchWelcome</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS__IsPatchDlg_PatchWizard##</td><td>Next</td><td>Next</td><td>Cancel</td><td>Patch Panel</td><td/><td>0</td><td/></row>
		<row><td>ReadmeInformation</td><td>50</td><td>50</td><td>374</td><td>266</td><td>7</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Next</td><td>Next</td><td>Cancel</td><td>Readme Information</td><td/><td>0</td><td>0</td></row>
		<row><td>ReadyToInstall</td><td>50</td><td>50</td><td>374</td><td>266</td><td>35</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>InstallNow</td><td>InstallNow</td><td>Cancel</td><td>Ready to Install</td><td/><td>0</td><td/></row>
		<row><td>ReadyToRemove</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>RemoveNow</td><td>RemoveNow</td><td>Cancel</td><td>Verify Remove</td><td/><td>0</td><td/></row>
		<row><td>SetupCompleteError</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Finish</td><td>Finish</td><td>Finish</td><td>Fatal Error</td><td/><td>0</td><td/></row>
		<row><td>SetupCompleteSuccess</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>OK</td><td>OK</td><td>OK</td><td>Exit</td><td/><td>0</td><td/></row>
		<row><td>SetupError</td><td>50</td><td>50</td><td>270</td><td>110</td><td>65543</td><td>##IDS__IsErrorDlg_InstallerInfo##</td><td>ErrorText</td><td>O</td><td>C</td><td>Error</td><td/><td>0</td><td/></row>
		<row><td>SetupInitialization</td><td>50</td><td>50</td><td>374</td><td>266</td><td>5</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Cancel</td><td>Cancel</td><td>Cancel</td><td>Setup Initialization</td><td/><td>0</td><td/></row>
		<row><td>SetupInterrupted</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Finish</td><td>Finish</td><td>Finish</td><td>User Exit</td><td/><td>0</td><td/></row>
		<row><td>SetupProgress</td><td>50</td><td>50</td><td>374</td><td>266</td><td>5</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Cancel</td><td>Cancel</td><td>Cancel</td><td>Progress</td><td/><td>0</td><td/></row>
		<row><td>SetupResume</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Next</td><td>Next</td><td>Cancel</td><td>Resume</td><td/><td>0</td><td/></row>
		<row><td>SetupType</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>RadioGroup</td><td>Next</td><td>Cancel</td><td>Setup Type</td><td/><td>0</td><td/></row>
		<row><td>SplashBitmap</td><td>50</td><td>50</td><td>374</td><td>266</td><td>3</td><td>##IDS_PRODUCTNAME_INSTALLSHIELD##</td><td>Next</td><td>Next</td><td>Cancel</td><td>Welcome Bitmap</td><td/><td>0</td><td/></row>
	</table>

	<table name="Directory">
		<col key="yes" def="s72">Directory</col>
		<col def="S72">Directory_Parent</col>
		<col def="l255">DefaultDir</col>
		<col def="S255">ISDescription</col>
		<col def="I4">ISAttributes</col>
		<col def="S255">ISFolderName</col>
		<row><td>ALLUSERSPROFILE</td><td>TARGETDIR</td><td>.:ALLUSE~1|All Users</td><td/><td>0</td><td/></row>
		<row><td>AdminToolsFolder</td><td>TARGETDIR</td><td>.:Admint~1|AdminTools</td><td/><td>0</td><td/></row>
		<row><td>AppDataFolder</td><td>TARGETDIR</td><td>.:APPLIC~1|Application Data</td><td/><td>0</td><td/></row>
		<row><td>BE</td><td>SAMRAKSH_EMOTE</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE1</td><td>SAMRAKSH_EMOTE_ADAPT</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE10</td><td>SAMRAKSH_EMOTE_DOTNOW1</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE11</td><td>SAMRAKSH_EMOTE_DSP1</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE12</td><td>SAMRAKSH_EMOTE_KIWI1</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE13</td><td>SAMRAKSH_EMOTE_NET1</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE14</td><td>SAMRAKSH_EMOTE_REALTIME1</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE15</td><td>DEBUG</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE16</td><td>DEBUG1</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE17</td><td>DEBUG2</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE18</td><td>VERSIONINFO</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE19</td><td>BIN2</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE2</td><td>SAMRAKSH_EMOTE_DOTNOW</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE20</td><td>SAMRAKSH_EMOTE2</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE21</td><td>SAMRAKSH_EMOTE_ADAPT2</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE22</td><td>SAMRAKSH_EMOTE_DOTNOW2</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE23</td><td>SAMRAKSH_EMOTE_DSP2</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE24</td><td>SAMRAKSH_EMOTE_KIWI2</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE25</td><td>SAMRAKSH_EMOTE_NET2</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE26</td><td>SAMRAKSH_EMOTE_REALTIME2</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE27</td><td>DEBUG3</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE28</td><td>DEBUG4</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE29</td><td>BIN4</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE3</td><td>SAMRAKSH_EMOTE_DSP</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE30</td><td>DEBUG5</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE31</td><td>BIN6</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE32</td><td>DEBUG6</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE33</td><td>BIN7</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE34</td><td>DEBUG7</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE35</td><td>BIN8</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE36</td><td>DEBUG8</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE37</td><td>BIN9</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE38</td><td>DEBUG10</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE4</td><td>SAMRAKSH_EMOTE_KIWI</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE5</td><td>SAMRAKSH_EMOTE_NET</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE6</td><td>SAMRAKSH_EMOTE_REALTIME</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE7</td><td>BIN</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE8</td><td>SAMRAKSH_EMOTE1</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BE9</td><td>SAMRAKSH_EMOTE_ADAPT1</td><td>be</td><td/><td>0</td><td/></row>
		<row><td>BIN</td><td>ENHANCEDEMOTELCD</td><td>bin</td><td/><td>0</td><td/></row>
		<row><td>BIN1</td><td>TESTENHANCEDEMOTELCD</td><td>bin</td><td/><td>0</td><td/></row>
		<row><td>BIN10</td><td>VERSIONINFO2</td><td>bin</td><td/><td>0</td><td/></row>
		<row><td>BIN2</td><td>SIMPLECSMA</td><td>bin</td><td/><td>0</td><td/></row>
		<row><td>BIN3</td><td>SIMPLECSMA1</td><td>bin</td><td/><td>0</td><td/></row>
		<row><td>BIN4</td><td>BITCONVERTER</td><td>bin</td><td/><td>0</td><td/></row>
		<row><td>BIN5</td><td>BITCONVERTER1</td><td>bin</td><td/><td>0</td><td/></row>
		<row><td>BIN6</td><td>SERIALCOMM</td><td>bin</td><td/><td>0</td><td/></row>
		<row><td>BIN7</td><td>SIMPLETIMER</td><td>bin</td><td/><td>0</td><td/></row>
		<row><td>BIN8</td><td>SQRT</td><td>bin</td><td/><td>0</td><td/></row>
		<row><td>BIN9</td><td>VERSIONINFO1</td><td>bin</td><td/><td>0</td><td/></row>
		<row><td>BITCONVERTER</td><td>GENERAL</td><td>BITCON~1|BitConverter</td><td/><td>0</td><td/></row>
		<row><td>BITCONVERTER1</td><td>BITCONVERTER</td><td>BITCON~1|BitConverter</td><td/><td>0</td><td/></row>
		<row><td>CLRANDBOOTER</td><td>EMOTE_.NOW</td><td>CLRAND~1|CLRandBooter</td><td/><td>0</td><td/></row>
		<row><td>CLRANDBOOTER1</td><td>EMOTE_.NOW_RELEASE_4.3.0.14</td><td>CLRAND~1|CLRandBooter</td><td/><td>0</td><td/></row>
		<row><td>CLRANDBOOTER2</td><td>EMOTE_.NOW_RELEASE_4.3.0.141</td><td>CLRAND~1|CLRandBooter</td><td/><td>0</td><td/></row>
		<row><td>CommonAppDataFolder</td><td>TARGETDIR</td><td>.:Common~1|CommonAppData</td><td/><td>0</td><td/></row>
		<row><td>CommonFiles64Folder</td><td>TARGETDIR</td><td>.:Common64</td><td/><td>0</td><td/></row>
		<row><td>CommonFilesFolder</td><td>TARGETDIR</td><td>.:Common</td><td/><td>0</td><td/></row>
		<row><td>DATABASEDIR</td><td>ISYourDataBaseDir</td><td>.</td><td/><td>0</td><td/></row>
		<row><td>DEBUG</td><td>OBJ</td><td>Debug</td><td/><td>0</td><td/></row>
		<row><td>DEBUG1</td><td>BIN1</td><td>Debug</td><td/><td>0</td><td/></row>
		<row><td>DEBUG10</td><td>OBJ7</td><td>Debug</td><td/><td>0</td><td/></row>
		<row><td>DEBUG2</td><td>OBJ1</td><td>Debug</td><td/><td>0</td><td/></row>
		<row><td>DEBUG3</td><td>BIN3</td><td>Debug</td><td/><td>0</td><td/></row>
		<row><td>DEBUG4</td><td>OBJ2</td><td>Debug</td><td/><td>0</td><td/></row>
		<row><td>DEBUG5</td><td>OBJ3</td><td>Debug</td><td/><td>0</td><td/></row>
		<row><td>DEBUG6</td><td>OBJ4</td><td>Debug</td><td/><td>0</td><td/></row>
		<row><td>DEBUG7</td><td>OBJ5</td><td>Debug</td><td/><td>0</td><td/></row>
		<row><td>DEBUG8</td><td>OBJ6</td><td>Debug</td><td/><td>0</td><td/></row>
		<row><td>DEBUG9</td><td>BIN10</td><td>Debug</td><td/><td>0</td><td/></row>
		<row><td>DOTNETMF_FS_EMULATION</td><td>TESTENHANCEDEMOTELCD</td><td>DOTNET~1|DOTNETMF_FS_EMULATION</td><td/><td>0</td><td/></row>
		<row><td>DOTNOW</td><td>UTILITY_CLASSES</td><td>DotNow</td><td/><td>0</td><td/></row>
		<row><td>DesktopFolder</td><td>TARGETDIR</td><td>.:Desktop</td><td/><td>3</td><td/></row>
		<row><td>EMOTE</td><td>SAMRAKSH</td><td>eMote</td><td/><td>0</td><td/></row>
		<row><td>EMOTE_.NOW</td><td>INSTALLDIR</td><td>EMOTE_~1|eMote .NOW</td><td/><td>0</td><td/></row>
		<row><td>EMOTE_.NOW_RELEASE_4.3.0.14</td><td>ENHANCEDEMOTELCD</td><td>EMOTE_~1|eMote .NOW Release 4.3.0.14</td><td/><td>0</td><td/></row>
		<row><td>EMOTE_.NOW_RELEASE_4.3.0.141</td><td>SIMPLECSMA</td><td>EMOTE_~1|eMote .NOW Release 4.3.0.14</td><td/><td>0</td><td/></row>
		<row><td>EMOTE_TINYCLR_V14.HEX</td><td>CLRANDBOOTER</td><td>EMOTE_~1|Emote_TinyCLR_v14.hex</td><td/><td>0</td><td/></row>
		<row><td>EMOTE_TINYCLR_V14.HEX1</td><td>CLRANDBOOTER1</td><td>EMOTE_~1|Emote_TinyCLR_v14.hex</td><td/><td>0</td><td/></row>
		<row><td>EMOTE_TINYCLR_V14.HEX2</td><td>CLRANDBOOTER2</td><td>EMOTE_~1|Emote_TinyCLR_v14.hex</td><td/><td>0</td><td/></row>
		<row><td>ENHANCEDEMOTELCD</td><td>DOTNOW</td><td>ENHANC~1|EnhancedEmoteLCD</td><td/><td>0</td><td/></row>
		<row><td>ENHANCEDEMOTELCD1</td><td>ENHANCEDEMOTELCD</td><td>ENHANC~1|EnhancedEmoteLCD</td><td/><td>0</td><td/></row>
		<row><td>FavoritesFolder</td><td>TARGETDIR</td><td>.:FAVORI~1|Favorites</td><td/><td>0</td><td/></row>
		<row><td>FontsFolder</td><td>TARGETDIR</td><td>.:Fonts</td><td/><td>0</td><td/></row>
		<row><td>GENERAL</td><td>UTILITY_CLASSES</td><td>General</td><td/><td>0</td><td/></row>
		<row><td>GlobalAssemblyCache</td><td>TARGETDIR</td><td>.:Global~1|GlobalAssemblyCache</td><td/><td>0</td><td/></row>
		<row><td>INSTALLDIR</td><td>EMOTE</td><td>.</td><td/><td>0</td><td/></row>
		<row><td>ISCommonFilesFolder</td><td>CommonFilesFolder</td><td>Instal~1|InstallShield</td><td/><td>0</td><td/></row>
		<row><td>ISMyCompanyDir</td><td>ProgramFilesFolder</td><td>MYCOMP~1|My Company Name</td><td/><td>0</td><td/></row>
		<row><td>ISMyProductDir</td><td>ISMyCompanyDir</td><td>MYPROD~1|My Product Name</td><td/><td>0</td><td/></row>
		<row><td>ISYourDataBaseDir</td><td>INSTALLDIR</td><td>Database</td><td/><td>0</td><td/></row>
		<row><td>LE</td><td>SAMRAKSH_EMOTE</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE1</td><td>SAMRAKSH_EMOTE_ADAPT</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE10</td><td>SAMRAKSH_EMOTE_DOTNOW1</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE11</td><td>SAMRAKSH_EMOTE_DSP1</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE12</td><td>SAMRAKSH_EMOTE_KIWI1</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE13</td><td>SAMRAKSH_EMOTE_NET1</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE14</td><td>SAMRAKSH_EMOTE_REALTIME1</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE15</td><td>DEBUG</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE16</td><td>DEBUG1</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE17</td><td>DEBUG2</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE18</td><td>VERSIONINFO</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE19</td><td>BIN2</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE2</td><td>SAMRAKSH_EMOTE_DOTNOW</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE20</td><td>SAMRAKSH_EMOTE2</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE21</td><td>SAMRAKSH_EMOTE_ADAPT2</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE22</td><td>SAMRAKSH_EMOTE_DOTNOW2</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE23</td><td>SAMRAKSH_EMOTE_DSP2</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE24</td><td>SAMRAKSH_EMOTE_KIWI2</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE25</td><td>SAMRAKSH_EMOTE_NET2</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE26</td><td>SAMRAKSH_EMOTE_REALTIME2</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE27</td><td>DEBUG3</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE28</td><td>DEBUG4</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE29</td><td>BIN4</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE3</td><td>SAMRAKSH_EMOTE_DSP</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE30</td><td>DEBUG5</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE31</td><td>BIN6</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE32</td><td>DEBUG6</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE33</td><td>BIN7</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE34</td><td>DEBUG7</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE35</td><td>BIN8</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE36</td><td>DEBUG8</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE37</td><td>BIN9</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE38</td><td>DEBUG10</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE4</td><td>SAMRAKSH_EMOTE_KIWI</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE5</td><td>SAMRAKSH_EMOTE_NET</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE6</td><td>SAMRAKSH_EMOTE_REALTIME</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE7</td><td>BIN</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE8</td><td>SAMRAKSH_EMOTE1</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LE9</td><td>SAMRAKSH_EMOTE_ADAPT1</td><td>le</td><td/><td>0</td><td/></row>
		<row><td>LocalAppDataFolder</td><td>TARGETDIR</td><td>.:LocalA~1|LocalAppData</td><td/><td>0</td><td/></row>
		<row><td>MY_PRODUCT_NAME</td><td>SAMRAKSH</td><td>MYPROD~1|My Product Name</td><td/><td>0</td><td/></row>
		<row><td>MyPicturesFolder</td><td>TARGETDIR</td><td>.:MyPict~1|MyPictures</td><td/><td>0</td><td/></row>
		<row><td>NetHoodFolder</td><td>TARGETDIR</td><td>.:NetHood</td><td/><td>0</td><td/></row>
		<row><td>OBJ</td><td>ENHANCEDEMOTELCD1</td><td>obj</td><td/><td>0</td><td/></row>
		<row><td>OBJ1</td><td>TESTENHANCEDEMOTELCD</td><td>obj</td><td/><td>0</td><td/></row>
		<row><td>OBJ2</td><td>SIMPLECSMA1</td><td>obj</td><td/><td>0</td><td/></row>
		<row><td>OBJ3</td><td>BITCONVERTER1</td><td>obj</td><td/><td>0</td><td/></row>
		<row><td>OBJ4</td><td>SERIALCOMM1</td><td>obj</td><td/><td>0</td><td/></row>
		<row><td>OBJ5</td><td>SIMPLETIMER1</td><td>obj</td><td/><td>0</td><td/></row>
		<row><td>OBJ6</td><td>SQRT1</td><td>obj</td><td/><td>0</td><td/></row>
		<row><td>OBJ7</td><td>VERSIONINFO2</td><td>obj</td><td/><td>0</td><td/></row>
		<row><td>PROPERTIES</td><td>ENHANCEDEMOTELCD1</td><td>PROPER~1|Properties</td><td/><td>0</td><td/></row>
		<row><td>PROPERTIES1</td><td>TESTENHANCEDEMOTELCD</td><td>PROPER~1|Properties</td><td/><td>0</td><td/></row>
		<row><td>PROPERTIES2</td><td>SIMPLECSMA1</td><td>PROPER~1|Properties</td><td/><td>0</td><td/></row>
		<row><td>PROPERTIES3</td><td>BITCONVERTER1</td><td>PROPER~1|Properties</td><td/><td>0</td><td/></row>
		<row><td>PROPERTIES4</td><td>SERIALCOMM1</td><td>PROPER~1|Properties</td><td/><td>0</td><td/></row>
		<row><td>PROPERTIES5</td><td>SIMPLETIMER1</td><td>PROPER~1|Properties</td><td/><td>0</td><td/></row>
		<row><td>PROPERTIES6</td><td>SQRT1</td><td>PROPER~1|Properties</td><td/><td>0</td><td/></row>
		<row><td>PROPERTIES7</td><td>VERSIONINFO2</td><td>PROPER~1|Properties</td><td/><td>0</td><td/></row>
		<row><td>PersonalFolder</td><td>TARGETDIR</td><td>.:Personal</td><td/><td>0</td><td/></row>
		<row><td>PrimaryVolumePath</td><td>TARGETDIR</td><td>.:Primar~1|PrimaryVolumePath</td><td/><td>0</td><td/></row>
		<row><td>PrintHoodFolder</td><td>TARGETDIR</td><td>.:PRINTH~1|PrintHood</td><td/><td>0</td><td/></row>
		<row><td>ProgramFiles64Folder</td><td>TARGETDIR</td><td>.:Prog64~1|Program Files 64</td><td/><td>0</td><td/></row>
		<row><td>ProgramFilesFolder</td><td>TARGETDIR</td><td>.:PROGRA~1|program files</td><td/><td>0</td><td/></row>
		<row><td>ProgramMenuFolder</td><td>TARGETDIR</td><td>.:Programs</td><td/><td>3</td><td/></row>
		<row><td>RELEASE</td><td>BIN3</td><td>Release</td><td/><td>0</td><td/></row>
		<row><td>RELEASE1</td><td>BIN5</td><td>Release</td><td/><td>0</td><td/></row>
		<row><td>RecentFolder</td><td>TARGETDIR</td><td>.:Recent</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH</td><td>CommonFilesFolder</td><td>Samraksh</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE</td><td>EMOTE_.NOW</td><td>SAMRAK~1|Samraksh_eMote</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE1</td><td>EMOTE_.NOW_RELEASE_4.3.0.14</td><td>SAMRAK~1|Samraksh_eMote</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE2</td><td>EMOTE_.NOW_RELEASE_4.3.0.141</td><td>SAMRAK~1|Samraksh_eMote</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_ADAPT</td><td>EMOTE_.NOW</td><td>SAMRAK~1|Samraksh_eMote_Adapt</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_ADAPT1</td><td>EMOTE_.NOW_RELEASE_4.3.0.14</td><td>SAMRAK~1|Samraksh_eMote_Adapt</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_ADAPT2</td><td>EMOTE_.NOW_RELEASE_4.3.0.141</td><td>SAMRAK~1|Samraksh_eMote_Adapt</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_DOTNOW</td><td>EMOTE_.NOW</td><td>SAMRAK~1|Samraksh_eMote_DotNow</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_DOTNOW1</td><td>EMOTE_.NOW_RELEASE_4.3.0.14</td><td>SAMRAK~1|Samraksh_eMote_DotNow</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_DOTNOW2</td><td>EMOTE_.NOW_RELEASE_4.3.0.141</td><td>SAMRAK~1|Samraksh_eMote_DotNow</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_DSP</td><td>EMOTE_.NOW</td><td>SAMRAK~1|Samraksh_eMote_DSP</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_DSP1</td><td>EMOTE_.NOW_RELEASE_4.3.0.14</td><td>SAMRAK~1|Samraksh_eMote_DSP</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_DSP2</td><td>EMOTE_.NOW_RELEASE_4.3.0.141</td><td>SAMRAK~1|Samraksh_eMote_DSP</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_KIWI</td><td>EMOTE_.NOW</td><td>SAMRAK~1|Samraksh_eMote_Kiwi</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_KIWI1</td><td>EMOTE_.NOW_RELEASE_4.3.0.14</td><td>SAMRAK~1|Samraksh_eMote_Kiwi</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_KIWI2</td><td>EMOTE_.NOW_RELEASE_4.3.0.141</td><td>SAMRAK~1|Samraksh_eMote_Kiwi</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_NET</td><td>EMOTE_.NOW</td><td>SAMRAK~1|Samraksh_eMote_Net</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_NET1</td><td>EMOTE_.NOW_RELEASE_4.3.0.14</td><td>SAMRAK~1|Samraksh_eMote_Net</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_NET2</td><td>EMOTE_.NOW_RELEASE_4.3.0.141</td><td>SAMRAK~1|Samraksh_eMote_Net</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_REALTIME</td><td>EMOTE_.NOW</td><td>SAMRAK~1|Samraksh_eMote_RealTime</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_REALTIME1</td><td>EMOTE_.NOW_RELEASE_4.3.0.14</td><td>SAMRAK~1|Samraksh_eMote_RealTime</td><td/><td>0</td><td/></row>
		<row><td>SAMRAKSH_EMOTE_REALTIME2</td><td>EMOTE_.NOW_RELEASE_4.3.0.141</td><td>SAMRAK~1|Samraksh_eMote_RealTime</td><td/><td>0</td><td/></row>
		<row><td>SERIALCOMM</td><td>GENERAL</td><td>SERIAL~1|SerialComm</td><td/><td>0</td><td/></row>
		<row><td>SERIALCOMM1</td><td>SERIALCOMM</td><td>SERIAL~1|SerialComm</td><td/><td>0</td><td/></row>
		<row><td>SIMPLECSMA</td><td>DOTNOW</td><td>SIMPLE~1|SimpleCSMA</td><td/><td>0</td><td/></row>
		<row><td>SIMPLECSMA1</td><td>SIMPLECSMA</td><td>SIMPLE~1|SimpleCSMA</td><td/><td>0</td><td/></row>
		<row><td>SIMPLETIMER</td><td>GENERAL</td><td>SIMPLE~1|SimpleTimer</td><td/><td>0</td><td/></row>
		<row><td>SIMPLETIMER1</td><td>SIMPLETIMER</td><td>SIMPLE~1|SimpleTimer</td><td/><td>0</td><td/></row>
		<row><td>SQRT</td><td>GENERAL</td><td>Sqrt</td><td/><td>0</td><td/></row>
		<row><td>SQRT1</td><td>SQRT</td><td>Sqrt</td><td/><td>0</td><td/></row>
		<row><td>SendToFolder</td><td>TARGETDIR</td><td>.:SendTo</td><td/><td>3</td><td/></row>
		<row><td>StartMenuFolder</td><td>TARGETDIR</td><td>.:STARTM~1|Start Menu</td><td/><td>3</td><td/></row>
		<row><td>StartupFolder</td><td>TARGETDIR</td><td>.:StartUp</td><td/><td>3</td><td/></row>
		<row><td>System16Folder</td><td>TARGETDIR</td><td>.:System</td><td/><td>0</td><td/></row>
		<row><td>System64Folder</td><td>TARGETDIR</td><td>.:System64</td><td/><td>0</td><td/></row>
		<row><td>SystemFolder</td><td>TARGETDIR</td><td>.:System32</td><td/><td>0</td><td/></row>
		<row><td>TARGETDIR</td><td/><td>SourceDir</td><td/><td>0</td><td/></row>
		<row><td>TEMPPE</td><td>DEBUG</td><td>TempPE</td><td/><td>0</td><td/></row>
		<row><td>TEMPPE1</td><td>DEBUG2</td><td>TempPE</td><td/><td>0</td><td/></row>
		<row><td>TEMPPE2</td><td>DEBUG4</td><td>TempPE</td><td/><td>0</td><td/></row>
		<row><td>TEMPPE3</td><td>DEBUG5</td><td>TempPE</td><td/><td>0</td><td/></row>
		<row><td>TEMPPE4</td><td>DEBUG6</td><td>TempPE</td><td/><td>0</td><td/></row>
		<row><td>TEMPPE5</td><td>DEBUG7</td><td>TempPE</td><td/><td>0</td><td/></row>
		<row><td>TEMPPE6</td><td>DEBUG8</td><td>TempPE</td><td/><td>0</td><td/></row>
		<row><td>TEMPPE7</td><td>DEBUG10</td><td>TempPE</td><td/><td>0</td><td/></row>
		<row><td>TESTENHANCEDEMOTELCD</td><td>ENHANCEDEMOTELCD</td><td>TESTEN~1|TestEnhancedEmoteLCD</td><td/><td>0</td><td/></row>
		<row><td>TempFolder</td><td>TARGETDIR</td><td>.:Temp</td><td/><td>0</td><td/></row>
		<row><td>TemplateFolder</td><td>TARGETDIR</td><td>.:ShellNew</td><td/><td>0</td><td/></row>
		<row><td>USERPROFILE</td><td>TARGETDIR</td><td>.:USERPR~1|UserProfile</td><td/><td>0</td><td/></row>
		<row><td>UTILITY</td><td>SAMRAKSH</td><td>Utility</td><td/><td>0</td><td/></row>
		<row><td>UTILITY_CLASSES</td><td>INSTALLDIR</td><td>UTILIT~1|Utility Classes</td><td/><td>0</td><td/></row>
		<row><td>UTILITY_CLASSES1</td><td>ENHANCEDEMOTELCD</td><td>UTILIT~1|Utility Classes</td><td/><td>0</td><td/></row>
		<row><td>VERSIONINFO</td><td>UTILITY_CLASSES1</td><td>VERSIO~1|VersionInfo</td><td/><td>0</td><td/></row>
		<row><td>VERSIONINFO1</td><td>GENERAL</td><td>VERSIO~1|VersionInfo</td><td/><td>0</td><td/></row>
		<row><td>VERSIONINFO2</td><td>VERSIONINFO1</td><td>VERSIO~1|VersionInfo</td><td/><td>0</td><td/></row>
		<row><td>WINFS</td><td>DOTNETMF_FS_EMULATION</td><td>WINFS</td><td/><td>0</td><td/></row>
		<row><td>WindowsFolder</td><td>TARGETDIR</td><td>.:Windows</td><td/><td>0</td><td/></row>
		<row><td>WindowsVolume</td><td>TARGETDIR</td><td>.:WinRoot</td><td/><td>0</td><td/></row>
		<row><td>emote</td><td>samraksh</td><td>eMote</td><td/><td>1</td><td/></row>
		<row><td>samraksh</td><td>ProgramMenuFolder</td><td>Samraksh</td><td/><td>1</td><td/></row>
	</table>

	<table name="DrLocator">
		<col key="yes" def="s72">Signature_</col>
		<col key="yes" def="S72">Parent</col>
		<col key="yes" def="S255">Path</col>
		<col def="I2">Depth</col>
	</table>

	<table name="DuplicateFile">
		<col key="yes" def="s72">FileKey</col>
		<col def="s72">Component_</col>
		<col def="s72">File_</col>
		<col def="L255">DestName</col>
		<col def="S72">DestFolder</col>
	</table>

	<table name="Environment">
		<col key="yes" def="s72">Environment</col>
		<col def="l255">Name</col>
		<col def="L255">Value</col>
		<col def="s72">Component_</col>
	</table>

	<table name="Error">
		<col key="yes" def="i2">Error</col>
		<col def="L255">Message</col>
		<row><td>0</td><td>##IDS_ERROR_0##</td></row>
		<row><td>1</td><td>##IDS_ERROR_1##</td></row>
		<row><td>10</td><td>##IDS_ERROR_8##</td></row>
		<row><td>11</td><td>##IDS_ERROR_9##</td></row>
		<row><td>1101</td><td>##IDS_ERROR_22##</td></row>
		<row><td>12</td><td>##IDS_ERROR_10##</td></row>
		<row><td>13</td><td>##IDS_ERROR_11##</td></row>
		<row><td>1301</td><td>##IDS_ERROR_23##</td></row>
		<row><td>1302</td><td>##IDS_ERROR_24##</td></row>
		<row><td>1303</td><td>##IDS_ERROR_25##</td></row>
		<row><td>1304</td><td>##IDS_ERROR_26##</td></row>
		<row><td>1305</td><td>##IDS_ERROR_27##</td></row>
		<row><td>1306</td><td>##IDS_ERROR_28##</td></row>
		<row><td>1307</td><td>##IDS_ERROR_29##</td></row>
		<row><td>1308</td><td>##IDS_ERROR_30##</td></row>
		<row><td>1309</td><td>##IDS_ERROR_31##</td></row>
		<row><td>1310</td><td>##IDS_ERROR_32##</td></row>
		<row><td>1311</td><td>##IDS_ERROR_33##</td></row>
		<row><td>1312</td><td>##IDS_ERROR_34##</td></row>
		<row><td>1313</td><td>##IDS_ERROR_35##</td></row>
		<row><td>1314</td><td>##IDS_ERROR_36##</td></row>
		<row><td>1315</td><td>##IDS_ERROR_37##</td></row>
		<row><td>1316</td><td>##IDS_ERROR_38##</td></row>
		<row><td>1317</td><td>##IDS_ERROR_39##</td></row>
		<row><td>1318</td><td>##IDS_ERROR_40##</td></row>
		<row><td>1319</td><td>##IDS_ERROR_41##</td></row>
		<row><td>1320</td><td>##IDS_ERROR_42##</td></row>
		<row><td>1321</td><td>##IDS_ERROR_43##</td></row>
		<row><td>1322</td><td>##IDS_ERROR_44##</td></row>
		<row><td>1323</td><td>##IDS_ERROR_45##</td></row>
		<row><td>1324</td><td>##IDS_ERROR_46##</td></row>
		<row><td>1325</td><td>##IDS_ERROR_47##</td></row>
		<row><td>1326</td><td>##IDS_ERROR_48##</td></row>
		<row><td>1327</td><td>##IDS_ERROR_49##</td></row>
		<row><td>1328</td><td>##IDS_ERROR_122##</td></row>
		<row><td>1329</td><td>##IDS_ERROR_1329##</td></row>
		<row><td>1330</td><td>##IDS_ERROR_1330##</td></row>
		<row><td>1331</td><td>##IDS_ERROR_1331##</td></row>
		<row><td>1332</td><td>##IDS_ERROR_1332##</td></row>
		<row><td>1333</td><td>##IDS_ERROR_1333##</td></row>
		<row><td>1334</td><td>##IDS_ERROR_1334##</td></row>
		<row><td>1335</td><td>##IDS_ERROR_1335##</td></row>
		<row><td>1336</td><td>##IDS_ERROR_1336##</td></row>
		<row><td>14</td><td>##IDS_ERROR_12##</td></row>
		<row><td>1401</td><td>##IDS_ERROR_50##</td></row>
		<row><td>1402</td><td>##IDS_ERROR_51##</td></row>
		<row><td>1403</td><td>##IDS_ERROR_52##</td></row>
		<row><td>1404</td><td>##IDS_ERROR_53##</td></row>
		<row><td>1405</td><td>##IDS_ERROR_54##</td></row>
		<row><td>1406</td><td>##IDS_ERROR_55##</td></row>
		<row><td>1407</td><td>##IDS_ERROR_56##</td></row>
		<row><td>1408</td><td>##IDS_ERROR_57##</td></row>
		<row><td>1409</td><td>##IDS_ERROR_58##</td></row>
		<row><td>1410</td><td>##IDS_ERROR_59##</td></row>
		<row><td>15</td><td>##IDS_ERROR_13##</td></row>
		<row><td>1500</td><td>##IDS_ERROR_60##</td></row>
		<row><td>1501</td><td>##IDS_ERROR_61##</td></row>
		<row><td>1502</td><td>##IDS_ERROR_62##</td></row>
		<row><td>1503</td><td>##IDS_ERROR_63##</td></row>
		<row><td>16</td><td>##IDS_ERROR_14##</td></row>
		<row><td>1601</td><td>##IDS_ERROR_64##</td></row>
		<row><td>1602</td><td>##IDS_ERROR_65##</td></row>
		<row><td>1603</td><td>##IDS_ERROR_66##</td></row>
		<row><td>1604</td><td>##IDS_ERROR_67##</td></row>
		<row><td>1605</td><td>##IDS_ERROR_68##</td></row>
		<row><td>1606</td><td>##IDS_ERROR_69##</td></row>
		<row><td>1607</td><td>##IDS_ERROR_70##</td></row>
		<row><td>1608</td><td>##IDS_ERROR_71##</td></row>
		<row><td>1609</td><td>##IDS_ERROR_1609##</td></row>
		<row><td>1651</td><td>##IDS_ERROR_1651##</td></row>
		<row><td>17</td><td>##IDS_ERROR_15##</td></row>
		<row><td>1701</td><td>##IDS_ERROR_72##</td></row>
		<row><td>1702</td><td>##IDS_ERROR_73##</td></row>
		<row><td>1703</td><td>##IDS_ERROR_74##</td></row>
		<row><td>1704</td><td>##IDS_ERROR_75##</td></row>
		<row><td>1705</td><td>##IDS_ERROR_76##</td></row>
		<row><td>1706</td><td>##IDS_ERROR_77##</td></row>
		<row><td>1707</td><td>##IDS_ERROR_78##</td></row>
		<row><td>1708</td><td>##IDS_ERROR_79##</td></row>
		<row><td>1709</td><td>##IDS_ERROR_80##</td></row>
		<row><td>1710</td><td>##IDS_ERROR_81##</td></row>
		<row><td>1711</td><td>##IDS_ERROR_82##</td></row>
		<row><td>1712</td><td>##IDS_ERROR_83##</td></row>
		<row><td>1713</td><td>##IDS_ERROR_123##</td></row>
		<row><td>1714</td><td>##IDS_ERROR_124##</td></row>
		<row><td>1715</td><td>##IDS_ERROR_1715##</td></row>
		<row><td>1716</td><td>##IDS_ERROR_1716##</td></row>
		<row><td>1717</td><td>##IDS_ERROR_1717##</td></row>
		<row><td>1718</td><td>##IDS_ERROR_1718##</td></row>
		<row><td>1719</td><td>##IDS_ERROR_1719##</td></row>
		<row><td>1720</td><td>##IDS_ERROR_1720##</td></row>
		<row><td>1721</td><td>##IDS_ERROR_1721##</td></row>
		<row><td>1722</td><td>##IDS_ERROR_1722##</td></row>
		<row><td>1723</td><td>##IDS_ERROR_1723##</td></row>
		<row><td>1724</td><td>##IDS_ERROR_1724##</td></row>
		<row><td>1725</td><td>##IDS_ERROR_1725##</td></row>
		<row><td>1726</td><td>##IDS_ERROR_1726##</td></row>
		<row><td>1727</td><td>##IDS_ERROR_1727##</td></row>
		<row><td>1728</td><td>##IDS_ERROR_1728##</td></row>
		<row><td>1729</td><td>##IDS_ERROR_1729##</td></row>
		<row><td>1730</td><td>##IDS_ERROR_1730##</td></row>
		<row><td>1731</td><td>##IDS_ERROR_1731##</td></row>
		<row><td>1732</td><td>##IDS_ERROR_1732##</td></row>
		<row><td>18</td><td>##IDS_ERROR_16##</td></row>
		<row><td>1801</td><td>##IDS_ERROR_84##</td></row>
		<row><td>1802</td><td>##IDS_ERROR_85##</td></row>
		<row><td>1803</td><td>##IDS_ERROR_86##</td></row>
		<row><td>1804</td><td>##IDS_ERROR_87##</td></row>
		<row><td>1805</td><td>##IDS_ERROR_88##</td></row>
		<row><td>1806</td><td>##IDS_ERROR_89##</td></row>
		<row><td>1807</td><td>##IDS_ERROR_90##</td></row>
		<row><td>19</td><td>##IDS_ERROR_17##</td></row>
		<row><td>1901</td><td>##IDS_ERROR_91##</td></row>
		<row><td>1902</td><td>##IDS_ERROR_92##</td></row>
		<row><td>1903</td><td>##IDS_ERROR_93##</td></row>
		<row><td>1904</td><td>##IDS_ERROR_94##</td></row>
		<row><td>1905</td><td>##IDS_ERROR_95##</td></row>
		<row><td>1906</td><td>##IDS_ERROR_96##</td></row>
		<row><td>1907</td><td>##IDS_ERROR_97##</td></row>
		<row><td>1908</td><td>##IDS_ERROR_98##</td></row>
		<row><td>1909</td><td>##IDS_ERROR_99##</td></row>
		<row><td>1910</td><td>##IDS_ERROR_100##</td></row>
		<row><td>1911</td><td>##IDS_ERROR_101##</td></row>
		<row><td>1912</td><td>##IDS_ERROR_102##</td></row>
		<row><td>1913</td><td>##IDS_ERROR_103##</td></row>
		<row><td>1914</td><td>##IDS_ERROR_104##</td></row>
		<row><td>1915</td><td>##IDS_ERROR_105##</td></row>
		<row><td>1916</td><td>##IDS_ERROR_106##</td></row>
		<row><td>1917</td><td>##IDS_ERROR_107##</td></row>
		<row><td>1918</td><td>##IDS_ERROR_108##</td></row>
		<row><td>1919</td><td>##IDS_ERROR_109##</td></row>
		<row><td>1920</td><td>##IDS_ERROR_110##</td></row>
		<row><td>1921</td><td>##IDS_ERROR_111##</td></row>
		<row><td>1922</td><td>##IDS_ERROR_112##</td></row>
		<row><td>1923</td><td>##IDS_ERROR_113##</td></row>
		<row><td>1924</td><td>##IDS_ERROR_114##</td></row>
		<row><td>1925</td><td>##IDS_ERROR_115##</td></row>
		<row><td>1926</td><td>##IDS_ERROR_116##</td></row>
		<row><td>1927</td><td>##IDS_ERROR_117##</td></row>
		<row><td>1928</td><td>##IDS_ERROR_118##</td></row>
		<row><td>1929</td><td>##IDS_ERROR_119##</td></row>
		<row><td>1930</td><td>##IDS_ERROR_125##</td></row>
		<row><td>1931</td><td>##IDS_ERROR_126##</td></row>
		<row><td>1932</td><td>##IDS_ERROR_127##</td></row>
		<row><td>1933</td><td>##IDS_ERROR_128##</td></row>
		<row><td>1934</td><td>##IDS_ERROR_129##</td></row>
		<row><td>1935</td><td>##IDS_ERROR_1935##</td></row>
		<row><td>1936</td><td>##IDS_ERROR_1936##</td></row>
		<row><td>1937</td><td>##IDS_ERROR_1937##</td></row>
		<row><td>1938</td><td>##IDS_ERROR_1938##</td></row>
		<row><td>2</td><td>##IDS_ERROR_2##</td></row>
		<row><td>20</td><td>##IDS_ERROR_18##</td></row>
		<row><td>21</td><td>##IDS_ERROR_19##</td></row>
		<row><td>2101</td><td>##IDS_ERROR_2101##</td></row>
		<row><td>2102</td><td>##IDS_ERROR_2102##</td></row>
		<row><td>2103</td><td>##IDS_ERROR_2103##</td></row>
		<row><td>2104</td><td>##IDS_ERROR_2104##</td></row>
		<row><td>2105</td><td>##IDS_ERROR_2105##</td></row>
		<row><td>2106</td><td>##IDS_ERROR_2106##</td></row>
		<row><td>2107</td><td>##IDS_ERROR_2107##</td></row>
		<row><td>2108</td><td>##IDS_ERROR_2108##</td></row>
		<row><td>2109</td><td>##IDS_ERROR_2109##</td></row>
		<row><td>2110</td><td>##IDS_ERROR_2110##</td></row>
		<row><td>2111</td><td>##IDS_ERROR_2111##</td></row>
		<row><td>2112</td><td>##IDS_ERROR_2112##</td></row>
		<row><td>2113</td><td>##IDS_ERROR_2113##</td></row>
		<row><td>22</td><td>##IDS_ERROR_120##</td></row>
		<row><td>2200</td><td>##IDS_ERROR_2200##</td></row>
		<row><td>2201</td><td>##IDS_ERROR_2201##</td></row>
		<row><td>2202</td><td>##IDS_ERROR_2202##</td></row>
		<row><td>2203</td><td>##IDS_ERROR_2203##</td></row>
		<row><td>2204</td><td>##IDS_ERROR_2204##</td></row>
		<row><td>2205</td><td>##IDS_ERROR_2205##</td></row>
		<row><td>2206</td><td>##IDS_ERROR_2206##</td></row>
		<row><td>2207</td><td>##IDS_ERROR_2207##</td></row>
		<row><td>2208</td><td>##IDS_ERROR_2208##</td></row>
		<row><td>2209</td><td>##IDS_ERROR_2209##</td></row>
		<row><td>2210</td><td>##IDS_ERROR_2210##</td></row>
		<row><td>2211</td><td>##IDS_ERROR_2211##</td></row>
		<row><td>2212</td><td>##IDS_ERROR_2212##</td></row>
		<row><td>2213</td><td>##IDS_ERROR_2213##</td></row>
		<row><td>2214</td><td>##IDS_ERROR_2214##</td></row>
		<row><td>2215</td><td>##IDS_ERROR_2215##</td></row>
		<row><td>2216</td><td>##IDS_ERROR_2216##</td></row>
		<row><td>2217</td><td>##IDS_ERROR_2217##</td></row>
		<row><td>2218</td><td>##IDS_ERROR_2218##</td></row>
		<row><td>2219</td><td>##IDS_ERROR_2219##</td></row>
		<row><td>2220</td><td>##IDS_ERROR_2220##</td></row>
		<row><td>2221</td><td>##IDS_ERROR_2221##</td></row>
		<row><td>2222</td><td>##IDS_ERROR_2222##</td></row>
		<row><td>2223</td><td>##IDS_ERROR_2223##</td></row>
		<row><td>2224</td><td>##IDS_ERROR_2224##</td></row>
		<row><td>2225</td><td>##IDS_ERROR_2225##</td></row>
		<row><td>2226</td><td>##IDS_ERROR_2226##</td></row>
		<row><td>2227</td><td>##IDS_ERROR_2227##</td></row>
		<row><td>2228</td><td>##IDS_ERROR_2228##</td></row>
		<row><td>2229</td><td>##IDS_ERROR_2229##</td></row>
		<row><td>2230</td><td>##IDS_ERROR_2230##</td></row>
		<row><td>2231</td><td>##IDS_ERROR_2231##</td></row>
		<row><td>2232</td><td>##IDS_ERROR_2232##</td></row>
		<row><td>2233</td><td>##IDS_ERROR_2233##</td></row>
		<row><td>2234</td><td>##IDS_ERROR_2234##</td></row>
		<row><td>2235</td><td>##IDS_ERROR_2235##</td></row>
		<row><td>2236</td><td>##IDS_ERROR_2236##</td></row>
		<row><td>2237</td><td>##IDS_ERROR_2237##</td></row>
		<row><td>2238</td><td>##IDS_ERROR_2238##</td></row>
		<row><td>2239</td><td>##IDS_ERROR_2239##</td></row>
		<row><td>2240</td><td>##IDS_ERROR_2240##</td></row>
		<row><td>2241</td><td>##IDS_ERROR_2241##</td></row>
		<row><td>2242</td><td>##IDS_ERROR_2242##</td></row>
		<row><td>2243</td><td>##IDS_ERROR_2243##</td></row>
		<row><td>2244</td><td>##IDS_ERROR_2244##</td></row>
		<row><td>2245</td><td>##IDS_ERROR_2245##</td></row>
		<row><td>2246</td><td>##IDS_ERROR_2246##</td></row>
		<row><td>2247</td><td>##IDS_ERROR_2247##</td></row>
		<row><td>2248</td><td>##IDS_ERROR_2248##</td></row>
		<row><td>2249</td><td>##IDS_ERROR_2249##</td></row>
		<row><td>2250</td><td>##IDS_ERROR_2250##</td></row>
		<row><td>2251</td><td>##IDS_ERROR_2251##</td></row>
		<row><td>2252</td><td>##IDS_ERROR_2252##</td></row>
		<row><td>2253</td><td>##IDS_ERROR_2253##</td></row>
		<row><td>2254</td><td>##IDS_ERROR_2254##</td></row>
		<row><td>2255</td><td>##IDS_ERROR_2255##</td></row>
		<row><td>2256</td><td>##IDS_ERROR_2256##</td></row>
		<row><td>2257</td><td>##IDS_ERROR_2257##</td></row>
		<row><td>2258</td><td>##IDS_ERROR_2258##</td></row>
		<row><td>2259</td><td>##IDS_ERROR_2259##</td></row>
		<row><td>2260</td><td>##IDS_ERROR_2260##</td></row>
		<row><td>2261</td><td>##IDS_ERROR_2261##</td></row>
		<row><td>2262</td><td>##IDS_ERROR_2262##</td></row>
		<row><td>2263</td><td>##IDS_ERROR_2263##</td></row>
		<row><td>2264</td><td>##IDS_ERROR_2264##</td></row>
		<row><td>2265</td><td>##IDS_ERROR_2265##</td></row>
		<row><td>2266</td><td>##IDS_ERROR_2266##</td></row>
		<row><td>2267</td><td>##IDS_ERROR_2267##</td></row>
		<row><td>2268</td><td>##IDS_ERROR_2268##</td></row>
		<row><td>2269</td><td>##IDS_ERROR_2269##</td></row>
		<row><td>2270</td><td>##IDS_ERROR_2270##</td></row>
		<row><td>2271</td><td>##IDS_ERROR_2271##</td></row>
		<row><td>2272</td><td>##IDS_ERROR_2272##</td></row>
		<row><td>2273</td><td>##IDS_ERROR_2273##</td></row>
		<row><td>2274</td><td>##IDS_ERROR_2274##</td></row>
		<row><td>2275</td><td>##IDS_ERROR_2275##</td></row>
		<row><td>2276</td><td>##IDS_ERROR_2276##</td></row>
		<row><td>2277</td><td>##IDS_ERROR_2277##</td></row>
		<row><td>2278</td><td>##IDS_ERROR_2278##</td></row>
		<row><td>2279</td><td>##IDS_ERROR_2279##</td></row>
		<row><td>2280</td><td>##IDS_ERROR_2280##</td></row>
		<row><td>2281</td><td>##IDS_ERROR_2281##</td></row>
		<row><td>2282</td><td>##IDS_ERROR_2282##</td></row>
		<row><td>23</td><td>##IDS_ERROR_121##</td></row>
		<row><td>2302</td><td>##IDS_ERROR_2302##</td></row>
		<row><td>2303</td><td>##IDS_ERROR_2303##</td></row>
		<row><td>2304</td><td>##IDS_ERROR_2304##</td></row>
		<row><td>2305</td><td>##IDS_ERROR_2305##</td></row>
		<row><td>2306</td><td>##IDS_ERROR_2306##</td></row>
		<row><td>2307</td><td>##IDS_ERROR_2307##</td></row>
		<row><td>2308</td><td>##IDS_ERROR_2308##</td></row>
		<row><td>2309</td><td>##IDS_ERROR_2309##</td></row>
		<row><td>2310</td><td>##IDS_ERROR_2310##</td></row>
		<row><td>2315</td><td>##IDS_ERROR_2315##</td></row>
		<row><td>2318</td><td>##IDS_ERROR_2318##</td></row>
		<row><td>2319</td><td>##IDS_ERROR_2319##</td></row>
		<row><td>2320</td><td>##IDS_ERROR_2320##</td></row>
		<row><td>2321</td><td>##IDS_ERROR_2321##</td></row>
		<row><td>2322</td><td>##IDS_ERROR_2322##</td></row>
		<row><td>2323</td><td>##IDS_ERROR_2323##</td></row>
		<row><td>2324</td><td>##IDS_ERROR_2324##</td></row>
		<row><td>2325</td><td>##IDS_ERROR_2325##</td></row>
		<row><td>2326</td><td>##IDS_ERROR_2326##</td></row>
		<row><td>2327</td><td>##IDS_ERROR_2327##</td></row>
		<row><td>2328</td><td>##IDS_ERROR_2328##</td></row>
		<row><td>2329</td><td>##IDS_ERROR_2329##</td></row>
		<row><td>2330</td><td>##IDS_ERROR_2330##</td></row>
		<row><td>2331</td><td>##IDS_ERROR_2331##</td></row>
		<row><td>2332</td><td>##IDS_ERROR_2332##</td></row>
		<row><td>2333</td><td>##IDS_ERROR_2333##</td></row>
		<row><td>2334</td><td>##IDS_ERROR_2334##</td></row>
		<row><td>2335</td><td>##IDS_ERROR_2335##</td></row>
		<row><td>2336</td><td>##IDS_ERROR_2336##</td></row>
		<row><td>2337</td><td>##IDS_ERROR_2337##</td></row>
		<row><td>2338</td><td>##IDS_ERROR_2338##</td></row>
		<row><td>2339</td><td>##IDS_ERROR_2339##</td></row>
		<row><td>2340</td><td>##IDS_ERROR_2340##</td></row>
		<row><td>2341</td><td>##IDS_ERROR_2341##</td></row>
		<row><td>2342</td><td>##IDS_ERROR_2342##</td></row>
		<row><td>2343</td><td>##IDS_ERROR_2343##</td></row>
		<row><td>2344</td><td>##IDS_ERROR_2344##</td></row>
		<row><td>2345</td><td>##IDS_ERROR_2345##</td></row>
		<row><td>2347</td><td>##IDS_ERROR_2347##</td></row>
		<row><td>2348</td><td>##IDS_ERROR_2348##</td></row>
		<row><td>2349</td><td>##IDS_ERROR_2349##</td></row>
		<row><td>2350</td><td>##IDS_ERROR_2350##</td></row>
		<row><td>2351</td><td>##IDS_ERROR_2351##</td></row>
		<row><td>2352</td><td>##IDS_ERROR_2352##</td></row>
		<row><td>2353</td><td>##IDS_ERROR_2353##</td></row>
		<row><td>2354</td><td>##IDS_ERROR_2354##</td></row>
		<row><td>2355</td><td>##IDS_ERROR_2355##</td></row>
		<row><td>2356</td><td>##IDS_ERROR_2356##</td></row>
		<row><td>2357</td><td>##IDS_ERROR_2357##</td></row>
		<row><td>2358</td><td>##IDS_ERROR_2358##</td></row>
		<row><td>2359</td><td>##IDS_ERROR_2359##</td></row>
		<row><td>2360</td><td>##IDS_ERROR_2360##</td></row>
		<row><td>2361</td><td>##IDS_ERROR_2361##</td></row>
		<row><td>2362</td><td>##IDS_ERROR_2362##</td></row>
		<row><td>2363</td><td>##IDS_ERROR_2363##</td></row>
		<row><td>2364</td><td>##IDS_ERROR_2364##</td></row>
		<row><td>2365</td><td>##IDS_ERROR_2365##</td></row>
		<row><td>2366</td><td>##IDS_ERROR_2366##</td></row>
		<row><td>2367</td><td>##IDS_ERROR_2367##</td></row>
		<row><td>2368</td><td>##IDS_ERROR_2368##</td></row>
		<row><td>2370</td><td>##IDS_ERROR_2370##</td></row>
		<row><td>2371</td><td>##IDS_ERROR_2371##</td></row>
		<row><td>2372</td><td>##IDS_ERROR_2372##</td></row>
		<row><td>2373</td><td>##IDS_ERROR_2373##</td></row>
		<row><td>2374</td><td>##IDS_ERROR_2374##</td></row>
		<row><td>2375</td><td>##IDS_ERROR_2375##</td></row>
		<row><td>2376</td><td>##IDS_ERROR_2376##</td></row>
		<row><td>2379</td><td>##IDS_ERROR_2379##</td></row>
		<row><td>2380</td><td>##IDS_ERROR_2380##</td></row>
		<row><td>2381</td><td>##IDS_ERROR_2381##</td></row>
		<row><td>2382</td><td>##IDS_ERROR_2382##</td></row>
		<row><td>2401</td><td>##IDS_ERROR_2401##</td></row>
		<row><td>2402</td><td>##IDS_ERROR_2402##</td></row>
		<row><td>2501</td><td>##IDS_ERROR_2501##</td></row>
		<row><td>2502</td><td>##IDS_ERROR_2502##</td></row>
		<row><td>2503</td><td>##IDS_ERROR_2503##</td></row>
		<row><td>2601</td><td>##IDS_ERROR_2601##</td></row>
		<row><td>2602</td><td>##IDS_ERROR_2602##</td></row>
		<row><td>2603</td><td>##IDS_ERROR_2603##</td></row>
		<row><td>2604</td><td>##IDS_ERROR_2604##</td></row>
		<row><td>2605</td><td>##IDS_ERROR_2605##</td></row>
		<row><td>2606</td><td>##IDS_ERROR_2606##</td></row>
		<row><td>2607</td><td>##IDS_ERROR_2607##</td></row>
		<row><td>2608</td><td>##IDS_ERROR_2608##</td></row>
		<row><td>2609</td><td>##IDS_ERROR_2609##</td></row>
		<row><td>2611</td><td>##IDS_ERROR_2611##</td></row>
		<row><td>2612</td><td>##IDS_ERROR_2612##</td></row>
		<row><td>2613</td><td>##IDS_ERROR_2613##</td></row>
		<row><td>2614</td><td>##IDS_ERROR_2614##</td></row>
		<row><td>2615</td><td>##IDS_ERROR_2615##</td></row>
		<row><td>2616</td><td>##IDS_ERROR_2616##</td></row>
		<row><td>2617</td><td>##IDS_ERROR_2617##</td></row>
		<row><td>2618</td><td>##IDS_ERROR_2618##</td></row>
		<row><td>2619</td><td>##IDS_ERROR_2619##</td></row>
		<row><td>2620</td><td>##IDS_ERROR_2620##</td></row>
		<row><td>2621</td><td>##IDS_ERROR_2621##</td></row>
		<row><td>2701</td><td>##IDS_ERROR_2701##</td></row>
		<row><td>2702</td><td>##IDS_ERROR_2702##</td></row>
		<row><td>2703</td><td>##IDS_ERROR_2703##</td></row>
		<row><td>2704</td><td>##IDS_ERROR_2704##</td></row>
		<row><td>2705</td><td>##IDS_ERROR_2705##</td></row>
		<row><td>2706</td><td>##IDS_ERROR_2706##</td></row>
		<row><td>2707</td><td>##IDS_ERROR_2707##</td></row>
		<row><td>2708</td><td>##IDS_ERROR_2708##</td></row>
		<row><td>2709</td><td>##IDS_ERROR_2709##</td></row>
		<row><td>2710</td><td>##IDS_ERROR_2710##</td></row>
		<row><td>2711</td><td>##IDS_ERROR_2711##</td></row>
		<row><td>2712</td><td>##IDS_ERROR_2712##</td></row>
		<row><td>2713</td><td>##IDS_ERROR_2713##</td></row>
		<row><td>2714</td><td>##IDS_ERROR_2714##</td></row>
		<row><td>2715</td><td>##IDS_ERROR_2715##</td></row>
		<row><td>2716</td><td>##IDS_ERROR_2716##</td></row>
		<row><td>2717</td><td>##IDS_ERROR_2717##</td></row>
		<row><td>2718</td><td>##IDS_ERROR_2718##</td></row>
		<row><td>2719</td><td>##IDS_ERROR_2719##</td></row>
		<row><td>2720</td><td>##IDS_ERROR_2720##</td></row>
		<row><td>2721</td><td>##IDS_ERROR_2721##</td></row>
		<row><td>2722</td><td>##IDS_ERROR_2722##</td></row>
		<row><td>2723</td><td>##IDS_ERROR_2723##</td></row>
		<row><td>2724</td><td>##IDS_ERROR_2724##</td></row>
		<row><td>2725</td><td>##IDS_ERROR_2725##</td></row>
		<row><td>2726</td><td>##IDS_ERROR_2726##</td></row>
		<row><td>2727</td><td>##IDS_ERROR_2727##</td></row>
		<row><td>2728</td><td>##IDS_ERROR_2728##</td></row>
		<row><td>2729</td><td>##IDS_ERROR_2729##</td></row>
		<row><td>2730</td><td>##IDS_ERROR_2730##</td></row>
		<row><td>2731</td><td>##IDS_ERROR_2731##</td></row>
		<row><td>2732</td><td>##IDS_ERROR_2732##</td></row>
		<row><td>2733</td><td>##IDS_ERROR_2733##</td></row>
		<row><td>2734</td><td>##IDS_ERROR_2734##</td></row>
		<row><td>2735</td><td>##IDS_ERROR_2735##</td></row>
		<row><td>2736</td><td>##IDS_ERROR_2736##</td></row>
		<row><td>2737</td><td>##IDS_ERROR_2737##</td></row>
		<row><td>2738</td><td>##IDS_ERROR_2738##</td></row>
		<row><td>2739</td><td>##IDS_ERROR_2739##</td></row>
		<row><td>2740</td><td>##IDS_ERROR_2740##</td></row>
		<row><td>2741</td><td>##IDS_ERROR_2741##</td></row>
		<row><td>2742</td><td>##IDS_ERROR_2742##</td></row>
		<row><td>2743</td><td>##IDS_ERROR_2743##</td></row>
		<row><td>2744</td><td>##IDS_ERROR_2744##</td></row>
		<row><td>2745</td><td>##IDS_ERROR_2745##</td></row>
		<row><td>2746</td><td>##IDS_ERROR_2746##</td></row>
		<row><td>2747</td><td>##IDS_ERROR_2747##</td></row>
		<row><td>2748</td><td>##IDS_ERROR_2748##</td></row>
		<row><td>2749</td><td>##IDS_ERROR_2749##</td></row>
		<row><td>2750</td><td>##IDS_ERROR_2750##</td></row>
		<row><td>27500</td><td>##IDS_ERROR_130##</td></row>
		<row><td>27501</td><td>##IDS_ERROR_131##</td></row>
		<row><td>27502</td><td>##IDS_ERROR_27502##</td></row>
		<row><td>27503</td><td>##IDS_ERROR_27503##</td></row>
		<row><td>27504</td><td>##IDS_ERROR_27504##</td></row>
		<row><td>27505</td><td>##IDS_ERROR_27505##</td></row>
		<row><td>27506</td><td>##IDS_ERROR_27506##</td></row>
		<row><td>27507</td><td>##IDS_ERROR_27507##</td></row>
		<row><td>27508</td><td>##IDS_ERROR_27508##</td></row>
		<row><td>27509</td><td>##IDS_ERROR_27509##</td></row>
		<row><td>2751</td><td>##IDS_ERROR_2751##</td></row>
		<row><td>27510</td><td>##IDS_ERROR_27510##</td></row>
		<row><td>27511</td><td>##IDS_ERROR_27511##</td></row>
		<row><td>27512</td><td>##IDS_ERROR_27512##</td></row>
		<row><td>27513</td><td>##IDS_ERROR_27513##</td></row>
		<row><td>27514</td><td>##IDS_ERROR_27514##</td></row>
		<row><td>27515</td><td>##IDS_ERROR_27515##</td></row>
		<row><td>27516</td><td>##IDS_ERROR_27516##</td></row>
		<row><td>27517</td><td>##IDS_ERROR_27517##</td></row>
		<row><td>27518</td><td>##IDS_ERROR_27518##</td></row>
		<row><td>27519</td><td>##IDS_ERROR_27519##</td></row>
		<row><td>2752</td><td>##IDS_ERROR_2752##</td></row>
		<row><td>27520</td><td>##IDS_ERROR_27520##</td></row>
		<row><td>27521</td><td>##IDS_ERROR_27521##</td></row>
		<row><td>27522</td><td>##IDS_ERROR_27522##</td></row>
		<row><td>27523</td><td>##IDS_ERROR_27523##</td></row>
		<row><td>27524</td><td>##IDS_ERROR_27524##</td></row>
		<row><td>27525</td><td>##IDS_ERROR_27525##</td></row>
		<row><td>27526</td><td>##IDS_ERROR_27526##</td></row>
		<row><td>27527</td><td>##IDS_ERROR_27527##</td></row>
		<row><td>27528</td><td>##IDS_ERROR_27528##</td></row>
		<row><td>27529</td><td>##IDS_ERROR_27529##</td></row>
		<row><td>2753</td><td>##IDS_ERROR_2753##</td></row>
		<row><td>27530</td><td>##IDS_ERROR_27530##</td></row>
		<row><td>27531</td><td>##IDS_ERROR_27531##</td></row>
		<row><td>27532</td><td>##IDS_ERROR_27532##</td></row>
		<row><td>27533</td><td>##IDS_ERROR_27533##</td></row>
		<row><td>27534</td><td>##IDS_ERROR_27534##</td></row>
		<row><td>27535</td><td>##IDS_ERROR_27535##</td></row>
		<row><td>27536</td><td>##IDS_ERROR_27536##</td></row>
		<row><td>27537</td><td>##IDS_ERROR_27537##</td></row>
		<row><td>27538</td><td>##IDS_ERROR_27538##</td></row>
		<row><td>27539</td><td>##IDS_ERROR_27539##</td></row>
		<row><td>2754</td><td>##IDS_ERROR_2754##</td></row>
		<row><td>27540</td><td>##IDS_ERROR_27540##</td></row>
		<row><td>27541</td><td>##IDS_ERROR_27541##</td></row>
		<row><td>27542</td><td>##IDS_ERROR_27542##</td></row>
		<row><td>27543</td><td>##IDS_ERROR_27543##</td></row>
		<row><td>27544</td><td>##IDS_ERROR_27544##</td></row>
		<row><td>27545</td><td>##IDS_ERROR_27545##</td></row>
		<row><td>27546</td><td>##IDS_ERROR_27546##</td></row>
		<row><td>27547</td><td>##IDS_ERROR_27547##</td></row>
		<row><td>27548</td><td>##IDS_ERROR_27548##</td></row>
		<row><td>27549</td><td>##IDS_ERROR_27549##</td></row>
		<row><td>2755</td><td>##IDS_ERROR_2755##</td></row>
		<row><td>27550</td><td>##IDS_ERROR_27550##</td></row>
		<row><td>27551</td><td>##IDS_ERROR_27551##</td></row>
		<row><td>27552</td><td>##IDS_ERROR_27552##</td></row>
		<row><td>27553</td><td>##IDS_ERROR_27553##</td></row>
		<row><td>27554</td><td>##IDS_ERROR_27554##</td></row>
		<row><td>27555</td><td>##IDS_ERROR_27555##</td></row>
		<row><td>2756</td><td>##IDS_ERROR_2756##</td></row>
		<row><td>2757</td><td>##IDS_ERROR_2757##</td></row>
		<row><td>2758</td><td>##IDS_ERROR_2758##</td></row>
		<row><td>2759</td><td>##IDS_ERROR_2759##</td></row>
		<row><td>2760</td><td>##IDS_ERROR_2760##</td></row>
		<row><td>2761</td><td>##IDS_ERROR_2761##</td></row>
		<row><td>2762</td><td>##IDS_ERROR_2762##</td></row>
		<row><td>2763</td><td>##IDS_ERROR_2763##</td></row>
		<row><td>2765</td><td>##IDS_ERROR_2765##</td></row>
		<row><td>2766</td><td>##IDS_ERROR_2766##</td></row>
		<row><td>2767</td><td>##IDS_ERROR_2767##</td></row>
		<row><td>2768</td><td>##IDS_ERROR_2768##</td></row>
		<row><td>2769</td><td>##IDS_ERROR_2769##</td></row>
		<row><td>2770</td><td>##IDS_ERROR_2770##</td></row>
		<row><td>2771</td><td>##IDS_ERROR_2771##</td></row>
		<row><td>2772</td><td>##IDS_ERROR_2772##</td></row>
		<row><td>2801</td><td>##IDS_ERROR_2801##</td></row>
		<row><td>2802</td><td>##IDS_ERROR_2802##</td></row>
		<row><td>2803</td><td>##IDS_ERROR_2803##</td></row>
		<row><td>2804</td><td>##IDS_ERROR_2804##</td></row>
		<row><td>2806</td><td>##IDS_ERROR_2806##</td></row>
		<row><td>2807</td><td>##IDS_ERROR_2807##</td></row>
		<row><td>2808</td><td>##IDS_ERROR_2808##</td></row>
		<row><td>2809</td><td>##IDS_ERROR_2809##</td></row>
		<row><td>2810</td><td>##IDS_ERROR_2810##</td></row>
		<row><td>2811</td><td>##IDS_ERROR_2811##</td></row>
		<row><td>2812</td><td>##IDS_ERROR_2812##</td></row>
		<row><td>2813</td><td>##IDS_ERROR_2813##</td></row>
		<row><td>2814</td><td>##IDS_ERROR_2814##</td></row>
		<row><td>2815</td><td>##IDS_ERROR_2815##</td></row>
		<row><td>2816</td><td>##IDS_ERROR_2816##</td></row>
		<row><td>2817</td><td>##IDS_ERROR_2817##</td></row>
		<row><td>2818</td><td>##IDS_ERROR_2818##</td></row>
		<row><td>2819</td><td>##IDS_ERROR_2819##</td></row>
		<row><td>2820</td><td>##IDS_ERROR_2820##</td></row>
		<row><td>2821</td><td>##IDS_ERROR_2821##</td></row>
		<row><td>2822</td><td>##IDS_ERROR_2822##</td></row>
		<row><td>2823</td><td>##IDS_ERROR_2823##</td></row>
		<row><td>2824</td><td>##IDS_ERROR_2824##</td></row>
		<row><td>2825</td><td>##IDS_ERROR_2825##</td></row>
		<row><td>2826</td><td>##IDS_ERROR_2826##</td></row>
		<row><td>2827</td><td>##IDS_ERROR_2827##</td></row>
		<row><td>2828</td><td>##IDS_ERROR_2828##</td></row>
		<row><td>2829</td><td>##IDS_ERROR_2829##</td></row>
		<row><td>2830</td><td>##IDS_ERROR_2830##</td></row>
		<row><td>2831</td><td>##IDS_ERROR_2831##</td></row>
		<row><td>2832</td><td>##IDS_ERROR_2832##</td></row>
		<row><td>2833</td><td>##IDS_ERROR_2833##</td></row>
		<row><td>2834</td><td>##IDS_ERROR_2834##</td></row>
		<row><td>2835</td><td>##IDS_ERROR_2835##</td></row>
		<row><td>2836</td><td>##IDS_ERROR_2836##</td></row>
		<row><td>2837</td><td>##IDS_ERROR_2837##</td></row>
		<row><td>2838</td><td>##IDS_ERROR_2838##</td></row>
		<row><td>2839</td><td>##IDS_ERROR_2839##</td></row>
		<row><td>2840</td><td>##IDS_ERROR_2840##</td></row>
		<row><td>2841</td><td>##IDS_ERROR_2841##</td></row>
		<row><td>2842</td><td>##IDS_ERROR_2842##</td></row>
		<row><td>2843</td><td>##IDS_ERROR_2843##</td></row>
		<row><td>2844</td><td>##IDS_ERROR_2844##</td></row>
		<row><td>2845</td><td>##IDS_ERROR_2845##</td></row>
		<row><td>2846</td><td>##IDS_ERROR_2846##</td></row>
		<row><td>2847</td><td>##IDS_ERROR_2847##</td></row>
		<row><td>2848</td><td>##IDS_ERROR_2848##</td></row>
		<row><td>2849</td><td>##IDS_ERROR_2849##</td></row>
		<row><td>2850</td><td>##IDS_ERROR_2850##</td></row>
		<row><td>2851</td><td>##IDS_ERROR_2851##</td></row>
		<row><td>2852</td><td>##IDS_ERROR_2852##</td></row>
		<row><td>2853</td><td>##IDS_ERROR_2853##</td></row>
		<row><td>2854</td><td>##IDS_ERROR_2854##</td></row>
		<row><td>2855</td><td>##IDS_ERROR_2855##</td></row>
		<row><td>2856</td><td>##IDS_ERROR_2856##</td></row>
		<row><td>2857</td><td>##IDS_ERROR_2857##</td></row>
		<row><td>2858</td><td>##IDS_ERROR_2858##</td></row>
		<row><td>2859</td><td>##IDS_ERROR_2859##</td></row>
		<row><td>2860</td><td>##IDS_ERROR_2860##</td></row>
		<row><td>2861</td><td>##IDS_ERROR_2861##</td></row>
		<row><td>2862</td><td>##IDS_ERROR_2862##</td></row>
		<row><td>2863</td><td>##IDS_ERROR_2863##</td></row>
		<row><td>2864</td><td>##IDS_ERROR_2864##</td></row>
		<row><td>2865</td><td>##IDS_ERROR_2865##</td></row>
		<row><td>2866</td><td>##IDS_ERROR_2866##</td></row>
		<row><td>2867</td><td>##IDS_ERROR_2867##</td></row>
		<row><td>2868</td><td>##IDS_ERROR_2868##</td></row>
		<row><td>2869</td><td>##IDS_ERROR_2869##</td></row>
		<row><td>2870</td><td>##IDS_ERROR_2870##</td></row>
		<row><td>2871</td><td>##IDS_ERROR_2871##</td></row>
		<row><td>2872</td><td>##IDS_ERROR_2872##</td></row>
		<row><td>2873</td><td>##IDS_ERROR_2873##</td></row>
		<row><td>2874</td><td>##IDS_ERROR_2874##</td></row>
		<row><td>2875</td><td>##IDS_ERROR_2875##</td></row>
		<row><td>2876</td><td>##IDS_ERROR_2876##</td></row>
		<row><td>2877</td><td>##IDS_ERROR_2877##</td></row>
		<row><td>2878</td><td>##IDS_ERROR_2878##</td></row>
		<row><td>2879</td><td>##IDS_ERROR_2879##</td></row>
		<row><td>2880</td><td>##IDS_ERROR_2880##</td></row>
		<row><td>2881</td><td>##IDS_ERROR_2881##</td></row>
		<row><td>2882</td><td>##IDS_ERROR_2882##</td></row>
		<row><td>2883</td><td>##IDS_ERROR_2883##</td></row>
		<row><td>2884</td><td>##IDS_ERROR_2884##</td></row>
		<row><td>2885</td><td>##IDS_ERROR_2885##</td></row>
		<row><td>2886</td><td>##IDS_ERROR_2886##</td></row>
		<row><td>2887</td><td>##IDS_ERROR_2887##</td></row>
		<row><td>2888</td><td>##IDS_ERROR_2888##</td></row>
		<row><td>2889</td><td>##IDS_ERROR_2889##</td></row>
		<row><td>2890</td><td>##IDS_ERROR_2890##</td></row>
		<row><td>2891</td><td>##IDS_ERROR_2891##</td></row>
		<row><td>2892</td><td>##IDS_ERROR_2892##</td></row>
		<row><td>2893</td><td>##IDS_ERROR_2893##</td></row>
		<row><td>2894</td><td>##IDS_ERROR_2894##</td></row>
		<row><td>2895</td><td>##IDS_ERROR_2895##</td></row>
		<row><td>2896</td><td>##IDS_ERROR_2896##</td></row>
		<row><td>2897</td><td>##IDS_ERROR_2897##</td></row>
		<row><td>2898</td><td>##IDS_ERROR_2898##</td></row>
		<row><td>2899</td><td>##IDS_ERROR_2899##</td></row>
		<row><td>2901</td><td>##IDS_ERROR_2901##</td></row>
		<row><td>2902</td><td>##IDS_ERROR_2902##</td></row>
		<row><td>2903</td><td>##IDS_ERROR_2903##</td></row>
		<row><td>2904</td><td>##IDS_ERROR_2904##</td></row>
		<row><td>2905</td><td>##IDS_ERROR_2905##</td></row>
		<row><td>2906</td><td>##IDS_ERROR_2906##</td></row>
		<row><td>2907</td><td>##IDS_ERROR_2907##</td></row>
		<row><td>2908</td><td>##IDS_ERROR_2908##</td></row>
		<row><td>2909</td><td>##IDS_ERROR_2909##</td></row>
		<row><td>2910</td><td>##IDS_ERROR_2910##</td></row>
		<row><td>2911</td><td>##IDS_ERROR_2911##</td></row>
		<row><td>2912</td><td>##IDS_ERROR_2912##</td></row>
		<row><td>2919</td><td>##IDS_ERROR_2919##</td></row>
		<row><td>2920</td><td>##IDS_ERROR_2920##</td></row>
		<row><td>2924</td><td>##IDS_ERROR_2924##</td></row>
		<row><td>2927</td><td>##IDS_ERROR_2927##</td></row>
		<row><td>2928</td><td>##IDS_ERROR_2928##</td></row>
		<row><td>2929</td><td>##IDS_ERROR_2929##</td></row>
		<row><td>2932</td><td>##IDS_ERROR_2932##</td></row>
		<row><td>2933</td><td>##IDS_ERROR_2933##</td></row>
		<row><td>2934</td><td>##IDS_ERROR_2934##</td></row>
		<row><td>2935</td><td>##IDS_ERROR_2935##</td></row>
		<row><td>2936</td><td>##IDS_ERROR_2936##</td></row>
		<row><td>2937</td><td>##IDS_ERROR_2937##</td></row>
		<row><td>2938</td><td>##IDS_ERROR_2938##</td></row>
		<row><td>2939</td><td>##IDS_ERROR_2939##</td></row>
		<row><td>2940</td><td>##IDS_ERROR_2940##</td></row>
		<row><td>2941</td><td>##IDS_ERROR_2941##</td></row>
		<row><td>2942</td><td>##IDS_ERROR_2942##</td></row>
		<row><td>2943</td><td>##IDS_ERROR_2943##</td></row>
		<row><td>2944</td><td>##IDS_ERROR_2944##</td></row>
		<row><td>2945</td><td>##IDS_ERROR_2945##</td></row>
		<row><td>3001</td><td>##IDS_ERROR_3001##</td></row>
		<row><td>3002</td><td>##IDS_ERROR_3002##</td></row>
		<row><td>32</td><td>##IDS_ERROR_20##</td></row>
		<row><td>33</td><td>##IDS_ERROR_21##</td></row>
		<row><td>4</td><td>##IDS_ERROR_3##</td></row>
		<row><td>5</td><td>##IDS_ERROR_4##</td></row>
		<row><td>7</td><td>##IDS_ERROR_5##</td></row>
		<row><td>8</td><td>##IDS_ERROR_6##</td></row>
		<row><td>9</td><td>##IDS_ERROR_7##</td></row>
	</table>

	<table name="EventMapping">
		<col key="yes" def="s72">Dialog_</col>
		<col key="yes" def="s50">Control_</col>
		<col key="yes" def="s50">Event</col>
		<col def="s50">Attribute</col>
		<row><td>CustomSetup</td><td>ItemDescription</td><td>SelectionDescription</td><td>Text</td></row>
		<row><td>CustomSetup</td><td>Location</td><td>SelectionPath</td><td>Text</td></row>
		<row><td>CustomSetup</td><td>Size</td><td>SelectionSize</td><td>Text</td></row>
		<row><td>SetupInitialization</td><td>ActionData</td><td>ActionData</td><td>Text</td></row>
		<row><td>SetupInitialization</td><td>ActionText</td><td>ActionText</td><td>Text</td></row>
		<row><td>SetupProgress</td><td>ActionProgress95</td><td>AdminInstallFinalize</td><td>Progress</td></row>
		<row><td>SetupProgress</td><td>ActionProgress95</td><td>InstallFiles</td><td>Progress</td></row>
		<row><td>SetupProgress</td><td>ActionProgress95</td><td>MoveFiles</td><td>Progress</td></row>
		<row><td>SetupProgress</td><td>ActionProgress95</td><td>RemoveFiles</td><td>Progress</td></row>
		<row><td>SetupProgress</td><td>ActionProgress95</td><td>RemoveRegistryValues</td><td>Progress</td></row>
		<row><td>SetupProgress</td><td>ActionProgress95</td><td>SetProgress</td><td>Progress</td></row>
		<row><td>SetupProgress</td><td>ActionProgress95</td><td>UnmoveFiles</td><td>Progress</td></row>
		<row><td>SetupProgress</td><td>ActionProgress95</td><td>WriteIniValues</td><td>Progress</td></row>
		<row><td>SetupProgress</td><td>ActionProgress95</td><td>WriteRegistryValues</td><td>Progress</td></row>
		<row><td>SetupProgress</td><td>ActionText</td><td>ActionText</td><td>Text</td></row>
	</table>

	<table name="Extension">
		<col key="yes" def="s255">Extension</col>
		<col key="yes" def="s72">Component_</col>
		<col def="S255">ProgId_</col>
		<col def="S64">MIME_</col>
		<col def="s38">Feature_</col>
	</table>

	<table name="Feature">
		<col key="yes" def="s38">Feature</col>
		<col def="S38">Feature_Parent</col>
		<col def="L64">Title</col>
		<col def="L255">Description</col>
		<col def="I2">Display</col>
		<col def="i2">Level</col>
		<col def="S72">Directory_</col>
		<col def="i2">Attributes</col>
		<col def="S255">ISReleaseFlags</col>
		<col def="S255">ISComments</col>
		<col def="S255">ISFeatureCabName</col>
		<col def="S255">ISProFeatureName</col>
		<row><td>AlwaysInstall</td><td/><td>##DN_AlwaysInstall##</td><td>Enter the description for this feature here.</td><td>0</td><td>1</td><td>INSTALLDIR</td><td>16</td><td/><td>Enter comments regarding this feature here.</td><td/><td/></row>
	</table>

	<table name="FeatureComponents">
		<col key="yes" def="s38">Feature_</col>
		<col key="yes" def="s72">Component_</col>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT1</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT10</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT100</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT101</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT102</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT103</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT104</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT105</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT106</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT107</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT108</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT109</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT11</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT110</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT111</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT112</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT113</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT114</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT115</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT116</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT117</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT118</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT119</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT12</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT120</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT121</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT122</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT123</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT124</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT125</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT126</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT127</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT128</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT129</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT13</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT130</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT131</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT132</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT133</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT134</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT135</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT136</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT137</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT138</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT139</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT14</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT140</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT141</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT142</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT143</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT144</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT145</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT146</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT147</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT148</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT149</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT15</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT150</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT151</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT152</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT153</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT154</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT155</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT156</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT157</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT158</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT159</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT16</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT160</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT161</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT162</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT163</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT164</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT165</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT166</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT167</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT168</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT169</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT17</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT170</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT171</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT172</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT173</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT174</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT175</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT176</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT177</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT18</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT19</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT2</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT20</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT21</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT22</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT23</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT24</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT25</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT26</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT27</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT28</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT29</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT3</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT30</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT31</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT32</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT33</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT34</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT35</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT36</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT37</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT38</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT39</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT4</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT40</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT41</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT42</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT43</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT44</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT45</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT46</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT47</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT48</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT49</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT5</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT50</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT51</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT52</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT53</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT54</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT55</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT56</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT57</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT58</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT59</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT6</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT60</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT61</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT62</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT63</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT64</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT65</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT66</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT67</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT68</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT69</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT7</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT70</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT71</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT72</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT73</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT74</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT75</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT76</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT77</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT78</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT79</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT8</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT80</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT81</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT82</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT83</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT84</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT85</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT86</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT87</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT88</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT89</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT9</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT90</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT91</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT92</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT93</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT94</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT95</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT96</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT97</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT98</td></row>
		<row><td>AlwaysInstall</td><td>ISX_DEFAULTCOMPONENT99</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.BitConverter.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.BitConverter.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.BitConverter.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.BitConverter.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.EnhancedeMoteLcd.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SerialComm.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SerialComm.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SerialComm.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SerialComm.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll4</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll5</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll6</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.Sqrt.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.Sqrt.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.Sqrt.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.Sqrt.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.VersionInfo.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.VersionInfo.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.VersionInfo.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.VersionInfo.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.VersionInfo.dll4</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.VersionInfo.dll5</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.VersionInfo.dll6</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.VersionInfo.dll7</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh.AppNote.Utility.VersionInfo.dll8</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote.dll4</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote.dll5</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote.dll6</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote.dll7</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote.dll8</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Adapt.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Adapt.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Adapt.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Adapt.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Adapt.dll4</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Adapt.dll5</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Adapt.dll6</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Adapt.dll7</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Adapt.dll8</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DSP.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DSP.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DSP.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DSP.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DSP.dll4</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DSP.dll5</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DSP.dll6</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DSP.dll7</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DSP.dll8</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DotNow.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DotNow.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DotNow.dll10</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DotNow.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DotNow.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DotNow.dll4</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DotNow.dll5</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DotNow.dll6</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DotNow.dll7</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DotNow.dll8</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_DotNow.dll9</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Kiwi.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Kiwi.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Kiwi.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Kiwi.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Kiwi.dll4</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Kiwi.dll5</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Kiwi.dll6</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Kiwi.dll7</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Kiwi.dll8</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Net.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Net.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Net.dll10</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Net.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Net.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Net.dll4</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Net.dll5</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Net.dll6</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Net.dll7</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Net.dll8</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_Net.dll9</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_RealTime.dll</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_RealTime.dll1</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_RealTime.dll2</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_RealTime.dll3</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_RealTime.dll4</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_RealTime.dll5</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_RealTime.dll6</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_RealTime.dll7</td></row>
		<row><td>AlwaysInstall</td><td>Samraksh_eMote_RealTime.dll8</td></row>
		<row><td>AlwaysInstall</td><td>TestEnhancedeMoteLCD.exe</td></row>
		<row><td>AlwaysInstall</td><td>TestEnhancedeMoteLCD.exe1</td></row>
		<row><td>AlwaysInstall</td><td>TestEnhancedeMoteLCD.exe2</td></row>
		<row><td>AlwaysInstall</td><td>TestEnhancedeMoteLCD.exe3</td></row>
		<row><td>AlwaysInstall</td><td>TestEnhancedeMoteLCD.exe4</td></row>
		<row><td>AlwaysInstall</td><td>TestEnhancedeMoteLCD.exe5</td></row>
		<row><td>AlwaysInstall</td><td>TestEnhancedeMoteLCD.exe6</td></row>
	</table>

	<table name="File">
		<col key="yes" def="s72">File</col>
		<col def="s72">Component_</col>
		<col def="s255">FileName</col>
		<col def="i4">FileSize</col>
		<col def="S72">Version</col>
		<col def="S20">Language</col>
		<col def="I2">Attributes</col>
		<col def="i2">Sequence</col>
		<col def="S255">ISBuildSourcePath</col>
		<col def="I4">ISAttributes</col>
		<col def="S72">ISComponentSubFolder_</col>
		<row><td>assemblyinfo.cs</td><td>ISX_DEFAULTCOMPONENT60</td><td>ASSEMB~1.CS|AssemblyInfo.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\Properties\AssemblyInfo.cs</td><td>1</td><td/></row>
		<row><td>assemblyinfo.cs1</td><td>ISX_DEFAULTCOMPONENT73</td><td>ASSEMB~1.CS|AssemblyInfo.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\Properties\AssemblyInfo.cs</td><td>1</td><td/></row>
		<row><td>assemblyinfo.cs2</td><td>ISX_DEFAULTCOMPONENT117</td><td>ASSEMB~1.CS|AssemblyInfo.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\Properties\AssemblyInfo.cs</td><td>1</td><td/></row>
		<row><td>assemblyinfo.cs3</td><td>ISX_DEFAULTCOMPONENT131</td><td>ASSEMB~1.CS|AssemblyInfo.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\Properties\AssemblyInfo.cs</td><td>1</td><td/></row>
		<row><td>assemblyinfo.cs4</td><td>ISX_DEFAULTCOMPONENT142</td><td>ASSEMB~1.CS|AssemblyInfo.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\Properties\AssemblyInfo.cs</td><td>1</td><td/></row>
		<row><td>assemblyinfo.cs5</td><td>ISX_DEFAULTCOMPONENT153</td><td>ASSEMB~1.CS|AssemblyInfo.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\Properties\AssemblyInfo.cs</td><td>1</td><td/></row>
		<row><td>assemblyinfo.cs6</td><td>ISX_DEFAULTCOMPONENT164</td><td>ASSEMB~1.CS|AssemblyInfo.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\Properties\AssemblyInfo.cs</td><td>1</td><td/></row>
		<row><td>assemblyinfo.cs7</td><td>ISX_DEFAULTCOMPONENT177</td><td>ASSEMB~1.CS|AssemblyInfo.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\Properties\AssemblyInfo.cs</td><td>1</td><td/></row>
		<row><td>bitconverter.cs</td><td>ISX_DEFAULTCOMPONENT123</td><td>BITCON~1.CS|BitConverter.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\BitConverter.cs</td><td>1</td><td/></row>
		<row><td>bitconverter.csproj</td><td>ISX_DEFAULTCOMPONENT123</td><td>BITCON~1.CSP|BitConverter.csproj</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\BitConverter.csproj</td><td>1</td><td/></row>
		<row><td>bitconverter.csproj.filelist</td><td>ISX_DEFAULTCOMPONENT127</td><td>BITCON~1.TXT|BitConverter.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\BitConverter.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>bitconverter.csprojresolveas</td><td>ISX_DEFAULTCOMPONENT127</td><td>BITCON~1.CAC|BitConverter.csprojResolveAssemblyReference.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\BitConverter.csprojResolveAssemblyReference.cache</td><td>1</td><td/></row>
		<row><td>bitconverter_1.1.sln</td><td>ISX_DEFAULTCOMPONENT119</td><td>BITCON~1.SLN|BitConverter 1.1.sln</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter 1.1.sln</td><td>1</td><td/></row>
		<row><td>bitconverter_1.1.v12.suo</td><td>ISX_DEFAULTCOMPONENT119</td><td>BITCON~1.SUO|BitConverter 1.1.v12.suo</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter 1.1.v12.suo</td><td>1</td><td/></row>
		<row><td>designtimeresolveassemblyref</td><td>ISX_DEFAULTCOMPONENT56</td><td>DESIGN~1.CAC|DesignTimeResolveAssemblyReferencesInput.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\DesignTimeResolveAssemblyReferencesInput.cache</td><td>1</td><td/></row>
		<row><td>designtimeresolveassemblyref1</td><td>ISX_DEFAULTCOMPONENT69</td><td>DESIGN~1.CAC|DesignTimeResolveAssemblyReferences.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\DesignTimeResolveAssemblyReferences.cache</td><td>1</td><td/></row>
		<row><td>designtimeresolveassemblyref2</td><td>ISX_DEFAULTCOMPONENT69</td><td>DESIGN~1.CAC|DesignTimeResolveAssemblyReferencesInput.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\DesignTimeResolveAssemblyReferencesInput.cache</td><td>1</td><td/></row>
		<row><td>designtimeresolveassemblyref3</td><td>ISX_DEFAULTCOMPONENT113</td><td>DESIGN~1.CAC|DesignTimeResolveAssemblyReferencesInput.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\DesignTimeResolveAssemblyReferencesInput.cache</td><td>1</td><td/></row>
		<row><td>designtimeresolveassemblyref4</td><td>ISX_DEFAULTCOMPONENT127</td><td>DESIGN~1.CAC|DesignTimeResolveAssemblyReferencesInput.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\DesignTimeResolveAssemblyReferencesInput.cache</td><td>1</td><td/></row>
		<row><td>designtimeresolveassemblyref5</td><td>ISX_DEFAULTCOMPONENT138</td><td>DESIGN~1.CAC|DesignTimeResolveAssemblyReferencesInput.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\obj\Debug\DesignTimeResolveAssemblyReferencesInput.cache</td><td>1</td><td/></row>
		<row><td>designtimeresolveassemblyref6</td><td>ISX_DEFAULTCOMPONENT149</td><td>DESIGN~1.CAC|DesignTimeResolveAssemblyReferencesInput.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\obj\Debug\DesignTimeResolveAssemblyReferencesInput.cache</td><td>1</td><td/></row>
		<row><td>designtimeresolveassemblyref7</td><td>ISX_DEFAULTCOMPONENT160</td><td>DESIGN~1.CAC|DesignTimeResolveAssemblyReferencesInput.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\obj\Debug\DesignTimeResolveAssemblyReferencesInput.cache</td><td>1</td><td/></row>
		<row><td>designtimeresolveassemblyref8</td><td>ISX_DEFAULTCOMPONENT173</td><td>DESIGN~1.CAC|DesignTimeResolveAssemblyReferencesInput.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\obj\Debug\DesignTimeResolveAssemblyReferencesInput.cache</td><td>1</td><td/></row>
		<row><td>emote_release_14_notes.rtf</td><td>ISX_DEFAULTCOMPONENT</td><td>EMOTE_~1.RTF|eMote_Release_14_Notes.rtf</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\eMote_Release_14_Notes.rtf</td><td>1</td><td/></row>
		<row><td>emote_release_14_notes.rtf1</td><td>ISX_DEFAULTCOMPONENT30</td><td>EMOTE_~1.RTF|eMote_Release_14_Notes.rtf</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\eMote_Release_14_Notes.rtf</td><td>1</td><td/></row>
		<row><td>emote_release_14_notes.rtf2</td><td>ISX_DEFAULTCOMPONENT82</td><td>EMOTE_~1.RTF|eMote_Release_14_Notes.rtf</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\eMote_Release_14_Notes.rtf</td><td>1</td><td/></row>
		<row><td>emote_tinybooter_v1.1.axf</td><td>ISX_DEFAULTCOMPONENT1</td><td>EMOTE_~1.AXF|Emote_TinyBooter_v1.1.axf</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\CLRandBooter\Emote_TinyBooter_v1.1.axf</td><td>1</td><td/></row>
		<row><td>emote_tinybooter_v1.1.axf1</td><td>ISX_DEFAULTCOMPONENT31</td><td>EMOTE_~1.AXF|Emote_TinyBooter_v1.1.axf</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\CLRandBooter\Emote_TinyBooter_v1.1.axf</td><td>1</td><td/></row>
		<row><td>emote_tinybooter_v1.1.axf2</td><td>ISX_DEFAULTCOMPONENT83</td><td>EMOTE_~1.AXF|Emote_TinyBooter_v1.1.axf</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\CLRandBooter\Emote_TinyBooter_v1.1.axf</td><td>1</td><td/></row>
		<row><td>enhancedemotelcd.cs</td><td>ISX_DEFAULTCOMPONENT54</td><td>ENHANC~1.CS|EnhancedEmoteLcd.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\EnhancedEmoteLcd.cs</td><td>1</td><td/></row>
		<row><td>enhancedemotelcd.csproj.file</td><td>ISX_DEFAULTCOMPONENT56</td><td>ENHANC~1.TXT|EnhancedeMoteLCD.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\EnhancedeMoteLCD.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>enhancedemotelcd.csprojresol</td><td>ISX_DEFAULTCOMPONENT56</td><td>ENHANC~1.CAC|EnhancedEmoteLCD.csprojResolveAssemblyReference.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\EnhancedEmoteLCD.csprojResolveAssemblyReference.cache</td><td>1</td><td/></row>
		<row><td>enhancedemotelcd_1.3.sln</td><td>ISX_DEFAULTCOMPONENT26</td><td>ENHANC~1.SLN|EnhancedEmoteLCD 1.3.sln</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD 1.3.sln</td><td>1</td><td/></row>
		<row><td>enhancedemotelcd_1.3.v12.suo</td><td>ISX_DEFAULTCOMPONENT26</td><td>ENHANC~1.SUO|EnhancedeMoteLCD 1.3.v12.suo</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedeMoteLCD 1.3.v12.suo</td><td>1</td><td/></row>
		<row><td>enhancedlcd.csproj.filelista</td><td>ISX_DEFAULTCOMPONENT56</td><td>ENHANC~1.TXT|EnhancedLCD.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\EnhancedLCD.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>enhancedlcd.csprojresolveass</td><td>ISX_DEFAULTCOMPONENT56</td><td>ENHANC~1.CAC|EnhancedLCD.csprojResolveAssemblyReference.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\EnhancedLCD.csprojResolveAssemblyReference.cache</td><td>1</td><td/></row>
		<row><td>er_config</td><td>ISX_DEFAULTCOMPONENT2</td><td>ER_CON~1|ER_CONFIG</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\CLRandBooter\Emote_TinyCLR_v14.hex\ER_CONFIG</td><td>1</td><td/></row>
		<row><td>er_config1</td><td>ISX_DEFAULTCOMPONENT32</td><td>ER_CON~1|ER_CONFIG</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\CLRandBooter\Emote_TinyCLR_v14.hex\ER_CONFIG</td><td>1</td><td/></row>
		<row><td>er_config2</td><td>ISX_DEFAULTCOMPONENT84</td><td>ER_CON~1|ER_CONFIG</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\CLRandBooter\Emote_TinyCLR_v14.hex\ER_CONFIG</td><td>1</td><td/></row>
		<row><td>er_dat</td><td>ISX_DEFAULTCOMPONENT2</td><td>ER_DAT</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\CLRandBooter\Emote_TinyCLR_v14.hex\ER_DAT</td><td>1</td><td/></row>
		<row><td>er_dat1</td><td>ISX_DEFAULTCOMPONENT32</td><td>ER_DAT</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\CLRandBooter\Emote_TinyCLR_v14.hex\ER_DAT</td><td>1</td><td/></row>
		<row><td>er_dat2</td><td>ISX_DEFAULTCOMPONENT84</td><td>ER_DAT</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\CLRandBooter\Emote_TinyCLR_v14.hex\ER_DAT</td><td>1</td><td/></row>
		<row><td>er_flash</td><td>ISX_DEFAULTCOMPONENT2</td><td>ER_FLASH</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\CLRandBooter\Emote_TinyCLR_v14.hex\ER_FLASH</td><td>1</td><td/></row>
		<row><td>er_flash1</td><td>ISX_DEFAULTCOMPONENT32</td><td>ER_FLASH</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\CLRandBooter\Emote_TinyCLR_v14.hex\ER_FLASH</td><td>1</td><td/></row>
		<row><td>er_flash2</td><td>ISX_DEFAULTCOMPONENT84</td><td>ER_FLASH</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\CLRandBooter\Emote_TinyCLR_v14.hex\ER_FLASH</td><td>1</td><td/></row>
		<row><td>er_iflash</td><td>ISX_DEFAULTCOMPONENT2</td><td>ER_IFL~1|ER_IFLASH</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\CLRandBooter\Emote_TinyCLR_v14.hex\ER_IFLASH</td><td>1</td><td/></row>
		<row><td>er_iflash1</td><td>ISX_DEFAULTCOMPONENT32</td><td>ER_IFL~1|ER_IFLASH</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\CLRandBooter\Emote_TinyCLR_v14.hex\ER_IFLASH</td><td>1</td><td/></row>
		<row><td>er_iflash2</td><td>ISX_DEFAULTCOMPONENT84</td><td>ER_IFL~1|ER_IFLASH</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\CLRandBooter\Emote_TinyCLR_v14.hex\ER_IFLASH</td><td>1</td><td/></row>
		<row><td>onboardflash.dat</td><td>ISX_DEFAULTCOMPONENT61</td><td>ONBOAR~1.DAT|OnBoardFlash.dat</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\OnBoardFlash.dat</td><td>1</td><td/></row>
		<row><td>onboardflash.dat.smd</td><td>ISX_DEFAULTCOMPONENT61</td><td>ONBOAR~1.SMD|OnBoardFlash.dat.smd</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\OnBoardFlash.dat.smd</td><td>1</td><td/></row>
		<row><td>program.cs</td><td>ISX_DEFAULTCOMPONENT61</td><td>Program.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\Program.cs</td><td>1</td><td/></row>
		<row><td>release14_full_image.bin</td><td>ISX_DEFAULTCOMPONENT1</td><td>RELEAS~1.BIN|release14_full_image.bin</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\CLRandBooter\release14_full_image.bin</td><td>1</td><td/></row>
		<row><td>release14_full_image.bin1</td><td>ISX_DEFAULTCOMPONENT31</td><td>RELEAS~1.BIN|release14_full_image.bin</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\CLRandBooter\release14_full_image.bin</td><td>1</td><td/></row>
		<row><td>release14_full_image.bin2</td><td>ISX_DEFAULTCOMPONENT83</td><td>RELEAS~1.BIN|release14_full_image.bin</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\CLRandBooter\release14_full_image.bin</td><td>1</td><td/></row>
		<row><td>resources.designer.cs</td><td>ISX_DEFAULTCOMPONENT61</td><td>RESOUR~1.CS|Resources.Designer.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\Resources.Designer.cs</td><td>1</td><td/></row>
		<row><td>resources.resx</td><td>ISX_DEFAULTCOMPONENT61</td><td>RESOUR~1.RES|Resources.resx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\Resources.resx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit</td><td>Samraksh.AppNote.Utility.BitConverter.dll</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.BitConverter.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\bin\be\Samraksh.AppNote.Utility.BitConverter.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit1</td><td>ISX_DEFAULTCOMPONENT121</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.BitConverter.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\bin\be\Samraksh.AppNote.Utility.BitConverter.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit10</td><td>ISX_DEFAULTCOMPONENT120</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.BitConverter.xml</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\bin\Samraksh.AppNote.Utility.BitConverter.xml</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit11</td><td>ISX_DEFAULTCOMPONENT128</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.BitConverter.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\be\Samraksh.AppNote.Utility.BitConverter.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit12</td><td>ISX_DEFAULTCOMPONENT128</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.BitConverter.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\be\Samraksh.AppNote.Utility.BitConverter.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit13</td><td>ISX_DEFAULTCOMPONENT129</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.BitConverter.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\le\Samraksh.AppNote.Utility.BitConverter.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit14</td><td>ISX_DEFAULTCOMPONENT129</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.BitConverter.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\le\Samraksh.AppNote.Utility.BitConverter.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit15</td><td>Samraksh.AppNote.Utility.BitConverter.dll3</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.BitConverter.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\Samraksh.AppNote.Utility.BitConverter.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit16</td><td>ISX_DEFAULTCOMPONENT127</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.BitConverter.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\Samraksh.AppNote.Utility.BitConverter.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit2</td><td>ISX_DEFAULTCOMPONENT121</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.BitConverter.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\bin\be\Samraksh.AppNote.Utility.BitConverter.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit3</td><td>ISX_DEFAULTCOMPONENT121</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.BitConverter.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\bin\be\Samraksh.AppNote.Utility.BitConverter.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit4</td><td>Samraksh.AppNote.Utility.BitConverter.dll1</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.BitConverter.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\bin\le\Samraksh.AppNote.Utility.BitConverter.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit5</td><td>ISX_DEFAULTCOMPONENT122</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.BitConverter.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\bin\le\Samraksh.AppNote.Utility.BitConverter.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit6</td><td>ISX_DEFAULTCOMPONENT122</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.BitConverter.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\bin\le\Samraksh.AppNote.Utility.BitConverter.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit7</td><td>ISX_DEFAULTCOMPONENT122</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.BitConverter.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\bin\le\Samraksh.AppNote.Utility.BitConverter.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit8</td><td>Samraksh.AppNote.Utility.BitConverter.dll2</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.BitConverter.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\bin\Samraksh.AppNote.Utility.BitConverter.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.bit9</td><td>ISX_DEFAULTCOMPONENT120</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.BitConverter.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\bin\Samraksh.AppNote.Utility.BitConverter.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\be\Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh1</td><td>ISX_DEFAULTCOMPONENT28</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\be\Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh10</td><td>ISX_DEFAULTCOMPONENT27</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.EnhancedEmoteLCD.xml</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\Samraksh.AppNote.Utility.EnhancedEmoteLCD.xml</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh11</td><td>ISX_DEFAULTCOMPONENT57</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\be\Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh12</td><td>ISX_DEFAULTCOMPONENT57</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.EnhancedEmoteLCD.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\be\Samraksh.AppNote.Utility.EnhancedEmoteLCD.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh13</td><td>ISX_DEFAULTCOMPONENT58</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\le\Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh14</td><td>ISX_DEFAULTCOMPONENT58</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.EnhancedEmoteLCD.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\le\Samraksh.AppNote.Utility.EnhancedEmoteLCD.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh15</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll3</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh16</td><td>ISX_DEFAULTCOMPONENT56</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh17</td><td>ISX_DEFAULTCOMPONENT64</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.EnhancedeMoteLcd.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\be\Samraksh.AppNote.Utility.EnhancedeMoteLcd.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh18</td><td>ISX_DEFAULTCOMPONENT64</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.EnhancedeMoteLcd.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\be\Samraksh.AppNote.Utility.EnhancedeMoteLcd.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh19</td><td>ISX_DEFAULTCOMPONENT65</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.EnhancedeMoteLcd.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\le\Samraksh.AppNote.Utility.EnhancedeMoteLcd.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh2</td><td>ISX_DEFAULTCOMPONENT28</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\be\Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh20</td><td>ISX_DEFAULTCOMPONENT65</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.EnhancedeMoteLcd.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\le\Samraksh.AppNote.Utility.EnhancedeMoteLcd.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh21</td><td>Samraksh.AppNote.Utility.EnhancedeMoteLcd.dll</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.EnhancedeMoteLcd.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\Samraksh.AppNote.Utility.EnhancedeMoteLcd.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh22</td><td>ISX_DEFAULTCOMPONENT63</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.EnhancedeMoteLcd.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\Samraksh.AppNote.Utility.EnhancedeMoteLcd.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh23</td><td>ISX_DEFAULTCOMPONENT63</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.EnhancedeMoteLcd.xml</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\Samraksh.AppNote.Utility.EnhancedeMoteLcd.xml</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh3</td><td>ISX_DEFAULTCOMPONENT28</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.EnhancedEmoteLCD.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\be\Samraksh.AppNote.Utility.EnhancedEmoteLCD.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh4</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll1</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\le\Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh5</td><td>ISX_DEFAULTCOMPONENT29</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\le\Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh6</td><td>ISX_DEFAULTCOMPONENT29</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\le\Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh7</td><td>ISX_DEFAULTCOMPONENT29</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.EnhancedEmoteLCD.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\le\Samraksh.AppNote.Utility.EnhancedEmoteLCD.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh8</td><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll2</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.enh9</td><td>ISX_DEFAULTCOMPONENT27</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\Samraksh.AppNote.Utility.EnhancedEmoteLCD.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser</td><td>Samraksh.AppNote.Utility.SerialComm.dll</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SerialComm.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\bin\be\Samraksh.AppNote.Utility.SerialComm.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser1</td><td>ISX_DEFAULTCOMPONENT134</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SerialComm.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\bin\be\Samraksh.AppNote.Utility.SerialComm.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser10</td><td>ISX_DEFAULTCOMPONENT133</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.SerialComm.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\bin\Samraksh.AppNote.Utility.SerialComm.XML</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser11</td><td>ISX_DEFAULTCOMPONENT139</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SerialComm.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\obj\Debug\be\Samraksh.AppNote.Utility.SerialComm.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser12</td><td>ISX_DEFAULTCOMPONENT139</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SerialComm.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\obj\Debug\be\Samraksh.AppNote.Utility.SerialComm.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser13</td><td>ISX_DEFAULTCOMPONENT140</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SerialComm.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\obj\Debug\le\Samraksh.AppNote.Utility.SerialComm.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser14</td><td>ISX_DEFAULTCOMPONENT140</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SerialComm.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\obj\Debug\le\Samraksh.AppNote.Utility.SerialComm.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser15</td><td>Samraksh.AppNote.Utility.SerialComm.dll3</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SerialComm.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\obj\Debug\Samraksh.AppNote.Utility.SerialComm.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser16</td><td>ISX_DEFAULTCOMPONENT138</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SerialComm.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\obj\Debug\Samraksh.AppNote.Utility.SerialComm.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser2</td><td>ISX_DEFAULTCOMPONENT134</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SerialComm.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\bin\be\Samraksh.AppNote.Utility.SerialComm.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser3</td><td>ISX_DEFAULTCOMPONENT134</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SerialComm.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\bin\be\Samraksh.AppNote.Utility.SerialComm.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser4</td><td>Samraksh.AppNote.Utility.SerialComm.dll1</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SerialComm.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\bin\le\Samraksh.AppNote.Utility.SerialComm.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser5</td><td>ISX_DEFAULTCOMPONENT135</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SerialComm.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\bin\le\Samraksh.AppNote.Utility.SerialComm.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser6</td><td>ISX_DEFAULTCOMPONENT135</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SerialComm.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\bin\le\Samraksh.AppNote.Utility.SerialComm.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser7</td><td>ISX_DEFAULTCOMPONENT135</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SerialComm.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\bin\le\Samraksh.AppNote.Utility.SerialComm.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser8</td><td>Samraksh.AppNote.Utility.SerialComm.dll2</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SerialComm.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\bin\Samraksh.AppNote.Utility.SerialComm.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ser9</td><td>ISX_DEFAULTCOMPONENT133</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SerialComm.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\bin\Samraksh.AppNote.Utility.SerialComm.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\be\Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim1</td><td>ISX_DEFAULTCOMPONENT80</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\be\Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim10</td><td>ISX_DEFAULTCOMPONENT79</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.SimpleCSMA.xml</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\Samraksh.AppNote.Utility.SimpleCSMA.xml</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim11</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll3</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\be\Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim12</td><td>ISX_DEFAULTCOMPONENT109</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\be\Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim13</td><td>ISX_DEFAULTCOMPONENT109</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCSMA.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\be\Samraksh.AppNote.Utility.SimpleCSMA.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim14</td><td>ISX_DEFAULTCOMPONENT109</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleCSMA.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\be\Samraksh.AppNote.Utility.SimpleCSMA.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim15</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\be\Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim16</td><td>ISX_DEFAULTCOMPONENT109</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCsmaRadio.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\be\Samraksh.AppNote.Utility.SimpleCsmaRadio.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim17</td><td>ISX_DEFAULTCOMPONENT109</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCsmaRadio.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\be\Samraksh.AppNote.Utility.SimpleCsmaRadio.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim18</td><td>ISX_DEFAULTCOMPONENT109</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleCsmaRadio.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\be\Samraksh.AppNote.Utility.SimpleCsmaRadio.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim19</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll4</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\le\Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim2</td><td>ISX_DEFAULTCOMPONENT80</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCSMA.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\be\Samraksh.AppNote.Utility.SimpleCSMA.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim20</td><td>ISX_DEFAULTCOMPONENT110</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\le\Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim21</td><td>ISX_DEFAULTCOMPONENT110</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCSMA.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\le\Samraksh.AppNote.Utility.SimpleCSMA.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim22</td><td>ISX_DEFAULTCOMPONENT110</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleCSMA.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\le\Samraksh.AppNote.Utility.SimpleCSMA.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim23</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll1</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\le\Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim24</td><td>ISX_DEFAULTCOMPONENT110</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCsmaRadio.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\le\Samraksh.AppNote.Utility.SimpleCsmaRadio.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim25</td><td>ISX_DEFAULTCOMPONENT110</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCsmaRadio.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\le\Samraksh.AppNote.Utility.SimpleCsmaRadio.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim26</td><td>ISX_DEFAULTCOMPONENT110</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleCsmaRadio.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\le\Samraksh.AppNote.Utility.SimpleCsmaRadio.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim27</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll5</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim28</td><td>ISX_DEFAULTCOMPONENT108</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim29</td><td>ISX_DEFAULTCOMPONENT108</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.SimpleCSMA.xml</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\Samraksh.AppNote.Utility.SimpleCSMA.xml</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim3</td><td>ISX_DEFAULTCOMPONENT80</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleCSMA.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\be\Samraksh.AppNote.Utility.SimpleCSMA.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim30</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll2</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim31</td><td>ISX_DEFAULTCOMPONENT108</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCsmaRadio.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\Samraksh.AppNote.Utility.SimpleCsmaRadio.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim32</td><td>ISX_DEFAULTCOMPONENT108</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.SimpleCsmaRadio.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\Samraksh.AppNote.Utility.SimpleCsmaRadio.XML</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim33</td><td>ISX_DEFAULTCOMPONENT114</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCSMA.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\be\Samraksh.AppNote.Utility.SimpleCSMA.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim34</td><td>ISX_DEFAULTCOMPONENT114</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleCSMA.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\be\Samraksh.AppNote.Utility.SimpleCSMA.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim35</td><td>ISX_DEFAULTCOMPONENT114</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCsmaRadio.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\be\Samraksh.AppNote.Utility.SimpleCsmaRadio.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim36</td><td>ISX_DEFAULTCOMPONENT114</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleCsmaRadio.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\be\Samraksh.AppNote.Utility.SimpleCsmaRadio.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim37</td><td>ISX_DEFAULTCOMPONENT115</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCSMA.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\le\Samraksh.AppNote.Utility.SimpleCSMA.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim38</td><td>ISX_DEFAULTCOMPONENT115</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleCSMA.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\le\Samraksh.AppNote.Utility.SimpleCSMA.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim39</td><td>ISX_DEFAULTCOMPONENT115</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCsmaRadio.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\le\Samraksh.AppNote.Utility.SimpleCsmaRadio.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim4</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll1</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\le\Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim40</td><td>ISX_DEFAULTCOMPONENT115</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleCsmaRadio.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\le\Samraksh.AppNote.Utility.SimpleCsmaRadio.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim41</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll6</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim42</td><td>ISX_DEFAULTCOMPONENT113</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim43</td><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll3</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim44</td><td>ISX_DEFAULTCOMPONENT113</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCsmaRadio.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\Samraksh.AppNote.Utility.SimpleCsmaRadio.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim45</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleTimer.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\bin\be\Samraksh.AppNote.Utility.SimpleTimer.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim46</td><td>ISX_DEFAULTCOMPONENT145</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleTimer.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\bin\be\Samraksh.AppNote.Utility.SimpleTimer.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim47</td><td>ISX_DEFAULTCOMPONENT145</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleTimer.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\bin\be\Samraksh.AppNote.Utility.SimpleTimer.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim48</td><td>ISX_DEFAULTCOMPONENT145</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleTimer.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\bin\be\Samraksh.AppNote.Utility.SimpleTimer.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim49</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll1</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleTimer.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\bin\le\Samraksh.AppNote.Utility.SimpleTimer.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim5</td><td>ISX_DEFAULTCOMPONENT81</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\le\Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim50</td><td>ISX_DEFAULTCOMPONENT146</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleTimer.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\bin\le\Samraksh.AppNote.Utility.SimpleTimer.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim51</td><td>ISX_DEFAULTCOMPONENT146</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleTimer.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\bin\le\Samraksh.AppNote.Utility.SimpleTimer.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim52</td><td>ISX_DEFAULTCOMPONENT146</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleTimer.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\bin\le\Samraksh.AppNote.Utility.SimpleTimer.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim53</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll2</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleTimer.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\bin\Samraksh.AppNote.Utility.SimpleTimer.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim54</td><td>ISX_DEFAULTCOMPONENT144</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleTimer.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\bin\Samraksh.AppNote.Utility.SimpleTimer.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim55</td><td>ISX_DEFAULTCOMPONENT144</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.SimpleTimer.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\bin\Samraksh.AppNote.Utility.SimpleTimer.XML</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim56</td><td>ISX_DEFAULTCOMPONENT150</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleTimer.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\obj\Debug\be\Samraksh.AppNote.Utility.SimpleTimer.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim57</td><td>ISX_DEFAULTCOMPONENT150</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleTimer.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\obj\Debug\be\Samraksh.AppNote.Utility.SimpleTimer.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim58</td><td>ISX_DEFAULTCOMPONENT151</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleTimer.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\obj\Debug\le\Samraksh.AppNote.Utility.SimpleTimer.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim59</td><td>ISX_DEFAULTCOMPONENT151</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleTimer.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\obj\Debug\le\Samraksh.AppNote.Utility.SimpleTimer.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim6</td><td>ISX_DEFAULTCOMPONENT81</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCSMA.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\le\Samraksh.AppNote.Utility.SimpleCSMA.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim60</td><td>Samraksh.AppNote.Utility.SimpleTimer.dll3</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleTimer.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\obj\Debug\Samraksh.AppNote.Utility.SimpleTimer.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim61</td><td>ISX_DEFAULTCOMPONENT149</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleTimer.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\obj\Debug\Samraksh.AppNote.Utility.SimpleTimer.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim7</td><td>ISX_DEFAULTCOMPONENT81</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.SimpleCSMA.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\le\Samraksh.AppNote.Utility.SimpleCSMA.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim8</td><td>Samraksh.AppNote.Utility.SimpleCSMA.dll2</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sim9</td><td>ISX_DEFAULTCOMPONENT79</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\Samraksh.AppNote.Utility.SimpleCSMA.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr</td><td>Samraksh.AppNote.Utility.Sqrt.dll</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.Sqrt.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\bin\be\Samraksh.AppNote.Utility.Sqrt.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr1</td><td>ISX_DEFAULTCOMPONENT156</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.Sqrt.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\bin\be\Samraksh.AppNote.Utility.Sqrt.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr10</td><td>ISX_DEFAULTCOMPONENT155</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.Sqrt.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\bin\Samraksh.AppNote.Utility.Sqrt.XML</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr11</td><td>ISX_DEFAULTCOMPONENT161</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.Sqrt.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\obj\Debug\be\Samraksh.AppNote.Utility.Sqrt.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr12</td><td>ISX_DEFAULTCOMPONENT161</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.Sqrt.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\obj\Debug\be\Samraksh.AppNote.Utility.Sqrt.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr13</td><td>ISX_DEFAULTCOMPONENT162</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.Sqrt.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\obj\Debug\le\Samraksh.AppNote.Utility.Sqrt.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr14</td><td>ISX_DEFAULTCOMPONENT162</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.Sqrt.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\obj\Debug\le\Samraksh.AppNote.Utility.Sqrt.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr15</td><td>Samraksh.AppNote.Utility.Sqrt.dll3</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.Sqrt.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\obj\Debug\Samraksh.AppNote.Utility.Sqrt.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr16</td><td>ISX_DEFAULTCOMPONENT160</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.Sqrt.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\obj\Debug\Samraksh.AppNote.Utility.Sqrt.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr2</td><td>ISX_DEFAULTCOMPONENT156</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.Sqrt.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\bin\be\Samraksh.AppNote.Utility.Sqrt.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr3</td><td>ISX_DEFAULTCOMPONENT156</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.Sqrt.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\bin\be\Samraksh.AppNote.Utility.Sqrt.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr4</td><td>Samraksh.AppNote.Utility.Sqrt.dll1</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.Sqrt.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\bin\le\Samraksh.AppNote.Utility.Sqrt.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr5</td><td>ISX_DEFAULTCOMPONENT157</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.Sqrt.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\bin\le\Samraksh.AppNote.Utility.Sqrt.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr6</td><td>ISX_DEFAULTCOMPONENT157</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.Sqrt.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\bin\le\Samraksh.AppNote.Utility.Sqrt.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr7</td><td>ISX_DEFAULTCOMPONENT157</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.Sqrt.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\bin\le\Samraksh.AppNote.Utility.Sqrt.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr8</td><td>Samraksh.AppNote.Utility.Sqrt.dll2</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.Sqrt.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\bin\Samraksh.AppNote.Utility.Sqrt.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.sqr9</td><td>ISX_DEFAULTCOMPONENT155</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.Sqrt.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\bin\Samraksh.AppNote.Utility.Sqrt.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver</td><td>ISX_DEFAULTCOMPONENT28</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\be\Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver1</td><td>ISX_DEFAULTCOMPONENT28</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.VersionInfo.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\be\Samraksh.AppNote.Utility.VersionInfo.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver10</td><td>ISX_DEFAULTCOMPONENT65</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.VersionInfo.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\le\Samraksh.AppNote.Utility.VersionInfo.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver11</td><td>Samraksh.AppNote.Utility.VersionInfo.dll1</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.VersionInfo.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\Samraksh.AppNote.Utility.VersionInfo.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver12</td><td>ISX_DEFAULTCOMPONENT63</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver13</td><td>ISX_DEFAULTCOMPONENT63</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.VersionInfo.xml</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\Samraksh.AppNote.Utility.VersionInfo.xml</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver14</td><td>Samraksh.AppNote.Utility.VersionInfo.dll2</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.VersionInfo.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\Utility Classes\VersionInfo\be\Samraksh.AppNote.Utility.VersionInfo.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver15</td><td>ISX_DEFAULTCOMPONENT76</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\Utility Classes\VersionInfo\be\Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver16</td><td>ISX_DEFAULTCOMPONENT76</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\Utility Classes\VersionInfo\be\Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver17</td><td>ISX_DEFAULTCOMPONENT76</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.VersionInfo.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\Utility Classes\VersionInfo\be\Samraksh.AppNote.Utility.VersionInfo.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver18</td><td>Samraksh.AppNote.Utility.VersionInfo.dll3</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.VersionInfo.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\Utility Classes\VersionInfo\le\Samraksh.AppNote.Utility.VersionInfo.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver19</td><td>ISX_DEFAULTCOMPONENT77</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\Utility Classes\VersionInfo\le\Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver2</td><td>ISX_DEFAULTCOMPONENT29</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\le\Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver20</td><td>ISX_DEFAULTCOMPONENT77</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\Utility Classes\VersionInfo\le\Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver21</td><td>ISX_DEFAULTCOMPONENT77</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.VersionInfo.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\Utility Classes\VersionInfo\le\Samraksh.AppNote.Utility.VersionInfo.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver22</td><td>Samraksh.AppNote.Utility.VersionInfo.dll4</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.VersionInfo.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\Utility Classes\VersionInfo\Samraksh.AppNote.Utility.VersionInfo.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver23</td><td>ISX_DEFAULTCOMPONENT75</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\Utility Classes\VersionInfo\Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver24</td><td>ISX_DEFAULTCOMPONENT75</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.VersionInfo.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\Utility Classes\VersionInfo\Samraksh.AppNote.Utility.VersionInfo.XML</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver25</td><td>Samraksh.AppNote.Utility.VersionInfo.dll5</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.VersionInfo.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\bin\be\Samraksh.AppNote.Utility.VersionInfo.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver26</td><td>ISX_DEFAULTCOMPONENT167</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\bin\be\Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver27</td><td>ISX_DEFAULTCOMPONENT167</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\bin\be\Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver28</td><td>ISX_DEFAULTCOMPONENT167</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.VersionInfo.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\bin\be\Samraksh.AppNote.Utility.VersionInfo.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver29</td><td>Samraksh.AppNote.Utility.VersionInfo.dll6</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.VersionInfo.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\bin\le\Samraksh.AppNote.Utility.VersionInfo.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver3</td><td>ISX_DEFAULTCOMPONENT29</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.VersionInfo.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\le\Samraksh.AppNote.Utility.VersionInfo.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver30</td><td>ISX_DEFAULTCOMPONENT168</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\bin\le\Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver31</td><td>ISX_DEFAULTCOMPONENT168</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\bin\le\Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver32</td><td>ISX_DEFAULTCOMPONENT168</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.VersionInfo.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\bin\le\Samraksh.AppNote.Utility.VersionInfo.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver33</td><td>Samraksh.AppNote.Utility.VersionInfo.dll7</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.VersionInfo.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\bin\Samraksh.AppNote.Utility.VersionInfo.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver34</td><td>ISX_DEFAULTCOMPONENT166</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\bin\Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver35</td><td>ISX_DEFAULTCOMPONENT166</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.VersionInfo.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\bin\Samraksh.AppNote.Utility.VersionInfo.XML</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver36</td><td>ISX_DEFAULTCOMPONENT171</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.VersionInfo.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\bin\Debug\Samraksh.AppNote.Utility.VersionInfo.XML</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver37</td><td>ISX_DEFAULTCOMPONENT174</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\obj\Debug\be\Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver38</td><td>ISX_DEFAULTCOMPONENT174</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.VersionInfo.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\obj\Debug\be\Samraksh.AppNote.Utility.VersionInfo.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver39</td><td>ISX_DEFAULTCOMPONENT175</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\obj\Debug\le\Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver4</td><td>Samraksh.AppNote.Utility.VersionInfo.dll</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.VersionInfo.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\Samraksh.AppNote.Utility.VersionInfo.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver40</td><td>ISX_DEFAULTCOMPONENT175</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.VersionInfo.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\obj\Debug\le\Samraksh.AppNote.Utility.VersionInfo.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver41</td><td>Samraksh.AppNote.Utility.VersionInfo.dll8</td><td>SAMRAK~1.DLL|Samraksh.AppNote.Utility.VersionInfo.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\obj\Debug\Samraksh.AppNote.Utility.VersionInfo.dll</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver42</td><td>ISX_DEFAULTCOMPONENT173</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\obj\Debug\Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver5</td><td>ISX_DEFAULTCOMPONENT27</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\Samraksh.AppNote.Utility.VersionInfo.pdb</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver6</td><td>ISX_DEFAULTCOMPONENT27</td><td>SAMRAK~1.XML|Samraksh.AppNote.Utility.VersionInfo.xml</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\Samraksh.AppNote.Utility.VersionInfo.xml</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver7</td><td>ISX_DEFAULTCOMPONENT64</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\be\Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver8</td><td>ISX_DEFAULTCOMPONENT64</td><td>SAMRAK~1.PE|Samraksh.AppNote.Utility.VersionInfo.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\be\Samraksh.AppNote.Utility.VersionInfo.pe</td><td>1</td><td/></row>
		<row><td>samraksh.appnote.utility.ver9</td><td>ISX_DEFAULTCOMPONENT65</td><td>SAMRAK~1.PDB|Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\le\Samraksh.AppNote.Utility.VersionInfo.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote.dll</td><td>Samraksh_eMote.dll</td><td>SAMRAK~1.DLL|Samraksh_eMote.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote\be\Samraksh_eMote.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote.dll1</td><td>Samraksh_eMote.dll1</td><td>SAMRAK~1.DLL|Samraksh_eMote.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote\le\Samraksh_eMote.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote.dll2</td><td>Samraksh_eMote.dll2</td><td>SAMRAK~1.DLL|Samraksh_eMote.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote\Samraksh_eMote.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote.dll3</td><td>Samraksh_eMote.dll3</td><td>SAMRAK~1.DLL|Samraksh_eMote.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote\be\Samraksh_eMote.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote.dll4</td><td>Samraksh_eMote.dll4</td><td>SAMRAK~1.DLL|Samraksh_eMote.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote\le\Samraksh_eMote.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote.dll5</td><td>Samraksh_eMote.dll5</td><td>SAMRAK~1.DLL|Samraksh_eMote.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote\Samraksh_eMote.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote.dll6</td><td>Samraksh_eMote.dll6</td><td>SAMRAK~1.DLL|Samraksh_eMote.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote\be\Samraksh_eMote.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote.dll7</td><td>Samraksh_eMote.dll7</td><td>SAMRAK~1.DLL|Samraksh_eMote.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote\le\Samraksh_eMote.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote.dll8</td><td>Samraksh_eMote.dll8</td><td>SAMRAK~1.DLL|Samraksh_eMote.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote\Samraksh_eMote.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdb</td><td>ISX_DEFAULTCOMPONENT4</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote\be\Samraksh_eMote.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdb1</td><td>ISX_DEFAULTCOMPONENT5</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote\le\Samraksh_eMote.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdb2</td><td>ISX_DEFAULTCOMPONENT3</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote\Samraksh_eMote.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdb3</td><td>ISX_DEFAULTCOMPONENT34</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote\be\Samraksh_eMote.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdb4</td><td>ISX_DEFAULTCOMPONENT35</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote\le\Samraksh_eMote.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdb5</td><td>ISX_DEFAULTCOMPONENT33</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote\Samraksh_eMote.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdb6</td><td>ISX_DEFAULTCOMPONENT86</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote\be\Samraksh_eMote.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdb7</td><td>ISX_DEFAULTCOMPONENT87</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote\le\Samraksh_eMote.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdb8</td><td>ISX_DEFAULTCOMPONENT85</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote\Samraksh_eMote.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdbx</td><td>ISX_DEFAULTCOMPONENT4</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote\be\Samraksh_eMote.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdbx1</td><td>ISX_DEFAULTCOMPONENT5</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote\le\Samraksh_eMote.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdbx2</td><td>ISX_DEFAULTCOMPONENT34</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote\be\Samraksh_eMote.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdbx3</td><td>ISX_DEFAULTCOMPONENT35</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote\le\Samraksh_eMote.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdbx4</td><td>ISX_DEFAULTCOMPONENT86</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote\be\Samraksh_eMote.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pdbx5</td><td>ISX_DEFAULTCOMPONENT87</td><td>SAMRAK~1.PDB|Samraksh_eMote.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote\le\Samraksh_eMote.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pe</td><td>ISX_DEFAULTCOMPONENT4</td><td>SAMRAK~1.PE|Samraksh_eMote.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote\be\Samraksh_eMote.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pe1</td><td>ISX_DEFAULTCOMPONENT5</td><td>SAMRAK~1.PE|Samraksh_eMote.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote\le\Samraksh_eMote.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pe2</td><td>ISX_DEFAULTCOMPONENT34</td><td>SAMRAK~1.PE|Samraksh_eMote.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote\be\Samraksh_eMote.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pe3</td><td>ISX_DEFAULTCOMPONENT35</td><td>SAMRAK~1.PE|Samraksh_eMote.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote\le\Samraksh_eMote.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pe4</td><td>ISX_DEFAULTCOMPONENT86</td><td>SAMRAK~1.PE|Samraksh_eMote.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote\be\Samraksh_eMote.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote.pe5</td><td>ISX_DEFAULTCOMPONENT87</td><td>SAMRAK~1.PE|Samraksh_eMote.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote\le\Samraksh_eMote.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote.xml</td><td>ISX_DEFAULTCOMPONENT3</td><td>SAMRAK~1.XML|Samraksh_eMote.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote\Samraksh_eMote.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote.xml1</td><td>ISX_DEFAULTCOMPONENT33</td><td>SAMRAK~1.XML|Samraksh_eMote.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote\Samraksh_eMote.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote.xml2</td><td>ISX_DEFAULTCOMPONENT85</td><td>SAMRAK~1.XML|Samraksh_eMote.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote\Samraksh_eMote.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.dll</td><td>Samraksh_eMote_Adapt.dll</td><td>SAMRAK~1.DLL|Samraksh_eMote_Adapt.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Adapt\be\Samraksh_eMote_Adapt.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.dll1</td><td>Samraksh_eMote_Adapt.dll1</td><td>SAMRAK~1.DLL|Samraksh_eMote_Adapt.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Adapt\le\Samraksh_eMote_Adapt.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.dll2</td><td>Samraksh_eMote_Adapt.dll2</td><td>SAMRAK~1.DLL|Samraksh_eMote_Adapt.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Adapt\Samraksh_eMote_Adapt.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.dll3</td><td>Samraksh_eMote_Adapt.dll3</td><td>SAMRAK~1.DLL|Samraksh_eMote_Adapt.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\be\Samraksh_eMote_Adapt.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.dll4</td><td>Samraksh_eMote_Adapt.dll4</td><td>SAMRAK~1.DLL|Samraksh_eMote_Adapt.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\le\Samraksh_eMote_Adapt.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.dll5</td><td>Samraksh_eMote_Adapt.dll5</td><td>SAMRAK~1.DLL|Samraksh_eMote_Adapt.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\Samraksh_eMote_Adapt.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.dll6</td><td>Samraksh_eMote_Adapt.dll6</td><td>SAMRAK~1.DLL|Samraksh_eMote_Adapt.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\be\Samraksh_eMote_Adapt.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.dll7</td><td>Samraksh_eMote_Adapt.dll7</td><td>SAMRAK~1.DLL|Samraksh_eMote_Adapt.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\le\Samraksh_eMote_Adapt.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.dll8</td><td>Samraksh_eMote_Adapt.dll8</td><td>SAMRAK~1.DLL|Samraksh_eMote_Adapt.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\Samraksh_eMote_Adapt.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdb</td><td>ISX_DEFAULTCOMPONENT7</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Adapt\be\Samraksh_eMote_Adapt.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdb1</td><td>ISX_DEFAULTCOMPONENT8</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Adapt\le\Samraksh_eMote_Adapt.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdb2</td><td>ISX_DEFAULTCOMPONENT6</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Adapt\Samraksh_eMote_Adapt.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdb3</td><td>ISX_DEFAULTCOMPONENT37</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\be\Samraksh_eMote_Adapt.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdb4</td><td>ISX_DEFAULTCOMPONENT38</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\le\Samraksh_eMote_Adapt.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdb5</td><td>ISX_DEFAULTCOMPONENT36</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\Samraksh_eMote_Adapt.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdb6</td><td>ISX_DEFAULTCOMPONENT89</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\be\Samraksh_eMote_Adapt.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdb7</td><td>ISX_DEFAULTCOMPONENT90</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\le\Samraksh_eMote_Adapt.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdb8</td><td>ISX_DEFAULTCOMPONENT88</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\Samraksh_eMote_Adapt.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdbx</td><td>ISX_DEFAULTCOMPONENT7</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Adapt\be\Samraksh_eMote_Adapt.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdbx1</td><td>ISX_DEFAULTCOMPONENT8</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Adapt\le\Samraksh_eMote_Adapt.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdbx2</td><td>ISX_DEFAULTCOMPONENT37</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\be\Samraksh_eMote_Adapt.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdbx3</td><td>ISX_DEFAULTCOMPONENT38</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\le\Samraksh_eMote_Adapt.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdbx4</td><td>ISX_DEFAULTCOMPONENT89</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\be\Samraksh_eMote_Adapt.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pdbx5</td><td>ISX_DEFAULTCOMPONENT90</td><td>SAMRAK~1.PDB|Samraksh_eMote_Adapt.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\le\Samraksh_eMote_Adapt.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pe</td><td>ISX_DEFAULTCOMPONENT7</td><td>SAMRAK~1.PE|Samraksh_eMote_Adapt.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Adapt\be\Samraksh_eMote_Adapt.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pe1</td><td>ISX_DEFAULTCOMPONENT8</td><td>SAMRAK~1.PE|Samraksh_eMote_Adapt.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Adapt\le\Samraksh_eMote_Adapt.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pe2</td><td>ISX_DEFAULTCOMPONENT37</td><td>SAMRAK~1.PE|Samraksh_eMote_Adapt.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\be\Samraksh_eMote_Adapt.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pe3</td><td>ISX_DEFAULTCOMPONENT38</td><td>SAMRAK~1.PE|Samraksh_eMote_Adapt.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\le\Samraksh_eMote_Adapt.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pe4</td><td>ISX_DEFAULTCOMPONENT89</td><td>SAMRAK~1.PE|Samraksh_eMote_Adapt.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\be\Samraksh_eMote_Adapt.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.pe5</td><td>ISX_DEFAULTCOMPONENT90</td><td>SAMRAK~1.PE|Samraksh_eMote_Adapt.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\le\Samraksh_eMote_Adapt.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.xml</td><td>ISX_DEFAULTCOMPONENT6</td><td>SAMRAK~1.XML|Samraksh_eMote_Adapt.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Adapt\Samraksh_eMote_Adapt.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.xml1</td><td>ISX_DEFAULTCOMPONENT36</td><td>SAMRAK~1.XML|Samraksh_eMote_Adapt.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\Samraksh_eMote_Adapt.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_adapt.xml2</td><td>ISX_DEFAULTCOMPONENT88</td><td>SAMRAK~1.XML|Samraksh_eMote_Adapt.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Adapt\Samraksh_eMote_Adapt.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.dll</td><td>Samraksh_eMote_DotNow.dll</td><td>SAMRAK~1.DLL|Samraksh_eMote_DotNow.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DotNow\be\Samraksh_eMote_DotNow.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.dll1</td><td>Samraksh_eMote_DotNow.dll1</td><td>SAMRAK~1.DLL|Samraksh_eMote_DotNow.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DotNow\le\Samraksh_eMote_DotNow.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.dll10</td><td>Samraksh_eMote_DotNow.dll10</td><td>SAMRAK~1.DLL|Samraksh_eMote_DotNow.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\Samraksh_eMote_DotNow.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.dll2</td><td>Samraksh_eMote_DotNow.dll2</td><td>SAMRAK~1.DLL|Samraksh_eMote_DotNow.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DotNow\Samraksh_eMote_DotNow.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.dll3</td><td>Samraksh_eMote_DotNow.dll3</td><td>SAMRAK~1.DLL|Samraksh_eMote_DotNow.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\Samraksh_eMote_DotNow.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.dll4</td><td>Samraksh_eMote_DotNow.dll4</td><td>SAMRAK~1.DLL|Samraksh_eMote_DotNow.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\be\Samraksh_eMote_DotNow.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.dll5</td><td>Samraksh_eMote_DotNow.dll5</td><td>SAMRAK~1.DLL|Samraksh_eMote_DotNow.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\le\Samraksh_eMote_DotNow.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.dll6</td><td>Samraksh_eMote_DotNow.dll6</td><td>SAMRAK~1.DLL|Samraksh_eMote_DotNow.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\Samraksh_eMote_DotNow.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.dll7</td><td>Samraksh_eMote_DotNow.dll7</td><td>SAMRAK~1.DLL|Samraksh_eMote_DotNow.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\Samraksh_eMote_DotNow.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.dll8</td><td>Samraksh_eMote_DotNow.dll8</td><td>SAMRAK~1.DLL|Samraksh_eMote_DotNow.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\be\Samraksh_eMote_DotNow.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.dll9</td><td>Samraksh_eMote_DotNow.dll9</td><td>SAMRAK~1.DLL|Samraksh_eMote_DotNow.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\le\Samraksh_eMote_DotNow.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdb</td><td>ISX_DEFAULTCOMPONENT10</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DotNow\be\Samraksh_eMote_DotNow.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdb1</td><td>ISX_DEFAULTCOMPONENT11</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DotNow\le\Samraksh_eMote_DotNow.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdb10</td><td>ISX_DEFAULTCOMPONENT91</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\Samraksh_eMote_DotNow.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdb2</td><td>ISX_DEFAULTCOMPONENT9</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DotNow\Samraksh_eMote_DotNow.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdb3</td><td>ISX_DEFAULTCOMPONENT27</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\Samraksh_eMote_DotNow.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdb4</td><td>ISX_DEFAULTCOMPONENT40</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\be\Samraksh_eMote_DotNow.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdb5</td><td>ISX_DEFAULTCOMPONENT41</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\le\Samraksh_eMote_DotNow.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdb6</td><td>ISX_DEFAULTCOMPONENT39</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\Samraksh_eMote_DotNow.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdb7</td><td>ISX_DEFAULTCOMPONENT63</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\Samraksh_eMote_DotNow.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdb8</td><td>ISX_DEFAULTCOMPONENT92</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\be\Samraksh_eMote_DotNow.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdb9</td><td>ISX_DEFAULTCOMPONENT93</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\le\Samraksh_eMote_DotNow.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdbx</td><td>ISX_DEFAULTCOMPONENT10</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DotNow\be\Samraksh_eMote_DotNow.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdbx1</td><td>ISX_DEFAULTCOMPONENT11</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DotNow\le\Samraksh_eMote_DotNow.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdbx2</td><td>ISX_DEFAULTCOMPONENT28</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\be\Samraksh_eMote_DotNow.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdbx3</td><td>ISX_DEFAULTCOMPONENT29</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\le\Samraksh_eMote_DotNow.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdbx4</td><td>ISX_DEFAULTCOMPONENT40</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\be\Samraksh_eMote_DotNow.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdbx5</td><td>ISX_DEFAULTCOMPONENT41</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\le\Samraksh_eMote_DotNow.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdbx6</td><td>ISX_DEFAULTCOMPONENT64</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\be\Samraksh_eMote_DotNow.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdbx7</td><td>ISX_DEFAULTCOMPONENT65</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\le\Samraksh_eMote_DotNow.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdbx8</td><td>ISX_DEFAULTCOMPONENT92</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\be\Samraksh_eMote_DotNow.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pdbx9</td><td>ISX_DEFAULTCOMPONENT93</td><td>SAMRAK~1.PDB|Samraksh_eMote_DotNow.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\le\Samraksh_eMote_DotNow.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pe</td><td>ISX_DEFAULTCOMPONENT10</td><td>SAMRAK~1.PE|Samraksh_eMote_DotNow.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DotNow\be\Samraksh_eMote_DotNow.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pe1</td><td>ISX_DEFAULTCOMPONENT11</td><td>SAMRAK~1.PE|Samraksh_eMote_DotNow.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DotNow\le\Samraksh_eMote_DotNow.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pe2</td><td>ISX_DEFAULTCOMPONENT28</td><td>SAMRAK~1.PE|Samraksh_eMote_DotNow.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\be\Samraksh_eMote_DotNow.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pe3</td><td>ISX_DEFAULTCOMPONENT29</td><td>SAMRAK~1.PE|Samraksh_eMote_DotNow.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\le\Samraksh_eMote_DotNow.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pe4</td><td>ISX_DEFAULTCOMPONENT40</td><td>SAMRAK~1.PE|Samraksh_eMote_DotNow.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\be\Samraksh_eMote_DotNow.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pe5</td><td>ISX_DEFAULTCOMPONENT41</td><td>SAMRAK~1.PE|Samraksh_eMote_DotNow.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\le\Samraksh_eMote_DotNow.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pe6</td><td>ISX_DEFAULTCOMPONENT64</td><td>SAMRAK~1.PE|Samraksh_eMote_DotNow.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\be\Samraksh_eMote_DotNow.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pe7</td><td>ISX_DEFAULTCOMPONENT65</td><td>SAMRAK~1.PE|Samraksh_eMote_DotNow.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\le\Samraksh_eMote_DotNow.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pe8</td><td>ISX_DEFAULTCOMPONENT92</td><td>SAMRAK~1.PE|Samraksh_eMote_DotNow.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\be\Samraksh_eMote_DotNow.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.pe9</td><td>ISX_DEFAULTCOMPONENT93</td><td>SAMRAK~1.PE|Samraksh_eMote_DotNow.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\le\Samraksh_eMote_DotNow.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.xml</td><td>ISX_DEFAULTCOMPONENT9</td><td>SAMRAK~1.XML|Samraksh_eMote_DotNow.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DotNow\Samraksh_eMote_DotNow.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.xml1</td><td>ISX_DEFAULTCOMPONENT27</td><td>SAMRAK~1.XML|Samraksh_eMote_DotNow.xml</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\Samraksh_eMote_DotNow.xml</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.xml2</td><td>ISX_DEFAULTCOMPONENT39</td><td>SAMRAK~1.XML|Samraksh_eMote_DotNow.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\Samraksh_eMote_DotNow.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.xml3</td><td>ISX_DEFAULTCOMPONENT63</td><td>SAMRAK~1.XML|Samraksh_eMote_DotNow.xml</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\Samraksh_eMote_DotNow.xml</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dotnow.xml4</td><td>ISX_DEFAULTCOMPONENT91</td><td>SAMRAK~1.XML|Samraksh_eMote_DotNow.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DotNow\Samraksh_eMote_DotNow.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.dll</td><td>Samraksh_eMote_DSP.dll</td><td>SAMRAK~1.DLL|Samraksh_eMote_DSP.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DSP\be\Samraksh_eMote_DSP.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.dll1</td><td>Samraksh_eMote_DSP.dll1</td><td>SAMRAK~1.DLL|Samraksh_eMote_DSP.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DSP\le\Samraksh_eMote_DSP.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.dll2</td><td>Samraksh_eMote_DSP.dll2</td><td>SAMRAK~1.DLL|Samraksh_eMote_DSP.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DSP\Samraksh_eMote_DSP.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.dll3</td><td>Samraksh_eMote_DSP.dll3</td><td>SAMRAK~1.DLL|Samraksh_eMote_DSP.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\be\Samraksh_eMote_DSP.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.dll4</td><td>Samraksh_eMote_DSP.dll4</td><td>SAMRAK~1.DLL|Samraksh_eMote_DSP.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\le\Samraksh_eMote_DSP.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.dll5</td><td>Samraksh_eMote_DSP.dll5</td><td>SAMRAK~1.DLL|Samraksh_eMote_DSP.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\Samraksh_eMote_DSP.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.dll6</td><td>Samraksh_eMote_DSP.dll6</td><td>SAMRAK~1.DLL|Samraksh_eMote_DSP.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\be\Samraksh_eMote_DSP.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.dll7</td><td>Samraksh_eMote_DSP.dll7</td><td>SAMRAK~1.DLL|Samraksh_eMote_DSP.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\le\Samraksh_eMote_DSP.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.dll8</td><td>Samraksh_eMote_DSP.dll8</td><td>SAMRAK~1.DLL|Samraksh_eMote_DSP.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\Samraksh_eMote_DSP.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdb</td><td>ISX_DEFAULTCOMPONENT13</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DSP\be\Samraksh_eMote_DSP.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdb1</td><td>ISX_DEFAULTCOMPONENT14</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DSP\le\Samraksh_eMote_DSP.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdb2</td><td>ISX_DEFAULTCOMPONENT12</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DSP\Samraksh_eMote_DSP.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdb3</td><td>ISX_DEFAULTCOMPONENT43</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\be\Samraksh_eMote_DSP.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdb4</td><td>ISX_DEFAULTCOMPONENT44</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\le\Samraksh_eMote_DSP.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdb5</td><td>ISX_DEFAULTCOMPONENT42</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\Samraksh_eMote_DSP.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdb6</td><td>ISX_DEFAULTCOMPONENT95</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\be\Samraksh_eMote_DSP.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdb7</td><td>ISX_DEFAULTCOMPONENT96</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\le\Samraksh_eMote_DSP.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdb8</td><td>ISX_DEFAULTCOMPONENT94</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\Samraksh_eMote_DSP.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdbx</td><td>ISX_DEFAULTCOMPONENT13</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DSP\be\Samraksh_eMote_DSP.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdbx1</td><td>ISX_DEFAULTCOMPONENT14</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DSP\le\Samraksh_eMote_DSP.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdbx2</td><td>ISX_DEFAULTCOMPONENT43</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\be\Samraksh_eMote_DSP.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdbx3</td><td>ISX_DEFAULTCOMPONENT44</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\le\Samraksh_eMote_DSP.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdbx4</td><td>ISX_DEFAULTCOMPONENT95</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\be\Samraksh_eMote_DSP.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pdbx5</td><td>ISX_DEFAULTCOMPONENT96</td><td>SAMRAK~1.PDB|Samraksh_eMote_DSP.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\le\Samraksh_eMote_DSP.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pe</td><td>ISX_DEFAULTCOMPONENT13</td><td>SAMRAK~1.PE|Samraksh_eMote_DSP.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DSP\be\Samraksh_eMote_DSP.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pe1</td><td>ISX_DEFAULTCOMPONENT14</td><td>SAMRAK~1.PE|Samraksh_eMote_DSP.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DSP\le\Samraksh_eMote_DSP.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pe2</td><td>ISX_DEFAULTCOMPONENT43</td><td>SAMRAK~1.PE|Samraksh_eMote_DSP.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\be\Samraksh_eMote_DSP.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pe3</td><td>ISX_DEFAULTCOMPONENT44</td><td>SAMRAK~1.PE|Samraksh_eMote_DSP.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\le\Samraksh_eMote_DSP.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pe4</td><td>ISX_DEFAULTCOMPONENT95</td><td>SAMRAK~1.PE|Samraksh_eMote_DSP.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\be\Samraksh_eMote_DSP.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.pe5</td><td>ISX_DEFAULTCOMPONENT96</td><td>SAMRAK~1.PE|Samraksh_eMote_DSP.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\le\Samraksh_eMote_DSP.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.xml</td><td>ISX_DEFAULTCOMPONENT12</td><td>SAMRAK~1.XML|Samraksh_eMote_DSP.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_DSP\Samraksh_eMote_DSP.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.xml1</td><td>ISX_DEFAULTCOMPONENT42</td><td>SAMRAK~1.XML|Samraksh_eMote_DSP.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\Samraksh_eMote_DSP.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_dsp.xml2</td><td>ISX_DEFAULTCOMPONENT94</td><td>SAMRAK~1.XML|Samraksh_eMote_DSP.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_DSP\Samraksh_eMote_DSP.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.dll</td><td>Samraksh_eMote_Kiwi.dll</td><td>SAMRAK~1.DLL|Samraksh_eMote_Kiwi.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Kiwi\be\Samraksh_eMote_Kiwi.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.dll1</td><td>Samraksh_eMote_Kiwi.dll1</td><td>SAMRAK~1.DLL|Samraksh_eMote_Kiwi.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Kiwi\le\Samraksh_eMote_Kiwi.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.dll2</td><td>Samraksh_eMote_Kiwi.dll2</td><td>SAMRAK~1.DLL|Samraksh_eMote_Kiwi.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Kiwi\Samraksh_eMote_Kiwi.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.dll3</td><td>Samraksh_eMote_Kiwi.dll3</td><td>SAMRAK~1.DLL|Samraksh_eMote_Kiwi.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\be\Samraksh_eMote_Kiwi.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.dll4</td><td>Samraksh_eMote_Kiwi.dll4</td><td>SAMRAK~1.DLL|Samraksh_eMote_Kiwi.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\le\Samraksh_eMote_Kiwi.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.dll5</td><td>Samraksh_eMote_Kiwi.dll5</td><td>SAMRAK~1.DLL|Samraksh_eMote_Kiwi.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\Samraksh_eMote_Kiwi.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.dll6</td><td>Samraksh_eMote_Kiwi.dll6</td><td>SAMRAK~1.DLL|Samraksh_eMote_Kiwi.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\be\Samraksh_eMote_Kiwi.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.dll7</td><td>Samraksh_eMote_Kiwi.dll7</td><td>SAMRAK~1.DLL|Samraksh_eMote_Kiwi.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\le\Samraksh_eMote_Kiwi.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.dll8</td><td>Samraksh_eMote_Kiwi.dll8</td><td>SAMRAK~1.DLL|Samraksh_eMote_Kiwi.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\Samraksh_eMote_Kiwi.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdb</td><td>ISX_DEFAULTCOMPONENT16</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Kiwi\be\Samraksh_eMote_Kiwi.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdb1</td><td>ISX_DEFAULTCOMPONENT17</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Kiwi\le\Samraksh_eMote_Kiwi.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdb2</td><td>ISX_DEFAULTCOMPONENT15</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Kiwi\Samraksh_eMote_Kiwi.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdb3</td><td>ISX_DEFAULTCOMPONENT46</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\be\Samraksh_eMote_Kiwi.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdb4</td><td>ISX_DEFAULTCOMPONENT47</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\le\Samraksh_eMote_Kiwi.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdb5</td><td>ISX_DEFAULTCOMPONENT45</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\Samraksh_eMote_Kiwi.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdb6</td><td>ISX_DEFAULTCOMPONENT98</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\be\Samraksh_eMote_Kiwi.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdb7</td><td>ISX_DEFAULTCOMPONENT99</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\le\Samraksh_eMote_Kiwi.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdb8</td><td>ISX_DEFAULTCOMPONENT97</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\Samraksh_eMote_Kiwi.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdbx</td><td>ISX_DEFAULTCOMPONENT16</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Kiwi\be\Samraksh_eMote_Kiwi.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdbx1</td><td>ISX_DEFAULTCOMPONENT17</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Kiwi\le\Samraksh_eMote_Kiwi.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdbx2</td><td>ISX_DEFAULTCOMPONENT46</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\be\Samraksh_eMote_Kiwi.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdbx3</td><td>ISX_DEFAULTCOMPONENT47</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\le\Samraksh_eMote_Kiwi.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdbx4</td><td>ISX_DEFAULTCOMPONENT98</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\be\Samraksh_eMote_Kiwi.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pdbx5</td><td>ISX_DEFAULTCOMPONENT99</td><td>SAMRAK~1.PDB|Samraksh_eMote_Kiwi.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\le\Samraksh_eMote_Kiwi.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pe</td><td>ISX_DEFAULTCOMPONENT16</td><td>SAMRAK~1.PE|Samraksh_eMote_Kiwi.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Kiwi\be\Samraksh_eMote_Kiwi.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pe1</td><td>ISX_DEFAULTCOMPONENT17</td><td>SAMRAK~1.PE|Samraksh_eMote_Kiwi.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Kiwi\le\Samraksh_eMote_Kiwi.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pe2</td><td>ISX_DEFAULTCOMPONENT46</td><td>SAMRAK~1.PE|Samraksh_eMote_Kiwi.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\be\Samraksh_eMote_Kiwi.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pe3</td><td>ISX_DEFAULTCOMPONENT47</td><td>SAMRAK~1.PE|Samraksh_eMote_Kiwi.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\le\Samraksh_eMote_Kiwi.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pe4</td><td>ISX_DEFAULTCOMPONENT98</td><td>SAMRAK~1.PE|Samraksh_eMote_Kiwi.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\be\Samraksh_eMote_Kiwi.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.pe5</td><td>ISX_DEFAULTCOMPONENT99</td><td>SAMRAK~1.PE|Samraksh_eMote_Kiwi.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\le\Samraksh_eMote_Kiwi.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.xml</td><td>ISX_DEFAULTCOMPONENT15</td><td>SAMRAK~1.XML|Samraksh_eMote_Kiwi.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Kiwi\Samraksh_eMote_Kiwi.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.xml1</td><td>ISX_DEFAULTCOMPONENT45</td><td>SAMRAK~1.XML|Samraksh_eMote_Kiwi.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\Samraksh_eMote_Kiwi.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_kiwi.xml2</td><td>ISX_DEFAULTCOMPONENT97</td><td>SAMRAK~1.XML|Samraksh_eMote_Kiwi.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Kiwi\Samraksh_eMote_Kiwi.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.dll</td><td>Samraksh_eMote_Net.dll</td><td>SAMRAK~1.DLL|Samraksh_eMote_Net.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Net\be\Samraksh_eMote_Net.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.dll1</td><td>Samraksh_eMote_Net.dll1</td><td>SAMRAK~1.DLL|Samraksh_eMote_Net.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Net\le\Samraksh_eMote_Net.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.dll10</td><td>Samraksh_eMote_Net.dll10</td><td>SAMRAK~1.DLL|Samraksh_eMote_Net.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\Samraksh_eMote_Net.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.dll2</td><td>Samraksh_eMote_Net.dll2</td><td>SAMRAK~1.DLL|Samraksh_eMote_Net.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Net\Samraksh_eMote_Net.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.dll3</td><td>Samraksh_eMote_Net.dll3</td><td>SAMRAK~1.DLL|Samraksh_eMote_Net.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\be\Samraksh_eMote_Net.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.dll4</td><td>Samraksh_eMote_Net.dll4</td><td>SAMRAK~1.DLL|Samraksh_eMote_Net.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\le\Samraksh_eMote_Net.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.dll5</td><td>Samraksh_eMote_Net.dll5</td><td>SAMRAK~1.DLL|Samraksh_eMote_Net.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\Samraksh_eMote_Net.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.dll6</td><td>Samraksh_eMote_Net.dll6</td><td>SAMRAK~1.DLL|Samraksh_eMote_Net.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\Samraksh_eMote_Net.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.dll7</td><td>Samraksh_eMote_Net.dll7</td><td>SAMRAK~1.DLL|Samraksh_eMote_Net.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\be\Samraksh_eMote_Net.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.dll8</td><td>Samraksh_eMote_Net.dll8</td><td>SAMRAK~1.DLL|Samraksh_eMote_Net.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\le\Samraksh_eMote_Net.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.dll9</td><td>Samraksh_eMote_Net.dll9</td><td>SAMRAK~1.DLL|Samraksh_eMote_Net.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\Samraksh_eMote_Net.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdb</td><td>ISX_DEFAULTCOMPONENT19</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Net\be\Samraksh_eMote_Net.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdb1</td><td>ISX_DEFAULTCOMPONENT20</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Net\le\Samraksh_eMote_Net.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdb10</td><td>ISX_DEFAULTCOMPONENT108</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\Samraksh_eMote_Net.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdb2</td><td>ISX_DEFAULTCOMPONENT18</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Net\Samraksh_eMote_Net.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdb3</td><td>ISX_DEFAULTCOMPONENT49</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\be\Samraksh_eMote_Net.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdb4</td><td>ISX_DEFAULTCOMPONENT50</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\le\Samraksh_eMote_Net.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdb5</td><td>ISX_DEFAULTCOMPONENT48</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\Samraksh_eMote_Net.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdb6</td><td>ISX_DEFAULTCOMPONENT79</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\Samraksh_eMote_Net.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdb7</td><td>ISX_DEFAULTCOMPONENT101</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\be\Samraksh_eMote_Net.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdb8</td><td>ISX_DEFAULTCOMPONENT102</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\le\Samraksh_eMote_Net.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdb9</td><td>ISX_DEFAULTCOMPONENT100</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\Samraksh_eMote_Net.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdbx</td><td>ISX_DEFAULTCOMPONENT19</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Net\be\Samraksh_eMote_Net.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdbx1</td><td>ISX_DEFAULTCOMPONENT20</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Net\le\Samraksh_eMote_Net.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdbx2</td><td>ISX_DEFAULTCOMPONENT49</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\be\Samraksh_eMote_Net.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdbx3</td><td>ISX_DEFAULTCOMPONENT50</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\le\Samraksh_eMote_Net.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdbx4</td><td>ISX_DEFAULTCOMPONENT80</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\be\Samraksh_eMote_Net.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdbx5</td><td>ISX_DEFAULTCOMPONENT81</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\le\Samraksh_eMote_Net.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdbx6</td><td>ISX_DEFAULTCOMPONENT101</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\be\Samraksh_eMote_Net.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdbx7</td><td>ISX_DEFAULTCOMPONENT102</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\le\Samraksh_eMote_Net.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdbx8</td><td>ISX_DEFAULTCOMPONENT109</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\be\Samraksh_eMote_Net.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pdbx9</td><td>ISX_DEFAULTCOMPONENT110</td><td>SAMRAK~1.PDB|Samraksh_eMote_Net.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\le\Samraksh_eMote_Net.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pe</td><td>ISX_DEFAULTCOMPONENT19</td><td>SAMRAK~1.PE|Samraksh_eMote_Net.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Net\be\Samraksh_eMote_Net.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pe1</td><td>ISX_DEFAULTCOMPONENT20</td><td>SAMRAK~1.PE|Samraksh_eMote_Net.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Net\le\Samraksh_eMote_Net.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pe2</td><td>ISX_DEFAULTCOMPONENT49</td><td>SAMRAK~1.PE|Samraksh_eMote_Net.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\be\Samraksh_eMote_Net.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pe3</td><td>ISX_DEFAULTCOMPONENT50</td><td>SAMRAK~1.PE|Samraksh_eMote_Net.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\le\Samraksh_eMote_Net.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pe4</td><td>ISX_DEFAULTCOMPONENT80</td><td>SAMRAK~1.PE|Samraksh_eMote_Net.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\be\Samraksh_eMote_Net.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pe5</td><td>ISX_DEFAULTCOMPONENT81</td><td>SAMRAK~1.PE|Samraksh_eMote_Net.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\le\Samraksh_eMote_Net.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pe6</td><td>ISX_DEFAULTCOMPONENT101</td><td>SAMRAK~1.PE|Samraksh_eMote_Net.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\be\Samraksh_eMote_Net.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pe7</td><td>ISX_DEFAULTCOMPONENT102</td><td>SAMRAK~1.PE|Samraksh_eMote_Net.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\le\Samraksh_eMote_Net.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pe8</td><td>ISX_DEFAULTCOMPONENT109</td><td>SAMRAK~1.PE|Samraksh_eMote_Net.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\be\Samraksh_eMote_Net.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.pe9</td><td>ISX_DEFAULTCOMPONENT110</td><td>SAMRAK~1.PE|Samraksh_eMote_Net.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\le\Samraksh_eMote_Net.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.xml</td><td>ISX_DEFAULTCOMPONENT18</td><td>SAMRAK~1.XML|Samraksh_eMote_Net.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_Net\Samraksh_eMote_Net.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.xml1</td><td>ISX_DEFAULTCOMPONENT48</td><td>SAMRAK~1.XML|Samraksh_eMote_Net.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\Samraksh_eMote_Net.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.xml2</td><td>ISX_DEFAULTCOMPONENT79</td><td>SAMRAK~1.XML|Samraksh_eMote_Net.xml</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\bin\Samraksh_eMote_Net.xml</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.xml3</td><td>ISX_DEFAULTCOMPONENT100</td><td>SAMRAK~1.XML|Samraksh_eMote_Net.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_Net\Samraksh_eMote_Net.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_net.xml4</td><td>ISX_DEFAULTCOMPONENT108</td><td>SAMRAK~1.XML|Samraksh_eMote_Net.xml</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\bin\Debug\Samraksh_eMote_Net.xml</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.dll</td><td>Samraksh_eMote_RealTime.dll</td><td>SAMRAK~1.DLL|Samraksh_eMote_RealTime.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_RealTime\be\Samraksh_eMote_RealTime.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.dll1</td><td>Samraksh_eMote_RealTime.dll1</td><td>SAMRAK~1.DLL|Samraksh_eMote_RealTime.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_RealTime\le\Samraksh_eMote_RealTime.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.dll2</td><td>Samraksh_eMote_RealTime.dll2</td><td>SAMRAK~1.DLL|Samraksh_eMote_RealTime.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_RealTime\Samraksh_eMote_RealTime.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.dll3</td><td>Samraksh_eMote_RealTime.dll3</td><td>SAMRAK~1.DLL|Samraksh_eMote_RealTime.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\be\Samraksh_eMote_RealTime.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.dll4</td><td>Samraksh_eMote_RealTime.dll4</td><td>SAMRAK~1.DLL|Samraksh_eMote_RealTime.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\le\Samraksh_eMote_RealTime.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.dll5</td><td>Samraksh_eMote_RealTime.dll5</td><td>SAMRAK~1.DLL|Samraksh_eMote_RealTime.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\Samraksh_eMote_RealTime.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.dll6</td><td>Samraksh_eMote_RealTime.dll6</td><td>SAMRAK~1.DLL|Samraksh_eMote_RealTime.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\be\Samraksh_eMote_RealTime.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.dll7</td><td>Samraksh_eMote_RealTime.dll7</td><td>SAMRAK~1.DLL|Samraksh_eMote_RealTime.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\le\Samraksh_eMote_RealTime.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.dll8</td><td>Samraksh_eMote_RealTime.dll8</td><td>SAMRAK~1.DLL|Samraksh_eMote_RealTime.dll</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\Samraksh_eMote_RealTime.dll</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdb</td><td>ISX_DEFAULTCOMPONENT22</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_RealTime\be\Samraksh_eMote_RealTime.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdb1</td><td>ISX_DEFAULTCOMPONENT23</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_RealTime\le\Samraksh_eMote_RealTime.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdb2</td><td>ISX_DEFAULTCOMPONENT21</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_RealTime\Samraksh_eMote_RealTime.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdb3</td><td>ISX_DEFAULTCOMPONENT52</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\be\Samraksh_eMote_RealTime.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdb4</td><td>ISX_DEFAULTCOMPONENT53</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\le\Samraksh_eMote_RealTime.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdb5</td><td>ISX_DEFAULTCOMPONENT51</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\Samraksh_eMote_RealTime.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdb6</td><td>ISX_DEFAULTCOMPONENT104</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\be\Samraksh_eMote_RealTime.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdb7</td><td>ISX_DEFAULTCOMPONENT105</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\le\Samraksh_eMote_RealTime.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdb8</td><td>ISX_DEFAULTCOMPONENT103</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\Samraksh_eMote_RealTime.pdb</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdbx</td><td>ISX_DEFAULTCOMPONENT22</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_RealTime\be\Samraksh_eMote_RealTime.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdbx1</td><td>ISX_DEFAULTCOMPONENT23</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_RealTime\le\Samraksh_eMote_RealTime.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdbx2</td><td>ISX_DEFAULTCOMPONENT52</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\be\Samraksh_eMote_RealTime.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdbx3</td><td>ISX_DEFAULTCOMPONENT53</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\le\Samraksh_eMote_RealTime.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdbx4</td><td>ISX_DEFAULTCOMPONENT104</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\be\Samraksh_eMote_RealTime.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pdbx5</td><td>ISX_DEFAULTCOMPONENT105</td><td>SAMRAK~1.PDB|Samraksh_eMote_RealTime.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\le\Samraksh_eMote_RealTime.pdbx</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pe</td><td>ISX_DEFAULTCOMPONENT22</td><td>SAMRAK~1.PE|Samraksh_eMote_RealTime.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_RealTime\be\Samraksh_eMote_RealTime.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pe1</td><td>ISX_DEFAULTCOMPONENT23</td><td>SAMRAK~1.PE|Samraksh_eMote_RealTime.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_RealTime\le\Samraksh_eMote_RealTime.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pe2</td><td>ISX_DEFAULTCOMPONENT52</td><td>SAMRAK~1.PE|Samraksh_eMote_RealTime.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\be\Samraksh_eMote_RealTime.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pe3</td><td>ISX_DEFAULTCOMPONENT53</td><td>SAMRAK~1.PE|Samraksh_eMote_RealTime.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\le\Samraksh_eMote_RealTime.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pe4</td><td>ISX_DEFAULTCOMPONENT104</td><td>SAMRAK~1.PE|Samraksh_eMote_RealTime.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\be\Samraksh_eMote_RealTime.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.pe5</td><td>ISX_DEFAULTCOMPONENT105</td><td>SAMRAK~1.PE|Samraksh_eMote_RealTime.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\le\Samraksh_eMote_RealTime.pe</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.xml</td><td>ISX_DEFAULTCOMPONENT21</td><td>SAMRAK~1.XML|Samraksh_eMote_RealTime.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\eMote .NOW\Samraksh_eMote_RealTime\Samraksh_eMote_RealTime.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.xml1</td><td>ISX_DEFAULTCOMPONENT51</td><td>SAMRAK~1.XML|Samraksh_eMote_RealTime.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\Samraksh_eMote_RealTime.XML</td><td>1</td><td/></row>
		<row><td>samraksh_emote_realtime.xml2</td><td>ISX_DEFAULTCOMPONENT103</td><td>SAMRAK~1.XML|Samraksh_eMote_RealTime.XML</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\eMote .NOW Release 4.3.0.14\Samraksh_eMote_RealTime\Samraksh_eMote_RealTime.XML</td><td>1</td><td/></row>
		<row><td>serialcomm.cs</td><td>ISX_DEFAULTCOMPONENT136</td><td>SERIAL~1.CS|SerialComm.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\SerialComm.cs</td><td>1</td><td/></row>
		<row><td>serialcomm.csproj</td><td>ISX_DEFAULTCOMPONENT136</td><td>SERIAL~1.CSP|SerialComm.csproj</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\SerialComm.csproj</td><td>1</td><td/></row>
		<row><td>serialcomm.csproj.filelistab</td><td>ISX_DEFAULTCOMPONENT138</td><td>SERIAL~1.TXT|SerialComm.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\obj\Debug\SerialComm.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>serialcomm.csprojresolveasse</td><td>ISX_DEFAULTCOMPONENT138</td><td>SERIAL~1.CAC|SerialComm.csprojResolveAssemblyReference.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\obj\Debug\SerialComm.csprojResolveAssemblyReference.cache</td><td>1</td><td/></row>
		<row><td>serialcomm_1.2.sln</td><td>ISX_DEFAULTCOMPONENT132</td><td>SERIAL~1.SLN|SerialComm 1.2.sln</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm 1.2.sln</td><td>1</td><td/></row>
		<row><td>serialcomm_1.2.v12.suo</td><td>ISX_DEFAULTCOMPONENT132</td><td>SERIAL~1.SUO|SerialComm 1.2.v12.suo</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm 1.2.v12.suo</td><td>1</td><td/></row>
		<row><td>simplecsma.cs</td><td>ISX_DEFAULTCOMPONENT106</td><td>SIMPLE~1.CS|SimpleCSMA.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\SimpleCSMA.cs</td><td>1</td><td/></row>
		<row><td>simplecsma.csproj.filelistab</td><td>ISX_DEFAULTCOMPONENT113</td><td>SIMPLE~1.TXT|SimpleCSMA.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\SimpleCSMA.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>simplecsma.csprojresolveasse</td><td>ISX_DEFAULTCOMPONENT113</td><td>SIMPLE~1.CAC|SimpleCSMA.csprojResolveAssemblyReference.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\SimpleCSMA.csprojResolveAssemblyReference.cache</td><td>1</td><td/></row>
		<row><td>simplecsma_1.6.sln</td><td>ISX_DEFAULTCOMPONENT78</td><td>SIMPLE~1.SLN|SimpleCSMA 1.6.sln</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA 1.6.sln</td><td>1</td><td/></row>
		<row><td>simplecsma_1.6.sln.dotsettin</td><td>ISX_DEFAULTCOMPONENT78</td><td>SIMPLE~1.DOT|SimpleCSMA 1.6.sln.DotSettings</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA 1.6.sln.DotSettings</td><td>1</td><td/></row>
		<row><td>simplecsma_1.6.v12.suo</td><td>ISX_DEFAULTCOMPONENT78</td><td>SIMPLE~1.SUO|SimpleCSMA 1.6.v12.suo</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA 1.6.v12.suo</td><td>1</td><td/></row>
		<row><td>simplecsmaproperties.cs</td><td>ISX_DEFAULTCOMPONENT106</td><td>SIMPLE~1.CS|SimpleCSMAProperties.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\SimpleCSMAProperties.cs</td><td>1</td><td/></row>
		<row><td>simplecsmaradio.csproj.filel</td><td>ISX_DEFAULTCOMPONENT113</td><td>SIMPLE~1.TXT|SimpleCsmaRadio.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\SimpleCsmaRadio.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>simplecsmaradio.csprojresolv</td><td>ISX_DEFAULTCOMPONENT113</td><td>SIMPLE~1.CAC|SimpleCsmaRadio.csprojResolveAssemblyReference.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\SimpleCsmaRadio.csprojResolveAssemblyReference.cache</td><td>1</td><td/></row>
		<row><td>simpletimer.cs</td><td>ISX_DEFAULTCOMPONENT147</td><td>SIMPLE~1.CS|SimpleTimer.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\SimpleTimer.cs</td><td>1</td><td/></row>
		<row><td>simpletimer.csproj</td><td>ISX_DEFAULTCOMPONENT147</td><td>SIMPLE~1.CSP|SimpleTimer.csproj</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\SimpleTimer.csproj</td><td>1</td><td/></row>
		<row><td>simpletimer.csproj.filelista</td><td>ISX_DEFAULTCOMPONENT149</td><td>SIMPLE~1.TXT|SimpleTimer.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\obj\Debug\SimpleTimer.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>simpletimer.csproj.user</td><td>ISX_DEFAULTCOMPONENT147</td><td>SIMPLE~1.USE|SimpleTimer.csproj.user</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\SimpleTimer.csproj.user</td><td>1</td><td/></row>
		<row><td>simpletimer.csprojresolveass</td><td>ISX_DEFAULTCOMPONENT149</td><td>SIMPLE~1.CAC|SimpleTimer.csprojResolveAssemblyReference.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\obj\Debug\SimpleTimer.csprojResolveAssemblyReference.cache</td><td>1</td><td/></row>
		<row><td>simpletimer_1.2.sln</td><td>ISX_DEFAULTCOMPONENT143</td><td>SIMPLE~1.SLN|SimpleTimer 1.2.sln</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer 1.2.sln</td><td>1</td><td/></row>
		<row><td>simpletimer_1.2.v12.suo</td><td>ISX_DEFAULTCOMPONENT143</td><td>SIMPLE~1.SUO|SimpleTimer 1.2.v12.suo</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer 1.2.v12.suo</td><td>1</td><td/></row>
		<row><td>sqrt.cs</td><td>ISX_DEFAULTCOMPONENT158</td><td>Sqrt.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\Sqrt.cs</td><td>1</td><td/></row>
		<row><td>sqrt.csproj</td><td>ISX_DEFAULTCOMPONENT158</td><td>SQRT~1.CSP|Sqrt.csproj</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\Sqrt.csproj</td><td>1</td><td/></row>
		<row><td>sqrt.csproj.filelistabsolute</td><td>ISX_DEFAULTCOMPONENT160</td><td>SQRTCS~1.TXT|Sqrt.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\obj\Debug\Sqrt.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>sqrt.csproj.user</td><td>ISX_DEFAULTCOMPONENT158</td><td>SQRTCS~1.USE|Sqrt.csproj.user</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\Sqrt.csproj.user</td><td>1</td><td/></row>
		<row><td>sqrt.csprojresolveassemblyre</td><td>ISX_DEFAULTCOMPONENT160</td><td>SQRTCS~1.CAC|Sqrt.csprojResolveAssemblyReference.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\obj\Debug\Sqrt.csprojResolveAssemblyReference.cache</td><td>1</td><td/></row>
		<row><td>sqrt_1.0.sln</td><td>ISX_DEFAULTCOMPONENT154</td><td>SQRT10~1.SLN|Sqrt 1.0.sln</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt 1.0.sln</td><td>1</td><td/></row>
		<row><td>sqrt_1.0.v12.suo</td><td>ISX_DEFAULTCOMPONENT154</td><td>SQRT10~1.SUO|Sqrt 1.0.v12.suo</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt 1.0.v12.suo</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_036c0</td><td>ISX_DEFAULTCOMPONENT56</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_036c01</td><td>ISX_DEFAULTCOMPONENT69</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_036c02</td><td>ISX_DEFAULTCOMPONENT113</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_036c03</td><td>ISX_DEFAULTCOMPONENT127</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_036c04</td><td>ISX_DEFAULTCOMPONENT138</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\obj\Debug\TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_036c05</td><td>ISX_DEFAULTCOMPONENT149</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\obj\Debug\TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_036c06</td><td>ISX_DEFAULTCOMPONENT160</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\obj\Debug\TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_036c07</td><td>ISX_DEFAULTCOMPONENT173</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\obj\Debug\TemporaryGeneratedFile_036C0B5B-1481-4323-8D20-8F5ADCB23D92.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_5937a</td><td>ISX_DEFAULTCOMPONENT56</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_5937a1</td><td>ISX_DEFAULTCOMPONENT69</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_5937a2</td><td>ISX_DEFAULTCOMPONENT113</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_5937a3</td><td>ISX_DEFAULTCOMPONENT127</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_5937a4</td><td>ISX_DEFAULTCOMPONENT138</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\obj\Debug\TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_5937a5</td><td>ISX_DEFAULTCOMPONENT149</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\obj\Debug\TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_5937a6</td><td>ISX_DEFAULTCOMPONENT160</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\obj\Debug\TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_5937a7</td><td>ISX_DEFAULTCOMPONENT173</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\obj\Debug\TemporaryGeneratedFile_5937a670-0e60-4077-877b-f7221da3dda1.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_e7a71</td><td>ISX_DEFAULTCOMPONENT56</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_e7a711</td><td>ISX_DEFAULTCOMPONENT69</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_e7a712</td><td>ISX_DEFAULTCOMPONENT113</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_e7a713</td><td>ISX_DEFAULTCOMPONENT127</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_e7a714</td><td>ISX_DEFAULTCOMPONENT138</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\obj\Debug\TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_e7a715</td><td>ISX_DEFAULTCOMPONENT149</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\obj\Debug\TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_e7a716</td><td>ISX_DEFAULTCOMPONENT160</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\obj\Debug\TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>1</td><td/></row>
		<row><td>temporarygeneratedfile_e7a717</td><td>ISX_DEFAULTCOMPONENT173</td><td>TEMPOR~1.CS|TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\obj\Debug\TemporaryGeneratedFile_E7A71F73-0F8D-4B9B-B56E-8E70B10BC5D3.cs</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.csproj</td><td>ISX_DEFAULTCOMPONENT61</td><td>TESTEN~1.CSP|TestEnhancedEmoteLCD.csproj</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\TestEnhancedEmoteLCD.csproj</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.csproj.</td><td>ISX_DEFAULTCOMPONENT69</td><td>TESTEN~1.TXT|TestEnhancedeMoteLCD.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\TestEnhancedeMoteLCD.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.csproj.1</td><td>ISX_DEFAULTCOMPONENT69</td><td>TESTEN~1.CAC|TestEnhancedeMoteLCD.csproj.GenerateResource.Cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\TestEnhancedeMoteLCD.csproj.GenerateResource.Cache</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.csproj.2</td><td>ISX_DEFAULTCOMPONENT61</td><td>TESTEN~1.USE|TestEnhancedEmoteLCD.csproj.user</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\TestEnhancedEmoteLCD.csproj.user</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.csprojr</td><td>ISX_DEFAULTCOMPONENT69</td><td>TESTEN~1.CAC|TestEnhancedEmoteLCD.csprojResolveAssemblyReference.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\TestEnhancedEmoteLCD.csprojResolveAssemblyReference.cache</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.exe</td><td>TestEnhancedeMoteLCD.exe</td><td>TESTEN~1.EXE|TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\be\TestEnhancedeMoteLCD.exe</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.exe1</td><td>TestEnhancedeMoteLCD.exe1</td><td>TESTEN~1.EXE|TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\le\TestEnhancedeMoteLCD.exe</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.exe2</td><td>TestEnhancedeMoteLCD.exe2</td><td>TESTEN~1.EXE|TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\TestEnhancedeMoteLCD.exe</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.exe3</td><td>TestEnhancedeMoteLCD.exe3</td><td>TESTEN~1.EXE|TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\be\TestEnhancedeMoteLCD.exe</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.exe4</td><td>TestEnhancedeMoteLCD.exe4</td><td>TESTEN~1.EXE|TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\le\TestEnhancedeMoteLCD.exe</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.exe5</td><td>TestEnhancedeMoteLCD.exe5</td><td>TESTEN~1.EXE|TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\TestEnhancedeMoteLCD.exe</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.exe6</td><td>TestEnhancedeMoteLCD.exe6</td><td>TESTEN~1.EXE|TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\TestEnhancedeMoteLCD.exe</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pdb</td><td>ISX_DEFAULTCOMPONENT28</td><td>TESTEN~1.PDB|TestEnhancedeMoteLCD.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\be\TestEnhancedeMoteLCD.pdb</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pdb1</td><td>ISX_DEFAULTCOMPONENT29</td><td>TESTEN~1.PDB|TestEnhancedeMoteLCD.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\le\TestEnhancedeMoteLCD.pdb</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pdb2</td><td>ISX_DEFAULTCOMPONENT27</td><td>TESTEN~1.PDB|TestEnhancedeMoteLCD.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\TestEnhancedeMoteLCD.pdb</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pdb3</td><td>ISX_DEFAULTCOMPONENT64</td><td>TESTEN~1.PDB|TestEnhancedeMoteLCD.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\be\TestEnhancedeMoteLCD.pdb</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pdb4</td><td>ISX_DEFAULTCOMPONENT65</td><td>TESTEN~1.PDB|TestEnhancedeMoteLCD.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\le\TestEnhancedeMoteLCD.pdb</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pdb5</td><td>ISX_DEFAULTCOMPONENT63</td><td>TESTEN~1.PDB|TestEnhancedeMoteLCD.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\TestEnhancedeMoteLCD.pdb</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pdb6</td><td>ISX_DEFAULTCOMPONENT69</td><td>TESTEN~1.PDB|TestEnhancedeMoteLCD.pdb</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\TestEnhancedeMoteLCD.pdb</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pdbx</td><td>ISX_DEFAULTCOMPONENT28</td><td>TESTEN~1.PDB|TestEnhancedeMoteLCD.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\be\TestEnhancedeMoteLCD.pdbx</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pdbx1</td><td>ISX_DEFAULTCOMPONENT29</td><td>TESTEN~1.PDB|TestEnhancedeMoteLCD.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\le\TestEnhancedeMoteLCD.pdbx</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pdbx2</td><td>ISX_DEFAULTCOMPONENT64</td><td>TESTEN~1.PDB|TestEnhancedeMoteLCD.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\be\TestEnhancedeMoteLCD.pdbx</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pdbx3</td><td>ISX_DEFAULTCOMPONENT65</td><td>TESTEN~1.PDB|TestEnhancedeMoteLCD.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\le\TestEnhancedeMoteLCD.pdbx</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pdbx4</td><td>ISX_DEFAULTCOMPONENT70</td><td>TESTEN~1.PDB|TestEnhancedeMoteLCD.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\be\TestEnhancedeMoteLCD.pdbx</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pdbx5</td><td>ISX_DEFAULTCOMPONENT71</td><td>TESTEN~1.PDB|TestEnhancedeMoteLCD.pdbx</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\le\TestEnhancedeMoteLCD.pdbx</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pe</td><td>ISX_DEFAULTCOMPONENT28</td><td>TESTEN~1.PE|TestEnhancedeMoteLCD.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\be\TestEnhancedeMoteLCD.pe</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pe1</td><td>ISX_DEFAULTCOMPONENT29</td><td>TESTEN~1.PE|TestEnhancedeMoteLCD.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\bin\le\TestEnhancedeMoteLCD.pe</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pe2</td><td>ISX_DEFAULTCOMPONENT64</td><td>TESTEN~1.PE|TestEnhancedeMoteLCD.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\be\TestEnhancedeMoteLCD.pe</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pe3</td><td>ISX_DEFAULTCOMPONENT65</td><td>TESTEN~1.PE|TestEnhancedeMoteLCD.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\bin\Debug\le\TestEnhancedeMoteLCD.pe</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pe4</td><td>ISX_DEFAULTCOMPONENT70</td><td>TESTEN~1.PE|TestEnhancedeMoteLCD.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\be\TestEnhancedeMoteLCD.pe</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.pe5</td><td>ISX_DEFAULTCOMPONENT71</td><td>TESTEN~1.PE|TestEnhancedeMoteLCD.pe</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\le\TestEnhancedeMoteLCD.pe</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.resourc</td><td>ISX_DEFAULTCOMPONENT69</td><td>TESTEN~1.RES|TestEnhancedeMoteLCD.Resources.resources</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\TestEnhancedeMoteLCD.Resources.resources</td><td>1</td><td/></row>
		<row><td>testenhancedemotelcd.resourc1</td><td>ISX_DEFAULTCOMPONENT69</td><td>TESTEN~1.TIN|TestEnhancedeMoteLCD.Resources.tinyresources</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\TestEnhancedeMoteLCD.Resources.tinyresources</td><td>1</td><td/></row>
		<row><td>tinyclr_debugreferences.cach</td><td>ISX_DEFAULTCOMPONENT69</td><td>TINYCL~1.CAC|TinyCLR_DebugReferences.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\TinyCLR_DebugReferences.cache</td><td>1</td><td/></row>
		<row><td>tinyclr_debugreferences.cach1</td><td>ISX_DEFAULTCOMPONENT113</td><td>TINYCL~1.CAC|TinyCLR_DebugReferences.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\TinyCLR_DebugReferences.cache</td><td>1</td><td/></row>
		<row><td>tinyclr_debugreferences.cach2</td><td>ISX_DEFAULTCOMPONENT127</td><td>TINYCL~1.CAC|TinyCLR_DebugReferences.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\TinyCLR_DebugReferences.cache</td><td>1</td><td/></row>
		<row><td>tinyclr_debugreferences.cach3</td><td>ISX_DEFAULTCOMPONENT138</td><td>TINYCL~1.CAC|TinyCLR_DebugReferences.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SerialComm\SerialComm\obj\Debug\TinyCLR_DebugReferences.cache</td><td>1</td><td/></row>
		<row><td>tinyclr_debugreferences.cach4</td><td>ISX_DEFAULTCOMPONENT149</td><td>TINYCL~1.CAC|TinyCLR_DebugReferences.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\SimpleTimer\SimpleTimer\obj\Debug\TinyCLR_DebugReferences.cache</td><td>1</td><td/></row>
		<row><td>tinyclr_debugreferences.cach5</td><td>ISX_DEFAULTCOMPONENT160</td><td>TINYCL~1.CAC|TinyCLR_DebugReferences.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\Sqrt\Sqrt\obj\Debug\TinyCLR_DebugReferences.cache</td><td>1</td><td/></row>
		<row><td>tinyclr_debugreferences.cach6</td><td>ISX_DEFAULTCOMPONENT173</td><td>TINYCL~1.CAC|TinyCLR_DebugReferences.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\obj\Debug\TinyCLR_DebugReferences.cache</td><td>1</td><td/></row>
		<row><td>tinyresgen.cache</td><td>ISX_DEFAULTCOMPONENT69</td><td>TINYRE~1.CAC|TinyResGen.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\TestEnhancedEmoteLCD\obj\Debug\TinyResGen.cache</td><td>1</td><td/></row>
		<row><td>utility.csproj.filelistabsol</td><td>ISX_DEFAULTCOMPONENT127</td><td>UTILIT~1.TXT|Utility.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\BitConverter\BitConverter\obj\Debug\Utility.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>utility.enhancedemotelcd.csp</td><td>ISX_DEFAULTCOMPONENT56</td><td>UTILIT~1.TXT|Utility.EnhancedEmoteLCD.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\Utility.EnhancedEmoteLCD.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>utility.enhancedemotelcd.csp1</td><td>ISX_DEFAULTCOMPONENT56</td><td>UTILIT~1.CAC|Utility.EnhancedEmoteLCD.csprojResolveAssemblyReference.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\obj\Debug\Utility.EnhancedEmoteLCD.csprojResolveAssemblyReference.cache</td><td>1</td><td/></row>
		<row><td>utility.enhancedemotelcd.csp2</td><td>ISX_DEFAULTCOMPONENT54</td><td>UTILIT~1.CSP|Utility.EnhancedEmoteLCD.csproj</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\Utility.EnhancedEmoteLCD.csproj</td><td>1</td><td/></row>
		<row><td>utility.enhancedemotelcd.csp3</td><td>ISX_DEFAULTCOMPONENT54</td><td>UTILIT~1.USE|Utility.EnhancedEmoteLCD.csproj.user</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\EnhancedEmoteLCD\EnhancedEmoteLCD\Utility.EnhancedEmoteLCD.csproj.user</td><td>1</td><td/></row>
		<row><td>utility.simplecsma.csproj</td><td>ISX_DEFAULTCOMPONENT106</td><td>UTILIT~1.CSP|Utility.SimpleCSMA.csproj</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\Utility.SimpleCSMA.csproj</td><td>1</td><td/></row>
		<row><td>utility.simplecsma.csproj.fi</td><td>ISX_DEFAULTCOMPONENT113</td><td>UTILIT~1.TXT|Utility.SimpleCSMA.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\Utility.SimpleCSMA.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>utility.simplecsma.csproj.us</td><td>ISX_DEFAULTCOMPONENT106</td><td>UTILIT~1.USE|Utility.SimpleCSMA.csproj.user</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\Utility.SimpleCSMA.csproj.user</td><td>1</td><td/></row>
		<row><td>utility.simplecsma.csprojres</td><td>ISX_DEFAULTCOMPONENT113</td><td>UTILIT~1.CAC|Utility.SimpleCSMA.csprojResolveAssemblyReference.cache</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\DotNow\SimpleCSMA\SimpleCSMA\obj\Debug\Utility.SimpleCSMA.csprojResolveAssemblyReference.cache</td><td>1</td><td/></row>
		<row><td>utility.versioninfo.csproj</td><td>ISX_DEFAULTCOMPONENT169</td><td>UTILIT~1.CSP|Utility.VersionInfo.csproj</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\Utility.VersionInfo.csproj</td><td>1</td><td/></row>
		<row><td>utility.versioninfo.csproj.f</td><td>ISX_DEFAULTCOMPONENT173</td><td>UTILIT~1.TXT|Utility.VersionInfo.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\obj\Debug\Utility.VersionInfo.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>utility.versioninfo.csproj.u</td><td>ISX_DEFAULTCOMPONENT169</td><td>UTILIT~1.USE|Utility.VersionInfo.csproj.user</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\Utility.VersionInfo.csproj.user</td><td>1</td><td/></row>
		<row><td>versioninfo.cs</td><td>ISX_DEFAULTCOMPONENT169</td><td>VERSIO~1.CS|VersionInfo.cs</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\VersionInfo.cs</td><td>1</td><td/></row>
		<row><td>versioninfo.csproj.filelista</td><td>ISX_DEFAULTCOMPONENT173</td><td>VERSIO~1.TXT|VersionInfo.csproj.FileListAbsolute.txt</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo\obj\Debug\VersionInfo.csproj.FileListAbsolute.txt</td><td>1</td><td/></row>
		<row><td>versioninfo_1.2.sln</td><td>ISX_DEFAULTCOMPONENT165</td><td>VERSIO~1.SLN|VersionInfo 1.2.sln</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo 1.2.sln</td><td>1</td><td/></row>
		<row><td>versioninfo_1.2.v12.suo</td><td>ISX_DEFAULTCOMPONENT165</td><td>VERSIO~1.SUO|VersionInfo 1.2.v12.suo</td><td>0</td><td/><td/><td/><td>1</td><td>C:\SamGit\AppNotes\Active\Utility Classes\General\VersionInfo\VersionInfo 1.2.v12.suo</td><td>1</td><td/></row>
	</table>

	<table name="FileSFPCatalog">
		<col key="yes" def="s72">File_</col>
		<col key="yes" def="s255">SFPCatalog_</col>
	</table>

	<table name="Font">
		<col key="yes" def="s72">File_</col>
		<col def="S128">FontTitle</col>
	</table>

	<table name="ISAssistantTag">
		<col key="yes" def="s72">Tag</col>
		<col def="S255">Data</col>
	</table>

	<table name="ISBillBoard">
		<col key="yes" def="s72">ISBillboard</col>
		<col def="i2">Duration</col>
		<col def="i2">Origin</col>
		<col def="i2">X</col>
		<col def="i2">Y</col>
		<col def="i2">Effect</col>
		<col def="i2">Sequence</col>
		<col def="i2">Target</col>
		<col def="S72">Color</col>
		<col def="S72">Style</col>
		<col def="S72">Font</col>
		<col def="L72">Title</col>
		<col def="S72">DisplayName</col>
	</table>

	<table name="ISChainPackage">
		<col key="yes" def="s72">Package</col>
		<col def="S255">SourcePath</col>
		<col def="S72">ProductCode</col>
		<col def="i2">Order</col>
		<col def="i4">Options</col>
		<col def="S255">InstallCondition</col>
		<col def="S255">RemoveCondition</col>
		<col def="S0">InstallProperties</col>
		<col def="S0">RemoveProperties</col>
		<col def="S255">ISReleaseFlags</col>
		<col def="S72">DisplayName</col>
	</table>

	<table name="ISChainPackageData">
		<col key="yes" def="s72">Package_</col>
		<col key="yes" def="s72">File</col>
		<col def="s50">FilePath</col>
		<col def="I4">Options</col>
		<col def="V0">Data</col>
		<col def="S255">ISBuildSourcePath</col>
	</table>

	<table name="ISClrWrap">
		<col key="yes" def="s72">Action_</col>
		<col key="yes" def="s72">Name</col>
		<col def="S0">Value</col>
	</table>

	<table name="ISComCatalogAttribute">
		<col key="yes" def="s72">ISComCatalogObject_</col>
		<col key="yes" def="s255">ItemName</col>
		<col def="S0">ItemValue</col>
	</table>

	<table name="ISComCatalogCollection">
		<col key="yes" def="s72">ISComCatalogCollection</col>
		<col def="s72">ISComCatalogObject_</col>
		<col def="s255">CollectionName</col>
	</table>

	<table name="ISComCatalogCollectionObjects">
		<col key="yes" def="s72">ISComCatalogCollection_</col>
		<col key="yes" def="s72">ISComCatalogObject_</col>
	</table>

	<table name="ISComCatalogObject">
		<col key="yes" def="s72">ISComCatalogObject</col>
		<col def="s255">DisplayName</col>
	</table>

	<table name="ISComPlusApplication">
		<col key="yes" def="s72">ISComCatalogObject_</col>
		<col def="S255">ComputerName</col>
		<col def="s72">Component_</col>
		<col def="I2">ISAttributes</col>
		<col def="S0">DepFiles</col>
	</table>

	<table name="ISComPlusApplicationDLL">
		<col key="yes" def="s72">ISComPlusApplicationDLL</col>
		<col def="s72">ISComPlusApplication_</col>
		<col def="s72">ISComCatalogObject_</col>
		<col def="s0">CLSID</col>
		<col def="S0">ProgId</col>
		<col def="S0">DLL</col>
		<col def="S0">AlterDLL</col>
	</table>

	<table name="ISComPlusProxy">
		<col key="yes" def="s72">ISComPlusProxy</col>
		<col def="s72">ISComPlusApplication_</col>
		<col def="S72">Component_</col>
		<col def="I2">ISAttributes</col>
		<col def="S0">DepFiles</col>
	</table>

	<table name="ISComPlusProxyDepFile">
		<col key="yes" def="s72">ISComPlusApplication_</col>
		<col key="yes" def="s72">File_</col>
		<col def="S0">ISPath</col>
	</table>

	<table name="ISComPlusProxyFile">
		<col key="yes" def="s72">File_</col>
		<col key="yes" def="s72">ISComPlusApplicationDLL_</col>
	</table>

	<table name="ISComPlusServerDepFile">
		<col key="yes" def="s72">ISComPlusApplication_</col>
		<col key="yes" def="s72">File_</col>
		<col def="S0">ISPath</col>
	</table>

	<table name="ISComPlusServerFile">
		<col key="yes" def="s72">File_</col>
		<col key="yes" def="s72">ISComPlusApplicationDLL_</col>
	</table>

	<table name="ISComponentExtended">
		<col key="yes" def="s72">Component_</col>
		<col def="I4">OS</col>
		<col def="S0">Language</col>
		<col def="s72">FilterProperty</col>
		<col def="I4">Platforms</col>
		<col def="S0">FTPLocation</col>
		<col def="S0">HTTPLocation</col>
		<col def="S0">Miscellaneous</col>
		<row><td>ISX_DEFAULTCOMPONENT</td><td/><td/><td>_6A45E323_D62D_4843_B9E4_37DA069853BC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT1</td><td/><td/><td>_69486600_FF19_4592_AD45_90F70290E492_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT10</td><td/><td/><td>_A62D9BA2_6BA1_4BFB_B4C4_EEC18E750ACD_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT100</td><td/><td/><td>_D71DAE8E_A719_4590_84D6_B4E3DED65FDC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT101</td><td/><td/><td>_8911B998_750B_4553_9F08_8B04172451B0_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT102</td><td/><td/><td>_2381EB38_0F8C_4775_8FDD_744F182CA136_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT103</td><td/><td/><td>_0A3E542F_0172_4547_B6E5_E0EE0947B480_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT104</td><td/><td/><td>_B7914650_01A1_484A_BC5D_6739E6313FE8_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT105</td><td/><td/><td>_C674D5E7_0FC5_4E0D_B2E0_3050CA973FB2_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT106</td><td/><td/><td>_7A41F9E0_E55F_43E2_99F0_8A402966BB46_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT107</td><td/><td/><td>_6A859BF7_EB3F_4F55_8D5D_ADF11079870A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT108</td><td/><td/><td>_B6446C47_9458_4AB0_8A24_4BEB4035BDD5_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT109</td><td/><td/><td>_D6645B2C_0A9E_4C00_95FB_B9768B6F5215_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT11</td><td/><td/><td>_EDD8F7C1_E3DE_4DD7_BD8E_4CCB88E8309C_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT110</td><td/><td/><td>_494715E7_6194_4628_ABCE_7098DC1FBC67_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT111</td><td/><td/><td>_F67C23ED_A943_48D2_9E65_A0104AD84A0A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT112</td><td/><td/><td>_CDC3A2B8_FF5E_461B_B850_4AA3D05F449F_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT113</td><td/><td/><td>_EA2265ED_78D4_4C5C_A351_0C17EEBA82C8_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT114</td><td/><td/><td>_08A46341_2676_4F05_A114_878483BDD06E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT115</td><td/><td/><td>_0CB5A899_D434_42E6_8E44_C2573D6BA51A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT116</td><td/><td/><td>_868CEF8B_2012_4E77_B852_6C3209AFFD5A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT117</td><td/><td/><td>_C47E24BA_22CE_4D51_B5E0_A4D023F0A1BC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT118</td><td/><td/><td>_A16023E6_BFFA_4765_B95E_123FF8F3B862_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT119</td><td/><td/><td>_8D6A0D62_1518_462D_8726_858A1869C245_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT12</td><td/><td/><td>_5AADC8B3_7439_4ACD_B886_2B42C96C1EBF_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT120</td><td/><td/><td>_D899C28A_F78B_401D_95FF_CA0E6262DB80_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT121</td><td/><td/><td>_233E1B8C_939B_4938_8638_2240986657CD_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT122</td><td/><td/><td>_93D055BA_08F7_4AC3_801D_1613AF777AAC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT123</td><td/><td/><td>_78E9DE09_4D8E_49BB_A6AC_B5D5B2380DD0_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT124</td><td/><td/><td>_F62944DE_0E01_40CB_8024_AA290E16B52B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT125</td><td/><td/><td>_45F85028_0B8B_44EC_B6FC_962AFFFC44EC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT126</td><td/><td/><td>_0532B4B3_4BF9_4887_A17D_D79CFA0BB2B7_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT127</td><td/><td/><td>_D33D80C0_7022_4BC4_9506_1F95230DABFE_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT128</td><td/><td/><td>_EBF0AF5C_129E_408E_8700_4D82E4578C3E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT129</td><td/><td/><td>_1C0142D4_D82C_445E_A4A9_E58C1576FB25_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT13</td><td/><td/><td>_75D5C291_128B_4CF5_83DE_80EE5D2857FC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT130</td><td/><td/><td>_AA11B26F_D388_40E8_9B3E_C031FE644D27_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT131</td><td/><td/><td>_C6F7455E_9450_4591_B926_29CBE1D7AEFB_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT132</td><td/><td/><td>_1CD7243D_50BF_4DC6_A31A_01E9DB11F37A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT133</td><td/><td/><td>_05080714_5B7B_476C_A6F8_1A22AD59C0E5_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT134</td><td/><td/><td>_3221882F_0829_48F1_BBE2_17B4C2F471AF_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT135</td><td/><td/><td>_96E31E9E_FDE7_415C_83B5_62D558B58950_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT136</td><td/><td/><td>_44FFDF38_2BCF_4CFA_AA07_2E6EC3482EF7_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT137</td><td/><td/><td>_11C0806F_6958_4829_B955_04CA430CC5D4_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT138</td><td/><td/><td>_963117C3_AD17_4430_9C5F_2232ECD5530E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT139</td><td/><td/><td>_3BDF1834_FA6D_4F46_AE81_2D58AC9B4631_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT14</td><td/><td/><td>_86C46268_BE4A_4EAC_9066_AB62E3ED04E6_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT140</td><td/><td/><td>_23F29257_9148_4162_8732_ADFF6008D2A2_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT141</td><td/><td/><td>_B95D3A98_4566_4DF5_906A_4D4AC4110264_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT142</td><td/><td/><td>_BC4DBCC7_F56C_478F_A0E9_2C3B281B29DE_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT143</td><td/><td/><td>_FB4DC805_9C5E_43B8_A303_BB15C9347EBA_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT144</td><td/><td/><td>_43A14217_A871_4703_A51A_81C547D5C427_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT145</td><td/><td/><td>_35EDB830_1946_4189_B1A8_6EA321B43C95_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT146</td><td/><td/><td>_694B340A_AF8A_4B12_B7A3_E1E5DFA1C6EE_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT147</td><td/><td/><td>_EF33242C_556D_4BEC_A211_F59820072FC3_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT148</td><td/><td/><td>_D9D75896_9174_4D25_A30E_9510CDF59E9F_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT149</td><td/><td/><td>_326EE531_AF1E_446A_9969_C9D37B81E206_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT15</td><td/><td/><td>_555E7897_A41F_4612_8F81_4612AEC4EEDC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT150</td><td/><td/><td>_EB6A4E84_AB8A_4BB0_BE3D_91C43474CAB7_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT151</td><td/><td/><td>_4A32D614_7FA7_492E_88A1_354D4E739F19_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT152</td><td/><td/><td>_875B23D3_CA6D_49B0_9404_80B39899EC8F_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT153</td><td/><td/><td>_4FBD433E_CAF5_4AAE_A94B_1681202D11EC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT154</td><td/><td/><td>_1CB2B478_3C25_4471_9DBD_61DA30FA99DF_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT155</td><td/><td/><td>_05F3F2F0_57F7_4231_BCE1_B92F1E055121_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT156</td><td/><td/><td>_550F0610_2D5A_4835_A13D_123F712F62F8_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT157</td><td/><td/><td>_EF2DD488_826D_48DF_9DBC_5AC947D8FAD7_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT158</td><td/><td/><td>_9C29A28B_EB91_4A23_800E_1DB6D2A8A2F4_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT159</td><td/><td/><td>_9DC8FDBC_FB54_442D_A5D8_D229EBA80624_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT16</td><td/><td/><td>_83869AFA_E45B_4DD8_BA99_3CFFBD474877_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT160</td><td/><td/><td>_49A85BED_96C9_4652_855C_C06C3AC4629E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT161</td><td/><td/><td>_BE84EDE0_1CD4_4D60_8598_44D9F80B44D8_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT162</td><td/><td/><td>_1535FB42_4715_466E_B344_4ED2E968334D_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT163</td><td/><td/><td>_0345844F_84BA_4595_AE77_3C30B597B18B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT164</td><td/><td/><td>_A3DAB520_090D_40C8_983A_E0A2178D22C4_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT165</td><td/><td/><td>_EDF02934_6757_4B65_8F69_34FC46145318_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT166</td><td/><td/><td>_EABA2BBB_746F_4A71_A6D1_7B5EB83BC0CB_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT167</td><td/><td/><td>_2D63BCDF_55F6_478D_B189_235C4B61EA1F_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT168</td><td/><td/><td>_131DCD30_9745_4B0E_9A95_8397EC8AF210_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT169</td><td/><td/><td>_8BF7DB65_19CF_4984_949D_73A00F9CF036_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT17</td><td/><td/><td>_92F1A861_1F2E_4C9E_93EE_EF0DD4916E09_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT170</td><td/><td/><td>_EFF7DE0D_1832_426F_BF10_CD49CC8C213E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT171</td><td/><td/><td>_DFC4C04B_576F_4B87_95BE_9F2DF0C07A43_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT172</td><td/><td/><td>_18844AF2_60E7_46C1_BE07_7111B864CF67_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT173</td><td/><td/><td>_60CFA2AE_5D13_44DC_B8AE_6A19443EF7EC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT174</td><td/><td/><td>_6384EF8A_F8D0_48CF_AA69_B7E4A35219E6_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT175</td><td/><td/><td>_2C3CF583_7A83_4350_B23F_16EF9566E7E7_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT176</td><td/><td/><td>_F513C771_7120_4000_8135_8843D2BC1F82_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT177</td><td/><td/><td>_D1974197_2E05_4A71_A373_41CD679D9427_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT18</td><td/><td/><td>_F599EDB9_6234_464B_8723_84D15E80F2F6_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT19</td><td/><td/><td>_85926FB6_B946_48DA_AD11_D3F964F613F7_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT2</td><td/><td/><td>_CDB471C4_2BC5_4E8D_A171_8B112BDDDE9A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT20</td><td/><td/><td>_69AE3E4B_7876_4C24_A311_9E79C4A7FC93_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT21</td><td/><td/><td>_628EFE8D_8D4D_4995_8181_CEF75A10A79E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT22</td><td/><td/><td>_6562DF77_A8D0_4D20_ABC3_C44CA0B61D07_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT23</td><td/><td/><td>_5F03569D_F079_400C_864E_0EF986A9AC12_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT24</td><td/><td/><td>_4594D595_76BE_4AD8_B6CF_728B2EF89194_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT25</td><td/><td/><td>_27248E7D_1B15_4E9E_B852_50E5B27F95CF_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT26</td><td/><td/><td>_799948CB_CD56_49C6_84AE_6D29BE5D2A7A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT27</td><td/><td/><td>_D465F0AA_16C1_4CD2_AE4A_E0244FF43946_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT28</td><td/><td/><td>_6CEB32F0_EE95_4D81_897C_BC111E2F6F09_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT29</td><td/><td/><td>_7BA6A1F1_172E_42F3_9638_F79F0E4B854A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT3</td><td/><td/><td>_ABD5975C_3347_4C6D_9459_B0B56C88C3B0_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT30</td><td/><td/><td>_7A09C3DA_7C22_4D98_8FCB_E03D1BEBF0AB_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT31</td><td/><td/><td>_C22A0938_6D15_4DA9_ADA5_2122D211F122_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT32</td><td/><td/><td>_31A24394_DD11_458E_9F38_EBCC9FE5BE5B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT33</td><td/><td/><td>_D4319A6C_01E6_4379_AB17_5B68CCBD4AA2_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT34</td><td/><td/><td>_94B8845D_55AC_4097_861F_05FCD42C145E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT35</td><td/><td/><td>_27D3B4B8_E3F3_4731_B0EE_F7217AD20B0F_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT36</td><td/><td/><td>_7D0D6658_247A_460C_A6C9_4BA45BE6A845_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT37</td><td/><td/><td>_22765B30_0343_46D6_BC6C_E723BA2B33E3_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT38</td><td/><td/><td>_CC7A3CB0_DD4A_4491_BBF1_61D6C032A21C_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT39</td><td/><td/><td>_D1B95A49_1D07_48C8_853B_4777CBF9A87B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT4</td><td/><td/><td>_C0E9BE01_431A_4366_B6BA_784738540524_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT40</td><td/><td/><td>_A782640C_0F13_4DA4_9251_13441B196FF7_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT41</td><td/><td/><td>_81C6372A_5A7C_437A_95ED_FE69E92C7E2A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT42</td><td/><td/><td>_5E0D95CF_3482_4520_908E_36A99469EBD8_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT43</td><td/><td/><td>_857C4684_CBB1_4244_BD6E_57DD27CCB2C0_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT44</td><td/><td/><td>_74DC1F4B_4C63_49E0_98E6_97808D7B6E8B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT45</td><td/><td/><td>_782FDEE9_94F5_4B5B_A129_45CDB08BEF33_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT46</td><td/><td/><td>_6A20666E_EC8C_4144_8362_1A65F08E6613_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT47</td><td/><td/><td>_97169590_670C_4DB6_B195_EA363DB71F14_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT48</td><td/><td/><td>_CA8FC440_2D13_4D9F_9FBB_FA9DA1FE4AA3_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT49</td><td/><td/><td>_0189A72F_1B9A_4DEB_9AD9_923F030CF1A0_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT5</td><td/><td/><td>_D2FD422F_943B_4691_8583_A482340501E8_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT50</td><td/><td/><td>_82B89C6B_A452_44BC_9906_B00207B39370_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT51</td><td/><td/><td>_9E5FC89C_8482_4B2C_8E10_5FE3CA1F067B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT52</td><td/><td/><td>_2BBA5D56_71C8_4AC4_B47F_7BC9E32354F3_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT53</td><td/><td/><td>_A2E0975C_80F0_42E2_9381_965A1F3FEDB9_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT54</td><td/><td/><td>_E44C7A95_8A80_48A3_8F06_2AB75A1902A4_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT55</td><td/><td/><td>_688FC4BD_F92E_414A_B2E9_7C17D9E03D20_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT56</td><td/><td/><td>_F213532D_FF35_47B9_9949_6F82FAF3BD09_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT57</td><td/><td/><td>_1CA46E06_9613_48C4_9C14_65F57899B024_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT58</td><td/><td/><td>_5E2E391A_825D_4701_B520_25E232B5407A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT59</td><td/><td/><td>_5A1FA949_5B4E_4B4F_A48B_FF5BF2E57B83_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT6</td><td/><td/><td>_335C1C2A_C5D9_4F60_9B91_30EDFB2FA8A7_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT60</td><td/><td/><td>_84EA7383_C2C0_4D89_AA88_04DAC745879E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT61</td><td/><td/><td>_95E05427_6471_423F_AADF_BEC959780C01_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT62</td><td/><td/><td>_EDC7F143_9E2C_44C5_A3A5_B3A457F7DF8B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT63</td><td/><td/><td>_75551812_6203_40FE_A0C6_F9DC2C643DC7_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT64</td><td/><td/><td>_C6E0A3DF_61DD_4591_8AB5_D86E5A6822B7_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT65</td><td/><td/><td>_107CA2C9_500D_4C9D_B5D3_B4C4CD0481E6_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT66</td><td/><td/><td>_8F8A7071_B478_45F2_B73C_AE55BFE506AB_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT67</td><td/><td/><td>_DE141CC6_0B90_4775_A32C_E10DA0A75C0F_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT68</td><td/><td/><td>_89E49243_0211_4B14_A7A9_19A831316681_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT69</td><td/><td/><td>_554E8264_0BEC_4014_94BD_12B2E91873BA_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT7</td><td/><td/><td>_4D8C02FD_AC7F_499B_908B_1D1A800E2422_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT70</td><td/><td/><td>_765FF8D8_8BE9_4443_B899_2FEFF3246B45_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT71</td><td/><td/><td>_B8F1F021_A293_4BD2_902D_053BFB775CFF_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT72</td><td/><td/><td>_66F0238F_563C_4B82_9BBD_D23084E58DD1_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT73</td><td/><td/><td>_B17CEEB9_79EB_41A1_B641_7CFCA832866C_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT74</td><td/><td/><td>_04992DC3_409F_4A36_950C_78028467F9C4_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT75</td><td/><td/><td>_539EF33E_B3CE_4FF5_B8A6_E2A42FCC754B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT76</td><td/><td/><td>_5C6194FC_066B_4D98_A10B_FFA005849B84_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT77</td><td/><td/><td>_4F98426F_DA20_4B8C_BA3E_EB10B304580C_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT78</td><td/><td/><td>_CCD94A9D_A9F8_4E04_B5D2_3C9C2267779E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT79</td><td/><td/><td>_39843765_BF94_42AA_AE99_B0595BB388FB_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT8</td><td/><td/><td>_8FF51A61_4DFF_48AB_A68C_9E5DC50BA184_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT80</td><td/><td/><td>_42F432C5_A4BE_4EA9_920A_FC976BDFAA9E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT81</td><td/><td/><td>_E85A6909_DB1C_4C02_8F33_F9F92517DD12_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT82</td><td/><td/><td>_2B39F352_A7FE_45E5_A0A2_DB35B2FE4D86_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT83</td><td/><td/><td>_17441C97_EC30_40A9_A137_F19709B09B47_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT84</td><td/><td/><td>_0B191A04_4C4F_4A9A_BCDF_182CA9D97D61_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT85</td><td/><td/><td>_BC2FA62F_76BD_45ED_A6C1_169B58AE465E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT86</td><td/><td/><td>_BF45460A_FCA3_4847_ACBA_1793E5F385FB_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT87</td><td/><td/><td>_BD97C971_F90A_4D3E_803E_49BEECE6BEA9_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT88</td><td/><td/><td>_4A4365E0_BB9D_45B2_AEC0_D1F901D1F985_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT89</td><td/><td/><td>_2EDB71F9_8054_4BFA_B504_CE812822C464_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT9</td><td/><td/><td>_3C2ECCA9_2209_4725_A72D_6FC029C7538C_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT90</td><td/><td/><td>_F28A1290_6064_4140_BD70_0B029B3CFA9D_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT91</td><td/><td/><td>_577D4483_DF6E_44A9_871D_B3A639C60934_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT92</td><td/><td/><td>_049B4842_4403_4F69_8030_3F5651E3E4AA_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT93</td><td/><td/><td>_C3832388_7DAF_4EA9_ACDC_E980F4B089D5_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT94</td><td/><td/><td>_1DA5C683_3EA7_4FEA_9FF8_FCEF5983DB14_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT95</td><td/><td/><td>_AFE58250_2342_422B_ACA2_B22FEAA53D67_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT96</td><td/><td/><td>_AC6D0383_F232_4648_997E_D27E68BB1DC1_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT97</td><td/><td/><td>_FC66558C_40F7_4368_B2E2_2A47E84722B6_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT98</td><td/><td/><td>_5B04E46E_ECCF_49C9_BAA9_795ECAF99A0D_FILTER</td><td/><td/><td/><td/></row>
		<row><td>ISX_DEFAULTCOMPONENT99</td><td/><td/><td>_42485ABB_AE4D_40B5_A10A_69F575170097_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.BitConverter.dll</td><td/><td/><td>_69B019A4_DC13_45A9_B3A0_7678DAF1E410_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.BitConverter.dll1</td><td/><td/><td>_4242A399_7086_41BF_A161_6A853ED0326E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.BitConverter.dll2</td><td/><td/><td>_9DF96E8F_0719_4CB1_8718_3034370AABB2_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.BitConverter.dll3</td><td/><td/><td>_6FB0FE3A_A87D_48BE_ADFD_F99595002C5D_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll</td><td/><td/><td>_B75C2B6F_F3B5_44FF_9213_29332AF95049_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll1</td><td/><td/><td>_5734FAA5_89CE_4538_BDA2_6280F94A5F4D_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll2</td><td/><td/><td>_ABB726DF_91A5_4CFC_85B3_C49437EEC0B5_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.EnhancedEmoteLCD.dll3</td><td/><td/><td>_A5856D03_60D4_4447_A8EF_93A1269746B2_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.EnhancedeMoteLcd.dll</td><td/><td/><td>_83C7F9C5_96BC_4281_AD35_25B68A3E9DB4_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SerialComm.dll</td><td/><td/><td>_8B3E91BA_C6D3_41FD_911F_8D5CFB569C3D_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SerialComm.dll1</td><td/><td/><td>_9DFF05D9_63D3_4455_86D6_572F93FA636A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SerialComm.dll2</td><td/><td/><td>_F056A5E5_29F3_438C_BC53_38E5902F0900_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SerialComm.dll3</td><td/><td/><td>_63588729_D884_43C2_AD6D_9FCE0C1C38E4_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll</td><td/><td/><td>_A7452FB7_73A6_4DBF_80BE_A77E920674C4_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll1</td><td/><td/><td>_1216A34A_31E9_44D1_B695_D4BE7A497223_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll2</td><td/><td/><td>_2941C798_D4FC_4CE5_8D44_2B7181A62C69_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll3</td><td/><td/><td>_0F82A883_9D15_4B1C_95FC_9752A0B6B51E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll4</td><td/><td/><td>_8E3C4257_382F_4068_AB1E_9B212656A18B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll5</td><td/><td/><td>_5F96EFEB_F6AD_490D_A70F_341CCBE39F58_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCSMA.dll6</td><td/><td/><td>_1D0AC34D_4432_4D8E_8166_71E792542B92_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll</td><td/><td/><td>_55992911_D24F_4DC3_9C85_48540B9A333D_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll1</td><td/><td/><td>_23655B08_3040_461C_B5A3_FB303CD60704_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll2</td><td/><td/><td>_833A4008_482E_484B_B9A8_626607962A5C_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleCsmaRadio.dll3</td><td/><td/><td>_4A73944A_10F1_4AA2_99CE_EDA43567BB2E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleTimer.dll</td><td/><td/><td>_D47AE7BA_8E41_4349_8934_A5F53849FF0D_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleTimer.dll1</td><td/><td/><td>_3F9A8160_187D_4F26_A98A_E97EF9A6FB52_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleTimer.dll2</td><td/><td/><td>_0EE84741_DE91_473A_B5A7_BCBE9E15888A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.SimpleTimer.dll3</td><td/><td/><td>_7D898758_B353_43CA_9A59_2432AFDE802E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.Sqrt.dll</td><td/><td/><td>_5B11D728_2369_45B7_8933_19F5903A44BF_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.Sqrt.dll1</td><td/><td/><td>_C4B3A6FB_F9F1_4C8E_885E_97D7FE8860A2_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.Sqrt.dll2</td><td/><td/><td>_7F0628DA_7C11_4987_BB06_CC2B1F81931D_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.Sqrt.dll3</td><td/><td/><td>_E0F8AD0C_4C59_48AB_BBC7_D822BC70CCCA_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll</td><td/><td/><td>_7A85A975_518B_451E_99E7_DBF705BB41AB_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll1</td><td/><td/><td>_1547272F_6B04_486A_8B16_D195C65B979B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll2</td><td/><td/><td>_939DE90A_F29D_486E_BA0D_5EF09CBA04E7_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll3</td><td/><td/><td>_1CFC55F5_F8EB_4BBB_86B8_9570AC39FBAC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll4</td><td/><td/><td>_8BC4B333_971B_4376_9085_5F40CD31C0CC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll5</td><td/><td/><td>_1C59E0C3_8E03_4AAE_AB7B_D1F6170A349B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll6</td><td/><td/><td>_6E05BF0F_29E6_4402_A7B9_27074B50DE03_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll7</td><td/><td/><td>_6F2E7141_95FF_4802_BD94_7CD276561076_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh.AppNote.Utility.VersionInfo.dll8</td><td/><td/><td>_3C2A70A5_C815_47CD_B679_BDC23A922320_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote.dll</td><td/><td/><td>_634E8667_92E2_4372_952F_21C7E9FCD9B5_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote.dll1</td><td/><td/><td>_6DA8FC7E_DAEB_4CBE_8F46_1A15C984CFBB_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote.dll2</td><td/><td/><td>_40BFDE93_2DEF_4C17_A23E_DB6C37FACFD6_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote.dll3</td><td/><td/><td>_E6019D14_A14C_45DF_A2FB_9438D38B1CCD_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote.dll4</td><td/><td/><td>_449A9A1A_FE8E_4086_8F6A_7C98650CC8F2_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote.dll5</td><td/><td/><td>_EAB8F7B9_28A9_496A_B900_52AEEEB1DBEC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote.dll6</td><td/><td/><td>_E174E6A2_5431_431F_8507_A326F0903D29_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote.dll7</td><td/><td/><td>_8ECD3769_A38B_4BE9_A90F_D0B5FC5E885D_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote.dll8</td><td/><td/><td>_BA7D33BE_5D92_4B5F_8F3A_14C7910D7C1A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Adapt.dll</td><td/><td/><td>_2175E055_E1C1_4009_A192_D3B4B2063F59_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Adapt.dll1</td><td/><td/><td>_D9C46DED_58CA_4EBE_8817_3C087FF90265_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Adapt.dll2</td><td/><td/><td>_CA182E9F_B4E6_4539_BF20_209E76501861_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Adapt.dll3</td><td/><td/><td>_BD98AB7E_75E8_4A65_9DF0_5FA713008E86_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Adapt.dll4</td><td/><td/><td>_A98248E6_C7B4_4453_B2DB_4AE1FADC44D6_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Adapt.dll5</td><td/><td/><td>_9599DE63_4316_4597_B7AF_F07F2AFEA5ED_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Adapt.dll6</td><td/><td/><td>_C3EC8E58_C255_4101_86A3_CA5D902C665A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Adapt.dll7</td><td/><td/><td>_B15CBA17_12DD_4001_8EF8_E94B278B76B3_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Adapt.dll8</td><td/><td/><td>_66997FD4_ADDD_485B_9B7A_8E64699A655A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DSP.dll</td><td/><td/><td>_C03D9A12_309B_4EB4_9451_28771C1B4D15_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DSP.dll1</td><td/><td/><td>_A333BCFF_FBB5_4EF6_8E44_1DB199B3861C_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DSP.dll2</td><td/><td/><td>_532BC135_3FD2_49CA_9899_9459BC7DA350_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DSP.dll3</td><td/><td/><td>_669A1168_0CA7_4C73_97D6_2586597D3E18_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DSP.dll4</td><td/><td/><td>_56D33303_47D6_4551_A2A9_5AD458088CEF_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DSP.dll5</td><td/><td/><td>_461766DA_7B1F_472B_AEF3_05E952CD964B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DSP.dll6</td><td/><td/><td>_7725BBA3_92F6_4E8A_B206_2129662550DF_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DSP.dll7</td><td/><td/><td>_1AEA4EEB_D9D5_4CE2_AF21_6B467908D1DE_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DSP.dll8</td><td/><td/><td>_BF6F6252_F7D8_4736_9B2F_F0C6FBBE2C50_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DotNow.dll</td><td/><td/><td>_E1097F7E_FCA4_4AAA_BB61_7C04EE7BF5F4_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DotNow.dll1</td><td/><td/><td>_52375B44_F622_40EF_B519_4AFA88C3765B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DotNow.dll10</td><td/><td/><td>_7B9CF778_D722_4D76_8F72_9E7310947ED7_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DotNow.dll2</td><td/><td/><td>_9C1DDC0A_4954_4458_BB6B_0D2A0ECF6033_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DotNow.dll3</td><td/><td/><td>_AC0CAA75_B30D_429C_A4D1_45D6E0870EAF_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DotNow.dll4</td><td/><td/><td>_243F454E_5B58_4F91_A9AD_A23A781556ED_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DotNow.dll5</td><td/><td/><td>_CA2DA845_11D7_4388_92F4_806E332046FC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DotNow.dll6</td><td/><td/><td>_1FBC8C46_31E3_4BB7_A6AB_7274E3A15BB6_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DotNow.dll7</td><td/><td/><td>_EF9F37A0_CB3B_46B1_808F_DFF2FD9161B5_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DotNow.dll8</td><td/><td/><td>_764DB457_6C4C_49E4_BEDC_26485A2A6D8D_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_DotNow.dll9</td><td/><td/><td>_D6E6ECF6_C9FD_47C8_9F94_B1FA465EBE12_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Kiwi.dll</td><td/><td/><td>_54C01931_1FD9_4DD4_AE77_FA9DD81A8235_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Kiwi.dll1</td><td/><td/><td>_4FBA4119_F30F_4BC1_AAC5_C8A8B30EDF76_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Kiwi.dll2</td><td/><td/><td>_7810BF08_82CD_458C_92FE_144285ACD981_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Kiwi.dll3</td><td/><td/><td>_9B091588_42DC_40A2_9FCC_A3337AE47231_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Kiwi.dll4</td><td/><td/><td>_090E7B6A_A843_404D_8142_20FB9386ABAD_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Kiwi.dll5</td><td/><td/><td>_0049F0C5_6D52_4A13_B011_B8A702B61F1D_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Kiwi.dll6</td><td/><td/><td>_3BF66B37_9662_4787_8E64_BB34D620D022_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Kiwi.dll7</td><td/><td/><td>_2FD48009_8575_4BE2_ADE4_14905951341B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Kiwi.dll8</td><td/><td/><td>_C104FC97_A61D_4C76_913C_4C2E28B6CC33_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Net.dll</td><td/><td/><td>_F6B9961D_95F9_4927_80AE_89EA4B5E49B4_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Net.dll1</td><td/><td/><td>_BF352278_B14C_4FD7_8552_1AD1848A43EF_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Net.dll10</td><td/><td/><td>_04985CB0_79D6_4AC4_A896_70E7B8054276_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Net.dll2</td><td/><td/><td>_4862FBB4_FDD3_4DCB_865E_7A3842889C00_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Net.dll3</td><td/><td/><td>_7DC74970_489B_4887_96AC_952E812E553E_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Net.dll4</td><td/><td/><td>_EEA701A9_735D_425E_AFD9_6C81D8C47FAB_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Net.dll5</td><td/><td/><td>_9CC66023_4CF1_4817_82D8_DBA5DBB48298_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Net.dll6</td><td/><td/><td>_20850289_C14B_41B3_B171_F4588CFE7B4A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Net.dll7</td><td/><td/><td>_6F176F32_6FDC_4F3C_A3C3_8F465171A30A_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Net.dll8</td><td/><td/><td>_B842CF8F_9092_414B_9E95_A4B3158293E0_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_Net.dll9</td><td/><td/><td>_93BD0381_E5B7_4198_8AD8_D4EC66536CAF_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_RealTime.dll</td><td/><td/><td>_8C268AB3_5F5B_4F60_A823_B3D0C5804CB4_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_RealTime.dll1</td><td/><td/><td>_33E7C560_14DC_40A7_84DC_0D355053E8D8_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_RealTime.dll2</td><td/><td/><td>_F33D422C_04F5_4ECB_B3F0_25C9516ADBB3_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_RealTime.dll3</td><td/><td/><td>_1CF22925_84D2_47EC_B9D3_ED2E8E5152DC_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_RealTime.dll4</td><td/><td/><td>_F76501D2_C099_47C0_AB4F_D1832D27D348_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_RealTime.dll5</td><td/><td/><td>_9D25A452_538F_4310_9F0A_3E6E71CF88B3_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_RealTime.dll6</td><td/><td/><td>_D07AE435_B74F_47C6_8E82_74B7C92B8824_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_RealTime.dll7</td><td/><td/><td>_778B54B4_9C88_4A9F_9DDD_5C2D7B4EB144_FILTER</td><td/><td/><td/><td/></row>
		<row><td>Samraksh_eMote_RealTime.dll8</td><td/><td/><td>_BA9AC099_0C84_4683_8466_88A220D31618_FILTER</td><td/><td/><td/><td/></row>
		<row><td>TestEnhancedeMoteLCD.exe</td><td/><td/><td>_84547D8A_59C6_4618_9C8F_26740B06ECE5_FILTER</td><td/><td/><td/><td/></row>
		<row><td>TestEnhancedeMoteLCD.exe1</td><td/><td/><td>_35F115EB_7D5E_4A72_A70B_A72148BA140B_FILTER</td><td/><td/><td/><td/></row>
		<row><td>TestEnhancedeMoteLCD.exe2</td><td/><td/><td>_C68FE334_3C14_41D7_87BE_88C77F8649E2_FILTER</td><td/><td/><td/><td/></row>
		<row><td>TestEnhancedeMoteLCD.exe3</td><td/><td/><td>_E0169B8D_6F31_4108_AE80_0C6D2C7D3385_FILTER</td><td/><td/><td/><td/></row>
		<row><td>TestEnhancedeMoteLCD.exe4</td><td/><td/><td>_B78F141A_DE20_4012_B2EA_18DFAC41A58D_FILTER</td><td/><td/><td/><td/></row>
		<row><td>TestEnhancedeMoteLCD.exe5</td><td/><td/><td>_4C1C8AD1_F87F_45BA_A156_9BF2B53B8E51_FILTER</td><td/><td/><td/><td/></row>
		<row><td>TestEnhancedeMoteLCD.exe6</td><td/><td/><td>_A77A3E29_35F6_4D05_99B3_F039D896D236_FILTER</td><td/><td/><td/><td/></row>
	</table>

	<table name="ISCustomActionReference">
		<col key="yes" def="s72">Action_</col>
		<col def="S0">Description</col>
		<col def="S255">FileType</col>
		<col def="S255">ISCAReferenceFilePath</col>
	</table>

	<table name="ISDIMDependency">
		<col key="yes" def="s72">ISDIMReference_</col>
		<col def="s255">RequiredUUID</col>
		<col def="S255">RequiredMajorVersion</col>
		<col def="S255">RequiredMinorVersion</col>
		<col def="S255">RequiredBuildVersion</col>
		<col def="S255">RequiredRevisionVersion</col>
	</table>

	<table name="ISDIMReference">
		<col key="yes" def="s72">ISDIMReference</col>
		<col def="S0">ISBuildSourcePath</col>
	</table>

	<table name="ISDIMReferenceDependencies">
		<col key="yes" def="s72">ISDIMReference_Parent</col>
		<col key="yes" def="s72">ISDIMDependency_</col>
	</table>

	<table name="ISDIMVariable">
		<col key="yes" def="s72">ISDIMVariable</col>
		<col def="s72">ISDIMReference_</col>
		<col def="s0">Name</col>
		<col def="S0">NewValue</col>
		<col def="I4">Type</col>
	</table>

	<table name="ISDLLWrapper">
		<col key="yes" def="s72">EntryPoint</col>
		<col def="I4">Type</col>
		<col def="s0">Source</col>
		<col def="s255">Target</col>
	</table>

	<table name="ISDependency">
		<col key="yes" def="S50">ISDependency</col>
		<col def="I2">Exclude</col>
	</table>

	<table name="ISDisk1File">
		<col key="yes" def="s72">ISDisk1File</col>
		<col def="s255">ISBuildSourcePath</col>
		<col def="I4">Disk</col>
	</table>

	<table name="ISDynamicFile">
		<col key="yes" def="s72">Component_</col>
		<col key="yes" def="s255">SourceFolder</col>
		<col def="I2">IncludeFlags</col>
		<col def="S0">IncludeFiles</col>
		<col def="S0">ExcludeFiles</col>
		<col def="I4">ISAttributes</col>
	</table>

	<table name="ISFeatureDIMReferences">
		<col key="yes" def="s38">Feature_</col>
		<col key="yes" def="s72">ISDIMReference_</col>
	</table>

	<table name="ISFeatureMergeModuleExcludes">
		<col key="yes" def="s38">Feature_</col>
		<col key="yes" def="s255">ModuleID</col>
		<col key="yes" def="i2">Language</col>
	</table>

	<table name="ISFeatureMergeModules">
		<col key="yes" def="s38">Feature_</col>
		<col key="yes" def="s255">ISMergeModule_</col>
		<col key="yes" def="i2">Language_</col>
	</table>

	<table name="ISFeatureSetupPrerequisites">
		<col key="yes" def="s38">Feature_</col>
		<col key="yes" def="s72">ISSetupPrerequisites_</col>
	</table>

	<table name="ISFileManifests">
		<col key="yes" def="s72">File_</col>
		<col key="yes" def="s72">Manifest_</col>
	</table>

	<table name="ISIISItem">
		<col key="yes" def="s72">ISIISItem</col>
		<col def="S72">ISIISItem_Parent</col>
		<col def="L255">DisplayName</col>
		<col def="i4">Type</col>
		<col def="S72">Component_</col>
	</table>

	<table name="ISIISProperty">
		<col key="yes" def="s72">ISIISProperty</col>
		<col key="yes" def="s72">ISIISItem_</col>
		<col def="S0">Schema</col>
		<col def="S255">FriendlyName</col>
		<col def="I4">MetaDataProp</col>
		<col def="I4">MetaDataType</col>
		<col def="I4">MetaDataUserType</col>
		<col def="I4">MetaDataAttributes</col>
		<col def="L0">MetaDataValue</col>
		<col def="I4">Order</col>
		<col def="I4">ISAttributes</col>
	</table>

	<table name="ISInstallScriptAction">
		<col key="yes" def="s72">EntryPoint</col>
		<col def="I4">Type</col>
		<col def="s72">Source</col>
		<col def="S255">Target</col>
	</table>

	<table name="ISLanguage">
		<col key="yes" def="s50">ISLanguage</col>
		<col def="I2">Included</col>
		<row><td>1033</td><td>1</td></row>
	</table>

	<table name="ISLinkerLibrary">
		<col key="yes" def="s72">ISLinkerLibrary</col>
		<col def="s255">Library</col>
		<col def="i4">Order</col>
		<row><td>isrt.obl</td><td>isrt.obl</td><td>2</td></row>
		<row><td>iswi.obl</td><td>iswi.obl</td><td>1</td></row>
	</table>

	<table name="ISLocalControl">
		<col key="yes" def="s72">Dialog_</col>
		<col key="yes" def="s50">Control_</col>
		<col key="yes" def="s50">ISLanguage_</col>
		<col def="I4">Attributes</col>
		<col def="I2">X</col>
		<col def="I2">Y</col>
		<col def="I2">Width</col>
		<col def="I2">Height</col>
		<col def="S72">Binary_</col>
		<col def="S255">ISBuildSourcePath</col>
	</table>

	<table name="ISLocalDialog">
		<col key="yes" def="S50">Dialog_</col>
		<col key="yes" def="S50">ISLanguage_</col>
		<col def="I4">Attributes</col>
		<col def="S72">TextStyle_</col>
		<col def="i2">Width</col>
		<col def="i2">Height</col>
	</table>

	<table name="ISLocalRadioButton">
		<col key="yes" def="s72">Property</col>
		<col key="yes" def="i2">Order</col>
		<col key="yes" def="s50">ISLanguage_</col>
		<col def="i2">X</col>
		<col def="i2">Y</col>
		<col def="i2">Width</col>
		<col def="i2">Height</col>
	</table>

	<table name="ISLockPermissions">
		<col key="yes" def="s72">LockObject</col>
		<col key="yes" def="s32">Table</col>
		<col key="yes" def="S255">Domain</col>
		<col key="yes" def="s255">User</col>
		<col def="I4">Permission</col>
		<col def="I4">Attributes</col>
	</table>

	<table name="ISLogicalDisk">
		<col key="yes" def="i2">DiskId</col>
		<col key="yes" def="s255">ISProductConfiguration_</col>
		<col key="yes" def="s255">ISRelease_</col>
		<col def="i2">LastSequence</col>
		<col def="L64">DiskPrompt</col>
		<col def="S255">Cabinet</col>
		<col def="S32">VolumeLabel</col>
		<col def="S32">Source</col>
	</table>

	<table name="ISLogicalDiskFeatures">
		<col key="yes" def="i2">ISLogicalDisk_</col>
		<col key="yes" def="s255">ISProductConfiguration_</col>
		<col key="yes" def="s255">ISRelease_</col>
		<col key="yes" def="S38">Feature_</col>
		<col def="i2">Sequence</col>
		<col def="I4">ISAttributes</col>
	</table>

	<table name="ISMergeModule">
		<col key="yes" def="s255">ISMergeModule</col>
		<col key="yes" def="i2">Language</col>
		<col def="s255">Name</col>
		<col def="S255">Destination</col>
		<col def="I4">ISAttributes</col>
	</table>

	<table name="ISMergeModuleCfgValues">
		<col key="yes" def="s255">ISMergeModule_</col>
		<col key="yes" def="i2">Language_</col>
		<col key="yes" def="s72">ModuleConfiguration_</col>
		<col def="L0">Value</col>
		<col def="i2">Format</col>
		<col def="L255">Type</col>
		<col def="L255">ContextData</col>
		<col def="L255">DefaultValue</col>
		<col def="I2">Attributes</col>
		<col def="L255">DisplayName</col>
		<col def="L255">Description</col>
		<col def="L255">HelpLocation</col>
		<col def="L255">HelpKeyword</col>
	</table>

	<table name="ISObject">
		<col key="yes" def="s50">ObjectName</col>
		<col def="s15">Language</col>
	</table>

	<table name="ISObjectProperty">
		<col key="yes" def="S50">ObjectName</col>
		<col key="yes" def="S50">Property</col>
		<col def="S0">Value</col>
		<col def="I2">IncludeInBuild</col>
	</table>

	<table name="ISPatchConfigImage">
		<col key="yes" def="S72">PatchConfiguration_</col>
		<col key="yes" def="s72">UpgradedImage_</col>
	</table>

	<table name="ISPatchConfiguration">
		<col key="yes" def="s72">Name</col>
		<col def="i2">CanPCDiffer</col>
		<col def="i2">CanPVDiffer</col>
		<col def="i2">IncludeWholeFiles</col>
		<col def="i2">LeaveDecompressed</col>
		<col def="i2">OptimizeForSize</col>
		<col def="i2">EnablePatchCache</col>
		<col def="S0">PatchCacheDir</col>
		<col def="i4">Flags</col>
		<col def="S0">PatchGuidsToReplace</col>
		<col def="s0">TargetProductCodes</col>
		<col def="s50">PatchGuid</col>
		<col def="s0">OutputPath</col>
		<col def="i2">MinMsiVersion</col>
		<col def="I4">Attributes</col>
	</table>

	<table name="ISPatchConfigurationProperty">
		<col key="yes" def="S72">ISPatchConfiguration_</col>
		<col key="yes" def="S50">Property</col>
		<col def="S50">Value</col>
	</table>

	<table name="ISPatchExternalFile">
		<col key="yes" def="s50">Name</col>
		<col key="yes" def="s13">ISUpgradedImage_</col>
		<col def="s72">FileKey</col>
		<col def="s255">FilePath</col>
	</table>

	<table name="ISPatchWholeFile">
		<col key="yes" def="s50">UpgradedImage</col>
		<col key="yes" def="s72">FileKey</col>
		<col def="S72">Component</col>
	</table>

	<table name="ISPathVariable">
		<col key="yes" def="s72">ISPathVariable</col>
		<col def="S255">Value</col>
		<col def="S255">TestValue</col>
		<col def="i4">Type</col>
		<row><td>CommonFilesFolder</td><td/><td/><td>1</td></row>
		<row><td>ISPROJECTDIR</td><td/><td/><td>1</td></row>
		<row><td>ISProductFolder</td><td/><td/><td>1</td></row>
		<row><td>ISProjectDataFolder</td><td/><td/><td>1</td></row>
		<row><td>ISProjectFolder</td><td/><td/><td>1</td></row>
		<row><td>ProgramFilesFolder</td><td/><td/><td>1</td></row>
		<row><td>SystemFolder</td><td/><td/><td>1</td></row>
		<row><td>WindowsFolder</td><td/><td/><td>1</td></row>
	</table>

	<table name="ISProductConfiguration">
		<col key="yes" def="s72">ISProductConfiguration</col>
		<col def="S255">ProductConfigurationFlags</col>
		<col def="I4">GeneratePackageCode</col>
		<row><td>Express</td><td/><td>1</td></row>
	</table>

	<table name="ISProductConfigurationInstance">
		<col key="yes" def="s72">ISProductConfiguration_</col>
		<col key="yes" def="i2">InstanceId</col>
		<col key="yes" def="s72">Property</col>
		<col def="s255">Value</col>
	</table>

	<table name="ISProductConfigurationProperty">
		<col key="yes" def="s72">ISProductConfiguration_</col>
		<col key="yes" def="s72">Property</col>
		<col def="L255">Value</col>
	</table>

	<table name="ISRelease">
		<col key="yes" def="s72">ISRelease</col>
		<col key="yes" def="s72">ISProductConfiguration_</col>
		<col def="s255">BuildLocation</col>
		<col def="s255">PackageName</col>
		<col def="i4">Type</col>
		<col def="s0">SupportedLanguagesUI</col>
		<col def="i4">MsiSourceType</col>
		<col def="i4">ReleaseType</col>
		<col def="s72">Platforms</col>
		<col def="S0">SupportedLanguagesData</col>
		<col def="s6">DefaultLanguage</col>
		<col def="i4">SupportedOSs</col>
		<col def="s50">DiskSize</col>
		<col def="i4">DiskSizeUnit</col>
		<col def="i4">DiskClusterSize</col>
		<col def="S0">ReleaseFlags</col>
		<col def="i4">DiskSpanning</col>
		<col def="S255">SynchMsi</col>
		<col def="s255">MediaLocation</col>
		<col def="S255">URLLocation</col>
		<col def="S255">DigitalURL</col>
		<col def="S255">DigitalPVK</col>
		<col def="S255">DigitalSPC</col>
		<col def="S255">Password</col>
		<col def="S255">VersionCopyright</col>
		<col def="i4">Attributes</col>
		<col def="S255">CDBrowser</col>
		<col def="S255">DotNetBuildConfiguration</col>
		<col def="S255">MsiCommandLine</col>
		<col def="I4">ISSetupPrerequisiteLocation</col>
		<row><td>CD_ROM</td><td>Express</td><td>&lt;ISProjectDataFolder&gt;</td><td>Default</td><td>0</td><td>1033</td><td>0</td><td>2</td><td>Intel</td><td/><td>1033</td><td>0</td><td>650</td><td>0</td><td>2048</td><td/><td>0</td><td/><td>MediaLocation</td><td/><td>http://</td><td/><td/><td/><td/><td>75805</td><td/><td/><td/><td>3</td></row>
		<row><td>Custom</td><td>Express</td><td>&lt;ISProjectDataFolder&gt;</td><td>Default</td><td>2</td><td>1033</td><td>0</td><td>2</td><td>Intel</td><td/><td>1033</td><td>0</td><td>100</td><td>0</td><td>1024</td><td/><td>0</td><td/><td>MediaLocation</td><td/><td>http://</td><td/><td/><td/><td/><td>75805</td><td/><td/><td/><td>3</td></row>
		<row><td>DVD-10</td><td>Express</td><td>&lt;ISProjectDataFolder&gt;</td><td>Default</td><td>3</td><td>1033</td><td>0</td><td>2</td><td>Intel</td><td/><td>1033</td><td>0</td><td>8.75</td><td>1</td><td>2048</td><td/><td>0</td><td/><td>MediaLocation</td><td/><td>http://</td><td/><td/><td/><td/><td>75805</td><td/><td/><td/><td>3</td></row>
		<row><td>DVD-18</td><td>Express</td><td>&lt;ISProjectDataFolder&gt;</td><td>Default</td><td>3</td><td>1033</td><td>0</td><td>2</td><td>Intel</td><td/><td>1033</td><td>0</td><td>15.83</td><td>1</td><td>2048</td><td/><td>0</td><td/><td>MediaLocation</td><td/><td>http://</td><td/><td/><td/><td/><td>75805</td><td/><td/><td/><td>3</td></row>
		<row><td>DVD-5</td><td>Express</td><td>&lt;ISProjectDataFolder&gt;</td><td>Default</td><td>3</td><td>1033</td><td>0</td><td>2</td><td>Intel</td><td/><td>1033</td><td>0</td><td>4.38</td><td>1</td><td>2048</td><td/><td>0</td><td/><td>MediaLocation</td><td/><td>http://</td><td/><td/><td/><td/><td>75805</td><td/><td/><td/><td>3</td></row>
		<row><td>DVD-9</td><td>Express</td><td>&lt;ISProjectDataFolder&gt;</td><td>Default</td><td>3</td><td>1033</td><td>0</td><td>2</td><td>Intel</td><td/><td>1033</td><td>0</td><td>7.95</td><td>1</td><td>2048</td><td/><td>0</td><td/><td>MediaLocation</td><td/><td>http://</td><td/><td/><td/><td/><td>75805</td><td/><td/><td/><td>3</td></row>
		<row><td>SingleImage</td><td>Express</td><td>&lt;ISProjectDataFolder&gt;</td><td>PackageName</td><td>1</td><td>1033</td><td>0</td><td>1</td><td>Intel</td><td/><td>1033</td><td>0</td><td>0</td><td>0</td><td>0</td><td/><td>0</td><td/><td>MediaLocation</td><td/><td>http://</td><td/><td/><td/><td/><td>108573</td><td/><td/><td/><td>3</td></row>
		<row><td>WebDeployment</td><td>Express</td><td>&lt;ISProjectDataFolder&gt;</td><td>PackageName</td><td>4</td><td>1033</td><td>2</td><td>1</td><td>Intel</td><td/><td>1033</td><td>0</td><td>0</td><td>0</td><td>0</td><td/><td>0</td><td/><td>MediaLocation</td><td/><td>http://</td><td/><td/><td/><td/><td>124941</td><td/><td/><td/><td>3</td></row>
	</table>

	<table name="ISReleaseASPublishInfo">
		<col key="yes" def="s72">ISRelease_</col>
		<col key="yes" def="s72">ISProductConfiguration_</col>
		<col key="yes" def="S0">Property</col>
		<col def="S0">Value</col>
	</table>

	<table name="ISReleaseExtended">
		<col key="yes" def="s72">ISRelease_</col>
		<col key="yes" def="s72">ISProductConfiguration_</col>
		<col def="I4">WebType</col>
		<col def="S255">WebURL</col>
		<col def="I4">WebCabSize</col>
		<col def="S255">OneClickCabName</col>
		<col def="S255">OneClickHtmlName</col>
		<col def="S255">WebLocalCachePath</col>
		<col def="I4">EngineLocation</col>
		<col def="S255">Win9xMsiUrl</col>
		<col def="S255">WinNTMsiUrl</col>
		<col def="I4">ISEngineLocation</col>
		<col def="S255">ISEngineURL</col>
		<col def="I4">OneClickTargetBrowser</col>
		<col def="S255">DigitalCertificateIdNS</col>
		<col def="S255">DigitalCertificateDBaseNS</col>
		<col def="S255">DigitalCertificatePasswordNS</col>
		<col def="I4">DotNetRedistLocation</col>
		<col def="S255">DotNetRedistURL</col>
		<col def="I4">DotNetVersion</col>
		<col def="S255">DotNetBaseLanguage</col>
		<col def="S0">DotNetLangaugePacks</col>
		<col def="S255">DotNetFxCmdLine</col>
		<col def="S255">DotNetLangPackCmdLine</col>
		<col def="S50">JSharpCmdLine</col>
		<col def="I4">Attributes</col>
		<col def="I4">JSharpRedistLocation</col>
		<col def="I4">MsiEngineVersion</col>
		<col def="S255">WinMsi30Url</col>
		<col def="S255">CertPassword</col>
		<row><td>CD_ROM</td><td>Express</td><td>0</td><td>http://</td><td>0</td><td>install</td><td>install</td><td>[LocalAppDataFolder]Downloaded Installations</td><td>0</td><td>http://www.installengine.com/Msiengine20</td><td>http://www.installengine.com/Msiengine20</td><td>0</td><td>http://www.installengine.com/cert05/isengine</td><td>0</td><td/><td/><td/><td>3</td><td>http://www.installengine.com/cert05/dotnetfx</td><td>0</td><td>1033</td><td/><td/><td/><td/><td/><td>3</td><td/><td>http://www.installengine.com/Msiengine30</td><td/></row>
		<row><td>Custom</td><td>Express</td><td>0</td><td>http://</td><td>0</td><td>install</td><td>install</td><td>[LocalAppDataFolder]Downloaded Installations</td><td>0</td><td>http://www.installengine.com/Msiengine20</td><td>http://www.installengine.com/Msiengine20</td><td>0</td><td>http://www.installengine.com/cert05/isengine</td><td>0</td><td/><td/><td/><td>3</td><td>http://www.installengine.com/cert05/dotnetfx</td><td>0</td><td>1033</td><td/><td/><td/><td/><td/><td>3</td><td/><td>http://www.installengine.com/Msiengine30</td><td/></row>
		<row><td>DVD-10</td><td>Express</td><td>0</td><td>http://</td><td>0</td><td>install</td><td>install</td><td>[LocalAppDataFolder]Downloaded Installations</td><td>0</td><td>http://www.installengine.com/Msiengine20</td><td>http://www.installengine.com/Msiengine20</td><td>0</td><td>http://www.installengine.com/cert05/isengine</td><td>0</td><td/><td/><td/><td>3</td><td>http://www.installengine.com/cert05/dotnetfx</td><td>0</td><td>1033</td><td/><td/><td/><td/><td/><td>3</td><td/><td>http://www.installengine.com/Msiengine30</td><td/></row>
		<row><td>DVD-18</td><td>Express</td><td>0</td><td>http://</td><td>0</td><td>install</td><td>install</td><td>[LocalAppDataFolder]Downloaded Installations</td><td>0</td><td>http://www.installengine.com/Msiengine20</td><td>http://www.installengine.com/Msiengine20</td><td>0</td><td>http://www.installengine.com/cert05/isengine</td><td>0</td><td/><td/><td/><td>3</td><td>http://www.installengine.com/cert05/dotnetfx</td><td>0</td><td>1033</td><td/><td/><td/><td/><td/><td>3</td><td/><td>http://www.installengine.com/Msiengine30</td><td/></row>
		<row><td>DVD-5</td><td>Express</td><td>0</td><td>http://</td><td>0</td><td>install</td><td>install</td><td>[LocalAppDataFolder]Downloaded Installations</td><td>0</td><td>http://www.installengine.com/Msiengine20</td><td>http://www.installengine.com/Msiengine20</td><td>0</td><td>http://www.installengine.com/cert05/isengine</td><td>0</td><td/><td/><td/><td>3</td><td>http://www.installengine.com/cert05/dotnetfx</td><td>0</td><td>1033</td><td/><td/><td/><td/><td/><td>3</td><td/><td>http://www.installengine.com/Msiengine30</td><td/></row>
		<row><td>DVD-9</td><td>Express</td><td>0</td><td>http://</td><td>0</td><td>install</td><td>install</td><td>[LocalAppDataFolder]Downloaded Installations</td><td>0</td><td>http://www.installengine.com/Msiengine20</td><td>http://www.installengine.com/Msiengine20</td><td>0</td><td>http://www.installengine.com/cert05/isengine</td><td>0</td><td/><td/><td/><td>3</td><td>http://www.installengine.com/cert05/dotnetfx</td><td>0</td><td>1033</td><td/><td/><td/><td/><td/><td>3</td><td/><td>http://www.installengine.com/Msiengine30</td><td/></row>
		<row><td>SingleImage</td><td>Express</td><td>0</td><td>http://</td><td>0</td><td>install</td><td>install</td><td>[LocalAppDataFolder]Downloaded Installations</td><td>1</td><td>http://www.installengine.com/Msiengine20</td><td>http://www.installengine.com/Msiengine20</td><td>0</td><td>http://www.installengine.com/cert05/isengine</td><td>0</td><td/><td/><td/><td>3</td><td>http://www.installengine.com/cert05/dotnetfx</td><td>0</td><td>1033</td><td/><td/><td/><td/><td/><td>3</td><td/><td>http://www.installengine.com/Msiengine30</td><td/></row>
		<row><td>WebDeployment</td><td>Express</td><td>0</td><td>http://</td><td>0</td><td>setup</td><td>Default</td><td>[LocalAppDataFolder]Downloaded Installations</td><td>2</td><td>http://www.Installengine.com/Msiengine20</td><td>http://www.Installengine.com/Msiengine20</td><td>0</td><td>http://www.installengine.com/cert05/isengine</td><td>0</td><td/><td/><td/><td>3</td><td>http://www.installengine.com/cert05/dotnetfx</td><td>0</td><td>1033</td><td/><td/><td/><td/><td/><td>3</td><td/><td>http://www.installengine.com/Msiengine30</td><td/></row>
	</table>

	<table name="ISReleaseProperty">
		<col key="yes" def="s72">ISRelease_</col>
		<col key="yes" def="s72">ISProductConfiguration_</col>
		<col key="yes" def="s72">Name</col>
		<col def="s0">Value</col>
	</table>

	<table name="ISReleasePublishInfo">
		<col key="yes" def="s72">ISRelease_</col>
		<col key="yes" def="s72">ISProductConfiguration_</col>
		<col def="S255">Repository</col>
		<col def="S255">DisplayName</col>
		<col def="S255">Publisher</col>
		<col def="S255">Description</col>
		<col def="I4">ISAttributes</col>
	</table>

	<table name="ISSQLConnection">
		<col key="yes" def="s72">ISSQLConnection</col>
		<col def="s255">Server</col>
		<col def="s255">Database</col>
		<col def="s255">UserName</col>
		<col def="s255">Password</col>
		<col def="s255">Authentication</col>
		<col def="i2">Attributes</col>
		<col def="i2">Order</col>
		<col def="S0">Comments</col>
		<col def="I4">CmdTimeout</col>
		<col def="S0">BatchSeparator</col>
		<col def="S0">ScriptVersion_Table</col>
		<col def="S0">ScriptVersion_Column</col>
	</table>

	<table name="ISSQLConnectionDBServer">
		<col key="yes" def="s72">ISSQLConnectionDBServer</col>
		<col key="yes" def="s72">ISSQLConnection_</col>
		<col key="yes" def="s72">ISSQLDBMetaData_</col>
		<col def="i2">Order</col>
	</table>

	<table name="ISSQLConnectionScript">
		<col key="yes" def="s72">ISSQLConnection_</col>
		<col key="yes" def="s72">ISSQLScriptFile_</col>
		<col def="i2">Order</col>
	</table>

	<table name="ISSQLDBMetaData">
		<col key="yes" def="s72">ISSQLDBMetaData</col>
		<col def="S0">DisplayName</col>
		<col def="S0">AdoDriverName</col>
		<col def="S0">AdoCxnDriver</col>
		<col def="S0">AdoCxnServer</col>
		<col def="S0">AdoCxnDatabase</col>
		<col def="S0">AdoCxnUserID</col>
		<col def="S0">AdoCxnPassword</col>
		<col def="S0">AdoCxnWindowsSecurity</col>
		<col def="S0">AdoCxnNetLibrary</col>
		<col def="S0">TestDatabaseCmd</col>
		<col def="S0">TestTableCmd</col>
		<col def="S0">VersionInfoCmd</col>
		<col def="S0">VersionBeginToken</col>
		<col def="S0">VersionEndToken</col>
		<col def="S0">LocalInstanceNames</col>
		<col def="S0">CreateDbCmd</col>
		<col def="S0">SwitchDbCmd</col>
		<col def="I4">ISAttributes</col>
		<col def="S0">TestTableCmd2</col>
		<col def="S0">WinAuthentUserId</col>
		<col def="S0">DsnODBCName</col>
		<col def="S0">AdoCxnPort</col>
		<col def="S0">AdoCxnAdditional</col>
		<col def="S0">QueryDatabasesCmd</col>
		<col def="S0">CreateTableCmd</col>
		<col def="S0">InsertRecordCmd</col>
		<col def="S0">SelectTableCmd</col>
		<col def="S0">ScriptVersion_Table</col>
		<col def="S0">ScriptVersion_Column</col>
		<col def="S0">ScriptVersion_ColumnType</col>
	</table>

	<table name="ISSQLRequirement">
		<col key="yes" def="s72">ISSQLRequirement</col>
		<col key="yes" def="s72">ISSQLConnection_</col>
		<col def="S15">MajorVersion</col>
		<col def="S25">ServicePackLevel</col>
		<col def="i4">Attributes</col>
		<col def="S72">ISSQLConnectionDBServer_</col>
	</table>

	<table name="ISSQLScriptError">
		<col key="yes" def="i4">ErrNumber</col>
		<col key="yes" def="S72">ISSQLScriptFile_</col>
		<col def="i2">ErrHandling</col>
		<col def="L255">Message</col>
		<col def="i2">Attributes</col>
	</table>

	<table name="ISSQLScriptFile">
		<col key="yes" def="s72">ISSQLScriptFile</col>
		<col def="s72">Component_</col>
		<col def="i2">Scheduling</col>
		<col def="L255">InstallText</col>
		<col def="L255">UninstallText</col>
		<col def="S0">ISBuildSourcePath</col>
		<col def="S0">Comments</col>
		<col def="i2">ErrorHandling</col>
		<col def="i2">Attributes</col>
		<col def="S255">Version</col>
		<col def="S255">Condition</col>
		<col def="S0">DisplayName</col>
	</table>

	<table name="ISSQLScriptImport">
		<col key="yes" def="s72">ISSQLScriptFile_</col>
		<col def="S255">Server</col>
		<col def="S255">Database</col>
		<col def="S255">UserName</col>
		<col def="S255">Password</col>
		<col def="i4">Authentication</col>
		<col def="S0">IncludeTables</col>
		<col def="S0">ExcludeTables</col>
		<col def="i4">Attributes</col>
	</table>

	<table name="ISSQLScriptReplace">
		<col key="yes" def="s72">ISSQLScriptReplace</col>
		<col key="yes" def="s72">ISSQLScriptFile_</col>
		<col def="S0">Search</col>
		<col def="S0">Replace</col>
		<col def="i4">Attributes</col>
	</table>

	<table name="ISScriptFile">
		<col key="yes" def="s255">ISScriptFile</col>
	</table>

	<table name="ISSelfReg">
		<col key="yes" def="s72">FileKey</col>
		<col def="I2">Cost</col>
		<col def="I2">Order</col>
		<col def="S50">CmdLine</col>
	</table>

	<table name="ISSetupFile">
		<col key="yes" def="s72">ISSetupFile</col>
		<col def="S255">FileName</col>
		<col def="V0">Stream</col>
		<col def="S50">Language</col>
		<col def="I2">Splash</col>
		<col def="S0">Path</col>
	</table>

	<table name="ISSetupPrerequisites">
		<col key="yes" def="s72">ISSetupPrerequisites</col>
		<col def="S255">ISBuildSourcePath</col>
		<col def="I2">Order</col>
		<col def="I2">ISSetupLocation</col>
		<col def="S255">ISReleaseFlags</col>
	</table>

	<table name="ISSetupType">
		<col key="yes" def="s38">ISSetupType</col>
		<col def="L255">Description</col>
		<col def="L255">Display_Name</col>
		<col def="i2">Display</col>
		<col def="S255">Comments</col>
		<row><td>Custom</td><td>##IDS__IsSetupTypeMinDlg_ChooseFeatures##</td><td>##IDS__IsSetupTypeMinDlg_Custom##</td><td>3</td><td/></row>
		<row><td>Minimal</td><td>##IDS__IsSetupTypeMinDlg_MinimumFeatures##</td><td>##IDS__IsSetupTypeMinDlg_Minimal##</td><td>2</td><td/></row>
		<row><td>Typical</td><td>##IDS__IsSetupTypeMinDlg_AllFeatures##</td><td>##IDS__IsSetupTypeMinDlg_Typical##</td><td>1</td><td/></row>
	</table>

	<table name="ISSetupTypeFeatures">
		<col key="yes" def="s38">ISSetupType_</col>
		<col key="yes" def="s38">Feature_</col>
		<row><td>Custom</td><td>AlwaysInstall</td></row>
		<row><td>Minimal</td><td>AlwaysInstall</td></row>
		<row><td>Typical</td><td>AlwaysInstall</td></row>
	</table>

	<table name="ISStorages">
		<col key="yes" def="s72">Name</col>
		<col def="S0">ISBuildSourcePath</col>
	</table>

	<table name="ISString">
		<col key="yes" def="s255">ISString</col>
		<col key="yes" def="s50">ISLanguage_</col>
		<col def="S0">Value</col>
		<col def="I2">Encoded</col>
		<col def="S0">Comment</col>
		<col def="I4">TimeStamp</col>
		<row><td>COMPANY_NAME</td><td>1033</td><td>Samraksh</td><td>0</td><td/><td>950326222</td></row>
		<row><td>DN_AlwaysInstall</td><td>1033</td><td>Always Install</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_EXPRESS_LAUNCH_CONDITION_COLOR</td><td>1033</td><td>The color settings of your system are not adequate for running [ProductName].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_EXPRESS_LAUNCH_CONDITION_OS</td><td>1033</td><td>The operating system is not adequate for running [ProductName].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_EXPRESS_LAUNCH_CONDITION_PROCESSOR</td><td>1033</td><td>The processor is not adequate for running [ProductName].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_EXPRESS_LAUNCH_CONDITION_RAM</td><td>1033</td><td>The amount of RAM is not adequate for running [ProductName].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_EXPRESS_LAUNCH_CONDITION_SCREEN</td><td>1033</td><td>The screen resolution is not adequate for running [ProductName].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_SETUPTYPE_COMPACT</td><td>1033</td><td>Compact</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_SETUPTYPE_COMPACT_DESC</td><td>1033</td><td>Compact Description</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_SETUPTYPE_COMPLETE</td><td>1033</td><td>Complete</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_SETUPTYPE_COMPLETE_DESC</td><td>1033</td><td>Complete</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_SETUPTYPE_CUSTOM</td><td>1033</td><td>Custom</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_SETUPTYPE_CUSTOM_DESC</td><td>1033</td><td>Custom Description</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_SETUPTYPE_CUSTOM_DESC_PRO</td><td>1033</td><td>Custom</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_SETUPTYPE_TYPICAL</td><td>1033</td><td>Typical</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDPROP_SETUPTYPE_TYPICAL_DESC</td><td>1033</td><td>Typical Description</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_1</td><td>1033</td><td>[1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_1b</td><td>1033</td><td>[1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_1c</td><td>1033</td><td>[1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_1d</td><td>1033</td><td>[1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Advertising</td><td>1033</td><td>Advertising application</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_AllocatingRegistry</td><td>1033</td><td>Allocating registry space</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_AppCommandLine</td><td>1033</td><td>Application: [1], Command line: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_AppId</td><td>1033</td><td>AppId: [1]{{, AppType: [2]}}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_AppIdAppTypeRSN</td><td>1033</td><td>AppId: [1]{{, AppType: [2], Users: [3], RSN: [4]}}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Application</td><td>1033</td><td>Application: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_BindingExes</td><td>1033</td><td>Binding executables</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_ClassId</td><td>1033</td><td>Class ID: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_ClsID</td><td>1033</td><td>Class ID: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_ComponentIDQualifier</td><td>1033</td><td>Component ID: [1], Qualifier: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_ComponentIdQualifier2</td><td>1033</td><td>Component ID: [1], Qualifier: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_ComputingSpace</td><td>1033</td><td>Computing space requirements</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_ComputingSpace2</td><td>1033</td><td>Computing space requirements</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_ComputingSpace3</td><td>1033</td><td>Computing space requirements</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_ContentTypeExtension</td><td>1033</td><td>MIME Content Type: [1], Extension: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_ContentTypeExtension2</td><td>1033</td><td>MIME Content Type: [1], Extension: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_CopyingNetworkFiles</td><td>1033</td><td>Copying files to the network</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_CopyingNewFiles</td><td>1033</td><td>Copying new files</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_CreatingDuplicate</td><td>1033</td><td>Creating duplicate files</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_CreatingFolders</td><td>1033</td><td>Creating folders</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_CreatingIISRoots</td><td>1033</td><td>Creating IIS Virtual Roots...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_CreatingShortcuts</td><td>1033</td><td>Creating shortcuts</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_DeletingServices</td><td>1033</td><td>Deleting services</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_EnvironmentStrings</td><td>1033</td><td>Updating environment strings</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_EvaluateLaunchConditions</td><td>1033</td><td>Evaluating launch conditions</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Extension</td><td>1033</td><td>Extension: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Extension2</td><td>1033</td><td>Extension: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Feature</td><td>1033</td><td>Feature: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FeatureColon</td><td>1033</td><td>Feature: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_File</td><td>1033</td><td>File: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_File2</td><td>1033</td><td>File: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FileDependencies</td><td>1033</td><td>File: [1],  Dependencies: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FileDir</td><td>1033</td><td>File: [1], Directory: [9]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FileDir2</td><td>1033</td><td>File: [1], Directory: [9]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FileDir3</td><td>1033</td><td>File: [1], Directory: [9]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FileDirSize</td><td>1033</td><td>File: [1], Directory: [9], Size: [6]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FileDirSize2</td><td>1033</td><td>File: [1],  Directory: [9],  Size: [6]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FileDirSize3</td><td>1033</td><td>File: [1],  Directory: [9],  Size: [6]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FileDirSize4</td><td>1033</td><td>File: [1],  Directory: [2],  Size: [3]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FileDirectorySize</td><td>1033</td><td>File: [1],  Directory: [9],  Size: [6]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FileFolder</td><td>1033</td><td>File: [1], Folder: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FileFolder2</td><td>1033</td><td>File: [1], Folder: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FileSectionKeyValue</td><td>1033</td><td>File: [1],  Section: [2],  Key: [3], Value: [4]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FileSectionKeyValue2</td><td>1033</td><td>File: [1],  Section: [2],  Key: [3], Value: [4]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Folder</td><td>1033</td><td>Folder: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Folder1</td><td>1033</td><td>Folder: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Font</td><td>1033</td><td>Font: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Font2</td><td>1033</td><td>Font: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FoundApp</td><td>1033</td><td>Found application: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_FreeSpace</td><td>1033</td><td>Free space: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_GeneratingScript</td><td>1033</td><td>Generating script operations for action:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_ISLockPermissionsCost</td><td>1033</td><td>Gathering permissions information for objects...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_ISLockPermissionsInstall</td><td>1033</td><td>Applying permissions information for objects...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_InitializeODBCDirs</td><td>1033</td><td>Initializing ODBC directories</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_InstallODBC</td><td>1033</td><td>Installing ODBC components</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_InstallServices</td><td>1033</td><td>Installing new services</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_InstallingSystemCatalog</td><td>1033</td><td>Installing system catalog</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_KeyName</td><td>1033</td><td>Key: [1], Name: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_KeyNameValue</td><td>1033</td><td>Key: [1], Name: [2], Value: [3]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_LibId</td><td>1033</td><td>LibID: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Libid2</td><td>1033</td><td>LibID: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_MigratingFeatureStates</td><td>1033</td><td>Migrating feature states from related applications</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_MovingFiles</td><td>1033</td><td>Moving files</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_NameValueAction</td><td>1033</td><td>Name: [1], Value: [2], Action [3]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_NameValueAction2</td><td>1033</td><td>Name: [1], Value: [2], Action [3]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_PatchingFiles</td><td>1033</td><td>Patching files</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_ProgID</td><td>1033</td><td>ProgID: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_ProgID2</td><td>1033</td><td>ProgID: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_PropertySignature</td><td>1033</td><td>Property: [1], Signature: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_PublishProductFeatures</td><td>1033</td><td>Publishing product features</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_PublishProductInfo</td><td>1033</td><td>Publishing product information</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_PublishingQualifiedComponents</td><td>1033</td><td>Publishing qualified components</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RegUser</td><td>1033</td><td>Registering user</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RegisterClassServer</td><td>1033</td><td>Registering class servers</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RegisterExtensionServers</td><td>1033</td><td>Registering extension servers</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RegisterFonts</td><td>1033</td><td>Registering fonts</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RegisterMimeInfo</td><td>1033</td><td>Registering MIME info</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RegisterTypeLibs</td><td>1033</td><td>Registering type libraries</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RegisteringComPlus</td><td>1033</td><td>Registering COM+ Applications and Components</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RegisteringModules</td><td>1033</td><td>Registering modules</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RegisteringProduct</td><td>1033</td><td>Registering product</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RegisteringProgIdentifiers</td><td>1033</td><td>Registering program identifiers</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RemoveApps</td><td>1033</td><td>Removing applications</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RemovingBackup</td><td>1033</td><td>Removing backup files</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RemovingDuplicates</td><td>1033</td><td>Removing duplicated files</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RemovingFiles</td><td>1033</td><td>Removing files</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RemovingFolders</td><td>1033</td><td>Removing folders</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RemovingIISRoots</td><td>1033</td><td>Removing IIS Virtual Roots...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RemovingIni</td><td>1033</td><td>Removing INI file entries</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RemovingMoved</td><td>1033</td><td>Removing moved files</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RemovingODBC</td><td>1033</td><td>Removing ODBC components</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RemovingRegistry</td><td>1033</td><td>Removing system registry values</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RemovingShortcuts</td><td>1033</td><td>Removing shortcuts</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_RollingBack</td><td>1033</td><td>Rolling back action:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_SearchForRelated</td><td>1033</td><td>Searching for related applications</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_SearchInstalled</td><td>1033</td><td>Searching for installed applications</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_SearchingQualifyingProducts</td><td>1033</td><td>Searching for qualifying products</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_SearchingQualifyingProducts2</td><td>1033</td><td>Searching for qualifying products</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Service</td><td>1033</td><td>Service: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Service2</td><td>1033</td><td>Service: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Service3</td><td>1033</td><td>Service: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Service4</td><td>1033</td><td>Service: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Shortcut</td><td>1033</td><td>Shortcut: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Shortcut1</td><td>1033</td><td>Shortcut: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_StartingServices</td><td>1033</td><td>Starting services</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_StoppingServices</td><td>1033</td><td>Stopping services</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_UnpublishProductFeatures</td><td>1033</td><td>Unpublishing product features</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_UnpublishQualified</td><td>1033</td><td>Unpublishing Qualified Components</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_UnpublishingProductInfo</td><td>1033</td><td>Unpublishing product information</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_UnregTypeLibs</td><td>1033</td><td>Unregistering type libraries</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_UnregisterClassServers</td><td>1033</td><td>Unregister class servers</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_UnregisterExtensionServers</td><td>1033</td><td>Unregistering extension servers</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_UnregisterModules</td><td>1033</td><td>Unregistering modules</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_UnregisteringComPlus</td><td>1033</td><td>Unregistering COM+ Applications and Components</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_UnregisteringFonts</td><td>1033</td><td>Unregistering fonts</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_UnregisteringMimeInfo</td><td>1033</td><td>Unregistering MIME info</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_UnregisteringProgramIds</td><td>1033</td><td>Unregistering program identifiers</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_UpdateComponentRegistration</td><td>1033</td><td>Updating component registration</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_UpdateEnvironmentStrings</td><td>1033</td><td>Updating environment strings</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_Validating</td><td>1033</td><td>Validating install</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_WritingINI</td><td>1033</td><td>Writing INI file values</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ACTIONTEXT_WritingRegistry</td><td>1033</td><td>Writing system registry values</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_BACK</td><td>1033</td><td>&lt; &amp;Back</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_CANCEL</td><td>1033</td><td>Cancel</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_CANCEL2</td><td>1033</td><td>&amp;Cancel</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_CHANGE</td><td>1033</td><td>&amp;Change...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_COMPLUS_PROGRESSTEXT_COST</td><td>1033</td><td>Costing COM+ application: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_COMPLUS_PROGRESSTEXT_INSTALL</td><td>1033</td><td>Installing COM+ application: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_COMPLUS_PROGRESSTEXT_UNINSTALL</td><td>1033</td><td>Uninstalling COM+ application: [1]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_DIALOG_TEXT2_DESCRIPTION</td><td>1033</td><td>Dialog Normal Description</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_DIALOG_TEXT_DESCRIPTION_EXTERIOR</td><td>1033</td><td>{&amp;TahomaBold10}Dialog Bold Title</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_DIALOG_TEXT_DESCRIPTION_INTERIOR</td><td>1033</td><td>{&amp;MSSansBold8}Dialog Bold Title</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_DIFX_AMD64</td><td>1033</td><td>[ProductName] requires an X64 processor. Click OK to exit the wizard.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_DIFX_IA64</td><td>1033</td><td>[ProductName] requires an IA64 processor. Click OK to exit the wizard.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_DIFX_X86</td><td>1033</td><td>[ProductName] requires an X86 processor. Click OK to exit the wizard.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_DatabaseFolder_InstallDatabaseTo</td><td>1033</td><td>Install [ProductName] database to:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_0</td><td>1033</td><td>{{Fatal error: }}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1</td><td>1033</td><td>Error [1]. </td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_10</td><td>1033</td><td>=== Logging started: [Date]  [Time] ===</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_100</td><td>1033</td><td>Could not remove shortcut [2]. Verify that the shortcut file exists and that you can access it.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_101</td><td>1033</td><td>Could not register type library for file [2].  Contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_102</td><td>1033</td><td>Could not unregister type library for file [2].  Contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_103</td><td>1033</td><td>Could not update the INI file [2][3].  Verify that the file exists and that you can access it.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_104</td><td>1033</td><td>Could not schedule file [2] to replace file [3] on reboot.  Verify that you have write permissions to file [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_105</td><td>1033</td><td>Error removing ODBC driver manager, ODBC error [2]: [3]. Contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_106</td><td>1033</td><td>Error installing ODBC driver manager, ODBC error [2]: [3]. Contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_107</td><td>1033</td><td>Error removing ODBC driver [4], ODBC error [2]: [3]. Verify that you have sufficient privileges to remove ODBC drivers.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_108</td><td>1033</td><td>Error installing ODBC driver [4], ODBC error [2]: [3]. Verify that the file [4] exists and that you can access it.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_109</td><td>1033</td><td>Error configuring ODBC data source [4], ODBC error [2]: [3]. Verify that the file [4] exists and that you can access it.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_11</td><td>1033</td><td>=== Logging stopped: [Date]  [Time] ===</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_110</td><td>1033</td><td>Service [2] ([3]) failed to start.  Verify that you have sufficient privileges to start system services.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_111</td><td>1033</td><td>Service [2] ([3]) could not be stopped.  Verify that you have sufficient privileges to stop system services.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_112</td><td>1033</td><td>Service [2] ([3]) could not be deleted.  Verify that you have sufficient privileges to remove system services.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_113</td><td>1033</td><td>Service [2] ([3]) could not be installed.  Verify that you have sufficient privileges to install system services.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_114</td><td>1033</td><td>Could not update environment variable [2].  Verify that you have sufficient privileges to modify environment variables.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_115</td><td>1033</td><td>You do not have sufficient privileges to complete this installation for all users of the machine.  Log on as an administrator and then retry this installation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_116</td><td>1033</td><td>Could not set file security for file [3]. Error: [2].  Verify that you have sufficient privileges to modify the security permissions for this file.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_117</td><td>1033</td><td>Component Services (COM+ 1.0) are not installed on this computer.  This installation requires Component Services in order to complete successfully.  Component Services are available on Windows 2000.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_118</td><td>1033</td><td>Error registering COM+ application.  Contact your support personnel for more information.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_119</td><td>1033</td><td>Error unregistering COM+ application.  Contact your support personnel for more information.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_12</td><td>1033</td><td>Action start [Time]: [1].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_120</td><td>1033</td><td>Removing older versions of this application</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_121</td><td>1033</td><td>Preparing to remove older versions of this application</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_122</td><td>1033</td><td>Error applying patch to file [2].  It has probably been updated by other means, and can no longer be modified by this patch.  For more information contact your patch vendor.  {{System Error: [3]}}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_123</td><td>1033</td><td>[2] cannot install one of its required products. Contact your technical support group.  {{System Error: [3].}}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_124</td><td>1033</td><td>The older version of [2] cannot be removed.  Contact your technical support group.  {{System Error [3].}}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_125</td><td>1033</td><td>The description for service '[2]' ([3]) could not be changed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_126</td><td>1033</td><td>The Windows Installer service cannot update the system file [2] because the file is protected by Windows.  You may need to update your operating system for this program to work correctly. {{Package version: [3], OS Protected version: [4]}}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_127</td><td>1033</td><td>The Windows Installer service cannot update the protected Windows file [2]. {{Package version: [3], OS Protected version: [4], SFP Error: [5]}}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_128</td><td>1033</td><td>The Windows Installer service cannot update one or more protected Windows files. SFP Error: [2]. List of protected files: [3]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_129</td><td>1033</td><td>User installations are disabled via policy on the machine.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_13</td><td>1033</td><td>Action ended [Time]: [1]. Return value [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_130</td><td>1033</td><td>This setup requires Internet Information Server for configuring IIS Virtual Roots. Please make sure that you have IIS installed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_131</td><td>1033</td><td>This setup requires Administrator privileges for configuring IIS Virtual Roots.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1329</td><td>1033</td><td>A file that is required cannot be installed because the cabinet file [2] is not digitally signed. This may indicate that the cabinet file is corrupt.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1330</td><td>1033</td><td>A file that is required cannot be installed because the cabinet file [2] has an invalid digital signature. This may indicate that the cabinet file is corrupt.{ Error [3] was returned by WinVerifyTrust.}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1331</td><td>1033</td><td>Failed to correctly copy [2] file: CRC error.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1332</td><td>1033</td><td>Failed to correctly patch [2] file: CRC error.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1333</td><td>1033</td><td>Failed to correctly patch [2] file: CRC error.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1334</td><td>1033</td><td>The file '[2]' cannot be installed because the file cannot be found in cabinet file '[3]'. This could indicate a network error, an error reading from the CD-ROM, or a problem with this package.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1335</td><td>1033</td><td>The cabinet file '[2]' required for this installation is corrupt and cannot be used. This could indicate a network error, an error reading from the CD-ROM, or a problem with this package.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1336</td><td>1033</td><td>There was an error creating a temporary file that is needed to complete this installation. Folder: [3]. System error code: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_14</td><td>1033</td><td>Time remaining: {[1] minutes }{[2] seconds}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_15</td><td>1033</td><td>Out of memory. Shut down other applications before retrying.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_16</td><td>1033</td><td>Installer is no longer responding.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1609</td><td>1033</td><td>An error occurred while applying security settings. [2] is not a valid user or group. This could be a problem with the package, or a problem connecting to a domain controller on the network. Check your network connection and click Retry, or Cancel to end the install. Unable to locate the user's SID, system error [3]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1651</td><td>1033</td><td>Admin user failed to apply patch for a per-user managed or a per-machine application which is in advertise state.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_17</td><td>1033</td><td>Installer terminated prematurely.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1715</td><td>1033</td><td>Installed [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1716</td><td>1033</td><td>Configured [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1717</td><td>1033</td><td>Removed [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1718</td><td>1033</td><td>File [2] was rejected by digital signature policy.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1719</td><td>1033</td><td>Windows Installer service could not be accessed. Contact your support personnel to verify that it is properly registered and enabled.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1720</td><td>1033</td><td>There is a problem with this Windows Installer package. A script required for this install to complete could not be run. Contact your support personnel or package vendor. Custom action [2] script error [3], [4]: [5] Line [6], Column [7], [8]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1721</td><td>1033</td><td>There is a problem with this Windows Installer package. A program required for this install to complete could not be run. Contact your support personnel or package vendor. Action: [2], location: [3], command: [4]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1722</td><td>1033</td><td>There is a problem with this Windows Installer package. A program run as part of the setup did not finish as expected. Contact your support personnel or package vendor. Action [2], location: [3], command: [4]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1723</td><td>1033</td><td>There is a problem with this Windows Installer package. A DLL required for this install to complete could not be run. Contact your support personnel or package vendor. Action [2], entry: [3], library: [4]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1724</td><td>1033</td><td>Removal completed successfully.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1725</td><td>1033</td><td>Removal failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1726</td><td>1033</td><td>Advertisement completed successfully.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1727</td><td>1033</td><td>Advertisement failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1728</td><td>1033</td><td>Configuration completed successfully.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1729</td><td>1033</td><td>Configuration failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1730</td><td>1033</td><td>You must be an Administrator to remove this application. To remove this application, you can log on as an administrator, or contact your technical support group for assistance.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1731</td><td>1033</td><td>The source installation package for the product [2] is out of sync with the client package. Try the installation again using a valid copy of the installation package '[3]'.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1732</td><td>1033</td><td>In order to complete the installation of [2], you must restart the computer. Other users are currently logged on to this computer, and restarting may cause them to lose their work. Do you want to restart now?</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_18</td><td>1033</td><td>Please wait while Windows configures [ProductName]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_19</td><td>1033</td><td>Gathering required information...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1935</td><td>1033</td><td>An error occurred during the installation of assembly component [2]. HRESULT: [3]. {{assembly interface: [4], function: [5], assembly name: [6]}}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1936</td><td>1033</td><td>An error occurred during the installation of assembly '[6]'. The assembly is not strongly named or is not signed with the minimal key length. HRESULT: [3]. {{assembly interface: [4], function: [5], component: [2]}}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1937</td><td>1033</td><td>An error occurred during the installation of assembly '[6]'. The signature or catalog could not be verified or is not valid. HRESULT: [3]. {{assembly interface: [4], function: [5], component: [2]}}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_1938</td><td>1033</td><td>An error occurred during the installation of assembly '[6]'. One or more modules of the assembly could not be found. HRESULT: [3]. {{assembly interface: [4], function: [5], component: [2]}}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2</td><td>1033</td><td>Warning [1]. </td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_20</td><td>1033</td><td>{[ProductName] }Setup completed successfully.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_21</td><td>1033</td><td>{[ProductName] }Setup failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2101</td><td>1033</td><td>Shortcuts not supported by the operating system.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2102</td><td>1033</td><td>Invalid .ini action: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2103</td><td>1033</td><td>Could not resolve path for shell folder [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2104</td><td>1033</td><td>Writing .ini file: [3]: System error: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2105</td><td>1033</td><td>Shortcut Creation [3] Failed. System error: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2106</td><td>1033</td><td>Shortcut Deletion [3] Failed. System error: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2107</td><td>1033</td><td>Error [3] registering type library [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2108</td><td>1033</td><td>Error [3] unregistering type library [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2109</td><td>1033</td><td>Section missing for .ini action.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2110</td><td>1033</td><td>Key missing for .ini action.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2111</td><td>1033</td><td>Detection of running applications failed, could not get performance data. Registered operation returned : [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2112</td><td>1033</td><td>Detection of running applications failed, could not get performance index. Registered operation returned : [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2113</td><td>1033</td><td>Detection of running applications failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_22</td><td>1033</td><td>Error reading from file: [2]. {{ System error [3].}}  Verify that the file exists and that you can access it.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2200</td><td>1033</td><td>Database: [2]. Database object creation failed, mode = [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2201</td><td>1033</td><td>Database: [2]. Initialization failed, out of memory.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2202</td><td>1033</td><td>Database: [2]. Data access failed, out of memory.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2203</td><td>1033</td><td>Database: [2]. Cannot open database file. System error [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2204</td><td>1033</td><td>Database: [2]. Table already exists: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2205</td><td>1033</td><td>Database: [2]. Table does not exist: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2206</td><td>1033</td><td>Database: [2]. Table could not be dropped: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2207</td><td>1033</td><td>Database: [2]. Intent violation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2208</td><td>1033</td><td>Database: [2]. Insufficient parameters for Execute.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2209</td><td>1033</td><td>Database: [2]. Cursor in invalid state.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2210</td><td>1033</td><td>Database: [2]. Invalid update data type in column [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2211</td><td>1033</td><td>Database: [2]. Could not create database table [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2212</td><td>1033</td><td>Database: [2]. Database not in writable state.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2213</td><td>1033</td><td>Database: [2]. Error saving database tables.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2214</td><td>1033</td><td>Database: [2]. Error writing export file: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2215</td><td>1033</td><td>Database: [2]. Cannot open import file: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2216</td><td>1033</td><td>Database: [2]. Import file format error: [3], Line [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2217</td><td>1033</td><td>Database: [2]. Wrong state to CreateOutputDatabase [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2218</td><td>1033</td><td>Database: [2]. Table name not supplied.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2219</td><td>1033</td><td>Database: [2]. Invalid Installer database format.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2220</td><td>1033</td><td>Database: [2]. Invalid row/field data.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2221</td><td>1033</td><td>Database: [2]. Code page conflict in import file: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2222</td><td>1033</td><td>Database: [2]. Transform or merge code page [3] differs from database code page [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2223</td><td>1033</td><td>Database: [2]. Databases are the same. No transform generated.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2224</td><td>1033</td><td>Database: [2]. GenerateTransform: Database corrupt. Table: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2225</td><td>1033</td><td>Database: [2]. Transform: Cannot transform a temporary table. Table: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2226</td><td>1033</td><td>Database: [2]. Transform failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2227</td><td>1033</td><td>Database: [2]. Invalid identifier '[3]' in SQL query: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2228</td><td>1033</td><td>Database: [2]. Unknown table '[3]' in SQL query: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2229</td><td>1033</td><td>Database: [2]. Could not load table '[3]' in SQL query: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2230</td><td>1033</td><td>Database: [2]. Repeated table '[3]' in SQL query: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2231</td><td>1033</td><td>Database: [2]. Missing ')' in SQL query: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2232</td><td>1033</td><td>Database: [2]. Unexpected token '[3]' in SQL query: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2233</td><td>1033</td><td>Database: [2]. No columns in SELECT clause in SQL query: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2234</td><td>1033</td><td>Database: [2]. No columns in ORDER BY clause in SQL query: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2235</td><td>1033</td><td>Database: [2]. Column '[3]' not present or ambiguous in SQL query: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2236</td><td>1033</td><td>Database: [2]. Invalid operator '[3]' in SQL query: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2237</td><td>1033</td><td>Database: [2]. Invalid or missing query string: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2238</td><td>1033</td><td>Database: [2]. Missing FROM clause in SQL query: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2239</td><td>1033</td><td>Database: [2]. Insufficient values in INSERT SQL statement.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2240</td><td>1033</td><td>Database: [2]. Missing update columns in UPDATE SQL statement.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2241</td><td>1033</td><td>Database: [2]. Missing insert columns in INSERT SQL statement.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2242</td><td>1033</td><td>Database: [2]. Column '[3]' repeated.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2243</td><td>1033</td><td>Database: [2]. No primary columns defined for table creation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2244</td><td>1033</td><td>Database: [2]. Invalid type specifier '[3]' in SQL query [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2245</td><td>1033</td><td>IStorage::Stat failed with error [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2246</td><td>1033</td><td>Database: [2]. Invalid Installer transform format.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2247</td><td>1033</td><td>Database: [2] Transform stream read/write failure.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2248</td><td>1033</td><td>Database: [2] GenerateTransform/Merge: Column type in base table does not match reference table. Table: [3] Col #: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2249</td><td>1033</td><td>Database: [2] GenerateTransform: More columns in base table than in reference table. Table: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2250</td><td>1033</td><td>Database: [2] Transform: Cannot add existing row. Table: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2251</td><td>1033</td><td>Database: [2] Transform: Cannot delete row that does not exist. Table: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2252</td><td>1033</td><td>Database: [2] Transform: Cannot add existing table. Table: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2253</td><td>1033</td><td>Database: [2] Transform: Cannot delete table that does not exist. Table: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2254</td><td>1033</td><td>Database: [2] Transform: Cannot update row that does not exist. Table: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2255</td><td>1033</td><td>Database: [2] Transform: Column with this name already exists. Table: [3] Col: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2256</td><td>1033</td><td>Database: [2] GenerateTransform/Merge: Number of primary keys in base table does not match reference table. Table: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2257</td><td>1033</td><td>Database: [2]. Intent to modify read only table: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2258</td><td>1033</td><td>Database: [2]. Type mismatch in parameter: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2259</td><td>1033</td><td>Database: [2] Table(s) Update failed</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2260</td><td>1033</td><td>Storage CopyTo failed. System error: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2261</td><td>1033</td><td>Could not remove stream [2]. System error: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2262</td><td>1033</td><td>Stream does not exist: [2]. System error: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2263</td><td>1033</td><td>Could not open stream [2]. System error: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2264</td><td>1033</td><td>Could not remove stream [2]. System error: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2265</td><td>1033</td><td>Could not commit storage. System error: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2266</td><td>1033</td><td>Could not rollback storage. System error: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2267</td><td>1033</td><td>Could not delete storage [2]. System error: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2268</td><td>1033</td><td>Database: [2]. Merge: There were merge conflicts reported in [3] tables.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2269</td><td>1033</td><td>Database: [2]. Merge: The column count differed in the '[3]' table of the two databases.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2270</td><td>1033</td><td>Database: [2]. GenerateTransform/Merge: Column name in base table does not match reference table. Table: [3] Col #: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2271</td><td>1033</td><td>SummaryInformation write for transform failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2272</td><td>1033</td><td>Database: [2]. MergeDatabase will not write any changes because the database is open read-only.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2273</td><td>1033</td><td>Database: [2]. MergeDatabase: A reference to the base database was passed as the reference database.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2274</td><td>1033</td><td>Database: [2]. MergeDatabase: Unable to write errors to Error table. Could be due to a non-nullable column in a predefined Error table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2275</td><td>1033</td><td>Database: [2]. Specified Modify [3] operation invalid for table joins.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2276</td><td>1033</td><td>Database: [2]. Code page [3] not supported by the system.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2277</td><td>1033</td><td>Database: [2]. Failed to save table [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2278</td><td>1033</td><td>Database: [2]. Exceeded number of expressions limit of 32 in WHERE clause of SQL query: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2279</td><td>1033</td><td>Database: [2] Transform: Too many columns in base table [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2280</td><td>1033</td><td>Database: [2]. Could not create column [3] for table [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2281</td><td>1033</td><td>Could not rename stream [2]. System error: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2282</td><td>1033</td><td>Stream name invalid [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_23</td><td>1033</td><td>Cannot create the file [3].  A directory with this name already exists.  Cancel the installation and try installing to a different location.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2302</td><td>1033</td><td>Patch notify: [2] bytes patched to far.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2303</td><td>1033</td><td>Error getting volume info. GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2304</td><td>1033</td><td>Error getting disk free space. GetLastError: [2]. Volume: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2305</td><td>1033</td><td>Error waiting for patch thread. GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2306</td><td>1033</td><td>Could not create thread for patch application. GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2307</td><td>1033</td><td>Source file key name is null.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2308</td><td>1033</td><td>Destination file name is null.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2309</td><td>1033</td><td>Attempting to patch file [2] when patch already in progress.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2310</td><td>1033</td><td>Attempting to continue patch when no patch is in progress.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2315</td><td>1033</td><td>Missing path separator: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2318</td><td>1033</td><td>File does not exist: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2319</td><td>1033</td><td>Error setting file attribute: [3] GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2320</td><td>1033</td><td>File not writable: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2321</td><td>1033</td><td>Error creating file: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2322</td><td>1033</td><td>User canceled.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2323</td><td>1033</td><td>Invalid file attribute.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2324</td><td>1033</td><td>Could not open file: [3] GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2325</td><td>1033</td><td>Could not get file time for file: [3] GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2326</td><td>1033</td><td>Error in FileToDosDateTime.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2327</td><td>1033</td><td>Could not remove directory: [3] GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2328</td><td>1033</td><td>Error getting file version info for file: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2329</td><td>1033</td><td>Error deleting file: [3]. GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2330</td><td>1033</td><td>Error getting file attributes: [3]. GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2331</td><td>1033</td><td>Error loading library [2] or finding entry point [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2332</td><td>1033</td><td>Error getting file attributes. GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2333</td><td>1033</td><td>Error setting file attributes. GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2334</td><td>1033</td><td>Error converting file time to local time for file: [3]. GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2335</td><td>1033</td><td>Path: [2] is not a parent of [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2336</td><td>1033</td><td>Error creating temp file on path: [3]. GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2337</td><td>1033</td><td>Could not close file: [3] GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2338</td><td>1033</td><td>Could not update resource for file: [3] GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2339</td><td>1033</td><td>Could not set file time for file: [3] GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2340</td><td>1033</td><td>Could not update resource for file: [3], Missing resource.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2341</td><td>1033</td><td>Could not update resource for file: [3], Resource too large.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2342</td><td>1033</td><td>Could not update resource for file: [3] GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2343</td><td>1033</td><td>Specified path is empty.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2344</td><td>1033</td><td>Could not find required file IMAGEHLP.DLL to validate file:[2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2345</td><td>1033</td><td>[2]: File does not contain a valid checksum value.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2347</td><td>1033</td><td>User ignore.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2348</td><td>1033</td><td>Error attempting to read from cabinet stream.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2349</td><td>1033</td><td>Copy resumed with different info.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2350</td><td>1033</td><td>FDI server error</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2351</td><td>1033</td><td>File key '[2]' not found in cabinet '[3]'. The installation cannot continue.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2352</td><td>1033</td><td>Could not initialize cabinet file server. The required file 'CABINET.DLL' may be missing.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2353</td><td>1033</td><td>Not a cabinet.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2354</td><td>1033</td><td>Cannot handle cabinet.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2355</td><td>1033</td><td>Corrupt cabinet.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2356</td><td>1033</td><td>Could not locate cabinet in stream: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2357</td><td>1033</td><td>Cannot set attributes.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2358</td><td>1033</td><td>Error determining whether file is in-use: [3]. GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2359</td><td>1033</td><td>Unable to create the target file - file may be in use.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2360</td><td>1033</td><td>Progress tick.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2361</td><td>1033</td><td>Need next cabinet.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2362</td><td>1033</td><td>Folder not found: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2363</td><td>1033</td><td>Could not enumerate subfolders for folder: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2364</td><td>1033</td><td>Bad enumeration constant in CreateCopier call.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2365</td><td>1033</td><td>Could not BindImage exe file [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2366</td><td>1033</td><td>User failure.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2367</td><td>1033</td><td>User abort.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2368</td><td>1033</td><td>Failed to get network resource information. Error [2], network path [3]. Extended error: network provider [5], error code [4], error description [6].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2370</td><td>1033</td><td>Invalid CRC checksum value for [2] file.{ Its header says [3] for checksum, its computed value is [4].}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2371</td><td>1033</td><td>Could not apply patch to file [2]. GetLastError: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2372</td><td>1033</td><td>Patch file [2] is corrupt or of an invalid format. Attempting to patch file [3]. GetLastError: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2373</td><td>1033</td><td>File [2] is not a valid patch file.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2374</td><td>1033</td><td>File [2] is not a valid destination file for patch file [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2375</td><td>1033</td><td>Unknown patching error: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2376</td><td>1033</td><td>Cabinet not found.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2379</td><td>1033</td><td>Error opening file for read: [3] GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2380</td><td>1033</td><td>Error opening file for write: [3]. GetLastError: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2381</td><td>1033</td><td>Directory does not exist: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2382</td><td>1033</td><td>Drive not ready: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_24</td><td>1033</td><td>Please insert the disk: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2401</td><td>1033</td><td>64-bit registry operation attempted on 32-bit operating system for key [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2402</td><td>1033</td><td>Out of memory.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_25</td><td>1033</td><td>The installer has insufficient privileges to access this directory: [2].  The installation cannot continue.  Log on as an administrator or contact your system administrator.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2501</td><td>1033</td><td>Could not create rollback script enumerator.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2502</td><td>1033</td><td>Called InstallFinalize when no install in progress.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2503</td><td>1033</td><td>Called RunScript when not marked in progress.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_26</td><td>1033</td><td>Error writing to file [2].  Verify that you have access to that directory.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2601</td><td>1033</td><td>Invalid value for property [2]: '[3]'</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2602</td><td>1033</td><td>The [2] table entry '[3]' has no associated entry in the Media table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2603</td><td>1033</td><td>Duplicate table name [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2604</td><td>1033</td><td>[2] Property undefined.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2605</td><td>1033</td><td>Could not find server [2] in [3] or [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2606</td><td>1033</td><td>Value of property [2] is not a valid full path: '[3]'.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2607</td><td>1033</td><td>Media table not found or empty (required for installation of files).</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2608</td><td>1033</td><td>Could not create security descriptor for object. Error: '[2]'.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2609</td><td>1033</td><td>Attempt to migrate product settings before initialization.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2611</td><td>1033</td><td>The file [2] is marked as compressed, but the associated media entry does not specify a cabinet.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2612</td><td>1033</td><td>Stream not found in '[2]' column. Primary key: '[3]'.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2613</td><td>1033</td><td>RemoveExistingProducts action sequenced incorrectly.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2614</td><td>1033</td><td>Could not access IStorage object from installation package.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2615</td><td>1033</td><td>Skipped unregistration of Module [2] due to source resolution failure.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2616</td><td>1033</td><td>Companion file [2] parent missing.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2617</td><td>1033</td><td>Shared component [2] not found in Component table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2618</td><td>1033</td><td>Isolated application component [2] not found in Component table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2619</td><td>1033</td><td>Isolated components [2], [3] not part of same feature.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2620</td><td>1033</td><td>Key file of isolated application component [2] not in File table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2621</td><td>1033</td><td>Resource DLL or Resource ID information for shortcut [2] set incorrectly.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27</td><td>1033</td><td>Error reading from file [2].  Verify that the file exists and that you can access it.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2701</td><td>1033</td><td>The depth of a feature exceeds the acceptable tree depth of [2] levels.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2702</td><td>1033</td><td>A Feature table record ([2]) references a non-existent parent in the Attributes field.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2703</td><td>1033</td><td>Property name for root source path not defined: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2704</td><td>1033</td><td>Root directory property undefined: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2705</td><td>1033</td><td>Invalid table: [2]; Could not be linked as tree.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2706</td><td>1033</td><td>Source paths not created. No path exists for entry [2] in Directory table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2707</td><td>1033</td><td>Target paths not created. No path exists for entry [2] in Directory table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2708</td><td>1033</td><td>No entries found in the file table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2709</td><td>1033</td><td>The specified Component name ('[2]') not found in Component table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2710</td><td>1033</td><td>The requested 'Select' state is illegal for this Component.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2711</td><td>1033</td><td>The specified Feature name ('[2]') not found in Feature table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2712</td><td>1033</td><td>Invalid return from modeless dialog: [3], in action [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2713</td><td>1033</td><td>Null value in a non-nullable column ('[2]' in '[3]' column of the '[4]' table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2714</td><td>1033</td><td>Invalid value for default folder name: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2715</td><td>1033</td><td>The specified File key ('[2]') not found in the File table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2716</td><td>1033</td><td>Could not create a random subcomponent name for component '[2]'.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2717</td><td>1033</td><td>Bad action condition or error calling custom action '[2]'.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2718</td><td>1033</td><td>Missing package name for product code '[2]'.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2719</td><td>1033</td><td>Neither UNC nor drive letter path found in source '[2]'.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2720</td><td>1033</td><td>Error opening source list key. Error: '[2]'</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2721</td><td>1033</td><td>Custom action [2] not found in Binary table stream.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2722</td><td>1033</td><td>Custom action [2] not found in File table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2723</td><td>1033</td><td>Custom action [2] specifies unsupported type.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2724</td><td>1033</td><td>The volume label '[2]' on the media you're running from does not match the label '[3]' given in the Media table. This is allowed only if you have only 1 entry in your Media table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2725</td><td>1033</td><td>Invalid database tables</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2726</td><td>1033</td><td>Action not found: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2727</td><td>1033</td><td>The directory entry '[2]' does not exist in the Directory table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2728</td><td>1033</td><td>Table definition error: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2729</td><td>1033</td><td>Install engine not initialized.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2730</td><td>1033</td><td>Bad value in database. Table: '[2]'; Primary key: '[3]'; Column: '[4]'</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2731</td><td>1033</td><td>Selection Manager not initialized.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2732</td><td>1033</td><td>Directory Manager not initialized.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2733</td><td>1033</td><td>Bad foreign key ('[2]') in '[3]' column of the '[4]' table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2734</td><td>1033</td><td>Invalid reinstall mode character.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2735</td><td>1033</td><td>Custom action '[2]' has caused an unhandled exception and has been stopped. This may be the result of an internal error in the custom action, such as an access violation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2736</td><td>1033</td><td>Generation of custom action temp file failed: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2737</td><td>1033</td><td>Could not access custom action [2], entry [3], library [4]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2738</td><td>1033</td><td>Could not access VBScript run time for custom action [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2739</td><td>1033</td><td>Could not access JavaScript run time for custom action [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2740</td><td>1033</td><td>Custom action [2] script error [3], [4]: [5] Line [6], Column [7], [8].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2741</td><td>1033</td><td>Configuration information for product [2] is corrupt. Invalid info: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2742</td><td>1033</td><td>Marshaling to Server failed: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2743</td><td>1033</td><td>Could not execute custom action [2], location: [3], command: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2744</td><td>1033</td><td>EXE failed called by custom action [2], location: [3], command: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2745</td><td>1033</td><td>Transform [2] invalid for package [3]. Expected language [4], found language [5].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2746</td><td>1033</td><td>Transform [2] invalid for package [3]. Expected product [4], found product [5].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2747</td><td>1033</td><td>Transform [2] invalid for package [3]. Expected product version &lt; [4], found product version [5].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2748</td><td>1033</td><td>Transform [2] invalid for package [3]. Expected product version &lt;= [4], found product version [5].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2749</td><td>1033</td><td>Transform [2] invalid for package [3]. Expected product version == [4], found product version [5].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2750</td><td>1033</td><td>Transform [2] invalid for package [3]. Expected product version &gt;= [4], found product version [5].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27502</td><td>1033</td><td>Could not connect to [2] '[3]'. [4]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27503</td><td>1033</td><td>Error retrieving version string from [2] '[3]'. [4]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27504</td><td>1033</td><td>SQL version requirements not met: [3]. This installation requires [2] [4] or later.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27505</td><td>1033</td><td>Could not open SQL script file [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27506</td><td>1033</td><td>Error executing SQL script [2]. Line [3]. [4]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27507</td><td>1033</td><td>Connection or browsing for database servers requires that MDAC be installed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27508</td><td>1033</td><td>Error installing COM+ application [2]. [3]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27509</td><td>1033</td><td>Error uninstalling COM+ application [2]. [3]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2751</td><td>1033</td><td>Transform [2] invalid for package [3]. Expected product version &gt; [4], found product version [5].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27510</td><td>1033</td><td>Error installing COM+ application [2].  Could not load Microsoft(R) .NET class libraries. Registering .NET serviced components requires that Microsoft(R) .NET Framework be installed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27511</td><td>1033</td><td>Could not execute SQL script file [2]. Connection not open: [3]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27512</td><td>1033</td><td>Error beginning transactions for [2] '[3]'. Database [4]. [5]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27513</td><td>1033</td><td>Error committing transactions for [2] '[3]'. Database [4]. [5]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27514</td><td>1033</td><td>This installation requires a Microsoft SQL Server. The specified server '[3]' is a Microsoft SQL Server Desktop Engine or SQL Server Express.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27515</td><td>1033</td><td>Error retrieving schema version from [2] '[3]'. Database: '[4]'. [5]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27516</td><td>1033</td><td>Error writing schema version to [2] '[3]'. Database: '[4]'. [5]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27517</td><td>1033</td><td>This installation requires Administrator privileges for installing COM+ applications. Log on as an administrator and then retry this installation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27518</td><td>1033</td><td>The COM+ application "[2]" is configured to run as an NT service; this requires COM+ 1.5 or later on the system. Since your system has COM+ 1.0, this application will not be installed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27519</td><td>1033</td><td>Error updating XML file [2]. [3]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2752</td><td>1033</td><td>Could not open transform [2] stored as child storage of package [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27520</td><td>1033</td><td>Error opening XML file [2]. [3]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27521</td><td>1033</td><td>This setup requires MSXML 3.0 or higher for configuring XML files. Please make sure that you have version 3.0 or higher.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27522</td><td>1033</td><td>Error creating XML file [2]. [3]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27523</td><td>1033</td><td>Error loading servers.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27524</td><td>1033</td><td>Error loading NetApi32.DLL. The ISNetApi.dll needs to have NetApi32.DLL properly loaded and requires an NT based operating system.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27525</td><td>1033</td><td>Server not found. Verify that the specified server exists. The server name can not be empty.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27526</td><td>1033</td><td>Unspecified error from ISNetApi.dll.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27527</td><td>1033</td><td>The buffer is too small.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27528</td><td>1033</td><td>Access denied. Check administrative rights.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27529</td><td>1033</td><td>Invalid computer.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2753</td><td>1033</td><td>The File '[2]' is not marked for installation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27530</td><td>1033</td><td>Unknown error returned from NetAPI. System error: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27531</td><td>1033</td><td>Unhandled exception.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27532</td><td>1033</td><td>Invalid user name for this server or domain.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27533</td><td>1033</td><td>The case-sensitive passwords do not match.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27534</td><td>1033</td><td>The list is empty.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27535</td><td>1033</td><td>Access violation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27536</td><td>1033</td><td>Error getting group.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27537</td><td>1033</td><td>Error adding user to group. Verify that the group exists for this domain or server.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27538</td><td>1033</td><td>Error creating user.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27539</td><td>1033</td><td>ERROR_NETAPI_ERROR_NOT_PRIMARY returned from NetAPI.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2754</td><td>1033</td><td>The File '[2]' is not a valid patch file.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27540</td><td>1033</td><td>The specified user already exists.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27541</td><td>1033</td><td>The specified group already exists.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27542</td><td>1033</td><td>Invalid password. Verify that the password is in accordance with your network password policy.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27543</td><td>1033</td><td>Invalid name.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27544</td><td>1033</td><td>Invalid group.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27545</td><td>1033</td><td>The user name can not be empty and must be in the format DOMAIN\Username.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27546</td><td>1033</td><td>Error loading or creating INI file in the user TEMP directory.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27547</td><td>1033</td><td>ISNetAPI.dll is not loaded or there was an error loading the dll. This dll needs to be loaded for this operation. Verify that the dll is in the SUPPORTDIR directory.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27548</td><td>1033</td><td>Error deleting INI file containing new user information from the user's TEMP directory.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27549</td><td>1033</td><td>Error getting the primary domain controller (PDC).</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2755</td><td>1033</td><td>Server returned unexpected error [2] attempting to install package [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27550</td><td>1033</td><td>Every field must have a value in order to create a user.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27551</td><td>1033</td><td>ODBC driver for [2] not found. This is required to connect to [2] database servers.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27552</td><td>1033</td><td>Error creating database [4]. Server: [2] [3]. [5]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27553</td><td>1033</td><td>Error connecting to database [4]. Server: [2] [3]. [5]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27554</td><td>1033</td><td>Error attempting to open connection [2]. No valid database metadata associated with this connection.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_27555</td><td>1033</td><td>Error attempting to apply permissions to object '[2]'. System error: [3] ([4])</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2756</td><td>1033</td><td>The property '[2]' was used as a directory property in one or more tables, but no value was ever assigned.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2757</td><td>1033</td><td>Could not create summary info for transform [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2758</td><td>1033</td><td>Transform [2] does not contain an MSI version.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2759</td><td>1033</td><td>Transform [2] version [3] incompatible with engine; Min: [4], Max: [5].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2760</td><td>1033</td><td>Transform [2] invalid for package [3]. Expected upgrade code [4], found [5].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2761</td><td>1033</td><td>Cannot begin transaction. Global mutex not properly initialized.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2762</td><td>1033</td><td>Cannot write script record. Transaction not started.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2763</td><td>1033</td><td>Cannot run script. Transaction not started.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2765</td><td>1033</td><td>Assembly name missing from AssemblyName table : Component: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2766</td><td>1033</td><td>The file [2] is an invalid MSI storage file.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2767</td><td>1033</td><td>No more data{ while enumerating [2]}.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2768</td><td>1033</td><td>Transform in patch package is invalid.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2769</td><td>1033</td><td>Custom Action [2] did not close [3] MSIHANDLEs.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2770</td><td>1033</td><td>Cached folder [2] not defined in internal cache folder table.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2771</td><td>1033</td><td>Upgrade of feature [2] has a missing component.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2772</td><td>1033</td><td>New upgrade feature [2] must be a leaf feature.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_28</td><td>1033</td><td>Another application has exclusive access to the file [2].  Please shut down all other applications, then click Retry.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2801</td><td>1033</td><td>Unknown Message -- Type [2]. No action is taken.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2802</td><td>1033</td><td>No publisher is found for the event [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2803</td><td>1033</td><td>Dialog View did not find a record for the dialog [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2804</td><td>1033</td><td>On activation of the control [3] on dialog [2] CMsiDialog failed to evaluate the condition [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2806</td><td>1033</td><td>The dialog [2] failed to evaluate the condition [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2807</td><td>1033</td><td>The action [2] is not recognized.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2808</td><td>1033</td><td>Default button is ill-defined on dialog [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2809</td><td>1033</td><td>On the dialog [2] the next control pointers do not form a cycle. There is a pointer from [3] to [4], but there is no further pointer.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2810</td><td>1033</td><td>On the dialog [2] the next control pointers do not form a cycle. There is a pointer from both [3] and [5] to [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2811</td><td>1033</td><td>On dialog [2] control [3] has to take focus, but it is unable to do so.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2812</td><td>1033</td><td>The event [2] is not recognized.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2813</td><td>1033</td><td>The EndDialog event was called with the argument [2], but the dialog has a parent.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2814</td><td>1033</td><td>On the dialog [2] the control [3] names a nonexistent control [4] as the next control.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2815</td><td>1033</td><td>ControlCondition table has a row without condition for the dialog [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2816</td><td>1033</td><td>The EventMapping table refers to an invalid control [4] on dialog [2] for the event [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2817</td><td>1033</td><td>The event [2] failed to set the attribute for the control [4] on dialog [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2818</td><td>1033</td><td>In the ControlEvent table EndDialog has an unrecognized argument [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2819</td><td>1033</td><td>Control [3] on dialog [2] needs a property linked to it.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2820</td><td>1033</td><td>Attempted to initialize an already initialized handler.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2821</td><td>1033</td><td>Attempted to initialize an already initialized dialog: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2822</td><td>1033</td><td>No other method can be called on dialog [2] until all the controls are added.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2823</td><td>1033</td><td>Attempted to initialize an already initialized control: [3] on dialog [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2824</td><td>1033</td><td>The dialog attribute [3] needs a record of at least [2] field(s).</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2825</td><td>1033</td><td>The control attribute [3] needs a record of at least [2] field(s).</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2826</td><td>1033</td><td>Control [3] on dialog [2] extends beyond the boundaries of the dialog [4] by [5] pixels.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2827</td><td>1033</td><td>The button [4] on the radio button group [3] on dialog [2] extends beyond the boundaries of the group [5] by [6] pixels.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2828</td><td>1033</td><td>Tried to remove control [3] from dialog [2], but the control is not part of the dialog.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2829</td><td>1033</td><td>Attempt to use an uninitialized dialog.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2830</td><td>1033</td><td>Attempt to use an uninitialized control on dialog [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2831</td><td>1033</td><td>The control [3] on dialog [2] does not support [5] the attribute [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2832</td><td>1033</td><td>The dialog [2] does not support the attribute [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2833</td><td>1033</td><td>Control [4] on dialog [3] ignored the message [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2834</td><td>1033</td><td>The next pointers on the dialog [2] do not form a single loop.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2835</td><td>1033</td><td>The control [2] was not found on dialog [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2836</td><td>1033</td><td>The control [3] on the dialog [2] cannot take focus.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2837</td><td>1033</td><td>The control [3] on dialog [2] wants the winproc to return [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2838</td><td>1033</td><td>The item [2] in the selection table has itself as a parent.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2839</td><td>1033</td><td>Setting the property [2] failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2840</td><td>1033</td><td>Error dialog name mismatch.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2841</td><td>1033</td><td>No OK button was found on the error dialog.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2842</td><td>1033</td><td>No text field was found on the error dialog.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2843</td><td>1033</td><td>The ErrorString attribute is not supported for standard dialogs.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2844</td><td>1033</td><td>Cannot execute an error dialog if the Errorstring is not set.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2845</td><td>1033</td><td>The total width of the buttons exceeds the size of the error dialog.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2846</td><td>1033</td><td>SetFocus did not find the required control on the error dialog.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2847</td><td>1033</td><td>The control [3] on dialog [2] has both the icon and the bitmap style set.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2848</td><td>1033</td><td>Tried to set control [3] as the default button on dialog [2], but the control does not exist.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2849</td><td>1033</td><td>The control [3] on dialog [2] is of a type, that cannot be integer valued.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2850</td><td>1033</td><td>Unrecognized volume type.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2851</td><td>1033</td><td>The data for the icon [2] is not valid.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2852</td><td>1033</td><td>At least one control has to be added to dialog [2] before it is used.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2853</td><td>1033</td><td>Dialog [2] is a modeless dialog. The execute method should not be called on it.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2854</td><td>1033</td><td>On the dialog [2] the control [3] is designated as first active control, but there is no such control.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2855</td><td>1033</td><td>The radio button group [3] on dialog [2] has fewer than 2 buttons.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2856</td><td>1033</td><td>Creating a second copy of the dialog [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2857</td><td>1033</td><td>The directory [2] is mentioned in the selection table but not found.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2858</td><td>1033</td><td>The data for the bitmap [2] is not valid.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2859</td><td>1033</td><td>Test error message.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2860</td><td>1033</td><td>Cancel button is ill-defined on dialog [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2861</td><td>1033</td><td>The next pointers for the radio buttons on dialog [2] control [3] do not form a cycle.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2862</td><td>1033</td><td>The attributes for the control [3] on dialog [2] do not define a valid icon size. Setting the size to 16.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2863</td><td>1033</td><td>The control [3] on dialog [2] needs the icon [4] in size [5]x[5], but that size is not available. Loading the first available size.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2864</td><td>1033</td><td>The control [3] on dialog [2] received a browse event, but there is no configurable directory for the present selection. Likely cause: browse button is not authored correctly.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2865</td><td>1033</td><td>Control [3] on billboard [2] extends beyond the boundaries of the billboard [4] by [5] pixels.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2866</td><td>1033</td><td>The dialog [2] is not allowed to return the argument [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2867</td><td>1033</td><td>The error dialog property is not set.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2868</td><td>1033</td><td>The error dialog [2] does not have the error style bit set.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2869</td><td>1033</td><td>The dialog [2] has the error style bit set, but is not an error dialog.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2870</td><td>1033</td><td>The help string [4] for control [3] on dialog [2] does not contain the separator character.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2871</td><td>1033</td><td>The [2] table is out of date: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2872</td><td>1033</td><td>The argument of the CheckPath control event on dialog [2] is invalid.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2873</td><td>1033</td><td>On the dialog [2] the control [3] has an invalid string length limit: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2874</td><td>1033</td><td>Changing the text font to [2] failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2875</td><td>1033</td><td>Changing the text color to [2] failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2876</td><td>1033</td><td>The control [3] on dialog [2] had to truncate the string: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2877</td><td>1033</td><td>The binary data [2] was not found</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2878</td><td>1033</td><td>On the dialog [2] the control [3] has a possible value: [4]. This is an invalid or duplicate value.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2879</td><td>1033</td><td>The control [3] on dialog [2] cannot parse the mask string: [4].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2880</td><td>1033</td><td>Do not perform the remaining control events.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2881</td><td>1033</td><td>CMsiHandler initialization failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2882</td><td>1033</td><td>Dialog window class registration failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2883</td><td>1033</td><td>CreateNewDialog failed for the dialog [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2884</td><td>1033</td><td>Failed to create a window for the dialog [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2885</td><td>1033</td><td>Failed to create the control [3] on the dialog [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2886</td><td>1033</td><td>Creating the [2] table failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2887</td><td>1033</td><td>Creating a cursor to the [2] table failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2888</td><td>1033</td><td>Executing the [2] view failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2889</td><td>1033</td><td>Creating the window for the control [3] on dialog [2] failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2890</td><td>1033</td><td>The handler failed in creating an initialized dialog.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2891</td><td>1033</td><td>Failed to destroy window for dialog [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2892</td><td>1033</td><td>[2] is an integer only control, [3] is not a valid integer value.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2893</td><td>1033</td><td>The control [3] on dialog [2] can accept property values that are at most [5] characters long. The value [4] exceeds this limit, and has been truncated.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2894</td><td>1033</td><td>Loading RICHED20.DLL failed. GetLastError() returned: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2895</td><td>1033</td><td>Freeing RICHED20.DLL failed. GetLastError() returned: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2896</td><td>1033</td><td>Executing action [2] failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2897</td><td>1033</td><td>Failed to create any [2] font on this system.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2898</td><td>1033</td><td>For [2] textstyle, the system created a '[3]' font, in [4] character set.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2899</td><td>1033</td><td>Failed to create [2] textstyle. GetLastError() returned: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_29</td><td>1033</td><td>There is not enough disk space to install the file [2].  Free some disk space and click Retry, or click Cancel to exit.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2901</td><td>1033</td><td>Invalid parameter to operation [2]: Parameter [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2902</td><td>1033</td><td>Operation [2] called out of sequence.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2903</td><td>1033</td><td>The file [2] is missing.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2904</td><td>1033</td><td>Could not BindImage file [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2905</td><td>1033</td><td>Could not read record from script file [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2906</td><td>1033</td><td>Missing header in script file [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2907</td><td>1033</td><td>Could not create secure security descriptor. Error: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2908</td><td>1033</td><td>Could not register component [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2909</td><td>1033</td><td>Could not unregister component [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2910</td><td>1033</td><td>Could not determine user's security ID.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2911</td><td>1033</td><td>Could not remove the folder [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2912</td><td>1033</td><td>Could not schedule file [2] for removal on restart.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2919</td><td>1033</td><td>No cabinet specified for compressed file: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2920</td><td>1033</td><td>Source directory not specified for file [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2924</td><td>1033</td><td>Script [2] version unsupported. Script version: [3], minimum version: [4], maximum version: [5].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2927</td><td>1033</td><td>ShellFolder id [2] is invalid.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2928</td><td>1033</td><td>Exceeded maximum number of sources. Skipping source '[2]'.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2929</td><td>1033</td><td>Could not determine publishing root. Error: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2932</td><td>1033</td><td>Could not create file [2] from script data. Error: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2933</td><td>1033</td><td>Could not initialize rollback script [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2934</td><td>1033</td><td>Could not secure transform [2]. Error [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2935</td><td>1033</td><td>Could not unsecure transform [2]. Error [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2936</td><td>1033</td><td>Could not find transform [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2937</td><td>1033</td><td>Windows Installer cannot install a system file protection catalog. Catalog: [2], Error: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2938</td><td>1033</td><td>Windows Installer cannot retrieve a system file protection catalog from the cache. Catalog: [2], Error: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2939</td><td>1033</td><td>Windows Installer cannot delete a system file protection catalog from the cache. Catalog: [2], Error: [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2940</td><td>1033</td><td>Directory Manager not supplied for source resolution.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2941</td><td>1033</td><td>Unable to compute the CRC for file [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2942</td><td>1033</td><td>BindImage action has not been executed on [2] file.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2943</td><td>1033</td><td>This version of Windows does not support deploying 64-bit packages. The script [2] is for a 64-bit package.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2944</td><td>1033</td><td>GetProductAssignmentType failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_2945</td><td>1033</td><td>Installation of ComPlus App [2] failed with error [3].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_3</td><td>1033</td><td>Info [1]. </td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_30</td><td>1033</td><td>Source file not found: [2].  Verify that the file exists and that you can access it.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_3001</td><td>1033</td><td>The patches in this list contain incorrect sequencing information: [2][3][4][5][6][7][8][9][10][11][12][13][14][15][16].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_3002</td><td>1033</td><td>Patch [2] contains invalid sequencing information. </td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_31</td><td>1033</td><td>Error reading from file: [3]. {{ System error [2].}}  Verify that the file exists and that you can access it.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_32</td><td>1033</td><td>Error writing to file: [3]. {{ System error [2].}}  Verify that you have access to that directory.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_33</td><td>1033</td><td>Source file not found{{(cabinet)}}: [2].  Verify that the file exists and that you can access it.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_34</td><td>1033</td><td>Cannot create the directory [2].  A file with this name already exists.  Please rename or remove the file and click Retry, or click Cancel to exit.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_35</td><td>1033</td><td>The volume [2] is currently unavailable.  Please select another.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_36</td><td>1033</td><td>The specified path [2] is unavailable.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_37</td><td>1033</td><td>Unable to write to the specified folder [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_38</td><td>1033</td><td>A network error occurred while attempting to read from the file [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_39</td><td>1033</td><td>An error occurred while attempting to create the directory [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_4</td><td>1033</td><td>Internal Error [1]. [2]{, [3]}{, [4]}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_40</td><td>1033</td><td>A network error occurred while attempting to create the directory [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_41</td><td>1033</td><td>A network error occurred while attempting to open the source file cabinet [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_42</td><td>1033</td><td>The specified path is too long [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_43</td><td>1033</td><td>The Installer has insufficient privileges to modify the file [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_44</td><td>1033</td><td>A portion of the path [2] exceeds the length allowed by the system.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_45</td><td>1033</td><td>The path [2] contains words that are not valid in folders.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_46</td><td>1033</td><td>The path [2] contains an invalid character.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_47</td><td>1033</td><td>[2] is not a valid short file name.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_48</td><td>1033</td><td>Error getting file security: [3] GetLastError: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_49</td><td>1033</td><td>Invalid Drive: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_5</td><td>1033</td><td>{{Disk full: }}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_50</td><td>1033</td><td>Could not create key [2]. {{ System error [3].}}  Verify that you have sufficient access to that key, or contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_51</td><td>1033</td><td>Could not open key: [2]. {{ System error [3].}}  Verify that you have sufficient access to that key, or contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_52</td><td>1033</td><td>Could not delete value [2] from key [3]. {{ System error [4].}}  Verify that you have sufficient access to that key, or contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_53</td><td>1033</td><td>Could not delete key [2]. {{ System error [3].}}  Verify that you have sufficient access to that key, or contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_54</td><td>1033</td><td>Could not read value [2] from key [3]. {{ System error [4].}}  Verify that you have sufficient access to that key, or contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_55</td><td>1033</td><td>Could not write value [2] to key [3]. {{ System error [4].}}  Verify that you have sufficient access to that key, or contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_56</td><td>1033</td><td>Could not get value names for key [2]. {{ System error [3].}}  Verify that you have sufficient access to that key, or contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_57</td><td>1033</td><td>Could not get sub key names for key [2]. {{ System error [3].}}  Verify that you have sufficient access to that key, or contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_58</td><td>1033</td><td>Could not read security information for key [2]. {{ System error [3].}}  Verify that you have sufficient access to that key, or contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_59</td><td>1033</td><td>Could not increase the available registry space. [2] KB of free registry space is required for the installation of this application.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_6</td><td>1033</td><td>Action [Time]: [1]. [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_60</td><td>1033</td><td>Another installation is in progress. You must complete that installation before continuing this one.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_61</td><td>1033</td><td>Error accessing secured data. Please make sure the Windows Installer is configured properly and try the installation again.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_62</td><td>1033</td><td>User [2] has previously initiated an installation for product [3].  That user will need to run that installation again before using that product.  Your current installation will now continue.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_63</td><td>1033</td><td>User [2] has previously initiated an installation for product [3].  That user will need to run that installation again before using that product.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_64</td><td>1033</td><td>Out of disk space -- Volume: '[2]'; required space: [3] KB; available space: [4] KB.  Free some disk space and retry.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_65</td><td>1033</td><td>Are you sure you want to cancel?</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_66</td><td>1033</td><td>The file [2][3] is being held in use{ by the following process: Name: [4], ID: [5], Window Title: [6]}.  Close that application and retry.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_67</td><td>1033</td><td>The product [2] is already installed, preventing the installation of this product.  The two products are incompatible.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_68</td><td>1033</td><td>Out of disk space -- Volume: [2]; required space: [3] KB; available space: [4] KB.  If rollback is disabled, enough space is available. Click Cancel to quit, Retry to check available disk space again, or Ignore to continue without rollback.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_69</td><td>1033</td><td>Could not access network location [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_7</td><td>1033</td><td>[ProductName]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_70</td><td>1033</td><td>The following applications should be closed before continuing the installation:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_71</td><td>1033</td><td>Could not find any previously installed compliant products on the machine for installing this product.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_72</td><td>1033</td><td>The key [2] is not valid.  Verify that you entered the correct key.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_73</td><td>1033</td><td>The installer must restart your system before configuration of [2] can continue.  Click Yes to restart now or No if you plan to restart later.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_74</td><td>1033</td><td>You must restart your system for the configuration changes made to [2] to take effect. Click Yes to restart now or No if you plan to restart later.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_75</td><td>1033</td><td>An installation for [2] is currently suspended.  You must undo the changes made by that installation to continue.  Do you want to undo those changes?</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_76</td><td>1033</td><td>A previous installation for this product is in progress.  You must undo the changes made by that installation to continue.  Do you want to undo those changes?</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_77</td><td>1033</td><td>No valid source could be found for product [2].  The Windows Installer cannot continue.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_78</td><td>1033</td><td>Installation operation completed successfully.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_79</td><td>1033</td><td>Installation operation failed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_8</td><td>1033</td><td>{[2]}{, [3]}{, [4]}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_80</td><td>1033</td><td>Product: [2] -- [3]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_81</td><td>1033</td><td>You may either restore your computer to its previous state or continue the installation later. Would you like to restore?</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_82</td><td>1033</td><td>An error occurred while writing installation information to disk.  Check to make sure enough disk space is available, and click Retry, or Cancel to end the installation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_83</td><td>1033</td><td>One or more of the files required to restore your computer to its previous state could not be found.  Restoration will not be possible.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_84</td><td>1033</td><td>The path [2] is not valid.  Please specify a valid path.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_85</td><td>1033</td><td>Out of memory. Shut down other applications before retrying.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_86</td><td>1033</td><td>There is no disk in drive [2]. Please insert one and click Retry, or click Cancel to go back to the previously selected volume.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_87</td><td>1033</td><td>There is no disk in drive [2]. Please insert one and click Retry, or click Cancel to return to the browse dialog and select a different volume.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_88</td><td>1033</td><td>The folder [2] does not exist.  Please enter a path to an existing folder.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_89</td><td>1033</td><td>You have insufficient privileges to read this folder.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_9</td><td>1033</td><td>Message type: [1], Argument: [2]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_90</td><td>1033</td><td>A valid destination folder for the installation could not be determined.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_91</td><td>1033</td><td>Error attempting to read from the source installation database: [2].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_92</td><td>1033</td><td>Scheduling reboot operation: Renaming file [2] to [3]. Must reboot to complete operation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_93</td><td>1033</td><td>Scheduling reboot operation: Deleting file [2]. Must reboot to complete operation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_94</td><td>1033</td><td>Module [2] failed to register.  HRESULT [3].  Contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_95</td><td>1033</td><td>Module [2] failed to unregister.  HRESULT [3].  Contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_96</td><td>1033</td><td>Failed to cache package [2]. Error: [3]. Contact your support personnel.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_97</td><td>1033</td><td>Could not register font [2].  Verify that you have sufficient permissions to install fonts, and that the system supports this font.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_98</td><td>1033</td><td>Could not unregister font [2]. Verify that you have sufficient permissions to remove fonts.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ERROR_99</td><td>1033</td><td>Could not create shortcut [2]. Verify that the destination folder exists and that you can access it.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_INSTALLDIR</td><td>1033</td><td>[INSTALLDIR]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_INSTALLSHIELD</td><td>1033</td><td>InstallShield</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_INSTALLSHIELD_FORMATTED</td><td>1033</td><td>{&amp;MSSWhiteSerif8}InstallShield</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ISSCRIPT_VERSION_MISSING</td><td>1033</td><td>The InstallScript engine is missing from this machine.  If available, please run ISScript.msi, or contact your support personnel for further assistance.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_ISSCRIPT_VERSION_OLD</td><td>1033</td><td>The InstallScript engine on this machine is older than the version required to run this setup.  If available, please install the latest version of ISScript.msi, or contact your support personnel for further assistance.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_NEXT</td><td>1033</td><td>&amp;Next &gt;</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_OK</td><td>1033</td><td>OK</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PREREQUISITE_SETUP_BROWSE</td><td>1033</td><td>Open [ProductName]'s original [SETUPEXENAME]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PREREQUISITE_SETUP_INVALID</td><td>1033</td><td>This executable file does not appear to be the original executable file for [ProductName]. Without using the original [SETUPEXENAME] to install additional dependencies, [ProductName] may not work correctly. Would you like to find the original [SETUPEXENAME]?</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PREREQUISITE_SETUP_SEARCH</td><td>1033</td><td>This installation may require additional dependencies. Without its dependencies, [ProductName] may not work correctly. Would you like to find the original [SETUPEXENAME]?</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PREVENT_DOWNGRADE_EXIT</td><td>1033</td><td>A newer version of this application is already installed on this computer. If you wish to install this version, please uninstall the newer version first. Click OK to exit the wizard.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PRINT_BUTTON</td><td>1033</td><td>&amp;Print</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PRODUCTNAME_INSTALLSHIELD</td><td>1033</td><td>[ProductName] - InstallShield Wizard</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_CREATEAPPPOOL</td><td>1033</td><td>Creating application pool %s</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_CREATEAPPPOOLS</td><td>1033</td><td>Creating application Pools...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_CREATEVROOT</td><td>1033</td><td>Creating IIS virtual directory %s</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_CREATEVROOTS</td><td>1033</td><td>Creating IIS virtual directories...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_CREATEWEBSERVICEEXTENSION</td><td>1033</td><td>Creating web service extension</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_CREATEWEBSERVICEEXTENSIONS</td><td>1033</td><td>Creating web service extensions...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_CREATEWEBSITE</td><td>1033</td><td>Creating IIS website %s</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_CREATEWEBSITES</td><td>1033</td><td>Creating IIS websites...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_EXTRACT</td><td>1033</td><td>Extracting information for IIS virtual directories...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_EXTRACTDONE</td><td>1033</td><td>Extracted information for IIS virtual directories...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_REMOVEAPPPOOL</td><td>1033</td><td>Removing application pool</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_REMOVEAPPPOOLS</td><td>1033</td><td>Removing application pools...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_REMOVESITE</td><td>1033</td><td>Removing web site at port %d</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_REMOVEVROOT</td><td>1033</td><td>Removing IIS virtual directory %s</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_REMOVEVROOTS</td><td>1033</td><td>Removing IIS virtual directories...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_REMOVEWEBSERVICEEXTENSION</td><td>1033</td><td>Removing web service extension</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_REMOVEWEBSERVICEEXTENSIONS</td><td>1033</td><td>Removing web service extensions...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_REMOVEWEBSITES</td><td>1033</td><td>Removing IIS websites...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_ROLLBACKAPPPOOLS</td><td>1033</td><td>Rolling back application pools...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_ROLLBACKVROOTS</td><td>1033</td><td>Rolling back virtual directory and web site changes...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_IIS_ROLLBACKWEBSERVICEEXTENSIONS</td><td>1033</td><td>Rolling back web service extensions...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_TEXTFILECHANGS_REPLACE</td><td>1033</td><td>Replacing %s with %s in %s...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_XML_COSTING</td><td>1033</td><td>Costing XML files...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_XML_CREATE_FILE</td><td>1033</td><td>Creating XML file %s...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_XML_FILES</td><td>1033</td><td>Performing XML file changes...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_XML_REMOVE_FILE</td><td>1033</td><td>Removing XML file %s...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_XML_ROLLBACK_FILES</td><td>1033</td><td>Rolling back XML file changes...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_PROGMSG_XML_UPDATE_FILE</td><td>1033</td><td>Updating XML file %s...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SETUPEXE_EXPIRE_MSG</td><td>1033</td><td>This setup works until %s. The setup will now exit.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SETUPEXE_LAUNCH_COND_E</td><td>1033</td><td>This setup was built with an evaluation version of InstallShield and can only be launched from setup.exe.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME1</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950330574</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME10</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950331182</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME11</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950331182</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME12</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950331182</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME13</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950331182</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME14</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950333230</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME2</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950330574</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME3</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950330574</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME4</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950330574</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME5</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950330574</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME6</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950330574</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME7</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950330574</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME8</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950331182</td></row>
		<row><td>IDS_SHORTCUT_DISPLAY_NAME9</td><td>1033</td><td>LAUNCH~1.EXE|Launch TestEnhancedeMoteLCD.exe</td><td>0</td><td/><td>950331182</td></row>
		<row><td>IDS_SQLBROWSE_INTRO</td><td>1033</td><td>From the list of servers below, select the database server you would like to target.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLBROWSE_INTRO_DB</td><td>1033</td><td>From the list of catalog names below, select the database catalog you would like to target.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLBROWSE_INTRO_TEMPLATE</td><td>1033</td><td>[IS_SQLBROWSE_INTRO]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLLOGIN_BROWSE</td><td>1033</td><td>B&amp;rowse...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLLOGIN_BROWSE_DB</td><td>1033</td><td>Br&amp;owse...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLLOGIN_CATALOG</td><td>1033</td><td>&amp;Name of database catalog:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLLOGIN_CONNECT</td><td>1033</td><td>Connect using:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLLOGIN_DESC</td><td>1033</td><td>Select database server and authentication method</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLLOGIN_ID</td><td>1033</td><td>&amp;Login ID:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLLOGIN_INTRO</td><td>1033</td><td>Select the database server to install to from the list below or click Browse to see a list of all database servers. You can also specify the way to authenticate your login using your current credentials or a SQL Login ID and Password.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLLOGIN_PSWD</td><td>1033</td><td>&amp;Password:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLLOGIN_SERVER</td><td>1033</td><td>&amp;Database Server:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLLOGIN_SERVER2</td><td>1033</td><td>&amp;Database server that you are installing to:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLLOGIN_SQL</td><td>1033</td><td>S&amp;erver authentication using the Login ID and password below</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLLOGIN_TITLE</td><td>1033</td><td>{&amp;MSSansBold8}Database Server</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLLOGIN_WIN</td><td>1033</td><td>&amp;Windows authentication credentials of current user</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLSCRIPT_INSTALLING</td><td>1033</td><td>Executing SQL Install Script...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SQLSCRIPT_UNINSTALLING</td><td>1033</td><td>Executing SQL Uninstall Script...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_STANDARD_USE_SETUPEXE</td><td>1033</td><td>This installation cannot be run by directly launching the MSI package. You must run setup.exe.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SetupTips_Advertise</td><td>1033</td><td>Will be installed on first use. (Available only if the feature supports this option.)</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SetupTips_AllInstalledLocal</td><td>1033</td><td>Will be completely installed to the local hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SetupTips_CustomSetup</td><td>1033</td><td>{&amp;MSSansBold8}Custom Setup Tips</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SetupTips_CustomSetupDescription</td><td>1033</td><td>Custom Setup allows you to selectively install program features.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SetupTips_IconInstallState</td><td>1033</td><td>The icon next to the feature name indicates the install state of the feature. Click the icon to drop down the install state menu for each feature.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SetupTips_InstallState</td><td>1033</td><td>This install state means the feature...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SetupTips_Network</td><td>1033</td><td>Will be installed to run from the network. (Available only if the feature supports this option.)</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SetupTips_OK</td><td>1033</td><td>OK</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SetupTips_SubFeaturesInstalledLocal</td><td>1033</td><td>Will have some subfeatures installed to the local hard drive. (Available only if the feature has subfeatures.)</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_SetupTips_WillNotBeInstalled</td><td>1033</td><td>Will not be installed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_Available</td><td>1033</td><td>Available</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_Bytes</td><td>1033</td><td>bytes</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_CompilingFeaturesCost</td><td>1033</td><td>Compiling cost for this feature...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_Differences</td><td>1033</td><td>Differences</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_DiskSize</td><td>1033</td><td>Disk Size</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureCompletelyRemoved</td><td>1033</td><td>This feature will be completely removed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureContinueNetwork</td><td>1033</td><td>This feature will continue to be run from the network</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureFreeSpace</td><td>1033</td><td>This feature frees up [1] on your hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureInstalledCD</td><td>1033</td><td>This feature, and all subfeatures, will be installed to run from the CD.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureInstalledCD2</td><td>1033</td><td>This feature will be installed to run from CD.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureInstalledLocal</td><td>1033</td><td>This feature, and all subfeatures, will be installed on local hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureInstalledLocal2</td><td>1033</td><td>This feature will be installed on local hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureInstalledNetwork</td><td>1033</td><td>This feature, and all subfeatures, will be installed to run from the network.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureInstalledNetwork2</td><td>1033</td><td>This feature will be installed to run from network.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureInstalledRequired</td><td>1033</td><td>Will be installed when required.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureInstalledWhenRequired</td><td>1033</td><td>This feature will be set to be installed when required.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureInstalledWhenRequired2</td><td>1033</td><td>This feature will be installed when required.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureLocal</td><td>1033</td><td>This feature will be installed on the local hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureLocal2</td><td>1033</td><td>This feature will be installed on your local hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureNetwork</td><td>1033</td><td>This feature will be installed to run from the network.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureNetwork2</td><td>1033</td><td>This feature will be available to run from the network.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureNotAvailable</td><td>1033</td><td>This feature will not be available.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureOnCD</td><td>1033</td><td>This feature will be installed to run from CD.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureOnCD2</td><td>1033</td><td>This feature will be available to run from CD.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureRemainLocal</td><td>1033</td><td>This feature will remain on your local hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureRemoveNetwork</td><td>1033</td><td>This feature will be removed from your local hard drive, but will be still available to run from the network.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureRemovedCD</td><td>1033</td><td>This feature will be removed from your local hard drive but will still be available to run from CD.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureRemovedUnlessRequired</td><td>1033</td><td>This feature will be removed from your local hard drive but will be set to be installed when required.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureRequiredSpace</td><td>1033</td><td>This feature requires [1] on your hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureRunFromCD</td><td>1033</td><td>This feature will continue to be run from the CD</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureSpaceFree</td><td>1033</td><td>This feature frees up [1] on your hard drive. It has [2] of [3] subfeatures selected. The subfeatures free up [4] on your hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureSpaceFree2</td><td>1033</td><td>This feature frees up [1] on your hard drive. It has [2] of [3] subfeatures selected. The subfeatures require [4] on your hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureSpaceFree3</td><td>1033</td><td>This feature requires [1] on your hard drive. It has [2] of [3] subfeatures selected. The subfeatures free up [4] on your hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureSpaceFree4</td><td>1033</td><td>This feature requires [1] on your hard drive. It has [2] of [3] subfeatures selected. The subfeatures require [4] on your hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureUnavailable</td><td>1033</td><td>This feature will become unavailable.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureUninstallNoNetwork</td><td>1033</td><td>This feature will be uninstalled completely, and you won't be able to run it from the network.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureWasCD</td><td>1033</td><td>This feature was run from the CD but will be set to be installed when required.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureWasCDLocal</td><td>1033</td><td>This feature was run from the CD but will be installed on the local hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureWasOnNetworkInstalled</td><td>1033</td><td>This feature was run from the network but will be installed when required.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureWasOnNetworkLocal</td><td>1033</td><td>This feature was run from the network but will be installed on the local hard drive.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_FeatureWillBeUninstalled</td><td>1033</td><td>This feature will be uninstalled completely, and you won't be able to run it from CD.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_Folder</td><td>1033</td><td>Fldr|New Folder</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_GB</td><td>1033</td><td>GB</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_KB</td><td>1033</td><td>KB</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_MB</td><td>1033</td><td>MB</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_Required</td><td>1033</td><td>Required</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_TimeRemaining</td><td>1033</td><td>Time remaining: {[1] min }{[2] sec}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS_UITEXT_Volume</td><td>1033</td><td>Volume</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__AgreeToLicense_0</td><td>1033</td><td>I &amp;do not accept the terms in the license agreement</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__AgreeToLicense_1</td><td>1033</td><td>I &amp;accept the terms in the license agreement</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__DatabaseFolder_ChangeFolder</td><td>1033</td><td>Click Next to install to this folder, or click Change to install to a different folder.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__DatabaseFolder_DatabaseDir</td><td>1033</td><td>[DATABASEDIR]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__DatabaseFolder_DatabaseFolder</td><td>1033</td><td>{&amp;MSSansBold8}Database Folder</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__DestinationFolder_Change</td><td>1033</td><td>&amp;Change...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__DestinationFolder_ChangeFolder</td><td>1033</td><td>Click Next to install to this folder, or click Change to install to a different folder.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__DestinationFolder_DestinationFolder</td><td>1033</td><td>{&amp;MSSansBold8}Destination Folder</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__DestinationFolder_InstallTo</td><td>1033</td><td>Install [ProductName] to:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__DisplayName_Custom</td><td>1033</td><td>Custom</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__DisplayName_Minimal</td><td>1033</td><td>Minimal</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__DisplayName_Typical</td><td>1033</td><td>Typical</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallBrowse_11</td><td>1033</td><td/><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallBrowse_4</td><td>1033</td><td/><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallBrowse_8</td><td>1033</td><td/><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallBrowse_BrowseDestination</td><td>1033</td><td>Browse to the destination folder.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallBrowse_ChangeDestination</td><td>1033</td><td>{&amp;MSSansBold8}Change Current Destination Folder</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallBrowse_CreateFolder</td><td>1033</td><td>Create new folder|</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallBrowse_FolderName</td><td>1033</td><td>&amp;Folder name:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallBrowse_LookIn</td><td>1033</td><td>&amp;Look in:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallBrowse_UpOneLevel</td><td>1033</td><td>Up one level|</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallPointWelcome_ServerImage</td><td>1033</td><td>The InstallShield(R) Wizard will create a server image of [ProductName] at a specified network location. To continue, click Next.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallPointWelcome_Wizard</td><td>1033</td><td>{&amp;TahomaBold10}Welcome to the InstallShield Wizard for [ProductName]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallPoint_Change</td><td>1033</td><td>&amp;Change...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallPoint_EnterNetworkLocation</td><td>1033</td><td>Enter the network location or click Change to browse to a location.  Click Install to create a server image of [ProductName] at the specified network location or click Cancel to exit the wizard.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallPoint_Install</td><td>1033</td><td>&amp;Install</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallPoint_NetworkLocation</td><td>1033</td><td>&amp;Network location:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallPoint_NetworkLocationFormatted</td><td>1033</td><td>{&amp;MSSansBold8}Network Location</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsAdminInstallPoint_SpecifyNetworkLocation</td><td>1033</td><td>Specify a network location for the server image of the product.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseButton</td><td>1033</td><td>&amp;Browse...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseFolderDlg_11</td><td>1033</td><td/><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseFolderDlg_4</td><td>1033</td><td/><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseFolderDlg_8</td><td>1033</td><td/><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseFolderDlg_BrowseDestFolder</td><td>1033</td><td>Browse to the destination folder.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseFolderDlg_ChangeCurrentFolder</td><td>1033</td><td>{&amp;MSSansBold8}Change Current Destination Folder</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseFolderDlg_CreateFolder</td><td>1033</td><td>Create New Folder|</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseFolderDlg_FolderName</td><td>1033</td><td>&amp;Folder name:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseFolderDlg_LookIn</td><td>1033</td><td>&amp;Look in:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseFolderDlg_OK</td><td>1033</td><td>OK</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseFolderDlg_UpOneLevel</td><td>1033</td><td>Up One Level|</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseForAccount</td><td>1033</td><td>Browse for a User Account</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseGroup</td><td>1033</td><td>Select a Group</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsBrowseUsernameTitle</td><td>1033</td><td>Select a User Name</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCancelDlg_ConfirmCancel</td><td>1033</td><td>Are you sure you want to cancel [ProductName] installation?</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCancelDlg_No</td><td>1033</td><td>&amp;No</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCancelDlg_Yes</td><td>1033</td><td>&amp;Yes</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsConfirmPassword</td><td>1033</td><td>Con&amp;firm password:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCreateNewUserTitle</td><td>1033</td><td>New User Information</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCreateUserBrowse</td><td>1033</td><td>N&amp;ew User Information...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCustomSelectionDlg_Change</td><td>1033</td><td>&amp;Change...</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCustomSelectionDlg_ClickFeatureIcon</td><td>1033</td><td>Click on an icon in the list below to change how a feature is installed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCustomSelectionDlg_CustomSetup</td><td>1033</td><td>{&amp;MSSansBold8}Custom Setup</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCustomSelectionDlg_FeatureDescription</td><td>1033</td><td>Feature Description</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCustomSelectionDlg_FeaturePath</td><td>1033</td><td>&lt;selected feature path&gt;</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCustomSelectionDlg_FeatureSize</td><td>1033</td><td>Feature size</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCustomSelectionDlg_Help</td><td>1033</td><td>&amp;Help</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCustomSelectionDlg_InstallTo</td><td>1033</td><td>Install to:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCustomSelectionDlg_MultilineDescription</td><td>1033</td><td>Multiline description of the currently selected item</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCustomSelectionDlg_SelectFeatures</td><td>1033</td><td>Select the program features you want installed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsCustomSelectionDlg_Space</td><td>1033</td><td>&amp;Space</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsDiskSpaceDlg_DiskSpace</td><td>1033</td><td>Disk space required for the installation exceeds available disk space.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsDiskSpaceDlg_HighlightedVolumes</td><td>1033</td><td>The highlighted volumes do not have enough disk space available for the currently selected features. You can remove files from the highlighted volumes, choose to install fewer features onto local drives, or select different destination drives.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsDiskSpaceDlg_Numbers</td><td>1033</td><td>{120}{70}{70}{70}{70}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsDiskSpaceDlg_OK</td><td>1033</td><td>OK</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsDiskSpaceDlg_OutOfDiskSpace</td><td>1033</td><td>{&amp;MSSansBold8}Out of Disk Space</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsDomainOrServer</td><td>1033</td><td>&amp;Domain or server:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsErrorDlg_Abort</td><td>1033</td><td>&amp;Abort</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsErrorDlg_ErrorText</td><td>1033</td><td>&lt;error text goes here&gt;&lt;error text goes here&gt;&lt;error text goes here&gt;&lt;error text goes here&gt;&lt;error text goes here&gt;&lt;error text goes here&gt;&lt;error text goes here&gt;&lt;error text goes here&gt;&lt;error text goes here&gt;&lt;error text goes here&gt;&lt;error text goes here&gt;</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsErrorDlg_Ignore</td><td>1033</td><td>&amp;Ignore</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsErrorDlg_InstallerInfo</td><td>1033</td><td>[ProductName] Installer Information</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsErrorDlg_NO</td><td>1033</td><td>&amp;No</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsErrorDlg_OK</td><td>1033</td><td>&amp;OK</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsErrorDlg_Retry</td><td>1033</td><td>&amp;Retry</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsErrorDlg_Yes</td><td>1033</td><td>&amp;Yes</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsExitDialog_Finish</td><td>1033</td><td>&amp;Finish</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsExitDialog_InstallSuccess</td><td>1033</td><td>The InstallShield Wizard has successfully installed [ProductName]. Click Finish to exit the wizard.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsExitDialog_LaunchProgram</td><td>1033</td><td>Launch the program</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsExitDialog_ShowReadMe</td><td>1033</td><td>Show the readme file</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsExitDialog_UninstallSuccess</td><td>1033</td><td>The InstallShield Wizard has successfully uninstalled [ProductName]. Click Finish to exit the wizard.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsExitDialog_Update_InternetConnection</td><td>1033</td><td>Your Internet connection can be used to make sure that you have the latest updates.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsExitDialog_Update_PossibleUpdates</td><td>1033</td><td>Some program files might have been updated since you purchased your copy of [ProductName].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsExitDialog_Update_SetupFinished</td><td>1033</td><td>Setup has finished installing [ProductName].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsExitDialog_Update_YesCheckForUpdates</td><td>1033</td><td>&amp;Yes, check for program updates (Recommended) after the setup completes.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsExitDialog_WizardCompleted</td><td>1033</td><td>{&amp;TahomaBold10}InstallShield Wizard Completed</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFatalError_ClickFinish</td><td>1033</td><td>Click Finish to exit the wizard.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFatalError_Finish</td><td>1033</td><td>&amp;Finish</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFatalError_KeepOrRestore</td><td>1033</td><td>You can either keep any existing installed elements on your system to continue this installation at a later time or you can restore your system to its original state prior to the installation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFatalError_NotModified</td><td>1033</td><td>Your system has not been modified. To complete installation at another time, please run setup again.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFatalError_RestoreOrContinueLater</td><td>1033</td><td>Click Restore or Continue Later to exit the wizard.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFatalError_WizardCompleted</td><td>1033</td><td>{&amp;TahomaBold10}InstallShield Wizard Completed</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFatalError_WizardInterrupted</td><td>1033</td><td>The wizard was interrupted before [ProductName] could be completely installed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFeatureDetailsDlg_DiskSpaceRequirements</td><td>1033</td><td>{&amp;MSSansBold8}Disk Space Requirements</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFeatureDetailsDlg_Numbers</td><td>1033</td><td>{120}{70}{70}{70}{70}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFeatureDetailsDlg_OK</td><td>1033</td><td>OK</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFeatureDetailsDlg_SpaceRequired</td><td>1033</td><td>The disk space required for the installation of the selected features.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFeatureDetailsDlg_VolumesTooSmall</td><td>1033</td><td>The highlighted volumes do not have enough disk space available for the currently selected features. You can remove files from the highlighted volumes, choose to install fewer features onto local drives, or select different destination drives.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFilesInUse_ApplicationsUsingFiles</td><td>1033</td><td>The following applications are using files that need to be updated by this setup. Close these applications and click Retry to continue.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFilesInUse_Exit</td><td>1033</td><td>&amp;Exit</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFilesInUse_FilesInUse</td><td>1033</td><td>{&amp;MSSansBold8}Files in Use</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFilesInUse_FilesInUseMessage</td><td>1033</td><td>Some files that need to be updated are currently in use.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFilesInUse_Ignore</td><td>1033</td><td>&amp;Ignore</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsFilesInUse_Retry</td><td>1033</td><td>&amp;Retry</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsGroup</td><td>1033</td><td>&amp;Group:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsGroupLabel</td><td>1033</td><td>Gr&amp;oup:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsInitDlg_1</td><td>1033</td><td/><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsInitDlg_2</td><td>1033</td><td/><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsInitDlg_PreparingWizard</td><td>1033</td><td>[ProductName] Setup is preparing the InstallShield Wizard which will guide you through the program setup process.  Please wait.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsInitDlg_WelcomeWizard</td><td>1033</td><td>{&amp;TahomaBold10}Welcome to the InstallShield Wizard for [ProductName]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsLicenseDlg_LicenseAgreement</td><td>1033</td><td>{&amp;MSSansBold8}License Agreement</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsLicenseDlg_ReadLicenseAgreement</td><td>1033</td><td>Please read the following license agreement carefully.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsLogonInfoDescription</td><td>1033</td><td>Specify the user name and password of the user account that will logon to use this application. The user account must be in the form DOMAIN\Username.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsLogonInfoTitle</td><td>1033</td><td>{&amp;MSSansBold8}Logon Information</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsLogonInfoTitleDescription</td><td>1033</td><td>Specify a user name and password</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsLogonNewUserDescription</td><td>1033</td><td>Select the button below to specify information about a new user that will be created during the installation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsMaintenanceDlg_ChangeFeatures</td><td>1033</td><td>Change which program features are installed. This option displays the Custom Selection dialog in which you can change the way features are installed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsMaintenanceDlg_MaitenanceOptions</td><td>1033</td><td>Modify, repair, or remove the program.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsMaintenanceDlg_Modify</td><td>1033</td><td>{&amp;MSSansBold8}&amp;Modify</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsMaintenanceDlg_ProgramMaintenance</td><td>1033</td><td>{&amp;MSSansBold8}Program Maintenance</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsMaintenanceDlg_Remove</td><td>1033</td><td>{&amp;MSSansBold8}&amp;Remove</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsMaintenanceDlg_RemoveProductName</td><td>1033</td><td>Remove [ProductName] from your computer.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsMaintenanceDlg_Repair</td><td>1033</td><td>{&amp;MSSansBold8}Re&amp;pair</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsMaintenanceDlg_RepairMessage</td><td>1033</td><td>Repair installation errors in the program. This option fixes missing or corrupt files, shortcuts, and registry entries.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsMaintenanceWelcome_MaintenanceOptionsDescription</td><td>1033</td><td>The InstallShield(R) Wizard will allow you to modify, repair, or remove [ProductName]. To continue, click Next.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsMaintenanceWelcome_WizardWelcome</td><td>1033</td><td>{&amp;TahomaBold10}Welcome to the InstallShield Wizard for [ProductName]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsMsiRMFilesInUse_ApplicationsUsingFiles</td><td>1033</td><td>The following applications are using files that need to be updated by this setup.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsMsiRMFilesInUse_CloseRestart</td><td>1033</td><td>Automatically close and attempt to restart applications.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsMsiRMFilesInUse_RebootAfter</td><td>1033</td><td>Do not close applications. (A reboot will be required.)</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsPatchDlg_PatchClickUpdate</td><td>1033</td><td>The InstallShield(R) Wizard will install the Patch for [ProductName] on your computer.  To continue, click Update.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsPatchDlg_PatchWizard</td><td>1033</td><td>[ProductName] Patch - InstallShield Wizard</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsPatchDlg_Update</td><td>1033</td><td>&amp;Update &gt;</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsPatchDlg_WelcomePatchWizard</td><td>1033</td><td>{&amp;TahomaBold10}Welcome to the Patch for [ProductName]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsProgressDlg_2</td><td>1033</td><td/><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsProgressDlg_Hidden</td><td>1033</td><td>(Hidden for now)</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsProgressDlg_HiddenTimeRemaining</td><td>1033</td><td>)Hidden for now)Estimated time remaining:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsProgressDlg_InstallingProductName</td><td>1033</td><td>{&amp;MSSansBold8}Installing [ProductName]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsProgressDlg_ProgressDone</td><td>1033</td><td>Progress done</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsProgressDlg_SecHidden</td><td>1033</td><td>(Hidden for now)Sec.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsProgressDlg_Status</td><td>1033</td><td>Status:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsProgressDlg_Uninstalling</td><td>1033</td><td>{&amp;MSSansBold8}Uninstalling [ProductName]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsProgressDlg_UninstallingFeatures</td><td>1033</td><td>The program features you selected are being uninstalled.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsProgressDlg_UninstallingFeatures2</td><td>1033</td><td>The program features you selected are being installed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsProgressDlg_WaitUninstall</td><td>1033</td><td>Please wait while the InstallShield Wizard uninstalls [ProductName]. This may take several minutes.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsProgressDlg_WaitUninstall2</td><td>1033</td><td>Please wait while the InstallShield Wizard installs [ProductName]. This may take several minutes.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsReadmeDlg_Cancel</td><td>1033</td><td>&amp;Cancel</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsReadmeDlg_PleaseReadInfo</td><td>1033</td><td>Please read the following readme information carefully.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsReadmeDlg_ReadMeInfo</td><td>1033</td><td>{&amp;MSSansBold8}Readme Information</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsRegisterUserDlg_16</td><td>1033</td><td/><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsRegisterUserDlg_Anyone</td><td>1033</td><td>&amp;Anyone who uses this computer (all users)</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsRegisterUserDlg_CustomerInformation</td><td>1033</td><td>{&amp;MSSansBold8}Customer Information</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsRegisterUserDlg_InstallFor</td><td>1033</td><td>Install this application for:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsRegisterUserDlg_OnlyMe</td><td>1033</td><td>Only for &amp;me ([USERNAME])</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsRegisterUserDlg_Organization</td><td>1033</td><td>&amp;Organization:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsRegisterUserDlg_PleaseEnterInfo</td><td>1033</td><td>Please enter your information.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsRegisterUserDlg_SerialNumber</td><td>1033</td><td>&amp;Serial Number:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsRegisterUserDlg_Tahoma50</td><td>1033</td><td>{\Tahoma8}{50}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsRegisterUserDlg_Tahoma80</td><td>1033</td><td>{\Tahoma8}{80}</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsRegisterUserDlg_UserName</td><td>1033</td><td>&amp;User Name:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsResumeDlg_ResumeSuspended</td><td>1033</td><td>The InstallShield(R) Wizard will complete the suspended installation of [ProductName] on your computer. To continue, click Next.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsResumeDlg_Resuming</td><td>1033</td><td>{&amp;TahomaBold10}Resuming the InstallShield Wizard for [ProductName]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsResumeDlg_WizardResume</td><td>1033</td><td>The InstallShield(R) Wizard will complete the installation of [ProductName] on your computer. To continue, click Next.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSelectDomainOrServer</td><td>1033</td><td>Select a Domain or Server</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSelectDomainUserInstructions</td><td>1033</td><td>Use the browse buttons to select a domain\server and a user name.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSetupComplete_ShowMsiLog</td><td>1033</td><td>Show the Windows Installer log</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSetupTypeMinDlg_13</td><td>1033</td><td/><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSetupTypeMinDlg_AllFeatures</td><td>1033</td><td>All program features will be installed. (Requires the most disk space.)</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSetupTypeMinDlg_ChooseFeatures</td><td>1033</td><td>Choose which program features you want installed and where they will be installed. Recommended for advanced users.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSetupTypeMinDlg_ChooseSetupType</td><td>1033</td><td>Choose the setup type that best suits your needs.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSetupTypeMinDlg_Complete</td><td>1033</td><td>{&amp;MSSansBold8}&amp;Complete</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSetupTypeMinDlg_Custom</td><td>1033</td><td>{&amp;MSSansBold8}Cu&amp;stom</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSetupTypeMinDlg_Minimal</td><td>1033</td><td>{&amp;MSSansBold8}&amp;Minimal</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSetupTypeMinDlg_MinimumFeatures</td><td>1033</td><td>Minimum required features will be installed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSetupTypeMinDlg_SelectSetupType</td><td>1033</td><td>Please select a setup type.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSetupTypeMinDlg_SetupType</td><td>1033</td><td>{&amp;MSSansBold8}Setup Type</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsSetupTypeMinDlg_Typical</td><td>1033</td><td>{&amp;MSSansBold8}&amp;Typical</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsUserExit_ClickFinish</td><td>1033</td><td>Click Finish to exit the wizard.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsUserExit_Finish</td><td>1033</td><td>&amp;Finish</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsUserExit_KeepOrRestore</td><td>1033</td><td>You can either keep any existing installed elements on your system to continue this installation at a later time or you can restore your system to its original state prior to the installation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsUserExit_NotModified</td><td>1033</td><td>Your system has not been modified. To install this program at a later time, please run the installation again.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsUserExit_RestoreOrContinue</td><td>1033</td><td>Click Restore or Continue Later to exit the wizard.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsUserExit_WizardCompleted</td><td>1033</td><td>{&amp;TahomaBold10}InstallShield Wizard Completed</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsUserExit_WizardInterrupted</td><td>1033</td><td>The wizard was interrupted before [ProductName] could be completely installed.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsUserNameLabel</td><td>1033</td><td>&amp;User name:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_BackOrCancel</td><td>1033</td><td>If you want to review or change any of your installation settings, click Back. Click Cancel to exit the wizard.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_ClickInstall</td><td>1033</td><td>Click Install to begin the installation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_Company</td><td>1033</td><td>Company: [COMPANYNAME]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_CurrentSettings</td><td>1033</td><td>Current Settings:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_DestFolder</td><td>1033</td><td>Destination Folder:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_Install</td><td>1033</td><td>&amp;Install</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_Installdir</td><td>1033</td><td>[INSTALLDIR]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_ModifyReady</td><td>1033</td><td>{&amp;MSSansBold8}Ready to Modify the Program</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_ReadyInstall</td><td>1033</td><td>{&amp;MSSansBold8}Ready to Install the Program</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_ReadyRepair</td><td>1033</td><td>{&amp;MSSansBold8}Ready to Repair the Program</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_SelectedSetupType</td><td>1033</td><td>[SelectedSetupType]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_Serial</td><td>1033</td><td>Serial: [ISX_SERIALNUM]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_SetupType</td><td>1033</td><td>Setup Type:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_UserInfo</td><td>1033</td><td>User Information:</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_UserName</td><td>1033</td><td>Name: [USERNAME]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyReadyDlg_WizardReady</td><td>1033</td><td>The wizard is ready to begin installation.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyRemoveAllDlg_ChoseRemoveProgram</td><td>1033</td><td>You have chosen to remove the program from your system.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyRemoveAllDlg_ClickBack</td><td>1033</td><td>If you want to review or change any settings, click Back.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyRemoveAllDlg_ClickRemove</td><td>1033</td><td>Click Remove to remove [ProductName] from your computer. After removal, this program will no longer be available for use.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyRemoveAllDlg_Remove</td><td>1033</td><td>&amp;Remove</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsVerifyRemoveAllDlg_RemoveProgram</td><td>1033</td><td>{&amp;MSSansBold8}Remove the Program</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsWelcomeDlg_InstallProductName</td><td>1033</td><td>The InstallShield(R) Wizard will install [ProductName] on your computer. To continue, click Next.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsWelcomeDlg_WarningCopyright</td><td>1033</td><td>WARNING: This program is protected by copyright law and international treaties.</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__IsWelcomeDlg_WelcomeProductName</td><td>1033</td><td>{&amp;TahomaBold10}Welcome to the InstallShield Wizard for [ProductName]</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__TargetReq_DESC_COLOR</td><td>1033</td><td>The color settings of your system are not adequate for running [ProductName].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__TargetReq_DESC_OS</td><td>1033</td><td>The operating system is not adequate for running [ProductName].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__TargetReq_DESC_PROCESSOR</td><td>1033</td><td>The processor is not adequate for running [ProductName].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__TargetReq_DESC_RAM</td><td>1033</td><td>The amount of RAM is not adequate for running [ProductName].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>IDS__TargetReq_DESC_RESOLUTION</td><td>1033</td><td>The screen resolution is not adequate for running [ProductName].</td><td>0</td><td/><td>950324174</td></row>
		<row><td>ID_STRING1</td><td>1033</td><td>http://www.Samraksh.com</td><td>0</td><td/><td>950326222</td></row>
		<row><td>ID_STRING2</td><td>1033</td><td>Samraksh</td><td>0</td><td/><td>950326222</td></row>
		<row><td>IIDS_UITEXT_FeatureUninstalled</td><td>1033</td><td>This feature will remain uninstalled.</td><td>0</td><td/><td>950324174</td></row>
	</table>

	<table name="ISSwidtagProperty">
		<col key="yes" def="s72">Name</col>
		<col def="s0">Value</col>
		<row><td>UniqueId</td><td>C91EAA7E-6CB1-4620-84CA-61B27D25311C</td></row>
	</table>

	<table name="ISTargetImage">
		<col key="yes" def="s13">UpgradedImage_</col>
		<col key="yes" def="s13">Name</col>
		<col def="s0">MsiPath</col>
		<col def="i2">Order</col>
		<col def="I4">Flags</col>
		<col def="i2">IgnoreMissingFiles</col>
	</table>

	<table name="ISUpgradeMsiItem">
		<col key="yes" def="s72">UpgradeItem</col>
		<col def="s0">ObjectSetupPath</col>
		<col def="S255">ISReleaseFlags</col>
		<col def="i2">ISAttributes</col>
	</table>

	<table name="ISUpgradedImage">
		<col key="yes" def="s13">Name</col>
		<col def="s0">MsiPath</col>
		<col def="s8">Family</col>
	</table>

	<table name="ISVirtualDirectory">
		<col key="yes" def="s72">Directory_</col>
		<col key="yes" def="s72">Name</col>
		<col def="s255">Value</col>
	</table>

	<table name="ISVirtualFile">
		<col key="yes" def="s72">File_</col>
		<col key="yes" def="s72">Name</col>
		<col def="s255">Value</col>
	</table>

	<table name="ISVirtualPackage">
		<col key="yes" def="s72">Name</col>
		<col def="s255">Value</col>
	</table>

	<table name="ISVirtualRegistry">
		<col key="yes" def="s72">Registry_</col>
		<col key="yes" def="s72">Name</col>
		<col def="s255">Value</col>
	</table>

	<table name="ISVirtualRelease">
		<col key="yes" def="s72">ISRelease_</col>
		<col key="yes" def="s72">ISProductConfiguration_</col>
		<col key="yes" def="s255">Name</col>
		<col def="s255">Value</col>
	</table>

	<table name="ISVirtualShortcut">
		<col key="yes" def="s72">Shortcut_</col>
		<col key="yes" def="s72">Name</col>
		<col def="s255">Value</col>
	</table>

	<table name="ISWSEWrap">
		<col key="yes" def="s72">Action_</col>
		<col key="yes" def="s72">Name</col>
		<col def="S0">Value</col>
	</table>

	<table name="ISXmlElement">
		<col key="yes" def="s72">ISXmlElement</col>
		<col def="s72">ISXmlFile_</col>
		<col def="S72">ISXmlElement_Parent</col>
		<col def="L0">XPath</col>
		<col def="L0">Content</col>
		<col def="I4">ISAttributes</col>
	</table>

	<table name="ISXmlElementAttrib">
		<col key="yes" def="s72">ISXmlElementAttrib</col>
		<col key="yes" def="s72">ISXmlElement_</col>
		<col def="L255">Name</col>
		<col def="L0">Value</col>
		<col def="I4">ISAttributes</col>
	</table>

	<table name="ISXmlFile">
		<col key="yes" def="s72">ISXmlFile</col>
		<col def="l255">FileName</col>
		<col def="s72">Component_</col>
		<col def="s72">Directory</col>
		<col def="I4">ISAttributes</col>
		<col def="S0">SelectionNamespaces</col>
		<col def="S255">Encoding</col>
	</table>

	<table name="ISXmlLocator">
		<col key="yes" def="s72">Signature_</col>
		<col key="yes" def="S72">Parent</col>
		<col def="S255">Element</col>
		<col def="S255">Attribute</col>
		<col def="I2">ISAttributes</col>
	</table>

	<table name="Icon">
		<col key="yes" def="s72">Name</col>
		<col def="V0">Data</col>
		<col def="S255">ISBuildSourcePath</col>
		<col def="I2">ISIconIndex</col>
		<row><td>ARPPRODUCTICON.exe</td><td/><td>&lt;ISProductFolder&gt;\redist\Language Independent\OS Independent\setupicon.ico</td><td>0</td></row>
		<row><td>TestEnhancedeMoteL_28933DCD56654D9ABC89318ACC3A8091.exe</td><td/><td>&lt;ISProductFolder&gt;\redist\Language Independent\OS Independent\GenericExe.ico</td><td>0</td></row>
		<row><td>TestEnhancedeMoteL_34B00F37E7A24866ACD602B037F7CDB2.exe</td><td/><td>&lt;ISProductFolder&gt;\redist\Language Independent\OS Independent\GenericExe.ico</td><td>0</td></row>
		<row><td>TestEnhancedeMoteL_3A78F41B03D7443894C38B8AE463E31A.exe</td><td/><td>&lt;ISProductFolder&gt;\redist\Language Independent\OS Independent\GenericExe.ico</td><td>0</td></row>
		<row><td>TestEnhancedeMoteL_46A569DBEA114093AC61E503EC474B8F.exe</td><td/><td>&lt;ISProductFolder&gt;\redist\Language Independent\OS Independent\GenericExe.ico</td><td>0</td></row>
		<row><td>TestEnhancedeMoteL_548A013E6B874F04827BCB90F1A05B2F.exe</td><td/><td>&lt;ISProductFolder&gt;\redist\Language Independent\OS Independent\GenericExe.ico</td><td>0</td></row>
		<row><td>TestEnhancedeMoteL_692433E1D9EE42479267A3820265048D.exe</td><td/><td>&lt;ISProductFolder&gt;\redist\Language Independent\OS Independent\GenericExe.ico</td><td>0</td></row>
		<row><td>TestEnhancedeMoteL_72BEE73F1A9F42F1A97ADB8E8446F3F3.exe</td><td/><td>&lt;ISProductFolder&gt;\redist\Language Independent\OS Independent\GenericExe.ico</td><td>0</td></row>
		<row><td>TestEnhancedeMoteL_991A1BC4E85940C7AA994930DE135726.exe</td><td/><td>&lt;ISProductFolder&gt;\redist\Language Independent\OS Independent\GenericExe.ico</td><td>0</td></row>
		<row><td>TestEnhancedeMoteL_AFEDFCAC860D4E438BDA95868A40DBEC.exe</td><td/><td>&lt;ISProductFolder&gt;\redist\Language Independent\OS Independent\GenericExe.ico</td><td>0</td></row>
		<row><td>TestEnhancedeMoteL_C0D917DE62734EF8B0D915BCEFEB86BD.exe</td><td/><td>&lt;ISProductFolder&gt;\redist\Language Independent\OS Independent\GenericExe.ico</td><td>0</td></row>
		<row><td>TestEnhancedeMoteL_C0E95738BD6D47DE83F2E1603FB786F5.exe</td><td/><td>&lt;ISProductFolder&gt;\redist\Language Independent\OS Independent\GenericExe.ico</td><td>0</td></row>
		<row><td>TestEnhancedeMoteL_FCDF4797A4074FB6A5453D3E0A1239D5.exe</td><td/><td>&lt;ISProductFolder&gt;\redist\Language Independent\OS Independent\GenericExe.ico</td><td>0</td></row>
	</table>

	<table name="IniFile">
		<col key="yes" def="s72">IniFile</col>
		<col def="l255">FileName</col>
		<col def="S72">DirProperty</col>
		<col def="l255">Section</col>
		<col def="l128">Key</col>
		<col def="s255">Value</col>
		<col def="i2">Action</col>
		<col def="s72">Component_</col>
	</table>

	<table name="IniLocator">
		<col key="yes" def="s72">Signature_</col>
		<col def="s255">FileName</col>
		<col def="s96">Section</col>
		<col def="s128">Key</col>
		<col def="I2">Field</col>
		<col def="I2">Type</col>
	</table>

	<table name="InstallExecuteSequence">
		<col key="yes" def="s72">Action</col>
		<col def="S255">Condition</col>
		<col def="I2">Sequence</col>
		<col def="S255">ISComments</col>
		<col def="I4">ISAttributes</col>
		<row><td>AllocateRegistrySpace</td><td>NOT Installed</td><td>1550</td><td>AllocateRegistrySpace</td><td/></row>
		<row><td>AppSearch</td><td/><td>400</td><td>AppSearch</td><td/></row>
		<row><td>BindImage</td><td/><td>4300</td><td>BindImage</td><td/></row>
		<row><td>CCPSearch</td><td>CCP_TEST</td><td>500</td><td>CCPSearch</td><td/></row>
		<row><td>CostFinalize</td><td/><td>1000</td><td>CostFinalize</td><td/></row>
		<row><td>CostInitialize</td><td/><td>800</td><td>CostInitialize</td><td/></row>
		<row><td>CreateFolders</td><td/><td>3700</td><td>CreateFolders</td><td/></row>
		<row><td>CreateShortcuts</td><td/><td>4500</td><td>CreateShortcuts</td><td/></row>
		<row><td>DeleteServices</td><td>VersionNT</td><td>2000</td><td>DeleteServices</td><td/></row>
		<row><td>DuplicateFiles</td><td/><td>4210</td><td>DuplicateFiles</td><td/></row>
		<row><td>FileCost</td><td/><td>900</td><td>FileCost</td><td/></row>
		<row><td>FindRelatedProducts</td><td>NOT ISSETUPDRIVEN</td><td>420</td><td>FindRelatedProducts</td><td/></row>
		<row><td>ISPreventDowngrade</td><td>ISFOUNDNEWERPRODUCTVERSION</td><td>450</td><td>ISPreventDowngrade</td><td/></row>
		<row><td>ISRunSetupTypeAddLocalEvent</td><td>Not Installed And Not ISRUNSETUPTYPEADDLOCALEVENT</td><td>1050</td><td>ISRunSetupTypeAddLocalEvent</td><td/></row>
		<row><td>ISSelfRegisterCosting</td><td/><td>2201</td><td/><td/></row>
		<row><td>ISSelfRegisterFiles</td><td/><td>5601</td><td/><td/></row>
		<row><td>ISSelfRegisterFinalize</td><td/><td>6601</td><td/><td/></row>
		<row><td>ISUnSelfRegisterFiles</td><td/><td>2202</td><td/><td/></row>
		<row><td>InstallFiles</td><td/><td>4000</td><td>InstallFiles</td><td/></row>
		<row><td>InstallFinalize</td><td/><td>6600</td><td>InstallFinalize</td><td/></row>
		<row><td>InstallInitialize</td><td/><td>1501</td><td>InstallInitialize</td><td/></row>
		<row><td>InstallODBC</td><td/><td>5400</td><td>InstallODBC</td><td/></row>
		<row><td>InstallServices</td><td>VersionNT</td><td>5800</td><td>InstallServices</td><td/></row>
		<row><td>InstallValidate</td><td/><td>1400</td><td>InstallValidate</td><td/></row>
		<row><td>IsolateComponents</td><td/><td>950</td><td>IsolateComponents</td><td/></row>
		<row><td>LaunchConditions</td><td>Not Installed</td><td>410</td><td>LaunchConditions</td><td/></row>
		<row><td>MigrateFeatureStates</td><td/><td>1010</td><td>MigrateFeatureStates</td><td/></row>
		<row><td>MoveFiles</td><td/><td>3800</td><td>MoveFiles</td><td/></row>
		<row><td>MsiConfigureServices</td><td>VersionMsi &gt;= "5.00"</td><td>5850</td><td>MSI5 MsiConfigureServices</td><td/></row>
		<row><td>MsiPublishAssemblies</td><td/><td>6250</td><td>MsiPublishAssemblies</td><td/></row>
		<row><td>MsiUnpublishAssemblies</td><td/><td>1750</td><td>MsiUnpublishAssemblies</td><td/></row>
		<row><td>PatchFiles</td><td/><td>4090</td><td>PatchFiles</td><td/></row>
		<row><td>ProcessComponents</td><td/><td>1600</td><td>ProcessComponents</td><td/></row>
		<row><td>PublishComponents</td><td/><td>6200</td><td>PublishComponents</td><td/></row>
		<row><td>PublishFeatures</td><td/><td>6300</td><td>PublishFeatures</td><td/></row>
		<row><td>PublishProduct</td><td/><td>6400</td><td>PublishProduct</td><td/></row>
		<row><td>RMCCPSearch</td><td>Not CCP_SUCCESS And CCP_TEST</td><td>600</td><td>RMCCPSearch</td><td/></row>
		<row><td>RegisterClassInfo</td><td/><td>4600</td><td>RegisterClassInfo</td><td/></row>
		<row><td>RegisterComPlus</td><td/><td>5700</td><td>RegisterComPlus</td><td/></row>
		<row><td>RegisterExtensionInfo</td><td/><td>4700</td><td>RegisterExtensionInfo</td><td/></row>
		<row><td>RegisterFonts</td><td/><td>5300</td><td>RegisterFonts</td><td/></row>
		<row><td>RegisterMIMEInfo</td><td/><td>4900</td><td>RegisterMIMEInfo</td><td/></row>
		<row><td>RegisterProduct</td><td/><td>6100</td><td>RegisterProduct</td><td/></row>
		<row><td>RegisterProgIdInfo</td><td/><td>4800</td><td>RegisterProgIdInfo</td><td/></row>
		<row><td>RegisterTypeLibraries</td><td/><td>5500</td><td>RegisterTypeLibraries</td><td/></row>
		<row><td>RegisterUser</td><td/><td>6000</td><td>RegisterUser</td><td/></row>
		<row><td>RemoveDuplicateFiles</td><td/><td>3400</td><td>RemoveDuplicateFiles</td><td/></row>
		<row><td>RemoveEnvironmentStrings</td><td/><td>3300</td><td>RemoveEnvironmentStrings</td><td/></row>
		<row><td>RemoveExistingProducts</td><td/><td>1410</td><td>RemoveExistingProducts</td><td/></row>
		<row><td>RemoveFiles</td><td/><td>3500</td><td>RemoveFiles</td><td/></row>
		<row><td>RemoveFolders</td><td/><td>3600</td><td>RemoveFolders</td><td/></row>
		<row><td>RemoveIniValues</td><td/><td>3100</td><td>RemoveIniValues</td><td/></row>
		<row><td>RemoveODBC</td><td/><td>2400</td><td>RemoveODBC</td><td/></row>
		<row><td>RemoveRegistryValues</td><td/><td>2600</td><td>RemoveRegistryValues</td><td/></row>
		<row><td>RemoveShortcuts</td><td/><td>3200</td><td>RemoveShortcuts</td><td/></row>
		<row><td>ResolveSource</td><td>Not Installed</td><td>850</td><td>ResolveSource</td><td/></row>
		<row><td>ScheduleReboot</td><td>ISSCHEDULEREBOOT</td><td>6410</td><td>ScheduleReboot</td><td/></row>
		<row><td>SelfRegModules</td><td/><td>5600</td><td>SelfRegModules</td><td/></row>
		<row><td>SelfUnregModules</td><td/><td>2200</td><td>SelfUnregModules</td><td/></row>
		<row><td>SetARPINSTALLLOCATION</td><td/><td>1100</td><td>SetARPINSTALLLOCATION</td><td/></row>
		<row><td>SetAllUsersProfileNT</td><td>VersionNT = 400</td><td>970</td><td/><td/></row>
		<row><td>SetODBCFolders</td><td/><td>1200</td><td>SetODBCFolders</td><td/></row>
		<row><td>StartServices</td><td>VersionNT</td><td>5900</td><td>StartServices</td><td/></row>
		<row><td>StopServices</td><td>VersionNT</td><td>1900</td><td>StopServices</td><td/></row>
		<row><td>UnpublishComponents</td><td/><td>1700</td><td>UnpublishComponents</td><td/></row>
		<row><td>UnpublishFeatures</td><td/><td>1800</td><td>UnpublishFeatures</td><td/></row>
		<row><td>UnregisterClassInfo</td><td/><td>2700</td><td>UnregisterClassInfo</td><td/></row>
		<row><td>UnregisterComPlus</td><td/><td>2100</td><td>UnregisterComPlus</td><td/></row>
		<row><td>UnregisterExtensionInfo</td><td/><td>2800</td><td>UnregisterExtensionInfo</td><td/></row>
		<row><td>UnregisterFonts</td><td/><td>2500</td><td>UnregisterFonts</td><td/></row>
		<row><td>UnregisterMIMEInfo</td><td/><td>3000</td><td>UnregisterMIMEInfo</td><td/></row>
		<row><td>UnregisterProgIdInfo</td><td/><td>2900</td><td>UnregisterProgIdInfo</td><td/></row>
		<row><td>UnregisterTypeLibraries</td><td/><td>2300</td><td>UnregisterTypeLibraries</td><td/></row>
		<row><td>ValidateProductID</td><td/><td>700</td><td>ValidateProductID</td><td/></row>
		<row><td>WriteEnvironmentStrings</td><td/><td>5200</td><td>WriteEnvironmentStrings</td><td/></row>
		<row><td>WriteIniValues</td><td/><td>5100</td><td>WriteIniValues</td><td/></row>
		<row><td>WriteRegistryValues</td><td/><td>5000</td><td>WriteRegistryValues</td><td/></row>
		<row><td>setAllUsersProfile2K</td><td>VersionNT &gt;= 500</td><td>980</td><td/><td/></row>
		<row><td>setUserProfileNT</td><td>VersionNT</td><td>960</td><td/><td/></row>
	</table>

	<table name="InstallShield">
		<col key="yes" def="s72">Property</col>
		<col def="S0">Value</col>
		<row><td>ActiveLanguage</td><td>1033</td></row>
		<row><td>Comments</td><td/></row>
		<row><td>CurrentMedia</td><td dt:dt="bin.base64" md5="de9f554a3bc05c12be9c31b998217995">
UwBpAG4AZwBsAGUASQBtAGEAZwBlAAEARQB4AHAAcgBlAHMAcwA=
			</td></row>
		<row><td>DefaultProductConfiguration</td><td>Express</td></row>
		<row><td>EnableSwidtag</td><td>1</td></row>
		<row><td>ISCompilerOption_CompileBeforeBuild</td><td>1</td></row>
		<row><td>ISCompilerOption_Debug</td><td>0</td></row>
		<row><td>ISCompilerOption_IncludePath</td><td/></row>
		<row><td>ISCompilerOption_LibraryPath</td><td/></row>
		<row><td>ISCompilerOption_MaxErrors</td><td>50</td></row>
		<row><td>ISCompilerOption_MaxWarnings</td><td>50</td></row>
		<row><td>ISCompilerOption_OutputPath</td><td>&lt;ISProjectDataFolder&gt;\Script Files</td></row>
		<row><td>ISCompilerOption_PreProcessor</td><td>_ISSCRIPT_NEW_STYLE_DLG_DEFS</td></row>
		<row><td>ISCompilerOption_WarningLevel</td><td>3</td></row>
		<row><td>ISCompilerOption_WarningsAsErrors</td><td>1</td></row>
		<row><td>ISTheme</td><td>InstallShield Blue.theme</td></row>
		<row><td>ISUSLock</td><td>{811B336C-9059-41B7-A278-52967D33591E}</td></row>
		<row><td>ISUSSignature</td><td>{D4C95AF2-6217-44F7-B0D6-3A92695B7F66}</td></row>
		<row><td>ISVisitedViews</td><td>viewAssistant,viewProject,viewAppFiles</td></row>
		<row><td>Limited</td><td>1</td></row>
		<row><td>LockPermissionMode</td><td>1</td></row>
		<row><td>MsiExecCmdLineOptions</td><td/></row>
		<row><td>MsiLogFile</td><td/></row>
		<row><td>OnUpgrade</td><td>0</td></row>
		<row><td>Owner</td><td/></row>
		<row><td>PatchFamily</td><td>MyPatchFamily1</td></row>
		<row><td>PatchSequence</td><td>1.0.0</td></row>
		<row><td>SaveAsSchema</td><td/></row>
		<row><td>SccEnabled</td><td>0</td></row>
		<row><td>SccPath</td><td/></row>
		<row><td>SchemaVersion</td><td>776</td></row>
		<row><td>Type</td><td>MSIE</td></row>
	</table>

	<table name="InstallUISequence">
		<col key="yes" def="s72">Action</col>
		<col def="S255">Condition</col>
		<col def="I2">Sequence</col>
		<col def="S255">ISComments</col>
		<col def="I4">ISAttributes</col>
		<row><td>AppSearch</td><td/><td>400</td><td>AppSearch</td><td/></row>
		<row><td>CCPSearch</td><td>CCP_TEST</td><td>500</td><td>CCPSearch</td><td/></row>
		<row><td>CostFinalize</td><td/><td>1000</td><td>CostFinalize</td><td/></row>
		<row><td>CostInitialize</td><td/><td>800</td><td>CostInitialize</td><td/></row>
		<row><td>ExecuteAction</td><td/><td>1300</td><td>ExecuteAction</td><td/></row>
		<row><td>FileCost</td><td/><td>900</td><td>FileCost</td><td/></row>
		<row><td>FindRelatedProducts</td><td/><td>430</td><td>FindRelatedProducts</td><td/></row>
		<row><td>ISPreventDowngrade</td><td>ISFOUNDNEWERPRODUCTVERSION</td><td>450</td><td>ISPreventDowngrade</td><td/></row>
		<row><td>InstallWelcome</td><td>Not Installed</td><td>1210</td><td>InstallWelcome</td><td/></row>
		<row><td>IsolateComponents</td><td/><td>950</td><td>IsolateComponents</td><td/></row>
		<row><td>LaunchConditions</td><td>Not Installed</td><td>410</td><td>LaunchConditions</td><td/></row>
		<row><td>MaintenanceWelcome</td><td>Installed And Not RESUME And Not Preselected And Not PATCH</td><td>1230</td><td>MaintenanceWelcome</td><td/></row>
		<row><td>MigrateFeatureStates</td><td/><td>1200</td><td>MigrateFeatureStates</td><td/></row>
		<row><td>PatchWelcome</td><td>Installed And PATCH And Not IS_MAJOR_UPGRADE</td><td>1205</td><td>Patch Panel</td><td/></row>
		<row><td>RMCCPSearch</td><td>Not CCP_SUCCESS And CCP_TEST</td><td>600</td><td>RMCCPSearch</td><td/></row>
		<row><td>ResolveSource</td><td>Not Installed</td><td>990</td><td>ResolveSource</td><td/></row>
		<row><td>SetAllUsersProfileNT</td><td>VersionNT = 400</td><td>970</td><td/><td/></row>
		<row><td>SetupCompleteError</td><td/><td>-3</td><td>SetupCompleteError</td><td/></row>
		<row><td>SetupCompleteSuccess</td><td/><td>-1</td><td>SetupCompleteSuccess</td><td/></row>
		<row><td>SetupInitialization</td><td/><td>420</td><td>SetupInitialization</td><td/></row>
		<row><td>SetupInterrupted</td><td/><td>-2</td><td>SetupInterrupted</td><td/></row>
		<row><td>SetupProgress</td><td/><td>1240</td><td>SetupProgress</td><td/></row>
		<row><td>SetupResume</td><td>Installed And (RESUME Or Preselected) And Not PATCH</td><td>1220</td><td>SetupResume</td><td/></row>
		<row><td>ValidateProductID</td><td/><td>700</td><td>ValidateProductID</td><td/></row>
		<row><td>setAllUsersProfile2K</td><td>VersionNT &gt;= 500</td><td>980</td><td/><td/></row>
		<row><td>setUserProfileNT</td><td>VersionNT</td><td>960</td><td/><td/></row>
	</table>

	<table name="IsolatedComponent">
		<col key="yes" def="s72">Component_Shared</col>
		<col key="yes" def="s72">Component_Application</col>
	</table>

	<table name="LaunchCondition">
		<col key="yes" def="s255">Condition</col>
		<col def="l255">Description</col>
	</table>

	<table name="ListBox">
		<col key="yes" def="s72">Property</col>
		<col key="yes" def="i2">Order</col>
		<col def="s64">Value</col>
		<col def="L64">Text</col>
	</table>

	<table name="ListView">
		<col key="yes" def="s72">Property</col>
		<col key="yes" def="i2">Order</col>
		<col def="s64">Value</col>
		<col def="L64">Text</col>
		<col def="S72">Binary_</col>
	</table>

	<table name="LockPermissions">
		<col key="yes" def="s72">LockObject</col>
		<col key="yes" def="s32">Table</col>
		<col key="yes" def="S255">Domain</col>
		<col key="yes" def="s255">User</col>
		<col def="I4">Permission</col>
	</table>

	<table name="MIME">
		<col key="yes" def="s64">ContentType</col>
		<col def="s255">Extension_</col>
		<col def="S38">CLSID</col>
	</table>

	<table name="Media">
		<col key="yes" def="i2">DiskId</col>
		<col def="i2">LastSequence</col>
		<col def="L64">DiskPrompt</col>
		<col def="S255">Cabinet</col>
		<col def="S32">VolumeLabel</col>
		<col def="S32">Source</col>
	</table>

	<table name="MoveFile">
		<col key="yes" def="s72">FileKey</col>
		<col def="s72">Component_</col>
		<col def="L255">SourceName</col>
		<col def="L255">DestName</col>
		<col def="S72">SourceFolder</col>
		<col def="s72">DestFolder</col>
		<col def="i2">Options</col>
	</table>

	<table name="MsiAssembly">
		<col key="yes" def="s72">Component_</col>
		<col def="s38">Feature_</col>
		<col def="S72">File_Manifest</col>
		<col def="S72">File_Application</col>
		<col def="I2">Attributes</col>
	</table>

	<table name="MsiAssemblyName">
		<col key="yes" def="s72">Component_</col>
		<col key="yes" def="s255">Name</col>
		<col def="s255">Value</col>
	</table>

	<table name="MsiDigitalCertificate">
		<col key="yes" def="s72">DigitalCertificate</col>
		<col def="v0">CertData</col>
	</table>

	<table name="MsiDigitalSignature">
		<col key="yes" def="s32">Table</col>
		<col key="yes" def="s72">SignObject</col>
		<col def="s72">DigitalCertificate_</col>
		<col def="V0">Hash</col>
	</table>

	<table name="MsiDriverPackages">
		<col key="yes" def="s72">Component</col>
		<col def="i4">Flags</col>
		<col def="I4">Sequence</col>
		<col def="S0">ReferenceComponents</col>
	</table>

	<table name="MsiEmbeddedChainer">
		<col key="yes" def="s72">MsiEmbeddedChainer</col>
		<col def="S255">Condition</col>
		<col def="S255">CommandLine</col>
		<col def="s72">Source</col>
		<col def="I4">Type</col>
	</table>

	<table name="MsiEmbeddedUI">
		<col key="yes" def="s72">MsiEmbeddedUI</col>
		<col def="s255">FileName</col>
		<col def="i2">Attributes</col>
		<col def="I4">MessageFilter</col>
		<col def="V0">Data</col>
		<col def="S255">ISBuildSourcePath</col>
	</table>

	<table name="MsiFileHash">
		<col key="yes" def="s72">File_</col>
		<col def="i2">Options</col>
		<col def="i4">HashPart1</col>
		<col def="i4">HashPart2</col>
		<col def="i4">HashPart3</col>
		<col def="i4">HashPart4</col>
	</table>

	<table name="MsiLockPermissionsEx">
		<col key="yes" def="s72">MsiLockPermissionsEx</col>
		<col def="s72">LockObject</col>
		<col def="s32">Table</col>
		<col def="s0">SDDLText</col>
		<col def="S255">Condition</col>
	</table>

	<table name="MsiPackageCertificate">
		<col key="yes" def="s72">PackageCertificate</col>
		<col def="s72">DigitalCertificate_</col>
	</table>

	<table name="MsiPatchCertificate">
		<col key="yes" def="s72">PatchCertificate</col>
		<col def="s72">DigitalCertificate_</col>
	</table>

	<table name="MsiPatchMetadata">
		<col key="yes" def="s72">PatchConfiguration_</col>
		<col key="yes" def="S72">Company</col>
		<col key="yes" def="s72">Property</col>
		<col def="S0">Value</col>
	</table>

	<table name="MsiPatchOldAssemblyFile">
		<col key="yes" def="s72">File_</col>
		<col key="yes" def="S72">Assembly_</col>
	</table>

	<table name="MsiPatchOldAssemblyName">
		<col key="yes" def="s72">Assembly</col>
		<col key="yes" def="s255">Name</col>
		<col def="S255">Value</col>
	</table>

	<table name="MsiPatchSequence">
		<col key="yes" def="s72">PatchConfiguration_</col>
		<col key="yes" def="s0">PatchFamily</col>
		<col key="yes" def="S0">Target</col>
		<col def="s0">Sequence</col>
		<col def="i2">Supersede</col>
	</table>

	<table name="MsiServiceConfig">
		<col key="yes" def="s72">MsiServiceConfig</col>
		<col def="s255">Name</col>
		<col def="i2">Event</col>
		<col def="i4">ConfigType</col>
		<col def="S0">Argument</col>
		<col def="s72">Component_</col>
	</table>

	<table name="MsiServiceConfigFailureActions">
		<col key="yes" def="s72">MsiServiceConfigFailureActions</col>
		<col def="s255">Name</col>
		<col def="i2">Event</col>
		<col def="I4">ResetPeriod</col>
		<col def="L255">RebootMessage</col>
		<col def="L255">Command</col>
		<col def="S0">Actions</col>
		<col def="S0">DelayActions</col>
		<col def="s72">Component_</col>
	</table>

	<table name="MsiShortcutProperty">
		<col key="yes" def="s72">MsiShortcutProperty</col>
		<col def="s72">Shortcut_</col>
		<col def="s0">PropertyKey</col>
		<col def="s0">PropVariantValue</col>
	</table>

	<table name="ODBCAttribute">
		<col key="yes" def="s72">Driver_</col>
		<col key="yes" def="s40">Attribute</col>
		<col def="S255">Value</col>
	</table>

	<table name="ODBCDataSource">
		<col key="yes" def="s72">DataSource</col>
		<col def="s72">Component_</col>
		<col def="s255">Description</col>
		<col def="s255">DriverDescription</col>
		<col def="i2">Registration</col>
	</table>

	<table name="ODBCDriver">
		<col key="yes" def="s72">Driver</col>
		<col def="s72">Component_</col>
		<col def="s255">Description</col>
		<col def="s72">File_</col>
		<col def="S72">File_Setup</col>
	</table>

	<table name="ODBCSourceAttribute">
		<col key="yes" def="s72">DataSource_</col>
		<col key="yes" def="s32">Attribute</col>
		<col def="S255">Value</col>
	</table>

	<table name="ODBCTranslator">
		<col key="yes" def="s72">Translator</col>
		<col def="s72">Component_</col>
		<col def="s255">Description</col>
		<col def="s72">File_</col>
		<col def="S72">File_Setup</col>
	</table>

	<table name="Patch">
		<col key="yes" def="s72">File_</col>
		<col key="yes" def="i2">Sequence</col>
		<col def="i4">PatchSize</col>
		<col def="i2">Attributes</col>
		<col def="V0">Header</col>
		<col def="S38">StreamRef_</col>
		<col def="S255">ISBuildSourcePath</col>
	</table>

	<table name="PatchPackage">
		<col key="yes" def="s38">PatchId</col>
		<col def="i2">Media_</col>
	</table>

	<table name="ProgId">
		<col key="yes" def="s255">ProgId</col>
		<col def="S255">ProgId_Parent</col>
		<col def="S38">Class_</col>
		<col def="L255">Description</col>
		<col def="S72">Icon_</col>
		<col def="I2">IconIndex</col>
		<col def="I4">ISAttributes</col>
	</table>

	<table name="Property">
		<col key="yes" def="s72">Property</col>
		<col def="L0">Value</col>
		<col def="S255">ISComments</col>
		<row><td>ALLUSERS</td><td>1</td><td/></row>
		<row><td>ARPINSTALLLOCATION</td><td/><td/></row>
		<row><td>ARPPRODUCTICON</td><td>ARPPRODUCTICON.exe</td><td/></row>
		<row><td>ARPSIZE</td><td/><td/></row>
		<row><td>ARPURLINFOABOUT</td><td>##ID_STRING1##</td><td/></row>
		<row><td>AgreeToLicense</td><td>No</td><td/></row>
		<row><td>ApplicationUsers</td><td>AllUsers</td><td/></row>
		<row><td>DWUSINTERVAL</td><td>30</td><td/></row>
		<row><td>DWUSLINK</td><td>CE6BC7A879CCB088D9AC67AF8E4C978F9EEC978FFE8CA06FCECCA08F8EBC40EFD98C60FFF9AC</td><td/></row>
		<row><td>DefaultUIFont</td><td>ExpressDefault</td><td/></row>
		<row><td>DialogCaption</td><td>InstallShield for Windows Installer</td><td/></row>
		<row><td>DiskPrompt</td><td>[1]</td><td/></row>
		<row><td>DiskSerial</td><td>1234-5678</td><td/></row>
		<row><td>DisplayNameCustom</td><td>##IDS__DisplayName_Custom##</td><td/></row>
		<row><td>DisplayNameMinimal</td><td>##IDS__DisplayName_Minimal##</td><td/></row>
		<row><td>DisplayNameTypical</td><td>##IDS__DisplayName_Typical##</td><td/></row>
		<row><td>Display_IsBitmapDlg</td><td>1</td><td/></row>
		<row><td>ErrorDialog</td><td>SetupError</td><td/></row>
		<row><td>INSTALLLEVEL</td><td>200</td><td/></row>
		<row><td>ISCHECKFORPRODUCTUPDATES</td><td>1</td><td/></row>
		<row><td>ISENABLEDWUSFINISHDIALOG</td><td/><td/></row>
		<row><td>ISSHOWMSILOG</td><td/><td/></row>
		<row><td>ISVROOT_PORT_NO</td><td>0</td><td/></row>
		<row><td>IS_COMPLUS_PROGRESSTEXT_COST</td><td>##IDS_COMPLUS_PROGRESSTEXT_COST##</td><td/></row>
		<row><td>IS_COMPLUS_PROGRESSTEXT_INSTALL</td><td>##IDS_COMPLUS_PROGRESSTEXT_INSTALL##</td><td/></row>
		<row><td>IS_COMPLUS_PROGRESSTEXT_UNINSTALL</td><td>##IDS_COMPLUS_PROGRESSTEXT_UNINSTALL##</td><td/></row>
		<row><td>IS_PREVENT_DOWNGRADE_EXIT</td><td>##IDS_PREVENT_DOWNGRADE_EXIT##</td><td/></row>
		<row><td>IS_PROGMSG_TEXTFILECHANGS_REPLACE</td><td>##IDS_PROGMSG_TEXTFILECHANGS_REPLACE##</td><td/></row>
		<row><td>IS_PROGMSG_XML_COSTING</td><td>##IDS_PROGMSG_XML_COSTING##</td><td/></row>
		<row><td>IS_PROGMSG_XML_CREATE_FILE</td><td>##IDS_PROGMSG_XML_CREATE_FILE##</td><td/></row>
		<row><td>IS_PROGMSG_XML_FILES</td><td>##IDS_PROGMSG_XML_FILES##</td><td/></row>
		<row><td>IS_PROGMSG_XML_REMOVE_FILE</td><td>##IDS_PROGMSG_XML_REMOVE_FILE##</td><td/></row>
		<row><td>IS_PROGMSG_XML_ROLLBACK_FILES</td><td>##IDS_PROGMSG_XML_ROLLBACK_FILES##</td><td/></row>
		<row><td>IS_PROGMSG_XML_UPDATE_FILE</td><td>##IDS_PROGMSG_XML_UPDATE_FILE##</td><td/></row>
		<row><td>IS_SQLSERVER_AUTHENTICATION</td><td>0</td><td/></row>
		<row><td>IS_SQLSERVER_DATABASE</td><td/><td/></row>
		<row><td>IS_SQLSERVER_PASSWORD</td><td/><td/></row>
		<row><td>IS_SQLSERVER_SERVER</td><td/><td/></row>
		<row><td>IS_SQLSERVER_USERNAME</td><td>sa</td><td/></row>
		<row><td>InstallChoice</td><td>AR</td><td/></row>
		<row><td>LAUNCHPROGRAM</td><td>1</td><td/></row>
		<row><td>LAUNCHREADME</td><td>1</td><td/></row>
		<row><td>MSIFASTINSTALL</td><td>6</td><td/></row>
		<row><td>Manufacturer</td><td>##COMPANY_NAME##</td><td/></row>
		<row><td>PIDKEY</td><td/><td/></row>
		<row><td>PIDTemplate</td><td>12345&lt;###-%%%%%%%&gt;@@@@@</td><td/></row>
		<row><td>PROGMSG_IIS_CREATEAPPPOOL</td><td>##IDS_PROGMSG_IIS_CREATEAPPPOOL##</td><td/></row>
		<row><td>PROGMSG_IIS_CREATEAPPPOOLS</td><td>##IDS_PROGMSG_IIS_CREATEAPPPOOLS##</td><td/></row>
		<row><td>PROGMSG_IIS_CREATEVROOT</td><td>##IDS_PROGMSG_IIS_CREATEVROOT##</td><td/></row>
		<row><td>PROGMSG_IIS_CREATEVROOTS</td><td>##IDS_PROGMSG_IIS_CREATEVROOTS##</td><td/></row>
		<row><td>PROGMSG_IIS_CREATEWEBSERVICEEXTENSION</td><td>##IDS_PROGMSG_IIS_CREATEWEBSERVICEEXTENSION##</td><td/></row>
		<row><td>PROGMSG_IIS_CREATEWEBSERVICEEXTENSIONS</td><td>##IDS_PROGMSG_IIS_CREATEWEBSERVICEEXTENSIONS##</td><td/></row>
		<row><td>PROGMSG_IIS_CREATEWEBSITE</td><td>##IDS_PROGMSG_IIS_CREATEWEBSITE##</td><td/></row>
		<row><td>PROGMSG_IIS_CREATEWEBSITES</td><td>##IDS_PROGMSG_IIS_CREATEWEBSITES##</td><td/></row>
		<row><td>PROGMSG_IIS_EXTRACT</td><td>##IDS_PROGMSG_IIS_EXTRACT##</td><td/></row>
		<row><td>PROGMSG_IIS_EXTRACTDONE</td><td>##IDS_PROGMSG_IIS_EXTRACTDONE##</td><td/></row>
		<row><td>PROGMSG_IIS_EXTRACTDONEz</td><td>##IDS_PROGMSG_IIS_EXTRACTDONE##</td><td/></row>
		<row><td>PROGMSG_IIS_EXTRACTzDONE</td><td>##IDS_PROGMSG_IIS_EXTRACTDONE##</td><td/></row>
		<row><td>PROGMSG_IIS_REMOVEAPPPOOL</td><td>##IDS_PROGMSG_IIS_REMOVEAPPPOOL##</td><td/></row>
		<row><td>PROGMSG_IIS_REMOVEAPPPOOLS</td><td>##IDS_PROGMSG_IIS_REMOVEAPPPOOLS##</td><td/></row>
		<row><td>PROGMSG_IIS_REMOVESITE</td><td>##IDS_PROGMSG_IIS_REMOVESITE##</td><td/></row>
		<row><td>PROGMSG_IIS_REMOVEVROOT</td><td>##IDS_PROGMSG_IIS_REMOVEVROOT##</td><td/></row>
		<row><td>PROGMSG_IIS_REMOVEVROOTS</td><td>##IDS_PROGMSG_IIS_REMOVEVROOTS##</td><td/></row>
		<row><td>PROGMSG_IIS_REMOVEWEBSERVICEEXTENSION</td><td>##IDS_PROGMSG_IIS_REMOVEWEBSERVICEEXTENSION##</td><td/></row>
		<row><td>PROGMSG_IIS_REMOVEWEBSERVICEEXTENSIONS</td><td>##IDS_PROGMSG_IIS_REMOVEWEBSERVICEEXTENSIONS##</td><td/></row>
		<row><td>PROGMSG_IIS_REMOVEWEBSITES</td><td>##IDS_PROGMSG_IIS_REMOVEWEBSITES##</td><td/></row>
		<row><td>PROGMSG_IIS_ROLLBACKAPPPOOLS</td><td>##IDS_PROGMSG_IIS_ROLLBACKAPPPOOLS##</td><td/></row>
		<row><td>PROGMSG_IIS_ROLLBACKVROOTS</td><td>##IDS_PROGMSG_IIS_ROLLBACKVROOTS##</td><td/></row>
		<row><td>PROGMSG_IIS_ROLLBACKWEBSERVICEEXTENSIONS</td><td>##IDS_PROGMSG_IIS_ROLLBACKWEBSERVICEEXTENSIONS##</td><td/></row>
		<row><td>ProductCode</td><td>{74E0E49F-3879-481D-B296-E05A48FD3006}</td><td/></row>
		<row><td>ProductName</td><td>eMote</td><td/></row>
		<row><td>ProductVersion</td><td>1.00.0000</td><td/></row>
		<row><td>ProgressType0</td><td>install</td><td/></row>
		<row><td>ProgressType1</td><td>Installing</td><td/></row>
		<row><td>ProgressType2</td><td>installed</td><td/></row>
		<row><td>ProgressType3</td><td>installs</td><td/></row>
		<row><td>RebootYesNo</td><td>Yes</td><td/></row>
		<row><td>ReinstallFileVersion</td><td>o</td><td/></row>
		<row><td>ReinstallModeText</td><td>omus</td><td/></row>
		<row><td>ReinstallRepair</td><td>r</td><td/></row>
		<row><td>RestartManagerOption</td><td>CloseRestart</td><td/></row>
		<row><td>SERIALNUMBER</td><td/><td/></row>
		<row><td>SERIALNUMVALSUCCESSRETVAL</td><td>1</td><td/></row>
		<row><td>SecureCustomProperties</td><td>ISFOUNDNEWERPRODUCTVERSION;USERNAME;COMPANYNAME;ISX_SERIALNUM;SUPPORTDIR</td><td/></row>
		<row><td>SelectedSetupType</td><td>##IDS__DisplayName_Typical##</td><td/></row>
		<row><td>SetupType</td><td>Typical</td><td/></row>
		<row><td>UpgradeCode</td><td>{F5BBFA5A-44A6-4C4B-9155-4B0F70D03254}</td><td/></row>
		<row><td>_IsMaintenance</td><td>Change</td><td/></row>
		<row><td>_IsSetupTypeMin</td><td>Typical</td><td/></row>
	</table>

	<table name="PublishComponent">
		<col key="yes" def="s38">ComponentId</col>
		<col key="yes" def="s255">Qualifier</col>
		<col key="yes" def="s72">Component_</col>
		<col def="L0">AppData</col>
		<col def="s38">Feature_</col>
	</table>

	<table name="RadioButton">
		<col key="yes" def="s72">Property</col>
		<col key="yes" def="i2">Order</col>
		<col def="s64">Value</col>
		<col def="i2">X</col>
		<col def="i2">Y</col>
		<col def="i2">Width</col>
		<col def="i2">Height</col>
		<col def="L64">Text</col>
		<col def="L50">Help</col>
		<col def="I4">ISControlId</col>
		<row><td>AgreeToLicense</td><td>1</td><td>No</td><td>0</td><td>15</td><td>291</td><td>15</td><td>##IDS__AgreeToLicense_0##</td><td/><td/></row>
		<row><td>AgreeToLicense</td><td>2</td><td>Yes</td><td>0</td><td>0</td><td>291</td><td>15</td><td>##IDS__AgreeToLicense_1##</td><td/><td/></row>
		<row><td>ApplicationUsers</td><td>1</td><td>AllUsers</td><td>1</td><td>7</td><td>290</td><td>14</td><td>##IDS__IsRegisterUserDlg_Anyone##</td><td/><td/></row>
		<row><td>ApplicationUsers</td><td>2</td><td>OnlyCurrentUser</td><td>1</td><td>23</td><td>290</td><td>14</td><td>##IDS__IsRegisterUserDlg_OnlyMe##</td><td/><td/></row>
		<row><td>RestartManagerOption</td><td>1</td><td>CloseRestart</td><td>6</td><td>9</td><td>331</td><td>14</td><td>##IDS__IsMsiRMFilesInUse_CloseRestart##</td><td/><td/></row>
		<row><td>RestartManagerOption</td><td>2</td><td>Reboot</td><td>6</td><td>21</td><td>331</td><td>14</td><td>##IDS__IsMsiRMFilesInUse_RebootAfter##</td><td/><td/></row>
		<row><td>_IsMaintenance</td><td>1</td><td>Change</td><td>0</td><td>0</td><td>290</td><td>14</td><td>##IDS__IsMaintenanceDlg_Modify##</td><td/><td/></row>
		<row><td>_IsMaintenance</td><td>2</td><td>Reinstall</td><td>0</td><td>60</td><td>290</td><td>14</td><td>##IDS__IsMaintenanceDlg_Repair##</td><td/><td/></row>
		<row><td>_IsMaintenance</td><td>3</td><td>Remove</td><td>0</td><td>120</td><td>290</td><td>14</td><td>##IDS__IsMaintenanceDlg_Remove##</td><td/><td/></row>
		<row><td>_IsSetupTypeMin</td><td>1</td><td>Typical</td><td>1</td><td>6</td><td>264</td><td>14</td><td>##IDS__IsSetupTypeMinDlg_Typical##</td><td/><td/></row>
	</table>

	<table name="RegLocator">
		<col key="yes" def="s72">Signature_</col>
		<col def="i2">Root</col>
		<col def="s255">Key</col>
		<col def="S255">Name</col>
		<col def="I2">Type</col>
	</table>

	<table name="Registry">
		<col key="yes" def="s72">Registry</col>
		<col def="i2">Root</col>
		<col def="s255">Key</col>
		<col def="S255">Name</col>
		<col def="S0">Value</col>
		<col def="s72">Component_</col>
		<col def="I4">ISAttributes</col>
	</table>

	<table name="RemoveFile">
		<col key="yes" def="s72">FileKey</col>
		<col def="s72">Component_</col>
		<col def="L255">FileName</col>
		<col def="s72">DirProperty</col>
		<col def="i2">InstallMode</col>
		<row><td>TestEnhancedeMoteLCD.exe</td><td>TestEnhancedeMoteLCD.exe</td><td/><td>emote</td><td>2</td></row>
		<row><td>TestEnhancedeMoteLCD.exe1</td><td>TestEnhancedeMoteLCD.exe1</td><td/><td>emote</td><td>2</td></row>
		<row><td>TestEnhancedeMoteLCD.exe2</td><td>TestEnhancedeMoteLCD.exe2</td><td/><td>emote</td><td>2</td></row>
		<row><td>TestEnhancedeMoteLCD.exe3</td><td>TestEnhancedeMoteLCD.exe3</td><td/><td>emote</td><td>2</td></row>
		<row><td>TestEnhancedeMoteLCD.exe4</td><td>TestEnhancedeMoteLCD.exe4</td><td/><td>emote</td><td>2</td></row>
		<row><td>TestEnhancedeMoteLCD.exe5</td><td>TestEnhancedeMoteLCD.exe5</td><td/><td>emote</td><td>2</td></row>
	</table>

	<table name="RemoveIniFile">
		<col key="yes" def="s72">RemoveIniFile</col>
		<col def="l255">FileName</col>
		<col def="S72">DirProperty</col>
		<col def="l96">Section</col>
		<col def="l128">Key</col>
		<col def="L255">Value</col>
		<col def="i2">Action</col>
		<col def="s72">Component_</col>
	</table>

	<table name="RemoveRegistry">
		<col key="yes" def="s72">RemoveRegistry</col>
		<col def="i2">Root</col>
		<col def="l255">Key</col>
		<col def="L255">Name</col>
		<col def="s72">Component_</col>
	</table>

	<table name="ReserveCost">
		<col key="yes" def="s72">ReserveKey</col>
		<col def="s72">Component_</col>
		<col def="S72">ReserveFolder</col>
		<col def="i4">ReserveLocal</col>
		<col def="i4">ReserveSource</col>
	</table>

	<table name="SFPCatalog">
		<col key="yes" def="s255">SFPCatalog</col>
		<col def="V0">Catalog</col>
		<col def="S0">Dependency</col>
	</table>

	<table name="SelfReg">
		<col key="yes" def="s72">File_</col>
		<col def="I2">Cost</col>
	</table>

	<table name="ServiceControl">
		<col key="yes" def="s72">ServiceControl</col>
		<col def="s255">Name</col>
		<col def="i2">Event</col>
		<col def="S255">Arguments</col>
		<col def="I2">Wait</col>
		<col def="s72">Component_</col>
	</table>

	<table name="ServiceInstall">
		<col key="yes" def="s72">ServiceInstall</col>
		<col def="s255">Name</col>
		<col def="L255">DisplayName</col>
		<col def="i4">ServiceType</col>
		<col def="i4">StartType</col>
		<col def="i4">ErrorControl</col>
		<col def="S255">LoadOrderGroup</col>
		<col def="S255">Dependencies</col>
		<col def="S255">StartName</col>
		<col def="S255">Password</col>
		<col def="S255">Arguments</col>
		<col def="s72">Component_</col>
		<col def="L255">Description</col>
	</table>

	<table name="Shortcut">
		<col key="yes" def="s72">Shortcut</col>
		<col def="s72">Directory_</col>
		<col def="l128">Name</col>
		<col def="s72">Component_</col>
		<col def="s255">Target</col>
		<col def="S255">Arguments</col>
		<col def="L255">Description</col>
		<col def="I2">Hotkey</col>
		<col def="S72">Icon_</col>
		<col def="I2">IconIndex</col>
		<col def="I2">ShowCmd</col>
		<col def="S72">WkDir</col>
		<col def="S255">DisplayResourceDLL</col>
		<col def="I2">DisplayResourceId</col>
		<col def="S255">DescriptionResourceDLL</col>
		<col def="I2">DescriptionResourceId</col>
		<col def="S255">ISComments</col>
		<col def="S255">ISShortcutName</col>
		<col def="I4">ISAttributes</col>
		<row><td>TestEnhancedeMoteLCD.exe</td><td>emote</td><td>##IDS_SHORTCUT_DISPLAY_NAME8##</td><td>TestEnhancedeMoteLCD.exe</td><td>AlwaysInstall</td><td/><td/><td/><td>TestEnhancedeMoteL_28933DCD56654D9ABC89318ACC3A8091.exe</td><td>0</td><td>1</td><td>BE7</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>TestEnhancedeMoteLCD.exe1</td><td>emote</td><td>##IDS_SHORTCUT_DISPLAY_NAME9##</td><td>TestEnhancedeMoteLCD.exe1</td><td>AlwaysInstall</td><td/><td/><td/><td>TestEnhancedeMoteL_C0D917DE62734EF8B0D915BCEFEB86BD.exe</td><td>0</td><td>1</td><td>LE7</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>TestEnhancedeMoteLCD.exe2</td><td>emote</td><td>##IDS_SHORTCUT_DISPLAY_NAME10##</td><td>TestEnhancedeMoteLCD.exe2</td><td>AlwaysInstall</td><td/><td/><td/><td>TestEnhancedeMoteL_991A1BC4E85940C7AA994930DE135726.exe</td><td>0</td><td>1</td><td>BIN</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>TestEnhancedeMoteLCD.exe3</td><td>emote</td><td>##IDS_SHORTCUT_DISPLAY_NAME11##</td><td>TestEnhancedeMoteLCD.exe3</td><td>AlwaysInstall</td><td/><td/><td/><td>TestEnhancedeMoteL_3A78F41B03D7443894C38B8AE463E31A.exe</td><td>0</td><td>1</td><td>BE16</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>TestEnhancedeMoteLCD.exe4</td><td>emote</td><td>##IDS_SHORTCUT_DISPLAY_NAME12##</td><td>TestEnhancedeMoteLCD.exe4</td><td>AlwaysInstall</td><td/><td/><td/><td>TestEnhancedeMoteL_34B00F37E7A24866ACD602B037F7CDB2.exe</td><td>0</td><td>1</td><td>LE16</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>TestEnhancedeMoteLCD.exe5</td><td>emote</td><td>##IDS_SHORTCUT_DISPLAY_NAME13##</td><td>TestEnhancedeMoteLCD.exe5</td><td>AlwaysInstall</td><td/><td/><td/><td>TestEnhancedeMoteL_C0E95738BD6D47DE83F2E1603FB786F5.exe</td><td>0</td><td>1</td><td>DEBUG1</td><td/><td/><td/><td/><td/><td/><td/></row>
	</table>

	<table name="Signature">
		<col key="yes" def="s72">Signature</col>
		<col def="s255">FileName</col>
		<col def="S20">MinVersion</col>
		<col def="S20">MaxVersion</col>
		<col def="I4">MinSize</col>
		<col def="I4">MaxSize</col>
		<col def="I4">MinDate</col>
		<col def="I4">MaxDate</col>
		<col def="S255">Languages</col>
	</table>

	<table name="TextStyle">
		<col key="yes" def="s72">TextStyle</col>
		<col def="s32">FaceName</col>
		<col def="i2">Size</col>
		<col def="I4">Color</col>
		<col def="I2">StyleBits</col>
		<row><td>Arial8</td><td>Arial</td><td>8</td><td/><td/></row>
		<row><td>Arial9</td><td>Arial</td><td>9</td><td/><td/></row>
		<row><td>ArialBlue10</td><td>Arial</td><td>10</td><td>16711680</td><td/></row>
		<row><td>ArialBlueStrike10</td><td>Arial</td><td>10</td><td>16711680</td><td>8</td></row>
		<row><td>CourierNew8</td><td>Courier New</td><td>8</td><td/><td/></row>
		<row><td>CourierNew9</td><td>Courier New</td><td>9</td><td/><td/></row>
		<row><td>ExpressDefault</td><td>Tahoma</td><td>8</td><td/><td/></row>
		<row><td>MSGothic9</td><td>MS Gothic</td><td>9</td><td/><td/></row>
		<row><td>MSSGreySerif8</td><td>MS Sans Serif</td><td>8</td><td>8421504</td><td/></row>
		<row><td>MSSWhiteSerif8</td><td>Tahoma</td><td>8</td><td>16777215</td><td/></row>
		<row><td>MSSansBold8</td><td>Tahoma</td><td>8</td><td/><td>1</td></row>
		<row><td>MSSansSerif8</td><td>MS Sans Serif</td><td>8</td><td/><td/></row>
		<row><td>MSSansSerif9</td><td>MS Sans Serif</td><td>9</td><td/><td/></row>
		<row><td>Tahoma10</td><td>Tahoma</td><td>10</td><td/><td/></row>
		<row><td>Tahoma8</td><td>Tahoma</td><td>8</td><td/><td/></row>
		<row><td>Tahoma9</td><td>Tahoma</td><td>9</td><td/><td/></row>
		<row><td>TahomaBold10</td><td>Tahoma</td><td>10</td><td/><td>1</td></row>
		<row><td>TahomaBold8</td><td>Tahoma</td><td>8</td><td/><td>1</td></row>
		<row><td>Times8</td><td>Times New Roman</td><td>8</td><td/><td/></row>
		<row><td>Times9</td><td>Times New Roman</td><td>9</td><td/><td/></row>
		<row><td>TimesItalic12</td><td>Times New Roman</td><td>12</td><td/><td>2</td></row>
		<row><td>TimesItalicBlue10</td><td>Times New Roman</td><td>10</td><td>16711680</td><td>2</td></row>
		<row><td>TimesRed16</td><td>Times New Roman</td><td>16</td><td>255</td><td/></row>
		<row><td>VerdanaBold14</td><td>Verdana</td><td>13</td><td/><td>1</td></row>
	</table>

	<table name="TypeLib">
		<col key="yes" def="s38">LibID</col>
		<col key="yes" def="i2">Language</col>
		<col key="yes" def="s72">Component_</col>
		<col def="I4">Version</col>
		<col def="L128">Description</col>
		<col def="S72">Directory_</col>
		<col def="s38">Feature_</col>
		<col def="I4">Cost</col>
	</table>

	<table name="UIText">
		<col key="yes" def="s72">Key</col>
		<col def="L255">Text</col>
		<row><td>AbsentPath</td><td/></row>
		<row><td>GB</td><td>##IDS_UITEXT_GB##</td></row>
		<row><td>KB</td><td>##IDS_UITEXT_KB##</td></row>
		<row><td>MB</td><td>##IDS_UITEXT_MB##</td></row>
		<row><td>MenuAbsent</td><td>##IDS_UITEXT_FeatureNotAvailable##</td></row>
		<row><td>MenuAdvertise</td><td>##IDS_UITEXT_FeatureInstalledWhenRequired2##</td></row>
		<row><td>MenuAllCD</td><td>##IDS_UITEXT_FeatureInstalledCD##</td></row>
		<row><td>MenuAllLocal</td><td>##IDS_UITEXT_FeatureInstalledLocal##</td></row>
		<row><td>MenuAllNetwork</td><td>##IDS_UITEXT_FeatureInstalledNetwork##</td></row>
		<row><td>MenuCD</td><td>##IDS_UITEXT_FeatureInstalledCD2##</td></row>
		<row><td>MenuLocal</td><td>##IDS_UITEXT_FeatureInstalledLocal2##</td></row>
		<row><td>MenuNetwork</td><td>##IDS_UITEXT_FeatureInstalledNetwork2##</td></row>
		<row><td>NewFolder</td><td>##IDS_UITEXT_Folder##</td></row>
		<row><td>SelAbsentAbsent</td><td>##IDS_UITEXT_GB##</td></row>
		<row><td>SelAbsentAdvertise</td><td>##IDS_UITEXT_FeatureInstalledWhenRequired##</td></row>
		<row><td>SelAbsentCD</td><td>##IDS_UITEXT_FeatureOnCD##</td></row>
		<row><td>SelAbsentLocal</td><td>##IDS_UITEXT_FeatureLocal##</td></row>
		<row><td>SelAbsentNetwork</td><td>##IDS_UITEXT_FeatureNetwork##</td></row>
		<row><td>SelAdvertiseAbsent</td><td>##IDS_UITEXT_FeatureUnavailable##</td></row>
		<row><td>SelAdvertiseAdvertise</td><td>##IDS_UITEXT_FeatureInstalledRequired##</td></row>
		<row><td>SelAdvertiseCD</td><td>##IDS_UITEXT_FeatureOnCD2##</td></row>
		<row><td>SelAdvertiseLocal</td><td>##IDS_UITEXT_FeatureLocal2##</td></row>
		<row><td>SelAdvertiseNetwork</td><td>##IDS_UITEXT_FeatureNetwork2##</td></row>
		<row><td>SelCDAbsent</td><td>##IDS_UITEXT_FeatureWillBeUninstalled##</td></row>
		<row><td>SelCDAdvertise</td><td>##IDS_UITEXT_FeatureWasCD##</td></row>
		<row><td>SelCDCD</td><td>##IDS_UITEXT_FeatureRunFromCD##</td></row>
		<row><td>SelCDLocal</td><td>##IDS_UITEXT_FeatureWasCDLocal##</td></row>
		<row><td>SelChildCostNeg</td><td>##IDS_UITEXT_FeatureFreeSpace##</td></row>
		<row><td>SelChildCostPos</td><td>##IDS_UITEXT_FeatureRequiredSpace##</td></row>
		<row><td>SelCostPending</td><td>##IDS_UITEXT_CompilingFeaturesCost##</td></row>
		<row><td>SelLocalAbsent</td><td>##IDS_UITEXT_FeatureCompletelyRemoved##</td></row>
		<row><td>SelLocalAdvertise</td><td>##IDS_UITEXT_FeatureRemovedUnlessRequired##</td></row>
		<row><td>SelLocalCD</td><td>##IDS_UITEXT_FeatureRemovedCD##</td></row>
		<row><td>SelLocalLocal</td><td>##IDS_UITEXT_FeatureRemainLocal##</td></row>
		<row><td>SelLocalNetwork</td><td>##IDS_UITEXT_FeatureRemoveNetwork##</td></row>
		<row><td>SelNetworkAbsent</td><td>##IDS_UITEXT_FeatureUninstallNoNetwork##</td></row>
		<row><td>SelNetworkAdvertise</td><td>##IDS_UITEXT_FeatureWasOnNetworkInstalled##</td></row>
		<row><td>SelNetworkLocal</td><td>##IDS_UITEXT_FeatureWasOnNetworkLocal##</td></row>
		<row><td>SelNetworkNetwork</td><td>##IDS_UITEXT_FeatureContinueNetwork##</td></row>
		<row><td>SelParentCostNegNeg</td><td>##IDS_UITEXT_FeatureSpaceFree##</td></row>
		<row><td>SelParentCostNegPos</td><td>##IDS_UITEXT_FeatureSpaceFree2##</td></row>
		<row><td>SelParentCostPosNeg</td><td>##IDS_UITEXT_FeatureSpaceFree3##</td></row>
		<row><td>SelParentCostPosPos</td><td>##IDS_UITEXT_FeatureSpaceFree4##</td></row>
		<row><td>TimeRemaining</td><td>##IDS_UITEXT_TimeRemaining##</td></row>
		<row><td>VolumeCostAvailable</td><td>##IDS_UITEXT_Available##</td></row>
		<row><td>VolumeCostDifference</td><td>##IDS_UITEXT_Differences##</td></row>
		<row><td>VolumeCostRequired</td><td>##IDS_UITEXT_Required##</td></row>
		<row><td>VolumeCostSize</td><td>##IDS_UITEXT_DiskSize##</td></row>
		<row><td>VolumeCostVolume</td><td>##IDS_UITEXT_Volume##</td></row>
		<row><td>bytes</td><td>##IDS_UITEXT_Bytes##</td></row>
	</table>

	<table name="Upgrade">
		<col key="yes" def="s38">UpgradeCode</col>
		<col key="yes" def="S20">VersionMin</col>
		<col key="yes" def="S20">VersionMax</col>
		<col key="yes" def="S255">Language</col>
		<col key="yes" def="i4">Attributes</col>
		<col def="S255">Remove</col>
		<col def="s72">ActionProperty</col>
		<col def="S72">ISDisplayName</col>
		<row><td>{00000000-0000-0000-0000-000000000000}</td><td>***ALL_VERSIONS***</td><td></td><td></td><td>2</td><td/><td>ISFOUNDNEWERPRODUCTVERSION</td><td>ISPreventDowngrade</td></row>
	</table>

	<table name="Verb">
		<col key="yes" def="s255">Extension_</col>
		<col key="yes" def="s32">Verb</col>
		<col def="I2">Sequence</col>
		<col def="L255">Command</col>
		<col def="L255">Argument</col>
	</table>

	<table name="_Validation">
		<col key="yes" def="s32">Table</col>
		<col key="yes" def="s32">Column</col>
		<col def="s4">Nullable</col>
		<col def="I4">MinValue</col>
		<col def="I4">MaxValue</col>
		<col def="S255">KeyTable</col>
		<col def="I2">KeyColumn</col>
		<col def="S32">Category</col>
		<col def="S255">Set</col>
		<col def="S255">Description</col>
		<row><td>ActionText</td><td>Action</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of action to be described.</td></row>
		<row><td>ActionText</td><td>Description</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Localized description displayed in progress dialog and log when action is executing.</td></row>
		<row><td>ActionText</td><td>Template</td><td>Y</td><td/><td/><td/><td/><td>Template</td><td/><td>Optional localized format template used to format action data records for display during action execution.</td></row>
		<row><td>AdminExecuteSequence</td><td>Action</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of action to invoke, either in the engine or the handler DLL.</td></row>
		<row><td>AdminExecuteSequence</td><td>Condition</td><td>Y</td><td/><td/><td/><td/><td>Condition</td><td/><td>Optional expression which skips the action if evaluates to expFalse.If the expression syntax is invalid, the engine will terminate, returning iesBadActionData.</td></row>
		<row><td>AdminExecuteSequence</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>This is used to store MM Custom Action Types</td></row>
		<row><td>AdminExecuteSequence</td><td>ISComments</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Author’s comments on this Sequence.</td></row>
		<row><td>AdminExecuteSequence</td><td>Sequence</td><td>Y</td><td>-4</td><td>32767</td><td/><td/><td/><td/><td>Number that determines the sort order in which the actions are to be executed.  Leave blank to suppress action.</td></row>
		<row><td>AdminUISequence</td><td>Action</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of action to invoke, either in the engine or the handler DLL.</td></row>
		<row><td>AdminUISequence</td><td>Condition</td><td>Y</td><td/><td/><td/><td/><td>Condition</td><td/><td>Optional expression which skips the action if evaluates to expFalse.If the expression syntax is invalid, the engine will terminate, returning iesBadActionData.</td></row>
		<row><td>AdminUISequence</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>This is used to store MM Custom Action Types</td></row>
		<row><td>AdminUISequence</td><td>ISComments</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Author’s comments on this Sequence.</td></row>
		<row><td>AdminUISequence</td><td>Sequence</td><td>Y</td><td>-4</td><td>32767</td><td/><td/><td/><td/><td>Number that determines the sort order in which the actions are to be executed.  Leave blank to suppress action.</td></row>
		<row><td>AdvtExecuteSequence</td><td>Action</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of action to invoke, either in the engine or the handler DLL.</td></row>
		<row><td>AdvtExecuteSequence</td><td>Condition</td><td>Y</td><td/><td/><td/><td/><td>Condition</td><td/><td>Optional expression which skips the action if evaluates to expFalse.If the expression syntax is invalid, the engine will terminate, returning iesBadActionData.</td></row>
		<row><td>AdvtExecuteSequence</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>This is used to store MM Custom Action Types</td></row>
		<row><td>AdvtExecuteSequence</td><td>ISComments</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Author’s comments on this Sequence.</td></row>
		<row><td>AdvtExecuteSequence</td><td>Sequence</td><td>Y</td><td>-4</td><td>32767</td><td/><td/><td/><td/><td>Number that determines the sort order in which the actions are to be executed.  Leave blank to suppress action.</td></row>
		<row><td>AdvtUISequence</td><td>Action</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of action to invoke, either in the engine or the handler DLL.</td></row>
		<row><td>AdvtUISequence</td><td>Condition</td><td>Y</td><td/><td/><td/><td/><td>Condition</td><td/><td>Optional expression which skips the action if evaluates to expFalse.If the expression syntax is invalid, the engine will terminate, returning iesBadActionData.</td></row>
		<row><td>AdvtUISequence</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>This is used to store MM Custom Action Types</td></row>
		<row><td>AdvtUISequence</td><td>ISComments</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Author’s comments on this Sequence.</td></row>
		<row><td>AdvtUISequence</td><td>Sequence</td><td>Y</td><td>-4</td><td>32767</td><td/><td/><td/><td/><td>Number that determines the sort order in which the actions are to be executed.  Leave blank to suppress action.</td></row>
		<row><td>AppId</td><td>ActivateAtStorage</td><td>Y</td><td>0</td><td>1</td><td/><td/><td/><td/><td/></row>
		<row><td>AppId</td><td>AppId</td><td>N</td><td/><td/><td/><td/><td>Guid</td><td/><td/></row>
		<row><td>AppId</td><td>DllSurrogate</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td/></row>
		<row><td>AppId</td><td>LocalService</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td/></row>
		<row><td>AppId</td><td>RemoteServerName</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td/></row>
		<row><td>AppId</td><td>RunAsInteractiveUser</td><td>Y</td><td>0</td><td>1</td><td/><td/><td/><td/><td/></row>
		<row><td>AppId</td><td>ServiceParameters</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td/></row>
		<row><td>AppSearch</td><td>Property</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>The property associated with a Signature</td></row>
		<row><td>AppSearch</td><td>Signature_</td><td>N</td><td/><td/><td>ISXmlLocator;Signature</td><td>1</td><td>Identifier</td><td/><td>The Signature_ represents a unique file signature and is also the foreign key in the Signature,  RegLocator, IniLocator, CompLocator and the DrLocator tables.</td></row>
		<row><td>BBControl</td><td>Attributes</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>A 32-bit word that specifies the attribute flags to be applied to this control.</td></row>
		<row><td>BBControl</td><td>BBControl</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of the control. This name must be unique within a billboard, but can repeat on different billboard.</td></row>
		<row><td>BBControl</td><td>Billboard_</td><td>N</td><td/><td/><td>Billboard</td><td>1</td><td>Identifier</td><td/><td>External key to the Billboard table, name of the billboard.</td></row>
		<row><td>BBControl</td><td>Height</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Height of the bounding rectangle of the control.</td></row>
		<row><td>BBControl</td><td>Text</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>A string used to set the initial text contained within a control (if appropriate).</td></row>
		<row><td>BBControl</td><td>Type</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>The type of the control.</td></row>
		<row><td>BBControl</td><td>Width</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Width of the bounding rectangle of the control.</td></row>
		<row><td>BBControl</td><td>X</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Horizontal coordinate of the upper left corner of the bounding rectangle of the control.</td></row>
		<row><td>BBControl</td><td>Y</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Vertical coordinate of the upper left corner of the bounding rectangle of the control.</td></row>
		<row><td>Billboard</td><td>Action</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>The name of an action. The billboard is displayed during the progress messages received from this action.</td></row>
		<row><td>Billboard</td><td>Billboard</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of the billboard.</td></row>
		<row><td>Billboard</td><td>Feature_</td><td>N</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>An external key to the Feature Table. The billboard is shown only if this feature is being installed.</td></row>
		<row><td>Billboard</td><td>Ordering</td><td>Y</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>A positive integer. If there is more than one billboard corresponding to an action they will be shown in the order defined by this column.</td></row>
		<row><td>Binary</td><td>Data</td><td>Y</td><td/><td/><td/><td/><td>Binary</td><td/><td>Binary stream. The binary icon data in PE (.DLL or .EXE) or icon (.ICO) format.</td></row>
		<row><td>Binary</td><td>ISBuildSourcePath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path to the ICO or EXE file.</td></row>
		<row><td>Binary</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Unique key identifying the binary data.</td></row>
		<row><td>BindImage</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>The index into the File table. This must be an executable file.</td></row>
		<row><td>BindImage</td><td>Path</td><td>Y</td><td/><td/><td/><td/><td>Paths</td><td/><td>A list of ;  delimited paths that represent the paths to be searched for the import DLLS. The list is usually a list of properties each enclosed within square brackets [] .</td></row>
		<row><td>CCPSearch</td><td>Signature_</td><td>N</td><td/><td/><td>Signature</td><td>1</td><td>Identifier</td><td/><td>The Signature_ represents a unique file signature and is also the foreign key in the Signature,  RegLocator, IniLocator, CompLocator and the DrLocator tables.</td></row>
		<row><td>CheckBox</td><td>Property</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>A named property to be tied to the item.</td></row>
		<row><td>CheckBox</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The value string associated with the item.</td></row>
		<row><td>Class</td><td>AppId_</td><td>Y</td><td/><td/><td>AppId</td><td>1</td><td>Guid</td><td/><td>Optional AppID containing DCOM information for associated application (string GUID).</td></row>
		<row><td>Class</td><td>Argument</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>optional argument for LocalServers.</td></row>
		<row><td>Class</td><td>Attributes</td><td>Y</td><td/><td>32767</td><td/><td/><td/><td/><td>Class registration attributes.</td></row>
		<row><td>Class</td><td>CLSID</td><td>N</td><td/><td/><td/><td/><td>Guid</td><td/><td>The CLSID of an OLE factory.</td></row>
		<row><td>Class</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Required foreign key into the Component Table, specifying the component for which to return a path when called through LocateComponent.</td></row>
		<row><td>Class</td><td>Context</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>The numeric server context for this server. CLSCTX_xxxx</td></row>
		<row><td>Class</td><td>DefInprocHandler</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td>1;2;3</td><td>Optional default inproc handler.  Only optionally provided if Context=CLSCTX_LOCAL_SERVER.  Typically "ole32.dll" or "mapi32.dll"</td></row>
		<row><td>Class</td><td>Description</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Localized description for the Class.</td></row>
		<row><td>Class</td><td>Feature_</td><td>N</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>Required foreign key into the Feature Table, specifying the feature to validate or install in order for the CLSID factory to be operational.</td></row>
		<row><td>Class</td><td>FileTypeMask</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Optional string containing information for the HKCRthis CLSID) key. If multiple patterns exist, they must be delimited by a semicolon, and numeric subkeys will be generated: 0,1,2...</td></row>
		<row><td>Class</td><td>IconIndex</td><td>Y</td><td>-32767</td><td>32767</td><td/><td/><td/><td/><td>Optional icon index.</td></row>
		<row><td>Class</td><td>Icon_</td><td>Y</td><td/><td/><td>Icon</td><td>1</td><td>Identifier</td><td/><td>Optional foreign key into the Icon Table, specifying the icon file associated with this CLSID. Will be written under the DefaultIcon key.</td></row>
		<row><td>Class</td><td>ProgId_Default</td><td>Y</td><td/><td/><td>ProgId</td><td>1</td><td>Text</td><td/><td>Optional ProgId associated with this CLSID.</td></row>
		<row><td>ComboBox</td><td>Order</td><td>N</td><td>1</td><td>32767</td><td/><td/><td/><td/><td>A positive integer used to determine the ordering of the items within one list.	The integers do not have to be consecutive.</td></row>
		<row><td>ComboBox</td><td>Property</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>A named property to be tied to this item. All the items tied to the same property become part of the same combobox.</td></row>
		<row><td>ComboBox</td><td>Text</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The visible text to be assigned to the item. Optional. If this entry or the entire column is missing, the text is the same as the value.</td></row>
		<row><td>ComboBox</td><td>Value</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The value string associated with this item. Selecting the line will set the associated property to this value.</td></row>
		<row><td>CompLocator</td><td>ComponentId</td><td>N</td><td/><td/><td/><td/><td>Guid</td><td/><td>A string GUID unique to this component, version, and language.</td></row>
		<row><td>CompLocator</td><td>Signature_</td><td>N</td><td/><td/><td>Signature</td><td>1</td><td>Identifier</td><td/><td>The table key. The Signature_ represents a unique file signature and is also the foreign key in the Signature table.</td></row>
		<row><td>CompLocator</td><td>Type</td><td>Y</td><td>0</td><td>1</td><td/><td/><td/><td/><td>A boolean value that determines if the registry value is a filename or a directory location.</td></row>
		<row><td>Complus</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key referencing Component that controls the ComPlus component.</td></row>
		<row><td>Complus</td><td>ExpType</td><td>Y</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>ComPlus component attributes.</td></row>
		<row><td>Component</td><td>Attributes</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Remote execution option, one of irsEnum</td></row>
		<row><td>Component</td><td>Component</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key used to identify a particular component record.</td></row>
		<row><td>Component</td><td>ComponentId</td><td>Y</td><td/><td/><td/><td/><td>Guid</td><td/><td>A string GUID unique to this component, version, and language.</td></row>
		<row><td>Component</td><td>Condition</td><td>Y</td><td/><td/><td/><td/><td>Condition</td><td/><td>A conditional statement that will disable this component if the specified condition evaluates to the 'True' state. If a component is disabled, it will not be installed, regardless of the 'Action' state associated with the component.</td></row>
		<row><td>Component</td><td>Directory_</td><td>N</td><td/><td/><td>Directory</td><td>1</td><td>Identifier</td><td/><td>Required key of a Directory table record. This is actually a property name whose value contains the actual path, set either by the AppSearch action or with the default setting obtained from the Directory table.</td></row>
		<row><td>Component</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>This is used to store Installshield custom properties of a component.</td></row>
		<row><td>Component</td><td>ISComments</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>User Comments.</td></row>
		<row><td>Component</td><td>ISDotNetInstallerArgsCommit</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Arguments passed to the key file of the component if if implements the .NET Installer class</td></row>
		<row><td>Component</td><td>ISDotNetInstallerArgsInstall</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Arguments passed to the key file of the component if if implements the .NET Installer class</td></row>
		<row><td>Component</td><td>ISDotNetInstallerArgsRollback</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Arguments passed to the key file of the component if if implements the .NET Installer class</td></row>
		<row><td>Component</td><td>ISDotNetInstallerArgsUninstall</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Arguments passed to the key file of the component if if implements the .NET Installer class</td></row>
		<row><td>Component</td><td>ISRegFileToMergeAtBuild</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Path and File name of a .REG file to merge into the component at build time.</td></row>
		<row><td>Component</td><td>ISScanAtBuildFile</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>File used by the Dot Net scanner to populate dependant assemblies' File_Application field.</td></row>
		<row><td>Component</td><td>KeyPath</td><td>Y</td><td/><td/><td>File;ODBCDataSource;Registry</td><td>1</td><td>Identifier</td><td/><td>Either the primary key into the File table, Registry table, or ODBCDataSource table. This extract path is stored when the component is installed, and is used to detect the presence of the component and to return the path to it.</td></row>
		<row><td>Condition</td><td>Condition</td><td>Y</td><td/><td/><td/><td/><td>Condition</td><td/><td>Expression evaluated to determine if Level in the Feature table is to change.</td></row>
		<row><td>Condition</td><td>Feature_</td><td>N</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>Reference to a Feature entry in Feature table.</td></row>
		<row><td>Condition</td><td>Level</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>New selection Level to set in Feature table if Condition evaluates to TRUE.</td></row>
		<row><td>Control</td><td>Attributes</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>A 32-bit word that specifies the attribute flags to be applied to this control.</td></row>
		<row><td>Control</td><td>Binary_</td><td>Y</td><td/><td/><td>Binary</td><td>1</td><td>Identifier</td><td/><td>External key to the Binary table.</td></row>
		<row><td>Control</td><td>Control</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of the control. This name must be unique within a dialog, but can repeat on different dialogs.</td></row>
		<row><td>Control</td><td>Control_Next</td><td>Y</td><td/><td/><td>Control</td><td>2</td><td>Identifier</td><td/><td>The name of an other control on the same dialog. This link defines the tab order of the controls. The links have to form one or more cycles!</td></row>
		<row><td>Control</td><td>Dialog_</td><td>N</td><td/><td/><td>Dialog</td><td>1</td><td>Identifier</td><td/><td>External key to the Dialog table, name of the dialog.</td></row>
		<row><td>Control</td><td>Height</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Height of the bounding rectangle of the control.</td></row>
		<row><td>Control</td><td>Help</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The help strings used with the button. The text is optional.</td></row>
		<row><td>Control</td><td>ISBuildSourcePath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path to .rtf file for scrollable text control</td></row>
		<row><td>Control</td><td>ISControlId</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>A number used to represent the control ID of the Control, Used in Dialog export</td></row>
		<row><td>Control</td><td>ISWindowStyle</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>A 32-bit word that specifies non-MSI window styles to be applied to this control.</td></row>
		<row><td>Control</td><td>Property</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>The name of a defined property to be linked to this control.</td></row>
		<row><td>Control</td><td>Text</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>A string used to set the initial text contained within a control (if appropriate).</td></row>
		<row><td>Control</td><td>Type</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>The type of the control.</td></row>
		<row><td>Control</td><td>Width</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Width of the bounding rectangle of the control.</td></row>
		<row><td>Control</td><td>X</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Horizontal coordinate of the upper left corner of the bounding rectangle of the control.</td></row>
		<row><td>Control</td><td>Y</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Vertical coordinate of the upper left corner of the bounding rectangle of the control.</td></row>
		<row><td>ControlCondition</td><td>Action</td><td>N</td><td/><td/><td/><td/><td/><td>Default;Disable;Enable;Hide;Show</td><td>The desired action to be taken on the specified control.</td></row>
		<row><td>ControlCondition</td><td>Condition</td><td>N</td><td/><td/><td/><td/><td>Condition</td><td/><td>A standard conditional statement that specifies under which conditions the action should be triggered.</td></row>
		<row><td>ControlCondition</td><td>Control_</td><td>N</td><td/><td/><td>Control</td><td>2</td><td>Identifier</td><td/><td>A foreign key to the Control table, name of the control.</td></row>
		<row><td>ControlCondition</td><td>Dialog_</td><td>N</td><td/><td/><td>Dialog</td><td>1</td><td>Identifier</td><td/><td>A foreign key to the Dialog table, name of the dialog.</td></row>
		<row><td>ControlEvent</td><td>Argument</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>A value to be used as a modifier when triggering a particular event.</td></row>
		<row><td>ControlEvent</td><td>Condition</td><td>Y</td><td/><td/><td/><td/><td>Condition</td><td/><td>A standard conditional statement that specifies under which conditions an event should be triggered.</td></row>
		<row><td>ControlEvent</td><td>Control_</td><td>N</td><td/><td/><td>Control</td><td>2</td><td>Identifier</td><td/><td>A foreign key to the Control table, name of the control</td></row>
		<row><td>ControlEvent</td><td>Dialog_</td><td>N</td><td/><td/><td>Dialog</td><td>1</td><td>Identifier</td><td/><td>A foreign key to the Dialog table, name of the dialog.</td></row>
		<row><td>ControlEvent</td><td>Event</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>An identifier that specifies the type of the event that should take place when the user interacts with control specified by the first two entries.</td></row>
		<row><td>ControlEvent</td><td>Ordering</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>An integer used to order several events tied to the same control. Can be left blank.</td></row>
		<row><td>CreateFolder</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the Component table.</td></row>
		<row><td>CreateFolder</td><td>Directory_</td><td>N</td><td/><td/><td>Directory</td><td>1</td><td>Identifier</td><td/><td>Primary key, could be foreign key into the Directory table.</td></row>
		<row><td>CustomAction</td><td>Action</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, name of action, normally appears in sequence table unless private use.</td></row>
		<row><td>CustomAction</td><td>ExtendedType</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>The numeric custom action type info flags.</td></row>
		<row><td>CustomAction</td><td>ISComments</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Author’s comments for this custom action.</td></row>
		<row><td>CustomAction</td><td>Source</td><td>Y</td><td/><td/><td/><td/><td>CustomSource</td><td/><td>The table reference of the source of the code.</td></row>
		<row><td>CustomAction</td><td>Target</td><td>Y</td><td/><td/><td>ISDLLWrapper;ISInstallScriptAction</td><td>1</td><td>Formatted</td><td/><td>Excecution parameter, depends on the type of custom action</td></row>
		<row><td>CustomAction</td><td>Type</td><td>N</td><td>1</td><td>32767</td><td/><td/><td/><td/><td>The numeric custom action type, consisting of source location, code type, entry, option flags.</td></row>
		<row><td>Dialog</td><td>Attributes</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>A 32-bit word that specifies the attribute flags to be applied to this dialog.</td></row>
		<row><td>Dialog</td><td>Control_Cancel</td><td>Y</td><td/><td/><td>Control</td><td>2</td><td>Identifier</td><td/><td>Defines the cancel control. Hitting escape or clicking on the close icon on the dialog is equivalent to pushing this button.</td></row>
		<row><td>Dialog</td><td>Control_Default</td><td>Y</td><td/><td/><td>Control</td><td>2</td><td>Identifier</td><td/><td>Defines the default control. Hitting return is equivalent to pushing this button.</td></row>
		<row><td>Dialog</td><td>Control_First</td><td>N</td><td/><td/><td>Control</td><td>2</td><td>Identifier</td><td/><td>Defines the control that has the focus when the dialog is created.</td></row>
		<row><td>Dialog</td><td>Dialog</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of the dialog.</td></row>
		<row><td>Dialog</td><td>HCentering</td><td>N</td><td>0</td><td>100</td><td/><td/><td/><td/><td>Horizontal position of the dialog on a 0-100 scale. 0 means left end, 100 means right end of the screen, 50 center.</td></row>
		<row><td>Dialog</td><td>Height</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Height of the bounding rectangle of the dialog.</td></row>
		<row><td>Dialog</td><td>ISComments</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Author’s comments for this dialog.</td></row>
		<row><td>Dialog</td><td>ISResourceId</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>A Number the Specifies the Dialog ID to be used in Dialog Export</td></row>
		<row><td>Dialog</td><td>ISWindowStyle</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>A 32-bit word that specifies non-MSI window styles to be applied to this control. This is only used in Script Based Setups.</td></row>
		<row><td>Dialog</td><td>TextStyle_</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Foreign Key into TextStyle table, only used in Script Based Projects.</td></row>
		<row><td>Dialog</td><td>Title</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>A text string specifying the title to be displayed in the title bar of the dialog's window.</td></row>
		<row><td>Dialog</td><td>VCentering</td><td>N</td><td>0</td><td>100</td><td/><td/><td/><td/><td>Vertical position of the dialog on a 0-100 scale. 0 means top end, 100 means bottom end of the screen, 50 center.</td></row>
		<row><td>Dialog</td><td>Width</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Width of the bounding rectangle of the dialog.</td></row>
		<row><td>Directory</td><td>DefaultDir</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The default sub-path under parent's path.</td></row>
		<row><td>Directory</td><td>Directory</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Unique identifier for directory entry, primary key. If a property by this name is defined, it contains the full path to the directory.</td></row>
		<row><td>Directory</td><td>Directory_Parent</td><td>Y</td><td/><td/><td>Directory</td><td>1</td><td>Identifier</td><td/><td>Reference to the entry in this table specifying the default parent directory. A record parented to itself or with a Null parent represents a root of the install tree.</td></row>
		<row><td>Directory</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td>0;1;2;3;4;5;6;7</td><td>This is used to store Installshield custom properties of a directory.  Currently the only one is Shortcut.</td></row>
		<row><td>Directory</td><td>ISDescription</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Description of folder</td></row>
		<row><td>Directory</td><td>ISFolderName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>This is used in Pro projects because the pro identifier used in the tree wasn't necessarily unique.</td></row>
		<row><td>DrLocator</td><td>Depth</td><td>Y</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The depth below the path to which the Signature_ is recursively searched. If absent, the depth is assumed to be 0.</td></row>
		<row><td>DrLocator</td><td>Parent</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>The parent file signature. It is also a foreign key in the Signature table. If null and the Path column does not expand to a full path, then all the fixed drives of the user system are searched using the Path.</td></row>
		<row><td>DrLocator</td><td>Path</td><td>Y</td><td/><td/><td/><td/><td>AnyPath</td><td/><td>The path on the user system. This is a either a subpath below the value of the Parent or a full path. The path may contain properties enclosed within [ ] that will be expanded.</td></row>
		<row><td>DrLocator</td><td>Signature_</td><td>N</td><td/><td/><td>Signature</td><td>1</td><td>Identifier</td><td/><td>The Signature_ represents a unique file signature and is also the foreign key in the Signature table.</td></row>
		<row><td>DuplicateFile</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key referencing Component that controls the duplicate file.</td></row>
		<row><td>DuplicateFile</td><td>DestFolder</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of a property whose value is assumed to resolve to the full pathname to a destination folder.</td></row>
		<row><td>DuplicateFile</td><td>DestName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Filename to be given to the duplicate file.</td></row>
		<row><td>DuplicateFile</td><td>FileKey</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key used to identify a particular file entry</td></row>
		<row><td>DuplicateFile</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Foreign key referencing the source file to be duplicated.</td></row>
		<row><td>Environment</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the Component table referencing component that controls the installing of the environmental value.</td></row>
		<row><td>Environment</td><td>Environment</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Unique identifier for the environmental variable setting</td></row>
		<row><td>Environment</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The name of the environmental value.</td></row>
		<row><td>Environment</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The value to set in the environmental settings.</td></row>
		<row><td>Error</td><td>Error</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Integer error number, obtained from header file IError(...) macros.</td></row>
		<row><td>Error</td><td>Message</td><td>Y</td><td/><td/><td/><td/><td>Template</td><td/><td>Error formatting template, obtained from user ed. or localizers.</td></row>
		<row><td>EventMapping</td><td>Attribute</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>The name of the control attribute, that is set when this event is received.</td></row>
		<row><td>EventMapping</td><td>Control_</td><td>N</td><td/><td/><td>Control</td><td>2</td><td>Identifier</td><td/><td>A foreign key to the Control table, name of the control.</td></row>
		<row><td>EventMapping</td><td>Dialog_</td><td>N</td><td/><td/><td>Dialog</td><td>1</td><td>Identifier</td><td/><td>A foreign key to the Dialog table, name of the Dialog.</td></row>
		<row><td>EventMapping</td><td>Event</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>An identifier that specifies the type of the event that the control subscribes to.</td></row>
		<row><td>Extension</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Required foreign key into the Component Table, specifying the component for which to return a path when called through LocateComponent.</td></row>
		<row><td>Extension</td><td>Extension</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The extension associated with the table row.</td></row>
		<row><td>Extension</td><td>Feature_</td><td>N</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>Required foreign key into the Feature Table, specifying the feature to validate or install in order for the CLSID factory to be operational.</td></row>
		<row><td>Extension</td><td>MIME_</td><td>Y</td><td/><td/><td>MIME</td><td>1</td><td>Text</td><td/><td>Optional Context identifier, typically "type/format" associated with the extension</td></row>
		<row><td>Extension</td><td>ProgId_</td><td>Y</td><td/><td/><td>ProgId</td><td>1</td><td>Text</td><td/><td>Optional ProgId associated with this extension.</td></row>
		<row><td>Feature</td><td>Attributes</td><td>N</td><td/><td/><td/><td/><td/><td>0;1;2;4;5;6;8;9;10;16;17;18;20;21;22;24;25;26;32;33;34;36;37;38;48;49;50;52;53;54</td><td>Feature attributes</td></row>
		<row><td>Feature</td><td>Description</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Longer descriptive text describing a visible feature item.</td></row>
		<row><td>Feature</td><td>Directory_</td><td>Y</td><td/><td/><td>Directory</td><td>1</td><td>UpperCase</td><td/><td>The name of the Directory that can be configured by the UI. A non-null value will enable the browse button.</td></row>
		<row><td>Feature</td><td>Display</td><td>Y</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Numeric sort order, used to force a specific display ordering.</td></row>
		<row><td>Feature</td><td>Feature</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key used to identify a particular feature record.</td></row>
		<row><td>Feature</td><td>Feature_Parent</td><td>Y</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>Optional key of a parent record in the same table. If the parent is not selected, then the record will not be installed. Null indicates a root item.</td></row>
		<row><td>Feature</td><td>ISComments</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Comments</td></row>
		<row><td>Feature</td><td>ISFeatureCabName</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Name of CAB used when compressing CABs by Feature. Used to override build generated name for CAB file.</td></row>
		<row><td>Feature</td><td>ISProFeatureName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The name of the feature used by pro projects.  This doesn't have to be unique.</td></row>
		<row><td>Feature</td><td>ISReleaseFlags</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Release Flags that specify whether this  feature will be built in a particular release.</td></row>
		<row><td>Feature</td><td>Level</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The install level at which record will be initially selected. An install level of 0 will disable an item and prevent its display.</td></row>
		<row><td>Feature</td><td>Title</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Short text identifying a visible feature item.</td></row>
		<row><td>FeatureComponents</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into Component table.</td></row>
		<row><td>FeatureComponents</td><td>Feature_</td><td>N</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>Foreign key into Feature table.</td></row>
		<row><td>File</td><td>Attributes</td><td>Y</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Integer containing bit flags representing file attributes (with the decimal value of each bit position in parentheses)</td></row>
		<row><td>File</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key referencing Component that controls the file.</td></row>
		<row><td>File</td><td>File</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized token, must match identifier in cabinet.  For uncompressed files, this field is ignored.</td></row>
		<row><td>File</td><td>FileName</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>File name used for installation.  This may contain a "short name|long name" pair.  It may be just a long name, hence it cannot be of the Filename data type.</td></row>
		<row><td>File</td><td>FileSize</td><td>N</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>Size of file in bytes (long integer).</td></row>
		<row><td>File</td><td>ISAttributes</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>This field contains the following attributes: UseSystemSettings(0x1)</td></row>
		<row><td>File</td><td>ISBuildSourcePath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path, the category is of Text instead of Path because of potential use of path variables.</td></row>
		<row><td>File</td><td>ISComponentSubFolder_</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Foreign key referencing component subfolder containing this file.  Only for Pro.</td></row>
		<row><td>File</td><td>Language</td><td>Y</td><td/><td/><td/><td/><td>Language</td><td/><td>List of decimal language Ids, comma-separated if more than one.</td></row>
		<row><td>File</td><td>Sequence</td><td>N</td><td>1</td><td>32767</td><td/><td/><td/><td/><td>Sequence with respect to the media images; order must track cabinet order.</td></row>
		<row><td>File</td><td>Version</td><td>Y</td><td/><td/><td>File</td><td>1</td><td>Version</td><td/><td>Version string for versioned files;  Blank for unversioned files.</td></row>
		<row><td>FileSFPCatalog</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>File associated with the catalog</td></row>
		<row><td>FileSFPCatalog</td><td>SFPCatalog_</td><td>N</td><td/><td/><td>SFPCatalog</td><td>1</td><td>Text</td><td/><td>Catalog associated with the file</td></row>
		<row><td>Font</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Primary key, foreign key into File table referencing font file.</td></row>
		<row><td>Font</td><td>FontTitle</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Font name.</td></row>
		<row><td>ISAssistantTag</td><td>Data</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISAssistantTag</td><td>Tag</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISBillBoard</td><td>Color</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISBillBoard</td><td>DisplayName</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISBillBoard</td><td>Duration</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td/></row>
		<row><td>ISBillBoard</td><td>Effect</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td/></row>
		<row><td>ISBillBoard</td><td>Font</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISBillBoard</td><td>ISBillboard</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISBillBoard</td><td>Origin</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td/></row>
		<row><td>ISBillBoard</td><td>Sequence</td><td>N</td><td>-32767</td><td>32767</td><td/><td/><td/><td/><td/></row>
		<row><td>ISBillBoard</td><td>Style</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISBillBoard</td><td>Target</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td/></row>
		<row><td>ISBillBoard</td><td>Title</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISBillBoard</td><td>X</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td/></row>
		<row><td>ISBillBoard</td><td>Y</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td/></row>
		<row><td>ISChainPackage</td><td>DisplayName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Display name for the chained package. Used only in the IDE.</td></row>
		<row><td>ISChainPackage</td><td>ISReleaseFlags</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISChainPackage</td><td>InstallCondition</td><td>Y</td><td/><td/><td/><td/><td>Condition</td><td/><td/></row>
		<row><td>ISChainPackage</td><td>InstallProperties</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td/></row>
		<row><td>ISChainPackage</td><td>Options</td><td>N</td><td/><td/><td/><td/><td>Integer</td><td/><td/></row>
		<row><td>ISChainPackage</td><td>Order</td><td>N</td><td/><td/><td/><td/><td>Integer</td><td/><td/></row>
		<row><td>ISChainPackage</td><td>Package</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td/></row>
		<row><td>ISChainPackage</td><td>ProductCode</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISChainPackage</td><td>RemoveCondition</td><td>Y</td><td/><td/><td/><td/><td>Condition</td><td/><td/></row>
		<row><td>ISChainPackage</td><td>RemoveProperties</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td/></row>
		<row><td>ISChainPackage</td><td>SourcePath</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISChainPackageData</td><td>Data</td><td>Y</td><td/><td/><td/><td/><td>Binary</td><td/><td>Binary stream. The binary icon data in PE (.DLL or .EXE) or icon (.ICO) format.</td></row>
		<row><td>ISChainPackageData</td><td>File</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td/></row>
		<row><td>ISChainPackageData</td><td>FilePath</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td/></row>
		<row><td>ISChainPackageData</td><td>ISBuildSourcePath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path to the ICO or EXE file.</td></row>
		<row><td>ISChainPackageData</td><td>Options</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISChainPackageData</td><td>Package_</td><td>N</td><td/><td/><td>ISChainPackage</td><td>1</td><td>Identifier</td><td/><td/></row>
		<row><td>ISClrWrap</td><td>Action_</td><td>N</td><td/><td/><td>CustomAction</td><td>1</td><td>Identifier</td><td/><td>Foreign key into CustomAction table</td></row>
		<row><td>ISClrWrap</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Property associated with this Action</td></row>
		<row><td>ISClrWrap</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Value associated with this Property</td></row>
		<row><td>ISComCatalogAttribute</td><td>ISComCatalogObject_</td><td>N</td><td/><td/><td>ISComCatalogObject</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the ISComCatalogObject table.</td></row>
		<row><td>ISComCatalogAttribute</td><td>ItemName</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The named attribute for a catalog object.</td></row>
		<row><td>ISComCatalogAttribute</td><td>ItemValue</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>A value associated with the attribute defined in the ItemName column.</td></row>
		<row><td>ISComCatalogCollection</td><td>CollectionName</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>A catalog collection name.</td></row>
		<row><td>ISComCatalogCollection</td><td>ISComCatalogCollection</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>A unique key for the ISComCatalogCollection table.</td></row>
		<row><td>ISComCatalogCollection</td><td>ISComCatalogObject_</td><td>N</td><td/><td/><td>ISComCatalogObject</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the ISComCatalogObject table.</td></row>
		<row><td>ISComCatalogCollectionObjects</td><td>ISComCatalogCollection_</td><td>N</td><td/><td/><td>ISComCatalogCollection</td><td>1</td><td>Identifier</td><td/><td>A unique key for the ISComCatalogCollection table.</td></row>
		<row><td>ISComCatalogCollectionObjects</td><td>ISComCatalogObject_</td><td>N</td><td/><td/><td>ISComCatalogObject</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the ISComCatalogObject table.</td></row>
		<row><td>ISComCatalogObject</td><td>DisplayName</td><td>N</td><td/><td/><td/><td/><td/><td/><td>The display name of a catalog object.</td></row>
		<row><td>ISComCatalogObject</td><td>ISComCatalogObject</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>A unique key for the ISComCatalogObject table.</td></row>
		<row><td>ISComPlusApplication</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the Component table that a COM+ application belongs to.</td></row>
		<row><td>ISComPlusApplication</td><td>ComputerName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Computer name that a COM+ application belongs to.</td></row>
		<row><td>ISComPlusApplication</td><td>DepFiles</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>List of the dependent files.</td></row>
		<row><td>ISComPlusApplication</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>InstallShield custom attributes associated with a COM+ application.</td></row>
		<row><td>ISComPlusApplication</td><td>ISComCatalogObject_</td><td>N</td><td/><td/><td>ISComCatalogObject</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the ISComCatalogObject table.</td></row>
		<row><td>ISComPlusApplicationDLL</td><td>AlterDLL</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Alternate filename of the COM+ application component. Will be used for a .NET serviced component.</td></row>
		<row><td>ISComPlusApplicationDLL</td><td>CLSID</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>CLSID of the COM+ application component.</td></row>
		<row><td>ISComPlusApplicationDLL</td><td>DLL</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Filename of the COM+ application component.</td></row>
		<row><td>ISComPlusApplicationDLL</td><td>ISComCatalogObject_</td><td>N</td><td/><td/><td>ISComCatalogObject</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the ISComCatalogObject table.</td></row>
		<row><td>ISComPlusApplicationDLL</td><td>ISComPlusApplicationDLL</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>A unique key for the ISComPlusApplicationDLL table.</td></row>
		<row><td>ISComPlusApplicationDLL</td><td>ISComPlusApplication_</td><td>N</td><td/><td/><td>ISComPlusApplication</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the ISComPlusApplication table.</td></row>
		<row><td>ISComPlusApplicationDLL</td><td>ProgId</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>ProgId of the COM+ application component.</td></row>
		<row><td>ISComPlusProxy</td><td>Component_</td><td>Y</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the Component table that a COM+ application proxy belongs to.</td></row>
		<row><td>ISComPlusProxy</td><td>DepFiles</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>List of the dependent files.</td></row>
		<row><td>ISComPlusProxy</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>InstallShield custom attributes associated with a COM+ application proxy.</td></row>
		<row><td>ISComPlusProxy</td><td>ISComPlusApplication_</td><td>N</td><td/><td/><td>ISComPlusApplication</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the ISComPlusApplication table that a COM+ application proxy belongs to.</td></row>
		<row><td>ISComPlusProxy</td><td>ISComPlusProxy</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>A unique key for the ISComPlusProxy table.</td></row>
		<row><td>ISComPlusProxyDepFile</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the File table.</td></row>
		<row><td>ISComPlusProxyDepFile</td><td>ISComPlusApplication_</td><td>N</td><td/><td/><td>ISComPlusApplication</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the ISComPlusApplication table.</td></row>
		<row><td>ISComPlusProxyDepFile</td><td>ISPath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path of the dependent file.</td></row>
		<row><td>ISComPlusProxyFile</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the File table.</td></row>
		<row><td>ISComPlusProxyFile</td><td>ISComPlusApplicationDLL_</td><td>N</td><td/><td/><td>ISComPlusApplicationDLL</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the ISComPlusApplicationDLL table.</td></row>
		<row><td>ISComPlusServerDepFile</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the File table.</td></row>
		<row><td>ISComPlusServerDepFile</td><td>ISComPlusApplication_</td><td>N</td><td/><td/><td>ISComPlusApplication</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the ISComPlusApplication table.</td></row>
		<row><td>ISComPlusServerDepFile</td><td>ISPath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path of the dependent file.</td></row>
		<row><td>ISComPlusServerFile</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the File table.</td></row>
		<row><td>ISComPlusServerFile</td><td>ISComPlusApplicationDLL_</td><td>N</td><td/><td/><td>ISComPlusApplicationDLL</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the ISComPlusApplicationDLL table.</td></row>
		<row><td>ISComponentExtended</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Primary key used to identify a particular component record.</td></row>
		<row><td>ISComponentExtended</td><td>FTPLocation</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>FTP Location</td></row>
		<row><td>ISComponentExtended</td><td>FilterProperty</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Property to set if you want to filter a component</td></row>
		<row><td>ISComponentExtended</td><td>HTTPLocation</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>HTTP Location</td></row>
		<row><td>ISComponentExtended</td><td>Language</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Language</td></row>
		<row><td>ISComponentExtended</td><td>Miscellaneous</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Miscellaneous</td></row>
		<row><td>ISComponentExtended</td><td>OS</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>bitwise addition of OSs</td></row>
		<row><td>ISComponentExtended</td><td>Platforms</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>bitwise addition of Platforms.</td></row>
		<row><td>ISCustomActionReference</td><td>Action_</td><td>N</td><td/><td/><td>CustomAction</td><td>1</td><td>Identifier</td><td/><td>Foreign key into theICustomAction table.</td></row>
		<row><td>ISCustomActionReference</td><td>Description</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Contents of the file speciifed in ISCAReferenceFilePath. This column is only used by MSI.</td></row>
		<row><td>ISCustomActionReference</td><td>FileType</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>file type of the file specified  ISCAReferenceFilePath. This column is only used by MSI.</td></row>
		<row><td>ISCustomActionReference</td><td>ISCAReferenceFilePath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path, the category is of Text instead of Path because of potential use of path variables.  This column only exists in ISM.</td></row>
		<row><td>ISDIMDependency</td><td>ISDIMReference_</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>This is the primary key to the ISDIMDependency table</td></row>
		<row><td>ISDIMDependency</td><td>RequiredBuildVersion</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>the build version identifying the required DIM</td></row>
		<row><td>ISDIMDependency</td><td>RequiredMajorVersion</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>the major version identifying the required DIM</td></row>
		<row><td>ISDIMDependency</td><td>RequiredMinorVersion</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>the minor version identifying the required DIM</td></row>
		<row><td>ISDIMDependency</td><td>RequiredRevisionVersion</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>the revision version identifying the required DIM</td></row>
		<row><td>ISDIMDependency</td><td>RequiredUUID</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>the UUID identifying the required DIM</td></row>
		<row><td>ISDIMReference</td><td>ISBuildSourcePath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path, the category is of Text instead of Path because of potential use of path variables.</td></row>
		<row><td>ISDIMReference</td><td>ISDIMReference</td><td>N</td><td/><td/><td>ISDIMDependency</td><td>1</td><td>Identifier</td><td/><td>This is the primary key to the ISDIMReference table</td></row>
		<row><td>ISDIMReferenceDependencies</td><td>ISDIMDependency_</td><td>N</td><td/><td/><td>ISDIMDependency</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISDIMDependency table.</td></row>
		<row><td>ISDIMReferenceDependencies</td><td>ISDIMReference_Parent</td><td>N</td><td/><td/><td>ISDIMReference</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISDIMReference table.</td></row>
		<row><td>ISDIMVariable</td><td>ISDIMReference_</td><td>N</td><td/><td/><td>ISDIMReference</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISDIMReference table.</td></row>
		<row><td>ISDIMVariable</td><td>ISDIMVariable</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>This is the primary key to the ISDIMVariable table</td></row>
		<row><td>ISDIMVariable</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Name of a variable defined in the .dim file</td></row>
		<row><td>ISDIMVariable</td><td>NewValue</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>New value that you want to override with</td></row>
		<row><td>ISDIMVariable</td><td>Type</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Type of the variable. 0: Build Variable, 1: Runtime Variable</td></row>
		<row><td>ISDLLWrapper</td><td>EntryPoint</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>This is a foreign key to the target column in the CustomAction table</td></row>
		<row><td>ISDLLWrapper</td><td>Source</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>This is column points to the source file for the DLLWrapper Custom Action</td></row>
		<row><td>ISDLLWrapper</td><td>Target</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The function signature</td></row>
		<row><td>ISDLLWrapper</td><td>Type</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Type</td></row>
		<row><td>ISDependency</td><td>Exclude</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISDependency</td><td>ISDependency</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISDisk1File</td><td>Disk</td><td>Y</td><td/><td/><td/><td/><td/><td>-1;0;1</td><td>Used to differentiate between disk1(1), last disk(-1), and other(0).</td></row>
		<row><td>ISDisk1File</td><td>ISBuildSourcePath</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path of file to be copied to Disk1 folder</td></row>
		<row><td>ISDisk1File</td><td>ISDisk1File</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key for ISDisk1File table</td></row>
		<row><td>ISDynamicFile</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key referencing Component that controls the file.</td></row>
		<row><td>ISDynamicFile</td><td>ExcludeFiles</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Wildcards for excluded files.</td></row>
		<row><td>ISDynamicFile</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td>0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15</td><td>This is used to store Installshield custom properties of a dynamic filet.  Currently the only one is SelfRegister.</td></row>
		<row><td>ISDynamicFile</td><td>IncludeFiles</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Wildcards for included files.</td></row>
		<row><td>ISDynamicFile</td><td>IncludeFlags</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Include flags.</td></row>
		<row><td>ISDynamicFile</td><td>SourceFolder</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path, the category is of Text instead of Path because of potential use of path variables.</td></row>
		<row><td>ISFeatureDIMReferences</td><td>Feature_</td><td>N</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>Foreign key into Feature table.</td></row>
		<row><td>ISFeatureDIMReferences</td><td>ISDIMReference_</td><td>N</td><td/><td/><td>ISDIMReference</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISDIMReference table.</td></row>
		<row><td>ISFeatureMergeModuleExcludes</td><td>Feature_</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Foreign key into Feature table.</td></row>
		<row><td>ISFeatureMergeModuleExcludes</td><td>Language</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Foreign key into ISMergeModule table.</td></row>
		<row><td>ISFeatureMergeModuleExcludes</td><td>ModuleID</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Foreign key into ISMergeModule table.</td></row>
		<row><td>ISFeatureMergeModules</td><td>Feature_</td><td>N</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>Foreign key into Feature table.</td></row>
		<row><td>ISFeatureMergeModules</td><td>ISMergeModule_</td><td>N</td><td/><td/><td>ISMergeModule</td><td>1</td><td>Text</td><td/><td>Foreign key into ISMergeModule table.</td></row>
		<row><td>ISFeatureMergeModules</td><td>Language_</td><td>N</td><td/><td/><td>ISMergeModule</td><td>2</td><td/><td/><td>Foreign key into ISMergeModule table.</td></row>
		<row><td>ISFeatureSetupPrerequisites</td><td>Feature_</td><td>N</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>Foreign key into Feature table.</td></row>
		<row><td>ISFeatureSetupPrerequisites</td><td>ISSetupPrerequisites_</td><td>N</td><td/><td/><td>ISSetupPrerequisites</td><td>1</td><td/><td/><td/></row>
		<row><td>ISFileManifests</td><td>File_</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Foreign key into File table.</td></row>
		<row><td>ISFileManifests</td><td>Manifest_</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Foreign key into File table.</td></row>
		<row><td>ISIISItem</td><td>Component_</td><td>Y</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key to Component table.</td></row>
		<row><td>ISIISItem</td><td>DisplayName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Localizable Item Name.</td></row>
		<row><td>ISIISItem</td><td>ISIISItem</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key for each item.</td></row>
		<row><td>ISIISItem</td><td>ISIISItem_Parent</td><td>Y</td><td/><td/><td>ISIISItem</td><td>1</td><td>Identifier</td><td/><td>This record's parent record.</td></row>
		<row><td>ISIISItem</td><td>Type</td><td>N</td><td/><td/><td/><td/><td/><td/><td>IIS resource type.</td></row>
		<row><td>ISIISProperty</td><td>FriendlyName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>IIS property name.</td></row>
		<row><td>ISIISProperty</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Flags.</td></row>
		<row><td>ISIISProperty</td><td>ISIISItem_</td><td>N</td><td/><td/><td>ISIISItem</td><td>1</td><td>Identifier</td><td/><td>Primary key for table, foreign key into ISIISItem.</td></row>
		<row><td>ISIISProperty</td><td>ISIISProperty</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key for table.</td></row>
		<row><td>ISIISProperty</td><td>MetaDataAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>IIS property attributes.</td></row>
		<row><td>ISIISProperty</td><td>MetaDataProp</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>IIS property ID.</td></row>
		<row><td>ISIISProperty</td><td>MetaDataType</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>IIS property data type.</td></row>
		<row><td>ISIISProperty</td><td>MetaDataUserType</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>IIS property user data type.</td></row>
		<row><td>ISIISProperty</td><td>MetaDataValue</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>IIS property value.</td></row>
		<row><td>ISIISProperty</td><td>Order</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Order sequencing.</td></row>
		<row><td>ISIISProperty</td><td>Schema</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>IIS7 schema information.</td></row>
		<row><td>ISInstallScriptAction</td><td>EntryPoint</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>This is a foreign key to the target column in the CustomAction table</td></row>
		<row><td>ISInstallScriptAction</td><td>Source</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>This is column points to the source file for the DLLWrapper Custom Action</td></row>
		<row><td>ISInstallScriptAction</td><td>Target</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The function signature</td></row>
		<row><td>ISInstallScriptAction</td><td>Type</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Type</td></row>
		<row><td>ISLanguage</td><td>ISLanguage</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>This is the language ID.</td></row>
		<row><td>ISLanguage</td><td>Included</td><td>Y</td><td/><td/><td/><td/><td/><td>0;1</td><td>Specify whether this language should be included.</td></row>
		<row><td>ISLinkerLibrary</td><td>ISLinkerLibrary</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Unique identifier for the link library.</td></row>
		<row><td>ISLinkerLibrary</td><td>Library</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path of the object library (.obl file).</td></row>
		<row><td>ISLinkerLibrary</td><td>Order</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Order of the Library</td></row>
		<row><td>ISLocalControl</td><td>Attributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>A 32-bit word that specifies the attribute flags to be applied to this control.</td></row>
		<row><td>ISLocalControl</td><td>Binary_</td><td>Y</td><td/><td/><td>Binary</td><td>1</td><td>Identifier</td><td/><td>External key to the Binary table.</td></row>
		<row><td>ISLocalControl</td><td>Control_</td><td>N</td><td/><td/><td>Control</td><td>2</td><td>Identifier</td><td/><td>Name of the control. This name must be unique within a dialog, but can repeat on different dialogs.</td></row>
		<row><td>ISLocalControl</td><td>Dialog_</td><td>N</td><td/><td/><td>Dialog</td><td>1</td><td>Identifier</td><td/><td>External key to the Dialog table, name of the dialog.</td></row>
		<row><td>ISLocalControl</td><td>Height</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Height of the bounding rectangle of the control.</td></row>
		<row><td>ISLocalControl</td><td>ISBuildSourcePath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path to .rtf file for scrollable text control</td></row>
		<row><td>ISLocalControl</td><td>ISLanguage_</td><td>N</td><td/><td/><td>ISLanguage</td><td>1</td><td>Text</td><td/><td>This is a foreign key to the ISLanguage table.</td></row>
		<row><td>ISLocalControl</td><td>Width</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Width of the bounding rectangle of the control.</td></row>
		<row><td>ISLocalControl</td><td>X</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Horizontal coordinate of the upper left corner of the bounding rectangle of the control.</td></row>
		<row><td>ISLocalControl</td><td>Y</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Vertical coordinate of the upper left corner of the bounding rectangle of the control.</td></row>
		<row><td>ISLocalDialog</td><td>Attributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>A 32-bit word that specifies the attribute flags to be applied to this dialog.</td></row>
		<row><td>ISLocalDialog</td><td>Dialog_</td><td>Y</td><td/><td/><td>Dialog</td><td>1</td><td>Identifier</td><td/><td>Name of the dialog.</td></row>
		<row><td>ISLocalDialog</td><td>Height</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Height of the bounding rectangle of the dialog.</td></row>
		<row><td>ISLocalDialog</td><td>ISLanguage_</td><td>Y</td><td/><td/><td>ISLanguage</td><td>1</td><td>Text</td><td/><td>This is a foreign key to the ISLanguage table.</td></row>
		<row><td>ISLocalDialog</td><td>TextStyle_</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Foreign Key into TextStyle table, only used in Script Based Projects.</td></row>
		<row><td>ISLocalDialog</td><td>Width</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Width of the bounding rectangle of the dialog.</td></row>
		<row><td>ISLocalRadioButton</td><td>Height</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The height of the button.</td></row>
		<row><td>ISLocalRadioButton</td><td>ISLanguage_</td><td>N</td><td/><td/><td>ISLanguage</td><td>1</td><td>Text</td><td/><td>This is a foreign key to the ISLanguage table.</td></row>
		<row><td>ISLocalRadioButton</td><td>Order</td><td>N</td><td>1</td><td>32767</td><td>RadioButton</td><td>2</td><td/><td/><td>A positive integer used to determine the ordering of the items within one list..The integers do not have to be consecutive.</td></row>
		<row><td>ISLocalRadioButton</td><td>Property</td><td>N</td><td/><td/><td>RadioButton</td><td>1</td><td>Identifier</td><td/><td>A named property to be tied to this radio button. All the buttons tied to the same property become part of the same group.</td></row>
		<row><td>ISLocalRadioButton</td><td>Width</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The width of the button.</td></row>
		<row><td>ISLocalRadioButton</td><td>X</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The horizontal coordinate of the upper left corner of the bounding rectangle of the radio button.</td></row>
		<row><td>ISLocalRadioButton</td><td>Y</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The vertical coordinate of the upper left corner of the bounding rectangle of the radio button.</td></row>
		<row><td>ISLockPermissions</td><td>Attributes</td><td>Y</td><td>-2147483647</td><td>2147483647</td><td/><td/><td/><td/><td>Permissions attributes mask, 1==Deny access; 2==No inherit, 4==Ignore apply failures, 8==Target object is 64-bit</td></row>
		<row><td>ISLockPermissions</td><td>Domain</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Domain name for user whose permissions are being set.</td></row>
		<row><td>ISLockPermissions</td><td>LockObject</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Foreign key into CreateFolder, Registry, or File table</td></row>
		<row><td>ISLockPermissions</td><td>Permission</td><td>Y</td><td>-2147483647</td><td>2147483647</td><td/><td/><td/><td/><td>Permission Access mask.</td></row>
		<row><td>ISLockPermissions</td><td>Table</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td>CreateFolder;File;Registry</td><td>Reference to another table name</td></row>
		<row><td>ISLockPermissions</td><td>User</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>User for permissions to be set. This can be a property, hardcoded named, or SID string</td></row>
		<row><td>ISLogicalDisk</td><td>Cabinet</td><td>Y</td><td/><td/><td/><td/><td>Cabinet</td><td/><td>If some or all of the files stored on the media are compressed in a cabinet, the name of that cabinet.</td></row>
		<row><td>ISLogicalDisk</td><td>DiskId</td><td>N</td><td>1</td><td>32767</td><td/><td/><td/><td/><td>Primary key, integer to determine sort order for table.</td></row>
		<row><td>ISLogicalDisk</td><td>DiskPrompt</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Disk name: the visible text actually printed on the disk.  This will be used to prompt the user when this disk needs to be inserted.</td></row>
		<row><td>ISLogicalDisk</td><td>ISProductConfiguration_</td><td>N</td><td/><td/><td>ISProductConfiguration</td><td>1</td><td>Text</td><td/><td>Foreign key into the ISProductConfiguration table.</td></row>
		<row><td>ISLogicalDisk</td><td>ISRelease_</td><td>N</td><td/><td/><td>ISRelease</td><td>1</td><td>Text</td><td/><td>Foreign key into the ISRelease table.</td></row>
		<row><td>ISLogicalDisk</td><td>LastSequence</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>File sequence number for the last file for this media.</td></row>
		<row><td>ISLogicalDisk</td><td>Source</td><td>Y</td><td/><td/><td/><td/><td>Property</td><td/><td>The property defining the location of the cabinet file.</td></row>
		<row><td>ISLogicalDisk</td><td>VolumeLabel</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The label attributed to the volume.</td></row>
		<row><td>ISLogicalDiskFeatures</td><td>Feature_</td><td>Y</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>Required foreign key into the Feature Table,</td></row>
		<row><td>ISLogicalDiskFeatures</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>This is used to store Installshield custom properties, like Compressed, etc.</td></row>
		<row><td>ISLogicalDiskFeatures</td><td>ISLogicalDisk_</td><td>N</td><td>1</td><td>32767</td><td>ISLogicalDisk</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the ISLogicalDisk table.</td></row>
		<row><td>ISLogicalDiskFeatures</td><td>ISProductConfiguration_</td><td>N</td><td/><td/><td>ISProductConfiguration</td><td>1</td><td>Text</td><td/><td>Foreign key into the ISProductConfiguration table.</td></row>
		<row><td>ISLogicalDiskFeatures</td><td>ISRelease_</td><td>N</td><td/><td/><td>ISRelease</td><td>1</td><td>Text</td><td/><td>Foreign key into the ISRelease table.</td></row>
		<row><td>ISLogicalDiskFeatures</td><td>Sequence</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>File sequence number for the file for this media.</td></row>
		<row><td>ISMergeModule</td><td>Destination</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Destination.</td></row>
		<row><td>ISMergeModule</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>This is used to store Installshield custom properties of a merge module.</td></row>
		<row><td>ISMergeModule</td><td>ISMergeModule</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The GUID identifying the merge module.</td></row>
		<row><td>ISMergeModule</td><td>Language</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Default decimal language of module.</td></row>
		<row><td>ISMergeModule</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Name of the merge module.</td></row>
		<row><td>ISMergeModuleCfgValues</td><td>Attributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Attributes (from configurable merge module)</td></row>
		<row><td>ISMergeModuleCfgValues</td><td>ContextData</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>ContextData  (from configurable merge module)</td></row>
		<row><td>ISMergeModuleCfgValues</td><td>DefaultValue</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>DefaultValue  (from configurable merge module)</td></row>
		<row><td>ISMergeModuleCfgValues</td><td>Description</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Description (from configurable merge module)</td></row>
		<row><td>ISMergeModuleCfgValues</td><td>DisplayName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>DisplayName (from configurable merge module)</td></row>
		<row><td>ISMergeModuleCfgValues</td><td>Format</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Format (from configurable merge module)</td></row>
		<row><td>ISMergeModuleCfgValues</td><td>HelpKeyword</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>HelpKeyword (from configurable merge module)</td></row>
		<row><td>ISMergeModuleCfgValues</td><td>HelpLocation</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>HelpLocation (from configurable merge module)</td></row>
		<row><td>ISMergeModuleCfgValues</td><td>ISMergeModule_</td><td>N</td><td/><td/><td>ISMergeModule</td><td>1</td><td>Text</td><td/><td>The module signature, a foreign key into the ISMergeModule table</td></row>
		<row><td>ISMergeModuleCfgValues</td><td>Language_</td><td>N</td><td/><td/><td>ISMergeModule</td><td>2</td><td/><td/><td>Default decimal language of module.</td></row>
		<row><td>ISMergeModuleCfgValues</td><td>ModuleConfiguration_</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Identifier, foreign key into ModuleConfiguration table (ModuleConfiguration.Name)</td></row>
		<row><td>ISMergeModuleCfgValues</td><td>Type</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Type (from configurable merge module)</td></row>
		<row><td>ISMergeModuleCfgValues</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Value for this item.</td></row>
		<row><td>ISObject</td><td>Language</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td/></row>
		<row><td>ISObject</td><td>ObjectName</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td/></row>
		<row><td>ISObjectProperty</td><td>IncludeInBuild</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Boolean, 0 for false non 0 for true</td></row>
		<row><td>ISObjectProperty</td><td>ObjectName</td><td>Y</td><td/><td/><td>ISObject</td><td>1</td><td>Text</td><td/><td/></row>
		<row><td>ISObjectProperty</td><td>Property</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td/></row>
		<row><td>ISObjectProperty</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td/></row>
		<row><td>ISPatchConfigImage</td><td>PatchConfiguration_</td><td>Y</td><td/><td/><td>ISPatchConfiguration</td><td>1</td><td>Text</td><td/><td>Foreign key to the ISPatchConfigurationTable</td></row>
		<row><td>ISPatchConfigImage</td><td>UpgradedImage_</td><td>N</td><td/><td/><td>ISUpgradedImage</td><td>1</td><td>Text</td><td/><td>Foreign key to the ISUpgradedImageTable</td></row>
		<row><td>ISPatchConfiguration</td><td>Attributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>PatchConfiguration attributes</td></row>
		<row><td>ISPatchConfiguration</td><td>CanPCDiffer</td><td>N</td><td/><td/><td/><td/><td/><td/><td>This is determine whether Product Codes may differ</td></row>
		<row><td>ISPatchConfiguration</td><td>CanPVDiffer</td><td>N</td><td/><td/><td/><td/><td/><td/><td>This is determine whether the Major Product Version may differ</td></row>
		<row><td>ISPatchConfiguration</td><td>EnablePatchCache</td><td>N</td><td/><td/><td/><td/><td/><td/><td>This is determine whether to Enable Patch cacheing</td></row>
		<row><td>ISPatchConfiguration</td><td>Flags</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Patching API Flags</td></row>
		<row><td>ISPatchConfiguration</td><td>IncludeWholeFiles</td><td>N</td><td/><td/><td/><td/><td/><td/><td>This is determine whether to build a binary level patch</td></row>
		<row><td>ISPatchConfiguration</td><td>LeaveDecompressed</td><td>N</td><td/><td/><td/><td/><td/><td/><td>This is determine whether to leave intermediate files devcompressed when finished</td></row>
		<row><td>ISPatchConfiguration</td><td>MinMsiVersion</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Minimum Required MSI Version</td></row>
		<row><td>ISPatchConfiguration</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Name of the Patch Configuration</td></row>
		<row><td>ISPatchConfiguration</td><td>OptimizeForSize</td><td>N</td><td/><td/><td/><td/><td/><td/><td>This is determine whether to Optimize for large files</td></row>
		<row><td>ISPatchConfiguration</td><td>OutputPath</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Build Location</td></row>
		<row><td>ISPatchConfiguration</td><td>PatchCacheDir</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Directory to recieve the Patch Cache information</td></row>
		<row><td>ISPatchConfiguration</td><td>PatchGuid</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Unique Patch Identifier</td></row>
		<row><td>ISPatchConfiguration</td><td>PatchGuidsToReplace</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>List Of Patch Guids to unregister</td></row>
		<row><td>ISPatchConfiguration</td><td>TargetProductCodes</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>List Of target Product Codes</td></row>
		<row><td>ISPatchConfigurationProperty</td><td>ISPatchConfiguration_</td><td>Y</td><td/><td/><td>ISPatchConfiguration</td><td>1</td><td>Text</td><td/><td>Name of the Patch Configuration</td></row>
		<row><td>ISPatchConfigurationProperty</td><td>Property</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Name of the Patch Configuration Property value</td></row>
		<row><td>ISPatchConfigurationProperty</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Value of the Patch Configuration Property</td></row>
		<row><td>ISPatchExternalFile</td><td>FileKey</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Filekey</td></row>
		<row><td>ISPatchExternalFile</td><td>FilePath</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Filepath</td></row>
		<row><td>ISPatchExternalFile</td><td>ISUpgradedImage_</td><td>N</td><td/><td/><td>ISUpgradedImage</td><td>1</td><td>Text</td><td/><td>Foreign key to the isupgraded image table</td></row>
		<row><td>ISPatchExternalFile</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Uniqu name to identify this record.</td></row>
		<row><td>ISPatchWholeFile</td><td>Component</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Component containing file key</td></row>
		<row><td>ISPatchWholeFile</td><td>FileKey</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Key of file to be included as whole</td></row>
		<row><td>ISPatchWholeFile</td><td>UpgradedImage</td><td>N</td><td/><td/><td>ISUpgradedImage</td><td>1</td><td>Text</td><td/><td>Foreign key to ISUpgradedImage Table</td></row>
		<row><td>ISPathVariable</td><td>ISPathVariable</td><td>N</td><td/><td/><td/><td/><td/><td/><td>The name of the path variable.</td></row>
		<row><td>ISPathVariable</td><td>TestValue</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The test value of the path variable.</td></row>
		<row><td>ISPathVariable</td><td>Type</td><td>N</td><td/><td/><td/><td/><td/><td>1;2;4;8</td><td>The type of the path variable.</td></row>
		<row><td>ISPathVariable</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The value of the path variable.</td></row>
		<row><td>ISProductConfiguration</td><td>GeneratePackageCode</td><td>Y</td><td/><td/><td/><td/><td>Number</td><td>0;1</td><td>Indicates whether or not to generate a package code.</td></row>
		<row><td>ISProductConfiguration</td><td>ISProductConfiguration</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The name of the product configuration.</td></row>
		<row><td>ISProductConfiguration</td><td>ProductConfigurationFlags</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Product configuration (release) flags.</td></row>
		<row><td>ISProductConfigurationInstance</td><td>ISProductConfiguration_</td><td>N</td><td/><td/><td>ISProductConfiguration</td><td>1</td><td>Text</td><td/><td>Foreign key into the ISProductConfiguration table.</td></row>
		<row><td>ISProductConfigurationInstance</td><td>InstanceId</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Identifies the instance number of this instance. This value is stored in the Property InstanceId.</td></row>
		<row><td>ISProductConfigurationInstance</td><td>Property</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Product Congiuration property name</td></row>
		<row><td>ISProductConfigurationInstance</td><td>Value</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>String value for property.</td></row>
		<row><td>ISProductConfigurationProperty</td><td>ISProductConfiguration_</td><td>N</td><td/><td/><td>ISProductConfiguration</td><td>1</td><td>Text</td><td/><td>Foreign key into the ISProductConfiguration table.</td></row>
		<row><td>ISProductConfigurationProperty</td><td>Property</td><td>N</td><td/><td/><td>Property</td><td>1</td><td>Text</td><td/><td>Product Congiuration property name</td></row>
		<row><td>ISProductConfigurationProperty</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>String value for property. Never null or empty.</td></row>
		<row><td>ISRelease</td><td>Attributes</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Bitfield holding boolean values for various release attributes.</td></row>
		<row><td>ISRelease</td><td>BuildLocation</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Build location.</td></row>
		<row><td>ISRelease</td><td>CDBrowser</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Demoshield browser location.</td></row>
		<row><td>ISRelease</td><td>DefaultLanguage</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Default language for setup.</td></row>
		<row><td>ISRelease</td><td>DigitalPVK</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Digital signing private key (.pvk) file.</td></row>
		<row><td>ISRelease</td><td>DigitalSPC</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Digital signing Software Publisher Certificate (.spc) file.</td></row>
		<row><td>ISRelease</td><td>DigitalURL</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Digital signing URL.</td></row>
		<row><td>ISRelease</td><td>DiskClusterSize</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Disk cluster size.</td></row>
		<row><td>ISRelease</td><td>DiskSize</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Disk size.</td></row>
		<row><td>ISRelease</td><td>DiskSizeUnit</td><td>N</td><td/><td/><td/><td/><td/><td>0;1;2</td><td>Disk size units (KB or MB).</td></row>
		<row><td>ISRelease</td><td>DiskSpanning</td><td>N</td><td/><td/><td/><td/><td/><td>0;1;2</td><td>Disk spanning (automatic, enforce size, etc.).</td></row>
		<row><td>ISRelease</td><td>DotNetBuildConfiguration</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Build Configuration for .NET solutions.</td></row>
		<row><td>ISRelease</td><td>ISProductConfiguration_</td><td>N</td><td/><td/><td>ISProductConfiguration</td><td>1</td><td>Text</td><td/><td>Foreign key into the ISProductConfiguration table.</td></row>
		<row><td>ISRelease</td><td>ISRelease</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The name of the release.</td></row>
		<row><td>ISRelease</td><td>ISSetupPrerequisiteLocation</td><td>Y</td><td/><td/><td/><td/><td/><td>0;1;2;3</td><td>Location the Setup Prerequisites will be placed in</td></row>
		<row><td>ISRelease</td><td>MediaLocation</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Media location on disk.</td></row>
		<row><td>ISRelease</td><td>MsiCommandLine</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Command line passed to the msi package from setup.exe</td></row>
		<row><td>ISRelease</td><td>MsiSourceType</td><td>N</td><td>-1</td><td>4</td><td/><td/><td/><td/><td>MSI media source type.</td></row>
		<row><td>ISRelease</td><td>PackageName</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Package name.</td></row>
		<row><td>ISRelease</td><td>Password</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Password.</td></row>
		<row><td>ISRelease</td><td>Platforms</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Platforms supported (Intel, Alpha, etc.).</td></row>
		<row><td>ISRelease</td><td>ReleaseFlags</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Release flags.</td></row>
		<row><td>ISRelease</td><td>ReleaseType</td><td>N</td><td/><td/><td/><td/><td/><td>1;2;4</td><td>Release type (single, uncompressed, etc.).</td></row>
		<row><td>ISRelease</td><td>SupportedLanguagesData</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Languages supported (for component filtering).</td></row>
		<row><td>ISRelease</td><td>SupportedLanguagesUI</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>UI languages supported.</td></row>
		<row><td>ISRelease</td><td>SupportedOSs</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Indicate which operating systmes are supported.</td></row>
		<row><td>ISRelease</td><td>SynchMsi</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>MSI file to synchronize file keys and other data with (patch-like functionality).</td></row>
		<row><td>ISRelease</td><td>Type</td><td>N</td><td>0</td><td>6</td><td/><td/><td/><td/><td>Release type (CDROM, Network, etc.).</td></row>
		<row><td>ISRelease</td><td>URLLocation</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Media location via URL.</td></row>
		<row><td>ISRelease</td><td>VersionCopyright</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Version stamp information.</td></row>
		<row><td>ISReleaseASPublishInfo</td><td>ISProductConfiguration_</td><td>N</td><td/><td/><td>ISProductConfiguration</td><td>1</td><td>Text</td><td/><td>Foreign key into the ISProductConfiguration table.</td></row>
		<row><td>ISReleaseASPublishInfo</td><td>ISRelease_</td><td>N</td><td/><td/><td>ISRelease</td><td>1</td><td>Text</td><td/><td>Foreign key into the ISRelease table.</td></row>
		<row><td>ISReleaseASPublishInfo</td><td>Property</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>AS Repository property name</td></row>
		<row><td>ISReleaseASPublishInfo</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>AS Repository property value</td></row>
		<row><td>ISReleaseExtended</td><td>Attributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Bitfield holding boolean values for various release attributes.</td></row>
		<row><td>ISReleaseExtended</td><td>CertPassword</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Digital certificate password</td></row>
		<row><td>ISReleaseExtended</td><td>DigitalCertificateDBaseNS</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Path to cerificate database for Netscape digital  signature</td></row>
		<row><td>ISReleaseExtended</td><td>DigitalCertificateIdNS</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Path to cerificate ID for Netscape digital  signature</td></row>
		<row><td>ISReleaseExtended</td><td>DigitalCertificatePasswordNS</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Password for Netscape digital  signature</td></row>
		<row><td>ISReleaseExtended</td><td>DotNetBaseLanguage</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Base Languge of .NET Redist</td></row>
		<row><td>ISReleaseExtended</td><td>DotNetFxCmdLine</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Command Line to pass to DotNetFx.exe</td></row>
		<row><td>ISReleaseExtended</td><td>DotNetLangPackCmdLine</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Command Line to pass to LangPack.exe</td></row>
		<row><td>ISReleaseExtended</td><td>DotNetLangaugePacks</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>.NET Redist language packs to include</td></row>
		<row><td>ISReleaseExtended</td><td>DotNetRedistLocation</td><td>Y</td><td>0</td><td>3</td><td/><td/><td/><td/><td>Location of .NET framework Redist (Web, SetupExe, Source, None)</td></row>
		<row><td>ISReleaseExtended</td><td>DotNetRedistURL</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>URL to .NET framework Redist</td></row>
		<row><td>ISReleaseExtended</td><td>DotNetVersion</td><td>Y</td><td>0</td><td>2</td><td/><td/><td/><td/><td>Version of .NET framework Redist (1.0, 1.1)</td></row>
		<row><td>ISReleaseExtended</td><td>EngineLocation</td><td>Y</td><td>0</td><td>2</td><td/><td/><td/><td/><td>Location of msi engine (Web, SetupExe...)</td></row>
		<row><td>ISReleaseExtended</td><td>ISEngineLocation</td><td>Y</td><td>0</td><td>2</td><td/><td/><td/><td/><td>Location of ISScript  engine (Web, SetupExe...)</td></row>
		<row><td>ISReleaseExtended</td><td>ISEngineURL</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>URL to InstallShield scripting engine</td></row>
		<row><td>ISReleaseExtended</td><td>ISProductConfiguration_</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Foreign key into the ISProductConfiguration table.</td></row>
		<row><td>ISReleaseExtended</td><td>ISRelease_</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The name of the release.</td></row>
		<row><td>ISReleaseExtended</td><td>JSharpCmdLine</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Command Line to pass to vjredist.exe</td></row>
		<row><td>ISReleaseExtended</td><td>JSharpRedistLocation</td><td>Y</td><td>0</td><td>3</td><td/><td/><td/><td/><td>Location of J# framework Redist (Web, SetupExe, Source, None)</td></row>
		<row><td>ISReleaseExtended</td><td>MsiEngineVersion</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Bitfield holding selected MSI engine versions included in this release</td></row>
		<row><td>ISReleaseExtended</td><td>OneClickCabName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>File name of generated cabfile</td></row>
		<row><td>ISReleaseExtended</td><td>OneClickHtmlName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>File name of generated html page</td></row>
		<row><td>ISReleaseExtended</td><td>OneClickTargetBrowser</td><td>Y</td><td>0</td><td>2</td><td/><td/><td/><td/><td>Target browser (IE, Netscape, both...)</td></row>
		<row><td>ISReleaseExtended</td><td>WebCabSize</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>Size of the cabfile</td></row>
		<row><td>ISReleaseExtended</td><td>WebLocalCachePath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Directory to cache downloaded package</td></row>
		<row><td>ISReleaseExtended</td><td>WebType</td><td>Y</td><td>0</td><td>2</td><td/><td/><td/><td/><td>Type of web install (One Executable, Downloader...)</td></row>
		<row><td>ISReleaseExtended</td><td>WebURL</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>URL to .msi package</td></row>
		<row><td>ISReleaseExtended</td><td>Win9xMsiUrl</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>URL to Ansi MSI engine</td></row>
		<row><td>ISReleaseExtended</td><td>WinMsi30Url</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>URL to MSI 3.0 engine</td></row>
		<row><td>ISReleaseExtended</td><td>WinNTMsiUrl</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>URL to Unicode MSI engine</td></row>
		<row><td>ISReleaseProperty</td><td>ISProductConfiguration_</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Foreign key into ISProductConfiguration table.</td></row>
		<row><td>ISReleaseProperty</td><td>ISRelease_</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Foreign key into ISRelease table.</td></row>
		<row><td>ISReleaseProperty</td><td>Name</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Property name</td></row>
		<row><td>ISReleaseProperty</td><td>Value</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Property value</td></row>
		<row><td>ISReleasePublishInfo</td><td>Description</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Repository item description</td></row>
		<row><td>ISReleasePublishInfo</td><td>DisplayName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Repository item display name</td></row>
		<row><td>ISReleasePublishInfo</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Bitfield holding various attributes</td></row>
		<row><td>ISReleasePublishInfo</td><td>ISProductConfiguration_</td><td>N</td><td/><td/><td>ISProductConfiguration</td><td>1</td><td>Text</td><td/><td>Foreign key into the ISProductConfiguration table.</td></row>
		<row><td>ISReleasePublishInfo</td><td>ISRelease_</td><td>N</td><td/><td/><td>ISRelease</td><td>1</td><td>Text</td><td/><td>The name of the release.</td></row>
		<row><td>ISReleasePublishInfo</td><td>Publisher</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Repository item publisher</td></row>
		<row><td>ISReleasePublishInfo</td><td>Repository</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Repository which to  publish the built merge module</td></row>
		<row><td>ISSQLConnection</td><td>Attributes</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLConnection</td><td>Authentication</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLConnection</td><td>BatchSeparator</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLConnection</td><td>CmdTimeout</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLConnection</td><td>Comments</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLConnection</td><td>Database</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLConnection</td><td>ISSQLConnection</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key used to identify a particular ISSQLConnection record.</td></row>
		<row><td>ISSQLConnection</td><td>Order</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLConnection</td><td>Password</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLConnection</td><td>ScriptVersion_Column</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLConnection</td><td>ScriptVersion_Table</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLConnection</td><td>Server</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLConnection</td><td>UserName</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLConnectionDBServer</td><td>ISSQLConnectionDBServer</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key used to identify a particular ISSQLConnectionDBServer record.</td></row>
		<row><td>ISSQLConnectionDBServer</td><td>ISSQLConnection_</td><td>N</td><td/><td/><td>ISSQLConnection</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISSQLConnection table.</td></row>
		<row><td>ISSQLConnectionDBServer</td><td>ISSQLDBMetaData_</td><td>N</td><td/><td/><td>ISSQLDBMetaData</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISSQLDBMetaData table.</td></row>
		<row><td>ISSQLConnectionDBServer</td><td>Order</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLConnectionScript</td><td>ISSQLConnection_</td><td>N</td><td/><td/><td>ISSQLConnection</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISSQLConnection table.</td></row>
		<row><td>ISSQLConnectionScript</td><td>ISSQLScriptFile_</td><td>N</td><td/><td/><td>ISSQLScriptFile</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISSQLScriptFile table.</td></row>
		<row><td>ISSQLConnectionScript</td><td>Order</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>AdoCxnAdditional</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>AdoCxnDatabase</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>AdoCxnDriver</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>AdoCxnNetLibrary</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>AdoCxnPassword</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>AdoCxnPort</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>AdoCxnServer</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>AdoCxnUserID</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>AdoCxnWindowsSecurity</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>AdoDriverName</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>CreateDbCmd</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>CreateTableCmd</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>DisplayName</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>DsnODBCName</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>ISSQLDBMetaData</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key used to identify a particular ISSQLDBMetaData record.</td></row>
		<row><td>ISSQLDBMetaData</td><td>InsertRecordCmd</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>LocalInstanceNames</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>QueryDatabasesCmd</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>ScriptVersion_Column</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>ScriptVersion_ColumnType</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>ScriptVersion_Table</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>SelectTableCmd</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>SwitchDbCmd</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>TestDatabaseCmd</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>TestTableCmd</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>TestTableCmd2</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>VersionBeginToken</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>VersionEndToken</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>VersionInfoCmd</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLDBMetaData</td><td>WinAuthentUserId</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLRequirement</td><td>Attributes</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLRequirement</td><td>ISSQLConnectionDBServer_</td><td>Y</td><td/><td/><td>ISSQLConnectionDBServer</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISSQLConnectionDBServer table.</td></row>
		<row><td>ISSQLRequirement</td><td>ISSQLConnection_</td><td>N</td><td/><td/><td>ISSQLConnection</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISSQLConnection table.</td></row>
		<row><td>ISSQLRequirement</td><td>ISSQLRequirement</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key used to identify a particular ISSQLRequirement record.</td></row>
		<row><td>ISSQLRequirement</td><td>MajorVersion</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLRequirement</td><td>ServicePackLevel</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptError</td><td>Attributes</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptError</td><td>ErrHandling</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptError</td><td>ErrNumber</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptError</td><td>ISSQLScriptFile_</td><td>Y</td><td/><td/><td>ISSQLScriptFile</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISSQLScriptFile table</td></row>
		<row><td>ISSQLScriptError</td><td>Message</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Custom end-user message. Reserved for future use.</td></row>
		<row><td>ISSQLScriptFile</td><td>Attributes</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptFile</td><td>Comments</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Comments</td></row>
		<row><td>ISSQLScriptFile</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key referencing Component that controls the SQL script.</td></row>
		<row><td>ISSQLScriptFile</td><td>Condition</td><td>Y</td><td/><td/><td/><td/><td>Condition</td><td/><td>A conditional statement that will disable this script if the specified condition evaluates to the 'False' state. If a script is disabled, it will not be installed regardless of the 'Action' state associated with the component.</td></row>
		<row><td>ISSQLScriptFile</td><td>DisplayName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Display name for the SQL script file.</td></row>
		<row><td>ISSQLScriptFile</td><td>ErrorHandling</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptFile</td><td>ISBuildSourcePath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path, the category is of Text instead of Path because of potential use of path variables.</td></row>
		<row><td>ISSQLScriptFile</td><td>ISSQLScriptFile</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>This is the primary key to the ISSQLScriptFile table</td></row>
		<row><td>ISSQLScriptFile</td><td>InstallText</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Feedback end-user text at install</td></row>
		<row><td>ISSQLScriptFile</td><td>Scheduling</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptFile</td><td>UninstallText</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Feedback end-user text at Uninstall</td></row>
		<row><td>ISSQLScriptFile</td><td>Version</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Schema Version (#####.#####.#####.#####)</td></row>
		<row><td>ISSQLScriptImport</td><td>Attributes</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptImport</td><td>Authentication</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptImport</td><td>Database</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptImport</td><td>ExcludeTables</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptImport</td><td>ISSQLScriptFile_</td><td>N</td><td/><td/><td>ISSQLScriptFile</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISSQLScriptFile table.</td></row>
		<row><td>ISSQLScriptImport</td><td>IncludeTables</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptImport</td><td>Password</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptImport</td><td>Server</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptImport</td><td>UserName</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptReplace</td><td>Attributes</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptReplace</td><td>ISSQLScriptFile_</td><td>N</td><td/><td/><td>ISSQLScriptFile</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISSQLScriptFile table.</td></row>
		<row><td>ISSQLScriptReplace</td><td>ISSQLScriptReplace</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key used to identify a particular ISSQLScriptReplace record.</td></row>
		<row><td>ISSQLScriptReplace</td><td>Replace</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSQLScriptReplace</td><td>Search</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISScriptFile</td><td>ISScriptFile</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>This is the full path of the script file. The path portion may be expressed in path variable form.</td></row>
		<row><td>ISSelfReg</td><td>CmdLine</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSelfReg</td><td>Cost</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSelfReg</td><td>FileKey</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Foreign key to the file table</td></row>
		<row><td>ISSelfReg</td><td>Order</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSetupFile</td><td>FileName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>This is the file name to use when streaming the file to the support files location</td></row>
		<row><td>ISSetupFile</td><td>ISSetupFile</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>This is the primary key to the ISSetupFile table</td></row>
		<row><td>ISSetupFile</td><td>Language</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Four digit language identifier.  0 for Language Neutral</td></row>
		<row><td>ISSetupFile</td><td>Path</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Link to the source file on the build machine</td></row>
		<row><td>ISSetupFile</td><td>Splash</td><td>Y</td><td/><td/><td/><td/><td>Short</td><td/><td>Boolean value indication whether his setup file entry belongs in the Splasc Screen section</td></row>
		<row><td>ISSetupFile</td><td>Stream</td><td>Y</td><td/><td/><td/><td/><td>Binary</td><td/><td>Binary stream. The bits to stream to the support location</td></row>
		<row><td>ISSetupPrerequisites</td><td>ISBuildSourcePath</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSetupPrerequisites</td><td>ISReleaseFlags</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Release Flags that specify whether this prereq  will be included in a particular release.</td></row>
		<row><td>ISSetupPrerequisites</td><td>ISSetupLocation</td><td>Y</td><td/><td/><td/><td/><td/><td>0;1;2</td><td/></row>
		<row><td>ISSetupPrerequisites</td><td>ISSetupPrerequisites</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSetupPrerequisites</td><td>Order</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISSetupType</td><td>Comments</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>User Comments.</td></row>
		<row><td>ISSetupType</td><td>Description</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Longer descriptive text describing a visible feature item.</td></row>
		<row><td>ISSetupType</td><td>Display</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Numeric sort order, used to force a specific display ordering.</td></row>
		<row><td>ISSetupType</td><td>Display_Name</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>A string used to set the initial text contained within a control (if appropriate).</td></row>
		<row><td>ISSetupType</td><td>ISSetupType</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key used to identify a particular feature record.</td></row>
		<row><td>ISSetupTypeFeatures</td><td>Feature_</td><td>N</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>Foreign key into Feature table.</td></row>
		<row><td>ISSetupTypeFeatures</td><td>ISSetupType_</td><td>N</td><td/><td/><td>ISSetupType</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISSetupType table.</td></row>
		<row><td>ISStorages</td><td>ISBuildSourcePath</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Path to the file to stream into sub-storage</td></row>
		<row><td>ISStorages</td><td>Name</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Name of the sub-storage key</td></row>
		<row><td>ISString</td><td>Comment</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Comment</td></row>
		<row><td>ISString</td><td>Encoded</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Encoding for multi-byte strings.</td></row>
		<row><td>ISString</td><td>ISLanguage_</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>This is a foreign key to the ISLanguage table.</td></row>
		<row><td>ISString</td><td>ISString</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>String id.</td></row>
		<row><td>ISString</td><td>TimeStamp</td><td>Y</td><td/><td/><td/><td/><td>Time/Date</td><td/><td>Time Stamp. MSI's Time/Date column type is just an int, with bits packed in a certain order.</td></row>
		<row><td>ISString</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>real string value.</td></row>
		<row><td>ISSwidtagProperty</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Property name</td></row>
		<row><td>ISSwidtagProperty</td><td>Value</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Property value</td></row>
		<row><td>ISTargetImage</td><td>Flags</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>relative order of the target image</td></row>
		<row><td>ISTargetImage</td><td>IgnoreMissingFiles</td><td>N</td><td/><td/><td/><td/><td/><td/><td>If true, ignore missing source files when creating patch</td></row>
		<row><td>ISTargetImage</td><td>MsiPath</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Path to the target image</td></row>
		<row><td>ISTargetImage</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of the TargetImage</td></row>
		<row><td>ISTargetImage</td><td>Order</td><td>N</td><td/><td/><td/><td/><td/><td/><td>relative order of the target image</td></row>
		<row><td>ISTargetImage</td><td>UpgradedImage_</td><td>N</td><td/><td/><td>ISUpgradedImage</td><td>1</td><td>Text</td><td/><td>foreign key to the upgraded Image table</td></row>
		<row><td>ISUpgradeMsiItem</td><td>ISAttributes</td><td>N</td><td/><td/><td/><td/><td/><td>0;1</td><td/></row>
		<row><td>ISUpgradeMsiItem</td><td>ISReleaseFlags</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>ISUpgradeMsiItem</td><td>ObjectSetupPath</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The path to the setup you want to upgrade.</td></row>
		<row><td>ISUpgradeMsiItem</td><td>UpgradeItem</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The name of the Upgrade Item.</td></row>
		<row><td>ISUpgradedImage</td><td>Family</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Name of the image family</td></row>
		<row><td>ISUpgradedImage</td><td>MsiPath</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Path to the upgraded image</td></row>
		<row><td>ISUpgradedImage</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of the UpgradedImage</td></row>
		<row><td>ISVirtualDirectory</td><td>Directory_</td><td>N</td><td/><td/><td>Directory</td><td>1</td><td>Identifier</td><td/><td>Foreign key into Directory table.</td></row>
		<row><td>ISVirtualDirectory</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Property name</td></row>
		<row><td>ISVirtualDirectory</td><td>Value</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Property value</td></row>
		<row><td>ISVirtualFile</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Foreign key into File  table.</td></row>
		<row><td>ISVirtualFile</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Property name</td></row>
		<row><td>ISVirtualFile</td><td>Value</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Property value</td></row>
		<row><td>ISVirtualPackage</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Property name</td></row>
		<row><td>ISVirtualPackage</td><td>Value</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Property value</td></row>
		<row><td>ISVirtualRegistry</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Property name</td></row>
		<row><td>ISVirtualRegistry</td><td>Registry_</td><td>N</td><td/><td/><td>Registry</td><td>1</td><td>Identifier</td><td/><td>Foreign key into Registry table.</td></row>
		<row><td>ISVirtualRegistry</td><td>Value</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Property value</td></row>
		<row><td>ISVirtualRelease</td><td>ISProductConfiguration_</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Foreign key into ISProductConfiguration table.</td></row>
		<row><td>ISVirtualRelease</td><td>ISRelease_</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Foreign key into ISRelease table.</td></row>
		<row><td>ISVirtualRelease</td><td>Name</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Property name</td></row>
		<row><td>ISVirtualRelease</td><td>Value</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Property value</td></row>
		<row><td>ISVirtualShortcut</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Property name</td></row>
		<row><td>ISVirtualShortcut</td><td>Shortcut_</td><td>N</td><td/><td/><td>Shortcut</td><td>1</td><td>Identifier</td><td/><td>Foreign key into Shortcut table.</td></row>
		<row><td>ISVirtualShortcut</td><td>Value</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Property value</td></row>
		<row><td>ISWSEWrap</td><td>Action_</td><td>N</td><td/><td/><td>CustomAction</td><td>1</td><td>Identifier</td><td/><td>Foreign key into CustomAction table</td></row>
		<row><td>ISWSEWrap</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Property associated with this Action</td></row>
		<row><td>ISWSEWrap</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Value associated with this Property</td></row>
		<row><td>ISXmlElement</td><td>Content</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Element contents</td></row>
		<row><td>ISXmlElement</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td>Number</td><td/><td>Internal XML element attributes</td></row>
		<row><td>ISXmlElement</td><td>ISXmlElement</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized, internal token for Xml element</td></row>
		<row><td>ISXmlElement</td><td>ISXmlElement_Parent</td><td>Y</td><td/><td/><td>ISXmlElement</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISXMLElement table.</td></row>
		<row><td>ISXmlElement</td><td>ISXmlFile_</td><td>N</td><td/><td/><td>ISXmlFile</td><td>1</td><td>Identifier</td><td/><td>Foreign key into XmlFile table.</td></row>
		<row><td>ISXmlElement</td><td>XPath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>XPath fragment including any operators</td></row>
		<row><td>ISXmlElementAttrib</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td>Number</td><td/><td>Internal XML elementattib attributes</td></row>
		<row><td>ISXmlElementAttrib</td><td>ISXmlElementAttrib</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized, internal token for Xml element attribute</td></row>
		<row><td>ISXmlElementAttrib</td><td>ISXmlElement_</td><td>N</td><td/><td/><td>ISXmlElement</td><td>1</td><td>Identifier</td><td/><td>Foreign key into ISXMLElement table.</td></row>
		<row><td>ISXmlElementAttrib</td><td>Name</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Localized attribute name</td></row>
		<row><td>ISXmlElementAttrib</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Localized attribute value</td></row>
		<row><td>ISXmlFile</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into Component table.</td></row>
		<row><td>ISXmlFile</td><td>Directory</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Foreign key into Directory table.</td></row>
		<row><td>ISXmlFile</td><td>Encoding</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>XML File Encoding</td></row>
		<row><td>ISXmlFile</td><td>FileName</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Localized XML file name</td></row>
		<row><td>ISXmlFile</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td>Number</td><td/><td>Internal XML file attributes</td></row>
		<row><td>ISXmlFile</td><td>ISXmlFile</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized,internal token for Xml file</td></row>
		<row><td>ISXmlFile</td><td>SelectionNamespaces</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Selection namespaces</td></row>
		<row><td>ISXmlLocator</td><td>Attribute</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>The name of an attribute within the XML element.</td></row>
		<row><td>ISXmlLocator</td><td>Element</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>XPath query that will locate an element in an XML file.</td></row>
		<row><td>ISXmlLocator</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td>0;1;2</td><td/></row>
		<row><td>ISXmlLocator</td><td>Parent</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>The parent file signature. It is also a foreign key in the Signature table.</td></row>
		<row><td>ISXmlLocator</td><td>Signature_</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>The Signature_ represents a unique file signature and is also the foreign key in the Signature,  RegLocator, IniLocator, ISXmlLocator, CompLocator and the DrLocator tables.</td></row>
		<row><td>Icon</td><td>Data</td><td>Y</td><td/><td/><td/><td/><td>Binary</td><td/><td>Binary stream. The binary icon data in PE (.DLL or .EXE) or icon (.ICO) format.</td></row>
		<row><td>Icon</td><td>ISBuildSourcePath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path to the ICO or EXE file.</td></row>
		<row><td>Icon</td><td>ISIconIndex</td><td>Y</td><td>-32767</td><td>32767</td><td/><td/><td/><td/><td>Optional icon index to be extracted.</td></row>
		<row><td>Icon</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key. Name of the icon file.</td></row>
		<row><td>IniFile</td><td>Action</td><td>N</td><td/><td/><td/><td/><td/><td>0;1;3</td><td>The type of modification to be made, one of iifEnum</td></row>
		<row><td>IniFile</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the Component table referencing component that controls the installing of the .INI value.</td></row>
		<row><td>IniFile</td><td>DirProperty</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Foreign key into the Directory table denoting the directory where the .INI file is.</td></row>
		<row><td>IniFile</td><td>FileName</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The .INI file name in which to write the information</td></row>
		<row><td>IniFile</td><td>IniFile</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized token.</td></row>
		<row><td>IniFile</td><td>Key</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The .INI file key below Section.</td></row>
		<row><td>IniFile</td><td>Section</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The .INI file Section.</td></row>
		<row><td>IniFile</td><td>Value</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The value to be written.</td></row>
		<row><td>IniLocator</td><td>Field</td><td>Y</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The field in the .INI line. If Field is null or 0 the entire line is read.</td></row>
		<row><td>IniLocator</td><td>FileName</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The .INI file name.</td></row>
		<row><td>IniLocator</td><td>Key</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Key value (followed by an equals sign in INI file).</td></row>
		<row><td>IniLocator</td><td>Section</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Section name within in file (within square brackets in INI file).</td></row>
		<row><td>IniLocator</td><td>Signature_</td><td>N</td><td/><td/><td>Signature</td><td>1</td><td>Identifier</td><td/><td>The table key. The Signature_ represents a unique file signature and is also the foreign key in the Signature table.</td></row>
		<row><td>IniLocator</td><td>Type</td><td>Y</td><td>0</td><td>2</td><td/><td/><td/><td/><td>An integer value that determines if the .INI value read is a filename or a directory location or to be used as is w/o interpretation.</td></row>
		<row><td>InstallExecuteSequence</td><td>Action</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of action to invoke, either in the engine or the handler DLL.</td></row>
		<row><td>InstallExecuteSequence</td><td>Condition</td><td>Y</td><td/><td/><td/><td/><td>Condition</td><td/><td>Optional expression which skips the action if evaluates to expFalse.If the expression syntax is invalid, the engine will terminate, returning iesBadActionData.</td></row>
		<row><td>InstallExecuteSequence</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>This is used to store MM Custom Action Types</td></row>
		<row><td>InstallExecuteSequence</td><td>ISComments</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Author’s comments on this Sequence.</td></row>
		<row><td>InstallExecuteSequence</td><td>Sequence</td><td>Y</td><td>-4</td><td>32767</td><td/><td/><td/><td/><td>Number that determines the sort order in which the actions are to be executed.  Leave blank to suppress action.</td></row>
		<row><td>InstallShield</td><td>Property</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of property, uppercase if settable by launcher or loader.</td></row>
		<row><td>InstallShield</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>String value for property.</td></row>
		<row><td>InstallUISequence</td><td>Action</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of action to invoke, either in the engine or the handler DLL.</td></row>
		<row><td>InstallUISequence</td><td>Condition</td><td>Y</td><td/><td/><td/><td/><td>Condition</td><td/><td>Optional expression which skips the action if evaluates to expFalse.If the expression syntax is invalid, the engine will terminate, returning iesBadActionData.</td></row>
		<row><td>InstallUISequence</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>This is used to store MM Custom Action Types</td></row>
		<row><td>InstallUISequence</td><td>ISComments</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Author’s comments on this Sequence.</td></row>
		<row><td>InstallUISequence</td><td>Sequence</td><td>Y</td><td>-4</td><td>32767</td><td/><td/><td/><td/><td>Number that determines the sort order in which the actions are to be executed.  Leave blank to suppress action.</td></row>
		<row><td>IsolatedComponent</td><td>Component_Application</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Key to Component table item for application</td></row>
		<row><td>IsolatedComponent</td><td>Component_Shared</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Key to Component table item to be isolated</td></row>
		<row><td>LaunchCondition</td><td>Condition</td><td>N</td><td/><td/><td/><td/><td>Condition</td><td/><td>Expression which must evaluate to TRUE in order for install to commence.</td></row>
		<row><td>LaunchCondition</td><td>Description</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Localizable text to display when condition fails and install must abort.</td></row>
		<row><td>ListBox</td><td>Order</td><td>N</td><td>1</td><td>32767</td><td/><td/><td/><td/><td>A positive integer used to determine the ordering of the items within one list..The integers do not have to be consecutive.</td></row>
		<row><td>ListBox</td><td>Property</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>A named property to be tied to this item. All the items tied to the same property become part of the same listbox.</td></row>
		<row><td>ListBox</td><td>Text</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The visible text to be assigned to the item. Optional. If this entry or the entire column is missing, the text is the same as the value.</td></row>
		<row><td>ListBox</td><td>Value</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The value string associated with this item. Selecting the line will set the associated property to this value.</td></row>
		<row><td>ListView</td><td>Binary_</td><td>Y</td><td/><td/><td>Binary</td><td>1</td><td>Identifier</td><td/><td>The name of the icon to be displayed with the icon. The binary information is looked up from the Binary Table.</td></row>
		<row><td>ListView</td><td>Order</td><td>N</td><td>1</td><td>32767</td><td/><td/><td/><td/><td>A positive integer used to determine the ordering of the items within one list..The integers do not have to be consecutive.</td></row>
		<row><td>ListView</td><td>Property</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>A named property to be tied to this item. All the items tied to the same property become part of the same listview.</td></row>
		<row><td>ListView</td><td>Text</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The visible text to be assigned to the item. Optional. If this entry or the entire column is missing, the text is the same as the value.</td></row>
		<row><td>ListView</td><td>Value</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The value string associated with this item. Selecting the line will set the associated property to this value.</td></row>
		<row><td>LockPermissions</td><td>Domain</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Domain name for user whose permissions are being set. (usually a property)</td></row>
		<row><td>LockPermissions</td><td>LockObject</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Foreign key into Registry or File table</td></row>
		<row><td>LockPermissions</td><td>Permission</td><td>Y</td><td>-2147483647</td><td>2147483647</td><td/><td/><td/><td/><td>Permission Access mask.  Full Control = 268435456 (GENERIC_ALL = 0x10000000)</td></row>
		<row><td>LockPermissions</td><td>Table</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td>Directory;File;Registry</td><td>Reference to another table name</td></row>
		<row><td>LockPermissions</td><td>User</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>User for permissions to be set.  (usually a property)</td></row>
		<row><td>MIME</td><td>CLSID</td><td>Y</td><td/><td/><td>Class</td><td>1</td><td>Guid</td><td/><td>Optional associated CLSID.</td></row>
		<row><td>MIME</td><td>ContentType</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Primary key. Context identifier, typically "type/format".</td></row>
		<row><td>MIME</td><td>Extension_</td><td>N</td><td/><td/><td>Extension</td><td>1</td><td>Text</td><td/><td>Optional associated extension (without dot)</td></row>
		<row><td>Media</td><td>Cabinet</td><td>Y</td><td/><td/><td/><td/><td>Cabinet</td><td/><td>If some or all of the files stored on the media are compressed in a cabinet, the name of that cabinet.</td></row>
		<row><td>Media</td><td>DiskId</td><td>N</td><td>1</td><td>32767</td><td/><td/><td/><td/><td>Primary key, integer to determine sort order for table.</td></row>
		<row><td>Media</td><td>DiskPrompt</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Disk name: the visible text actually printed on the disk.  This will be used to prompt the user when this disk needs to be inserted.</td></row>
		<row><td>Media</td><td>LastSequence</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>File sequence number for the last file for this media.</td></row>
		<row><td>Media</td><td>Source</td><td>Y</td><td/><td/><td/><td/><td>Property</td><td/><td>The property defining the location of the cabinet file.</td></row>
		<row><td>Media</td><td>VolumeLabel</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The label attributed to the volume.</td></row>
		<row><td>MoveFile</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>If this component is not "selected" for installation or removal, no action will be taken on the associated MoveFile entry</td></row>
		<row><td>MoveFile</td><td>DestFolder</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of a property whose value is assumed to resolve to the full path to the destination directory</td></row>
		<row><td>MoveFile</td><td>DestName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Name to be given to the original file after it is moved or copied.  If blank, the destination file will be given the same name as the source file</td></row>
		<row><td>MoveFile</td><td>FileKey</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key that uniquely identifies a particular MoveFile record</td></row>
		<row><td>MoveFile</td><td>Options</td><td>N</td><td>0</td><td>1</td><td/><td/><td/><td/><td>Integer value specifying the MoveFile operating mode, one of imfoEnum</td></row>
		<row><td>MoveFile</td><td>SourceFolder</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of a property whose value is assumed to resolve to the full path to the source directory</td></row>
		<row><td>MoveFile</td><td>SourceName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Name of the source file(s) to be moved or copied.  Can contain the '*' or '?' wildcards.</td></row>
		<row><td>MsiAssembly</td><td>Attributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Assembly attributes</td></row>
		<row><td>MsiAssembly</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into Component table.</td></row>
		<row><td>MsiAssembly</td><td>Feature_</td><td>N</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>Foreign key into Feature table.</td></row>
		<row><td>MsiAssembly</td><td>File_Application</td><td>Y</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Foreign key into File table, denoting the application context for private assemblies. Null for global assemblies.</td></row>
		<row><td>MsiAssembly</td><td>File_Manifest</td><td>Y</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the File table denoting the manifest file for the assembly.</td></row>
		<row><td>MsiAssemblyName</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into Component table.</td></row>
		<row><td>MsiAssemblyName</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The name part of the name-value pairs for the assembly name.</td></row>
		<row><td>MsiAssemblyName</td><td>Value</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The value part of the name-value pairs for the assembly name.</td></row>
		<row><td>MsiDigitalCertificate</td><td>CertData</td><td>N</td><td/><td/><td/><td/><td>Binary</td><td/><td>A certificate context blob for a signer certificate</td></row>
		<row><td>MsiDigitalCertificate</td><td>DigitalCertificate</td><td>N</td><td/><td/><td>MsiPackageCertificate</td><td>2</td><td>Identifier</td><td/><td>A unique identifier for the row</td></row>
		<row><td>MsiDigitalSignature</td><td>DigitalCertificate_</td><td>N</td><td/><td/><td>MsiDigitalCertificate</td><td>1</td><td>Identifier</td><td/><td>Foreign key to MsiDigitalCertificate table identifying the signer certificate</td></row>
		<row><td>MsiDigitalSignature</td><td>Hash</td><td>Y</td><td/><td/><td/><td/><td>Binary</td><td/><td>The encoded hash blob from the digital signature</td></row>
		<row><td>MsiDigitalSignature</td><td>SignObject</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Foreign key to Media table</td></row>
		<row><td>MsiDigitalSignature</td><td>Table</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Reference to another table name (only Media table is supported)</td></row>
		<row><td>MsiDriverPackages</td><td>Component</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Primary key used to identify a particular component record.</td></row>
		<row><td>MsiDriverPackages</td><td>Flags</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Driver package flags</td></row>
		<row><td>MsiDriverPackages</td><td>ReferenceComponents</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>MsiDriverPackages</td><td>Sequence</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>Installation sequence number</td></row>
		<row><td>MsiEmbeddedChainer</td><td>CommandLine</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td/></row>
		<row><td>MsiEmbeddedChainer</td><td>Condition</td><td>Y</td><td/><td/><td/><td/><td>Condition</td><td/><td/></row>
		<row><td>MsiEmbeddedChainer</td><td>MsiEmbeddedChainer</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td/></row>
		<row><td>MsiEmbeddedChainer</td><td>Source</td><td>N</td><td/><td/><td/><td/><td>CustomSource</td><td/><td/></row>
		<row><td>MsiEmbeddedChainer</td><td>Type</td><td>Y</td><td/><td/><td/><td/><td>Integer</td><td>2;18;50</td><td/></row>
		<row><td>MsiEmbeddedUI</td><td>Attributes</td><td>N</td><td>0</td><td>3</td><td/><td/><td>Integer</td><td/><td>Information about the data in the Data column.</td></row>
		<row><td>MsiEmbeddedUI</td><td>Data</td><td>Y</td><td/><td/><td/><td/><td>Binary</td><td/><td>This column contains binary information.</td></row>
		<row><td>MsiEmbeddedUI</td><td>FileName</td><td>N</td><td/><td/><td/><td/><td>Filename</td><td/><td>The name of the file that receives the binary information in the Data column.</td></row>
		<row><td>MsiEmbeddedUI</td><td>ISBuildSourcePath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td/></row>
		<row><td>MsiEmbeddedUI</td><td>MessageFilter</td><td>Y</td><td>0</td><td>234913791</td><td/><td/><td>Integer</td><td/><td>Specifies the types of messages that are sent to the user interface DLL. This column is only relevant for rows with the msidbEmbeddedUI attribute.</td></row>
		<row><td>MsiEmbeddedUI</td><td>MsiEmbeddedUI</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>The primary key for the table.</td></row>
		<row><td>MsiFileHash</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Primary key, foreign key into File table referencing file with this hash</td></row>
		<row><td>MsiFileHash</td><td>HashPart1</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Size of file in bytes (long integer).</td></row>
		<row><td>MsiFileHash</td><td>HashPart2</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Size of file in bytes (long integer).</td></row>
		<row><td>MsiFileHash</td><td>HashPart3</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Size of file in bytes (long integer).</td></row>
		<row><td>MsiFileHash</td><td>HashPart4</td><td>N</td><td/><td/><td/><td/><td/><td/><td>Size of file in bytes (long integer).</td></row>
		<row><td>MsiFileHash</td><td>Options</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Various options and attributes for this hash.</td></row>
		<row><td>MsiLockPermissionsEx</td><td>Condition</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>Expression which must evaluate to TRUE in order for this set of permissions to be applied</td></row>
		<row><td>MsiLockPermissionsEx</td><td>LockObject</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Foreign key into Registry, File, CreateFolder, or ServiceInstall table</td></row>
		<row><td>MsiLockPermissionsEx</td><td>MsiLockPermissionsEx</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized token</td></row>
		<row><td>MsiLockPermissionsEx</td><td>SDDLText</td><td>N</td><td/><td/><td/><td/><td>FormattedSDDLText</td><td/><td>String to indicate permissions to be applied to the LockObject</td></row>
		<row><td>MsiLockPermissionsEx</td><td>Table</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td>CreateFolder;File;Registry;ServiceInstall</td><td>Reference to another table name</td></row>
		<row><td>MsiPackageCertificate</td><td>DigitalCertificate_</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>A foreign key to the digital certificate table</td></row>
		<row><td>MsiPackageCertificate</td><td>PackageCertificate</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>A unique identifier for the row</td></row>
		<row><td>MsiPatchCertificate</td><td>DigitalCertificate_</td><td>N</td><td/><td/><td>MsiDigitalCertificate</td><td>1</td><td>Identifier</td><td/><td>A foreign key to the digital certificate table</td></row>
		<row><td>MsiPatchCertificate</td><td>PatchCertificate</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>A unique identifier for the row</td></row>
		<row><td>MsiPatchMetadata</td><td>Company</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Optional company name</td></row>
		<row><td>MsiPatchMetadata</td><td>PatchConfiguration_</td><td>N</td><td/><td/><td>ISPatchConfiguration</td><td>1</td><td>Text</td><td/><td>Foreign key to the ISPatchConfiguration table</td></row>
		<row><td>MsiPatchMetadata</td><td>Property</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Name of the metadata</td></row>
		<row><td>MsiPatchMetadata</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Value of the metadata</td></row>
		<row><td>MsiPatchOldAssemblyFile</td><td>Assembly_</td><td>Y</td><td/><td/><td>MsiPatchOldAssemblyName</td><td>1</td><td/><td/><td/></row>
		<row><td>MsiPatchOldAssemblyFile</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td/><td/><td/></row>
		<row><td>MsiPatchOldAssemblyName</td><td>Assembly</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>MsiPatchOldAssemblyName</td><td>Name</td><td>N</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>MsiPatchOldAssemblyName</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td/><td/><td/></row>
		<row><td>MsiPatchSequence</td><td>PatchConfiguration_</td><td>N</td><td/><td/><td>ISPatchConfiguration</td><td>1</td><td>Text</td><td/><td>Foreign key to the patch configuration table</td></row>
		<row><td>MsiPatchSequence</td><td>PatchFamily</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Name of the family to which this patch belongs</td></row>
		<row><td>MsiPatchSequence</td><td>Sequence</td><td>N</td><td/><td/><td/><td/><td>Version</td><td/><td>The version of this patch in this family</td></row>
		<row><td>MsiPatchSequence</td><td>Supersede</td><td>N</td><td/><td/><td/><td/><td>Integer</td><td/><td>Supersede</td></row>
		<row><td>MsiPatchSequence</td><td>Target</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Target product codes for this patch family</td></row>
		<row><td>MsiServiceConfig</td><td>Argument</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Argument(s) for service configuration. Value depends on the content of the ConfigType field</td></row>
		<row><td>MsiServiceConfig</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Required foreign key into the Component Table that controls the configuration of the service</td></row>
		<row><td>MsiServiceConfig</td><td>ConfigType</td><td>N</td><td>-2147483647</td><td>2147483647</td><td/><td/><td/><td/><td>Service Configuration Option</td></row>
		<row><td>MsiServiceConfig</td><td>Event</td><td>N</td><td>0</td><td>7</td><td/><td/><td/><td/><td>Bit field:   0x1 = Install, 0x2 = Uninstall, 0x4 = Reinstall</td></row>
		<row><td>MsiServiceConfig</td><td>MsiServiceConfig</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized token.</td></row>
		<row><td>MsiServiceConfig</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>Name of a service. /, \, comma and space are invalid</td></row>
		<row><td>MsiServiceConfigFailureActions</td><td>Actions</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>A list of integer actions separated by [~] delimiters: 0 = SC_ACTION_NONE, 1 = SC_ACTION_RESTART, 2 = SC_ACTION_REBOOT, 3 = SC_ACTION_RUN_COMMAND. Terminate with [~][~]</td></row>
		<row><td>MsiServiceConfigFailureActions</td><td>Command</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>Command line of the process to CreateProcess function to execute</td></row>
		<row><td>MsiServiceConfigFailureActions</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Required foreign key into the Component Table that controls the configuration of the service</td></row>
		<row><td>MsiServiceConfigFailureActions</td><td>DelayActions</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>A list of delays (time in milli-seconds), separated by [~] delmiters, to wait before taking the corresponding Action. Terminate with [~][~]</td></row>
		<row><td>MsiServiceConfigFailureActions</td><td>Event</td><td>N</td><td>0</td><td>7</td><td/><td/><td/><td/><td>Bit field:   0x1 = Install, 0x2 = Uninstall, 0x4 = Reinstall</td></row>
		<row><td>MsiServiceConfigFailureActions</td><td>MsiServiceConfigFailureActions</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized token</td></row>
		<row><td>MsiServiceConfigFailureActions</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>Name of a service. /, \, comma and space are invalid</td></row>
		<row><td>MsiServiceConfigFailureActions</td><td>RebootMessage</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>Message to be broadcast to server users before rebooting</td></row>
		<row><td>MsiServiceConfigFailureActions</td><td>ResetPeriod</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>Time in seconds after which to reset the failure count to zero. Leave blank if it should never be reset</td></row>
		<row><td>MsiShortcutProperty</td><td>MsiShortcutProperty</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized token</td></row>
		<row><td>MsiShortcutProperty</td><td>PropVariantValue</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>String representation of the value in the property</td></row>
		<row><td>MsiShortcutProperty</td><td>PropertyKey</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>Canonical string representation of the Property Key being set</td></row>
		<row><td>MsiShortcutProperty</td><td>Shortcut_</td><td>N</td><td/><td/><td>Shortcut</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the Shortcut table</td></row>
		<row><td>ODBCAttribute</td><td>Attribute</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Name of ODBC driver attribute</td></row>
		<row><td>ODBCAttribute</td><td>Driver_</td><td>N</td><td/><td/><td>ODBCDriver</td><td>1</td><td>Identifier</td><td/><td>Reference to ODBC driver in ODBCDriver table</td></row>
		<row><td>ODBCAttribute</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Value for ODBC driver attribute</td></row>
		<row><td>ODBCDataSource</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Reference to associated component</td></row>
		<row><td>ODBCDataSource</td><td>DataSource</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized.internal token for data source</td></row>
		<row><td>ODBCDataSource</td><td>Description</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Text used as registered name for data source</td></row>
		<row><td>ODBCDataSource</td><td>DriverDescription</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Reference to driver description, may be existing driver</td></row>
		<row><td>ODBCDataSource</td><td>Registration</td><td>N</td><td>0</td><td>1</td><td/><td/><td/><td/><td>Registration option: 0=machine, 1=user, others t.b.d.</td></row>
		<row><td>ODBCDriver</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Reference to associated component</td></row>
		<row><td>ODBCDriver</td><td>Description</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Text used as registered name for driver, non-localized</td></row>
		<row><td>ODBCDriver</td><td>Driver</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized.internal token for driver</td></row>
		<row><td>ODBCDriver</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Reference to key driver file</td></row>
		<row><td>ODBCDriver</td><td>File_Setup</td><td>Y</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Optional reference to key driver setup DLL</td></row>
		<row><td>ODBCSourceAttribute</td><td>Attribute</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Name of ODBC data source attribute</td></row>
		<row><td>ODBCSourceAttribute</td><td>DataSource_</td><td>N</td><td/><td/><td>ODBCDataSource</td><td>1</td><td>Identifier</td><td/><td>Reference to ODBC data source in ODBCDataSource table</td></row>
		<row><td>ODBCSourceAttribute</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Value for ODBC data source attribute</td></row>
		<row><td>ODBCTranslator</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Reference to associated component</td></row>
		<row><td>ODBCTranslator</td><td>Description</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>Text used as registered name for translator</td></row>
		<row><td>ODBCTranslator</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Reference to key translator file</td></row>
		<row><td>ODBCTranslator</td><td>File_Setup</td><td>Y</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Optional reference to key translator setup DLL</td></row>
		<row><td>ODBCTranslator</td><td>Translator</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized.internal token for translator</td></row>
		<row><td>Patch</td><td>Attributes</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Integer containing bit flags representing patch attributes</td></row>
		<row><td>Patch</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Primary key, non-localized token, foreign key to File table, must match identifier in cabinet.</td></row>
		<row><td>Patch</td><td>Header</td><td>Y</td><td/><td/><td/><td/><td>Binary</td><td/><td>Binary stream. The patch header, used for patch validation.</td></row>
		<row><td>Patch</td><td>ISBuildSourcePath</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Full path to patch header.</td></row>
		<row><td>Patch</td><td>PatchSize</td><td>N</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>Size of patch in bytes (long integer).</td></row>
		<row><td>Patch</td><td>Sequence</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Primary key, sequence with respect to the media images; order must track cabinet order.</td></row>
		<row><td>Patch</td><td>StreamRef_</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>External key into the MsiPatchHeaders table specifying the row that contains the patch header stream.</td></row>
		<row><td>PatchPackage</td><td>Media_</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Foreign key to DiskId column of Media table. Indicates the disk containing the patch package.</td></row>
		<row><td>PatchPackage</td><td>PatchId</td><td>N</td><td/><td/><td/><td/><td>Guid</td><td/><td>A unique string GUID representing this patch.</td></row>
		<row><td>ProgId</td><td>Class_</td><td>Y</td><td/><td/><td>Class</td><td>1</td><td>Guid</td><td/><td>The CLSID of an OLE factory corresponding to the ProgId.</td></row>
		<row><td>ProgId</td><td>Description</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Localized description for the Program identifier.</td></row>
		<row><td>ProgId</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>This is used to store Installshield custom properties of a component, like ExtractIcon, etc.</td></row>
		<row><td>ProgId</td><td>IconIndex</td><td>Y</td><td>-32767</td><td>32767</td><td/><td/><td/><td/><td>Optional icon index.</td></row>
		<row><td>ProgId</td><td>Icon_</td><td>Y</td><td/><td/><td>Icon</td><td>1</td><td>Identifier</td><td/><td>Optional foreign key into the Icon Table, specifying the icon file associated with this ProgId. Will be written under the DefaultIcon key.</td></row>
		<row><td>ProgId</td><td>ProgId</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The Program Identifier. Primary key.</td></row>
		<row><td>ProgId</td><td>ProgId_Parent</td><td>Y</td><td/><td/><td>ProgId</td><td>1</td><td>Text</td><td/><td>The Parent Program Identifier. If specified, the ProgId column becomes a version independent prog id.</td></row>
		<row><td>Property</td><td>ISComments</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>User Comments.</td></row>
		<row><td>Property</td><td>Property</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of property, uppercase if settable by launcher or loader.</td></row>
		<row><td>Property</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>String value for property.</td></row>
		<row><td>PublishComponent</td><td>AppData</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>This is localisable Application specific data that can be associated with a Qualified Component.</td></row>
		<row><td>PublishComponent</td><td>ComponentId</td><td>N</td><td/><td/><td/><td/><td>Guid</td><td/><td>A string GUID that represents the component id that will be requested by the alien product.</td></row>
		<row><td>PublishComponent</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the Component table.</td></row>
		<row><td>PublishComponent</td><td>Feature_</td><td>N</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the Feature table.</td></row>
		<row><td>PublishComponent</td><td>Qualifier</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>This is defined only when the ComponentId column is an Qualified Component Id. This is the Qualifier for ProvideComponentIndirect.</td></row>
		<row><td>RadioButton</td><td>Height</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The height of the button.</td></row>
		<row><td>RadioButton</td><td>Help</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The help strings used with the button. The text is optional.</td></row>
		<row><td>RadioButton</td><td>ISControlId</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>A number used to represent the control ID of the Control, Used in Dialog export</td></row>
		<row><td>RadioButton</td><td>Order</td><td>N</td><td>1</td><td>32767</td><td/><td/><td/><td/><td>A positive integer used to determine the ordering of the items within one list..The integers do not have to be consecutive.</td></row>
		<row><td>RadioButton</td><td>Property</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>A named property to be tied to this radio button. All the buttons tied to the same property become part of the same group.</td></row>
		<row><td>RadioButton</td><td>Text</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The visible title to be assigned to the radio button.</td></row>
		<row><td>RadioButton</td><td>Value</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The value string associated with this button. Selecting the button will set the associated property to this value.</td></row>
		<row><td>RadioButton</td><td>Width</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The width of the button.</td></row>
		<row><td>RadioButton</td><td>X</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The horizontal coordinate of the upper left corner of the bounding rectangle of the radio button.</td></row>
		<row><td>RadioButton</td><td>Y</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The vertical coordinate of the upper left corner of the bounding rectangle of the radio button.</td></row>
		<row><td>RegLocator</td><td>Key</td><td>N</td><td/><td/><td/><td/><td>RegPath</td><td/><td>The key for the registry value.</td></row>
		<row><td>RegLocator</td><td>Name</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The registry value name.</td></row>
		<row><td>RegLocator</td><td>Root</td><td>N</td><td>0</td><td>3</td><td/><td/><td/><td/><td>The predefined root key for the registry value, one of rrkEnum.</td></row>
		<row><td>RegLocator</td><td>Signature_</td><td>N</td><td/><td/><td>Signature</td><td>1</td><td>Identifier</td><td/><td>The table key. The Signature_ represents a unique file signature and is also the foreign key in the Signature table. If the type is 0, the registry values refers a directory, and _Signature is not a foreign key.</td></row>
		<row><td>RegLocator</td><td>Type</td><td>Y</td><td>0</td><td>18</td><td/><td/><td/><td/><td>An integer value that determines if the registry value is a filename or a directory location or to be used as is w/o interpretation.</td></row>
		<row><td>Registry</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the Component table referencing component that controls the installing of the registry value.</td></row>
		<row><td>Registry</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>This is used to store Installshield custom properties of a registry item.  Currently the only one is Automatic.</td></row>
		<row><td>Registry</td><td>Key</td><td>N</td><td/><td/><td/><td/><td>RegPath</td><td/><td>The key for the registry value.</td></row>
		<row><td>Registry</td><td>Name</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The registry value name.</td></row>
		<row><td>Registry</td><td>Registry</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized token.</td></row>
		<row><td>Registry</td><td>Root</td><td>N</td><td>-1</td><td>3</td><td/><td/><td/><td/><td>The predefined root key for the registry value, one of rrkEnum.</td></row>
		<row><td>Registry</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The registry value.</td></row>
		<row><td>RemoveFile</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key referencing Component that controls the file to be removed.</td></row>
		<row><td>RemoveFile</td><td>DirProperty</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of a property whose value is assumed to resolve to the full pathname to the folder of the file to be removed.</td></row>
		<row><td>RemoveFile</td><td>FileKey</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key used to identify a particular file entry</td></row>
		<row><td>RemoveFile</td><td>FileName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Name of the file to be removed.</td></row>
		<row><td>RemoveFile</td><td>InstallMode</td><td>N</td><td/><td/><td/><td/><td/><td>1;2;3</td><td>Installation option, one of iimEnum.</td></row>
		<row><td>RemoveIniFile</td><td>Action</td><td>N</td><td/><td/><td/><td/><td/><td>2;4</td><td>The type of modification to be made, one of iifEnum.</td></row>
		<row><td>RemoveIniFile</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the Component table referencing component that controls the deletion of the .INI value.</td></row>
		<row><td>RemoveIniFile</td><td>DirProperty</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Foreign key into the Directory table denoting the directory where the .INI file is.</td></row>
		<row><td>RemoveIniFile</td><td>FileName</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The .INI file name in which to delete the information</td></row>
		<row><td>RemoveIniFile</td><td>Key</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The .INI file key below Section.</td></row>
		<row><td>RemoveIniFile</td><td>RemoveIniFile</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized token.</td></row>
		<row><td>RemoveIniFile</td><td>Section</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The .INI file Section.</td></row>
		<row><td>RemoveIniFile</td><td>Value</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The value to be deleted. The value is required when Action is iifIniRemoveTag</td></row>
		<row><td>RemoveRegistry</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the Component table referencing component that controls the deletion of the registry value.</td></row>
		<row><td>RemoveRegistry</td><td>Key</td><td>N</td><td/><td/><td/><td/><td>RegPath</td><td/><td>The key for the registry value.</td></row>
		<row><td>RemoveRegistry</td><td>Name</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The registry value name.</td></row>
		<row><td>RemoveRegistry</td><td>RemoveRegistry</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized token.</td></row>
		<row><td>RemoveRegistry</td><td>Root</td><td>N</td><td>-1</td><td>3</td><td/><td/><td/><td/><td>The predefined root key for the registry value, one of rrkEnum</td></row>
		<row><td>ReserveCost</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Reserve a specified amount of space if this component is to be installed.</td></row>
		<row><td>ReserveCost</td><td>ReserveFolder</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of a property whose value is assumed to resolve to the full path to the destination directory</td></row>
		<row><td>ReserveCost</td><td>ReserveKey</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key that uniquely identifies a particular ReserveCost record</td></row>
		<row><td>ReserveCost</td><td>ReserveLocal</td><td>N</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>Disk space to reserve if linked component is installed locally.</td></row>
		<row><td>ReserveCost</td><td>ReserveSource</td><td>N</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>Disk space to reserve if linked component is installed to run from the source location.</td></row>
		<row><td>SFPCatalog</td><td>Catalog</td><td>Y</td><td/><td/><td/><td/><td>Binary</td><td/><td>SFP Catalog</td></row>
		<row><td>SFPCatalog</td><td>Dependency</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>Parent catalog - only used by SFP</td></row>
		<row><td>SFPCatalog</td><td>SFPCatalog</td><td>N</td><td/><td/><td/><td/><td>Filename</td><td/><td>File name for the catalog.</td></row>
		<row><td>SelfReg</td><td>Cost</td><td>Y</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The cost of registering the module.</td></row>
		<row><td>SelfReg</td><td>File_</td><td>N</td><td/><td/><td>File</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the File table denoting the module that needs to be registered.</td></row>
		<row><td>ServiceControl</td><td>Arguments</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>Arguments for the service.  Separate by [~].</td></row>
		<row><td>ServiceControl</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Required foreign key into the Component Table that controls the startup of the service</td></row>
		<row><td>ServiceControl</td><td>Event</td><td>N</td><td>0</td><td>187</td><td/><td/><td/><td/><td>Bit field:  Install:  0x1 = Start, 0x2 = Stop, 0x8 = Delete, Uninstall: 0x10 = Start, 0x20 = Stop, 0x80 = Delete</td></row>
		<row><td>ServiceControl</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>Name of a service. /, \, comma and space are invalid</td></row>
		<row><td>ServiceControl</td><td>ServiceControl</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized token.</td></row>
		<row><td>ServiceControl</td><td>Wait</td><td>Y</td><td>0</td><td>1</td><td/><td/><td/><td/><td>Boolean for whether to wait for the service to fully start</td></row>
		<row><td>ServiceInstall</td><td>Arguments</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>Arguments to include in every start of the service, passed to WinMain</td></row>
		<row><td>ServiceInstall</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Required foreign key into the Component Table that controls the startup of the service</td></row>
		<row><td>ServiceInstall</td><td>Dependencies</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>Other services this depends on to start.  Separate by [~], and end with [~][~]</td></row>
		<row><td>ServiceInstall</td><td>Description</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Description of service.</td></row>
		<row><td>ServiceInstall</td><td>DisplayName</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>External Name of the Service</td></row>
		<row><td>ServiceInstall</td><td>ErrorControl</td><td>N</td><td>-2147483647</td><td>2147483647</td><td/><td/><td/><td/><td>Severity of error if service fails to start</td></row>
		<row><td>ServiceInstall</td><td>LoadOrderGroup</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>LoadOrderGroup</td></row>
		<row><td>ServiceInstall</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Formatted</td><td/><td>Internal Name of the Service</td></row>
		<row><td>ServiceInstall</td><td>Password</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>password to run service with.  (with StartName)</td></row>
		<row><td>ServiceInstall</td><td>ServiceInstall</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized token.</td></row>
		<row><td>ServiceInstall</td><td>ServiceType</td><td>N</td><td>-2147483647</td><td>2147483647</td><td/><td/><td/><td/><td>Type of the service</td></row>
		<row><td>ServiceInstall</td><td>StartName</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>User or object name to run service as</td></row>
		<row><td>ServiceInstall</td><td>StartType</td><td>N</td><td>0</td><td>4</td><td/><td/><td/><td/><td>Type of the service</td></row>
		<row><td>Shortcut</td><td>Arguments</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The command-line arguments for the shortcut.</td></row>
		<row><td>Shortcut</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the Component table denoting the component whose selection gates the the shortcut creation/deletion.</td></row>
		<row><td>Shortcut</td><td>Description</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The description for the shortcut.</td></row>
		<row><td>Shortcut</td><td>DescriptionResourceDLL</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>This field contains a Formatted string value for the full path to the language neutral file that contains the MUI manifest.</td></row>
		<row><td>Shortcut</td><td>DescriptionResourceId</td><td>Y</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The description name index for the shortcut.</td></row>
		<row><td>Shortcut</td><td>Directory_</td><td>N</td><td/><td/><td>Directory</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the Directory table denoting the directory where the shortcut file is created.</td></row>
		<row><td>Shortcut</td><td>DisplayResourceDLL</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>This field contains a Formatted string value for the full path to the language neutral file that contains the MUI manifest.</td></row>
		<row><td>Shortcut</td><td>DisplayResourceId</td><td>Y</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The display name index for the shortcut.</td></row>
		<row><td>Shortcut</td><td>Hotkey</td><td>Y</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The hotkey for the shortcut. It has the virtual-key code for the key in the low-order byte, and the modifier flags in the high-order byte.</td></row>
		<row><td>Shortcut</td><td>ISAttributes</td><td>Y</td><td/><td/><td/><td/><td/><td/><td>This is used to store Installshield custom properties of a shortcut.  Mainly used in pro project types.</td></row>
		<row><td>Shortcut</td><td>ISComments</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Author’s comments on this Shortcut.</td></row>
		<row><td>Shortcut</td><td>ISShortcutName</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>A non-unique name for the shortcut.  Mainly used by pro pro project types.</td></row>
		<row><td>Shortcut</td><td>IconIndex</td><td>Y</td><td>-32767</td><td>32767</td><td/><td/><td/><td/><td>The icon index for the shortcut.</td></row>
		<row><td>Shortcut</td><td>Icon_</td><td>Y</td><td/><td/><td>Icon</td><td>1</td><td>Identifier</td><td/><td>Foreign key into the File table denoting the external icon file for the shortcut.</td></row>
		<row><td>Shortcut</td><td>Name</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The name of the shortcut to be created.</td></row>
		<row><td>Shortcut</td><td>Shortcut</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Primary key, non-localized token.</td></row>
		<row><td>Shortcut</td><td>ShowCmd</td><td>Y</td><td/><td/><td/><td/><td/><td>1;3;7</td><td>The show command for the application window.The following values may be used.</td></row>
		<row><td>Shortcut</td><td>Target</td><td>N</td><td/><td/><td/><td/><td>Shortcut</td><td/><td>The shortcut target. This is usually a property that is expanded to a file or a folder that the shortcut points to.</td></row>
		<row><td>Shortcut</td><td>WkDir</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of property defining location of working directory.</td></row>
		<row><td>Signature</td><td>FileName</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The name of the file. This may contain a "short name|long name" pair.</td></row>
		<row><td>Signature</td><td>Languages</td><td>Y</td><td/><td/><td/><td/><td>Language</td><td/><td>The languages supported by the file.</td></row>
		<row><td>Signature</td><td>MaxDate</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>The maximum creation date of the file.</td></row>
		<row><td>Signature</td><td>MaxSize</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>The maximum size of the file.</td></row>
		<row><td>Signature</td><td>MaxVersion</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The maximum version of the file.</td></row>
		<row><td>Signature</td><td>MinDate</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>The minimum creation date of the file.</td></row>
		<row><td>Signature</td><td>MinSize</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>The minimum size of the file.</td></row>
		<row><td>Signature</td><td>MinVersion</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The minimum version of the file.</td></row>
		<row><td>Signature</td><td>Signature</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>The table key. The Signature represents a unique file signature.</td></row>
		<row><td>TextStyle</td><td>Color</td><td>Y</td><td>0</td><td>16777215</td><td/><td/><td/><td/><td>A long integer indicating the color of the string in the RGB format (Red, Green, Blue each 0-255, RGB = R + 256*G + 256^2*B).</td></row>
		<row><td>TextStyle</td><td>FaceName</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>A string indicating the name of the font used. Required. The string must be at most 31 characters long.</td></row>
		<row><td>TextStyle</td><td>Size</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The size of the font used. This size is given in our units (1/12 of the system font height). Assuming that the system font is set to 12 point size, this is equivalent to the point size.</td></row>
		<row><td>TextStyle</td><td>StyleBits</td><td>Y</td><td>0</td><td>15</td><td/><td/><td/><td/><td>A combination of style bits.</td></row>
		<row><td>TextStyle</td><td>TextStyle</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of the style. The primary key of this table. This name is embedded in the texts to indicate a style change.</td></row>
		<row><td>TypeLib</td><td>Component_</td><td>N</td><td/><td/><td>Component</td><td>1</td><td>Identifier</td><td/><td>Required foreign key into the Component Table, specifying the component for which to return a path when called through LocateComponent.</td></row>
		<row><td>TypeLib</td><td>Cost</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>The cost associated with the registration of the typelib. This column is currently optional.</td></row>
		<row><td>TypeLib</td><td>Description</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td/></row>
		<row><td>TypeLib</td><td>Directory_</td><td>Y</td><td/><td/><td>Directory</td><td>1</td><td>Identifier</td><td/><td>Optional. The foreign key into the Directory table denoting the path to the help file for the type library.</td></row>
		<row><td>TypeLib</td><td>Feature_</td><td>N</td><td/><td/><td>Feature</td><td>1</td><td>Identifier</td><td/><td>Required foreign key into the Feature Table, specifying the feature to validate or install in order for the type library to be operational.</td></row>
		<row><td>TypeLib</td><td>Language</td><td>N</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>The language of the library.</td></row>
		<row><td>TypeLib</td><td>LibID</td><td>N</td><td/><td/><td/><td/><td>Guid</td><td/><td>The GUID that represents the library.</td></row>
		<row><td>TypeLib</td><td>Version</td><td>Y</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>The version of the library. The major version is in the upper 8 bits of the short integer. The minor version is in the lower 8 bits.</td></row>
		<row><td>UIText</td><td>Key</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>A unique key that identifies the particular string.</td></row>
		<row><td>UIText</td><td>Text</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The localized version of the string.</td></row>
		<row><td>Upgrade</td><td>ActionProperty</td><td>N</td><td/><td/><td/><td/><td>UpperCase</td><td/><td>The property to set when a product in this set is found.</td></row>
		<row><td>Upgrade</td><td>Attributes</td><td>N</td><td>0</td><td>2147483647</td><td/><td/><td/><td/><td>The attributes of this product set.</td></row>
		<row><td>Upgrade</td><td>ISDisplayName</td><td>Y</td><td/><td/><td>ISUpgradeMsiItem</td><td>1</td><td/><td/><td/></row>
		<row><td>Upgrade</td><td>Language</td><td>Y</td><td/><td/><td/><td/><td>Language</td><td/><td>A comma-separated list of languages for either products in this set or products not in this set.</td></row>
		<row><td>Upgrade</td><td>Remove</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The list of features to remove when uninstalling a product from this set.  The default is "ALL".</td></row>
		<row><td>Upgrade</td><td>UpgradeCode</td><td>N</td><td/><td/><td/><td/><td>Guid</td><td/><td>The UpgradeCode GUID belonging to the products in this set.</td></row>
		<row><td>Upgrade</td><td>VersionMax</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The maximum ProductVersion of the products in this set.  The set may or may not include products with this particular version.</td></row>
		<row><td>Upgrade</td><td>VersionMin</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>The minimum ProductVersion of the products in this set.  The set may or may not include products with this particular version.</td></row>
		<row><td>Verb</td><td>Argument</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>Optional value for the command arguments.</td></row>
		<row><td>Verb</td><td>Command</td><td>Y</td><td/><td/><td/><td/><td>Formatted</td><td/><td>The command text.</td></row>
		<row><td>Verb</td><td>Extension_</td><td>N</td><td/><td/><td>Extension</td><td>1</td><td>Text</td><td/><td>The extension associated with the table row.</td></row>
		<row><td>Verb</td><td>Sequence</td><td>Y</td><td>0</td><td>32767</td><td/><td/><td/><td/><td>Order within the verbs for a particular extension. Also used simply to specify the default verb.</td></row>
		<row><td>Verb</td><td>Verb</td><td>N</td><td/><td/><td/><td/><td>Text</td><td/><td>The verb for the command.</td></row>
		<row><td>_Validation</td><td>Category</td><td>Y</td><td/><td/><td/><td/><td/><td>"Text";"Formatted";"Template";"Condition";"Guid";"Path";"Version";"Language";"Identifier";"Binary";"UpperCase";"LowerCase";"Filename";"Paths";"AnyPath";"WildCardFilename";"RegPath";"KeyFormatted";"CustomSource";"Property";"Cabinet";"Shortcut";"URL";"DefaultDir"</td><td>String category</td></row>
		<row><td>_Validation</td><td>Column</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of column</td></row>
		<row><td>_Validation</td><td>Description</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Description of column</td></row>
		<row><td>_Validation</td><td>KeyColumn</td><td>Y</td><td>1</td><td>32</td><td/><td/><td/><td/><td>Column to which foreign key connects</td></row>
		<row><td>_Validation</td><td>KeyTable</td><td>Y</td><td/><td/><td/><td/><td>Identifier</td><td/><td>For foreign key, Name of table to which data must link</td></row>
		<row><td>_Validation</td><td>MaxValue</td><td>Y</td><td>-2147483647</td><td>2147483647</td><td/><td/><td/><td/><td>Maximum value allowed</td></row>
		<row><td>_Validation</td><td>MinValue</td><td>Y</td><td>-2147483647</td><td>2147483647</td><td/><td/><td/><td/><td>Minimum value allowed</td></row>
		<row><td>_Validation</td><td>Nullable</td><td>N</td><td/><td/><td/><td/><td/><td>Y;N;@</td><td>Whether the column is nullable</td></row>
		<row><td>_Validation</td><td>Set</td><td>Y</td><td/><td/><td/><td/><td>Text</td><td/><td>Set of values that are permitted</td></row>
		<row><td>_Validation</td><td>Table</td><td>N</td><td/><td/><td/><td/><td>Identifier</td><td/><td>Name of table</td></row>
	</table>
</msi>
