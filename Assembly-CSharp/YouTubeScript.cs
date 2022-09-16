// Decompiled with JetBrains decompiler
// Type: YouTubeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using RetroAesthetics;
using UnityEngine;

public class YouTubeScript : MonoBehaviour
{
  public RetroCameraEffect EightiesEffects;
  public CameraEffectsScript CameraEffects;
  public NormalBufferView VaporwaveVisuals;
  public Camera MyCamera;
  public YandereScript Yandere;
  public GameObject[] Label;
  public GameObject[] Trees;
  public Animation Girl;
  public float Strength;
  public float Focus = 1f;
  public float Bloom = 60f;
  public float Knee = 1f;
  public float Radius = 7f;
  public float Threshold;
  public float Speed;
  public float Timer;
  public bool Begin;
  public int Phase;
  public int Type;

  private void Start()
  {
    if (!((Object) this.Girl != (Object) null))
      return;
    this.Girl["OkaTurn1"].time = 15f;
  }

  private void Update()
  {
    if (this.Type == 6)
      this.MyCamera.orthographicSize -= Time.deltaTime * 0.0333333351f;
    if (Input.GetKeyDown("z"))
    {
      ++this.Phase;
      if (this.Type == 5)
        this.Label[this.Phase].SetActive(true);
    }
    if (this.Phase > 0)
    {
      if (this.Type == 1)
        this.transform.position += new Vector3(0.0f, 0.0f, Time.deltaTime * -0.1f);
      else if (this.Type == 2)
        this.transform.Translate(Vector3.forward * Time.deltaTime * -1f * this.Speed);
      else if (this.Type == 3)
      {
        this.transform.Translate(Vector3.forward * Time.deltaTime * -1f);
        this.Begin = true;
      }
      else if (this.Type == 4)
        this.Begin = true;
    }
    if (!this.Begin)
      return;
    if (this.Type != 4)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 1.0)
        return;
      if (this.Phase == 1)
      {
        this.VaporwaveVisuals.ApplyNormalView();
        RenderSettings.skybox = this.Yandere.VaporwaveSkybox;
        ++this.Phase;
        this.Bloom = 5f;
        this.Threshold = 0.0f;
        this.Knee = 1f;
        this.Radius = 7f;
        this.CameraEffects.UpdateBloom(this.Bloom);
        this.CameraEffects.UpdateThreshold(this.Threshold);
        this.CameraEffects.UpdateBloomKnee(this.Knee);
        this.CameraEffects.UpdateBloomRadius(this.Radius);
        for (int index = 1; index < this.Trees.Length; ++index)
        {
          Debug.Log((object) "Deactivating trees...or trying to.");
          this.Trees[index].SetActive(false);
        }
        this.EightiesEffects.enabled = true;
      }
      else
      {
        this.Bloom = Mathf.Lerp(this.Bloom, 1f, Time.deltaTime);
        this.Threshold = Mathf.Lerp(this.Bloom, 1.1f, Time.deltaTime);
        this.Knee = Mathf.Lerp(this.Bloom, 0.5f, Time.deltaTime);
        this.Radius = Mathf.Lerp(this.Bloom, 4f, Time.deltaTime);
        this.CameraEffects.UpdateBloom(this.Bloom);
        this.CameraEffects.UpdateThreshold(this.Threshold);
        this.CameraEffects.UpdateBloomKnee(this.Knee);
        this.CameraEffects.UpdateBloomRadius(this.Radius);
      }
    }
    else
    {
      this.Speed += Time.deltaTime;
      this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(-1.3f, 0.0f, 0.4f), Time.deltaTime * this.Speed);
    }
  }
}
