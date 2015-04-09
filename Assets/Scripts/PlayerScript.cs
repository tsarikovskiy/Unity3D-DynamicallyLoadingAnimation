using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	AnimationLoadManager animationLoadManager;

	// Use this for initialization
	void Start ()
	{
		animationLoadManager = GetComponent<AnimationLoadManager>();

		//Load animation clip after 3 seconds
		Invoke("LoadAnimataionClip", 3);

		//Unload Animation Clip after 10 seconds
		Invoke("UnloadAnimationCLip", 10);
	}
	
	void LoadAnimataionClip () 
	{
		animationLoadManager.LoadAnimation("Run", null);
	}

	void UnloadAnimationCLip()
	{
		animationLoadManager.UnloadPreviousLoadAnimation();
	}
}
