using System;
using UnityEngine;

// Token: 0x0200034C RID: 844
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x06001944 RID: 6468 RVA: 0x000FCFF8 File Offset: 0x000FB1F8
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

	// Token: 0x06001945 RID: 6469 RVA: 0x000FD048 File Offset: 0x000FB248
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

	// Token: 0x06001946 RID: 6470 RVA: 0x000FD130 File Offset: 0x000FB330
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x040027D7 RID: 10199
	public EndOfDayScript EndOfDay;

	// Token: 0x040027D8 RID: 10200
	public PromptScript Prompt;

	// Token: 0x040027D9 RID: 10201
	public GameObject Note;

	// Token: 0x040027DA RID: 10202
	public GameObject Box;
}
