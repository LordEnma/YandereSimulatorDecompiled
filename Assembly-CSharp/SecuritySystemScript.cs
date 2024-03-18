using UnityEngine;

public class SecuritySystemScript : MonoBehaviour
{
	public PromptScript Prompt;

	public bool AlreadyShutDown;

	public bool Evidence;

	public bool Masked;

	public SecurityCameraScript[] Cameras;

	public MetalDetectorScript[] Detectors;

	private void Start()
	{
		if (!MissionModeGlobals.MissionMode && PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (Prompt.Yandere.Inventory.IDCard)
			{
				ShutDown();
				return;
			}
			Prompt.Yandere.NotificationManager.CustomText = "Faculty ID card required!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	public void ShutDown()
	{
		for (int i = 0; i < Cameras.Length; i++)
		{
			Cameras[i].transform.parent.transform.parent.gameObject.GetComponent<AudioSource>().Stop();
			Cameras[i].gameObject.SetActive(value: false);
		}
		for (int i = 0; i < Detectors.Length; i++)
		{
			Detectors[i].MyCollider.enabled = false;
			Detectors[i].enabled = false;
		}
		GetComponent<AudioSource>().Play();
		Prompt.Hide();
		Prompt.enabled = false;
		AlreadyShutDown = true;
		Evidence = false;
		base.enabled = false;
	}
}
