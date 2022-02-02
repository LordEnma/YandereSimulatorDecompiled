using System;
using UnityEngine;

// Token: 0x0200034C RID: 844
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x06001945 RID: 6469 RVA: 0x000FD430 File Offset: 0x000FB630
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

	// Token: 0x06001946 RID: 6470 RVA: 0x000FD480 File Offset: 0x000FB680
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

	// Token: 0x06001947 RID: 6471 RVA: 0x000FD568 File Offset: 0x000FB768
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x040027DD RID: 10205
	public EndOfDayScript EndOfDay;

	// Token: 0x040027DE RID: 10206
	public PromptScript Prompt;

	// Token: 0x040027DF RID: 10207
	public GameObject Note;

	// Token: 0x040027E0 RID: 10208
	public GameObject Box;
}
