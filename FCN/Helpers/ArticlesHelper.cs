using FCN.Classes;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace FCN.Helpers
{
    public class ArticlesHelper
    {
        public async static Task<ObservableCollection<Article>> GetArticlesAsync()
        {
            ObservableCollection<Article> ArticleCollection = new ObservableCollection<Article>();
            Articles Articles = await LoadArticlesAsync();
            foreach (Article article in Articles.ArticlesList)
            {
                ArticleCollection.Add(article);
            }
            return ArticleCollection;
        }

        public static string GetArticleTextAsHTML(string path)
        {
             string text = "Article did not load";
             foreach(var i in new HtmlWeb().Load(GenerateArticleUrl(path)).DocumentNode.SelectNodes("//div[contains(@class, 'markdown-body svelte-1i6jy0o')]"))
             {
                 text = i.InnerHtml;
                 break;
             }
            return text;
        }

        private static string GenerateArticleUrl(string path)
        {
          return "https://fcn.netlify.app/blog" + path.Replace(".md", "").Remove(0, 1);
        }

        private static string GetWebSource(string url) => new System.Net.WebClient().DownloadString(url);

        public static ImageSource GetArticleThumbnail(string thumbnailpath)
        {
            var bit = new BitmapImage();
            bit.UriSource = new Uri(@"https://fcn.netlify.app" + thumbnailpath);
            return bit;
        }

        public static string FormatTime(DateTime date) => date.ToString("MMM dd, yyyy");

        public static ImageSource GetProfilePicture(string author)
        {
            var bit = new BitmapImage();
            bit.UriSource = new Uri(@"https://github.com/" + author + ".png");
            return bit;
        }

        public static Uri GetAuthorLink(string author)
        {
            return new Uri(@"https://github.com/" + author);
        }

        private async static Task<Articles> LoadArticlesAsync()
        {
            return await Task.Run(async() =>
            {
                using (WebClient wc = new WebClient())
                {
                    return await JsonHelper.DeserializeArticlesAsync("{\"ArticlesList\":" + wc.DownloadString("https://fcn.netlify.app/blog.json") + "}");
                }
            });
        }
    }
}
