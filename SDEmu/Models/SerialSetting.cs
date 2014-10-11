/*
 * Created by SharpDevelop.
 * User: IEUser
 * Date: 10/11/2014
 * Time: 3:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO.Ports;

namespace Net.Junian.SDEmu.Models
{
	/// <summary>
	/// Description of SerialSetting.
	/// </summary>
	[Serializable]
	public class SerialSetting
	{
		public const int DefaultBaudRate = 19200;
		public const Handshake DefaultHandshake = Handshake.None;
		public const Parity DefaultParity = Parity.None;
		public const int DefaultDataBits = 8;
		public const StopBits DefaultStopBits = StopBits.One;
		
		public int BaudRate {get; set;}
		public Handshake Handshake {get; set;}
		public Parity Parity {get; set;}
		public int DataBits {get;set;}
		public StopBits StopBits {get; set;}
		
		public SerialSetting()
		{
			this.BaudRate 	= DefaultBaudRate;
			this.Handshake 	= DefaultHandshake;
			this.Parity 	= DefaultParity;
			this.DataBits 	= DefaultDataBits;
			this.StopBits 	= DefaultStopBits;
		}
	}
}
