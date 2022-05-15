using System;
using UnityEngine;

// Token: 0x0200032B RID: 811
public class HomeVideoCameraScript : MonoBehaviour
{
	// Token: 0x060018CE RID: 6350 RVA: 0x000F430C File Offset: 0x000F250C
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

	// Token: 0x040025D7 RID: 9687
	public HomePrisonerChanScript HomePrisonerChan;

	// Token: 0x040025D8 RID: 9688
	public HomeDarknessScript HomeDarkness;

	// Token: 0x040025D9 RID: 9689
	public HomePrisonerScript HomePrisoner;

	// Token: 0x040025DA RID: 9690
	public HomeYandereScript HomeYandere;

	// Token: 0x040025DB RID: 9691
	public HomeCameraScript HomeCamera;

	// Token: 0x040025DC RID: 9692
	public PromptScript Prompt;

	// Token: 0x040025DD RID: 9693
	public UILabel Subtitle;

	// Token: 0x040025DE RID: 9694
	public bool AudioPlayed;

	// Token: 0x040025DF RID: 9695
	public bool TextSet;

	// Token: 0x040025E0 RID: 9696
	public float Timer;
}
