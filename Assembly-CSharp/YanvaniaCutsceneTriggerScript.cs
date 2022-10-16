// Decompiled with JetBrains decompiler
// Type: YanvaniaCutsceneTriggerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
  public YanvaniaYanmontScript Yanmont;
  public GameObject BossBattleWall;

  private void OnTriggerEnter(Collider other)
  {
    if (!(other.gameObject.name == "YanmontChan"))
      return;
    this.BossBattleWall.SetActive(true);
    this.Yanmont.EnterCutscene = true;
    Object.Destroy((Object) this.gameObject);
  }
}
