// Decompiled with JetBrains decompiler
// Type: DokiScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DokiScript : MonoBehaviour
{
  public YandereShoeLockerScript ShoeLocker;
  public MusicCreditScript Credits;
  public YandereScript Yandere;
  public PromptScript OtherPrompt;
  public PromptScript Prompt;
  public GameObject TransformEffect;
  public Texture DokiTexture;
  public Texture[] DokiSocks;
  public Texture[] DokiHair;
  public string[] DokiName;
  public int ID;

  private void Update()
  {
    if (!this.Yandere.Egg)
    {
      if ((double) this.OtherPrompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.enabled = false;
      }
      if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
        return;
      this.Yandere.PantyAttacher.newRenderer.enabled = false;
      this.Prompt.Circle[0].fillAmount = 1f;
      Object.Instantiate<GameObject>(this.TransformEffect, this.Yandere.Hips.position, Quaternion.identity);
      this.Yandere.MyRenderer.sharedMesh = this.Yandere.Uniforms[4];
      this.Yandere.MyRenderer.materials[0].mainTexture = this.DokiTexture;
      this.Yandere.MyRenderer.materials[1].mainTexture = this.DokiTexture;
      ++this.ID;
      if (this.ID > 4)
        this.ID = 1;
      this.Credits.SongLabel.text = this.DokiName[this.ID] + " from Doki Doki Literature Club";
      this.Credits.BandLabel.text = "by Team Salvato";
      this.Credits.Panel.enabled = true;
      this.Credits.Slide = true;
      this.Credits.Timer = 0.0f;
      if (this.ID == 1)
      {
        this.Yandere.MyRenderer.materials[0].SetTexture("_OverlayTex", this.DokiSocks[0]);
        this.Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", this.DokiSocks[0]);
      }
      else
      {
        this.Yandere.MyRenderer.materials[0].SetTexture("_OverlayTex", this.DokiSocks[1]);
        this.Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", this.DokiSocks[1]);
      }
      Debug.Log((object) "Activating shadows on Yandere-chan.");
      this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
      this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
      this.Yandere.MyRenderer.materials[2].mainTexture = this.DokiHair[this.ID];
      this.Yandere.Hairstyle = 136 + this.ID;
      this.Yandere.UpdateHair();
      this.ShoeLocker.enabled = false;
    }
    else
    {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.enabled = false;
    }
  }
}
