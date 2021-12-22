using System;
using UnityEngine;

// Token: 0x02000394 RID: 916
public class PeekScript : MonoBehaviour
{
	// Token: 0x06001A4E RID: 6734 RVA: 0x00118F2F File Offset: 0x0011712F
	private void Start()
	{
		this.Prompt.Door = true;
	}

	// Token: 0x06001A4F RID: 6735 RVA: 0x00118F40 File Offset: 0x00117140
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

	// Token: 0x04002B3A RID: 11066
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04002B3B RID: 11067
	public PromptBarScript PromptBar;

	// Token: 0x04002B3C RID: 11068
	public SubtitleScript Subtitle;

	// Token: 0x04002B3D RID: 11069
	public JukeboxScript Jukebox;

	// Token: 0x04002B3E RID: 11070
	public PromptScript Prompt;

	// Token: 0x04002B3F RID: 11071
	public GameObject BlueLight;

	// Token: 0x04002B40 RID: 11072
	public GameObject PeekCamera;

	// Token: 0x04002B41 RID: 11073
	public bool Spoke;

	// Token: 0x04002B42 RID: 11074
	public float Timer;
}
