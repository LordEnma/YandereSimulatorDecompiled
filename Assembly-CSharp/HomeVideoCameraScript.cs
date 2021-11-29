using System;
using UnityEngine;

// Token: 0x02000324 RID: 804
public class HomeVideoCameraScript : MonoBehaviour
{
	// Token: 0x06001890 RID: 6288 RVA: 0x000F0A78 File Offset: 0x000EEC78
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

	// Token: 0x04002537 RID: 9527
	public HomePrisonerChanScript HomePrisonerChan;

	// Token: 0x04002538 RID: 9528
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002539 RID: 9529
	public HomePrisonerScript HomePrisoner;

	// Token: 0x0400253A RID: 9530
	public HomeYandereScript HomeYandere;

	// Token: 0x0400253B RID: 9531
	public HomeCameraScript HomeCamera;

	// Token: 0x0400253C RID: 9532
	public PromptScript Prompt;

	// Token: 0x0400253D RID: 9533
	public UILabel Subtitle;

	// Token: 0x0400253E RID: 9534
	public bool AudioPlayed;

	// Token: 0x0400253F RID: 9535
	public bool TextSet;

	// Token: 0x04002540 RID: 9536
	public float Timer;
}
