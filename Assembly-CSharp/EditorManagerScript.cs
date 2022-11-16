// Decompiled with JetBrains decompiler
// Type: EditorManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using JsonFx.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditorManagerScript : MonoBehaviour
{
  [SerializeField]
  private UIPanel mainPanel;
  [SerializeField]
  private UIPanel[] editorPanels;
  [SerializeField]
  private UILabel cursorLabel;
  [SerializeField]
  private PromptBarScript promptBar;
  private int buttonIndex;
  private const int ButtonCount = 3;
  private InputManagerScript inputManager;

  private void Awake()
  {
    this.buttonIndex = 0;
    this.inputManager = Object.FindObjectOfType<InputManagerScript>();
  }

  private void Start()
  {
    this.promptBar.Label[0].text = "Select";
    this.promptBar.Label[1].text = "Exit";
    this.promptBar.Label[4].text = "Choose";
    this.promptBar.UpdateButtons();
  }

  private void OnEnable()
  {
    this.promptBar.Label[0].text = "Select";
    this.promptBar.Label[1].text = "Exit";
    this.promptBar.Label[4].text = "Choose";
    this.promptBar.UpdateButtons();
  }

  public static Dictionary<string, object>[] DeserializeJson(string filename) => JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename))));

  private void HandleInput()
  {
    if (Input.GetButtonDown("B"))
      SceneManager.LoadScene("NewTitleScene");
    int num = this.inputManager.TappedUp ? 1 : 0;
    bool tappedDown = this.inputManager.TappedDown;
    if (num != 0)
      this.buttonIndex = this.buttonIndex > 0 ? this.buttonIndex - 1 : 2;
    else if (tappedDown)
      this.buttonIndex = this.buttonIndex < 2 ? this.buttonIndex + 1 : 0;
    if ((num | (tappedDown ? 1 : 0)) != 0)
    {
      Transform transform = this.cursorLabel.transform;
      transform.localPosition = new Vector3(transform.localPosition.x, (float) (100.0 - (double) this.buttonIndex * 100.0), transform.localPosition.z);
    }
    if (!Input.GetButtonDown("A"))
      return;
    this.editorPanels[this.buttonIndex].gameObject.SetActive(true);
    this.mainPanel.gameObject.SetActive(false);
  }

  private void Update() => this.HandleInput();
}
