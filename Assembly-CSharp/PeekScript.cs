using System;
using UnityEngine;

// Token: 0x02000394 RID: 916
public class PeekScript : MonoBehaviour
{
	// Token: 0x06001A50 RID: 6736 RVA: 0x0011920B File Offset: 0x0011740B
	private void Start()
	{
		this.Prompt.Door = true;
	}

	// Token: 0x06001A51 RID: 6737 RVA: 0x0011921C File Offset: 0x0011741C
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

	// Token: 0x04002B3E RID: 11070
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04002B3F RID: 11071
	public PromptBarScript PromptBar;

	// Token: 0x04002B40 RID: 11072
	public SubtitleScript Subtitle;

	// Token: 0x04002B41 RID: 11073
	public JukeboxScript Jukebox;

	// Token: 0x04002B42 RID: 11074
	public PromptScript Prompt;

	// Token: 0x04002B43 RID: 11075
	public GameObject BlueLight;

	// Token: 0x04002B44 RID: 11076
	public GameObject PeekCamera;

	// Token: 0x04002B45 RID: 11077
	public bool Spoke;

	// Token: 0x04002B46 RID: 11078
	public float Timer;
}
