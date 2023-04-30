# Flowers for Algernon

## Overview and Running the Game
Flowers for Algernon is a short maze game built in Unity based on the novel by the same name.
As the game is built in Unity, it's not possible to build it without the need for an IDE. As such, we've
provided two options to run it:

1. For Mac users, the `Algernon-macOS.app` should be able to be run natively.
2. For anyone else, you should be able to visit [this link](https://play.unity.com/mg/other/flowers-for-algernon) to access it on Unity Play and play in your browser on a computer.

The game can be played using wasd on your keyboard, with esc used to pause the game. Movement can also be done using a
paired game controller, and this "feels" better in my opinion, so I'd recommend pairing a PS5 controller or something
similar to your computer to play with the joystick. Note that you'll still have to click on menu buttons.

The game supports saving progress, so you should be able to close the game, re-open it, and load the save game with the "Load Game" button.
> Note: This should work on macOS, but due to us not being able to control browser cache, we are unsure if this will work 100% of the time in the browser. Be sure to allow all cookies and not to clear your browser data.

## Collaboration

We used GitHub for source control and to share code between group members. We have four group members, and here is how each contributed:

- Ethan Humphrey: Project Manager. Set up the GitHub, managed communication between members, etc. Code-wise, he developed the Maze Generation algorithm, the save data manager, the unit tests, and designed the levels/level features.
- Ziyang Wang: Designed the overall story of the game and how the mechanics should interact together. Implemented the menus of the game, including the main menu, pause menu, win/lose menu, as well as the timer and the initial maze prototype.
- Genfu Liu: Worked on some of the art of the game, including backgrounds.
- Deep Parekh: Worked on the test document and helped with player testing/system testing.


## Code
The code can be opened in the Unity editor if you'd like. Script files are written in C# and hosted in the ``/Assets/Scripts/` sub-folder. Some logic is handled in Unity Scene files or by the Unity engine itself.

## Testing
Tests are located in the `/Assets/Tests/` sub-folder. We used the built-in NUnit testing framework, and ensured that our script files were written in a way that we could test the classes without initializing the whole Unity scene (the benefit of using a good architecture!).

## Documentation
We didn't write much documentation, but we aimed to make sure the code was readable. Documentation is important, but equally important is your code being self-documenting.

