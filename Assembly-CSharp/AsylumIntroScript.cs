// Decompiled with JetBrains decompiler
// Type: AsylumIntroScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.PostProcessing;

public class AsylumIntroScript : MonoBehaviour
{
  public PostProcessingProfile Profile;
  public StalkerYandereScript Yandere;
  public RPG_Camera RPGCamera;
  public Renderer Darkness;
  public Vector3 Rotation;
  public float Alpha;
  public float Speed;
  public float Timer;
  public float DOF;
  public int Phase;
  public GameObject[] Bags;
  public UIPanel SkipPanel;
  public UISprite SkipCircle;
  private float SkipTimer;

  private void Start()
  {
    this.Profile.colorGrading.enabled = true;
    RenderSettings.ambientIntensity = 8f;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    this.transform.position = new Vector3(-21.7985f, 1f, -29f);
    this.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
    this.Yandere.transform.position = new Vector3(-21.7985f, 0.0f, -31f);
    this.Yandere.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    Physics.SyncTransforms();
    this.SetVignetteBlack();
    this.UpdateDOF(4f);
    this.DOF = 4f;
    this.Alpha = 1f;
    this.Yandere.Start();
    this.SkipPanel.alpha = 0.0f;
    for (int index = 10 - DateGlobals.Week; index > 0; --index)
      this.Bags[index].SetActive(false);
  }

  private void Update()
  {
    if (this.SkipPanel.enabled)
      this.UpdateSkipPanel();
    if (this.Phase == 0)
    {
      if ((double) this.Alpha < 1.0)
      {
        this.Yandere.transform.position = new Vector3(-22.1f, -3.965f, -34f);
        this.Yandere.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        Physics.SyncTransforms();
      }
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.5f);
      this.Darkness.material.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      if ((double) this.Alpha != 0.0)
        return;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 1.0)
        return;
      this.Yandere.VtuberCheck();
      this.Timer = 0.0f;
      ++this.Phase;
    }
    else if (this.Phase == 1)
    {
      if ((double) this.Timer == 0.0)
      {
        this.Yandere.MyAnimation["f02_climbTrellis_00"].time = 7f;
        this.Yandere.MyAnimation.Play();
      }
      this.Timer += Time.deltaTime;
      if ((double) this.Yandere.MyAnimation["f02_climbTrellis_00"].time <= 15.0)
        return;
      this.Yandere.MyAnimation.Play("f02_idleShort_00");
      this.Yandere.transform.position = new Vector3(-21.7985f, 0.03203398f, -29f);
      this.transform.position = new Vector3(-21.3985f, 1.33203387f, -28.4f);
      this.transform.eulerAngles = new Vector3(0.0f, -135f, 0.0f);
      Physics.SyncTransforms();
      this.DOF = 0.5f;
      this.UpdateDOF(this.DOF);
      this.Speed = -1f;
      ++this.Phase;
    }
    else
    {
      if (this.Phase != 2)
        return;
      this.Speed += Time.deltaTime;
      if ((double) this.Speed > -1.0)
      {
        this.Yandere.MyAnimation.CrossFade("f02_stealthIdle_00");
        this.Yandere.transform.position = new Vector3(-21.7985f, 0.03203398f, -29f);
        Physics.SyncTransforms();
      }
      if ((double) this.Speed <= 0.0)
        return;
      this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(-21.7985f, 1.547184f, -30.92219f), Time.deltaTime * this.Speed);
      this.Rotation = Vector3.Lerp(this.Rotation, new Vector3(15f, 0.0f, 0.0f), (float) ((double) Time.deltaTime * (double) this.Speed * 2.0));
      this.transform.eulerAngles = this.Rotation;
      this.DOF = Mathf.MoveTowards(this.DOF, 2f, Time.deltaTime * this.Speed);
      this.UpdateDOF(this.DOF);
      if ((double) this.Speed <= 4.0)
        return;
      this.Darkness.material.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.DOF = 2f;
      this.UpdateDOF(this.DOF);
      this.SkipPanel.enabled = false;
      this.RPGCamera.enabled = true;
      this.Yandere.enabled = true;
      ++this.Phase;
    }
  }

  private void UpdateDOF(float Value) => this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
  {
    focusDistance = Value,
    aperture = 5.6f
  };

  public void SetVignetteBlack() => this.Profile.vignette.settings = this.Profile.vignette.settings with
  {
    color = new Color(0.0f, 0.0f, 0.0f, 1f),
    intensity = 0.45f,
    smoothness = 0.2f,
    roundness = 1f
  };

  private void UpdateSkipPanel()
  {
    this.SkipTimer += Time.deltaTime;
    if ((double) this.SkipTimer > 1.0)
      this.SkipPanel.alpha += Time.deltaTime;
    if (Input.GetButton("X"))
    {
      this.SkipPanel.alpha = 1f;
      this.SkipTimer = 0.0f;
      this.SkipCircle.fillAmount -= Time.deltaTime;
      if ((double) this.SkipCircle.fillAmount != 0.0)
        return;
      this.Phase = 2;
      this.Speed = 100f;
      this.Yandere.MyAnimation.Play("f02_stealthIdle_00");
    }
    else
      this.SkipCircle.fillAmount = 1f;
  }
}
