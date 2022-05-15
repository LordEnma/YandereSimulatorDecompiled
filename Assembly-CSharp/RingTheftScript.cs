using System;
using UnityEngine;

// Token: 0x020003DE RID: 990
public class RingTheftScript : MonoBehaviour
{
	// Token: 0x06001BB2 RID: 7090 RVA: 0x0013B4EC File Offset: 0x001396EC
	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			this.BasuRing.SetActive(false);
			this.Eighties = true;
		}
		else
		{
			base.transform.localPosition = new Vector3(11.272f, 0.8306667f, -1.3f);
			foreach (GameObject gameObject in this.Rings)
			{
				if (gameObject != null)
				{
					gameObject.SetActive(false);
				}
			}
		}
		base.gameObject.SetActive(false);
	}

	// Token: 0x06001BB3 RID: 7091 RVA: 0x0013B56C File Offset: 0x0013976C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
			if (!this.Prompt.Yandere.Inventory.Ring)
			{
				if (!this.Prompt.Yandere.StudentManager.YandereVisible)
				{
					if (this.Eighties)
					{
						this.Rings[DateGlobals.Week].SetActive(false);
					}
					else
					{
						this.BasuRing.SetActive(false);
					}
					this.Prompt.Yandere.Inventory.Ring = true;
					this.Stolen = true;
					this.Prompt.Label[0].text = "     Return Stolen Ring";
					return;
				}
				this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
				this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				return;
			}
			else
			{
				if (this.Eighties)
				{
					this.Rings[DateGlobals.Week].SetActive(true);
				}
				else
				{
					this.BasuRing.SetActive(true);
				}
				this.Prompt.Yandere.Inventory.Ring = false;
				this.Stolen = false;
				this.Prompt.Label[0].text = "     Steal Ring";
			}
		}
	}

	// Token: 0x04002F9D RID: 12189
	public PromptScript Prompt;

	// Token: 0x04002F9E RID: 12190
	public GameObject BasuRing;

	// Token: 0x04002F9F RID: 12191
	public GameObject[] Rings;

	// Token: 0x04002FA0 RID: 12192
	public bool Eighties;

	// Token: 0x04002FA1 RID: 12193
	public bool Stolen;
}
