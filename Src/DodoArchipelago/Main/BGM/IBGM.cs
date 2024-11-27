﻿
// Type: DodoTheGame.BGM.IBGM

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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