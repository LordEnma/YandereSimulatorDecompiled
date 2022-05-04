using System;
using UnityEngine;

// Token: 0x0200031F RID: 799
public class HomeExitScript : MonoBehaviour
{
	// Token: 0x06001896 RID: 6294 RVA: 0x000EEA10 File Offset: 0x000ECC10
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

	// Token: 0x06001897 RID: 6295 RVA: 0x000EEB38 File Offset: 0x000ECD38
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

	// Token: 0x06001898 RID: 6296 RVA: 0x000EEDD0 File Offset: 0x000ECFD0
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

	// Token: 0x040024CE RID: 9422
	public InputManagerScript InputManager;

	// Token: 0x040024CF RID: 9423
	public HomeDarknessScript HomeDarkness;

	// Token: 0x040024D0 RID: 9424
	public HomeYandereScript HomeYandere;

	// Token: 0x040024D1 RID: 9425
	public BringItemScript HomeBringItem;

	// Token: 0x040024D2 RID: 9426
	public HomeCameraScript HomeCamera;

	// Token: 0x040024D3 RID: 9427
	public HomeWindowScript HomeWindow;

	// Token: 0x040024D4 RID: 9428
	public GameObject BringItemPrompt;

	// Token: 0x040024D5 RID: 9429
	public Transform Highlight;

	// Token: 0x040024D6 RID: 9430
	public UILabel[] Labels;

	// Token: 0x040024D7 RID: 9431
	public int ID = 1;
}
