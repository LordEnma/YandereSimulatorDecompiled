using System;
using UnityEngine;

// Token: 0x02000350 RID: 848
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x0600196A RID: 6506 RVA: 0x000FF354 File Offset: 0x000FD554
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

	// Token: 0x0600196B RID: 6507 RVA: 0x000FF3A4 File Offset: 0x000FD5A4
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

	// Token: 0x0600196C RID: 6508 RVA: 0x000FF48C File Offset: 0x000FD68C
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x0400283F RID: 10303
	public EndOfDayScript EndOfDay;

	// Token: 0x04002840 RID: 10304
	public PromptScript Prompt;

	// Token: 0x04002841 RID: 10305
	public GameObject Note;

	// Token: 0x04002842 RID: 10306
	public GameObject Box;
}
