using System;
using UnityEngine;

// Token: 0x02000328 RID: 808
public class HomeVideoCameraScript : MonoBehaviour
{
	// Token: 0x060018B5 RID: 6325 RVA: 0x000F314C File Offset: 0x000F134C
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

	// Token: 0x040025A5 RID: 9637
	public HomePrisonerChanScript HomePrisonerChan;

	// Token: 0x040025A6 RID: 9638
	public HomeDarknessScript HomeDarkness;

	// Token: 0x040025A7 RID: 9639
	public HomePrisonerScript HomePrisoner;

	// Token: 0x040025A8 RID: 9640
	public HomeYandereScript HomeYandere;

	// Token: 0x040025A9 RID: 9641
	public HomeCameraScript HomeCamera;

	// Token: 0x040025AA RID: 9642
	public PromptScript Prompt;

	// Token: 0x040025AB RID: 9643
	public UILabel Subtitle;

	// Token: 0x040025AC RID: 9644
	public bool AudioPlayed;

	// Token: 0x040025AD RID: 9645
	public bool TextSet;

	// Token: 0x040025AE RID: 9646
	public float Timer;
}
