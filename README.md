# Kana Swap
> Kana Swap is a gamified application for desktop and mobile platforms to aid with the learning of Japanese hiragana and katakana character sets.

[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/KasumiL5x/kanaswap/raw/master/LICENSE)

The core idea of Kana Swap is memorization through organization; when shuffled, the user must reorganize the characters into their correct location. The grid of characters is interactive via touch or mouse click. The set of icons in the top-right manipulate the grid or provide context-sensitive interactions. For instance, toggling between hiragana and katakana display, shuffling and resetting the characters on the board, and even viewing the stroke order of the selected character in the grid.

![Shuffle Characters](https://raw.githubusercontent.com/KasumiL5x/kanaswap/master/docs/kanaswap-1.gif)

In addition, animations of how to correctly draw the characters are ideal to accompany writing practice.

![Draw Characters](https://raw.githubusercontent.com/KasumiL5x/kanaswap/master/docs/kanaswap-2.gif)

## Interesting Extras
One of the most interesting problems solved was the creation and rendering of line segments used in the stroke viewing. For rendering, LineRenderer was initially used, but it quickly became apparent that it had too many limitations and not enough flexibility. Instead, a custom triangle-list GL renderer was created. The more interesting side is that of how the triangle lists were generated in an editor-friendly way, especially considering there is a total of 92 characters to create stroke order animations for.

![Bezier](https://raw.githubusercontent.com/KasumiL5x/kanaswap/master/docs/kanaswap-bezier.png)

In the above image, the hierarchy panel shows how character strokes were set up. The system has three levels of GameObjects. The first layer is the GameObject for the character itself (e.g. a, i, u), which contains a script that controls the animation timing of the strokes the character contains. The second layer is each child GameObject (e.g. 1, 2, 3), each of which represent a single stroke. These are automatically handled by the parent GameObject’s animation script. They also contain a script that dynamically generates bezier curves, as well as a script for generating triangle strips for rendering. The third layer is child GameObjects of each stroke GameObject. These define, in order, the points of which the bezier curve will go through. Handles are automatically generated to ensure that the generated curve goes through each of the points. Handles can of course be placed manually, but for this application, automatic generation was suitable. The automatically generated bezier curves are sampled for both position and tangent data, which is use to expand the line into a thickened triangle list for rendering. The green spheres shown in the image are a simplified representation of the generated curve passing through all given GameObjects. This makes creating the curves very simple. They can even be edited in runtime, for fine tweaks.