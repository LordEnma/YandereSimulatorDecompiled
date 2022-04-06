using System;
using UnityEngine;

// Token: 0x02000442 RID: 1090
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001D0D RID: 7437 RVA: 0x0015A46C File Offset: 0x0015866C
	private void Start()
	{
	}

	// Token: 0x06001D0E RID: 7438 RVA: 0x0015A470 File Offset: 0x00158670
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

	// Token: 0x06001D0F RID: 7439 RVA: 0x0015A628 File Offset: 0x00158828
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

	// Token: 0x0400348F RID: 13455
	public PromptBarScript PromptBar;

	// Token: 0x04003490 RID: 13456
	public YandereScript Yandere;

	// Token: 0x04003491 RID: 13457
	public PromptScript Prompt;

	// Token: 0x04003492 RID: 13458
	public GameObject SpyCamera;

	// Token: 0x04003493 RID: 13459
	public Transform SpyTarget;

	// Token: 0x04003494 RID: 13460
	public Transform SpySpot;

	// Token: 0x04003495 RID: 13461
	public float Timer;

	// Token: 0x04003496 RID: 13462
	public bool RecordEvent;

	// Token: 0x04003497 RID: 13463
	public bool CanRecord;

	// Token: 0x04003498 RID: 13464
	public bool Recording;

	// Token: 0x04003499 RID: 13465
	public int Phase;
}
