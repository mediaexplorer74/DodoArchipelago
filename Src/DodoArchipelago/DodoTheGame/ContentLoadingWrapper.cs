// Decompiled with JetBrains decompiler
// Type: DodoTheGame.ContentLoadingWrapper
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using DodoTheGame.Localization;
using Microsoft.Xna.Framework.Content;
using SharpRaven.Data;
using System.IO;


namespace DodoTheGame
{
  internal static class ContentLoadingWrapper
  {
    public static int loadedAssetCount = 0;
    public static readonly int expectedAssetCount = 1258;
    public static ContentManager contentManager;

    public static string LastAssetName { get; private set; } = "";

    public static T Load<T>(string assetName)
    {
      ++ContentLoadingWrapper.loadedAssetCount;
      if (ContentLoadingWrapper.loadedAssetCount > ContentLoadingWrapper.expectedAssetCount)
        Game1.Log("Loaded asset count is higher than expected", BreadcrumbLevel.Critical, "clw");
      string assetName1 = LocalizationManager.GetAssetName(assetName, false);
      ContentLoadingWrapper.LastAssetName = assetName1 == null || !(assetName != assetName1) ? assetName : assetName + " => " + assetName1;
      return assetName1 == null ? ContentLoadingWrapper.contentManager.Load<T>(assetName) : ContentLoadingWrapper.contentManager.Load<T>(assetName1);
    }

    public static FileInfo[] ListAssets(string folder)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(ContentLoadingWrapper.contentManager.RootDirectory + "\\" + folder);
      return directoryInfo.Exists ? directoryInfo.GetFiles("*.*") : throw new DirectoryNotFoundException();
    }
  }
}
