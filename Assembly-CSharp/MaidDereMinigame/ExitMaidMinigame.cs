// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.ExitMaidMinigame
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  public class ExitMaidMinigame : MonoBehaviour
  {
    private void OnMouseOver()
    {
      if (!Input.GetMouseButtonDown(0))
        return;
      GameController.GoToExitScene();
    }
  }
}
