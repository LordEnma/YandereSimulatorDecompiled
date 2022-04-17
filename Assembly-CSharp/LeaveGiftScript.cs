using System;
using UnityEngine;

// Token: 0x02000350 RID: 848
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x0600196E RID: 6510 RVA: 0x000FF5E8 File Offset: 0x000FD7E8
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

	// Token: 0x0600196F RID: 6511 RVA: 0x000FF638 File Offset: 0x000FD838
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

	// Token: 0x06001970 RID: 6512 RVA: 0x000FF720 File Offset: 0x000FD920
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x04002847 RID: 10311
	public EndOfDayScript EndOfDay;

	// Token: 0x04002848 RID: 10312
	public PromptScript Prompt;

	// Token: 0x04002849 RID: 10313
	public GameObject Note;

	// Token: 0x0400284A RID: 10314
	public GameObject Box;
}
