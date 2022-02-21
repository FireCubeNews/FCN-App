using FCN.Classes;
using FCN.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FCN
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Article> ArticleCollection;
        Article FirstArticle;

        public MainPage() => InitializeComponent();

        //FIX this

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ArticleCollection = await ArticlesHelper.GetArticlesAsync();
            FirstArticle = ArticleCollection.First<Article>();
            ArticleCollection.Remove(ArticleCollection.First<Article>());
            ArticlesListView.ItemsSource = ArticleCollection;
            Bindings.Update();
        }

        private void ArticlesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ArticlesListView.Visibility = Visibility.Collapsed;
            Reader.Visibility = Visibility.Visible;
            Reader.Article = e.ClickedItem as Article;
            Bindings.Update();
        }

        private void ReadMoreButton_Click(object sender, RoutedEventArgs e)
        {
            ArticlesListView.Visibility = Visibility.Collapsed;
            Reader.Visibility = Visibility.Visible;
            Reader.Article = FirstArticle;
            Bindings.Update();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ArticlesListView.Visibility = Visibility.Visible;
            Reader.Visibility = Visibility.Collapsed;
            Bindings.Update();
        }

        //copied code
        private void Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = ((Grid)sender).Resources["EnterStoryboard"] as Storyboard;
            sb.Begin();
        }

        private void Grid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = ((Grid)sender).Resources["ExitStoryboard"] as Storyboard;
            sb.Begin();
        }

        private void Grid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = ((Grid)sender).Resources["PressedStoryboard"] as Storyboard;
            sb.Begin();
        }

        private void Grid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = ((Grid)sender).Resources["ReleasedStoryboard"] as Storyboard;
            sb.Begin();
        }
    }
}
