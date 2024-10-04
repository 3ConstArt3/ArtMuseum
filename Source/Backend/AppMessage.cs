using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ergasia3.Source.Backend
{
	public static class AppMessage
	{

		public static DialogResult showMessageBox(string message, MessageBoxIcon boxIcon,
												  MessageBoxButtons buttons = MessageBoxButtons.OK)
		{
			var caption = $"{boxIcon}";
			return MessageBox.Show( message, caption, buttons, boxIcon );
		}

	}
}