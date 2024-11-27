
// Type: DodoTheGame.Cutscene.StoryIntroCutscene

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DodoTheGame.Cutscene
{
  internal class StoryIntroCutscene : ICutscene
  {
    public static Texture2D bg;
    public static Texture2D lum;
    public static Sprite fire;
    public static Sprite objshadow1100;
    public static Sprite rado;
    public static Sprite bato;
    public static Sprite walk;
    public static Sprite eggs;
    public static Sprite idle;
    public static Sprite shocked;
    public static Sprite run;
    public static Sprite runeggs;
    public static Sprite runtransition;
    public static Sprite jumpeggs;
    public static Sprite badwave;
    public static Sprite badwavehead;
    public static Sprite dood1sleep;
    public static Sprite dood2sleep;
    public static Sprite dood3sleep;
    public static Sprite dood4sleep;
    public static Sprite dood1wake;
    public static Sprite dood2wake;
    public static Sprite dood3wake;
    public static Sprite dood4wake;
    public static Sprite dood2_shadow;
    public static Sprite dood3_shadow;
    public static Sprite dood4_shadow;
    private float time;
    private readonly float firstPanSpeed = 8f;
    private readonly float firstPanEndLocation = 1000f;
    private readonly float firstPanStillTime;
    private readonly float timeToRewindLeft = 1500f;
    private readonly float afterRewindStillTime = 3000f;
    private readonly float secondPanFirstPartLength = 6000f;
    private readonly float secondPanFirstSpeed = 0.43f;
    private readonly float secondPanSecondPartLength = 13000f;
    private readonly float secondPanSecondSpeed = 0.28f;
    private readonly float finalShotStillTime = 4000f;
    private readonly float cutStillTime = 2000f;
    private int soundXPlayer;

    public bool Terminated { get; private set; }

    public float BlackFade => 0.0f;

    public float WhiteFade => 0.0f;

    public List<RenderOverride> Overrides { get; private set; } 
            = Enum.GetValues(typeof (RenderOverride)).Cast<RenderOverride>().ToList<RenderOverride>();

    public void DrawOverride(
      RenderOverride @override,
      SpriteBatch spriteBatch,
      GameTime gameTime,
      Game1 game,
      Vector2 layerLocation)
    {
      if (this.Terminated || @override != RenderOverride.HUD)
        return;
      spriteBatch.Begin(SpriteSortMode.Immediate);
      Vector2 location = (double) this.time >= (double) this.firstPanEndLocation * (double) this.firstPanSpeed ? ((double) this.time >= (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft ? ((double) this.time >= (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime ? ((double) this.time >= (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + (double) this.secondPanFirstPartLength ? ((double) this.time >= (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + (double) this.secondPanFirstPartLength + (double) this.secondPanSecondPartLength ? ((double) this.time >= (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + (double) this.secondPanFirstPartLength + (double) this.secondPanSecondPartLength + (double) this.finalShotStillTime ? Vector2.One : new Vector2((float) (-((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + (double) this.secondPanFirstPartLength - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime)) * (double) this.secondPanFirstSpeed - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + (double) this.secondPanFirstPartLength + (double) this.secondPanSecondPartLength - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + (double) this.secondPanFirstPartLength)) * (double) this.secondPanSecondSpeed), 0.0f)) : new Vector2((float) (-((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + (double) this.secondPanFirstPartLength - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime)) * (double) this.secondPanFirstSpeed - ((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + (double) this.secondPanFirstPartLength)) * (double) this.secondPanSecondSpeed), 0.0f)) : new Vector2((float) -((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime)) * this.secondPanFirstSpeed, 0.0f)) : new Vector2(0.0f, 0.0f)) : new Vector2((float) ((-3500.0 - 1.0 * ((double) this.firstPanEndLocation * (double) this.firstPanSpeed / (double) this.firstPanSpeed)) * (1.0 - ((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime)) / ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime)))), 0.0f)) : new Vector2((float) (-3500.0 - 1.0 * ((double) this.time / (double) this.firstPanSpeed)), 0.0f);
      if (location != Vector2.One)
      {
        if (this.soundXPlayer == 0)
        {
          Sound.soundEffectList.First<SoundEffect>((Func<SoundEffect, bool>) (p => p.Name == "bgm/StoryIntro")).Play(1f, 0.0f, 0.0f);
          Sound.soundEffectList.First<SoundEffect>((Func<SoundEffect, bool>) (p => p.Name == "soundeffects/cigales")).Play(0.3f, 0.0f, 0.0f);
          Sound.soundEffectList.First<SoundEffect>((Func<SoundEffect, bool>) (p => p.Name == "soundeffects/braises")).Play(1f, 0.0f, 0.0f);
          this.soundXPlayer = 1;
        }
        else if ((double) this.time > (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft - 700.0 && this.soundXPlayer == 1)
        {
          Sound.soundEffectList.First<SoundEffect>((Func<SoundEffect, bool>) (p => p.Name == "soundeffects/bato en bois")).Play(0.4f, 0.0f, 0.0f);
          this.soundXPlayer = 2;
        }
        Recorder.RDraw(spriteBatch, StoryIntroCutscene.bg, location, Color.White);
        StoryIntroCutscene.objshadow1100.Draw(spriteBatch, new Vector2((float) ((double) location.X + 4750.0 - 589.0), location.Y), gameTime);
        StoryIntroCutscene.fire.Draw(spriteBatch, new Vector2(location.X + 4750f, location.Y + 360f), gameTime);
        if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 19350.0)
          StoryIntroCutscene.rado.Draw(spriteBatch, new Vector2(location.X + 6920f, location.Y + 600f), gameTime);
        else
          StoryIntroCutscene.rado.Draw(spriteBatch, new Vector2((float) ((double) location.X - 50.0 + 0.11999999731779099 * ((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 19000.0)) + 320.0 + 840.0 + 1800.0 + 3960.000244140625), location.Y + 600f), gameTime);
        if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 14550.0)
          StoryIntroCutscene.eggs.Draw(spriteBatch, new Vector2(location.X + 5950f, location.Y + 600f), gameTime);
        if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime)
          StoryIntroCutscene.walk.Draw(spriteBatch, new Vector2((float) ((double) location.X - 0.10000000149011612 * (double) this.time + 4000.0), location.Y + 550f), gameTime);
        else if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 500.0)
          StoryIntroCutscene.idle.Draw(spriteBatch, new Vector2(location.X + 1750f, location.Y + 550f), gameTime);
        else if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 3000.0)
          StoryIntroCutscene.shocked.Draw(spriteBatch, new Vector2(location.X + 1750f, location.Y + 550f), gameTime);
        else if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 14000.0)
          StoryIntroCutscene.run.Draw(spriteBatch, new Vector2((float) ((double) location.X + 1800.0 + 0.36000001430511475 * ((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 3000.0))), location.Y + 550f), gameTime);
        else if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 14720.0)
          StoryIntroCutscene.runtransition.Draw(spriteBatch, new Vector2((float) ((double) location.X + 0.2199999988079071 * ((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 14000.0)) + 1800.0 + 3960.000244140625), location.Y + 550f), gameTime);
        else if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 18000.0)
          StoryIntroCutscene.runeggs.Draw(spriteBatch, new Vector2((float) ((double) location.X + 0.2199999988079071 * ((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 14000.0)) + 1800.0 + 3960.000244140625), location.Y + 550f), gameTime);
        else if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 18400.0)
          StoryIntroCutscene.jumpeggs.Draw(spriteBatch, new Vector2((float) ((double) location.X + 0.090000003576278687 * ((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 18000.0)) + 880.0 + 1800.0 + 3960.000244140625), location.Y + 520f), gameTime);
        else if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 19000.0)
          StoryIntroCutscene.jumpeggs.Draw(spriteBatch, new Vector2((float) ((double) location.X + 0.40999999642372131 * ((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 18400.0)) + 36.0 + 880.0 + 1800.0 + 3960.000244140625), location.Y + 520f), gameTime);
        else if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 23100.0)
          StoryIntroCutscene.jumpeggs.Draw(spriteBatch, new Vector2((float) ((double) location.X + 0.11999999731779099 * ((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 19000.0)) + 246.0 + 36.0 + 880.0 + 1800.0 + 3960.000244140625), location.Y + 520f), gameTime);
        StoryIntroCutscene.badwavehead.Draw(spriteBatch, new Vector2(15f * Convert.ToSingle(Math.Cos((double) Convert.ToSingle(this.time / 200f))) + Math.Min((float) ((double) location.X + 600.0 + 0.34999999403953552 * ((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime))), 630f), location.Y + 0.0f), gameTime, colorn: new Color?(Color.White * Math.Max(0.0f, Math.Min(1f, (float) (((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime - 500.0)) / 1000.0)))));
        StoryIntroCutscene.badwave.Draw(spriteBatch, new Vector2(15f * Convert.ToSingle(Math.Cos((double) Convert.ToSingle(this.time / 200f))) + Math.Min((float) ((double) location.X + 600.0 - 1280.0 + 0.34999999403953552 * ((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime))), -650f), location.Y + 0.0f), gameTime, colorn: new Color?(Color.White * Math.Max(0.0f, Math.Min(1f, (float) (((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime - 500.0)) / 1000.0)))));
        if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 8450.0)
          StoryIntroCutscene.dood1sleep.Draw(spriteBatch, new Vector2(location.X + 4030f, location.Y + 260f), gameTime);
        else
          StoryIntroCutscene.dood1wake.Draw(spriteBatch, new Vector2(location.X + 4030f, location.Y + 260f), gameTime);
        StoryIntroCutscene.dood2_shadow.Draw(spriteBatch, new Vector2((float) ((double) location.X + 4400.0 - 121.0 + 10.0), (float) ((double) location.Y + 251.0 + 10.0)), gameTime, colorn: new Color?(Color.White * 0.2f));
        if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 10800.0)
          StoryIntroCutscene.dood2sleep.Draw(spriteBatch, new Vector2(location.X + 4400f, location.Y + 200f), gameTime);
        else
          StoryIntroCutscene.dood2wake.Draw(spriteBatch, new Vector2(location.X + 4400f, location.Y + 302f), gameTime);
        StoryIntroCutscene.dood3_shadow.Draw(spriteBatch, new Vector2((float) ((double) location.X + 4600.0 - (double) sbyte.MaxValue + 10.0), (float) ((double) location.Y + 410.0 + 100.0 - 10.0)), gameTime, colorn: new Color?(Color.White * 0.2f));
        if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 10300.0)
          StoryIntroCutscene.dood3sleep.Draw(spriteBatch, new Vector2(location.X + 4600f, location.Y + 410f), gameTime);
        else
          StoryIntroCutscene.dood3wake.Draw(spriteBatch, new Vector2(location.X + 4600f, location.Y + 410f), gameTime);
        StoryIntroCutscene.dood4_shadow.Draw(spriteBatch, new Vector2((float) ((double) location.X + 5000.0 - 110.0), location.Y + 485f), gameTime, colorn: new Color?(Color.White * 0.2f));
        if ((double) this.time < (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + 11200.0)
          StoryIntroCutscene.dood4sleep.Draw(spriteBatch, new Vector2((float) ((double) location.X + 5000.0 - 130.0), location.Y + 385f), gameTime);
        else
          StoryIntroCutscene.dood4wake.Draw(spriteBatch, new Vector2((float) ((double) location.X + 5000.0 - 130.0), location.Y + 385f), gameTime);
        if ((double) this.time > (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft - 200.0)
          StoryIntroCutscene.bato.Draw(spriteBatch, new Vector2(Math.Min((float) ((double) location.X + 0.05000000074505806 * ((double) this.time - ((double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft)) - 100.0), location.X), location.Y + 0.0f), gameTime);
        Recorder.RDraw(spriteBatch, StoryIntroCutscene.lum, location, Color.White * 0.92f);
      }
      spriteBatch.End();
    }

    public UserInputStatus Process(GameTime gameTime, Player player, World world)
    {
      this.time += Convert.ToSingle(gameTime.ElapsedGameTime.TotalMilliseconds);
      if ((double) this.time > (double) this.firstPanEndLocation * (double) this.firstPanSpeed + (double) this.firstPanStillTime + (double) this.timeToRewindLeft + (double) this.afterRewindStillTime + (double) this.secondPanFirstPartLength + (double) this.secondPanSecondPartLength + (double) this.finalShotStillTime + (double) this.cutStillTime)
        CutsceneManager.StartCutscene((ICutscene) new ArchipelagoArrivalCutscene(), (GameTime) null, Game1.player, Game1.world);
      return new UserInputStatus();
    }

    public void Start(GameTime gameTime, Player player, World world)
    {
      StoryIntroCutscene.shocked.ResetAnimation();
      StoryIntroCutscene.runtransition.ResetAnimation();
      StoryIntroCutscene.dood1wake.ResetAnimation();
      StoryIntroCutscene.dood2wake.ResetAnimation();
      StoryIntroCutscene.dood3wake.ResetAnimation();
      StoryIntroCutscene.dood4wake.ResetAnimation();
      StoryIntroCutscene.bato.ResetAnimation();
      StoryIntroCutscene.jumpeggs.ResetAnimation();
      this.time = 0.0f;
    }
  }
}
