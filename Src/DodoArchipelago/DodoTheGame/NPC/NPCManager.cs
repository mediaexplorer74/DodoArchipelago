// Decompiled with JetBrains decompiler
// Type: DodoTheGame.NPC.NPCManager
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using System;


namespace DodoTheGame.NPC
{
  internal static class NPCManager
  {
    private static int LastSpawnedNPC;

    internal static void Update(World world, GameTime gameTime)
    {
      world.NPCs.ForEach((Action<INPC>) (n => n.Update(gameTime, world)));
    }

    public static void SpawnDodo(World world, Vector2 SpawnPosition)
    {
      if (NPCManager.LastSpawnedNPC >= Game1.NPCs.Count)
        NPCManager.LastSpawnedNPC = 0;
      Game1.NPCs[NPCManager.LastSpawnedNPC].Location = SpawnPosition - new Vector2((float) (Game1.NPCs[NPCManager.LastSpawnedNPC].IdleSprite.Width / 2), (float) Game1.NPCs[NPCManager.LastSpawnedNPC].IdleSprite.height) - new Vector2((float) (85 * NPCManager.LastSpawnedNPC), (float) (-15 * NPCManager.LastSpawnedNPC));
      world.NPCs.Add(Game1.NPCs[NPCManager.LastSpawnedNPC]);
      ++NPCManager.LastSpawnedNPC;
    }
  }
}
