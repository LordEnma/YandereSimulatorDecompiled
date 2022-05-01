using System;
using System.Collections.Generic;
using AmplifyMotion;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x020000B3 RID: 179
[AddComponentMenu("")]
[RequireComponent(typeof(Camera))]
public class AmplifyMotionCamera : MonoBehaviour
{
	// Token: 0x170001E9 RID: 489
	// (get) Token: 0x0600092E RID: 2350 RVA: 0x0004AA3D File Offset: 0x00048C3D
	public bool Initialized
	{
		get
		{
			return this.m_initialized;
		}
	}

	// Token: 0x170001EA RID: 490
	// (get) Token: 0x0600092F RID: 2351 RVA: 0x0004AA45 File Offset: 0x00048C45
	public bool AutoStep
	{
		get
		{
			return this.m_autoStep;
		}
	}

	// Token: 0x170001EB RID: 491
	// (get) Token: 0x06000930 RID: 2352 RVA: 0x0004AA4D File Offset: 0x00048C4D
	public bool Overlay
	{
		get
		{
			return this.m_overlay;
		}
	}

	// Token: 0x170001EC RID: 492
	// (get) Token: 0x06000931 RID: 2353 RVA: 0x0004AA55 File Offset: 0x00048C55
	public Camera Camera
	{
		get
		{
			return this.m_camera;
		}
	}

	// Token: 0x06000932 RID: 2354 RVA: 0x0004AA5D File Offset: 0x00048C5D
	public void RegisterObject(AmplifyMotionObjectBase obj)
	{
		this.m_affectedObjectsTable.Add(obj);
		this.m_affectedObjectsChanged = true;
	}

	// Token: 0x06000933 RID: 2355 RVA: 0x0004AA73 File Offset: 0x00048C73
	public void UnregisterObject(AmplifyMotionObjectBase obj)
	{
		this.m_affectedObjectsTable.Remove(obj);
		this.m_affectedObjectsChanged = true;
	}

	// Token: 0x06000934 RID: 2356 RVA: 0x0004AA8C File Offset: 0x00048C8C
	private void UpdateAffectedObjects()
	{
		if (this.m_affectedObjects == null || this.m_affectedObjectsTable.Count != this.m_affectedObjects.Length)
		{
			this.m_affectedObjects = new AmplifyMotionObjectBase[this.m_affectedObjectsTable.Count];
		}
		this.m_affectedObjectsTable.CopyTo(this.m_affectedObjects);
		this.m_affectedObjectsChanged = false;
	}

	// Token: 0x06000935 RID: 2357 RVA: 0x0004AAE4 File Offset: 0x00048CE4
	public void LinkTo(AmplifyMotionEffectBase instance, bool overlay)
	{
		this.Instance = instance;
		this.m_camera = base.GetComponent<Camera>();
		this.m_camera.depthTextureMode |= DepthTextureMode.Depth;
		this.InitializeCommandBuffers();
		this.m_overlay = overlay;
		this.m_linked = true;
	}

	// Token: 0x06000936 RID: 2358 RVA: 0x0004AB20 File Offset: 0x00048D20
	public void Initialize()
	{
		this.m_step = false;
		this.UpdateMatrices();
		this.m_initialized = true;
	}

	// Token: 0x06000937 RID: 2359 RVA: 0x0004AB36 File Offset: 0x00048D36
	private void InitializeCommandBuffers()
	{
		this.ShutdownCommandBuffers();
		this.m_renderCB = new CommandBuffer();
		this.m_renderCB.name = "AmplifyMotion.Render";
		this.m_camera.AddCommandBuffer(CameraEvent.BeforeImageEffects, this.m_renderCB);
	}

	// Token: 0x06000938 RID: 2360 RVA: 0x0004AB6C File Offset: 0x00048D6C
	private void ShutdownCommandBuffers()
	{
		if (this.m_renderCB != null)
		{
			this.m_camera.RemoveCommandBuffer(CameraEvent.BeforeImageEffects, this.m_renderCB);
			this.m_renderCB.Release();
			this.m_renderCB = null;
		}
	}

	// Token: 0x06000939 RID: 2361 RVA: 0x0004AB9B File Offset: 0x00048D9B
	private void Awake()
	{
		this.Transform = base.transform;
	}

	// Token: 0x0600093A RID: 2362 RVA: 0x0004ABA9 File Offset: 0x00048DA9
	private void OnEnable()
	{
		AmplifyMotionEffectBase.RegisterCamera(this);
	}

	// Token: 0x0600093B RID: 2363 RVA: 0x0004ABB1 File Offset: 0x00048DB1
	private void OnDisable()
	{
		this.m_initialized = false;
		this.ShutdownCommandBuffers();
		AmplifyMotionEffectBase.UnregisterCamera(this);
	}

	// Token: 0x0600093C RID: 2364 RVA: 0x0004ABC6 File Offset: 0x00048DC6
	private void OnDestroy()
	{
		if (this.Instance != null)
		{
			this.Instance.RemoveCamera(this.m_camera);
		}
	}

	// Token: 0x0600093D RID: 2365 RVA: 0x0004ABE7 File Offset: 0x00048DE7
	public void StopAutoStep()
	{
		if (this.m_autoStep)
		{
			this.m_autoStep = false;
			this.m_step = true;
		}
	}

	// Token: 0x0600093E RID: 2366 RVA: 0x0004ABFF File Offset: 0x00048DFF
	public void StartAutoStep()
	{
		this.m_autoStep = true;
	}

	// Token: 0x0600093F RID: 2367 RVA: 0x0004AC08 File Offset: 0x00048E08
	public void Step()
	{
		this.m_step = true;
	}

	// Token: 0x06000940 RID: 2368 RVA: 0x0004AC14 File Offset: 0x00048E14
	private void Update()
	{
		if (!this.m_linked || !this.Instance.isActiveAndEnabled)
		{
			return;
		}
		if (!this.m_initialized)
		{
			this.Initialize();
		}
		if ((this.m_camera.depthTextureMode & DepthTextureMode.Depth) == DepthTextureMode.None)
		{
			this.m_camera.depthTextureMode |= DepthTextureMode.Depth;
		}
	}

	// Token: 0x06000941 RID: 2369 RVA: 0x0004AC68 File Offset: 0x00048E68
	private void UpdateMatrices()
	{
		if (!this.m_starting)
		{
			this.PrevViewProjMatrix = this.ViewProjMatrix;
			this.PrevViewProjMatrixRT = this.ViewProjMatrixRT;
		}
		Matrix4x4 worldToCameraMatrix = this.m_camera.worldToCameraMatrix;
		Matrix4x4 gpuprojectionMatrix = GL.GetGPUProjectionMatrix(this.m_camera.projectionMatrix, false);
		this.ViewProjMatrix = gpuprojectionMatrix * worldToCameraMatrix;
		this.InvViewProjMatrix = Matrix4x4.Inverse(this.ViewProjMatrix);
		Matrix4x4 gpuprojectionMatrix2 = GL.GetGPUProjectionMatrix(this.m_camera.projectionMatrix, true);
		this.ViewProjMatrixRT = gpuprojectionMatrix2 * worldToCameraMatrix;
		if (this.m_starting)
		{
			this.PrevViewProjMatrix = this.ViewProjMatrix;
			this.PrevViewProjMatrixRT = this.ViewProjMatrixRT;
		}
	}

	// Token: 0x06000942 RID: 2370 RVA: 0x0004AD10 File Offset: 0x00048F10
	public void FixedUpdateTransform(AmplifyMotionEffectBase inst, CommandBuffer updateCB)
	{
		if (!this.m_initialized)
		{
			this.Initialize();
		}
		if (this.m_affectedObjectsChanged)
		{
			this.UpdateAffectedObjects();
		}
		for (int i = 0; i < this.m_affectedObjects.Length; i++)
		{
			if (this.m_affectedObjects[i].FixedStep)
			{
				this.m_affectedObjects[i].OnUpdateTransform(inst, this.m_camera, updateCB, this.m_starting);
			}
		}
	}

	// Token: 0x06000943 RID: 2371 RVA: 0x0004AD78 File Offset: 0x00048F78
	public void UpdateTransform(AmplifyMotionEffectBase inst, CommandBuffer updateCB)
	{
		if (!this.m_initialized)
		{
			this.Initialize();
		}
		if (Time.frameCount > this.m_prevFrameCount && (this.m_autoStep || this.m_step))
		{
			this.UpdateMatrices();
			if (this.m_affectedObjectsChanged)
			{
				this.UpdateAffectedObjects();
			}
			for (int i = 0; i < this.m_affectedObjects.Length; i++)
			{
				if (!this.m_affectedObjects[i].FixedStep)
				{
					this.m_affectedObjects[i].OnUpdateTransform(inst, this.m_camera, updateCB, this.m_starting);
				}
			}
			this.m_starting = false;
			this.m_step = false;
			this.m_prevFrameCount = Time.frameCount;
		}
	}

	// Token: 0x06000944 RID: 2372 RVA: 0x0004AE1C File Offset: 0x0004901C
	public void RenderReprojectionVectors(RenderTexture destination, float scale)
	{
		this.m_renderCB.SetGlobalMatrix("_AM_MATRIX_CURR_REPROJ", this.PrevViewProjMatrix * this.InvViewProjMatrix);
		this.m_renderCB.SetGlobalFloat("_AM_MOTION_SCALE", scale);
		RenderTexture tex = null;
		this.m_renderCB.Blit(new RenderTargetIdentifier(tex), destination, this.Instance.ReprojectionMaterial);
	}

	// Token: 0x06000945 RID: 2373 RVA: 0x0004AE80 File Offset: 0x00049080
	public void PreRenderVectors(RenderTexture motionRT, bool clearColor, float rcpDepthThreshold)
	{
		this.m_renderCB.Clear();
		this.m_renderCB.SetGlobalFloat("_AM_MIN_VELOCITY", this.Instance.MinVelocity);
		this.m_renderCB.SetGlobalFloat("_AM_MAX_VELOCITY", this.Instance.MaxVelocity);
		this.m_renderCB.SetGlobalFloat("_AM_RCP_TOTAL_VELOCITY", 1f / (this.Instance.MaxVelocity - this.Instance.MinVelocity));
		this.m_renderCB.SetGlobalVector("_AM_DEPTH_THRESHOLD", new Vector2(this.Instance.DepthThreshold, rcpDepthThreshold));
		this.m_renderCB.SetRenderTarget(motionRT);
		this.m_renderCB.ClearRenderTarget(true, clearColor, Color.black);
	}

	// Token: 0x06000946 RID: 2374 RVA: 0x0004AF44 File Offset: 0x00049144
	public void RenderVectors(float scale, float fixedScale, Quality quality)
	{
		if (!this.m_initialized)
		{
			this.Initialize();
		}
		float nearClipPlane = this.m_camera.nearClipPlane;
		float farClipPlane = this.m_camera.farClipPlane;
		Vector4 vector;
		if (AmplifyMotionEffectBase.IsD3D)
		{
			vector.x = 1f - farClipPlane / nearClipPlane;
			vector.y = farClipPlane / nearClipPlane;
		}
		else
		{
			vector.x = (1f - farClipPlane / nearClipPlane) / 2f;
			vector.y = (1f + farClipPlane / nearClipPlane) / 2f;
		}
		vector.z = vector.x / farClipPlane;
		vector.w = vector.y / farClipPlane;
		this.m_renderCB.SetGlobalVector("_AM_ZBUFFER_PARAMS", vector);
		if (this.m_affectedObjectsChanged)
		{
			this.UpdateAffectedObjects();
		}
		for (int i = 0; i < this.m_affectedObjects.Length; i++)
		{
			if ((this.m_camera.cullingMask & 1 << this.m_affectedObjects[i].gameObject.layer) != 0)
			{
				this.m_affectedObjects[i].OnRenderVectors(this.m_camera, this.m_renderCB, this.m_affectedObjects[i].FixedStep ? fixedScale : scale, quality);
			}
		}
	}

	// Token: 0x040007EF RID: 2031
	internal AmplifyMotionEffectBase Instance;

	// Token: 0x040007F0 RID: 2032
	internal Matrix4x4 PrevViewProjMatrix;

	// Token: 0x040007F1 RID: 2033
	internal Matrix4x4 ViewProjMatrix;

	// Token: 0x040007F2 RID: 2034
	internal Matrix4x4 InvViewProjMatrix;

	// Token: 0x040007F3 RID: 2035
	internal Matrix4x4 PrevViewProjMatrixRT;

	// Token: 0x040007F4 RID: 2036
	internal Matrix4x4 ViewProjMatrixRT;

	// Token: 0x040007F5 RID: 2037
	internal Transform Transform;

	// Token: 0x040007F6 RID: 2038
	private bool m_linked;

	// Token: 0x040007F7 RID: 2039
	private bool m_initialized;

	// Token: 0x040007F8 RID: 2040
	private bool m_starting = true;

	// Token: 0x040007F9 RID: 2041
	private bool m_autoStep = true;

	// Token: 0x040007FA RID: 2042
	private bool m_step;

	// Token: 0x040007FB RID: 2043
	private bool m_overlay;

	// Token: 0x040007FC RID: 2044
	private Camera m_camera;

	// Token: 0x040007FD RID: 2045
	private int m_prevFrameCount;

	// Token: 0x040007FE RID: 2046
	private HashSet<AmplifyMotionObjectBase> m_affectedObjectsTable = new HashSet<AmplifyMotionObjectBase>();

	// Token: 0x040007FF RID: 2047
	private AmplifyMotionObjectBase[] m_affectedObjects;

	// Token: 0x04000800 RID: 2048
	private bool m_affectedObjectsChanged = true;

	// Token: 0x04000801 RID: 2049
	private const CameraEvent m_renderCBEvent = CameraEvent.BeforeImageEffects;

	// Token: 0x04000802 RID: 2050
	private CommandBuffer m_renderCB;
}
