using System;
using UnityEngine;

// Token: 0x0200034C RID: 844
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x06001944 RID: 6468 RVA: 0x000FCE90 File Offset: 0x000FB090
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

	// Token: 0x06001945 RID: 6469 RVA: 0x000FCEE0 File Offset: 0x000FB0E0
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

	// Token: 0x06001946 RID: 6470 RVA: 0x000FCFC8 File Offset: 0x000FB1C8
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x040027D4 RID: 10196
	public EndOfDayScript EndOfDay;

	// Token: 0x040027D5 RID: 10197
	public PromptScript Prompt;

	// Token: 0x040027D6 RID: 10198
	public GameObject Note;

	// Token: 0x040027D7 RID: 10199
	public GameObject Box;
}
