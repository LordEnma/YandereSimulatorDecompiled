using RetroAesthetics;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class QualityManagerScript : MonoBehaviour
{
	public CameraFilterPack_Colors_Adjust_PreFilters ColorGrading;

	public CameraFilterPack_Colors_Adjust_PreFilters Tint;

	public AntialiasingAsPostEffect PostAliasing;

	public StudentManagerScript StudentManager;

	public PostProcessingBehaviour Obscurance;

	public SettingsScript Settings;

	public NemesisScript Nemesis;

	public YandereScript Yandere;

	public Bloom BloomEffect;

	public GameObject Clouds;

	public GameObject Grass;

	public Light Sun;

	public ParticleSystem EastRomanceBlossoms;

	public ParticleSystem WestRomanceBlossoms;

	public ParticleSystem[] EastGardenBlossoms;

	public ParticleSystem[] WestGardenBlossoms;

	public ParticleSystem CorridorBlossoms;

	public ParticleSystem PlazaBlossoms;

	public ParticleSystem MythBlossoms;

	public ParticleSystem[] Fountains;

	public ParticleSystem[] Steam;

	public Renderer YandereHairRenderer;

	public Shader NewBodyShader;

	public Shader NewHairShader;

	public Shader Toon;

	public Shader ToonOverlay;

	public Shader ToonOutline;

	public Shader ToonOutlineOverlay;

	public Shader ToonRimLight;

	public Shader ToonRimLightOverlay;

	public Shader ToonOutlineRimLight;

	public Shader ToonOutlineRimLightOverlay;

	public BloomAndLensFlares ExperimentalBloomAndLensFlares;

	public DepthOfField34 ExperimentalDepthOfField34;

	public SSAOEffect ExperimentalSSAOEffect;

	public bool DoNothing;

	public bool SchoolScene;

	private static readonly int[] FPSValues = new int[4] { 2147483647, 30, 60, 120 };

	public static readonly string[] FPSStrings = new string[4] { "Unlimited", "30", "60", "120" };

	public RetroCameraEffect EightiesEffects;

	public bool DisableOutlinesLater;

	public bool DisableRimLightLater;

	public Material GlassesMaterial;

	public bool Eighties;

	public bool LoveSick;

	public bool OriginalFog;

	public void Start()
	{
		Eighties = GameGlobals.Eighties;
		if (OptionGlobals.DisableOutlines)
		{
			DisableOutlinesLater = true;
		}
		if (!OptionGlobals.RimLight)
		{
			DisableRimLightLater = true;
		}
		OptionGlobals.DisableOutlines = false;
		OptionGlobals.RimLight = true;
		if (OptionGlobals.DrawDistance == 0)
		{
			OptionGlobals.DrawDistanceLimit = 350;
			OptionGlobals.DrawDistance = 350;
		}
		if (SceneManager.GetActiveScene().name != "SchoolScene")
		{
			DoNothing = true;
		}
		else
		{
			SchoolScene = true;
		}
		if (!DoNothing)
		{
			if (OptionGlobals.ParticleCount == 0)
			{
				OptionGlobals.ParticleCount = 3;
			}
			if (OptionGlobals.DisableFarAnimations == 0)
			{
				OptionGlobals.DisableFarAnimations = 10;
			}
			if (OptionGlobals.Sensitivity == 0)
			{
				OptionGlobals.Sensitivity = 3;
			}
			if (ColorGrading == null)
			{
				CameraFilterPack_Colors_Adjust_PreFilters[] components = StudentManager.MainCamera.GetComponents<CameraFilterPack_Colors_Adjust_PreFilters>();
				ColorGrading = components[2];
			}
			Yandere.PauseScreen.NewSettings.Profile.depthOfField.enabled = OptionGlobals.DepthOfField;
			Yandere.PauseScreen.NewSettings.Profile.motionBlur.enabled = OptionGlobals.MotionBlur;
			StudentManager.TransparentWindows = false;
			StudentManager.SetWindowsOpaque();
			StudentManager.LateUpdate();
			ToggleRun();
			UpdateFog();
			DisplayFPS();
			UpdateHair();
			UpdateAnims();
			UpdateVsync();
			UpdateGrass();
			UpdateMirrors();
			UpdateShadows();
			UpdateFPSIndex();
			UpdateDrawDistance();
			UpdateSubtitleSize();
			UpdateOpaqueWindows();
			UpdateCameraPosition();
			UpdateLowDetailStudents();
			UpdateEightiesEffects();
			if (EastRomanceBlossoms != null)
			{
				UpdateParticles();
			}
			if (ColorGrading != null)
			{
				UpdateColorGrading();
			}
		}
		LoveSick = GameGlobals.LoveSick;
	}

	public void UpdateParticles()
	{
		if (OptionGlobals.ParticleCount > 3)
		{
			OptionGlobals.ParticleCount = 1;
		}
		else if (OptionGlobals.ParticleCount < 1)
		{
			OptionGlobals.ParticleCount = 3;
		}
		if (!DoNothing)
		{
			ParticleSystem.EmissionModule emission = EastRomanceBlossoms.emission;
			ParticleSystem.EmissionModule emission2 = WestRomanceBlossoms.emission;
			ParticleSystem.EmissionModule emission3 = EastGardenBlossoms[1].emission;
			ParticleSystem.EmissionModule emission4 = EastGardenBlossoms[2].emission;
			ParticleSystem.EmissionModule emission5 = EastGardenBlossoms[3].emission;
			ParticleSystem.EmissionModule emission6 = EastGardenBlossoms[4].emission;
			ParticleSystem.EmissionModule emission7 = WestGardenBlossoms[1].emission;
			ParticleSystem.EmissionModule emission8 = WestGardenBlossoms[2].emission;
			ParticleSystem.EmissionModule emission9 = WestGardenBlossoms[3].emission;
			ParticleSystem.EmissionModule emission10 = WestGardenBlossoms[4].emission;
			ParticleSystem.EmissionModule emission11 = CorridorBlossoms.emission;
			ParticleSystem.EmissionModule emission12 = PlazaBlossoms.emission;
			ParticleSystem.EmissionModule emission13 = MythBlossoms.emission;
			ParticleSystem.EmissionModule emission14 = Steam[1].emission;
			ParticleSystem.EmissionModule emission15 = Fountains[1].emission;
			ParticleSystem.EmissionModule emission16 = Fountains[2].emission;
			ParticleSystem.EmissionModule emission17 = Fountains[3].emission;
			emission.enabled = true;
			emission2.enabled = true;
			emission3.enabled = true;
			emission4.enabled = true;
			emission5.enabled = true;
			emission6.enabled = true;
			emission7.enabled = true;
			emission8.enabled = true;
			emission9.enabled = true;
			emission10.enabled = true;
			emission11.enabled = true;
			emission12.enabled = true;
			emission13.enabled = true;
			emission14.enabled = true;
			emission15.enabled = true;
			emission16.enabled = true;
			emission17.enabled = true;
			if (OptionGlobals.ParticleCount == 3)
			{
				emission.rateOverTime = 100f;
				emission2.rateOverTime = 100f;
				emission3.rateOverTime = 100f;
				emission4.rateOverTime = 100f;
				emission5.rateOverTime = 100f;
				emission6.rateOverTime = 100f;
				emission7.rateOverTime = 100f;
				emission8.rateOverTime = 100f;
				emission9.rateOverTime = 100f;
				emission10.rateOverTime = 100f;
				emission11.rateOverTime = 1000f;
				emission12.rateOverTime = 400f;
				emission13.rateOverTime = 100f;
				emission14.rateOverTime = 100f;
				emission15.rateOverTime = 100f;
				emission16.rateOverTime = 100f;
				emission17.rateOverTime = 100f;
			}
			else if (OptionGlobals.ParticleCount == 2)
			{
				emission.rateOverTime = 10f;
				emission2.rateOverTime = 10f;
				emission3.rateOverTime = 10f;
				emission4.rateOverTime = 10f;
				emission5.rateOverTime = 10f;
				emission6.rateOverTime = 10f;
				emission7.rateOverTime = 10f;
				emission8.rateOverTime = 10f;
				emission9.rateOverTime = 10f;
				emission10.rateOverTime = 10f;
				emission11.rateOverTime = 100f;
				emission12.rateOverTime = 40f;
				emission13.rateOverTime = 10f;
				emission14.rateOverTime = 10f;
				emission15.rateOverTime = 10f;
				emission16.rateOverTime = 10f;
				emission17.rateOverTime = 10f;
			}
			else if (OptionGlobals.ParticleCount == 1)
			{
				emission.enabled = false;
				emission2.enabled = false;
				emission3.enabled = false;
				emission4.enabled = false;
				emission5.enabled = false;
				emission6.enabled = false;
				emission7.enabled = false;
				emission8.enabled = false;
				emission9.enabled = false;
				emission10.enabled = false;
				emission11.enabled = false;
				emission12.enabled = false;
				emission13.enabled = false;
				emission14.enabled = false;
				emission15.enabled = false;
				emission16.enabled = false;
				emission17.enabled = false;
			}
		}
	}

	public void UpdateStockings()
	{
		if (DoNothing)
		{
			return;
		}
		for (int i = 1; i < StudentManager.Students.Length; i++)
		{
			StudentScript studentScript = StudentManager.Students[i];
			if (studentScript != null && !studentScript.Male)
			{
				if (studentScript.Cosmetic.MyStockings != null)
				{
					studentScript.MyRenderer.materials[0].SetTexture("_OverlayTex", studentScript.Cosmetic.MyStockings);
					studentScript.MyRenderer.materials[1].SetTexture("_OverlayTex", studentScript.Cosmetic.MyStockings);
					studentScript.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
					studentScript.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
				}
				else
				{
					studentScript.MyRenderer.materials[0].SetTexture("_OverlayTex", null);
					studentScript.MyRenderer.materials[1].SetTexture("_OverlayTex", null);
					studentScript.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
					studentScript.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
				}
				if (studentScript.LabcoatAttacher.enabled || studentScript.ClubAttire)
				{
					studentScript.HideLabCoatPanties();
				}
			}
		}
	}

	public void UpdateOutlines()
	{
		if (!DoNothing)
		{
			for (int i = 1; i < StudentManager.Students.Length; i++)
			{
				StudentScript studentScript = StudentManager.Students[i];
				if (!(studentScript != null))
				{
					continue;
				}
				if (OptionGlobals.DisableOutlines)
				{
					NewHairShader = Toon;
					NewBodyShader = ToonOverlay;
				}
				else
				{
					NewHairShader = ToonOutline;
					NewBodyShader = ToonOutlineOverlay;
				}
				if (!studentScript.Male)
				{
					studentScript.MyRenderer.materials[0].shader = NewBodyShader;
					studentScript.MyRenderer.materials[1].shader = NewBodyShader;
					if (studentScript.MyRenderer.materials.Length > 2)
					{
						studentScript.MyRenderer.materials[2].shader = NewBodyShader;
						if (studentScript.MyRenderer.materials.Length > 3)
						{
							studentScript.MyRenderer.materials[3].shader = NewBodyShader;
						}
					}
					studentScript.Cosmetic.RightStockings[0].GetComponent<Renderer>().material.shader = NewBodyShader;
					studentScript.Cosmetic.LeftStockings[0].GetComponent<Renderer>().material.shader = NewBodyShader;
					if (studentScript.Club == ClubType.Bully)
					{
						studentScript.Cosmetic.Bookbag.GetComponent<Renderer>().material.shader = NewHairShader;
						studentScript.Cosmetic.LeftWristband.GetComponent<Renderer>().material.shader = NewHairShader;
						studentScript.Cosmetic.RightWristband.GetComponent<Renderer>().material.shader = NewHairShader;
						studentScript.Cosmetic.HoodieRenderer.material.shader = NewHairShader;
					}
					if (studentScript.StudentID == 87)
					{
						studentScript.Cosmetic.ScarfRenderer.material.shader = NewHairShader;
					}
					else if (studentScript.StudentID == 90)
					{
						if (studentScript.Cosmetic.TeacherAccessories[studentScript.Cosmetic.Accessory] != null)
						{
							studentScript.Cosmetic.TeacherAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = NewHairShader;
						}
						if (studentScript.MyRenderer.materials.Length == 4)
						{
							studentScript.MyRenderer.materials[3].shader = NewBodyShader;
						}
					}
					if (studentScript.Cosmetic.HairbandRenderer != null)
					{
						studentScript.Cosmetic.HairbandRenderer.material.shader = NewHairShader;
					}
				}
				else
				{
					studentScript.MyRenderer.materials[0].shader = NewHairShader;
					studentScript.MyRenderer.materials[1].shader = NewHairShader;
					studentScript.MyRenderer.materials[2].shader = NewBodyShader;
				}
				studentScript.Armband.GetComponent<Renderer>().material.shader = NewHairShader;
				if (!studentScript.Male)
				{
					if (!studentScript.Teacher)
					{
						if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle] != null)
						{
							if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
							{
								studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = NewHairShader;
							}
							else
							{
								studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = NewHairShader;
								studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = NewHairShader;
							}
						}
						if (studentScript.Cosmetic.Accessory > 0 && studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>() != null)
						{
							studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = NewHairShader;
						}
						studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = NewHairShader;
						if (LoveSick)
						{
							studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.SetFloat("_Saturation", 0f);
						}
					}
					else
					{
						if (studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle] != null)
						{
							studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = NewHairShader;
						}
						if (studentScript.Cosmetic.Accessory <= 0)
						{
						}
					}
				}
				else
				{
					if (studentScript.Cosmetic.Hairstyle > 0)
					{
						if (studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
						{
							studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = NewHairShader;
							if (studentScript.Cosmetic.UsingDefaultHairColor && !LoveSick)
							{
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.SetFloat("_Saturation", 1f);
							}
							else
							{
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.SetFloat("_Saturation", 0f);
							}
						}
						else
						{
							studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = NewHairShader;
							studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = NewHairShader;
							if (studentScript.Cosmetic.UsingDefaultHairColor && !LoveSick)
							{
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].SetFloat("_Saturation", 1f);
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].SetFloat("_Saturation", 1f);
							}
							else
							{
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].SetFloat("_Saturation", 0f);
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].SetFloat("_Saturation", 0f);
							}
						}
					}
					if (studentScript.Cosmetic.Accessory > 0)
					{
						Renderer component = studentScript.Cosmetic.MaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>();
						if (component != null)
						{
							component.material.shader = NewHairShader;
						}
					}
				}
				if (!studentScript.Teacher && studentScript.Cosmetic.Club > ClubType.None && studentScript.Cosmetic.Club != ClubType.Council && studentScript.Cosmetic.Club != ClubType.Bully && studentScript.Cosmetic.Club != ClubType.Delinquent && studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club] != null)
				{
					Renderer component2 = studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club].GetComponent<Renderer>();
					if (component2 != null)
					{
						component2.material.shader = NewHairShader;
					}
				}
			}
			Yandere.MyRenderer.materials[0].shader = NewBodyShader;
			Yandere.MyRenderer.materials[1].shader = NewBodyShader;
			Yandere.MyRenderer.materials[2].shader = NewBodyShader;
			Yandere.EightiesPonytailRenderer.material.shader = NewHairShader;
			YandereHairRenderer.material.shader = NewHairShader;
			for (int j = 1; j < Yandere.Hairstyles.Length; j++)
			{
				Renderer component3 = Yandere.Hairstyles[j].GetComponent<Renderer>();
				if (component3 != null)
				{
					component3.material.shader = NewHairShader;
				}
				if (Yandere.Hairstyles[j].transform.childCount <= 0)
				{
					continue;
				}
				foreach (Transform item in Yandere.Hairstyles[j].transform)
				{
					Renderer component4 = item.GetComponent<Renderer>();
					if (component4 != null)
					{
						component4.material.shader = NewHairShader;
						continue;
					}
					SkinnedMeshRenderer component5 = item.GetComponent<SkinnedMeshRenderer>();
					if (component5 != null)
					{
						component5.material.shader = NewHairShader;
					}
				}
			}
			Nemesis.Cosmetic.MyRenderer.materials[0].shader = NewBodyShader;
			Nemesis.Cosmetic.MyRenderer.materials[1].shader = NewBodyShader;
			Nemesis.Cosmetic.MyRenderer.materials[2].shader = NewBodyShader;
			Nemesis.NemesisHair.GetComponent<Renderer>().material.shader = NewHairShader;
		}
		UpdateStockings();
	}

	public void UpdatePostAliasing()
	{
		if (!DoNothing)
		{
			PostAliasing.enabled = !OptionGlobals.DisablePostAliasing;
		}
	}

	public void UpdateBloom()
	{
		Debug.Log("Just ran UpdateBloom()");
		if (!DoNothing)
		{
			BloomEffect.enabled = !OptionGlobals.DisableBloom;
		}
	}

	public void UpdateOpaqueWindows()
	{
		if (!DoNothing)
		{
			if (OptionGlobals.OpaqueWindows)
			{
				StudentManager.TransparentWindows = false;
				StudentManager.SetWindowsOpaque();
			}
			else
			{
				StudentManager.WindowOccluder.open = true;
				StudentManager.TransparentWindows = true;
				StudentManager.SetWindowsTransparent();
			}
			StudentManager.LateUpdate();
		}
	}

	public void UpdateColorGrading()
	{
		if (!DoNothing)
		{
			ColorGrading.enabled = OptionGlobals.ColorGrading;
		}
	}

	public void UpdateGrass()
	{
		if (!DoNothing)
		{
			Grass.SetActive(OptionGlobals.ToggleGrass);
		}
	}

	public void UpdateMirrors()
	{
		if (!DoNothing)
		{
			CameraDistanceDisableScript[] mirrorsAndMonitors = StudentManager.MirrorsAndMonitors;
			for (int i = 0; i < mirrorsAndMonitors.Length; i++)
			{
				mirrorsAndMonitors[i].CheckIfShouldDisable();
			}
		}
	}

	public void UpdateHair()
	{
		if (!DoNothing)
		{
			StudentManager.UpdateDynamicBones(!OptionGlobals.HairPhysics);
		}
	}

	public void DisplayFPS()
	{
		if (!DoNothing)
		{
			StudentManager.UpdateFPSDisplay(OptionGlobals.DisplayFPS);
		}
	}

	public void UpdateLowDetailStudents()
	{
		if (OptionGlobals.LowDetailStudents > 10)
		{
			OptionGlobals.LowDetailStudents = 0;
		}
		else if (OptionGlobals.LowDetailStudents < 0)
		{
			OptionGlobals.LowDetailStudents = 10;
		}
		if (DoNothing)
		{
			return;
		}
		StudentManager.LowDetailThreshold = OptionGlobals.LowDetailStudents * 10;
		bool flag = false;
		flag = (float)StudentManager.LowDetailThreshold > 0f;
		if (StudentManager.Students[1] != null)
		{
			StudentManager.Students[1].LowPoly.MyMesh.enabled = false;
			StudentManager.Students[1].MyRenderer.enabled = true;
			StudentManager.Students[1].LowPoly.enabled = false;
		}
		for (int i = 2; i < 101; i++)
		{
			if (StudentManager.Students[i] != null && !StudentManager.Students[i].Ragdoll.Concealed)
			{
				StudentManager.Students[i].LowPoly.enabled = flag;
				if (!flag && StudentManager.Students[i].LowPoly.MyMesh.enabled)
				{
					StudentManager.Students[i].LowPoly.MyMesh.enabled = false;
					StudentManager.Students[i].MyRenderer.enabled = true;
				}
			}
		}
	}

	public void UpdateAnims()
	{
		if (OptionGlobals.DisableFarAnimations > 20)
		{
			OptionGlobals.DisableFarAnimations = 1;
		}
		else if (OptionGlobals.DisableFarAnimations < 1)
		{
			OptionGlobals.DisableFarAnimations = 20;
		}
		if (!DoNothing)
		{
			StudentManager.FarAnimThreshold = OptionGlobals.DisableFarAnimations * 5;
			if ((float)StudentManager.FarAnimThreshold > 0f)
			{
				StudentManager.DisableFarAnims = true;
			}
			else
			{
				StudentManager.DisableFarAnims = false;
			}
		}
	}

	public void UpdateDrawDistance()
	{
		if (OptionGlobals.DrawDistance > OptionGlobals.DrawDistanceLimit)
		{
			OptionGlobals.DrawDistance = 10;
		}
		else if (OptionGlobals.DrawDistance < 1)
		{
			OptionGlobals.DrawDistance = OptionGlobals.DrawDistanceLimit;
		}
		if (!DoNothing)
		{
			Camera.main.farClipPlane = OptionGlobals.DrawDistance;
			RenderSettings.fogEndDistance = OptionGlobals.DrawDistance;
			Yandere.Smartphone.farClipPlane = OptionGlobals.DrawDistance;
			if (OptionGlobals.DrawDistance < 250)
			{
				Clouds.SetActive(value: false);
			}
			else
			{
				Clouds.SetActive(value: true);
			}
		}
	}

	public void UpdateVsync()
	{
		if (!OptionGlobals.Vsync)
		{
			QualitySettings.vSyncCount = 0;
		}
		else
		{
			QualitySettings.vSyncCount = 1;
		}
	}

	public void UpdateFog()
	{
		if (DoNothing)
		{
			return;
		}
		if (GameGlobals.EightiesTutorial)
		{
			Debug.Log("The QualityManager script knows that we're in the tutorial.");
			OriginalFog = OptionGlobals.Fog;
			Debug.Log("QualityManager.OriginalFog is: " + OriginalFog);
			OptionGlobals.Fog = true;
			Debug.Log("QualityManager is now manually enabling fog.");
		}
		if (!OptionGlobals.Fog)
		{
			Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
			RenderSettings.fogMode = FogMode.Exponential;
			return;
		}
		Yandere.MainCamera.clearFlags = CameraClearFlags.Color;
		RenderSettings.fogMode = FogMode.Linear;
		RenderSettings.fogEndDistance = OptionGlobals.DrawDistance;
		if (GameGlobals.EightiesTutorial && DateGlobals.Week < 10)
		{
			RenderSettings.fogColor = new Color(1f, 1f, 1f, 1f);
			RenderSettings.fogMode = FogMode.Exponential;
			RenderSettings.fogDensity = 0.1f;
		}
	}

	public void UpdateShadows()
	{
		if (!DoNothing)
		{
			Sun.shadows = (OptionGlobals.EnableShadows ? LightShadows.Soft : LightShadows.None);
		}
	}

	public void ToggleRun()
	{
		if (!DoNothing)
		{
			Yandere.ToggleRun = OptionGlobals.ToggleRun;
		}
	}

	public void UpdateFPSIndex()
	{
		if (OptionGlobals.FPSIndex < 0)
		{
			OptionGlobals.FPSIndex = FPSValues.Length - 1;
		}
		else if (OptionGlobals.FPSIndex >= FPSValues.Length)
		{
			OptionGlobals.FPSIndex = 0;
		}
		Application.targetFrameRate = FPSValues[OptionGlobals.FPSIndex];
	}

	public void ToggleExperiment()
	{
		if (!DoNothing)
		{
			if (!ExperimentalBloomAndLensFlares.enabled)
			{
				ExperimentalBloomAndLensFlares.enabled = true;
				ExperimentalDepthOfField34.enabled = false;
				ExperimentalSSAOEffect.enabled = false;
				BloomEffect.enabled = true;
			}
			else
			{
				ExperimentalBloomAndLensFlares.enabled = false;
				ExperimentalDepthOfField34.enabled = false;
				ExperimentalSSAOEffect.enabled = false;
				BloomEffect.enabled = false;
			}
		}
	}

	public void UpdateOutlinesAndRimlight()
	{
		if (OptionGlobals.DisableOutlines)
		{
			if (OptionGlobals.RimLight)
			{
				NewHairShader = ToonRimLight;
				NewBodyShader = ToonRimLightOverlay;
			}
			else
			{
				NewHairShader = Toon;
				NewBodyShader = ToonOverlay;
			}
		}
		else if (OptionGlobals.RimLight)
		{
			NewHairShader = ToonOutlineRimLight;
			NewBodyShader = ToonOutlineRimLightOverlay;
		}
		else
		{
			NewHairShader = ToonOutline;
			NewBodyShader = ToonOutlineOverlay;
		}
		if (!DoNothing)
		{
			for (int i = 1; i < StudentManager.Students.Length; i++)
			{
				StudentScript studentScript = StudentManager.Students[i];
				if (!(studentScript != null))
				{
					continue;
				}
				studentScript.MyRenderer.materials[0].shader = NewBodyShader;
				studentScript.MyRenderer.materials[1].shader = NewBodyShader;
				AdjustRimLight(studentScript.MyRenderer.materials[0]);
				AdjustRimLight(studentScript.MyRenderer.materials[1]);
				if (studentScript.MyRenderer.materials.Length > 2)
				{
					studentScript.MyRenderer.materials[2].shader = NewBodyShader;
					AdjustRimLight(studentScript.MyRenderer.materials[2]);
					if (studentScript.MyRenderer.materials.Length > 3)
					{
						studentScript.MyRenderer.materials[3].shader = NewBodyShader;
						AdjustRimLight(studentScript.MyRenderer.materials[3]);
					}
				}
				if (!studentScript.Male)
				{
					if (!studentScript.Teacher)
					{
						if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle] != null)
						{
							if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
							{
								studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = NewBodyShader;
								AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material);
							}
							else
							{
								studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = NewBodyShader;
								studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = NewBodyShader;
								AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0]);
								AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1]);
							}
						}
						if (studentScript.Cosmetic.Accessory > 0 && studentScript.Cosmetic.Accessory < studentScript.Cosmetic.FemaleAccessories.Length && studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>() != null)
						{
							studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = NewBodyShader;
							AdjustRimLight(studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material);
						}
						if (studentScript.Club == ClubType.Bully)
						{
							studentScript.Cosmetic.Bookbag.GetComponent<Renderer>().material.shader = NewHairShader;
							studentScript.Cosmetic.LeftWristband.GetComponent<Renderer>().material.shader = NewHairShader;
							studentScript.Cosmetic.RightWristband.GetComponent<Renderer>().material.shader = NewHairShader;
							studentScript.Cosmetic.HoodieRenderer.material.shader = NewHairShader;
						}
						studentScript.Cosmetic.RightStockings[0].GetComponent<Renderer>().material.shader = NewHairShader;
						studentScript.Cosmetic.LeftStockings[0].GetComponent<Renderer>().material.shader = NewHairShader;
						if (studentScript.Club == ClubType.Council)
						{
							studentScript.Cosmetic.TurtleEyewearRenderer.material.shader = NewHairShader;
							studentScript.Cosmetic.ScarfRenderer.material.shader = NewHairShader;
						}
						if (LoveSick)
						{
							studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.SetFloat("_Saturation", 0f);
						}
						if (studentScript.Cosmetic.HairbandRenderer != null)
						{
							studentScript.Cosmetic.HairbandRenderer.material.shader = NewHairShader;
						}
					}
					else
					{
						studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = NewBodyShader;
						if (studentScript.Cosmetic.Accessory > 0)
						{
							studentScript.Cosmetic.TeacherAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = NewHairShader;
						}
						AdjustRimLight(studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material);
						studentScript.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
						studentScript.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
						if (LoveSick)
						{
							studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material.SetFloat("_Saturation", 0f);
						}
					}
				}
				else
				{
					if (studentScript.Cosmetic.Hairstyle > 0)
					{
						if (studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
						{
							studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = NewBodyShader;
							AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material);
							if (studentScript.Cosmetic.UsingDefaultHairColor && !LoveSick)
							{
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.SetFloat("_Saturation", 1f);
							}
							else
							{
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.SetFloat("_Saturation", 0f);
							}
						}
						else
						{
							studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = NewBodyShader;
							studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = NewBodyShader;
							AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0]);
							AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1]);
							if (studentScript.Cosmetic.UsingDefaultHairColor && !LoveSick)
							{
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].SetFloat("_Saturation", 1f);
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].SetFloat("_Saturation", 1f);
							}
							else
							{
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].SetFloat("_Saturation", 0f);
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].SetFloat("_Saturation", 0f);
							}
						}
					}
					if (studentScript.Cosmetic.Accessory > 0)
					{
						Renderer component = studentScript.Cosmetic.MaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>();
						if (component != null)
						{
							component.material.shader = NewBodyShader;
							AdjustRimLight(component.material);
							if (!Eighties && studentScript.StudentID == 33)
							{
								component.materials[2].color = new Color(1f, 1f, 1f, 0.5f);
								component.materials[2].shader = Shader.Find("Transparent/Diffuse");
							}
						}
					}
				}
				if (!studentScript.Teacher && studentScript.Cosmetic.Club > ClubType.None && studentScript.Cosmetic.Club != ClubType.Council && studentScript.Cosmetic.Club != ClubType.Bully && studentScript.Cosmetic.Club != ClubType.Delinquent && studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club] != null)
				{
					Renderer component2 = studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club].GetComponent<Renderer>();
					if (component2 != null)
					{
						component2.material.shader = NewBodyShader;
						AdjustRimLight(component2.material);
					}
				}
				if (studentScript.Cosmetic.EyewearID > 0 && studentScript.Cosmetic.Eyewear.Length != 0 && studentScript.Cosmetic.Eyewear[studentScript.Cosmetic.EyewearID] != null)
				{
					studentScript.Cosmetic.Eyewear[studentScript.Cosmetic.EyewearID].GetComponent<Renderer>().material.shader = NewHairShader;
				}
				studentScript.SmartPhone.GetComponent<Renderer>().material.shader = NewHairShader;
				studentScript.Armband.GetComponent<Renderer>().material.shader = NewHairShader;
				if (studentScript.ApronAttacher.newRenderer != null)
				{
					studentScript.ApronAttacher.newRenderer.material.shader = NewHairShader;
				}
				if (studentScript.LabcoatAttacher.newRenderer != null)
				{
					studentScript.LabcoatAttacher.newRenderer.material.shader = NewHairShader;
				}
			}
			UpdateYandereChan();
			Nemesis.Cosmetic.MyRenderer.materials[0].shader = NewBodyShader;
			Nemesis.Cosmetic.MyRenderer.materials[1].shader = NewBodyShader;
			Nemesis.Cosmetic.MyRenderer.materials[2].shader = NewBodyShader;
			Nemesis.NemesisHair.GetComponent<Renderer>().material.shader = NewBodyShader;
			AdjustRimLight(Nemesis.Cosmetic.MyRenderer.materials[0]);
			AdjustRimLight(Nemesis.Cosmetic.MyRenderer.materials[1]);
			AdjustRimLight(Nemesis.Cosmetic.MyRenderer.materials[2]);
			AdjustRimLight(Nemesis.NemesisHair.GetComponent<Renderer>().material);
			StudentManager.Journalist.GetComponent<JournalistScript>().Renderer.materials[0].shader = NewBodyShader;
			StudentManager.Journalist.GetComponent<JournalistScript>().Renderer.materials[1].shader = NewBodyShader;
		}
		UpdateStockings();
		if (Yandere != null)
		{
			Yandere.TheDebugMenuScript.UpdateCensor();
			Yandere.TheDebugMenuScript.UpdateCensor();
		}
	}

	public void UpdateYandereChan()
	{
		Yandere.MyRenderer.materials[0].shader = NewBodyShader;
		Yandere.MyRenderer.materials[1].shader = NewBodyShader;
		Yandere.MyRenderer.materials[2].shader = NewBodyShader;
		AdjustRimLight(Yandere.MyRenderer.materials[0]);
		AdjustRimLight(Yandere.MyRenderer.materials[1]);
		AdjustRimLight(Yandere.MyRenderer.materials[2]);
		AdjustRimLight(Yandere.LooseSocks[0].GetComponent<Renderer>().material);
		AdjustRimLight(Yandere.LooseSocks[1].GetComponent<Renderer>().material);
		AdjustRimLight(Yandere.LooseSocks[2].GetComponent<Renderer>().material);
		AdjustRimLight(Yandere.LooseSocks[3].GetComponent<Renderer>().material);
		Yandere.LooseSocks[0].GetComponent<Renderer>().material.shader = NewBodyShader;
		Yandere.LooseSocks[1].GetComponent<Renderer>().material.shader = NewBodyShader;
		Yandere.LooseSocks[2].GetComponent<Renderer>().material.shader = NewBodyShader;
		Yandere.LooseSocks[3].GetComponent<Renderer>().material.shader = NewBodyShader;
		for (int i = 1; i < Yandere.Hairstyles.Length; i++)
		{
			Renderer component = Yandere.Hairstyles[i].GetComponent<Renderer>();
			if (component != null)
			{
				Yandere.EightiesPonytailRenderer.material.shader = NewBodyShader;
				YandereHairRenderer.material.shader = NewBodyShader;
				component.material.shader = NewBodyShader;
				AdjustRimLight(YandereHairRenderer.material);
				AdjustRimLight(component.material);
			}
			if (Yandere.Hairstyles[i].transform.childCount <= 0)
			{
				continue;
			}
			foreach (Transform item in Yandere.Hairstyles[i].transform)
			{
				Renderer component2 = item.GetComponent<Renderer>();
				if (component2 != null)
				{
					component2.material.shader = NewBodyShader;
					AdjustRimLight(component2.material);
					continue;
				}
				SkinnedMeshRenderer component3 = item.GetComponent<SkinnedMeshRenderer>();
				if (component3 != null)
				{
					component3.material.shader = NewBodyShader;
					AdjustRimLight(component3.material);
				}
			}
		}
	}

	public void UpdateObscurance()
	{
		if (!DoNothing)
		{
			Obscurance.enabled = !OptionGlobals.DisableObscurance;
		}
	}

	public void AdjustRimLight(Material mat)
	{
		if (!DoNothing)
		{
			mat.SetFloat("_RimLightIntensity", 5f);
			mat.SetFloat("_RimCrisp", 0.5f);
			mat.SetFloat("_RimAdditive", 0.5f);
			mat.SetFloat("_BlendAmount", 0f);
			mat.SetFloat("_BlendAmount1", 0f);
		}
		UpdateStockings();
	}

	public void UpdateEightiesEffects()
	{
		EightiesEffects.useStaticNoise = !OptionGlobals.DisableStatic;
		EightiesEffects.useDisplacementWaves = !OptionGlobals.DisableDisplacement;
		EightiesEffects.useChromaticAberration = !OptionGlobals.DisableAbberation;
		EightiesEffects.useVignette = !OptionGlobals.DisableVignette;
		EightiesEffects.useRadialDistortion = !OptionGlobals.DisableDistortion;
		EightiesEffects.useScanlines = !OptionGlobals.DisableScanlines;
		EightiesEffects.useBottomNoise = !OptionGlobals.DisableNoise;
		EightiesEffects.useBottomStretch = !OptionGlobals.DisableNoise;
		if (Tint != null)
		{
			Tint.enabled = !OptionGlobals.DisableTint;
		}
	}

	public void UpdateCameraPosition()
	{
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
	}

	public void UpdateSubtitleSize()
	{
		if (StudentManager.Yandere.PauseScreen != null)
		{
			StudentManager.Yandere.PauseScreen.UpdateSubtitleSize();
		}
	}
}
