// Decompiled with JetBrains decompiler
// Type: BloodParentScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BloodParentScript : MonoBehaviour
{
  public YandereScript Yandere;
  public GameObject Bloodpool;
  public GameObject Footprint;
  public Vector3[] FootprintPositions;
  public Vector3[] BloodPositions;
  public Vector3[] FootprintRotations;
  public Vector3[] BloodRotations;
  public float[] BloodSizes;
  public int FootprintID;
  public int PoolID;

  public void RecordAllBlood()
  {
    this.PoolID = 0;
    this.FootprintID = 0;
    foreach (Transform transform in this.transform)
    {
      BloodPoolScript component = transform.GetComponent<BloodPoolScript>();
      if ((Object) component != (Object) null)
      {
        ++this.PoolID;
        if (this.PoolID < 100)
        {
          this.BloodPositions[this.PoolID] = transform.position;
          this.BloodRotations[this.PoolID] = transform.eulerAngles;
          this.BloodSizes[this.PoolID] = component.TargetSize;
        }
      }
      else
      {
        ++this.FootprintID;
        if (this.FootprintID < 100)
        {
          this.FootprintPositions[this.FootprintID] = transform.position;
          this.FootprintRotations[this.FootprintID] = transform.eulerAngles;
        }
      }
    }
  }

  public void RestoreAllBlood()
  {
    for (; this.PoolID > 0; --this.PoolID)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.Bloodpool, this.BloodPositions[this.PoolID], Quaternion.identity);
      gameObject.GetComponent<BloodPoolScript>().TargetSize = this.BloodSizes[this.PoolID];
      gameObject.transform.eulerAngles = this.BloodRotations[this.PoolID];
      gameObject.transform.parent = this.transform;
    }
    for (; this.FootprintID > 0; --this.FootprintID)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.Footprint, this.FootprintPositions[this.FootprintID], Quaternion.identity);
      gameObject.transform.GetChild(0).GetComponent<FootprintScript>().Yandere = this.Yandere;
      gameObject.transform.eulerAngles = this.FootprintRotations[this.FootprintID];
      gameObject.transform.parent = this.transform;
    }
  }
}
