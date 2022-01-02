using System;
using UnityEngine;

// Token: 0x02000438 RID: 1080
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001CD1 RID: 7377 RVA: 0x001552C4 File Offset: 0x001534C4
	private void Start()
	{
	}

	// Token: 0x06001CD2 RID: 7378 RVA: 0x001552C8 File Offset: 0x001534C8
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

	// Token: 0x06001CD3 RID: 7379 RVA: 0x00155480 File Offset: 0x00153680
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

	// Token: 0x040033FA RID: 13306
	public PromptBarScript PromptBar;

	// Token: 0x040033FB RID: 13307
	public YandereScript Yandere;

	// Token: 0x040033FC RID: 13308
	public PromptScript Prompt;

	// Token: 0x040033FD RID: 13309
	public GameObject SpyCamera;

	// Token: 0x040033FE RID: 13310
	public Transform SpyTarget;

	// Token: 0x040033FF RID: 13311
	public Transform SpySpot;

	// Token: 0x04003400 RID: 13312
	public float Timer;

	// Token: 0x04003401 RID: 13313
	public bool RecordEvent;

	// Token: 0x04003402 RID: 13314
	public bool CanRecord;

	// Token: 0x04003403 RID: 13315
	public bool Recording;

	// Token: 0x04003404 RID: 13316
	public int Phase;
}
