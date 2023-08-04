using UnityEngine;

public class LayeredAnimScript : MonoBehaviour
{
	public Animation Anim;

	private void Start()
	{
		Anim["f02_walk_00"].layer = 0;
		Anim.Play("f02_walk_00");
		Anim["f02_walk_00"].weight = 1f;
		Anim["AnotherMopTest"].layer = 1;
		Anim.Play("AnotherMopTest");
		Anim["AnotherMopTest"].weight = 1f;
	}
}
