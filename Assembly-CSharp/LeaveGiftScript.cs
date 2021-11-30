using System;
using UnityEngine;

// Token: 0x0200034A RID: 842
public class LeaveGiftScript : MonoBehaviour
{
	// Token: 0x06001937 RID: 6455 RVA: 0x000FC060 File Offset: 0x000FA260
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

	// Token: 0x06001938 RID: 6456 RVA: 0x000FC0B0 File Offset: 0x000FA2B0
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

	// Token: 0x06001939 RID: 6457 RVA: 0x000FC198 File Offset: 0x000FA398
	private void CheckForDisable()
	{
		if (this.Prompt.HideButton[0] && this.Prompt.HideButton[1])
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x040027A7 RID: 10151
	public EndOfDayScript EndOfDay;

	// Token: 0x040027A8 RID: 10152
	public PromptScript Prompt;

	// Token: 0x040027A9 RID: 10153
	public GameObject Note;

	// Token: 0x040027AA RID: 10154
	public GameObject Box;
}
