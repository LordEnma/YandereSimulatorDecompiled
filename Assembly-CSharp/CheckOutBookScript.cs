using System;
using UnityEngine;

// Token: 0x0200023F RID: 575
public class CheckOutBookScript : MonoBehaviour
{
	// Token: 0x0600123D RID: 4669 RVA: 0x0008BFAC File Offset: 0x0008A1AC
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

	// Token: 0x0600123E RID: 4670 RVA: 0x0008C020 File Offset: 0x0008A220
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

	// Token: 0x0600123F RID: 4671 RVA: 0x0008C0B4 File Offset: 0x0008A2B4
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

	// Token: 0x040016FD RID: 5885
	public PromptScript Prompt;

	// Token: 0x040016FE RID: 5886
	public int ID;
}
