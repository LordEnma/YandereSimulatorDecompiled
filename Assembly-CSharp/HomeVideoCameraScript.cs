using System;
using UnityEngine;

// Token: 0x02000328 RID: 808
public class HomeVideoCameraScript : MonoBehaviour
{
	// Token: 0x060018B0 RID: 6320 RVA: 0x000F2C8C File Offset: 0x000F0E8C
	private void Update()
	{
		if (!this.TextSet && !HomeGlobals.Night)
		{
			this.Prompt.Label[0].text = "     Only Available At Night";
		}
		if (!HomeGlobals.Night)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.HomeCamera.Destination = this.HomeCamera.Destinations[11];
			this.HomeCamera.Target = this.HomeCamera.Targets[11];
			this.HomeCamera.ID = 11;
			this.HomePrisonerChan.LookAhead = true;
			this.HomeYandere.CanMove = false;
			this.HomeYandere.gameObject.SetActive(false);
		}
		if (this.HomeCamera.ID == 11 && !this.HomePrisoner.Bantering)
		{
			this.Timer += Time.deltaTime;
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.Timer > 2f && !this.AudioPlayed)
			{
				this.Subtitle.text = "...daddy...please...help...I'm scared...I don't wanna die...";
				this.AudioPlayed = true;
				component.Play();
			}
			if (this.Timer > 2f + component.clip.length)
			{
				this.Subtitle.text = string.Empty;
			}
			if (this.Timer > 3f + component.clip.length)
			{
				this.HomeDarkness.FadeSlow = true;
				this.HomeDarkness.FadeOut = true;
			}
		}
	}

	// Token: 0x04002594 RID: 9620
	public HomePrisonerChanScript HomePrisonerChan;

	// Token: 0x04002595 RID: 9621
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002596 RID: 9622
	public HomePrisonerScript HomePrisoner;

	// Token: 0x04002597 RID: 9623
	public HomeYandereScript HomeYandere;

	// Token: 0x04002598 RID: 9624
	public HomeCameraScript HomeCamera;

	// Token: 0x04002599 RID: 9625
	public PromptScript Prompt;

	// Token: 0x0400259A RID: 9626
	public UILabel Subtitle;

	// Token: 0x0400259B RID: 9627
	public bool AudioPlayed;

	// Token: 0x0400259C RID: 9628
	public bool TextSet;

	// Token: 0x0400259D RID: 9629
	public float Timer;
}
