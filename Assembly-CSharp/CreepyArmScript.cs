// Decompiled with JetBrains decompiler
// Type: CreepyArmScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CreepyArmScript : MonoBehaviour
{
  private void Update() => this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime * 0.1f, this.transform.position.z);
}
