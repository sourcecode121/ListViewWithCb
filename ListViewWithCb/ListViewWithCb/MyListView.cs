using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewWithCb
{
    public class MyListView : ListView
    {
        public ITemplatedItemsList<Cell> TemplatedItems
        {
            get { return ((ITemplatedItemsView<Cell>)this).TemplatedItems; }
        }

        public Cell GetTemplatedItem(object itemData)
        {
            return TemplatedItems.First(p => p.BindingContext == itemData);
        }
    }
}
