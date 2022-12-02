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
		if (Phase == 0)
		{
			Timer += Time.deltaTime;
			if (Timer > 5f)
			{
				Timer = 0f;
				Phase++;
			}
			return;
		}
		Timer += Time.deltaTime;
		if (base.transform.position.z > -18f)
		{
			LateTimer = Mathf.Lerp(LateTimer, Timer, Time.deltaTime);
			RotationY = Mathf.Lerp(RotationY, -22.5f, Time.deltaTime * LateTimer);
		}
		RotationZ = Mathf.Lerp(RotationZ, 22.5f, Time.deltaTime * Timer);
		base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0.33333f, 101.45f, -16.5f), Time.deltaTime * Timer);
		base.transform.eulerAngles = new Vector3(0f, RotationY, RotationZ);
		if (!Turning)
		{
			if (base.transform.position.z > -17f)
			{
				LoveSickYandere.CrossFade("f02_edgyTurn_00");
				VictimHead.parent = RightHand;
				Turning = true;
			}
		}
		else if (LoveSickYandere["f02_edgyTurn_00"].time >= LoveSickYandere["f02_edgyTurn_00"].length)
		{
			LoveSickYandere.CrossFade("f02_edgyOverShoulder_00");
		}
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			Time.timeScale -= 1f;
		}
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			Time.timeScale += 1f;
		}
	}
}
