// Decompiled with JetBrains decompiler
// Type: AdviceWindowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
    if (this.Initialized)
      return;
    this.StudentManager.RivalBookBag.Start();
    this.Affection = DatingGlobals.Affection;
    for (int topicID = 1; topicID < 26; ++topicID)
      this.TopicsDiscussed[topicID] = DatingGlobals.GetTopicDiscussed(topicID);
    for (int complimentID = 1; complimentID < 11; ++complimentID)
      this.ComplimentsGiven[complimentID] = DatingGlobals.GetComplimentGiven(complimentID);
    for (int traitID = 1; traitID < 4; ++traitID)
      this.TraitsDemonstrated[traitID] = DatingGlobals.GetTraitDemonstrated(traitID);
    for (int index = 1; index < 5; ++index)
      this.GiftsInPossession[index] = CollectibleGlobals.GetGiftPurchased(index + 5);
    for (int giftID = 1; giftID < 5; ++giftID)
      this.GiftsGiven[giftID] = CollectibleGlobals.GetGiftGiven(giftID);
    this.RivalOpinions = this.JSON.Topics[10 + DateGlobals.Week].Topics;
    switch (DateGlobals.Week)
    {
      case 1:
        this.RivalComplimentsDesired = this.Week1Compliments;
        break;
      case 2:
        this.RivalComplimentsDesired = this.Week2Compliments;
        break;
      case 3:
        this.RivalComplimentsDesired = this.Week3Compliments;
        break;
      case 4:
        this.RivalComplimentsDesired = this.Week4Compliments;
        break;
      case 5:
        this.RivalComplimentsDesired = this.Week5Compliments;
        break;
      case 6:
        this.RivalComplimentsDesired = this.Week6Compliments;
        break;
      case 7:
        this.RivalComplimentsDesired = this.Week7Compliments;
        break;
      case 8:
        this.RivalComplimentsDesired = this.Week8Compliments;
        break;
      case 9:
        this.RivalComplimentsDesired = this.Week9Compliments;
        break;
      case 10:
        this.RivalComplimentsDesired = this.Week10Compliments;
        break;
    }
    this.RivalRespectedTrait = this.StudentManager.RivalBookBag.DesiredTrait;
    this.UpdateText();
    this.Initialized = true;
  }

  private void Update()
  {
    if (this.InputManager.TappedDown)
    {
      ++this.Selected;
      this.UpdateHighlight();
      this.UpdateText();
    }
    else if (this.InputManager.TappedUp)
    {
      --this.Selected;
      this.UpdateHighlight();
      this.UpdateText();
    }
    else if (this.InputManager.TappedRight)
    {
      if (this.Selected == 1)
      {
        ++this.PositiveID;
        if (this.PositiveID > this.Subjects.Length - 1)
          this.PositiveID = 1;
      }
      else if (this.Selected == 2)
      {
        ++this.NegativeID;
        if (this.NegativeID > this.Subjects.Length - 1)
          this.NegativeID = 1;
      }
      else if (this.Selected == 3)
      {
        ++this.ComplimentID;
        if (this.ComplimentID > this.Compliments.Length - 1)
          this.ComplimentID = 1;
      }
      else if (this.Selected == 4)
      {
        ++this.ShowOffID;
        if (this.ShowOffID > this.ShowOffs.Length - 1)
          this.ShowOffID = 1;
      }
      else if (this.Selected == 5)
      {
        ++this.GiftID;
        if (this.GiftID > this.Gifts.Length - 1)
          this.GiftID = 1;
      }
      this.UpdateText();
    }
    else if (this.InputManager.TappedLeft)
    {
      if (this.Selected == 1)
      {
        --this.PositiveID;
        if (this.PositiveID < 1)
          this.PositiveID = this.Subjects.Length - 1;
      }
      else if (this.Selected == 2)
      {
        --this.NegativeID;
        if (this.NegativeID < 1)
          this.NegativeID = this.Subjects.Length - 1;
      }
      else if (this.Selected == 3)
      {
        --this.ComplimentID;
        if (this.ComplimentID < 1)
          this.ComplimentID = this.Compliments.Length - 1;
      }
      else if (this.Selected == 4)
      {
        --this.ShowOffID;
        if (this.ShowOffID < 1)
          this.ShowOffID = this.ShowOffs.Length - 1;
      }
      else if (this.Selected == 5)
      {
        --this.GiftID;
        if (this.GiftID < 1)
          this.GiftID = this.Gifts.Length - 1;
      }
      this.UpdateText();
    }
    else
    {
      if (!Input.GetButtonDown("B"))
        return;
      this.Selected = 1;
      this.UpdateHighlight();
      Time.timeScale = 1f;
      this.PromptBar.ClearButtons();
      this.PromptBar.Show = false;
      this.gameObject.SetActive(false);
      this.Yandere.Interaction = YandereInteractionType.Advice;
      this.Yandere.TalkTimer = 5f;
    }
  }

  private void UpdateHighlight()
  {
    if (this.Selected > 5)
      this.Selected = 1;
    else if (this.Selected < 1)
      this.Selected = 5;
    this.Highlight.transform.localPosition = new Vector3(0.0f, (float) (570 - 150 * this.Selected), 0.0f);
  }

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
        this.AdviceLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
      }
      else
        this.AdviceLabel.text = "You can learn your rival's likes and dislikes by looking through her bookbag.";
    }
    else if (this.Selected == 2)
    {
      if (DatingGlobals.GetTopicDiscussed(this.NegativeID))
      {
        this.AdviceLabel.text = "The suitor has already discussed this subject with your rival.";
        this.AdviceLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
      }
      else
        this.AdviceLabel.text = "You can learn your rival's likes and dislikes by looking through her bookbag.";
    }
    else if (this.Selected == 3)
    {
      if (DatingGlobals.GetComplimentGiven(this.ComplimentID))
      {
        this.AdviceLabel.text = "The suitor has already said this to your rival.";
        this.AdviceLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
      }
      else
        this.AdviceLabel.text = "Consider your rival's personality when deciding what your suitor should say to her.";
    }
    else if (this.Selected == 4)
    {
      if (this.ShowOffID == 1)
      {
        string str;
        if (this.StudentManager.DatingMinigame.Trait[this.ShowOffID] < this.StudentManager.DatingMinigame.TraitDemonstrated[this.ShowOffID] + 1)
        {
          str = "This will not impress your rival. To increase the suitor's courage, lead him to the ''haunted'' painting in the third-floor Art Room.";
          this.AdviceLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
        }
        else
          str = "This is enough to impress your rival.";
        this.AdviceLabel.text = "Your suitor's courage is ''Level " + this.StudentManager.DatingMinigame.Trait[this.ShowOffID].ToString() + "''. " + str;
      }
      else if (this.ShowOffID == 2)
      {
        string str;
        if (this.StudentManager.DatingMinigame.Trait[this.ShowOffID] < this.StudentManager.DatingMinigame.TraitDemonstrated[this.ShowOffID] + 1)
        {
          str = "This will not impress your rival. To increase the suitor's intelligence, lead him to the library and study with him.";
          this.AdviceLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
        }
        else
          str = "This is enough to impress your rival.";
        this.AdviceLabel.text = "Your suitor's intelligence is ''Level " + this.StudentManager.DatingMinigame.Trait[this.ShowOffID].ToString() + "''. " + str;
      }
      else if (this.ShowOffID == 3)
      {
        string str;
        if (this.StudentManager.DatingMinigame.Trait[this.ShowOffID] < this.StudentManager.DatingMinigame.TraitDemonstrated[this.ShowOffID] + 1)
        {
          str = "This will not impress your rival. To increase the suitor's strength, lead him to the running track and train him.";
          this.AdviceLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
        }
        else
          str = "This is enough to impress your rival.";
        this.AdviceLabel.text = "Your suitor's strength is ''Level " + this.StudentManager.DatingMinigame.Trait[this.ShowOffID].ToString() + "''. " + str;
      }
    }
    else if (this.Selected == 5)
    {
      if (!CollectibleGlobals.GetGiftPurchased(this.GiftID + 5))
      {
        this.AdviceLabel.text = "You don't own this gift. You can buy it at the Gift Shop in town. You can visit town before school or after school.";
        this.AdviceLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
      }
      else if (CollectibleGlobals.GetGiftGiven(this.GiftID))
      {
        this.AdviceLabel.text = "Your suitor already gave your rival this gift on a previous day.";
        this.AdviceLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
      }
      else
        this.AdviceLabel.text = "Your rival would appreciate this gift.";
    }
    this.StatsLabel.text = "SUITOR STATS\n\nCOURAGE: " + this.StudentManager.DatingMinigame.Trait[1].ToString() + "\n\nINTELLIGENCE: " + this.StudentManager.DatingMinigame.Trait[2].ToString() + "\n\nSTRENGTH: " + this.StudentManager.DatingMinigame.Trait[3].ToString();
  }

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
      ++this.Multiplier;
    }
    else
      this.AttractionText[1] = "Your rival might like her suitor better with a different hairstyle.";
    if (this.Suitor.Cosmetic.MaleAccessories[rivalBookBag.DesiredAccessory].activeInHierarchy)
    {
      this.AttractionText[2] = "Your rival likes her suitor's piercings!";
      ++this.Multiplier;
    }
    else
      this.AttractionText[2] = "The suitor lacks accessories that your rival finds appealing.";
    if (this.Suitor.Cosmetic.Eyewear[rivalBookBag.DesiredEyewear].activeInHierarchy)
    {
      this.AttractionText[3] = "Your rival likes her suitor's glasses!";
      ++this.Multiplier;
    }
    else
      this.AttractionText[3] = "The suitor lacks facialwear that your rival finds appealing.";
    if (rivalBookBag.DesiredSkin > 0)
    {
      if (this.Suitor.Cosmetic.SkinColor == rivalBookBag.DesiredSkin)
      {
        this.AttractionText[4] = "Your rival likes her suitor's tan!";
        ++this.Multiplier;
      }
      else
        this.AttractionText[4] = "The suitor lacks a physical trait that your rival is attracted to.";
    }
    else
      this.AttractionText[4] = "Your rival doesn't seem to have a preference regarding skin color.";
    if (rivalBookBag.DesiredHairColor != "")
    {
      if (this.Suitor.Cosmetic.HairColor == "SolidBlack")
      {
        this.AttractionText[5] = "Your rival likes her suitor's hair color!";
        ++this.Multiplier;
      }
      else
        this.AttractionText[5] = "Your rival doesn't like her suitor's hair color.";
    }
    else
      this.AttractionText[5] = "Your rival doesn't seem to have a preference regarding hair color.";
    if (rivalBookBag.DesiredJewelry)
    {
      if (this.Suitor.Cosmetic.GaloAccessories[0].activeInHierarchy == rivalBookBag.DesiredJewelry)
      {
        this.AttractionText[6] = "Your rival likes her suitor's jewelry!";
        ++this.Multiplier;
      }
      else
        this.AttractionText[6] = "Your rival is disappointed that her suitor doesn't wear jewelry.";
    }
    else
      this.AttractionText[6] = "Your rival doesn't seem to care whether or not someone is wearing jewelry.";
    if (PlayerGlobals.PantiesEquipped == 2)
    {
      this.AttractionText[7] = "The panties you put on this morning put you into the right mindset to give your suitor the best advice!";
      ++this.Multiplier;
    }
    else
      this.AttractionText[7] = "Consider visiting the lingerie store in town to purchase panties that boost your matchmaking skill.";
    if (this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 0)
    {
      this.AttractionText[8] = "The romance manga you've been reading contained helpful advice for your suitor!";
      this.Multiplier += this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus;
    }
    else
      this.AttractionText[8] = "You can provide the suitor with better advice if you visit the manga store in town, purchase romance manga, and read it at night.";
    if (this.Yandere.Class.PsychologyGrade + this.Yandere.Class.PsychologyBonus > 0)
    {
      this.AttractionText[9] = "Your knowledge of psychology improved the effectiveness of your advice!";
      this.Multiplier += this.Yandere.Class.PsychologyGrade + this.Yandere.Class.PsychologyBonus;
    }
    else
      this.AttractionText[9] = "You could provide the suitor with better advice if you studied psychology at classtime.";
    this.AttractionLabel.text = this.AttractionText[1] + "\n\n" + this.AttractionText[2] + "\n\n" + this.AttractionText[3] + "\n\n" + this.AttractionText[4] + "\n\n" + this.AttractionText[5] + "\n\n" + this.AttractionText[6] + "\n\n" + this.AttractionText[7] + "\n\n" + this.AttractionText[8] + "\n\n" + this.AttractionText[9];
  }

  public void CalculateLove()
  {
    this.Start();
    this.CalculateMultiplier();
    if (!DatingGlobals.GetTopicDiscussed(this.PositiveID))
    {
      if (this.RivalOpinions[this.PositiveID] == 2)
      {
        this.Affection += (float) this.Multiplier;
        this.Outcomes[1] = "Your rival enjoyed what her suitor said about " + this.Subjects[this.PositiveID] + ".";
      }
      else
        this.Outcomes[1] = "Your rival disliked what her suitor said about " + this.Subjects[this.PositiveID] + ".";
    }
    else
      this.Outcomes[1] = "Your rival was bored when her suitor tried to discuss " + this.Subjects[this.PositiveID] + ", because they already discussed it on a previous day.";
    this.TopicsDiscussed[this.PositiveID] = true;
    if (!DatingGlobals.GetTopicDiscussed(this.NegativeID))
    {
      if (this.RivalOpinions[this.NegativeID] == 1)
      {
        this.Affection += (float) this.Multiplier;
        this.Outcomes[2] = "Your rival enjoyed what her suitor said about " + this.Subjects[this.NegativeID] + ".";
      }
      else
        this.Outcomes[2] = "Your rival disliked what her suitor said about " + this.Subjects[this.NegativeID] + ".";
    }
    else
      this.Outcomes[2] = "Your rival was bored when her suitor tried to discuss " + this.Subjects[this.NegativeID] + ", because they already discussed it on a previous day.";
    this.TopicsDiscussed[this.NegativeID] = true;
    if (!DatingGlobals.GetComplimentGiven(this.ComplimentID))
    {
      if (this.RivalComplimentsDesired[this.ComplimentID])
      {
        this.Affection += (float) this.Multiplier;
        this.Outcomes[3] = "Your rival enjoyed hearing " + this.Compliments[this.ComplimentID];
      }
      else
        this.Outcomes[3] = "Your rival did not appreciate hearing " + this.Compliments[this.ComplimentID];
    }
    else
      this.Outcomes[3] = "Your rival was bored when her suitor said " + this.Compliments[this.ComplimentID] + ", because the suitor already said that on a previous day.";
    this.ComplimentsGiven[this.ComplimentID] = true;
    if (CollectibleGlobals.GetGiftPurchased(this.GiftID + 5))
    {
      if (!CollectibleGlobals.GetGiftGiven(this.GiftID))
      {
        this.Affection += (float) this.Multiplier;
        this.Outcomes[4] = "Your rival appreciated recieving a " + this.Gifts[this.GiftID] + ".";
      }
      else
        this.Outcomes[4] = "Your rival did not appreciate appreciated recieving a " + this.Gifts[this.GiftID] + ", because the suitor already gave her one on a previous day.";
      this.GiftsInPossession[this.GiftID] = false;
      this.GiftsGiven[this.GiftID] = true;
    }
    else
      this.Outcomes[4] = "You did not provide the suitor with a gift to give to your rival.";
    if (this.RivalRespectedTrait == this.ShowOffID)
    {
      if (this.StudentManager.DatingMinigame.Trait[this.ShowOffID] > this.StudentManager.DatingMinigame.TraitDemonstrated[this.ShowOffID])
      {
        this.Affection += (float) this.Multiplier;
        this.Outcomes[5] = "Your rival was impressed with the suitor's " + this.ShowOffs[this.ShowOffID] + ".";
        ++this.TraitsDemonstrated[this.ShowOffID];
      }
      else
        this.Outcomes[5] = "The suitor didn't have enough " + this.ShowOffs[this.ShowOffID] + " to impress your rival.";
    }
    else
      this.Outcomes[5] = "Your rival didn't really care when her suitor tried to show off his " + this.ShowOffs[this.ShowOffID] + ".";
    this.Outcomes[6] = "Your rival's affection for the suitor increased by " + (this.Affection - DatingGlobals.Affection).ToString() + " points.";
    if ((double) this.Affection < (double) (DateGlobals.Week * 10))
    {
      this.Outcomes[7] = ((float) (DateGlobals.Week * 10) - this.Affection).ToString() + " more points are required in order to make your rival fall in love with her suitor.";
    }
    else
    {
      this.Outcomes[7] = "Your rival is now in love with her suitor! She will confess to him at 5:00 PM on Friday!";
      if (DateGlobals.Weekday == DayOfWeek.Friday)
        this.StudentManager.LoveManager.ConfessToSuitor = true;
    }
    this.ResultLabel.text = this.Outcomes[1] + "\n\n" + this.Outcomes[2] + "\n\n" + this.Outcomes[3] + "\n\n" + this.Outcomes[4] + "\n\n" + this.Outcomes[5] + "\n\n" + this.Outcomes[6] + "\n\n" + this.Outcomes[7];
    this.ResultsScreen.gameObject.SetActive(true);
    Time.timeScale = 0.0001f;
    this.DataNeedsSaving = true;
    Debug.Log((object) ("Affection is now: " + this.Affection.ToString()));
  }

  public void SaveTopicsAndCompliments()
  {
    for (int topicID = 1; topicID < 26; ++topicID)
      DatingGlobals.SetTopicDiscussed(topicID, this.TopicsDiscussed[topicID]);
    for (int complimentID = 1; complimentID < 11; ++complimentID)
      DatingGlobals.SetComplimentGiven(complimentID, this.ComplimentsGiven[complimentID]);
    for (int traitID = 1; traitID < 4; ++traitID)
      DatingGlobals.SetTraitDemonstrated(traitID, this.TraitsDemonstrated[traitID]);
    for (int giftID = 1; giftID < 5; ++giftID)
    {
      CollectibleGlobals.SetGiftPurchased(giftID + 5, this.GiftsInPossession[giftID]);
      CollectibleGlobals.SetGiftGiven(giftID, this.GiftsGiven[giftID]);
    }
    DatingGlobals.Affection = this.Affection;
    Debug.Log((object) "Saving suitor data stored in AdviceWindowScript.");
  }
}
