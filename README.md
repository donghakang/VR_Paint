# Drawing Pad
Yehyun Ryu, Dongha Kang

## Introduction
This **Drawing Pad** is focused on 3D User Interface. Mainly this project is about implemented Diegetic Graphical Menu and
1-DOF Menu. This project is not about how well we copied the original software called 'Tilt Brush'.

## Summary:
Drawing Pad is a virtual painting experience similar to Google Tiltbrush.
The player starts with two controllers, one on each hand. On the right hand, you have a ball that you can use
to paint in 3D space. By pressing down on the Secondary Hand Trigger (button on the side), you start painting.
On the left controller, you have the settings for painting that we call "palette". You can interact with the
palette using the black laser pointer and the Secondary Index Trigger (button pressed with the index finger).
As for the palette, there are four sides. You can rotate the sides by pressing the Y button on the left
controller. The "Color" menu controls the color of the paint, "Size" menu controls the stroke width, "Texture"
changes the material that renders the stroke, and the "Emissive" controls whether emission should be added to
the material. All changes to the menu is reflected on the ball on the right hand to make it intuitive for
players. Finally, players can move around the environment using the right joystick with view-directed
steering and snap turn. As for advanced techniques, "Diegetic Graphical Menu" was implemented as shown in
the palette settings and "1-DOF Menu" was implemented as the sides within the palette.


## Idea
So first our idea. We actually got our idea from Google Tilt Brush. In case you don’t know, it is a virtual painting experience that Google has put out and the image on the right is how it works. A person has a set of tools and they are able to select and paint in 3D space using a virtual reality headset. For our project, we hope to do something similar but instead of painting in complete 3D, we are planning to paint on surfaces of 3D objects for simplicity sake.

## Diegetic Graphical Menu
So the focus of this project will mostly be on the menus. We want this to be as intuitive and easy-to-use for our users as possible. To do this, we are planning to implement a diegetic graphical menu as one of our advanced techniques. This would mean that the menu would exist in 3D space instead of existing outside the virtual world and this would allow a more immersive experience. Right now, some ideas we have for this is to attach the menu to the user’s hand similar to how a painter would have his/her palette on his/her left hand.

<img src="https://samwongpic.files.wordpress.com/2014/06/metro2033_ui.jpg" width="50%" height="50%">

## 1-DOF Menu
Finally, our second advanced technique would go along with that idea as we are planning to create a 1 degree of freedom menu. So just like the picture on the slide, we hope to create a virtual ring or wristband that wraps around the user’s nondominant hand that allows users to swap between tools when they paint.

<img src="https://drive.google.com/file/d/1QJ5uWh0EwyPb-0fiwfIOY8OtKoAW-AhH/view?usp=sharing" width="50%" height="50%">

### 3rd Party Assets:
- Low Poly Environment Pack (Korveen),
- ControllerLocomotion.cs from Homeworks,
- YouTube Tutorial on VR Painting (https://www.youtube.com/watch?v=eMJATZI0A7c)
- Lava Texture (https://assetstore.unity.com/packages/2d/textures-materials/stylized-lava-texture-153161)
- Rainbox Texture (https://www.rgbstock.com/photo/oPHNM50/Rainbow+Texture)
