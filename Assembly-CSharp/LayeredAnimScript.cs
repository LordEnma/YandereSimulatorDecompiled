using UnityEngine;

public class LayeredAnimScript : MonoBehaviour
{
	public Animation Anim;

	private void Start()
	{
		Anim["moptest 1"].layer = 1;
		Anim.Play("moptest 1");
		Anim["moptest 1"].weight = 1f;
	}

	private void Update()
	{
		Anim.CrossFade("f02_walk_00");
	}
}
