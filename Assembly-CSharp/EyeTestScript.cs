using UnityEngine;

public class EyeTestScript : MonoBehaviour
{
	public Animation MyAnimation;

	private void Start()
	{
		MyAnimation["moodyEyes_00"].layer = 1;
		MyAnimation.Play("moodyEyes_00");
		MyAnimation["moodyEyes_00"].weight = 1f;
		MyAnimation.Play("moodyEyes_00");
	}
}
