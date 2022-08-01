// Decompiled with JetBrains decompiler
// Type: DiscordVerificationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscordVerificationScript : MonoBehaviour
{
  private void Update()
  {
    if (!Input.GetKeyDown("q"))
      return;
    SceneManager.LoadScene("MissionModeScene");
  }
}
