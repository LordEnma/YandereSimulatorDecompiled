using System;
using UnityEngine;

// Token: 0x02000324 RID: 804
public class HomeSleepScript : MonoBehaviour
{
	// Token: 0x06001894 RID: 6292 RVA: 0x000F1540 File Offset: 0x000EF740
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

	// Token: 0x06001895 RID: 6293 RVA: 0x000F15D0 File Offset: 0x000EF7D0
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

	// Token: 0x04002552 RID: 9554
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002553 RID: 9555
	public HomeYandereScript HomeYandere;

	// Token: 0x04002554 RID: 9556
	public HomeCameraScript HomeCamera;

	// Token: 0x04002555 RID: 9557
	public HomeWindowScript HomeWindow;

	// Token: 0x04002556 RID: 9558
	public GameObject SkipSchoolWindow;

	// Token: 0x04002557 RID: 9559
	public UILabel EightiesLabel;

	// Token: 0x04002558 RID: 9560
	public UILabel DescLabel;

	// Token: 0x04002559 RID: 9561
	public UILabel Label;

	// Token: 0x0400255A RID: 9562
	public bool Anime;
}
