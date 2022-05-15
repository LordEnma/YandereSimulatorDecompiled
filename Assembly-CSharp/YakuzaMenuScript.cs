using System;
using UnityEngine;

// Token: 0x020004D0 RID: 1232
public class YakuzaMenuScript : MonoBehaviour
{
	// Token: 0x06002037 RID: 8247 RVA: 0x001CC1DC File Offset: 0x001CA3DC
	private void Start()
	{
		this.UpdateMoneyLabel();
		this.RansomConfirmationWindow.SetActive(false);
		this.ConfirmationWindow.SetActive(false);
		this.ResultWindow.SetActive(false);
		this.AssassinationMenu.alpha = 0f;
		this.ContrabandMenu.alpha = 0f;
		this.KidnappingMenu.alpha = 0f;
		this.ServicesMenu.alpha = 1f;
		this.UpdateRansomPortraits();
		this.UpdateCrosshair();
		this.UpdateBullet();
		this.UpdateItem();
		int i = 1;
		WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_1.png");
		while (i < 11)
		{
			www = new WWW(string.Concat(new string[]
			{
				"file:///",
				Application.streamingAssetsPath,
				"/Portraits1989/Student_",
				(i + 10).ToString(),
				".png"
			}));
			this.RivalPortraits[i].mainTexture = www.texture;
			if (StudentGlobals.GetStudentDead(10 + i) || StudentGlobals.GetStudentKidnapped(10 + i))
			{
				this.RivalPortraits[i].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			}
			this.RivalNameLabels[i].text = this.RivalNames[i];
			this.RivalPortraits[i].transform.parent.localEulerAngles = new Vector3(0f, 0f, UnityEngine.Random.Range(-5f, 5f));
			i++;
		}
		www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_30.png");
		this.RansomPortrait[30].mainTexture = www.texture;
		www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_35.png");
		this.RansomPortrait[35].mainTexture = www.texture;
		www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_40.png");
		this.RansomPortrait[40].mainTexture = www.texture;
		www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_45.png");
		this.RansomPortrait[45].mainTexture = www.texture;
		www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_50.png");
		this.RansomPortrait[50].mainTexture = www.texture;
		www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_55.png");
		this.RansomPortrait[55].mainTexture = www.texture;
		www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_60.png");
		this.RansomPortrait[60].mainTexture = www.texture;
		www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_65.png");
		this.RansomPortrait[65].mainTexture = www.texture;
		www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_70.png");
		this.RansomPortrait[70].mainTexture = www.texture;
		www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_75.png");
		this.RansomPortrait[75].mainTexture = www.texture;
		for (i = DateGlobals.Week + 1; i < 11; i++)
		{
			this.RivalPortraits[i].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			this.RivalPortraits[i].mainTexture = this.BlankPortrait;
			this.RivalNameLabels[i].text = "?????";
		}
		this.Panel.alpha = 0f;
		this.Alpha = 0f;
		for (int j = 1; j < this.Scales.Length; j++)
		{
			this.Scales[j].material.color = new Color(1f, 0f, 0f, this.Alpha);
		}
		this.Background.material.color = new Color(1f, 0f, 0f, 0f);
		if (GameGlobals.YakuzaPhase == 0 || !HomeGlobals.Night || StudentGlobals.GetStudentDead(79))
		{
			base.gameObject.SetActive(false);
			this.ButtonPrompt.alpha = 0f;
			if (StudentGlobals.GetStudentDead(79))
			{
				this.Yakuza.gameObject.SetActive(false);
			}
		}
		if (SchoolGlobals.KidnapVictim == 0)
		{
			this.PrisonerLabel.text = "Come back when you have a prisoner in your basement.";
		}
		else
		{
			this.PrisonerLabel.text = "You currently have a prisoner in your basement.";
		}
		this.OriginalItemPrice[5] = DateGlobals.Week * 1000;
		this.ItemPrice[5] = DateGlobals.Week * 1000;
	}

	// Token: 0x06002038 RID: 8248 RVA: 0x001CC6BC File Offset: 0x001CA8BC
	private void Update()
	{
		if (this.Show)
		{
			this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 1f, Time.deltaTime);
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
			for (int i = 1; i < this.Scales.Length; i++)
			{
				this.Scales[i].material.color = new Color(1f, 0f, 0f, this.Alpha);
			}
			this.Background.material.color = new Color(1f, 0f, 0f, this.Alpha * 0.25f);
			if (this.Menu == 1)
			{
				this.ServicesMenu.alpha = Mathf.MoveTowards(this.ServicesMenu.alpha, 1f, Time.deltaTime * 10f);
				this.ContrabandMenu.alpha = Mathf.MoveTowards(this.ContrabandMenu.alpha, 0f, Time.deltaTime * 10f);
				this.KidnappingMenu.alpha = Mathf.MoveTowards(this.KidnappingMenu.alpha, 0f, Time.deltaTime * 10f);
				this.AssassinationMenu.alpha = Mathf.MoveTowards(this.AssassinationMenu.alpha, 0f, Time.deltaTime * 10f);
				if (this.ServicesMenu.alpha == 1f)
				{
					if (this.InputManager.TappedDown)
					{
						this.Selected++;
						this.UpdateBullet();
					}
					else if (this.InputManager.TappedUp)
					{
						this.Selected--;
						this.UpdateBullet();
					}
					if (Input.GetButtonDown("A"))
					{
						if (this.Selected == 1)
						{
							if (!GameGlobals.IntroducedAbduction)
							{
								GameGlobals.IntroducedAbduction = true;
								GameGlobals.YakuzaPhase = 6;
								this.CutscenePhase = 24;
								this.StartCutscene();
								this.Show = false;
							}
							else
							{
								AudioSource.PlayClipAtPoint(this.OpenAssassinationMenu, this.Yandere.MainCamera.transform.position);
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[0].text = "Abduct";
								this.PromptBar.Label[1].text = "Back";
								this.PromptBar.Label[4].text = "Change Selection";
								this.PromptBar.Label[5].text = "Change Selection";
								this.PromptBar.UpdateButtons();
								this.Menu = 2;
							}
						}
						else if (this.Selected == 2)
						{
							AudioSource.PlayClipAtPoint(this.OpenContrabandMenu, this.Yandere.MainCamera.transform.position);
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Purchase";
							this.PromptBar.Label[1].text = "Back";
							this.PromptBar.Label[5].text = "Change Selection";
							this.PromptBar.UpdateButtons();
							this.Menu = 3;
							this.UpdateItem();
						}
						else if (this.Selected == 3)
						{
							if (!GameGlobals.IntroducedRansom)
							{
								GameGlobals.IntroducedRansom = true;
								GameGlobals.YakuzaPhase = 8;
								this.CutscenePhase = 33;
								this.StartCutscene();
								this.Show = false;
							}
							else
							{
								this.PromptBar.ClearButtons();
								if (SchoolGlobals.KidnapVictim > 0)
								{
									this.PromptBar.Label[0].text = "Sell";
								}
								this.PromptBar.Label[1].text = "Back";
								this.PromptBar.UpdateButtons();
								this.Menu = 4;
							}
						}
						else if (this.Selected == 4)
						{
							AudioSource.PlayClipAtPoint(this.Exit, this.Yandere.MainCamera.transform.position);
							this.Quit();
						}
					}
					else if (Input.GetButtonDown("B"))
					{
						AudioSource.PlayClipAtPoint(this.Exit, this.Yandere.MainCamera.transform.position);
						this.Quit();
					}
				}
			}
			else if (this.Menu == 2)
			{
				this.ServicesMenu.alpha = Mathf.MoveTowards(this.ServicesMenu.alpha, 0f, Time.deltaTime * 10f);
				this.ContrabandMenu.alpha = Mathf.MoveTowards(this.ContrabandMenu.alpha, 0f, Time.deltaTime * 10f);
				this.KidnappingMenu.alpha = Mathf.MoveTowards(this.KidnappingMenu.alpha, 0f, Time.deltaTime * 10f);
				this.AssassinationMenu.alpha = Mathf.MoveTowards(this.AssassinationMenu.alpha, 1f, Time.deltaTime * 10f);
				if (this.AssassinationMenu.alpha == 1f)
				{
					if (!this.ConfirmationWindow.activeInHierarchy && !this.ResultWindow.activeInHierarchy)
					{
						if (this.InputManager.TappedDown || this.InputManager.TappedUp)
						{
							this.Row++;
							this.UpdateCrosshair();
						}
						if (this.InputManager.TappedRight)
						{
							this.Column++;
							this.UpdateCrosshair();
						}
						else if (this.InputManager.TappedLeft)
						{
							this.Column--;
							this.UpdateCrosshair();
						}
						if (Input.GetButtonDown("A"))
						{
							if (this.RivalPortraits[this.TargetSelected].color == new Color(1f, 1f, 1f, 1f))
							{
								AudioSource.PlayClipAtPoint(this.Confirmation, this.Yandere.MainCamera.transform.position);
								this.ConfirmationWindow.SetActive(true);
								this.ConfirmationLabel.text = string.Concat(new string[]
								{
									"Do you want ",
									this.RivalNames[this.TargetSelected],
									" to disappear forever? It will cost $",
									this.Costs[this.TargetSelected].ToString(),
									"."
								});
								this.PromptBar.Show = false;
							}
						}
						else if (Input.GetButtonDown("B"))
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Confirm";
							this.PromptBar.Label[1].text = "Exit";
							this.PromptBar.Label[4].text = "Change Selection";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
							GameGlobals.YakuzaPhase = 100;
							this.Menu = 1;
						}
					}
					else if (this.ConfirmationWindow.activeInHierarchy)
					{
						if (Input.GetButtonDown("A"))
						{
							if (PlayerGlobals.Money > (float)this.Costs[this.TargetSelected])
							{
								AudioSource.PlayClipAtPoint(this.AssassinationPurchase, this.Yandere.MainCamera.transform.position);
								StudentGlobals.SetStudentKidnapped(this.TargetSelected + 10, true);
								StudentGlobals.SetStudentMissing(this.TargetSelected + 10, true);
								StudentGlobals.SetStudentKidnapped(this.TargetSelected + 10, true);
								StudentGlobals.SetStudentMissing(this.TargetSelected + 10, true);
								if (this.TargetSelected == DateGlobals.Week)
								{
									GameGlobals.RivalEliminationID = 11;
									GameGlobals.SpecificEliminationID = 12;
								}
								this.ResultLabel.text = "This girl will be abducted before school tomorrow.";
								this.RivalPortraits[this.TargetSelected].color = new Color(0.5f, 0.5f, 0.5f, 1f);
								PlayerGlobals.Money -= (float)this.Costs[this.TargetSelected];
								this.UpdateMoneyLabel();
								GameGlobals.AbductionTarget = this.TargetSelected + 10;
								GameGlobals.ShowAbduction = true;
							}
							else
							{
								this.ResultLabel.text = "You don't have enough money to pay for her abduction!";
								this.Fail = true;
							}
							this.ConfirmationWindow.SetActive(false);
							this.ResultWindow.SetActive(true);
						}
						else if (Input.GetButtonDown("B"))
						{
							AudioSource.PlayClipAtPoint(this.BackOut, this.Yandere.MainCamera.transform.position);
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Confirm";
							this.PromptBar.Label[1].text = "Exit";
							this.PromptBar.Label[4].text = "Change Selection";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
							this.ConfirmationWindow.SetActive(false);
						}
					}
					else if (Input.GetButtonDown("A"))
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Confirm";
						this.PromptBar.Label[1].text = "Exit";
						this.PromptBar.Label[4].text = "Change Selection";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
						this.ResultWindow.SetActive(false);
						if (!this.Fail && GameGlobals.YakuzaPhase == 6)
						{
							GameGlobals.YakuzaPhase = 7;
							this.CutscenePhase = 28;
							this.StartCutscene();
							this.Show = false;
						}
						this.Fail = false;
					}
				}
			}
			else if (this.Menu == 3)
			{
				this.ServicesMenu.alpha = Mathf.MoveTowards(this.ServicesMenu.alpha, 0f, Time.deltaTime * 10f);
				this.ContrabandMenu.alpha = Mathf.MoveTowards(this.ContrabandMenu.alpha, 1f, Time.deltaTime * 10f);
				this.KidnappingMenu.alpha = Mathf.MoveTowards(this.KidnappingMenu.alpha, 0f, Time.deltaTime * 10f);
				this.AssassinationMenu.alpha = Mathf.MoveTowards(this.AssassinationMenu.alpha, 0f, Time.deltaTime * 10f);
				if (this.ContrabandMenu.alpha == 1f)
				{
					if (!this.ItemConfirmationWindow.activeInHierarchy)
					{
						if (this.InputManager.TappedDown)
						{
							this.ItemSelected++;
							this.UpdateItem();
						}
						else if (this.InputManager.TappedUp)
						{
							this.ItemSelected--;
							this.UpdateItem();
						}
						if (Input.GetButtonDown("A"))
						{
							if (GameGlobals.YakuzaPhase < 4)
							{
								if (this.ItemSelected == 1)
								{
									PlayerGlobals.BoughtLockpick = true;
								}
								else if (this.ItemSelected == 2)
								{
									PlayerGlobals.FakeID = true;
								}
								else if (this.ItemSelected == 3)
								{
									PlayerGlobals.BoughtNarcotics = true;
								}
								else if (this.ItemSelected == 4)
								{
									PlayerGlobals.BoughtPoison = true;
								}
								else if (this.ItemSelected == 5)
								{
									PlayerGlobals.BoughtExplosive = true;
								}
								GameGlobals.YakuzaPhase = 4;
								this.CutscenePhase = 12;
								this.StartCutscene();
								this.Show = false;
							}
							else if (this.ItemBG[this.ItemSelected].alpha == 1f)
							{
								AudioSource.PlayClipAtPoint(this.Confirmation, this.Yandere.MainCamera.transform.position);
								this.ItemConfirmationLabel.text = string.Concat(new string[]
								{
									"Would you like to purchase ",
									this.ItemName[this.ItemSelected],
									" for $",
									this.ItemPrice[this.ItemSelected].ToString(),
									"?"
								});
								this.ItemConfirmationWindow.SetActive(true);
								this.PromptBar.Show = false;
							}
						}
						else if (Input.GetButtonDown("B"))
						{
							if (GameGlobals.YakuzaPhase < 4)
							{
								GameGlobals.YakuzaPhase = 2;
								this.CutscenePhase = 8;
								this.StartCutscene();
								this.Show = false;
							}
							else
							{
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[0].text = "Confirm";
								this.PromptBar.Label[1].text = "Exit";
								this.PromptBar.Label[4].text = "Change Selection";
								this.PromptBar.UpdateButtons();
								this.PromptBar.Show = true;
								this.Menu = 1;
							}
						}
					}
					else if (Input.GetButtonDown("A"))
					{
						AudioSource.PlayClipAtPoint(this.ContrabandPurchase, this.Yandere.MainCamera.transform.position);
						if (this.ItemSelected == 1)
						{
							PlayerGlobals.BoughtLockpick = true;
						}
						else if (this.ItemSelected == 2)
						{
							PlayerGlobals.FakeID = true;
						}
						else if (this.ItemSelected == 3)
						{
							PlayerGlobals.BoughtNarcotics = true;
						}
						else if (this.ItemSelected == 4)
						{
							PlayerGlobals.BoughtPoison = true;
						}
						else if (this.ItemSelected == 5)
						{
							PlayerGlobals.BoughtExplosive = true;
						}
						PlayerGlobals.Money -= (float)this.ItemPrice[this.ItemSelected];
						this.UpdateMoneyLabel();
						this.UpdateItem();
						this.ItemConfirmationWindow.SetActive(false);
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Purchase";
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.Label[5].text = "Change Selection";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
					}
					else if (Input.GetButtonDown("B"))
					{
						AudioSource.PlayClipAtPoint(this.BackOut, this.Yandere.MainCamera.transform.position);
						this.ItemConfirmationWindow.SetActive(false);
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Purchase";
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.Label[5].text = "Change Selection";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
					}
				}
			}
			else if (this.Menu == 4)
			{
				this.ServicesMenu.alpha = Mathf.MoveTowards(this.ServicesMenu.alpha, 0f, Time.deltaTime * 10f);
				this.ContrabandMenu.alpha = Mathf.MoveTowards(this.ContrabandMenu.alpha, 0f, Time.deltaTime * 10f);
				this.KidnappingMenu.alpha = Mathf.MoveTowards(this.KidnappingMenu.alpha, 1f, Time.deltaTime * 10f);
				this.AssassinationMenu.alpha = Mathf.MoveTowards(this.AssassinationMenu.alpha, 0f, Time.deltaTime * 10f);
				if (this.KidnappingMenu.alpha == 1f)
				{
					if (!this.RansomConfirmationWindow.activeInHierarchy)
					{
						if (Input.GetButtonDown("A"))
						{
							if (SchoolGlobals.KidnapVictim > 0)
							{
								this.RansomConfirmationWindow.SetActive(true);
								this.RansomConfirmationLabel.text = "Give the kidnapped student in your basement to the yakuza in exchange for $" + this.Ransom[SchoolGlobals.KidnapVictim].ToString() + "?";
								this.PromptBar.Show = false;
							}
						}
						else if (Input.GetButtonDown("B"))
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Confirm";
							this.PromptBar.Label[1].text = "Exit";
							this.PromptBar.Label[4].text = "Change Selection";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
							this.Menu = 1;
						}
					}
					else if (Input.GetButtonDown("A"))
					{
						AudioSource.PlayClipAtPoint(this.ContrabandPurchase, this.Yandere.MainCamera.transform.position);
						StudentGlobals.SetStudentKidnapped(SchoolGlobals.KidnapVictim, false);
						StudentGlobals.SetStudentMissing(SchoolGlobals.KidnapVictim, false);
						StudentGlobals.SetStudentRansomed(SchoolGlobals.KidnapVictim, true);
						StudentGlobals.SetStudentBroken(SchoolGlobals.KidnapVictim, true);
						PlayerGlobals.Money += (float)this.Ransom[SchoolGlobals.KidnapVictim];
						this.UpdateMoneyLabel();
						this.UpdateRansomPortraits();
						SchoolGlobals.KidnapVictim = 0;
						this.RansomConfirmationWindow.SetActive(false);
						this.PrisonerLabel.text = "Come back when you have a prisoner in your basement.";
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
					}
					else if (Input.GetButtonDown("B"))
					{
						AudioSource.PlayClipAtPoint(this.BackOut, this.Yandere.MainCamera.transform.position);
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Sell";
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
						this.RansomConfirmationWindow.SetActive(false);
					}
				}
			}
			this.BulletLabel[this.Selected].transform.parent.localScale = Vector3.Lerp(this.BulletLabel[this.Selected].transform.parent.localScale, new Vector3(1.05f, 1.05f, 1.05f), Time.deltaTime * 10f);
			for (int j = 1; j < this.Bullet.Length; j++)
			{
				if (j != this.Selected)
				{
					this.BulletLabel[j].transform.parent.localScale = Vector3.Lerp(this.BulletLabel[j].transform.parent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
			this.Crosshair.localPosition = Vector3.Lerp(this.Crosshair.localPosition, this.TargetPosition, Time.deltaTime * 10f);
			if (!(this.CrosshairGraphic.localPosition != this.WobblePosition))
			{
				this.WobblePosition = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), 0f);
				return;
			}
			this.CrosshairGraphic.localPosition = Vector3.MoveTowards(this.CrosshairGraphic.localPosition, this.WobblePosition, Time.deltaTime * 50f);
			if (this.CrosshairGraphic.localPosition == this.WobblePosition)
			{
				this.WobblePosition = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), 0f);
				return;
			}
		}
		else
		{
			if (!this.Cutscene)
			{
				this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0f, Time.deltaTime);
			}
			else
			{
				this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.1f, Time.deltaTime);
			}
			this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0f, Time.deltaTime);
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
			for (int k = 1; k < this.Scales.Length; k++)
			{
				this.Scales[k].material.color = new Color(1f, 0f, 0f, this.Alpha);
			}
			this.Background.material.color = new Color(1f, 0f, 0f, this.Alpha * 0.25f);
			if (!this.Cutscene)
			{
				if (Vector3.Distance(this.Yandere.transform.position, this.Yakuza.position) >= 2f)
				{
					this.ButtonPrompt.alpha = Mathf.MoveTowards(this.ButtonPrompt.alpha, 0f, Time.deltaTime * 2f);
					return;
				}
				this.ButtonPrompt.alpha = Mathf.MoveTowards(this.ButtonPrompt.alpha, 1f, Time.deltaTime * 2f);
				if (Input.GetButtonDown("A") && this.Alpha == 0f)
				{
					if (GameGlobals.YakuzaPhase == 1)
					{
						this.CutscenePhase = 1;
						this.StartCutscene();
						return;
					}
					if (GameGlobals.YakuzaPhase == 3)
					{
						this.CutscenePhase = 10;
						this.StartCutscene();
						return;
					}
					if (GameGlobals.YakuzaPhase == 5)
					{
						this.CutscenePhase = 16;
						this.StartCutscene();
						return;
					}
					int num = UnityEngine.Random.Range(1, 4);
					AudioSource.PlayClipAtPoint(this.Greeting[num], this.Yandere.MainCamera.transform.position);
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Confirm";
					this.PromptBar.Label[1].text = "Exit";
					this.PromptBar.Label[4].text = "Change Selection";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
					this.Yandere.RPGCamera.enabled = false;
					this.Yandere.CanMove = false;
					this.Jukebox.volume = 1f;
					this.Jukebox.Play();
					this.TimeDayPanel.alpha = 0f;
					this.Show = true;
					return;
				}
			}
			else
			{
				if (!this.Jukebox.isPlaying)
				{
					this.Jukebox.Play();
				}
				this.Speed += Time.deltaTime;
				this.Yandere.MainCamera.transform.position = Vector3.Lerp(this.Yandere.MainCamera.transform.position, new Vector3(-2.25f, 1.5f, -5.5f), Time.deltaTime * this.Speed * 0.01f);
				if (!this.Dialogue.isPlaying || Input.GetButtonDown("A"))
				{
					this.CutscenePhase++;
					if (GameGlobals.YakuzaPhase == 1)
					{
						if (this.CutscenePhase < 8)
						{
							this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
							this.Dialogue.Play();
							this.Subtitle.text = this.DialogueText[this.CutscenePhase];
							return;
						}
						this.SummonContrabandMenu();
						return;
					}
					else if (GameGlobals.YakuzaPhase == 2)
					{
						if (this.CutscenePhase < 10)
						{
							this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
							this.Dialogue.Play();
							this.Subtitle.text = this.DialogueText[this.CutscenePhase];
							return;
						}
						GameGlobals.YakuzaPhase = 3;
						this.Quit();
						return;
					}
					else if (GameGlobals.YakuzaPhase == 3)
					{
						if (this.CutscenePhase < 12)
						{
							this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
							this.Dialogue.Play();
							this.Subtitle.text = this.DialogueText[this.CutscenePhase];
							return;
						}
						this.SummonContrabandMenu();
						return;
					}
					else if (GameGlobals.YakuzaPhase == 4)
					{
						if (this.CutscenePhase < 16)
						{
							this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
							this.Dialogue.Play();
							this.Subtitle.text = this.DialogueText[this.CutscenePhase];
							return;
						}
						GameGlobals.YakuzaPhase = 5;
						this.Quit();
						return;
					}
					else if (GameGlobals.YakuzaPhase == 5)
					{
						if (this.CutscenePhase < 24)
						{
							this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
							this.Dialogue.Play();
							this.Subtitle.text = this.DialogueText[this.CutscenePhase];
							return;
						}
						GameGlobals.YakuzaPhase = 100;
						this.SummonServicesMenu();
						return;
					}
					else if (GameGlobals.YakuzaPhase == 6)
					{
						if (this.CutscenePhase < 28)
						{
							this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
							this.Dialogue.Play();
							this.Subtitle.text = this.DialogueText[this.CutscenePhase];
							return;
						}
						this.SummonAssassinationMenu();
						return;
					}
					else if (GameGlobals.YakuzaPhase == 7)
					{
						if (this.CutscenePhase < 33)
						{
							this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
							this.Dialogue.Play();
							this.Subtitle.text = this.DialogueText[this.CutscenePhase];
							return;
						}
						GameGlobals.YakuzaPhase = 100;
						this.Quit();
						return;
					}
					else if (GameGlobals.YakuzaPhase == 8)
					{
						if (this.CutscenePhase < 41)
						{
							this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
							this.Dialogue.Play();
							this.Subtitle.text = this.DialogueText[this.CutscenePhase];
							return;
						}
						GameGlobals.YakuzaPhase = 100;
						this.SummonKidnappingMenu();
					}
				}
			}
		}
	}

	// Token: 0x06002039 RID: 8249 RVA: 0x001CE090 File Offset: 0x001CC290
	private void UpdateBullet()
	{
		if (this.Selected > this.Limit)
		{
			this.Selected = 1;
		}
		else if (this.Selected < 1)
		{
			this.Selected = this.Limit;
		}
		for (int i = 1; i < this.Bullet.Length; i++)
		{
			this.BulletLabel[i].color = new Color(1f, 1f, 1f, 1f);
			this.Bullet[i].color = new Color(0f, 0f, 0f, 1f);
		}
		this.BulletLabel[this.Selected].color = new Color(0f, 0f, 0f, 1f);
		this.Bullet[this.Selected].color = new Color(1f, 1f, 1f, 1f);
		if (this.Show)
		{
			AudioSource.PlayClipAtPoint(this.BulletSFX, Camera.main.transform.position);
		}
	}

	// Token: 0x0600203A RID: 8250 RVA: 0x001CE1A0 File Offset: 0x001CC3A0
	private void UpdateCrosshair()
	{
		if (this.Row > 2)
		{
			this.Row = 1;
		}
		else if (this.Row < 1)
		{
			this.Row = 2;
		}
		if (this.Column > 5)
		{
			this.Column = 1;
		}
		else if (this.Column < 1)
		{
			this.Column = 5;
		}
		this.TargetPosition = new Vector3((float)(-1500 + 500 * this.Column), (float)(340 - (this.Row - 1) * 600), 0f);
		this.TargetSelected = this.Column + (this.Row - 1) * 5;
	}

	// Token: 0x0600203B RID: 8251 RVA: 0x001CE240 File Offset: 0x001CC440
	private void UpdateItem()
	{
		if (this.ItemSelected > this.ItemLimit)
		{
			this.ItemSelected = 1;
		}
		else if (this.ItemSelected < 1)
		{
			this.ItemSelected = this.ItemLimit;
		}
		for (int i = 1; i < this.ItemBG.Length; i++)
		{
			this.ItemLabel[i].color = new Color(1f, 1f, 1f, 1f);
			this.ItemBG[i].color = new Color(0f, 0f, 0f, 1f);
			this.PriceLabel[i].color = new Color(1f, 1f, 1f, 1f);
			this.PriceBG[i].color = new Color(0f, 0f, 0f, 1f);
		}
		this.ItemLabel[this.ItemSelected].color = new Color(0f, 0f, 0f, 1f);
		this.ItemBG[this.ItemSelected].color = new Color(1f, 1f, 1f, 1f);
		this.PriceLabel[this.ItemSelected].color = new Color(0f, 0f, 0f, 1f);
		this.PriceBG[this.ItemSelected].color = new Color(1f, 1f, 1f, 1f);
		if (PlayerGlobals.BoughtLockpick)
		{
			this.ItemLabel[1].alpha = 0.5f;
			this.ItemBG[1].alpha = 0.5f;
			this.PriceLabel[1].alpha = 0.5f;
			this.PriceBG[1].alpha = 0.5f;
		}
		if (PlayerGlobals.FakeID)
		{
			this.ItemLabel[2].alpha = 0.5f;
			this.ItemBG[2].alpha = 0.5f;
			this.PriceLabel[2].alpha = 0.5f;
			this.PriceBG[2].alpha = 0.5f;
		}
		if (PlayerGlobals.BoughtNarcotics)
		{
			this.ItemLabel[3].alpha = 0.5f;
			this.ItemBG[3].alpha = 0.5f;
			this.PriceLabel[3].alpha = 0.5f;
			this.PriceBG[3].alpha = 0.5f;
		}
		if (PlayerGlobals.BoughtPoison)
		{
			this.ItemLabel[4].alpha = 0.5f;
			this.ItemBG[4].alpha = 0.5f;
			this.PriceLabel[4].alpha = 0.5f;
			this.PriceBG[4].alpha = 0.5f;
		}
		if (PlayerGlobals.BoughtExplosive)
		{
			this.ItemLabel[5].alpha = 0.5f;
			this.ItemBG[5].alpha = 0.5f;
			this.PriceLabel[5].alpha = 0.5f;
			this.PriceBG[5].alpha = 0.5f;
		}
		for (int i = 1; i < this.ItemBG.Length; i++)
		{
			if (GameGlobals.YakuzaPhase < 4)
			{
				this.ItemPrice[i] = 0;
				this.PriceLabel[i].text = "FREE";
			}
			else
			{
				this.ItemPrice[i] = this.OriginalItemPrice[i];
				this.PriceLabel[i].text = "$" + this.ItemPrice[i].ToString();
			}
			if (PlayerGlobals.Money < (float)this.ItemPrice[i])
			{
				this.ItemLabel[i].alpha = 0.5f;
				this.ItemBG[i].alpha = 0.5f;
				this.PriceLabel[i].alpha = 0.5f;
				this.PriceBG[i].alpha = 0.5f;
			}
		}
	}

	// Token: 0x0600203C RID: 8252 RVA: 0x001CE630 File Offset: 0x001CC830
	private void UpdateRansomPortraits()
	{
		for (int i = 1; i < this.RansomIDs.Length; i++)
		{
			if (StudentGlobals.GetStudentRansomed(this.RansomIDs[i]))
			{
				this.RansomPortrait[this.RansomIDs[i]].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			}
		}
	}

	// Token: 0x0600203D RID: 8253 RVA: 0x001CE68C File Offset: 0x001CC88C
	private void Quit()
	{
		this.Yandere.RPGCamera.enabled = true;
		this.Yandere.CanMove = true;
		this.TimeDayPanel.alpha = 1f;
		this.Subtitle.text = "";
		this.Cutscene = false;
		this.Show = false;
		this.Menu = 1;
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.HomeClock.UpdateMoneyLabel();
	}

	// Token: 0x0600203E RID: 8254 RVA: 0x001CE710 File Offset: 0x001CC910
	private void StartCutscene()
	{
		this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
		this.Yandere.RPGCamera.enabled = false;
		this.Yandere.CanMove = false;
		this.Yandere.MainCamera.transform.position = new Vector3(-2.25f, 0.1f, -5.5f);
		this.Yandere.MainCamera.transform.eulerAngles = new Vector3(0f, 30f, 0f);
		this.Yandere.transform.position = new Vector3(-2f, 0f, -4f);
		this.Yandere.transform.eulerAngles = new Vector3(0f, 150f, 0f);
		this.ButtonPrompt.alpha = 0f;
		this.TimeDayPanel.alpha = 0f;
		this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
		this.Dialogue.Play();
		this.Subtitle.text = this.DialogueText[this.CutscenePhase];
		this.Cutscene = true;
		this.Speed = 0f;
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
	}

	// Token: 0x0600203F RID: 8255 RVA: 0x001CE874 File Offset: 0x001CCA74
	private void SummonContrabandMenu()
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[0].text = "Purchase";
		this.PromptBar.Label[1].text = "Back";
		this.PromptBar.Label[5].text = "Change Selection";
		this.PromptBar.UpdateButtons();
		this.PromptBar.Show = true;
		this.MoneyLabel.transform.parent.gameObject.SetActive(false);
		this.ContrabandMenu.alpha = 1f;
		this.ServicesMenu.alpha = 0f;
		this.Jukebox.volume = 1f;
		this.Jukebox.Play();
		this.Subtitle.text = "";
		this.Cutscene = false;
		this.Show = true;
		this.Menu = 3;
	}

	// Token: 0x06002040 RID: 8256 RVA: 0x001CE964 File Offset: 0x001CCB64
	private void SummonAssassinationMenu()
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[0].text = "Abduct";
		this.PromptBar.Label[1].text = "Back";
		this.PromptBar.Label[4].text = "Change Selection";
		this.PromptBar.Label[5].text = "Change Selection";
		this.PromptBar.UpdateButtons();
		this.PromptBar.Show = true;
		this.MoneyLabel.transform.parent.gameObject.SetActive(true);
		this.AssassinationMenu.alpha = 1f;
		this.ServicesMenu.alpha = 0f;
		this.Jukebox.volume = 1f;
		this.Jukebox.Play();
		this.Subtitle.text = "";
		this.Cutscene = false;
		this.Show = true;
		this.Menu = 2;
	}

	// Token: 0x06002041 RID: 8257 RVA: 0x001CEA6C File Offset: 0x001CCC6C
	private void SummonServicesMenu()
	{
		this.PromptBar.ClearButtons();
		this.PromptBar.Label[0].text = "Confirm";
		this.PromptBar.Label[1].text = "Exit";
		this.PromptBar.Label[4].text = "Change Selection";
		this.PromptBar.UpdateButtons();
		this.PromptBar.Show = true;
		this.MoneyLabel.transform.parent.gameObject.SetActive(true);
		this.AssassinationMenu.alpha = 0f;
		this.ServicesMenu.alpha = 1f;
		this.Jukebox.volume = 1f;
		this.Jukebox.Play();
		this.Subtitle.text = "";
		this.Cutscene = false;
		this.Show = true;
		this.Menu = 1;
	}

	// Token: 0x06002042 RID: 8258 RVA: 0x001CEB5C File Offset: 0x001CCD5C
	private void SummonKidnappingMenu()
	{
		this.PromptBar.ClearButtons();
		if (SchoolGlobals.KidnapVictim > 0)
		{
			this.PromptBar.Label[0].text = "Sell";
		}
		this.PromptBar.Label[1].text = "Back";
		this.PromptBar.UpdateButtons();
		this.PromptBar.Show = true;
		this.MoneyLabel.transform.parent.gameObject.SetActive(true);
		this.AssassinationMenu.alpha = 0f;
		this.ServicesMenu.alpha = 1f;
		this.Jukebox.volume = 1f;
		this.Jukebox.Play();
		this.Subtitle.text = "";
		this.Cutscene = false;
		this.Show = true;
		this.Menu = 4;
	}

	// Token: 0x06002043 RID: 8259 RVA: 0x001CEC3C File Offset: 0x001CCE3C
	private void UpdateMoneyLabel()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2");
	}

	// Token: 0x040043FD RID: 17405
	public InputManagerScript InputManager;

	// Token: 0x040043FE RID: 17406
	public StalkerYandereScript Yandere;

	// Token: 0x040043FF RID: 17407
	public HomeClockScript HomeClock;

	// Token: 0x04004400 RID: 17408
	public PromptBarScript PromptBar;

	// Token: 0x04004401 RID: 17409
	public UISprite AssassinationMenu;

	// Token: 0x04004402 RID: 17410
	public UISprite ContrabandMenu;

	// Token: 0x04004403 RID: 17411
	public UISprite KidnappingMenu;

	// Token: 0x04004404 RID: 17412
	public UISprite ServicesMenu;

	// Token: 0x04004405 RID: 17413
	public AudioClip[] DialogueClip;

	// Token: 0x04004406 RID: 17414
	public string[] DialogueText;

	// Token: 0x04004407 RID: 17415
	public AudioSource Dialogue;

	// Token: 0x04004408 RID: 17416
	public AudioSource Jukebox;

	// Token: 0x04004409 RID: 17417
	public UIPanel TimeDayPanel;

	// Token: 0x0400440A RID: 17418
	public UIPanel Panel;

	// Token: 0x0400440B RID: 17419
	public UILabel ButtonPrompt;

	// Token: 0x0400440C RID: 17420
	public UILabel MoneyLabel;

	// Token: 0x0400440D RID: 17421
	public Renderer Background;

	// Token: 0x0400440E RID: 17422
	public Renderer[] Scales;

	// Token: 0x0400440F RID: 17423
	public Transform Yakuza;

	// Token: 0x04004410 RID: 17424
	public UILabel Subtitle;

	// Token: 0x04004411 RID: 17425
	public int RivalsToDisable;

	// Token: 0x04004412 RID: 17426
	public int CutscenePhase = 1;

	// Token: 0x04004413 RID: 17427
	public int Menu = 1;

	// Token: 0x04004414 RID: 17428
	public float Alpha;

	// Token: 0x04004415 RID: 17429
	public float Speed;

	// Token: 0x04004416 RID: 17430
	public bool Cutscene;

	// Token: 0x04004417 RID: 17431
	public bool Fail;

	// Token: 0x04004418 RID: 17432
	public bool Show;

	// Token: 0x04004419 RID: 17433
	public UILabel[] BulletLabel;

	// Token: 0x0400441A RID: 17434
	public UITexture[] Bullet;

	// Token: 0x0400441B RID: 17435
	public AudioClip BulletSFX;

	// Token: 0x0400441C RID: 17436
	public int Selected = 1;

	// Token: 0x0400441D RID: 17437
	public int Limit = 4;

	// Token: 0x0400441E RID: 17438
	public GameObject ConfirmationWindow;

	// Token: 0x0400441F RID: 17439
	public GameObject ResultWindow;

	// Token: 0x04004420 RID: 17440
	public Transform CrosshairGraphic;

	// Token: 0x04004421 RID: 17441
	public Transform Crosshair;

	// Token: 0x04004422 RID: 17442
	public UITexture[] RivalPortraits;

	// Token: 0x04004423 RID: 17443
	public UILabel[] RivalNameLabels;

	// Token: 0x04004424 RID: 17444
	public UILabel ConfirmationLabel;

	// Token: 0x04004425 RID: 17445
	public UILabel ResultLabel;

	// Token: 0x04004426 RID: 17446
	public Vector3 TargetPosition;

	// Token: 0x04004427 RID: 17447
	public Vector3 WobblePosition;

	// Token: 0x04004428 RID: 17448
	public Texture BlankPortrait;

	// Token: 0x04004429 RID: 17449
	public string[] RivalNames;

	// Token: 0x0400442A RID: 17450
	public int TargetSelected = 1;

	// Token: 0x0400442B RID: 17451
	public int Column = 1;

	// Token: 0x0400442C RID: 17452
	public int Row = 1;

	// Token: 0x0400442D RID: 17453
	public int[] Costs;

	// Token: 0x0400442E RID: 17454
	public GameObject ItemConfirmationWindow;

	// Token: 0x0400442F RID: 17455
	public UILabel ItemConfirmationLabel;

	// Token: 0x04004430 RID: 17456
	public int ItemSelected = 1;

	// Token: 0x04004431 RID: 17457
	public int ItemLimit = 5;

	// Token: 0x04004432 RID: 17458
	public UILabel[] PriceLabel;

	// Token: 0x04004433 RID: 17459
	public UISprite[] PriceBG;

	// Token: 0x04004434 RID: 17460
	public UILabel[] ItemLabel;

	// Token: 0x04004435 RID: 17461
	public UISprite[] ItemBG;

	// Token: 0x04004436 RID: 17462
	public string[] ItemName;

	// Token: 0x04004437 RID: 17463
	public int[] OriginalItemPrice;

	// Token: 0x04004438 RID: 17464
	public int[] ItemPrice;

	// Token: 0x04004439 RID: 17465
	public GameObject RansomConfirmationWindow;

	// Token: 0x0400443A RID: 17466
	public UILabel RansomConfirmationLabel;

	// Token: 0x0400443B RID: 17467
	public UITexture[] RansomPortrait;

	// Token: 0x0400443C RID: 17468
	public UILabel PrisonerLabel;

	// Token: 0x0400443D RID: 17469
	public int[] Ransom;

	// Token: 0x0400443E RID: 17470
	public AudioClip[] Greeting;

	// Token: 0x0400443F RID: 17471
	public AudioClip AssassinationPurchase;

	// Token: 0x04004440 RID: 17472
	public AudioClip OpenAssassinationMenu;

	// Token: 0x04004441 RID: 17473
	public AudioClip ContrabandPurchase;

	// Token: 0x04004442 RID: 17474
	public AudioClip OpenContrabandMenu;

	// Token: 0x04004443 RID: 17475
	public AudioClip Confirmation;

	// Token: 0x04004444 RID: 17476
	public AudioClip BackOut;

	// Token: 0x04004445 RID: 17477
	public AudioClip Exit;

	// Token: 0x04004446 RID: 17478
	public int[] RansomIDs;
}
