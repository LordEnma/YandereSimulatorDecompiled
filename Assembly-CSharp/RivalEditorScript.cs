// Decompiled with JetBrains decompiler
// Type: RivalEditorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RivalEditorScript : MonoBehaviour
{
  [SerializeField]
  private UIPanel mainPanel;
  [SerializeField]
  private UIPanel rivalPanel;
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
    this.rivalPanel.gameObject.SetActive(false);
  }

  private void Update() => this.HandleInput();
}
