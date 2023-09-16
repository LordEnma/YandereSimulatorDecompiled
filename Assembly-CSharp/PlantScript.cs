using UnityEngine;

public class PlantScript : MonoBehaviour
{
	public AudioSource MyAudio;

	public PromptScript Prompt;

	public Transform Plant;

	public Transform Lid;

	public bool Initialized;

	public bool FadeOut;

	public bool FadeIn;

	public int Progress;

	private void Start()
	{
		Plant.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		Plant.localPosition = new Vector3(1.4f, 1.125f, 5.15f);
		Lid.localEulerAngles = new Vector3(0f, 0f, 0f);
		if (!Initialized)
		{
			Progress = SchoolGlobals.PlantProgress;
			Initialized = true;
		}
		if (Progress == 1)
		{
			Plant.localScale = new Vector3(0.7f, 0.7f, 0.7f);
			Plant.localPosition = new Vector3(1.4f, 1.125f, 5.174f);
		}
		else if (Progress == 2)
		{
			Plant.localScale = new Vector3(0.9f, 0.9f, 0.9f);
			Plant.localPosition = new Vector3(1.4f, 1.125f, 5.234f);
		}
		else if (Progress == 3)
		{
			Plant.localScale = new Vector3(1.1f, 1.1f, 1.1f);
			Plant.localPosition = new Vector3(1.4f, 1.125f, 5.293f);
		}
		else if (Progress == 4)
		{
			Plant.localScale = new Vector3(1.3f, 1.3f, 1.3f);
			Plant.localPosition = new Vector3(1.4f, 1.125f, 5.353f);
			Lid.localEulerAngles = new Vector3(-7f, 0f, 0f);
		}
		else if (Progress >= 5)
		{
			Plant.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			Plant.localPosition = new Vector3(1.4f, 1.125f, 5.025f);
			Lid.localEulerAngles = new Vector3(-20f, 0f, 0f);
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (Progress < 5)
			{
				if (Prompt.Yandere.Inventory.GrowthStimulant)
				{
					Prompt.Yandere.NotificationManager.CustomText = "Fed the plant!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					Prompt.Yandere.Inventory.GrowthStimulant = false;
					Progress++;
					Start();
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "You don't have any growth stimulant...";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			else if (Prompt.Yandere.Carrying || Prompt.Yandere.Dragging || (Prompt.Yandere.PickUp != null && (bool)Prompt.Yandere.PickUp.BodyPart))
			{
				Prompt.Yandere.Police.Darkness.enabled = true;
				Prompt.Yandere.CanMove = false;
				FadeOut = true;
			}
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = "It hungers for blood...";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		if (FadeOut)
		{
			Prompt.Yandere.Police.Darkness.alpha = Mathf.MoveTowards(Prompt.Yandere.Police.Darkness.alpha, 1f, Time.deltaTime);
			if (Prompt.Yandere.Police.Darkness.alpha == 1f)
			{
				if (Prompt.Yandere.PickUp != null)
				{
					GameObject obj = Prompt.Yandere.PickUp.gameObject;
					Prompt.Yandere.EmptyHands();
					Object.Destroy(obj);
				}
				else
				{
					RagdollScript currentRagdoll = Prompt.Yandere.CurrentRagdoll;
					Prompt.Yandere.EmptyHands();
					currentRagdoll.Student.gameObject.SetActive(value: false);
					currentRagdoll.Disposed = true;
					Prompt.Yandere.Police.Corpses--;
				}
				FadeOut = false;
				FadeIn = true;
				MyAudio.Play();
			}
		}
		if (FadeIn && !MyAudio.isPlaying)
		{
			Prompt.Yandere.CharacterAnimation.CrossFade(Prompt.Yandere.IdleAnim);
			Prompt.Yandere.Police.Darkness.alpha = Mathf.MoveTowards(Prompt.Yandere.Police.Darkness.alpha, 0f, Time.deltaTime);
			if (Prompt.Yandere.Police.Darkness.alpha == 0f)
			{
				Prompt.Yandere.Police.Darkness.enabled = false;
				Prompt.Yandere.CanMove = true;
				FadeIn = false;
			}
		}
	}

	public void SavePlantProgress()
	{
		SchoolGlobals.PlantProgress = Progress;
	}
}
