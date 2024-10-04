using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ergasia3.Source.Backend
{
	public static class Encode
	{

		public static string encryptPassword( string password )
		{
			var bytePassword = Encoding.ASCII.GetBytes( password );
			var hashedPassword = SHA512.HashData( bytePassword );
			var hexStringPassword = Convert.ToHexString( hashedPassword );

			return hexStringPassword.ToLower();
		}

	}
}