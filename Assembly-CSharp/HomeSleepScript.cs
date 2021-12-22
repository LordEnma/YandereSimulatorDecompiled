using System;
using UnityEngine;

// Token: 0x02000323 RID: 803
public class HomeSleepScript : MonoBehaviour
{
	// Token: 0x0600188E RID: 6286 RVA: 0x000F0F54 File Offset: 0x000EF154
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

	// Token: 0x0600188F RID: 6287 RVA: 0x000F0FE4 File Offset: 0x000EF1E4
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

	// Token: 0x0400254A RID: 9546
	public HomeDarknessScript HomeDarkness;

	// Token: 0x0400254B RID: 9547
	public HomeYandereScript HomeYandere;

	// Token: 0x0400254C RID: 9548
	public HomeCameraScript HomeCamera;

	// Token: 0x0400254D RID: 9549
	public HomeWindowScript HomeWindow;

	// Token: 0x0400254E RID: 9550
	public GameObject SkipSchoolWindow;

	// Token: 0x0400254F RID: 9551
	public UILabel EightiesLabel;

	// Token: 0x04002550 RID: 9552
	public UILabel DescLabel;

	// Token: 0x04002551 RID: 9553
	public UILabel Label;

	// Token: 0x04002552 RID: 9554
	public bool Anime;
}
