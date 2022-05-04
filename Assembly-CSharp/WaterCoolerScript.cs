using System;
using UnityEngine;

// Token: 0x020004C2 RID: 1218
public class WaterCoolerScript : MonoBehaviour
{
	// Token: 0x06001FDF RID: 8159 RVA: 0x001C2FBC File Offset: 0x001C11BC
	private void Start()
	{
		this.Cylinder.localScale = new Vector3(1f, 0f, 1f);
		this.TripwireTrap.SetActive(false);
		this.Prompt.HideButton[1] = true;
		this.OriginalColor[0] = this.Prompt.Label[1].gradientTop;
		this.OriginalColor[1] = this.Prompt.Label[1].gradientBottom;
	}

	// Token: 0x06001FE0 RID: 8160 RVA: 0x001C3040 File Offset: 0x001C1240
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

	// Token: 0x06001FE1 RID: 8161 RVA: 0x001C3640 File Offset: 0x001C1840
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

	// Token: 0x06001FE2 RID: 8162 RVA: 0x001C370C File Offset: 0x001C190C
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

	// Token: 0x040042CE RID: 17102
	public StringTrapScript Tripwire;

	// Token: 0x040042CF RID: 17103
	public YandereScript Yandere;

	// Token: 0x040042D0 RID: 17104
	public PickUpScript PickUp;

	// Token: 0x040042D1 RID: 17105
	public PromptScript Prompt;

	// Token: 0x040042D2 RID: 17106
	public UIPanel WaterCoolerChecklist;

	// Token: 0x040042D3 RID: 17107
	public UISprite LiquidCheckmark;

	// Token: 0x040042D4 RID: 17108
	public UISprite WeaponCheckmark;

	// Token: 0x040042D5 RID: 17109
	public UISprite ThreadCheckmark;

	// Token: 0x040042D6 RID: 17110
	public UISprite TapeCheckmark;

	// Token: 0x040042D7 RID: 17111
	public Renderer CylinderRenderer;

	// Token: 0x040042D8 RID: 17112
	public GameObject TripwireTrap;

	// Token: 0x040042D9 RID: 17113
	public Rigidbody MyRigidbody;

	// Token: 0x040042DA RID: 17114
	public Transform Cylinder;

	// Token: 0x040042DB RID: 17115
	public bool BrownPaint;

	// Token: 0x040042DC RID: 17116
	public bool Gasoline;

	// Token: 0x040042DD RID: 17117
	public bool Water;

	// Token: 0x040042DE RID: 17118
	public bool Blood;

	// Token: 0x040042DF RID: 17119
	public bool TrapSet;

	// Token: 0x040042E0 RID: 17120
	public bool Empty;

	// Token: 0x040042E1 RID: 17121
	public float Timer;

	// Token: 0x040042E2 RID: 17122
	public Color[] OriginalColor;
}
