// Decompiled with JetBrains decompiler
// Type: AmplifyMotionEffectBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using AmplifyMotion;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

[RequireComponent(typeof (Camera))]
[AddComponentMenu("")]
public class AmplifyMotionEffectBase : MonoBehaviour
{
  [Header("Motion Blur")]
  public AmplifyMotion.Quality QualityLevel = AmplifyMotion.Quality.Standard;
  public int QualitySteps = 1;
  public float MotionScale = 3f;
  public float CameraMotionMult = 1f;
  public float MinVelocity = 1f;
  public float MaxVelocity = 10f;
  public float DepthThreshold = 0.01f;
  public bool Noise;
  [Header("Camera")]
  public Camera[] OverlayCameras = new Camera[0];
  public LayerMask CullingMask = (LayerMask) -1;
  [Header("Objects")]
  public bool AutoRegisterObjs = true;
  public float MinResetDeltaDist = 1000f;
  [NonSerialized]
  public float MinResetDeltaDistSqr;
  public int ResetFrameDelay = 1;
  [Header("Low-Level")]
  [FormerlySerializedAs("workerThreads")]
  public int WorkerThreads;
  public bool SystemThreadPool;
  public bool ForceCPUOnly;
  public bool DebugMode;
  private Camera m_camera;
  private bool m_starting = true;
  private int m_width;
  private int m_height;
  private RenderTexture m_motionRT;
  private Material m_blurMaterial;
  private Material m_solidVectorsMaterial;
  private Material m_skinnedVectorsMaterial;
  private Material m_clothVectorsMaterial;
  private Material m_reprojectionMaterial;
  private Material m_combineMaterial;
  private Material m_dilationMaterial;
  private Material m_depthMaterial;
  private Material m_debugMaterial;
  private Dictionary<Camera, AmplifyMotionCamera> m_linkedCameras = new Dictionary<Camera, AmplifyMotionCamera>();
  internal Camera[] m_linkedCameraKeys;
  internal AmplifyMotionCamera[] m_linkedCameraValues;
  internal bool m_linkedCamerasChanged = true;
  private AmplifyMotionPostProcess m_currentPostProcess;
  private int m_globalObjectId = 1;
  private float m_deltaTime;
  private float m_fixedDeltaTime;
  private float m_motionScaleNorm;
  private float m_fixedMotionScaleNorm;
  private AmplifyMotion.Quality m_qualityLevel;
  private AmplifyMotionCamera m_baseCamera;
  private WorkerThreadPool m_workerThreadPool;
  public static Dictionary<GameObject, AmplifyMotionObjectBase> m_activeObjects = new Dictionary<GameObject, AmplifyMotionObjectBase>();
  public static Dictionary<Camera, AmplifyMotionCamera> m_activeCameras = new Dictionary<Camera, AmplifyMotionCamera>();
  private static bool m_isD3D = false;
  private bool m_canUseGPU;
  private const CameraEvent m_updateCBEvent = CameraEvent.BeforeImageEffectsOpaque;
  private CommandBuffer m_updateCB;
  private const CameraEvent m_fixedUpdateCBEvent = CameraEvent.BeforeImageEffectsOpaque;
  private CommandBuffer m_fixedUpdateCB;
  private static bool m_ignoreMotionScaleWarning = false;
  private static AmplifyMotionEffectBase m_firstInstance = (AmplifyMotionEffectBase) null;

  [Obsolete("workerThreads is deprecated, please use WorkerThreads instead.")]
  public int workerThreads
  {
    get => this.WorkerThreads;
    set => this.WorkerThreads = value;
  }

  internal Material ReprojectionMaterial => this.m_reprojectionMaterial;

  internal Material SolidVectorsMaterial => this.m_solidVectorsMaterial;

  internal Material SkinnedVectorsMaterial => this.m_skinnedVectorsMaterial;

  internal Material ClothVectorsMaterial => this.m_clothVectorsMaterial;

  internal RenderTexture MotionRenderTexture => this.m_motionRT;

  public Dictionary<Camera, AmplifyMotionCamera> LinkedCameras => this.m_linkedCameras;

  internal float MotionScaleNorm => this.m_motionScaleNorm;

  internal float FixedMotionScaleNorm => this.m_fixedMotionScaleNorm;

  public AmplifyMotionCamera BaseCamera => this.m_baseCamera;

  internal WorkerThreadPool WorkerPool => this.m_workerThreadPool;

  public static bool IsD3D => AmplifyMotionEffectBase.m_isD3D;

  public bool CanUseGPU => this.m_canUseGPU;

  public static bool IgnoreMotionScaleWarning => AmplifyMotionEffectBase.m_ignoreMotionScaleWarning;

  public static AmplifyMotionEffectBase FirstInstance => AmplifyMotionEffectBase.m_firstInstance;

  public static AmplifyMotionEffectBase Instance => AmplifyMotionEffectBase.m_firstInstance;

  private void Awake()
  {
    if ((UnityEngine.Object) AmplifyMotionEffectBase.m_firstInstance == (UnityEngine.Object) null)
      AmplifyMotionEffectBase.m_firstInstance = this;
    AmplifyMotionEffectBase.m_isD3D = SystemInfo.graphicsDeviceVersion.StartsWith("Direct3D");
    this.m_globalObjectId = 1;
    this.m_width = this.m_height = 0;
    if (this.ForceCPUOnly)
      this.m_canUseGPU = false;
    else
      this.m_canUseGPU = SystemInfo.graphicsShaderLevel >= 30 & SystemInfo.SupportsTextureFormat(TextureFormat.RHalf) & SystemInfo.SupportsTextureFormat(TextureFormat.RGHalf) & SystemInfo.SupportsTextureFormat(TextureFormat.RGBAHalf) & SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBFloat);
  }

  internal void ResetObjectId() => this.m_globalObjectId = 1;

  internal int GenerateObjectId(GameObject obj)
  {
    if (obj.isStatic)
      return 0;
    ++this.m_globalObjectId;
    if (this.m_globalObjectId > 254)
      this.m_globalObjectId = 1;
    return this.m_globalObjectId;
  }

  private void SafeDestroyMaterial(ref Material mat)
  {
    if (!((UnityEngine.Object) mat != (UnityEngine.Object) null))
      return;
    UnityEngine.Object.DestroyImmediate((UnityEngine.Object) mat);
    mat = (Material) null;
  }

  private bool CheckMaterialAndShader(Material material, string name)
  {
    bool flag = true;
    if ((UnityEngine.Object) material == (UnityEngine.Object) null || (UnityEngine.Object) material.shader == (UnityEngine.Object) null)
    {
      Debug.LogWarning((object) ("[AmplifyMotion] Error creating " + name + " material"));
      flag = false;
    }
    else if (!material.shader.isSupported)
    {
      Debug.LogWarning((object) ("[AmplifyMotion] " + name + " shader not supported on this platform"));
      flag = false;
    }
    return flag;
  }

  private void DestroyMaterials()
  {
    this.SafeDestroyMaterial(ref this.m_blurMaterial);
    this.SafeDestroyMaterial(ref this.m_solidVectorsMaterial);
    this.SafeDestroyMaterial(ref this.m_skinnedVectorsMaterial);
    this.SafeDestroyMaterial(ref this.m_clothVectorsMaterial);
    this.SafeDestroyMaterial(ref this.m_reprojectionMaterial);
    this.SafeDestroyMaterial(ref this.m_combineMaterial);
    this.SafeDestroyMaterial(ref this.m_dilationMaterial);
    this.SafeDestroyMaterial(ref this.m_depthMaterial);
    this.SafeDestroyMaterial(ref this.m_debugMaterial);
  }

  private bool CreateMaterials()
  {
    this.DestroyMaterials();
    string name1 = "Hidden/Amplify Motion/MotionBlurSM" + (SystemInfo.graphicsShaderLevel >= 30 ? 3 : 2).ToString();
    string name2 = "Hidden/Amplify Motion/SolidVectors";
    string name3 = "Hidden/Amplify Motion/SkinnedVectors";
    string name4 = "Hidden/Amplify Motion/ClothVectors";
    string name5 = "Hidden/Amplify Motion/ReprojectionVectors";
    string name6 = "Hidden/Amplify Motion/Combine";
    string name7 = "Hidden/Amplify Motion/Dilation";
    string name8 = "Hidden/Amplify Motion/Depth";
    string name9 = "Hidden/Amplify Motion/Debug";
    try
    {
      Material material1 = new Material(Shader.Find(name1));
      material1.hideFlags = HideFlags.DontSave;
      this.m_blurMaterial = material1;
      Material material2 = new Material(Shader.Find(name2));
      material2.hideFlags = HideFlags.DontSave;
      this.m_solidVectorsMaterial = material2;
      Material material3 = new Material(Shader.Find(name3));
      material3.hideFlags = HideFlags.DontSave;
      this.m_skinnedVectorsMaterial = material3;
      Material material4 = new Material(Shader.Find(name4));
      material4.hideFlags = HideFlags.DontSave;
      this.m_clothVectorsMaterial = material4;
      Material material5 = new Material(Shader.Find(name5));
      material5.hideFlags = HideFlags.DontSave;
      this.m_reprojectionMaterial = material5;
      Material material6 = new Material(Shader.Find(name6));
      material6.hideFlags = HideFlags.DontSave;
      this.m_combineMaterial = material6;
      Material material7 = new Material(Shader.Find(name7));
      material7.hideFlags = HideFlags.DontSave;
      this.m_dilationMaterial = material7;
      Material material8 = new Material(Shader.Find(name8));
      material8.hideFlags = HideFlags.DontSave;
      this.m_depthMaterial = material8;
      Material material9 = new Material(Shader.Find(name9));
      material9.hideFlags = HideFlags.DontSave;
      this.m_debugMaterial = material9;
    }
    catch (Exception ex)
    {
    }
    return (((((((!this.CheckMaterialAndShader(this.m_blurMaterial, name1) ? 0 : (this.CheckMaterialAndShader(this.m_solidVectorsMaterial, name2) ? 1 : 0)) == 0 ? 0 : (this.CheckMaterialAndShader(this.m_skinnedVectorsMaterial, name3) ? 1 : 0)) == 0 ? 0 : (this.CheckMaterialAndShader(this.m_clothVectorsMaterial, name4) ? 1 : 0)) == 0 ? 0 : (this.CheckMaterialAndShader(this.m_reprojectionMaterial, name5) ? 1 : 0)) == 0 ? 0 : (this.CheckMaterialAndShader(this.m_combineMaterial, name6) ? 1 : 0)) == 0 ? 0 : (this.CheckMaterialAndShader(this.m_dilationMaterial, name7) ? 1 : 0)) == 0 ? 0 : (this.CheckMaterialAndShader(this.m_depthMaterial, name8) ? 1 : 0)) != 0 && this.CheckMaterialAndShader(this.m_debugMaterial, name9);
  }

  private RenderTexture CreateRenderTexture(
    string name,
    int depth,
    RenderTextureFormat fmt,
    RenderTextureReadWrite rw,
    FilterMode fm)
  {
    RenderTexture renderTexture = new RenderTexture(this.m_width, this.m_height, depth, fmt, rw);
    renderTexture.hideFlags = HideFlags.DontSave;
    renderTexture.name = name;
    renderTexture.wrapMode = TextureWrapMode.Clamp;
    renderTexture.filterMode = fm;
    renderTexture.Create();
    return renderTexture;
  }

  private void SafeDestroyRenderTexture(ref RenderTexture rt)
  {
    if (!((UnityEngine.Object) rt != (UnityEngine.Object) null))
      return;
    RenderTexture.active = (RenderTexture) null;
    rt.Release();
    UnityEngine.Object.DestroyImmediate((UnityEngine.Object) rt);
    rt = (RenderTexture) null;
  }

  private void SafeDestroyTexture(ref Texture tex)
  {
    if (!((UnityEngine.Object) tex != (UnityEngine.Object) null))
      return;
    UnityEngine.Object.DestroyImmediate((UnityEngine.Object) tex);
    tex = (Texture) null;
  }

  private void DestroyRenderTextures()
  {
    RenderTexture.active = (RenderTexture) null;
    this.SafeDestroyRenderTexture(ref this.m_motionRT);
  }

  private void UpdateRenderTextures(bool qualityChanged)
  {
    int num1 = Mathf.Max(Mathf.FloorToInt((float) this.m_camera.pixelWidth + 0.5f), 1);
    int num2 = Mathf.Max(Mathf.FloorToInt((float) this.m_camera.pixelHeight + 0.5f), 1);
    if (this.QualityLevel == AmplifyMotion.Quality.Mobile)
    {
      num1 /= 2;
      num2 /= 2;
    }
    if (this.m_width != num1 || this.m_height != num2)
    {
      this.m_width = num1;
      this.m_height = num2;
      this.DestroyRenderTextures();
    }
    if (!((UnityEngine.Object) this.m_motionRT == (UnityEngine.Object) null))
      return;
    this.m_motionRT = this.CreateRenderTexture("AM-MotionVectors", 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear, FilterMode.Point);
  }

  public bool CheckSupport()
  {
    if (SystemInfo.supportsImageEffects)
      return true;
    Debug.LogError((object) "[AmplifyMotion] Initialization failed. This plugin requires support for Image Effects and Render Textures.");
    return false;
  }

  private void InitializeThreadPool()
  {
    if (this.WorkerThreads <= 0)
      this.WorkerThreads = Mathf.Max(Environment.ProcessorCount / 2, 1);
    this.m_workerThreadPool = new WorkerThreadPool();
    this.m_workerThreadPool.InitializeAsyncUpdateThreads(this.WorkerThreads, this.SystemThreadPool);
  }

  private void ShutdownThreadPool()
  {
    if (this.m_workerThreadPool == null)
      return;
    this.m_workerThreadPool.FinalizeAsyncUpdateThreads();
    this.m_workerThreadPool = (WorkerThreadPool) null;
  }

  private void InitializeCommandBuffers()
  {
    this.ShutdownCommandBuffers();
    this.m_updateCB = new CommandBuffer();
    this.m_updateCB.name = "AmplifyMotion.Update";
    this.m_camera.AddCommandBuffer(CameraEvent.BeforeImageEffectsOpaque, this.m_updateCB);
    this.m_fixedUpdateCB = new CommandBuffer();
    this.m_fixedUpdateCB.name = "AmplifyMotion.FixedUpdate";
    this.m_camera.AddCommandBuffer(CameraEvent.BeforeImageEffectsOpaque, this.m_fixedUpdateCB);
  }

  private void ShutdownCommandBuffers()
  {
    if (this.m_updateCB != null)
    {
      this.m_camera.RemoveCommandBuffer(CameraEvent.BeforeImageEffectsOpaque, this.m_updateCB);
      this.m_updateCB.Release();
      this.m_updateCB = (CommandBuffer) null;
    }
    if (this.m_fixedUpdateCB == null)
      return;
    this.m_camera.RemoveCommandBuffer(CameraEvent.BeforeImageEffectsOpaque, this.m_fixedUpdateCB);
    this.m_fixedUpdateCB.Release();
    this.m_fixedUpdateCB = (CommandBuffer) null;
  }

  private void OnEnable()
  {
    this.m_camera = this.GetComponent<Camera>();
    if (!this.CheckSupport())
    {
      this.enabled = false;
    }
    else
    {
      this.InitializeThreadPool();
      this.m_starting = true;
      if (!this.CreateMaterials())
      {
        Debug.LogError((object) "[AmplifyMotion] Failed loading or compiling necessary shaders. Please try reinstalling Amplify Motion or contact support@amplify.pt");
        this.enabled = false;
      }
      else
      {
        if (this.AutoRegisterObjs)
          this.UpdateActiveObjects();
        this.InitializeCameras();
        this.InitializeCommandBuffers();
        this.UpdateRenderTextures(true);
        this.m_linkedCameras.TryGetValue(this.m_camera, out this.m_baseCamera);
        if ((UnityEngine.Object) this.m_baseCamera == (UnityEngine.Object) null)
        {
          Debug.LogError((object) "[AmplifyMotion] Failed setting up Base Camera. Please contact support@amplify.pt");
          this.enabled = false;
        }
        else
        {
          if ((UnityEngine.Object) this.m_currentPostProcess != (UnityEngine.Object) null)
            this.m_currentPostProcess.enabled = true;
          this.m_qualityLevel = this.QualityLevel;
        }
      }
    }
  }

  private void OnDisable()
  {
    if ((UnityEngine.Object) this.m_currentPostProcess != (UnityEngine.Object) null)
      this.m_currentPostProcess.enabled = false;
    this.ShutdownCommandBuffers();
    this.ShutdownThreadPool();
  }

  private void Start() => this.UpdatePostProcess();

  internal void RemoveCamera(Camera reference) => this.m_linkedCameras.Remove(reference);

  private void OnDestroy()
  {
    foreach (AmplifyMotionCamera amplifyMotionCamera in this.m_linkedCameras.Values.ToArray<AmplifyMotionCamera>())
    {
      if ((UnityEngine.Object) amplifyMotionCamera != (UnityEngine.Object) null && (UnityEngine.Object) amplifyMotionCamera.gameObject != (UnityEngine.Object) this.gameObject)
      {
        Camera component = amplifyMotionCamera.GetComponent<Camera>();
        if ((UnityEngine.Object) component != (UnityEngine.Object) null)
          component.targetTexture = (RenderTexture) null;
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) amplifyMotionCamera);
      }
    }
    this.DestroyRenderTextures();
    this.DestroyMaterials();
  }

  private GameObject RecursiveFindCamera(GameObject obj, string auxCameraName)
  {
    GameObject camera = (GameObject) null;
    if (obj.name == auxCameraName)
    {
      camera = obj;
    }
    else
    {
      foreach (Component component in obj.transform)
      {
        camera = this.RecursiveFindCamera(component.gameObject, auxCameraName);
        if ((UnityEngine.Object) camera != (UnityEngine.Object) null)
          break;
      }
    }
    return camera;
  }

  private void InitializeCameras()
  {
    List<Camera> cameraList = new List<Camera>(this.OverlayCameras.Length);
    for (int index = 0; index < this.OverlayCameras.Length; ++index)
    {
      if ((UnityEngine.Object) this.OverlayCameras[index] != (UnityEngine.Object) null)
        cameraList.Add(this.OverlayCameras[index]);
    }
    Camera[] cameraArray = new Camera[cameraList.Count + 1];
    cameraArray[0] = this.m_camera;
    for (int index = 0; index < cameraList.Count; ++index)
      cameraArray[index + 1] = cameraList[index];
    this.m_linkedCameras.Clear();
    for (int index = 0; index < cameraArray.Length; ++index)
    {
      Camera key = cameraArray[index];
      if (!this.m_linkedCameras.ContainsKey(key))
      {
        AmplifyMotionCamera amplifyMotionCamera = key.gameObject.GetComponent<AmplifyMotionCamera>();
        if ((UnityEngine.Object) amplifyMotionCamera != (UnityEngine.Object) null)
        {
          amplifyMotionCamera.enabled = false;
          amplifyMotionCamera.enabled = true;
        }
        else
          amplifyMotionCamera = key.gameObject.AddComponent<AmplifyMotionCamera>();
        amplifyMotionCamera.LinkTo(this, index > 0);
        this.m_linkedCameras.Add(key, amplifyMotionCamera);
        this.m_linkedCamerasChanged = true;
      }
    }
  }

  public void UpdateActiveCameras() => this.InitializeCameras();

  internal static void RegisterCamera(AmplifyMotionCamera cam)
  {
    if (!AmplifyMotionEffectBase.m_activeCameras.ContainsValue(cam))
      AmplifyMotionEffectBase.m_activeCameras.Add(cam.GetComponent<Camera>(), cam);
    foreach (AmplifyMotionObjectBase motionObjectBase in AmplifyMotionEffectBase.m_activeObjects.Values)
      motionObjectBase.RegisterCamera(cam);
  }

  internal static void UnregisterCamera(AmplifyMotionCamera cam)
  {
    foreach (AmplifyMotionObjectBase motionObjectBase in AmplifyMotionEffectBase.m_activeObjects.Values)
      motionObjectBase.UnregisterCamera(cam);
    AmplifyMotionEffectBase.m_activeCameras.Remove(cam.GetComponent<Camera>());
  }

  public void UpdateActiveObjects()
  {
    GameObject[] objectsOfType = UnityEngine.Object.FindObjectsOfType(typeof (GameObject)) as GameObject[];
    for (int index = 0; index < objectsOfType.Length; ++index)
    {
      if (!AmplifyMotionEffectBase.m_activeObjects.ContainsKey(objectsOfType[index]))
        AmplifyMotionEffectBase.TryRegister(objectsOfType[index], true);
    }
  }

  internal static void RegisterObject(AmplifyMotionObjectBase obj)
  {
    AmplifyMotionEffectBase.m_activeObjects.Add(obj.gameObject, obj);
    foreach (AmplifyMotionCamera camera in AmplifyMotionEffectBase.m_activeCameras.Values)
      obj.RegisterCamera(camera);
  }

  internal static void UnregisterObject(AmplifyMotionObjectBase obj)
  {
    foreach (AmplifyMotionCamera camera in AmplifyMotionEffectBase.m_activeCameras.Values)
      obj.UnregisterCamera(camera);
    AmplifyMotionEffectBase.m_activeObjects.Remove(obj.gameObject);
  }

  internal static bool FindValidTag(Material[] materials)
  {
    for (int index = 0; index < materials.Length; ++index)
    {
      Material material = materials[index];
      if ((UnityEngine.Object) material != (UnityEngine.Object) null)
      {
        string tag = material.GetTag("RenderType", false);
        if (tag == "Opaque" || tag == "TransparentCutout")
          return !material.IsKeywordEnabled("_ALPHABLEND_ON") && !material.IsKeywordEnabled("_ALPHAPREMULTIPLY_ON");
      }
    }
    return false;
  }

  internal static bool CanRegister(GameObject gameObj, bool autoReg)
  {
    if (gameObj.isStatic)
      return false;
    Renderer component = gameObj.GetComponent<Renderer>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null || component.sharedMaterials == null || component.isPartOfStaticBatch || !component.enabled || component.shadowCastingMode == ShadowCastingMode.ShadowsOnly || ((object) component).GetType() == typeof (SpriteRenderer) || !AmplifyMotionEffectBase.FindValidTag(component.sharedMaterials))
      return false;
    System.Type type = ((object) component).GetType();
    if (type == typeof (MeshRenderer) || type == typeof (SkinnedMeshRenderer))
      return true;
    if (!(type == typeof (ParticleSystemRenderer)) || autoReg)
      return false;
    ParticleSystemRenderMode renderMode = (component as ParticleSystemRenderer).renderMode;
    return renderMode == ParticleSystemRenderMode.Mesh || renderMode == ParticleSystemRenderMode.Billboard;
  }

  internal static void TryRegister(GameObject gameObj, bool autoReg)
  {
    if (!AmplifyMotionEffectBase.CanRegister(gameObj, autoReg) || !((UnityEngine.Object) gameObj.GetComponent<AmplifyMotionObjectBase>() == (UnityEngine.Object) null))
      return;
    AmplifyMotionObjectBase.ApplyToChildren = false;
    gameObj.AddComponent<AmplifyMotionObjectBase>();
    AmplifyMotionObjectBase.ApplyToChildren = true;
  }

  internal static void TryUnregister(GameObject gameObj)
  {
    AmplifyMotionObjectBase component = gameObj.GetComponent<AmplifyMotionObjectBase>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    UnityEngine.Object.Destroy((UnityEngine.Object) component);
  }

  public void Register(GameObject gameObj)
  {
    if (AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
      return;
    AmplifyMotionEffectBase.TryRegister(gameObj, false);
  }

  public static void RegisterS(GameObject gameObj)
  {
    if (AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
      return;
    AmplifyMotionEffectBase.TryRegister(gameObj, false);
  }

  public void RegisterRecursively(GameObject gameObj)
  {
    if (!AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
      AmplifyMotionEffectBase.TryRegister(gameObj, false);
    foreach (Component component in gameObj.transform)
      this.RegisterRecursively(component.gameObject);
  }

  public static void RegisterRecursivelyS(GameObject gameObj)
  {
    if (!AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
      AmplifyMotionEffectBase.TryRegister(gameObj, false);
    foreach (Component component in gameObj.transform)
      AmplifyMotionEffectBase.RegisterRecursivelyS(component.gameObject);
  }

  public void Unregister(GameObject gameObj)
  {
    if (!AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
      return;
    AmplifyMotionEffectBase.TryUnregister(gameObj);
  }

  public static void UnregisterS(GameObject gameObj)
  {
    if (!AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
      return;
    AmplifyMotionEffectBase.TryUnregister(gameObj);
  }

  public void UnregisterRecursively(GameObject gameObj)
  {
    if (AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
      AmplifyMotionEffectBase.TryUnregister(gameObj);
    foreach (Component component in gameObj.transform)
      this.UnregisterRecursively(component.gameObject);
  }

  public static void UnregisterRecursivelyS(GameObject gameObj)
  {
    if (AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
      AmplifyMotionEffectBase.TryUnregister(gameObj);
    foreach (Component component in gameObj.transform)
      AmplifyMotionEffectBase.UnregisterRecursivelyS(component.gameObject);
  }

  private void UpdatePostProcess()
  {
    Camera camera = (Camera) null;
    float num = float.MinValue;
    if (this.m_linkedCamerasChanged)
      this.UpdateLinkedCameras();
    for (int index = 0; index < this.m_linkedCameraKeys.Length; ++index)
    {
      if ((UnityEngine.Object) this.m_linkedCameraKeys[index] != (UnityEngine.Object) null && this.m_linkedCameraKeys[index].isActiveAndEnabled && (double) this.m_linkedCameraKeys[index].depth > (double) num)
      {
        camera = this.m_linkedCameraKeys[index];
        num = this.m_linkedCameraKeys[index].depth;
      }
    }
    if ((UnityEngine.Object) this.m_currentPostProcess != (UnityEngine.Object) null && (UnityEngine.Object) this.m_currentPostProcess.gameObject != (UnityEngine.Object) camera.gameObject)
    {
      UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.m_currentPostProcess);
      this.m_currentPostProcess = (AmplifyMotionPostProcess) null;
    }
    if (!((UnityEngine.Object) this.m_currentPostProcess == (UnityEngine.Object) null) || !((UnityEngine.Object) camera != (UnityEngine.Object) null) || !((UnityEngine.Object) camera != (UnityEngine.Object) this.m_camera))
      return;
    AmplifyMotionPostProcess[] components = this.gameObject.GetComponents<AmplifyMotionPostProcess>();
    if (components != null && components.Length != 0)
    {
      for (int index = 0; index < components.Length; ++index)
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) components[index]);
    }
    this.m_currentPostProcess = camera.gameObject.AddComponent<AmplifyMotionPostProcess>();
    this.m_currentPostProcess.Instance = this;
  }

  private void LateUpdate()
  {
    if (this.m_baseCamera.AutoStep)
    {
      float num = Application.isPlaying ? Time.unscaledDeltaTime : Time.fixedDeltaTime;
      float fixedDeltaTime = Time.fixedDeltaTime;
      this.m_deltaTime = (double) num > 1.40129846432482E-45 ? num : this.m_deltaTime;
      this.m_fixedDeltaTime = (double) num > 1.40129846432482E-45 ? fixedDeltaTime : this.m_fixedDeltaTime;
    }
    this.QualitySteps = Mathf.Clamp(this.QualitySteps, 0, 16);
    this.MotionScale = Mathf.Max(this.MotionScale, 0.0f);
    this.MinVelocity = Mathf.Min(this.MinVelocity, this.MaxVelocity);
    this.DepthThreshold = Mathf.Max(this.DepthThreshold, 0.0f);
    this.MinResetDeltaDist = Mathf.Max(this.MinResetDeltaDist, 0.0f);
    this.MinResetDeltaDistSqr = this.MinResetDeltaDist * this.MinResetDeltaDist;
    this.ResetFrameDelay = Mathf.Max(this.ResetFrameDelay, 0);
    this.UpdatePostProcess();
  }

  public void StopAutoStep()
  {
    foreach (AmplifyMotionCamera amplifyMotionCamera in this.m_linkedCameras.Values)
      amplifyMotionCamera.StopAutoStep();
  }

  public void StartAutoStep()
  {
    foreach (AmplifyMotionCamera amplifyMotionCamera in this.m_linkedCameras.Values)
      amplifyMotionCamera.StartAutoStep();
  }

  public void Step(float delta)
  {
    this.m_deltaTime = delta;
    this.m_fixedDeltaTime = delta;
    foreach (AmplifyMotionCamera amplifyMotionCamera in this.m_linkedCameras.Values)
      amplifyMotionCamera.Step();
  }

  private void UpdateLinkedCameras()
  {
    Dictionary<Camera, AmplifyMotionCamera>.KeyCollection keys = this.m_linkedCameras.Keys;
    Dictionary<Camera, AmplifyMotionCamera>.ValueCollection values = this.m_linkedCameras.Values;
    if (this.m_linkedCameraKeys == null || keys.Count != this.m_linkedCameraKeys.Length)
      this.m_linkedCameraKeys = new Camera[keys.Count];
    if (this.m_linkedCameraValues == null || values.Count != this.m_linkedCameraValues.Length)
      this.m_linkedCameraValues = new AmplifyMotionCamera[values.Count];
    keys.CopyTo(this.m_linkedCameraKeys, 0);
    values.CopyTo(this.m_linkedCameraValues, 0);
    this.m_linkedCamerasChanged = false;
  }

  private void FixedUpdate()
  {
    if (!this.m_camera.enabled)
      return;
    if (this.m_linkedCamerasChanged)
      this.UpdateLinkedCameras();
    this.m_fixedUpdateCB.Clear();
    for (int index = 0; index < this.m_linkedCameraValues.Length; ++index)
    {
      if ((UnityEngine.Object) this.m_linkedCameraValues[index] != (UnityEngine.Object) null && this.m_linkedCameraValues[index].isActiveAndEnabled)
        this.m_linkedCameraValues[index].FixedUpdateTransform(this, this.m_fixedUpdateCB);
    }
  }

  private void OnPreRender()
  {
    if (!this.m_camera.enabled || Time.frameCount != 1 && (double) Mathf.Abs(Time.unscaledDeltaTime) <= 1.40129846432482E-45)
      return;
    if (this.m_linkedCamerasChanged)
      this.UpdateLinkedCameras();
    this.m_updateCB.Clear();
    for (int index = 0; index < this.m_linkedCameraValues.Length; ++index)
    {
      if ((UnityEngine.Object) this.m_linkedCameraValues[index] != (UnityEngine.Object) null && this.m_linkedCameraValues[index].isActiveAndEnabled)
        this.m_linkedCameraValues[index].UpdateTransform(this, this.m_updateCB);
    }
  }

  private void OnPostRender()
  {
    bool qualityChanged = this.QualityLevel != this.m_qualityLevel;
    this.m_qualityLevel = this.QualityLevel;
    this.UpdateRenderTextures(qualityChanged);
    this.ResetObjectId();
    bool flag = (double) this.CameraMotionMult > 1.40129846432482E-45;
    bool clearColor = !flag || this.m_starting;
    float num1 = (double) this.DepthThreshold > 1.40129846432482E-45 ? 1f / this.DepthThreshold : float.MaxValue;
    this.m_motionScaleNorm = (double) this.m_deltaTime >= 1.40129846432482E-45 ? this.MotionScale * (1f / this.m_deltaTime) : 0.0f;
    this.m_fixedMotionScaleNorm = (double) this.m_fixedDeltaTime >= 1.40129846432482E-45 ? this.MotionScale * (1f / this.m_fixedDeltaTime) : 0.0f;
    float scale1 = !this.m_starting ? this.m_motionScaleNorm : 0.0f;
    float fixedScale = !this.m_starting ? this.m_fixedMotionScaleNorm : 0.0f;
    Shader.SetGlobalFloat("_AM_MIN_VELOCITY", this.MinVelocity);
    Shader.SetGlobalFloat("_AM_MAX_VELOCITY", this.MaxVelocity);
    Shader.SetGlobalFloat("_AM_RCP_TOTAL_VELOCITY", (float) (1.0 / ((double) this.MaxVelocity - (double) this.MinVelocity)));
    Shader.SetGlobalVector("_AM_DEPTH_THRESHOLD", (Vector4) new Vector2(this.DepthThreshold, num1));
    this.m_motionRT.DiscardContents();
    this.m_baseCamera.PreRenderVectors(this.m_motionRT, clearColor, num1);
    for (int index = 0; index < this.m_linkedCameraValues.Length; ++index)
    {
      AmplifyMotionCamera linkedCameraValue = this.m_linkedCameraValues[index];
      if ((UnityEngine.Object) linkedCameraValue != (UnityEngine.Object) null && linkedCameraValue.Overlay && linkedCameraValue.isActiveAndEnabled)
      {
        linkedCameraValue.PreRenderVectors(this.m_motionRT, clearColor, num1);
        linkedCameraValue.RenderVectors(scale1, fixedScale, this.QualityLevel);
      }
    }
    if (flag)
    {
      float num2 = (double) this.m_deltaTime >= 1.40129846432482E-45 ? (float) ((double) this.MotionScale * (double) this.CameraMotionMult * (1.0 / (double) this.m_deltaTime)) : 0.0f;
      float scale2 = !this.m_starting ? num2 : 0.0f;
      this.m_motionRT.DiscardContents();
      this.m_baseCamera.RenderReprojectionVectors(this.m_motionRT, scale2);
    }
    this.m_baseCamera.RenderVectors(scale1, fixedScale, this.QualityLevel);
    for (int index = 0; index < this.m_linkedCameraValues.Length; ++index)
    {
      AmplifyMotionCamera linkedCameraValue = this.m_linkedCameraValues[index];
      if ((UnityEngine.Object) linkedCameraValue != (UnityEngine.Object) null && linkedCameraValue.Overlay && linkedCameraValue.isActiveAndEnabled)
        linkedCameraValue.RenderVectors(scale1, fixedScale, this.QualityLevel);
    }
    this.m_starting = false;
  }

  private void ApplyMotionBlur(RenderTexture source, RenderTexture destination, Vector4 blurStep)
  {
    bool flag = this.QualityLevel == AmplifyMotion.Quality.Mobile;
    int pass = (int) (this.QualityLevel + (this.Noise ? 4 : 0));
    RenderTexture renderTexture1 = (RenderTexture) null;
    if (flag)
    {
      renderTexture1 = RenderTexture.GetTemporary(this.m_width, this.m_height, 0, RenderTextureFormat.ARGB32);
      renderTexture1.name = "AM-DepthTemp";
      renderTexture1.wrapMode = TextureWrapMode.Clamp;
      renderTexture1.filterMode = FilterMode.Point;
    }
    RenderTexture temporary1 = RenderTexture.GetTemporary(this.m_width, this.m_height, 0, source.format);
    temporary1.name = "AM-CombinedTemp";
    temporary1.wrapMode = TextureWrapMode.Clamp;
    temporary1.filterMode = FilterMode.Point;
    temporary1.DiscardContents();
    this.m_combineMaterial.SetTexture("_MotionTex", (Texture) this.m_motionRT);
    source.filterMode = FilterMode.Point;
    Graphics.Blit((Texture) source, temporary1, this.m_combineMaterial, 0);
    this.m_blurMaterial.SetTexture("_MotionTex", (Texture) this.m_motionRT);
    if (flag)
    {
      Graphics.Blit((Texture) null, renderTexture1, this.m_depthMaterial, 0);
      this.m_blurMaterial.SetTexture("_DepthTex", (Texture) renderTexture1);
    }
    if (this.QualitySteps > 1)
    {
      RenderTexture temporary2 = RenderTexture.GetTemporary(this.m_width, this.m_height, 0, source.format);
      temporary2.name = "AM-CombinedTemp2";
      temporary2.filterMode = FilterMode.Point;
      float num1 = 1f / (float) this.QualitySteps;
      float num2 = 1f;
      RenderTexture source1 = temporary1;
      RenderTexture dest = temporary2;
      for (int index = 0; index < this.QualitySteps; ++index)
      {
        if ((UnityEngine.Object) dest != (UnityEngine.Object) destination)
          dest.DiscardContents();
        this.m_blurMaterial.SetVector("_AM_BLUR_STEP", blurStep * num2);
        Graphics.Blit((Texture) source1, dest, this.m_blurMaterial, pass);
        if (index < this.QualitySteps - 2)
        {
          RenderTexture renderTexture2 = dest;
          dest = source1;
          source1 = renderTexture2;
        }
        else
        {
          source1 = dest;
          dest = destination;
        }
        num2 -= num1;
      }
      RenderTexture.ReleaseTemporary(temporary2);
    }
    else
    {
      this.m_blurMaterial.SetVector("_AM_BLUR_STEP", blurStep);
      Graphics.Blit((Texture) temporary1, destination, this.m_blurMaterial, pass);
    }
    if (flag)
    {
      this.m_combineMaterial.SetTexture("_MotionTex", (Texture) this.m_motionRT);
      Graphics.Blit((Texture) source, destination, this.m_combineMaterial, 1);
    }
    RenderTexture.ReleaseTemporary(temporary1);
    if (!((UnityEngine.Object) renderTexture1 != (UnityEngine.Object) null))
      return;
    RenderTexture.ReleaseTemporary(renderTexture1);
  }

  private void OnRenderImage(RenderTexture source, RenderTexture destination)
  {
    if ((UnityEngine.Object) this.m_currentPostProcess == (UnityEngine.Object) null)
      this.PostProcess(source, destination);
    else
      Graphics.Blit((Texture) source, destination);
  }

  public void PostProcess(RenderTexture source, RenderTexture destination)
  {
    Vector4 zero = Vector4.zero with
    {
      x = this.MaxVelocity / 1000f,
      y = this.MaxVelocity / 1000f
    };
    RenderTexture renderTexture = (RenderTexture) null;
    if (QualitySettings.antiAliasing > 1)
    {
      renderTexture = RenderTexture.GetTemporary(this.m_width, this.m_height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
      renderTexture.name = "AM-DilatedTemp";
      renderTexture.filterMode = FilterMode.Point;
      this.m_dilationMaterial.SetTexture("_MotionTex", (Texture) this.m_motionRT);
      Graphics.Blit((Texture) this.m_motionRT, renderTexture, this.m_dilationMaterial, 0);
      this.m_dilationMaterial.SetTexture("_MotionTex", (Texture) renderTexture);
      Graphics.Blit((Texture) renderTexture, this.m_motionRT, this.m_dilationMaterial, 1);
    }
    if (this.DebugMode)
    {
      this.m_debugMaterial.SetTexture("_MotionTex", (Texture) this.m_motionRT);
      Graphics.Blit((Texture) source, destination, this.m_debugMaterial);
    }
    else
      this.ApplyMotionBlur(source, destination, zero);
    if (!((UnityEngine.Object) renderTexture != (UnityEngine.Object) null))
      return;
    RenderTexture.ReleaseTemporary(renderTexture);
  }
}
