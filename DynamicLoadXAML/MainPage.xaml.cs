using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace DynamicLoadXAML
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void bt_addXAML_Click(object sender, RoutedEventArgs e)
        {
            //XAML字符串内的命名空间不能少"http://schemas.microsoft.com/winfx/2006/xaml/presentation"不能少。
            string buttonXAML = "<Button xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'" + " Content = \"加载 XAML 文件\" Foreground = \"Red\"></Button>";
            Button btnRed = (Button)XamlReader.Load(buttonXAML);
            btnRed.Click += btnRed_Click;
            sp_show.Children.Add(btnRed);
        }
        //已经加载的XAMl按钮关联的事件
        async void btnRed_Click(object sender,RoutedEventArgs e)
        {
            string xaml = string.Empty;
            //加载程序的Rectangle.xaml文件
            StorageFile fileRead = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync("Rectangle.xaml");
            //读取文件内容
            xaml = await FileIO.ReadTextAsync(fileRead);
            //加载Rectangle
            Rectangle rectangle = (Rectangle)XamlReader.Load(xaml);
            sp_show.Children.Add(rectangle);
        }
    }
}
