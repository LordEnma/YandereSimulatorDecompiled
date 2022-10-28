// Decompiled with JetBrains decompiler
// Type: ConstantRandomRotation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ConstantRandomRotation : MonoBehaviour
{
  private void Update() => this.transform.Rotate((float) Random.Range(0, 360), (float) Random.Range(0, 360), (float) Random.Range(0, 360));
}
