using Plugin.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StudyCalender.Views
{
    public class SettingsDetailsView: ContentPage
    {
        public SettingsDetailsView(ModelSettings item)
        {
            //BindingContext = item;
            var webView = new WebView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            webView.Source = new HtmlWebViewSource
            {
                Html = item.Description
            };
            Content = new StackLayout
            {
                Children =
        {
          webView
        }
            };
            var share = new ToolbarItem
            {
                Icon = "ic_share.png",
                Text = "Share",
                Command = new Command(() => CrossShare.Current
                  .Share(new Plugin.Share.Abstractions.ShareMessage
                  {
                      Text = "Be sure to read @shanselman's " ,
                      Title = "Share"
                      //Url = item-
                  }))
            };

            ToolbarItems.Add(share);
        }
    }
}
