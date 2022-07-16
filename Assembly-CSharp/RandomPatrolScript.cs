// Decompiled with JetBrains decompiler
// Type: RandomPatrolScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RandomPatrolScript : MonoBehaviour
{
  public Transform[] PatrolPoints;
  public int[] Height;

  private void Start()
  {
    for (int index = 1; index < 5; ++index)
    {
      this.Height[index] = Random.Range(1, 5);
      if (this.Height[index] == 1)
        this.Height[index] = 0;
      else if (this.Height[index] == 2)
        this.Height[index] = 4;
      else if (this.Height[index] == 3)
        this.Height[index] = 8;
      else if (this.Height[index] == 4)
        this.Height[index] = 12;
    }
    Transform patrolPoint1 = this.PatrolPoints[1];
    Transform patrolPoint2 = this.PatrolPoints[2];
    Transform patrolPoint3 = this.PatrolPoints[3];
    Transform patrolPoint4 = this.PatrolPoints[4];
    patrolPoint1.position = new Vector3(Random.Range(-21f, 21f), (float) this.Height[1], Random.Range(21f, 19f));
    patrolPoint2.position = new Vector3(Random.Range(19f, 21f), (float) this.Height[2], Random.Range(29f, -37f));
    patrolPoint3.position = new Vector3(Random.Range(-21f, 21f), (float) this.Height[3], Random.Range(-21f, -19f));
    patrolPoint4.position = new Vector3(Random.Range(-19f, -21f), (float) this.Height[4], Random.Range(29f, -37f));
    patrolPoint1.localEulerAngles = new Vector3(patrolPoint1.localEulerAngles.x, Random.Range(0.0f, 360f), patrolPoint1.localEulerAngles.z);
    patrolPoint2.localEulerAngles = new Vector3(patrolPoint2.localEulerAngles.x, Random.Range(0.0f, 360f), patrolPoint2.localEulerAngles.z);
    patrolPoint3.localEulerAngles = new Vector3(patrolPoint3.localEulerAngles.x, Random.Range(0.0f, 360f), patrolPoint3.localEulerAngles.z);
    patrolPoint4.localEulerAngles = new Vector3(patrolPoint4.localEulerAngles.x, Random.Range(0.0f, 360f), patrolPoint4.localEulerAngles.z);
  }
}
