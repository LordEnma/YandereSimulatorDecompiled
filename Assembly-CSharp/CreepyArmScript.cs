// Decompiled with JetBrains decompiler
// Type: CreepyArmScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CreepyArmScript : MonoBehaviour
{
  private void Update() => this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime * 0.1f, this.transform.position.z);
}
