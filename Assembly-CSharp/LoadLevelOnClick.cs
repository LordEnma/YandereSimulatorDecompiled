// Decompiled with JetBrains decompiler
// Type: LoadLevelOnClick
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
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
