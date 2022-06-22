// Decompiled with JetBrains decompiler
// Type: TitleMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TitleMenuScript : MonoBehaviour
{
  public ColorCorrectionCurves ColorCorrection;
  public InputManagerScript InputManager;
  public TitleSaveFilesScript SaveFiles;
  public SelectiveGrayscale Grayscale;
  public TitleSponsorScript Sponsors;
  public TitleExtrasScript Extras;
  public PromptBarScript PromptBar;
  public SSAOEffect SSAO;
  public JsonScript JSON;
  public UISprite[] MediumSprites;
  public UISprite[] LightSprites;
  public UISprite[] DarkSprites;
  public UILabel TitleLabel;
  public UILabel SimulatorLabel;
  public UILabel[] ColoredLabels;
  public Color MediumColor;
  public Color LightColor;
  public Color DarkColor;
  public Transform VictimHead;
  public Transform RightHand;
  public Transform TwintailL;
  public Transform TwintailR;
  public Animation LoveSickYandere;
  public GameObject BloodProjector;
  public GameObject LoveSickLogo;
  public GameObject BloodCamera;
  public GameObject Yandere;
  public GameObject Knife;
  public GameObject Logo;
  public GameObject Sun;
  public AudioSource LoveSickMusic;
  public AudioSource CuteMusic;
  public AudioSource DarkMusic;
  public Renderer[] YandereEye;
  public Material CuteSkybox;
  public Material DarkSkybox;
  public Transform Highlight;
  public Transform[] Spine;
  public Transform[] Arm;
  public UISprite Darkness;
  public Vector3 PermaPositionL;
  public Vector3 PermaPositionR;
  public bool NeverChange;
  public bool LoveSick;
  public bool FadeOut;
  public bool Turning;
  public bool Fading = true;
  public int SelectionCount = 8;
  public int Selected;
  public float InputTimer;
  public float FadeSpeed = 1f;
  public float LateTimer;
  public float RotationY;
  public float RotationZ;
  public float Volume;
  public float Timer;
  public int Phase;

  private void Start()
  {
    RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.25f, 1f);
    Time.timeScale = 1f;
  }

  private void Update()
  {
    if (this.Phase == 0)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 5.0)
        return;
      this.Timer = 0.0f;
      ++this.Phase;
    }
    else
    {
      this.Timer += Time.deltaTime;
      if ((double) this.transform.position.z > -18.0)
      {
        this.LateTimer = Mathf.Lerp(this.LateTimer, this.Timer, Time.deltaTime);
        this.RotationY = Mathf.Lerp(this.RotationY, -22.5f, Time.deltaTime * this.LateTimer);
      }
      this.RotationZ = Mathf.Lerp(this.RotationZ, 22.5f, Time.deltaTime * this.Timer);
      this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0.33333f, 101.45f, -16.5f), Time.deltaTime * this.Timer);
      this.transform.eulerAngles = new Vector3(0.0f, this.RotationY, this.RotationZ);
      if (!this.Turning)
      {
        if ((double) this.transform.position.z > -17.0)
        {
          this.LoveSickYandere.CrossFade("f02_edgyTurn_00");
          this.VictimHead.parent = this.RightHand;
          this.Turning = true;
        }
      }
      else if ((double) this.LoveSickYandere["f02_edgyTurn_00"].time >= (double) this.LoveSickYandere["f02_edgyTurn_00"].length)
        this.LoveSickYandere.CrossFade("f02_edgyOverShoulder_00");
      if (Input.GetKeyDown(KeyCode.Minus))
        --Time.timeScale;
      if (!Input.GetKeyDown(KeyCode.Equals))
        return;
      ++Time.timeScale;
    }
  }
}
