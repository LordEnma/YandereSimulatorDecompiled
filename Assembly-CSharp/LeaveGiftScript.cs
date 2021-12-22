using System;
using UnityEngine;

// Token: 0x0200034B RID: 843
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x0600193E RID: 6462 RVA: 0x000FC870 File Offset: 0x000FAA70
	private void Start()
	{
		this.Note.SetActive(false);
		this.Box.SetActive(false);
		this.EndOfDay.SenpaiGifts = CollectibleGlobals.SenpaiGifts;
		if (this.EndOfDay.SenpaiGifts == 0)
		{
			this.Prompt.HideButton[1] = true;
		}
	}

	// Token: 0x0600193F RID: 6463 RVA: 0x000FC8C0 File Offset: 0x000FAAC0
	private void Update()
	{
		if (this.Prompt.InView)
		{
			if (Vector3.Distance(this.Prompt.Yandere.transform.position, this.Prompt.Yandere.Senpai.position) > 10f)
			{
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Prompt.HideButton[0] = true;
					this.Note.SetActive(true);
					this.CheckForDisable();
					return;
				}
				if (this.Prompt.Circle[1].fillAmount == 0f)
				{
					this.Prompt.HideButton[1] = true;
					this.EndOfDay.SenpaiGifts--;
					this.Box.SetActive(true);
					this.CheckForDisable();
					return;
				}
			}
			else
			{
				this.Prompt.Hide();
			}
		}
	}

	// Token: 0x06001940 RID: 6464 RVA: 0x000FC9A8 File Offset: 0x000FABA8
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x040027CC RID: 10188
	public EndOfDayScript EndOfDay;

	// Token: 0x040027CD RID: 10189
	public PromptScript Prompt;

	// Token: 0x040027CE RID: 10190
	public GameObject Note;

	// Token: 0x040027CF RID: 10191
	public GameObject Box;
}
