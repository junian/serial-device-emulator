/*
 * Created by SharpDevelop.
 * User: IEUser
 * Date: 10/11/2014
 * Time: 3:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Net.Junian.SDEmu.Models
{
	/// <summary>
	/// Description of SDEmuSetting.
	/// </summary>
	[Serializable]
	public class SDEmuSetting
	{
		public SerialSetting SerialSetting {get;set;}
		
		public SDEmuSetting()
		{
			this.SerialSetting = new SerialSetting();
		}
	}
}
