using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000327 RID: 807
public class HomeVideoGamesScript : MonoBehaviour
{
	// Token: 0x060018A2 RID: 6306 RVA: 0x000F20A8 File Offset: 0x000F02A8
	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			this.GameTitles[2].text = "Space Witch";
		}
		else if (TaskGlobals.GetTaskStatus(38) == 0)
		{
			this.TitleScreens[1] = this.TitleScreens[5];
			UILabel uilabel = this.GameTitles[1];
			uilabel.text = this.GameTitles[5].text;
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
		}
		this.TitleScreen.mainTexture = this.TitleScreens[1];
	}

	// Token: 0x060018A3 RID: 6307 RVA: 0x000F214C File Offset: 0x000F034C
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

	// Token: 0x060018A4 RID: 6308 RVA: 0x000F2504 File Offset: 0x000F0704
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

	// Token: 0x04002575 RID: 9589
	public InputManagerScript InputManager;

	// Token: 0x04002576 RID: 9590
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04002577 RID: 9591
	public HomeYandereScript HomeYandere;

	// Token: 0x04002578 RID: 9592
	public HomeCameraScript HomeCamera;

	// Token: 0x04002579 RID: 9593
	public HomeWindowScript HomeWindow;

	// Token: 0x0400257A RID: 9594
	public PromptBarScript PromptBar;

	// Token: 0x0400257B RID: 9595
	public Texture[] TitleScreens;

	// Token: 0x0400257C RID: 9596
	public UITexture TitleScreen;

	// Token: 0x0400257D RID: 9597
	public Transform Highlight;

	// Token: 0x0400257E RID: 9598
	public UILabel[] GameTitles;

	// Token: 0x0400257F RID: 9599
	public Transform TV;

	// Token: 0x04002580 RID: 9600
	public int ID = 1;

	// Token: 0x04002581 RID: 9601
	public GameObject EightiesController;

	// Token: 0x04002582 RID: 9602
	public GameObject Controller;
}
