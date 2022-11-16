// Decompiled with JetBrains decompiler
// Type: SpeedrunMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
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
