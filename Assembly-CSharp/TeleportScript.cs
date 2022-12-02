using UnityEngine;

public class TeleportScript : MonoBehaviour
{
	public PromptScript Prompt;

	public Transform Destination;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.transform.position = Destination.position;
			Physics.SyncTransforms();
		}
	}
}
