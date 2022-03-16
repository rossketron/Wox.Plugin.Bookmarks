using System;
using System.Collections.Generic;
using System.Diagnostics;
using Wox.Plugin.Bookmarks.Helpers; 

namespace Wox.Plugin.Bookmarks.Plugins
{
  static class Bookmarks
  {
    private static readonly string ico = "Prompt.png";

    private static void OpenUrl(string url)
    {
      Process.Start(url);
    }

    public static List<Result> Query(Query query, SettingsModel settings, PluginInitContext context)
    {
      List<Result> list = new List<Result>();

      if (query.Search.Length == 0)
      {
        list.Add(new Result
        {
          Title = $"Open Bookmark in {settings.DefaultBrowser}",
          SubTitle = "...keep typing to search bookmarks",
          IcoPath = ico
        });
        return list;
      }

      List<BookmarkResult> results = BookmarkApi.QueryBookmarks(query, settings);

      if (results.Count > 0)
      {
        foreach (BookmarkResult result in results)
        {
          list.Add(new Result
          {
            Title = result.name,
            SubTitle = result.url,
            IcoPath = ico,
            Action = (e) =>
            {
              OpenUrl(result.url);
              return true;
            }
          });
        }
      }
      else
      {
        list.Add(new Result
        {
          Title = "No Results Found",
          IcoPath = ico
        });
      }

      return list;
    }
  }
}