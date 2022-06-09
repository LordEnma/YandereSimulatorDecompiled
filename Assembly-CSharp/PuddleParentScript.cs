// Decompiled with JetBrains decompiler
// Type: PuddleParentScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PuddleParentScript : MonoBehaviour
{
  public GameObject WaterPuddle;
  public GameObject GasPuddle;
  public GameObject BrownPuddle;
  public Vector3[] PuddlePositions;
  public Vector3[] PuddleRotations;
  public int[] Type;
  public int PoolID;

  public void RecordAllPuddles()
  {
    this.PoolID = 0;
    foreach (Transform transform in this.transform)
    {
      BloodPoolScript component = transform.GetComponent<BloodPoolScript>();
      if ((Object) component != (Object) null)
      {
        ++this.PoolID;
        if (this.PoolID < 100)
        {
          this.PuddlePositions[this.PoolID] = transform.position;
          this.PuddleRotations[this.PoolID] = transform.eulerAngles;
        }
        if (component.Gasoline)
          this.Type[this.PoolID] = 1;
        else if (component.Brown)
          this.Type[this.PoolID] = 2;
      }
    }
  }

  public void RestoreAllPuddles()
  {
    for (; this.PoolID > 0; --this.PoolID)
    {
      GameObject gameObject = (GameObject) null;
      if (this.Type[this.PoolID] == 0)
        gameObject = Object.Instantiate<GameObject>(this.WaterPuddle, this.PuddlePositions[this.PoolID], Quaternion.identity);
      else if (this.Type[this.PoolID] == 1)
        gameObject = Object.Instantiate<GameObject>(this.GasPuddle, this.PuddlePositions[this.PoolID], Quaternion.identity);
      else if (this.Type[this.PoolID] == 2)
        gameObject = Object.Instantiate<GameObject>(this.GasPuddle, this.PuddlePositions[this.PoolID], Quaternion.identity);
      gameObject.GetComponent<BloodPoolScript>().TargetSize = 1f;
      gameObject.transform.eulerAngles = this.PuddleRotations[this.PoolID];
      gameObject.transform.parent = this.transform;
    }
  }
}
