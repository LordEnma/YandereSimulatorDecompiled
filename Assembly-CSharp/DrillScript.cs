// Decompiled with JetBrains decompiler
// Type: DrillScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DrillScript : MonoBehaviour
{
  private void LateUpdate() => this.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
}
