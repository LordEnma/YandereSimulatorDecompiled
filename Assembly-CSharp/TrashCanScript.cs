using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
	public WeaponScript ConcealedWeapon;

	public ContainerScript Container;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform TrashPosition;

	public Rigidbody MyRigidbody;

	public GameObject Item;

	public bool Occupied;

	public bool Wearable;

	public bool Weapon;

	public bool Foil;

	public bool Worn;

	public float KinematicTimer;

	public int BagID;

	private void Start()
	{
		Physics.IgnoreCollision(Yandere.GetComponent<Collider>(), base.gameObject.GetComponent<BoxCollider>());
		if (Wearable && ChallengeGlobals.NoBag)
		{
			if (Yandere.Club == ClubType.Delinquent || Yandere.Club == ClubType.LightMusic)
			{
				AttachToBack();
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}

	private void Update()
	{
		if (!Occupied)
		{
			if (Prompt.HideButton[0])
			{
				if (Yandere.Armed)
				{
					UpdatePrompt();
				}
			}
			else
			{
				if (Prompt.Circle[0].fillAmount == 0f)
				{
					Prompt.Circle[0].fillAmount = 1f;
					if ((Yandere.PickUp != null && Yandere.PickUp.TrashCan != null) || (Yandere.Armed && Yandere.EquippedWeapon.Type == WeaponType.Scythe))
					{
						Yandere.NotificationManager.CustomText = "You can't fit that in there.";
						Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else
					{
						StashItem();
					}
				}
				if (!Yandere.Armed)
				{
					UpdatePrompt();
				}
			}
		}
		else if (Prompt.Circle[0].fillAmount == 0f)
		{
			RemoveContents();
		}
		if (Item != null)
		{
			if (Weapon)
			{
				if (ConcealedWeapon != null && ConcealedWeapon.WeaponID == 23)
				{
					if (Wearable)
					{
						Item.transform.localPosition = new Vector3(-0.05f, 0.25f, 0.0066666f);
						Item.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
						Item.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
					}
					else
					{
						Item.transform.localPosition = new Vector3(-0.1f, 0.29f, 0f);
						Item.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
					}
				}
				else
				{
					Item.transform.localPosition = new Vector3(0f, 0.29f, 0f);
					Item.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
				}
				if (Item.transform.parent != TrashPosition)
				{
					Item = null;
					Weapon = false;
				}
			}
			else
			{
				Item.transform.localPosition = new Vector3(0f, 0f, -0.021f);
				Item.transform.localEulerAngles = Vector3.zero;
			}
		}
		if (!Wearable)
		{
			return;
		}
		if (Prompt.Circle[3].fillAmount == 0f)
		{
			Prompt.Circle[3].fillAmount = 1f;
			if (Prompt.Yandere.Container != null)
			{
				Prompt.Yandere.NotificationManager.CustomText = "You're already wearing something on your back!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else
			{
				AttachToBack();
			}
		}
		if (Yandere.PickUp != null && Yandere.PickUp.Tinfoil)
		{
			Prompt.HideButton[1] = false;
			if (Prompt.Circle[1].fillAmount == 0f)
			{
				Prompt.Circle[1].fillAmount = 1f;
				Foil = true;
				GameObject obj = Yandere.PickUp.gameObject;
				Yandere.EmptyHands();
				obj.SetActive(value: false);
			}
		}
		else
		{
			Prompt.HideButton[1] = true;
		}
		if (!MyRigidbody.isKinematic)
		{
			KinematicTimer = Mathf.MoveTowards(KinematicTimer, 5f, Time.deltaTime);
			if (KinematicTimer == 5f)
			{
				MyRigidbody.isKinematic = true;
				KinematicTimer = 0f;
			}
			if (base.transform.position.x > -71f && base.transform.position.x < -61f && base.transform.position.z > -37.5f && base.transform.position.z < -27.5f)
			{
				Yandere.NotificationManager.CustomText = "You can't drop that there!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				base.transform.position = new Vector3(-63f, 1f, -26.5f);
				KinematicTimer = 0f;
			}
			if (base.transform.position.x > -21f && base.transform.position.x < 21f && base.transform.position.z > 100f && base.transform.position.z < 135f)
			{
				base.transform.position = new Vector3(0f, 1f, 100f);
				KinematicTimer = 0f;
			}
			if (base.transform.position.x > -46f && base.transform.position.x < -18f && base.transform.position.z > 66f && base.transform.position.z < 78f)
			{
				base.transform.position = new Vector3(-16f, 5f, 72f);
				KinematicTimer = 0f;
			}
		}
	}

	public void UpdatePrompt()
	{
		if (!Occupied)
		{
			if (Yandere.Armed)
			{
				Prompt.Label[0].text = "     Insert";
				Prompt.HideButton[0] = false;
			}
			else if (Yandere.PickUp != null)
			{
				if (!Yandere.PickUp.Bucket && !Yandere.PickUp.Mop)
				{
					if (Yandere.PickUp.Evidence || Yandere.PickUp.Suspicious)
					{
						Prompt.Label[0].text = "     Insert";
						Prompt.HideButton[0] = false;
					}
					else
					{
						Prompt.HideButton[0] = true;
					}
				}
				else
				{
					Prompt.HideButton[0] = true;
				}
			}
			else
			{
				Prompt.HideButton[0] = true;
			}
		}
		else
		{
			Prompt.Label[0].text = "     Remove";
			Prompt.HideButton[0] = false;
		}
	}

	public void RemoveContents()
	{
		Prompt.Circle[0].fillAmount = 1f;
		Item.GetComponent<PromptScript>().Circle[3].fillAmount = -1f;
		Item.GetComponent<PromptScript>().enabled = true;
		if (Item.GetComponent<PickUpScript>() != null)
		{
			Item.transform.localScale = Item.GetComponent<PickUpScript>().OriginalScale;
		}
		Item = null;
		ConcealedWeapon = null;
		Occupied = false;
		Weapon = false;
		UpdatePrompt();
	}

	public void StashItem()
	{
		if (Yandere.PickUp != null)
		{
			Item = Yandere.PickUp.gameObject;
			Yandere.EmptyHands();
		}
		else
		{
			Debug.Log("Concealing a weapon in the weapon bag.");
			ConcealedWeapon = Yandere.EquippedWeapon;
			Yandere.DropTimer[Yandere.Equipped] = 0.5f;
			Yandere.DropWeapon(Yandere.Equipped);
			PutWeaponInBag();
		}
		PositionItem();
	}

	public void PositionItem()
	{
		Item.transform.parent = TrashPosition;
		Item.GetComponent<Rigidbody>().useGravity = false;
		Item.GetComponent<Collider>().enabled = false;
		Item.GetComponent<PromptScript>().Hide();
		Item.GetComponent<PromptScript>().enabled = false;
		Occupied = true;
		UpdatePrompt();
		Item.transform.localScale = new Vector3(0.33333f, 0.5f, 0.5f);
		if (ConcealedWeapon != null && ConcealedWeapon.Type != WeaponType.Bat && ConcealedWeapon.Type != WeaponType.Katana)
		{
			Item.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	public void AttachToBack()
	{
		Debug.Log("The weapon bag is now being attached to the player's back.");
		base.transform.parent = Prompt.Yandere.Backpack;
		base.transform.localPosition = Vector3.zero;
		base.transform.localEulerAngles = new Vector3(90f, -154f, 0f);
		if (Prompt.Yandere.Container != null)
		{
			Prompt.Yandere.Container.Drop();
		}
		Prompt.Yandere.Container = Container;
		Prompt.Yandere.WeaponMenu.UpdateSprites();
		Prompt.MyCollider.enabled = false;
		Prompt.Hide();
		Prompt.enabled = false;
		MyRigidbody.isKinematic = true;
		MyRigidbody.useGravity = false;
		Worn = true;
	}

	public void PutWeaponInBag()
	{
		Item = ConcealedWeapon.gameObject;
		ConcealedWeapon.MyRigidbody.isKinematic = true;
		ConcealedWeapon.InBag = true;
		ConcealedWeapon.BagID = BagID;
		Weapon = true;
		PositionItem();
	}
}
