// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.ExitMaidMinigame
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
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
