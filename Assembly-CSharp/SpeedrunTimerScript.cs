// Decompiled with JetBrains decompiler
// Type: SpeedrunTimerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpeedrunTimerScript : MonoBehaviour
{
  public PoliceScript Police;
  public UILabel Label;
  public float Timer;

  private void Start() => this.Label.enabled = false;

  private void Update()
  {
    if (this.Police.FadeOut)
      return;
    this.Timer += Time.unscaledDeltaTime;
    if (this.Label.enabled)
      this.Label.text = this.FormatTime(this.Timer) ?? "";
    if (!Input.GetKeyDown(KeyCode.Delete))
      return;
    this.Label.enabled = !this.Label.enabled;
  }

  private string FormatTime(float time)
  {
    int num = (int) time;
    return string.Format("{0:00}:{1:00}:{2:000}", (object) (num / 60), (object) (num % 60), (object) (time * 1000f % 1000f));
  }
}
