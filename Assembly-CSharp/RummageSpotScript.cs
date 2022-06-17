// Decompiled with JetBrains decompiler
// Type: RummageSpotScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class RummageSpotScript : MonoBehaviour
{
  public GameObject AlarmDisc;
  public DoorGapScript DoorGap;
  public SchemesScript Schemes;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public ClockScript Clock;
  public Transform Target;
  public int Phase;
  public int ID;

  private void Start()
  {
    if (this.ID != 1)
      return;
    if (GameGlobals.AnswerSheetUnavailable)
    {
      Debug.Log((object) "The answer sheet is no longer available, due to events on a previous day.");
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.gameObject.SetActive(false);
    }
    else
    {
      if (DateGlobals.Weekday != DayOfWeek.Friday || (double) this.Clock.HourTime <= 13.5)
        return;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.gameObject.SetActive(false);
    }
  }

  private void Update()
  {
    AudioSource component = this.GetComponent<AudioSource>();
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
      {
        this.Yandere.EmptyHands();
        this.Yandere.CharacterAnimation.CrossFade("f02_rummage_00");
        this.Yandere.ProgressBar.transform.parent.gameObject.SetActive(true);
        this.Yandere.RummageSpot = this;
        this.Yandere.Rummaging = true;
        this.Yandere.CanMove = false;
        component.Play();
      }
    }
    if (this.Yandere.Rummaging)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.transform.position, Quaternion.identity);
      gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
      gameObject.transform.localScale = new Vector3(750f, gameObject.transform.localScale.y, 750f);
    }
    if (!this.Yandere.Noticed)
      return;
    component.Stop();
  }

  public void GetReward()
  {
    if (this.ID != 1)
      return;
    if (this.Phase == 1)
    {
      SchemeGlobals.SetSchemeStage(5, 5);
      this.Schemes.UpdateInstructions();
      this.Yandere.Inventory.AnswerSheet = true;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.DoorGap.Prompt.enabled = true;
      ++this.Phase;
    }
    else
    {
      if (this.Phase != 2)
        return;
      SchemeGlobals.SetSchemeStage(5, 8);
      this.Schemes.UpdateInstructions();
      this.Prompt.Yandere.Inventory.AnswerSheet = false;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.gameObject.SetActive(false);
      ++this.Phase;
    }
  }
}
