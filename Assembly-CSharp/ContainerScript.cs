using System;
using UnityEngine;

// Token: 0x0200025A RID: 602
public class ContainerScript : MonoBehaviour
{
	// Token: 0x060012B3 RID: 4787 RVA: 0x000991F8 File Offset: 0x000973F8
	public void Start()
	{
		this.GardenArea = GameObject.Find("GardenArea").GetComponent<Collider>();
		this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
		this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
		this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
		this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
	}

	// Token: 0x060012B4 RID: 4788 RVA: 0x00099270 File Offset: 0x00097470
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

	// Token: 0x060012B5 RID: 4789 RVA: 0x0009973C File Offset: 0x0009793C
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

	// Token: 0x060012B6 RID: 4790 RVA: 0x00099804 File Offset: 0x00097A04
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

	// Token: 0x040018C4 RID: 6340
	public TrashCanScript TrashCan;

	// Token: 0x040018C5 RID: 6341
	public WeaponScript Weapon;

	// Token: 0x040018C6 RID: 6342
	public PromptScript Prompt;

	// Token: 0x040018C7 RID: 6343
	public Transform[] BodyPartPositions;

	// Token: 0x040018C8 RID: 6344
	public Transform WeaponSpot;

	// Token: 0x040018C9 RID: 6345
	public Transform Lid;

	// Token: 0x040018CA RID: 6346
	public Collider GardenArea;

	// Token: 0x040018CB RID: 6347
	public Collider NEStairs;

	// Token: 0x040018CC RID: 6348
	public Collider NWStairs;

	// Token: 0x040018CD RID: 6349
	public Collider SEStairs;

	// Token: 0x040018CE RID: 6350
	public Collider SWStairs;

	// Token: 0x040018CF RID: 6351
	public PickUpScript[] BodyParts;

	// Token: 0x040018D0 RID: 6352
	public PickUpScript BodyPart;

	// Token: 0x040018D1 RID: 6353
	public string SpriteName = string.Empty;

	// Token: 0x040018D2 RID: 6354
	public bool CelloCase;

	// Token: 0x040018D3 RID: 6355
	public bool CanDrop;

	// Token: 0x040018D4 RID: 6356
	public bool Open;

	// Token: 0x040018D5 RID: 6357
	public int Contents;

	// Token: 0x040018D6 RID: 6358
	public int ID;
}
