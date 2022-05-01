using System;
using UnityEngine;

// Token: 0x02000328 RID: 808
public class HomeSleepScript : MonoBehaviour
{
	// Token: 0x060018C0 RID: 6336 RVA: 0x000F3D2C File Offset: 0x000F1F2C
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

	// Token: 0x060018C1 RID: 6337 RVA: 0x000F3DBC File Offset: 0x000F1FBC
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

	// Token: 0x040025BF RID: 9663
	public HomeDarknessScript HomeDarkness;

	// Token: 0x040025C0 RID: 9664
	public HomeYandereScript HomeYandere;

	// Token: 0x040025C1 RID: 9665
	public HomeCameraScript HomeCamera;

	// Token: 0x040025C2 RID: 9666
	public HomeWindowScript HomeWindow;

	// Token: 0x040025C3 RID: 9667
	public GameObject SkipSchoolWindow;

	// Token: 0x040025C4 RID: 9668
	public UILabel EightiesLabel;

	// Token: 0x040025C5 RID: 9669
	public UILabel DescLabel;

	// Token: 0x040025C6 RID: 9670
	public UILabel Label;

	// Token: 0x040025C7 RID: 9671
	public bool Anime;
}
