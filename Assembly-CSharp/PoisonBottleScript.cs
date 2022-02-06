using System;
using UnityEngine;

// Token: 0x020003A9 RID: 937
public class PoisonBottleScript : MonoBehaviour
{
	// Token: 0x06001AB2 RID: 6834 RVA: 0x001219EC File Offset: 0x0011FBEC
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Theft)
			{
				this.Prompt.Yandere.TheftTimer = 0.1f;
			}
			if (this.ID == 1)
			{
				this.Prompt.Yandere.Inventory.EmeticPoison = true;
			}
			else if (this.ID == 2)
			{
				this.Prompt.Yandere.Inventory.LethalPoison = true;
				this.Prompt.Yandere.Inventory.LethalPoisons++;
			}
			else if (this.ID == 3)
			{
				if (!this.Prompt.Yandere.Inventory.RatPoison)
				{
					this.Prompt.Yandere.Inventory.RatPoison = true;
				}
				else
				{
					this.Prompt.Yandere.NotificationManager.CustomText = "You're already carrying some of that";
					this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			else if (this.ID == 4)
			{
				this.Prompt.Yandere.Inventory.HeadachePoison = true;
			}
			else if (this.ID == 5)
			{
				this.Prompt.Yandere.Inventory.Tranquilizer = true;
			}
			else if (this.ID == 6)
			{
				this.Prompt.Yandere.Inventory.Sedative = true;
			}
			this.Prompt.Yandere.StudentManager.UpdateAllBentos();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002C81 RID: 11393
	public PromptScript Prompt;

	// Token: 0x04002C82 RID: 11394
	public bool Theft;

	// Token: 0x04002C83 RID: 11395
	public int ID;
}
