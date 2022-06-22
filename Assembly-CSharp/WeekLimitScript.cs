// Decompiled with JetBrains decompiler
// Type: WeekLimitScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
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
