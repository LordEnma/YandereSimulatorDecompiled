using System;
using UnityEngine;

// Token: 0x0200031A RID: 794
public class HomeExitScript : MonoBehaviour
{
	// Token: 0x06001864 RID: 6244 RVA: 0x000EBCB8 File Offset: 0x000E9EB8
	private void Start()
	{
		UILabel uilabel = this.Labels[1];
		if (HomeGlobals.Night)
		{
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
			Debug.Log("Scheme #6 is at stage: " + SchemeGlobals.GetSchemeStage(6).ToString());
			if (SchemeGlobals.GetSchemeStage(6) == 9 && !StudentGlobals.GetStudentDead(10 + DateGlobals.Week) && !StudentGlobals.GetStudentKidnapped(10 + DateGlobals.Week))
			{
				UILabel uilabel2 = this.Labels[4];
				uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 1f);
				uilabel2.text = "Stalker's House";
				if (GameGlobals.Eighties)
				{
					this.Labels[4].text = "Insane Asylum";
				}
			}
			this.BringItemPrompt.SetActive(false);
			return;
		}
		if (DateGlobals.Weekday == DayOfWeek.Sunday)
		{
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
		}
	}

	// Token: 0x06001865 RID: 6245 RVA: 0x000EBDF4 File Offset: 0x000E9FF4
	private void Update()
	{
		if (!this.HomeYandere.CanMove && !this.HomeDarkness.FadeOut && this.HomeWindow.Sprite.color.a > 0.9f)
		{
			if (this.InputManager.TappedDown)
			{
				this.ID++;
				if (this.ID > 4)
				{
					this.ID = 1;
				}
				this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 50f - (float)this.ID * 50f, this.Highlight.localPosition.z);
			}
			if (this.InputManager.TappedUp)
			{
				this.ID--;
				if (this.ID < 1)
				{
					this.ID = 4;
				}
				this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 50f - (float)this.ID * 50f, this.Highlight.localPosition.z);
			}
			if (Input.GetButtonDown("A") && this.Labels[this.ID].color.a == 1f)
			{
				if (this.ID == 1)
				{
					this.HomeBringItem.HomeWindow.Show = true;
					this.HomeWindow.Show = false;
				}
				else
				{
					if (this.ID == 2)
					{
						this.HomeDarkness.Sprite.color = new Color(1f, 1f, 1f, 0f);
					}
					else if (this.ID == 3)
					{
						this.HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
					}
					else if (this.ID == 4)
					{
						this.HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
					}
					this.HomeDarkness.FadeOut = true;
					this.HomeWindow.Show = false;
					base.enabled = false;
				}
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

	// Token: 0x06001866 RID: 6246 RVA: 0x000EC08C File Offset: 0x000EA28C
	public void GoToSchool()
	{
		if (SchoolGlobals.SchoolAtmosphere < 0.5f || GameGlobals.LoveSick)
		{
			this.HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
		}
		else
		{
			this.HomeDarkness.Sprite.color = new Color(1f, 1f, 1f, 0f);
		}
		this.HomeDarkness.FadeOut = true;
		this.HomeWindow.Show = false;
		base.enabled = false;
	}

	// Token: 0x04002459 RID: 9305
	public InputManagerScript InputManager;

	// Token: 0x0400245A RID: 9306
	public HomeDarknessScript HomeDarkness;

	// Token: 0x0400245B RID: 9307
	public HomeYandereScript HomeYandere;

	// Token: 0x0400245C RID: 9308
	public BringItemScript HomeBringItem;

	// Token: 0x0400245D RID: 9309
	public HomeCameraScript HomeCamera;

	// Token: 0x0400245E RID: 9310
	public HomeWindowScript HomeWindow;

	// Token: 0x0400245F RID: 9311
	public GameObject BringItemPrompt;

	// Token: 0x04002460 RID: 9312
	public Transform Highlight;

	// Token: 0x04002461 RID: 9313
	public UILabel[] Labels;

	// Token: 0x04002462 RID: 9314
	public int ID = 1;
}
