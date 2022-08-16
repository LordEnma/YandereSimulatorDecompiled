// Decompiled with JetBrains decompiler
// Type: StalkerIntroScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.PostProcessing;

public class StalkerIntroScript : MonoBehaviour
{
  public PostProcessingProfile Profile;
  public StalkerYandereScript Yandere;
  public RPG_Camera RPGCamera;
  public Transform CameraFocus;
  public Transform Moon;
  public Renderer Darkness;
  public float Alpha;
  public float Speed;
  public float Timer;
  public float DOF;
  public int Phase;
  public GameObject[] Neighborhood;
  public UIPanel SkipPanel;
  public UISprite SkipCircle;
  private float SkipTimer;

  private void Start()
  {
    if ((Object) this.Yandere.InstructionLabel != (Object) null)
      this.Yandere.InstructionLabel.alpha = 0.0f;
    this.Profile.colorGrading.enabled = true;
    RenderSettings.ambientIntensity = 8f;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    this.transform.position = new Vector3(12.5f, 5f, 13f);
    this.transform.LookAt(this.Moon);
    this.CameraFocus.parent = this.transform;
    this.CameraFocus.localPosition = new Vector3(0.0f, 0.0f, 100f);
    this.CameraFocus.parent = (Transform) null;
    this.SetVignetteBlack();
    this.UpdateDOF(4f);
    this.DOF = 4f;
    this.Alpha = 1f;
    this.Yandere.Start();
    this.SkipPanel.alpha = 0.0f;
  }

  private void Update()
  {
    if (this.SkipPanel.enabled)
      this.UpdateSkipPanel();
    this.Moon.LookAt(this.transform);
    if (this.Phase == 0)
    {
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.5f);
      this.Darkness.material.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      if ((double) this.Alpha != 0.0)
        return;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 2.0)
        return;
      this.Yandere.VtuberCheck();
      ++this.Phase;
    }
    else if (this.Phase == 1)
    {
      if ((double) this.Speed == 0.0)
        this.Yandere.MyAnimation.Play();
      this.Speed += Time.deltaTime;
      this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(11.5f, 1f, 13f), Time.deltaTime * this.Speed);
      this.CameraFocus.position = Vector3.Lerp(this.CameraFocus.position, new Vector3(13.62132f, 1f, 15.12132f), Time.deltaTime * this.Speed);
      this.DOF = Mathf.MoveTowards(this.DOF, 1.4f, Time.deltaTime * this.Speed);
      this.UpdateDOF(this.DOF);
      this.transform.LookAt(this.CameraFocus);
      if ((double) this.Yandere.MyAnimation["f02_jumpOverWall_00"].time <= 13.0)
        return;
      this.Yandere.transform.position = new Vector3(13.15f, 0.0f, 13f);
      this.transform.position = new Vector3(12.75f, 1.3f, 12.4f);
      this.transform.eulerAngles = new Vector3(0.0f, 45f, 0.0f);
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
      if ((double) this.Speed <= 0.0)
        return;
      this.Yandere.transform.position = new Vector3(13.15f, 0.0f, 13f);
      this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(13.15f, 1.51515f, 14.92272f), Time.deltaTime * this.Speed);
      this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, new Vector3(15f, 180f, 0.0f), (float) ((double) Time.deltaTime * (double) this.Speed * 2.0));
      this.DOF = Mathf.MoveTowards(this.DOF, 2f, Time.deltaTime * this.Speed);
      this.UpdateDOF(this.DOF);
      if ((double) this.Speed <= 4.0)
        return;
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
