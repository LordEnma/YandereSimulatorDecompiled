// Decompiled with JetBrains decompiler
// Type: FloatAbovePointScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FloatAbovePointScript : MonoBehaviour
{
  public Transform Target;

  private void Update() => this.transform.position = this.Target.position + new Vector3(0.0f, 0.15f, 0.0f);
}
