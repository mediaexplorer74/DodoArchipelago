// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Cutscene.ArchipelagoArrivalCutscene
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using DodoTheGame.GUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace DodoTheGame.Cutscene
{
  internal class ArchipelagoArrivalCutscene : ICutscene
  {
    private float waitTime;

    public bool Terminated { get; private set; }

    public float BlackFade { get; private set; }

    public float WhiteFade => 0.0f;

    public List<RenderOverride> Overrides { get; private set; } = new List<RenderOverride>();

    public void DrawOverride(
      RenderOverride @override,
      SpriteBatch spriteBatch,
      GameTime gameTime,
      Game1 game,
      Vector2 layerLocation)
    {
      if (@override == RenderOverride.HUD || @override != RenderOverride.Dodo)
        return;
      Game1.player.facing = 1;
      spriteBatch.Begin(SpriteSortMode.Immediate);
      if ((double) this.waitTime < 1700.0)
      {
        game.dodoWakingUp.ResetAnimation();
        game.dodoLaying.Draw(spriteBatch, new Vector2(layerLocation.X + 19f, layerLocation.Y), gameTime);
      }
      else
        game.dodoWakingUp.Draw(spriteBatch, new Vector2(layerLocation.X + 19f, layerLocation.Y), gameTime);
      spriteBatch.End();
    }

    public UserInputStatus Process(GameTime gameTime, Player player, World world)
    {
      if (this.Terminated)
        return new UserInputStatus();
      if ((double) player.location.X > 8820.0)
      {
        GUIManager.ClearThenSet((IGUI) GUIManager.tutorialHUD);
        this.Terminated = true;
      }
      this.waitTime += Convert.ToSingle(gameTime.ElapsedGameTime.TotalMilliseconds);
      if ((double) this.waitTime > 2500.0 && (double) this.waitTime < 3800.0)
      {
        this.Overrides.Remove(RenderOverride.Dodo);
        return new UserInputStatus();
      }
      if ((double) this.waitTime > 3800.0)
      {
        if ((double) player.location.X > 4200.0 && (double) player.location.X < 4500.0)
          this.BlackFade = (float) (((double) player.location.X - 4200.0) / 100.0);
        else if ((double) player.location.X > 4500.0 && (double) player.location.X < 4700.0)
          this.BlackFade = 1f;
        else if ((double) player.location.X > 4700.0 && (double) player.location.X < 7000.0)
        {
          this.BlackFade = 1f;
          player.location = new Vector2(8440f, 7960f);
        }
        else if ((double) player.location.X > 8440.0 && (double) player.location.X < 8700.0)
          this.BlackFade = (float) (1.0 - ((double) player.location.X - 8440.0) / 100.0);
        else if ((double) player.location.X > 8700.0)
          this.BlackFade = 0.0f;
        return new UserInputStatus() { moveRight = 1f };
      }
      if (!this.Overrides.Contains(RenderOverride.Dodo))
        this.Overrides.Add(RenderOverride.Dodo);
      return new UserInputStatus();
    }

    public void Start(GameTime gameTime, Player player, World world)
    {
      this.waitTime = 0.0f;
      this.BlackFade = 0.0f;
      this.Overrides = new List<RenderOverride>()
      {
        RenderOverride.HUD
      };
      player.location = new Vector2(3513f, 7383f);
    }
  }
}
