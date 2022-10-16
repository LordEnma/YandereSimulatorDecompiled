// Decompiled with JetBrains decompiler
// Type: DanceMinigamePromptScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DanceMinigamePromptScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public Renderer OriginalRenderer;
  public DDRManager DanceManager;
  public PromptScript Prompt;
  public ClockScript Clock;
  public GameObject DanceMinigame;
  public Transform PlayerLocation;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Yandere.transform.position = this.PlayerLocation.position;
    this.Prompt.Yandere.transform.rotation = this.PlayerLocation.rotation;
    this.Prompt.Yandere.CharacterAnimation.Play("f02_danceMachineIdle_00");
    this.Prompt.Yandere.StudentManager.Clock.StopTime = true;
    this.Prompt.Yandere.MyController.enabled = false;
    this.Prompt.Yandere.HeartCamera.enabled = false;
    this.Prompt.Yandere.HUD.enabled = false;
    this.Prompt.Yandere.CanMove = false;
    this.Prompt.Yandere.enabled = false;
    this.Prompt.Yandere.Jukebox.LastVolume = this.Prompt.Yandere.Jukebox.Volume;
    this.Prompt.Yandere.Jukebox.Volume = 0.0f;
    this.Prompt.Yandere.HUD.transform.parent.gameObject.SetActive(false);
    this.Prompt.Yandere.MainCamera.gameObject.SetActive(false);
    this.OriginalRenderer.enabled = false;
    Physics.SyncTransforms();
    this.DanceMinigame.SetActive(true);
    this.DanceManager.BeginMinigame();
    this.StudentManager.DisableEveryone();
  }
}
