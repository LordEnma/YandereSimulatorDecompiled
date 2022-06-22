// Decompiled with JetBrains decompiler
// Type: BountyMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
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
