using ListViewWithCb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace ListViewWithCb
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var listView = new MyListView();

            List<ListData> data = new List<ListData>
            {
                new ListData{ title="Title 1", subtitle="Subtitle 1" },
                new ListData{ title="Title 2", subtitle="Subtitle 2" },
                new ListData{ title="Title 3", subtitle="Subtitle 3" }
            };

            listView.ItemsSource = data;

            listView.ItemSelected += (sender, e) => {
                ((ListView)sender).SelectedItem = null;
                
            };

            listView.ItemTapped += (sender, e) => {
                Cell itemCell = ((MyListView)sender).GetTemplatedItem(e.Item);

                if (itemCell is CustomCell)
                {
                    CustomCell cc = (CustomCell)itemCell;
                    if (cc.cb.Checked)
                        cc.cb.Checked = false;
                    else
                        cc.cb.Checked = true;
                }
            };

            listView.ItemTemplate = new DataTemplate(typeof(CustomCell));

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { listView }
            };
        }

        //private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    Cell itemCell = GetTemplatedItem(e.Item);

        //    if (itemCell is ViewCell)
        //    {
        //        ViewCell viewCell = (ViewCell)itemCell;
        //        viewCell.View...
        //    }
        //}

        public class CustomCell : ViewCell
        {

            public CheckBox cb;

            public CustomCell()
            {
                //instantiate each of our views
                StackLayout cellWrapper = new StackLayout();
                StackLayout horizontalLayout = new StackLayout();
                Label left = new Label();
                Label right = new Label();
                cb = new CheckBox();

                //set bindings
                left.SetBinding(Label.TextProperty, "title");
                right.SetBinding(Label.TextProperty, "subtitle");

                //Set properties for desired design
                cellWrapper.BackgroundColor = Color.FromHex("#eee");
                horizontalLayout.Orientation = StackOrientation.Horizontal;
                right.HorizontalOptions = LayoutOptions.EndAndExpand;
                left.TextColor = Color.FromHex("#f35e20");
                right.TextColor = Color.FromHex("503026");

                //add views to the view hierarchy
                horizontalLayout.Children.Add(left);
                horizontalLayout.Children.Add(cb);
                horizontalLayout.Children.Add(right);
                cellWrapper.Children.Add(horizontalLayout);
                View = cellWrapper;
            }
        }
    }
}
