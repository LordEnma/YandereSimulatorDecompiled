// Decompiled with JetBrains decompiler
// Type: PantyDetectorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PantyDetectorScript : MonoBehaviour
{
  public YandereScript Yandere;
  public StudentScript Student;
  public int Frame;

  private void Update()
  {
    if (this.Frame == 1)
    {
      this.Yandere.StudentManager.UpdatePanties(false);
      Object.Destroy((Object) this.gameObject);
    }
    ++this.Frame;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!((Object) this.Student == (Object) null) || !(other.gameObject.name == "Panties"))
      return;
    this.Student = other.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
    this.Yandere.ResetYandereEffects();
    this.Yandere.Shutter.PhotoDescLabel.text = "Photo of: " + this.Student.Name + "'s Panties";
    this.Yandere.Shutter.PhotoIcons.SetActive(true);
    this.Yandere.Shutter.PantiesX.SetActive(false);
    this.Yandere.Shutter.InfoX.SetActive(true);
    this.Yandere.Shutter.Student = this.Student;
    Time.timeScale = 0.0f;
    this.Yandere.Shutter.Panel.SetActive(true);
    this.Yandere.Shutter.MainMenu.SetActive(false);
    this.Yandere.PauseScreen.Show = true;
    this.Yandere.PauseScreen.Panel.enabled = true;
    this.Yandere.PromptBar.ClearButtons();
    this.Yandere.PromptBar.Label[1].text = "Exit";
    this.Yandere.PromptBar.UpdateButtons();
    this.Yandere.PromptBar.Show = true;
    this.Yandere.PauseScreen.Sideways = false;
    this.Yandere.Shutter.TextMessages.gameObject.SetActive(true);
    this.Yandere.Shutter.SpawnMessage();
  }
}
