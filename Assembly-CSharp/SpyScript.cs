using System;
using UnityEngine;

// Token: 0x02000444 RID: 1092
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001D1F RID: 7455 RVA: 0x0015BFF4 File Offset: 0x0015A1F4
	private void Start()
	{
	}

	// Token: 0x06001D20 RID: 7456 RVA: 0x0015BFF8 File Offset: 0x0015A1F8
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

	// Token: 0x06001D21 RID: 7457 RVA: 0x0015C1B0 File Offset: 0x0015A3B0
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

	// Token: 0x040034C6 RID: 13510
	public PromptBarScript PromptBar;

	// Token: 0x040034C7 RID: 13511
	public YandereScript Yandere;

	// Token: 0x040034C8 RID: 13512
	public PromptScript Prompt;

	// Token: 0x040034C9 RID: 13513
	public GameObject SpyCamera;

	// Token: 0x040034CA RID: 13514
	public Transform SpyTarget;

	// Token: 0x040034CB RID: 13515
	public Transform SpySpot;

	// Token: 0x040034CC RID: 13516
	public float Timer;

	// Token: 0x040034CD RID: 13517
	public bool RecordEvent;

	// Token: 0x040034CE RID: 13518
	public bool CanRecord;

	// Token: 0x040034CF RID: 13519
	public bool Recording;

	// Token: 0x040034D0 RID: 13520
	public int Phase;
}
