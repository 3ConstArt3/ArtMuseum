using Ergasia3.Source.Backend;
using System.Xml;

namespace Ergasia3.Source.Frontend.CinemaHall
{
	public partial class CoffeeHall : BaseForm
	{

		private const uint ItemLimit = 3;

		private ItemSelection itemSelection = ItemSelection.Foods;
		private readonly Item[,] itemInfo = new Item[ ItemLimit, ( uint )ItemSelection.MAX_ITEMSELECTIONS ];
		private readonly uint[,] itemStock = new uint[ ItemLimit, ( uint )ItemSelection.MAX_ITEMSELECTIONS ];
		private readonly uint[,] pickedItems = new uint[ ItemLimit, ( uint )ItemSelection.MAX_ITEMSELECTIONS ];

		// c_ meaning control, to avoid confusion
		private PictureBox[] c_itemImages;
		private Label[] c_itemNames, c_itemsLeft, c_itemsPrice, c_itemsPicked;
		private Button[,] c_buttons;

		#region Constructor definition
		public CoffeeHall()
		{
			InitializeComponent();
			this.initializeElements();
		}
		#endregion

		#region Function definition
		private void CoffeeHall_FormClosed( object sender, FormClosedEventArgs e )
		{
			Application.OpenForms[ 1 ]?.Show();
		}

		private void initializeElements()
		{
			this.readCoffeeHallItems();

			this.c_itemImages = [ this.Food1Pbx, this.Food2Pbx, this.Food3Pbx ];
			this.c_itemNames = [ this.Food1Name, this.Food2Name, this.Food3Name ];
			this.c_itemsLeft = [ this.Left1Lbl, this.Left2Lbl, this.Left3Lbl ];
			this.c_itemsPrice = [ this.Price1Lbl, this.Price2Lbl, this.Price3Lbl ];
			this.c_itemsPicked = [ this.Picked1Lbl, this.Picked2Lbl, this.Picked3Lbl ];

			Array.Clear( this.pickedItems );

			this.c_buttons = new Button[,] {
				{ Decrease1Btn, Increase1Btn },
				{ Decrease2Btn, Increase2Btn },
				{ Decrease3Btn, Increase3Btn }
			};

			Random random = new();
			for( int k = 0; k < ItemLimit; k++ )
			{
				this.itemStock[ k, ( uint )ItemSelection.Foods ] =
					( uint )(33 * random.NextDouble());
				this.itemStock[ k, ( uint )ItemSelection.Drinks ] =
					( uint )(42 * random.NextDouble());
			}

			this.FoodRbtn.Checked = true;
			this.DrinkRbtn.Checked = false;
			this.updateFormItems();
		}

		private void readCoffeeHallItems()
		{
			XmlDocument document = new();
			document.Load( "Data/CoffeeHall.xml" );

			XmlNode? rootNode = document.SelectSingleNode( "coffee_hall" );
			if( rootNode == null )
			{
				var message = "Couldn't find root node!";
				throw new Exception( message );
			}

			XmlNode? foodNode = rootNode.SelectSingleNode( "foods" );
			XmlNode? drinkNode = rootNode.SelectSingleNode( "drinks" );

			if( foodNode == null || drinkNode == null )
			{
				var message = "foods or drinks node doesn't exist!";
				throw new Exception( message );
			}

			Item[] foods = grabItemsFrom( foodNode );
			Item[] drinks = grabItemsFrom( drinkNode );
			for( int i = 0; i < foods.Length; i++ )
			{
				itemInfo[ i, ( uint )ItemSelection.Foods ] = foods[ i ];
				itemInfo[ i, ( uint )ItemSelection.Drinks ] = drinks[ i ];
			}
		}

		private static Item[] grabItemsFrom( XmlNode node )
		{
			if( node.ChildNodes.Count != ItemLimit )
			{
				var message = $"{node.Name} node must have {ItemLimit} children nodes!";
				throw new Exception( message );
			}

			var returnedItems = new Item[ ItemLimit ];
			for( int i = 0; i < node.ChildNodes.Count; i++ )
			{
				XmlNode? itemNode = node.ChildNodes[ i ];
				if( itemNode.Attributes == null || itemNode.Attributes.Count != ItemLimit )
				{
					var message = "Incorrect amount of attributes in item node!";
					throw new Exception( message );
				}

				if( itemNode.Attributes[ "name" ] == null ||
					itemNode.Attributes[ "price" ] == null ||
					itemNode.Attributes[ "imagePath" ] == null )
				{
					var message = "Incorrect attributes in item node!";
					throw new Exception( message );
				}

				var name = itemNode.Attributes[ "name" ]?.Value;
				var price = float.Parse( itemNode.Attributes[ "price" ]?.Value );
				var imagePath = itemNode.Attributes[ "imagePath" ]?.Value;
				returnedItems[ i ] = new Item( name, price, imagePath );
			}

			return returnedItems;
		}

		private void FoodRbtn_CheckedChanged( object sender, EventArgs e )
		{
			this.itemSelection = ItemSelection.Foods;
			updateFormItems();
		}

		private void DrinkRbtn_CheckedChanged( object sender, EventArgs e )
		{
			this.itemSelection = ItemSelection.Drinks;
			updateFormItems();
		}

		private void updateItems()
		{
			for( int item = 0; item < this.c_itemImages.Length; item++ )
			{
				var selectedItem = this.itemInfo[ item, ( uint )itemSelection ];

				this.c_itemImages[ item ].Load( selectedItem.ImagePath );
				this.c_itemNames[ item ].Text = selectedItem.Name;
				this.c_itemsPrice[ item ].Text = $"{selectedItem.Price:f2}";
			}
			enableAllItems();
		}

		private void updateAmountQuantity()
		{
			for( int i = 0; i < this.c_itemImages.Length; i++ )
			{
				this.c_itemsLeft[ i ].Text = itemStock[ i, ( uint )itemSelection ].ToString();
				this.c_itemsPicked[ i ].Text = pickedItems[ i, ( uint )itemSelection ].ToString();
			}
		}

		private void clearPickedQuantities()
		{
			for( int i = 0; i < ItemLimit; i++ )
			{
				this.pickedItems[ i, ( uint )itemSelection ] = 0;
				this.c_itemsPicked[ i ].Text = "0";
			}
		}

		private void updateFormItems()
		{
			this.updateItems();
			this.updateAmountQuantity();
			this.disableOutOfStockItems();
			this.updateTotalPrice();
		}

		private void BuyBtn_Click( object sender, EventArgs e )
		{
			bool hasClientPurchasedAnything = false;
			foreach( uint amt in pickedItems )
				if( amt != 0 )
					hasClientPurchasedAnything = true;

			if( !hasClientPurchasedAnything )
			{
				AppMessage.showMessageBox(
					"Please add an item for purchase!",
					MessageBoxIcon.Warning
				);
				return;
			}

			// we've made sure from the checks in the GUI that the client will
			// not try and buy more items than those that are available
			for( int i = 0; i < ItemLimit; i++ )
				itemStock[ i, ( uint )itemSelection ] -= pickedItems[ i, ( uint )itemSelection ];

			AppMessage.showMessageBox( "Purchase successful!", MessageBoxIcon.Information );
			var userAnswer = AppMessage.showMessageBox(
				"Do you want to move to the Cinema Hall?",
				MessageBoxIcon.Question,
				MessageBoxButtons.YesNo
			);

			if (userAnswer == DialogResult.Yes )
			{
				new CinemaHall().Show();
				Hide();
			}

			this.updateAmountQuantity();
			this.disableOutOfStockItems();
			this.clearPickedQuantities();
			this.updateTotalPrice();
		}

		private void updateTotalPrice()
		{
			TotalPrice.Text = (
				itemInfo[ 0, ( uint )itemSelection ].Price * pickedItems[ 0, ( uint )itemSelection ] +
				itemInfo[ 1, ( uint )itemSelection ].Price * pickedItems[ 1, ( uint )itemSelection ] +
				itemInfo[ 2, ( uint )itemSelection ].Price * pickedItems[ 2, ( uint )itemSelection ]
			).ToString( "f2" );
		}

		private void disableOutOfStockItems()
		{
			static void makePanelsGray( params Button[] btns )
			{
				foreach( Button btn in btns )
				{
					btn.Enabled = false;
					btn.BackColor = Color.Gray;
				}
			}

			for( int i = 0; i < ItemLimit; i++ )
				if( this.itemStock[ i, ( uint )itemSelection ] == 0 )
					makePanelsGray( this.c_buttons[ i, 0 ], this.c_buttons[ i, 1 ] );
		}

		private void enableAllItems()
		{
			foreach( Button btn in this.c_buttons )
			{
				btn.Enabled = true;
				btn.BackColor = Palette.ColorMap[ Globals.SelectedPaletteIndex ].Color1;
			}
		}

		private void ChangeItemQuantity_Click( object sender, EventArgs e )
		{
			// this should not crash
			Button btn = ( Button )sender;

			int getIndex()
			{
				if( btn.Name.Contains( '1' ) )
					return 0;
				else if( btn.Name.Contains( '2' ) )
					return 1;
				else if( btn.Name.Contains( '3' ) )
					return 2;
				else
					throw new Exception( "Button has incorrect name structure!" );
			}

			int index = getIndex();
			if( btn.Text.Equals( "-" ) )
			{
				if( pickedItems[ index, ( uint )itemSelection ] > 0 )
					--pickedItems[ index, ( uint )itemSelection ];
			}
			else if( btn.Text.Equals( "+" ) )
			{
				if( pickedItems[ index, ( uint )itemSelection ] < itemStock[ index, ( uint )itemSelection ] )
					++pickedItems[ index, ( uint )itemSelection ];
			}
			else
				throw new Exception( "Button has incorrect text applied to it!" );

			updateAmountQuantity();
			updateTotalPrice();
		}

		private void helpLbl_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			HelpFile.Show( HelpFile.ProjectionHall );
		}
		#endregion


		private readonly struct Item( string name, float price, string imagepath )
		{
			internal string Name { get; } = name;
			internal float Price { get; } = price;
			internal string ImagePath { get; } = imagepath;
		};

		private enum ItemSelection : uint
		{
			Foods = 0,
			Drinks,
			MAX_ITEMSELECTIONS
		}
	}
}