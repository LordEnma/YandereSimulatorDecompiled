using System;
using UnityEngine;

// Token: 0x02000326 RID: 806
public class HomeSleepScript : MonoBehaviour
{
	// Token: 0x060018A7 RID: 6311 RVA: 0x000F2640 File Offset: 0x000F0840
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

	// Token: 0x060018A8 RID: 6312 RVA: 0x000F26D0 File Offset: 0x000F08D0
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

	// Token: 0x04002573 RID: 9587
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002574 RID: 9588
	public HomeYandereScript HomeYandere;

	// Token: 0x04002575 RID: 9589
	public HomeCameraScript HomeCamera;

	// Token: 0x04002576 RID: 9590
	public HomeWindowScript HomeWindow;

	// Token: 0x04002577 RID: 9591
	public GameObject SkipSchoolWindow;

	// Token: 0x04002578 RID: 9592
	public UILabel EightiesLabel;

	// Token: 0x04002579 RID: 9593
	public UILabel DescLabel;

	// Token: 0x0400257A RID: 9594
	public UILabel Label;

	// Token: 0x0400257B RID: 9595
	public bool Anime;
}
