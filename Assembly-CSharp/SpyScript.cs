using System;
using UnityEngine;

// Token: 0x02000442 RID: 1090
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001D11 RID: 7441 RVA: 0x0015A87C File Offset: 0x00158A7C
	private void Start()
	{
	}

	// Token: 0x06001D12 RID: 7442 RVA: 0x0015A880 File Offset: 0x00158A80
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

	// Token: 0x06001D13 RID: 7443 RVA: 0x0015AA38 File Offset: 0x00158C38
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

	// Token: 0x0400349A RID: 13466
	public PromptBarScript PromptBar;

	// Token: 0x0400349B RID: 13467
	public YandereScript Yandere;

	// Token: 0x0400349C RID: 13468
	public PromptScript Prompt;

	// Token: 0x0400349D RID: 13469
	public GameObject SpyCamera;

	// Token: 0x0400349E RID: 13470
	public Transform SpyTarget;

	// Token: 0x0400349F RID: 13471
	public Transform SpySpot;

	// Token: 0x040034A0 RID: 13472
	public float Timer;

	// Token: 0x040034A1 RID: 13473
	public bool RecordEvent;

	// Token: 0x040034A2 RID: 13474
	public bool CanRecord;

	// Token: 0x040034A3 RID: 13475
	public bool Recording;

	// Token: 0x040034A4 RID: 13476
	public int Phase;
}
