// Decompiled with JetBrains decompiler
// Type: CustomizationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class CustomizationScript : MonoBehaviour
{
  [SerializeField]
  private CustomizationScript.CustomizationData Data;
  [SerializeField]
  private InputManagerScript InputManager;
  [SerializeField]
  private Renderer FacialHairRenderer;
  [SerializeField]
  private SkinnedMeshRenderer YandereRenderer;
  [SerializeField]
  private SkinnedMeshRenderer SenpaiRenderer;
  [SerializeField]
  private Renderer HairRenderer;
  [SerializeField]
  private AudioSource MyAudio;
  [SerializeField]
  private Renderer EyeR;
  [SerializeField]
  private Renderer EyeL;
  [SerializeField]
  private Transform UniformHighlight;
  [SerializeField]
  private Transform ApologyWindow;
  [SerializeField]
  private Transform YandereHead;
  [SerializeField]
  private Transform YandereNeck;
  [SerializeField]
  private Transform SenpaiHead;
  [SerializeField]
  private Transform Highlight;
  [SerializeField]
  private Transform Yandere;
  [SerializeField]
  private Transform Senpai;
  [SerializeField]
  private Transform[] Corridor;
  [SerializeField]
  private UIPanel CustomizePanel;
  [SerializeField]
  private UIPanel UniformPanel;
  [SerializeField]
  private UIPanel FinishPanel;
  [SerializeField]
  private UIPanel GenderPanel;
  [SerializeField]
  private UIPanel WhitePanel;
  [SerializeField]
  private UILabel FacialHairStyleLabel;
  [SerializeField]
  private UILabel FemaleUniformLabel;
  [SerializeField]
  private UILabel MaleUniformLabel;
  [SerializeField]
  private UILabel SkinColorLabel;
  [SerializeField]
  private UILabel HairStyleLabel;
  [SerializeField]
  private UILabel HairColorLabel;
  [SerializeField]
  private UILabel EyeColorLabel;
  [SerializeField]
  private UILabel EyeWearLabel;
  [SerializeField]
  private GameObject LoveSickCamera;
  [SerializeField]
  private GameObject CensorCloud;
  [SerializeField]
  private GameObject BigCloud;
  [SerializeField]
  private GameObject Hearts;
  [SerializeField]
  private GameObject Cloud;
  [SerializeField]
  private UISprite Black;
  [SerializeField]
  private UISprite White;
  private bool SkipToCalendar;
  private bool Apologize;
  private bool LoveSick;
  private bool FadeOut;
  [SerializeField]
  private float ScrollSpeed;
  [SerializeField]
  private float Timer;
  [SerializeField]
  private int Selected = 1;
  [SerializeField]
  private int Phase = 1;
  [SerializeField]
  private Texture[] FemaleUniformTextures;
  [SerializeField]
  private Texture[] MaleUniformTextures;
  [SerializeField]
  private Texture[] FaceTextures;
  [SerializeField]
  private Texture[] SkinTextures;
  [SerializeField]
  private GameObject[] FacialHairstyles;
  [SerializeField]
  private GameObject[] Hairstyles;
  [SerializeField]
  private GameObject[] Eyewears;
  [SerializeField]
  private Mesh[] FemaleUniforms;
  [SerializeField]
  private Mesh[] MaleUniforms;
  [SerializeField]
  private Texture FemaleFace;
  [SerializeField]
  private string HairColorName = string.Empty;
  [SerializeField]
  private string EyeColorName = string.Empty;
  [SerializeField]
  private AudioClip LoveSickIntro;
  [SerializeField]
  private AudioClip LoveSickLoop;
  public float AbsoluteRotation;
  public float Adjustment;
  public float Rotation;
  public PostProcessingProfile Profile;
  public GameObject YandereHair;
  public GameObject[] VtuberHair;
  public Texture[] VtuberFace;
  public bool OriginalDOFStatus;
  private static readonly KeyValuePair<Color, string>[] ColorPairs = new KeyValuePair<Color, string>[11]
  {
    new KeyValuePair<Color, string>(new Color(), string.Empty),
    new KeyValuePair<Color, string>(new Color(0.5f, 0.5f, 0.5f), nameof (Black)),
    new KeyValuePair<Color, string>(new Color(1f, 0.0f, 0.0f), "Red"),
    new KeyValuePair<Color, string>(new Color(1f, 1f, 0.0f), "Yellow"),
    new KeyValuePair<Color, string>(new Color(0.0f, 1f, 0.0f), "Green"),
    new KeyValuePair<Color, string>(new Color(0.0f, 1f, 1f), "Cyan"),
    new KeyValuePair<Color, string>(new Color(0.0f, 0.0f, 1f), "Blue"),
    new KeyValuePair<Color, string>(new Color(1f, 0.0f, 1f), "Purple"),
    new KeyValuePair<Color, string>(new Color(1f, 0.5f, 0.0f), "Orange"),
    new KeyValuePair<Color, string>(new Color(0.5f, 0.25f, 0.0f), "Brown"),
    new KeyValuePair<Color, string>(new Color(1f, 1f, 1f), nameof (White))
  };

  private void Awake()
  {
    this.Data = new CustomizationScript.CustomizationData();
    this.Data.skinColor = new RangeInt(3, this.MinSkinColor, this.MaxSkinColor);
    this.Data.hairstyle = new RangeInt(1, this.MinHairstyle, this.MaxHairstyle);
    this.Data.hairColor = new RangeInt(1, this.MinHairColor, this.MaxHairColor);
    this.Data.eyeColor = new RangeInt(1, this.MinEyeColor, this.MaxEyeColor);
    this.Data.eyewear = new RangeInt(0, this.MinEyewear, this.MaxEyewear);
    this.Data.facialHair = new RangeInt(0, this.MinFacialHair, this.MaxFacialHair);
    this.Data.maleUniform = new RangeInt(1, this.MinMaleUniform, this.MaxMaleUniform);
    this.Data.femaleUniform = new RangeInt(1, this.MinFemaleUniform, this.MaxFemaleUniform);
  }

  private void Start()
  {
    this.OriginalDOFStatus = this.Profile.depthOfField.enabled;
    this.Profile.depthOfField.enabled = false;
    Cursor.visible = false;
    Time.timeScale = 1f;
    this.LoveSick = GameGlobals.LoveSick;
    this.ApologyWindow.localPosition = new Vector3(1555f, this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
    this.CustomizePanel.alpha = 0.0f;
    this.UniformPanel.alpha = 0.0f;
    this.FinishPanel.alpha = 0.0f;
    this.GenderPanel.alpha = 0.0f;
    this.WhitePanel.alpha = 1f;
    this.UpdateFacialHair(this.Data.facialHair.Value);
    this.UpdateHairStyle(this.Data.hairstyle.Value);
    this.UpdateEyes(this.Data.eyeColor.Value);
    this.UpdateSkin(this.Data.skinColor.Value);
    if (this.LoveSick)
    {
      this.LoveSickColorSwap();
      this.WhitePanel.alpha = 0.0f;
      this.Data.femaleUniform.Value = 5;
      this.Data.maleUniform.Value = 5;
      RenderSettings.fogColor = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.LoveSickCamera.SetActive(true);
      this.Black.color = Color.black;
      this.MyAudio.loop = false;
      this.MyAudio.clip = this.LoveSickIntro;
      this.MyAudio.Play();
    }
    else
    {
      this.Data.femaleUniform.Value = this.MinFemaleUniform;
      this.Data.maleUniform.Value = this.MinMaleUniform;
      RenderSettings.fogColor = new Color(1f, 0.5f, 1f, 1f);
      this.Black.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.LoveSickCamera.SetActive(false);
    }
    this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
    this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
    this.Senpai.position = new Vector3(0.0f, -1f, 2f);
    this.Senpai.gameObject.SetActive(true);
    this.Senpai.GetComponent<Animation>().Play("newWalk_00");
    this.Yandere.position = new Vector3(1f, -1f, 4.5f);
    this.Yandere.gameObject.SetActive(true);
    this.Yandere.GetComponent<Animation>().Play("f02_newWalk_00");
    this.CensorCloud.SetActive(false);
    this.Hearts.SetActive(false);
    if (GameGlobals.VtuberID > 0)
    {
      this.YandereHair.SetActive(false);
      this.VtuberHair[GameGlobals.VtuberID].SetActive(true);
      this.FemaleFace = this.VtuberFace[GameGlobals.VtuberID];
      this.UpdateFemaleUniform(1);
      for (int index = 0; index < 13; ++index)
        this.YandereRenderer.SetBlendShapeWeight(index, 0.0f);
      this.YandereRenderer.SetBlendShapeWeight(0, 100f);
      this.YandereRenderer.SetBlendShapeWeight(9, 100f);
    }
    else
      this.VtuberHair[1].SetActive(false);
  }

  private int MinSkinColor => 1;

  private int MaxSkinColor => 5;

  private int MinHairstyle => 0;

  private int MaxHairstyle => this.Hairstyles.Length - 1;

  private int MinHairColor => 1;

  private int MaxHairColor => CustomizationScript.ColorPairs.Length - 1;

  private int MinEyeColor => 1;

  private int MaxEyeColor => CustomizationScript.ColorPairs.Length - 1;

  private int MinEyewear => 0;

  private int MaxEyewear => 5;

  private int MinFacialHair => 0;

  private int MaxFacialHair => this.FacialHairstyles.Length - 1;

  private int MinMaleUniform => 1;

  private int MaxMaleUniform => this.MaleUniforms.Length - 1;

  private int MinFemaleUniform => 1;

  private int MaxFemaleUniform => this.FemaleUniforms.Length - 1;

  private float CameraSpeed => Time.deltaTime * 10f;

  private void Update()
  {
    if (!this.MyAudio.loop && !this.MyAudio.isPlaying)
    {
      this.MyAudio.loop = true;
      this.MyAudio.clip = this.LoveSickLoop;
      this.MyAudio.Play();
    }
    for (int index = 1; index < 3; ++index)
    {
      Transform transform = this.Corridor[index];
      transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * this.ScrollSpeed);
      if ((double) transform.position.z > 36.0)
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 72f);
    }
    if (this.Phase == 1)
    {
      if ((double) this.WhitePanel.alpha == 0.0)
      {
        this.GenderPanel.alpha = Mathf.MoveTowards(this.GenderPanel.alpha, 1f, Time.deltaTime * 2f);
        if ((double) this.GenderPanel.alpha == 1.0)
        {
          if (Input.GetButtonDown("A"))
            ++this.Phase;
          if (Input.GetButtonDown("B"))
            this.Apologize = true;
          if (Input.GetButtonDown("X"))
          {
            this.White.color = new Color(0.0f, 0.0f, 0.0f, 1f);
            this.FadeOut = true;
            this.Phase = 0;
          }
          if (Input.GetButtonDown("Y"))
          {
            this.White.color = new Color(0.0f, 0.0f, 0.0f, 1f);
            this.SkipToCalendar = true;
            this.FadeOut = true;
            this.Phase = 0;
          }
        }
      }
    }
    else if (this.Phase == 2)
    {
      this.GenderPanel.alpha = Mathf.MoveTowards(this.GenderPanel.alpha, 0.0f, Time.deltaTime * 2f);
      this.Black.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Black.color.a, 0.0f, Time.deltaTime * 2f));
      if ((double) this.GenderPanel.alpha == 0.0)
      {
        this.Senpai.gameObject.SetActive(true);
        ++this.Phase;
      }
    }
    else if (this.Phase == 3)
    {
      this.Adjustment += (float) ((double) Input.GetAxis("Mouse X") * (double) Time.deltaTime * 10.0);
      if ((double) this.Adjustment > 3.0)
        this.Adjustment = 3f;
      else if ((double) this.Adjustment < 0.0)
        this.Adjustment = 0.0f;
      this.CustomizePanel.alpha = Mathf.MoveTowards(this.CustomizePanel.alpha, 1f, Time.deltaTime * 2f);
      if ((double) this.CustomizePanel.alpha == 1.0)
      {
        if (Input.GetButtonDown("A"))
        {
          this.Senpai.localEulerAngles = new Vector3(this.Senpai.localEulerAngles.x, 180f, this.Senpai.localEulerAngles.z);
          ++this.Phase;
        }
        bool tappedDown = this.InputManager.TappedDown;
        bool tappedUp = this.InputManager.TappedUp;
        if (tappedDown | tappedUp)
        {
          if (tappedDown)
            this.Selected = this.Selected >= 6 ? 1 : this.Selected + 1;
          else if (tappedUp)
            this.Selected = this.Selected <= 1 ? 6 : this.Selected - 1;
          this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (650.0 - (double) this.Selected * 150.0), this.Highlight.localPosition.z);
        }
        if (this.InputManager.TappedRight)
        {
          if (this.Selected == 1)
          {
            this.Data.skinColor.Value = this.Data.skinColor.Next;
            this.UpdateSkin(this.Data.skinColor.Value);
          }
          else if (this.Selected == 2)
          {
            this.Data.hairstyle.Value = this.Data.hairstyle.Next;
            this.UpdateHairStyle(this.Data.hairstyle.Value);
          }
          else if (this.Selected == 3)
          {
            this.Data.hairColor.Value = this.Data.hairColor.Next;
            this.UpdateColor(this.Data.hairColor.Value);
          }
          else if (this.Selected == 4)
          {
            this.Data.eyeColor.Value = this.Data.eyeColor.Next;
            this.UpdateEyes(this.Data.eyeColor.Value);
          }
          else if (this.Selected == 5)
          {
            this.Data.eyewear.Value = this.Data.eyewear.Next;
            this.UpdateEyewear(this.Data.eyewear.Value);
          }
          else if (this.Selected == 6)
          {
            this.Data.facialHair.Value = this.Data.facialHair.Next;
            this.UpdateFacialHair(this.Data.facialHair.Value);
          }
        }
        if (this.InputManager.TappedLeft)
        {
          if (this.Selected == 1)
          {
            this.Data.skinColor.Value = this.Data.skinColor.Previous;
            this.UpdateSkin(this.Data.skinColor.Value);
          }
          else if (this.Selected == 2)
          {
            this.Data.hairstyle.Value = this.Data.hairstyle.Previous;
            this.UpdateHairStyle(this.Data.hairstyle.Value);
          }
          else if (this.Selected == 3)
          {
            this.Data.hairColor.Value = this.Data.hairColor.Previous;
            this.UpdateColor(this.Data.hairColor.Value);
          }
          else if (this.Selected == 4)
          {
            this.Data.eyeColor.Value = this.Data.eyeColor.Previous;
            this.UpdateEyes(this.Data.eyeColor.Value);
          }
          else if (this.Selected == 5)
          {
            this.Data.eyewear.Value = this.Data.eyewear.Previous;
            this.UpdateEyewear(this.Data.eyewear.Value);
          }
          else if (this.Selected == 6)
          {
            this.Data.facialHair.Value = this.Data.facialHair.Previous;
            this.UpdateFacialHair(this.Data.facialHair.Value);
          }
        }
      }
      this.Rotation = Mathf.Lerp(this.Rotation, (float) (45.0 - (double) this.Adjustment * 30.0), Time.deltaTime * 10f);
      this.AbsoluteRotation = 45f - Mathf.Abs(this.Rotation);
      this.LoveSickCamera.transform.position = this.Selected != 1 ? new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, (float) ((double) this.Adjustment * 0.33333000540733337 - 0.5), this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, (float) (1.5 - (double) this.AbsoluteRotation * 0.014999999664723873 * 0.33333000540733337), this.CameraSpeed)) : new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, this.Adjustment - 1.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0.0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, (float) (0.5 - (double) this.AbsoluteRotation * 0.014999999664723873), this.CameraSpeed));
      this.LoveSickCamera.transform.eulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
      this.transform.eulerAngles = this.LoveSickCamera.transform.eulerAngles;
      this.transform.position = this.LoveSickCamera.transform.position;
    }
    else if (this.Phase == 4)
    {
      this.Adjustment = Mathf.Lerp(this.Adjustment, 0.0f, Time.deltaTime * 10f);
      this.Rotation = Mathf.Lerp(this.Rotation, 45f, Time.deltaTime * 10f);
      this.AbsoluteRotation = 45f - Mathf.Abs(this.Rotation);
      this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, this.Adjustment - 1.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0.0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, (float) (0.5 - (double) this.AbsoluteRotation * 0.014999999664723873), this.CameraSpeed));
      this.LoveSickCamera.transform.eulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
      this.transform.eulerAngles = this.LoveSickCamera.transform.eulerAngles;
      this.transform.position = this.LoveSickCamera.transform.position;
      this.CustomizePanel.alpha = Mathf.MoveTowards(this.CustomizePanel.alpha, 0.0f, Time.deltaTime * 2f);
      if ((double) this.CustomizePanel.alpha == 0.0)
        ++this.Phase;
    }
    else if (this.Phase == 5)
    {
      this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 1f, Time.deltaTime * 2f);
      if ((double) this.FinishPanel.alpha == 1.0)
      {
        if (Input.GetButtonDown("A"))
          ++this.Phase;
        if (Input.GetButtonDown("B"))
        {
          this.Selected = 1;
          this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (650.0 - (double) this.Selected * 150.0), this.Highlight.localPosition.z);
          this.Phase = 100;
        }
      }
    }
    else if (this.Phase == 6)
    {
      this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0.0f, Time.deltaTime * 2f);
      if ((double) this.FinishPanel.alpha == 0.0)
      {
        this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
        this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
        this.CensorCloud.SetActive(false);
        this.Yandere.gameObject.SetActive(true);
        this.Selected = 1;
        ++this.Phase;
      }
    }
    else if (this.Phase == 7)
    {
      this.UniformPanel.alpha = Mathf.MoveTowards(this.UniformPanel.alpha, 1f, Time.deltaTime * 2f);
      if ((double) this.UniformPanel.alpha == 1.0)
      {
        if (Input.GetButtonDown("A"))
        {
          this.Yandere.localEulerAngles = new Vector3(this.Yandere.localEulerAngles.x, 180f, this.Yandere.localEulerAngles.z);
          this.Senpai.localEulerAngles = new Vector3(this.Senpai.localEulerAngles.x, 180f, this.Senpai.localEulerAngles.z);
          ++this.Phase;
        }
        if (this.InputManager.TappedDown || this.InputManager.TappedUp)
        {
          this.Selected = this.Selected == 1 ? 2 : 1;
          this.UniformHighlight.localPosition = new Vector3(this.UniformHighlight.localPosition.x, (float) (650.0 - (double) this.Selected * 150.0), this.UniformHighlight.localPosition.z);
        }
        if (this.InputManager.TappedRight)
        {
          if (this.Selected == 1)
          {
            this.Data.maleUniform.Value = this.Data.maleUniform.Next;
            this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
          }
          else if (this.Selected == 2)
          {
            this.Data.femaleUniform.Value = this.Data.femaleUniform.Next;
            this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
          }
        }
        if (this.InputManager.TappedLeft)
        {
          if (this.Selected == 1)
          {
            this.Data.maleUniform.Value = this.Data.maleUniform.Previous;
            this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
          }
          else if (this.Selected == 2)
          {
            this.Data.femaleUniform.Value = this.Data.femaleUniform.Previous;
            this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
          }
        }
      }
    }
    else if (this.Phase == 8)
    {
      this.UniformPanel.alpha = Mathf.MoveTowards(this.UniformPanel.alpha, 0.0f, Time.deltaTime * 2f);
      if ((double) this.UniformPanel.alpha == 0.0)
        ++this.Phase;
    }
    else if (this.Phase == 9)
    {
      this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 1f, Time.deltaTime * 2f);
      if ((double) this.FinishPanel.alpha == 1.0)
      {
        if (Input.GetButtonDown("A"))
          ++this.Phase;
        if (Input.GetButtonDown("B"))
        {
          this.Selected = 1;
          this.UniformHighlight.localPosition = new Vector3(this.UniformHighlight.localPosition.x, (float) (650.0 - (double) this.Selected * 150.0), this.UniformHighlight.localPosition.z);
          this.Phase = 99;
        }
      }
    }
    else if (this.Phase == 10)
    {
      this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0.0f, Time.deltaTime * 2f);
      if ((double) this.FinishPanel.alpha == 0.0)
      {
        this.White.color = new Color(0.0f, 0.0f, 0.0f, 1f);
        this.FadeOut = true;
        this.Phase = 0;
      }
    }
    else if (this.Phase == 99)
    {
      this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0.0f, Time.deltaTime * 2f);
      if ((double) this.FinishPanel.alpha == 0.0)
        this.Phase = 7;
    }
    else if (this.Phase == 100)
    {
      this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0.0f, Time.deltaTime * 2f);
      if ((double) this.FinishPanel.alpha == 0.0)
        this.Phase = 3;
    }
    if (this.Phase > 3 && this.Phase < 100)
    {
      if (this.Phase < 6)
      {
        this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, -1.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0.0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 0.5f, this.CameraSpeed));
        this.transform.position = this.LoveSickCamera.transform.position;
      }
      else
      {
        this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, 0.0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 0.0f, this.CameraSpeed));
        this.LoveSickCamera.transform.eulerAngles = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.eulerAngles.x, 15f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.eulerAngles.y, 0.0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.eulerAngles.z, 0.0f, this.CameraSpeed));
        this.transform.eulerAngles = this.LoveSickCamera.transform.eulerAngles;
        this.transform.position = this.LoveSickCamera.transform.position;
        this.Yandere.position = new Vector3(Mathf.Lerp(this.Yandere.position.x, 1f, Time.deltaTime * 10f), Mathf.Lerp(this.Yandere.position.y, -1f, Time.deltaTime * 10f), Mathf.Lerp(this.Yandere.position.z, 3.5f, Time.deltaTime * 10f));
      }
    }
    if (this.FadeOut)
    {
      this.WhitePanel.alpha = Mathf.MoveTowards(this.WhitePanel.alpha, 1f, Time.deltaTime);
      this.GetComponent<AudioSource>().volume = 1f - this.WhitePanel.alpha;
      if ((double) this.WhitePanel.alpha == 1.0)
      {
        SenpaiGlobals.CustomSenpai = true;
        SenpaiGlobals.SenpaiSkinColor = this.Data.skinColor.Value;
        SenpaiGlobals.SenpaiHairStyle = this.Data.hairstyle.Value;
        SenpaiGlobals.SenpaiHairColor = this.HairColorName;
        SenpaiGlobals.SenpaiEyeColor = this.EyeColorName;
        SenpaiGlobals.SenpaiEyeWear = this.Data.eyewear.Value;
        SenpaiGlobals.SenpaiFacialHair = this.Data.facialHair.Value;
        StudentGlobals.MaleUniform = this.Data.maleUniform.Value;
        StudentGlobals.FemaleUniform = this.Data.femaleUniform.Value;
        this.Profile.depthOfField.enabled = this.OriginalDOFStatus;
        if (this.SkipToCalendar)
          SceneManager.LoadScene("CalendarScene");
        else
          SceneManager.LoadScene("NewIntroScene");
      }
    }
    else
      this.WhitePanel.alpha = Mathf.MoveTowards(this.WhitePanel.alpha, 0.0f, Time.deltaTime);
    if (!this.Apologize)
      return;
    this.Timer += Time.deltaTime;
    if ((double) this.Timer < 1.0)
    {
      this.ApologyWindow.localPosition = new Vector3(Mathf.Lerp(this.ApologyWindow.localPosition.x, 0.0f, Time.deltaTime * 10f), this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
    }
    else
    {
      this.ApologyWindow.localPosition = new Vector3(Mathf.Abs((float) (((double) this.ApologyWindow.localPosition.x - (double) Time.deltaTime) * 0.0099999997764825821)) * (Time.deltaTime * 1000f), this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
      if ((double) this.ApologyWindow.localPosition.x >= -1555.0)
        return;
      this.ApologyWindow.localPosition = new Vector3(1555f, this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
      this.Apologize = false;
      this.Timer = 0.0f;
    }
  }

  private void LateUpdate() => this.YandereHead.LookAt(this.SenpaiHead.position);

  private void UpdateSkin(int skinColor)
  {
    this.UpdateMaleUniform(this.Data.maleUniform.Value, skinColor);
    this.SkinColorLabel.text = "Skin Color " + skinColor.ToString();
  }

  private void UpdateHairStyle(int hairstyle)
  {
    for (int index = 1; index < this.Hairstyles.Length; ++index)
      this.Hairstyles[index].SetActive(false);
    if (hairstyle > 0)
    {
      this.HairRenderer = this.Hairstyles[hairstyle].GetComponent<Renderer>();
      this.Hairstyles[hairstyle].SetActive(true);
    }
    this.HairStyleLabel.text = "Hair Style " + hairstyle.ToString();
    this.UpdateColor(this.Data.hairColor.Value);
  }

  private void UpdateFacialHair(int facialHair)
  {
    for (int index = 1; index < this.FacialHairstyles.Length; ++index)
      this.FacialHairstyles[index].SetActive(false);
    if (facialHair > 0)
    {
      this.FacialHairRenderer = this.FacialHairstyles[facialHair].GetComponent<Renderer>();
      this.FacialHairstyles[facialHair].SetActive(true);
    }
    this.FacialHairStyleLabel.text = "Facial Hair " + facialHair.ToString();
    this.UpdateColor(this.Data.hairColor.Value);
  }

  private void UpdateColor(int hairColor)
  {
    KeyValuePair<Color, string> colorPair = CustomizationScript.ColorPairs[hairColor];
    Color key = colorPair.Key;
    this.HairColorName = colorPair.Value;
    if (this.Data.hairstyle.Value > 0)
    {
      this.HairRenderer = this.Hairstyles[this.Data.hairstyle.Value].GetComponent<Renderer>();
      this.HairRenderer.material.color = key;
    }
    if (this.Data.facialHair.Value > 0)
    {
      this.FacialHairRenderer = this.FacialHairstyles[this.Data.facialHair.Value].GetComponent<Renderer>();
      this.FacialHairRenderer.material.color = key;
      if (this.FacialHairRenderer.materials.Length > 1)
        this.FacialHairRenderer.materials[1].color = key;
    }
    this.HairColorLabel.text = "Hair Color " + hairColor.ToString();
  }

  private void UpdateEyes(int eyeColor)
  {
    KeyValuePair<Color, string> colorPair = CustomizationScript.ColorPairs[eyeColor];
    Color key = colorPair.Key;
    this.EyeColorName = colorPair.Value;
    this.EyeR.material.color = key;
    this.EyeL.material.color = key;
    this.EyeColorLabel.text = "Eye Color " + eyeColor.ToString();
  }

  private void UpdateEyewear(int eyewear)
  {
    for (int index = 1; index < this.Eyewears.Length; ++index)
      this.Eyewears[index].SetActive(false);
    if (eyewear > 0)
      this.Eyewears[eyewear].SetActive(true);
    this.EyeWearLabel.text = "Eye Wear " + eyewear.ToString();
  }

  private void UpdateMaleUniform(int maleUniform, int skinColor)
  {
    this.SenpaiRenderer.sharedMesh = this.MaleUniforms[maleUniform];
    switch (maleUniform)
    {
      case 1:
        this.SenpaiRenderer.materials[0].mainTexture = this.SkinTextures[skinColor];
        this.SenpaiRenderer.materials[1].mainTexture = this.MaleUniformTextures[maleUniform];
        this.SenpaiRenderer.materials[2].mainTexture = this.FaceTextures[skinColor];
        break;
      case 2:
        this.SenpaiRenderer.materials[0].mainTexture = this.MaleUniformTextures[maleUniform];
        this.SenpaiRenderer.materials[1].mainTexture = this.FaceTextures[skinColor];
        this.SenpaiRenderer.materials[2].mainTexture = this.SkinTextures[skinColor];
        break;
      case 3:
        this.SenpaiRenderer.materials[0].mainTexture = this.MaleUniformTextures[maleUniform];
        this.SenpaiRenderer.materials[1].mainTexture = this.FaceTextures[skinColor];
        this.SenpaiRenderer.materials[2].mainTexture = this.SkinTextures[skinColor];
        break;
      case 4:
        this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[skinColor];
        this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[skinColor];
        this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[maleUniform];
        break;
      case 5:
        this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[skinColor];
        this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[skinColor];
        this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[maleUniform];
        break;
      case 6:
        this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[skinColor];
        this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[skinColor];
        this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[maleUniform];
        break;
    }
    this.MaleUniformLabel.text = "Male Uniform " + maleUniform.ToString();
  }

  private void UpdateFemaleUniform(int femaleUniform)
  {
    this.YandereRenderer.sharedMesh = this.FemaleUniforms[femaleUniform];
    this.YandereRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
    this.YandereRenderer.materials[1].mainTexture = this.FemaleUniformTextures[femaleUniform];
    this.YandereRenderer.materials[2].mainTexture = this.FemaleFace;
    this.YandereRenderer.materials[3].mainTexture = this.FemaleFace;
    this.FemaleUniformLabel.text = "Female Uniform " + femaleUniform.ToString();
  }

  private void LoveSickColorSwap()
  {
    foreach (GameObject gameObject in Object.FindObjectsOfType<GameObject>())
    {
      UISprite component1 = gameObject.GetComponent<UISprite>();
      if ((Object) component1 != (Object) null && component1.color != Color.black && (Object) component1.transform.parent != (Object) this.Highlight && (Object) component1.transform.parent != (Object) this.UniformHighlight)
        component1.color = new Color(1f, 0.0f, 0.0f, component1.color.a);
      UITexture component2 = gameObject.GetComponent<UITexture>();
      if ((Object) component2 != (Object) null)
        component2.color = new Color(1f, 0.0f, 0.0f, component2.color.a);
      UILabel component3 = gameObject.GetComponent<UILabel>();
      if ((Object) component3 != (Object) null && component3.color != Color.black)
        component3.color = new Color(1f, 0.0f, 0.0f, component3.color.a);
    }
  }

  private class CustomizationData
  {
    public RangeInt skinColor;
    public RangeInt hairstyle;
    public RangeInt hairColor;
    public RangeInt eyeColor;
    public RangeInt eyewear;
    public RangeInt facialHair;
    public RangeInt maleUniform;
    public RangeInt femaleUniform;
  }
}
