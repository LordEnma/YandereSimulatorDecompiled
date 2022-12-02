using System.Collections.Generic;
using AmplifyMotion;
using UnityEngine;
using UnityEngine.Rendering;

[AddComponentMenu("")]
[RequireComponent(typeof(Camera))]
public class AmplifyMotionCamera : MonoBehaviour
{
	internal AmplifyMotionEffectBase Instance;

	internal Matrix4x4 PrevViewProjMatrix;

	internal Matrix4x4 ViewProjMatrix;

	internal Matrix4x4 InvViewProjMatrix;

	internal Matrix4x4 PrevViewProjMatrixRT;

	internal Matrix4x4 ViewProjMatrixRT;

	internal Transform Transform;

	private bool m_linked;

	private bool m_initialized;

	private bool m_starting = true;

	private bool m_autoStep = true;

	private bool m_step;

	private bool m_overlay;

	private Camera m_camera;

	private int m_prevFrameCount;

	private HashSet<AmplifyMotionObjectBase> m_affectedObjectsTable = new HashSet<AmplifyMotionObjectBase>();

	private AmplifyMotionObjectBase[] m_affectedObjects;

	private bool m_affectedObjectsChanged = true;

	private const CameraEvent m_renderCBEvent = CameraEvent.BeforeImageEffects;

	private CommandBuffer m_renderCB;

	public bool Initialized
	{
		get
		{
			return m_initialized;
		}
	}

	public bool AutoStep
	{
		get
		{
			return m_autoStep;
		}
	}

	public bool Overlay
	{
		get
		{
			return m_overlay;
		}
	}

	public Camera Camera
	{
		get
		{
			return m_camera;
		}
	}

	public void RegisterObject(AmplifyMotionObjectBase obj)
	{
		m_affectedObjectsTable.Add(obj);
		m_affectedObjectsChanged = true;
	}

	public void UnregisterObject(AmplifyMotionObjectBase obj)
	{
		m_affectedObjectsTable.Remove(obj);
		m_affectedObjectsChanged = true;
	}

	private void UpdateAffectedObjects()
	{
		if (m_affectedObjects == null || m_affectedObjectsTable.Count != m_affectedObjects.Length)
		{
			m_affectedObjects = new AmplifyMotionObjectBase[m_affectedObjectsTable.Count];
		}
		m_affectedObjectsTable.CopyTo(m_affectedObjects);
		m_affectedObjectsChanged = false;
	}

	public void LinkTo(AmplifyMotionEffectBase instance, bool overlay)
	{
		Instance = instance;
		m_camera = GetComponent<Camera>();
		m_camera.depthTextureMode |= DepthTextureMode.Depth;
		InitializeCommandBuffers();
		m_overlay = overlay;
		m_linked = true;
	}

	public void Initialize()
	{
		m_step = false;
		UpdateMatrices();
		m_initialized = true;
	}

	private void InitializeCommandBuffers()
	{
		ShutdownCommandBuffers();
		m_renderCB = new CommandBuffer();
		m_renderCB.name = "AmplifyMotion.Render";
		m_camera.AddCommandBuffer(CameraEvent.BeforeImageEffects, m_renderCB);
	}

	private void ShutdownCommandBuffers()
	{
		if (m_renderCB != null)
		{
			m_camera.RemoveCommandBuffer(CameraEvent.BeforeImageEffects, m_renderCB);
			m_renderCB.Release();
			m_renderCB = null;
		}
	}

	private void Awake()
	{
		Transform = base.transform;
	}

	private void OnEnable()
	{
		AmplifyMotionEffectBase.RegisterCamera(this);
	}

	private void OnDisable()
	{
		m_initialized = false;
		ShutdownCommandBuffers();
		AmplifyMotionEffectBase.UnregisterCamera(this);
	}

	private void OnDestroy()
	{
		if (Instance != null)
		{
			Instance.RemoveCamera(m_camera);
		}
	}

	public void StopAutoStep()
	{
		if (m_autoStep)
		{
			m_autoStep = false;
			m_step = true;
		}
	}

	public void StartAutoStep()
	{
		m_autoStep = true;
	}

	public void Step()
	{
		m_step = true;
	}

	private void Update()
	{
		if (m_linked && Instance.isActiveAndEnabled)
		{
			if (!m_initialized)
			{
				Initialize();
			}
			if ((m_camera.depthTextureMode & DepthTextureMode.Depth) == 0)
			{
				m_camera.depthTextureMode |= DepthTextureMode.Depth;
			}
		}
	}

	private void UpdateMatrices()
	{
		if (!m_starting)
		{
			PrevViewProjMatrix = ViewProjMatrix;
			PrevViewProjMatrixRT = ViewProjMatrixRT;
		}
		Matrix4x4 worldToCameraMatrix = m_camera.worldToCameraMatrix;
		Matrix4x4 gPUProjectionMatrix = GL.GetGPUProjectionMatrix(m_camera.projectionMatrix, false);
		ViewProjMatrix = gPUProjectionMatrix * worldToCameraMatrix;
		InvViewProjMatrix = Matrix4x4.Inverse(ViewProjMatrix);
		Matrix4x4 gPUProjectionMatrix2 = GL.GetGPUProjectionMatrix(m_camera.projectionMatrix, true);
		ViewProjMatrixRT = gPUProjectionMatrix2 * worldToCameraMatrix;
		if (m_starting)
		{
			PrevViewProjMatrix = ViewProjMatrix;
			PrevViewProjMatrixRT = ViewProjMatrixRT;
		}
	}

	public void FixedUpdateTransform(AmplifyMotionEffectBase inst, CommandBuffer updateCB)
	{
		if (!m_initialized)
		{
			Initialize();
		}
		if (m_affectedObjectsChanged)
		{
			UpdateAffectedObjects();
		}
		for (int i = 0; i < m_affectedObjects.Length; i++)
		{
			if (m_affectedObjects[i].FixedStep)
			{
				m_affectedObjects[i].OnUpdateTransform(inst, m_camera, updateCB, m_starting);
			}
		}
	}

	public void UpdateTransform(AmplifyMotionEffectBase inst, CommandBuffer updateCB)
	{
		if (!m_initialized)
		{
			Initialize();
		}
		if (Time.frameCount <= m_prevFrameCount || (!m_autoStep && !m_step))
		{
			return;
		}
		UpdateMatrices();
		if (m_affectedObjectsChanged)
		{
			UpdateAffectedObjects();
		}
		for (int i = 0; i < m_affectedObjects.Length; i++)
		{
			if (!m_affectedObjects[i].FixedStep)
			{
				m_affectedObjects[i].OnUpdateTransform(inst, m_camera, updateCB, m_starting);
			}
		}
		m_starting = false;
		m_step = false;
		m_prevFrameCount = Time.frameCount;
	}

	public void RenderReprojectionVectors(RenderTexture destination, float scale)
	{
		m_renderCB.SetGlobalMatrix("_AM_MATRIX_CURR_REPROJ", PrevViewProjMatrix * InvViewProjMatrix);
		m_renderCB.SetGlobalFloat("_AM_MOTION_SCALE", scale);
		RenderTexture tex = null;
		m_renderCB.Blit(new RenderTargetIdentifier(tex), destination, Instance.ReprojectionMaterial);
	}

	public void PreRenderVectors(RenderTexture motionRT, bool clearColor, float rcpDepthThreshold)
	{
		m_renderCB.Clear();
		m_renderCB.SetGlobalFloat("_AM_MIN_VELOCITY", Instance.MinVelocity);
		m_renderCB.SetGlobalFloat("_AM_MAX_VELOCITY", Instance.MaxVelocity);
		m_renderCB.SetGlobalFloat("_AM_RCP_TOTAL_VELOCITY", 1f / (Instance.MaxVelocity - Instance.MinVelocity));
		m_renderCB.SetGlobalVector("_AM_DEPTH_THRESHOLD", new Vector2(Instance.DepthThreshold, rcpDepthThreshold));
		m_renderCB.SetRenderTarget(motionRT);
		m_renderCB.ClearRenderTarget(true, clearColor, Color.black);
	}

	public void RenderVectors(float scale, float fixedScale, Quality quality)
	{
		if (!m_initialized)
		{
			Initialize();
		}
		float nearClipPlane = m_camera.nearClipPlane;
		float farClipPlane = m_camera.farClipPlane;
		Vector4 value = default(Vector4);
		if (AmplifyMotionEffectBase.IsD3D)
		{
			value.x = 1f - farClipPlane / nearClipPlane;
			value.y = farClipPlane / nearClipPlane;
		}
		else
		{
			value.x = (1f - farClipPlane / nearClipPlane) / 2f;
			value.y = (1f + farClipPlane / nearClipPlane) / 2f;
		}
		value.z = value.x / farClipPlane;
		value.w = value.y / farClipPlane;
		m_renderCB.SetGlobalVector("_AM_ZBUFFER_PARAMS", value);
		if (m_affectedObjectsChanged)
		{
			UpdateAffectedObjects();
		}
		for (int i = 0; i < m_affectedObjects.Length; i++)
		{
			if ((m_camera.cullingMask & (1 << m_affectedObjects[i].gameObject.layer)) != 0)
			{
				m_affectedObjects[i].OnRenderVectors(m_camera, m_renderCB, m_affectedObjects[i].FixedStep ? fixedScale : scale, quality);
			}
		}
	}
}
