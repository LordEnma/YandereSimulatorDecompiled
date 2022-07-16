// Decompiled with JetBrains decompiler
// Type: BuildingDestructionScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BuildingDestructionScript : MonoBehaviour
{
  public Transform NewSchool;
  public bool Sink;
  public int Phase;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      ++this.Phase;
      this.Sink = true;
    }
    if (!this.Sink)
      return;
    if (this.Phase == 1)
      this.transform.position = new Vector3(Random.Range(-1f, 1f), this.transform.position.y - Time.deltaTime * 10f, Random.Range(-19f, -21f));
    else if ((double) this.NewSchool.position.y != 0.0)
    {
      this.NewSchool.position = new Vector3(this.NewSchool.position.x, Mathf.MoveTowards(this.NewSchool.position.y, 0.0f, Time.deltaTime * 10f), this.NewSchool.position.z);
      this.transform.position = new Vector3(Random.Range(-1f, 1f), this.transform.position.y, Random.Range(13f, 15f));
    }
    else
      this.transform.position = new Vector3(0.0f, this.transform.position.y, 14f);
  }
}
