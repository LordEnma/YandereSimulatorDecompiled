using System;
using UnityEngine;

// Token: 0x020004BF RID: 1215
public class YakuzaMenuScript : MonoBehaviour
{
	// Token: 0x06001FC8 RID: 8136 RVA: 0x001C1A18 File Offset: 0x001BFC18
	private void Start()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString();
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

	// Token: 0x06001FC9 RID: 8137 RVA: 0x001C1F14 File Offset: 0x001C0114
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
								this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString();
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
						this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString();
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
						this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString();
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

	// Token: 0x06001FCA RID: 8138 RVA: 0x001C393C File Offset: 0x001C1B3C
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

	// Token: 0x06001FCB RID: 8139 RVA: 0x001C3A4C File Offset: 0x001C1C4C
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

	// Token: 0x06001FCC RID: 8140 RVA: 0x001C3AEC File Offset: 0x001C1CEC
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

	// Token: 0x06001FCD RID: 8141 RVA: 0x001C3EDC File Offset: 0x001C20DC
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

	// Token: 0x06001FCE RID: 8142 RVA: 0x001C3F38 File Offset: 0x001C2138
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
	}

	// Token: 0x06001FCF RID: 8143 RVA: 0x001C3FB0 File Offset: 0x001C21B0
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

	// Token: 0x06001FD0 RID: 8144 RVA: 0x001C4114 File Offset: 0x001C2314
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

	// Token: 0x06001FD1 RID: 8145 RVA: 0x001C4204 File Offset: 0x001C2404
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

	// Token: 0x06001FD2 RID: 8146 RVA: 0x001C430C File Offset: 0x001C250C
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

	// Token: 0x06001FD3 RID: 8147 RVA: 0x001C43FC File Offset: 0x001C25FC
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

	// Token: 0x040042BF RID: 17087
	public InputManagerScript InputManager;

	// Token: 0x040042C0 RID: 17088
	public StalkerYandereScript Yandere;

	// Token: 0x040042C1 RID: 17089
	public PromptBarScript PromptBar;

	// Token: 0x040042C2 RID: 17090
	public UISprite AssassinationMenu;

	// Token: 0x040042C3 RID: 17091
	public UISprite ContrabandMenu;

	// Token: 0x040042C4 RID: 17092
	public UISprite KidnappingMenu;

	// Token: 0x040042C5 RID: 17093
	public UISprite ServicesMenu;

	// Token: 0x040042C6 RID: 17094
	public AudioClip[] DialogueClip;

	// Token: 0x040042C7 RID: 17095
	public string[] DialogueText;

	// Token: 0x040042C8 RID: 17096
	public AudioSource Dialogue;

	// Token: 0x040042C9 RID: 17097
	public AudioSource Jukebox;

	// Token: 0x040042CA RID: 17098
	public UIPanel TimeDayPanel;

	// Token: 0x040042CB RID: 17099
	public UIPanel Panel;

	// Token: 0x040042CC RID: 17100
	public UILabel ButtonPrompt;

	// Token: 0x040042CD RID: 17101
	public UILabel MoneyLabel;

	// Token: 0x040042CE RID: 17102
	public Renderer Background;

	// Token: 0x040042CF RID: 17103
	public Renderer[] Scales;

	// Token: 0x040042D0 RID: 17104
	public Transform Yakuza;

	// Token: 0x040042D1 RID: 17105
	public UILabel Subtitle;

	// Token: 0x040042D2 RID: 17106
	public int RivalsToDisable;

	// Token: 0x040042D3 RID: 17107
	public int CutscenePhase = 1;

	// Token: 0x040042D4 RID: 17108
	public int Menu = 1;

	// Token: 0x040042D5 RID: 17109
	public float Alpha;

	// Token: 0x040042D6 RID: 17110
	public float Speed;

	// Token: 0x040042D7 RID: 17111
	public bool Cutscene;

	// Token: 0x040042D8 RID: 17112
	public bool Fail;

	// Token: 0x040042D9 RID: 17113
	public bool Show;

	// Token: 0x040042DA RID: 17114
	public UILabel[] BulletLabel;

	// Token: 0x040042DB RID: 17115
	public UITexture[] Bullet;

	// Token: 0x040042DC RID: 17116
	public AudioClip BulletSFX;

	// Token: 0x040042DD RID: 17117
	public int Selected = 1;

	// Token: 0x040042DE RID: 17118
	public int Limit = 4;

	// Token: 0x040042DF RID: 17119
	public GameObject ConfirmationWindow;

	// Token: 0x040042E0 RID: 17120
	public GameObject ResultWindow;

	// Token: 0x040042E1 RID: 17121
	public Transform CrosshairGraphic;

	// Token: 0x040042E2 RID: 17122
	public Transform Crosshair;

	// Token: 0x040042E3 RID: 17123
	public UITexture[] RivalPortraits;

	// Token: 0x040042E4 RID: 17124
	public UILabel[] RivalNameLabels;

	// Token: 0x040042E5 RID: 17125
	public UILabel ConfirmationLabel;

	// Token: 0x040042E6 RID: 17126
	public UILabel ResultLabel;

	// Token: 0x040042E7 RID: 17127
	public Vector3 TargetPosition;

	// Token: 0x040042E8 RID: 17128
	public Vector3 WobblePosition;

	// Token: 0x040042E9 RID: 17129
	public Texture BlankPortrait;

	// Token: 0x040042EA RID: 17130
	public string[] RivalNames;

	// Token: 0x040042EB RID: 17131
	public int TargetSelected = 1;

	// Token: 0x040042EC RID: 17132
	public int Column = 1;

	// Token: 0x040042ED RID: 17133
	public int Row = 1;

	// Token: 0x040042EE RID: 17134
	public int[] Costs;

	// Token: 0x040042EF RID: 17135
	public GameObject ItemConfirmationWindow;

	// Token: 0x040042F0 RID: 17136
	public UILabel ItemConfirmationLabel;

	// Token: 0x040042F1 RID: 17137
	public int ItemSelected = 1;

	// Token: 0x040042F2 RID: 17138
	public int ItemLimit = 5;

	// Token: 0x040042F3 RID: 17139
	public UILabel[] PriceLabel;

	// Token: 0x040042F4 RID: 17140
	public UISprite[] PriceBG;

	// Token: 0x040042F5 RID: 17141
	public UILabel[] ItemLabel;

	// Token: 0x040042F6 RID: 17142
	public UISprite[] ItemBG;

	// Token: 0x040042F7 RID: 17143
	public string[] ItemName;

	// Token: 0x040042F8 RID: 17144
	public int[] OriginalItemPrice;

	// Token: 0x040042F9 RID: 17145
	public int[] ItemPrice;

	// Token: 0x040042FA RID: 17146
	public GameObject RansomConfirmationWindow;

	// Token: 0x040042FB RID: 17147
	public UILabel RansomConfirmationLabel;

	// Token: 0x040042FC RID: 17148
	public UITexture[] RansomPortrait;

	// Token: 0x040042FD RID: 17149
	public UILabel PrisonerLabel;

	// Token: 0x040042FE RID: 17150
	public int[] Ransom;

	// Token: 0x040042FF RID: 17151
	public AudioClip[] Greeting;

	// Token: 0x04004300 RID: 17152
	public AudioClip AssassinationPurchase;

	// Token: 0x04004301 RID: 17153
	public AudioClip OpenAssassinationMenu;

	// Token: 0x04004302 RID: 17154
	public AudioClip ContrabandPurchase;

	// Token: 0x04004303 RID: 17155
	public AudioClip OpenContrabandMenu;

	// Token: 0x04004304 RID: 17156
	public AudioClip Confirmation;

	// Token: 0x04004305 RID: 17157
	public AudioClip BackOut;

	// Token: 0x04004306 RID: 17158
	public AudioClip Exit;

	// Token: 0x04004307 RID: 17159
	public int[] RansomIDs;
}
