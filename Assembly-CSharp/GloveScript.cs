using UnityEngine;

public class GloveScript : MonoBehaviour
{
	public PromptScript Prompt;

	public PickUpScript PickUp;

	public Collider MyCollider;

	public Projector Blood;

	public bool Raincoat;

	public int GloveID;

	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (Prompt.Yandere.Invisible)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Can't wear this while invisible!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Prompt.Yandere.WearingRaincoat || Prompt.Yandere.Gloved)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Can't combine clothing!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else
			{
				base.transform.parent = Prompt.Yandere.transform;
				base.transform.localPosition = new Vector3(0f, 1f, 0.25f);
				if (Raincoat)
				{
					Prompt.Yandere.WearingRaincoat = true;
				}
				Prompt.Yandere.StudentManager.GloveID = GloveID;
				Debug.Log("The StudentManager was just informed that GloveID should be: " + GloveID);
				Prompt.Yandere.Gloves = this;
				Prompt.Yandere.WearGloves();
				base.gameObject.SetActive(false);
			}
		}
		Prompt.HideButton[0] = Prompt.Yandere.Schoolwear != 1 || Prompt.Yandere.ClubAttire;
	}
}
