// Decompiled with JetBrains decompiler
// Type: Rotator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Rotator : MonoBehaviour
{
  public float speed = 15f;

  private void Update() => this.transform.Rotate(0.0f, this.speed * Time.deltaTime, 0.0f);
}
