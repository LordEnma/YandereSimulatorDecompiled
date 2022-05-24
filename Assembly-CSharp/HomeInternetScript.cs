using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000321 RID: 801
public class HomeInternetScript : MonoBehaviour
{
	// Token: 0x0600189F RID: 6303 RVA: 0x000EF2F0 File Offset: 0x000ED4F0
	private void Awake()
	{
		this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, -180f, this.StudentPost1.localPosition.z);
		this.StudentPost2.localPosition = new Vector3(this.StudentPost2.localPosition.x, -365f, this.StudentPost2.localPosition.z);
		this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, -88f, this.YandereReply.localPosition.z);
		this.YanderePost.localPosition = new Vector3(this.YanderePost.localPosition.x, -2f, this.YanderePost.localPosition.z);
		for (int i = 1; i < 6; i++)
		{
			Transform transform = this.StudentReplies[i];
			transform.localPosition = new Vector3(transform.localPosition.x, -40f, transform.localPosition.z);
		}
		this.LameReply.localPosition = new Vector3(this.LameReply.localPosition.x, -40f, this.LameReply.localPosition.z);
		this.PostLabels[1].text = "";
		this.PostLabels[2].text = "";
		this.PostLabels[3].text = "";
		this.Highlights[1].enabled = false;
		this.Highlights[2].enabled = false;
		this.Highlights[3].enabled = false;
		this.YanderePost.gameObject.SetActive(false);
		this.NavigationMenu.SetActive(true);
		this.ChangeLabel.SetActive(false);
		this.ChangeIcon.SetActive(false);
		this.PostLabel.SetActive(false);
		this.PostIcon.SetActive(false);
		this.OnlineShopping.SetActive(false);
		this.NewPostText.SetActive(false);
		this.BG.SetActive(false);
		if (!SchemeGlobals.EmbarassingSecret || StudentGlobals.GetStudentExposed(11))
		{
			this.WriteLabel.SetActive(false);
			this.WriteIcon.SetActive(false);
		}
		this.GetPortrait(2);
		this.StudentPost1Portrait.mainTexture = this.CurrentPortrait;
		this.GetPortrait(39);
		this.StudentPost2Portrait.mainTexture = this.CurrentPortrait;
		this.GetPortrait(25);
		this.LamePostPortrait.mainTexture = this.CurrentPortrait;
		this.ID = 1;
		while (this.ID < 6)
		{
			this.GetPortrait(86 - this.ID);
			this.Portraits[this.ID].mainTexture = this.CurrentPortrait;
			this.ID++;
		}
		if (!DateGlobals.DayPassed)
		{
			this.YancordLabel.color = new Color(1f, 1f, 1f, 0.2f);
			this.YancordLogo.color = new Color(1f, 1f, 1f, 0.2f);
		}
	}

	// Token: 0x060018A0 RID: 6304 RVA: 0x000EF61C File Offset: 0x000ED81C
	private void Update()
	{
		if (!this.HomeYandere.CanMove && !this.PauseScreen.Show)
		{
			if (this.NavigationMenu.activeInHierarchy && !this.HomeCamera.CyberstalkWindow.activeInHierarchy)
			{
				if (Input.GetButtonDown("A"))
				{
					this.NavigationMenu.SetActive(false);
					this.SocialMedia.SetActive(true);
					return;
				}
				if (Input.GetButtonDown("X"))
				{
					if (DateGlobals.DayPassed)
					{
						this.HomeCamera.HomeDarkness.FadeOut = true;
						return;
					}
				}
				else
				{
					if (Input.GetButtonDown("Y"))
					{
						this.PauseScreen.MainMenu.SetActive(false);
						this.PauseScreen.Panel.enabled = true;
						this.PauseScreen.Sideways = true;
						this.PauseScreen.Show = true;
						this.StudentInfoMenu.gameObject.SetActive(true);
						this.StudentInfoMenu.CyberStalking = true;
						base.StartCoroutine(this.StudentInfoMenu.UpdatePortraits());
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "View Info";
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
						return;
					}
					if (Input.GetButtonDown("LB"))
					{
						this.NavigationMenu.SetActive(false);
						this.OnlineShopping.SetActive(true);
						this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
						return;
					}
					if (Input.GetButtonDown("B"))
					{
						this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
						this.HomeCamera.Target = this.HomeCamera.Targets[0];
						this.HomeYandere.CanMove = true;
						this.HomeWindow.Show = false;
						base.enabled = false;
						return;
					}
				}
			}
			else if (this.SocialMedia.activeInHierarchy)
			{
				this.Menu.localScale = Vector3.Lerp(this.Menu.localScale, this.ShowMenu ? new Vector3(2f, 2f, 2f) : Vector3.zero, Time.deltaTime * 10f);
				if (this.WritingPost)
				{
					this.NewPost.transform.localPosition = Vector3.Lerp(this.NewPost.transform.localPosition, Vector3.zero, Time.deltaTime * 10f);
					this.NewPost.transform.localScale = Vector3.Lerp(this.NewPost.transform.localScale, new Vector3(2.43f, 2.43f, 2.43f), Time.deltaTime * 10f);
					for (int i = 1; i < this.Highlights.Length; i++)
					{
						UISprite uisprite = this.Highlights[i];
						uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, Mathf.MoveTowards(uisprite.color.a, this.FadeOut ? 0f : 1f, Time.deltaTime));
					}
					if (this.Highlights[this.Selected].color.a == 1f)
					{
						this.FadeOut = true;
					}
					else if (this.Highlights[this.Selected].color.a == 0f)
					{
						this.FadeOut = false;
					}
					if (!this.ShowMenu)
					{
						if (this.InputManager.TappedRight)
						{
							this.Selected++;
							this.UpdateHighlight();
						}
						if (this.InputManager.TappedLeft)
						{
							this.Selected--;
							this.UpdateHighlight();
						}
					}
					else
					{
						if (this.InputManager.TappedDown)
						{
							this.MenuSelected++;
							this.UpdateMenuHighlight();
						}
						if (this.InputManager.TappedUp)
						{
							this.MenuSelected--;
							this.UpdateMenuHighlight();
						}
					}
				}
				else
				{
					this.NewPost.transform.localPosition = Vector3.Lerp(this.NewPost.transform.localPosition, new Vector3(175f, -10f, 0f), Time.deltaTime * 10f);
					this.NewPost.transform.localScale = Vector3.Lerp(this.NewPost.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
				if (!this.PostSequence)
				{
					if (Input.GetButtonDown("A") && this.WriteIcon.activeInHierarchy && !this.Posted)
					{
						if (!this.ShowMenu)
						{
							if (!this.WritingPost)
							{
								this.AcceptLabel.text = "Select";
								this.ChangeLabel.SetActive(true);
								this.ChangeIcon.SetActive(true);
								this.NewPostText.SetActive(true);
								this.BG.SetActive(true);
								this.WritingPost = true;
								this.Selected = 1;
								this.UpdateHighlight();
							}
							else if (this.Selected == 1)
							{
								this.PauseScreen.MainMenu.SetActive(false);
								this.PauseScreen.Panel.enabled = true;
								this.PauseScreen.Sideways = true;
								this.PauseScreen.Show = true;
								this.StudentInfoMenu.gameObject.SetActive(true);
								this.StudentInfoMenu.CyberBullying = true;
								base.StartCoroutine(this.StudentInfoMenu.UpdatePortraits());
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[0].text = "View Info";
								this.PromptBar.Label[1].text = "Back";
								this.PromptBar.UpdateButtons();
								this.PromptBar.Show = true;
							}
							else if (this.Selected == 2)
							{
								this.MenuSelected = 1;
								this.UpdateMenuHighlight();
								this.ShowMenu = true;
								for (int j = 1; j < this.MenuLabels.Length; j++)
								{
									this.MenuLabels[j].text = this.Locations[j];
								}
							}
							else if (this.Selected == 3)
							{
								this.MenuSelected = 1;
								this.UpdateMenuHighlight();
								this.ShowMenu = true;
								for (int k = 1; k < this.MenuLabels.Length; k++)
								{
									this.MenuLabels[k].text = this.Actions[k];
								}
							}
						}
						else
						{
							if (this.Selected == 2)
							{
								this.Location = this.MenuSelected;
								this.PostLabels[2].text = this.Locations[this.MenuSelected];
								this.ShowMenu = false;
							}
							else if (this.Selected == 3)
							{
								this.Action = this.MenuSelected;
								this.PostLabels[3].text = this.Actions[this.MenuSelected];
								this.ShowMenu = false;
							}
							this.CheckForCompletion();
						}
					}
					if (Input.GetButtonDown("B"))
					{
						if (!this.ShowMenu)
						{
							if (!this.WritingPost)
							{
								this.NavigationMenu.SetActive(true);
								this.SocialMedia.SetActive(false);
							}
							else
							{
								this.AcceptLabel.text = "Write";
								this.ChangeLabel.SetActive(false);
								this.ChangeIcon.SetActive(false);
								this.PostLabel.SetActive(false);
								this.PostIcon.SetActive(false);
								this.ExitPost();
							}
						}
						else
						{
							this.ShowMenu = false;
						}
					}
					if (Input.GetButtonDown("X") && this.PostIcon.activeInHierarchy)
					{
						this.YanderePostLabel.text = string.Concat(new string[]
						{
							"Did you know that ",
							this.PostLabels[1].text,
							" used to ",
							this.PostLabels[2].text,
							" about ",
							this.PostLabels[3].text,
							"?"
						});
						this.ExitPost();
						this.InternetPrompts.SetActive(false);
						this.ChangeLabel.SetActive(false);
						this.ChangeIcon.SetActive(false);
						this.WriteLabel.SetActive(false);
						this.WriteIcon.SetActive(false);
						this.PostLabel.SetActive(false);
						this.PostIcon.SetActive(false);
						this.PostSequence = true;
						this.Posted = true;
						if (this.Student == 11 && this.Location == 10 && this.Action == 10)
						{
							this.Success = true;
						}
					}
					if (Input.GetKeyDown("space"))
					{
						this.WriteLabel.SetActive(true);
						this.WriteIcon.SetActive(true);
					}
				}
				if (this.PostSequence)
				{
					if (Input.GetButtonDown("A"))
					{
						this.Timer += 2f;
					}
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f && this.Timer < 3f)
					{
						this.YanderePost.gameObject.SetActive(true);
						this.YanderePost.transform.localPosition = new Vector3(this.YanderePost.transform.localPosition.x, Mathf.Lerp(this.YanderePost.transform.localPosition.y, -155f, Time.deltaTime * 10f), this.YanderePost.transform.localPosition.z);
						this.StudentPost1.transform.localPosition = new Vector3(this.StudentPost1.transform.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -365f, Time.deltaTime * 10f), this.StudentPost1.transform.localPosition.z);
						this.StudentPost2.transform.localPosition = new Vector3(this.StudentPost2.transform.localPosition.x, Mathf.Lerp(this.StudentPost2.transform.localPosition.y, -550f, Time.deltaTime * 10f), this.StudentPost2.transform.localPosition.z);
					}
					if (!this.Success)
					{
						if (this.Timer > 3f && this.Timer < 5f)
						{
							this.LameReply.localPosition = new Vector3(this.LameReply.localPosition.x, Mathf.Lerp(this.LameReply.transform.localPosition.y, -88f, Time.deltaTime * 10f), this.LameReply.localPosition.z);
							this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -137f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
							this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -415f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
						}
						if (this.Timer > 5f)
						{
							PlayerGlobals.Reputation -= 5f;
							this.InternetPrompts.SetActive(true);
							this.PostSequence = false;
							return;
						}
					}
					else
					{
						if (this.Timer > 3f && this.Timer < 5f)
						{
							Transform transform = this.StudentReplies[1];
							transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform.localPosition.z);
							this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -137f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
							this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -415f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
						}
						if (this.Timer > 5f && this.Timer < 7f)
						{
							Transform transform2 = this.StudentReplies[2];
							transform2.localPosition = new Vector3(transform2.localPosition.x, Mathf.Lerp(transform2.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform2.localPosition.z);
							Transform transform3 = this.StudentReplies[1];
							transform3.localPosition = new Vector3(transform3.localPosition.x, Mathf.Lerp(transform3.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform3.localPosition.z);
							this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -185f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
							this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -465f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
						}
						if (this.Timer > 7f && this.Timer < 9f)
						{
							Transform transform4 = this.StudentReplies[3];
							transform4.localPosition = new Vector3(transform4.localPosition.x, Mathf.Lerp(transform4.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform4.localPosition.z);
							Transform transform5 = this.StudentReplies[2];
							transform5.localPosition = new Vector3(transform5.localPosition.x, Mathf.Lerp(transform5.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform5.localPosition.z);
							Transform transform6 = this.StudentReplies[1];
							transform6.localPosition = new Vector3(transform6.localPosition.x, Mathf.Lerp(transform6.transform.localPosition.y, -184f, Time.deltaTime * 10f), transform6.localPosition.z);
							this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -233f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
							this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -510f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
						}
						if (this.Timer > 9f && this.Timer < 11f)
						{
							Transform transform7 = this.StudentReplies[4];
							transform7.localPosition = new Vector3(transform7.localPosition.x, Mathf.Lerp(transform7.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform7.localPosition.z);
							Transform transform8 = this.StudentReplies[3];
							transform8.localPosition = new Vector3(transform8.localPosition.x, Mathf.Lerp(transform8.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform8.localPosition.z);
							Transform transform9 = this.StudentReplies[2];
							transform9.localPosition = new Vector3(transform9.localPosition.x, Mathf.Lerp(transform9.transform.localPosition.y, -184f, Time.deltaTime * 10f), transform9.localPosition.z);
							Transform transform10 = this.StudentReplies[1];
							transform10.localPosition = new Vector3(transform10.localPosition.x, Mathf.Lerp(transform10.transform.localPosition.y, -232f, Time.deltaTime * 10f), transform10.localPosition.z);
							this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -281f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
							this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -560f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
						}
						if (this.Timer > 11f && this.Timer < 13f)
						{
							Transform transform11 = this.StudentReplies[5];
							transform11.localPosition = new Vector3(transform11.localPosition.x, Mathf.Lerp(transform11.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform11.localPosition.z);
							Transform transform12 = this.StudentReplies[4];
							transform12.localPosition = new Vector3(transform12.localPosition.x, Mathf.Lerp(transform12.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform12.localPosition.z);
							Transform transform13 = this.StudentReplies[3];
							transform13.localPosition = new Vector3(transform13.localPosition.x, Mathf.Lerp(transform13.transform.localPosition.y, -184f, Time.deltaTime * 10f), transform13.localPosition.z);
							Transform transform14 = this.StudentReplies[2];
							transform14.localPosition = new Vector3(transform14.localPosition.x, Mathf.Lerp(transform14.transform.localPosition.y, -232f, Time.deltaTime * 10f), transform14.localPosition.z);
							Transform transform15 = this.StudentReplies[1];
							transform15.localPosition = new Vector3(transform15.localPosition.x, Mathf.Lerp(transform15.transform.localPosition.y, -280f, Time.deltaTime * 10f), transform15.localPosition.z);
							this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -329f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
						}
						if (this.Timer > 13f)
						{
							StudentGlobals.SetStudentExposed(11, true);
							StudentGlobals.UpdateRivalReputation = true;
							this.InternetPrompts.SetActive(true);
							this.PostSequence = false;
							return;
						}
					}
				}
			}
			else if (this.OnlineShopping.activeInHierarchy)
			{
				if (Input.GetKeyDown("m"))
				{
					PlayerGlobals.Money = 100f;
				}
				if (Input.GetButtonDown("A"))
				{
					if (this.Height == 0 || this.Height > 1)
					{
						if (PlayerGlobals.Money > 33.33f)
						{
							if (!this.AreYouSure.activeInHierarchy)
							{
								this.AreYouSure.SetActive(true);
							}
							else
							{
								this.AreYouSure.SetActive(false);
								GameGlobals.SpareUniform = true;
								PlayerGlobals.Money -= 33.33f;
								this.MyAudio.Play();
								this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
								this.Clock.UpdateMoneyLabel();
							}
						}
						else
						{
							this.Shake = 10f;
						}
					}
					else if (this.Height == 1)
					{
						if (PlayerGlobals.Money > 8.49f)
						{
							if (!this.AreYouSure.activeInHierarchy)
							{
								this.AreYouSure.SetActive(true);
							}
							else
							{
								this.AreYouSure.SetActive(false);
								GameGlobals.BlondeHair = true;
								PlayerGlobals.Money -= 8.49f;
								this.MyAudio.Play();
								this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
								this.Clock.UpdateMoneyLabel();
							}
						}
						else
						{
							this.Shake = 10f;
						}
					}
				}
				this.Shake = Mathf.MoveTowards(this.Shake, 0f, Time.deltaTime * 10f);
				this.MoneyLabel.transform.localPosition = new Vector3(445f + UnityEngine.Random.Range(this.Shake * -1f, this.Shake * 1f), 410f + UnityEngine.Random.Range(this.Shake * -1f, this.Shake * 1f), 0f);
				if (Input.GetButtonDown("B"))
				{
					if (!this.AreYouSure.activeInHierarchy)
					{
						this.NavigationMenu.SetActive(true);
						this.OnlineShopping.SetActive(false);
					}
					else
					{
						this.AreYouSure.SetActive(false);
					}
				}
				if (this.InputManager.TappedDown)
				{
					this.Height++;
				}
				if (this.InputManager.TappedUp)
				{
					this.Height--;
				}
				if (this.Height < 0)
				{
					this.Height = 0;
				}
				if (this.Height > 4)
				{
					this.Height = 4;
				}
				if (this.Height == 0)
				{
					this.Highlight.localPosition = Vector3.Lerp(this.Highlight.localPosition, new Vector3(this.Highlight.localPosition.x, 130f, this.Highlight.localPosition.z), Time.deltaTime * 10f);
				}
				else if (this.Height > 0)
				{
					this.Highlight.localPosition = Vector3.Lerp(this.Highlight.localPosition, new Vector3(this.Highlight.localPosition.x, -85f, this.Highlight.localPosition.z), Time.deltaTime * 10f);
				}
				if (this.Height < 2)
				{
					this.ItemList.localPosition = Vector3.Lerp(this.ItemList.localPosition, new Vector3(this.ItemList.localPosition.x, 130f, this.ItemList.localPosition.z), Time.deltaTime * 10f);
					return;
				}
				this.ItemList.localPosition = Vector3.Lerp(this.ItemList.localPosition, new Vector3(this.ItemList.localPosition.x, (float)(130 + 215 * (this.Height - 1)), this.ItemList.localPosition.z), Time.deltaTime * 10f);
			}
		}
	}

	// Token: 0x060018A1 RID: 6305 RVA: 0x000F0F3C File Offset: 0x000EF13C
	private void ExitPost()
	{
		this.Highlights[1].enabled = false;
		this.Highlights[2].enabled = false;
		this.Highlights[3].enabled = false;
		this.NewPostText.SetActive(false);
		this.BG.SetActive(false);
		this.PostLabels[1].text = string.Empty;
		this.PostLabels[2].text = string.Empty;
		this.PostLabels[3].text = string.Empty;
		this.WritingPost = false;
	}

	// Token: 0x060018A2 RID: 6306 RVA: 0x000F0FC8 File Offset: 0x000EF1C8
	private void UpdateHighlight()
	{
		if (this.Selected > 3)
		{
			this.Selected = 1;
		}
		if (this.Selected < 1)
		{
			this.Selected = 3;
		}
		this.Highlights[1].enabled = false;
		this.Highlights[2].enabled = false;
		this.Highlights[3].enabled = false;
		this.Highlights[this.Selected].enabled = true;
	}

	// Token: 0x060018A3 RID: 6307 RVA: 0x000F1034 File Offset: 0x000EF234
	private void UpdateMenuHighlight()
	{
		if (this.MenuSelected > 10)
		{
			this.MenuSelected = 1;
		}
		if (this.MenuSelected < 1)
		{
			this.MenuSelected = 10;
		}
		this.MenuHighlight.transform.localPosition = new Vector3(this.MenuHighlight.transform.localPosition.x, 220f - 40f * (float)this.MenuSelected, this.MenuHighlight.transform.localPosition.z);
	}

	// Token: 0x060018A4 RID: 6308 RVA: 0x000F10B8 File Offset: 0x000EF2B8
	private void CheckForCompletion()
	{
		if (this.PostLabels[1].text != string.Empty && this.PostLabels[2].text != string.Empty && this.PostLabels[3].text != string.Empty)
		{
			this.PostLabel.SetActive(true);
			this.PostIcon.SetActive(true);
		}
	}

	// Token: 0x060018A5 RID: 6309 RVA: 0x000F1128 File Offset: 0x000EF328
	private void GetPortrait(int ID)
	{
		WWW www = new WWW(string.Concat(new string[]
		{
			"file:///",
			Application.streamingAssetsPath,
			"/Portraits/Student_",
			ID.ToString(),
			".png"
		}));
		this.CurrentPortrait = www.texture;
	}

	// Token: 0x040024E4 RID: 9444
	public StudentInfoMenuScript StudentInfoMenu;

	// Token: 0x040024E5 RID: 9445
	public InputManagerScript InputManager;

	// Token: 0x040024E6 RID: 9446
	public PauseScreenScript PauseScreen;

	// Token: 0x040024E7 RID: 9447
	public PromptBarScript PromptBar;

	// Token: 0x040024E8 RID: 9448
	public HomeClockScript Clock;

	// Token: 0x040024E9 RID: 9449
	public HomeYandereScript HomeYandere;

	// Token: 0x040024EA RID: 9450
	public HomeCameraScript HomeCamera;

	// Token: 0x040024EB RID: 9451
	public HomeWindowScript HomeWindow;

	// Token: 0x040024EC RID: 9452
	public UILabel YanderePostLabel;

	// Token: 0x040024ED RID: 9453
	public UILabel YancordLabel;

	// Token: 0x040024EE RID: 9454
	public UILabel AcceptLabel;

	// Token: 0x040024EF RID: 9455
	public UITexture YancordLogo;

	// Token: 0x040024F0 RID: 9456
	public GameObject InternetPrompts;

	// Token: 0x040024F1 RID: 9457
	public GameObject NavigationMenu;

	// Token: 0x040024F2 RID: 9458
	public GameObject OnlineShopping;

	// Token: 0x040024F3 RID: 9459
	public GameObject SocialMedia;

	// Token: 0x040024F4 RID: 9460
	public GameObject NewPostText;

	// Token: 0x040024F5 RID: 9461
	public GameObject ChangeLabel;

	// Token: 0x040024F6 RID: 9462
	public GameObject ChangeIcon;

	// Token: 0x040024F7 RID: 9463
	public GameObject WriteLabel;

	// Token: 0x040024F8 RID: 9464
	public GameObject WriteIcon;

	// Token: 0x040024F9 RID: 9465
	public GameObject PostLabel;

	// Token: 0x040024FA RID: 9466
	public GameObject PostIcon;

	// Token: 0x040024FB RID: 9467
	public GameObject BG;

	// Token: 0x040024FC RID: 9468
	public Transform MenuHighlight;

	// Token: 0x040024FD RID: 9469
	public Transform StudentPost1;

	// Token: 0x040024FE RID: 9470
	public Transform StudentPost2;

	// Token: 0x040024FF RID: 9471
	public Transform YandereReply;

	// Token: 0x04002500 RID: 9472
	public Transform YanderePost;

	// Token: 0x04002501 RID: 9473
	public Transform LameReply;

	// Token: 0x04002502 RID: 9474
	public Transform NewPost;

	// Token: 0x04002503 RID: 9475
	public Transform Menu;

	// Token: 0x04002504 RID: 9476
	public Transform[] StudentReplies;

	// Token: 0x04002505 RID: 9477
	public UISprite[] Highlights;

	// Token: 0x04002506 RID: 9478
	public UILabel[] PostLabels;

	// Token: 0x04002507 RID: 9479
	public UILabel[] MenuLabels;

	// Token: 0x04002508 RID: 9480
	public string[] Locations;

	// Token: 0x04002509 RID: 9481
	public string[] Actions;

	// Token: 0x0400250A RID: 9482
	public bool PostSequence;

	// Token: 0x0400250B RID: 9483
	public bool WritingPost;

	// Token: 0x0400250C RID: 9484
	public bool ShowMenu;

	// Token: 0x0400250D RID: 9485
	public bool FadeOut;

	// Token: 0x0400250E RID: 9486
	public bool Success;

	// Token: 0x0400250F RID: 9487
	public bool Posted;

	// Token: 0x04002510 RID: 9488
	public int MenuSelected = 1;

	// Token: 0x04002511 RID: 9489
	public int Selected = 1;

	// Token: 0x04002512 RID: 9490
	public int ID = 1;

	// Token: 0x04002513 RID: 9491
	public int Location;

	// Token: 0x04002514 RID: 9492
	public int Student;

	// Token: 0x04002515 RID: 9493
	public int Action;

	// Token: 0x04002516 RID: 9494
	public float Timer;

	// Token: 0x04002517 RID: 9495
	public UITexture StudentPost1Portrait;

	// Token: 0x04002518 RID: 9496
	public UITexture StudentPost2Portrait;

	// Token: 0x04002519 RID: 9497
	public UITexture LamePostPortrait;

	// Token: 0x0400251A RID: 9498
	public Texture CurrentPortrait;

	// Token: 0x0400251B RID: 9499
	public UITexture[] Portraits;

	// Token: 0x0400251C RID: 9500
	public int Height;

	// Token: 0x0400251D RID: 9501
	public Transform Highlight;

	// Token: 0x0400251E RID: 9502
	public Transform ItemList;

	// Token: 0x0400251F RID: 9503
	public GameObject AreYouSure;

	// Token: 0x04002520 RID: 9504
	public AudioSource MyAudio;

	// Token: 0x04002521 RID: 9505
	public UILabel MoneyLabel;

	// Token: 0x04002522 RID: 9506
	public float Shake;
}
