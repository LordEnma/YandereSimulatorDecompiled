// Decompiled with JetBrains decompiler
// Type: YanvaniaBlackHoleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaBlackHoleScript : MonoBehaviour
{
  public GameObject BlackHoleAttack;
  public int Attacks;
  public float SpawnTimer;
  public float Timer;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= 1.0)
      return;
    this.SpawnTimer -= Time.deltaTime;
    if ((double) this.SpawnTimer > 0.0 || this.Attacks >= 5)
      return;
    Object.Instantiate<GameObject>(this.BlackHoleAttack, this.transform.position, Quaternion.identity);
    this.SpawnTimer = 0.5f;
    ++this.Attacks;
  }
}
