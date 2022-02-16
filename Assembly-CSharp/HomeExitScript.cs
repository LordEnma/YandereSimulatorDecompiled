using System;
using UnityEngine;

// Token: 0x0200031C RID: 796
public class HomeExitScript : MonoBehaviour
{
	// Token: 0x06001874 RID: 6260 RVA: 0x000ECB04 File Offset: 0x000EAD04
	private void Start()
	{
		UILabel uilabel = this.Labels[1];
		if (HomeGlobals.Night)
		{
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
			if (SchemeGlobals.GetSchemeStage(6) == 9 && !StudentGlobals.GetStudentDead(10 + DateGlobals.Week) && !StudentGlobals.GetStudentKidnapped(10 + DateGlobals.Week) && GameGlobals.RivalEliminationID == 0)
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

	// Token: 0x06001875 RID: 6261 RVA: 0x000ECC2C File Offset: 0x000EAE2C
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

	// Token: 0x06001876 RID: 6262 RVA: 0x000ECEC4 File Offset: 0x000EB0C4
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

	// Token: 0x04002473 RID: 9331
	public InputManagerScript InputManager;

	// Token: 0x04002474 RID: 9332
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002475 RID: 9333
	public HomeYandereScript HomeYandere;

	// Token: 0x04002476 RID: 9334
	public BringItemScript HomeBringItem;

	// Token: 0x04002477 RID: 9335
	public HomeCameraScript HomeCamera;

	// Token: 0x04002478 RID: 9336
	public HomeWindowScript HomeWindow;

	// Token: 0x04002479 RID: 9337
	public GameObject BringItemPrompt;

	// Token: 0x0400247A RID: 9338
	public Transform Highlight;

	// Token: 0x0400247B RID: 9339
	public UILabel[] Labels;

	// Token: 0x0400247C RID: 9340
	public int ID = 1;
}
