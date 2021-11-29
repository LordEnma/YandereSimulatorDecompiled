using System;
using UnityEngine;

// Token: 0x02000322 RID: 802
public class HomeSleepScript : MonoBehaviour
{
	// Token: 0x06001887 RID: 6279 RVA: 0x000F0764 File Offset: 0x000EE964
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

	// Token: 0x06001888 RID: 6280 RVA: 0x000F07F4 File Offset: 0x000EE9F4
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

	// Token: 0x0400252A RID: 9514
	public HomeDarknessScript HomeDarkness;

	// Token: 0x0400252B RID: 9515
	public HomeYandereScript HomeYandere;

	// Token: 0x0400252C RID: 9516
	public HomeCameraScript HomeCamera;

	// Token: 0x0400252D RID: 9517
	public HomeWindowScript HomeWindow;

	// Token: 0x0400252E RID: 9518
	public GameObject SkipSchoolWindow;

	// Token: 0x0400252F RID: 9519
	public UILabel EightiesLabel;

	// Token: 0x04002530 RID: 9520
	public UILabel DescLabel;

	// Token: 0x04002531 RID: 9521
	public UILabel Label;

	// Token: 0x04002532 RID: 9522
	public bool Anime;
}
