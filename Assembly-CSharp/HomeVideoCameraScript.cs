using System;
using UnityEngine;

// Token: 0x02000327 RID: 807
public class HomeVideoCameraScript : MonoBehaviour
{
	// Token: 0x060018A7 RID: 6311 RVA: 0x000F2070 File Offset: 0x000F0270
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

	// Token: 0x04002571 RID: 9585
	public HomePrisonerChanScript HomePrisonerChan;

	// Token: 0x04002572 RID: 9586
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002573 RID: 9587
	public HomePrisonerScript HomePrisoner;

	// Token: 0x04002574 RID: 9588
	public HomeYandereScript HomeYandere;

	// Token: 0x04002575 RID: 9589
	public HomeCameraScript HomeCamera;

	// Token: 0x04002576 RID: 9590
	public PromptScript Prompt;

	// Token: 0x04002577 RID: 9591
	public UILabel Subtitle;

	// Token: 0x04002578 RID: 9592
	public bool AudioPlayed;

	// Token: 0x04002579 RID: 9593
	public bool TextSet;

	// Token: 0x0400257A RID: 9594
	public float Timer;
}
