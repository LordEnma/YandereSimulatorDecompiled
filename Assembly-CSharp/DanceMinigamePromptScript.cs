using UnityEngine;

public class DanceMinigamePromptScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public Renderer OriginalRenderer;

	public DDRManager DanceManager;

	public PromptScript Prompt;

	public ClockScript Clock;

	public GameObject DanceMinigame;

	public Transform PlayerLocation;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		bool flag = false;
		for (int i = 1; i < 100; i++)
		{
			if (StudentManager.Students[i] != null && StudentManager.Students[i].InEvent)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			Prompt.Yandere.transform.position = PlayerLocation.position;
			Prompt.Yandere.transform.rotation = PlayerLocation.rotation;
			Prompt.Yandere.CharacterAnimation.Play("f02_danceMachineIdle_00");
			Prompt.Yandere.StudentManager.Clock.StopTime = true;
			Prompt.Yandere.MyController.enabled = false;
			Prompt.Yandere.HeartCamera.enabled = false;
			Prompt.Yandere.HUD.enabled = false;
			Prompt.Yandere.CanMove = false;
			Prompt.Yandere.enabled = false;
			Prompt.Yandere.Jukebox.LastVolume = Prompt.Yandere.Jukebox.Volume;
			Prompt.Yandere.Jukebox.Volume = 0f;
			Prompt.Yandere.HUD.transform.parent.gameObject.SetActive(value: false);
			Prompt.Yandere.MainCamera.gameObject.SetActive(value: false);
			OriginalRenderer.enabled = false;
			Physics.SyncTransforms();
			DanceMinigame.SetActive(value: true);
			DanceManager.BeginMinigame();
			StudentManager.DisableEveryone();
		}
		else
		{
			Prompt.Yandere.NotificationManager.CustomText = "Try again in a few minutes.";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Prompt.Yandere.NotificationManager.CustomText = "It's installing a firmware update.";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}
}
