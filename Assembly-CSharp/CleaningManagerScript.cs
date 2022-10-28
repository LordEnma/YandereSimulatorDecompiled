// Decompiled with JetBrains decompiler
// Type: CleaningManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CleaningManagerScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public Transform[] Windows;
  public Transform[] Desks;
  public Transform[] Floors;
  public Transform[] Toilets;
  public Transform[] Rooftops;
  public Transform[] ClappingSpots;
  public Transform Spot;
  public bool Eighties;
  public int Role;

  private void Start()
  {
    if (SchoolGlobals.RoofFence)
    {
      for (int index = 1; index < this.ClappingSpots.Length; ++index)
        this.ClappingSpots[index].transform.position = new Vector3(this.ClappingSpots[index].transform.position.x, this.ClappingSpots[index].transform.position.y, this.ClappingSpots[index].transform.position.z + 0.5f);
    }
    this.Eighties = GameGlobals.Eighties;
  }

  public void GetRole(int StudentID)
  {
    switch (StudentID)
    {
      case 1:
        this.Role = 4;
        this.Spot = this.Toilets[0];
        break;
      case 2:
        this.Role = 1;
        this.Spot = this.Windows[4];
        break;
      case 3:
        this.Role = 2;
        this.Spot = this.Desks[4];
        break;
      case 4:
        this.Role = 3;
        this.Spot = this.Floors[4];
        break;
      case 5:
        this.Role = 5;
        this.Spot = this.Rooftops[4];
        break;
      case 6:
        this.Role = 3;
        this.Spot = this.Floors[12];
        break;
      case 7:
        this.Role = 3;
        this.Spot = this.Floors[13];
        break;
      case 8:
        this.Role = 3;
        this.Spot = this.Floors[14];
        break;
      case 9:
        this.Role = 3;
        this.Spot = this.Floors[15];
        break;
      case 10:
        if (!this.Eighties)
        {
          if (!((Object) this.StudentManager.Students[11] != (Object) null))
            break;
          this.Role = 3;
          this.Spot = this.StudentManager.Students[11].transform;
          break;
        }
        this.Role = 3;
        this.Spot = this.Floors[45];
        break;
      case 11:
        this.Role = 3;
        this.Spot = this.Floors[35];
        break;
      case 12:
        this.Role = 3;
        this.Spot = this.Floors[36];
        break;
      case 13:
        this.Role = 3;
        this.Spot = this.Floors[37];
        break;
      case 14:
        this.Role = 3;
        this.Spot = this.Floors[38];
        break;
      case 15:
        this.Role = 3;
        this.Spot = this.Floors[39];
        break;
      case 16:
        this.Role = 3;
        this.Spot = this.Floors[40];
        break;
      case 17:
        this.Role = 3;
        this.Spot = this.Floors[41];
        break;
      case 18:
        this.Role = 3;
        this.Spot = this.Floors[42];
        break;
      case 19:
        this.Role = 3;
        this.Spot = this.Floors[43];
        break;
      case 20:
        this.Role = 3;
        this.Spot = this.Floors[44];
        break;
      case 21:
        this.Role = 1;
        this.Spot = this.Windows[6];
        break;
      case 22:
        this.Role = 1;
        this.Spot = this.Windows[5];
        break;
      case 23:
        this.Role = 1;
        this.Spot = this.Windows[3];
        break;
      case 24:
        this.Role = 1;
        this.Spot = this.Windows[2];
        break;
      case 25:
        this.Role = 1;
        this.Spot = this.Windows[1];
        break;
      case 26:
        this.Role = 2;
        this.Spot = this.Desks[6];
        break;
      case 27:
        this.Role = 2;
        this.Spot = this.Desks[5];
        break;
      case 28:
        this.Role = 2;
        this.Spot = this.Desks[3];
        break;
      case 29:
        this.Role = 2;
        this.Spot = this.Desks[2];
        break;
      case 30:
        this.Role = 2;
        this.Spot = this.Desks[1];
        break;
      case 31:
        this.Role = 3;
        this.Spot = this.Floors[6];
        break;
      case 32:
        this.Role = 3;
        this.Spot = this.Floors[5];
        break;
      case 33:
        this.Role = 3;
        this.Spot = this.Floors[3];
        break;
      case 34:
        this.Role = 3;
        this.Spot = this.Floors[2];
        break;
      case 35:
        this.Role = 3;
        this.Spot = this.Floors[1];
        break;
      case 36:
        this.Role = 3;
        this.Spot = this.Floors[7];
        break;
      case 37:
        this.Role = 3;
        this.Spot = this.Floors[8];
        break;
      case 38:
        this.Role = 3;
        this.Spot = this.Floors[9];
        break;
      case 39:
        this.Role = 3;
        this.Spot = this.Floors[10];
        break;
      case 40:
        this.Role = 3;
        this.Spot = this.Floors[11];
        break;
      case 41:
        this.Role = 5;
        this.Spot = this.Rooftops[6];
        break;
      case 42:
        this.Role = 5;
        this.Spot = this.Rooftops[5];
        break;
      case 43:
        this.Role = 5;
        this.Spot = this.Rooftops[3];
        break;
      case 44:
        this.Role = 5;
        this.Spot = this.Rooftops[2];
        break;
      case 45:
        this.Role = 5;
        this.Spot = this.Rooftops[1];
        break;
      case 46:
        this.Role = 4;
        this.Spot = this.Toilets[1];
        break;
      case 47:
        this.Role = 4;
        this.Spot = this.Toilets[2];
        break;
      case 48:
        this.Role = 4;
        this.Spot = this.Toilets[3];
        break;
      case 49:
        this.Role = 3;
        this.Spot = this.Floors[16];
        break;
      case 50:
        this.Role = 3;
        this.Spot = this.Floors[17];
        break;
      case 51:
        this.Role = 4;
        this.Spot = this.Toilets[7];
        break;
      case 52:
        this.Role = 4;
        this.Spot = this.Toilets[8];
        break;
      case 53:
        this.Role = 4;
        this.Spot = this.Toilets[9];
        break;
      case 54:
        this.Role = 4;
        this.Spot = this.Toilets[10];
        break;
      case 55:
        this.Role = 4;
        this.Spot = this.Toilets[11];
        break;
      case 56:
        this.Role = 4;
        this.Spot = this.Toilets[4];
        break;
      case 57:
        this.Role = 4;
        this.Spot = this.Toilets[5];
        break;
      case 58:
        this.Role = 4;
        this.Spot = this.Toilets[6];
        break;
      case 59:
        this.Role = 3;
        this.Spot = this.Floors[18];
        break;
      case 60:
        this.Role = 3;
        this.Spot = this.Floors[19];
        break;
      case 61:
        this.Role = 3;
        this.Spot = this.Floors[20];
        break;
      case 62:
        this.Role = 3;
        this.Spot = this.Floors[21];
        break;
      case 63:
        this.Role = 3;
        this.Spot = this.Floors[22];
        break;
      case 64:
        this.Role = 3;
        this.Spot = this.Floors[23];
        break;
      case 65:
        this.Role = 3;
        this.Spot = this.Floors[24];
        break;
      case 66:
        this.Role = 3;
        this.Spot = this.Floors[25];
        break;
      case 67:
        this.Role = 3;
        this.Spot = this.Floors[26];
        break;
      case 68:
        this.Role = 3;
        this.Spot = this.Floors[27];
        break;
      case 69:
        this.Role = 3;
        this.Spot = this.Floors[28];
        break;
      case 70:
        this.Role = 3;
        this.Spot = this.Floors[29];
        break;
      case 71:
        this.Role = 3;
        this.Spot = this.Floors[30];
        break;
      case 72:
        this.Role = 3;
        this.Spot = this.Floors[31];
        break;
      case 73:
        this.Role = 3;
        this.Spot = this.Floors[32];
        break;
      case 74:
        this.Role = 3;
        this.Spot = this.Floors[33];
        break;
      case 75:
        this.Role = 3;
        this.Spot = this.Floors[34];
        break;
    }
  }
}
