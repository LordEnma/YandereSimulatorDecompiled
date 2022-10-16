// Decompiled with JetBrains decompiler
// Type: TapePlayerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TapePlayerScript : MonoBehaviour
{
  public TapePlayerMenuScript TapePlayerMenu;
  public PromptBarScript PromptBar;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public Transform RWButton;
  public Transform FFButton;
  public Camera TapePlayerCamera;
  public Transform[] Rolls;
  public GameObject NoteWindow;
  public GameObject Tape;
  public bool FastForward;
  public bool Rewind;
  public bool Spin;
  public float SpinSpeed;

  private void Start() => this.Tape.SetActive(false);

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Yandere.HeartCamera.enabled = false;
      this.Yandere.RPGCamera.enabled = false;
      this.TapePlayerMenu.TimeBar.gameObject.SetActive(true);
      this.TapePlayerMenu.List.gameObject.SetActive(true);
      this.TapePlayerCamera.enabled = true;
      this.TapePlayerMenu.UpdateLabels();
      this.TapePlayerMenu.Show = true;
      this.NoteWindow.SetActive(false);
      this.Yandere.CanMove = false;
      this.Yandere.HUD.alpha = 0.0f;
      Time.timeScale = 0.0001f;
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[1].text = "EXIT";
      this.PromptBar.Label[4].text = "CHOOSE";
      this.PromptBar.Label[5].text = "CATEGORY";
      this.TapePlayerMenu.CheckSelection();
      this.PromptBar.Show = true;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if (this.Spin)
    {
      Transform roll1 = this.Rolls[0];
      roll1.localEulerAngles = new Vector3(roll1.localEulerAngles.x, roll1.localEulerAngles.y + (float) (0.01666666753590107 * (360.0 * (double) this.SpinSpeed)), roll1.localEulerAngles.z);
      Transform roll2 = this.Rolls[1];
      roll2.localEulerAngles = new Vector3(roll2.localEulerAngles.x, roll2.localEulerAngles.y + (float) (0.01666666753590107 * (360.0 * (double) this.SpinSpeed)), roll2.localEulerAngles.z);
    }
    if (this.FastForward)
    {
      this.FFButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.FFButton.localEulerAngles.x, 6.25f, 1.66666663f), this.FFButton.localEulerAngles.y, this.FFButton.localEulerAngles.z);
      this.SpinSpeed = 2f;
    }
    else
    {
      this.FFButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.FFButton.localEulerAngles.x, 0.0f, 1.66666663f), this.FFButton.localEulerAngles.y, this.FFButton.localEulerAngles.z);
      this.SpinSpeed = 1f;
    }
    if (this.Rewind)
    {
      this.RWButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.RWButton.localEulerAngles.x, 6.25f, 1.66666663f), this.RWButton.localEulerAngles.y, this.RWButton.localEulerAngles.z);
      this.SpinSpeed = -2f;
    }
    else
      this.RWButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.RWButton.localEulerAngles.x, 0.0f, 1.66666663f), this.RWButton.localEulerAngles.y, this.RWButton.localEulerAngles.z);
  }
}
