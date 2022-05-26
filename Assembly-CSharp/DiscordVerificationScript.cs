// Decompiled with JetBrains decompiler
// Type: DiscordVerificationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
