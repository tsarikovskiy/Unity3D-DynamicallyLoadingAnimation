using UnityEngine;
using System.Collections;

public class AnimationLoadManager : MonoBehaviour 
{
	AnimatorOverrideController overrideController;
	static string prevLoadAnim;
	Animator animator;
	ResourceRequest request;
	AnimatorStateInfo[] layerInfo;

	// Use this for initialization
	void Start() 
	{
		animator	       = GetComponent<Animator>();
		overrideController = animator.runtimeAnimatorController as AnimatorOverrideController;
	}

	IEnumerator LoadAnimClip(string clipName, string boolName)
	{
		request = Resources.LoadAsync("Animations/" + clipName);

		yield return request;

		AnimationClip animClip = request.asset as AnimationClip;
		
		overrideController[clipName + " Empty"] = animClip;

		// Push back state
		for (int i = 0; i < animator.layerCount; i++)
		{
			animator.Play(layerInfo[i].nameHash, i, layerInfo[i].normalizedTime);
		}

		// Force an update
		animator.Update(0.0f);

//		animator.SetBool(boolName, true);
	}

	/// <summary>
	/// Load Animation Clip
	/// </summary>
	 
	public void LoadAnimation(string animationName, string animationBoolName)
	{
		animator = GetComponent<Animator>();

		//Save current state
		layerInfo = new AnimatorStateInfo[animator.layerCount];
		
		for (int i = 0; i < animator.layerCount; i++)
		{
			layerInfo[i] = animator.GetCurrentAnimatorStateInfo(i);
		}

		// Start Load Animation Clip
		StartCoroutine(LoadAnimClip(animationName, animationBoolName));

		prevLoadAnim = animationName;
	}	
	
	public void UnloadPreviousLoadAnimation()
	{
		for (int i = 0; i < animator.layerCount; i++)
		{
			layerInfo[i] = animator.GetCurrentAnimatorStateInfo(i);
		}
		
		overrideController[prevLoadAnim + " Empty"] = null;
		Resources.UnloadUnusedAssets();
		
		for (int i = 0; i < animator.layerCount; i++)
		{
			animator.Play(layerInfo[i].nameHash, i, layerInfo[i].normalizedTime);
		}
		
		// Force an update
		animator.Update(0.0f);
	}
}
