// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.MobileControlRig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
  [ExecuteInEditMode]
  public class MobileControlRig : MonoBehaviour
  {
    private void OnEnable() => this.CheckEnableControlRig();

    private void Start()
    {
      if (!((Object) Object.FindObjectOfType<EventSystem>() == (Object) null))
        return;
      GameObject gameObject = new GameObject("EventSystem");
      gameObject.AddComponent<EventSystem>();
      gameObject.AddComponent<StandaloneInputModule>();
    }

    private void CheckEnableControlRig() => this.EnableControlRig(false);

    private void EnableControlRig(bool enabled)
    {
      foreach (Component component in this.transform)
        component.gameObject.SetActive(enabled);
    }
  }
}
