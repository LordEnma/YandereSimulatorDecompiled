﻿// Decompiled with JetBrains decompiler
// Type: DiscordVerificationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
