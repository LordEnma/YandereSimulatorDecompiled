using UnityEngine;

public class GloveScript : MonoBehaviour
{
	public PromptScript Prompt;

	public PickUpScript PickUp;

	public Collider MyCollider;

	public Projector Blood;

	public bool OccultRobe;

	public bool Raincoat;

	public int GloveID;

	public Texture BloodTexture;

	public Texture CensorTexture;

	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
		UpdateBlood();
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
			else if (Prompt.Yandere.Schoolwear == 2)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Can't combine this with a swimsuit!";
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
				base.gameObject.SetActive(value: false);
			}
		}
		Prompt.HideButton[0] = Prompt.Yandere.ClubAttire;
	}

	public void UpdateBlood()
	{
		Texture texture = null;
		texture = ((!GameGlobals.CensorBlood) ? BloodTexture : CensorTexture);
		Blood.material.mainTexture = texture;
		Blood.material.SetTexture("_MainText", texture);
		Blood.material.color = new Color(0.25f, 0.25f, 0.25f, 0.5f);
		Blood.material.SetColor("_TintColor", new Color(0.25f, 0.25f, 0.25f, 0.5f));
	}
}
