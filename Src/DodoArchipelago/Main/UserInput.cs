
// Type: DodoTheGame.UserInput

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.GUI;
using GameManager;
using Microsoft.Xna.Framework.Input;
using System;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;


namespace DodoTheGame
{
  internal class UserInput
  {
    public const int INPUT_KEYBOARD = 1;
    public const int INPUT_JOYCON = 2;
    public const int INPUT_WIIMOTE = 3;
    public int inputMethod;
    public bool locked;
    public bool inputError;
    public int deviceIncrement;
    private UserInputStatus wiimoteUIS;
    private UserInputStatus lastUIS;
    private string keyboardLang;
    //private Controller Controller;

    public UserInput(int inputMthd)
    {
      //Controller = new Controller(); // multi-controller init

      //Controller.Update();

      this.inputMethod = inputMthd;

      this.lastUIS = new UserInputStatus();

      this.keyboardLang = "eng";//CultureInfo.GetCultureInfo(
                               //(int) (ushort)
                               //((int) UserInput.GetKeyboardLayout(0U) >> 16))
                               //.ThreeLetterISOLanguageName;
    }

    //[DllImport("user32.dll")]
    //private static extern IntPtr GetKeyboardLayout(uint idThread);

    public UserInputStatus GetInput()
    {
      
      UserInputStatus input = new UserInputStatus();
      if (this.inputMethod != 1)
        throw new Exception("Unknown input method in class UserInput");

      KeyboardState state = Keyboard.GetState();
      
      //if (this.keyboardLang == "fra")
      //{
      //  if (state.IsKeyDown(Keys.Z))
      //    input.moveUp = 1f;
      //  if (state.IsKeyDown(Keys.S))
      //    input.moveDown = 1f;
      //  if (state.IsKeyDown(Keys.Q))
      //    input.moveLeft = 1f;
      //  if (state.IsKeyDown(Keys.D))
      //    input.moveRight = 1f;
      //  if (state.IsKeyDown(Keys.E))
       //   input.bike = UserInputStatus.InputState.Held;
      //  if (state.IsKeyDown(Keys.A))
      //    input.inventory = UserInputStatus.InputState.Held;
      //}
      //else
      //{
        /*
        if (state.IsKeyDown(Keys.W))
          input.moveUp = 1f;
        if (state.IsKeyDown(Keys.S))
          input.moveDown = 1f;
        if (state.IsKeyDown(Keys.A))
          input.moveLeft = 1f;
        if (state.IsKeyDown(Keys.D))
          input.moveRight = 1f;
        if (state.IsKeyDown(Keys.E))
          input.bike = UserInputStatus.InputState.Held;
        if (state.IsKeyDown(Keys.Q))
          input.inventory = UserInputStatus.InputState.Held;
        */
        if (Game1.Controller.Is.MoveUp)
           input.moveUp = 1f;
        if (Game1.Controller.Is.MoveDown)
          input.moveDown = 1f;
        if (Game1.Controller.Is.MoveLeft)
            input.moveLeft = 1f;
        if (Game1.Controller.Is.MoveRight)
          input.moveRight = 1f;

        if (state.IsKeyDown(Keys.E))
            input.bike = UserInputStatus.InputState.Held;

        if (state.IsKeyDown(Keys.Q))
            input.inventory = UserInputStatus.InputState.Held;
        //}

      if (Game1.Controller.Is.SpaceBar)//(state.IsKeyDown(Keys.Space) || state.IsKeyDown(Keys.Enter))
        input.spacebar = UserInputStatus.InputState.Held;

      if (Game1.Controller.Is.Escape)//(state.IsKeyDown(Keys.Escape))
        input.escape = UserInputStatus.InputState.Held;

      if (Game1.Controller.Is.Inventory)//(state.IsKeyDown(Keys.Escape))
       input.inventory = UserInputStatus.InputState.Held;

      if (!GUIManager.currentHUDs.OfType<EditorGUI>().Any<EditorGUI>())
      {
        if (Game1.Controller.InteractUp)//(state.IsKeyDown(Keys.Up))
          input.interactUp = UserInputStatus.InputState.Held;

        if (Game1.Controller.InteractDown)//(state.IsKeyDown(Keys.Down))
          input.interactDown = UserInputStatus.InputState.Held;

        if (Game1.Controller.InteractLeft)//(state.IsKeyDown(Keys.Left))
          input.interactLeft = UserInputStatus.InputState.Held;

        if (Game1.Controller.InteractRight)//(state.IsKeyDown(Keys.Right))
          input.interactRight = UserInputStatus.InputState.Held;
      }

      if (state.IsKeyDown(Keys.LeftAlt) || state.IsKeyDown(Keys.RightAlt))
        input.alt = UserInputStatus.InputState.Held;
      
      if (state.IsKeyDown(Keys.M))
        input.bicycle = UserInputStatus.InputState.Held;
      
      if ((double) input.moveUp == 1.0 && (double) input.moveLeft == 1.0 
         && (double) input.moveRight == 0.0 && (double) input.moveDown == 0.0)
      {
        input.moveUp = Convert.ToSingle(Math.Sqrt(2.0) / 2.0);
        input.moveLeft = Convert.ToSingle(Math.Sqrt(2.0) / 2.0);
      }
      else if ((double) input.moveUp == 1.0 && (double) input.moveRight == 1.0
                && (double) input.moveDown == 0.0 && (double) input.moveLeft == 0.0)
      {
        input.moveUp = Convert.ToSingle(Math.Sqrt(2.0) / 2.0);
        input.moveRight = Convert.ToSingle(Math.Sqrt(2.0) / 2.0);
      }
      else if ((double) input.moveDown == 1.0 && (double) input.moveLeft == 1.0 
                && (double) input.moveUp == 0.0 && (double) input.moveRight == 0.0)
      {
        input.moveDown = Convert.ToSingle(Math.Sqrt(2.0) / 2.0);
        input.moveLeft = Convert.ToSingle(Math.Sqrt(2.0) / 2.0);
      }
      else if ((double) input.moveDown == 1.0 && (double) input.moveRight == 1.0 
                && (double) input.moveUp == 0.0 && (double) input.moveLeft == 0.0)
      {
        input.moveDown = Convert.ToSingle(Math.Sqrt(2.0) / 2.0);
        input.moveRight = Convert.ToSingle(Math.Sqrt(2.0) / 2.0);
      }
      this.inputError = false;
      if (this.locked)
      {
        input.moveUp = 0.0f;
        input.moveDown = 0.0f;
        input.moveLeft = 0.0f;
        input.moveRight = 0.0f;
      }

      if (this.lastUIS.escape == UserInputStatus.InputState.Released
                && input.escape == UserInputStatus.InputState.Held)
        input.escape = UserInputStatus.InputState.Pressed;

      if (this.lastUIS.spacebar == UserInputStatus.InputState.Released 
                && input.spacebar == UserInputStatus.InputState.Held)
        input.spacebar = UserInputStatus.InputState.Pressed;

      if (this.lastUIS.inventory == UserInputStatus.InputState.Released 
                && input.inventory == UserInputStatus.InputState.Held)
        input.inventory = UserInputStatus.InputState.Pressed;

      if (this.lastUIS.bike == UserInputStatus.InputState.Released 
                && input.bike == UserInputStatus.InputState.Held)
        input.bike = UserInputStatus.InputState.Pressed;

      if (this.lastUIS.bicycle == UserInputStatus.InputState.Released
                && input.bicycle == UserInputStatus.InputState.Held)
        input.bicycle = UserInputStatus.InputState.Pressed;

      if (!GUIManager.currentHUDs.OfType<EditorGUI>().Any<EditorGUI>())
      {
        if (this.lastUIS.interactRight == UserInputStatus.InputState.Released 
                    && input.interactRight == UserInputStatus.InputState.Held)
          input.interactRight = UserInputStatus.InputState.Pressed;

        if (this.lastUIS.interactLeft == UserInputStatus.InputState.Released
                    && input.interactLeft == UserInputStatus.InputState.Held)
          input.interactLeft = UserInputStatus.InputState.Pressed;

        if (this.lastUIS.interactUp == UserInputStatus.InputState.Released 
                    && input.interactUp == UserInputStatus.InputState.Held)
          input.interactUp = UserInputStatus.InputState.Pressed;

        if (this.lastUIS.interactDown == UserInputStatus.InputState.Released
                    && input.interactDown == UserInputStatus.InputState.Held)
          input.interactDown = UserInputStatus.InputState.Pressed;
      }

      if (this.lastUIS.alt == UserInputStatus.InputState.Released 
                && input.alt == UserInputStatus.InputState.Held)
        input.alt = UserInputStatus.InputState.Pressed;

      this.lastUIS = input;
      return input;
    }
  }
}
