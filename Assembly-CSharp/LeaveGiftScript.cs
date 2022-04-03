using System;
using UnityEngine;

// Token: 0x0200034F RID: 847
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x06001964 RID: 6500 RVA: 0x000FF254 File Offset: 0x000FD454
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

	// Token: 0x06001965 RID: 6501 RVA: 0x000FF2A4 File Offset: 0x000FD4A4
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

	// Token: 0x06001966 RID: 6502 RVA: 0x000FF38C File Offset: 0x000FD58C
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x0400283C RID: 10300
	public EndOfDayScript EndOfDay;

	// Token: 0x0400283D RID: 10301
	public PromptScript Prompt;

	// Token: 0x0400283E RID: 10302
	public GameObject Note;

	// Token: 0x0400283F RID: 10303
	public GameObject Box;
}
