// Decompiled with JetBrains decompiler
// Type: ReputationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ReputationScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public ArmDetectorScript ArmDetector;
  public PortalScript Portal;
  public Transform CurrentRepMarker;
  public Transform PendingRepMarker;
  public UILabel PendingRepLabel;
  public UILabel RepUpdateLabel;
  public UILabel RepLabel;
  public ClockScript Clock;
  public float Reputation;
  public float LerpTimer;
  public float PreviousRep;
  public float PendingRep;
  public int CheckedRep = 1;
  public int Phase;
  public bool MissionMode;

  private void Start()
  {
    this.RepUpdateLabel.enabled = true;
    if (MissionModeGlobals.MissionMode)
    {
      this.RepUpdateLabel.enabled = false;
      this.MissionMode = true;
    }
    if (GameGlobals.Eighties)
      this.BecomeEighties();
    this.Reputation = PlayerGlobals.Reputation;
  }

  private void Update()
  {
    switch (this.Phase)
    {
      case 1:
        if ((double) this.Clock.PresentTime / 60.0 > 8.5)
        {
          ++this.Phase;
          break;
        }
        break;
      case 2:
        if ((double) this.Clock.PresentTime / 60.0 > 13.5)
        {
          ++this.Phase;
          break;
        }
        break;
      case 3:
        if ((double) this.Clock.PresentTime / 60.0 > 18.0)
        {
          this.RepUpdateLabel.text = "REP WILL UPDATE AFTER SCHOOL";
          ++this.Phase;
          break;
        }
        break;
    }
    if (this.CheckedRep < this.Phase && !this.StudentManager.Yandere.Struggling && !this.StudentManager.Yandere.DelinquentFighting && !this.StudentManager.Yandere.Pickpocketing && !this.StudentManager.Yandere.Noticed && !this.ArmDetector.SummonDemon)
    {
      this.UpdateRep();
      if ((double) this.Reputation <= -100.0)
        this.Portal.EndDay();
    }
    if (!this.MissionMode)
    {
      if ((double) this.LerpTimer < 1.0)
      {
        this.CurrentRepMarker.localPosition = new Vector3(Mathf.Lerp(this.CurrentRepMarker.localPosition.x, (float) ((double) this.Reputation * 1.5 - 830.0), Time.deltaTime * 10f), this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
        this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, this.CurrentRepMarker.transform.localPosition.x + this.PendingRep * 1.5f, Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
        this.LerpTimer += Time.deltaTime;
      }
      if ((double) this.PendingRep != (double) this.PreviousRep)
        this.UpdatePendingRepLabel();
    }
    else
    {
      this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, (float) ((double) this.PendingRep * -3.0 - 980.0), Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
      this.PendingRepLabel.text = (double) this.PendingRep >= 0.0 ? string.Empty : (-this.PendingRep).ToString("F1");
    }
    if ((double) this.CurrentRepMarker.localPosition.x < -980.0)
      this.CurrentRepMarker.localPosition = new Vector3(-980f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
    if ((double) this.PendingRepMarker.localPosition.x < -980.0)
      this.PendingRepMarker.localPosition = new Vector3(-980f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
    if ((double) this.CurrentRepMarker.localPosition.x > -680.0)
      this.CurrentRepMarker.localPosition = new Vector3(-680f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
    if ((double) this.PendingRepMarker.localPosition.x <= -680.0)
      return;
    this.PendingRepMarker.localPosition = new Vector3(-680f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
  }

  public void UpdateRep()
  {
    this.Reputation += this.PendingRep;
    this.PendingRep = 0.0f;
    ++this.CheckedRep;
    if (this.StudentManager.Yandere.Club == ClubType.Delinquent)
    {
      if ((double) this.Reputation > -33.333328247070313)
        this.Reputation = -33.33333f;
    }
    else if ((double) this.Reputation > 100.0)
      this.Reputation = 100f;
    this.StudentManager.WipePendingRep();
  }

  public void BecomeEighties()
  {
    this.StudentManager.EightiesifyLabel(this.PendingRepLabel);
    this.StudentManager.EightiesifyLabel(this.RepUpdateLabel);
    this.StudentManager.EightiesifyLabel(this.RepLabel);
  }

  public void UpdatePendingRepLabel()
  {
    this.PreviousRep = this.PendingRep;
    this.LerpTimer = 0.0f;
    if (!this.MissionMode)
      this.RepUpdateLabel.enabled = true;
    if ((double) this.PendingRep > 0.0)
      this.PendingRepLabel.text = "+" + this.PendingRep.ToString("F1");
    else if ((double) this.PendingRep < 0.0)
    {
      this.StudentManager.TutorialWindow.ShowRepMessage = true;
      this.PendingRepLabel.text = this.PendingRep.ToString("F1");
    }
    else
    {
      this.RepUpdateLabel.enabled = false;
      this.PendingRepLabel.text = string.Empty;
    }
  }
}
