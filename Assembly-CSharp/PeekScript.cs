using System;
using UnityEngine;

// Token: 0x02000398 RID: 920
public class PeekScript : MonoBehaviour
{
	// Token: 0x06001A6B RID: 6763 RVA: 0x0011AE23 File Offset: 0x00119023
	private void Start()
	{
		this.Prompt.Door = true;
	}

	// Token: 0x06001A6C RID: 6764 RVA: 0x0011AE34 File Offset: 0x00119034
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

	// Token: 0x04002B7D RID: 11133
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04002B7E RID: 11134
	public PromptBarScript PromptBar;

	// Token: 0x04002B7F RID: 11135
	public SubtitleScript Subtitle;

	// Token: 0x04002B80 RID: 11136
	public JukeboxScript Jukebox;

	// Token: 0x04002B81 RID: 11137
	public PromptScript Prompt;

	// Token: 0x04002B82 RID: 11138
	public GameObject BlueLight;

	// Token: 0x04002B83 RID: 11139
	public GameObject PeekCamera;

	// Token: 0x04002B84 RID: 11140
	public bool Spoke;

	// Token: 0x04002B85 RID: 11141
	public float Timer;
}
