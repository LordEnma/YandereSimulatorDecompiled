using System;
using UnityEngine;

// Token: 0x0200034C RID: 844
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x06001947 RID: 6471 RVA: 0x000FD5F8 File Offset: 0x000FB7F8
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

	// Token: 0x06001948 RID: 6472 RVA: 0x000FD648 File Offset: 0x000FB848
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

	// Token: 0x06001949 RID: 6473 RVA: 0x000FD730 File Offset: 0x000FB930
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x040027E1 RID: 10209
	public EndOfDayScript EndOfDay;

	// Token: 0x040027E2 RID: 10210
	public PromptScript Prompt;

	// Token: 0x040027E3 RID: 10211
	public GameObject Note;

	// Token: 0x040027E4 RID: 10212
	public GameObject Box;
}
