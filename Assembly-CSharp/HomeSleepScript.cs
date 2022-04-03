using System;
using UnityEngine;

// Token: 0x02000327 RID: 807
public class HomeSleepScript : MonoBehaviour
{
	// Token: 0x060018B2 RID: 6322 RVA: 0x000F3494 File Offset: 0x000F1694
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

	// Token: 0x060018B3 RID: 6323 RVA: 0x000F3524 File Offset: 0x000F1724
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

	// Token: 0x040025AB RID: 9643
	public HomeDarknessScript HomeDarkness;

	// Token: 0x040025AC RID: 9644
	public HomeYandereScript HomeYandere;

	// Token: 0x040025AD RID: 9645
	public HomeCameraScript HomeCamera;

	// Token: 0x040025AE RID: 9646
	public HomeWindowScript HomeWindow;

	// Token: 0x040025AF RID: 9647
	public GameObject SkipSchoolWindow;

	// Token: 0x040025B0 RID: 9648
	public UILabel EightiesLabel;

	// Token: 0x040025B1 RID: 9649
	public UILabel DescLabel;

	// Token: 0x040025B2 RID: 9650
	public UILabel Label;

	// Token: 0x040025B3 RID: 9651
	public bool Anime;
}
