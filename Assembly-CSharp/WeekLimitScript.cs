﻿// Decompiled with JetBrains decompiler
// Type: WeekLimitScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
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