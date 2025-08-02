/*
 * Created by SharpDevelop.
 * User: IEUser
 * Date: 10/11/2014
 * Time: 3:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace JunianDev.SDEmu.Models
{
	/// <summary>
	/// Description of SDEmuSetting.
	/// </summary>
	[Serializable]
	public class SDEmuSetting
	{
		private bool isStringMode;
		
		/// <summary>
		/// Is data to send ended with CR
		/// </summary>
		public bool IsEndedWithCR {get; set;}
		
		/// <summary>
		/// Is data to send ended with LF
		/// </summary>
		public bool IsEndedWithLF {get; set;}
		
		/// <summary>
		/// is current mode is string
		/// </summary>
		public bool IsStringMode
		{
			get
			{
				return isStringMode;
			}
			set
			{
				isStringMode = value;				
			}
		}
		
		/// <summary>
		/// is current mode is Hexadecimal
		/// </summary>
		public bool IsHexMode
		{
			get
			{
				return !isStringMode;
			}
			set
			{
				isStringMode = !value;
			}
		}
		
		/// <summary>
		/// Serial port setting
		/// </summary>
		public SerialSetting SerialSetting {get; set;}
		
		/// <summary>
		/// Constructor for SDEmuSetting
		/// </summary>
		public SDEmuSetting()
		{
			this.SerialSetting = new SerialSetting();
			this.IsEndedWithCR = this.IsEndedWithLF = false;
			this.IsHexMode = true;
		}
	}
}
