// Decompiled with JetBrains decompiler
// Type: UIButtonActivate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button Activate")]
public class UIButtonActivate : MonoBehaviour
{
  public GameObject target;
  public bool state = true;

  private void OnClick()
  {
    if (!((Object) this.target != (Object) null))
      return;
    NGUITools.SetActive(this.target, this.state);
  }
}
