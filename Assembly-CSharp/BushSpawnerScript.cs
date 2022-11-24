// Decompiled with JetBrains decompiler
// Type: BushSpawnerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BushSpawnerScript : MonoBehaviour
{
  public GameObject Bush;
  public bool Begin;

  private void Update()
  {
    if (Input.GetKeyDown("z"))
      this.Begin = true;
    if (!this.Begin)
      return;
    Object.Instantiate<GameObject>(this.Bush, new Vector3(Random.Range(-16f, 16f), Random.Range(0.0f, 4f), Random.Range(-16f, 16f)), Quaternion.identity);
  }
}
