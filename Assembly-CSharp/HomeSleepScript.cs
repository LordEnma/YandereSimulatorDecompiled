using System;
using UnityEngine;

// Token: 0x02000326 RID: 806
public class HomeSleepScript : MonoBehaviour
{
	// Token: 0x060018AC RID: 6316 RVA: 0x000F2E38 File Offset: 0x000F1038
	public void Start()
	{
		if (!this.Anime)
		{
			this.SkipSchoolWindow.SetActive(false);
			if (GameGlobals.Eighties)
			{
				this.Label = this.EightiesLabel;
			}
			if (!HomeGlobals.Night)
			{
				if (DateGlobals.Weekday == DayOfWeek.Sunday)
				{
					this.DescLabel.text = "Advance to nighttime?";
					this.Label.text = "Nap";
					return;
				}
				this.DescLabel.text = "Advance to nighttime?";
				this.Label.text = "Skip School";
				this.SkipSchoolWindow.SetActive(true);
			}
		}
	}

	// Token: 0x060018AD RID: 6317 RVA: 0x000F2EC8 File Offset: 0x000F10C8
	private void Update()
	{
		if (!this.HomeYandere.CanMove && !this.HomeDarkness.FadeOut)
		{
			if (Input.GetButtonDown("A"))
			{
				this.HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
				this.HomeDarkness.Cyberstalking = true;
				this.HomeDarkness.FadeOut = true;
				this.HomeWindow.Show = false;
				base.enabled = false;
			}
			if (Input.GetButtonDown("B"))
			{
				this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
				this.HomeCamera.Target = this.HomeCamera.Targets[0];
				this.HomeYandere.CanMove = true;
				this.HomeWindow.Show = false;
				base.enabled = false;
			}
		}
	}

	// Token: 0x04002598 RID: 9624
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002599 RID: 9625
	public HomeYandereScript HomeYandere;

	// Token: 0x0400259A RID: 9626
	public HomeCameraScript HomeCamera;

	// Token: 0x0400259B RID: 9627
	public HomeWindowScript HomeWindow;

	// Token: 0x0400259C RID: 9628
	public GameObject SkipSchoolWindow;

	// Token: 0x0400259D RID: 9629
	public UILabel EightiesLabel;

	// Token: 0x0400259E RID: 9630
	public UILabel DescLabel;

	// Token: 0x0400259F RID: 9631
	public UILabel Label;

	// Token: 0x040025A0 RID: 9632
	public bool Anime;
}
