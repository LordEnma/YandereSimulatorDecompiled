// Decompiled with JetBrains decompiler
// Type: YanvaniaCutsceneTriggerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
