// Decompiled with JetBrains decompiler
// Type: BountyMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BountyMenuScript : MonoBehaviour
{
  public ClockScript Clock;
  public UITexture Portrait;
  public UILabel DescLabel;
  public string[] Descriptions;
  public int[] StudentIDs;

  private void Start()
  {
    this.DescLabel.text = this.Descriptions[this.Clock.Day];
    this.GetPortrait(this.StudentIDs[this.Clock.Day]);
  }

  private void Update() => this.DescLabel.text = this.DescLabel.text.Replace('@', '\n');

  private void GetPortrait(int ID) => this.Portrait.mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + ID.ToString() + ".png").texture;
}
