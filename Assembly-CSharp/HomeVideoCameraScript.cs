using System;
using UnityEngine;

// Token: 0x0200032A RID: 810
public class HomeVideoCameraScript : MonoBehaviour
{
	// Token: 0x060018C1 RID: 6337 RVA: 0x000F38A8 File Offset: 0x000F1AA8
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

	// Token: 0x040025BB RID: 9659
	public HomePrisonerChanScript HomePrisonerChan;

	// Token: 0x040025BC RID: 9660
	public HomeDarknessScript HomeDarkness;

	// Token: 0x040025BD RID: 9661
	public HomePrisonerScript HomePrisoner;

	// Token: 0x040025BE RID: 9662
	public HomeYandereScript HomeYandere;

	// Token: 0x040025BF RID: 9663
	public HomeCameraScript HomeCamera;

	// Token: 0x040025C0 RID: 9664
	public PromptScript Prompt;

	// Token: 0x040025C1 RID: 9665
	public UILabel Subtitle;

	// Token: 0x040025C2 RID: 9666
	public bool AudioPlayed;

	// Token: 0x040025C3 RID: 9667
	public bool TextSet;

	// Token: 0x040025C4 RID: 9668
	public float Timer;
}
