// Decompiled with JetBrains decompiler
// Type: GenericRivalBagScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GenericRivalBagScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public InputManagerScript InputManager;
  public GenericRivalEventScript Event;
  public PromptBarScript PromptBar;
  public StudentScript Rival;
  public PromptScript Prompt;
  public JsonScript JSON;
  public GameObject MagazineButton;
  public GameObject DiaryButton;
  public GameObject Window;
  public Transform Highlight;
  public Transform Magazine;
  public Transform Diary;
  public UILabel DiaryLabelRight;
  public UILabel DiaryLabelLeft;
  public UILabel[] Label;
  public UITexture DiaryBG;
  public Texture[] DiaryTextures;
  public bool BorrowedBook;
  public bool Alcohol;
  public bool Condoms;
  public bool Cigarettes;
  public bool StolenRing;
  public bool AnswerSheet;
  public bool Narcotics;
  public bool ShowMagazine;
  public bool BentoStolen;
  public bool ShowDiary;
  public bool NoBento;
  public int Selected;
  public int Limit;
  public int Menu;
  public int[] RivalOpinions;
  public string[] Subjects;
  public string[] RivalDislikes;
  public string[] RivalLikes;
  public int Dislikes = 1;
  public int Likes = 1;
  public int[] DesiredHairstyles;
  public int[] DesiredAccessories;
  public int[] DesiredEyewears;
  public int[] DesiredSkins;
  public string[] DesiredHairColors;
  public bool[] DesiredJewelries;
  public int[] DesiredTraits;
  public string[] DiaryEntryLeft;
  public string[] DiaryEntryRight;
  public int DesiredHairstyle;
  public int DesiredAccessory;
  public int DesiredEyewear;
  public int DesiredSkin;
  public string DesiredHairColor;
  public bool DesiredJewelry;
  public int DesiredTrait;
  public string DesiredHairstyleText;
  public string DesiredAccessoryText;
  public string DesiredEyewearText;
  public string DesiredSkinText;
  public string DesiredHairColorText;
  public string DesiredJewelryText;
  public string DesiredTraitText;
  public bool Initialized;
  public int Page = 1;
  public Vector3 CorrectPosition;
  public Vector3 CorrectRotation;
  public bool EmeticStatus;
  public bool TranquilStatus;
  public bool HeadacheStatus;
  public bool LethalStatus;
  public bool TamperedStatus;
  public GameObject TanHearts;
  public GameObject PiercingHearts;
  public GameObject DarkHairHearts;
  public GameObject GlassesHearts;
  public GameObject BandanaHearts;
  public GameObject JewleryHearts;
  public GameObject SunglassesHearts;
  public GameObject PonytailHearts;
  public GameObject SlickHearts;
  public GameObject CourageHearts;
  public GameObject SmartHearts;
  public GameObject StrongHearts;
  public GameObject QuoteBoxes;
  public Transform Pivot;
  public UITexture[] Pages;

  public void Start()
  {
    if (this.Initialized)
      return;
    this.GrabRivalInfo();
    this.Magazine.gameObject.SetActive(false);
    this.MagazineButton.SetActive(false);
    this.Magazine.localPosition = new Vector3(-700f, -1470f, 0.0f);
    this.Magazine.localEulerAngles = new Vector3(0.0f, 0.0f, 45f);
    this.Diary.gameObject.SetActive(false);
    this.DiaryButton.SetActive(false);
    this.Diary.localPosition = new Vector3(-700f, -1470f, 0.0f);
    this.Diary.localEulerAngles = new Vector3(0.0f, 0.0f, 45f);
    this.gameObject.SetActive(false);
    this.Window.SetActive(false);
    this.Prompt.enabled = false;
    this.Prompt.Hide();
    this.Initialized = true;
  }

  private void Update()
  {
    if (!this.Window.activeInHierarchy)
    {
      if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
        return;
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
        this.PromptBar.Label[4].text = "Change Selection";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
      }
      else
      {
        this.Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone is watching!";
        this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
    }
    else
    {
      if (this.InputManager.TappedDown)
      {
        ++this.Selected;
        this.UpdateHighlight();
      }
      else if (this.InputManager.TappedUp)
      {
        --this.Selected;
        this.UpdateHighlight();
      }
      if (Input.GetButtonDown("A"))
      {
        if (this.Menu == 1)
        {
          if ((double) this.Label[this.Selected].color.a == 1.0)
          {
            if (this.Selected == 1)
            {
              this.Menu = 2;
              this.UpdateMenuLabels();
            }
            else if (this.Selected == 2)
            {
              this.Menu = 3;
              this.UpdateMenuLabels();
            }
            else if (this.Selected == 3)
            {
              this.Menu = 4;
              this.UpdateMenuLabels();
            }
            else if (this.Selected == 4)
              this.CloseWindow();
          }
        }
        else if (this.Menu == 2)
        {
          if ((double) this.Label[this.Selected].color.a == 1.0)
          {
            if (this.Selected == 1)
            {
              Debug.Log((object) "The player has stolen the book that the rival borrowed from Senpai.");
              this.BorrowedBook = false;
              this.Event.Sabotage();
              ScheduleBlock scheduleBlock = this.Rival.ScheduleBlocks[4];
              scheduleBlock.destination = "Search Patrol";
              scheduleBlock.action = "Search Patrol";
              this.Rival.GetDestinations();
              Debug.Log((object) "The rival's routine should now be adjusted to ''Search'' at lunchtime.");
              this.UpdateMenuLabels();
            }
            else if (this.Selected == 2)
            {
              this.MagazineButton.SetActive(true);
              this.Highlight.gameObject.SetActive(false);
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[1].text = "Back";
              this.PromptBar.UpdateButtons();
              this.Menu = 5;
              this.UpdateMenuLabels();
            }
            else if (this.Selected == 3)
            {
              this.DiaryButton.SetActive(true);
              this.GrabRivalInfo();
              this.Highlight.gameObject.SetActive(false);
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[1].text = "Back";
              this.PromptBar.UpdateButtons();
              this.Menu = 6;
              this.UpdateMenuLabels();
              for (int Topic = 1; Topic < 26; ++Topic)
                this.Prompt.Yandere.StudentManager.SetTopicLearnedByStudent(Topic, this.Prompt.Yandere.StudentManager.RivalID, true);
              this.Prompt.Yandere.NotificationManager.CustomText = "Learned the rival's likes & dislikes";
              this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
            else if (this.Selected == 4)
            {
              this.Menu = 1;
              this.UpdateMenuLabels();
            }
          }
        }
        else if (this.Menu == 3)
        {
          if ((double) this.Label[this.Selected].color.a == 1.0)
          {
            if (this.Selected == 1)
            {
              --this.Prompt.Yandere.Inventory.EmeticPoisons;
              this.Rival.MyBento.Tampered = true;
              this.Rival.MyBento.Emetic = true;
            }
            else if (this.Selected == 2)
            {
              this.Prompt.Yandere.Sanity -= (PlayerGlobals.PantiesEquipped == 10 ? 10f : 20f) * this.Prompt.Yandere.Numbness;
              --this.Prompt.Yandere.Inventory.LethalPoisons;
              this.Rival.MyBento.Tampered = true;
              this.Rival.MyBento.Lethal = true;
            }
            else if (this.Selected == 3)
            {
              --this.Prompt.Yandere.Inventory.HeadachePoisons;
              this.Rival.MyBento.Tampered = true;
              this.Rival.MyBento.Headache = true;
            }
            else if (this.Selected == 4)
            {
              --this.Prompt.Yandere.Inventory.SedativePoisons;
              this.Rival.MyBento.Tampered = true;
              this.Rival.MyBento.Tranquil = true;
            }
            else if (this.Selected == 5)
            {
              if (this.Rival.ScheduleBlocks[4].action != "Search Patrol")
              {
                Debug.Log((object) "The current rival should spend her lunchtime looking sad.");
                this.Rival.ScheduleBlocks[4].action = "Shamed";
                this.Rival.GetDestinations();
              }
              this.BentoStolen = true;
            }
            this.Menu = 1;
            this.UpdateMenuLabels();
          }
        }
        else if (this.Menu == 4)
        {
          if ((double) this.Label[this.Selected].color.a == 1.0)
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
          }
        }
        else if (this.Menu == 5)
        {
          this.PromptBar.Label[5].text = "Change Selection";
          this.PromptBar.UpdateButtons();
          this.Magazine.gameObject.SetActive(true);
          this.MagazineButton.SetActive(false);
          this.ShowMagazine = true;
          this.HideAllHearts();
          this.Page = 1;
          this.UpdateHearts();
        }
        else if (this.Menu == 6)
        {
          this.Diary.gameObject.SetActive(true);
          this.DiaryButton.SetActive(false);
          this.ShowDiary = true;
        }
      }
      else if (Input.GetButtonDown("B"))
      {
        if (this.ShowMagazine)
        {
          this.PromptBar.Label[5].text = "";
          this.PromptBar.UpdateButtons();
          this.MagazineButton.SetActive(true);
          this.ShowMagazine = false;
        }
        else if (this.ShowDiary)
        {
          this.PromptBar.Label[5].text = "";
          this.PromptBar.UpdateButtons();
          this.DiaryButton.SetActive(true);
          this.ShowDiary = false;
        }
        else
        {
          this.MagazineButton.SetActive(false);
          this.DiaryButton.SetActive(false);
          this.Highlight.gameObject.SetActive(true);
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Confirm";
          this.PromptBar.Label[4].text = "Change Selection";
          this.PromptBar.UpdateButtons();
          if (this.Menu == 5)
          {
            this.Menu = 2;
            this.UpdateMenuLabels();
          }
          else if (this.Menu == 6)
          {
            this.Menu = 2;
            this.UpdateMenuLabels();
          }
        }
      }
      else if (this.Page == 1 && this.Prompt.Yandere.PauseScreen.InputManager.TappedRight)
      {
        ++this.Page;
        this.HideAllHearts();
        this.UpdateHearts();
      }
      else if (this.Page == 2 && this.Prompt.Yandere.PauseScreen.InputManager.TappedLeft)
      {
        --this.Page;
        this.HideAllHearts();
        this.UpdateHearts();
      }
      if (this.ShowMagazine)
      {
        this.Magazine.localPosition = Vector3.Lerp(this.Magazine.localPosition, new Vector3(0.0f, 50f, 0.0f), Time.unscaledDeltaTime * 10f);
        this.Magazine.localEulerAngles = Vector3.Lerp(this.Magazine.localEulerAngles, new Vector3(0.0f, 0.0f, 0.0f), Time.unscaledDeltaTime * 10f);
        if (this.Page == 1)
        {
          this.Pivot.localEulerAngles = Vector3.Lerp(this.Pivot.localEulerAngles, new Vector3(0.0f, 0.0f, 0.0f), Time.unscaledDeltaTime * 36f);
          if ((double) this.Pivot.localEulerAngles.y < 90.0)
            this.Pages[2].enabled = true;
          if ((double) this.Pivot.localEulerAngles.y >= 1.0)
            ;
        }
        else
        {
          this.Pivot.localEulerAngles = Vector3.Lerp(this.Pivot.localEulerAngles, new Vector3(0.0f, 180f, 0.0f), Time.unscaledDeltaTime * 36f);
          if ((double) this.Pivot.localEulerAngles.y > 90.0)
            this.Pages[2].enabled = false;
          if ((double) this.Pivot.localEulerAngles.y <= 179.0)
            ;
        }
      }
      else
      {
        this.Magazine.localPosition = Vector3.Lerp(this.Magazine.localPosition, new Vector3(-735f, -1470f, 0.0f), Time.unscaledDeltaTime * 10f);
        this.Magazine.localEulerAngles = Vector3.Lerp(this.Magazine.localEulerAngles, new Vector3(0.0f, 0.0f, 45f), Time.unscaledDeltaTime * 10f);
      }
      if (this.ShowDiary)
      {
        this.Diary.localPosition = Vector3.Lerp(this.Diary.localPosition, new Vector3(0.0f, 50f, 0.0f), Time.unscaledDeltaTime * 10f);
        this.Diary.localEulerAngles = Vector3.Lerp(this.Diary.localEulerAngles, new Vector3(0.0f, 0.0f, 0.0f), Time.unscaledDeltaTime * 10f);
      }
      else
      {
        this.Diary.localPosition = Vector3.Lerp(this.Diary.localPosition, new Vector3(-765f, -1530f, 0.0f), Time.unscaledDeltaTime * 10f);
        this.Diary.localEulerAngles = Vector3.Lerp(this.Diary.localEulerAngles, new Vector3(0.0f, 0.0f, 45f), Time.unscaledDeltaTime * 10f);
      }
    }
  }

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

  private void UpdateHighlight()
  {
    if (this.Selected > this.Limit)
      this.Selected = 1;
    else if (this.Selected < 1)
      this.Selected = this.Limit;
    this.Highlight.localPosition = new Vector3(0.0f, (float) (400 - this.Selected * 100), 0.0f);
  }

  private void UpdateMenuLabels()
  {
    this.Selected = 1;
    this.UpdateHighlight();
    for (int index = 1; index < this.Label.Length; ++index)
    {
      this.Label[index].color = new Color(1f, 1f, 1f, 1f);
      this.Label[index].text = "";
    }
    this.Label[8].text = "";
    if (this.Menu == 1)
    {
      this.Label[1].text = "BOOKS";
      this.Label[2].text = "BENTO";
      this.Label[3].text = "CONTRABAND";
      this.Label[4].text = "EXIT";
      if ((Object) this.Rival == (Object) null)
      {
        Debug.Log((object) "Rival was null, grabbing her info now.");
        this.GrabRivalInfo();
      }
      if (this.Rival.MyBento.Tampered || this.BentoStolen || this.NoBento)
      {
        this.Label[2].color = new Color(1f, 1f, 1f, 0.5f);
        this.Label[2].text = !this.BentoStolen ? (!this.NoBento ? "BENTO (POISONED)" : "NO BENTO") : "BENTO (STOLEN)";
      }
      if (this.Prompt.Yandere.StudentManager.Clock.Period > 3)
        this.Label[2].color = new Color(1f, 1f, 1f, 0.5f);
      this.Limit = 4;
    }
    else if (this.Menu == 2)
    {
      this.Label[1].text = "STEAL BORROWED BOOK";
      this.Label[2].text = "READ MAGAZINE";
      this.Label[3].text = "READ DIARY";
      this.Label[4].text = "BACK";
      if (!this.BorrowedBook || this.Prompt.Yandere.StudentManager.Clock.Period == 3)
        this.Label[1].color = new Color(1f, 1f, 1f, 0.5f);
      this.Limit = 4;
    }
    else if (this.Menu == 3)
    {
      this.Label[1].text = "PUT EMETIC POISON IN BENTO";
      this.Label[2].text = "PUT LETHAL POISON IN BENTO";
      this.Label[3].text = "PUT HEADACHE POISON IN BENTO";
      this.Label[4].text = "PUT SEDATIVE POISON IN BENTO";
      this.Label[5].text = "STEAL BENTO";
      this.Label[6].text = "BACK";
      if (this.Prompt.Yandere.Inventory.EmeticPoisons == 0)
        this.Label[1].color = new Color(1f, 1f, 1f, 0.5f);
      if (this.Prompt.Yandere.Inventory.LethalPoisons == 0)
        this.Label[2].color = new Color(1f, 1f, 1f, 0.5f);
      if (this.Prompt.Yandere.Inventory.HeadachePoisons == 0)
        this.Label[3].color = new Color(1f, 1f, 1f, 0.5f);
      if (this.Prompt.Yandere.Inventory.SedativePoisons == 0)
        this.Label[4].color = new Color(1f, 1f, 1f, 0.5f);
      this.Limit = 6;
    }
    else if (this.Menu == 4)
    {
      this.Label[1].text = "PUT ALCOHOL INTO BAG";
      this.Label[2].text = "PUT CONDOMS INTO BAG";
      this.Label[3].text = "PUT CIGARETTES INTO BAG";
      this.Label[4].text = "PUT STOLEN RING INTO BAG";
      this.Label[5].text = "PUT ANSWER SHEET INTO BAG";
      this.Label[6].text = "PUT NARCOTICS INTO BAG";
      this.Label[7].text = "BACK";
      if (!this.Prompt.Yandere.Inventory.Sake)
        this.Label[1].color = new Color(1f, 1f, 1f, 0.5f);
      if (!this.Prompt.Yandere.Inventory.Condoms)
        this.Label[2].color = new Color(1f, 1f, 1f, 0.5f);
      if (!this.Prompt.Yandere.Inventory.Cigs)
        this.Label[3].color = new Color(1f, 1f, 1f, 0.5f);
      if (!this.Prompt.Yandere.Inventory.Ring)
        this.Label[4].color = new Color(1f, 1f, 1f, 0.5f);
      if (!this.Prompt.Yandere.Inventory.AnswerSheet)
        this.Label[5].color = new Color(1f, 1f, 1f, 0.5f);
      if (!this.Prompt.Yandere.Inventory.Narcotics)
        this.Label[6].color = new Color(1f, 1f, 1f, 0.5f);
      this.Limit = 7;
    }
    else if (this.Menu == 5)
    {
      this.Label[8].text = "You find a magazine in your rival's bookbag.\n\nIt's a fashion magazine with lots of cute boys in it.\n\nYour rival has drawn hearts next to certain boys.\n\nYou could use this information to determine what traits she's attracted to.\n\nTo look inside the magazine, press:\n\n";
    }
    else
    {
      if (this.Menu != 6)
        return;
      this.Label[8].text = "You find a diary in your rival's bookbag.\n\nBy reading your rival's diary, you will be able to learn her likes and dislikes,\n\nembarassing secrets that will allow you to spread gossip about her,\n\nand personal problems that you can discuss with her by leaving a note in her locker.\n\nTo look inside the diary, press:\n\n";
      this.Prompt.Yandere.Police.EndOfDay.LearnedAboutPhotographer = true;
      this.Prompt.Yandere.StudentManager.EmbarassingSecret = true;
    }
  }

  public void GrabRivalInfo()
  {
    this.Rival = this.Prompt.Yandere.StudentManager.Students[this.Prompt.Yandere.StudentManager.RivalID];
    int week = DateGlobals.Week;
    if (week >= 11)
      return;
    if (week == 4)
      this.NoBento = true;
    int index1 = 10 + week;
    this.RivalOpinions = this.JSON.Topics[index1].Topics;
    int index2 = 1;
    this.Likes = 1;
    this.Dislikes = 1;
    for (; index2 < 26; ++index2)
    {
      if (this.RivalOpinions[index2] == 2)
      {
        this.RivalLikes[this.Likes] = this.Subjects[index2];
        ++this.Likes;
      }
      else if (this.RivalOpinions[index2] == 1)
      {
        this.RivalDislikes[this.Dislikes] = this.Subjects[index2];
        ++this.Dislikes;
      }
    }
    int index3 = index1 - 10;
    this.DesiredHairstyle = this.DesiredHairstyles[index3];
    this.DesiredAccessory = this.DesiredAccessories[index3];
    this.DesiredEyewear = this.DesiredEyewears[index3];
    this.DesiredSkin = this.DesiredSkins[index3];
    this.DesiredHairColor = this.DesiredHairColors[index3];
    this.DesiredJewelry = this.DesiredJewelries[index3];
    this.DesiredTrait = this.DesiredTraits[index3];
    this.DiaryLabelLeft.text = "My best friend asked me to name the 5 things I love the most. It was difficult, but I narrowed it down to:\n\n" + this.RivalLikes[1] + ", " + this.RivalLikes[2] + ", " + this.RivalLikes[3] + ", " + this.RivalLikes[4] + ", and " + this.RivalLikes[5] + ".\n\nNext, she wanted me to name my 5 least favorite things. I decided on:\n\n" + this.RivalDislikes[1] + ", " + this.RivalDislikes[2] + ", " + this.RivalDislikes[3] + ", " + this.RivalDislikes[4] + ", and " + this.RivalDislikes[5] + ".\n\nLast night, I had a nightmare that everyone at Akademi learned my most embarassing secret:\n\n" + this.DiaryEntryLeft[index3];
    this.DiaryLabelRight.text = this.DiaryEntryRight[index3];
    this.DiaryBG.mainTexture = this.DiaryTextures[index3];
  }

  private void HideAllHearts()
  {
    this.PonytailHearts.SetActive(false);
    this.SlickHearts.SetActive(false);
    this.PiercingHearts.SetActive(false);
    this.BandanaHearts.SetActive(false);
    this.GlassesHearts.SetActive(false);
    this.SunglassesHearts.SetActive(false);
    this.TanHearts.SetActive(false);
    this.DarkHairHearts.SetActive(false);
    this.JewleryHearts.SetActive(false);
    this.CourageHearts.SetActive(false);
    this.SmartHearts.SetActive(false);
    this.StrongHearts.SetActive(false);
    this.QuoteBoxes.SetActive(false);
  }

  private void UpdateHearts()
  {
    if (this.Page == 1)
    {
      this.QuoteBoxes.SetActive(true);
      if (this.DesiredAccessory == 17)
        this.PiercingHearts.SetActive(true);
      else if (this.DesiredAccessory == 1)
        this.BandanaHearts.SetActive(true);
      if (this.DesiredEyewear == 6)
        this.GlassesHearts.SetActive(true);
      else if (this.DesiredEyewear == 3)
        this.SunglassesHearts.SetActive(true);
      if (this.DesiredSkin == 6)
        this.TanHearts.SetActive(true);
      if (this.DesiredHairColor == "SolidBlack")
        this.DarkHairHearts.SetActive(true);
      if (this.DesiredJewelry)
        this.JewleryHearts.SetActive(true);
      if (this.DesiredTrait == 1)
        this.CourageHearts.SetActive(true);
      else if (this.DesiredTrait == 2)
      {
        this.SmartHearts.SetActive(true);
      }
      else
      {
        if (this.DesiredTrait != 3)
          return;
        this.StrongHearts.SetActive(true);
      }
    }
    else if (this.DesiredHairstyle == 55)
    {
      this.PonytailHearts.SetActive(true);
    }
    else
    {
      if (this.DesiredHairstyle != 56)
        return;
      this.SlickHearts.SetActive(true);
    }
  }

  public void UpdatePosition()
  {
    this.transform.position = this.CorrectPosition;
    this.transform.eulerAngles = this.CorrectRotation;
  }

  public void RememberBentoStatus()
  {
    if (!((Object) this.Rival != (Object) null))
      return;
    this.EmeticStatus = this.Rival.MyBento.Emetic;
    this.TranquilStatus = this.Rival.MyBento.Tranquil;
    this.HeadacheStatus = this.Rival.MyBento.Headache;
    this.LethalStatus = this.Rival.MyBento.Lethal;
    this.TamperedStatus = this.Rival.MyBento.Tampered;
  }

  public void RestoreBentoStatus()
  {
    if (!((Object) this.Rival != (Object) null))
      return;
    this.Rival.MyBento.Emetic = this.EmeticStatus;
    this.Rival.MyBento.Tranquil = this.TranquilStatus;
    this.Rival.MyBento.Headache = this.HeadacheStatus;
    this.Rival.MyBento.Lethal = this.LethalStatus;
    this.Rival.MyBento.Tampered = this.TamperedStatus;
  }
}
