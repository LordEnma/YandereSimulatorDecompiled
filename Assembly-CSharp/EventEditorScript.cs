// Decompiled with JetBrains decompiler
// Type: EventEditorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class EventEditorScript : MonoBehaviour
{
  [SerializeField]
  private UIPanel mainPanel;
  [SerializeField]
  private UIPanel eventPanel;
  [SerializeField]
  private UILabel titleLabel;
  [SerializeField]
  private PromptBarScript promptBar;
  private InputManagerScript inputManager;

  private void Awake() => this.inputManager = Object.FindObjectOfType<InputManagerScript>();

  private void OnEnable()
  {
    this.promptBar.Label[0].text = string.Empty;
    this.promptBar.Label[1].text = "Back";
    this.promptBar.Label[4].text = string.Empty;
    this.promptBar.UpdateButtons();
  }

  private void HandleInput()
  {
    if (!Input.GetButtonDown("B"))
      return;
    this.mainPanel.gameObject.SetActive(true);
    this.eventPanel.gameObject.SetActive(false);
  }

  private void Update() => this.HandleInput();
}
