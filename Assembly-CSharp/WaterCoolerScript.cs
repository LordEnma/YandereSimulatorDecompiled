using System;
using UnityEngine;

// Token: 0x020004C1 RID: 1217
public class WaterCoolerScript : MonoBehaviour
{
	// Token: 0x06001FCF RID: 8143 RVA: 0x001C1128 File Offset: 0x001BF328
	private void Start()
	{
		this.Cylinder.localScale = new Vector3(1f, 0f, 1f);
		this.TripwireTrap.SetActive(false);
		this.Prompt.HideButton[1] = true;
		this.OriginalColor[0] = this.Prompt.Label[1].gradientTop;
		this.OriginalColor[1] = this.Prompt.Label[1].gradientBottom;
	}

	// Token: 0x06001FD0 RID: 8144 RVA: 0x001C11AC File Offset: 0x001BF3AC
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

	// Token: 0x06001FD1 RID: 8145 RVA: 0x001C17AC File Offset: 0x001BF9AC
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

	// Token: 0x06001FD2 RID: 8146 RVA: 0x001C1878 File Offset: 0x001BFA78
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

	// Token: 0x040042A8 RID: 17064
	public StringTrapScript Tripwire;

	// Token: 0x040042A9 RID: 17065
	public YandereScript Yandere;

	// Token: 0x040042AA RID: 17066
	public PickUpScript PickUp;

	// Token: 0x040042AB RID: 17067
	public PromptScript Prompt;

	// Token: 0x040042AC RID: 17068
	public UIPanel WaterCoolerChecklist;

	// Token: 0x040042AD RID: 17069
	public UISprite LiquidCheckmark;

	// Token: 0x040042AE RID: 17070
	public UISprite WeaponCheckmark;

	// Token: 0x040042AF RID: 17071
	public UISprite ThreadCheckmark;

	// Token: 0x040042B0 RID: 17072
	public UISprite TapeCheckmark;

	// Token: 0x040042B1 RID: 17073
	public Renderer CylinderRenderer;

	// Token: 0x040042B2 RID: 17074
	public GameObject TripwireTrap;

	// Token: 0x040042B3 RID: 17075
	public Rigidbody MyRigidbody;

	// Token: 0x040042B4 RID: 17076
	public Transform Cylinder;

	// Token: 0x040042B5 RID: 17077
	public bool BrownPaint;

	// Token: 0x040042B6 RID: 17078
	public bool Gasoline;

	// Token: 0x040042B7 RID: 17079
	public bool Water;

	// Token: 0x040042B8 RID: 17080
	public bool Blood;

	// Token: 0x040042B9 RID: 17081
	public bool TrapSet;

	// Token: 0x040042BA RID: 17082
	public bool Empty;

	// Token: 0x040042BB RID: 17083
	public float Timer;

	// Token: 0x040042BC RID: 17084
	public Color[] OriginalColor;
}
