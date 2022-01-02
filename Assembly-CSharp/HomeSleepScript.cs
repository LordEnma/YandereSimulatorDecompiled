using System;
using UnityEngine;

// Token: 0x02000323 RID: 803
public class HomeSleepScript : MonoBehaviour
{
	// Token: 0x06001890 RID: 6288 RVA: 0x000F1208 File Offset: 0x000EF408
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

	// Token: 0x06001891 RID: 6289 RVA: 0x000F1298 File Offset: 0x000EF498
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

	// Token: 0x0400254E RID: 9550
	public HomeDarknessScript HomeDarkness;

	// Token: 0x0400254F RID: 9551
	public HomeYandereScript HomeYandere;

	// Token: 0x04002550 RID: 9552
	public HomeCameraScript HomeCamera;

	// Token: 0x04002551 RID: 9553
	public HomeWindowScript HomeWindow;

	// Token: 0x04002552 RID: 9554
	public GameObject SkipSchoolWindow;

	// Token: 0x04002553 RID: 9555
	public UILabel EightiesLabel;

	// Token: 0x04002554 RID: 9556
	public UILabel DescLabel;

	// Token: 0x04002555 RID: 9557
	public UILabel Label;

	// Token: 0x04002556 RID: 9558
	public bool Anime;
}
