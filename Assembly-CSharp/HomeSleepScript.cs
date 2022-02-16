using System;
using UnityEngine;

// Token: 0x02000325 RID: 805
public class HomeSleepScript : MonoBehaviour
{
	// Token: 0x0600189E RID: 6302 RVA: 0x000F1D5C File Offset: 0x000EFF5C
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

	// Token: 0x0600189F RID: 6303 RVA: 0x000F1DEC File Offset: 0x000EFFEC
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

	// Token: 0x04002564 RID: 9572
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002565 RID: 9573
	public HomeYandereScript HomeYandere;

	// Token: 0x04002566 RID: 9574
	public HomeCameraScript HomeCamera;

	// Token: 0x04002567 RID: 9575
	public HomeWindowScript HomeWindow;

	// Token: 0x04002568 RID: 9576
	public GameObject SkipSchoolWindow;

	// Token: 0x04002569 RID: 9577
	public UILabel EightiesLabel;

	// Token: 0x0400256A RID: 9578
	public UILabel DescLabel;

	// Token: 0x0400256B RID: 9579
	public UILabel Label;

	// Token: 0x0400256C RID: 9580
	public bool Anime;
}
