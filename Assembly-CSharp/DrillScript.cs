// Decompiled with JetBrains decompiler
// Type: DrillScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DrillScript : MonoBehaviour
{
  private void LateUpdate() => this.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
}
