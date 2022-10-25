// Decompiled with JetBrains decompiler
// Type: SpeedrunMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpeedrunMenuScript : MonoBehaviour
{
  public Animation YandereAnim;

  private void Start() => this.YandereAnim["f02_nierRun_00"].speed = 1.5f;

  private void Update()
  {
  }
}
