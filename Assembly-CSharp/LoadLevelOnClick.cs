// Decompiled with JetBrains decompiler
// Type: LoadLevelOnClick
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
