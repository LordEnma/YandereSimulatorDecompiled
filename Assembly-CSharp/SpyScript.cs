using System;
using UnityEngine;

// Token: 0x02000443 RID: 1091
public class SpyScript : MonoBehaviour
{
	// Token: 0x06001D18 RID: 7448 RVA: 0x0015B084 File Offset: 0x00159284
	private void Start()
	{
	}

	// Token: 0x06001D19 RID: 7449 RVA: 0x0015B088 File Offset: 0x00159288
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

	// Token: 0x06001D1A RID: 7450 RVA: 0x0015B240 File Offset: 0x00159440
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

	// Token: 0x040034A9 RID: 13481
	public PromptBarScript PromptBar;

	// Token: 0x040034AA RID: 13482
	public YandereScript Yandere;

	// Token: 0x040034AB RID: 13483
	public PromptScript Prompt;

	// Token: 0x040034AC RID: 13484
	public GameObject SpyCamera;

	// Token: 0x040034AD RID: 13485
	public Transform SpyTarget;

	// Token: 0x040034AE RID: 13486
	public Transform SpySpot;

	// Token: 0x040034AF RID: 13487
	public float Timer;

	// Token: 0x040034B0 RID: 13488
	public bool RecordEvent;

	// Token: 0x040034B1 RID: 13489
	public bool CanRecord;

	// Token: 0x040034B2 RID: 13490
	public bool Recording;

	// Token: 0x040034B3 RID: 13491
	public int Phase;
}
