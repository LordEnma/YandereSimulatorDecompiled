// Decompiled with JetBrains decompiler
// Type: DoorGapScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DoorGapScript : MonoBehaviour
{
  public RummageSpotScript RummageSpot;
  public SchemesScript Schemes;
  public PromptScript Prompt;
  public Transform[] Papers;
  public bool[] PhoneHacked;
  public bool StolenPhoneDropoff;
  public float Timer;
  public int Phase = 1;

  private void Start() => this.Papers[1].gameObject.SetActive(false);

  private void Update()
  {
    if (!this.StolenPhoneDropoff)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        if (this.Phase == 1)
        {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
          this.Prompt.Yandere.Inventory.AnswerSheet = false;
          this.Papers[1].gameObject.SetActive(true);
          SchemeGlobals.SetSchemeStage(5, 6);
          this.Schemes.UpdateInstructions();
          this.GetComponent<AudioSource>().Play();
        }
        else
        {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
          this.Prompt.Yandere.Inventory.AnswerSheet = true;
          this.Prompt.Yandere.Inventory.DuplicateSheet = true;
          this.Papers[2].gameObject.SetActive(false);
          this.RummageSpot.Prompt.Label[0].text = "     Return Answer Sheet";
          this.RummageSpot.Prompt.enabled = true;
          SchemeGlobals.SetSchemeStage(5, 7);
          this.Schemes.UpdateInstructions();
        }
        ++this.Phase;
      }
      if (this.Phase != 2)
        return;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 4.0)
      {
        this.Prompt.Label[0].text = "     Pick Up Sheets";
        this.Prompt.enabled = true;
        this.Phase = 2;
      }
      else if ((double) this.Timer > 3.0)
      {
        Transform paper = this.Papers[2];
        paper.localPosition = new Vector3(paper.localPosition.x, paper.localPosition.y, Mathf.Lerp(paper.localPosition.z, -0.166f, Time.deltaTime * 10f));
      }
      else
      {
        if ((double) this.Timer <= 1.0)
          return;
        Transform paper = this.Papers[1];
        paper.localPosition = new Vector3(paper.localPosition.x, paper.localPosition.y, Mathf.Lerp(paper.localPosition.z, 0.166f, Time.deltaTime * 10f));
      }
    }
    else
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        if (this.Phase == 1)
        {
          if (StudentGlobals.GetStudentPhoneStolen(this.Prompt.Yandere.StudentManager.CommunalLocker.RivalPhone.StudentID))
          {
            this.Prompt.Yandere.NotificationManager.CustomText = "Info-chan doesn't need this phone";
            this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
          else
          {
            this.Prompt.Hide();
            this.Prompt.enabled = false;
            this.Prompt.Yandere.Inventory.RivalPhone = false;
            this.Prompt.Yandere.RivalPhone = false;
            this.PhoneHacked[this.Prompt.Yandere.StudentManager.CommunalLocker.RivalPhone.StudentID] = true;
            this.Prompt.Yandere.Inventory.PantyShots += 20;
            this.Prompt.Yandere.NotificationManager.CustomText = "+20 Info Points! You have " + this.Prompt.Yandere.Inventory.PantyShots.ToString() + " in total";
            this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            this.Papers[1].gameObject.SetActive(true);
            this.GetComponent<AudioSource>().Play();
            ++this.Phase;
          }
        }
        else if (this.Phase == 2)
        {
          this.Prompt.Yandere.Inventory.RivalPhone = true;
          this.Papers[1].gameObject.SetActive(false);
          this.Prompt.Hide();
          this.Prompt.enabled = false;
          ++this.Phase;
        }
      }
      if (this.Phase != 2)
        return;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 4.0)
      {
        this.Prompt.Label[0].text = "     Pick Up Phone";
        this.Prompt.enabled = true;
      }
      else if ((double) this.Timer > 3.0)
      {
        this.Papers[1].localPosition = new Vector3(this.Papers[1].localPosition.x, this.Papers[1].localPosition.y, Mathf.Lerp(this.Papers[1].localPosition.z, -0.166f, Time.deltaTime * 10f));
      }
      else
      {
        if ((double) this.Timer <= 1.0)
          return;
        this.Papers[1].localPosition = new Vector3(this.Papers[1].localPosition.x, this.Papers[1].localPosition.y, Mathf.Lerp(this.Papers[1].localPosition.z, 0.166f, Time.deltaTime * 10f));
      }
    }
  }

  public void SetPhonesHacked()
  {
    for (int studentID = 1; studentID < 101; ++studentID)
    {
      if (this.PhoneHacked[studentID])
        StudentGlobals.SetStudentPhoneStolen(studentID, true);
    }
  }
}
