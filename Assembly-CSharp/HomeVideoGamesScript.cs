using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000326 RID: 806
public class HomeVideoGamesScript : MonoBehaviour
{
	// Token: 0x0600189B RID: 6299 RVA: 0x000F16C0 File Offset: 0x000EF8C0
	private void Start()
	{
		if (TaskGlobals.GetTaskStatus(38) == 0)
		{
			this.TitleScreens[1] = this.TitleScreens[5];
			UILabel uilabel = this.GameTitles[1];
			uilabel.text = this.GameTitles[5].text;
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
		}
		if (GameGlobals.Eighties)
		{
			this.GameTitles[2].text = "Space Witch";
		}
		this.TitleScreen.mainTexture = this.TitleScreens[1];
	}

	// Token: 0x0600189C RID: 6300 RVA: 0x000F1760 File Offset: 0x000EF960
	private void Update()
	{
		if (this.HomeCamera.Destination == this.HomeCamera.Destinations[5])
		{
			if (Input.GetKeyDown("y"))
			{
				TaskGlobals.SetTaskStatus(38, 1);
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
			this.TV.localScale = Vector3.Lerp(this.TV.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (!this.HomeYandere.CanMove)
			{
				if (this.HomeDarkness.FadeOut)
				{
					Transform transform = this.HomeCamera.Destinations[5];
					Transform transform2 = this.HomeCamera.Targets[5];
					transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform2.position.x, Time.deltaTime * 0.75f), Mathf.Lerp(transform.position.y, transform2.position.y, Time.deltaTime * 10f), Mathf.Lerp(transform.position.z, transform2.position.z, Time.deltaTime * 10f));
					return;
				}
				if (this.InputManager.TappedDown)
				{
					this.ID++;
					if (this.ID > 5)
					{
						this.ID = 1;
					}
					this.TitleScreen.mainTexture = this.TitleScreens[this.ID];
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 150f - (float)this.ID * 50f, this.Highlight.localPosition.z);
				}
				if (this.InputManager.TappedUp)
				{
					this.ID--;
					if (this.ID < 1)
					{
						this.ID = 5;
					}
					this.TitleScreen.mainTexture = this.TitleScreens[this.ID];
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 150f - (float)this.ID * 50f, this.Highlight.localPosition.z);
				}
				if (Input.GetButtonDown("A") && this.GameTitles[this.ID].color.a == 1f)
				{
					Transform transform3 = this.HomeCamera.Targets[5];
					if (!this.HomeCamera.Eighties)
					{
						transform3.localPosition = new Vector3(transform3.localPosition.x, 1.153333f, transform3.localPosition.z);
					}
					else
					{
						transform3.localPosition = new Vector3(transform3.localPosition.x, 0.948f, transform3.localPosition.z);
					}
					this.HomeDarkness.Sprite.color = new Color(this.HomeDarkness.Sprite.color.r, this.HomeDarkness.Sprite.color.g, this.HomeDarkness.Sprite.color.b, -1f);
					this.HomeDarkness.FadeOut = true;
					this.HomeWindow.Show = false;
					this.PromptBar.Show = false;
					this.HomeCamera.ID = 5;
				}
				if (Input.GetButtonDown("B"))
				{
					this.Quit();
					return;
				}
			}
		}
		else
		{
			this.TV.localScale = Vector3.Lerp(this.TV.localScale, Vector3.zero, Time.deltaTime * 10f);
		}
	}

	// Token: 0x0600189D RID: 6301 RVA: 0x000F1B18 File Offset: 0x000EFD18
	public void Quit()
	{
		if (!this.HomeCamera.Eighties)
		{
			this.Controller.transform.localPosition = new Vector3(0.20385f, 0.0595f, 0.0215f);
			this.Controller.transform.localEulerAngles = new Vector3(-90f, -90f, 0f);
		}
		else
		{
			this.EightiesController.transform.localPosition = new Vector3(-0.08163334f, -0.1855f, -0.02433333f);
		}
		this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
		this.HomeCamera.Target = this.HomeCamera.Targets[0];
		this.HomeYandere.CanMove = true;
		this.HomeYandere.enabled = true;
		this.HomeWindow.Show = false;
		this.HomeCamera.PlayMusic();
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
	}

	// Token: 0x04002565 RID: 9573
	public InputManagerScript InputManager;

	// Token: 0x04002566 RID: 9574
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002567 RID: 9575
	public HomeYandereScript HomeYandere;

	// Token: 0x04002568 RID: 9576
	public HomeCameraScript HomeCamera;

	// Token: 0x04002569 RID: 9577
	public HomeWindowScript HomeWindow;

	// Token: 0x0400256A RID: 9578
	public PromptBarScript PromptBar;

	// Token: 0x0400256B RID: 9579
	public Texture[] TitleScreens;

	// Token: 0x0400256C RID: 9580
	public UITexture TitleScreen;

	// Token: 0x0400256D RID: 9581
	public Transform Highlight;

	// Token: 0x0400256E RID: 9582
	public UILabel[] GameTitles;

	// Token: 0x0400256F RID: 9583
	public Transform TV;

	// Token: 0x04002570 RID: 9584
	public int ID = 1;

	// Token: 0x04002571 RID: 9585
	public GameObject EightiesController;

	// Token: 0x04002572 RID: 9586
	public GameObject Controller;
}
