// Decompiled with JetBrains decompiler
// Type: CreepyArmScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CreepyArmScript : MonoBehaviour
{
  private void Update() => this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime * 0.1f, this.transform.position.z);
}
