# Unity CanvasRenderer Bug (Submesh Crash)

This project reproduces the bug described [here](https://fogbugz.unity3d.com/default.asp?910059_8h267lsffk02668k). In brief, assigning a Mesh containing submeshes to the CanvasRenderer causes the Unity Editor to crash immediately when existing Play Mode and sometimes in Editor Mode. This bug has been observed in Unity 5.4-5.6.

## Usage

1. Launch the project in Unity 5.6.
2. Press the Play button to enter Play Mode.
3. Press the Play button to exit Play Mode. The Editor will crash immediately.

The component responsible for the crash is called "SubmeshGraphic". To observe the default case, 
where only one submesh is assigned to the CanvasRenderer component, set the Submesh Count on the
SubmeshGraphic component to 1. Any value higher than 1 will crash the editor when exiting Play Mode.

#

[![Twitter Follow][twitter-follow-badge]][twitter-url]

[twitter-follow-badge]: https://img.shields.io/twitter/follow/igetgames.svg?style=social&label=Follow%20%40igetgames
[twitter-url]: https://twitter.com/igetgames
