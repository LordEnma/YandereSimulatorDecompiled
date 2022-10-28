// Decompiled with JetBrains decompiler
// Type: IntroScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class IntroScript : MonoBehaviour
{
  public PostProcessingBehaviour PostProcessing;
  public PostProcessingBehaviour GUIPP;
  public PostProcessingProfile Profile;
  public GameObject[] AttackPair;
  public GameObject MontagePrefab;
  public GameObject ConfessionScene;
  public GameObject ParentAndChild;
  public GameObject DeathCorridor;
  public GameObject BloodParent;
  public GameObject Particles;
  public GameObject Stalking;
  public GameObject School;
  public GameObject Osana;
  public GameObject Room;
  public GameObject Quad;
  public Texture[] Textures;
  public Transform RightForeArm;
  public Transform LeftForeArm;
  public Transform RightWrist;
  public Transform LeftWrist;
  public Transform MontageParent;
  public Transform Corridors;
  public Transform RightHand;
  public Transform Senpai;
  public Transform Head;
  public Animation BloodyHandsAnim;
  public Animation HoleInChestAnim;
  public Animation YoungFatherAnim;
  public Animation YoungRyobaAnim;
  public Animation StalkerAnim;
  public Animation YandereAnim;
  public Animation SenpaiAnim;
  public Animation MotherAnim;
  public Animation ChildAnim;
  public Animation[] AttackAnim;
  public Renderer[] TreeRenderer;
  public Renderer YoungFatherHairRenderer;
  public Renderer YoungFatherRenderer;
  public Renderer GrassBlades;
  public Renderer Montage;
  public Renderer Petals;
  public Renderer Mound;
  public Renderer Sky;
  public SkinnedMeshRenderer Yandere;
  public ParticleSystem Blossoms;
  public ParticleSystem Bubbles;
  public ParticleSystem Stars;
  public UISprite FadeOutDarkness;
  public UITexture LoveSickLogo;
  public UIPanel SkipPanel;
  public UISprite Darkness;
  public UISprite Circle;
  public UITexture Logo;
  public UILabel Label;
  public AudioSource Narration;
  public AudioSource BGM;
  public string[] Lines;
  public float[] Cue;
  public bool Narrating;
  public bool Musicing;
  public bool FadeOut;
  public bool New;
  public float CameraRotationX;
  public float CameraRotationY;
  public float ThirdSpeed;
  public float SecondSpeed;
  public float Speed;
  public float Brightness;
  public float StartTimer;
  public float SkipTimer;
  public float EyeTimer;
  public float Alpha;
  public float Timer;
  public float AnimTimer;
  public int PhotosSpawned;
  public int TextureID;
  public int ID;
  public float VibrationIntensity;
  public float VibrationTimer;
  public bool VibrationCheck;
  public Transform RightHair;
  public Transform LeftHair;
  public Transform Ponytail;
  public Transform RightHair2;
  public Transform LeftHair2;
  public Transform Ponytail2;
  public Transform BookRight;
  public Transform BookLeft;
  public Transform LeftArm;
  public Transform Neck;
  public float Rotation;
  public float Weight;
  public float X;
  public float Y;
  public float Z;
  public float X2;
  public float Y2;
  public float Z2;
  public UniformSetterScript[] UniformSetters;
  public GameObject[] OriginalHairs;
  public GameObject[] VtuberHairs;
  public Texture[] VtuberFaces;
  public Texture[] VtuberEyes;
  public SkinnedMeshRenderer YandereRenderer;
  public SkinnedMeshRenderer ChildRenderer;

  private void Start()
  {
    Application.targetFrameRate = 60;
    this.LoveSickCheck();
    this.Circle.fillAmount = 0.0f;
    if (!this.New)
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.Label.text = string.Empty;
    this.SkipTimer = 15f;
    if (this.New)
    {
      RenderSettings.ambientLight = new Color(1f, 1f, 1f);
      this.BloodyHandsAnim["f02_clenchFists_00"].speed = 0.166666f;
      this.HoleInChestAnim["f02_holeInChest_00"].speed = 0.0f;
      this.YoungRyobaAnim["f02_introHoldHands_00"].speed = 0.0f;
      this.YoungFatherAnim["introHoldHands_00"].speed = 0.0f;
      this.BrightenEnvironment();
      this.transform.position = new Vector3(0.0f, 1.255f, 0.2f);
      this.transform.eulerAngles = new Vector3(45f, 0.0f, 0.0f);
      this.HoleInChestAnim.gameObject.SetActive(false);
      this.BloodyHandsAnim.gameObject.SetActive(true);
      this.Montage.gameObject.SetActive(false);
      this.ConfessionScene.SetActive(false);
      this.ParentAndChild.SetActive(false);
      this.DeathCorridor.SetActive(false);
      this.Stalking.SetActive(false);
      this.School.SetActive(false);
      this.Room.SetActive(false);
      this.SetToDefault();
      this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
      {
        focusDistance = 0.66666f,
        aperture = 32f
      };
      foreach (Renderer componentsInChild in this.Corridors.gameObject.GetComponentsInChildren<Renderer>())
        componentsInChild.material.color = new Color(0.75f, 0.75f, 0.75f, 1f);
      this.AttackAnim[1]["f02_katanaHighSanityA_00"].speed = 2.5f;
      this.AttackAnim[2]["f02_katanaHighSanityB_00"].speed = 2.5f;
      this.AttackAnim[3]["f02_batLowSanityA_00"].speed = 2.5f;
      this.AttackAnim[4]["f02_batLowSanityB_00"].speed = 2.5f;
      this.AttackAnim[5]["f02_katanaLowSanityA_00"].speed = 2.5f;
      this.AttackAnim[6]["f02_katanaLowSanityB_00"].speed = 2.5f;
      this.MotherAnim["f02_parentTalking_00"].speed = 0.75f;
      this.ChildAnim["f02_childListening_00"].speed = 0.75f;
      for (int index = 4; index < this.Cue.Length; ++index)
      {
        if (index < 21)
          this.Cue[index] += 3.898f;
        else if (index > 32)
          this.Cue[index] += 4f;
        else
          this.Cue[index] += 2f;
        if (index > 40)
          this.Cue[index] += 3f;
      }
    }
    this.VtuberCheck();
  }

  private void Update()
  {
    if (this.VibrationCheck)
    {
      this.VibrationTimer = Mathf.MoveTowards(this.VibrationTimer, 0.0f, Time.deltaTime);
      if ((double) this.VibrationTimer == 0.0)
      {
        GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
        this.VibrationCheck = false;
      }
    }
    if (Input.GetButton("X"))
    {
      this.Circle.fillAmount = Mathf.MoveTowards(this.Circle.fillAmount, 1f, Time.deltaTime);
      this.SkipTimer = 15f;
      if ((double) this.Circle.fillAmount == 1.0)
        this.FadeOut = true;
      this.SkipPanel.alpha = 1f;
    }
    else
    {
      this.Circle.fillAmount = Mathf.MoveTowards(this.Circle.fillAmount, 0.0f, Time.deltaTime);
      this.SkipTimer -= Time.deltaTime * 2f;
      this.SkipPanel.alpha = this.SkipTimer / 10f;
    }
    this.StartTimer += Time.deltaTime;
    if ((double) this.StartTimer > 1.0 && !this.Narrating)
    {
      this.Narration.Play();
      this.Narrating = true;
      if ((Object) this.BGM != (Object) null)
        this.BGM.Play();
    }
    this.Timer = this.Narration.time;
    if (this.ID < this.Cue.Length && (double) this.Narration.time > (double) this.Cue[this.ID])
    {
      this.Label.text = this.Lines[this.ID];
      ++this.ID;
    }
    if (this.FadeOut)
    {
      this.FadeOutDarkness.color = new Color(this.FadeOutDarkness.color.r, this.FadeOutDarkness.color.g, this.FadeOutDarkness.color.b, Mathf.MoveTowards(this.FadeOutDarkness.color.a, 1f, Time.deltaTime));
      this.Circle.fillAmount = 1f;
      this.Narration.volume = this.FadeOutDarkness.color.a;
      if ((double) this.FadeOutDarkness.color.a == 1.0)
        SceneManager.LoadScene("PhoneScene");
    }
    if (!this.New)
    {
      if ((double) this.Narration.time > 39.75 && (double) this.Narration.time < 73.0)
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime * 0.5f));
      if ((double) this.Narration.time > 73.0 && (double) this.Narration.time < 105.5)
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if ((double) this.Narration.time > 105.5 && (double) this.Narration.time < 134.0)
        this.Darkness.color = new Color(1f, 0.0f, 0.0f, 1f);
      if ((double) this.Narration.time > 134.0 && (double) this.Narration.time < 147.0)
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
      if ((double) this.Narration.time > 147.0 && (double) this.Narration.time < 152.0)
      {
        this.Logo.transform.localScale = new Vector3(this.Logo.transform.localScale.x + Time.deltaTime * 0.1f, this.Logo.transform.localScale.y + Time.deltaTime * 0.1f, this.Logo.transform.localScale.z + Time.deltaTime * 0.1f);
        this.LoveSickLogo.transform.localScale = new Vector3(this.LoveSickLogo.transform.localScale.x + Time.deltaTime * 0.05f, this.LoveSickLogo.transform.localScale.y + Time.deltaTime * 0.05f, this.LoveSickLogo.transform.localScale.z + Time.deltaTime * 0.05f);
        this.Logo.color = new Color(this.Logo.color.r, this.Logo.color.g, this.Logo.color.b, 1f);
        this.LoveSickLogo.color = new Color(this.LoveSickLogo.color.r, this.LoveSickLogo.color.g, this.LoveSickLogo.color.b, 1f);
      }
      if ((double) this.Narration.time > 155.89799499511719)
      {
        this.Logo.color = new Color(this.Logo.color.r, this.Logo.color.g, this.Logo.color.b, 0.0f);
        this.LoveSickLogo.color = new Color(this.LoveSickLogo.color.r, this.LoveSickLogo.color.g, this.LoveSickLogo.color.b, 0.0f);
      }
      if ((double) this.Narration.time > 159.89799499511719)
        SceneManager.LoadScene("PhoneScene");
    }
    if (!this.New)
      return;
    if (this.ID > 19)
      this.AnimTimer += Time.deltaTime;
    if (this.ID > 52)
    {
      if (this.Narration.isPlaying)
        return;
      if ((Object) this.MontageParent != (Object) null)
      {
        Object.Destroy((Object) this.MontageParent.gameObject);
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        this.Montage.gameObject.SetActive(false);
        this.PostProcessing.enabled = true;
        this.Label.enabled = false;
        this.GUIPP.enabled = true;
        this.Speed = 0.0f;
        if (GameGlobals.LoveSick)
          this.LoveSickLogo.gameObject.SetActive(true);
        else
          this.Logo.gameObject.SetActive(true);
        this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
        {
          focusDistance = 10f
        };
        this.Profile.depthOfField.enabled = true;
        BloomModel.Settings settings = this.Profile.bloom.settings;
        settings.bloom.intensity = 1f;
        this.Profile.bloom.settings = settings;
        this.Profile.bloom.enabled = true;
        GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
        this.VibrationCheck = true;
        this.VibrationTimer = 0.1f;
      }
      this.Logo.transform.localScale = new Vector3(this.Logo.transform.localScale.x + Time.deltaTime * 0.1f, this.Logo.transform.localScale.y + Time.deltaTime * 0.1f, this.Logo.transform.localScale.z + Time.deltaTime * 0.1f);
      this.LoveSickLogo.transform.localScale = new Vector3(this.LoveSickLogo.transform.localScale.x + Time.deltaTime * 0.05f, this.LoveSickLogo.transform.localScale.y + Time.deltaTime * 0.05f, this.LoveSickLogo.transform.localScale.z + Time.deltaTime * 0.05f);
      this.Logo.color = new Color(this.Logo.color.r, this.Logo.color.g, this.Logo.color.b, 1f);
      this.LoveSickLogo.color = new Color(this.LoveSickLogo.color.r, this.LoveSickLogo.color.g, this.LoveSickLogo.color.b, 1f);
      this.Speed += Time.deltaTime;
      if ((double) this.Speed > 11.0)
      {
        SceneManager.LoadScene("PhoneScene");
      }
      else
      {
        if ((double) this.Speed <= 5.0 || !this.Logo.gameObject.activeInHierarchy && !this.LoveSickLogo.gameObject.activeInHierarchy)
          return;
        this.LoveSickLogo.gameObject.SetActive(false);
        this.Logo.gameObject.SetActive(false);
        GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
        this.VibrationCheck = true;
        this.VibrationTimer = 0.1f;
      }
    }
    else if (this.ID > 51)
    {
      if (this.DeathCorridor.activeInHierarchy)
      {
        RenderSettings.ambientLight = new Color(1f, 1f, 1f);
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        this.DeathCorridor.SetActive(false);
        this.PostProcessing.enabled = false;
        this.BloodParent.SetActive(false);
        this.Stalking.SetActive(false);
        this.BGM.volume = 1f;
        this.Speed = 0.0f;
        this.SetToDefault();
        this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
        {
          focusDistance = 10f
        };
        this.Profile.depthOfField.enabled = false;
        BloomModel.Settings settings = this.Profile.bloom.settings;
        settings.bloom.intensity = 0.5f;
        this.Profile.bloom.settings = settings;
        this.Profile.bloom.enabled = false;
        this.VibrationIntensity = 0.0f;
      }
      ++this.Speed;
      if ((double) this.Speed > 2.0)
      {
        this.Speed = 0.0f;
        ++this.TextureID;
        if (this.TextureID == 31)
          this.TextureID = 1;
        if (this.TextureID > 10 && this.TextureID < 21)
          this.PostProcessing.enabled = true;
        else
          this.PostProcessing.enabled = false;
        GameObject gameObject = Object.Instantiate<GameObject>(this.MontagePrefab, this.transform.position, Quaternion.identity);
        gameObject.GetComponent<Renderer>().material.mainTexture = this.Textures[this.TextureID];
        gameObject.transform.parent = this.MontageParent;
        gameObject.transform.localScale = new Vector3(0.6833265f, 0.384440482f, 0.33333f);
        gameObject.transform.localPosition = new Vector3(Random.Range(-0.633333f, 0.633333f), Random.Range(-0.29f, 0.29f), (float) this.PhotosSpawned * -0.0001f);
        gameObject.transform.localEulerAngles = new Vector3(0.0f, 0.0f, Random.Range(-15f, 15f));
        this.Montage.material.mainTexture = this.Textures[this.TextureID];
        ++this.PhotosSpawned;
      }
      if ((double) this.Timer > 225.0)
      {
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
      }
      else
      {
        this.VibrationIntensity += Time.deltaTime * 0.2f;
        GamePad.SetVibration(PlayerIndex.One, this.VibrationIntensity, this.VibrationIntensity);
        this.VibrationCheck = true;
        this.VibrationTimer = 0.1f;
      }
    }
    else if (this.ID > 41)
    {
      if ((double) this.transform.position.z < 0.0)
      {
        RenderSettings.ambientLight = new Color(0.2f, 0.2f, 0.2f);
        this.AttackPair[3].SetActive(false);
        this.DeathCorridor.SetActive(true);
        this.Stalking.SetActive(false);
        this.Quad.SetActive(false);
        this.transform.position = new Vector3(0.0f, 1f, 0.0f);
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, -15f);
        ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
        settings.basic.saturation = 1f;
        settings.channelMixer.red = new Vector3(1f, 0.0f, 0.0f);
        settings.channelMixer.green = new Vector3(0.0f, 1f, 0.0f);
        settings.channelMixer.blue = new Vector3(0.0f, 0.0f, 1f);
        this.Profile.colorGrading.settings = settings;
        this.Rotation = -15f;
        this.Speed = 0.0f;
        this.BGM.volume = 0.5f;
      }
      this.Speed += Time.deltaTime * 0.015f;
      this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0.0f, 1f, 34f), Time.deltaTime * this.Speed);
      this.Rotation = Mathf.Lerp(this.Rotation, 15f, Time.deltaTime * this.Speed);
      this.transform.eulerAngles = new Vector3(0.0f, 0.0f, this.Rotation);
      this.Alpha = this.ID >= 51 ? 1f : Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.2f);
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
    }
    else if (this.ID > 33)
    {
      if (this.School.activeInHierarchy)
      {
        this.School.SetActive(false);
        this.Stalking.SetActive(true);
        this.transform.position = new Vector3(-0.02f, 1.12f, 1f);
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        this.SetToDefault();
        this.Speed = 0.0f;
      }
      if (this.ID < 40)
      {
        this.VibrationIntensity += Time.deltaTime * 0.05f;
        GamePad.SetVibration(PlayerIndex.One, this.VibrationIntensity, this.VibrationIntensity);
        this.VibrationCheck = true;
        this.VibrationTimer = 0.1f;
      }
      if (this.ID < 37)
      {
        this.Speed += Time.deltaTime * 0.1f;
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(-0.02f, 1.12f, -0.25f), Time.deltaTime * this.Speed);
        this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.2f);
      }
      else
      {
        if ((double) this.Speed > 0.0)
        {
          this.CameraRotationY = 0.0f;
          this.Speed = 0.0f;
        }
        this.Speed -= Time.deltaTime * 0.1f;
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0.3f, 0.8f, -0.25f), (float) ((double) Time.deltaTime * (double) this.Speed * -1.0));
        this.CameraRotationY = Mathf.Lerp(this.CameraRotationY, -15f, (float) ((double) Time.deltaTime * (double) this.Speed * -1.0));
        this.transform.eulerAngles = new Vector3(0.0f, this.CameraRotationY, 0.0f);
        if ((double) this.Timer > 179.0)
          this.StalkerAnim.Play("f02_clenchFist_00");
        if (this.ID == 40)
          this.Alpha = 1f;
        if (this.ID > 39)
          this.BGM.volume += Time.deltaTime;
        if ((double) this.Timer > 186.0)
        {
          this.DeathCorridor.SetActive(true);
          this.Alpha = 1f;
        }
        else if ((double) this.Timer > 185.60000610351563)
        {
          this.AttackPair[2].SetActive(false);
          this.AttackPair[3].SetActive(true);
          GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
          this.VibrationCheck = true;
          this.VibrationTimer = 0.2f;
          this.Alpha = 0.0f;
        }
        else if ((double) this.Timer > 185.19999694824219)
          this.Alpha = 1f;
        else if ((double) this.Timer > 184.80000305175781)
        {
          this.AttackPair[1].SetActive(false);
          this.AttackPair[2].SetActive(true);
          GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
          this.VibrationCheck = true;
          this.VibrationTimer = 0.2f;
          this.Alpha = 0.0f;
        }
        else if ((double) this.Timer > 184.39999389648438)
          this.Alpha = 1f;
        else if ((double) this.Timer > 184.0)
        {
          ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
          settings.channelMixer.red = new Vector3(0.1f, 0.0f, 0.0f);
          settings.channelMixer.green = Vector3.zero;
          settings.channelMixer.blue = Vector3.zero;
          this.Profile.colorGrading.settings = settings;
          this.Alpha = 0.0f;
          this.Stalking.SetActive(false);
          this.Quad.SetActive(true);
          this.AttackPair[1].SetActive(true);
          GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
          this.VibrationCheck = true;
          this.VibrationTimer = 0.2f;
        }
      }
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
    }
    else if (this.ID > 31)
    {
      if (!this.Osana.activeInHierarchy)
      {
        this.transform.position = new Vector3(0.5f, 1.366666f, 0.25f);
        this.transform.eulerAngles = new Vector3(15f, -67.5f, 0.0f);
        this.SenpaiAnim.transform.parent.localPosition = new Vector3(0.533333f, 0.0f, -6.9f);
        this.SenpaiAnim.transform.parent.localEulerAngles = new Vector3(0.0f, 90f, 0.0f);
        this.SenpaiAnim.Play("Monday_1");
        this.Osana.SetActive(true);
        this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
        {
          focusDistance = 1.5f
        };
        this.YandereAnim["f02_Intro_00"].speed = 0.33333f;
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        this.Alpha = 0.0f;
      }
      this.transform.Translate(Vector3.forward * 0.01f * Time.deltaTime, Space.Self);
      this.TurnRed();
      if ((double) this.Narration.time <= 156.19999694824219)
        return;
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.Alpha = 1f;
    }
    else if (this.ID > 27)
    {
      if ((double) this.transform.position.x > 0.0)
      {
        this.transform.position = new Vector3(-1.5f, 1f, -1.5f);
        this.transform.eulerAngles = new Vector3(0.0f, 45f, 0.0f);
        this.YandereAnim["f02_Intro_00"].time += 0.0f;
        this.SenpaiAnim["Intro_00"].time += 0.0f;
        this.YandereAnim["f02_Intro_00"].speed = 1.33333f;
        this.SenpaiAnim["Intro_00"].speed = 1.33333f;
        this.Speed = 0.0f;
        this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
        {
          focusDistance = 1.5f,
          aperture = 11.2f
        };
      }
      if (this.ID > 28)
      {
        this.Speed += Time.deltaTime * 0.1f;
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(-1.1f, 1.33333f, 1f), Time.deltaTime * this.Speed);
        this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, new Vector3(0.0f, 135f, 0.0f), Time.deltaTime * this.Speed);
      }
      if (this.ID > 29)
      {
        this.Stars.Stop();
        this.Bubbles.Stop();
      }
      if (this.ID <= 30)
        return;
      this.TurnNeutral();
    }
    else if (this.ID > 23)
    {
      if ((double) this.EyeTimer == 0.0)
      {
        this.transform.position = new Vector3(0.0f, 0.9f, 0.0f);
        this.transform.eulerAngles = new Vector3(15f, -45f, 0.0f);
        this.YandereAnim["f02_Intro_00"].speed = 0.2f;
        this.SenpaiAnim["Intro_00"].speed = 0.2f;
        this.Yandere.materials[2].SetFloat("_BlendAmount", 1f);
        this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
        {
          focusDistance = 1.5f,
          aperture = 11.2f
        };
      }
      this.EyeTimer += Time.deltaTime;
      if ((double) this.EyeTimer > 0.10000000149011612)
      {
        this.Yandere.materials[2].SetTextureOffset("_OverlayTex", new Vector2(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f)));
        this.EyeTimer -= 0.1f;
      }
      this.transform.Translate(Vector3.forward * -0.1f * Time.deltaTime, Space.Self);
    }
    else if (this.ID > 19)
    {
      if (this.Room.gameObject.activeInHierarchy)
      {
        this.Room.gameObject.SetActive(false);
        this.School.SetActive(true);
        this.transform.localPosition = new Vector3(-3f, 1f, 1.5f);
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Alpha = 1f;
        this.Speed = 0.0f;
        ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
        settings.basic.saturation = 0.0f;
        this.Profile.colorGrading.settings = settings;
        this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
        {
          focusDistance = 10f,
          aperture = 5.6f
        };
        this.Yandere.materials[2].SetFloat("_BlendAmount", 0.0f);
      }
      if ((double) this.Narration.time < 94.898002624511719)
      {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(0.0f, 1f, -2f), Time.deltaTime * 1.09f);
      }
      else
      {
        this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
        {
          focusDistance = 1.2f,
          aperture = 11.2f
        };
        if ((double) this.Narration.time < 101.5)
        {
          this.transform.position = new Vector3(-0.25f, 0.75f, -0.25f);
          this.transform.eulerAngles = new Vector3(22.5f, -45f, 0.0f);
          this.Senpai.transform.position = new Vector3(0.0f, -0.2f, 0.0f);
        }
        else
        {
          this.Speed += Time.deltaTime * 0.5f;
          this.Senpai.transform.position = Vector3.Lerp(this.Senpai.transform.position, new Vector3(0.0f, 0.0f, 0.0f), (float) ((double) Time.deltaTime * (double) this.Speed * 2.0));
          this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(-0.25f, 0.66666f, -1.25f), (float) ((double) Time.deltaTime * (double) this.Speed * 0.5));
          this.CameraRotationX = Mathf.Lerp(this.CameraRotationX, 0.0f, Time.deltaTime * this.Speed);
          this.CameraRotationY = Mathf.Lerp(this.CameraRotationY, 0.0f, Time.deltaTime * this.Speed);
          this.transform.eulerAngles = new Vector3(this.CameraRotationX, this.CameraRotationY, 0.0f);
        }
      }
      if (this.ID > 21)
      {
        this.YandereAnim["f02_Intro_00"].speed = Mathf.MoveTowards(this.YandereAnim["f02_Intro_00"].speed, 0.1f, Time.deltaTime);
        this.SenpaiAnim["Intro_00"].speed = Mathf.MoveTowards(this.SenpaiAnim["Intro_00"].speed, 0.1f, Time.deltaTime);
        if ((double) this.Narration.time > 106.5)
        {
          ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
          settings.basic.saturation = Mathf.MoveTowards(settings.basic.saturation, 2f, Time.deltaTime);
          settings.channelMixer.red = Vector3.MoveTowards(settings.channelMixer.red, new Vector3(2f, 0.0f, 0.0f), Time.deltaTime);
          settings.channelMixer.blue = Vector3.MoveTowards(settings.channelMixer.blue, new Vector3(0.0f, 0.0f, 2f), Time.deltaTime);
          this.Profile.colorGrading.settings = settings;
          this.Particles.SetActive(true);
        }
      }
      else if ((double) this.Narration.time > 98.0)
      {
        this.YandereAnim["f02_Intro_00"].speed = 1f;
        this.SenpaiAnim["Intro_00"].speed = 1f;
      }
      else if ((double) this.Narration.time > 97.0)
      {
        this.YandereAnim["f02_Intro_00"].speed = 3f;
        this.SenpaiAnim["Intro_00"].speed = 3f;
      }
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.2f);
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
    }
    else if (this.ID > 15)
    {
      if (this.ParentAndChild.gameObject.activeInHierarchy)
      {
        this.ParentAndChild.gameObject.SetActive(false);
        this.Room.SetActive(true);
        this.transform.position = new Vector3(0.0f, 1f, 0.0f);
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Alpha = 1f;
        this.Speed = 0.1f;
        this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
        {
          focusDistance = 10f
        };
      }
      this.transform.position -= new Vector3(0.0f, 0.0f, (float) ((double) Time.deltaTime * (double) this.Speed * 0.75));
      this.Alpha = (double) this.Narration.time <= 88.898002624511719 ? Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.2f) : Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.66666f);
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
    }
    else if (this.ID > 13)
    {
      if (this.ConfessionScene.gameObject.activeInHierarchy)
      {
        this.ConfessionScene.gameObject.SetActive(false);
        this.ParentAndChild.SetActive(true);
        this.X = 15f;
        this.Y = -90f;
        this.X2 = 15f;
        this.Y2 = -90f;
        this.Z2 = 0.0f;
        this.transform.position = new Vector3(0.0f, 0.5f, -1f);
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Alpha = 1f;
        this.Speed = 0.1f;
        ColorGradingModel.Settings settings1 = this.Profile.colorGrading.settings;
        settings1.basic.saturation = 1f;
        this.Profile.colorGrading.settings = settings1;
        BloomModel.Settings settings2 = this.Profile.bloom.settings;
        settings2.bloom.intensity = 1f;
        this.Profile.bloom.settings = settings2;
        this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
        {
          focusDistance = 10f,
          aperture = 11.2f
        };
      }
      this.transform.position -= new Vector3(0.0f, 0.0f, Time.deltaTime * this.Speed);
      this.Alpha = (double) this.Narration.time <= 69.898002624511719 ? Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.2f) : Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.5f);
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
    }
    else if (this.ID > 9)
    {
      if (this.HoleInChestAnim.gameObject.activeInHierarchy)
      {
        this.HoleInChestAnim.gameObject.SetActive(false);
        this.ConfessionScene.SetActive(true);
        this.transform.position = new Vector3(0.0f, 1f, -1f);
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.Alpha = 1f;
        this.Speed = 0.1f;
        this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
        {
          focusDistance = 1f
        };
        ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
        settings.basic.saturation = 0.0f;
        this.Profile.colorGrading.settings = settings;
      }
      this.transform.position -= new Vector3(0.0f, 0.0f, Time.deltaTime * this.Speed);
      if (this.ID > 10)
      {
        this.YoungRyobaAnim["f02_introHoldHands_00"].speed = 0.5f;
        this.YoungRyobaAnim.Play();
        this.YoungFatherAnim["introHoldHands_00"].speed = 0.5f;
        this.YoungFatherAnim.Play();
        this.Brightness = Mathf.MoveTowards(this.Brightness, 1f, Time.deltaTime * 0.25f);
        this.BrightenEnvironment();
        this.Blossoms.Play();
        this.X = Mathf.MoveTowards(this.X, 0.0f, Time.deltaTime * 10f);
      }
      if (this.ID > 11)
      {
        ColorGradingModel.Settings settings3 = this.Profile.colorGrading.settings;
        settings3.basic.saturation += Time.deltaTime * 0.25f;
        BloomModel.Settings settings4 = this.Profile.bloom.settings;
        settings4.bloom.intensity = 1f + settings3.basic.saturation;
        this.Profile.bloom.settings = settings4;
        this.Profile.colorGrading.settings = settings3;
      }
      this.Alpha = (double) this.Narration.time <= 56.897998809814453 ? Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.2f) : Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.5f);
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
    }
    else if (this.ID > 4)
    {
      if (this.BloodyHandsAnim.gameObject.activeInHierarchy)
      {
        this.transform.position = new Vector3(0.012f, 1.13f, 0.029f);
        this.transform.eulerAngles = Vector3.zero;
        this.BloodyHandsAnim.gameObject.SetActive(false);
        this.HoleInChestAnim.gameObject.SetActive(true);
        this.Alpha = 0.0f;
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
        this.SetToDefault();
      }
      this.Speed = Mathf.MoveTowards(this.Speed, 0.1f, Time.deltaTime * 0.01f);
      this.transform.position -= new Vector3(0.0f, 0.0f, Time.deltaTime * this.Speed);
      if ((double) this.transform.position.z < -0.05000000074505806)
      {
        this.SecondSpeed = Mathf.MoveTowards(this.SecondSpeed, 0.1f, Time.deltaTime * 0.1f);
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x, 1f, this.transform.position.z), Time.deltaTime * this.SecondSpeed);
      }
      if ((double) this.transform.position.z < -0.5)
      {
        this.HoleInChestAnim["f02_holeInChest_00"].speed = 0.5f;
        this.HoleInChestAnim.Play();
      }
      if (this.ID <= 8)
        return;
      this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.2f);
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
    }
    else
    {
      if (this.ID <= 0)
        return;
      if ((double) this.Timer < 2.0)
      {
        this.BloodyHandsAnim["f02_clenchFists_00"].time = 0.6f;
        this.BloodyHandsAnim["f02_clenchFists_00"].speed = 0.0f;
      }
      else
        this.BloodyHandsAnim["f02_clenchFists_00"].speed = 0.07f;
      if (this.ID <= 3)
        return;
      this.Alpha = 1f;
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      this.BGM.volume = Mathf.MoveTowards(this.BGM.volume, 0.5f, Time.deltaTime * 0.266666f);
    }
  }

  private void LateUpdate()
  {
    if (!this.New)
      return;
    if (this.ID < 41)
    {
      if ((double) this.Narration.time > 103.0)
      {
        if (this.ID < 24)
        {
          this.LeftArm.localEulerAngles = new Vector3(0.0f, 15f, 0.0f);
          this.BookRight.localEulerAngles = new Vector3(0.0f, 180f, -90f);
          this.BookLeft.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
          this.BookRight.parent.parent.localPosition = new Vector3(-0.12f, -0.04f, 0.0f);
          this.BookRight.parent.parent.localEulerAngles = new Vector3(0.0f, -15f, -135f);
          this.BookRight.parent.parent.parent.localEulerAngles = new Vector3(45f, 45f, 0.0f);
        }
        else
        {
          this.BookRight.parent.parent.localPosition = new Vector3(-0.075f, -0.085f, 0.0f);
          this.BookRight.parent.parent.localEulerAngles = new Vector3(0.0f, -45f, -90f);
          this.BookRight.localEulerAngles = new Vector3(0.0f, 180f, -45f);
          this.BookLeft.localEulerAngles = new Vector3(0.0f, 180f, 45f);
        }
      }
      else if ((double) this.Narration.time > 94.898002624511719)
        this.Rotation = 22.5f;
    }
    if ((double) this.Narration.time > 104.0 && (double) this.Narration.time < 190.0)
    {
      this.ThirdSpeed += Time.deltaTime;
      this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * 3.6f * this.ThirdSpeed);
    }
    this.Neck.localEulerAngles += new Vector3(this.Rotation, 0.0f, 0.0f);
    if ((double) this.Narration.time > 99.0)
      this.Weight = Mathf.MoveTowards(this.Weight, 0.0f, Time.deltaTime * 20f);
    else if ((double) this.Narration.time > 96.648002624511719)
      this.Weight = Mathf.MoveTowards(this.Weight, 50f, Time.deltaTime * 100f);
    this.Yandere.SetBlendShapeWeight(5, this.Weight);
    this.Ponytail.transform.eulerAngles = new Vector3(this.X, this.Y, this.Z);
    this.Ponytail.transform.GetChild(0).eulerAngles = new Vector3(0.0f, 90f, 0.0f);
    this.RightHair.transform.eulerAngles = new Vector3(this.X2, this.Y2, this.Z2);
    this.LeftHair.transform.eulerAngles = new Vector3(this.X2, this.Y2, this.Z2);
    this.Ponytail2.transform.eulerAngles = new Vector3(this.X, this.Y, this.Z);
    this.RightHair2.transform.eulerAngles = new Vector3(this.X2, this.Y2, this.Z2);
    this.LeftHair2.transform.eulerAngles = new Vector3(this.X2, this.Y2, this.Z2);
    this.RightHand.localEulerAngles += new Vector3(Random.Range(1f, -1f), Random.Range(1f, -1f), Random.Range(1f, -1f));
  }

  private void LoveSickCheck()
  {
    if (GameGlobals.LoveSick)
    {
      Camera.main.backgroundColor = new Color(0.0f, 0.0f, 0.0f, 1f);
      foreach (GameObject gameObject in Object.FindObjectsOfType<GameObject>())
      {
        UISprite component1 = gameObject.GetComponent<UISprite>();
        if ((Object) component1 != (Object) null)
          component1.color = new Color(1f, 0.0f, 0.0f, component1.color.a);
        UITexture component2 = gameObject.GetComponent<UITexture>();
        if ((Object) component2 != (Object) null)
          component2.color = new Color(1f, 0.0f, 0.0f, component2.color.a);
        UILabel component3 = gameObject.GetComponent<UILabel>();
        if ((Object) component3 != (Object) null && component3.color != Color.black)
          component3.color = new Color(1f, 0.0f, 0.0f, component3.color.a);
      }
      this.FadeOutDarkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.LoveSickLogo.enabled = true;
      this.Logo.enabled = false;
    }
    else
      this.LoveSickLogo.enabled = false;
  }

  private void BrightenEnvironment()
  {
    this.TreeRenderer[0].materials[0].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
    this.TreeRenderer[0].materials[1].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
    this.TreeRenderer[1].materials[0].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
    this.TreeRenderer[1].materials[1].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
    this.TreeRenderer[2].materials[0].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
    this.TreeRenderer[2].materials[1].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
    this.GrassBlades.material.SetColor("_BladeTopColor", new Color(0.0f, this.Brightness * 0.5f, 0.0f, 1f));
    this.Petals.material.color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
    this.Mound.material.color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
    this.Sky.material.color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
    this.YoungFatherRenderer.materials[0].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
    this.YoungFatherRenderer.materials[1].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
    this.YoungFatherRenderer.materials[2].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
    this.YoungFatherHairRenderer.material.color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
  }

  private void TurnNeutral()
  {
    ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
    settings.channelMixer.red = Vector3.MoveTowards(settings.channelMixer.red, new Vector3(1f, 0.0f, 0.0f), Time.deltaTime * 0.66666f);
    settings.channelMixer.green = Vector3.MoveTowards(settings.channelMixer.green, new Vector3(0.0f, 1f, 0.0f), Time.deltaTime * 0.66666f);
    settings.channelMixer.blue = Vector3.MoveTowards(settings.channelMixer.blue, new Vector3(0.0f, 0.0f, 1f), Time.deltaTime * 0.66666f);
    this.Profile.colorGrading.settings = settings;
  }

  private void TurnRed()
  {
    ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
    settings.basic.saturation = Mathf.MoveTowards(settings.basic.saturation, 1f, Time.deltaTime * 0.1f);
    settings.channelMixer.red = Vector3.MoveTowards(settings.channelMixer.red, new Vector3(1f, 0.0f, 0.0f), Time.deltaTime * 0.1f);
    settings.channelMixer.green = Vector3.MoveTowards(settings.channelMixer.green, new Vector3(0.0f, 0.5f, 0.0f), Time.deltaTime * 0.1f);
    settings.channelMixer.blue = Vector3.MoveTowards(settings.channelMixer.blue, new Vector3(0.0f, 0.0f, 0.5f), Time.deltaTime * 0.1f);
    this.Profile.colorGrading.settings = settings;
  }

  private void SetToDefault()
  {
    ColorGradingModel.Settings settings1 = this.Profile.colorGrading.settings;
    settings1.basic.saturation = 1f;
    settings1.channelMixer.red = new Vector3(1f, 0.0f, 0.0f);
    settings1.channelMixer.green = new Vector3(0.0f, 1f, 0.0f);
    settings1.channelMixer.blue = new Vector3(0.0f, 0.0f, 1f);
    this.Profile.colorGrading.settings = settings1;
    this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
    {
      focusDistance = 10f,
      aperture = 11.2f
    };
    BloomModel.Settings settings2 = this.Profile.bloom.settings;
    settings2.bloom.intensity = 1f;
    this.Profile.bloom.settings = settings2;
  }

  private void VtuberCheck()
  {
    if (GameGlobals.VtuberID > 0)
    {
      for (int index = 1; index < this.OriginalHairs.Length; ++index)
      {
        this.OriginalHairs[index].SetActive(false);
        this.VtuberHairs[index].SetActive(true);
      }
      for (int index = 1; index < this.UniformSetters.Length; ++index)
      {
        this.UniformSetters[index].AyanoFace = this.VtuberFaces[GameGlobals.VtuberID];
        this.UniformSetters[index].SetFemaleUniform();
      }
      for (int index = 0; index < 13; ++index)
        this.YandereRenderer.SetBlendShapeWeight(index, 0.0f);
      this.YandereRenderer.SetBlendShapeWeight(9, 100f);
      this.ChildRenderer.materials[0].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
      this.ChildRenderer.materials[2].mainTexture = this.VtuberEyes[GameGlobals.VtuberID];
    }
    else
    {
      for (int index = 1; index < this.VtuberHairs.Length; ++index)
        this.VtuberHairs[index].SetActive(false);
    }
  }
}
