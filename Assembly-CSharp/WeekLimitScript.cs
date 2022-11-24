// Decompiled with JetBrains decompiler
// Type: WeekLimitScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
