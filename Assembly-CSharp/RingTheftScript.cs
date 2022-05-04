using System;
using UnityEngine;

// Token: 0x020003DD RID: 989
public class RingTheftScript : MonoBehaviour
{
	// Token: 0x06001BAC RID: 7084 RVA: 0x0013A96C File Offset: 0x00138B6C
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

	// Token: 0x06001BAD RID: 7085 RVA: 0x0013A9EC File Offset: 0x00138BEC
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
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
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.enabled = false;
				return;
			}
			this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x04002F88 RID: 12168
	public PromptScript Prompt;

	// Token: 0x04002F89 RID: 12169
	public GameObject BasuRing;

	// Token: 0x04002F8A RID: 12170
	public GameObject[] Rings;

	// Token: 0x04002F8B RID: 12171
	public bool Eighties;

	// Token: 0x04002F8C RID: 12172
	public bool Stolen;
}
