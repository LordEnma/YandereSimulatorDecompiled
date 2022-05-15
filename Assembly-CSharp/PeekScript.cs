using System;
using UnityEngine;

// Token: 0x0200039C RID: 924
public class PeekScript : MonoBehaviour
{
	// Token: 0x06001A90 RID: 6800 RVA: 0x0011D313 File Offset: 0x0011B513
	private void Start()
	{
		this.Prompt.Door = true;
	}

	// Token: 0x06001A91 RID: 6801 RVA: 0x0011D324 File Offset: 0x0011B524
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

	// Token: 0x04002BE1 RID: 11233
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04002BE2 RID: 11234
	public PromptBarScript PromptBar;

	// Token: 0x04002BE3 RID: 11235
	public SubtitleScript Subtitle;

	// Token: 0x04002BE4 RID: 11236
	public JukeboxScript Jukebox;

	// Token: 0x04002BE5 RID: 11237
	public PromptScript Prompt;

	// Token: 0x04002BE6 RID: 11238
	public GameObject BlueLight;

	// Token: 0x04002BE7 RID: 11239
	public GameObject PeekCamera;

	// Token: 0x04002BE8 RID: 11240
	public bool Spoke;

	// Token: 0x04002BE9 RID: 11241
	public float Timer;
}
