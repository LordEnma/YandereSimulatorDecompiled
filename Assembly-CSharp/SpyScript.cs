using System;
using UnityEngine;

// Token: 0x0200043C RID: 1084
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001CE4 RID: 7396 RVA: 0x001576B4 File Offset: 0x001558B4
	private void Start()
	{
	}

	// Token: 0x06001CE5 RID: 7397 RVA: 0x001576B8 File Offset: 0x001558B8
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

	// Token: 0x06001CE6 RID: 7398 RVA: 0x00157870 File Offset: 0x00155A70
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

	// Token: 0x04003415 RID: 13333
	public PromptBarScript PromptBar;

	// Token: 0x04003416 RID: 13334
	public YandereScript Yandere;

	// Token: 0x04003417 RID: 13335
	public PromptScript Prompt;

	// Token: 0x04003418 RID: 13336
	public GameObject SpyCamera;

	// Token: 0x04003419 RID: 13337
	public Transform SpyTarget;

	// Token: 0x0400341A RID: 13338
	public Transform SpySpot;

	// Token: 0x0400341B RID: 13339
	public float Timer;

	// Token: 0x0400341C RID: 13340
	public bool RecordEvent;

	// Token: 0x0400341D RID: 13341
	public bool CanRecord;

	// Token: 0x0400341E RID: 13342
	public bool Recording;

	// Token: 0x0400341F RID: 13343
	public int Phase;
}
