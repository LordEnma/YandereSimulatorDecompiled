using System;
using UnityEngine;

// Token: 0x0200034B RID: 843
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x06001940 RID: 6464 RVA: 0x000FCB30 File Offset: 0x000FAD30
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

	// Token: 0x06001941 RID: 6465 RVA: 0x000FCB80 File Offset: 0x000FAD80
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

	// Token: 0x06001942 RID: 6466 RVA: 0x000FCC68 File Offset: 0x000FAE68
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x040027D0 RID: 10192
	public EndOfDayScript EndOfDay;

	// Token: 0x040027D1 RID: 10193
	public PromptScript Prompt;

	// Token: 0x040027D2 RID: 10194
	public GameObject Note;

	// Token: 0x040027D3 RID: 10195
	public GameObject Box;
}
