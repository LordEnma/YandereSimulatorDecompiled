using UnityEngine;

public class LibraryFlyerCopyScript : MonoBehaviour
{
	public GameObject PosterPrompts;

	public PromptScript Prompt;

	public Transform Destination;

	public AudioSource MyAudio;

	public bool Animate;

	public float Timer;

	public int TaskID = 13;

	public string AnimationName = "f02_usingPrinter_00";

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.enabled = false;
			Prompt.Hide();
			Prompt.Yandere.CanMove = false;
			Animate = true;
			if (MyAudio != null)
			{
				MyAudio.Play();
			}
		}
		if (!Animate)
		{
			return;
		}
		Prompt.Yandere.CharacterAnimation.CrossFade(AnimationName);
		Prompt.Yandere.transform.rotation = Quaternion.Slerp(Prompt.Yandere.transform.rotation, Destination.rotation, Time.deltaTime * 10f);
		Prompt.Yandere.MoveTowardsTarget(Destination.position);
		Timer += Time.deltaTime;
		if (Timer > 5f)
		{
			if (TaskID == 13)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Flyers obtained.";
				Prompt.Yandere.Inventory.Flyers = 12;
			}
			else if (TaskID == 17)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Books obtained.";
				Prompt.Yandere.Inventory.Books = 6;
			}
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			PosterPrompts.SetActive(value: true);
			Prompt.Yandere.CanMove = true;
			base.enabled = false;
		}
	}
}
