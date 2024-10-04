using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ergasia3.Source.Backend
{
	public static class Palette
	{

		public static ColorMatrix[] ColorMap { get; } =
		[
			new ColorMatrix(
				[Color.FromArgb( 255, 43, 45, 66 ),
				 Color.FromArgb( 255, 141, 153, 174 ),
				 Color.FromArgb( 255, 237, 242, 244 )]
				),	
			new ColorMatrix(
				[Color.FromArgb( 255, 61, 90, 128 ),
				 Color.FromArgb( 255, 152, 193, 217 ),
				 Color.FromArgb( 255, 224, 251, 252 )]
				),
			new ColorMatrix(
				[Color.FromArgb( 255, 2, 43, 58 ),
				 Color.FromArgb( 255, 31, 122, 140 ),
				 Color.FromArgb( 255, 191, 219, 247 )]
				),
			new ColorMatrix(
				[Color.DarkSlateBlue,
				 Color.MediumSlateBlue,
				 Color.Snow]
				)
		];

		// a recursive function to apply a color palette to any form or panel and
		// all the controls inside them
		public static void ApplyColorMatrix( Control container, int paletteIndex )
		{
			foreach( Control control in container.Controls )
			{
				if( control is Panel || control is Label ||
					control is Button || control is PictureBox ||
					control is ListView || control is TextBox ||
					control is RichTextBox)
				{
					var backColor = control.BackColor;
					var foreColor = control.ForeColor;

					if( isInColorList( Palette.DarkColors, backColor ) )
						backColor = Palette.DarkColors[ paletteIndex ];

					if( isInColorList( Palette.MediumColors, backColor ) )
						backColor = Palette.MediumColors[ paletteIndex ];

					if( isInColorList( Palette.FrontColors, backColor ) )
						backColor = Palette.FrontColors[ paletteIndex ];

					if( isInColorList( Palette.DarkColors, foreColor ) )
						foreColor = Palette.DarkColors[ paletteIndex ];

					if( isInColorList( Palette.MediumColors, foreColor ) )
						foreColor = Palette.MediumColors[ paletteIndex ];

					if( isInColorList( Palette.FrontColors, foreColor ) )
						foreColor = Palette.FrontColors[ paletteIndex ];

					control.BackColor = backColor;
					control.ForeColor = foreColor;
					makeTransparent( control );
				}

				ApplyColorMatrix( control, paletteIndex );
			}
		}

		private static void makeTransparent( Control container )
		{
			if (container is Panel || container is Label ||
				container is Button || container is PictureBox )
			{
				float temp_lower_bound = Globals._Temperature.AcBounds[ 0 ];
					Color finalBackColor = Color.FromArgb(
						Globals.IsAcOn ?
							( int )((Globals.Temperature - temp_lower_bound) *
							(140 / temp_lower_bound) + 115)
							: 215,
						container.BackColor.R,
						container.BackColor.G,
						container.BackColor.B
					);
					Color finalForeColor = Color.FromArgb(
						Globals.IsAcOn ?
							( int )((Globals.Temperature - temp_lower_bound) *
							(140 / temp_lower_bound) + 115)
							: 215,
						container.ForeColor.R,
						container.ForeColor.G,
						container.ForeColor.B
					);
					container.BackColor = finalBackColor;
					container.ForeColor = finalForeColor;
			}
		}

		private static bool isInColorList( Color[] colorList, Color targetColor )
		{
			foreach ( Color color in colorList )
			{
				if (color.R == targetColor.R &&
					color.G == targetColor.G &&
					color.B == targetColor.B)
					return true;
			}
			return false;
		}

		public static Color[] DarkColors { get; } =
		[
			ColorMap[ 0 ].Color1,
			ColorMap[ 1 ].Color1,
			ColorMap[ 2 ].Color1,
			ColorMap[ 3 ].Color1
		];

		public static Color[] MediumColors { get; } =
		[
			ColorMap[ 0 ].Color2,
			ColorMap[ 1 ].Color2,
			ColorMap[ 2 ].Color2,
			ColorMap[ 3 ].Color2
		];

		public static Color[] FrontColors { get; } =
		[
			ColorMap[ 0 ].Color3,
			ColorMap[ 1 ].Color3,
			ColorMap[ 2 ].Color3,
			ColorMap[ 3 ].Color3
		];

		public readonly struct ColorMatrix( Color[] colorMatrix)
		{
			internal Color Color1 { get; } = colorMatrix[ 0 ];
			internal Color Color2 { get; } = colorMatrix[ 1 ];
			internal Color Color3 { get; } = colorMatrix[ 2 ];
		}
	}
}