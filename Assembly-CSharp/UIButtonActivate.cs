// Decompiled with JetBrains decompiler
// Type: UIButtonActivate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
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
