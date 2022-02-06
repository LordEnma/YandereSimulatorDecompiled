using System;
using UnityEngine;

// Token: 0x02000324 RID: 804
public class HomeSleepScript : MonoBehaviour
{
	// Token: 0x06001897 RID: 6295 RVA: 0x000F1BF0 File Offset: 0x000EFDF0
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

	// Token: 0x06001898 RID: 6296 RVA: 0x000F1C80 File Offset: 0x000EFE80
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

	// Token: 0x0400255E RID: 9566
	public HomeDarknessScript HomeDarkness;

	// Token: 0x0400255F RID: 9567
	public HomeYandereScript HomeYandere;

	// Token: 0x04002560 RID: 9568
	public HomeCameraScript HomeCamera;

	// Token: 0x04002561 RID: 9569
	public HomeWindowScript HomeWindow;

	// Token: 0x04002562 RID: 9570
	public GameObject SkipSchoolWindow;

	// Token: 0x04002563 RID: 9571
	public UILabel EightiesLabel;

	// Token: 0x04002564 RID: 9572
	public UILabel DescLabel;

	// Token: 0x04002565 RID: 9573
	public UILabel Label;

	// Token: 0x04002566 RID: 9574
	public bool Anime;
}
