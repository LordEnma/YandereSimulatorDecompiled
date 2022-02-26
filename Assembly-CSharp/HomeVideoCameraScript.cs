using System;
using UnityEngine;

// Token: 0x02000328 RID: 808
public class HomeVideoCameraScript : MonoBehaviour
{
	// Token: 0x060018B0 RID: 6320 RVA: 0x000F2954 File Offset: 0x000F0B54
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

	// Token: 0x04002580 RID: 9600
	public HomePrisonerChanScript HomePrisonerChan;

	// Token: 0x04002581 RID: 9601
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002582 RID: 9602
	public HomePrisonerScript HomePrisoner;

	// Token: 0x04002583 RID: 9603
	public HomeYandereScript HomeYandere;

	// Token: 0x04002584 RID: 9604
	public HomeCameraScript HomeCamera;

	// Token: 0x04002585 RID: 9605
	public PromptScript Prompt;

	// Token: 0x04002586 RID: 9606
	public UILabel Subtitle;

	// Token: 0x04002587 RID: 9607
	public bool AudioPlayed;

	// Token: 0x04002588 RID: 9608
	public bool TextSet;

	// Token: 0x04002589 RID: 9609
	public float Timer;
}
