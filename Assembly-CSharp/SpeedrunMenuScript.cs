// Decompiled with JetBrains decompiler
// Type: SpeedrunMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpeedrunMenuScript : MonoBehaviour
{
  public Animation YandereAnim;

  private void Start() => this.YandereAnim["f02_nierRun_00"].speed = 1.5f;

  private void Update()
  {
  }
}
