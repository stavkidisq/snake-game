# snake-game
[![Last commit](https://img.shields.io/github/last-commit/Stavkidisq/SnakeGame)]()
[![Commit activity](https://img.shields.io/github/commit-activity/y/Stavkidisq/SnakeGame)]()
[![Github All Releases](https://img.shields.io/github/downloads/Stavkidisq/SnakeGame/total.svg)]()
[![Build Status](https://travis-ci.com/username/projectname.svg?branch=master)](https://travis-ci.com/Stavkidisq/SnakeGame)
[![Code Size](https://img.shields.io/github/languages/code-size/Stavkidisq/SnakeGame)]()
[![Repo Size](https://img.shields.io/github/repo-size/Stavkidisq/SnakeGame)]()
[![GitHub watchers](https://img.shields.io/github/watchers/Stavkidisq/SnakeGame?style=social)]()
[![Twitter follow](https://img.shields.io/twitter/follow/stavkidisq?style=social)]()
## :snowflake:Brief description of the program.
**Snake-game** is based on the fact that the player controls a character (a snake), on a field fenced with walls. Objects called apples are spawned on it. If the snake eats an apple, its length will increase. Also, the game keeps an account of the apples eaten, for one apple eaten, the player is awarded one point. If the snake's head collides with its tail or with a wall, then the game is over.
<br>
<br>
<div align="center">
  <img src="https://user-images.githubusercontent.com/57217014/146670067-dd0d91a4-6984-40ba-b646-f0d19ce4718c.png" alt="Screen"><br>
  <em>Picture 1. A screenshot from the game itself.</em>
</div>
<br>
<h2> :snowflake:Brief description of the program code.</h2>

### :snowman:Start the program using GameOptions?
The program is started by creating an instance of the `GameOptions` class. After that, the constructor is called, which accepts `SnakeModel`, `AppleModel` and `SurfaceModel` objects. For example:

```C#
List<PointModel> points = new List<PointModel>() { new PointModel(6, 2), new PointModel(6, 3), new PointModel(6, 4) };
new GameOptions(new SnakeModel(points, 300), new AppleModel('$'), SurfaceModel(20, 20));
```
In this example, a list was created from instances of the `PointModel` class. Next, the constructor of the `GameOptions` class was called. Next, let's look at each class separately.

### :snowman:What happens in the PointModel class?
The `PointModel` class is the basis for organizing the snake's work, since the snake consists of a list of instances of this class. Consider the constructor of this class, it takes the position of `int x` and `int y` of the object on the playing field. Below is the constructor of the PointModel class itself:

```C#
public PointModel(int x, int y)
{
  // Here is code...
}
```

### :snowman:What happens in the AppleModel class?

Consider the constructor of the `PointModel` class. It accepts it accepts only one variable, namely char skin, which is responsible for displaying the apple on the field. Below is the code of the constructor:

```C#
public AppleModel(char skin)
{
  // Here is code...
}
```

### :snowman:What happens in the SurfaceModel class?

The `SurfaceModel` class is responsible for the operation of the playing field. The constructor of this class accepts `int width` and `int height`, which determine its size. Below is the code of the `SurfaceModel` constructor:

```C#
public SurfaceModel(int width, int height)
{
  // Here is code...
}
```

### :snowman:What happens in the SnakeModel class?

And the last class that I would like to consider is `SnakeModel`, the class that is responsible for the snake itself in the game. Its constructor accepts two parameters, namely: `List<PointModel> snakeLine` and `int speed`. The first parameter is responsible for the positioning of the snake itself, and the second for its speed. Below is the code of the `SnakeModel` class constructor:

```C#
public class SnakeModel(List<PointModel> snakeLine, int speed)
{
  // Here is code...
}
```

### :snowman:The сonsultion.

Above was a brief information on how the program works.
