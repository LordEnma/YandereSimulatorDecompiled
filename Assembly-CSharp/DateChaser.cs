// Decompiled with JetBrains decompiler
// Type: DateChaser
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class DateChaser : MonoBehaviour
{
  public int CurrentDate;
  public string CurrentTimeString;
  [Header("Epoch timestamps")]
  [SerializeField]
  private int startDate = 1581724799;
  [SerializeField]
  private int endDate = 1421366399;
  [Space(5f)]
  [Header("Settings")]
  [SerializeField]
  private float generalDuration = 10f;
  [SerializeField]
  private AnimationCurve curve;
  public bool Animate;
  private float startTime;
  private string[] monthNames = new string[12]
  {
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December"
  };
  private int lastFrameDay;
  private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
  public UILabel Label;
  public float Timer;
  public int Stage;

  private static DateTime fromUnix(long unix) => DateChaser.epoch.AddSeconds((double) unix);

  private void Start()
  {
    Application.targetFrameRate = 60;
    Time.timeScale = 1f;
  }

  private void Update()
  {
    if (this.Animate)
    {
      this.CurrentDate = (int) Mathf.Lerp((float) this.startDate, (float) this.endDate, this.curve.Evaluate((Time.time - this.startTime) / this.generalDuration));
      DateTime dateTime = DateChaser.fromUnix((long) this.CurrentDate);
      string str = dateTime.Day == 22 || dateTime.Day == 2 ? "nd" : (dateTime.Day == 3 ? "rd" : (dateTime.Day == 1 ? "st" : "th"));
      this.CurrentTimeString = string.Format("{0} {1}{2}, {3}", (object) this.monthNames[dateTime.Month - 1], (object) dateTime.Day, (object) str, (object) dateTime.Year);
      if (this.lastFrameDay != dateTime.Day)
        this.onDayTick(dateTime.Day);
      this.lastFrameDay = dateTime.Day;
      this.Timer += Time.deltaTime;
    }
    else
    {
      this.startTime = Time.time;
      this.CurrentDate = this.startDate;
    }
  }

  private void onDayTick(int day) => this.Label.text = this.CurrentTimeString;
}
