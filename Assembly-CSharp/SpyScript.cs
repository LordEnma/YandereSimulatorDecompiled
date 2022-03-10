using System;
using UnityEngine;

// Token: 0x0200043D RID: 1085
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001CEF RID: 7407 RVA: 0x001586E4 File Offset: 0x001568E4
	private void Start()
	{
	}

	// Token: 0x06001CF0 RID: 7408 RVA: 0x001586E8 File Offset: 0x001568E8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.CharacterAnimation.CrossFade("f02_spying_00");
			this.Yandere.CanMove = false;
			this.Phase++;
		}
		if (this.Phase == 1)
		{
			Quaternion b = Quaternion.LookRotation(this.SpyTarget.transform.position - this.Yandere.transform.position);
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, b, Time.deltaTime * 10f);
			this.Yandere.MoveTowardsTarget(this.SpySpot.position);
			if (!this.Recording && this.RecordEvent && this.Yandere.Inventory.DirectionalMic)
			{
				this.Yandere.CharacterAnimation.CrossFade("f02_spyRecord_00");
				this.Yandere.Microphone.SetActive(true);
				this.Recording = true;
			}
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.PromptBar.Label[1].text = "Stop";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.Yandere.MainCamera.enabled = false;
				this.SpyCamera.SetActive(true);
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 2 && Input.GetButtonDown("B"))
		{
			this.End();
		}
	}

	// Token: 0x06001CF1 RID: 7409 RVA: 0x001588A0 File Offset: 0x00156AA0
	public void End()
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.Yandere.Microphone.SetActive(false);
		this.Yandere.MainCamera.enabled = true;
		this.Yandere.CanMove = true;
		this.SpyCamera.SetActive(false);
		this.Timer = 0f;
		this.Phase = 0;
	}

	// Token: 0x0400343B RID: 13371
	public PromptBarScript PromptBar;

	// Token: 0x0400343C RID: 13372
	public YandereScript Yandere;

	// Token: 0x0400343D RID: 13373
	public PromptScript Prompt;

	// Token: 0x0400343E RID: 13374
	public GameObject SpyCamera;

	// Token: 0x0400343F RID: 13375
	public Transform SpyTarget;

	// Token: 0x04003440 RID: 13376
	public Transform SpySpot;

	// Token: 0x04003441 RID: 13377
	public float Timer;

	// Token: 0x04003442 RID: 13378
	public bool RecordEvent;

	// Token: 0x04003443 RID: 13379
	public bool CanRecord;

	// Token: 0x04003444 RID: 13380
	public bool Recording;

	// Token: 0x04003445 RID: 13381
	public int Phase;
}
