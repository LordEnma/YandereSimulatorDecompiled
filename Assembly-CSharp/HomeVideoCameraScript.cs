using System;
using UnityEngine;

// Token: 0x02000325 RID: 805
public class HomeVideoCameraScript : MonoBehaviour
{
	// Token: 0x06001899 RID: 6297 RVA: 0x000F151C File Offset: 0x000EF71C
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

	// Token: 0x0400255B RID: 9563
	public HomePrisonerChanScript HomePrisonerChan;

	// Token: 0x0400255C RID: 9564
	public HomeDarknessScript HomeDarkness;

	// Token: 0x0400255D RID: 9565
	public HomePrisonerScript HomePrisoner;

	// Token: 0x0400255E RID: 9566
	public HomeYandereScript HomeYandere;

	// Token: 0x0400255F RID: 9567
	public HomeCameraScript HomeCamera;

	// Token: 0x04002560 RID: 9568
	public PromptScript Prompt;

	// Token: 0x04002561 RID: 9569
	public UILabel Subtitle;

	// Token: 0x04002562 RID: 9570
	public bool AudioPlayed;

	// Token: 0x04002563 RID: 9571
	public bool TextSet;

	// Token: 0x04002564 RID: 9572
	public float Timer;
}
