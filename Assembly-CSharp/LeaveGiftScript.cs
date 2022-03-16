using System;
using UnityEngine;

// Token: 0x0200034E RID: 846
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x0600195E RID: 6494 RVA: 0x000FEBC8 File Offset: 0x000FCDC8
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

	// Token: 0x0600195F RID: 6495 RVA: 0x000FEC18 File Offset: 0x000FCE18
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

	// Token: 0x06001960 RID: 6496 RVA: 0x000FED00 File Offset: 0x000FCF00
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x04002829 RID: 10281
	public EndOfDayScript EndOfDay;

	// Token: 0x0400282A RID: 10282
	public PromptScript Prompt;

	// Token: 0x0400282B RID: 10283
	public GameObject Note;

	// Token: 0x0400282C RID: 10284
	public GameObject Box;
}
