// Decompiled with JetBrains decompiler
// Type: TopicInterfaceScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TopicInterfaceScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public InputManagerScript InputManager;
  public StudentScript TargetStudent;
  public StudentScript Student;
  public YandereScript Yandere;
  public JsonScript JSON;
  public GameObject NegativeRemark;
  public GameObject PositiveRemark;
  public GameObject EmbarassingSecret;
  public Transform TopicHighlight;
  public UISprite[] OpinionIcons;
  public UILabel EmbarassingLabel;
  public UILabel Label;
  public int TopicSelected;
  public int Opinion;
  public int Column;
  public int Row;
  public bool Socializing;
  public bool Positive;
  public bool Success;
  public string[] OpinionSpriteNames;
  public string[] TopicNames;
  public string Statement;
  public string LoveHate;
  public int TargetStudentID = 1;
  public int StudentID = 1;

  private void Start()
  {
    if ((Object) this.Student == (Object) null)
      this.gameObject.SetActive(false);
    if (!GameGlobals.Eighties)
      return;
    this.EmbarassingLabel.text = "(You will also mention the embarassing information you found in her diary.)";
    this.TopicNames[14] = "jokes";
  }

  private void Update()
  {
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
    if (Input.GetButtonDown("A"))
    {
      if (this.Socializing)
      {
        this.Yandere.Interaction = YandereInteractionType.Compliment;
        this.Yandere.TalkTimer = 5f;
      }
      else
      {
        this.Yandere.Interaction = YandereInteractionType.Gossip;
        this.Yandere.TalkTimer = 5f;
      }
      this.Yandere.PromptBar.Show = false;
      this.gameObject.SetActive(false);
      Time.timeScale = 1f;
    }
    else if (Input.GetButtonDown("X"))
    {
      this.Positive = !this.Positive;
      this.UpdateTopicHighlight();
    }
    else
    {
      if (!Input.GetButtonDown("B"))
        return;
      this.Yandere.Interaction = YandereInteractionType.Bye;
      this.Yandere.TalkTimer = 2f;
      this.Yandere.PromptBar.Show = false;
      this.gameObject.SetActive(false);
      Time.timeScale = 1f;
    }
  }

  public void UpdateTopicHighlight()
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
    this.DetermineOpinion();
    if (this.Socializing)
    {
      this.LoveHate = this.Positive ? "love" : "hate";
      this.Statement = "Hi, " + this.Student.Name + "! Gosh, I just really " + this.LoveHate + " " + this.TopicNames[this.TopicSelected] + ". Can you relate to that at all?";
      if (this.Positive && this.Opinion == 2 || !this.Positive && this.Opinion == 1)
        this.Success = true;
    }
    else
    {
      this.LoveHate = this.Positive ? "loves" : "hates";
      this.Statement = "Hey, " + this.Student.Name + "! Did you know that " + this.StudentManager.JSON.Students[this.TargetStudentID].Name + " really " + this.LoveHate + " " + this.TopicNames[this.TopicSelected] + "?";
      if (this.Positive && this.Opinion == 1 || !this.Positive && this.Opinion == 2)
        this.Success = true;
    }
    this.Label.text = this.Statement;
    this.EmbarassingSecret.SetActive(false);
    if (!this.Socializing && this.TargetStudentID == this.StudentManager.RivalID && this.StudentManager.EmbarassingSecret)
      this.EmbarassingSecret.SetActive(true);
    if (this.Positive)
    {
      this.NegativeRemark.SetActive(false);
      this.PositiveRemark.SetActive(true);
    }
    else
    {
      this.PositiveRemark.SetActive(false);
      this.NegativeRemark.SetActive(true);
    }
  }

  public void UpdateOpinions()
  {
    for (int Topic = 1; Topic <= 25; ++Topic)
    {
      UISprite opinionIcon = this.OpinionIcons[Topic];
      if (!this.StudentManager.GetTopicLearnedByStudent(Topic, this.StudentID))
      {
        opinionIcon.spriteName = "Unknown";
      }
      else
      {
        int[] topics = this.JSON.Topics[this.StudentID].Topics;
        opinionIcon.spriteName = this.OpinionSpriteNames[topics[Topic]];
      }
    }
  }

  private void DetermineOpinion()
  {
    this.Opinion = this.JSON.Topics[this.StudentID].Topics[this.TopicSelected];
    this.Success = false;
  }
}
