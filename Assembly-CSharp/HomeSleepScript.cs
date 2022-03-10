using System;
using UnityEngine;

// Token: 0x02000326 RID: 806
public class HomeSleepScript : MonoBehaviour
{
	// Token: 0x060018A7 RID: 6311 RVA: 0x000F2978 File Offset: 0x000F0B78
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

	// Token: 0x060018A8 RID: 6312 RVA: 0x000F2A08 File Offset: 0x000F0C08
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

	// Token: 0x04002587 RID: 9607
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002588 RID: 9608
	public HomeYandereScript HomeYandere;

	// Token: 0x04002589 RID: 9609
	public HomeCameraScript HomeCamera;

	// Token: 0x0400258A RID: 9610
	public HomeWindowScript HomeWindow;

	// Token: 0x0400258B RID: 9611
	public GameObject SkipSchoolWindow;

	// Token: 0x0400258C RID: 9612
	public UILabel EightiesLabel;

	// Token: 0x0400258D RID: 9613
	public UILabel DescLabel;

	// Token: 0x0400258E RID: 9614
	public UILabel Label;

	// Token: 0x0400258F RID: 9615
	public bool Anime;
}
