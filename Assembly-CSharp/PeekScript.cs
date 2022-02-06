﻿using System;
using UnityEngine;

// Token: 0x02000396 RID: 918
public class PeekScript : MonoBehaviour
{
	// Token: 0x06001A5A RID: 6746 RVA: 0x00119D1B File Offset: 0x00117F1B
	private void Start()
	{
		this.Prompt.Door = true;
	}

	// Token: 0x06001A5B RID: 6747 RVA: 0x00119D2C File Offset: 0x00117F2C
	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.Prompt.Yandere.transform.position) < 2f)
		{
			this.Prompt.Yandere.StudentManager.TutorialWindow.ShowInfoMessage = true;
		}
		if (this.InfoChanWindow.Drop)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Prompt.Yandere.Chased && this.Prompt.Yandere.Chasers == 0)
			{
				this.Prompt.Yandere.CanMove = false;
				this.PeekCamera.SetActive(true);
				this.BlueLight.SetActive(true);
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[1].text = "Stop";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
			}
		}
		if (this.PeekCamera.activeInHierarchy)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f && !this.Spoke)
			{
				this.Subtitle.UpdateLabel(SubtitleType.InfoNotice, 0, 6.5f);
				this.Spoke = true;
				base.GetComponent<AudioSource>().Play();
			}
			if (Input.GetButtonDown("B") || this.Prompt.Yandere.Noticed || this.Prompt.Yandere.Sprayed)
			{
				if (!this.Prompt.Yandere.Noticed && !this.Prompt.Yandere.Sprayed)
				{
					this.Prompt.Yandere.CanMove = true;
				}
				this.PeekCamera.SetActive(false);
				this.BlueLight.SetActive(false);
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x04002B51 RID: 11089
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04002B52 RID: 11090
	public PromptBarScript PromptBar;

	// Token: 0x04002B53 RID: 11091
	public SubtitleScript Subtitle;

	// Token: 0x04002B54 RID: 11092
	public JukeboxScript Jukebox;

	// Token: 0x04002B55 RID: 11093
	public PromptScript Prompt;

	// Token: 0x04002B56 RID: 11094
	public GameObject BlueLight;

	// Token: 0x04002B57 RID: 11095
	public GameObject PeekCamera;

	// Token: 0x04002B58 RID: 11096
	public bool Spoke;

	// Token: 0x04002B59 RID: 11097
	public float Timer;
}
