// Decompiled with JetBrains decompiler
// Type: CreepyArmScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CreepyArmScript : MonoBehaviour
{
  private void Update() => this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime * 0.1f, this.transform.position.z);
}
