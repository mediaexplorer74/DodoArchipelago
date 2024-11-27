
// Type: DodoTheGame.Program

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
using System;
using System.Text;


namespace DodoTheGame
{
  internal static class Program
  {
    [STAThread]
    private static void Main(string[] args)
    {
      if (args.Length != 0)
      {
        string[] strArray = args[0].Split(':');
        bool debugTools = strArray[1] == "1";
        int int32_1 = Convert.ToInt32(strArray[5]);
        int int32_2 = Convert.ToInt32(strArray[6]);
        int int32_3 = Convert.ToInt32(strArray[7]);
        bool errorReporting = Convert.ToInt32(strArray[8]) == 1;
        if (strArray.Length >= 10)
          Environment.CurrentDirectory = Program.Base64Decode(strArray[9]);
        float sfxVolume = (float) Convert.ToInt32(strArray[4]) / 100f;
        float bgmVolume = (float) Convert.ToInt32(strArray[3]) / 100f;
        using (Game1 game1 = new Game1(Convert.ToInt32(strArray[0]), debugTools, sfxVolume, bgmVolume, int32_1, int32_2, int32_3, errorReporting))
          game1.Run();
      }
      else
      {
        using (Game1 game1 = new Game1(1, true, 1f, 0.13f, 1280, 720, 0, false))
          game1.Run();
      }
    }

    private static string Base64Encode(string plainText)
    {
      return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
    }

    private static string Base64Decode(string base64EncodedData)
    {
      return Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));
    }
  }
}
*/


using DodoTheGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace DodoTheGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
		readonly Game1 _game;

		public GamePage()
        {
            this.InitializeComponent();

			// Create the game.
			var launchArguments = string.Empty;
            _game = MonoGame.Framework.XamlGame<Game1>.Create(launchArguments, 
                Window.Current.CoreWindow, swapChainPanel);
        }
    }
}
