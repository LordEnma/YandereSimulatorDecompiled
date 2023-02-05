using UnityEngine;

public class BugScript : MonoBehaviour
{
	public PromptScript Prompt;

	public Renderer MyRenderer;

	public AudioSource MyAudio;

	public AudioClip[] Praise;

	public bool Placed;

	private void Start()
	{
		if (GameGlobals.Eighties || GameGlobals.KokonaTutorial)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.gameObject.SetActive(value: false);
		}
		MyRenderer.enabled = false;
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			MyAudio.clip = Praise[Random.Range(0, Praise.Length)];
			MyAudio.Play();
			MyRenderer.enabled = true;
			Prompt.Yandere.Inventory.PantyShots += 5;
			Prompt.Yandere.NotificationManager.CustomText = "+5 Info Points! You have " + Prompt.Yandere.Inventory.PantyShots + " in total";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Placed = true;
			base.enabled = false;
			Prompt.enabled = false;
			Prompt.Hide();
		}
	}

	public void CheckStatus()
	{
		if (Placed)
		{
			MyRenderer.enabled = true;
			base.enabled = false;
			Prompt.enabled = false;
			Prompt.Hide();
		}
	}
}
