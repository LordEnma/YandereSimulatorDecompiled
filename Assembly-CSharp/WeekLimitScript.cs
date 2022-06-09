// Decompiled with JetBrains decompiler
// Type: WeekLimitScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class WeekLimitScript : MonoBehaviour
{
  private void Update()
  {
    if (!Input.anyKeyDown)
      return;
    SceneManager.LoadScene("HomeScene");
  }
}
