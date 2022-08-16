// Decompiled with JetBrains decompiler
// Type: QualityManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
  public GameObject Grass;
  public Light Sun;
  public ParticleSystem EastRomanceBlossoms;
  public ParticleSystem WestRomanceBlossoms;
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
  private static readonly int[] FPSValues = new int[4]
  {
    int.MaxValue,
    30,
    60,
    120
  };
  public static readonly string[] FPSStrings = new string[4]
  {
    "Unlimited",
    "30",
    "60",
    "120"
  };
  public RetroCameraEffect EightiesEffects;
  public bool DisableOutlinesLater;
  public bool DisableRimLightLater;

  public void Start()
  {
    if (OptionGlobals.DisableOutlines)
      this.DisableOutlinesLater = true;
    if (!OptionGlobals.RimLight)
      this.DisableRimLightLater = true;
    OptionGlobals.DisableOutlines = false;
    OptionGlobals.RimLight = true;
    if (OptionGlobals.DrawDistance == 0)
    {
      OptionGlobals.DrawDistanceLimit = 350;
      OptionGlobals.DrawDistance = 350;
    }
    if (SceneManager.GetActiveScene().name != "SchoolScene")
      this.DoNothing = true;
    else
      this.SchoolScene = true;
    if (this.DoNothing)
      return;
    if (OptionGlobals.ParticleCount == 0)
      OptionGlobals.ParticleCount = 3;
    if (OptionGlobals.DisableFarAnimations == 0)
      OptionGlobals.DisableFarAnimations = 10;
    if (OptionGlobals.Sensitivity == 0)
      OptionGlobals.Sensitivity = 3;
    if ((Object) this.ColorGrading == (Object) null)
      this.ColorGrading = this.StudentManager.MainCamera.GetComponents<CameraFilterPack_Colors_Adjust_PreFilters>()[2];
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
    if ((Object) this.EastRomanceBlossoms != (Object) null)
      this.UpdateParticles();
    if (!((Object) this.ColorGrading != (Object) null))
      return;
    this.UpdateColorGrading();
  }

  public void UpdateParticles()
  {
    if (OptionGlobals.ParticleCount > 3)
      OptionGlobals.ParticleCount = 1;
    else if (OptionGlobals.ParticleCount < 1)
      OptionGlobals.ParticleCount = 3;
    if (this.DoNothing)
      return;
    ParticleSystem.EmissionModule emission1 = this.EastRomanceBlossoms.emission;
    ParticleSystem.EmissionModule emission2 = this.WestRomanceBlossoms.emission;
    ParticleSystem.EmissionModule emission3 = this.CorridorBlossoms.emission;
    ParticleSystem.EmissionModule emission4 = this.PlazaBlossoms.emission;
    ParticleSystem.EmissionModule emission5 = this.MythBlossoms.emission;
    ParticleSystem.EmissionModule emission6 = this.Steam[1].emission;
    ParticleSystem.EmissionModule emission7 = this.Fountains[1].emission;
    ParticleSystem.EmissionModule emission8 = this.Fountains[2].emission;
    ParticleSystem.EmissionModule emission9 = this.Fountains[3].emission;
    emission1.enabled = true;
    emission2.enabled = true;
    emission3.enabled = true;
    emission4.enabled = true;
    emission5.enabled = true;
    emission6.enabled = true;
    emission7.enabled = true;
    emission8.enabled = true;
    emission9.enabled = true;
    switch (OptionGlobals.ParticleCount)
    {
      case 1:
        emission1.enabled = false;
        emission2.enabled = false;
        emission3.enabled = false;
        emission4.enabled = false;
        emission5.enabled = false;
        emission6.enabled = false;
        emission7.enabled = false;
        emission8.enabled = false;
        emission9.enabled = false;
        break;
      case 2:
        emission1.rateOverTime = (ParticleSystem.MinMaxCurve) 10f;
        emission2.rateOverTime = (ParticleSystem.MinMaxCurve) 10f;
        emission3.rateOverTime = (ParticleSystem.MinMaxCurve) 100f;
        emission4.rateOverTime = (ParticleSystem.MinMaxCurve) 40f;
        emission5.rateOverTime = (ParticleSystem.MinMaxCurve) 10f;
        emission6.rateOverTime = (ParticleSystem.MinMaxCurve) 10f;
        emission7.rateOverTime = (ParticleSystem.MinMaxCurve) 10f;
        emission8.rateOverTime = (ParticleSystem.MinMaxCurve) 10f;
        emission9.rateOverTime = (ParticleSystem.MinMaxCurve) 10f;
        break;
      case 3:
        emission1.rateOverTime = (ParticleSystem.MinMaxCurve) 100f;
        emission2.rateOverTime = (ParticleSystem.MinMaxCurve) 100f;
        emission3.rateOverTime = (ParticleSystem.MinMaxCurve) 1000f;
        emission4.rateOverTime = (ParticleSystem.MinMaxCurve) 400f;
        emission5.rateOverTime = (ParticleSystem.MinMaxCurve) 100f;
        emission6.rateOverTime = (ParticleSystem.MinMaxCurve) 100f;
        emission7.rateOverTime = (ParticleSystem.MinMaxCurve) 100f;
        emission8.rateOverTime = (ParticleSystem.MinMaxCurve) 100f;
        emission9.rateOverTime = (ParticleSystem.MinMaxCurve) 100f;
        break;
    }
  }

  public void UpdateStockings()
  {
    if (this.DoNothing)
      return;
    for (int index = 1; index < this.StudentManager.Students.Length; ++index)
    {
      StudentScript student = this.StudentManager.Students[index];
      if ((Object) student != (Object) null)
      {
        if ((Object) student.Cosmetic.MyStockings != (Object) null)
        {
          student.MyRenderer.materials[0].SetTexture("_OverlayTex", student.Cosmetic.MyStockings);
          student.MyRenderer.materials[1].SetTexture("_OverlayTex", student.Cosmetic.MyStockings);
          student.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
          student.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
        }
        else
        {
          student.MyRenderer.materials[0].SetTexture("_OverlayTex", (Texture) null);
          student.MyRenderer.materials[1].SetTexture("_OverlayTex", (Texture) null);
          student.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
          student.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
        }
        if (student.LabcoatAttacher.enabled && !student.Male)
          student.HideLabCoatPanties();
      }
    }
  }

  public void UpdateOutlines()
  {
    if (!this.DoNothing)
    {
      for (int index = 1; index < this.StudentManager.Students.Length; ++index)
      {
        StudentScript student = this.StudentManager.Students[index];
        if ((Object) student != (Object) null)
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
          if (!student.Male)
          {
            student.MyRenderer.materials[0].shader = this.NewBodyShader;
            student.MyRenderer.materials[1].shader = this.NewBodyShader;
            if (student.MyRenderer.materials.Length > 2)
              student.MyRenderer.materials[2].shader = this.NewBodyShader;
            student.Cosmetic.RightStockings[0].GetComponent<Renderer>().material.shader = this.NewBodyShader;
            student.Cosmetic.LeftStockings[0].GetComponent<Renderer>().material.shader = this.NewBodyShader;
            if (student.Club == ClubType.Bully)
            {
              student.Cosmetic.Bookbag.GetComponent<Renderer>().material.shader = this.NewHairShader;
              student.Cosmetic.LeftWristband.GetComponent<Renderer>().material.shader = this.NewHairShader;
              student.Cosmetic.RightWristband.GetComponent<Renderer>().material.shader = this.NewHairShader;
              student.Cosmetic.HoodieRenderer.material.shader = this.NewHairShader;
            }
            if (student.StudentID == 87)
              student.Cosmetic.ScarfRenderer.material.shader = this.NewHairShader;
            else if (student.StudentID == 90)
            {
              if ((Object) student.Cosmetic.TeacherAccessories[student.Cosmetic.Accessory] != (Object) null)
                student.Cosmetic.TeacherAccessories[student.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = this.NewHairShader;
              if (student.MyRenderer.materials.Length == 4)
                student.MyRenderer.materials[3].shader = this.NewBodyShader;
            }
          }
          else
          {
            student.MyRenderer.materials[0].shader = this.NewHairShader;
            student.MyRenderer.materials[1].shader = this.NewHairShader;
            student.MyRenderer.materials[2].shader = this.NewBodyShader;
          }
          student.Armband.GetComponent<Renderer>().material.shader = this.NewHairShader;
          if (!student.Male)
          {
            if (!student.Teacher)
            {
              if ((Object) student.Cosmetic.FemaleHairRenderers[student.Cosmetic.Hairstyle] != (Object) null)
              {
                if (student.Cosmetic.FemaleHairRenderers[student.Cosmetic.Hairstyle].materials.Length == 1)
                {
                  student.Cosmetic.FemaleHairRenderers[student.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
                }
                else
                {
                  student.Cosmetic.FemaleHairRenderers[student.Cosmetic.Hairstyle].materials[0].shader = this.NewHairShader;
                  student.Cosmetic.FemaleHairRenderers[student.Cosmetic.Hairstyle].materials[1].shader = this.NewHairShader;
                }
              }
              if (student.Cosmetic.Accessory > 0 && (Object) student.Cosmetic.FemaleAccessories[student.Cosmetic.Accessory].GetComponent<Renderer>() != (Object) null)
                student.Cosmetic.FemaleAccessories[student.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = this.NewHairShader;
            }
            else
            {
              if ((Object) student.Cosmetic.TeacherHairRenderers[student.Cosmetic.Hairstyle] != (Object) null)
                student.Cosmetic.TeacherHairRenderers[student.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
              if (student.Cosmetic.Accessory <= 0)
                ;
            }
          }
          else
          {
            if (student.Cosmetic.Hairstyle > 0)
            {
              if (student.Cosmetic.MaleHairRenderers[student.Cosmetic.Hairstyle].materials.Length == 1)
              {
                student.Cosmetic.MaleHairRenderers[student.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
              }
              else
              {
                student.Cosmetic.MaleHairRenderers[student.Cosmetic.Hairstyle].materials[0].shader = this.NewHairShader;
                student.Cosmetic.MaleHairRenderers[student.Cosmetic.Hairstyle].materials[1].shader = this.NewHairShader;
              }
            }
            if (student.Cosmetic.Accessory > 0)
            {
              Renderer component = student.Cosmetic.MaleAccessories[student.Cosmetic.Accessory].GetComponent<Renderer>();
              if ((Object) component != (Object) null)
                component.material.shader = this.NewHairShader;
            }
          }
          if (!student.Teacher && student.Cosmetic.Club > ClubType.None && student.Cosmetic.Club != ClubType.Council && student.Cosmetic.Club != ClubType.Bully && student.Cosmetic.Club != ClubType.Delinquent && (Object) student.Cosmetic.ClubAccessories[(int) student.Cosmetic.Club] != (Object) null)
          {
            Renderer component = student.Cosmetic.ClubAccessories[(int) student.Cosmetic.Club].GetComponent<Renderer>();
            if ((Object) component != (Object) null)
              component.material.shader = this.NewHairShader;
          }
        }
      }
      this.Yandere.MyRenderer.materials[0].shader = this.NewBodyShader;
      this.Yandere.MyRenderer.materials[1].shader = this.NewBodyShader;
      this.Yandere.MyRenderer.materials[2].shader = this.NewBodyShader;
      for (int index = 1; index < this.Yandere.Hairstyles.Length; ++index)
      {
        Renderer component = this.Yandere.Hairstyles[index].GetComponent<Renderer>();
        if ((Object) component != (Object) null)
        {
          this.Yandere.EightiesPonytailRenderer.material.shader = this.NewHairShader;
          this.YandereHairRenderer.material.shader = this.NewHairShader;
          component.material.shader = this.NewHairShader;
        }
      }
      this.Nemesis.Cosmetic.MyRenderer.materials[0].shader = this.NewBodyShader;
      this.Nemesis.Cosmetic.MyRenderer.materials[1].shader = this.NewBodyShader;
      this.Nemesis.Cosmetic.MyRenderer.materials[2].shader = this.NewBodyShader;
      this.Nemesis.NemesisHair.GetComponent<Renderer>().material.shader = this.NewHairShader;
    }
    this.UpdateStockings();
  }

  public void UpdatePostAliasing()
  {
    if (this.DoNothing)
      return;
    this.PostAliasing.enabled = !OptionGlobals.DisablePostAliasing;
  }

  public void UpdateBloom()
  {
    Debug.Log((object) "Just ran UpdateBloom()");
    if (this.DoNothing)
      return;
    this.BloomEffect.enabled = !OptionGlobals.DisableBloom;
  }

  public void UpdateOpaqueWindows()
  {
    if (this.DoNothing)
      return;
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

  public void UpdateColorGrading()
  {
    if (this.DoNothing)
      return;
    this.ColorGrading.enabled = OptionGlobals.ColorGrading;
  }

  public void UpdateGrass()
  {
    if (this.DoNothing)
      return;
    this.Grass.SetActive(OptionGlobals.ToggleGrass);
  }

  public void UpdateHair()
  {
    if (this.DoNothing)
      return;
    this.StudentManager.UpdateDynamicBones(!OptionGlobals.HairPhysics);
  }

  public void DisplayFPS()
  {
    if (this.DoNothing)
      return;
    this.StudentManager.UpdateFPSDisplay(OptionGlobals.DisplayFPS);
  }

  public void UpdateLowDetailStudents()
  {
    if (OptionGlobals.LowDetailStudents > 10)
      OptionGlobals.LowDetailStudents = 0;
    else if (OptionGlobals.LowDetailStudents < 0)
      OptionGlobals.LowDetailStudents = 10;
    if (this.DoNothing)
      return;
    this.StudentManager.LowDetailThreshold = OptionGlobals.LowDetailStudents * 10;
    bool flag = (double) this.StudentManager.LowDetailThreshold > 0.0;
    for (int index = 1; index < 101; ++index)
    {
      if ((Object) this.StudentManager.Students[index] != (Object) null)
      {
        this.StudentManager.Students[index].LowPoly.enabled = flag;
        if (!flag && this.StudentManager.Students[index].LowPoly.MyMesh.enabled)
        {
          this.StudentManager.Students[index].LowPoly.MyMesh.enabled = false;
          this.StudentManager.Students[index].MyRenderer.enabled = true;
        }
      }
    }
  }

  public void UpdateAnims()
  {
    if (OptionGlobals.DisableFarAnimations > 20)
      OptionGlobals.DisableFarAnimations = 1;
    else if (OptionGlobals.DisableFarAnimations < 1)
      OptionGlobals.DisableFarAnimations = 20;
    if (this.DoNothing)
      return;
    this.StudentManager.FarAnimThreshold = OptionGlobals.DisableFarAnimations * 5;
    if ((double) this.StudentManager.FarAnimThreshold > 0.0)
      this.StudentManager.DisableFarAnims = true;
    else
      this.StudentManager.DisableFarAnims = false;
  }

  public void UpdateDrawDistance()
  {
    if (OptionGlobals.DrawDistance > OptionGlobals.DrawDistanceLimit)
      OptionGlobals.DrawDistance = 10;
    else if (OptionGlobals.DrawDistance < 1)
      OptionGlobals.DrawDistance = OptionGlobals.DrawDistanceLimit;
    if (this.DoNothing)
      return;
    Camera.main.farClipPlane = (float) OptionGlobals.DrawDistance;
    RenderSettings.fogEndDistance = (float) OptionGlobals.DrawDistance;
    this.Yandere.Smartphone.farClipPlane = (float) OptionGlobals.DrawDistance;
  }

  public void UpdateVsync()
  {
    if (!OptionGlobals.Vsync)
      QualitySettings.vSyncCount = 0;
    else
      QualitySettings.vSyncCount = 1;
  }

  public void UpdateFog()
  {
    if (this.DoNothing)
      return;
    if (GameGlobals.EightiesTutorial)
    {
      Debug.Log((object) "The QualityManager script knows that we're in the tutorial, so it is manually enabling Fog.");
      OptionGlobals.Fog = true;
    }
    if (!OptionGlobals.Fog)
    {
      this.Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
      RenderSettings.fogMode = FogMode.Exponential;
    }
    else
    {
      this.Yandere.MainCamera.clearFlags = CameraClearFlags.Color;
      RenderSettings.fogMode = FogMode.Linear;
      RenderSettings.fogEndDistance = (float) OptionGlobals.DrawDistance;
      if (!GameGlobals.EightiesTutorial || DateGlobals.Week >= 10)
        return;
      RenderSettings.fogColor = new Color(1f, 1f, 1f, 1f);
      RenderSettings.fogMode = FogMode.Exponential;
      RenderSettings.fogDensity = 0.1f;
    }
  }

  public void UpdateShadows()
  {
    if (this.DoNothing)
      return;
    this.Sun.shadows = OptionGlobals.EnableShadows ? LightShadows.Soft : LightShadows.None;
  }

  public void ToggleRun()
  {
    if (this.DoNothing)
      return;
    this.Yandere.ToggleRun = OptionGlobals.ToggleRun;
  }

  public void UpdateFPSIndex()
  {
    if (OptionGlobals.FPSIndex < 0)
      OptionGlobals.FPSIndex = QualityManagerScript.FPSValues.Length - 1;
    else if (OptionGlobals.FPSIndex >= QualityManagerScript.FPSValues.Length)
      OptionGlobals.FPSIndex = 0;
    Application.targetFrameRate = QualityManagerScript.FPSValues[OptionGlobals.FPSIndex];
  }

  public void ToggleExperiment()
  {
    if (this.DoNothing)
      return;
    if (!this.ExperimentalBloomAndLensFlares.enabled)
    {
      this.ExperimentalBloomAndLensFlares.enabled = true;
      this.ExperimentalDepthOfField34.enabled = false;
      this.ExperimentalSSAOEffect.enabled = false;
      this.BloomEffect.enabled = true;
    }
    else
    {
      this.ExperimentalBloomAndLensFlares.enabled = false;
      this.ExperimentalDepthOfField34.enabled = false;
      this.ExperimentalSSAOEffect.enabled = false;
      this.BloomEffect.enabled = false;
    }
  }

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
      for (int index = 1; index < this.StudentManager.Students.Length; ++index)
      {
        StudentScript student = this.StudentManager.Students[index];
        if ((Object) student != (Object) null)
        {
          student.MyRenderer.materials[0].shader = this.NewBodyShader;
          student.MyRenderer.materials[1].shader = this.NewBodyShader;
          this.AdjustRimLight(student.MyRenderer.materials[0]);
          this.AdjustRimLight(student.MyRenderer.materials[1]);
          if (student.MyRenderer.materials.Length > 2)
          {
            student.MyRenderer.materials[2].shader = this.NewBodyShader;
            this.AdjustRimLight(student.MyRenderer.materials[2]);
          }
          if (!student.Male)
          {
            if (!student.Teacher)
            {
              if ((Object) student.Cosmetic.FemaleHairRenderers[student.Cosmetic.Hairstyle] != (Object) null)
              {
                if (student.Cosmetic.FemaleHairRenderers[student.Cosmetic.Hairstyle].materials.Length == 1)
                {
                  student.Cosmetic.FemaleHairRenderers[student.Cosmetic.Hairstyle].material.shader = this.NewBodyShader;
                  this.AdjustRimLight(student.Cosmetic.FemaleHairRenderers[student.Cosmetic.Hairstyle].material);
                }
                else
                {
                  student.Cosmetic.FemaleHairRenderers[student.Cosmetic.Hairstyle].materials[0].shader = this.NewBodyShader;
                  student.Cosmetic.FemaleHairRenderers[student.Cosmetic.Hairstyle].materials[1].shader = this.NewBodyShader;
                  this.AdjustRimLight(student.Cosmetic.FemaleHairRenderers[student.Cosmetic.Hairstyle].materials[0]);
                  this.AdjustRimLight(student.Cosmetic.FemaleHairRenderers[student.Cosmetic.Hairstyle].materials[1]);
                }
              }
              if (student.Cosmetic.Accessory > 0 && (Object) student.Cosmetic.FemaleAccessories[student.Cosmetic.Accessory].GetComponent<Renderer>() != (Object) null)
              {
                student.Cosmetic.FemaleAccessories[student.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = this.NewBodyShader;
                this.AdjustRimLight(student.Cosmetic.FemaleAccessories[student.Cosmetic.Accessory].GetComponent<Renderer>().material);
              }
              if (student.Club == ClubType.Bully)
              {
                student.Cosmetic.Bookbag.GetComponent<Renderer>().material.shader = this.NewHairShader;
                student.Cosmetic.LeftWristband.GetComponent<Renderer>().material.shader = this.NewHairShader;
                student.Cosmetic.RightWristband.GetComponent<Renderer>().material.shader = this.NewHairShader;
                student.Cosmetic.HoodieRenderer.material.shader = this.NewHairShader;
              }
              student.Cosmetic.RightStockings[0].GetComponent<Renderer>().material.shader = this.NewHairShader;
              student.Cosmetic.LeftStockings[0].GetComponent<Renderer>().material.shader = this.NewHairShader;
              if (student.Club == ClubType.Council)
              {
                student.Cosmetic.TurtleEyewearRenderer.material.shader = this.NewHairShader;
                student.Cosmetic.ScarfRenderer.material.shader = this.NewHairShader;
              }
            }
            else
            {
              student.Cosmetic.TeacherHairRenderers[student.Cosmetic.Hairstyle].material.shader = this.NewBodyShader;
              if (student.Cosmetic.Accessory > 0)
                student.Cosmetic.TeacherAccessories[student.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = this.NewHairShader;
              this.AdjustRimLight(student.Cosmetic.TeacherHairRenderers[student.Cosmetic.Hairstyle].material);
              student.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0.0f);
              student.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0.0f);
            }
          }
          else
          {
            if (student.Cosmetic.Hairstyle > 0)
            {
              if (student.Cosmetic.MaleHairRenderers[student.Cosmetic.Hairstyle].materials.Length == 1)
              {
                student.Cosmetic.MaleHairRenderers[student.Cosmetic.Hairstyle].material.shader = this.NewBodyShader;
                this.AdjustRimLight(student.Cosmetic.MaleHairRenderers[student.Cosmetic.Hairstyle].material);
              }
              else
              {
                student.Cosmetic.MaleHairRenderers[student.Cosmetic.Hairstyle].materials[0].shader = this.NewBodyShader;
                student.Cosmetic.MaleHairRenderers[student.Cosmetic.Hairstyle].materials[1].shader = this.NewBodyShader;
                this.AdjustRimLight(student.Cosmetic.MaleHairRenderers[student.Cosmetic.Hairstyle].materials[0]);
                this.AdjustRimLight(student.Cosmetic.MaleHairRenderers[student.Cosmetic.Hairstyle].materials[1]);
              }
            }
            if (student.Cosmetic.Accessory > 0)
            {
              Renderer component = student.Cosmetic.MaleAccessories[student.Cosmetic.Accessory].GetComponent<Renderer>();
              if ((Object) component != (Object) null)
              {
                component.material.shader = this.NewBodyShader;
                this.AdjustRimLight(component.material);
              }
            }
          }
          if (!student.Teacher && student.Cosmetic.Club > ClubType.None && student.Cosmetic.Club != ClubType.Council && student.Cosmetic.Club != ClubType.Bully && student.Cosmetic.Club != ClubType.Delinquent && (Object) student.Cosmetic.ClubAccessories[(int) student.Cosmetic.Club] != (Object) null)
          {
            Renderer component = student.Cosmetic.ClubAccessories[(int) student.Cosmetic.Club].GetComponent<Renderer>();
            if ((Object) component != (Object) null)
            {
              component.material.shader = this.NewBodyShader;
              this.AdjustRimLight(component.material);
            }
          }
          if (student.Cosmetic.EyewearID > 0)
            student.Cosmetic.Eyewear[student.Cosmetic.EyewearID].GetComponent<Renderer>().material.shader = this.NewHairShader;
          student.SmartPhone.GetComponent<Renderer>().material.shader = this.NewHairShader;
          student.Armband.GetComponent<Renderer>().material.shader = this.NewHairShader;
          if ((Object) student.ApronAttacher.newRenderer != (Object) null)
            student.ApronAttacher.newRenderer.material.shader = this.NewHairShader;
        }
      }
      this.UpdateYandereChan();
      this.Nemesis.Cosmetic.MyRenderer.materials[0].shader = this.NewBodyShader;
      this.Nemesis.Cosmetic.MyRenderer.materials[1].shader = this.NewBodyShader;
      this.Nemesis.Cosmetic.MyRenderer.materials[2].shader = this.NewBodyShader;
      this.Nemesis.NemesisHair.GetComponent<Renderer>().material.shader = this.NewBodyShader;
      this.AdjustRimLight(this.Nemesis.Cosmetic.MyRenderer.materials[0]);
      this.AdjustRimLight(this.Nemesis.Cosmetic.MyRenderer.materials[1]);
      this.AdjustRimLight(this.Nemesis.Cosmetic.MyRenderer.materials[2]);
      this.AdjustRimLight(this.Nemesis.NemesisHair.GetComponent<Renderer>().material);
    }
    this.UpdateStockings();
  }

  public void UpdateYandereChan()
  {
    this.Yandere.MyRenderer.materials[0].shader = this.NewBodyShader;
    this.Yandere.MyRenderer.materials[1].shader = this.NewBodyShader;
    this.Yandere.MyRenderer.materials[2].shader = this.NewBodyShader;
    this.AdjustRimLight(this.Yandere.MyRenderer.materials[0]);
    this.AdjustRimLight(this.Yandere.MyRenderer.materials[1]);
    this.AdjustRimLight(this.Yandere.MyRenderer.materials[2]);
    for (int index = 1; index < this.Yandere.Hairstyles.Length; ++index)
    {
      Renderer component = this.Yandere.Hairstyles[index].GetComponent<Renderer>();
      if ((Object) component != (Object) null)
      {
        this.Yandere.EightiesPonytailRenderer.material.shader = this.NewBodyShader;
        this.YandereHairRenderer.material.shader = this.NewBodyShader;
        component.material.shader = this.NewBodyShader;
        this.AdjustRimLight(this.YandereHairRenderer.material);
        this.AdjustRimLight(component.material);
      }
    }
  }

  public void UpdateObscurance()
  {
    if (this.DoNothing)
      return;
    this.Obscurance.enabled = !OptionGlobals.DisableObscurance;
  }

  public void AdjustRimLight(Material mat)
  {
    if (!this.DoNothing)
    {
      mat.SetFloat("_RimLightIntensity", 5f);
      mat.SetFloat("_RimCrisp", 0.5f);
      mat.SetFloat("_RimAdditive", 0.5f);
      mat.SetFloat("_BlendAmount", 0.0f);
    }
    this.UpdateStockings();
  }

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
    if (!((Object) this.Tint != (Object) null))
      return;
    this.Tint.enabled = !OptionGlobals.DisableTint;
  }

  public void UpdateCameraPosition()
  {
    if (!this.SchoolScene)
      return;
    if (OptionGlobals.CameraPosition == 0)
      this.StudentManager.Yandere.Zoom.OverShoulder = false;
    else if (OptionGlobals.CameraPosition == 1)
    {
      this.StudentManager.Yandere.Zoom.OverShoulder = true;
      this.StudentManager.Yandere.Zoom.midOffset = 0.25f;
    }
    else
    {
      this.StudentManager.Yandere.Zoom.OverShoulder = true;
      this.StudentManager.Yandere.Zoom.midOffset = -0.25f;
    }
  }
}
