// Decompiled with JetBrains decompiler
// Type: SceneSwitch
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
  private void Start()
  {
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
      SceneManager.LoadScene("Structure_01");
    if (Input.GetKeyDown(KeyCode.Alpha2))
      SceneManager.LoadScene("Structure_02");
    if (Input.GetKeyDown(KeyCode.Alpha3))
      SceneManager.LoadScene("Structure_03");
    if (Input.GetKeyDown(KeyCode.Alpha4))
      SceneManager.LoadScene("Props Furniture Showcase");
    if (!Input.GetKeyDown(KeyCode.Escape))
      return;
    Application.Quit();
  }
}
