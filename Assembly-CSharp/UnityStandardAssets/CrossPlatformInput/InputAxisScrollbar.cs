// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.InputAxisScrollbar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
