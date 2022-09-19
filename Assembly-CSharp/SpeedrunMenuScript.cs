// Decompiled with JetBrains decompiler
// Type: SpeedrunMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
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
