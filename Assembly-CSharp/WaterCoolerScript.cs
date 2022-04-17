using System;
using UnityEngine;

// Token: 0x020004C1 RID: 1217
public class WaterCoolerScript : MonoBehaviour
{
	// Token: 0x06001FD5 RID: 8149 RVA: 0x001C1B04 File Offset: 0x001BFD04
	private void Start()
	{
		this.Cylinder.localScale = new Vector3(1f, 0f, 1f);
		this.TripwireTrap.SetActive(false);
		this.Prompt.HideButton[1] = true;
		this.OriginalColor[0] = this.Prompt.Label[1].gradientTop;
		this.OriginalColor[1] = this.Prompt.Label[1].gradientBottom;
	}

	// Token: 0x06001FD6 RID: 8150 RVA: 0x001C1B88 File Offset: 0x001BFD88
	private void Update()
	{
		if (this.Empty)
		{
			if (this.Yandere.PickUp != null)
			{
				if ((this.Yandere.PickUp.Bucket != null && this.Yandere.PickUp.Bucket.Full) || this.Yandere.PickUp.BrownPaint || this.Yandere.PickUp.JerryCan)
				{
					this.Prompt.HideButton[0] = false;
					if (this.Prompt.Circle[0].fillAmount == 0f)
					{
						if (this.Yandere.PickUp.Bucket == null)
						{
							this.BrownPaint = this.Yandere.PickUp.BrownPaint;
							this.Gasoline = this.Yandere.PickUp.JerryCan;
							this.UpdateCylinderColor();
						}
						else
						{
							if (this.Yandere.PickUp.Bucket.DyedBrown)
							{
								this.BrownPaint = true;
							}
							else if (this.Yandere.PickUp.Bucket.Bloodiness > 50f)
							{
								this.Blood = true;
							}
							else if (this.Yandere.PickUp.Bucket.Gasoline)
							{
								this.Gasoline = true;
							}
							else
							{
								this.Water = true;
							}
							this.UpdateCylinderColor();
							this.Yandere.PickUp.Bucket.Empty();
						}
						this.Empty = false;
						this.Timer = 1f;
						this.Prompt.HideButton[0] = true;
					}
				}
				else
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
			this.Prompt.HideButton[1] = true;
		}
		else if (!this.TrapSet)
		{
			if (this.Yandere.Inventory.String && this.Yandere.Inventory.MaskingTape && this.Yandere.Weapon[1] != null && this.Yandere.Weapon[1].Type == WeaponType.Knife)
			{
				this.Prompt.HideButton[1] = false;
				this.Prompt.Label[1].applyGradient = false;
				this.Prompt.Label[1].color = Color.red;
				if (this.Prompt.Circle[1].fillAmount == 0f)
				{
					this.Prompt.Circle[1].fillAmount = 1f;
					this.Yandere.SuspiciousActionTimer = 1f;
					this.SetTrap();
				}
			}
			else
			{
				this.Prompt.HideButton[1] = true;
				this.Prompt.Label[1].applyGradient = true;
				this.Prompt.Label[1].gradientTop = this.OriginalColor[0];
				this.Prompt.Label[1].gradientBottom = this.OriginalColor[1];
			}
		}
		else if (this.Prompt.Circle[1].fillAmount == 0f)
		{
			this.Prompt.Circle[1].fillAmount = 1f;
			this.Prompt.Label[1].text = "     Create Tripwire Trap";
			this.Prompt.Label[1].applyGradient = false;
			this.Prompt.Label[1].color = Color.red;
			this.TripwireTrap.SetActive(false);
			this.TrapSet = false;
			this.Prompt.HideButton[3] = false;
			this.PickUp.enabled = true;
			this.MyRigidbody.isKinematic = false;
		}
		if (this.Timer > 0f)
		{
			this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
			if (this.Empty)
			{
				this.Cylinder.localScale = Vector3.Lerp(this.Cylinder.localScale, new Vector3(1f, 0f, 1f), Time.deltaTime * 10f);
			}
			else
			{
				this.Cylinder.localScale = Vector3.Lerp(this.Cylinder.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
		}
		if ((this.Prompt.enabled && this.Prompt.DistanceSqr < 1f) || (!this.Prompt.enabled && Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 1f))
		{
			if (this.WaterCoolerChecklist.alpha < 1f)
			{
				this.WaterCoolerChecklist.alpha = Mathf.MoveTowards(this.WaterCoolerChecklist.alpha, 1f, Time.deltaTime * 10f);
			}
			this.WeaponCheckmark.spriteName = ((this.Yandere.Weapon[1] != null && this.Yandere.Weapon[1].Type == WeaponType.Knife) ? "Yes" : "No");
			this.TapeCheckmark.spriteName = (this.Yandere.Inventory.MaskingTape ? "Yes" : "No");
			this.ThreadCheckmark.spriteName = (this.Yandere.Inventory.String ? "Yes" : "No");
			this.LiquidCheckmark.spriteName = ((!this.Empty) ? "Yes" : "No");
			return;
		}
		if (this.WaterCoolerChecklist.alpha > 0f)
		{
			this.WaterCoolerChecklist.alpha = Mathf.MoveTowards(this.WaterCoolerChecklist.alpha, 0f, Time.deltaTime * 10f);
		}
	}

	// Token: 0x06001FD7 RID: 8151 RVA: 0x001C2188 File Offset: 0x001C0388
	public void UpdateCylinderColor()
	{
		if (this.BrownPaint)
		{
			this.CylinderRenderer.material.color = new Color(0.5f, 0.25f, 0f, 1f);
			return;
		}
		if (this.Blood)
		{
			this.CylinderRenderer.material.color = new Color(1f, 0f, 0f, 1f);
			return;
		}
		if (this.Gasoline)
		{
			this.CylinderRenderer.material.color = new Color(1f, 1f, 0f, 1f);
			return;
		}
		this.CylinderRenderer.material.color = new Color(0f, 1f, 1f, 1f);
	}

	// Token: 0x06001FD8 RID: 8152 RVA: 0x001C2254 File Offset: 0x001C0454
	public void SetTrap()
	{
		this.Prompt.Label[1].text = "     Remove Trap";
		this.Prompt.Label[1].applyGradient = true;
		this.Prompt.Label[1].gradientTop = this.OriginalColor[0];
		this.Prompt.Label[1].gradientBottom = this.OriginalColor[1];
		this.Prompt.Label[1].color = Color.white;
		this.TripwireTrap.SetActive(true);
		this.TrapSet = true;
		this.Prompt.HideButton[1] = false;
		this.Prompt.HideButton[3] = true;
		this.PickUp.enabled = false;
		this.MyRigidbody.isKinematic = true;
	}

	// Token: 0x040042B8 RID: 17080
	public StringTrapScript Tripwire;

	// Token: 0x040042B9 RID: 17081
	public YandereScript Yandere;

	// Token: 0x040042BA RID: 17082
	public PickUpScript PickUp;

	// Token: 0x040042BB RID: 17083
	public PromptScript Prompt;

	// Token: 0x040042BC RID: 17084
	public UIPanel WaterCoolerChecklist;

	// Token: 0x040042BD RID: 17085
	public UISprite LiquidCheckmark;

	// Token: 0x040042BE RID: 17086
	public UISprite WeaponCheckmark;

	// Token: 0x040042BF RID: 17087
	public UISprite ThreadCheckmark;

	// Token: 0x040042C0 RID: 17088
	public UISprite TapeCheckmark;

	// Token: 0x040042C1 RID: 17089
	public Renderer CylinderRenderer;

	// Token: 0x040042C2 RID: 17090
	public GameObject TripwireTrap;

	// Token: 0x040042C3 RID: 17091
	public Rigidbody MyRigidbody;

	// Token: 0x040042C4 RID: 17092
	public Transform Cylinder;

	// Token: 0x040042C5 RID: 17093
	public bool BrownPaint;

	// Token: 0x040042C6 RID: 17094
	public bool Gasoline;

	// Token: 0x040042C7 RID: 17095
	public bool Water;

	// Token: 0x040042C8 RID: 17096
	public bool Blood;

	// Token: 0x040042C9 RID: 17097
	public bool TrapSet;

	// Token: 0x040042CA RID: 17098
	public bool Empty;

	// Token: 0x040042CB RID: 17099
	public float Timer;

	// Token: 0x040042CC RID: 17100
	public Color[] OriginalColor;
}
