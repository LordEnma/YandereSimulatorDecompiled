using System;
using UnityEngine;

// Token: 0x0200034E RID: 846
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x06001957 RID: 6487 RVA: 0x000FE40C File Offset: 0x000FC60C
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

	// Token: 0x06001958 RID: 6488 RVA: 0x000FE45C File Offset: 0x000FC65C
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

	// Token: 0x06001959 RID: 6489 RVA: 0x000FE544 File Offset: 0x000FC744
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x0400280C RID: 10252
	public EndOfDayScript EndOfDay;

	// Token: 0x0400280D RID: 10253
	public PromptScript Prompt;

	// Token: 0x0400280E RID: 10254
	public GameObject Note;

	// Token: 0x0400280F RID: 10255
	public GameObject Box;
}
