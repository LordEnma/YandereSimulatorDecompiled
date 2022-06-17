// Decompiled with JetBrains decompiler
// Type: LoadLevelOnClick
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
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
