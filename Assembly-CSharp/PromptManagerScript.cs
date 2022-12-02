using UnityEngine;

public class PromptManagerScript : MonoBehaviour
{
	public PromptScript[] Prompts;

	public int ID;

	public Transform Yandere;

	public bool Outside;

	private void Update()
	{
		if (Yandere.transform.position.z < -38f)
		{
			if (Outside)
			{
				return;
			}
			Outside = true;
			PromptScript[] prompts = Prompts;
			foreach (PromptScript promptScript in prompts)
			{
				if (promptScript != null)
				{
					promptScript.enabled = false;
				}
			}
		}
		else
		{
			if (!Outside)
			{
				return;
			}
			Outside = false;
			PromptScript[] prompts = Prompts;
			foreach (PromptScript promptScript2 in prompts)
			{
				if (promptScript2 != null)
				{
					promptScript2.enabled = true;
				}
			}
		}
	}
}
