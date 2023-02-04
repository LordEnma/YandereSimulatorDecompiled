using System;
using UnityEngine;

public class AdviceWindowScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public Transform Highlight;

	public JsonScript JSON;

	public bool[] Week1Compliments;

	public bool[] Week2Compliments;

	public bool[] Week3Compliments;

	public bool[] Week4Compliments;

	public bool[] Week5Compliments;

	public bool[] Week6Compliments;

	public bool[] Week7Compliments;

	public bool[] Week8Compliments;

	public bool[] Week9Compliments;

	public bool[] Week10Compliments;

	public bool[] RivalComplimentsDesired;

	public bool[] GiftsInPossession;

	public bool[] ComplimentsGiven;

	public bool[] TopicsDiscussed;

	public bool[] GiftsGiven;

	public int[] TraitsDemonstrated;

	public int[] RivalOpinions;

	public UILabel PositiveLabel;

	public UILabel NegativeLabel;

	public UILabel ComplimentLabel;

	public UILabel ShowOffLabel;

	public UILabel GiftLabel;

	public UILabel AdviceLabel;

	public UILabel StatsLabel;

	public string[] Subjects;

	public string[] Compliments;

	public string[] ShowOffs;

	public string[] Gifts;

	public int RivalRespectedTrait = 2;

	public int Selected = 1;

	public int PositiveID = 1;

	public int NegativeID = 1;

	public int ComplimentID = 1;

	public int ShowOffID = 1;

	public int GiftID = 1;

	public bool GiftDataNeedsSaving;

	public bool DataNeedsSaving;

	public bool Initialized;

	public StudentScript Suitor;

	public int Multiplier = 1;

	public UILabel AttractionLabel;

	public string[] AttractionText;

	public GameObject[] HUDElement;

	public GameObject ResultsScreen;

	public UILabel ResultLabel;

	public string[] Outcomes;

	public float Affection;

	public void Start()
	{
		if (!Initialized)
		{
			StudentManager.RivalBookBag.Start();
			Affection = DatingGlobals.Affection;
			for (int i = 1; i < 26; i++)
			{
				TopicsDiscussed[i] = DatingGlobals.GetTopicDiscussed(i);
			}
			for (int j = 1; j < 11; j++)
			{
				ComplimentsGiven[j] = DatingGlobals.GetComplimentGiven(j);
			}
			for (int k = 1; k < 4; k++)
			{
				TraitsDemonstrated[k] = DatingGlobals.GetTraitDemonstrated(k);
			}
			for (int l = 1; l < 5; l++)
			{
				GiftsInPossession[l] = CollectibleGlobals.GetGiftPurchased(l + 5);
			}
			for (int m = 1; m < 5; m++)
			{
				GiftsGiven[m] = CollectibleGlobals.GetGiftGiven(m);
			}
			RivalOpinions = JSON.Topics[10 + DateGlobals.Week].Topics;
			switch (DateGlobals.Week)
			{
			case 1:
				RivalComplimentsDesired = Week1Compliments;
				break;
			case 2:
				RivalComplimentsDesired = Week2Compliments;
				break;
			case 3:
				RivalComplimentsDesired = Week3Compliments;
				break;
			case 4:
				RivalComplimentsDesired = Week4Compliments;
				break;
			case 5:
				RivalComplimentsDesired = Week5Compliments;
				break;
			case 6:
				RivalComplimentsDesired = Week6Compliments;
				break;
			case 7:
				RivalComplimentsDesired = Week7Compliments;
				break;
			case 8:
				RivalComplimentsDesired = Week8Compliments;
				break;
			case 9:
				RivalComplimentsDesired = Week9Compliments;
				break;
			case 10:
				RivalComplimentsDesired = Week10Compliments;
				break;
			}
			RivalRespectedTrait = StudentManager.RivalBookBag.DesiredTrait;
			UpdateText();
			Initialized = true;
		}
	}

	private void Update()
	{
		if (InputManager.TappedDown)
		{
			Selected++;
			UpdateHighlight();
			UpdateText();
		}
		else if (InputManager.TappedUp)
		{
			Selected--;
			UpdateHighlight();
			UpdateText();
		}
		else if (InputManager.TappedRight)
		{
			if (Selected == 1)
			{
				PositiveID++;
				if (PositiveID > Subjects.Length - 1)
				{
					PositiveID = 1;
				}
			}
			else if (Selected == 2)
			{
				NegativeID++;
				if (NegativeID > Subjects.Length - 1)
				{
					NegativeID = 1;
				}
			}
			else if (Selected == 3)
			{
				ComplimentID++;
				if (ComplimentID > Compliments.Length - 1)
				{
					ComplimentID = 1;
				}
			}
			else if (Selected == 4)
			{
				ShowOffID++;
				if (ShowOffID > ShowOffs.Length - 1)
				{
					ShowOffID = 1;
				}
			}
			else if (Selected == 5)
			{
				GiftID++;
				if (GiftID > Gifts.Length - 1)
				{
					GiftID = 1;
				}
			}
			UpdateText();
		}
		else if (InputManager.TappedLeft)
		{
			if (Selected == 1)
			{
				PositiveID--;
				if (PositiveID < 1)
				{
					PositiveID = Subjects.Length - 1;
				}
			}
			else if (Selected == 2)
			{
				NegativeID--;
				if (NegativeID < 1)
				{
					NegativeID = Subjects.Length - 1;
				}
			}
			else if (Selected == 3)
			{
				ComplimentID--;
				if (ComplimentID < 1)
				{
					ComplimentID = Compliments.Length - 1;
				}
			}
			else if (Selected == 4)
			{
				ShowOffID--;
				if (ShowOffID < 1)
				{
					ShowOffID = ShowOffs.Length - 1;
				}
			}
			else if (Selected == 5)
			{
				GiftID--;
				if (GiftID < 1)
				{
					GiftID = Gifts.Length - 1;
				}
			}
			UpdateText();
		}
		else if (Input.GetButtonDown("B"))
		{
			Selected = 1;
			UpdateHighlight();
			Time.timeScale = 1f;
			PromptBar.ClearButtons();
			PromptBar.Show = false;
			base.gameObject.SetActive(value: false);
			Yandere.Interaction = YandereInteractionType.Advice;
			Yandere.TalkTimer = 5f;
		}
	}

	private void UpdateHighlight()
	{
		if (Selected > 5)
		{
			Selected = 1;
		}
		else if (Selected < 1)
		{
			Selected = 5;
		}
		Highlight.transform.localPosition = new Vector3(0f, 570 - 150 * Selected, 0f);
	}

	public void UpdateText()
	{
		PositiveLabel.text = Subjects[PositiveID];
		NegativeLabel.text = Subjects[NegativeID];
		ComplimentLabel.text = Compliments[ComplimentID];
		ShowOffLabel.text = ShowOffs[ShowOffID];
		GiftLabel.text = Gifts[GiftID];
		AdviceLabel.color = new Color(1f, 1f, 1f, 1f);
		if (Selected == 1)
		{
			if (DatingGlobals.GetTopicDiscussed(PositiveID))
			{
				AdviceLabel.text = "The suitor has already discussed this subject with your rival.";
				AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
			}
			else
			{
				AdviceLabel.text = "You can learn your rival's likes and dislikes by looking through her bookbag.";
			}
		}
		else if (Selected == 2)
		{
			if (DatingGlobals.GetTopicDiscussed(NegativeID))
			{
				AdviceLabel.text = "The suitor has already discussed this subject with your rival.";
				AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
			}
			else
			{
				AdviceLabel.text = "You can learn your rival's likes and dislikes by looking through her bookbag.";
			}
		}
		else if (Selected == 3)
		{
			if (DatingGlobals.GetComplimentGiven(ComplimentID))
			{
				AdviceLabel.text = "The suitor has already said this to your rival.";
				AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
			}
			else
			{
				AdviceLabel.text = "Consider your rival's personality when deciding what your suitor should say to her.";
			}
		}
		else if (Selected == 4)
		{
			string text = "";
			if (ShowOffID == 1)
			{
				if (StudentManager.DatingMinigame.Trait[ShowOffID] < StudentManager.DatingMinigame.TraitDemonstrated[ShowOffID] + 1)
				{
					text = "This will not impress your rival. To increase the suitor's courage, lead him to the ''haunted'' painting in the third-floor Art Room.";
					AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
				}
				else
				{
					text = "This is enough to impress your rival.";
				}
				AdviceLabel.text = "Your suitor's courage is ''Level " + StudentManager.DatingMinigame.Trait[ShowOffID] + "''. " + text;
			}
			else if (ShowOffID == 2)
			{
				if (StudentManager.DatingMinigame.Trait[ShowOffID] < StudentManager.DatingMinigame.TraitDemonstrated[ShowOffID] + 1)
				{
					text = "This will not impress your rival. To increase the suitor's intelligence, lead him to the library and study with him.";
					AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
				}
				else
				{
					text = "This is enough to impress your rival.";
				}
				AdviceLabel.text = "Your suitor's intelligence is ''Level " + StudentManager.DatingMinigame.Trait[ShowOffID] + "''. " + text;
			}
			else if (ShowOffID == 3)
			{
				if (StudentManager.DatingMinigame.Trait[ShowOffID] < StudentManager.DatingMinigame.TraitDemonstrated[ShowOffID] + 1)
				{
					text = "This will not impress your rival. To increase the suitor's strength, lead him to the running track and train him.";
					AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
				}
				else
				{
					text = "This is enough to impress your rival.";
				}
				AdviceLabel.text = "Your suitor's strength is ''Level " + StudentManager.DatingMinigame.Trait[ShowOffID] + "''. " + text;
			}
		}
		else if (Selected == 5)
		{
			if (!CollectibleGlobals.GetGiftPurchased(GiftID + 5))
			{
				AdviceLabel.text = "You don't own this gift. You can buy it at the Gift Shop in town. You can visit town before school or after school.";
				AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
			}
			else if (CollectibleGlobals.GetGiftGiven(GiftID))
			{
				AdviceLabel.text = "Your suitor already gave your rival this gift on a previous day.";
				AdviceLabel.color = new Color(1f, 0f, 0f, 1f);
			}
			else
			{
				AdviceLabel.text = "Your rival would appreciate this gift.";
			}
		}
		StatsLabel.text = "SUITOR STATS\n\nCOURAGE: " + StudentManager.DatingMinigame.Trait[1] + "\n\nINTELLIGENCE: " + StudentManager.DatingMinigame.Trait[2] + "\n\nSTRENGTH: " + StudentManager.DatingMinigame.Trait[3];
	}

	private void CalculateMultiplier()
	{
		HUDElement[1].SetActive(value: false);
		HUDElement[2].SetActive(value: false);
		HUDElement[3].SetActive(value: false);
		Suitor = StudentManager.Students[StudentManager.SuitorID];
		GenericRivalBagScript rivalBookBag = StudentManager.RivalBookBag;
		if (Suitor.Cosmetic.MaleHair[rivalBookBag.DesiredHairstyle].activeInHierarchy)
		{
			AttractionText[1] = "Your rival likes her suitor's hairstyle!";
			Multiplier++;
		}
		else
		{
			AttractionText[1] = "Your rival might like her suitor better with a different hairstyle.";
		}
		if (Suitor.Cosmetic.MaleAccessories[rivalBookBag.DesiredAccessory].activeInHierarchy)
		{
			if (rivalBookBag.DesiredAccessory == 17)
			{
				AttractionText[2] = "Your rival likes her suitor's piercings!";
			}
			else
			{
				AttractionText[2] = "Your rival likes her suitor's bandana!";
			}
			Multiplier++;
		}
		else
		{
			AttractionText[2] = "The suitor lacks accessories that your rival finds appealing.";
		}
		if (Suitor.Cosmetic.Eyewear[rivalBookBag.DesiredEyewear].activeInHierarchy)
		{
			AttractionText[3] = "Your rival likes her suitor's glasses!";
			Multiplier++;
		}
		else
		{
			AttractionText[3] = "The suitor lacks facialwear that your rival finds appealing.";
		}
		if (rivalBookBag.DesiredSkin > 0)
		{
			if (Suitor.Cosmetic.SkinColor == rivalBookBag.DesiredSkin)
			{
				AttractionText[4] = "Your rival likes her suitor's tan!";
				Multiplier++;
			}
			else
			{
				AttractionText[4] = "The suitor lacks a physical trait that your rival is attracted to.";
			}
		}
		else
		{
			AttractionText[4] = "Your rival doesn't seem to have a preference regarding skin color.";
		}
		if (rivalBookBag.DesiredHairColor != "")
		{
			if (Suitor.Cosmetic.HairColor == "SolidBlack")
			{
				AttractionText[5] = "Your rival likes her suitor's hair color!";
				Multiplier++;
			}
			else
			{
				AttractionText[5] = "Your rival doesn't like her suitor's hair color.";
			}
		}
		else
		{
			AttractionText[5] = "Your rival doesn't seem to have a preference regarding hair color.";
		}
		if (rivalBookBag.DesiredJewelry)
		{
			if (Suitor.Cosmetic.GaloAccessories[0].activeInHierarchy == rivalBookBag.DesiredJewelry)
			{
				AttractionText[6] = "Your rival likes her suitor's jewelry!";
				Multiplier++;
			}
			else
			{
				AttractionText[6] = "Your rival is disappointed that her suitor doesn't wear jewelry.";
			}
		}
		else
		{
			AttractionText[6] = "Your rival doesn't seem to care whether or not someone is wearing jewelry.";
		}
		if (PlayerGlobals.PantiesEquipped == 2)
		{
			AttractionText[7] = "The panties you put on this morning put you into the right mindset to give your suitor the best advice!";
			Multiplier++;
		}
		else
		{
			AttractionText[7] = "Consider visiting the lingerie store in town to purchase panties that boost your matchmaking skill.";
		}
		if (Yandere.Class.Seduction + Yandere.Class.SeductionBonus > 0)
		{
			AttractionText[8] = "The romance manga you've been reading contained helpful advice for your suitor!";
			Multiplier += Yandere.Class.Seduction + Yandere.Class.SeductionBonus;
		}
		else
		{
			AttractionText[8] = "You can provide the suitor with better advice if you visit the manga store in town, purchase romance manga, and read it at night.";
		}
		if (Yandere.Class.PsychologyGrade + Yandere.Class.PsychologyBonus > 0)
		{
			AttractionText[9] = "Your knowledge of psychology improved the effectiveness of your advice!";
			Multiplier += Yandere.Class.PsychologyGrade + Yandere.Class.PsychologyBonus;
		}
		else
		{
			AttractionText[9] = "You could provide the suitor with better advice if you studied psychology at classtime.";
		}
		AttractionLabel.text = AttractionText[1] + "\n\n" + AttractionText[2] + "\n\n" + AttractionText[3] + "\n\n" + AttractionText[4] + "\n\n" + AttractionText[5] + "\n\n" + AttractionText[6] + "\n\n" + AttractionText[7] + "\n\n" + AttractionText[8] + "\n\n" + AttractionText[9];
	}

	public void CalculateLove()
	{
		Start();
		CalculateMultiplier();
		if (!DatingGlobals.GetTopicDiscussed(PositiveID))
		{
			if (RivalOpinions[PositiveID] == 2)
			{
				Affection += Multiplier;
				Outcomes[1] = "Your rival enjoyed what her suitor said about " + Subjects[PositiveID] + ".";
			}
			else
			{
				Outcomes[1] = "Your rival disliked what her suitor said about " + Subjects[PositiveID] + ".";
			}
		}
		else
		{
			Outcomes[1] = "Your rival was bored when her suitor tried to discuss " + Subjects[PositiveID] + ", because they already discussed it on a previous day.";
		}
		TopicsDiscussed[PositiveID] = true;
		if (!DatingGlobals.GetTopicDiscussed(NegativeID))
		{
			if (RivalOpinions[NegativeID] == 1)
			{
				Affection += Multiplier;
				Outcomes[2] = "Your rival enjoyed what her suitor said about " + Subjects[NegativeID] + ".";
			}
			else
			{
				Outcomes[2] = "Your rival disliked what her suitor said about " + Subjects[NegativeID] + ".";
			}
		}
		else
		{
			Outcomes[2] = "Your rival was bored when her suitor tried to discuss " + Subjects[NegativeID] + ", because they already discussed it on a previous day.";
		}
		TopicsDiscussed[NegativeID] = true;
		if (!DatingGlobals.GetComplimentGiven(ComplimentID))
		{
			if (RivalComplimentsDesired[ComplimentID])
			{
				Affection += Multiplier;
				Outcomes[3] = "Your rival enjoyed hearing " + Compliments[ComplimentID];
			}
			else
			{
				Outcomes[3] = "Your rival did not appreciate hearing " + Compliments[ComplimentID];
			}
		}
		else
		{
			Outcomes[3] = "Your rival was bored when her suitor said " + Compliments[ComplimentID] + ", because the suitor already said that on a previous day.";
		}
		ComplimentsGiven[ComplimentID] = true;
		if (CollectibleGlobals.GetGiftPurchased(GiftID + 5))
		{
			if (!CollectibleGlobals.GetGiftGiven(GiftID))
			{
				Affection += Multiplier;
				Outcomes[4] = "Your rival appreciated recieving a " + Gifts[GiftID] + ".";
			}
			else
			{
				Outcomes[4] = "Your rival did not appreciate appreciated recieving a " + Gifts[GiftID] + ", because the suitor already gave her one on a previous day.";
			}
			GiftsInPossession[GiftID] = false;
			GiftsGiven[GiftID] = true;
		}
		else
		{
			Outcomes[4] = "You did not provide the suitor with a gift to give to your rival.";
		}
		if (RivalRespectedTrait == ShowOffID)
		{
			if (StudentManager.DatingMinigame.Trait[ShowOffID] > StudentManager.DatingMinigame.TraitDemonstrated[ShowOffID])
			{
				Affection += Multiplier;
				Outcomes[5] = "Your rival was impressed with the suitor's " + ShowOffs[ShowOffID] + ".";
				TraitsDemonstrated[ShowOffID]++;
			}
			else
			{
				Outcomes[5] = "The suitor didn't have enough " + ShowOffs[ShowOffID] + " to impress your rival.";
			}
		}
		else
		{
			Outcomes[5] = "Your rival didn't really care when her suitor tried to show off his " + ShowOffs[ShowOffID] + ".";
		}
		Outcomes[6] = "Your rival's affection for the suitor increased by " + (Affection - DatingGlobals.Affection) + " points.";
		if (Affection < (float)(DateGlobals.Week * 10))
		{
			Outcomes[7] = (float)(DateGlobals.Week * 10) - Affection + " more points are required in order to make your rival fall in love with her suitor.";
		}
		else
		{
			Outcomes[7] = "Your rival is now in love with her suitor! She will confess to him at 5:00 PM on Friday!";
			if (DateGlobals.Weekday == DayOfWeek.Friday)
			{
				StudentManager.LoveManager.ConfessToSuitor = true;
			}
		}
		ResultLabel.text = Outcomes[1] + "\n\n" + Outcomes[2] + "\n\n" + Outcomes[3] + "\n\n" + Outcomes[4] + "\n\n" + Outcomes[5] + "\n\n" + Outcomes[6] + "\n\n" + Outcomes[7];
		ResultsScreen.gameObject.SetActive(value: true);
		Time.timeScale = 0.0001f;
		GiftDataNeedsSaving = true;
		DataNeedsSaving = true;
		Debug.Log("Affection is now: " + Affection);
		Debug.Log("The game now believes that we need to update which matchmaking gifts are in the player's possession.");
	}

	public void SaveTopicsAndCompliments()
	{
		for (int i = 1; i < 26; i++)
		{
			DatingGlobals.SetTopicDiscussed(i, TopicsDiscussed[i]);
		}
		for (int j = 1; j < 11; j++)
		{
			DatingGlobals.SetComplimentGiven(j, ComplimentsGiven[j]);
		}
		for (int k = 1; k < 4; k++)
		{
			DatingGlobals.SetTraitDemonstrated(k, TraitsDemonstrated[k]);
		}
		DatingGlobals.Affection = Affection;
		Debug.Log("Saving suitor data stored in AdviceWindowScript.");
	}

	public void SaveGiftStatus()
	{
		Debug.Log("The game is now saving which matchmaking gifts are in the player's possession.");
		for (int i = 1; i < 5; i++)
		{
			CollectibleGlobals.SetGiftPurchased(i + 5, GiftsInPossession[i]);
			CollectibleGlobals.SetGiftGiven(i, GiftsGiven[i]);
		}
	}
}
