# AdbMonkey-DotNet
Want to simpulate fast input to any android device using ```adb```? The AdbMonkey-DotNet is a small dotnet library will enable you to simulate touch and tap input to android device using adb.
AdbMonkey-DotNet is a .NET library that allows .NET applications to simulate touch and keyboard input to Android devices. It provides a .NET implementation of the input protocol of android shell command ``` /dev/input/eventx ```
 ie.. the Linux input stream
####Prerequisites
- Windows Operating System
- .NET Framework
- Android SDK
- [SharpAdbClient Library](https://github.com/quamotion/madb)

####Simpulating Tap
 
 ```
Monkey monkey;
monkey = new Monkey(selectedDevice, new InputEvent(0));
monkey.Down((UInt32)50,(UInt32)80);
Thread.Sleep(100);
monkey.Up();
 ```
####Simpulating Swipe
```  
Monkey monkey;
monkey = new Monkey(selectedDevice, new InputEvent(0));
monkey.Down((UInt32)50, (UInt32)0);
Thread.Sleep(300);
monkey.SetXY((UInt32)50, (UInt32)100);
monkey.Up();
```

####Monkeying Touch Event
 
```
 Boolean IsDown = false;
private void pictureBox1_MouseUp(object sender, MouseEventArgs e){
  IsDown = false;
  monkey.Up();
}
 private void pictureBox1_MouseDown(object sender, MouseEventArgs e){
  IsDown = true;
  monkey.Down((UInt32)e.X, (UInt32)e.Y);
}
private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
  if (IsDown)
    monkey.SetXY((UInt32)e.X, (UInt32)e.Y);
}
 ```
