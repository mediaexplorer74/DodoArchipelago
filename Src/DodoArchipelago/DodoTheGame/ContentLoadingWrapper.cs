// Type: DodoTheGame.ContentLoadingWrapper

using DodoTheGame.Localization;
using Microsoft.Xna.Framework.Content;
using System;
using System.Diagnostics;
using System.IO;


namespace DodoTheGame
{
  internal static class ContentLoadingWrapper
  {
    public static int loadedAssetCount = 0;
    public static readonly int expectedAssetCount = 1258;
    public static ContentManager contentManager;

    public static string LastAssetName { get; private set; } = "";


    // Load<T>(string assetName)
    public static T Load<T>(string assetName)
    {
      ++ContentLoadingWrapper.loadedAssetCount;

      if (ContentLoadingWrapper.loadedAssetCount > ContentLoadingWrapper.expectedAssetCount)
      {
        Debug.WriteLine("Loaded asset count is higher than expected");
      }

      string assetName1 = LocalizationManager.GetAssetName(assetName, false);
      ContentLoadingWrapper.LastAssetName = assetName1 == null 
                || !(assetName != assetName1) ? assetName : assetName + " => " + assetName1;

        T res = default;
        if (assetName1 == null)
        {
            try
            {
                res = ContentLoadingWrapper.contentManager.Load<T>(assetName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ex] contentManager.Load error: "
                                   +"[" + assetName + "]" + ex.Message);
            }
        }
        else
        {
            try
            { 
                res = ContentLoadingWrapper.contentManager.Load<T>(assetName1);
            }
            catch (Exception ex)
            {
                    Debug.WriteLine("[ex] contentManager.Load error: "
                                       + "[" + assetName1 + "]" + ex.Message);
            }
       }

        return res;
    }//Load<T>...


    // ListAssets(...)
    public static FileInfo[] ListAssets(string folder)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(ContentLoadingWrapper.contentManager.RootDirectory + "\\" + folder);
      return directoryInfo.Exists ? directoryInfo.GetFiles("*.*") : throw new DirectoryNotFoundException();
    }//
  }
}
