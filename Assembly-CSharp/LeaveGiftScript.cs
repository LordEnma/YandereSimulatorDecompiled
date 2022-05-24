using System;
using UnityEngine;

// Token: 0x02000351 RID: 849
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x06001979 RID: 6521 RVA: 0x001004F8 File Offset: 0x000FE6F8
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

	// Token: 0x0600197A RID: 6522 RVA: 0x00100548 File Offset: 0x000FE748
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

	// Token: 0x0600197B RID: 6523 RVA: 0x00100630 File Offset: 0x000FE830
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x04002868 RID: 10344
	public EndOfDayScript EndOfDay;

	// Token: 0x04002869 RID: 10345
	public PromptScript Prompt;

	// Token: 0x0400286A RID: 10346
	public GameObject Note;

	// Token: 0x0400286B RID: 10347
	public GameObject Box;
}
