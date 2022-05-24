using System;
using UnityEngine;

// Token: 0x02000329 RID: 809
public class HomeSleepScript : MonoBehaviour
{
	// Token: 0x060018C5 RID: 6341 RVA: 0x000F4174 File Offset: 0x000F2374
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

	// Token: 0x060018C6 RID: 6342 RVA: 0x000F4204 File Offset: 0x000F2404
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

	// Token: 0x040025CD RID: 9677
	public HomeDarknessScript HomeDarkness;

	// Token: 0x040025CE RID: 9678
	public HomeYandereScript HomeYandere;

	// Token: 0x040025CF RID: 9679
	public HomeCameraScript HomeCamera;

	// Token: 0x040025D0 RID: 9680
	public HomeWindowScript HomeWindow;

	// Token: 0x040025D1 RID: 9681
	public GameObject SkipSchoolWindow;

	// Token: 0x040025D2 RID: 9682
	public UILabel EightiesLabel;

	// Token: 0x040025D3 RID: 9683
	public UILabel DescLabel;

	// Token: 0x040025D4 RID: 9684
	public UILabel Label;

	// Token: 0x040025D5 RID: 9685
	public bool Anime;
}
