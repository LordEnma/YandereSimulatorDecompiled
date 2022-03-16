using System;
using UnityEngine;

// Token: 0x020004BD RID: 1213
public class WaterCoolerScript : MonoBehaviour
{
	// Token: 0x06001FBD RID: 8125 RVA: 0x001BF693 File Offset: 0x001BD893
	private void Start()
	{
		this.Cylinder.localScale = new Vector3(1f, 0f, 1f);
		this.TripwireTrap.SetActive(false);
		this.Prompt.HideButton[1] = true;
	}

	// Token: 0x06001FBE RID: 8126 RVA: 0x001BF6D0 File Offset: 0x001BD8D0
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
			}
		}
		else if (this.Prompt.Circle[1].fillAmount == 0f)
		{
			this.Prompt.Circle[1].fillAmount = 1f;
			this.Prompt.Label[1].text = "     Create Tripwire Trap";
			this.TripwireTrap.SetActive(false);
			this.TrapSet = false;
			this.Prompt.HideButton[3] = false;
			this.PickUp.enabled = true;
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

	// Token: 0x06001FBF RID: 8127 RVA: 0x001BFC10 File Offset: 0x001BDE10
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

	// Token: 0x06001FC0 RID: 8128 RVA: 0x001BFCDC File Offset: 0x001BDEDC
	public void SetTrap()
	{
		this.Prompt.Label[1].text = "     Remove Trap";
		this.TripwireTrap.SetActive(true);
		this.TrapSet = true;
		this.Prompt.HideButton[1] = false;
		this.Prompt.HideButton[3] = true;
		this.PickUp.enabled = false;
	}

	// Token: 0x04004278 RID: 17016
	public StringTrapScript Tripwire;

	// Token: 0x04004279 RID: 17017
	public YandereScript Yandere;

	// Token: 0x0400427A RID: 17018
	public PickUpScript PickUp;

	// Token: 0x0400427B RID: 17019
	public PromptScript Prompt;

	// Token: 0x0400427C RID: 17020
	public UIPanel WaterCoolerChecklist;

	// Token: 0x0400427D RID: 17021
	public UISprite LiquidCheckmark;

	// Token: 0x0400427E RID: 17022
	public UISprite WeaponCheckmark;

	// Token: 0x0400427F RID: 17023
	public UISprite ThreadCheckmark;

	// Token: 0x04004280 RID: 17024
	public UISprite TapeCheckmark;

	// Token: 0x04004281 RID: 17025
	public Renderer CylinderRenderer;

	// Token: 0x04004282 RID: 17026
	public GameObject TripwireTrap;

	// Token: 0x04004283 RID: 17027
	public Transform Cylinder;

	// Token: 0x04004284 RID: 17028
	public bool BrownPaint;

	// Token: 0x04004285 RID: 17029
	public bool Gasoline;

	// Token: 0x04004286 RID: 17030
	public bool Water;

	// Token: 0x04004287 RID: 17031
	public bool Blood;

	// Token: 0x04004288 RID: 17032
	public bool TrapSet;

	// Token: 0x04004289 RID: 17033
	public bool Empty;

	// Token: 0x0400428A RID: 17034
	public float Timer;
}
