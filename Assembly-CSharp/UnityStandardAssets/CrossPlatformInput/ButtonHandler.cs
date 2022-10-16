// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.ButtonHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
  public class ButtonHandler : MonoBehaviour
  {
    public string Name;

    private void OnEnable()
    {
    }

    public void SetDownState() => CrossPlatformInputManager.SetButtonDown(this.Name);

    public void SetUpState() => CrossPlatformInputManager.SetButtonUp(this.Name);

    public void SetAxisPositiveState() => CrossPlatformInputManager.SetAxisPositive(this.Name);

    public void SetAxisNeutralState() => CrossPlatformInputManager.SetAxisZero(this.Name);

    public void SetAxisNegativeState() => CrossPlatformInputManager.SetAxisNegative(this.Name);

    public void Update()
    {
    }
  }
}
