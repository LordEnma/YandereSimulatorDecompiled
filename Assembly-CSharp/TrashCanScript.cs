using System;
using UnityEngine;

// Token: 0x02000480 RID: 1152
public class TrashCanScript : MonoBehaviour
{
	// Token: 0x06001ED9 RID: 7897 RVA: 0x001B0E58 File Offset: 0x001AF058
	private void Update()
	{
		if (!this.Occupied)
		{
			if (this.Prompt.HideButton[0])
			{
				if (this.Yandere.Armed)
				{
					this.UpdatePrompt();
				}
			}
			else
			{
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Prompt.Circle[0].fillAmount = 1f;
					if (this.Yandere.PickUp != null)
					{
						this.Item = this.Yandere.PickUp.gameObject;
						this.Yandere.MyController.radius = 0.5f;
						this.Yandere.EmptyHands();
					}
					else
					{
						this.ConcealedWeapon = this.Yandere.EquippedWeapon;
						this.Item = this.Yandere.EquippedWeapon.gameObject;
						this.Yandere.DropTimer[this.Yandere.Equipped] = 0.5f;
						this.Yandere.DropWeapon(this.Yandere.Equipped);
						this.ConcealedWeapon.MyRigidbody.isKinematic = true;
						this.Weapon = true;
					}
					this.Item.transform.parent = this.TrashPosition;
					this.Item.GetComponent<Rigidbody>().useGravity = false;
					this.Item.GetComponent<Collider>().enabled = false;
					this.Item.GetComponent<PromptScript>().Hide();
					this.Item.GetComponent<PromptScript>().enabled = false;
					this.Occupied = true;
					this.UpdatePrompt();
				}
				if (!this.Yandere.Armed)
				{
					this.UpdatePrompt();
				}
			}
		}
		else if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.RemoveContents();
		}
		if (this.Item != null)
		{
			if (this.Weapon)
			{
				if (this.ConcealedWeapon != null && this.ConcealedWeapon.WeaponID == 23)
				{
					if (this.Wearable)
					{
						this.Item.transform.localPosition = new Vector3(-0.05f, 0.25f, 0.0066666f);
						this.Item.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
						this.Item.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
					}
					else
					{
						this.Item.transform.localPosition = new Vector3(-0.1f, 0.29f, 0f);
						this.Item.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
					}
				}
				else
				{
					this.Item.transform.localPosition = new Vector3(0f, 0.29f, 0f);
					this.Item.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
				}
				if (this.Item.transform.parent != this.TrashPosition)
				{
					this.Item = null;
					this.Weapon = false;
				}
			}
			else
			{
				this.Item.transform.localPosition = new Vector3(0f, 0f, -0.021f);
				this.Item.transform.localEulerAngles = Vector3.zero;
			}
		}
		if (this.Wearable)
		{
			if (this.Prompt.Circle[3].fillAmount == 0f)
			{
				this.Prompt.Circle[3].fillAmount = 1f;
				base.transform.parent = this.Prompt.Yandere.Backpack;
				base.transform.localPosition = Vector3.zero;
				base.transform.localEulerAngles = new Vector3(90f, -154f, 0f);
				this.Prompt.Yandere.Container = this.Container;
				this.Prompt.Yandere.WeaponMenu.UpdateSprites();
				this.Prompt.MyCollider.enabled = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.MyRigidbody.isKinematic = true;
				this.MyRigidbody.useGravity = false;
			}
			if (!this.MyRigidbody.isKinematic)
			{
				this.KinematicTimer = Mathf.MoveTowards(this.KinematicTimer, 5f, Time.deltaTime);
				if (this.KinematicTimer == 5f)
				{
					this.MyRigidbody.isKinematic = true;
					this.KinematicTimer = 0f;
				}
				if (base.transform.position.x > -71f && base.transform.position.x < -61f && base.transform.position.z > -37.5f && base.transform.position.z < -27.5f)
				{
					this.Yandere.NotificationManager.CustomText = "You can't drop that there!";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					base.transform.position = new Vector3(-63f, 1f, -26.5f);
					this.KinematicTimer = 0f;
				}
				if (base.transform.position.x > -21f && base.transform.position.x < 21f && base.transform.position.z > 100f && base.transform.position.z < 135f)
				{
					base.transform.position = new Vector3(0f, 1f, 100f);
					this.KinematicTimer = 0f;
				}
				if (base.transform.position.x > -46f && base.transform.position.x < -18f && base.transform.position.z > 66f && base.transform.position.z < 78f)
				{
					base.transform.position = new Vector3(-16f, 5f, 72f);
					this.KinematicTimer = 0f;
				}
			}
		}
	}

	// Token: 0x06001EDA RID: 7898 RVA: 0x001B14D4 File Offset: 0x001AF6D4
	public void UpdatePrompt()
	{
		if (this.Occupied)
		{
			this.Prompt.Label[0].text = "     Remove";
			this.Prompt.HideButton[0] = false;
			return;
		}
		if (this.Yandere.Armed)
		{
			this.Prompt.Label[0].text = "     Insert";
			this.Prompt.HideButton[0] = false;
			return;
		}
		if (!(this.Yandere.PickUp != null))
		{
			this.Prompt.HideButton[0] = true;
			return;
		}
		if (this.Yandere.PickUp.Bucket)
		{
			this.Prompt.HideButton[0] = true;
			return;
		}
		if (this.Yandere.PickUp.Evidence || this.Yandere.PickUp.Suspicious)
		{
			this.Prompt.Label[0].text = "     Insert";
			this.Prompt.HideButton[0] = false;
			return;
		}
		this.Prompt.HideButton[0] = true;
	}

	// Token: 0x06001EDB RID: 7899 RVA: 0x001B15E8 File Offset: 0x001AF7E8
	public void RemoveContents()
	{
		Debug.Log("The object that was in this container has been removed.");
		this.Prompt.Circle[0].fillAmount = 1f;
		this.Item.GetComponent<PromptScript>().Circle[3].fillAmount = -1f;
		this.Item.GetComponent<PromptScript>().enabled = true;
		this.Item = null;
		this.ConcealedWeapon = null;
		this.Occupied = false;
		this.Weapon = false;
		this.UpdatePrompt();
	}

	// Token: 0x04004021 RID: 16417
	public WeaponScript ConcealedWeapon;

	// Token: 0x04004022 RID: 16418
	public ContainerScript Container;

	// Token: 0x04004023 RID: 16419
	public YandereScript Yandere;

	// Token: 0x04004024 RID: 16420
	public PromptScript Prompt;

	// Token: 0x04004025 RID: 16421
	public Transform TrashPosition;

	// Token: 0x04004026 RID: 16422
	public Rigidbody MyRigidbody;

	// Token: 0x04004027 RID: 16423
	public GameObject Item;

	// Token: 0x04004028 RID: 16424
	public bool Occupied;

	// Token: 0x04004029 RID: 16425
	public bool Wearable;

	// Token: 0x0400402A RID: 16426
	public bool Weapon;

	// Token: 0x0400402B RID: 16427
	public float KinematicTimer;
}
