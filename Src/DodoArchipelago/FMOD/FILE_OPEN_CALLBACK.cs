﻿
// Type: FMOD.FILE_OPEN_CALLBACK

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;


namespace FMOD
{
  public delegate RESULT FILE_OPEN_CALLBACK(
    StringWrapper name,
    ref uint filesize,
    ref IntPtr handle,
    IntPtr userdata);
}
