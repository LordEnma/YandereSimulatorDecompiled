using UnityEngine;

public class GenericBentoScript : MonoBehaviour
{
	public GameObject EmptyGameObject;

	public GameObject Lid;

	public Transform PoisonSpot;

	public PromptScript Prompt;

	public bool Emetic;

	public bool Tranquil;

	public bool Headache;

	public bool Lethal;

	public bool Tampered;

	public int StudentID;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f && Prompt.Circle[1].fillAmount != 0f && Prompt.Circle[2].fillAmount != 0f && Prompt.Circle[3].fillAmount != 0f)
		{
			return;
		}
		Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
		if (!Prompt.Yandere.StudentManager.YandereVisible)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Yandere.Inventory.EmeticPoisons--;
				Prompt.Yandere.PoisonType = 1;
				Emetic = true;
				ShutOff();
			}
			else if (Prompt.Circle[1].fillAmount == 0f)
			{
				Prompt.Yandere.Inventory.SedativePoisons--;
				Prompt.Yandere.PoisonType = 4;
				Tranquil = true;
				ShutOff();
			}
			else if (Prompt.Circle[2].fillAmount == 0f)
			{
				Prompt.Yandere.Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Prompt.Yandere.Numbness;
				Prompt.Yandere.Inventory.LethalPoisons--;
				Prompt.Yandere.PoisonType = 2;
				Lethal = true;
				ShutOff();
			}
			else if (Prompt.Circle[3].fillAmount == 0f)
			{
				Prompt.Yandere.Inventory.HeadachePoisons--;
				Prompt.Yandere.PoisonType = 5;
				Headache = true;
				ShutOff();
			}
		}
		else
		{
			Prompt.Circle[0].fillAmount = 1f;
			Prompt.Circle[1].fillAmount = 1f;
			Prompt.Circle[2].fillAmount = 1f;
			Prompt.Circle[3].fillAmount = 1f;
			Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	private void ShutOff()
	{
		Debug.Log("Shutting off a bento. This bento should be inaccessible from now on...");
		GameObject gameObject = Object.Instantiate(EmptyGameObject, base.transform.position, Quaternion.identity);
		PoisonSpot = gameObject.transform;
		PoisonSpot.position = new Vector3(PoisonSpot.position.x, Prompt.Yandere.transform.position.y, PoisonSpot.position.z);
		PoisonSpot.LookAt(Prompt.Yandere.transform.position);
		PoisonSpot.Translate(Vector3.forward * 0.25f);
		Prompt.Yandere.CharacterAnimation["f02_poisoning_00"].speed = 2f;
		Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
		Prompt.Yandere.StudentManager.UpdateAllBentos();
		Prompt.Yandere.TargetBento = this;
		Prompt.Yandere.Poisoning = true;
		Prompt.Yandere.CanMove = false;
		Tampered = true;
		base.enabled = false;
		Prompt.enabled = false;
		Prompt.Hide();
	}

	public void UpdatePrompts()
	{
		if (!Tampered)
		{
			Prompt.HideButton[0] = true;
			Prompt.HideButton[1] = true;
			Prompt.HideButton[2] = true;
			Prompt.HideButton[3] = true;
			if (Prompt.Yandere.Inventory.EmeticPoisons > 0)
			{
				Prompt.HideButton[0] = false;
			}
			if (Prompt.Yandere.Inventory.SedativePoisons > 0)
			{
				Prompt.HideButton[1] = false;
			}
			if (Prompt.Yandere.Inventory.LethalPoisons > 0)
			{
				Prompt.HideButton[2] = false;
			}
			if (Prompt.Yandere.Inventory.HeadachePoisons > 0)
			{
				Prompt.HideButton[3] = false;
			}
			Prompt.Yandere.EmptyHands();
		}
	}
}
