// Decompiled with JetBrains decompiler
// Type: BushSpawnerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
