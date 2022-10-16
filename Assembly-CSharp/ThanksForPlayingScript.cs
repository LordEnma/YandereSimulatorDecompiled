// Decompiled with JetBrains decompiler
// Type: ThanksForPlayingScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class ThanksForPlayingScript : MonoBehaviour
{
  public CameraEffectsScript CameraEffects;
  public ParticleSystem[] Hearts;
  public UIPanel ThankYouPanel;
  public UIPanel FinalGamePanel;
  public UIPanel RivalPanel;
  public UIPanel QualityPanel;
  public UIPanel WeaponsPanel;
  public UIPanel StoryPanel;
  public UIPanel MorePanel;
  public UIPanel CrowdfundPanel;
  public UIPanel SkipPanel;
  public AudioSource Jukebox;
  public Transform Yandere;
  public UISprite SkipCircle;
  public UISprite Darkness;
  public Animation YandereKun;
  public Animation Ryoba;
  public bool FadeOut;
  public float Alpha;

  private void Start()
  {
    this.Ryoba["f02_faceCouncilGrace_00"].layer = 1;
    this.Ryoba.Play("f02_faceCouncilGrace_00");
    this.YandereKun["AltYanKunFace"].layer = 1;
    this.YandereKun.Play("AltYanKunFace");
    this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.SkipPanel.alpha = 0.0f;
    this.Alpha = 1f;
    this.CameraEffects.UpdateDOF(2f);
    this.CameraEffects.UpdateBloom(1f);
    this.CameraEffects.UpdateBloomKnee(0.5f);
    this.CameraEffects.UpdateBloomRadius(4f);
  }

  private void Update()
  {
    if (!this.FadeOut)
    {
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.5f);
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      if ((double) this.Alpha == 0.0)
        this.SkipPanel.alpha += Time.deltaTime;
    }
    else
    {
      this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.5f);
      this.Darkness.color = new Color(1f, 1f, 1f, this.Alpha);
      this.Jukebox.volume -= Time.deltaTime * 0.5f;
      if ((double) this.Alpha == 1.0)
        SceneManager.LoadScene("NewTitleScene");
    }
    if ((double) this.SkipPanel.alpha == 1.0)
    {
      if (Input.GetButton("X"))
      {
        this.SkipCircle.fillAmount -= Time.deltaTime;
        if ((double) this.SkipCircle.fillAmount == 0.0)
          this.FadeOut = true;
      }
      else
        this.SkipCircle.fillAmount = 1f;
    }
    if (Input.GetKeyDown("=") && (double) Time.timeScale < 10.0)
      ++Time.timeScale;
    if (Input.GetKeyDown("-") && (double) Time.timeScale > 1.0)
      --Time.timeScale;
    if ((double) this.Yandere.position.z > 1.0 && (double) this.Yandere.position.z < 10.0)
      this.ThankYouPanel.alpha = Mathf.MoveTowards(this.ThankYouPanel.alpha, 1f, Time.deltaTime * 0.5f);
    else
      this.ThankYouPanel.alpha = Mathf.MoveTowards(this.ThankYouPanel.alpha, 0.0f, Time.deltaTime * 0.5f);
    if ((double) this.Yandere.position.z > 20.0 && (double) this.Yandere.position.z < 120.0)
      this.FinalGamePanel.alpha = Mathf.MoveTowards(this.FinalGamePanel.alpha, 1f, Time.deltaTime * 0.5f);
    else
      this.FinalGamePanel.alpha = Mathf.MoveTowards(this.FinalGamePanel.alpha, 0.0f, Time.deltaTime * 0.5f);
    if ((double) this.Yandere.position.z > 30.0 && (double) this.Yandere.position.z < 40.0)
      this.RivalPanel.alpha = Mathf.MoveTowards(this.RivalPanel.alpha, 1f, Time.deltaTime * 0.5f);
    else
      this.RivalPanel.alpha = Mathf.MoveTowards(this.RivalPanel.alpha, 0.0f, Time.deltaTime * 0.5f);
    if ((double) this.Yandere.position.z > 50.0 && (double) this.Yandere.position.z < 60.0)
      this.QualityPanel.alpha = Mathf.MoveTowards(this.QualityPanel.alpha, 1f, Time.deltaTime * 0.5f);
    else
      this.QualityPanel.alpha = Mathf.MoveTowards(this.QualityPanel.alpha, 0.0f, Time.deltaTime * 0.5f);
    if ((double) this.Yandere.position.z > 70.0 && (double) this.Yandere.position.z < 80.0)
      this.WeaponsPanel.alpha = Mathf.MoveTowards(this.WeaponsPanel.alpha, 1f, Time.deltaTime * 0.5f);
    else
      this.WeaponsPanel.alpha = Mathf.MoveTowards(this.WeaponsPanel.alpha, 0.0f, Time.deltaTime * 0.5f);
    if ((double) this.Yandere.position.z > 90.0 && (double) this.Yandere.position.z < 100.0)
      this.StoryPanel.alpha = Mathf.MoveTowards(this.StoryPanel.alpha, 1f, Time.deltaTime * 0.5f);
    else
      this.StoryPanel.alpha = Mathf.MoveTowards(this.StoryPanel.alpha, 0.0f, Time.deltaTime * 0.5f);
    if ((double) this.Yandere.position.z > 110.0 && (double) this.Yandere.position.z < 120.0)
      this.MorePanel.alpha = Mathf.MoveTowards(this.MorePanel.alpha, 1f, Time.deltaTime * 0.5f);
    else
      this.MorePanel.alpha = Mathf.MoveTowards(this.MorePanel.alpha, 0.0f, Time.deltaTime * 0.5f);
    if ((double) this.Yandere.position.z > 130.0 && (double) this.Yandere.position.z < 140.0)
    {
      this.CrowdfundPanel.alpha = Mathf.MoveTowards(this.CrowdfundPanel.alpha, 1f, Time.deltaTime * 0.5f);
      if (Input.GetButtonDown("A"))
        this.FadeOut = true;
      if (this.Hearts[1].isPlaying)
        return;
      this.Hearts[1].Play();
      this.Hearts[2].Play();
    }
    else
    {
      this.CrowdfundPanel.alpha = Mathf.MoveTowards(this.CrowdfundPanel.alpha, 0.0f, Time.deltaTime * 0.5f);
      this.Hearts[1].Stop();
      this.Hearts[2].Stop();
    }
  }
}
