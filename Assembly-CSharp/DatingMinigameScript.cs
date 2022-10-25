// Decompiled with JetBrains decompiler
// Type: DatingMinigameScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DatingMinigameScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public InputManagerScript InputManager;
  public LoveManagerScript LoveManager;
  public PromptBarScript PromptBar;
  public YandereScript Yandere;
  public StudentScript Suitor;
  public StudentScript Rival;
  public PromptScript Prompt;
  public JsonScript JSON;
  public Transform AffectionSet;
  public Transform OptionSet;
  public GameObject HeartbeatCamera;
  public GameObject SeductionIcon;
  public GameObject PantyIcon;
  public Transform TopicHighlight;
  public Transform ComplimentSet;
  public Transform AffectionBar;
  public Transform Highlight;
  public Transform GiveGift;
  public Transform PeekSpot;
  public Transform[] Options;
  public Transform ShowOff;
  public Transform Topics;
  public Texture X;
  public UISprite[] OpinionIcons;
  public UISprite[] TopicIcons;
  public UITexture[] MultiplierIcons;
  public UILabel[] ComplimentLabels;
  public UISprite[] ComplimentBGs;
  public UILabel MultiplierLabel;
  public UILabel SeductionLabel;
  public UILabel TopicNameLabel;
  public UILabel DialogueLabel;
  public UIPanel DatingSimHUD;
  public UILabel WisdomLabel;
  public UIPanel Panel;
  public UITexture[] GiftIcons;
  public UISprite[] TraitBGs;
  public UISprite[] GiftBGs;
  public UILabel[] Labels;
  public string[] OpinionSpriteNames;
  public string[] Compliments;
  public string[] TopicNames;
  public string[] GiveGifts;
  public string[] Greetings;
  public string[] Farewells;
  public string[] Negatives;
  public string[] Positives;
  public string[] ShowOffs;
  public bool[] ComplimentsGiven;
  public bool[] TopicsDiscussed;
  public bool[] GiftsPurchased;
  public bool[] GiftsGiven;
  public bool SuitorAndRivalTalking;
  public bool GiftStatusNeedsSaving;
  public bool DataNeedsSaving;
  public bool SelectingTopic;
  public bool AffectionGrow;
  public bool Complimenting;
  public bool Initialized;
  public bool Matchmaking;
  public bool GivingGift;
  public bool ShowingOff;
  public bool Eighties;
  public bool Negative;
  public bool SlideOut;
  public bool Testing;
  public float HighlightTarget;
  public float Affection;
  public float Rotation;
  public float Speed;
  public float Timer;
  public int ComplimentSelected = 1;
  public int TraitSelected = 1;
  public int TopicSelected = 1;
  public int GiftSelected = 1;
  public int Selected = 1;
  public int AffectionLevel;
  public int Multiplier;
  public int Opinion;
  public int Phase = 1;
  public int WisdomTraitDemonstrated;
  public int WisdomTrait;
  public int CourageTraitDemonstrated;
  public int CourageTrait;
  public int StrengthTraitDemonstrated;
  public int StrengthTrait;
  public int[] TraitDemonstrated;
  public int[] Trait;
  public int GiftColumn = 1;
  public int GiftRow = 1;
  public int Column = 1;
  public int Row = 1;
  public int Side = 1;
  public int Line = 1;
  public string CurrentAnim = string.Empty;
  public Color OriginalColor;
  public Camera MainCamera;

  public void Start()
  {
    if (this.Initialized)
      return;
    this.MainCamera = Camera.main;
    this.Affection = DatingGlobals.Affection;
    this.AffectionBar.localScale = new Vector3(this.Affection / 100f, this.AffectionBar.localScale.y, this.AffectionBar.localScale.z);
    this.CalculateAffection();
    this.OriginalColor = this.ComplimentBGs[1].color;
    this.ComplimentSet.localScale = Vector3.zero;
    this.GiveGift.localScale = Vector3.zero;
    this.ShowOff.localScale = Vector3.zero;
    this.Topics.localScale = Vector3.zero;
    this.DatingSimHUD.gameObject.SetActive(false);
    this.DatingSimHUD.alpha = 0.0f;
    for (int topicID = 1; topicID < 26; ++topicID)
    {
      if (DatingGlobals.GetTopicDiscussed(topicID))
      {
        this.TopicsDiscussed[topicID] = true;
        UISprite topicIcon = this.TopicIcons[topicID];
        topicIcon.color = new Color(topicIcon.color.r, topicIcon.color.g, topicIcon.color.b, 0.5f);
      }
    }
    for (int complimentID = 1; complimentID < 11; ++complimentID)
    {
      if (DatingGlobals.GetComplimentGiven(complimentID))
      {
        this.ComplimentsGiven[complimentID] = true;
        UILabel complimentLabel = this.ComplimentLabels[complimentID];
        complimentLabel.color = new Color(complimentLabel.color.r, complimentLabel.color.g, complimentLabel.color.b, 0.5f);
      }
    }
    this.UpdateComplimentHighlight();
    this.UpdateTraitHighlight();
    this.UpdateGiftHighlight();
    this.Eighties = GameGlobals.Eighties;
    this.CourageTrait = DatingGlobals.GetSuitorTrait(1);
    this.CourageTraitDemonstrated = DatingGlobals.GetTraitDemonstrated(1);
    this.WisdomTrait = DatingGlobals.GetSuitorTrait(2);
    this.WisdomTraitDemonstrated = DatingGlobals.GetTraitDemonstrated(2);
    this.StrengthTrait = DatingGlobals.GetSuitorTrait(3);
    this.StrengthTraitDemonstrated = DatingGlobals.GetTraitDemonstrated(3);
    this.TraitDemonstrated[1] = this.CourageTraitDemonstrated;
    this.TraitDemonstrated[2] = this.WisdomTraitDemonstrated;
    this.TraitDemonstrated[3] = this.StrengthTraitDemonstrated;
    this.Trait[1] = this.CourageTrait;
    this.Trait[2] = this.WisdomTrait;
    this.Trait[3] = this.StrengthTrait;
    this.Initialized = true;
  }

  private void CalculateAffection()
  {
    if ((double) this.Affection > 100.0)
      this.Affection = 100f;
    if ((double) this.Affection == 0.0)
      this.AffectionLevel = 0;
    else if ((double) this.Affection < 25.0)
      this.AffectionLevel = 1;
    else if ((double) this.Affection < 50.0)
      this.AffectionLevel = 2;
    else if ((double) this.Affection < 75.0)
      this.AffectionLevel = 3;
    else if ((double) this.Affection < 100.0)
      this.AffectionLevel = 4;
    else
      this.AffectionLevel = 5;
  }

  private void Update()
  {
    if (this.Testing)
      this.Prompt.enabled = true;
    else if (this.LoveManager.RivalWaiting)
    {
      if ((Object) this.Rival == (Object) null)
      {
        this.Suitor = this.StudentManager.Students[this.LoveManager.SuitorID];
        this.Rival = this.StudentManager.Students[this.LoveManager.RivalID];
      }
      if ((double) this.Rival.MeetTimer > 0.0 && (double) this.Suitor.MeetTimer > 0.0)
      {
        if (!this.Eighties)
          this.Prompt.enabled = true;
        else if (!this.SuitorAndRivalTalking)
        {
          Debug.Log((object) "DatingMinigameScript is now setting SuitorAndRivalTalking to ''true''.");
          this.Suitor.CurrentDestination = this.Rival.transform;
          this.Suitor.Pathfinding.target = this.Rival.transform;
          this.Suitor.DistractionTarget = this.Rival;
          this.Suitor.TargetDistance = 1f;
          this.Suitor.DistractTimer = 10f;
          this.Suitor.Distracting = true;
          this.Suitor.Routine = false;
          this.Suitor.Pathfinding.canSearch = true;
          this.Suitor.Pathfinding.canMove = true;
          this.Rival.Pathfinding.canSearch = false;
          this.Rival.Pathfinding.canMove = false;
          this.Suitor.Meeting = false;
          this.Rival.Meeting = false;
          this.Rival.Routine = false;
          this.Suitor.MeetTimer = 0.0f;
          this.Rival.MeetTimer = 0.0f;
          this.SuitorAndRivalTalking = true;
        }
      }
    }
    else if (this.Prompt.enabled)
    {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Yandere.Chased && this.Yandere.Chasers == 0 && !this.Rival.Hunted)
      {
        this.Yandere.CameraEffects.UpdateDOF(1f);
        this.Suitor.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
        this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
        this.Suitor.CharacterAnimation.enabled = true;
        this.Rival.CharacterAnimation.enabled = true;
        this.Suitor.enabled = false;
        this.Rival.enabled = false;
        this.Rival.CharacterAnimation["f02_smile_00"].layer = 1;
        this.Rival.CharacterAnimation.Play("f02_smile_00");
        this.Rival.CharacterAnimation["f02_smile_00"].weight = 0.0f;
        this.StudentManager.Clock.StopTime = true;
        this.Yandere.RPGCamera.enabled = false;
        this.HeartbeatCamera.SetActive(false);
        this.Yandere.Headset.SetActive(true);
        this.Yandere.CanMove = false;
        this.Yandere.EmptyHands();
        if (this.Yandere.YandereVision)
        {
          this.Yandere.ResetYandereEffects();
          this.Yandere.YandereVision = false;
        }
        this.Yandere.transform.position = this.PeekSpot.position;
        this.Yandere.transform.eulerAngles = this.PeekSpot.eulerAngles;
        this.Yandere.CharacterAnimation.Play("f02_treePeeking_00");
        this.MainCamera.transform.position = new Vector3(48f, 3f, -44f);
        this.MainCamera.transform.eulerAngles = new Vector3(15f, 90f, 0.0f);
        this.WisdomLabel.text = "Wisdom: " + this.WisdomTrait.ToString();
        this.GiftIcons[1].enabled = CollectibleGlobals.GetGiftPurchased(6);
        this.GiftIcons[2].enabled = CollectibleGlobals.GetGiftPurchased(7);
        this.GiftIcons[3].enabled = CollectibleGlobals.GetGiftPurchased(8);
        this.GiftIcons[4].enabled = CollectibleGlobals.GetGiftPurchased(9);
        this.GiftsPurchased[1] = CollectibleGlobals.GetGiftPurchased(6);
        this.GiftsPurchased[2] = CollectibleGlobals.GetGiftPurchased(7);
        this.GiftsPurchased[3] = CollectibleGlobals.GetGiftPurchased(8);
        this.GiftsPurchased[4] = CollectibleGlobals.GetGiftPurchased(9);
        this.GiftsGiven[1] = CollectibleGlobals.GetGiftGiven(1);
        this.GiftsGiven[2] = CollectibleGlobals.GetGiftGiven(2);
        this.GiftsGiven[3] = CollectibleGlobals.GetGiftGiven(3);
        this.GiftsGiven[4] = CollectibleGlobals.GetGiftGiven(4);
        this.Matchmaking = true;
        this.UpdateTopics();
        Time.timeScale = 1f;
      }
    }
    if (!this.Matchmaking)
      return;
    if (this.CurrentAnim != string.Empty && (double) this.Rival.CharacterAnimation[this.CurrentAnim].time >= (double) this.Rival.CharacterAnimation[this.CurrentAnim].length)
      this.Rival.CharacterAnimation.Play(this.Rival.IdleAnim);
    if (this.Phase == 1)
    {
      this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0.0f, Time.deltaTime);
      this.Timer += Time.deltaTime;
      this.MainCamera.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(54f, 1.25f, -45.25f), this.Timer * 0.02f);
      this.MainCamera.transform.eulerAngles = Vector3.Lerp(this.MainCamera.transform.eulerAngles, new Vector3(0.0f, 45f, 0.0f), this.Timer * 0.02f);
      if ((double) this.Timer > 5.0)
      {
        this.Yandere.CameraEffects.UpdateDOF(0.6f);
        this.Suitor.CharacterAnimation.Play("insertEarpiece_00");
        this.Suitor.CharacterAnimation["insertEarpiece_00"].time = 0.0f;
        this.Suitor.CharacterAnimation.Play("insertEarpiece_00");
        this.Suitor.Earpiece.SetActive(true);
        this.MainCamera.transform.position = new Vector3(45.5f, 1.25f, -44.5f);
        this.MainCamera.transform.eulerAngles = new Vector3(0.0f, -45f, 0.0f);
        this.Rotation = -45f;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 2)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 4.0)
      {
        this.Suitor.Earpiece.transform.parent = this.Suitor.Head;
        this.Suitor.Earpiece.transform.localPosition = new Vector3(0.0f, -1.12f, 1.14f);
        this.Suitor.Earpiece.transform.localEulerAngles = new Vector3(45f, -180f, 0.0f);
        this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, new Vector3(45.11f, 1.375f, -44f), (float) (((double) this.Timer - 4.0) * 0.019999999552965164));
        this.Rotation = Mathf.Lerp(this.Rotation, 90f, (float) (((double) this.Timer - 4.0) * 0.019999999552965164));
        this.MainCamera.transform.eulerAngles = new Vector3(this.MainCamera.transform.eulerAngles.x, this.Rotation, this.MainCamera.transform.eulerAngles.z);
        if ((double) this.Rotation > 89.9000015258789)
        {
          this.Yandere.CameraEffects.UpdateDOF(0.75f);
          this.Rival.CharacterAnimation["f02_turnAround_00"].time = 0.0f;
          this.Rival.CharacterAnimation.CrossFade("f02_turnAround_00");
          this.AffectionBar.localScale = new Vector3(this.Affection / 100f, this.AffectionBar.localScale.y, this.AffectionBar.localScale.z);
          this.DialogueLabel.text = this.Greetings[this.AffectionLevel];
          this.CalculateMultiplier();
          this.DatingSimHUD.gameObject.SetActive(true);
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
    }
    else if (this.Phase == 3)
    {
      this.DatingSimHUD.alpha = Mathf.MoveTowards(this.DatingSimHUD.alpha, 1f, Time.deltaTime);
      if ((double) this.Rival.CharacterAnimation["f02_turnAround_00"].time >= (double) this.Rival.CharacterAnimation["f02_turnAround_00"].length)
      {
        this.Rival.transform.eulerAngles = new Vector3(this.Rival.transform.eulerAngles.x, -90f, this.Rival.transform.eulerAngles.z);
        this.Rival.CharacterAnimation.Play("f02_turnAround_00");
        this.Rival.CharacterAnimation["f02_turnAround_00"].time = 0.0f;
        this.Rival.CharacterAnimation["f02_turnAround_00"].speed = 0.0f;
        this.Rival.CharacterAnimation.Play("f02_turnAround_00");
        this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
        Time.timeScale = 1f;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Confirm";
        this.PromptBar.Label[1].text = "Back";
        this.PromptBar.Label[4].text = "Select";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        ++this.Phase;
      }
    }
    else if (this.Phase == 4)
    {
      if (this.AffectionGrow)
      {
        this.Affection = Mathf.MoveTowards(this.Affection, 100f, Time.deltaTime * 10f);
        this.CalculateAffection();
      }
      this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", this.Affection * 0.01f);
      this.Rival.CharacterAnimation["f02_smile_00"].weight = this.Affection * 0.01f;
      this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, Mathf.Lerp(this.Highlight.localPosition.y, this.HighlightTarget, Time.deltaTime * 10f), this.Highlight.localPosition.z);
      for (int index = 1; index < this.Options.Length; ++index)
      {
        Transform option = this.Options[index];
        option.localPosition = new Vector3(Mathf.Lerp(option.localPosition.x, index == this.Selected ? 750f : 800f, Time.deltaTime * 10f), option.localPosition.y, option.localPosition.z);
      }
      this.AffectionBar.localScale = new Vector3(Mathf.Lerp(this.AffectionBar.localScale.x, this.Affection / 100f, Time.deltaTime * 10f), this.AffectionBar.localScale.y, this.AffectionBar.localScale.z);
      if (!this.SelectingTopic && !this.Complimenting && !this.ShowingOff && !this.GivingGift)
      {
        this.Topics.localScale = Vector3.Lerp(this.Topics.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.ComplimentSet.localScale = Vector3.Lerp(this.ComplimentSet.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.ShowOff.localScale = Vector3.Lerp(this.ShowOff.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.GiveGift.localScale = Vector3.Lerp(this.GiveGift.localScale, Vector3.zero, Time.deltaTime * 10f);
        if (this.InputManager.TappedUp)
        {
          --this.Selected;
          this.UpdateHighlight();
        }
        if (this.InputManager.TappedDown)
        {
          ++this.Selected;
          this.UpdateHighlight();
        }
        if (Input.GetButtonDown("A") && (double) this.Labels[this.Selected].color.a == 1.0)
        {
          if (this.Selected == 1)
          {
            this.SelectingTopic = true;
            this.Negative = true;
          }
          else if (this.Selected == 2)
          {
            this.SelectingTopic = true;
            this.Negative = false;
          }
          else if (this.Selected == 3)
            this.Complimenting = true;
          else if (this.Selected == 4)
            this.ShowingOff = true;
          else if (this.Selected == 5)
            this.GivingGift = true;
          else if (this.Selected == 6)
          {
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = "Confirm";
            this.PromptBar.UpdateButtons();
            this.CalculateAffection();
            this.DialogueLabel.text = this.Farewells[this.AffectionLevel];
            ++this.Phase;
          }
        }
      }
      else if (this.SelectingTopic)
      {
        this.Topics.localScale = Vector3.Lerp(this.Topics.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        if (this.InputManager.TappedUp)
        {
          --this.Row;
          this.UpdateTopicHighlight();
        }
        else if (this.InputManager.TappedDown)
        {
          ++this.Row;
          this.UpdateTopicHighlight();
        }
        if (this.InputManager.TappedLeft)
        {
          --this.Column;
          this.UpdateTopicHighlight();
        }
        else if (this.InputManager.TappedRight)
        {
          ++this.Column;
          this.UpdateTopicHighlight();
        }
        if (Input.GetButtonDown("A") && (double) this.TopicIcons[this.TopicSelected].color.a == 1.0)
        {
          this.SelectingTopic = false;
          UISprite topicIcon = this.TopicIcons[this.TopicSelected];
          topicIcon.color = new Color(topicIcon.color.r, topicIcon.color.g, topicIcon.color.b, 0.5f);
          this.TopicsDiscussed[this.TopicSelected] = true;
          this.DetermineOpinion();
          if (!this.Yandere.StudentManager.GetTopicLearnedByStudent(this.Opinion, this.LoveManager.RivalID))
            this.Yandere.StudentManager.SetTopicLearnedByStudent(this.Opinion, this.LoveManager.RivalID, true);
          if (this.Negative)
          {
            UILabel label = this.Labels[1];
            label.color = new Color(label.color.r, label.color.g, label.color.b, 0.5f);
            if (this.Opinion == 2)
            {
              this.DialogueLabel.text = "Hey! Just so you know, I take offense to that...";
              this.Rival.CharacterAnimation.CrossFade("f02_refuse_00");
              this.CurrentAnim = "f02_refuse_00";
              --this.Affection;
              this.CalculateAffection();
            }
            else if (this.Opinion == 1)
            {
              this.DialogueLabel.text = this.Negatives[this.AffectionLevel];
              this.Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
              this.CurrentAnim = "f02_lookdown_00";
              this.Affection += (float) this.Multiplier;
              this.CalculateAffection();
            }
            else if (this.Opinion == 0)
              this.DialogueLabel.text = "Um...okay.";
          }
          else
          {
            UILabel label = this.Labels[2];
            label.color = new Color(label.color.r, label.color.g, label.color.b, 0.5f);
            if (this.Opinion == 2)
            {
              this.DialogueLabel.text = this.Positives[this.AffectionLevel];
              this.Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
              this.CurrentAnim = "f02_lookdown_00";
              this.Affection += (float) this.Multiplier;
              this.CalculateAffection();
            }
            else if (this.Opinion == 1)
            {
              this.DialogueLabel.text = "To be honest with you, I strongly disagree...";
              this.Rival.CharacterAnimation.CrossFade("f02_refuse_00");
              this.CurrentAnim = "f02_refuse_00";
              --this.Affection;
              this.CalculateAffection();
            }
            else if (this.Opinion == 0)
              this.DialogueLabel.text = "Um...all right.";
          }
          if ((double) this.Affection > 100.0)
            this.Affection = 100f;
          else if ((double) this.Affection < 0.0)
            this.Affection = 0.0f;
        }
        if (Input.GetButtonDown("B"))
          this.SelectingTopic = false;
      }
      else if (this.Complimenting)
      {
        this.ComplimentSet.localScale = Vector3.Lerp(this.ComplimentSet.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        if (this.InputManager.TappedUp)
        {
          --this.Line;
          this.UpdateComplimentHighlight();
        }
        else if (this.InputManager.TappedDown)
        {
          ++this.Line;
          this.UpdateComplimentHighlight();
        }
        if (this.InputManager.TappedLeft)
        {
          --this.Side;
          this.UpdateComplimentHighlight();
        }
        else if (this.InputManager.TappedRight)
        {
          ++this.Side;
          this.UpdateComplimentHighlight();
        }
        if (Input.GetButtonDown("A") && (double) this.ComplimentLabels[this.ComplimentSelected].color.a == 1.0)
        {
          UILabel label = this.Labels[3];
          label.color = new Color(label.color.r, label.color.g, label.color.b, 0.5f);
          this.Complimenting = false;
          this.DialogueLabel.text = this.Compliments[this.ComplimentSelected];
          this.ComplimentsGiven[this.ComplimentSelected] = true;
          if (this.ComplimentSelected == 1 || this.ComplimentSelected == 4 || this.ComplimentSelected == 5 || this.ComplimentSelected == 8 || this.ComplimentSelected == 9)
          {
            this.Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
            this.CurrentAnim = "f02_lookdown_00";
            this.Affection += (float) this.Multiplier;
            this.CalculateAffection();
          }
          else
          {
            this.Rival.CharacterAnimation.CrossFade("f02_refuse_00");
            this.CurrentAnim = "f02_refuse_00";
            --this.Affection;
            this.CalculateAffection();
          }
          if ((double) this.Affection > 100.0)
            this.Affection = 100f;
          else if ((double) this.Affection < 0.0)
            this.Affection = 0.0f;
        }
        if (Input.GetButtonDown("B"))
          this.Complimenting = false;
      }
      else if (this.ShowingOff)
      {
        this.ShowOff.localScale = Vector3.Lerp(this.ShowOff.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        if (this.InputManager.TappedUp)
        {
          --this.TraitSelected;
          this.UpdateTraitHighlight();
        }
        else if (this.InputManager.TappedDown)
        {
          ++this.TraitSelected;
          this.UpdateTraitHighlight();
        }
        if (Input.GetButtonDown("A"))
        {
          UILabel label = this.Labels[4];
          label.color = new Color(label.color.r, label.color.g, label.color.b, 0.5f);
          this.ShowingOff = false;
          if (this.TraitSelected == 2)
          {
            Debug.Log((object) ("Wisdom trait is " + this.WisdomTrait.ToString() + ". Wisdom Demonstrated is " + this.WisdomTraitDemonstrated.ToString() + "."));
            if (this.WisdomTrait > this.WisdomTraitDemonstrated)
            {
              ++this.WisdomTraitDemonstrated;
              this.DialogueLabel.text = this.ShowOffs[this.AffectionLevel];
              this.Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
              this.CurrentAnim = "f02_lookdown_00";
              this.Affection += (float) this.Multiplier;
              this.CalculateAffection();
            }
            else if (this.WisdomTrait == 0)
              this.DialogueLabel.text = "Uh...that doesn't sound correct...";
            else if (this.WisdomTrait == this.WisdomTraitDemonstrated)
              this.DialogueLabel.text = "Uh...you already told me about that...";
          }
          else
            this.DialogueLabel.text = "Um...well...that sort of thing doesn't really matter to me...";
          if ((double) this.Affection > 100.0)
            this.Affection = 100f;
          else if ((double) this.Affection < 0.0)
            this.Affection = 0.0f;
        }
        if (Input.GetButtonDown("B"))
          this.ShowingOff = false;
      }
      else if (this.GivingGift)
      {
        this.GiveGift.localScale = Vector3.Lerp(this.GiveGift.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        if (this.InputManager.TappedUp)
        {
          --this.GiftRow;
          this.UpdateGiftHighlight();
        }
        else if (this.InputManager.TappedDown)
        {
          ++this.GiftRow;
          this.UpdateGiftHighlight();
        }
        if (this.InputManager.TappedLeft)
        {
          --this.GiftColumn;
          this.UpdateGiftHighlight();
        }
        else if (this.InputManager.TappedRight)
        {
          ++this.GiftColumn;
          this.UpdateGiftHighlight();
        }
        if (Input.GetButtonDown("A"))
        {
          if (this.GiftIcons[this.GiftSelected].enabled)
          {
            this.GiftStatusNeedsSaving = true;
            this.GiftsPurchased[this.GiftSelected] = false;
            this.GiftsGiven[this.GiftSelected] = true;
            this.Rival.Cosmetic.CatGifts[this.GiftSelected].SetActive(true);
            UILabel label = this.Labels[5];
            label.color = new Color(label.color.r, label.color.g, label.color.b, 0.5f);
            this.GivingGift = false;
            this.DialogueLabel.text = this.GiveGifts[this.GiftSelected];
            this.Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
            this.CurrentAnim = "f02_lookdown_00";
            this.Affection += (float) this.Multiplier;
            this.CalculateAffection();
          }
          if ((double) this.Affection > 100.0)
            this.Affection = 100f;
          else if ((double) this.Affection < 0.0)
            this.Affection = 0.0f;
        }
        if (Input.GetButtonDown("B"))
          this.GivingGift = false;
      }
    }
    else if (this.Phase == 5)
    {
      this.Speed += Time.deltaTime * 100f;
      this.AffectionSet.localPosition = new Vector3(this.AffectionSet.localPosition.x, this.AffectionSet.localPosition.y + this.Speed, this.AffectionSet.localPosition.z);
      this.OptionSet.localPosition = new Vector3(this.OptionSet.localPosition.x + this.Speed, this.OptionSet.localPosition.y, this.OptionSet.localPosition.z);
      if ((double) this.Speed > 100.0 && Input.GetButtonDown("A"))
        ++this.Phase;
    }
    else if (this.Phase == 6)
    {
      this.DatingSimHUD.alpha = Mathf.MoveTowards(this.DatingSimHUD.alpha, 0.0f, Time.deltaTime);
      if ((double) this.DatingSimHUD.alpha == 0.0)
      {
        this.DatingSimHUD.gameObject.SetActive(false);
        ++this.Phase;
      }
    }
    else if (this.Phase == 7)
    {
      if ((double) this.Panel.alpha == 0.0)
      {
        Debug.Log((object) "The rival and suitor are now being released from the dating minigame.");
        this.Yandere.CameraEffects.UpdateDOF(2f);
        this.Suitor.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
        this.LoveManager.RivalWaiting = false;
        this.LoveManager.Courted = true;
        this.Suitor.enabled = true;
        this.Rival.enabled = true;
        this.Suitor.CurrentDestination = this.Suitor.Destinations[this.Suitor.Phase];
        this.Suitor.Pathfinding.target = this.Suitor.Destinations[this.Suitor.Phase];
        this.Suitor.Prompt.Label[0].text = "     Talk";
        this.Suitor.Pathfinding.canSearch = true;
        this.Suitor.Pathfinding.canMove = true;
        this.Suitor.Pushable = false;
        this.Suitor.Meeting = false;
        this.Suitor.Routine = true;
        this.Suitor.MeetTimer = 0.0f;
        this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0.0f);
        this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
        this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
        this.Rival.CharacterAnimation["f02_smile_00"].weight = 0.0f;
        this.Rival.Prompt.Label[0].text = "     Talk";
        this.Rival.Pathfinding.canSearch = true;
        this.Rival.Pathfinding.canMove = true;
        this.Rival.DistanceToDestination = 100f;
        this.Rival.Pushable = false;
        this.Rival.Meeting = false;
        this.Rival.Routine = true;
        this.Rival.MeetTimer = 0.0f;
        this.StudentManager.Clock.StopTime = false;
        this.Yandere.RPGCamera.enabled = true;
        this.Suitor.Earpiece.SetActive(false);
        this.HeartbeatCamera.SetActive(true);
        this.Yandere.Headset.SetActive(false);
        if (this.AffectionLevel == 5)
          this.LoveManager.ConfessToSuitor = true;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
        if ((Object) this.StudentManager.Students[10] != (Object) null && (Object) this.StudentManager.Students[10].FollowTarget != (Object) null)
        {
          this.StudentManager.Students[10].CurrentDestination = this.StudentManager.Students[10].FollowTarget.transform;
          this.StudentManager.Students[10].Pathfinding.target = this.StudentManager.Students[10].FollowTarget.transform;
        }
        this.DataNeedsSaving = true;
      }
      else if ((double) this.Panel.alpha == 1.0)
      {
        this.Matchmaking = false;
        this.Yandere.CanMove = true;
        this.gameObject.SetActive(false);
      }
      this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 1f, Time.deltaTime);
    }
    if (this.Yandere.NoDebug)
      return;
    if (Input.GetKeyDown(KeyCode.Space))
    {
      this.Yandere.CharacterAnimation["f02_treePeeking_00"].time = 0.0f;
      this.Yandere.CharacterAnimation.Play("f02_treePeeking_00");
      this.MainCamera.transform.position = new Vector3(48f, 3f, -44f);
      this.MainCamera.transform.eulerAngles = new Vector3(15f, 90f, 0.0f);
      this.Rival.transform.eulerAngles = new Vector3(this.Rival.transform.eulerAngles.x, 90f, this.Rival.transform.eulerAngles.z);
      this.Rival.CharacterAnimation.Play(this.Rival.IdleAnim);
      this.Rival.CharacterAnimation["f02_turnAround_00"].speed = 1f;
      DatingGlobals.SetComplimentGiven(1, false);
      DatingGlobals.SetComplimentGiven(4, false);
      DatingGlobals.SetComplimentGiven(5, false);
      DatingGlobals.SetComplimentGiven(8, false);
      DatingGlobals.SetComplimentGiven(9, false);
      DatingGlobals.SetTraitDemonstrated(2, 0);
      DatingGlobals.AffectionLevel = 0.0f;
      DatingGlobals.Affection = 0.0f;
      this.AffectionBar.localScale = new Vector3(0.0f, this.AffectionBar.localScale.y, this.AffectionBar.localScale.z);
      this.AffectionLevel = 0;
      this.Affection = 0.0f;
      for (int index = 1; index < 6; ++index)
      {
        UILabel label = this.Labels[index];
        label.color = new Color(label.color.r, label.color.g, label.color.b, 1f);
      }
      this.Phase = 1;
      this.Timer = 0.0f;
      for (int topicID = 1; topicID < 26; ++topicID)
      {
        DatingGlobals.SetTopicDiscussed(topicID, false);
        UISprite topicIcon = this.TopicIcons[topicID];
        topicIcon.color = new Color(topicIcon.color.r, topicIcon.color.g, topicIcon.color.b, 1f);
      }
      this.UpdateTopics();
    }
    if (Input.GetKeyDown("="))
      ++Time.timeScale;
    if (!Input.GetKeyDown(KeyCode.LeftControl))
      return;
    this.Affection += 10f;
    this.CalculateAffection();
    this.DialogueLabel.text = this.Greetings[this.AffectionLevel];
  }

  private void LateUpdate()
  {
    int phase = this.Phase;
  }

  private void CalculateMultiplier()
  {
    this.Multiplier = 5;
    if (!this.Suitor.Cosmetic.MaleHair[55].activeInHierarchy)
    {
      this.MultiplierIcons[1].mainTexture = this.X;
      --this.Multiplier;
    }
    if (!this.Suitor.Cosmetic.MaleAccessories[17].activeInHierarchy)
    {
      this.MultiplierIcons[2].mainTexture = this.X;
      --this.Multiplier;
    }
    if (!this.Suitor.Cosmetic.Eyewear[6].activeInHierarchy)
    {
      this.MultiplierIcons[3].mainTexture = this.X;
      --this.Multiplier;
    }
    if (this.Suitor.Cosmetic.SkinColor != 6)
    {
      this.MultiplierIcons[4].mainTexture = this.X;
      --this.Multiplier;
    }
    if (PlayerGlobals.PantiesEquipped == 2)
    {
      this.PantyIcon.SetActive(true);
      ++this.Multiplier;
    }
    else
      this.PantyIcon.SetActive(false);
    if (this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 0)
    {
      this.SeductionLabel.text = (this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus).ToString();
      this.Multiplier += this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus;
      this.SeductionIcon.SetActive(true);
    }
    else
      this.SeductionIcon.SetActive(false);
    this.Multiplier += this.Yandere.Class.PsychologyGrade + this.Yandere.Class.PsychologyBonus;
    this.MultiplierLabel.text = "Multiplier: " + this.Multiplier.ToString() + "x";
  }

  private void UpdateHighlight()
  {
    if (this.Selected < 1)
      this.Selected = 6;
    else if (this.Selected > 6)
      this.Selected = 1;
    this.HighlightTarget = (float) (450.0 - 100.0 * (double) this.Selected);
  }

  private void UpdateTopicHighlight()
  {
    if (this.Row < 1)
      this.Row = 5;
    else if (this.Row > 5)
      this.Row = 1;
    if (this.Column < 1)
      this.Column = 5;
    else if (this.Column > 5)
      this.Column = 1;
    this.TopicHighlight.localPosition = new Vector3((float) (125 * this.Column - 375), (float) (375 - 125 * this.Row), this.TopicHighlight.localPosition.z);
    this.TopicSelected = (this.Row - 1) * 5 + this.Column;
    this.TopicNameLabel.text = ConversationGlobals.GetTopicDiscovered(this.TopicSelected) ? this.TopicNames[this.TopicSelected] : "??????????";
  }

  private void DetermineOpinion() => this.Opinion = this.JSON.Topics[this.LoveManager.RivalID].Topics[this.TopicSelected];

  private void UpdateTopics()
  {
    for (int topicID = 1; topicID < this.TopicIcons.Length; ++topicID)
    {
      UISprite topicIcon = this.TopicIcons[topicID];
      if (!ConversationGlobals.GetTopicDiscovered(topicID))
      {
        topicIcon.spriteName = 0.ToString();
        topicIcon.color = new Color(topicIcon.color.r, topicIcon.color.g, topicIcon.color.b, 0.5f);
      }
      else
        topicIcon.spriteName = topicID.ToString();
    }
    for (int Topic = 1; Topic <= 25; ++Topic)
    {
      UISprite opinionIcon = this.OpinionIcons[Topic];
      if (!this.StudentManager.GetTopicLearnedByStudent(Topic, this.LoveManager.RivalID))
      {
        opinionIcon.spriteName = "Unknown";
      }
      else
      {
        int[] topics = this.JSON.Topics[this.LoveManager.RivalID].Topics;
        opinionIcon.spriteName = this.OpinionSpriteNames[topics[Topic]];
      }
    }
  }

  private void UpdateComplimentHighlight()
  {
    for (int index = 1; index < this.TopicIcons.Length; ++index)
      this.ComplimentBGs[this.ComplimentSelected].color = this.OriginalColor;
    if (this.Line < 1)
      this.Line = 5;
    else if (this.Line > 5)
      this.Line = 1;
    if (this.Side < 1)
      this.Side = 2;
    else if (this.Side > 2)
      this.Side = 1;
    this.ComplimentSelected = (this.Line - 1) * 2 + this.Side;
    this.ComplimentBGs[this.ComplimentSelected].color = Color.white;
  }

  private void UpdateTraitHighlight()
  {
    if (this.TraitSelected < 1)
      this.TraitSelected = 3;
    else if (this.TraitSelected > 3)
      this.TraitSelected = 1;
    for (int index = 1; index < this.TraitBGs.Length; ++index)
      this.TraitBGs[index].color = this.OriginalColor;
    this.TraitBGs[this.TraitSelected].color = Color.white;
  }

  private void UpdateGiftHighlight()
  {
    for (int index = 1; index < this.GiftBGs.Length; ++index)
      this.GiftBGs[index].color = this.OriginalColor;
    if (this.GiftRow < 1)
      this.GiftRow = 2;
    else if (this.GiftRow > 2)
      this.GiftRow = 1;
    if (this.GiftColumn < 1)
      this.GiftColumn = 2;
    else if (this.GiftColumn > 2)
      this.GiftColumn = 1;
    this.GiftSelected = (this.GiftRow - 1) * 2 + this.GiftColumn;
    this.GiftBGs[this.GiftSelected].color = Color.white;
  }

  public void SaveTopicsAndCompliments()
  {
    Debug.Log((object) "Saving Dating Minigame data.");
    for (int topicID = 1; topicID < 26; ++topicID)
      DatingGlobals.SetTopicDiscussed(topicID, this.TopicsDiscussed[topicID]);
    for (int complimentID = 1; complimentID < 11; ++complimentID)
      DatingGlobals.SetComplimentGiven(complimentID, this.ComplimentsGiven[complimentID]);
    DatingGlobals.SetTraitDemonstrated(1, this.CourageTraitDemonstrated);
    DatingGlobals.SetTraitDemonstrated(2, this.WisdomTraitDemonstrated);
    DatingGlobals.SetTraitDemonstrated(3, this.StrengthTraitDemonstrated);
    DatingGlobals.SetSuitorTrait(1, this.CourageTrait);
    DatingGlobals.SetSuitorTrait(2, this.WisdomTrait);
    DatingGlobals.SetSuitorTrait(3, this.StrengthTrait);
    DatingGlobals.Affection = this.Affection;
  }

  public void SaveGiftStatus()
  {
    Debug.Log((object) "Saving Dating Minigame gift status.");
    for (int giftID = 1; giftID < 5; ++giftID)
    {
      CollectibleGlobals.SetGiftPurchased(giftID + 5, this.GiftsPurchased[giftID]);
      CollectibleGlobals.SetGiftGiven(giftID, this.GiftsGiven[giftID]);
    }
  }
}
