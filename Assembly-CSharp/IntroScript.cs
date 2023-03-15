using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class IntroScript : MonoBehaviour
{
	public PostProcessingBehaviour PostProcessing;

	public PostProcessingBehaviour GUIPP;

	public PostProcessingProfile Profile;

	public NoiseEffect Noise;

	public GlassShardSpawnerScript GlassShardSpawner;

	public GameObject[] AttackPair;

	public GameObject MontagePrefab;

	public GameObject CorpseCamera;

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

	public Transform[] Corpses;

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

	public Animation WindowAnim;

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

	public UITexture SanitySmudges;

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

	public bool ResetSpeed;

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

	public float Tension;

	public float Alpha;

	public float Timer;

	public float DeathCameraTimer;

	public float AnimTimer;

	public int PhotosSpawned;

	public int TextureID;

	public int CorpseID;

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
		LoveSickCheck();
		Circle.fillAmount = 0f;
		if (!New)
		{
			Darkness.color = new Color(0f, 0f, 0f, 1f);
		}
		Label.text = string.Empty;
		SkipTimer = 15f;
		if (New)
		{
			SetToDefault();
			RenderSettings.ambientLight = new Color(1f, 1f, 1f);
			BloodyHandsAnim["f02_clenchFists_00"].speed = 0.166666f;
			HoleInChestAnim["f02_holeInChest_00"].speed = 0f;
			YoungRyobaAnim["f02_introHoldHands_00"].speed = 0f;
			YoungFatherAnim["introHoldHands_00"].speed = 0f;
			WindowAnim["f02_yandereWindowSit_00"].speed = 1.2f;
			BrightenEnvironment();
			base.transform.position = new Vector3(0f, 1.255f, 0.2f);
			base.transform.eulerAngles = new Vector3(45f, 0f, 0f);
			HoleInChestAnim.gameObject.SetActive(value: false);
			BloodyHandsAnim.gameObject.SetActive(value: true);
			Montage.gameObject.SetActive(value: false);
			ConfessionScene.SetActive(value: false);
			ParentAndChild.SetActive(value: false);
			DeathCorridor.SetActive(value: false);
			Stalking.SetActive(value: false);
			School.SetActive(value: false);
			Room.SetActive(value: false);
			SetToDefault();
			DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
			settings.focusDistance = 0.66666f;
			settings.aperture = 32f;
			Profile.depthOfField.settings = settings;
			AttackAnim[1]["f02_katanaHighSanityA_00"].speed = 2.5f;
			AttackAnim[2]["f02_katanaHighSanityB_00"].speed = 2.5f;
			AttackAnim[3]["f02_batLowSanityA_00"].speed = 2.5f;
			AttackAnim[4]["f02_batLowSanityB_00"].speed = 2.5f;
			AttackAnim[5]["f02_katanaLowSanityA_00"].speed = 2.5f;
			AttackAnim[6]["f02_katanaLowSanityB_00"].speed = 2.5f;
			MotherAnim["f02_parentTalking_00"].speed = 0.75f;
			ChildAnim["f02_childListening_00"].speed = 0.75f;
			for (int i = 4; i < Cue.Length; i++)
			{
				if (i < 21)
				{
					Cue[i] += 3.898f;
				}
				else if (i > 32)
				{
					Cue[i] += 4f;
				}
				else
				{
					Cue[i] += 2f;
				}
				if (i > 40)
				{
					Cue[i] += 3f;
				}
			}
		}
		VtuberCheck();
	}

	private void Update()
	{
		if (VibrationCheck)
		{
			VibrationTimer = Mathf.MoveTowards(VibrationTimer, 0f, Time.deltaTime);
			if (VibrationTimer == 0f)
			{
				GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
				VibrationCheck = false;
			}
		}
		if (Input.GetButton("X"))
		{
			Circle.fillAmount = Mathf.MoveTowards(Circle.fillAmount, 1f, Time.deltaTime);
			SkipTimer = 15f;
			if (Circle.fillAmount == 1f)
			{
				FadeOut = true;
			}
			SkipPanel.alpha = 1f;
		}
		else
		{
			Circle.fillAmount = Mathf.MoveTowards(Circle.fillAmount, 0f, Time.deltaTime);
			SkipTimer -= Time.deltaTime * 2f;
			SkipPanel.alpha = SkipTimer / 10f;
		}
		StartTimer += Time.deltaTime;
		if (StartTimer > 1f && !Narrating)
		{
			Narration.Play();
			Narrating = true;
			if (BGM != null)
			{
				BGM.Play();
			}
		}
		Timer = Narration.time;
		if (ID < Cue.Length && Narration.time > Cue[ID])
		{
			Label.text = Lines[ID];
			ID++;
		}
		if (FadeOut)
		{
			FadeOutDarkness.color = new Color(FadeOutDarkness.color.r, FadeOutDarkness.color.g, FadeOutDarkness.color.b, Mathf.MoveTowards(FadeOutDarkness.color.a, 1f, Time.deltaTime));
			Circle.fillAmount = 1f;
			Narration.volume = FadeOutDarkness.color.a;
			if (FadeOutDarkness.color.a == 1f)
			{
				SceneManager.LoadScene("KokonaTutorialScene");
			}
		}
		if (!New)
		{
			if (Narration.time > 39.75f && Narration.time < 73f)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime * 0.5f));
			}
			if (Narration.time > 73f && Narration.time < 105.5f)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			}
			if (Narration.time > 105.5f && Narration.time < 134f)
			{
				Darkness.color = new Color(1f, 0f, 0f, 1f);
			}
			if (Narration.time > 134f && Narration.time < 147f)
			{
				Darkness.color = new Color(0f, 0f, 0f, 1f);
			}
			if (Narration.time > 147f && Narration.time < 152f)
			{
				Logo.transform.localScale = new Vector3(Logo.transform.localScale.x + Time.deltaTime * 0.1f, Logo.transform.localScale.y + Time.deltaTime * 0.1f, Logo.transform.localScale.z + Time.deltaTime * 0.1f);
				LoveSickLogo.transform.localScale = new Vector3(LoveSickLogo.transform.localScale.x + Time.deltaTime * 0.05f, LoveSickLogo.transform.localScale.y + Time.deltaTime * 0.05f, LoveSickLogo.transform.localScale.z + Time.deltaTime * 0.05f);
				Logo.color = new Color(Logo.color.r, Logo.color.g, Logo.color.b, 1f);
				LoveSickLogo.color = new Color(LoveSickLogo.color.r, LoveSickLogo.color.g, LoveSickLogo.color.b, 1f);
			}
			if (Narration.time > 155.898f)
			{
				Logo.color = new Color(Logo.color.r, Logo.color.g, Logo.color.b, 0f);
				LoveSickLogo.color = new Color(LoveSickLogo.color.r, LoveSickLogo.color.g, LoveSickLogo.color.b, 0f);
			}
			if (Narration.time > 159.898f)
			{
				SceneManager.LoadScene("KokonaTutorialScene");
			}
		}
		if (!New)
		{
			return;
		}
		if (ID > 19)
		{
			AnimTimer += Time.deltaTime;
		}
		if (ID > 52)
		{
			if (Narration.isPlaying)
			{
				return;
			}
			if (MontageParent != null)
			{
				Object.Destroy(MontageParent.gameObject);
				Darkness.color = new Color(0f, 0f, 0f, 0f);
				Montage.gameObject.SetActive(value: false);
				PostProcessing.enabled = true;
				Label.enabled = false;
				GUIPP.enabled = true;
				Speed = 0f;
				if (GameGlobals.LoveSick)
				{
					LoveSickLogo.gameObject.SetActive(value: true);
				}
				else
				{
					Logo.gameObject.SetActive(value: true);
				}
				DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
				settings.focusDistance = 10f;
				Profile.depthOfField.settings = settings;
				Profile.depthOfField.enabled = true;
				BloomModel.Settings settings2 = Profile.bloom.settings;
				settings2.bloom.intensity = 1f;
				Profile.bloom.settings = settings2;
				Profile.bloom.enabled = true;
				GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
				VibrationCheck = true;
				VibrationTimer = 0.1f;
			}
			Logo.transform.localScale = new Vector3(Logo.transform.localScale.x + Time.deltaTime * 0.1f, Logo.transform.localScale.y + Time.deltaTime * 0.1f, Logo.transform.localScale.z + Time.deltaTime * 0.1f);
			LoveSickLogo.transform.localScale = new Vector3(LoveSickLogo.transform.localScale.x + Time.deltaTime * 0.05f, LoveSickLogo.transform.localScale.y + Time.deltaTime * 0.05f, LoveSickLogo.transform.localScale.z + Time.deltaTime * 0.05f);
			Logo.color = new Color(Logo.color.r, Logo.color.g, Logo.color.b, 1f);
			LoveSickLogo.color = new Color(LoveSickLogo.color.r, LoveSickLogo.color.g, LoveSickLogo.color.b, 1f);
			Speed += Time.deltaTime;
			if (Speed > 11f)
			{
				SceneManager.LoadScene("KokonaTutorialScene");
			}
			else if (Speed > 5f && (Logo.gameObject.activeInHierarchy || LoveSickLogo.gameObject.activeInHierarchy))
			{
				LoveSickLogo.gameObject.SetActive(value: false);
				Logo.gameObject.SetActive(value: false);
				GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
				VibrationCheck = true;
				VibrationTimer = 0.1f;
			}
		}
		else if (ID > 51)
		{
			if (DeathCorridor.activeInHierarchy)
			{
				RenderSettings.ambientLight = new Color(1f, 1f, 1f);
				Darkness.color = new Color(0f, 0f, 0f, 0f);
				DeathCorridor.SetActive(value: false);
				PostProcessing.enabled = false;
				CorpseCamera.SetActive(value: false);
				BloodParent.SetActive(value: false);
				Stalking.SetActive(value: false);
				BGM.volume = 1f;
				Speed = 0f;
				SetToDefault();
				DepthOfFieldModel.Settings settings3 = Profile.depthOfField.settings;
				settings3.focusDistance = 10f;
				Profile.depthOfField.settings = settings3;
				Profile.depthOfField.enabled = false;
				BloomModel.Settings settings4 = Profile.bloom.settings;
				settings4.bloom.intensity = 0.5f;
				Profile.bloom.settings = settings4;
				Profile.bloom.enabled = false;
				VibrationIntensity = 0f;
				SanitySmudges.alpha = 0f;
				Noise.enabled = false;
			}
			Speed += 1f;
			if (Speed > 2f)
			{
				Speed = 0f;
				TextureID++;
				if (TextureID == 31)
				{
					TextureID = 1;
				}
				if (TextureID > 10 && TextureID < 21)
				{
					PostProcessing.enabled = true;
				}
				else
				{
					PostProcessing.enabled = false;
				}
				GameObject obj = Object.Instantiate(MontagePrefab, base.transform.position, Quaternion.identity);
				obj.GetComponent<Renderer>().material.mainTexture = Textures[TextureID];
				obj.transform.parent = MontageParent;
				obj.transform.localScale = new Vector3(0.6833265f, 0.38444048f, 0.33333f);
				obj.transform.localPosition = new Vector3(Random.Range(-0.633333f, 0.633333f), Random.Range(-0.29f, 0.29f), (float)PhotosSpawned * -0.0001f);
				obj.transform.localEulerAngles = new Vector3(0f, 0f, Random.Range(-15f, 15f));
				Montage.material.mainTexture = Textures[TextureID];
				PhotosSpawned++;
			}
			if (Timer > 225f)
			{
				Darkness.color = new Color(0f, 0f, 0f, 1f);
				return;
			}
			VibrationIntensity += Time.deltaTime * 0.2f;
			GamePad.SetVibration(PlayerIndex.One, VibrationIntensity, VibrationIntensity);
			VibrationCheck = true;
			VibrationTimer = 0.1f;
		}
		else if (ID > 41)
		{
			if (base.transform.position.z < 0f)
			{
				RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.25f);
				AttackPair[3].SetActive(value: false);
				DeathCorridor.SetActive(value: true);
				Stalking.SetActive(value: false);
				Quad.SetActive(value: false);
				base.transform.position = new Vector3(0f, 1f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 0f, -15f);
				ColorGradingModel.Settings settings5 = Profile.colorGrading.settings;
				settings5.basic.saturation = 1f;
				settings5.channelMixer.red = new Vector3(1f, 0f, 0f);
				settings5.channelMixer.green = new Vector3(0f, 1f, 0f);
				settings5.channelMixer.blue = new Vector3(0f, 0f, 1f);
				Profile.colorGrading.settings = settings5;
				Rotation = -15f;
				Speed = 0f;
				BGM.volume = 0.5f;
				SanitySmudges.alpha = 1f;
				Noise.enabled = true;
			}
			Speed += Time.deltaTime * 0.015f;
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 1f, 34f), Time.deltaTime * Speed);
			Rotation = Mathf.Lerp(Rotation, 15f, Time.deltaTime * Speed);
			base.transform.eulerAngles = new Vector3(0f, 0f, Rotation);
			if (ID < 51)
			{
				if (ID < 49)
				{
					Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.2f);
					if (Alpha == 0f)
					{
						DeathCameraTimer += Time.deltaTime * Tension;
						if (DeathCameraTimer >= 3f)
						{
							CorpseCamera.transform.position += new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * Time.deltaTime;
							if (!CorpseCamera.activeInHierarchy)
							{
								CorpseCamera.transform.position += new Vector3(0f, 0f, 2f);
								CorpseID++;
								CorpseCamera.transform.LookAt(Corpses[CorpseID]);
								CorpseCamera.SetActive(value: true);
								SanitySmudges.alpha = 0f;
							}
							if (DeathCameraTimer >= 4f)
							{
								DeathCameraTimer = 0f;
								CorpseCamera.SetActive(value: false);
								SanitySmudges.alpha = 1f;
							}
						}
					}
				}
				else if (CorpseCamera.activeInHierarchy)
				{
					DeathCameraTimer = 0f;
					SanitySmudges.alpha = 1f;
					CorpseCamera.SetActive(value: false);
				}
			}
			else
			{
				Alpha = 1f;
			}
			Darkness.color = new Color(0f, 0f, 0f, Alpha);
		}
		else if (ID > 33)
		{
			if (School.activeInHierarchy)
			{
				School.SetActive(value: false);
				Stalking.SetActive(value: true);
				base.transform.position = new Vector3(-0.02f, 1.12f, 1f);
				base.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				SetToDefault();
				Speed = 0f;
			}
			if (ID < 40)
			{
				VibrationIntensity += Time.deltaTime * 0.05f;
				GamePad.SetVibration(PlayerIndex.One, VibrationIntensity, VibrationIntensity);
				VibrationCheck = true;
				VibrationTimer = 0.1f;
			}
			if (ID < 37)
			{
				Speed += Time.deltaTime * 0.1f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-0.02f, 1.12f, -0.25f), Time.deltaTime * Speed);
				Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.2f);
			}
			else
			{
				if (Speed > 0f)
				{
					CameraRotationY = 0f;
					Speed = 0f;
				}
				Speed -= Time.deltaTime * 0.1f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0.3f, 0.8f, -0.25f), Time.deltaTime * Speed * -1f);
				CameraRotationY = Mathf.Lerp(CameraRotationY, -15f, Time.deltaTime * Speed * -1f);
				base.transform.eulerAngles = new Vector3(0f, CameraRotationY, 0f);
				if (Timer > 179f)
				{
					StalkerAnim.Play("f02_clenchFist_00");
				}
				if (ID == 40)
				{
					Alpha = 1f;
				}
				if (ID > 39)
				{
					BGM.volume += Time.deltaTime;
				}
				if (Timer > 186f)
				{
					DeathCorridor.SetActive(value: true);
					Alpha = 1f;
				}
				else if (Timer > 185.6f)
				{
					AttackPair[2].SetActive(value: false);
					AttackPair[3].SetActive(value: true);
					GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
					VibrationCheck = true;
					VibrationTimer = 0.2f;
					Alpha = 0f;
				}
				else if (Timer > 185.2f)
				{
					Alpha = 1f;
				}
				else if (Timer > 184.8f)
				{
					AttackPair[1].SetActive(value: false);
					AttackPair[2].SetActive(value: true);
					GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
					VibrationCheck = true;
					VibrationTimer = 0.2f;
					Alpha = 0f;
				}
				else if (Timer > 184.4f)
				{
					Alpha = 1f;
				}
				else if (Timer > 184f)
				{
					ColorGradingModel.Settings settings6 = Profile.colorGrading.settings;
					settings6.channelMixer.red = new Vector3(0.1f, 0f, 0f);
					settings6.channelMixer.green = Vector3.zero;
					settings6.channelMixer.blue = Vector3.zero;
					Profile.colorGrading.settings = settings6;
					Alpha = 0f;
					Stalking.SetActive(value: false);
					Quad.SetActive(value: true);
					AttackPair[1].SetActive(value: true);
					GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
					VibrationCheck = true;
					VibrationTimer = 0.2f;
					Noise.enabled = true;
				}
			}
			Darkness.color = new Color(0f, 0f, 0f, Alpha);
		}
		else if (ID > 31)
		{
			if (!Osana.activeInHierarchy)
			{
				base.transform.position = new Vector3(0.5f, 1.366666f, 0.25f);
				base.transform.eulerAngles = new Vector3(15f, -67.5f, 0f);
				SenpaiAnim.transform.parent.localPosition = new Vector3(0.533333f, 0f, -6.9f);
				SenpaiAnim.transform.parent.localEulerAngles = new Vector3(0f, 90f, 0f);
				SenpaiAnim.Play("Monday_1");
				Osana.SetActive(value: true);
				DepthOfFieldModel.Settings settings7 = Profile.depthOfField.settings;
				settings7.focusDistance = 1.5f;
				Profile.depthOfField.settings = settings7;
				YandereAnim["f02_Intro_00"].speed = 0.33333f;
				Darkness.color = new Color(0f, 0f, 0f, 0f);
				Alpha = 0f;
			}
			base.transform.Translate(Vector3.forward * 0.01f * Time.deltaTime, Space.Self);
			TurnRed();
			if (Narration.time > 156.2f)
			{
				Darkness.color = new Color(0f, 0f, 0f, 1f);
				Alpha = 1f;
			}
		}
		else if (ID > 27)
		{
			if (base.transform.position.x > 0f)
			{
				base.transform.position = new Vector3(-1.5f, 1f, -1.5f);
				base.transform.eulerAngles = new Vector3(0f, 45f, 0f);
				YandereAnim["f02_Intro_00"].time += 0f;
				SenpaiAnim["Intro_00"].time += 0f;
				YandereAnim["f02_Intro_00"].speed = 1.33333f;
				SenpaiAnim["Intro_00"].speed = 1.33333f;
				Speed = 0f;
				DepthOfFieldModel.Settings settings8 = Profile.depthOfField.settings;
				settings8.focusDistance = 1.5f;
				settings8.aperture = 11.2f;
				Profile.depthOfField.settings = settings8;
			}
			if (ID > 28)
			{
				Speed += Time.deltaTime * 0.1f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-1.1f, 1.33333f, 1f), Time.deltaTime * Speed);
				base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, new Vector3(0f, 135f, 0f), Time.deltaTime * Speed);
			}
			if (ID > 29)
			{
				Stars.Stop();
				Bubbles.Stop();
			}
			if (ID > 30)
			{
				TurnNeutral();
			}
		}
		else if (ID > 23)
		{
			if (EyeTimer == 0f)
			{
				base.transform.position = new Vector3(0f, 0.9f, 0f);
				base.transform.eulerAngles = new Vector3(15f, -45f, 0f);
				YandereAnim["f02_Intro_00"].speed = 0.2f;
				SenpaiAnim["Intro_00"].speed = 0.2f;
				Yandere.materials[2].SetFloat("_BlendAmount", 1f);
				DepthOfFieldModel.Settings settings9 = Profile.depthOfField.settings;
				settings9.focusDistance = 1.5f;
				settings9.aperture = 11.2f;
				Profile.depthOfField.settings = settings9;
			}
			EyeTimer += Time.deltaTime;
			if (EyeTimer > 0.1f)
			{
				Yandere.materials[2].SetTextureOffset("_OverlayTex", new Vector2(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f)));
				EyeTimer -= 0.1f;
			}
			base.transform.Translate(Vector3.forward * -0.1f * Time.deltaTime, Space.Self);
		}
		else if (ID > 19)
		{
			if (Room.gameObject.activeInHierarchy)
			{
				Room.gameObject.SetActive(value: false);
				School.SetActive(value: true);
				base.transform.localPosition = new Vector3(-3f, 1f, 1.5f);
				Darkness.color = new Color(0f, 0f, 0f, 1f);
				Alpha = 1f;
				Speed = 0f;
				ColorGradingModel.Settings settings10 = Profile.colorGrading.settings;
				settings10.basic.saturation = 0f;
				Profile.colorGrading.settings = settings10;
				DepthOfFieldModel.Settings settings11 = Profile.depthOfField.settings;
				settings11.focusDistance = 10f;
				settings11.aperture = 5.6f;
				Profile.depthOfField.settings = settings11;
				Yandere.materials[2].SetFloat("_BlendAmount", 0f);
			}
			if (Narration.time < 94.898f)
			{
				base.transform.position = Vector3.MoveTowards(base.transform.position, new Vector3(0f, 1f, -2f), Time.deltaTime * 1.09f);
			}
			else
			{
				DepthOfFieldModel.Settings settings12 = Profile.depthOfField.settings;
				settings12.focusDistance = 1.2f;
				settings12.aperture = 11.2f;
				Profile.depthOfField.settings = settings12;
				if (Narration.time < 101.5f)
				{
					base.transform.position = new Vector3(-0.25f, 0.75f, -0.25f);
					base.transform.eulerAngles = new Vector3(22.5f, -45f, 0f);
					Senpai.transform.position = new Vector3(0f, -0.2f, 0f);
				}
				else
				{
					Speed += Time.deltaTime * 0.5f;
					Senpai.transform.position = Vector3.Lerp(Senpai.transform.position, new Vector3(0f, 0f, 0f), Time.deltaTime * Speed * 2f);
					base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-0.25f, 0.66666f, -1.25f), Time.deltaTime * Speed * 0.5f);
					CameraRotationX = Mathf.Lerp(CameraRotationX, 0f, Time.deltaTime * Speed);
					CameraRotationY = Mathf.Lerp(CameraRotationY, 0f, Time.deltaTime * Speed);
					base.transform.eulerAngles = new Vector3(CameraRotationX, CameraRotationY, 0f);
				}
			}
			if (ID > 21)
			{
				YandereAnim["f02_Intro_00"].speed = Mathf.MoveTowards(YandereAnim["f02_Intro_00"].speed, 0.1f, Time.deltaTime);
				SenpaiAnim["Intro_00"].speed = Mathf.MoveTowards(SenpaiAnim["Intro_00"].speed, 0.1f, Time.deltaTime);
				if (Narration.time > 106.5f)
				{
					ColorGradingModel.Settings settings13 = Profile.colorGrading.settings;
					settings13.basic.saturation = Mathf.MoveTowards(settings13.basic.saturation, 2f, Time.deltaTime);
					settings13.channelMixer.red = Vector3.MoveTowards(settings13.channelMixer.red, new Vector3(2f, 0f, 0f), Time.deltaTime);
					settings13.channelMixer.blue = Vector3.MoveTowards(settings13.channelMixer.blue, new Vector3(0f, 0f, 2f), Time.deltaTime);
					Profile.colorGrading.settings = settings13;
					Particles.SetActive(value: true);
				}
			}
			else if (Narration.time > 98f)
			{
				YandereAnim["f02_Intro_00"].speed = 1f;
				SenpaiAnim["Intro_00"].speed = 1f;
			}
			else if (Narration.time > 97f)
			{
				YandereAnim["f02_Intro_00"].speed = 3f;
				SenpaiAnim["Intro_00"].speed = 3f;
			}
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.2f);
			Darkness.color = new Color(0f, 0f, 0f, Alpha);
		}
		else if (ID > 15)
		{
			if (ParentAndChild.gameObject.activeInHierarchy)
			{
				ParentAndChild.gameObject.SetActive(value: false);
				Room.SetActive(value: true);
				base.transform.position = new Vector3(0f, 1f, 0f);
				Darkness.color = new Color(0f, 0f, 0f, 1f);
				Alpha = 1f;
				Speed = 0.1f;
				DepthOfFieldModel.Settings settings14 = Profile.depthOfField.settings;
				settings14.focusDistance = 10f;
				Profile.depthOfField.settings = settings14;
				GlassShardSpawner.gameObject.SetActive(value: false);
			}
			base.transform.position -= new Vector3(0f, 0f, Time.deltaTime * Speed * 0.75f);
			if (Narration.time > 88.898f)
			{
				Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * 0.66666f);
			}
			else
			{
				Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.2f);
			}
			Darkness.color = new Color(0f, 0f, 0f, Alpha);
		}
		else if (ID > 13)
		{
			if (ConfessionScene.gameObject.activeInHierarchy)
			{
				GlassShardSpawner.enabled = false;
				ConfessionScene.gameObject.SetActive(value: false);
				ParentAndChild.SetActive(value: true);
				X = 15f;
				Y = -90f;
				X2 = 15f;
				Y2 = -90f;
				Z2 = 0f;
				base.transform.position = new Vector3(0f, 0.5f, -1f);
				Darkness.color = new Color(0f, 0f, 0f, 1f);
				Alpha = 1f;
				Speed = 0.1f;
				ColorGradingModel.Settings settings15 = Profile.colorGrading.settings;
				settings15.basic.saturation = 1f;
				Profile.colorGrading.settings = settings15;
				BloomModel.Settings settings16 = Profile.bloom.settings;
				settings16.bloom.intensity = 1f;
				Profile.bloom.settings = settings16;
				DepthOfFieldModel.Settings settings17 = Profile.depthOfField.settings;
				settings17.focusDistance = 10f;
				settings17.aperture = 11.2f;
				Profile.depthOfField.settings = settings17;
				GlassShardSpawner.RestoreShards();
			}
			base.transform.position -= new Vector3(0f, 0f, Time.deltaTime * Speed);
			if (Narration.time > 69.898f)
			{
				Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * 0.5f);
			}
			else
			{
				Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.2f);
			}
			Darkness.color = new Color(0f, 0f, 0f, Alpha);
		}
		else if (ID > 9)
		{
			if (HoleInChestAnim.gameObject.activeInHierarchy)
			{
				SetToDefault();
				RenderSettings.ambientLight = new Color(1f, 1f, 1f);
				RenderSettings.fog = false;
				HoleInChestAnim.gameObject.SetActive(value: false);
				ConfessionScene.SetActive(value: true);
				base.transform.position = new Vector3(0f, 1f, -1f);
				Darkness.color = new Color(0f, 0f, 0f, 1f);
				Alpha = 1f;
				Speed = 0.1f;
				DepthOfFieldModel.Settings settings18 = Profile.depthOfField.settings;
				settings18.focusDistance = 1f;
				Profile.depthOfField.settings = settings18;
				ColorGradingModel.Settings settings19 = Profile.colorGrading.settings;
				settings19.basic.saturation = 0f;
				Profile.colorGrading.settings = settings19;
				base.transform.eulerAngles = Vector3.zero;
			}
			base.transform.position -= new Vector3(0f, 0f, Time.deltaTime * Speed);
			if (ID > 10)
			{
				GlassShardSpawner.Fall = true;
				YoungRyobaAnim["f02_introHoldHands_00"].speed = 0.5f;
				YoungRyobaAnim.Play();
				YoungFatherAnim["introHoldHands_00"].speed = 0.5f;
				YoungFatherAnim.Play();
				Brightness = Mathf.MoveTowards(Brightness, 1f, Time.deltaTime * 0.25f);
				BrightenEnvironment();
				Blossoms.Play();
				X = Mathf.MoveTowards(X, 0f, Time.deltaTime * 10f);
			}
			if (ID > 11)
			{
				ColorGradingModel.Settings settings20 = Profile.colorGrading.settings;
				settings20.basic.saturation += Time.deltaTime * 0.25f;
				BloomModel.Settings settings21 = Profile.bloom.settings;
				settings21.bloom.intensity = 1f + settings20.basic.saturation;
				Profile.bloom.settings = settings21;
				Profile.colorGrading.settings = settings20;
			}
			if (Narration.time > 56.898f)
			{
				Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * 0.5f);
			}
			else
			{
				Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.2f);
			}
			Darkness.color = new Color(0f, 0f, 0f, Alpha);
		}
		else if (ID > 4)
		{
			DepthOfFieldModel.Settings settings22 = Profile.depthOfField.settings;
			if (BloodyHandsAnim.gameObject.activeInHierarchy)
			{
				GlassShardSpawner.enabled = true;
				RenderSettings.ambientLight = new Color(0f, 0f, 0f);
				RenderSettings.fog = true;
				base.transform.position = new Vector3(0.012f, 1.13f, 0.029f);
				base.transform.eulerAngles = new Vector3(0f, 0f, -15f);
				BloodyHandsAnim.gameObject.SetActive(value: false);
				HoleInChestAnim.gameObject.SetActive(value: true);
				Alpha = 1f;
				Darkness.color = new Color(0f, 0f, 0f, Alpha);
				SetToDefault();
				settings22.focusDistance = 0.1f;
				Profile.depthOfField.settings = settings22;
				Profile.depthOfField.enabled = true;
				VignetteModel.Settings settings23 = Profile.vignette.settings;
				settings23.color = new Color(0.01960784f, 0.04313726f, 0.1333333f);
				settings23.smoothness = 1f;
				Profile.vignette.settings = settings23;
			}
			base.transform.eulerAngles += new Vector3(0f, 0f, Time.deltaTime);
			Speed = Mathf.MoveTowards(Speed, 0.1f, Time.deltaTime * 0.02f);
			base.transform.position -= new Vector3(0f, 0f, Time.deltaTime * Speed);
			if (base.transform.position.z < 0f)
			{
				if (base.transform.position.z < -0.1f)
				{
					settings22.focusDistance = 0f - base.transform.position.z;
					Profile.depthOfField.settings = settings22;
				}
				if (ID < 7)
				{
					SecondSpeed = Mathf.MoveTowards(SecondSpeed, 1f, Time.deltaTime * 0.1f);
					base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(base.transform.position.x, 1.1f, base.transform.position.z), Time.deltaTime * SecondSpeed);
				}
				else
				{
					if (!ResetSpeed)
					{
						ResetSpeed = true;
						SecondSpeed = 0f;
					}
					SecondSpeed = Mathf.MoveTowards(SecondSpeed, 1f, Time.deltaTime * 0.1f);
					base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(base.transform.position.x, 0.8f, base.transform.position.z), Time.deltaTime * SecondSpeed);
				}
			}
			if (base.transform.position.z < 0f)
			{
				HoleInChestAnim["f02_holeInChest_00"].speed = 0.3f;
				HoleInChestAnim.Play();
			}
			if (ID > 8)
			{
				if (Narration.time > 35f)
				{
					Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * 0.3f);
				}
				Darkness.color = new Color(0f, 0f, 0f, Alpha);
			}
			else
			{
				Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 0.2f);
				Darkness.color = new Color(0f, 0f, 0f, Alpha);
			}
		}
		else if (ID > 0)
		{
			if (Timer < 2f)
			{
				BloodyHandsAnim["f02_clenchFists_00"].time = 0.6f;
				BloodyHandsAnim["f02_clenchFists_00"].speed = 0f;
			}
			else
			{
				BloodyHandsAnim["f02_clenchFists_00"].speed = 0.07f;
			}
			if (ID > 3)
			{
				Alpha = 1f;
				Darkness.color = new Color(0f, 0f, 0f, Alpha);
				BGM.volume = Mathf.MoveTowards(BGM.volume, 0.5f, Time.deltaTime * 0.266666f);
			}
		}
	}

	private void LateUpdate()
	{
		if (!New)
		{
			return;
		}
		if (ID < 41)
		{
			if (Narration.time > 103f)
			{
				if (ID < 24)
				{
					LeftArm.localEulerAngles = new Vector3(0f, 15f, 0f);
					BookRight.localEulerAngles = new Vector3(0f, 180f, -90f);
					BookLeft.localEulerAngles = new Vector3(0f, 180f, 0f);
					BookRight.parent.parent.localPosition = new Vector3(-0.12f, -0.04f, 0f);
					BookRight.parent.parent.localEulerAngles = new Vector3(0f, -15f, -135f);
					BookRight.parent.parent.parent.localEulerAngles = new Vector3(45f, 45f, 0f);
				}
				else
				{
					BookRight.parent.parent.localPosition = new Vector3(-0.075f, -0.085f, 0f);
					BookRight.parent.parent.localEulerAngles = new Vector3(0f, -45f, -90f);
					BookRight.localEulerAngles = new Vector3(0f, 180f, -45f);
					BookLeft.localEulerAngles = new Vector3(0f, 180f, 45f);
				}
			}
			else if (Narration.time > 94.898f)
			{
				Rotation = 22.5f;
			}
		}
		if (Narration.time > 104f && Narration.time < 190f)
		{
			ThirdSpeed += Time.deltaTime;
			Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 3.6f * ThirdSpeed);
		}
		Neck.localEulerAngles += new Vector3(Rotation, 0f, 0f);
		if (Narration.time > 99f)
		{
			Weight = Mathf.MoveTowards(Weight, 0f, Time.deltaTime * 20f);
		}
		else if (Narration.time > 96.648f)
		{
			Weight = Mathf.MoveTowards(Weight, 50f, Time.deltaTime * 100f);
		}
		Yandere.SetBlendShapeWeight(5, Weight);
		Ponytail.transform.eulerAngles = new Vector3(X, Y, Z);
		Ponytail.transform.GetChild(0).eulerAngles = new Vector3(0f, 90f, 0f);
		RightHair.transform.eulerAngles = new Vector3(X2, Y2, Z2);
		LeftHair.transform.eulerAngles = new Vector3(X2, Y2, Z2);
		Ponytail2.transform.eulerAngles = new Vector3(X, Y, Z);
		RightHair2.transform.eulerAngles = new Vector3(X2, Y2, Z2);
		LeftHair2.transform.eulerAngles = new Vector3(X2, Y2, Z2);
		RightHand.localEulerAngles += new Vector3(Random.Range(1f, -1f), Random.Range(1f, -1f), Random.Range(1f, -1f));
	}

	private void LoveSickCheck()
	{
		if (GameGlobals.LoveSick)
		{
			Camera.main.backgroundColor = new Color(0f, 0f, 0f, 1f);
			GameObject[] array = Object.FindObjectsOfType<GameObject>();
			foreach (GameObject obj in array)
			{
				UISprite component = obj.GetComponent<UISprite>();
				if (component != null)
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
			FadeOutDarkness.color = new Color(0f, 0f, 0f, 0f);
			LoveSickLogo.enabled = true;
			Logo.enabled = false;
		}
		else
		{
			LoveSickLogo.enabled = false;
		}
	}

	private void BrightenEnvironment()
	{
		TreeRenderer[0].materials[0].color = new Color(Brightness, Brightness, Brightness, 1f);
		TreeRenderer[0].materials[1].color = new Color(Brightness, Brightness, Brightness, 1f);
		TreeRenderer[1].materials[0].color = new Color(Brightness, Brightness, Brightness, 1f);
		TreeRenderer[1].materials[1].color = new Color(Brightness, Brightness, Brightness, 1f);
		TreeRenderer[2].materials[0].color = new Color(Brightness, Brightness, Brightness, 1f);
		TreeRenderer[2].materials[1].color = new Color(Brightness, Brightness, Brightness, 1f);
		GrassBlades.material.SetColor("_BladeTopColor", new Color(0f, Brightness * 0.5f, 0f, 1f));
		Petals.material.color = new Color(Brightness, Brightness, Brightness, 1f);
		Mound.material.color = new Color(Brightness, Brightness, Brightness, 1f);
		Sky.material.color = new Color(Brightness, Brightness, Brightness, 1f);
		YoungFatherRenderer.materials[0].color = new Color(Brightness, Brightness, Brightness, 1f);
		YoungFatherRenderer.materials[1].color = new Color(Brightness, Brightness, Brightness, 1f);
		YoungFatherRenderer.materials[2].color = new Color(Brightness, Brightness, Brightness, 1f);
		YoungFatherHairRenderer.material.color = new Color(Brightness, Brightness, Brightness, 1f);
	}

	private void TurnNeutral()
	{
		ColorGradingModel.Settings settings = Profile.colorGrading.settings;
		settings.channelMixer.red = Vector3.MoveTowards(settings.channelMixer.red, new Vector3(1f, 0f, 0f), Time.deltaTime * 0.66666f);
		settings.channelMixer.green = Vector3.MoveTowards(settings.channelMixer.green, new Vector3(0f, 1f, 0f), Time.deltaTime * 0.66666f);
		settings.channelMixer.blue = Vector3.MoveTowards(settings.channelMixer.blue, new Vector3(0f, 0f, 1f), Time.deltaTime * 0.66666f);
		Profile.colorGrading.settings = settings;
	}

	private void TurnRed()
	{
		ColorGradingModel.Settings settings = Profile.colorGrading.settings;
		settings.basic.saturation = Mathf.MoveTowards(settings.basic.saturation, 1f, Time.deltaTime * 0.1f);
		settings.channelMixer.red = Vector3.MoveTowards(settings.channelMixer.red, new Vector3(1f, 0f, 0f), Time.deltaTime * 0.1f);
		settings.channelMixer.green = Vector3.MoveTowards(settings.channelMixer.green, new Vector3(0f, 0.5f, 0f), Time.deltaTime * 0.1f);
		settings.channelMixer.blue = Vector3.MoveTowards(settings.channelMixer.blue, new Vector3(0f, 0f, 0.5f), Time.deltaTime * 0.1f);
		Profile.colorGrading.settings = settings;
	}

	private void SetToDefault()
	{
		ColorGradingModel.Settings settings = Profile.colorGrading.settings;
		settings.basic.saturation = 1f;
		settings.channelMixer.red = new Vector3(1f, 0f, 0f);
		settings.channelMixer.green = new Vector3(0f, 1f, 0f);
		settings.channelMixer.blue = new Vector3(0f, 0f, 1f);
		Profile.colorGrading.settings = settings;
		DepthOfFieldModel.Settings settings2 = Profile.depthOfField.settings;
		settings2.focusDistance = 10f;
		settings2.aperture = 11.2f;
		Profile.depthOfField.settings = settings2;
		BloomModel.Settings settings3 = Profile.bloom.settings;
		settings3.bloom.intensity = 1f;
		Profile.bloom.settings = settings3;
		VignetteModel.Settings settings4 = Profile.vignette.settings;
		settings4.color = Color.black;
		settings4.intensity = 0.45f;
		settings4.smoothness = 0.2f;
		settings4.roundness = 1f;
		Profile.vignette.settings = settings4;
	}

	private void VtuberCheck()
	{
		if (GameGlobals.VtuberID > 0)
		{
			for (int i = 1; i < OriginalHairs.Length; i++)
			{
				OriginalHairs[i].SetActive(value: false);
				VtuberHairs[i].SetActive(value: true);
			}
			for (int i = 1; i < UniformSetters.Length; i++)
			{
				UniformSetters[i].AyanoFace = VtuberFaces[GameGlobals.VtuberID];
				UniformSetters[i].SetFemaleUniform();
			}
			for (int i = 0; i < 13; i++)
			{
				YandereRenderer.SetBlendShapeWeight(i, 0f);
			}
			YandereRenderer.SetBlendShapeWeight(9, 100f);
			ChildRenderer.materials[0].mainTexture = VtuberFaces[GameGlobals.VtuberID];
			ChildRenderer.materials[2].mainTexture = VtuberEyes[GameGlobals.VtuberID];
		}
		else
		{
			for (int j = 1; j < VtuberHairs.Length; j++)
			{
				VtuberHairs[j].SetActive(value: false);
			}
		}
	}
}
