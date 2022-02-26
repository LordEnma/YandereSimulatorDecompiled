using System;
using UnityEngine;

// Token: 0x0200043D RID: 1085
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001CED RID: 7405 RVA: 0x00158160 File Offset: 0x00156360
	private void Start()
	{
	}

	// Token: 0x06001CEE RID: 7406 RVA: 0x00158164 File Offset: 0x00156364
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

	// Token: 0x06001CEF RID: 7407 RVA: 0x0015831C File Offset: 0x0015651C
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

	// Token: 0x04003425 RID: 13349
	public PromptBarScript PromptBar;

	// Token: 0x04003426 RID: 13350
	public YandereScript Yandere;

	// Token: 0x04003427 RID: 13351
	public PromptScript Prompt;

	// Token: 0x04003428 RID: 13352
	public GameObject SpyCamera;

	// Token: 0x04003429 RID: 13353
	public Transform SpyTarget;

	// Token: 0x0400342A RID: 13354
	public Transform SpySpot;

	// Token: 0x0400342B RID: 13355
	public float Timer;

	// Token: 0x0400342C RID: 13356
	public bool RecordEvent;

	// Token: 0x0400342D RID: 13357
	public bool CanRecord;

	// Token: 0x0400342E RID: 13358
	public bool Recording;

	// Token: 0x0400342F RID: 13359
	public int Phase;
}
