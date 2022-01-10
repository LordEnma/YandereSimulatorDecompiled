using System;
using UnityEngine;

// Token: 0x020000C3 RID: 195
public class AdviceWindowScript : MonoBehaviour
{
	// Token: 0x0600099F RID: 2463 RVA: 0x0004CFB0 File Offset: 0x0004B1B0
	public void Start()
	{
		if (!this.Initialized)
		{
			this.StudentManager.RivalBookBag.Start();
			this.Affection = DatingGlobals.Affection;
			for (int i = 1; i < 26; i++)
			{
				this.TopicsDiscussed[i] = DatingGlobals.GetTopicDiscussed(i);
			}
			for (int j = 1; j < 11; j++)
			{
				this.ComplimentsGiven[j] = DatingGlobals.GetComplimentGiven(j);
			}
			for (int k = 1; k < 4; k++)
			{
				this.TraitsDemonstrated[k] = DatingGlobals.GetTraitDemonstrated(k);
			}
			for (int l = 1; l < 5; l++)
			{
				this.GiftsInPossession[l] = CollectibleGlobals.GetGiftPurchased(l + 5);
			}
			for (int m = 1; m < 5; m++)
			{
				this.GiftsGiven[m] = CollectibleGlobals.GetGiftGiven(m);
			}
			this.RivalOpinions = this.JSON.Topics[10 + DateGlobals.Week].Topics;
			int week = DateGlobals.Week;
			if (week == 1)
			{
				this.RivalComplimentsDesired = this.Week1Compliments;
			}
			else if (week == 2)
			{
				this.RivalComplimentsDesired = this.Week2Compliments;
			}
			else if (week == 3)
			{
				this.RivalComplimentsDesired = this.Week3Compliments;
			}
			else if (week == 4)
			{
				this.RivalComplimentsDesired = this.Week4Compliments;
			}
			else if (week == 5)
			{
				this.RivalComplimentsDesired = this.Week5Compliments;
			}
			else if (week == 6)
			{
				this.RivalComplimentsDesired = this.Week6Compliments;
			}
			else if (week == 7)
			{
				this.RivalComplimentsDesired = this.Week7Compliments;
			}
			else if (week == 8)
			{
				this.RivalComplimentsDesired = this.Week8Compliments;
			}
			else if (week == 9)
			{
				this.RivalComplimentsDesired = this.Week9Compliments;
			}
			else if (week == 10)
			{
				this.RivalComplimentsDesired = this.Week10Compliments;
			}
			this.RivalRespectedTrait = this.StudentManager.RivalBookBag.DesiredTrait;
			this.UpdateText();
			this.Initialized = true;
		}
	}

	// Token: 0x060009A0 RID: 2464 RVA: 0x0004D178 File Offset: 0x0004B378
	private void Update()
	{
		if (this.InputManager.TappedDown)
		{
			this.Selected++;
			this.UpdateHighlight();
			this.UpdateText();
			return;
		}
		if (this.InputManager.TappedUp)
		{
			this.Selected--;
			this.UpdateHighlight();
			this.UpdateText();
			return;
		}
		if (this.InputManager.TappedRight)
		{
			if (this.Selected == 1)
			{
				this.PositiveID++;
				if (this.PositiveID > this.Subjects.Length - 1)
				{
					this.PositiveID = 1;
				}
			}
			else if (this.Selected == 2)
			{
				this.NegativeID++;
				if (this.NegativeID > this.Subjects.Length - 1)
				{
					this.NegativeID = 1;
				}
			}
			else if (this.Selected == 3)
			{
				this.ComplimentID++;
				if (this.ComplimentID > this.Compliments.Length - 1)
				{
					this.ComplimentID = 1;
				}
			}
			else if (this.Selected == 4)
			{
				this.ShowOffID++;
				if (this.ShowOffID > this.ShowOffs.Length - 1)
				{
					this.ShowOffID = 1;
				}
			}
			else if (this.Selected == 5)
			{
				this.GiftID++;
				if (this.GiftID > this.Gifts.Length - 1)
				{
					this.GiftID = 1;
				}
			}
			this.UpdateText();
			return;
		}
		if (this.InputManager.TappedLeft)
		{
			if (this.Selected == 1)
			{
				this.PositiveID--;
				if (this.PositiveID < 1)
				{
					this.PositiveID = this.Subjects.Length - 1;
				}
			}
			else if (this.Selected == 2)
			{
				this.NegativeID--;
				if (this.NegativeID < 1)
				{
					this.NegativeID = this.Subjects.Length - 1;
				}
			}
			else if (this.Selected == 3)
			{
				this.ComplimentID--;
				if (this.ComplimentID < 1)
				{
					this.ComplimentID = this.Compliments.Length - 1;
				}
			}
			else if (this.Selected == 4)
			{
				this.ShowOffID--;
				if (this.ShowOffID < 1)
				{
					this.ShowOffID = this.ShowOffs.Length - 1;
				}
			}
			else if (this.Selected == 5)
			{
				this.GiftID--;
				if (this.GiftID < 1)
				{
					this.GiftID = this.Gifts.Length - 1;
				}
			}
			this.UpdateText();
			return;
		}
		if (Input.GetButtonDown("B"))
		{
			this.Selected = 1;
			this.UpdateHighlight();
			Time.timeScale = 1f;
			this.PromptBar.ClearButtons();
			this.PromptBar.Show = false;
			base.gameObject.SetActive(false);
			this.Yandere.Interaction = YandereInteractionType.Advice;
			this.Yandere.TalkTimer = 5f;
		}
	}

	// Token: 0x060009A1 RID: 2465 RVA: 0x0004D470 File Offset: 0x0004B670
	private void UpdateHighlight()
	{
		if (this.Selected > 5)
		{
			this.Selected = 1;
		}
		else if (this.Selected < 1)
		{
			this.Selected = 5;
		}
		this.Highlight.transform.localPosition = new Vector3(0f, (float)(570 - 150 * this.Selected), 0f);
	}

	// Token: 0x060009A2 RID: 2466 RVA: 0x0004D4D4 File Offset: 0x0004B6D4
	public void UpdateText()
	{
		this.PositiveLabel.text = this.Subjects[this.PositiveID];
		this.NegativeLabel.text = this.Subjects[this.NegativeID];
		this.ComplimentLabel.text = this.Compliments[this.ComplimentID];
		this.ShowOffLabel.text = this.ShowOffs[this.ShowOffID];
		this.GiftLabel.text = this.Gifts[this.GiftID];
		this.AdviceLabel.color = new Color(1f, 1f, 1f, 1f);
		if (this.Selected == 1)
		{
			if (DatingGlobals.GetTopicDiscussed(this.PositiveID))
			{
				this.AdviceLabel.text = "The suitor has already discussed this subject with your rival.";
				this.AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
			}
			else
			{
				this.AdviceLabel.text = "You can learn your rival's likes and dislikes by looking through her bookbag.";
			}
		}
		else if (this.Selected == 2)
		{
			if (DatingGlobals.GetTopicDiscussed(this.NegativeID))
			{
				this.AdviceLabel.text = "The suitor has already discussed this subject with your rival.";
				this.AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
			}
			else
			{
				this.AdviceLabel.text = "You can learn your rival's likes and dislikes by looking through her bookbag.";
			}
		}
		else if (this.Selected == 3)
		{
			if (DatingGlobals.GetComplimentGiven(this.ComplimentID))
			{
				this.AdviceLabel.text = "The suitor has already said this to your rival.";
				this.AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
			}
			else
			{
				this.AdviceLabel.text = "Consider your rival's personality when deciding what your suitor should say to her.";
			}
		}
		else if (this.Selected == 4)
		{
			if (this.ShowOffID == 1)
			{
				string str;
				if (this.StudentManager.DatingMinigame.Trait[this.ShowOffID] < this.StudentManager.DatingMinigame.TraitDemonstrated[this.ShowOffID] + 1)
				{
					str = "This will not impress your rival. To increase the suitor's courage, lead him to the ''haunted'' painting in the third-floor Art Room.";
					this.AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
				}
				else
				{
					str = "This is enough to impress your rival.";
				}
				this.AdviceLabel.text = "Your suitor's courage is ''Level " + this.StudentManager.DatingMinigame.Trait[this.ShowOffID].ToString() + "''. " + str;
			}
			else if (this.ShowOffID == 2)
			{
				string str;
				if (this.StudentManager.DatingMinigame.Trait[this.ShowOffID] < this.StudentManager.DatingMinigame.TraitDemonstrated[this.ShowOffID] + 1)
				{
					str = "This will not impress your rival. To increase the suitor's intelligence, lead him to the library and study with him.";
					this.AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
				}
				else
				{
					str = "This is enough to impress your rival.";
				}
				this.AdviceLabel.text = "Your suitor's intelligence is ''Level " + this.StudentManager.DatingMinigame.Trait[this.ShowOffID].ToString() + "''. " + str;
			}
			else if (this.ShowOffID == 3)
			{
				string str;
				if (this.StudentManager.DatingMinigame.Trait[this.ShowOffID] < this.StudentManager.DatingMinigame.TraitDemonstrated[this.ShowOffID] + 1)
				{
					str = "This will not impress your rival. To increase the suitor's strength, lead him to the running track and train him.";
					this.AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
				}
				else
				{
					str = "This is enough to impress your rival.";
				}
				this.AdviceLabel.text = "Your suitor's strength is ''Level " + this.StudentManager.DatingMinigame.Trait[this.ShowOffID].ToString() + "''. " + str;
			}
		}
		else if (this.Selected == 5)
		{
			if (!CollectibleGlobals.GetGiftPurchased(this.GiftID + 5))
			{
				this.AdviceLabel.text = "You don't own this gift. You can buy it at the Gift Shop in town. You can visit town before school or after school.";
				this.AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
			}
			else if (CollectibleGlobals.GetGiftGiven(this.GiftID))
			{
				this.AdviceLabel.text = "Your suitor already gave your rival this gift on a previous day.";
				this.AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
			}
			else
			{
				this.AdviceLabel.text = "Your rival would appreciate this gift.";
			}
		}
		this.StatsLabel.text = string.Concat(new string[]
		{
			"SUITOR STATS\n\nCOURAGE: ",
			this.StudentManager.DatingMinigame.Trait[1].ToString(),
			"\n\nINTELLIGENCE: ",
			this.StudentManager.DatingMinigame.Trait[2].ToString(),
			"\n\nSTRENGTH: ",
			this.StudentManager.DatingMinigame.Trait[3].ToString()
		});
	}

	// Token: 0x060009A3 RID: 2467 RVA: 0x0004D9F8 File Offset: 0x0004BBF8
	private void CalculateMultiplier()
	{
		this.HUDElement[1].SetActive(false);
		this.HUDElement[2].SetActive(false);
		this.HUDElement[3].SetActive(false);
		this.Suitor = this.StudentManager.Students[this.StudentManager.SuitorID];
		GenericRivalBagScript rivalBookBag = this.StudentManager.RivalBookBag;
		if (this.Suitor.Cosmetic.MaleHair[rivalBookBag.DesiredHairstyle].activeInHierarchy)
		{
			this.AttractionText[1] = "Your rival likes her suitor's hairstyle!";
			this.Multiplier++;
		}
		else
		{
			this.AttractionText[1] = "Your rival might like her suitor better with a different hairstyle.";
		}
		if (this.Suitor.Cosmetic.MaleAccessories[rivalBookBag.DesiredAccessory].activeInHierarchy)
		{
			this.AttractionText[2] = "Your rival likes her suitor's piercings!";
			this.Multiplier++;
		}
		else
		{
			this.AttractionText[2] = "The suitor lacks accessories that your rival finds appealing.";
		}
		if (this.Suitor.Cosmetic.Eyewear[rivalBookBag.DesiredEyewear].activeInHierarchy)
		{
			this.AttractionText[3] = "Your rival likes her suitor's glasses!";
			this.Multiplier++;
		}
		else
		{
			this.AttractionText[3] = "The suitor lacks facialwear that your rival finds appealing.";
		}
		if (rivalBookBag.DesiredSkin > 0)
		{
			if (this.Suitor.Cosmetic.SkinColor == rivalBookBag.DesiredSkin)
			{
				this.AttractionText[4] = "Your rival likes her suitor's tan!";
				this.Multiplier++;
			}
			else
			{
				this.AttractionText[4] = "The suitor lacks a physical trait that your rival is attracted to.";
			}
		}
		else
		{
			this.AttractionText[4] = "Your rival doesn't seem to have a preference regarding skin color.";
		}
		if (rivalBookBag.DesiredHairColor != "")
		{
			if (this.Suitor.Cosmetic.HairColor != "SolidBlack")
			{
				this.AttractionText[5] = "Your rival likes her suitor's hair color!";
				this.Multiplier++;
			}
			else
			{
				this.AttractionText[5] = "Your rival doesn't like her suitor's hair color.";
			}
		}
		else
		{
			this.AttractionText[5] = "Your rival doesn't seem to have a preference regarding hair color.";
		}
		if (rivalBookBag.DesiredJewelry)
		{
			if (this.Suitor.Cosmetic.GaloAccessories[0].activeInHierarchy == rivalBookBag.DesiredJewelry)
			{
				this.AttractionText[6] = "Your rival likes her suitor's jewelry!";
				this.Multiplier++;
			}
			else
			{
				this.AttractionText[6] = "Your rival is disappointed that her suitor doesn't wear jewelry.";
			}
		}
		else
		{
			this.AttractionText[6] = "Your rival doesn't seem to care whether or not someone is wearing jewelry.";
		}
		if (PlayerGlobals.PantiesEquipped == 2)
		{
			this.AttractionText[7] = "The panties you put on this morning put you into the right mindset to give your suitor the best advice!";
			this.Multiplier++;
		}
		else
		{
			this.AttractionText[7] = "Consider visiting the lingerie store in town to purchase panties that boost your matchmaking skill.";
		}
		if (this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 0)
		{
			this.AttractionText[8] = "The romance manga you've been reading contained helpful advice for your suitor!";
			this.Multiplier += this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus;
		}
		else
		{
			this.AttractionText[8] = "You can provide the suitor with better advice if you visit the manga store in town, purchase romance manga, and read it at night.";
		}
		if (this.Yandere.Class.PsychologyGrade + this.Yandere.Class.PsychologyBonus > 0)
		{
			this.AttractionText[9] = "Your knowledge of psychology improved the effectiveness of your advice!";
			this.Multiplier += this.Yandere.Class.PsychologyGrade + this.Yandere.Class.PsychologyBonus;
		}
		else
		{
			this.AttractionText[9] = "You could provide the suitor with better advice if you studied psychology at classtime.";
		}
		this.AttractionLabel.text = string.Concat(new string[]
		{
			this.AttractionText[1],
			"\n\n",
			this.AttractionText[2],
			"\n\n",
			this.AttractionText[3],
			"\n\n",
			this.AttractionText[4],
			"\n\n",
			this.AttractionText[5],
			"\n\n",
			this.AttractionText[6],
			"\n\n",
			this.AttractionText[7],
			"\n\n",
			this.AttractionText[8],
			"\n\n",
			this.AttractionText[9]
		});
	}

	// Token: 0x060009A4 RID: 2468 RVA: 0x0004DE24 File Offset: 0x0004C024
	public void CalculateLove()
	{
		this.Start();
		this.CalculateMultiplier();
		if (!DatingGlobals.GetTopicDiscussed(this.PositiveID))
		{
			if (this.RivalOpinions[this.PositiveID] == 2)
			{
				this.Affection += (float)this.Multiplier;
				this.Outcomes[1] = "Your rival enjoyed what her suitor said about " + this.Subjects[this.PositiveID] + ".";
			}
			else
			{
				this.Outcomes[1] = "Your rival disliked what her suitor said about " + this.Subjects[this.PositiveID] + ".";
			}
		}
		else
		{
			this.Outcomes[1] = "Your rival was bored when her suitor tried to discuss " + this.Subjects[this.PositiveID] + ", because they already discussed it on a previous day.";
		}
		this.TopicsDiscussed[this.PositiveID] = true;
		if (!DatingGlobals.GetTopicDiscussed(this.NegativeID))
		{
			if (this.RivalOpinions[this.NegativeID] == 1)
			{
				this.Affection += (float)this.Multiplier;
				this.Outcomes[2] = "Your rival enjoyed what her suitor said about " + this.Subjects[this.NegativeID] + ".";
			}
			else
			{
				this.Outcomes[2] = "Your rival disliked what her suitor said about " + this.Subjects[this.NegativeID] + ".";
			}
		}
		else
		{
			this.Outcomes[2] = "Your rival was bored when her suitor tried to discuss " + this.Subjects[this.NegativeID] + ", because they already discussed it on a previous day.";
		}
		this.TopicsDiscussed[this.NegativeID] = true;
		if (!DatingGlobals.GetComplimentGiven(this.ComplimentID))
		{
			if (this.RivalComplimentsDesired[this.ComplimentID])
			{
				this.Affection += (float)this.Multiplier;
				this.Outcomes[3] = "Your rival enjoyed hearing " + this.Compliments[this.ComplimentID];
			}
			else
			{
				this.Outcomes[3] = "Your rival did not appreciate hearing " + this.Compliments[this.ComplimentID];
			}
		}
		else
		{
			this.Outcomes[3] = "Your rival was bored when her suitor said " + this.Compliments[this.ComplimentID] + ", because the suitor already said that on a previous day.";
		}
		this.ComplimentsGiven[this.ComplimentID] = true;
		if (CollectibleGlobals.GetGiftPurchased(this.GiftID + 5))
		{
			if (!CollectibleGlobals.GetGiftGiven(this.GiftID))
			{
				this.Affection += (float)this.Multiplier;
				this.Outcomes[4] = "Your rival appreciated recieving a " + this.Gifts[this.GiftID] + ".";
			}
			else
			{
				this.Outcomes[4] = "Your rival did not appreciate appreciated recieving a " + this.Gifts[this.GiftID] + ", because the suitor already gave her one on a previous day.";
			}
			this.GiftsInPossession[this.GiftID] = false;
			this.GiftsGiven[this.GiftID] = true;
		}
		else
		{
			this.Outcomes[4] = "You did not provide the suitor with a gift to give to your rival.";
		}
		if (this.RivalRespectedTrait == this.ShowOffID)
		{
			if (this.StudentManager.DatingMinigame.Trait[this.ShowOffID] > this.StudentManager.DatingMinigame.TraitDemonstrated[this.ShowOffID])
			{
				this.Affection += (float)this.Multiplier;
				this.Outcomes[5] = "Your rival was impressed with the suitor's " + this.ShowOffs[this.ShowOffID] + ".";
				this.TraitsDemonstrated[this.ShowOffID]++;
			}
			else
			{
				this.Outcomes[5] = "The suitor didn't have enough " + this.ShowOffs[this.ShowOffID] + " to impress your rival.";
			}
		}
		else
		{
			this.Outcomes[5] = "Your rival didn't really care when her suitor tried to show off his " + this.ShowOffs[this.ShowOffID] + ".";
		}
		this.Outcomes[6] = "Your rival's affection for the suitor increased by " + (this.Affection - DatingGlobals.Affection).ToString() + " points.";
		if (this.Affection < (float)(DateGlobals.Week * 10))
		{
			this.Outcomes[7] = ((float)(DateGlobals.Week * 10) - this.Affection).ToString() + " more points are required in order to make your rival fall in love with her suitor.";
		}
		else
		{
			this.Outcomes[7] = "Your rival is now in love with her suitor! She will confess to him at 5:00 PM on Friday!";
			if (DateGlobals.Weekday == DayOfWeek.Friday)
			{
				this.StudentManager.LoveManager.ConfessToSuitor = true;
			}
		}
		this.ResultLabel.text = string.Concat(new string[]
		{
			this.Outcomes[1],
			"\n\n",
			this.Outcomes[2],
			"\n\n",
			this.Outcomes[3],
			"\n\n",
			this.Outcomes[4],
			"\n\n",
			this.Outcomes[5],
			"\n\n",
			this.Outcomes[6],
			"\n\n",
			this.Outcomes[7]
		});
		this.ResultsScreen.gameObject.SetActive(true);
		Time.timeScale = 0.0001f;
		this.DataNeedsSaving = true;
		Debug.Log("Affection is now: " + this.Affection.ToString());
	}

	// Token: 0x060009A5 RID: 2469 RVA: 0x0004E324 File Offset: 0x0004C524
	public void SaveTopicsAndCompliments()
	{
		for (int i = 1; i < 26; i++)
		{
			DatingGlobals.SetTopicDiscussed(i, this.TopicsDiscussed[i]);
		}
		for (int j = 1; j < 11; j++)
		{
			DatingGlobals.SetComplimentGiven(j, this.ComplimentsGiven[j]);
		}
		for (int k = 1; k < 4; k++)
		{
			DatingGlobals.SetTraitDemonstrated(k, this.TraitsDemonstrated[k]);
		}
		for (int l = 1; l < 5; l++)
		{
			CollectibleGlobals.SetGiftPurchased(l + 5, this.GiftsInPossession[l]);
			CollectibleGlobals.SetGiftGiven(l, this.GiftsGiven[l]);
		}
		DatingGlobals.Affection = this.Affection;
		Debug.Log("Saving suitor data stored in AdviceWindowScript.");
	}

	// Token: 0x04000858 RID: 2136
	public StudentManagerScript StudentManager;

	// Token: 0x04000859 RID: 2137
	public InputManagerScript InputManager;

	// Token: 0x0400085A RID: 2138
	public PromptBarScript PromptBar;

	// Token: 0x0400085B RID: 2139
	public YandereScript Yandere;

	// Token: 0x0400085C RID: 2140
	public Transform Highlight;

	// Token: 0x0400085D RID: 2141
	public JsonScript JSON;

	// Token: 0x0400085E RID: 2142
	public bool[] Week1Compliments;

	// Token: 0x0400085F RID: 2143
	public bool[] Week2Compliments;

	// Token: 0x04000860 RID: 2144
	public bool[] Week3Compliments;

	// Token: 0x04000861 RID: 2145
	public bool[] Week4Compliments;

	// Token: 0x04000862 RID: 2146
	public bool[] Week5Compliments;

	// Token: 0x04000863 RID: 2147
	public bool[] Week6Compliments;

	// Token: 0x04000864 RID: 2148
	public bool[] Week7Compliments;

	// Token: 0x04000865 RID: 2149
	public bool[] Week8Compliments;

	// Token: 0x04000866 RID: 2150
	public bool[] Week9Compliments;

	// Token: 0x04000867 RID: 2151
	public bool[] Week10Compliments;

	// Token: 0x04000868 RID: 2152
	public bool[] RivalComplimentsDesired;

	// Token: 0x04000869 RID: 2153
	public bool[] GiftsInPossession;

	// Token: 0x0400086A RID: 2154
	public bool[] ComplimentsGiven;

	// Token: 0x0400086B RID: 2155
	public bool[] TopicsDiscussed;

	// Token: 0x0400086C RID: 2156
	public bool[] GiftsGiven;

	// Token: 0x0400086D RID: 2157
	public int[] TraitsDemonstrated;

	// Token: 0x0400086E RID: 2158
	public int[] RivalOpinions;

	// Token: 0x0400086F RID: 2159
	public UILabel PositiveLabel;

	// Token: 0x04000870 RID: 2160
	public UILabel NegativeLabel;

	// Token: 0x04000871 RID: 2161
	public UILabel ComplimentLabel;

	// Token: 0x04000872 RID: 2162
	public UILabel ShowOffLabel;

	// Token: 0x04000873 RID: 2163
	public UILabel GiftLabel;

	// Token: 0x04000874 RID: 2164
	public UILabel AdviceLabel;

	// Token: 0x04000875 RID: 2165
	public UILabel StatsLabel;

	// Token: 0x04000876 RID: 2166
	public string[] Subjects;

	// Token: 0x04000877 RID: 2167
	public string[] Compliments;

	// Token: 0x04000878 RID: 2168
	public string[] ShowOffs;

	// Token: 0x04000879 RID: 2169
	public string[] Gifts;

	// Token: 0x0400087A RID: 2170
	public int RivalRespectedTrait = 2;

	// Token: 0x0400087B RID: 2171
	public int Selected = 1;

	// Token: 0x0400087C RID: 2172
	public int PositiveID = 1;

	// Token: 0x0400087D RID: 2173
	public int NegativeID = 1;

	// Token: 0x0400087E RID: 2174
	public int ComplimentID = 1;

	// Token: 0x0400087F RID: 2175
	public int ShowOffID = 1;

	// Token: 0x04000880 RID: 2176
	public int GiftID = 1;

	// Token: 0x04000881 RID: 2177
	public bool DataNeedsSaving;

	// Token: 0x04000882 RID: 2178
	public bool Initialized;

	// Token: 0x04000883 RID: 2179
	public StudentScript Suitor;

	// Token: 0x04000884 RID: 2180
	public int Multiplier = 1;

	// Token: 0x04000885 RID: 2181
	public UILabel AttractionLabel;

	// Token: 0x04000886 RID: 2182
	public string[] AttractionText;

	// Token: 0x04000887 RID: 2183
	public GameObject[] HUDElement;

	// Token: 0x04000888 RID: 2184
	public GameObject ResultsScreen;

	// Token: 0x04000889 RID: 2185
	public UILabel ResultLabel;

	// Token: 0x0400088A RID: 2186
	public string[] Outcomes;

	// Token: 0x0400088B RID: 2187
	public float Affection;
}
