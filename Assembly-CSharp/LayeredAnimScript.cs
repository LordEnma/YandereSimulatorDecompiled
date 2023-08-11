using UnityEngine;

public class LayeredAnimScript : MonoBehaviour
{
	public Animation Anim;

	private void Start()
	{
		Anim["f02_walk_00"].layer = 0;
		Anim.Play("f02_walk_00");
		Anim["f02_walk_00"].weight = 1f;
		Anim["MopTest"].layer = 1;
		Anim.Play("MopTest");
		Anim["MopTest"].weight = 1f;
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			if (Anim["MopTest"].weight == 1f)
			{
				Anim["MopTest"].weight = 0f;
			}
			else
			{
				Anim["MopTest"].weight = 1f;
			}
		}
	}
}
