// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.ButtonHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
