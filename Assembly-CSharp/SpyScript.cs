using System;
using UnityEngine;

// Token: 0x0200043B RID: 1083
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001CDA RID: 7386 RVA: 0x00156CDC File Offset: 0x00154EDC
	private void Start()
	{
	}

	// Token: 0x06001CDB RID: 7387 RVA: 0x00156CE0 File Offset: 0x00154EE0
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

	// Token: 0x06001CDC RID: 7388 RVA: 0x00156E98 File Offset: 0x00155098
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

	// Token: 0x04003405 RID: 13317
	public PromptBarScript PromptBar;

	// Token: 0x04003406 RID: 13318
	public YandereScript Yandere;

	// Token: 0x04003407 RID: 13319
	public PromptScript Prompt;

	// Token: 0x04003408 RID: 13320
	public GameObject SpyCamera;

	// Token: 0x04003409 RID: 13321
	public Transform SpyTarget;

	// Token: 0x0400340A RID: 13322
	public Transform SpySpot;

	// Token: 0x0400340B RID: 13323
	public float Timer;

	// Token: 0x0400340C RID: 13324
	public bool RecordEvent;

	// Token: 0x0400340D RID: 13325
	public bool CanRecord;

	// Token: 0x0400340E RID: 13326
	public bool Recording;

	// Token: 0x0400340F RID: 13327
	public int Phase;
}
