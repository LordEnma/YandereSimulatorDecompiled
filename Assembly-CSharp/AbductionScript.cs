// Decompiled with JetBrains decompiler
// Type: AbductionScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class AbductionScript : MonoBehaviour
{
  public SkinnedMeshRenderer Renderer;
  public Texture[] RivalStockings;
  public AudioSource MyAudio;
  public UISprite Darkness;
  public Camera MainCamera;
  public float StartTimer;
  public float Timer;
  public bool PlayedAudio;
  public int Phase;
  public Animation Anim1;
  public Animator Anim2;
  public PostProcessingProfile Profile;

  private void Start()
  {
    if ((double) SchoolGlobals.SchoolAtmosphere > 0.5)
      this.Darkness.color = new Color(1f, 1f, 1f, 1f);
    else
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.UpdateDOF(1f);
    if (GameGlobals.AbductionTarget <= 0)
      return;
    this.Renderer.material.SetTexture("_OverlayTex", this.RivalStockings[GameGlobals.AbductionTarget - 10]);
  }

  private void Update()
  {
    this.StartTimer += Time.deltaTime;
    if ((double) this.StartTimer <= 1.0)
      return;
    if ((double) this.StartTimer > 2.5 && !this.MyAudio.isPlaying && !this.PlayedAudio)
    {
      this.PlayedAudio = true;
      this.MyAudio.Play();
    }
    if (this.Phase == 0)
    {
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.0f, Time.deltaTime * 0.33333f);
      if ((double) this.Darkness.alpha != 0.0)
        return;
      this.Anim1.Play();
      this.Anim2.enabled = true;
      ++this.Phase;
    }
    else
    {
      if ((double) this.Anim1["Scene"].time < (double) this.Anim1["Scene"].length)
        return;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 2.0)
        return;
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime * 0.33333f);
      if ((double) this.Darkness.alpha != 1.0)
        return;
      SceneManager.LoadScene("LoadingScene");
    }
  }

  private void UpdateDOF(float Focus) => this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
  {
    focusDistance = Focus
  };
}
