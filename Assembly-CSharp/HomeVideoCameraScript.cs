using System;
using UnityEngine;

// Token: 0x02000326 RID: 806
public class HomeVideoCameraScript : MonoBehaviour
{
	// Token: 0x060018A0 RID: 6304 RVA: 0x000F1F04 File Offset: 0x000F0104
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

	// Token: 0x0400256B RID: 9579
	public HomePrisonerChanScript HomePrisonerChan;

	// Token: 0x0400256C RID: 9580
	public HomeDarknessScript HomeDarkness;

	// Token: 0x0400256D RID: 9581
	public HomePrisonerScript HomePrisoner;

	// Token: 0x0400256E RID: 9582
	public HomeYandereScript HomeYandere;

	// Token: 0x0400256F RID: 9583
	public HomeCameraScript HomeCamera;

	// Token: 0x04002570 RID: 9584
	public PromptScript Prompt;

	// Token: 0x04002571 RID: 9585
	public UILabel Subtitle;

	// Token: 0x04002572 RID: 9586
	public bool AudioPlayed;

	// Token: 0x04002573 RID: 9587
	public bool TextSet;

	// Token: 0x04002574 RID: 9588
	public float Timer;
}
