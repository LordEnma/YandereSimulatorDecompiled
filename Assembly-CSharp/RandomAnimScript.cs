using UnityEngine;

public class RandomAnimScript : MonoBehaviour
{
	public string[] AnimationNames;

	public string CurrentAnim = string.Empty;

	private void Start()
	{
		PickRandomAnim();
		GetComponent<Animation>().CrossFade(CurrentAnim);
	}

	private void Update()
	{
		AnimationState animationState = GetComponent<Animation>()[CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			PickRandomAnim();
		}
	}

	private void PickRandomAnim()
	{
		CurrentAnim = AnimationNames[Random.Range(0, AnimationNames.Length)];
		GetComponent<Animation>().CrossFade(CurrentAnim);
	}
}
