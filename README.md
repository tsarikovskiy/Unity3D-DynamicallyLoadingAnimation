# DynamicallyLoadingAnimation
 Unity3D example project

## This example will help you with optimization memory usage in Unity3D engine.
It load and unload sprites from memeory with animation clips at runtime, that very helpful!

There's two simple methods:

- for loading animation:
```C#
animationLoadManager.LoadAnimation(animationClipName, boolName);
	```
	
	- for unloading animation from memory when animation is done
	
	```C#
	animationLoadManager.UnloadPreviousLoadAnimation();
	```

	
