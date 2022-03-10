using System;
using UnityEngine;

// Token: 0x02000240 RID: 576
public class CheckOutBookScript : MonoBehaviour
{
	// Token: 0x06001241 RID: 4673 RVA: 0x0008C550 File Offset: 0x0008A750
	private void Start()
	{
		if (!GameGlobals.Eighties)
		{
			if (this.ID == 1)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.transform.parent.gameObject.SetActive(false);
				return;
			}
		}
		else if (this.ID == 0)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x06001242 RID: 4674 RVA: 0x0008C5C4 File Offset: 0x0008A7C4
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.ID == 0)
			{
				this.Prompt.Yandere.Inventory.Book = true;
			}
			else
			{
				this.Prompt.Yandere.NotificationManager.CustomText = "Finished homework assignment!";
				this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				this.Prompt.Yandere.Inventory.FinishedHomework = true;
			}
			this.UpdatePrompt();
		}
	}

	// Token: 0x06001243 RID: 4675 RVA: 0x0008C658 File Offset: 0x0008A858
	public void UpdatePrompt()
	{
		if ((this.ID == 0 && this.Prompt.Yandere.Inventory.Book) || (this.ID == 1 && this.Prompt.Yandere.Inventory.FinishedHomework))
		{
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			return;
		}
		this.Prompt.enabled = true;
		this.Prompt.Hide();
	}

	// Token: 0x0400170E RID: 5902
	public PromptScript Prompt;

	// Token: 0x0400170F RID: 5903
	public int ID;
}
