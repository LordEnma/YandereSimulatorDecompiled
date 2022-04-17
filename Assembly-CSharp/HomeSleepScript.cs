using System;
using UnityEngine;

// Token: 0x02000328 RID: 808
public class HomeSleepScript : MonoBehaviour
{
	// Token: 0x060018BC RID: 6332 RVA: 0x000F3828 File Offset: 0x000F1A28
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

	// Token: 0x060018BD RID: 6333 RVA: 0x000F38B8 File Offset: 0x000F1AB8
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

	// Token: 0x040025B6 RID: 9654
	public HomeDarknessScript HomeDarkness;

	// Token: 0x040025B7 RID: 9655
	public HomeYandereScript HomeYandere;

	// Token: 0x040025B8 RID: 9656
	public HomeCameraScript HomeCamera;

	// Token: 0x040025B9 RID: 9657
	public HomeWindowScript HomeWindow;

	// Token: 0x040025BA RID: 9658
	public GameObject SkipSchoolWindow;

	// Token: 0x040025BB RID: 9659
	public UILabel EightiesLabel;

	// Token: 0x040025BC RID: 9660
	public UILabel DescLabel;

	// Token: 0x040025BD RID: 9661
	public UILabel Label;

	// Token: 0x040025BE RID: 9662
	public bool Anime;
}
