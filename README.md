# UnityPhotoTool

Features
---
- Take screenshots with your desired size and position.
- Count down and flash light effect animation.
- Chroma keying and basic brightness, contrast, and saturation adjustment with the help of [ProcAmp by Keijiro](https://github.com/keijiro/ProcAmp), [HSV Color Picker by judah4](https://github.com/judah4/HSV-Color-Picker-Unity), and [PlayerPrefsX by Eric Haines](http://wiki.unity3d.com/index.php/ArrayPrefs2#C.23_-_PlayerPrefsX.cs).

There are 3 sample scenes in this project:
- **Test_PhotoTool** takes a screenshot and display it on a GUI Raw Image.
- **Test_PhotoAnim** demostrates how to set up simple count down and flash light animation.
- **Test_Keying** applies chroma keying and color adjustment onto textures.
 
## 🌟 While the above scenes demonstrates how I use the scripts individually,  [UnityPhotoBooth](https://github.com/GimChuang/UnityPhotoBooth) is a complete photo booth game using all these scripts together. Please check it out if you need it.


How to Use
---
### PhotoTool.cs
#### Settings in the Inspector
- Set `startX`, `startY`, `width`, and `height` for the region you want to take screenshots with. You can view the region you've set by checking `Debug On GUI`.
#### Scripting Reference
- `Init()` initializes a *Texture2D* for screenshots with startX, startY, width, and height. There's also an overload function `Init(int _startX, int _startY, int _width, int _height)` for overriding the settings.
- `TakePhoto()` takes a screenshot and apply it to `tex2d_photo`.
- `OnPhotoTaken(tex2d_photo)` is called after the screenshot is taken.

### PhotoAnimController.cs
#### Settings in the Inspector
- Drag some *Transform* components into the  `countDownElements` array. These *GameObjects* will be used in the countdown animation, which is driven by a [DOTween](http://dotween.demigiant.com/) Sequence.
- Type in `duration_countDown` (in seconds). It's the duration of each `countDownElements`'s scaling animation.
- Assign a UI Image to `Img_shot`. It'll be used in a "flash" animation driven by DOTween, too. `duration_shot` is the duration of the animation.
- (Optional) You can also assign an *AudioSource* to `audio_shot` and it will be played with the flash animation.

#### Scripting Reference
- `Init()` MUST be called to initialize the DOTween tweeners/sequences.
- `PlayCountDownAnim()` plays the countdown animation. `OnCountDownFinish()` is called when the  animation finishes.
- `PlayShotAnim()` plays the flash light animation (along with the `audio_shot` sound effect if it's assigned). `OnShotFinish()` is called when the animation finishes.

### KeyingColorPickers.cs, KeyingSliders.cs, and KeyingToggle.cs

These scripts are used to control values on materials using  [ProcAmp](https://github.com/keijiro/ProcAmp) shader.

- Assign a material using *Klak/Video/ProcAmp* shader to `keyingMaterial`
- Type in `propertyName` eg. _KEYING, _Brightness. They are internally used by some functions such as  [Material.SetFloat](https://docs.unity3d.com/2018.2/Documentation/ScriptReference/Material.SetFloat.html) and [PlayerPref.SetFloat](https://docs.unity3d.com/2018.2/Documentation/ScriptReference/PlayerPrefs.SetFloat.html).
- (Optional) If `btn_resetDefault` is assigned, value of the color picker, sliders, and toggle will be set to default when `btn_resetDefault` is pressed.
- (Optional) There is a **Panel-Keying** *Prefab* inside *gm_PhotoTool/Prefab/Panel-Keying*. It's a *UI Panel* which already contains a color picker, a toggle, and sliders. You can put it onto a *UI Canvas* and then set up values followng steps above. 


Notes
---
This project uses Git submodule [gm_PhotoTool](https://github.com/GimChuang/gm_PhotoTool). If you want to clone this reposiory, you need to call
```
git clone --recurse-submodules <URL>
``` 


License
---
MIT


Acknowledgement
---
This project uses [ProcAmp by Keijiro](https://github.com/keijiro/ProcAmp) and [HSV Color Picker by judah4](https://github.com/judah4/HSV-Color-Picker-Unity) to achieve chroma keying. Also uses  [PlayerPrefsX by Eric Haines](http://wiki.unity3d.com/index.php/ArrayPrefs2#C.23_-_PlayerPrefsX.cs) to save colors with *PlayerPrefs*! 🙇‍♀️
