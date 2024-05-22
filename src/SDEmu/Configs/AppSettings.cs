/*
 * Created by SharpDevelop.
 * User: IEUser
 * Date: 10/11/2014
 * Time: 4:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

using Juniansoft.SDEmu.Models;
using Juniansoft.SDEmu.Utilities;

namespace Juniansoft.SDEmu.Configs
{
	/// <summary>
	/// Description of AppSettings.
	/// </summary>
	public class AppSettings
	{
		public SDEmuSetting SDEmuSetting {get;set;}
		public string LocalAppSettingsPath {get;set;}
		public string CurrentAppSettingsPath {get; private set;}
		
		private static AppSettings instance;
		
		public static AppSettings Instance
		{
			get
			{
				if(instance == null)
					instance = new AppSettings();
				return instance;
			}
		}
		
		private AppSettings()
		{
			this.SDEmuSetting = new SDEmuSetting();
			
			this.LocalAppSettingsPath = 
				string.Format("{0}\\{1}\\{2}",
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
				Application.CompanyName,
				Application.ProductName);
			
			this.CurrentAppSettingsPath = 
				string.Format("{0}\\{1}.sdemu",
	              this.LocalAppSettingsPath,
	              HashEngine.MD5Hash("current-sdemu-setting"));
			
			if(!Directory.Exists(LocalAppSettingsPath))
			{
				Directory.CreateDirectory(LocalAppSettingsPath);
			}
		}
		
		public void LoadCurrentAppSettings()
		{
			this.SDEmuSetting = LoadAppSettings(this.CurrentAppSettingsPath);
		}
		
		public SDEmuSetting LoadAppSettings(string path)
		{
			SDEmuSetting sdEmuSetting = null;
			FileStream fileStream = null;
			
			try
			{
				var serializer = new BinaryFormatter();
				fileStream = new FileStream(path, FileMode.Open);
				sdEmuSetting = (SDEmuSetting) serializer.Deserialize(fileStream);
			}
			catch(Exception ex)
			{
				Debug.WriteLine(string.Format("{0}\\{1}", ex.Message, ex.StackTrace));
				sdEmuSetting = new SDEmuSetting();
			}
			finally
			{
				if(fileStream != null)
					fileStream.Close();
			}
			return sdEmuSetting;
		}
		
		public void SaveCurrentAppSettings()
		{
			this.SaveAppSettings(this.CurrentAppSettingsPath, this.SDEmuSetting);
		}
		
		public void SaveAppSettings(string path, SDEmuSetting setting)
		{
			FileStream fileStream = null;
			
			try
			{
				var serializer = new BinaryFormatter();
				fileStream = new FileStream(path, FileMode.Create);
				serializer.Serialize(fileStream, setting);
			}
			catch(Exception ex)
			{
				Debug.WriteLine(string.Format("{0}\\{1}", ex.Message, ex.StackTrace));
			}
			finally
			{
				if(fileStream != null)
					fileStream.Close();
			}
		}
	}
}
