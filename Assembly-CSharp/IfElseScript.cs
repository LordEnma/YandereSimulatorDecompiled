// Decompiled with JetBrains decompiler
// Type: IfElseScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class IfElseScript : MonoBehaviour
{
  public int ID;
  public string Day;

  private void Start() => this.SwitchCase();

  private void IfElse()
  {
    if (this.ID == 1)
      this.Day = "Monday";
    else if (this.ID == 2)
      this.Day = "Tuesday";
    else if (this.ID == 3)
      this.Day = "Wednesday";
    else if (this.ID == 4)
      this.Day = "Thursday";
    else if (this.ID == 5)
      this.Day = "Friday";
    else if (this.ID == 6)
    {
      this.Day = "Saturday";
    }
    else
    {
      if (this.ID != 7)
        return;
      this.Day = "Sunday";
    }
  }

  private void SwitchCase()
  {
    switch (this.ID)
    {
      case 1:
        this.Day = "Monday";
        break;
      case 2:
        this.Day = "Tuesday";
        break;
      case 3:
        this.Day = "Wednesday";
        break;
      case 4:
        this.Day = "Thursday";
        break;
      case 5:
        this.Day = "Friday";
        break;
      case 6:
        this.Day = "Saturday";
        break;
      case 7:
        this.Day = "Sunday";
        break;
    }
  }
}
