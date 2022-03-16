using System;
using UnityEngine;

// Token: 0x0200043E RID: 1086
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001CFC RID: 7420 RVA: 0x001595F0 File Offset: 0x001577F0
	private void Start()
	{
	}

	// Token: 0x06001CFD RID: 7421 RVA: 0x001595F4 File Offset: 0x001577F4
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

	// Token: 0x06001CFE RID: 7422 RVA: 0x001597AC File Offset: 0x001579AC
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

	// Token: 0x04003470 RID: 13424
	public PromptBarScript PromptBar;

	// Token: 0x04003471 RID: 13425
	public YandereScript Yandere;

	// Token: 0x04003472 RID: 13426
	public PromptScript Prompt;

	// Token: 0x04003473 RID: 13427
	public GameObject SpyCamera;

	// Token: 0x04003474 RID: 13428
	public Transform SpyTarget;

	// Token: 0x04003475 RID: 13429
	public Transform SpySpot;

	// Token: 0x04003476 RID: 13430
	public float Timer;

	// Token: 0x04003477 RID: 13431
	public bool RecordEvent;

	// Token: 0x04003478 RID: 13432
	public bool CanRecord;

	// Token: 0x04003479 RID: 13433
	public bool Recording;

	// Token: 0x0400347A RID: 13434
	public int Phase;
}
