// Decompiled with JetBrains decompiler
// Type: KittenScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class KittenScript : MonoBehaviour
{
  public YandereScript Yandere;
  public GameObject Character;
  public string[] AnimationNames;
  public Transform Target;
  public Transform Head;
  public string CurrentAnim = string.Empty;
  public string IdleAnim = string.Empty;
  public bool Wait;
  public float Timer;

  private void LateUpdate()
  {
    if ((double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) >= 5.0)
      return;
    if (!this.Yandere.Aiming)
    {
      this.Target.position = Vector3.Lerp(this.Target.position, (double) this.Yandere.Head.transform.position.x < (double) this.transform.position.x ? this.Yandere.Head.transform.position : this.transform.position + this.transform.forward + this.transform.up * 0.139854f, Time.deltaTime * 5f);
      this.Head.transform.LookAt(this.Target);
    }
    else
      this.Head.transform.LookAt(this.Yandere.transform.position + Vector3.up * this.Head.position.y);
  }
}
