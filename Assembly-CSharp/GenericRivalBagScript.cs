using System;
using UnityEngine;

// Token: 0x020002DE RID: 734
public class GenericRivalBagScript : MonoBehaviour
{
	// Token: 0x060014DC RID: 5340 RVA: 0x000D0040 File Offset: 0x000CE240
	public void Start()
	{
		if (!this.Initialized)
		{
			int week = DateGlobals.Week;
			if (week < 11)
			{
				if (week == 4)
				{
					this.NoBento = true;
				}
				int num = 10 + week;
				this.RivalOpinions = this.JSON.Topics[num].Topics;
				for (int i = 1; i < 26; i++)
				{
					if (this.RivalOpinions[i] == 2)
					{
						this.RivalLikes[this.Likes] = this.Subjects[i];
						this.Likes++;
					}
					else if (this.RivalOpinions[i] == 1)
					{
						this.RivalDislikes[this.Dislikes] = this.Subjects[i];
						this.Dislikes++;
					}
				}
				num -= 10;
				this.DesiredHairstyle = this.DesiredHairstyles[num];
				this.DesiredAccessory = this.DesiredAccessories[num];
				this.DesiredEyewear = this.DesiredEyewears[num];
				this.DesiredSkin = this.DesiredSkins[num];
				this.DesiredHairColor = this.DesiredHairColors[num];
				this.DesiredJewelry = this.DesiredJewelries[num];
				this.DesiredTrait = this.DesiredTraits[num];
				if (this.DesiredHairstyle == 55)
				{
					this.DesiredHairstyleText = "She likes boys who have ponytails.";
				}
				else if (this.DesiredHairstyle == 56)
				{
					this.DesiredHairstyleText = "She likes boys who have slick hair.";
				}
				if (this.DesiredAccessory == 17)
				{
					this.DesiredAccessoryText = "She likes boys who have piercings.";
				}
				else if (this.DesiredAccessory == 1)
				{
					this.DesiredAccessoryText = "She likes boys who wear bandanas.";
				}
				if (this.DesiredEyewear == 6)
				{
					this.DesiredEyewearText = "She likes boys who wear glasses.";
				}
				else if (this.DesiredEyewear == 3)
				{
					this.DesiredEyewearText = "She likes boys who wear shades.";
				}
				if (this.DesiredSkin == 6)
				{
					this.DesiredSkinText = "She likes boys who tan their skin.";
				}
				else
				{
					this.DesiredSkinText = "She doesn't like boys who tan their skin.";
				}
				if (this.DesiredHairColor == "SolidBlack")
				{
					this.DesiredHairColorText = "She likes boys with dark hair.";
				}
				else
				{
					this.DesiredHairColorText = "She doesn't like dark hair.";
				}
				if (this.DesiredJewelry)
				{
					this.DesiredJewelryText = "She likes boys who wear a lot of jewelry.";
				}
				else
				{
					this.DesiredJewelryText = "She doesn't like boys who wear a lot of jewlery.";
				}
				if (this.DesiredTrait == 1)
				{
					this.DesiredTraitText = "She admires men who have a lot of courage.";
				}
				else if (this.DesiredTrait == 2)
				{
					this.DesiredTraitText = "She admires men who have intelligence.";
				}
				else if (this.DesiredTrait == 3)
				{
					this.DesiredTraitText = "She admires men with a lot of physical strength.";
				}
			}
			base.gameObject.SetActive(false);
			this.Window.SetActive(false);
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			this.Initialized = true;
		}
	}

	// Token: 0x060014DD RID: 5341 RVA: 0x000D02C4 File Offset: 0x000CE4C4
	private void Update()
	{
		if (!this.Window.activeInHierarchy)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!this.Prompt.Yandere.StudentManager.YandereVisible)
				{
					this.Prompt.Yandere.RPGCamera.enabled = false;
					this.Prompt.Yandere.CanMove = false;
					Time.timeScale = 0.0001f;
					this.Window.SetActive(true);
					this.Menu = 1;
					this.UpdateMenuLabels();
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Confirm";
					this.PromptBar.Label[5].text = "Change Selection";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					return;
				}
				this.Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone is watching!";
				this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				return;
			}
		}
		else
		{
			if (this.InputManager.TappedDown)
			{
				this.Selected++;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedUp)
			{
				this.Selected--;
				this.UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				if (this.Menu == 1)
				{
					if (this.Label[this.Selected].color.a == 1f)
					{
						if (this.Selected == 1)
						{
							this.Menu = 2;
							this.UpdateMenuLabels();
							return;
						}
						if (this.Selected == 2)
						{
							this.Menu = 3;
							this.UpdateMenuLabels();
							return;
						}
						if (this.Selected == 3)
						{
							this.Menu = 4;
							this.UpdateMenuLabels();
							return;
						}
						if (this.Selected == 4)
						{
							this.CloseWindow();
							return;
						}
					}
				}
				else if (this.Menu == 2)
				{
					if (this.Label[this.Selected].color.a == 1f)
					{
						if (this.Selected == 1)
						{
							Debug.Log("The player has stolen the book that the rival borrowed from Senpai.");
							this.BorrowedBook = false;
							this.Event.Sabotage();
							ScheduleBlock scheduleBlock = this.Rival.ScheduleBlocks[4];
							scheduleBlock.destination = "Search Patrol";
							scheduleBlock.action = "Search Patrol";
							this.Rival.GetDestinations();
							Debug.Log("The rival's routine should now be adjusted to ''Search'' at lunchtime.");
							this.UpdateMenuLabels();
							return;
						}
						if (this.Selected == 2)
						{
							this.Highlight.gameObject.SetActive(false);
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[1].text = "Back";
							this.PromptBar.UpdateButtons();
							this.Menu = 5;
							this.UpdateMenuLabels();
							return;
						}
						if (this.Selected == 3)
						{
							this.Highlight.gameObject.SetActive(false);
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[1].text = "Back";
							this.PromptBar.UpdateButtons();
							this.Menu = 6;
							this.UpdateMenuLabels();
							return;
						}
						if (this.Selected == 4)
						{
							this.Menu = 1;
							this.UpdateMenuLabels();
							return;
						}
					}
				}
				else if (this.Menu == 3)
				{
					if (this.Label[this.Selected].color.a == 1f)
					{
						if (this.Selected == 1)
						{
							if (this.Prompt.Yandere.Inventory.RatPoison)
							{
								this.Prompt.Yandere.Inventory.RatPoison = false;
							}
							else
							{
								this.Prompt.Yandere.Inventory.EmeticPoison = false;
							}
							this.Rival.MyBento.Tampered = true;
							this.Rival.MyBento.Emetic = true;
						}
						else if (this.Selected == 2)
						{
							this.Rival.MyBento.Tampered = true;
							this.Rival.MyBento.Lethal = true;
							if (this.Prompt.Yandere.Inventory.LethalPoison)
							{
								this.Prompt.Yandere.Inventory.LethalPoison = false;
							}
							else
							{
								this.Prompt.Yandere.Inventory.ChemicalPoison = false;
							}
						}
						else if (this.Selected == 3)
						{
							this.Rival.MyBento.Tampered = true;
							this.Rival.MyBento.Headache = true;
						}
						else if (this.Selected == 4)
						{
							if (this.Prompt.Yandere.Inventory.Tranquilizer)
							{
								this.Prompt.Yandere.Inventory.Tranquilizer = false;
							}
							else
							{
								this.Prompt.Yandere.Inventory.Sedative = false;
							}
							this.Rival.MyBento.Tampered = true;
							this.Rival.MyBento.Tranquil = true;
						}
						else if (this.Selected == 5)
						{
							this.Rival.ScheduleBlocks[4].action = "Shamed";
							this.Rival.GetDestinations();
							this.BentoStolen = true;
						}
						this.Menu = 1;
						this.UpdateMenuLabels();
						return;
					}
				}
				else if (this.Menu == 4 && this.Label[this.Selected].color.a == 1f)
				{
					if (this.Selected == 1)
					{
						this.Prompt.Yandere.Inventory.Sake = false;
						this.Alcohol = true;
					}
					else if (this.Selected == 2)
					{
						this.Prompt.Yandere.Inventory.Condoms = false;
						this.Condoms = true;
					}
					else if (this.Selected == 3)
					{
						this.Prompt.Yandere.Inventory.Cigs = false;
						this.Cigarettes = true;
					}
					else if (this.Selected == 4)
					{
						this.Prompt.Yandere.Inventory.Ring = false;
						this.StolenRing = true;
					}
					else if (this.Selected == 5)
					{
						this.Prompt.Yandere.Inventory.AnswerSheet = false;
						this.AnswerSheet = true;
					}
					else if (this.Selected == 6)
					{
						this.Prompt.Yandere.Inventory.Narcotics = false;
						this.Narcotics = true;
					}
					this.Menu = 1;
					this.UpdateMenuLabels();
					return;
				}
			}
			else if (Input.GetButtonDown("B"))
			{
				this.Highlight.gameObject.SetActive(true);
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Confirm";
				this.PromptBar.Label[5].text = "Change Selection";
				this.PromptBar.UpdateButtons();
				if (this.Menu == 5)
				{
					this.Menu = 2;
					this.UpdateMenuLabels();
					return;
				}
				if (this.Menu == 6)
				{
					this.Menu = 2;
					this.UpdateMenuLabels();
				}
			}
		}
	}

	// Token: 0x060014DE RID: 5342 RVA: 0x000D09F8 File Offset: 0x000CEBF8
	private void CloseWindow()
	{
		this.Selected = 1;
		this.UpdateHighlight();
		this.Prompt.Yandere.RPGCamera.enabled = true;
		this.Prompt.Yandere.CanMove = true;
		this.Window.SetActive(false);
		Time.timeScale = 1f;
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
	}

	// Token: 0x060014DF RID: 5343 RVA: 0x000D0A68 File Offset: 0x000CEC68
	private void UpdateHighlight()
	{
		if (this.Selected > this.Limit)
		{
			this.Selected = 1;
		}
		else if (this.Selected < 1)
		{
			this.Selected = this.Limit;
		}
		this.Highlight.localPosition = new Vector3(0f, (float)(400 - this.Selected * 100), 0f);
	}

	// Token: 0x060014E0 RID: 5344 RVA: 0x000D0ACC File Offset: 0x000CECCC
	private void UpdateMenuLabels()
	{
		Debug.Log("Updating menu labels as of right now.");
		this.Selected = 1;
		this.UpdateHighlight();
		for (int i = 1; i < this.Label.Length; i++)
		{
			this.Label[i].color = new Color(1f, 1f, 1f, 1f);
			this.Label[i].text = "";
		}
		this.Label[8].text = "";
		if (this.Menu == 1)
		{
			this.Label[1].text = "BOOKS";
			this.Label[2].text = "BENTO";
			this.Label[3].text = "CONTRABAND";
			this.Label[4].text = "EXIT";
			if (this.Rival.MyBento.Tampered || this.BentoStolen || this.NoBento)
			{
				this.Label[2].color = new Color(1f, 1f, 1f, 0.5f);
				if (this.BentoStolen)
				{
					this.Label[2].text = "BENTO (STOLEN)";
				}
				else if (this.NoBento)
				{
					this.Label[2].text = "NO BENTO";
				}
				else
				{
					this.Label[2].text = "BENTO (POISONED)";
				}
			}
			if (this.Prompt.Yandere.StudentManager.Clock.Period > 3)
			{
				this.Label[2].color = new Color(1f, 1f, 1f, 0.5f);
			}
			this.Limit = 4;
			return;
		}
		if (this.Menu == 2)
		{
			this.Label[1].text = "STEAL BORROWED BOOK";
			this.Label[2].text = "READ MAGAZINE";
			this.Label[3].text = "READ DIARY";
			this.Label[4].text = "BACK";
			if (!this.BorrowedBook || this.Prompt.Yandere.StudentManager.Clock.Period == 3)
			{
				this.Label[1].color = new Color(1f, 1f, 1f, 0.5f);
			}
			this.Limit = 4;
			return;
		}
		if (this.Menu == 3)
		{
			this.Label[1].text = "PUT EMETIC POISON IN BENTO";
			this.Label[2].text = "PUT LETHAL POISON IN BENTO";
			this.Label[3].text = "PUT HEADACHE POISON IN BENTO";
			this.Label[4].text = "PUT SEDATIVE POISON IN BENTO";
			this.Label[5].text = "STEAL BENTO";
			this.Label[6].text = "BACK";
			if (!this.Prompt.Yandere.Inventory.EmeticPoison && !this.Prompt.Yandere.Inventory.RatPoison)
			{
				this.Label[1].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (this.Prompt.Yandere.Inventory.LethalPoisons == 0)
			{
				this.Label[2].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!this.Prompt.Yandere.Inventory.HeadachePoison)
			{
				this.Label[3].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!this.Prompt.Yandere.Inventory.Sedative && !this.Prompt.Yandere.Inventory.Tranquilizer)
			{
				this.Label[4].color = new Color(1f, 1f, 1f, 0.5f);
			}
			this.Limit = 6;
			return;
		}
		if (this.Menu == 4)
		{
			this.Label[1].text = "PUT ALCOHOL INTO BAG";
			this.Label[2].text = "PUT CONDOMS INTO BAG";
			this.Label[3].text = "PUT CIGARETTES INTO BAG";
			this.Label[4].text = "PUT STOLEN RING INTO BAG";
			this.Label[5].text = "PUT ANSWER SHEET INTO BAG";
			this.Label[6].text = "PUT NARCOTICS INTO BAG";
			this.Label[7].text = "BACK";
			if (!this.Prompt.Yandere.Inventory.Sake)
			{
				this.Label[1].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!this.Prompt.Yandere.Inventory.Condoms)
			{
				this.Label[2].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!this.Prompt.Yandere.Inventory.Cigs)
			{
				this.Label[3].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!this.Prompt.Yandere.Inventory.Ring)
			{
				this.Label[4].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!this.Prompt.Yandere.Inventory.AnswerSheet)
			{
				this.Label[5].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!this.Prompt.Yandere.Inventory.Narcotics)
			{
				this.Label[6].color = new Color(1f, 1f, 1f, 0.5f);
			}
			this.Limit = 7;
			return;
		}
		if (this.Menu == 5)
		{
			this.Label[8].text = string.Concat(new string[]
			{
				"You find a magazine in your rival's bookbag. It's a magazine about cute boys. Your rival has drawn circles around the boys she likes the most. It's apparent that...\n\n",
				this.DesiredHairstyleText,
				"\n\n",
				this.DesiredAccessoryText,
				"\n\n",
				this.DesiredEyewearText,
				"\n\n",
				this.DesiredSkinText,
				"\n\n",
				this.DesiredHairColorText,
				"\n\n",
				this.DesiredJewelryText,
				"\n\n",
				this.DesiredTraitText
			});
			return;
		}
		if (this.Menu == 6)
		{
			this.Label[8].text = string.Concat(new string[]
			{
				"You look through your rival's diary. \n\nShe likes ",
				this.RivalLikes[1],
				", ",
				this.RivalLikes[2],
				", ",
				this.RivalLikes[3],
				", ",
				this.RivalLikes[4],
				", and ",
				this.RivalLikes[5],
				".\n\nShe dislikes ",
				this.RivalDislikes[1],
				", ",
				this.RivalDislikes[2],
				", ",
				this.RivalDislikes[3],
				", ",
				this.RivalDislikes[4],
				", and ",
				this.RivalDislikes[5],
				".\n\nYou learn some embarassing secrets that will help you spread gossip about her.\n\nMost recent diary entry: \n\n''I can't sleep! I'm too worried about that EVIL PHOTOGRAPHER!''\n\nPerhaps you should befriend her and put a note in her locker to arrange a discussion about that topic."
			});
			this.Prompt.Yandere.Police.EndOfDay.LearnedAboutPhotographer = true;
			this.Prompt.Yandere.StudentManager.EmbarassingSecret = true;
		}
	}

	// Token: 0x04002105 RID: 8453
	public InputManagerScript InputManager;

	// Token: 0x04002106 RID: 8454
	public GenericRivalEventScript Event;

	// Token: 0x04002107 RID: 8455
	public PromptBarScript PromptBar;

	// Token: 0x04002108 RID: 8456
	public StudentScript Rival;

	// Token: 0x04002109 RID: 8457
	public PromptScript Prompt;

	// Token: 0x0400210A RID: 8458
	public JsonScript JSON;

	// Token: 0x0400210B RID: 8459
	public Transform Highlight;

	// Token: 0x0400210C RID: 8460
	public GameObject Window;

	// Token: 0x0400210D RID: 8461
	public UILabel[] Label;

	// Token: 0x0400210E RID: 8462
	public bool BorrowedBook;

	// Token: 0x0400210F RID: 8463
	public bool Alcohol;

	// Token: 0x04002110 RID: 8464
	public bool Condoms;

	// Token: 0x04002111 RID: 8465
	public bool Cigarettes;

	// Token: 0x04002112 RID: 8466
	public bool StolenRing;

	// Token: 0x04002113 RID: 8467
	public bool AnswerSheet;

	// Token: 0x04002114 RID: 8468
	public bool Narcotics;

	// Token: 0x04002115 RID: 8469
	public bool BentoStolen;

	// Token: 0x04002116 RID: 8470
	public bool NoBento;

	// Token: 0x04002117 RID: 8471
	public int Selected;

	// Token: 0x04002118 RID: 8472
	public int Limit;

	// Token: 0x04002119 RID: 8473
	public int Menu;

	// Token: 0x0400211A RID: 8474
	public int[] RivalOpinions;

	// Token: 0x0400211B RID: 8475
	public string[] Subjects;

	// Token: 0x0400211C RID: 8476
	public string[] RivalDislikes;

	// Token: 0x0400211D RID: 8477
	public string[] RivalLikes;

	// Token: 0x0400211E RID: 8478
	public int Dislikes = 1;

	// Token: 0x0400211F RID: 8479
	public int Likes = 1;

	// Token: 0x04002120 RID: 8480
	public int[] DesiredHairstyles;

	// Token: 0x04002121 RID: 8481
	public int[] DesiredAccessories;

	// Token: 0x04002122 RID: 8482
	public int[] DesiredEyewears;

	// Token: 0x04002123 RID: 8483
	public int[] DesiredSkins;

	// Token: 0x04002124 RID: 8484
	public string[] DesiredHairColors;

	// Token: 0x04002125 RID: 8485
	public bool[] DesiredJewelries;

	// Token: 0x04002126 RID: 8486
	public int[] DesiredTraits;

	// Token: 0x04002127 RID: 8487
	public int DesiredHairstyle;

	// Token: 0x04002128 RID: 8488
	public int DesiredAccessory;

	// Token: 0x04002129 RID: 8489
	public int DesiredEyewear;

	// Token: 0x0400212A RID: 8490
	public int DesiredSkin;

	// Token: 0x0400212B RID: 8491
	public string DesiredHairColor;

	// Token: 0x0400212C RID: 8492
	public bool DesiredJewelry;

	// Token: 0x0400212D RID: 8493
	public int DesiredTrait;

	// Token: 0x0400212E RID: 8494
	public string DesiredHairstyleText;

	// Token: 0x0400212F RID: 8495
	public string DesiredAccessoryText;

	// Token: 0x04002130 RID: 8496
	public string DesiredEyewearText;

	// Token: 0x04002131 RID: 8497
	public string DesiredSkinText;

	// Token: 0x04002132 RID: 8498
	public string DesiredHairColorText;

	// Token: 0x04002133 RID: 8499
	public string DesiredJewelryText;

	// Token: 0x04002134 RID: 8500
	public string DesiredTraitText;

	// Token: 0x04002135 RID: 8501
	public bool Initialized;
}
