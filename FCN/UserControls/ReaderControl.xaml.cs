using FCN.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FCN.UserControls
{
    public sealed partial class ReaderControl : UserControl
    {
        public Article Article
        {
            get => (Article)GetValue(ArticleProperty);
            set => SetValue(ArticleProperty, value);
        }

        public static readonly DependencyProperty ArticleProperty =
          DependencyProperty.Register("Article", typeof(Article), typeof(ReaderControl), null);

        public ReaderControl() => InitializeComponent();
    }
}
