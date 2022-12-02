using UnityEngine;

public class RivalPhoneScript : MonoBehaviour
{
	public DoorGapScript StolenPhoneDropoff;

	public Renderer MyRenderer;

	public PromptScript Prompt;

	public bool LewdPhotos;

	public bool Stolen;

	public int StudentID;

	public Vector3 OriginalPosition;

	public Quaternion OriginalRotation;

	public Transform OriginalParent;

	private void Start()
	{
		OriginalParent = base.transform.parent;
		OriginalPosition = base.transform.localPosition;
		OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		Prompt.Hide();
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
		if (!Prompt.Yandere.StudentManager.YandereVisible)
		{
			if (StudentID == Prompt.Yandere.StudentManager.RivalID && SchemeGlobals.GetSchemeStage(1) == 4)
			{
				SchemeGlobals.SetSchemeStage(1, 5);
				Prompt.Yandere.PauseScreen.Schemes.UpdateInstructions();
			}
			Prompt.Yandere.RivalPhoneTexture = MyRenderer.material.mainTexture;
			Prompt.Yandere.Inventory.RivalPhone = true;
			Prompt.Yandere.Inventory.RivalPhoneID = StudentID;
			Prompt.enabled = false;
			base.enabled = false;
			StolenPhoneDropoff.Prompt.enabled = true;
			StolenPhoneDropoff.Phase = 1;
			StolenPhoneDropoff.Timer = 0f;
			StolenPhoneDropoff.Prompt.Label[0].text = "     Provide Stolen Phone";
			base.gameObject.SetActive(false);
			Stolen = true;
		}
		else
		{
			Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	public void ReturnToOrigin()
	{
		base.transform.parent = OriginalParent;
		base.transform.localPosition = OriginalPosition;
		base.transform.localRotation = OriginalRotation;
		base.gameObject.SetActive(false);
		Prompt.enabled = true;
		LewdPhotos = false;
		Stolen = false;
		base.enabled = true;
	}
}
