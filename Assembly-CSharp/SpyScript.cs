using System;
using UnityEngine;

// Token: 0x02000444 RID: 1092
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001D1E RID: 7454 RVA: 0x0015BD38 File Offset: 0x00159F38
	private void Start()
	{
	}

	// Token: 0x06001D1F RID: 7455 RVA: 0x0015BD3C File Offset: 0x00159F3C
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

	// Token: 0x06001D20 RID: 7456 RVA: 0x0015BEF4 File Offset: 0x0015A0F4
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

	// Token: 0x040034BE RID: 13502
	public PromptBarScript PromptBar;

	// Token: 0x040034BF RID: 13503
	public YandereScript Yandere;

	// Token: 0x040034C0 RID: 13504
	public PromptScript Prompt;

	// Token: 0x040034C1 RID: 13505
	public GameObject SpyCamera;

	// Token: 0x040034C2 RID: 13506
	public Transform SpyTarget;

	// Token: 0x040034C3 RID: 13507
	public Transform SpySpot;

	// Token: 0x040034C4 RID: 13508
	public float Timer;

	// Token: 0x040034C5 RID: 13509
	public bool RecordEvent;

	// Token: 0x040034C6 RID: 13510
	public bool CanRecord;

	// Token: 0x040034C7 RID: 13511
	public bool Recording;

	// Token: 0x040034C8 RID: 13512
	public int Phase;
}
