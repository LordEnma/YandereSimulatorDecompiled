// Decompiled with JetBrains decompiler
// Type: TextMessageManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TextMessageManagerScript : MonoBehaviour
{
  public PauseScreenScript PauseScreen;
  public PromptBarScript PromptBar;
  public GameObject ServicesMenu;
  public string[] Messages;
  private GameObject NewMessage;
  public GameObject Message;
  public int MessageHeight;
  public string MessageText = string.Empty;

  private void Update()
  {
    if (!Input.GetButtonDown("B"))
      return;
    Object.Destroy((Object) this.NewMessage);
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[0].text = "Accept";
    this.PromptBar.Label[1].text = "Exit";
    this.PromptBar.Label[5].text = "Choose";
    this.PromptBar.UpdateButtons();
    this.PauseScreen.Sideways = true;
    this.ServicesMenu.SetActive(true);
    this.gameObject.SetActive(false);
    this.PauseScreen.StudentInfoMenu.SendingHome = false;
  }

  public void SpawnMessage(int ServiceID)
  {
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[1].text = "Exit";
    this.PromptBar.UpdateButtons();
    this.PauseScreen.Sideways = false;
    this.ServicesMenu.SetActive(false);
    this.gameObject.SetActive(true);
    if ((Object) this.NewMessage != (Object) null)
      Object.Destroy((Object) this.NewMessage);
    this.NewMessage = Object.Instantiate<GameObject>(this.Message);
    this.NewMessage.transform.parent = this.transform;
    this.NewMessage.transform.localPosition = new Vector3(-225f, -275f, 0.0f);
    this.NewMessage.transform.localEulerAngles = Vector3.zero;
    this.NewMessage.transform.localScale = new Vector3(1f, 1f, 1f);
    this.MessageText = this.Messages[ServiceID];
    switch (ServiceID)
    {
      case 4:
      case 7:
        this.MessageHeight = 11;
        break;
      case 9:
        this.MessageHeight = 6;
        break;
      default:
        this.MessageHeight = 5;
        break;
    }
    this.NewMessage.GetComponent<UISprite>().height = 36 + 36 * this.MessageHeight;
    this.NewMessage.GetComponent<TextMessageScript>().Label.text = this.MessageText;
  }
}
