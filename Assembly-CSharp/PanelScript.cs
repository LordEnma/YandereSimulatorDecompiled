// Decompiled with JetBrains decompiler
// Type: PanelScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PanelScript : MonoBehaviour
{
  public UILabel BuildingLabel;
  public DoorBoxScript DoorBox;
  public Transform Player;
  public string Floor = string.Empty;
  public float PracticeBuildingZ;
  public float StairsZ;
  public float Floor1Height;
  public float Floor2Height;
  public float Floor3Height;

  private void Update()
  {
    this.Floor = (double) this.Player.position.z > (double) this.StairsZ || (double) this.Player.position.z < -(double) this.StairsZ ? "Stairs" : ((double) this.Player.position.y >= (double) this.Floor1Height ? ((double) this.Player.position.y <= (double) this.Floor1Height || (double) this.Player.position.y >= (double) this.Floor2Height ? ((double) this.Player.position.y <= (double) this.Floor2Height || (double) this.Player.position.y >= (double) this.Floor3Height ? "Rooftop" : "Third Floor") : "Second Floor") : "First Floor");
    this.BuildingLabel.text = (double) this.Player.position.z >= (double) this.PracticeBuildingZ ? "Classroom Building, " + this.Floor : "Practice Building, " + this.Floor;
    this.DoorBox.Show = false;
  }
}
