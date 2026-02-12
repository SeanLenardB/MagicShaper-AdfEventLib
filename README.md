# MagicShaper-AdfEventLib
 
A scripting-based tool for making charts in ADOFAI, including adding decorations, rendering lyrics and more!

## Project structure

Modify `Program.cs` to redirect the program to run your project's main function (by convention that is `AdfVfxProj_<ProjectName>.ProjMain()`)

All projects under the `VfxProjects` folder (or, directory btw) are my past projects. They are all available for your reference.
Also feel free to copy pasta some parts from them if you're stuckk.

Extension classes under the `AdfExtensions` are basically "prefab" functions that you can use. They are very handy for some randomly-generated visuals,
such as track appear / disappear animations and other stuff.

Decorations are implemented in `DecoScene` namespace classes. The design of the decoration system and its implementation is still not set in stone.
Currently the general idea is that decorations belong to reusable scenes and you can apply a scene to a range of tiles in the chart.

If you are new to the project, please refer to the `VfxProjects` folder and look at my past projects **in chronological order**, that is,
look at newer projects first, and then probably older ones. Older ones do not get the good syntaxes and may mislead your code style.
Newer code is better organized and are more terse because the changes I made to the codebase over the course of development.

## Notes

This project is mainly completed, with only a few performance optimizations to be implemented.
However, due to my lack of passion in ADOFAI in general, this project will not receive regular updates.

I will still occasionally make some charts to test out my ideas and experiment with this tool.
