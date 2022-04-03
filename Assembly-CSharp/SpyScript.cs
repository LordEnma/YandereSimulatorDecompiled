using System;
using UnityEngine;

// Token: 0x02000441 RID: 1089
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001D06 RID: 7430 RVA: 0x0015A14C File Offset: 0x0015834C
	private void Start()
	{
	}

	// Token: 0x06001D07 RID: 7431 RVA: 0x0015A150 File Offset: 0x00158350
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

	// Token: 0x06001D08 RID: 7432 RVA: 0x0015A308 File Offset: 0x00158508
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

	// Token: 0x0400348C RID: 13452
	public PromptBarScript PromptBar;

	// Token: 0x0400348D RID: 13453
	public YandereScript Yandere;

	// Token: 0x0400348E RID: 13454
	public PromptScript Prompt;

	// Token: 0x0400348F RID: 13455
	public GameObject SpyCamera;

	// Token: 0x04003490 RID: 13456
	public Transform SpyTarget;

	// Token: 0x04003491 RID: 13457
	public Transform SpySpot;

	// Token: 0x04003492 RID: 13458
	public float Timer;

	// Token: 0x04003493 RID: 13459
	public bool RecordEvent;

	// Token: 0x04003494 RID: 13460
	public bool CanRecord;

	// Token: 0x04003495 RID: 13461
	public bool Recording;

	// Token: 0x04003496 RID: 13462
	public int Phase;
}
