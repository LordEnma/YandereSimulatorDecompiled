// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.MobileControlRig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
