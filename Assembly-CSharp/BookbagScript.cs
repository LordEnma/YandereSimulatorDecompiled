using UnityEngine;

public class BookbagScript : MonoBehaviour
{
	public PickUpScript ConcealedPickup;

	public WeaponScript ConcealedWeapon;

	public Rigidbody MyRigidbody;

	public PromptScript Prompt;

	public Texture EightiesBookBagTexture;

	public Mesh EightiesBookBag;

	public Renderer MyRenderer;

	public MeshFilter MyMesh;

	public bool Worn;

	private void Start()
	{
		MyRigidbody.useGravity = false;
		MyRigidbody.isKinematic = true;
		if (GameGlobals.Eighties)
		{
			MyRenderer.material.mainTexture = EightiesBookBagTexture;
			MyMesh.mesh = EightiesBookBag;
		}
	}

	private void Update()
	{
		if (Prompt.Yandere.PickUp != null || ConcealedPickup != null)
		{
			Prompt.HideButton[0] = false;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (ConcealedPickup == null)
				{
					TryToStashItem();
				}
				else
				{
					RemoveContents();
				}
			}
		}
		else
		{
			Prompt.HideButton[0] = true;
		}
		if (Prompt.Circle[3].fillAmount == 0f)
		{
			Wear();
		}
	}

	public void TryToStashItem()
	{
		if (Prompt.Yandere.PickUp.OpenFlame)
		{
			Prompt.Yandere.NotificationManager.CustomText = "That's too dangerous!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
		else if (Prompt.Yandere.PickUp.TrashCan == null && !Prompt.Yandere.PickUp.JerryCan && !Prompt.Yandere.PickUp.Mop && !Prompt.Yandere.PickUp.Bucket && !Prompt.Yandere.PickUp.Bleach && !Prompt.Yandere.PickUp.TooBig && !Prompt.Yandere.PickUp.Weight)
		{
			Prompt.Yandere.CharacterAnimation["f02_reachForWeapon_00"].time = 0f;
			Prompt.Yandere.ReachWeight = 1f;
			ConcealedPickup = Prompt.Yandere.PickUp;
			ConcealedPickup.InsideBookbag = true;
			ConcealedPickup.Drop();
			ConcealedPickup.gameObject.SetActive(value: false);
			if (ConcealedPickup.Clothing)
			{
				Prompt.Label[0].text = "     Retrieve " + ConcealedPickup.name;
			}
			else if (ConcealedPickup.Prompt.Text[3] != "")
			{
				Prompt.Label[0].text = "     Retrieve " + ConcealedPickup.Prompt.Text[3];
			}
			else
			{
				Prompt.Label[0].text = "     Retrieve " + ConcealedPickup.name;
			}
		}
		else
		{
			Prompt.Yandere.NotificationManager.CustomText = "That wouldn't fit!";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	public void RemoveContents()
	{
		Prompt.Yandere.CharacterAnimation["f02_reachForWeapon_00"].time = 0f;
		Prompt.Yandere.ReachWeight = 1f;
		ConcealedPickup.transform.position = base.transform.position;
		ConcealedPickup.gameObject.SetActive(value: true);
		ConcealedPickup.Prompt.Circle[3].fillAmount = -1f;
		ConcealedPickup.InsideBookbag = false;
		ConcealedPickup = null;
		ConcealedWeapon = null;
		Prompt.Label[0].text = "     Conceal Item";
	}

	public void Drop()
	{
		Worn = false;
		Prompt.Yandere.Bookbag = null;
		base.transform.parent = null;
		Prompt.MyCollider.enabled = true;
		MyRigidbody.useGravity = true;
		MyRigidbody.isKinematic = false;
		Prompt.enabled = true;
		base.enabled = true;
	}

	public void Wear()
	{
		Worn = true;
		Prompt.Yandere.Bookbag = this;
		base.transform.parent = Prompt.Yandere.BookBagParent;
		base.transform.localPosition = new Vector3(0f, 0f, 0f);
		base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		Prompt.MyCollider.enabled = false;
		MyRigidbody.useGravity = false;
		MyRigidbody.isKinematic = true;
		Prompt.Hide();
		Prompt.enabled = false;
		base.enabled = true;
	}
}
