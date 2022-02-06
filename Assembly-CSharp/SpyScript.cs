﻿using System;
using UnityEngine;

// Token: 0x0200043B RID: 1083
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001CDD RID: 7389 RVA: 0x001573AC File Offset: 0x001555AC
	private void Start()
	{
	}

	// Token: 0x06001CDE RID: 7390 RVA: 0x001573B0 File Offset: 0x001555B0
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

	// Token: 0x06001CDF RID: 7391 RVA: 0x00157568 File Offset: 0x00155768
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

	// Token: 0x0400340F RID: 13327
	public PromptBarScript PromptBar;

	// Token: 0x04003410 RID: 13328
	public YandereScript Yandere;

	// Token: 0x04003411 RID: 13329
	public PromptScript Prompt;

	// Token: 0x04003412 RID: 13330
	public GameObject SpyCamera;

	// Token: 0x04003413 RID: 13331
	public Transform SpyTarget;

	// Token: 0x04003414 RID: 13332
	public Transform SpySpot;

	// Token: 0x04003415 RID: 13333
	public float Timer;

	// Token: 0x04003416 RID: 13334
	public bool RecordEvent;

	// Token: 0x04003417 RID: 13335
	public bool CanRecord;

	// Token: 0x04003418 RID: 13336
	public bool Recording;

	// Token: 0x04003419 RID: 13337
	public int Phase;
}
