using System;
using UnityEngine;

// Token: 0x0200039B RID: 923
public class PeekScript : MonoBehaviour
{
	// Token: 0x06001A8A RID: 6794 RVA: 0x0011C9E3 File Offset: 0x0011ABE3
	private void Start()
	{
		this.Prompt.Door = true;
	}

	// Token: 0x06001A8B RID: 6795 RVA: 0x0011C9F4 File Offset: 0x0011ABF4
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

	// Token: 0x04002BCF RID: 11215
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04002BD0 RID: 11216
	public PromptBarScript PromptBar;

	// Token: 0x04002BD1 RID: 11217
	public SubtitleScript Subtitle;

	// Token: 0x04002BD2 RID: 11218
	public JukeboxScript Jukebox;

	// Token: 0x04002BD3 RID: 11219
	public PromptScript Prompt;

	// Token: 0x04002BD4 RID: 11220
	public GameObject BlueLight;

	// Token: 0x04002BD5 RID: 11221
	public GameObject PeekCamera;

	// Token: 0x04002BD6 RID: 11222
	public bool Spoke;

	// Token: 0x04002BD7 RID: 11223
	public float Timer;
}
