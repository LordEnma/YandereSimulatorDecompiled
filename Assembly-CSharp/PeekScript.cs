using System;
using UnityEngine;

// Token: 0x02000398 RID: 920
public class PeekScript : MonoBehaviour
{
	// Token: 0x06001A75 RID: 6773 RVA: 0x0011B933 File Offset: 0x00119B33
	private void Start()
	{
		this.Prompt.Door = true;
	}

	// Token: 0x06001A76 RID: 6774 RVA: 0x0011B944 File Offset: 0x00119B44
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

	// Token: 0x04002BA6 RID: 11174
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04002BA7 RID: 11175
	public PromptBarScript PromptBar;

	// Token: 0x04002BA8 RID: 11176
	public SubtitleScript Subtitle;

	// Token: 0x04002BA9 RID: 11177
	public JukeboxScript Jukebox;

	// Token: 0x04002BAA RID: 11178
	public PromptScript Prompt;

	// Token: 0x04002BAB RID: 11179
	public GameObject BlueLight;

	// Token: 0x04002BAC RID: 11180
	public GameObject PeekCamera;

	// Token: 0x04002BAD RID: 11181
	public bool Spoke;

	// Token: 0x04002BAE RID: 11182
	public float Timer;
}
