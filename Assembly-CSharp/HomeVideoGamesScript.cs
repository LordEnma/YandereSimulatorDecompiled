using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000329 RID: 809
public class HomeVideoGamesScript : MonoBehaviour
{
	// Token: 0x060018B2 RID: 6322 RVA: 0x000F2AF8 File Offset: 0x000F0CF8
	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			this.GameTitles[2].text = "Space Witch";
			this.GameTitles[1].text = "??????????";
			this.GameTitles[1].color = new Color(1f, 1f, 1f, 0.5f);
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

	// Token: 0x060018B3 RID: 6323 RVA: 0x000F2BD4 File Offset: 0x000F0DD4
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

	// Token: 0x060018B4 RID: 6324 RVA: 0x000F2F8C File Offset: 0x000F118C
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

	// Token: 0x0400258A RID: 9610
	public InputManagerScript InputManager;

	// Token: 0x0400258B RID: 9611
	public HomeDarknessScript HomeDarkness;

	// Token: 0x0400258C RID: 9612
	public HomeYandereScript HomeYandere;

	// Token: 0x0400258D RID: 9613
	public HomeCameraScript HomeCamera;

	// Token: 0x0400258E RID: 9614
	public HomeWindowScript HomeWindow;

	// Token: 0x0400258F RID: 9615
	public PromptBarScript PromptBar;

	// Token: 0x04002590 RID: 9616
	public Texture[] TitleScreens;

	// Token: 0x04002591 RID: 9617
	public UITexture TitleScreen;

	// Token: 0x04002592 RID: 9618
	public Transform Highlight;

	// Token: 0x04002593 RID: 9619
	public UILabel[] GameTitles;

	// Token: 0x04002594 RID: 9620
	public Transform TV;

	// Token: 0x04002595 RID: 9621
	public int ID = 1;

	// Token: 0x04002596 RID: 9622
	public GameObject EightiesController;

	// Token: 0x04002597 RID: 9623
	public GameObject Controller;
}
