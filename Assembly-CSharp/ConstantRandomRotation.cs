// Decompiled with JetBrains decompiler
// Type: ConstantRandomRotation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ConstantRandomRotation : MonoBehaviour
{
  private void Update() => this.transform.Rotate((float) Random.Range(0, 360), (float) Random.Range(0, 360), (float) Random.Range(0, 360));
}
