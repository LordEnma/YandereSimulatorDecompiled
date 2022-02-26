using System;
using UnityEngine;

// Token: 0x02000398 RID: 920
public class PeekScript : MonoBehaviour
{
	// Token: 0x06001A6A RID: 6762 RVA: 0x0011AA4B File Offset: 0x00118C4B
	private void Start()
	{
		this.Prompt.Door = true;
	}

	// Token: 0x06001A6B RID: 6763 RVA: 0x0011AA5C File Offset: 0x00118C5C
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

	// Token: 0x04002B67 RID: 11111
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04002B68 RID: 11112
	public PromptBarScript PromptBar;

	// Token: 0x04002B69 RID: 11113
	public SubtitleScript Subtitle;

	// Token: 0x04002B6A RID: 11114
	public JukeboxScript Jukebox;

	// Token: 0x04002B6B RID: 11115
	public PromptScript Prompt;

	// Token: 0x04002B6C RID: 11116
	public GameObject BlueLight;

	// Token: 0x04002B6D RID: 11117
	public GameObject PeekCamera;

	// Token: 0x04002B6E RID: 11118
	public bool Spoke;

	// Token: 0x04002B6F RID: 11119
	public float Timer;
}
