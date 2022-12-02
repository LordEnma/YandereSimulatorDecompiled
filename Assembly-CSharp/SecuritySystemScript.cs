using UnityEngine;

public class SecuritySystemScript : MonoBehaviour
{
	public PromptScript Prompt;

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
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		if (Prompt.Yandere.Inventory.IDCard)
		{
			for (int i = 0; i < Cameras.Length; i++)
			{
				Cameras[i].transform.parent.transform.parent.gameObject.GetComponent<AudioSource>().Stop();
				Cameras[i].gameObject.SetActive(false);
			}
			for (int i = 0; i < Detectors.Length; i++)
			{
				Detectors[i].MyCollider.enabled = false;
				Detectors[i].enabled = false;
			}
			GetComponent<AudioSource>().Play();
			Prompt.Hide();
			Prompt.enabled = false;
			Evidence = false;
			base.enabled = false;
		}
		else
		{
			Prompt.Yandere.NotificationManager.CustomText = "Faculty ID card required!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}
}
