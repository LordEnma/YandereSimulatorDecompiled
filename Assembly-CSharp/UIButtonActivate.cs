// Decompiled with JetBrains decompiler
// Type: UIButtonActivate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
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
