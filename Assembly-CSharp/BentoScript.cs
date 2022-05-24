using System;
using UnityEngine;

// Token: 0x020000E4 RID: 228
public class BentoScript : MonoBehaviour
{
	// Token: 0x06000A29 RID: 2601 RVA: 0x0005A444 File Offset: 0x00058644
	private void Start()
	{
		if (this.Prompt.Yandere != null)
		{
			this.Yandere = this.Prompt.Yandere;
		}
	}

	// Token: 0x06000A2A RID: 2602 RVA: 0x0005A46C File Offset: 0x0005866C
	private void Update()
	{
		if (this.Yandere == null)
		{
			if (this.Prompt.Yandere != null)
			{
				this.Yandere = this.Prompt.Yandere;
				return;
			}
		}
		else if (this.Yandere.Inventory.EmeticPoison || this.Yandere.Inventory.RatPoison || this.Yandere.Inventory.LethalPoison || this.Yandere.Inventory.ChemicalPoison)
		{
			this.Prompt.enabled = true;
			if (!this.Yandere.Inventory.EmeticPoison && !this.Yandere.Inventory.RatPoison)
			{
				this.Prompt.HideButton[0] = true;
			}
			else
			{
				this.Prompt.HideButton[0] = false;
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!this.Prompt.Yandere.StudentManager.YandereVisible)
				{
					if (this.Yandere.Inventory.EmeticPoison)
					{
						this.Yandere.Inventory.EmeticPoison = false;
						this.Yandere.PoisonType = 1;
					}
					else
					{
						this.Yandere.Inventory.RatPoison = false;
						this.Yandere.PoisonType = 3;
					}
					this.StudentManager.Students[this.ID].MyBento.Tampered = true;
					this.StudentManager.Students[this.ID].MyBento.Emetic = true;
					this.StudentManager.Students[this.ID].Emetic = true;
					this.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
					this.Yandere.PoisonSpot = this.PoisonSpot;
					this.Yandere.Poisoning = true;
					this.Yandere.CanMove = false;
					base.enabled = false;
					this.Poison = 1;
					if (this.ID != 1)
					{
						this.StudentManager.Students[this.ID].Emetic = true;
					}
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Prompt.Yandere.StudentManager.UpdateAllBentos();
				}
				else
				{
					this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			if (this.ID == 11 || this.ID == 6)
			{
				if (this.Prompt.Yandere.Inventory.LethalPoison || this.Prompt.Yandere.Inventory.ChemicalPoison)
				{
					this.Prompt.HideButton[1] = false;
				}
				else
				{
					this.Prompt.HideButton[1] = true;
				}
				if (this.Prompt.Circle[1].fillAmount == 0f)
				{
					if (this.Yandere.Inventory.LethalPoison)
					{
						this.Yandere.Inventory.LethalPoison = false;
					}
					else
					{
						this.Yandere.Inventory.ChemicalPoison = false;
					}
					this.Prompt.Yandere.Inventory.LethalPoisons--;
					this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
					this.StudentManager.Students[this.ID].MyBento.Tampered = true;
					this.StudentManager.Students[this.ID].MyBento.Lethal = true;
					this.StudentManager.Students[this.ID].Lethal = true;
					this.Prompt.Yandere.PoisonSpot = this.PoisonSpot;
					this.Prompt.Yandere.Poisoning = true;
					this.Prompt.Yandere.CanMove = false;
					this.Prompt.Yandere.PoisonType = 2;
					base.enabled = false;
					this.Poison = 2;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Prompt.Yandere.StudentManager.UpdateAllBentos();
					return;
				}
			}
		}
		else
		{
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x04000B89 RID: 2953
	public StudentManagerScript StudentManager;

	// Token: 0x04000B8A RID: 2954
	public YandereScript Yandere;

	// Token: 0x04000B8B RID: 2955
	public Transform PoisonSpot;

	// Token: 0x04000B8C RID: 2956
	public PromptScript Prompt;

	// Token: 0x04000B8D RID: 2957
	public int Poison;

	// Token: 0x04000B8E RID: 2958
	public int ID;
}
