using System;
using UnityEngine;

// Token: 0x0200039B RID: 923
public class PeekScript : MonoBehaviour
{
	// Token: 0x06001A82 RID: 6786 RVA: 0x0011C13F File Offset: 0x0011A33F
	private void Start()
	{
		this.Prompt.Door = true;
	}

	// Token: 0x06001A83 RID: 6787 RVA: 0x0011C150 File Offset: 0x0011A350
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

	// Token: 0x04002BBE RID: 11198
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04002BBF RID: 11199
	public PromptBarScript PromptBar;

	// Token: 0x04002BC0 RID: 11200
	public SubtitleScript Subtitle;

	// Token: 0x04002BC1 RID: 11201
	public JukeboxScript Jukebox;

	// Token: 0x04002BC2 RID: 11202
	public PromptScript Prompt;

	// Token: 0x04002BC3 RID: 11203
	public GameObject BlueLight;

	// Token: 0x04002BC4 RID: 11204
	public GameObject PeekCamera;

	// Token: 0x04002BC5 RID: 11205
	public bool Spoke;

	// Token: 0x04002BC6 RID: 11206
	public float Timer;
}
