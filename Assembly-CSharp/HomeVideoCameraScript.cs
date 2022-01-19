using System;
using UnityEngine;

// Token: 0x02000326 RID: 806
public class HomeVideoCameraScript : MonoBehaviour
{
	// Token: 0x0600189D RID: 6301 RVA: 0x000F194C File Offset: 0x000EFB4C
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

	// Token: 0x04002562 RID: 9570
	public HomePrisonerChanScript HomePrisonerChan;

	// Token: 0x04002563 RID: 9571
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002564 RID: 9572
	public HomePrisonerScript HomePrisoner;

	// Token: 0x04002565 RID: 9573
	public HomeYandereScript HomeYandere;

	// Token: 0x04002566 RID: 9574
	public HomeCameraScript HomeCamera;

	// Token: 0x04002567 RID: 9575
	public PromptScript Prompt;

	// Token: 0x04002568 RID: 9576
	public UILabel Subtitle;

	// Token: 0x04002569 RID: 9577
	public bool AudioPlayed;

	// Token: 0x0400256A RID: 9578
	public bool TextSet;

	// Token: 0x0400256B RID: 9579
	public float Timer;
}
