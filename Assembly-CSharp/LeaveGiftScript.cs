using System;
using UnityEngine;

// Token: 0x0200034D RID: 845
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x0600194E RID: 6478 RVA: 0x000FD79C File Offset: 0x000FB99C
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

	// Token: 0x0600194F RID: 6479 RVA: 0x000FD7EC File Offset: 0x000FB9EC
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

	// Token: 0x06001950 RID: 6480 RVA: 0x000FD8D4 File Offset: 0x000FBAD4
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x040027E7 RID: 10215
	public EndOfDayScript EndOfDay;

	// Token: 0x040027E8 RID: 10216
	public PromptScript Prompt;

	// Token: 0x040027E9 RID: 10217
	public GameObject Note;

	// Token: 0x040027EA RID: 10218
	public GameObject Box;
}
