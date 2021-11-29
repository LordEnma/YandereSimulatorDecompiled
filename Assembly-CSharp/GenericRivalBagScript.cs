using System;
using UnityEngine;

// Token: 0x020002DC RID: 732
public class GenericRivalBagScript : MonoBehaviour
{
	// Token: 0x060014D0 RID: 5328 RVA: 0x000CEE6C File Offset: 0x000CD06C
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

	// Token: 0x060014D1 RID: 5329 RVA: 0x000CF0F0 File Offset: 0x000CD2F0
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

	// Token: 0x060014D2 RID: 5330 RVA: 0x000CF7DC File Offset: 0x000CD9DC
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

	// Token: 0x060014D3 RID: 5331 RVA: 0x000CF84C File Offset: 0x000CDA4C
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

	// Token: 0x060014D4 RID: 5332 RVA: 0x000CF8B0 File Offset: 0x000CDAB0
	private void UpdateMenuLabels()
	{
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
			if (!this.Prompt.Yandere.Inventory.LethalPoison)
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

	// Token: 0x040020D6 RID: 8406
	public InputManagerScript InputManager;

	// Token: 0x040020D7 RID: 8407
	public GenericRivalEventScript Event;

	// Token: 0x040020D8 RID: 8408
	public PromptBarScript PromptBar;

	// Token: 0x040020D9 RID: 8409
	public StudentScript Rival;

	// Token: 0x040020DA RID: 8410
	public PromptScript Prompt;

	// Token: 0x040020DB RID: 8411
	public JsonScript JSON;

	// Token: 0x040020DC RID: 8412
	public Transform Highlight;

	// Token: 0x040020DD RID: 8413
	public GameObject Window;

	// Token: 0x040020DE RID: 8414
	public UILabel[] Label;

	// Token: 0x040020DF RID: 8415
	public bool BorrowedBook;

	// Token: 0x040020E0 RID: 8416
	public bool Alcohol;

	// Token: 0x040020E1 RID: 8417
	public bool Condoms;

	// Token: 0x040020E2 RID: 8418
	public bool Cigarettes;

	// Token: 0x040020E3 RID: 8419
	public bool StolenRing;

	// Token: 0x040020E4 RID: 8420
	public bool AnswerSheet;

	// Token: 0x040020E5 RID: 8421
	public bool Narcotics;

	// Token: 0x040020E6 RID: 8422
	public bool BentoStolen;

	// Token: 0x040020E7 RID: 8423
	public bool NoBento;

	// Token: 0x040020E8 RID: 8424
	public int Selected;

	// Token: 0x040020E9 RID: 8425
	public int Limit;

	// Token: 0x040020EA RID: 8426
	public int Menu;

	// Token: 0x040020EB RID: 8427
	public int[] RivalOpinions;

	// Token: 0x040020EC RID: 8428
	public string[] Subjects;

	// Token: 0x040020ED RID: 8429
	public string[] RivalDislikes;

	// Token: 0x040020EE RID: 8430
	public string[] RivalLikes;

	// Token: 0x040020EF RID: 8431
	public int Dislikes = 1;

	// Token: 0x040020F0 RID: 8432
	public int Likes = 1;

	// Token: 0x040020F1 RID: 8433
	public int[] DesiredHairstyles;

	// Token: 0x040020F2 RID: 8434
	public int[] DesiredAccessories;

	// Token: 0x040020F3 RID: 8435
	public int[] DesiredEyewears;

	// Token: 0x040020F4 RID: 8436
	public int[] DesiredSkins;

	// Token: 0x040020F5 RID: 8437
	public string[] DesiredHairColors;

	// Token: 0x040020F6 RID: 8438
	public bool[] DesiredJewelries;

	// Token: 0x040020F7 RID: 8439
	public int[] DesiredTraits;

	// Token: 0x040020F8 RID: 8440
	public int DesiredHairstyle;

	// Token: 0x040020F9 RID: 8441
	public int DesiredAccessory;

	// Token: 0x040020FA RID: 8442
	public int DesiredEyewear;

	// Token: 0x040020FB RID: 8443
	public int DesiredSkin;

	// Token: 0x040020FC RID: 8444
	public string DesiredHairColor;

	// Token: 0x040020FD RID: 8445
	public bool DesiredJewelry;

	// Token: 0x040020FE RID: 8446
	public int DesiredTrait;

	// Token: 0x040020FF RID: 8447
	public string DesiredHairstyleText;

	// Token: 0x04002100 RID: 8448
	public string DesiredAccessoryText;

	// Token: 0x04002101 RID: 8449
	public string DesiredEyewearText;

	// Token: 0x04002102 RID: 8450
	public string DesiredSkinText;

	// Token: 0x04002103 RID: 8451
	public string DesiredHairColorText;

	// Token: 0x04002104 RID: 8452
	public string DesiredJewelryText;

	// Token: 0x04002105 RID: 8453
	public string DesiredTraitText;

	// Token: 0x04002106 RID: 8454
	public bool Initialized;
}
