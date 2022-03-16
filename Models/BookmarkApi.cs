using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wox.Plugin.Bookmarks.Helpers
{
  static class BookmarkApi
  {
    private static Dictionary<string, string> browserBookmarkPaths = new Dictionary<string, string>()
    {
      { "edge", "\\Local\\Microsoft\\Edge\\User Data\\Default\\Bookmarks" },
      { "chrome", "\\Local\\Google\\Chrome\\User Data\\Default\\Bookmarks" },
    };

    private static string getFilePath(string browser)
    {
      string filepath = "";
      if (!browserBookmarkPaths.TryGetValue(browser.ToLower(), out filepath)) {
        return "";
      }
      return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), filepath);
    }

    public static List<BookmarkResult> QueryBookmarks(Query query, SettingsModel settings)
    {
      String filepath = "";
      if (!browserBookmarkPaths.TryGetValue(settings.DefaultBrowser.ToLower(), out filepath))
      {
        return new List<BookmarkResult>();
      }

      using (StreamReader objReader = new StreamReader(filepath))
      {
        var json = objReader.ReadToEnd();
        List<BookmarkResult> results = JsonConvert.DeserializeObject<List<BookmarkResult>>(json);
        List<BookmarkResult> filteredResultsList = new List<BookmarkResult>();
        foreach (BookmarkResult result in results)
        {
          if (result.name.ToLower().Contains(query.Search.ToLower()) || result.url.ToLower().Contains(query.Search.ToLower()))
          {
            filteredResultsList.Add(result);
          }
        }
        return filteredResultsList;
      }
    }
  }
}
