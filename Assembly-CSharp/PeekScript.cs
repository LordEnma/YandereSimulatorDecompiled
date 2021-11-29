using System;
using UnityEngine;

// Token: 0x02000393 RID: 915
public class PeekScript : MonoBehaviour
{
	// Token: 0x06001A46 RID: 6726 RVA: 0x001186EF File Offset: 0x001168EF
	private void Start()
	{
		this.Prompt.Door = true;
	}

	// Token: 0x06001A47 RID: 6727 RVA: 0x00118700 File Offset: 0x00116900
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

	// Token: 0x04002B10 RID: 11024
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04002B11 RID: 11025
	public PromptBarScript PromptBar;

	// Token: 0x04002B12 RID: 11026
	public SubtitleScript Subtitle;

	// Token: 0x04002B13 RID: 11027
	public JukeboxScript Jukebox;

	// Token: 0x04002B14 RID: 11028
	public PromptScript Prompt;

	// Token: 0x04002B15 RID: 11029
	public GameObject BlueLight;

	// Token: 0x04002B16 RID: 11030
	public GameObject PeekCamera;

	// Token: 0x04002B17 RID: 11031
	public bool Spoke;

	// Token: 0x04002B18 RID: 11032
	public float Timer;
}
