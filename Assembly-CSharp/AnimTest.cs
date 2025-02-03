using UnityEngine;

public class AnimTest : MonoBehaviour
{
	public Animation Anim;

	public string[] AnimNames;

	public int ID;

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			ID++;
			if (ID == AnimNames.Length)
			{
				ID = 0;
			}
			Anim.Play(AnimNames[ID]);
		}
	}
}
