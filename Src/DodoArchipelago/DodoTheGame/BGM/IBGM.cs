// Decompiled with JetBrains decompiler
// Type: DodoTheGame.BGM.IBGM
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using System;


namespace DodoTheGame.BGM
{
  internal interface IBGM
  {
    float Volume { get; set; }

    BGMStatus Status { get; }

    void Start();

    void Update(GameTime gameTime);

    void Kill();

    bool RequestStop(bool doStop);

    void StateSongChanged(object sender, EventArgs e);
  }
}
