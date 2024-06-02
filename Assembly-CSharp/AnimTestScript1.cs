using UnityEngine;

public class AnimTestScript1 : MonoBehaviour
{
	public Transform Head;

	public Animation Anim;

	public string AnimName;

	private void Update()
	{
		Anim.CrossFade(AnimName);
	}

	private void LateUpdate()
	{
		Head.LookAt(Camera.main.transform.position);
	}
}
