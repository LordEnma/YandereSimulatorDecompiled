using System;
using System.Collections.Generic;
using System.Linq;
using AmplifyMotion;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

// Token: 0x020000B2 RID: 178
[RequireComponent(typeof(Camera))]
[AddComponentMenu("")]
public class AmplifyMotionEffectBase : MonoBehaviour
{
	// Token: 0x170001D9 RID: 473
	// (get) Token: 0x060008E5 RID: 2277 RVA: 0x00048C1F File Offset: 0x00046E1F
	// (set) Token: 0x060008E6 RID: 2278 RVA: 0x00048C27 File Offset: 0x00046E27
	[Obsolete("workerThreads is deprecated, please use WorkerThreads instead.")]
	public int workerThreads
	{
		get
		{
			return this.WorkerThreads;
		}
		set
		{
			this.WorkerThreads = value;
		}
	}

	// Token: 0x170001DA RID: 474
	// (get) Token: 0x060008E7 RID: 2279 RVA: 0x00048C30 File Offset: 0x00046E30
	internal Material ReprojectionMaterial
	{
		get
		{
			return this.m_reprojectionMaterial;
		}
	}

	// Token: 0x170001DB RID: 475
	// (get) Token: 0x060008E8 RID: 2280 RVA: 0x00048C38 File Offset: 0x00046E38
	internal Material SolidVectorsMaterial
	{
		get
		{
			return this.m_solidVectorsMaterial;
		}
	}

	// Token: 0x170001DC RID: 476
	// (get) Token: 0x060008E9 RID: 2281 RVA: 0x00048C40 File Offset: 0x00046E40
	internal Material SkinnedVectorsMaterial
	{
		get
		{
			return this.m_skinnedVectorsMaterial;
		}
	}

	// Token: 0x170001DD RID: 477
	// (get) Token: 0x060008EA RID: 2282 RVA: 0x00048C48 File Offset: 0x00046E48
	internal Material ClothVectorsMaterial
	{
		get
		{
			return this.m_clothVectorsMaterial;
		}
	}

	// Token: 0x170001DE RID: 478
	// (get) Token: 0x060008EB RID: 2283 RVA: 0x00048C50 File Offset: 0x00046E50
	internal RenderTexture MotionRenderTexture
	{
		get
		{
			return this.m_motionRT;
		}
	}

	// Token: 0x170001DF RID: 479
	// (get) Token: 0x060008EC RID: 2284 RVA: 0x00048C58 File Offset: 0x00046E58
	public Dictionary<Camera, AmplifyMotionCamera> LinkedCameras
	{
		get
		{
			return this.m_linkedCameras;
		}
	}

	// Token: 0x170001E0 RID: 480
	// (get) Token: 0x060008ED RID: 2285 RVA: 0x00048C60 File Offset: 0x00046E60
	internal float MotionScaleNorm
	{
		get
		{
			return this.m_motionScaleNorm;
		}
	}

	// Token: 0x170001E1 RID: 481
	// (get) Token: 0x060008EE RID: 2286 RVA: 0x00048C68 File Offset: 0x00046E68
	internal float FixedMotionScaleNorm
	{
		get
		{
			return this.m_fixedMotionScaleNorm;
		}
	}

	// Token: 0x170001E2 RID: 482
	// (get) Token: 0x060008EF RID: 2287 RVA: 0x00048C70 File Offset: 0x00046E70
	public AmplifyMotionCamera BaseCamera
	{
		get
		{
			return this.m_baseCamera;
		}
	}

	// Token: 0x170001E3 RID: 483
	// (get) Token: 0x060008F0 RID: 2288 RVA: 0x00048C78 File Offset: 0x00046E78
	internal WorkerThreadPool WorkerPool
	{
		get
		{
			return this.m_workerThreadPool;
		}
	}

	// Token: 0x170001E4 RID: 484
	// (get) Token: 0x060008F1 RID: 2289 RVA: 0x00048C80 File Offset: 0x00046E80
	public static bool IsD3D
	{
		get
		{
			return AmplifyMotionEffectBase.m_isD3D;
		}
	}

	// Token: 0x170001E5 RID: 485
	// (get) Token: 0x060008F2 RID: 2290 RVA: 0x00048C87 File Offset: 0x00046E87
	public bool CanUseGPU
	{
		get
		{
			return this.m_canUseGPU;
		}
	}

	// Token: 0x170001E6 RID: 486
	// (get) Token: 0x060008F3 RID: 2291 RVA: 0x00048C8F File Offset: 0x00046E8F
	public static bool IgnoreMotionScaleWarning
	{
		get
		{
			return AmplifyMotionEffectBase.m_ignoreMotionScaleWarning;
		}
	}

	// Token: 0x170001E7 RID: 487
	// (get) Token: 0x060008F4 RID: 2292 RVA: 0x00048C96 File Offset: 0x00046E96
	public static AmplifyMotionEffectBase FirstInstance
	{
		get
		{
			return AmplifyMotionEffectBase.m_firstInstance;
		}
	}

	// Token: 0x170001E8 RID: 488
	// (get) Token: 0x060008F5 RID: 2293 RVA: 0x00048C9D File Offset: 0x00046E9D
	public static AmplifyMotionEffectBase Instance
	{
		get
		{
			return AmplifyMotionEffectBase.m_firstInstance;
		}
	}

	// Token: 0x060008F6 RID: 2294 RVA: 0x00048CA4 File Offset: 0x00046EA4
	private void Awake()
	{
		if (AmplifyMotionEffectBase.m_firstInstance == null)
		{
			AmplifyMotionEffectBase.m_firstInstance = this;
		}
		AmplifyMotionEffectBase.m_isD3D = SystemInfo.graphicsDeviceVersion.StartsWith("Direct3D");
		this.m_globalObjectId = 1;
		this.m_width = (this.m_height = 0);
		if (this.ForceCPUOnly)
		{
			this.m_canUseGPU = false;
			return;
		}
		bool flag = SystemInfo.graphicsShaderLevel >= 30;
		bool flag2 = SystemInfo.SupportsTextureFormat(TextureFormat.RHalf);
		bool flag3 = SystemInfo.SupportsTextureFormat(TextureFormat.RGHalf);
		bool flag4 = SystemInfo.SupportsTextureFormat(TextureFormat.RGBAHalf);
		bool flag5 = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBFloat);
		this.m_canUseGPU = (flag && flag2 && flag3 && flag4 && flag5);
	}

	// Token: 0x060008F7 RID: 2295 RVA: 0x00048D3F File Offset: 0x00046F3F
	internal void ResetObjectId()
	{
		this.m_globalObjectId = 1;
	}

	// Token: 0x060008F8 RID: 2296 RVA: 0x00048D48 File Offset: 0x00046F48
	internal int GenerateObjectId(GameObject obj)
	{
		if (obj.isStatic)
		{
			return 0;
		}
		this.m_globalObjectId++;
		if (this.m_globalObjectId > 254)
		{
			this.m_globalObjectId = 1;
		}
		return this.m_globalObjectId;
	}

	// Token: 0x060008F9 RID: 2297 RVA: 0x00048D7C File Offset: 0x00046F7C
	private void SafeDestroyMaterial(ref Material mat)
	{
		if (mat != null)
		{
			UnityEngine.Object.DestroyImmediate(mat);
			mat = null;
		}
	}

	// Token: 0x060008FA RID: 2298 RVA: 0x00048D94 File Offset: 0x00046F94
	private bool CheckMaterialAndShader(Material material, string name)
	{
		bool result = true;
		if (material == null || material.shader == null)
		{
			Debug.LogWarning("[AmplifyMotion] Error creating " + name + " material");
			result = false;
		}
		else if (!material.shader.isSupported)
		{
			Debug.LogWarning("[AmplifyMotion] " + name + " shader not supported on this platform");
			result = false;
		}
		return result;
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x00048DF8 File Offset: 0x00046FF8
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

	// Token: 0x060008FC RID: 2300 RVA: 0x00048E74 File Offset: 0x00047074
	private bool CreateMaterials()
	{
		this.DestroyMaterials();
		string name = "Hidden/Amplify Motion/MotionBlurSM" + ((SystemInfo.graphicsShaderLevel >= 30) ? 3 : 2).ToString();
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
			this.m_blurMaterial = new Material(Shader.Find(name))
			{
				hideFlags = HideFlags.DontSave
			};
			this.m_solidVectorsMaterial = new Material(Shader.Find(name2))
			{
				hideFlags = HideFlags.DontSave
			};
			this.m_skinnedVectorsMaterial = new Material(Shader.Find(name3))
			{
				hideFlags = HideFlags.DontSave
			};
			this.m_clothVectorsMaterial = new Material(Shader.Find(name4))
			{
				hideFlags = HideFlags.DontSave
			};
			this.m_reprojectionMaterial = new Material(Shader.Find(name5))
			{
				hideFlags = HideFlags.DontSave
			};
			this.m_combineMaterial = new Material(Shader.Find(name6))
			{
				hideFlags = HideFlags.DontSave
			};
			this.m_dilationMaterial = new Material(Shader.Find(name7))
			{
				hideFlags = HideFlags.DontSave
			};
			this.m_depthMaterial = new Material(Shader.Find(name8))
			{
				hideFlags = HideFlags.DontSave
			};
			this.m_debugMaterial = new Material(Shader.Find(name9))
			{
				hideFlags = HideFlags.DontSave
			};
		}
		catch (Exception)
		{
		}
		return this.CheckMaterialAndShader(this.m_blurMaterial, name) && this.CheckMaterialAndShader(this.m_solidVectorsMaterial, name2) && this.CheckMaterialAndShader(this.m_skinnedVectorsMaterial, name3) && this.CheckMaterialAndShader(this.m_clothVectorsMaterial, name4) && this.CheckMaterialAndShader(this.m_reprojectionMaterial, name5) && this.CheckMaterialAndShader(this.m_combineMaterial, name6) && this.CheckMaterialAndShader(this.m_dilationMaterial, name7) && this.CheckMaterialAndShader(this.m_depthMaterial, name8) && this.CheckMaterialAndShader(this.m_debugMaterial, name9);
	}

	// Token: 0x060008FD RID: 2301 RVA: 0x0004907C File Offset: 0x0004727C
	private RenderTexture CreateRenderTexture(string name, int depth, RenderTextureFormat fmt, RenderTextureReadWrite rw, FilterMode fm)
	{
		RenderTexture renderTexture = new RenderTexture(this.m_width, this.m_height, depth, fmt, rw);
		renderTexture.hideFlags = HideFlags.DontSave;
		renderTexture.name = name;
		renderTexture.wrapMode = TextureWrapMode.Clamp;
		renderTexture.filterMode = fm;
		renderTexture.Create();
		return renderTexture;
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x000490B8 File Offset: 0x000472B8
	private void SafeDestroyRenderTexture(ref RenderTexture rt)
	{
		if (rt != null)
		{
			RenderTexture.active = null;
			rt.Release();
			UnityEngine.Object.DestroyImmediate(rt);
			rt = null;
		}
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x000490DB File Offset: 0x000472DB
	private void SafeDestroyTexture(ref Texture tex)
	{
		if (tex != null)
		{
			UnityEngine.Object.DestroyImmediate(tex);
			tex = null;
		}
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x000490F1 File Offset: 0x000472F1
	private void DestroyRenderTextures()
	{
		RenderTexture.active = null;
		this.SafeDestroyRenderTexture(ref this.m_motionRT);
	}

	// Token: 0x06000901 RID: 2305 RVA: 0x00049108 File Offset: 0x00047308
	private void UpdateRenderTextures(bool qualityChanged)
	{
		int num = Mathf.Max(Mathf.FloorToInt((float)this.m_camera.pixelWidth + 0.5f), 1);
		int num2 = Mathf.Max(Mathf.FloorToInt((float)this.m_camera.pixelHeight + 0.5f), 1);
		if (this.QualityLevel == Quality.Mobile)
		{
			num /= 2;
			num2 /= 2;
		}
		if (this.m_width != num || this.m_height != num2)
		{
			this.m_width = num;
			this.m_height = num2;
			this.DestroyRenderTextures();
		}
		if (this.m_motionRT == null)
		{
			this.m_motionRT = this.CreateRenderTexture("AM-MotionVectors", 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear, FilterMode.Point);
		}
	}

	// Token: 0x06000902 RID: 2306 RVA: 0x000491AB File Offset: 0x000473AB
	public bool CheckSupport()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			Debug.LogError("[AmplifyMotion] Initialization failed. This plugin requires support for Image Effects and Render Textures.");
			return false;
		}
		return true;
	}

	// Token: 0x06000903 RID: 2307 RVA: 0x000491C1 File Offset: 0x000473C1
	private void InitializeThreadPool()
	{
		if (this.WorkerThreads <= 0)
		{
			this.WorkerThreads = Mathf.Max(Environment.ProcessorCount / 2, 1);
		}
		this.m_workerThreadPool = new WorkerThreadPool();
		this.m_workerThreadPool.InitializeAsyncUpdateThreads(this.WorkerThreads, this.SystemThreadPool);
	}

	// Token: 0x06000904 RID: 2308 RVA: 0x00049201 File Offset: 0x00047401
	private void ShutdownThreadPool()
	{
		if (this.m_workerThreadPool != null)
		{
			this.m_workerThreadPool.FinalizeAsyncUpdateThreads();
			this.m_workerThreadPool = null;
		}
	}

	// Token: 0x06000905 RID: 2309 RVA: 0x00049220 File Offset: 0x00047420
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

	// Token: 0x06000906 RID: 2310 RVA: 0x00049290 File Offset: 0x00047490
	private void ShutdownCommandBuffers()
	{
		if (this.m_updateCB != null)
		{
			this.m_camera.RemoveCommandBuffer(CameraEvent.BeforeImageEffectsOpaque, this.m_updateCB);
			this.m_updateCB.Release();
			this.m_updateCB = null;
		}
		if (this.m_fixedUpdateCB != null)
		{
			this.m_camera.RemoveCommandBuffer(CameraEvent.BeforeImageEffectsOpaque, this.m_fixedUpdateCB);
			this.m_fixedUpdateCB.Release();
			this.m_fixedUpdateCB = null;
		}
	}

	// Token: 0x06000907 RID: 2311 RVA: 0x000492F8 File Offset: 0x000474F8
	private void OnEnable()
	{
		this.m_camera = base.GetComponent<Camera>();
		if (!this.CheckSupport())
		{
			base.enabled = false;
			return;
		}
		this.InitializeThreadPool();
		this.m_starting = true;
		if (!this.CreateMaterials())
		{
			Debug.LogError("[AmplifyMotion] Failed loading or compiling necessary shaders. Please try reinstalling Amplify Motion or contact support@amplify.pt");
			base.enabled = false;
			return;
		}
		if (this.AutoRegisterObjs)
		{
			this.UpdateActiveObjects();
		}
		this.InitializeCameras();
		this.InitializeCommandBuffers();
		this.UpdateRenderTextures(true);
		this.m_linkedCameras.TryGetValue(this.m_camera, out this.m_baseCamera);
		if (this.m_baseCamera == null)
		{
			Debug.LogError("[AmplifyMotion] Failed setting up Base Camera. Please contact support@amplify.pt");
			base.enabled = false;
			return;
		}
		if (this.m_currentPostProcess != null)
		{
			this.m_currentPostProcess.enabled = true;
		}
		this.m_qualityLevel = this.QualityLevel;
	}

	// Token: 0x06000908 RID: 2312 RVA: 0x000493C7 File Offset: 0x000475C7
	private void OnDisable()
	{
		if (this.m_currentPostProcess != null)
		{
			this.m_currentPostProcess.enabled = false;
		}
		this.ShutdownCommandBuffers();
		this.ShutdownThreadPool();
	}

	// Token: 0x06000909 RID: 2313 RVA: 0x000493EF File Offset: 0x000475EF
	private void Start()
	{
		this.UpdatePostProcess();
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x000493F7 File Offset: 0x000475F7
	internal void RemoveCamera(Camera reference)
	{
		this.m_linkedCameras.Remove(reference);
	}

	// Token: 0x0600090B RID: 2315 RVA: 0x00049408 File Offset: 0x00047608
	private void OnDestroy()
	{
		foreach (AmplifyMotionCamera amplifyMotionCamera in this.m_linkedCameras.Values.ToArray<AmplifyMotionCamera>())
		{
			if (amplifyMotionCamera != null && amplifyMotionCamera.gameObject != base.gameObject)
			{
				Camera component = amplifyMotionCamera.GetComponent<Camera>();
				if (component != null)
				{
					component.targetTexture = null;
				}
				UnityEngine.Object.DestroyImmediate(amplifyMotionCamera);
			}
		}
		this.DestroyRenderTextures();
		this.DestroyMaterials();
	}

	// Token: 0x0600090C RID: 2316 RVA: 0x00049480 File Offset: 0x00047680
	private GameObject RecursiveFindCamera(GameObject obj, string auxCameraName)
	{
		GameObject gameObject = null;
		if (obj.name == auxCameraName)
		{
			gameObject = obj;
		}
		else
		{
			foreach (object obj2 in obj.transform)
			{
				Transform transform = (Transform)obj2;
				gameObject = this.RecursiveFindCamera(transform.gameObject, auxCameraName);
				if (gameObject != null)
				{
					break;
				}
			}
		}
		return gameObject;
	}

	// Token: 0x0600090D RID: 2317 RVA: 0x00049500 File Offset: 0x00047700
	private void InitializeCameras()
	{
		List<Camera> list = new List<Camera>(this.OverlayCameras.Length);
		for (int i = 0; i < this.OverlayCameras.Length; i++)
		{
			if (this.OverlayCameras[i] != null)
			{
				list.Add(this.OverlayCameras[i]);
			}
		}
		Camera[] array = new Camera[list.Count + 1];
		array[0] = this.m_camera;
		for (int j = 0; j < list.Count; j++)
		{
			array[j + 1] = list[j];
		}
		this.m_linkedCameras.Clear();
		for (int k = 0; k < array.Length; k++)
		{
			Camera camera = array[k];
			if (!this.m_linkedCameras.ContainsKey(camera))
			{
				AmplifyMotionCamera amplifyMotionCamera = camera.gameObject.GetComponent<AmplifyMotionCamera>();
				if (amplifyMotionCamera != null)
				{
					amplifyMotionCamera.enabled = false;
					amplifyMotionCamera.enabled = true;
				}
				else
				{
					amplifyMotionCamera = camera.gameObject.AddComponent<AmplifyMotionCamera>();
				}
				amplifyMotionCamera.LinkTo(this, k > 0);
				this.m_linkedCameras.Add(camera, amplifyMotionCamera);
				this.m_linkedCamerasChanged = true;
			}
		}
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x0004960D File Offset: 0x0004780D
	public void UpdateActiveCameras()
	{
		this.InitializeCameras();
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x00049618 File Offset: 0x00047818
	internal static void RegisterCamera(AmplifyMotionCamera cam)
	{
		if (!AmplifyMotionEffectBase.m_activeCameras.ContainsValue(cam))
		{
			AmplifyMotionEffectBase.m_activeCameras.Add(cam.GetComponent<Camera>(), cam);
		}
		foreach (AmplifyMotionObjectBase amplifyMotionObjectBase in AmplifyMotionEffectBase.m_activeObjects.Values)
		{
			amplifyMotionObjectBase.RegisterCamera(cam);
		}
	}

	// Token: 0x06000910 RID: 2320 RVA: 0x0004968C File Offset: 0x0004788C
	internal static void UnregisterCamera(AmplifyMotionCamera cam)
	{
		foreach (AmplifyMotionObjectBase amplifyMotionObjectBase in AmplifyMotionEffectBase.m_activeObjects.Values)
		{
			amplifyMotionObjectBase.UnregisterCamera(cam);
		}
		AmplifyMotionEffectBase.m_activeCameras.Remove(cam.GetComponent<Camera>());
	}

	// Token: 0x06000911 RID: 2321 RVA: 0x000496F4 File Offset: 0x000478F4
	public void UpdateActiveObjects()
	{
		GameObject[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		for (int i = 0; i < array.Length; i++)
		{
			if (!AmplifyMotionEffectBase.m_activeObjects.ContainsKey(array[i]))
			{
				AmplifyMotionEffectBase.TryRegister(array[i], true);
			}
		}
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x0004973C File Offset: 0x0004793C
	internal static void RegisterObject(AmplifyMotionObjectBase obj)
	{
		AmplifyMotionEffectBase.m_activeObjects.Add(obj.gameObject, obj);
		foreach (AmplifyMotionCamera camera in AmplifyMotionEffectBase.m_activeCameras.Values)
		{
			obj.RegisterCamera(camera);
		}
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x000497A4 File Offset: 0x000479A4
	internal static void UnregisterObject(AmplifyMotionObjectBase obj)
	{
		foreach (AmplifyMotionCamera camera in AmplifyMotionEffectBase.m_activeCameras.Values)
		{
			obj.UnregisterCamera(camera);
		}
		AmplifyMotionEffectBase.m_activeObjects.Remove(obj.gameObject);
	}

	// Token: 0x06000914 RID: 2324 RVA: 0x0004980C File Offset: 0x00047A0C
	internal static bool FindValidTag(Material[] materials)
	{
		foreach (Material material in materials)
		{
			if (material != null)
			{
				string tag = material.GetTag("RenderType", false);
				if (tag == "Opaque" || tag == "TransparentCutout")
				{
					return !material.IsKeywordEnabled("_ALPHABLEND_ON") && !material.IsKeywordEnabled("_ALPHAPREMULTIPLY_ON");
				}
			}
		}
		return false;
	}

	// Token: 0x06000915 RID: 2325 RVA: 0x0004987C File Offset: 0x00047A7C
	internal static bool CanRegister(GameObject gameObj, bool autoReg)
	{
		if (gameObj.isStatic)
		{
			return false;
		}
		Renderer component = gameObj.GetComponent<Renderer>();
		if (component == null || component.sharedMaterials == null || component.isPartOfStaticBatch)
		{
			return false;
		}
		if (!component.enabled)
		{
			return false;
		}
		if (component.shadowCastingMode == ShadowCastingMode.ShadowsOnly)
		{
			return false;
		}
		if (component.GetType() == typeof(SpriteRenderer))
		{
			return false;
		}
		if (!AmplifyMotionEffectBase.FindValidTag(component.sharedMaterials))
		{
			return false;
		}
		Type type = component.GetType();
		if (type == typeof(MeshRenderer) || type == typeof(SkinnedMeshRenderer))
		{
			return true;
		}
		if (type == typeof(ParticleSystemRenderer) && !autoReg)
		{
			ParticleSystemRenderMode renderMode = (component as ParticleSystemRenderer).renderMode;
			return renderMode == ParticleSystemRenderMode.Mesh || renderMode == ParticleSystemRenderMode.Billboard;
		}
		return false;
	}

	// Token: 0x06000916 RID: 2326 RVA: 0x0004994C File Offset: 0x00047B4C
	internal static void TryRegister(GameObject gameObj, bool autoReg)
	{
		if (AmplifyMotionEffectBase.CanRegister(gameObj, autoReg) && gameObj.GetComponent<AmplifyMotionObjectBase>() == null)
		{
			AmplifyMotionObjectBase.ApplyToChildren = false;
			gameObj.AddComponent<AmplifyMotionObjectBase>();
			AmplifyMotionObjectBase.ApplyToChildren = true;
		}
	}

	// Token: 0x06000917 RID: 2327 RVA: 0x00049978 File Offset: 0x00047B78
	internal static void TryUnregister(GameObject gameObj)
	{
		AmplifyMotionObjectBase component = gameObj.GetComponent<AmplifyMotionObjectBase>();
		if (component != null)
		{
			UnityEngine.Object.Destroy(component);
		}
	}

	// Token: 0x06000918 RID: 2328 RVA: 0x0004999B File Offset: 0x00047B9B
	public void Register(GameObject gameObj)
	{
		if (!AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
		{
			AmplifyMotionEffectBase.TryRegister(gameObj, false);
		}
	}

	// Token: 0x06000919 RID: 2329 RVA: 0x000499B1 File Offset: 0x00047BB1
	public static void RegisterS(GameObject gameObj)
	{
		if (!AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
		{
			AmplifyMotionEffectBase.TryRegister(gameObj, false);
		}
	}

	// Token: 0x0600091A RID: 2330 RVA: 0x000499C8 File Offset: 0x00047BC8
	public void RegisterRecursively(GameObject gameObj)
	{
		if (!AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
		{
			AmplifyMotionEffectBase.TryRegister(gameObj, false);
		}
		foreach (object obj in gameObj.transform)
		{
			Transform transform = (Transform)obj;
			this.RegisterRecursively(transform.gameObject);
		}
	}

	// Token: 0x0600091B RID: 2331 RVA: 0x00049A3C File Offset: 0x00047C3C
	public static void RegisterRecursivelyS(GameObject gameObj)
	{
		if (!AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
		{
			AmplifyMotionEffectBase.TryRegister(gameObj, false);
		}
		foreach (object obj in gameObj.transform)
		{
			AmplifyMotionEffectBase.RegisterRecursivelyS(((Transform)obj).gameObject);
		}
	}

	// Token: 0x0600091C RID: 2332 RVA: 0x00049AAC File Offset: 0x00047CAC
	public void Unregister(GameObject gameObj)
	{
		if (AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
		{
			AmplifyMotionEffectBase.TryUnregister(gameObj);
		}
	}

	// Token: 0x0600091D RID: 2333 RVA: 0x00049AC1 File Offset: 0x00047CC1
	public static void UnregisterS(GameObject gameObj)
	{
		if (AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
		{
			AmplifyMotionEffectBase.TryUnregister(gameObj);
		}
	}

	// Token: 0x0600091E RID: 2334 RVA: 0x00049AD8 File Offset: 0x00047CD8
	public void UnregisterRecursively(GameObject gameObj)
	{
		if (AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
		{
			AmplifyMotionEffectBase.TryUnregister(gameObj);
		}
		foreach (object obj in gameObj.transform)
		{
			Transform transform = (Transform)obj;
			this.UnregisterRecursively(transform.gameObject);
		}
	}

	// Token: 0x0600091F RID: 2335 RVA: 0x00049B4C File Offset: 0x00047D4C
	public static void UnregisterRecursivelyS(GameObject gameObj)
	{
		if (AmplifyMotionEffectBase.m_activeObjects.ContainsKey(gameObj))
		{
			AmplifyMotionEffectBase.TryUnregister(gameObj);
		}
		foreach (object obj in gameObj.transform)
		{
			AmplifyMotionEffectBase.UnregisterRecursivelyS(((Transform)obj).gameObject);
		}
	}

	// Token: 0x06000920 RID: 2336 RVA: 0x00049BBC File Offset: 0x00047DBC
	private void UpdatePostProcess()
	{
		Camera camera = null;
		float num = float.MinValue;
		if (this.m_linkedCamerasChanged)
		{
			this.UpdateLinkedCameras();
		}
		for (int i = 0; i < this.m_linkedCameraKeys.Length; i++)
		{
			if (this.m_linkedCameraKeys[i] != null && this.m_linkedCameraKeys[i].isActiveAndEnabled && this.m_linkedCameraKeys[i].depth > num)
			{
				camera = this.m_linkedCameraKeys[i];
				num = this.m_linkedCameraKeys[i].depth;
			}
		}
		if (this.m_currentPostProcess != null && this.m_currentPostProcess.gameObject != camera.gameObject)
		{
			UnityEngine.Object.DestroyImmediate(this.m_currentPostProcess);
			this.m_currentPostProcess = null;
		}
		if (this.m_currentPostProcess == null && camera != null && camera != this.m_camera)
		{
			AmplifyMotionPostProcess[] components = base.gameObject.GetComponents<AmplifyMotionPostProcess>();
			if (components != null && components.Length != 0)
			{
				for (int j = 0; j < components.Length; j++)
				{
					UnityEngine.Object.DestroyImmediate(components[j]);
				}
			}
			this.m_currentPostProcess = camera.gameObject.AddComponent<AmplifyMotionPostProcess>();
			this.m_currentPostProcess.Instance = this;
		}
	}

	// Token: 0x06000921 RID: 2337 RVA: 0x00049CE0 File Offset: 0x00047EE0
	private void LateUpdate()
	{
		if (this.m_baseCamera.AutoStep)
		{
			float num = Application.isPlaying ? Time.unscaledDeltaTime : Time.fixedDeltaTime;
			float fixedDeltaTime = Time.fixedDeltaTime;
			this.m_deltaTime = ((num > float.Epsilon) ? num : this.m_deltaTime);
			this.m_fixedDeltaTime = ((num > float.Epsilon) ? fixedDeltaTime : this.m_fixedDeltaTime);
		}
		this.QualitySteps = Mathf.Clamp(this.QualitySteps, 0, 16);
		this.MotionScale = Mathf.Max(this.MotionScale, 0f);
		this.MinVelocity = Mathf.Min(this.MinVelocity, this.MaxVelocity);
		this.DepthThreshold = Mathf.Max(this.DepthThreshold, 0f);
		this.MinResetDeltaDist = Mathf.Max(this.MinResetDeltaDist, 0f);
		this.MinResetDeltaDistSqr = this.MinResetDeltaDist * this.MinResetDeltaDist;
		this.ResetFrameDelay = Mathf.Max(this.ResetFrameDelay, 0);
		this.UpdatePostProcess();
	}

	// Token: 0x06000922 RID: 2338 RVA: 0x00049DDC File Offset: 0x00047FDC
	public void StopAutoStep()
	{
		foreach (AmplifyMotionCamera amplifyMotionCamera in this.m_linkedCameras.Values)
		{
			amplifyMotionCamera.StopAutoStep();
		}
	}

	// Token: 0x06000923 RID: 2339 RVA: 0x00049E34 File Offset: 0x00048034
	public void StartAutoStep()
	{
		foreach (AmplifyMotionCamera amplifyMotionCamera in this.m_linkedCameras.Values)
		{
			amplifyMotionCamera.StartAutoStep();
		}
	}

	// Token: 0x06000924 RID: 2340 RVA: 0x00049E8C File Offset: 0x0004808C
	public void Step(float delta)
	{
		this.m_deltaTime = delta;
		this.m_fixedDeltaTime = delta;
		foreach (AmplifyMotionCamera amplifyMotionCamera in this.m_linkedCameras.Values)
		{
			amplifyMotionCamera.Step();
		}
	}

	// Token: 0x06000925 RID: 2341 RVA: 0x00049EF0 File Offset: 0x000480F0
	private void UpdateLinkedCameras()
	{
		Dictionary<Camera, AmplifyMotionCamera>.KeyCollection keys = this.m_linkedCameras.Keys;
		Dictionary<Camera, AmplifyMotionCamera>.ValueCollection values = this.m_linkedCameras.Values;
		if (this.m_linkedCameraKeys == null || keys.Count != this.m_linkedCameraKeys.Length)
		{
			this.m_linkedCameraKeys = new Camera[keys.Count];
		}
		if (this.m_linkedCameraValues == null || values.Count != this.m_linkedCameraValues.Length)
		{
			this.m_linkedCameraValues = new AmplifyMotionCamera[values.Count];
		}
		keys.CopyTo(this.m_linkedCameraKeys, 0);
		values.CopyTo(this.m_linkedCameraValues, 0);
		this.m_linkedCamerasChanged = false;
	}

	// Token: 0x06000926 RID: 2342 RVA: 0x00049F88 File Offset: 0x00048188
	private void FixedUpdate()
	{
		if (this.m_camera.enabled)
		{
			if (this.m_linkedCamerasChanged)
			{
				this.UpdateLinkedCameras();
			}
			this.m_fixedUpdateCB.Clear();
			for (int i = 0; i < this.m_linkedCameraValues.Length; i++)
			{
				if (this.m_linkedCameraValues[i] != null && this.m_linkedCameraValues[i].isActiveAndEnabled)
				{
					this.m_linkedCameraValues[i].FixedUpdateTransform(this, this.m_fixedUpdateCB);
				}
			}
		}
	}

	// Token: 0x06000927 RID: 2343 RVA: 0x0004A004 File Offset: 0x00048204
	private void OnPreRender()
	{
		if (this.m_camera.enabled && (Time.frameCount == 1 || Mathf.Abs(Time.unscaledDeltaTime) > 1E-45f))
		{
			if (this.m_linkedCamerasChanged)
			{
				this.UpdateLinkedCameras();
			}
			this.m_updateCB.Clear();
			for (int i = 0; i < this.m_linkedCameraValues.Length; i++)
			{
				if (this.m_linkedCameraValues[i] != null && this.m_linkedCameraValues[i].isActiveAndEnabled)
				{
					this.m_linkedCameraValues[i].UpdateTransform(this, this.m_updateCB);
				}
			}
		}
	}

	// Token: 0x06000928 RID: 2344 RVA: 0x0004A098 File Offset: 0x00048298
	private void OnPostRender()
	{
		bool qualityChanged = this.QualityLevel != this.m_qualityLevel;
		this.m_qualityLevel = this.QualityLevel;
		this.UpdateRenderTextures(qualityChanged);
		this.ResetObjectId();
		bool flag = this.CameraMotionMult > float.Epsilon;
		bool clearColor = !flag || this.m_starting;
		float num = (this.DepthThreshold > float.Epsilon) ? (1f / this.DepthThreshold) : float.MaxValue;
		this.m_motionScaleNorm = ((this.m_deltaTime >= float.Epsilon) ? (this.MotionScale * (1f / this.m_deltaTime)) : 0f);
		this.m_fixedMotionScaleNorm = ((this.m_fixedDeltaTime >= float.Epsilon) ? (this.MotionScale * (1f / this.m_fixedDeltaTime)) : 0f);
		float scale = (!this.m_starting) ? this.m_motionScaleNorm : 0f;
		float fixedScale = (!this.m_starting) ? this.m_fixedMotionScaleNorm : 0f;
		Shader.SetGlobalFloat("_AM_MIN_VELOCITY", this.MinVelocity);
		Shader.SetGlobalFloat("_AM_MAX_VELOCITY", this.MaxVelocity);
		Shader.SetGlobalFloat("_AM_RCP_TOTAL_VELOCITY", 1f / (this.MaxVelocity - this.MinVelocity));
		Shader.SetGlobalVector("_AM_DEPTH_THRESHOLD", new Vector2(this.DepthThreshold, num));
		this.m_motionRT.DiscardContents();
		this.m_baseCamera.PreRenderVectors(this.m_motionRT, clearColor, num);
		for (int i = 0; i < this.m_linkedCameraValues.Length; i++)
		{
			AmplifyMotionCamera amplifyMotionCamera = this.m_linkedCameraValues[i];
			if (amplifyMotionCamera != null && amplifyMotionCamera.Overlay && amplifyMotionCamera.isActiveAndEnabled)
			{
				amplifyMotionCamera.PreRenderVectors(this.m_motionRT, clearColor, num);
				amplifyMotionCamera.RenderVectors(scale, fixedScale, this.QualityLevel);
			}
		}
		if (flag)
		{
			float num2 = (this.m_deltaTime >= float.Epsilon) ? (this.MotionScale * this.CameraMotionMult * (1f / this.m_deltaTime)) : 0f;
			float scale2 = (!this.m_starting) ? num2 : 0f;
			this.m_motionRT.DiscardContents();
			this.m_baseCamera.RenderReprojectionVectors(this.m_motionRT, scale2);
		}
		this.m_baseCamera.RenderVectors(scale, fixedScale, this.QualityLevel);
		for (int j = 0; j < this.m_linkedCameraValues.Length; j++)
		{
			AmplifyMotionCamera amplifyMotionCamera2 = this.m_linkedCameraValues[j];
			if (amplifyMotionCamera2 != null && amplifyMotionCamera2.Overlay && amplifyMotionCamera2.isActiveAndEnabled)
			{
				amplifyMotionCamera2.RenderVectors(scale, fixedScale, this.QualityLevel);
			}
		}
		this.m_starting = false;
	}

	// Token: 0x06000929 RID: 2345 RVA: 0x0004A338 File Offset: 0x00048538
	private void ApplyMotionBlur(RenderTexture source, RenderTexture destination, Vector4 blurStep)
	{
		bool flag = this.QualityLevel == Quality.Mobile;
		int pass = (int)(this.QualityLevel + (this.Noise ? 4 : 0));
		RenderTexture renderTexture = null;
		if (flag)
		{
			renderTexture = RenderTexture.GetTemporary(this.m_width, this.m_height, 0, RenderTextureFormat.ARGB32);
			renderTexture.name = "AM-DepthTemp";
			renderTexture.wrapMode = TextureWrapMode.Clamp;
			renderTexture.filterMode = FilterMode.Point;
		}
		RenderTexture temporary = RenderTexture.GetTemporary(this.m_width, this.m_height, 0, source.format);
		temporary.name = "AM-CombinedTemp";
		temporary.wrapMode = TextureWrapMode.Clamp;
		temporary.filterMode = FilterMode.Point;
		temporary.DiscardContents();
		this.m_combineMaterial.SetTexture("_MotionTex", this.m_motionRT);
		source.filterMode = FilterMode.Point;
		Graphics.Blit(source, temporary, this.m_combineMaterial, 0);
		this.m_blurMaterial.SetTexture("_MotionTex", this.m_motionRT);
		if (flag)
		{
			Graphics.Blit(null, renderTexture, this.m_depthMaterial, 0);
			this.m_blurMaterial.SetTexture("_DepthTex", renderTexture);
		}
		if (this.QualitySteps > 1)
		{
			RenderTexture temporary2 = RenderTexture.GetTemporary(this.m_width, this.m_height, 0, source.format);
			temporary2.name = "AM-CombinedTemp2";
			temporary2.filterMode = FilterMode.Point;
			float num = 1f / (float)this.QualitySteps;
			float num2 = 1f;
			RenderTexture renderTexture2 = temporary;
			RenderTexture renderTexture3 = temporary2;
			for (int i = 0; i < this.QualitySteps; i++)
			{
				if (renderTexture3 != destination)
				{
					renderTexture3.DiscardContents();
				}
				this.m_blurMaterial.SetVector("_AM_BLUR_STEP", blurStep * num2);
				Graphics.Blit(renderTexture2, renderTexture3, this.m_blurMaterial, pass);
				if (i < this.QualitySteps - 2)
				{
					RenderTexture renderTexture4 = renderTexture3;
					renderTexture3 = renderTexture2;
					renderTexture2 = renderTexture4;
				}
				else
				{
					renderTexture2 = renderTexture3;
					renderTexture3 = destination;
				}
				num2 -= num;
			}
			RenderTexture.ReleaseTemporary(temporary2);
		}
		else
		{
			this.m_blurMaterial.SetVector("_AM_BLUR_STEP", blurStep);
			Graphics.Blit(temporary, destination, this.m_blurMaterial, pass);
		}
		if (flag)
		{
			this.m_combineMaterial.SetTexture("_MotionTex", this.m_motionRT);
			Graphics.Blit(source, destination, this.m_combineMaterial, 1);
		}
		RenderTexture.ReleaseTemporary(temporary);
		if (renderTexture != null)
		{
			RenderTexture.ReleaseTemporary(renderTexture);
		}
	}

	// Token: 0x0600092A RID: 2346 RVA: 0x0004A55D File Offset: 0x0004875D
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.m_currentPostProcess == null)
		{
			this.PostProcess(source, destination);
			return;
		}
		Graphics.Blit(source, destination);
	}

	// Token: 0x0600092B RID: 2347 RVA: 0x0004A580 File Offset: 0x00048780
	public void PostProcess(RenderTexture source, RenderTexture destination)
	{
		Vector4 zero = Vector4.zero;
		zero.x = this.MaxVelocity / 1000f;
		zero.y = this.MaxVelocity / 1000f;
		RenderTexture renderTexture = null;
		if (QualitySettings.antiAliasing > 1)
		{
			renderTexture = RenderTexture.GetTemporary(this.m_width, this.m_height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
			renderTexture.name = "AM-DilatedTemp";
			renderTexture.filterMode = FilterMode.Point;
			this.m_dilationMaterial.SetTexture("_MotionTex", this.m_motionRT);
			Graphics.Blit(this.m_motionRT, renderTexture, this.m_dilationMaterial, 0);
			this.m_dilationMaterial.SetTexture("_MotionTex", renderTexture);
			Graphics.Blit(renderTexture, this.m_motionRT, this.m_dilationMaterial, 1);
		}
		if (this.DebugMode)
		{
			this.m_debugMaterial.SetTexture("_MotionTex", this.m_motionRT);
			Graphics.Blit(source, destination, this.m_debugMaterial);
		}
		else
		{
			this.ApplyMotionBlur(source, destination, zero);
		}
		if (renderTexture != null)
		{
			RenderTexture.ReleaseTemporary(renderTexture);
		}
	}

	// Token: 0x040007AC RID: 1964
	[Header("Motion Blur")]
	public Quality QualityLevel = Quality.Standard;

	// Token: 0x040007AD RID: 1965
	public int QualitySteps = 1;

	// Token: 0x040007AE RID: 1966
	public float MotionScale = 3f;

	// Token: 0x040007AF RID: 1967
	public float CameraMotionMult = 1f;

	// Token: 0x040007B0 RID: 1968
	public float MinVelocity = 1f;

	// Token: 0x040007B1 RID: 1969
	public float MaxVelocity = 10f;

	// Token: 0x040007B2 RID: 1970
	public float DepthThreshold = 0.01f;

	// Token: 0x040007B3 RID: 1971
	public bool Noise;

	// Token: 0x040007B4 RID: 1972
	[Header("Camera")]
	public Camera[] OverlayCameras = new Camera[0];

	// Token: 0x040007B5 RID: 1973
	public LayerMask CullingMask = -1;

	// Token: 0x040007B6 RID: 1974
	[Header("Objects")]
	public bool AutoRegisterObjs = true;

	// Token: 0x040007B7 RID: 1975
	public float MinResetDeltaDist = 1000f;

	// Token: 0x040007B8 RID: 1976
	[NonSerialized]
	public float MinResetDeltaDistSqr;

	// Token: 0x040007B9 RID: 1977
	public int ResetFrameDelay = 1;

	// Token: 0x040007BA RID: 1978
	[Header("Low-Level")]
	[FormerlySerializedAs("workerThreads")]
	public int WorkerThreads;

	// Token: 0x040007BB RID: 1979
	public bool SystemThreadPool;

	// Token: 0x040007BC RID: 1980
	public bool ForceCPUOnly;

	// Token: 0x040007BD RID: 1981
	public bool DebugMode;

	// Token: 0x040007BE RID: 1982
	private Camera m_camera;

	// Token: 0x040007BF RID: 1983
	private bool m_starting = true;

	// Token: 0x040007C0 RID: 1984
	private int m_width;

	// Token: 0x040007C1 RID: 1985
	private int m_height;

	// Token: 0x040007C2 RID: 1986
	private RenderTexture m_motionRT;

	// Token: 0x040007C3 RID: 1987
	private Material m_blurMaterial;

	// Token: 0x040007C4 RID: 1988
	private Material m_solidVectorsMaterial;

	// Token: 0x040007C5 RID: 1989
	private Material m_skinnedVectorsMaterial;

	// Token: 0x040007C6 RID: 1990
	private Material m_clothVectorsMaterial;

	// Token: 0x040007C7 RID: 1991
	private Material m_reprojectionMaterial;

	// Token: 0x040007C8 RID: 1992
	private Material m_combineMaterial;

	// Token: 0x040007C9 RID: 1993
	private Material m_dilationMaterial;

	// Token: 0x040007CA RID: 1994
	private Material m_depthMaterial;

	// Token: 0x040007CB RID: 1995
	private Material m_debugMaterial;

	// Token: 0x040007CC RID: 1996
	private Dictionary<Camera, AmplifyMotionCamera> m_linkedCameras = new Dictionary<Camera, AmplifyMotionCamera>();

	// Token: 0x040007CD RID: 1997
	internal Camera[] m_linkedCameraKeys;

	// Token: 0x040007CE RID: 1998
	internal AmplifyMotionCamera[] m_linkedCameraValues;

	// Token: 0x040007CF RID: 1999
	internal bool m_linkedCamerasChanged = true;

	// Token: 0x040007D0 RID: 2000
	private AmplifyMotionPostProcess m_currentPostProcess;

	// Token: 0x040007D1 RID: 2001
	private int m_globalObjectId = 1;

	// Token: 0x040007D2 RID: 2002
	private float m_deltaTime;

	// Token: 0x040007D3 RID: 2003
	private float m_fixedDeltaTime;

	// Token: 0x040007D4 RID: 2004
	private float m_motionScaleNorm;

	// Token: 0x040007D5 RID: 2005
	private float m_fixedMotionScaleNorm;

	// Token: 0x040007D6 RID: 2006
	private Quality m_qualityLevel;

	// Token: 0x040007D7 RID: 2007
	private AmplifyMotionCamera m_baseCamera;

	// Token: 0x040007D8 RID: 2008
	private WorkerThreadPool m_workerThreadPool;

	// Token: 0x040007D9 RID: 2009
	public static Dictionary<GameObject, AmplifyMotionObjectBase> m_activeObjects = new Dictionary<GameObject, AmplifyMotionObjectBase>();

	// Token: 0x040007DA RID: 2010
	public static Dictionary<Camera, AmplifyMotionCamera> m_activeCameras = new Dictionary<Camera, AmplifyMotionCamera>();

	// Token: 0x040007DB RID: 2011
	private static bool m_isD3D = false;

	// Token: 0x040007DC RID: 2012
	private bool m_canUseGPU;

	// Token: 0x040007DD RID: 2013
	private const CameraEvent m_updateCBEvent = CameraEvent.BeforeImageEffectsOpaque;

	// Token: 0x040007DE RID: 2014
	private CommandBuffer m_updateCB;

	// Token: 0x040007DF RID: 2015
	private const CameraEvent m_fixedUpdateCBEvent = CameraEvent.BeforeImageEffectsOpaque;

	// Token: 0x040007E0 RID: 2016
	private CommandBuffer m_fixedUpdateCB;

	// Token: 0x040007E1 RID: 2017
	private static bool m_ignoreMotionScaleWarning = false;

	// Token: 0x040007E2 RID: 2018
	private static AmplifyMotionEffectBase m_firstInstance = null;
}
