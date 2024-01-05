using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class CustomizationScript : MonoBehaviour
{
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

	[SerializeField]
	private CustomizationData Data;

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

	public Shader NewShader;

	public InputDeviceScript InputDevice;

	public bool OriginalDOFStatus;

	private static readonly KeyValuePair<Color, string>[] ColorPairs = new KeyValuePair<Color, string>[11]
	{
		new KeyValuePair<Color, string>(default(Color), string.Empty),
		new KeyValuePair<Color, string>(new Color(0.5f, 0.5f, 0.5f), "Black"),
		new KeyValuePair<Color, string>(new Color(1f, 0f, 0f), "Red"),
		new KeyValuePair<Color, string>(new Color(1f, 1f, 0f), "Yellow"),
		new KeyValuePair<Color, string>(new Color(0f, 1f, 0f), "Green"),
		new KeyValuePair<Color, string>(new Color(0f, 1f, 1f), "Cyan"),
		new KeyValuePair<Color, string>(new Color(0f, 0f, 1f), "Blue"),
		new KeyValuePair<Color, string>(new Color(1f, 0f, 1f), "Purple"),
		new KeyValuePair<Color, string>(new Color(1f, 0.5f, 0f), "Orange"),
		new KeyValuePair<Color, string>(new Color(0.5f, 0.25f, 0f), "Brown"),
		new KeyValuePair<Color, string>(new Color(1f, 1f, 1f), "White")
	};

	private int MinSkinColor => 1;

	private int MaxSkinColor => 5;

	private int MinHairstyle => 0;

	private int MaxHairstyle => Hairstyles.Length - 1;

	private int MinHairColor => 1;

	private int MaxHairColor => ColorPairs.Length - 1;

	private int MinEyeColor => 1;

	private int MaxEyeColor => ColorPairs.Length - 1;

	private int MinEyewear => 0;

	private int MaxEyewear => 5;

	private int MinFacialHair => 0;

	private int MaxFacialHair => FacialHairstyles.Length - 1;

	private int MinMaleUniform => 1;

	private int MaxMaleUniform => MaleUniforms.Length - 1;

	private int MinFemaleUniform => 1;

	private int MaxFemaleUniform => FemaleUniforms.Length - 1;

	private float CameraSpeed => Time.deltaTime * 10f;

	private void Awake()
	{
		Data = new CustomizationData();
		Data.skinColor = new RangeInt(3, MinSkinColor, MaxSkinColor);
		Data.hairstyle = new RangeInt(1, MinHairstyle, MaxHairstyle);
		Data.hairColor = new RangeInt(1, MinHairColor, MaxHairColor);
		Data.eyeColor = new RangeInt(1, MinEyeColor, MaxEyeColor);
		Data.eyewear = new RangeInt(0, MinEyewear, MaxEyewear);
		Data.facialHair = new RangeInt(0, MinFacialHair, MaxFacialHair);
		Data.maleUniform = new RangeInt(1, MinMaleUniform, MaxMaleUniform);
		Data.femaleUniform = new RangeInt(1, MinFemaleUniform, MaxFemaleUniform);
	}

	private void Start()
	{
		OriginalDOFStatus = Profile.depthOfField.enabled;
		Profile.depthOfField.enabled = false;
		Cursor.visible = false;
		Time.timeScale = 1f;
		LoveSick = GameGlobals.LoveSick;
		ApologyWindow.localPosition = new Vector3(1555f, ApologyWindow.localPosition.y, ApologyWindow.localPosition.z);
		CustomizePanel.alpha = 0f;
		UniformPanel.alpha = 0f;
		FinishPanel.alpha = 0f;
		GenderPanel.alpha = 0f;
		WhitePanel.alpha = 1f;
		UpdateFacialHair(Data.facialHair.Value);
		UpdateHairStyle(Data.hairstyle.Value);
		UpdateEyes(Data.eyeColor.Value);
		UpdateSkin(Data.skinColor.Value);
		if (LoveSick)
		{
			LoveSickColorSwap();
			WhitePanel.alpha = 0f;
			Data.femaleUniform.Value = 5;
			Data.maleUniform.Value = 5;
			RenderSettings.fogColor = new Color(0f, 0f, 0f, 1f);
			LoveSickCamera.SetActive(value: true);
			Black.color = Color.black;
			MyAudio.loop = false;
			MyAudio.clip = LoveSickIntro;
			MyAudio.Play();
		}
		else
		{
			Data.femaleUniform.Value = MinFemaleUniform;
			Data.maleUniform.Value = MinMaleUniform;
			RenderSettings.fogColor = new Color(1f, 0.5f, 1f, 1f);
			Black.color = new Color(0f, 0f, 0f, 0f);
			LoveSickCamera.SetActive(value: false);
		}
		UpdateMaleUniform(Data.maleUniform.Value, Data.skinColor.Value);
		UpdateFemaleUniform(Data.femaleUniform.Value);
		Senpai.position = new Vector3(0f, -1f, 2f);
		Senpai.gameObject.SetActive(value: true);
		Senpai.GetComponent<Animation>().Play("newWalk_00");
		Yandere.position = new Vector3(1f, -1f, 4.5f);
		Yandere.gameObject.SetActive(value: true);
		Yandere.GetComponent<Animation>().Play("f02_newWalk_00");
		CensorCloud.SetActive(value: false);
		Hearts.SetActive(value: false);
		if (GameGlobals.VtuberID > 0)
		{
			YandereHair.SetActive(value: false);
			VtuberHair[GameGlobals.VtuberID].SetActive(value: true);
			FemaleFace = VtuberFace[GameGlobals.VtuberID];
			UpdateFemaleUniform(1);
			for (int i = 0; i < 13; i++)
			{
				YandereRenderer.SetBlendShapeWeight(i, 0f);
			}
			YandereRenderer.SetBlendShapeWeight(0, 100f);
			YandereRenderer.SetBlendShapeWeight(9, 100f);
		}
		else
		{
			VtuberHair[1].SetActive(value: false);
		}
		for (int j = 0; j < Hairstyles.Length; j++)
		{
			if (Hairstyles[j] != null)
			{
				HairRenderer = Hairstyles[j].GetComponent<Renderer>();
				HairRenderer.material.shader = NewShader;
				HairRenderer.material.SetFloat("_Saturation", 0f);
			}
		}
	}

	private void Update()
	{
		if (!MyAudio.loop && !MyAudio.isPlaying)
		{
			MyAudio.loop = true;
			MyAudio.clip = LoveSickLoop;
			MyAudio.Play();
		}
		for (int i = 1; i < 3; i++)
		{
			Transform transform = Corridor[i];
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * ScrollSpeed);
			if (transform.position.z > 36f)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 72f);
			}
		}
		if (Phase == 1)
		{
			if (WhitePanel.alpha == 0f)
			{
				GenderPanel.alpha = Mathf.MoveTowards(GenderPanel.alpha, 1f, Time.deltaTime * 2f);
				if (GenderPanel.alpha == 1f)
				{
					if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						Phase++;
					}
					if (Input.GetButtonDown(InputNames.Xbox_B))
					{
						Apologize = true;
					}
					if (Input.GetButtonDown(InputNames.Xbox_X))
					{
						White.color = new Color(0f, 0f, 0f, 1f);
						FadeOut = true;
						Phase = 0;
					}
					if (Input.GetButtonDown(InputNames.Xbox_Y))
					{
						White.color = new Color(0f, 0f, 0f, 1f);
						SkipToCalendar = true;
						FadeOut = true;
						Phase = 0;
					}
				}
			}
		}
		else if (Phase == 2)
		{
			GenderPanel.alpha = Mathf.MoveTowards(GenderPanel.alpha, 0f, Time.deltaTime * 2f);
			Black.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Black.color.a, 0f, Time.deltaTime * 2f));
			if (GenderPanel.alpha == 0f)
			{
				Senpai.gameObject.SetActive(value: true);
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			string axisName = "Mouse X";
			if (InputDevice.Type == InputDeviceType.Gamepad)
			{
				axisName = InputNames.Xbox_JoyX;
				_ = InputNames.Xbox_JoyY;
			}
			Adjustment += Input.GetAxis(axisName) * Time.deltaTime * 10f;
			if (Adjustment > 3f)
			{
				Adjustment = 3f;
			}
			else if (Adjustment < 0f)
			{
				Adjustment = 0f;
			}
			CustomizePanel.alpha = Mathf.MoveTowards(CustomizePanel.alpha, 1f, Time.deltaTime * 2f);
			if (CustomizePanel.alpha == 1f)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					Senpai.localEulerAngles = new Vector3(Senpai.localEulerAngles.x, 180f, Senpai.localEulerAngles.z);
					Phase++;
				}
				bool tappedDown = InputManager.TappedDown;
				bool tappedUp = InputManager.TappedUp;
				if (tappedDown || tappedUp)
				{
					if (tappedDown)
					{
						Selected = ((Selected >= 6) ? 1 : (Selected + 1));
					}
					else if (tappedUp)
					{
						Selected = ((Selected <= 1) ? 6 : (Selected - 1));
					}
					Highlight.localPosition = new Vector3(Highlight.localPosition.x, 650f - (float)Selected * 150f, Highlight.localPosition.z);
				}
				if (InputManager.TappedRight)
				{
					if (Selected == 1)
					{
						Data.skinColor.Value = Data.skinColor.Next;
						UpdateSkin(Data.skinColor.Value);
					}
					else if (Selected == 2)
					{
						Data.hairstyle.Value = Data.hairstyle.Next;
						UpdateHairStyle(Data.hairstyle.Value);
					}
					else if (Selected == 3)
					{
						Data.hairColor.Value = Data.hairColor.Next;
						UpdateColor(Data.hairColor.Value);
					}
					else if (Selected == 4)
					{
						Data.eyeColor.Value = Data.eyeColor.Next;
						UpdateEyes(Data.eyeColor.Value);
					}
					else if (Selected == 5)
					{
						Data.eyewear.Value = Data.eyewear.Next;
						UpdateEyewear(Data.eyewear.Value);
					}
					else if (Selected == 6)
					{
						Data.facialHair.Value = Data.facialHair.Next;
						UpdateFacialHair(Data.facialHair.Value);
					}
				}
				if (InputManager.TappedLeft)
				{
					if (Selected == 1)
					{
						Data.skinColor.Value = Data.skinColor.Previous;
						UpdateSkin(Data.skinColor.Value);
					}
					else if (Selected == 2)
					{
						Data.hairstyle.Value = Data.hairstyle.Previous;
						UpdateHairStyle(Data.hairstyle.Value);
					}
					else if (Selected == 3)
					{
						Data.hairColor.Value = Data.hairColor.Previous;
						UpdateColor(Data.hairColor.Value);
					}
					else if (Selected == 4)
					{
						Data.eyeColor.Value = Data.eyeColor.Previous;
						UpdateEyes(Data.eyeColor.Value);
					}
					else if (Selected == 5)
					{
						Data.eyewear.Value = Data.eyewear.Previous;
						UpdateEyewear(Data.eyewear.Value);
					}
					else if (Selected == 6)
					{
						Data.facialHair.Value = Data.facialHair.Previous;
						UpdateFacialHair(Data.facialHair.Value);
					}
				}
			}
			Rotation = Mathf.Lerp(Rotation, 45f - Adjustment * 30f, Time.deltaTime * 10f);
			AbsoluteRotation = 45f - Mathf.Abs(Rotation);
			if (Selected == 1)
			{
				LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(LoveSickCamera.transform.position.x, -1.5f + Adjustment, CameraSpeed), Mathf.Lerp(LoveSickCamera.transform.position.y, 0f, CameraSpeed), Mathf.Lerp(LoveSickCamera.transform.position.z, 0.5f - AbsoluteRotation * 0.015f, CameraSpeed));
			}
			else
			{
				LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(LoveSickCamera.transform.position.x, -0.5f + Adjustment * 0.33333f, CameraSpeed), Mathf.Lerp(LoveSickCamera.transform.position.y, 0.5f, CameraSpeed), Mathf.Lerp(LoveSickCamera.transform.position.z, 1.5f - AbsoluteRotation * 0.015f * 0.33333f, CameraSpeed));
			}
			LoveSickCamera.transform.eulerAngles = new Vector3(0f, Rotation, 0f);
			base.transform.eulerAngles = LoveSickCamera.transform.eulerAngles;
			base.transform.position = LoveSickCamera.transform.position;
		}
		else if (Phase == 4)
		{
			Adjustment = Mathf.Lerp(Adjustment, 0f, Time.deltaTime * 10f);
			Rotation = Mathf.Lerp(Rotation, 45f, Time.deltaTime * 10f);
			AbsoluteRotation = 45f - Mathf.Abs(Rotation);
			LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(LoveSickCamera.transform.position.x, -1.5f + Adjustment, CameraSpeed), Mathf.Lerp(LoveSickCamera.transform.position.y, 0f, CameraSpeed), Mathf.Lerp(LoveSickCamera.transform.position.z, 0.5f - AbsoluteRotation * 0.015f, CameraSpeed));
			LoveSickCamera.transform.eulerAngles = new Vector3(0f, Rotation, 0f);
			base.transform.eulerAngles = LoveSickCamera.transform.eulerAngles;
			base.transform.position = LoveSickCamera.transform.position;
			CustomizePanel.alpha = Mathf.MoveTowards(CustomizePanel.alpha, 0f, Time.deltaTime * 2f);
			if (CustomizePanel.alpha == 0f)
			{
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			FinishPanel.alpha = Mathf.MoveTowards(FinishPanel.alpha, 1f, Time.deltaTime * 2f);
			if (FinishPanel.alpha == 1f)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					Phase++;
				}
				if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					Selected = 1;
					Highlight.localPosition = new Vector3(Highlight.localPosition.x, 650f - (float)Selected * 150f, Highlight.localPosition.z);
					Phase = 100;
				}
			}
		}
		else if (Phase == 6)
		{
			FinishPanel.alpha = Mathf.MoveTowards(FinishPanel.alpha, 0f, Time.deltaTime * 2f);
			if (FinishPanel.alpha == 0f)
			{
				UpdateFemaleUniform(Data.femaleUniform.Value);
				UpdateMaleUniform(Data.maleUniform.Value, Data.skinColor.Value);
				CensorCloud.SetActive(value: false);
				Yandere.gameObject.SetActive(value: true);
				Selected = 1;
				Phase++;
			}
		}
		else if (Phase == 7)
		{
			UniformPanel.alpha = Mathf.MoveTowards(UniformPanel.alpha, 1f, Time.deltaTime * 2f);
			if (UniformPanel.alpha == 1f)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					Yandere.localEulerAngles = new Vector3(Yandere.localEulerAngles.x, 180f, Yandere.localEulerAngles.z);
					Senpai.localEulerAngles = new Vector3(Senpai.localEulerAngles.x, 180f, Senpai.localEulerAngles.z);
					Phase++;
				}
				if (InputManager.TappedDown || InputManager.TappedUp)
				{
					Selected = ((Selected != 1) ? 1 : 2);
					UniformHighlight.localPosition = new Vector3(UniformHighlight.localPosition.x, 650f - (float)Selected * 150f, UniformHighlight.localPosition.z);
				}
				if (InputManager.TappedRight)
				{
					if (Selected == 1)
					{
						Data.maleUniform.Value = Data.maleUniform.Next;
						UpdateMaleUniform(Data.maleUniform.Value, Data.skinColor.Value);
					}
					else if (Selected == 2)
					{
						Data.femaleUniform.Value = Data.femaleUniform.Next;
						UpdateFemaleUniform(Data.femaleUniform.Value);
					}
				}
				if (InputManager.TappedLeft)
				{
					if (Selected == 1)
					{
						Data.maleUniform.Value = Data.maleUniform.Previous;
						UpdateMaleUniform(Data.maleUniform.Value, Data.skinColor.Value);
					}
					else if (Selected == 2)
					{
						Data.femaleUniform.Value = Data.femaleUniform.Previous;
						UpdateFemaleUniform(Data.femaleUniform.Value);
					}
				}
			}
		}
		else if (Phase == 8)
		{
			UniformPanel.alpha = Mathf.MoveTowards(UniformPanel.alpha, 0f, Time.deltaTime * 2f);
			if (UniformPanel.alpha == 0f)
			{
				Phase++;
			}
		}
		else if (Phase == 9)
		{
			FinishPanel.alpha = Mathf.MoveTowards(FinishPanel.alpha, 1f, Time.deltaTime * 2f);
			if (FinishPanel.alpha == 1f)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					Phase++;
				}
				if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					Selected = 1;
					UniformHighlight.localPosition = new Vector3(UniformHighlight.localPosition.x, 650f - (float)Selected * 150f, UniformHighlight.localPosition.z);
					Phase = 99;
				}
			}
		}
		else if (Phase == 10)
		{
			FinishPanel.alpha = Mathf.MoveTowards(FinishPanel.alpha, 0f, Time.deltaTime * 2f);
			if (FinishPanel.alpha == 0f)
			{
				White.color = new Color(0f, 0f, 0f, 1f);
				FadeOut = true;
				Phase = 0;
			}
		}
		else if (Phase == 99)
		{
			FinishPanel.alpha = Mathf.MoveTowards(FinishPanel.alpha, 0f, Time.deltaTime * 2f);
			if (FinishPanel.alpha == 0f)
			{
				Phase = 7;
			}
		}
		else if (Phase == 100)
		{
			FinishPanel.alpha = Mathf.MoveTowards(FinishPanel.alpha, 0f, Time.deltaTime * 2f);
			if (FinishPanel.alpha == 0f)
			{
				Phase = 3;
			}
		}
		if (Phase > 3 && Phase < 100)
		{
			if (Phase < 6)
			{
				LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(LoveSickCamera.transform.position.x, -1.5f, CameraSpeed), Mathf.Lerp(LoveSickCamera.transform.position.y, 0f, CameraSpeed), Mathf.Lerp(LoveSickCamera.transform.position.z, 0.5f, CameraSpeed));
				base.transform.position = LoveSickCamera.transform.position;
			}
			else
			{
				LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(LoveSickCamera.transform.position.x, 0f, CameraSpeed), Mathf.Lerp(LoveSickCamera.transform.position.y, 0.5f, CameraSpeed), Mathf.Lerp(LoveSickCamera.transform.position.z, 0f, CameraSpeed));
				LoveSickCamera.transform.eulerAngles = new Vector3(Mathf.Lerp(LoveSickCamera.transform.eulerAngles.x, 15f, CameraSpeed), Mathf.Lerp(LoveSickCamera.transform.eulerAngles.y, 0f, CameraSpeed), Mathf.Lerp(LoveSickCamera.transform.eulerAngles.z, 0f, CameraSpeed));
				base.transform.eulerAngles = LoveSickCamera.transform.eulerAngles;
				base.transform.position = LoveSickCamera.transform.position;
				Yandere.position = new Vector3(Mathf.Lerp(Yandere.position.x, 1f, Time.deltaTime * 10f), Mathf.Lerp(Yandere.position.y, -1f, Time.deltaTime * 10f), Mathf.Lerp(Yandere.position.z, 3.5f, Time.deltaTime * 10f));
			}
		}
		if (FadeOut)
		{
			WhitePanel.alpha = Mathf.MoveTowards(WhitePanel.alpha, 1f, Time.deltaTime);
			GetComponent<AudioSource>().volume = 1f - WhitePanel.alpha;
			if (WhitePanel.alpha == 1f)
			{
				SenpaiGlobals.CustomSenpai = true;
				SenpaiGlobals.SenpaiSkinColor = Data.skinColor.Value;
				SenpaiGlobals.SenpaiHairStyle = Data.hairstyle.Value;
				SenpaiGlobals.SenpaiHairColor = HairColorName;
				SenpaiGlobals.SenpaiEyeColor = EyeColorName;
				SenpaiGlobals.SenpaiEyeWear = Data.eyewear.Value;
				SenpaiGlobals.SenpaiFacialHair = Data.facialHair.Value;
				StudentGlobals.MaleUniform = Data.maleUniform.Value;
				StudentGlobals.FemaleUniform = Data.femaleUniform.Value;
				Profile.depthOfField.enabled = OriginalDOFStatus;
				GameGlobals.LastInputType = (int)InputDevice.Type;
				if (SkipToCalendar)
				{
					SceneManager.LoadScene("CalendarScene");
				}
				else
				{
					SceneManager.LoadScene("NewIntroScene");
				}
			}
		}
		else
		{
			WhitePanel.alpha = Mathf.MoveTowards(WhitePanel.alpha, 0f, Time.deltaTime);
		}
		if (!Apologize)
		{
			return;
		}
		Timer += Time.deltaTime;
		if (Timer < 1f)
		{
			ApologyWindow.localPosition = new Vector3(Mathf.Lerp(ApologyWindow.localPosition.x, 0f, Time.deltaTime * 10f), ApologyWindow.localPosition.y, ApologyWindow.localPosition.z);
			return;
		}
		ApologyWindow.localPosition = new Vector3(Mathf.Abs((ApologyWindow.localPosition.x - Time.deltaTime) * 0.01f) * (Time.deltaTime * 1000f), ApologyWindow.localPosition.y, ApologyWindow.localPosition.z);
		if (ApologyWindow.localPosition.x < -1555f)
		{
			ApologyWindow.localPosition = new Vector3(1555f, ApologyWindow.localPosition.y, ApologyWindow.localPosition.z);
			Apologize = false;
			Timer = 0f;
		}
	}

	private void LateUpdate()
	{
		YandereHead.LookAt(SenpaiHead.position);
	}

	private void UpdateSkin(int skinColor)
	{
		UpdateMaleUniform(Data.maleUniform.Value, skinColor);
		SkinColorLabel.text = "Skin Color " + skinColor;
	}

	private void UpdateHairStyle(int hairstyle)
	{
		for (int i = 1; i < Hairstyles.Length; i++)
		{
			Hairstyles[i].SetActive(value: false);
		}
		if (hairstyle > 0)
		{
			HairRenderer = Hairstyles[hairstyle].GetComponent<Renderer>();
			Hairstyles[hairstyle].SetActive(value: true);
		}
		HairStyleLabel.text = "Hair Style " + hairstyle;
		UpdateColor(Data.hairColor.Value);
	}

	private void UpdateFacialHair(int facialHair)
	{
		for (int i = 1; i < FacialHairstyles.Length; i++)
		{
			FacialHairstyles[i].SetActive(value: false);
		}
		if (facialHair > 0)
		{
			FacialHairRenderer = FacialHairstyles[facialHair].GetComponent<Renderer>();
			FacialHairstyles[facialHair].SetActive(value: true);
		}
		FacialHairStyleLabel.text = "Facial Hair " + facialHair;
		UpdateColor(Data.hairColor.Value);
	}

	private void UpdateColor(int hairColor)
	{
		KeyValuePair<Color, string> keyValuePair = ColorPairs[hairColor];
		Color key = keyValuePair.Key;
		HairColorName = keyValuePair.Value;
		if (Data.hairstyle.Value > 0)
		{
			HairRenderer = Hairstyles[Data.hairstyle.Value].GetComponent<Renderer>();
			HairRenderer.material.color = key;
		}
		if (Data.facialHair.Value > 0)
		{
			FacialHairRenderer = FacialHairstyles[Data.facialHair.Value].GetComponent<Renderer>();
			FacialHairRenderer.material.color = key;
			if (FacialHairRenderer.materials.Length > 1)
			{
				FacialHairRenderer.materials[1].color = key;
			}
		}
		HairColorLabel.text = "Hair Color " + hairColor;
	}

	private void UpdateEyes(int eyeColor)
	{
		KeyValuePair<Color, string> keyValuePair = ColorPairs[eyeColor];
		Color key = keyValuePair.Key;
		EyeColorName = keyValuePair.Value;
		EyeR.material.color = key;
		EyeL.material.color = key;
		EyeColorLabel.text = "Eye Color " + eyeColor;
	}

	private void UpdateEyewear(int eyewear)
	{
		for (int i = 1; i < Eyewears.Length; i++)
		{
			Eyewears[i].SetActive(value: false);
		}
		if (eyewear > 0)
		{
			Eyewears[eyewear].SetActive(value: true);
		}
		EyeWearLabel.text = "Eye Wear " + eyewear;
	}

	private void UpdateMaleUniform(int maleUniform, int skinColor)
	{
		SenpaiRenderer.sharedMesh = MaleUniforms[maleUniform];
		switch (maleUniform)
		{
		case 1:
			SenpaiRenderer.materials[0].mainTexture = SkinTextures[skinColor];
			SenpaiRenderer.materials[1].mainTexture = MaleUniformTextures[maleUniform];
			SenpaiRenderer.materials[2].mainTexture = FaceTextures[skinColor];
			break;
		case 2:
			SenpaiRenderer.materials[0].mainTexture = MaleUniformTextures[maleUniform];
			SenpaiRenderer.materials[1].mainTexture = FaceTextures[skinColor];
			SenpaiRenderer.materials[2].mainTexture = SkinTextures[skinColor];
			break;
		case 3:
			SenpaiRenderer.materials[0].mainTexture = MaleUniformTextures[maleUniform];
			SenpaiRenderer.materials[1].mainTexture = FaceTextures[skinColor];
			SenpaiRenderer.materials[2].mainTexture = SkinTextures[skinColor];
			break;
		case 4:
			SenpaiRenderer.materials[0].mainTexture = FaceTextures[skinColor];
			SenpaiRenderer.materials[1].mainTexture = SkinTextures[skinColor];
			SenpaiRenderer.materials[2].mainTexture = MaleUniformTextures[maleUniform];
			break;
		case 5:
			SenpaiRenderer.materials[0].mainTexture = FaceTextures[skinColor];
			SenpaiRenderer.materials[1].mainTexture = SkinTextures[skinColor];
			SenpaiRenderer.materials[2].mainTexture = MaleUniformTextures[maleUniform];
			break;
		case 6:
			SenpaiRenderer.materials[0].mainTexture = FaceTextures[skinColor];
			SenpaiRenderer.materials[1].mainTexture = SkinTextures[skinColor];
			SenpaiRenderer.materials[2].mainTexture = MaleUniformTextures[maleUniform];
			break;
		}
		MaleUniformLabel.text = "Male Uniform " + maleUniform;
	}

	private void UpdateFemaleUniform(int femaleUniform)
	{
		YandereRenderer.sharedMesh = FemaleUniforms[femaleUniform];
		YandereRenderer.materials[0].mainTexture = FemaleUniformTextures[femaleUniform];
		YandereRenderer.materials[1].mainTexture = FemaleUniformTextures[femaleUniform];
		YandereRenderer.materials[2].mainTexture = FemaleFace;
		YandereRenderer.materials[3].mainTexture = FemaleFace;
		FemaleUniformLabel.text = "Female Uniform " + femaleUniform;
	}

	private void LoveSickColorSwap()
	{
		GameObject[] array = Object.FindObjectsOfType<GameObject>();
		foreach (GameObject obj in array)
		{
			UISprite component = obj.GetComponent<UISprite>();
			if (component != null && component.color != Color.black && component.transform.parent != Highlight && component.transform.parent != UniformHighlight)
			{
				component.color = new Color(1f, 0f, 0f, component.color.a);
			}
			UITexture component2 = obj.GetComponent<UITexture>();
			if (component2 != null)
			{
				component2.color = new Color(1f, 0f, 0f, component2.color.a);
			}
			UILabel component3 = obj.GetComponent<UILabel>();
			if (component3 != null && component3.color != Color.black)
			{
				component3.color = new Color(1f, 0f, 0f, component3.color.a);
			}
		}
	}
}
