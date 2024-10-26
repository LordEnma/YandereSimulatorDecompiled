using UnityEngine;
using UnityEngine.PostProcessing;

public class NewSettingsScript : MonoBehaviour
{
	public CameraFilterPack_Colors_Adjust_PreFilters ColorGrading;

	public MinimalistManagerScript MinimalistManager;

	public StudentManagerScript StudentManager;

	public NewTitleScreenScript NewTitleScreen;

	public QualityManagerScript QualityManager;

	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public PostProcessingProfile Profile;

	public ParticleSystem PlazaBlossoms;

	public Camera MainCamera;

	public Light Sun;

	public GameObject OptionList;

	public GameObject PostProcessing;

	public GameObject Details;

	public GameObject Gameplay;

	public GameObject Grass;

	public UIPanel[] Panel;

	public UISprite Cursor;

	public UILabel[] Labels;

	public int[] Limit;

	public int Selection = 1;

	public int Speed = 1;

	public int Menu = 1;

	public bool UpdateOnNextFrame;

	public bool HairPhysics;

	public bool SchoolScene;

	public bool Transition;

	public int[] Widths;

	public int[] Heights;

	public float LightIntensity = 0.5f;

	public Projector TitleScreenProjector;

	public Material FlowerMaterial;

	public Material BloodMaterial;

	public Renderer Window;

	public Renderer YandereRenderer;

	public Renderer YandereHairRenderer;

	public Shader ToonOutlineRimLight;

	public Shader ToonRimLight;

	public Shader ToonOutline;

	public Shader Toon;

	public void Start()
	{
		UpdateLabels();
		HairPhysics = !OptionGlobals.HairPhysics;
		if (!SchoolScene)
		{
			if (GameGlobals.CensorBlood)
			{
				TitleScreenProjector.material = FlowerMaterial;
			}
			else
			{
				TitleScreenProjector.material = BloodMaterial;
			}
		}
	}

	private void Update()
	{
		if (UpdateOnNextFrame)
		{
			UpdateLabels();
			UpdateOnNextFrame = false;
		}
		Cursor.transform.parent.Rotate(new Vector3(Time.unscaledDeltaTime * 100f, 0f, 0f), Space.Self);
		Cursor.transform.parent.localPosition = Vector3.Lerp(Cursor.transform.parent.localPosition, new Vector3(700f, -100f - 100f * (float)Selection, Cursor.transform.parent.localPosition.z), Time.unscaledDeltaTime * 10f);
		Labels[45].text = (Screen.fullScreen ? "No" : "Yes");
		if (Cursor.alpha == 1f)
		{
			if (NewTitleScreen.InputManager.TappedDown)
			{
				Selection++;
				UpdateCursor();
			}
			if (NewTitleScreen.InputManager.TappedUp)
			{
				Selection--;
				UpdateCursor();
			}
		}
		if (!(NewTitleScreen.Speed > 2f))
		{
			return;
		}
		if (Transition)
		{
			Cursor.alpha = Mathf.MoveTowards(Cursor.alpha, 0f, Time.unscaledDeltaTime * (float)Speed);
			for (int i = 0; i < Panel.Length; i++)
			{
				Panel[i].alpha = Mathf.MoveTowards(Panel[i].alpha, 0f, Time.unscaledDeltaTime * (float)Speed);
			}
			if (Cursor.alpha == 0f)
			{
				Transition = false;
				Selection = 1;
			}
			return;
		}
		Cursor.alpha = Mathf.MoveTowards(Cursor.alpha, 1f, Time.unscaledDeltaTime * (float)Speed);
		UpdatePanels();
		if (Panel[Menu].alpha != 1f || Cursor.alpha != 1f)
		{
			return;
		}
		if (Menu == 0)
		{
			if (!PromptBar.Show)
			{
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Make Selection";
				PromptBar.Label[1].text = "Go Back";
				PromptBar.Label[4].text = "Change Selection";
				PromptBar.Label[5].text = "Change Selection";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				Menu = Selection;
				Transition = true;
				PromptBar.Show = false;
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				if (SchoolScene)
				{
					PauseScreen.MainMenu.SetActive(value: true);
					base.gameObject.SetActive(value: false);
					base.enabled = false;
				}
				NewTitleScreen.Speed = 0f;
				NewTitleScreen.Phase = 2;
				PromptBar.Show = false;
				base.enabled = false;
			}
		}
		else if (Menu == 1)
		{
			if (!PromptBar.Show)
			{
				PromptBar.ClearButtons();
				PromptBar.Label[1].text = "Go Back";
				PromptBar.Label[2].text = "Set All to Lowest";
				PromptBar.Label[3].text = "Reset All to Default";
				PromptBar.Label[4].text = "Change Selection";
				PromptBar.Label[5].text = "Edit Setting";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
			if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
			{
				if (Selection == 1)
				{
					Profile.antialiasing.enabled = !Profile.antialiasing.enabled;
				}
				else if (Selection == 2)
				{
					Profile.ambientOcclusion.enabled = !Profile.ambientOcclusion.enabled;
				}
				else if (Selection == 3)
				{
					Profile.depthOfField.enabled = !Profile.depthOfField.enabled;
				}
				else if (Selection == 4)
				{
					Profile.motionBlur.enabled = !Profile.motionBlur.enabled;
				}
				else if (Selection == 5)
				{
					Profile.bloom.enabled = !Profile.bloom.enabled;
				}
				else if (Selection == 6)
				{
					Profile.chromaticAberration.enabled = !Profile.chromaticAberration.enabled;
				}
				else if (Selection == 7)
				{
					Profile.vignette.enabled = !Profile.vignette.enabled;
				}
				OptionGlobals.DisablePostAliasing = !Profile.antialiasing.enabled;
				OptionGlobals.DisableObscurance = !Profile.ambientOcclusion.enabled;
				OptionGlobals.DisableAbberation = !Profile.chromaticAberration.enabled;
				OptionGlobals.DisableVignette = !Profile.vignette.enabled;
				UpdateLabels();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				Profile.antialiasing.enabled = false;
				Profile.ambientOcclusion.enabled = false;
				Profile.depthOfField.enabled = false;
				Profile.motionBlur.enabled = false;
				Profile.bloom.enabled = false;
				Profile.chromaticAberration.enabled = false;
				Profile.vignette.enabled = false;
				OptionGlobals.DisablePostAliasing = !Profile.antialiasing.enabled;
				OptionGlobals.DisableObscurance = !Profile.ambientOcclusion.enabled;
				OptionGlobals.DisableAbberation = !Profile.chromaticAberration.enabled;
				OptionGlobals.DisableVignette = !Profile.vignette.enabled;
				UpdateLabels();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_Y))
			{
				Profile.antialiasing.enabled = true;
				Profile.ambientOcclusion.enabled = true;
				Profile.depthOfField.enabled = true;
				Profile.motionBlur.enabled = false;
				Profile.bloom.enabled = true;
				Profile.chromaticAberration.enabled = true;
				Profile.vignette.enabled = true;
				OptionGlobals.DisablePostAliasing = !Profile.antialiasing.enabled;
				OptionGlobals.DisableObscurance = !Profile.ambientOcclusion.enabled;
				OptionGlobals.DisableAbberation = !Profile.chromaticAberration.enabled;
				OptionGlobals.DisableVignette = !Profile.vignette.enabled;
				UpdateLabels();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				OptionGlobals.DepthOfField = Profile.depthOfField.enabled;
				OptionGlobals.MotionBlur = Profile.motionBlur.enabled;
				PromptBar.Show = false;
				Transition = true;
				Menu = 0;
			}
		}
		else if (Menu == 2)
		{
			if (!PromptBar.Show)
			{
				PromptBar.ClearButtons();
				PromptBar.Label[1].text = "Go Back";
				PromptBar.Label[2].text = "Set All to Lowest";
				PromptBar.Label[3].text = "Reset All to Default";
				PromptBar.Label[4].text = "Change Selection";
				PromptBar.Label[5].text = "Edit Setting";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
			if (Selection == 1)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.OpaqueWindows = !OptionGlobals.OpaqueWindows;
					QualityManager.UpdateOpaqueWindows();
					if (!SchoolScene)
					{
						UpdateGraphics();
					}
					UpdateLabels();
				}
			}
			else if (Selection == 2)
			{
				if (NewTitleScreen.InputManager.TappedRight)
				{
					OptionGlobals.DisableFarAnimations++;
					QualityManager.UpdateAnims();
					UpdateLabels();
				}
				else if (NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.DisableFarAnimations--;
					QualityManager.UpdateAnims();
					UpdateLabels();
				}
			}
			else if (Selection == 3)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.DisableMirrors = !OptionGlobals.DisableMirrors;
					QualityManager.UpdateMirrors();
					UpdateLabels();
				}
			}
			else if (Selection == 4)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.RimLight = !OptionGlobals.RimLight;
					if (OptionGlobals.RimLight)
					{
						OptionGlobals.DisableOutlines = false;
					}
					if (!SchoolScene)
					{
						UpdateGraphics();
					}
					else
					{
						QualityManager.UpdateOutlinesAndRimlight();
					}
					UpdateLabels();
				}
			}
			else if (Selection == 5)
			{
				if (NewTitleScreen.InputManager.TappedRight)
				{
					OptionGlobals.LowDetailStudents++;
					QualityManager.UpdateLowDetailStudents();
					UpdateLabels();
				}
				else if (NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.LowDetailStudents--;
					QualityManager.UpdateLowDetailStudents();
					UpdateLabels();
				}
			}
			else if (Selection == 6)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.DisableOutlines = !OptionGlobals.DisableOutlines;
					if (OptionGlobals.DisableOutlines)
					{
						OptionGlobals.RimLight = false;
					}
					QualityManager.UpdateOutlinesAndRimlight();
					if (!SchoolScene)
					{
						UpdateGraphics();
					}
					UpdateLabels();
				}
			}
			else if (Selection == 7)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					Screen.SetResolution(Screen.width, Screen.height, !Screen.fullScreen);
					UpdateLabels();
				}
			}
			else if (Selection == 8)
			{
				if (NewTitleScreen.InputManager.TappedRight)
				{
					OptionGlobals.DrawDistance += 10;
					QualityManager.UpdateDrawDistance();
					UpdateLabels();
				}
				else if (NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.DrawDistance -= 10;
					QualityManager.UpdateDrawDistance();
					UpdateLabels();
				}
				if (!SchoolScene)
				{
					UpdateGraphics();
				}
			}
			else if (Selection == 9)
			{
				if (NewTitleScreen.InputManager.TappedRight)
				{
					OptionGlobals.ParticleCount++;
					QualityManager.UpdateParticles();
					UpdateLabels();
				}
				else if (NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.ParticleCount--;
					QualityManager.UpdateParticles();
					UpdateLabels();
				}
				if (!SchoolScene)
				{
					UpdateGraphics();
				}
			}
			else if (Selection == 10)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.ColorGrading = !OptionGlobals.ColorGrading;
					QualityManager.UpdateColorGrading();
					if (!SchoolScene)
					{
						UpdateGraphics();
					}
					UpdateLabels();
				}
			}
			else if (Selection == 11)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.ToggleGrass = !OptionGlobals.ToggleGrass;
					QualityManager.UpdateGrass();
					if (!SchoolScene)
					{
						UpdateGraphics();
					}
					UpdateLabels();
				}
			}
			else if (Selection == 12)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.HairPhysics = !OptionGlobals.HairPhysics;
					HairPhysics = !OptionGlobals.HairPhysics;
					QualityManager.UpdateHair();
					if (!SchoolScene)
					{
						UpdateGraphics();
					}
					UpdateLabels();
				}
			}
			else if (Selection == 13)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.DisplayFPS = !OptionGlobals.DisplayFPS;
					QualityManager.DisplayFPS();
					if (!SchoolScene)
					{
						UpdateGraphics();
					}
					UpdateLabels();
				}
			}
			else if (Selection == 14)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.EnableShadows = !OptionGlobals.EnableShadows;
					QualityManager.UpdateShadows();
					if (!SchoolScene)
					{
						UpdateGraphics();
					}
					UpdateLabels();
				}
			}
			else if (Selection == 15)
			{
				if (NewTitleScreen.InputManager.TappedRight)
				{
					OptionGlobals.FPSIndex++;
					QualityManager.UpdateFPSIndex();
				}
				else if (NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.FPSIndex--;
					QualityManager.UpdateFPSIndex();
				}
				UpdateLabels();
			}
			else if (Selection == 16)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.Vsync = !OptionGlobals.Vsync;
					QualityManager.UpdateVsync();
					UpdateLabels();
				}
			}
			else if (Selection == 17 && (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft))
			{
				OptionGlobals.Fog = !OptionGlobals.Fog;
				QualityManager.UpdateFog();
				if (!SchoolScene)
				{
					UpdateGraphics();
				}
				UpdateLabels();
			}
			if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				OptionGlobals.OpaqueWindows = true;
				OptionGlobals.DisableFarAnimations = 1;
				OptionGlobals.DisableMirrors = true;
				OptionGlobals.RimLight = false;
				OptionGlobals.LowDetailStudents = 1;
				OptionGlobals.DisableOutlines = true;
				OptionGlobals.DrawDistance = 50;
				OptionGlobals.ParticleCount = 1;
				OptionGlobals.ColorGrading = false;
				OptionGlobals.EnableShadows = false;
				OptionGlobals.ToggleGrass = false;
				OptionGlobals.Fog = false;
				OptionGlobals.HairPhysics = true;
				HairPhysics = !OptionGlobals.HairPhysics;
				if (!SchoolScene)
				{
					UpdateGraphics();
				}
				else
				{
					QualityManagerUpdateGraphics();
					QualityManager.UpdateHair();
				}
				UpdateLabels();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_Y))
			{
				OptionGlobals.OpaqueWindows = true;
				OptionGlobals.DisableFarAnimations = 10;
				OptionGlobals.DisableMirrors = false;
				OptionGlobals.RimLight = true;
				OptionGlobals.LowDetailStudents = 0;
				OptionGlobals.DisableOutlines = false;
				OptionGlobals.DrawDistanceLimit = 350;
				OptionGlobals.DrawDistance = 350;
				OptionGlobals.ParticleCount = 3;
				OptionGlobals.ColorGrading = true;
				OptionGlobals.EnableShadows = false;
				OptionGlobals.ToggleGrass = false;
				OptionGlobals.Fog = false;
				OptionGlobals.HairPhysics = false;
				HairPhysics = !OptionGlobals.HairPhysics;
				if (!SchoolScene)
				{
					UpdateGraphics();
				}
				else
				{
					QualityManagerUpdateGraphics();
					QualityManager.UpdateHair();
				}
				UpdateLabels();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				PromptBar.Show = false;
				Transition = true;
				Menu = 0;
			}
		}
		else if (Menu == 3)
		{
			if (Selection == 1)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.ToggleRun = !OptionGlobals.ToggleRun;
					QualityManager.ToggleRun();
					UpdateLabels();
				}
			}
			else if (Selection == 2)
			{
				if (NewTitleScreen.InputManager.TappedRight)
				{
					if (OptionGlobals.Sensitivity < 10)
					{
						OptionGlobals.Sensitivity++;
						UpdateLabels();
					}
				}
				else if (NewTitleScreen.InputManager.TappedLeft && OptionGlobals.Sensitivity > 1)
				{
					OptionGlobals.Sensitivity--;
					UpdateLabels();
				}
				if (PauseScreen != null && PauseScreen.RPGCamera != null)
				{
					PauseScreen.RPGCamera.sensitivity = OptionGlobals.Sensitivity;
				}
			}
			else if (Selection == 3)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.TutorialsOff = !OptionGlobals.TutorialsOff;
					if (SchoolScene)
					{
						StudentManager.TutorialWindow.enabled = !OptionGlobals.TutorialsOff;
					}
					UpdateLabels();
				}
			}
			else if (Selection == 4)
			{
				if (NewTitleScreen.InputManager.TappedRight)
				{
					if (OptionGlobals.CameraPosition < 2)
					{
						OptionGlobals.CameraPosition++;
					}
					else
					{
						OptionGlobals.CameraPosition = 0;
					}
				}
				else if (NewTitleScreen.InputManager.TappedLeft)
				{
					if (OptionGlobals.CameraPosition > 0)
					{
						OptionGlobals.CameraPosition--;
					}
					else
					{
						OptionGlobals.CameraPosition = 2;
					}
				}
				if (SchoolScene)
				{
					if (OptionGlobals.CameraPosition == 0)
					{
						StudentManager.Yandere.Zoom.OverShoulder = false;
					}
					else if (OptionGlobals.CameraPosition == 1)
					{
						StudentManager.Yandere.Zoom.OverShoulder = true;
						StudentManager.Yandere.Zoom.midOffset = 0.25f;
					}
					else
					{
						StudentManager.Yandere.Zoom.OverShoulder = true;
						StudentManager.Yandere.Zoom.midOffset = -0.25f;
					}
				}
				UpdateLabels();
			}
			else if (Selection == 5)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.InvertAxisX = !OptionGlobals.InvertAxisX;
					if (PauseScreen != null && PauseScreen.RPGCamera != null)
					{
						PauseScreen.RPGCamera.invertAxisX = OptionGlobals.InvertAxisX;
					}
					UpdateLabels();
				}
			}
			else if (Selection == 6)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.InvertAxisY = !OptionGlobals.InvertAxisY;
					if (PauseScreen != null && PauseScreen.RPGCamera != null)
					{
						PauseScreen.RPGCamera.invertAxisY = OptionGlobals.InvertAxisY;
					}
					UpdateLabels();
				}
			}
			else if (Selection == 7)
			{
				if (NewTitleScreen.InputManager.TappedRight)
				{
					OptionGlobals.SubtitleSize++;
					if (OptionGlobals.SubtitleSize > 3)
					{
						OptionGlobals.SubtitleSize = 1;
					}
					if (PauseScreen != null)
					{
						PauseScreen.UpdateSubtitleSize();
					}
					UpdateLabels();
				}
				else if (NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.SubtitleSize--;
					if (OptionGlobals.SubtitleSize < 1)
					{
						OptionGlobals.SubtitleSize = 3;
					}
					if (PauseScreen != null)
					{
						PauseScreen.UpdateSubtitleSize();
					}
					UpdateLabels();
				}
			}
			else if (Selection == 8 && (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft))
			{
				OptionGlobals.RivalDeathSlowMo = !OptionGlobals.RivalDeathSlowMo;
				if (StudentManager != null)
				{
					StudentManager.DisableRivalDeathSloMo = OptionGlobals.RivalDeathSlowMo;
				}
				UpdateLabels();
			}
			if (!PromptBar.Show)
			{
				PromptBar.ClearButtons();
				PromptBar.Label[1].text = "Go Back";
				PromptBar.Label[4].text = "Change Selection";
				PromptBar.Label[5].text = "Edit Setting";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				PromptBar.Show = false;
				Transition = true;
				Menu = 0;
			}
		}
		else if (Menu == 4)
		{
			if (Selection == 1)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					GameGlobals.CensorKillingAnims = !GameGlobals.CensorKillingAnims;
					if (SchoolScene)
					{
						StudentManager.Yandere.AttackManager.Censor = GameGlobals.CensorKillingAnims;
					}
					UpdateLabels();
				}
			}
			else if (Selection == 2)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					GameGlobals.CensorPanties = !GameGlobals.CensorPanties;
					if (SchoolScene)
					{
						StudentManager.CensorStudents();
						StudentManager.Yandere.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().Censor();
					}
					UpdateLabels();
				}
			}
			else if (Selection == 3 && (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft))
			{
				GameGlobals.CensorBlood = !GameGlobals.CensorBlood;
				if (SchoolScene)
				{
					StudentManager.Yandere.WeaponManager.ChangeBloodTexture();
					StudentManager.BloodParent.ChangeBloodTexture();
					StudentManager.Yandere.Bloodiness += 0f;
				}
				else if (GameGlobals.CensorBlood)
				{
					TitleScreenProjector.material = FlowerMaterial;
				}
				else
				{
					TitleScreenProjector.material = BloodMaterial;
				}
				UpdateLabels();
			}
			if (!PromptBar.Show)
			{
				PromptBar.ClearButtons();
				PromptBar.Label[1].text = "Go Back";
				PromptBar.Label[4].text = "Change Selection";
				PromptBar.Label[5].text = "Edit Setting";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				PromptBar.Show = false;
				Transition = true;
				Menu = 0;
			}
		}
		else if (Menu == 5)
		{
			if (!PromptBar.Show)
			{
				PromptBar.ClearButtons();
				PromptBar.Label[1].text = "Go Back";
				PromptBar.Label[2].text = "Set All to Lowest";
				PromptBar.Label[3].text = "Reset All to Default";
				PromptBar.Label[4].text = "Change Selection";
				PromptBar.Label[5].text = "Edit Setting";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
			if (Selection == 1)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.DisableStatic = !OptionGlobals.DisableStatic;
					QualityManager.UpdateEightiesEffects();
					UpdateLabels();
				}
			}
			else if (Selection == 2)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.DisableDisplacement = !OptionGlobals.DisableDisplacement;
					QualityManager.UpdateEightiesEffects();
					UpdateLabels();
				}
			}
			else if (Selection == 3)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.DisableAbberation = !OptionGlobals.DisableAbberation;
					QualityManager.UpdateEightiesEffects();
					UpdateLabels();
				}
			}
			else if (Selection == 4)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.DisableVignette = !OptionGlobals.DisableVignette;
					QualityManager.UpdateEightiesEffects();
					UpdateLabels();
				}
			}
			else if (Selection == 5)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.DisableDistortion = !OptionGlobals.DisableDistortion;
					QualityManager.UpdateEightiesEffects();
					UpdateLabels();
				}
			}
			else if (Selection == 6)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.DisableScanlines = !OptionGlobals.DisableScanlines;
					QualityManager.UpdateEightiesEffects();
					UpdateLabels();
				}
			}
			else if (Selection == 7)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					OptionGlobals.DisableNoise = !OptionGlobals.DisableNoise;
					QualityManager.UpdateEightiesEffects();
					UpdateLabels();
				}
			}
			else if (Selection == 8 && (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft))
			{
				OptionGlobals.DisableTint = !OptionGlobals.DisableTint;
				QualityManager.UpdateEightiesEffects();
				UpdateLabels();
			}
			if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				OptionGlobals.DisableStatic = true;
				OptionGlobals.DisableDisplacement = true;
				OptionGlobals.DisableAbberation = true;
				OptionGlobals.DisableVignette = true;
				OptionGlobals.DisableDistortion = true;
				OptionGlobals.DisableScanlines = true;
				OptionGlobals.DisableNoise = true;
				OptionGlobals.DisableTint = true;
				QualityManager.UpdateEightiesEffects();
				UpdateLabels();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_Y))
			{
				OptionGlobals.DisableStatic = false;
				OptionGlobals.DisableDisplacement = false;
				OptionGlobals.DisableAbberation = false;
				OptionGlobals.DisableVignette = false;
				OptionGlobals.DisableDistortion = false;
				OptionGlobals.DisableScanlines = false;
				OptionGlobals.DisableNoise = false;
				OptionGlobals.DisableTint = false;
				QualityManager.UpdateEightiesEffects();
				UpdateLabels();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				PromptBar.ClearButtons();
				PromptBar.UpdateButtons();
				PromptBar.Show = false;
				Transition = true;
				Menu = 0;
			}
		}
		else
		{
			if (Menu != 6)
			{
				return;
			}
			if (!PromptBar.Show)
			{
				PromptBar.ClearButtons();
				PromptBar.Label[1].text = "Go Back";
				PromptBar.Label[4].text = "Change Selection";
				PromptBar.Label[5].text = "Edit Setting";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
			if (Selection == 1)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					if (NewTitleScreen.InputManager.TappedRight)
					{
						OptionGlobals.ResolutionID++;
						if (OptionGlobals.ResolutionID == Widths.Length)
						{
							OptionGlobals.ResolutionID = 0;
						}
					}
					else
					{
						OptionGlobals.ResolutionID--;
						if (OptionGlobals.ResolutionID < 0)
						{
							OptionGlobals.ResolutionID = Widths.Length - 1;
						}
					}
					Screen.SetResolution(Widths[OptionGlobals.ResolutionID], Heights[OptionGlobals.ResolutionID], Screen.fullScreen);
					UpdateOnNextFrame = true;
				}
			}
			else if (Selection == 2)
			{
				if (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft)
				{
					Screen.fullScreen = !Screen.fullScreen;
					UpdateOnNextFrame = true;
				}
			}
			else if (Selection == 3 && (NewTitleScreen.InputManager.TappedRight || NewTitleScreen.InputManager.TappedLeft))
			{
				OptionGlobals.MinimalistHUD = !OptionGlobals.MinimalistHUD;
				if (MinimalistManager != null)
				{
					MinimalistManager.Start();
				}
				UpdateOnNextFrame = true;
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				PromptBar.ClearButtons();
				PromptBar.UpdateButtons();
				PromptBar.Show = false;
				Transition = true;
				Menu = 0;
			}
		}
	}

	private void UpdateCursor()
	{
		if (Selection > Limit[Menu])
		{
			Selection = 1;
		}
		else if (Selection < 1)
		{
			Selection = Limit[Menu];
		}
	}

	private void UpdatePanels()
	{
		for (int i = 0; i < Panel.Length; i++)
		{
			if (i == Menu)
			{
				Panel[i].alpha = Mathf.MoveTowards(Panel[i].alpha, 1f, Time.unscaledDeltaTime * (float)Speed);
			}
			else
			{
				Panel[i].alpha = Mathf.MoveTowards(Panel[i].alpha, 0f, Time.unscaledDeltaTime * (float)Speed);
			}
		}
	}

	public void UpdateLabels()
	{
		Labels[1].text = (Profile.antialiasing.enabled ? "On" : "Off");
		Labels[2].text = (Profile.ambientOcclusion.enabled ? "On" : "Off");
		Labels[3].text = (Profile.depthOfField.enabled ? "On" : "Off");
		Labels[4].text = (Profile.motionBlur.enabled ? "On" : "Off");
		Labels[5].text = (Profile.bloom.enabled ? "On" : "Off");
		Labels[6].text = (Profile.chromaticAberration.enabled ? "On" : "Off");
		Labels[7].text = (Profile.vignette.enabled ? "On" : "Off");
		Labels[8].text = (OptionGlobals.OpaqueWindows ? "No" : "Yes");
		Labels[9].text = ((OptionGlobals.DisableFarAnimations == 0) ? "Off" : (OptionGlobals.DisableFarAnimations * 5 + "m"));
		Labels[10].text = (OptionGlobals.DisableMirrors ? "Yes" : "No");
		Labels[11].text = (OptionGlobals.RimLight ? "On" : "Off");
		Labels[12].text = ((OptionGlobals.LowDetailStudents == 0) ? "Off" : (OptionGlobals.LowDetailStudents * 10 + "m"));
		Labels[13].text = (OptionGlobals.DisableOutlines ? "Off" : "On");
		Labels[14].text = (Screen.fullScreen ? "No" : "Yes");
		Labels[15].text = OptionGlobals.DrawDistance + "m";
		if (OptionGlobals.ParticleCount == 3)
		{
			Labels[16].text = "High";
		}
		else if (OptionGlobals.ParticleCount == 2)
		{
			Labels[16].text = "Low";
		}
		else if (OptionGlobals.ParticleCount == 1)
		{
			Labels[16].text = "None";
		}
		Labels[17].text = (OptionGlobals.ColorGrading ? "Yes" : "No");
		Labels[18].text = (OptionGlobals.ToggleGrass ? "On" : "Off");
		Labels[19].text = (OptionGlobals.HairPhysics ? "Disabled" : "Enabled");
		Labels[20].text = (OptionGlobals.DisplayFPS ? "Yes" : "No");
		Labels[21].text = (OptionGlobals.EnableShadows ? "Yes" : "No");
		Labels[22].text = QualityManagerScript.FPSStrings[OptionGlobals.FPSIndex];
		Labels[23].text = (OptionGlobals.Vsync ? "On" : "Off");
		Labels[24].text = (OptionGlobals.Fog ? "On" : "Off");
		Labels[25].text = (OptionGlobals.ToggleRun ? "Toggle" : "Hold");
		Labels[26].text = OptionGlobals.Sensitivity.ToString() ?? "";
		Labels[27].text = (OptionGlobals.TutorialsOff ? "Yes" : "No");
		if (OptionGlobals.CameraPosition == 0)
		{
			Labels[28].text = "Behind";
		}
		else if (OptionGlobals.CameraPosition == 1)
		{
			Labels[28].text = "Right";
		}
		else if (OptionGlobals.CameraPosition == 2)
		{
			Labels[28].text = "Left";
		}
		Labels[29].text = (OptionGlobals.InvertAxisX ? "Yes" : "No");
		Labels[30].text = (OptionGlobals.InvertAxisY ? "Yes" : "No");
		if (OptionGlobals.SubtitleSize == 1)
		{
			Labels[31].text = "None";
		}
		else if (OptionGlobals.SubtitleSize == 2)
		{
			Labels[31].text = "Medium";
		}
		else if (OptionGlobals.SubtitleSize == 3)
		{
			Labels[31].text = "Large";
		}
		Labels[32].text = (OptionGlobals.RivalDeathSlowMo ? "Disabled" : "Enabled");
		Labels[33].text = (GameGlobals.CensorKillingAnims ? "Yes" : "No");
		Labels[34].text = (GameGlobals.CensorPanties ? "Yes" : "No");
		Labels[35].text = (GameGlobals.CensorBlood ? "Yes" : "No");
		Labels[36].text = (OptionGlobals.DisableStatic ? "Yes" : "No");
		Labels[37].text = (OptionGlobals.DisableDisplacement ? "Yes" : "No");
		Labels[38].text = (OptionGlobals.DisableAbberation ? "Yes" : "No");
		Labels[39].text = (OptionGlobals.DisableVignette ? "Yes" : "No");
		Labels[40].text = (OptionGlobals.DisableDistortion ? "Yes" : "No");
		Labels[41].text = (OptionGlobals.DisableScanlines ? "Yes" : "No");
		Labels[42].text = (OptionGlobals.DisableNoise ? "Yes" : "No");
		Labels[43].text = (OptionGlobals.DisableTint ? "Yes" : "No");
		Labels[44].text = Screen.width + " x " + Screen.height;
		Labels[45].text = ((!Screen.fullScreen) ? "Yes" : "No");
		Labels[46].text = (OptionGlobals.MinimalistHUD ? "Yes" : "No");
		if (GameGlobals.Eighties)
		{
			UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				EightiesifyLabel(componentsInChildren[i]);
			}
		}
		OptionGlobals.DisableBloom = !Profile.bloom.enabled;
		if (StudentManager != null && StudentManager.Yandere != null && StudentManager.Yandere.Zoom != null && StudentManager.Yandere.CameraEffects != null)
		{
			StudentManager.Yandere.Zoom.UpdateDOF();
		}
	}

	public void SetWindowsOpaque()
	{
		if (!OptionGlobals.OpaqueWindows)
		{
			Window.sharedMaterial.color = new Color(1f, 1f, 1f, 0.5f);
			Window.sharedMaterial.shader = Shader.Find("Transparent/Diffuse");
		}
		else
		{
			Window.sharedMaterial.color = new Color(1f, 1f, 1f, 1f);
			Window.sharedMaterial.shader = Shader.Find("Diffuse");
		}
	}

	public void UpdateShaders()
	{
		if (OptionGlobals.RimLight)
		{
			if (OptionGlobals.DisableOutlines)
			{
				YandereRenderer.materials[0].shader = ToonRimLight;
				YandereRenderer.materials[1].shader = ToonRimLight;
				YandereRenderer.materials[2].shader = ToonRimLight;
				YandereHairRenderer.material.shader = ToonRimLight;
				AdjustRimLight(YandereRenderer.materials[0]);
				AdjustRimLight(YandereRenderer.materials[1]);
				AdjustRimLight(YandereRenderer.materials[2]);
				AdjustRimLight(YandereHairRenderer.material);
			}
			else
			{
				YandereRenderer.materials[0].shader = ToonOutlineRimLight;
				YandereRenderer.materials[1].shader = ToonOutlineRimLight;
				YandereRenderer.materials[2].shader = ToonOutlineRimLight;
				YandereHairRenderer.material.shader = ToonOutlineRimLight;
				AdjustRimLight(YandereRenderer.materials[0]);
				AdjustRimLight(YandereRenderer.materials[1]);
				AdjustRimLight(YandereRenderer.materials[2]);
				AdjustRimLight(YandereHairRenderer.material);
			}
		}
		else if (OptionGlobals.DisableOutlines)
		{
			YandereRenderer.materials[0].shader = Toon;
			YandereRenderer.materials[1].shader = Toon;
			YandereRenderer.materials[2].shader = Toon;
			YandereHairRenderer.material.shader = Toon;
		}
		else
		{
			YandereRenderer.materials[0].shader = ToonOutline;
			YandereRenderer.materials[1].shader = ToonOutline;
			YandereRenderer.materials[2].shader = ToonOutline;
			YandereHairRenderer.material.shader = ToonOutline;
		}
	}

	public void AdjustRimLight(Material mat)
	{
		mat.SetFloat("_RimLightIntencity", 5f);
		mat.SetFloat("_RimCrisp", 0.5f);
		mat.SetFloat("_RimAdditive", 0.5f);
	}

	public void UpdateGraphics()
	{
		SetWindowsOpaque();
		UpdateShaders();
		MainCamera.farClipPlane = OptionGlobals.DrawDistance;
		RenderSettings.fogEndDistance = OptionGlobals.DrawDistance;
		ParticleSystem.EmissionModule emission = PlazaBlossoms.emission;
		emission.enabled = true;
		if (OptionGlobals.ParticleCount == 3)
		{
			emission.rateOverTime = 500f;
		}
		else if (OptionGlobals.ParticleCount == 2)
		{
			emission.rateOverTime = 100f;
		}
		else if (OptionGlobals.ParticleCount == 1)
		{
			emission.enabled = false;
		}
		ColorGrading.enabled = OptionGlobals.ColorGrading;
		Grass.SetActive(OptionGlobals.ToggleGrass);
		Sun.shadows = (OptionGlobals.EnableShadows ? LightShadows.Soft : LightShadows.None);
		if (OptionGlobals.EnableShadows)
		{
			Sun.intensity = LightIntensity;
		}
		else
		{
			Sun.intensity = 0.25f;
		}
		if (!OptionGlobals.Fog)
		{
			MainCamera.clearFlags = CameraClearFlags.Skybox;
			RenderSettings.fog = false;
		}
		else
		{
			MainCamera.clearFlags = CameraClearFlags.Color;
			RenderSettings.fog = true;
			RenderSettings.fogMode = FogMode.Linear;
			RenderSettings.fogColor = MainCamera.backgroundColor;
			RenderSettings.fogEndDistance = OptionGlobals.DrawDistance;
		}
		QualityManager.UpdateEightiesEffects();
	}

	public void QualityManagerUpdateGraphics()
	{
		QualityManager.UpdateOpaqueWindows();
		QualityManager.UpdateAnims();
		QualityManager.UpdateMirrors();
		QualityManager.UpdateLowDetailStudents();
		QualityManager.UpdateOutlinesAndRimlight();
		QualityManager.UpdateDrawDistance();
		QualityManager.UpdateParticles();
		QualityManager.UpdateColorGrading();
		QualityManager.UpdateShadows();
		QualityManager.UpdateGrass();
		QualityManager.UpdateFog();
		QualityManager.UpdateEightiesEffects();
	}

	public void EightiesifyLabel(UILabel Label)
	{
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
		Label.effectDistance = new Vector2(5f, 5f);
	}
}
