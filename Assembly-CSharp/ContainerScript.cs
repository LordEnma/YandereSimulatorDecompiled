using System;
using UnityEngine;

// Token: 0x0200025B RID: 603
public class ContainerScript : MonoBehaviour
{
	// Token: 0x060012B9 RID: 4793 RVA: 0x00099EA0 File Offset: 0x000980A0
	public void Start()
	{
		this.GardenArea = GameObject.Find("GardenArea").GetComponent<Collider>();
		this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
		this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
		this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
		this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
	}

	// Token: 0x060012BA RID: 4794 RVA: 0x00099F18 File Offset: 0x00098118
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Open = !this.Open;
			this.UpdatePrompts();
		}
		if (this.Prompt.Circle[1].fillAmount == 0f)
		{
			this.Prompt.Circle[1].fillAmount = 1f;
			if (this.Prompt.Yandere.Armed)
			{
				this.Weapon = this.Prompt.Yandere.EquippedWeapon;
				this.Prompt.Yandere.EmptyHands();
				this.Weapon.transform.parent = this.WeaponSpot;
				this.Weapon.transform.localPosition = Vector3.zero;
				this.Weapon.transform.localEulerAngles = Vector3.zero;
				this.Weapon.gameObject.GetComponent<Rigidbody>().useGravity = false;
				this.Weapon.MyCollider.isTrigger = true;
				this.Weapon.Prompt.Hide();
				this.Weapon.Prompt.enabled = false;
			}
			else
			{
				this.BodyPart = this.Prompt.Yandere.PickUp;
				this.Prompt.Yandere.EmptyHands();
				this.BodyPart.transform.parent = this.BodyPartPositions[this.BodyPart.GetComponent<BodyPartScript>().Type];
				this.BodyPart.transform.localPosition = Vector3.zero;
				this.BodyPart.transform.localEulerAngles = Vector3.zero;
				this.BodyPart.gameObject.GetComponent<Rigidbody>().useGravity = false;
				this.BodyPart.MyCollider.isTrigger = true;
				this.BodyParts[this.BodyPart.GetComponent<BodyPartScript>().Type] = this.BodyPart;
			}
			this.Contents++;
			this.UpdatePrompts();
		}
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Circle[3].fillAmount = 1f;
			if (!this.Open)
			{
				base.transform.parent = this.Prompt.Yandere.Backpack;
				base.transform.localPosition = Vector3.zero;
				base.transform.localEulerAngles = Vector3.zero;
				if (this.Prompt.Yandere.Container != null)
				{
					this.Prompt.Yandere.Container.Drop();
				}
				this.Prompt.Yandere.Container = this;
				this.Prompt.Yandere.WeaponMenu.UpdateSprites();
				this.Prompt.MyCollider.enabled = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				Rigidbody component = base.GetComponent<Rigidbody>();
				component.isKinematic = true;
				component.useGravity = false;
			}
			else
			{
				if (this.Weapon != null)
				{
					this.Weapon.Prompt.Circle[3].fillAmount = -1f;
					this.Weapon.Prompt.enabled = true;
					this.Weapon = null;
				}
				else
				{
					this.BodyPart = null;
					this.ID = 1;
					while (this.BodyPart == null)
					{
						this.BodyPart = this.BodyParts[this.ID];
						this.BodyParts[this.ID] = null;
						this.ID++;
					}
					this.BodyPart.Prompt.Circle[3].fillAmount = -1f;
				}
				this.Contents--;
				this.UpdatePrompts();
			}
		}
		this.Lid.localEulerAngles = new Vector3(this.Lid.localEulerAngles.x, this.Lid.localEulerAngles.y, Mathf.Lerp(this.Lid.localEulerAngles.z, this.Open ? 90f : 0f, Time.deltaTime * 10f));
		if (this.Weapon != null)
		{
			this.Weapon.transform.localPosition = Vector3.zero;
			this.Weapon.transform.localEulerAngles = Vector3.zero;
		}
		this.ID = 1;
		while (this.ID < this.BodyParts.Length)
		{
			if (this.BodyParts[this.ID] != null)
			{
				this.BodyParts[this.ID].transform.localPosition = Vector3.zero;
				this.BodyParts[this.ID].transform.localEulerAngles = Vector3.zero;
			}
			this.ID++;
		}
	}

	// Token: 0x060012BB RID: 4795 RVA: 0x0009A414 File Offset: 0x00098614
	public void Drop()
	{
		base.transform.parent = null;
		if (base.enabled)
		{
			base.transform.position = this.Prompt.Yandere.ObstacleDetector.transform.position + new Vector3(0f, 0.5f, 0f);
			base.transform.eulerAngles = this.Prompt.Yandere.ObstacleDetector.transform.eulerAngles;
		}
		this.Prompt.Yandere.Container = null;
		this.Prompt.MyCollider.enabled = true;
		this.Prompt.enabled = true;
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.isKinematic = false;
		component.useGravity = true;
	}

	// Token: 0x060012BC RID: 4796 RVA: 0x0009A4DC File Offset: 0x000986DC
	public void UpdatePrompts()
	{
		if (this.Weapon != null)
		{
			this.Weapon.MyCollider.enabled = this.Open;
		}
		this.ID = 0;
		while (this.ID < this.BodyParts.Length)
		{
			if (this.BodyParts[this.ID] != null)
			{
				this.BodyParts[this.ID].MyCollider.enabled = this.Open;
			}
			this.ID++;
		}
		if (!this.Open)
		{
			if (this.Prompt.Label[0] != null)
			{
				this.Prompt.Label[0].text = "     Open";
				this.Prompt.HideButton[1] = true;
				this.Prompt.Label[3].text = "     Wear";
				this.Prompt.HideButton[3] = false;
			}
			return;
		}
		this.Prompt.Label[0].text = "     Close";
		if (this.Contents > 0)
		{
			this.Prompt.Label[3].text = "     Remove";
			this.Prompt.HideButton[3] = false;
		}
		else
		{
			this.Prompt.HideButton[3] = true;
		}
		if (this.Prompt.Yandere.Armed)
		{
			if (this.Prompt.Yandere.EquippedWeapon.Concealable)
			{
				this.Prompt.HideButton[1] = true;
				return;
			}
			if (this.Weapon == null)
			{
				this.Prompt.Label[1].text = "     Insert";
				this.Prompt.HideButton[1] = false;
				return;
			}
			this.Prompt.HideButton[1] = true;
			return;
		}
		else
		{
			if (!(this.Prompt.Yandere.PickUp != null))
			{
				this.Prompt.HideButton[1] = true;
				return;
			}
			if (!(this.Prompt.Yandere.PickUp.BodyPart != null))
			{
				this.Prompt.HideButton[1] = true;
				return;
			}
			if (this.BodyParts[this.Prompt.Yandere.PickUp.gameObject.GetComponent<BodyPartScript>().Type] == null)
			{
				this.Prompt.Label[1].text = "     Insert";
				this.Prompt.HideButton[1] = false;
				return;
			}
			this.Prompt.HideButton[1] = true;
			return;
		}
	}

	// Token: 0x040018E3 RID: 6371
	public TrashCanScript TrashCan;

	// Token: 0x040018E4 RID: 6372
	public WeaponScript Weapon;

	// Token: 0x040018E5 RID: 6373
	public PromptScript Prompt;

	// Token: 0x040018E6 RID: 6374
	public Transform[] BodyPartPositions;

	// Token: 0x040018E7 RID: 6375
	public Transform WeaponSpot;

	// Token: 0x040018E8 RID: 6376
	public Transform Lid;

	// Token: 0x040018E9 RID: 6377
	public Collider GardenArea;

	// Token: 0x040018EA RID: 6378
	public Collider NEStairs;

	// Token: 0x040018EB RID: 6379
	public Collider NWStairs;

	// Token: 0x040018EC RID: 6380
	public Collider SEStairs;

	// Token: 0x040018ED RID: 6381
	public Collider SWStairs;

	// Token: 0x040018EE RID: 6382
	public PickUpScript[] BodyParts;

	// Token: 0x040018EF RID: 6383
	public PickUpScript BodyPart;

	// Token: 0x040018F0 RID: 6384
	public string SpriteName = string.Empty;

	// Token: 0x040018F1 RID: 6385
	public bool CelloCase;

	// Token: 0x040018F2 RID: 6386
	public bool CanDrop;

	// Token: 0x040018F3 RID: 6387
	public bool Open;

	// Token: 0x040018F4 RID: 6388
	public int Contents;

	// Token: 0x040018F5 RID: 6389
	public int ID;
}
