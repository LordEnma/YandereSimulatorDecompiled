using UnityEngine;

public class GenericBentoScript : MonoBehaviour
{
	public GameObject EmptyGameObject;

	public GameObject Lid;

	public GameObject[] FoodVariant;

	public Transform PoisonSpot;

	public PromptScript Prompt;

	public bool Emetic;

	public bool Tranquil;

	public bool Headache;

	public bool Lethal;

	public bool Tampered;

	public int StudentID;

	private void Start()
	{
		FoodVariant[0].SetActive(value: false);
		FoodVariant[1].SetActive(value: false);
		FoodVariant[2].SetActive(value: false);
		FoodVariant[3].SetActive(value: false);
		if (FoodVariant.Length > 4)
		{
			FoodVariant[4].SetActive(value: false);
		}
		if (StudentID == 22)
		{
			FoodVariant[4].SetActive(value: true);
		}
		else
		{
			FoodVariant[Random.Range(0, 4)].SetActive(value: true);
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f && Prompt.Circle[1].fillAmount != 0f && Prompt.Circle[2].fillAmount != 0f && Prompt.Circle[3].fillAmount != 0f)
		{
			return;
		}
		if (Vector3.Distance(base.transform.position, Prompt.Yandere.StudentManager.Students[StudentID].transform.position) < 1.5f && StudentID != 10)
		{
			Prompt.Circle[0].fillAmount = 1f;
			Prompt.Circle[1].fillAmount = 1f;
			Prompt.Circle[2].fillAmount = 1f;
			Prompt.Circle[3].fillAmount = 1f;
			Prompt.Yandere.NotificationManager.CustomText = "Back up a bit!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Prompt.Yandere.NotificationManager.CustomText = Prompt.Yandere.StudentManager.Students[StudentID].Name + "!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Prompt.Yandere.NotificationManager.CustomText = "You're standing too close to ";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
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
			Prompt.Yandere.NotificationManager.CustomText = Prompt.Yandere.StudentManager.SeerName + " can see you!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Prompt.Yandere.NotificationManager.CustomText = "You can't do that!";
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
