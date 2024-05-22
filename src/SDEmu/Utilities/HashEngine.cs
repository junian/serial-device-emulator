/*
 * Created by SharpDevelop.
 * User: IEUser
 * Date: 10/11/2014
 * Time: 11:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Security.Cryptography;
using System.Text;

namespace Juniansoft.SDEmu.Utilities
{
	/// <summary>
	/// Description of HashEngine.
	/// </summary>
	public class HashEngine
	{
		public HashEngine()
		{
		}
		
	    public static string MD5Hash(string text)
	    {
	      MD5 md5 = new MD5CryptoServiceProvider();
	      
	      //compute hash from the bytes of text
	      md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
	 
	      //get hash result after compute it
	      byte[] result = md5.Hash;
	 
	      StringBuilder strBuilder = new StringBuilder();
	      for (int i = 0; i < result.Length; i++)
	      {
	        //change it into 2 hexadecimal digits
	        //for each byte
	        strBuilder.Append(result[i].ToString("x2"));
	      }
	 
	      return strBuilder.ToString();
	    }
	}
}
