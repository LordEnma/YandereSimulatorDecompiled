// Decompiled with JetBrains decompiler
// Type: PopulationManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class PopulationManagerScript : MonoBehaviour
{
  [Tooltip("All defined areas should go in here. If your area is not in here, it will not count as an actual area.")]
  [SerializeField]
  private List<AreaScript> _definedAreas;
  public Transform Cube;

  public Vector3 GetCrowdedLocation()
  {
    AreaScript crowdedArea = this.GetCrowdedArea();
    Vector3 position = crowdedArea.transform.position;
    Vector3 vector3_1 = new Vector3(0.0f, 0.0f, 0.0f);
    float num = 0.0f;
    foreach (StudentScript student in crowdedArea.Students)
    {
      vector3_1 += new Vector3(student.transform.position.x, 0.0f, student.transform.position.z);
      ++num;
    }
    Vector3 vector3_2 = vector3_1 / num;
    int y = (double) position.y < 0.0 || (double) position.y >= 4.0 ? ((double) position.y < 4.0 || (double) position.y >= 8.0 ? ((double) position.y < 8.0 || (double) position.y >= 12.0 ? 12 : 8) : 4) : 0;
    return new Vector3(vector3_2.x, (float) y, vector3_2.z);
  }

  public AreaScript GetCrowdedArea()
  {
    AreaScript crowdedArea = (AreaScript) null;
    float num = 0.0f;
    foreach (AreaScript definedArea in this._definedAreas)
    {
      int population = definedArea.Population;
      if ((double) population > (double) num)
      {
        num = (float) population;
        crowdedArea = definedArea;
      }
    }
    return crowdedArea;
  }
}
