﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

namespace DodoTheGame
{
   
    sealed partial class App : Application
{
    static string deviceFamily;

  
    public App()
    {
        this.InitializeComponent();
        this.Suspending += OnSuspending;

            //API check to ensure the "RequiresPointerMode" property exists, ensuring project is running on build 14393 or later
            //if (Windows.Foundation.Metadata.ApiInformation.IsPropertyPresent(
            //    "Windows.UI.Xaml.Application", "RequiresPointerMode"))
            //{
            //If running on the Xbox, disable screen pointer
            //    if (IsXbox())
            //    {
            //        Application.Current.RequiresPointerMode = ApplicationRequiresPointerMode.WhenRequested;
            //    }
            //}

            //RnD
            Application.Current.RequiresPointerMode = ApplicationRequiresPointerMode.Auto;
    }

    /// <summary>
    /// Detection code in Windows 10 to identify the platform it is being run on
    /// This function returns true if the project is running on an XboxOne
    /// </summary>
    public static bool IsXbox()
    {
        if (deviceFamily == null)
            deviceFamily = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily;

        return deviceFamily == "Windows.Xbox";
    }

   
    protected override async void OnLaunched(LaunchActivatedEventArgs e)
    {
            //ApplicationView.GetForCurrentView().SetDesiredBoundsMode(
            //    ApplicationViewBoundsMode.UseCoreWindow);

            if (await ApplicationData.Current.LocalFolder.TryGetItemAsync("slot0.dodomemory") == null)
            {
                StorageFile databaseFile = await Package.Current.InstalledLocation.GetFileAsync("Content\\slot0.dodomemory");
                await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);
            }

            Frame rootFrame = Window.Current.Content as Frame;

        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if (rootFrame == null)
        {
            // Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = new Frame();

            rootFrame.NavigationFailed += OnNavigationFailed;

            if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                //TODO: Load state from previously suspended application
            }

            // Place the frame in the current Window
            Window.Current.Content = rootFrame;
        }

        if (rootFrame.Content == null)
        {
            // When the navigation stack isn't restored navigate to the first page,
            // configuring the new page by passing required information as a navigation
            // parameter
            rootFrame.Navigate(typeof(GamePage), e.Arguments);
        }
        // Ensure the current window is active
        Window.Current.Activate();
    }

    /// <summary>
    /// Invoked when Navigation to a certain page fails
    /// </summary>
    /// <param name="sender">The Frame which failed navigation</param>
    /// <param name="e">Details about the navigation failure</param>
    void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
        throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
    }

    /// <summary>
    /// Invoked when application execution is being suspended.  Application state is saved
    /// without knowing whether the application will be terminated or resumed with the contents
    /// of memory still intact.
    /// </summary>
    /// <param name="sender">The source of the suspend request.</param>
    /// <param name="e">Details about the suspend request.</param>
    private void OnSuspending(object sender, SuspendingEventArgs e)
    {
        var deferral = e.SuspendingOperation.GetDeferral();
        //TODO: Save application state and stop any background activity
        deferral.Complete();
    }
}
}