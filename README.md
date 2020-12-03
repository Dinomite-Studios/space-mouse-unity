# Space Mouse Unity

3DConnexion Space Mouse driver for Unity3D.

This driver lets you fly around your scene and allows you to move stuff around.  
You can also use it at runtime via scripting.

The default mode is **Fly** mode and when you're flying around, this driver keeps your horizon horizontal.  
So you don't have to worry about ending up upside down, just go where you want and get some work done.  
To comfortably navigate large areas and minute details, you can easilly switch between 3 customizable sensitivity presets.  
To move stuff around, you can use 2 modes: Telekinesis and GrabMove.  
In **Telekinesis** mode, you can move the stuff you selected with the SpaceNavigator, while your camera stays put.  
(this mode can be operated in Camera-, World-, Parent- and Local coordinates)  
In **GrabMove** mode the stuff will be linked to your camera so you can take it with you and position it where you want.  
Translation can be snapped to a grid and rotation can be angle-snapped.  

## Platform support

This driver supports both PC and Mac.

## Known bugs and limitations

- Grab Mode only works in the camera coordinate system (sorry, I couldn't get my head around the quaternion math of manipulating in one coordinate system while constraining in another)

## The goods

- The package also contains a couple of runtime samples:
  - Fly around.unity: Fly around with a sphere while knocking over some cubes.
  - Folow curve.unity: Make your torus follow the curve, but don't touch it!

## Installation

- Install [3DConnexion driver](http://www.3dconnexion.com/service/drivers.html) and make sure it is running
- Import the package into your Unity project via `Unity Package Manager Window` -> `Add package from git URL...`
- Open the SpaceNavigator window from the pull-down menu `Window` -> `SpaceNavigator`

## Credits

- Thanks to [Patrick Hogenboom](https://github.com/PatHightree) who created the original plugin
- Thanks to Stephen Wolter for further refinement to the mac drift fix. 
- Thanks to Enrico Tuttobene for contributing the mac drift fix.
- Thanks to Kieron Lanning for implementing navigation at runtime.
- Big thanks to Chase Cobb for motivating me to implement the mac version.
- Thanks to Manuela Maier and Dave Buchhoffer (@vsaitoo) for testing and development feedback.
- Thanks to Ewoud Wijma for loaning me the Hackingtosh for building the Mac port.
- Quaternion math by Minahito
  http://sunday-lab.blogspot.nl/2008/04/get-pitch-yaw-roll-from-quaternion.html
