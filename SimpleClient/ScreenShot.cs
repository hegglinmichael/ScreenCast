
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

/*
I probably need to make a series of system
calls depending on the OS to take a screenshot

*/
public class PrintScreen {
  
  enum OsType {
    FreeBSD,
    OSX,
    Linux,
    Windows
  }
  private OsType sysType = OsType.FreeBSD;

  /*
   * This method figures out what type of operating system
   * the program is running on.
   */
  public void GetOsType() {
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
      sysType = OsType.Linux;
    } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
      sysType = OsType.OSX;
    } else if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD)) {
      sysType = OsType.FreeBSD;
    } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
      sysType = OsType.Windows;
    } 
  }

  /*
   * This method is meant to direct
   * what system calls must be made
   * depending on the OS.
   */
  public void captureScreen() {
    this.GetOsType();

    switch(sysType) {
      case OsType.Linux:
        break;
      case OsType.OSX:
        break;
      case OsType.Windows:
        break;
      case OsType.FreeBSD:
        break;
      default:
        Console.WriteLine("Failed to capture screen");
    }
  }

  public void captureOSX() {
    //
  }
}

 