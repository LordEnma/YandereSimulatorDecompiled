using System;
using RetroAesthetics;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x020003C4 RID: 964
public class QualityManagerScript : MonoBehaviour
{
	// Token: 0x06001B24 RID: 6948 RVA: 0x0012EDE4 File Offset: 0x0012CFE4
	public void Start()
	{
		if (OptionGlobals.DisableOutlines)
		{
			this.DisableOutlinesLater = true;
		}
		if (!OptionGlobals.RimLight)
		{
			this.DisableRimLightLater = true;
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
			this.DoNothing = true;
		}
		else
		{
			this.SchoolScene = true;
		}
		if (!this.DoNothing)
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
			if (this.ColorGrading == null)
			{
				CameraFilterPack_Colors_Adjust_PreFilters[] components = this.StudentManager.MainCamera.GetComponents<CameraFilterPack_Colors_Adjust_PreFilters>();
				this.ColorGrading = components[2];
			}
			this.Yandere.PauseScreen.NewSettings.Profile.depthOfField.enabled = OptionGlobals.DepthOfField;
			this.Yandere.PauseScreen.NewSettings.Profile.motionBlur.enabled = OptionGlobals.MotionBlur;
			this.StudentManager.TransparentWindows = false;
			this.StudentManager.SetWindowsOpaque();
			this.StudentManager.LateUpdate();
			this.ToggleRun();
			this.UpdateFog();
			this.DisplayFPS();
			this.UpdateHair();
			this.UpdateAnims();
			this.UpdateVsync();
			this.UpdateGrass();
			this.UpdateShadows();
			this.UpdateFPSIndex();
			this.UpdateDrawDistance();
			this.UpdateOpaqueWindows();
			this.UpdateCameraPosition();
			this.UpdateLowDetailStudents();
			this.UpdateEightiesEffects();
			if (this.EastRomanceBlossoms != null)
			{
				this.UpdateParticles();
			}
			if (this.ColorGrading != null)
			{
				this.UpdateColorGrading();
			}
		}
	}

	// Token: 0x06001B25 RID: 6949 RVA: 0x0012EFA0 File Offset: 0x0012D1A0
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
		if (!this.DoNothing)
		{
			ParticleSystem.EmissionModule emission = this.EastRomanceBlossoms.emission;
			ParticleSystem.EmissionModule emission2 = this.WestRomanceBlossoms.emission;
			ParticleSystem.EmissionModule emission3 = this.CorridorBlossoms.emission;
			ParticleSystem.EmissionModule emission4 = this.PlazaBlossoms.emission;
			ParticleSystem.EmissionModule emission5 = this.MythBlossoms.emission;
			ParticleSystem.EmissionModule emission6 = this.Steam[1].emission;
			ParticleSystem.EmissionModule emission7 = this.Fountains[1].emission;
			ParticleSystem.EmissionModule emission8 = this.Fountains[2].emission;
			ParticleSystem.EmissionModule emission9 = this.Fountains[3].emission;
			emission.enabled = true;
			emission2.enabled = true;
			emission3.enabled = true;
			emission4.enabled = true;
			emission5.enabled = true;
			emission6.enabled = true;
			emission7.enabled = true;
			emission8.enabled = true;
			emission9.enabled = true;
			if (OptionGlobals.ParticleCount == 3)
			{
				emission.rateOverTime = 100f;
				emission2.rateOverTime = 100f;
				emission3.rateOverTime = 1000f;
				emission4.rateOverTime = 400f;
				emission5.rateOverTime = 100f;
				emission6.rateOverTime = 100f;
				emission7.rateOverTime = 100f;
				emission8.rateOverTime = 100f;
				emission9.rateOverTime = 100f;
				return;
			}
			if (OptionGlobals.ParticleCount == 2)
			{
				emission.rateOverTime = 10f;
				emission2.rateOverTime = 10f;
				emission3.rateOverTime = 100f;
				emission4.rateOverTime = 40f;
				emission5.rateOverTime = 10f;
				emission6.rateOverTime = 10f;
				emission7.rateOverTime = 10f;
				emission8.rateOverTime = 10f;
				emission9.rateOverTime = 10f;
				return;
			}
			if (OptionGlobals.ParticleCount == 1)
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
			}
		}
	}

	// Token: 0x06001B26 RID: 6950 RVA: 0x0012F234 File Offset: 0x0012D434
	public void UpdateOutlines()
	{
		if (!this.DoNothing)
		{
			for (int i = 1; i < this.StudentManager.Students.Length; i++)
			{
				StudentScript studentScript = this.StudentManager.Students[i];
				if (studentScript != null)
				{
					if (OptionGlobals.DisableOutlines)
					{
						this.NewHairShader = this.Toon;
						this.NewBodyShader = this.ToonOverlay;
					}
					else
					{
						this.NewHairShader = this.ToonOutline;
						this.NewBodyShader = this.ToonOutlineOverlay;
					}
					if (!studentScript.Male)
					{
						studentScript.MyRenderer.materials[0].shader = this.NewBodyShader;
						studentScript.MyRenderer.materials[1].shader = this.NewBodyShader;
						if (studentScript.MyRenderer.materials.Length > 2)
						{
							studentScript.MyRenderer.materials[2].shader = this.NewBodyShader;
						}
						studentScript.Cosmetic.RightStockings[0].GetComponent<Renderer>().material.shader = this.NewBodyShader;
						studentScript.Cosmetic.LeftStockings[0].GetComponent<Renderer>().material.shader = this.NewBodyShader;
						if (studentScript.Club == ClubType.Bully)
						{
							studentScript.Cosmetic.Bookbag.GetComponent<Renderer>().material.shader = this.NewHairShader;
							studentScript.Cosmetic.LeftWristband.GetComponent<Renderer>().material.shader = this.NewHairShader;
							studentScript.Cosmetic.RightWristband.GetComponent<Renderer>().material.shader = this.NewHairShader;
							studentScript.Cosmetic.HoodieRenderer.GetComponent<Renderer>().material.shader = this.NewHairShader;
						}
						if (studentScript.StudentID == 87)
						{
							studentScript.Cosmetic.ScarfRenderer.material.shader = this.NewHairShader;
						}
						else if (studentScript.StudentID == 90)
						{
							if (studentScript.Cosmetic.TeacherAccessories[studentScript.Cosmetic.Accessory] != null)
							{
								studentScript.Cosmetic.TeacherAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = this.NewHairShader;
							}
							if (studentScript.MyRenderer.materials.Length == 4)
							{
								studentScript.MyRenderer.materials[3].shader = this.NewBodyShader;
							}
						}
					}
					else
					{
						studentScript.MyRenderer.materials[0].shader = this.NewHairShader;
						studentScript.MyRenderer.materials[1].shader = this.NewHairShader;
						studentScript.MyRenderer.materials[2].shader = this.NewBodyShader;
					}
					studentScript.Armband.GetComponent<Renderer>().material.shader = this.NewHairShader;
					if (!studentScript.Male)
					{
						if (!studentScript.Teacher)
						{
							if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle] != null)
							{
								if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
								{
									studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
								}
								else
								{
									studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = this.NewHairShader;
									studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = this.NewHairShader;
								}
							}
							if (studentScript.Cosmetic.Accessory > 0 && studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>() != null)
							{
								studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = this.NewHairShader;
							}
						}
						else
						{
							if (studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle] != null)
							{
								studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
							}
							if (studentScript.Cosmetic.Accessory > 0)
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
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
							}
							else
							{
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = this.NewHairShader;
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = this.NewHairShader;
							}
						}
						if (studentScript.Cosmetic.Accessory > 0)
						{
							Renderer component = studentScript.Cosmetic.MaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>();
							if (component != null)
							{
								component.material.shader = this.NewHairShader;
							}
						}
					}
					if (!studentScript.Teacher && studentScript.Cosmetic.Club > ClubType.None && studentScript.Cosmetic.Club != ClubType.Council && studentScript.Cosmetic.Club != ClubType.Bully && studentScript.Cosmetic.Club != ClubType.Delinquent && studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club] != null)
					{
						Renderer component2 = studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club].GetComponent<Renderer>();
						if (component2 != null)
						{
							component2.material.shader = this.NewHairShader;
						}
					}
				}
			}
			this.Yandere.MyRenderer.materials[0].shader = this.NewBodyShader;
			this.Yandere.MyRenderer.materials[1].shader = this.NewBodyShader;
			this.Yandere.MyRenderer.materials[2].shader = this.NewBodyShader;
			for (int j = 1; j < this.Yandere.Hairstyles.Length; j++)
			{
				Renderer component3 = this.Yandere.Hairstyles[j].GetComponent<Renderer>();
				if (component3 != null)
				{
					this.Yandere.EightiesPonytailRenderer.material.shader = this.NewHairShader;
					this.YandereHairRenderer.material.shader = this.NewHairShader;
					component3.material.shader = this.NewHairShader;
				}
			}
			this.Nemesis.Cosmetic.MyRenderer.materials[0].shader = this.NewBodyShader;
			this.Nemesis.Cosmetic.MyRenderer.materials[1].shader = this.NewBodyShader;
			this.Nemesis.Cosmetic.MyRenderer.materials[2].shader = this.NewBodyShader;
			this.Nemesis.NemesisHair.GetComponent<Renderer>().material.shader = this.NewHairShader;
		}
	}

	// Token: 0x06001B27 RID: 6951 RVA: 0x0012F985 File Offset: 0x0012DB85
	public void UpdatePostAliasing()
	{
		if (!this.DoNothing)
		{
			this.PostAliasing.enabled = !OptionGlobals.DisablePostAliasing;
		}
	}

	// Token: 0x06001B28 RID: 6952 RVA: 0x0012F9A2 File Offset: 0x0012DBA2
	public void UpdateBloom()
	{
		Debug.Log("Just ran UpdateBloom()");
		if (!this.DoNothing)
		{
			this.BloomEffect.enabled = !OptionGlobals.DisableBloom;
		}
	}

	// Token: 0x06001B29 RID: 6953 RVA: 0x0012F9CC File Offset: 0x0012DBCC
	public void UpdateOpaqueWindows()
	{
		if (!this.DoNothing)
		{
			if (OptionGlobals.OpaqueWindows)
			{
				this.StudentManager.TransparentWindows = false;
				this.StudentManager.SetWindowsOpaque();
			}
			else
			{
				this.StudentManager.WindowOccluder.open = true;
				this.StudentManager.TransparentWindows = true;
				this.StudentManager.SetWindowsTransparent();
			}
			this.StudentManager.LateUpdate();
		}
	}

	// Token: 0x06001B2A RID: 6954 RVA: 0x0012FA34 File Offset: 0x0012DC34
	public void UpdateColorGrading()
	{
		if (!this.DoNothing)
		{
			this.ColorGrading.enabled = OptionGlobals.ColorGrading;
		}
	}

	// Token: 0x06001B2B RID: 6955 RVA: 0x0012FA4E File Offset: 0x0012DC4E
	public void UpdateGrass()
	{
		if (!this.DoNothing)
		{
			this.Grass.SetActive(OptionGlobals.ToggleGrass);
		}
	}

	// Token: 0x06001B2C RID: 6956 RVA: 0x0012FA68 File Offset: 0x0012DC68
	public void UpdateHair()
	{
		if (!this.DoNothing)
		{
			this.StudentManager.UpdateDynamicBones(!OptionGlobals.HairPhysics);
		}
	}

	// Token: 0x06001B2D RID: 6957 RVA: 0x0012FA85 File Offset: 0x0012DC85
	public void DisplayFPS()
	{
		if (!this.DoNothing)
		{
			this.StudentManager.UpdateFPSDisplay(OptionGlobals.DisplayFPS);
		}
	}

	// Token: 0x06001B2E RID: 6958 RVA: 0x0012FAA0 File Offset: 0x0012DCA0
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
		if (!this.DoNothing)
		{
			this.StudentManager.LowDetailThreshold = OptionGlobals.LowDetailStudents * 10;
			bool flag = (float)this.StudentManager.LowDetailThreshold > 0f;
			for (int i = 1; i < 101; i++)
			{
				if (this.StudentManager.Students[i] != null)
				{
					this.StudentManager.Students[i].LowPoly.enabled = flag;
					if (!flag && this.StudentManager.Students[i].LowPoly.MyMesh.enabled)
					{
						this.StudentManager.Students[i].LowPoly.MyMesh.enabled = false;
						this.StudentManager.Students[i].MyRenderer.enabled = true;
					}
				}
			}
		}
	}

	// Token: 0x06001B2F RID: 6959 RVA: 0x0012FB9C File Offset: 0x0012DD9C
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
		if (!this.DoNothing)
		{
			this.StudentManager.FarAnimThreshold = OptionGlobals.DisableFarAnimations * 5;
			if ((float)this.StudentManager.FarAnimThreshold > 0f)
			{
				this.StudentManager.DisableFarAnims = true;
				return;
			}
			this.StudentManager.DisableFarAnims = false;
		}
	}

	// Token: 0x06001B30 RID: 6960 RVA: 0x0012FC10 File Offset: 0x0012DE10
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
		if (!this.DoNothing)
		{
			Camera.main.farClipPlane = (float)OptionGlobals.DrawDistance;
			RenderSettings.fogEndDistance = (float)OptionGlobals.DrawDistance;
			this.Yandere.Smartphone.farClipPlane = (float)OptionGlobals.DrawDistance;
		}
	}

	// Token: 0x06001B31 RID: 6961 RVA: 0x0012FC7D File Offset: 0x0012DE7D
	public void UpdateVsync()
	{
		if (!OptionGlobals.Vsync)
		{
			QualitySettings.vSyncCount = 0;
			return;
		}
		QualitySettings.vSyncCount = 1;
	}

	// Token: 0x06001B32 RID: 6962 RVA: 0x0012FC94 File Offset: 0x0012DE94
	public void UpdateFog()
	{
		if (!this.DoNothing)
		{
			if (GameGlobals.EightiesTutorial)
			{
				Debug.Log("The QualityManager script knows that we're in the tutorial, so it is manually enabling Fog.");
				OptionGlobals.Fog = true;
			}
			if (!OptionGlobals.Fog)
			{
				this.Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
				RenderSettings.fogMode = FogMode.Exponential;
				return;
			}
			this.Yandere.MainCamera.clearFlags = CameraClearFlags.Color;
			RenderSettings.fogMode = FogMode.Linear;
			RenderSettings.fogEndDistance = (float)OptionGlobals.DrawDistance;
			if (GameGlobals.EightiesTutorial && DateGlobals.Week < 10)
			{
				RenderSettings.fogColor = new Color(1f, 1f, 1f, 1f);
				RenderSettings.fogMode = FogMode.Exponential;
				RenderSettings.fogDensity = 0.1f;
			}
		}
	}

	// Token: 0x06001B33 RID: 6963 RVA: 0x0012FD42 File Offset: 0x0012DF42
	public void UpdateShadows()
	{
		if (!this.DoNothing)
		{
			this.Sun.shadows = (OptionGlobals.EnableShadows ? LightShadows.Soft : LightShadows.None);
		}
	}

	// Token: 0x06001B34 RID: 6964 RVA: 0x0012FD62 File Offset: 0x0012DF62
	public void ToggleRun()
	{
		if (!this.DoNothing)
		{
			this.Yandere.ToggleRun = OptionGlobals.ToggleRun;
		}
	}

	// Token: 0x06001B35 RID: 6965 RVA: 0x0012FD7C File Offset: 0x0012DF7C
	public void UpdateFPSIndex()
	{
		if (OptionGlobals.FPSIndex < 0)
		{
			OptionGlobals.FPSIndex = QualityManagerScript.FPSValues.Length - 1;
		}
		else if (OptionGlobals.FPSIndex >= QualityManagerScript.FPSValues.Length)
		{
			OptionGlobals.FPSIndex = 0;
		}
		Application.targetFrameRate = QualityManagerScript.FPSValues[OptionGlobals.FPSIndex];
	}

	// Token: 0x06001B36 RID: 6966 RVA: 0x0012FDBC File Offset: 0x0012DFBC
	public void ToggleExperiment()
	{
		if (!this.DoNothing)
		{
			if (!this.ExperimentalBloomAndLensFlares.enabled)
			{
				this.ExperimentalBloomAndLensFlares.enabled = true;
				this.ExperimentalDepthOfField34.enabled = false;
				this.ExperimentalSSAOEffect.enabled = false;
				this.BloomEffect.enabled = true;
				return;
			}
			this.ExperimentalBloomAndLensFlares.enabled = false;
			this.ExperimentalDepthOfField34.enabled = false;
			this.ExperimentalSSAOEffect.enabled = false;
			this.BloomEffect.enabled = false;
		}
	}

	// Token: 0x06001B37 RID: 6967 RVA: 0x0012FE40 File Offset: 0x0012E040
	public void UpdateOutlinesAndRimlight()
	{
		if (OptionGlobals.DisableOutlines)
		{
			if (OptionGlobals.RimLight)
			{
				this.NewHairShader = this.ToonRimLight;
				this.NewBodyShader = this.ToonRimLightOverlay;
			}
			else
			{
				this.NewHairShader = this.Toon;
				this.NewBodyShader = this.ToonOverlay;
			}
		}
		else if (OptionGlobals.RimLight)
		{
			this.NewHairShader = this.ToonOutlineRimLight;
			this.NewBodyShader = this.ToonOutlineRimLightOverlay;
		}
		else
		{
			this.NewHairShader = this.ToonOutline;
			this.NewBodyShader = this.ToonOutlineOverlay;
		}
		if (!this.DoNothing)
		{
			for (int i = 1; i < this.StudentManager.Students.Length; i++)
			{
				StudentScript studentScript = this.StudentManager.Students[i];
				if (studentScript != null)
				{
					studentScript.MyRenderer.materials[0].shader = this.NewBodyShader;
					studentScript.MyRenderer.materials[1].shader = this.NewBodyShader;
					this.AdjustRimLight(studentScript.MyRenderer.materials[0]);
					this.AdjustRimLight(studentScript.MyRenderer.materials[1]);
					if (studentScript.MyRenderer.materials.Length > 2)
					{
						studentScript.MyRenderer.materials[2].shader = this.NewBodyShader;
						this.AdjustRimLight(studentScript.MyRenderer.materials[2]);
					}
					if (!studentScript.Male)
					{
						if (!studentScript.Teacher)
						{
							if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle] != null)
							{
								if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
								{
									studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewBodyShader;
									this.AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material);
								}
								else
								{
									studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = this.NewBodyShader;
									studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = this.NewBodyShader;
									this.AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0]);
									this.AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1]);
								}
							}
							if (studentScript.Cosmetic.Accessory > 0 && studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>() != null)
							{
								studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = this.NewBodyShader;
								this.AdjustRimLight(studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material);
							}
						}
						else
						{
							studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewBodyShader;
							this.AdjustRimLight(studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material);
						}
					}
					else
					{
						if (studentScript.Cosmetic.Hairstyle > 0)
						{
							if (studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials.Length == 1)
							{
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewBodyShader;
								this.AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material);
							}
							else
							{
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0].shader = this.NewBodyShader;
								studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1].shader = this.NewBodyShader;
								this.AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[0]);
								this.AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].materials[1]);
							}
						}
						if (studentScript.Cosmetic.Accessory > 0)
						{
							Renderer component = studentScript.Cosmetic.MaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>();
							if (component != null)
							{
								component.material.shader = this.NewBodyShader;
								this.AdjustRimLight(component.material);
							}
						}
					}
					if (!studentScript.Teacher && studentScript.Cosmetic.Club > ClubType.None && studentScript.Cosmetic.Club != ClubType.Council && studentScript.Cosmetic.Club != ClubType.Bully && studentScript.Cosmetic.Club != ClubType.Delinquent && studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club] != null)
					{
						Renderer component2 = studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club].GetComponent<Renderer>();
						if (component2 != null)
						{
							component2.material.shader = this.NewBodyShader;
							this.AdjustRimLight(component2.material);
						}
					}
				}
			}
			this.Yandere.MyRenderer.materials[0].shader = this.NewBodyShader;
			this.Yandere.MyRenderer.materials[1].shader = this.NewBodyShader;
			this.Yandere.MyRenderer.materials[2].shader = this.NewBodyShader;
			this.AdjustRimLight(this.Yandere.MyRenderer.materials[0]);
			this.AdjustRimLight(this.Yandere.MyRenderer.materials[1]);
			this.AdjustRimLight(this.Yandere.MyRenderer.materials[2]);
			for (int j = 1; j < this.Yandere.Hairstyles.Length; j++)
			{
				Renderer component3 = this.Yandere.Hairstyles[j].GetComponent<Renderer>();
				if (component3 != null)
				{
					this.Yandere.EightiesPonytailRenderer.material.shader = this.NewBodyShader;
					this.YandereHairRenderer.material.shader = this.NewBodyShader;
					component3.material.shader = this.NewBodyShader;
					this.AdjustRimLight(this.YandereHairRenderer.material);
					this.AdjustRimLight(component3.material);
				}
			}
			this.Nemesis.Cosmetic.MyRenderer.materials[0].shader = this.NewBodyShader;
			this.Nemesis.Cosmetic.MyRenderer.materials[1].shader = this.NewBodyShader;
			this.Nemesis.Cosmetic.MyRenderer.materials[2].shader = this.NewBodyShader;
			this.Nemesis.NemesisHair.GetComponent<Renderer>().material.shader = this.NewBodyShader;
			this.AdjustRimLight(this.Nemesis.Cosmetic.MyRenderer.materials[0]);
			this.AdjustRimLight(this.Nemesis.Cosmetic.MyRenderer.materials[1]);
			this.AdjustRimLight(this.Nemesis.Cosmetic.MyRenderer.materials[2]);
			this.AdjustRimLight(this.Nemesis.NemesisHair.GetComponent<Renderer>().material);
		}
	}

	// Token: 0x06001B38 RID: 6968 RVA: 0x0013060D File Offset: 0x0012E80D
	public void UpdateObscurance()
	{
		if (!this.DoNothing)
		{
			this.Obscurance.enabled = !OptionGlobals.DisableObscurance;
		}
	}

	// Token: 0x06001B39 RID: 6969 RVA: 0x0013062A File Offset: 0x0012E82A
	public void AdjustRimLight(Material mat)
	{
		if (!this.DoNothing)
		{
			mat.SetFloat("_RimLightIntensity", 5f);
			mat.SetFloat("_RimCrisp", 0.5f);
			mat.SetFloat("_RimAdditive", 0.5f);
		}
	}

	// Token: 0x06001B3A RID: 6970 RVA: 0x00130664 File Offset: 0x0012E864
	public void UpdateEightiesEffects()
	{
		this.EightiesEffects.useStaticNoise = !OptionGlobals.DisableStatic;
		this.EightiesEffects.useDisplacementWaves = !OptionGlobals.DisableDisplacement;
		this.EightiesEffects.useChromaticAberration = !OptionGlobals.DisableAbberation;
		this.EightiesEffects.useVignette = !OptionGlobals.DisableVignette;
		this.EightiesEffects.useRadialDistortion = !OptionGlobals.DisableDistortion;
		this.EightiesEffects.useScanlines = !OptionGlobals.DisableScanlines;
		this.EightiesEffects.useBottomNoise = !OptionGlobals.DisableNoise;
		this.EightiesEffects.useBottomStretch = !OptionGlobals.DisableNoise;
		if (this.Tint != null)
		{
			this.Tint.enabled = !OptionGlobals.DisableTint;
		}
	}

	// Token: 0x06001B3B RID: 6971 RVA: 0x0013072C File Offset: 0x0012E92C
	public void UpdateCameraPosition()
	{
		if (this.SchoolScene)
		{
			if (OptionGlobals.CameraPosition == 0)
			{
				this.StudentManager.Yandere.Zoom.OverShoulder = false;
				return;
			}
			if (OptionGlobals.CameraPosition == 1)
			{
				this.StudentManager.Yandere.Zoom.OverShoulder = true;
				this.StudentManager.Yandere.Zoom.midOffset = 0.25f;
				return;
			}
			this.StudentManager.Yandere.Zoom.OverShoulder = true;
			this.StudentManager.Yandere.Zoom.midOffset = -0.25f;
		}
	}

	// Token: 0x04002E29 RID: 11817
	public CameraFilterPack_Colors_Adjust_PreFilters ColorGrading;

	// Token: 0x04002E2A RID: 11818
	public CameraFilterPack_Colors_Adjust_PreFilters Tint;

	// Token: 0x04002E2B RID: 11819
	public AntialiasingAsPostEffect PostAliasing;

	// Token: 0x04002E2C RID: 11820
	public StudentManagerScript StudentManager;

	// Token: 0x04002E2D RID: 11821
	public PostProcessingBehaviour Obscurance;

	// Token: 0x04002E2E RID: 11822
	public SettingsScript Settings;

	// Token: 0x04002E2F RID: 11823
	public NemesisScript Nemesis;

	// Token: 0x04002E30 RID: 11824
	public YandereScript Yandere;

	// Token: 0x04002E31 RID: 11825
	public Bloom BloomEffect;

	// Token: 0x04002E32 RID: 11826
	public GameObject Grass;

	// Token: 0x04002E33 RID: 11827
	public Light Sun;

	// Token: 0x04002E34 RID: 11828
	public ParticleSystem EastRomanceBlossoms;

	// Token: 0x04002E35 RID: 11829
	public ParticleSystem WestRomanceBlossoms;

	// Token: 0x04002E36 RID: 11830
	public ParticleSystem CorridorBlossoms;

	// Token: 0x04002E37 RID: 11831
	public ParticleSystem PlazaBlossoms;

	// Token: 0x04002E38 RID: 11832
	public ParticleSystem MythBlossoms;

	// Token: 0x04002E39 RID: 11833
	public ParticleSystem[] Fountains;

	// Token: 0x04002E3A RID: 11834
	public ParticleSystem[] Steam;

	// Token: 0x04002E3B RID: 11835
	public Renderer YandereHairRenderer;

	// Token: 0x04002E3C RID: 11836
	public Shader NewBodyShader;

	// Token: 0x04002E3D RID: 11837
	public Shader NewHairShader;

	// Token: 0x04002E3E RID: 11838
	public Shader Toon;

	// Token: 0x04002E3F RID: 11839
	public Shader ToonOverlay;

	// Token: 0x04002E40 RID: 11840
	public Shader ToonOutline;

	// Token: 0x04002E41 RID: 11841
	public Shader ToonOutlineOverlay;

	// Token: 0x04002E42 RID: 11842
	public Shader ToonRimLight;

	// Token: 0x04002E43 RID: 11843
	public Shader ToonRimLightOverlay;

	// Token: 0x04002E44 RID: 11844
	public Shader ToonOutlineRimLight;

	// Token: 0x04002E45 RID: 11845
	public Shader ToonOutlineRimLightOverlay;

	// Token: 0x04002E46 RID: 11846
	public BloomAndLensFlares ExperimentalBloomAndLensFlares;

	// Token: 0x04002E47 RID: 11847
	public DepthOfField34 ExperimentalDepthOfField34;

	// Token: 0x04002E48 RID: 11848
	public SSAOEffect ExperimentalSSAOEffect;

	// Token: 0x04002E49 RID: 11849
	public bool DoNothing;

	// Token: 0x04002E4A RID: 11850
	public bool SchoolScene;

	// Token: 0x04002E4B RID: 11851
	private static readonly int[] FPSValues = new int[]
	{
		int.MaxValue,
		30,
		60,
		120
	};

	// Token: 0x04002E4C RID: 11852
	public static readonly string[] FPSStrings = new string[]
	{
		"Unlimited",
		"30",
		"60",
		"120"
	};

	// Token: 0x04002E4D RID: 11853
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04002E4E RID: 11854
	public bool DisableOutlinesLater;

	// Token: 0x04002E4F RID: 11855
	public bool DisableRimLightLater;
}
