// Decompiled with JetBrains decompiler
// Type: LoadLevelOnClick
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("NGUI/Examples/Load Level On Click")]
public class LoadLevelOnClick : MonoBehaviour
{
  public string levelName;

  private void OnClick()
  {
    if (string.IsNullOrEmpty(this.levelName))
      return;
    SceneManager.LoadScene(this.levelName);
  }
}
