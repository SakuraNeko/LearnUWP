using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace VisualTreeTraversal
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
        string visulTreeStr = "";

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            visulTreeStr = "";
            GetChildType(stackPanel);
            MessageDialog messageDialog = new MessageDialog(visulTreeStr);
            await messageDialog.ShowAsync();
        }
        //获取某个XAML元素的可视化对象的递归方法
        public void GetChildType(DependencyObject reference)
        {
            //获取子对象个数
            int count = VisualTreeHelper.GetChildrenCount(reference);
            //如果子对象的数量不为 0 将继续递归调用
            if (count > 0)
            {
                for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(reference) - 1; i++)
                {
                    //获取当前节点的子对象
                    var child = VisualTreeHelper.GetChild(reference, i);
                    //获取子对象的类型
                    visulTreeStr += child.GetType().ToString() + count + " ";
                    //递归调用
                    GetChildType(child);
                }
            }
        }
    }
}
