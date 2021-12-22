using System;
using UnityEngine;

// Token: 0x02000325 RID: 805
public class HomeVideoCameraScript : MonoBehaviour
{
	// Token: 0x06001897 RID: 6295 RVA: 0x000F1268 File Offset: 0x000EF468
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

	// Token: 0x04002557 RID: 9559
	public HomePrisonerChanScript HomePrisonerChan;

	// Token: 0x04002558 RID: 9560
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002559 RID: 9561
	public HomePrisonerScript HomePrisoner;

	// Token: 0x0400255A RID: 9562
	public HomeYandereScript HomeYandere;

	// Token: 0x0400255B RID: 9563
	public HomeCameraScript HomeCamera;

	// Token: 0x0400255C RID: 9564
	public PromptScript Prompt;

	// Token: 0x0400255D RID: 9565
	public UILabel Subtitle;

	// Token: 0x0400255E RID: 9566
	public bool AudioPlayed;

	// Token: 0x0400255F RID: 9567
	public bool TextSet;

	// Token: 0x04002560 RID: 9568
	public float Timer;
}
