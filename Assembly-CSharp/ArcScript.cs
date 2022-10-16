// Decompiled with JetBrains decompiler
// Type: ArcScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ArcScript : MonoBehaviour
{
  private static readonly Vector3 NEW_ARC_RELATIVE_FORCE = Vector3.forward * 375f;
  public GameObject ArcTrail;
  public float Timer;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= 0.5)
      return;
    GameObject gameObject = Object.Instantiate<GameObject>(this.ArcTrail, this.transform.position, this.transform.rotation);
    gameObject.transform.parent = this.transform;
    gameObject.GetComponent<Rigidbody>().AddRelativeForce(ArcScript.NEW_ARC_RELATIVE_FORCE);
    this.Timer = 0.0f;
  }
}
