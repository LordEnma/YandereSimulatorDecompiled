using System;
using UnityEngine;

// Token: 0x0200039B RID: 923
public class PeekScript : MonoBehaviour
{
	// Token: 0x06001A86 RID: 6790 RVA: 0x0011C447 File Offset: 0x0011A647
	private void Start()
	{
		this.Prompt.Door = true;
	}

	// Token: 0x06001A87 RID: 6791 RVA: 0x0011C458 File Offset: 0x0011A658
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

	// Token: 0x04002BC6 RID: 11206
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04002BC7 RID: 11207
	public PromptBarScript PromptBar;

	// Token: 0x04002BC8 RID: 11208
	public SubtitleScript Subtitle;

	// Token: 0x04002BC9 RID: 11209
	public JukeboxScript Jukebox;

	// Token: 0x04002BCA RID: 11210
	public PromptScript Prompt;

	// Token: 0x04002BCB RID: 11211
	public GameObject BlueLight;

	// Token: 0x04002BCC RID: 11212
	public GameObject PeekCamera;

	// Token: 0x04002BCD RID: 11213
	public bool Spoke;

	// Token: 0x04002BCE RID: 11214
	public float Timer;
}
