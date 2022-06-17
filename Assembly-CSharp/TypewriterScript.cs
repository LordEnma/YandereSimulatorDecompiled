// Decompiled with JetBrains decompiler
// Type: TypewriterScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TypewriterScript : MonoBehaviour
{
  public PromptScript Prompt;
  public GameObject Window;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Prompt.Yandere.RPGCamera.enabled = false;
      this.Prompt.Yandere.CanMove = false;
      Time.timeScale = 0.0001f;
      this.Window.SetActive(true);
    }
    if (!this.Window.activeInHierarchy)
      return;
    if (Input.GetButtonDown("A"))
    {
      this.Prompt.Yandere.Police.EndOfDay.ArticleID = 1;
      this.CloseWindow();
      this.Disable();
    }
    else if (Input.GetButtonDown("X"))
    {
      this.Prompt.Yandere.Police.EndOfDay.ArticleID = 2;
      this.CloseWindow();
      this.Disable();
    }
    else if (Input.GetButtonDown("Y"))
    {
      this.Prompt.Yandere.Police.EndOfDay.ArticleID = 3;
      this.CloseWindow();
      this.Disable();
    }
    else
    {
      if (!Input.GetButtonDown("B"))
        return;
      this.CloseWindow();
    }
  }

  private void CloseWindow()
  {
    this.Prompt.Yandere.RPGCamera.enabled = true;
    this.Prompt.Yandere.CanMove = true;
    this.Window.SetActive(false);
    Time.timeScale = 1f;
  }

  private void Disable()
  {
    this.Prompt.enabled = false;
    this.enabled = false;
    this.Prompt.Hide();
  }
}
