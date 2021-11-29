using System;
using UnityEngine;

// Token: 0x02000437 RID: 1079
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001CC7 RID: 7367 RVA: 0x0015455C File Offset: 0x0015275C
	private void Start()
	{
	}

	// Token: 0x06001CC8 RID: 7368 RVA: 0x00154560 File Offset: 0x00152760
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

	// Token: 0x06001CC9 RID: 7369 RVA: 0x00154718 File Offset: 0x00152918
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

	// Token: 0x040033C8 RID: 13256
	public PromptBarScript PromptBar;

	// Token: 0x040033C9 RID: 13257
	public YandereScript Yandere;

	// Token: 0x040033CA RID: 13258
	public PromptScript Prompt;

	// Token: 0x040033CB RID: 13259
	public GameObject SpyCamera;

	// Token: 0x040033CC RID: 13260
	public Transform SpyTarget;

	// Token: 0x040033CD RID: 13261
	public Transform SpySpot;

	// Token: 0x040033CE RID: 13262
	public float Timer;

	// Token: 0x040033CF RID: 13263
	public bool RecordEvent;

	// Token: 0x040033D0 RID: 13264
	public bool CanRecord;

	// Token: 0x040033D1 RID: 13265
	public bool Recording;

	// Token: 0x040033D2 RID: 13266
	public int Phase;
}
