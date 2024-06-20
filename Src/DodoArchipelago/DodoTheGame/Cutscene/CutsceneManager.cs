// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Cutscene.CutsceneManager
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpRaven.Data;
using System;


namespace DodoTheGame.Cutscene
{
  internal static class CutsceneManager
  {
    private static ICutscene currentCutscene;

    internal static UserInputStatus InputStatus { get; private set; } = new UserInputStatus();

    internal static bool CutsceneActive { get; private set; } = false;

    internal static Type CurrentCutsceneType => CutsceneManager.currentCutscene.GetType();

    internal static bool IsOverrideInEffect(RenderOverride ro)
    {
      return CutsceneManager.currentCutscene != null && CutsceneManager.currentCutscene.Overrides.Contains(ro);
    }

    internal static float CurrentBlackFade { get; private set; }

    internal static float CurrentWhiteFade { get; private set; }

    internal static void StartCutscene(
      ICutscene cutscene,
      GameTime gameTime,
      Player player,
      World world)
    {
      CutsceneManager.CutsceneActive = true;
      CutsceneManager.currentCutscene = cutscene;
      CutsceneManager.currentCutscene.Start(gameTime, player, world);
    }

    internal static void DrawOverride(
      RenderOverride @override,
      SpriteBatch spriteBatch,
      GameTime gameTime,
      Game1 game,
      Vector2 layerLocation)
    {
      if (CutsceneManager.currentCutscene != null && CutsceneManager.currentCutscene.Overrides.Contains(@override))
        CutsceneManager.currentCutscene.DrawOverride(@override, spriteBatch, gameTime, game, layerLocation);
      else
        Game1.Log("Cutscene.DrawOverride was called when it shouldn't have been", BreadcrumbLevel.Warning);
    }

    internal static void Update(GameTime gameTime, Player player, World world)
    {
      if (CutsceneManager.currentCutscene == null)
        return;
      if (CutsceneManager.currentCutscene.Terminated)
      {
        CutsceneManager.currentCutscene = (ICutscene) null;
        CutsceneManager.CutsceneActive = false;
      }
      if (CutsceneManager.currentCutscene != null)
      {
        CutsceneManager.InputStatus = CutsceneManager.currentCutscene.Process(gameTime, player, world);
        CutsceneManager.CurrentBlackFade = CutsceneManager.currentCutscene.BlackFade;
        CutsceneManager.CurrentWhiteFade = CutsceneManager.currentCutscene.WhiteFade;
      }
      else
      {
        CutsceneManager.CurrentBlackFade = 0.0f;
        CutsceneManager.CurrentWhiteFade = 0.0f;
        CutsceneManager.InputStatus = new UserInputStatus();
      }
    }
  }
}
