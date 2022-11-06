// Decompiled with JetBrains decompiler
// Type: CountdownTimerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CountdownTimerScript : MonoBehaviour
{
  public UILabel CountdownLabel;
  public float Timer;

  private void Update()
  {
    this.Timer = Mathf.MoveTowards(this.Timer, 0.0f, Time.deltaTime);
    this.DisplayTime(this.Timer);
  }

  private void DisplayTime(float timeToDisplay) => this.CountdownLabel.text = string.Format("{0:0}:{1:00}", (object) (float) Mathf.FloorToInt(timeToDisplay / 60f), (object) (float) Mathf.FloorToInt(timeToDisplay % 60f));
}
