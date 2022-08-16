// Decompiled with JetBrains decompiler
// Type: FloatAbovePointScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FloatAbovePointScript : MonoBehaviour
{
  public Transform Target;

  private void Update() => this.transform.position = this.Target.position + new Vector3(0.0f, 0.15f, 0.0f);
}
