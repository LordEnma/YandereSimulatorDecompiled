// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.InputAxisScrollbar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
  public class InputAxisScrollbar : MonoBehaviour
  {
    public string axis;

    private void Update()
    {
    }

    public void HandleInput(float value) => CrossPlatformInputManager.SetAxis(this.axis, (float) ((double) value * 2.0 - 1.0));
  }
}
