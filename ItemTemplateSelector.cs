using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Discount.Proxies;

namespace Discount
{
    public class ItemTemplateSelector : ContentControl
    {
        public DataTemplate ProductTemplate { get; set; }
        public DataTemplate StoreTemplate { get; set; }
        public DataTemplate ProductsTableTemplate { get; set; }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            if (newContent is CProduct)
                ContentTemplate = ProductTemplate;
            else if (newContent is CStore)
                ContentTemplate = StoreTemplate;
            else if (newContent is ProductsTable)
                ContentTemplate = ProductsTableTemplate;
            else
                ContentTemplate = null;
        }
    }
}
