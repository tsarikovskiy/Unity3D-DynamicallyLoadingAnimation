# Dynamically Loading Animation
 Unity3D example project

## This example will help you with optimization memory usage in Unity3D engine.
AnimationLoadManager script load and unload sprites from memory with animation clips at runtime, that very helpful!

There's two simple public methods:

- for loading animation:
``` csharp
animationLoadManager.LoadAnimation(animationClipName, boolName);
```
	
- for unloading animation from memory when animation is done
	
```csharp
animationLoadManager.UnloadPreviousLoadAnimation();
```

## Contact

if you have any question feel free to contact me https://twitter.com/s_tsarikovskiy
