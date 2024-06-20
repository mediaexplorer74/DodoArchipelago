// Decompiled with JetBrains decompiler
// Type: DodoTheGame.UserInputStatus
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe


namespace DodoTheGame
{
  internal class UserInputStatus
  {
    public float moveLeft;
    public float moveRight;
    public float moveUp;
    public float moveDown;
    public UserInputStatus.InputState interactUp;
    public UserInputStatus.InputState interactDown;
    public UserInputStatus.InputState interactLeft;
    public UserInputStatus.InputState interactRight;
    public UserInputStatus.InputState escape;
    public UserInputStatus.InputState spacebar;
    public UserInputStatus.InputState inventory;
    public UserInputStatus.InputState alt;
    public UserInputStatus.InputState bike;
    public UserInputStatus.InputState bicycle;

    public enum InputState
    {
      Released,
      Held,
      Pressed,
    }
  }
}
