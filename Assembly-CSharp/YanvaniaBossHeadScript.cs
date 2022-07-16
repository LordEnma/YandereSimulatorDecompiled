// Decompiled with JetBrains decompiler
// Type: YanvaniaBossHeadScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaBossHeadScript : MonoBehaviour
{
  public YanvaniaDraculaScript Dracula;
  public GameObject HitEffect;
  public float Timer;

  private void Update() => this.Timer -= Time.deltaTime;

  private void OnTriggerEnter(Collider other)
  {
    if ((double) this.Timer > 0.0 || !((Object) this.Dracula.NewTeleportEffect == (Object) null) || !(other.gameObject.name == "Heart"))
      return;
    GameObject gameObject = Object.Instantiate<GameObject>(this.HitEffect, this.transform.position, Quaternion.identity);
    if ((double) gameObject.transform.position.y < 7.0)
      gameObject.transform.position += new Vector3(0.0f, 1f, 0.0f);
    this.Timer = 1f;
    this.Dracula.TakeDamage();
  }
}
