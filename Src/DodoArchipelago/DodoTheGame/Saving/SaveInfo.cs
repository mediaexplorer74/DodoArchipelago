// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Saving.SaveInfo
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame.Saving
{
  internal class SaveInfo
  {
    public DateTime saveTime;
    public int playTime;
    public Texture2D screenshot;
    public bool isValid;

    public SaveInfo(bool isValid, int playTime, DateTime saveTime, Texture2D screenshot)
    {
      this.isValid = isValid;
      this.playTime = playTime;
      this.saveTime = saveTime;
      this.screenshot = screenshot;
    }

    public SaveInfo()
    {
    }
  }
}
