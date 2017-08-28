////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Views\ItemsPage.xaml.cs
//
// summary:	Implements the items page.xaml class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ApiViewer.Xamarin.Views
{
	public partial class ItemsPage : ContentPage
	{
        Picker ddlCategory;
        Picker ddlApi;
        public ListView lstResults;

		public ItemsPage()
		{
			InitializeComponent();
            StackLayout stack = new StackLayout();

            ddlCategory = new Picker();

            ddlApi = new Picker();

            lstResults = new ListView();

            ddlCategory.ItemsSource = Standard.Apis.FactoryApi.GetCategories();
            ddlCategory.SelectedIndex = 0;
            ddlCategory.SelectedIndexChanged += ddlCategoryChanged;

            LoadApis();
            ddlApi.SelectedIndexChanged += ddlApiChanged;

            LoadResults();

            stack.Children.Add(new Label() { Text = "Category" });
            stack.Children.Add(ddlCategory);
            stack.Children.Add(new Label() { Text = "Apis" });
            stack.Children.Add(ddlApi);
            stack.Children.Add(new Label() { Text = "Results" });
            stack.Children.Add(lstResults);

            Content = stack;
        }
        
        public void ddlCategoryChanged (object sender, EventArgs e)
        {
            LoadApis();
        }

        public void ddlApiChanged (object sender, EventArgs e)
        {
            LoadResults();
        }

        protected void LoadApis()
        {
            ddlApi.ItemsSource = null;
            ddlApi.Items.Clear();
            Standard.Apis.FactoryApi.GetApis(ddlCategory.SelectedItem.ToString()).ForEach(x => ddlApi.Items.Add(x.Value));
            ddlApi.SelectedIndex = 0;
        }

        protected void LoadResults()
        {
            lstResults.ItemsSource = null;
            if (ddlApi.SelectedItem == null) return;
            lstResults.ItemsSource = Standard.Apis.FactoryApi.GetFromName(ddlApi.SelectedItem.ToString()).GetAll();
            lstResults.ItemTemplate = new DataTemplate(() =>
            {
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            nameLabel
                        }
                    }
                };
            });
        }
        

        protected override void OnAppearing()
		{
			base.OnAppearing();
            
		}
	}
}
