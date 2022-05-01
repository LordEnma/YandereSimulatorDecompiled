using System;
using UnityEngine;

// Token: 0x02000350 RID: 848
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x06001972 RID: 6514 RVA: 0x000FFAEC File Offset: 0x000FDCEC
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

	// Token: 0x06001973 RID: 6515 RVA: 0x000FFB3C File Offset: 0x000FDD3C
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

	// Token: 0x06001974 RID: 6516 RVA: 0x000FFC24 File Offset: 0x000FDE24
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x04002850 RID: 10320
	public EndOfDayScript EndOfDay;

	// Token: 0x04002851 RID: 10321
	public PromptScript Prompt;

	// Token: 0x04002852 RID: 10322
	public GameObject Note;

	// Token: 0x04002853 RID: 10323
	public GameObject Box;
}
