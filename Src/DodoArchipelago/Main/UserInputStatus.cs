
// Type: DodoTheGame.UserInputStatus

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


namespace DodoTheGame
{
  public class UserInputStatus
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

    public UserInputStatus.InputState alt; //?
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
