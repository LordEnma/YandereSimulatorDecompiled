using System;
using UnityEngine;

// Token: 0x0200032A RID: 810
public class HomeVideoCameraScript : MonoBehaviour
{
	// Token: 0x060018C9 RID: 6345 RVA: 0x000F400C File Offset: 0x000F220C
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

	// Token: 0x040025CC RID: 9676
	public HomePrisonerChanScript HomePrisonerChan;

	// Token: 0x040025CD RID: 9677
	public HomeDarknessScript HomeDarkness;

	// Token: 0x040025CE RID: 9678
	public HomePrisonerScript HomePrisoner;

	// Token: 0x040025CF RID: 9679
	public HomeYandereScript HomeYandere;

	// Token: 0x040025D0 RID: 9680
	public HomeCameraScript HomeCamera;

	// Token: 0x040025D1 RID: 9681
	public PromptScript Prompt;

	// Token: 0x040025D2 RID: 9682
	public UILabel Subtitle;

	// Token: 0x040025D3 RID: 9683
	public bool AudioPlayed;

	// Token: 0x040025D4 RID: 9684
	public bool TextSet;

	// Token: 0x040025D5 RID: 9685
	public float Timer;
}
