// Decompiled with JetBrains decompiler
// Type: AmplifyMotionCamera
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[AddComponentMenu("")]
[RequireComponent(typeof (Camera))]
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

  public bool Initialized => this.m_initialized;

  public bool AutoStep => this.m_autoStep;

  public bool Overlay => this.m_overlay;

  public Camera Camera => this.m_camera;

  public void RegisterObject(AmplifyMotionObjectBase obj)
  {
    this.m_affectedObjectsTable.Add(obj);
    this.m_affectedObjectsChanged = true;
  }

  public void UnregisterObject(AmplifyMotionObjectBase obj)
  {
    this.m_affectedObjectsTable.Remove(obj);
    this.m_affectedObjectsChanged = true;
  }

  private void UpdateAffectedObjects()
  {
    if (this.m_affectedObjects == null || this.m_affectedObjectsTable.Count != this.m_affectedObjects.Length)
      this.m_affectedObjects = new AmplifyMotionObjectBase[this.m_affectedObjectsTable.Count];
    this.m_affectedObjectsTable.CopyTo(this.m_affectedObjects);
    this.m_affectedObjectsChanged = false;
  }

  public void LinkTo(AmplifyMotionEffectBase instance, bool overlay)
  {
    this.Instance = instance;
    this.m_camera = this.GetComponent<Camera>();
    this.m_camera.depthTextureMode |= DepthTextureMode.Depth;
    this.InitializeCommandBuffers();
    this.m_overlay = overlay;
    this.m_linked = true;
  }

  public void Initialize()
  {
    this.m_step = false;
    this.UpdateMatrices();
    this.m_initialized = true;
  }

  private void InitializeCommandBuffers()
  {
    this.ShutdownCommandBuffers();
    this.m_renderCB = new CommandBuffer();
    this.m_renderCB.name = "AmplifyMotion.Render";
    this.m_camera.AddCommandBuffer(CameraEvent.BeforeImageEffects, this.m_renderCB);
  }

  private void ShutdownCommandBuffers()
  {
    if (this.m_renderCB == null)
      return;
    this.m_camera.RemoveCommandBuffer(CameraEvent.BeforeImageEffects, this.m_renderCB);
    this.m_renderCB.Release();
    this.m_renderCB = (CommandBuffer) null;
  }

  private void Awake() => this.Transform = this.transform;

  private void OnEnable() => AmplifyMotionEffectBase.RegisterCamera(this);

  private void OnDisable()
  {
    this.m_initialized = false;
    this.ShutdownCommandBuffers();
    AmplifyMotionEffectBase.UnregisterCamera(this);
  }

  private void OnDestroy()
  {
    if (!((Object) this.Instance != (Object) null))
      return;
    this.Instance.RemoveCamera(this.m_camera);
  }

  public void StopAutoStep()
  {
    if (!this.m_autoStep)
      return;
    this.m_autoStep = false;
    this.m_step = true;
  }

  public void StartAutoStep() => this.m_autoStep = true;

  public void Step() => this.m_step = true;

  private void Update()
  {
    if (!this.m_linked || !this.Instance.isActiveAndEnabled)
      return;
    if (!this.m_initialized)
      this.Initialize();
    if ((this.m_camera.depthTextureMode & DepthTextureMode.Depth) != DepthTextureMode.None)
      return;
    this.m_camera.depthTextureMode |= DepthTextureMode.Depth;
  }

  private void UpdateMatrices()
  {
    if (!this.m_starting)
    {
      this.PrevViewProjMatrix = this.ViewProjMatrix;
      this.PrevViewProjMatrixRT = this.ViewProjMatrixRT;
    }
    Matrix4x4 worldToCameraMatrix = this.m_camera.worldToCameraMatrix;
    this.ViewProjMatrix = GL.GetGPUProjectionMatrix(this.m_camera.projectionMatrix, false) * worldToCameraMatrix;
    this.InvViewProjMatrix = Matrix4x4.Inverse(this.ViewProjMatrix);
    this.ViewProjMatrixRT = GL.GetGPUProjectionMatrix(this.m_camera.projectionMatrix, true) * worldToCameraMatrix;
    if (!this.m_starting)
      return;
    this.PrevViewProjMatrix = this.ViewProjMatrix;
    this.PrevViewProjMatrixRT = this.ViewProjMatrixRT;
  }

  public void FixedUpdateTransform(AmplifyMotionEffectBase inst, CommandBuffer updateCB)
  {
    if (!this.m_initialized)
      this.Initialize();
    if (this.m_affectedObjectsChanged)
      this.UpdateAffectedObjects();
    for (int index = 0; index < this.m_affectedObjects.Length; ++index)
    {
      if (this.m_affectedObjects[index].FixedStep)
        this.m_affectedObjects[index].OnUpdateTransform(inst, this.m_camera, updateCB, this.m_starting);
    }
  }

  public void UpdateTransform(AmplifyMotionEffectBase inst, CommandBuffer updateCB)
  {
    if (!this.m_initialized)
      this.Initialize();
    if (Time.frameCount <= this.m_prevFrameCount || !this.m_autoStep && !this.m_step)
      return;
    this.UpdateMatrices();
    if (this.m_affectedObjectsChanged)
      this.UpdateAffectedObjects();
    for (int index = 0; index < this.m_affectedObjects.Length; ++index)
    {
      if (!this.m_affectedObjects[index].FixedStep)
        this.m_affectedObjects[index].OnUpdateTransform(inst, this.m_camera, updateCB, this.m_starting);
    }
    this.m_starting = false;
    this.m_step = false;
    this.m_prevFrameCount = Time.frameCount;
  }

  public void RenderReprojectionVectors(RenderTexture destination, float scale)
  {
    this.m_renderCB.SetGlobalMatrix("_AM_MATRIX_CURR_REPROJ", this.PrevViewProjMatrix * this.InvViewProjMatrix);
    this.m_renderCB.SetGlobalFloat("_AM_MOTION_SCALE", scale);
    this.m_renderCB.Blit(new RenderTargetIdentifier((Texture) null), (RenderTargetIdentifier) (Texture) destination, this.Instance.ReprojectionMaterial);
  }

  public void PreRenderVectors(RenderTexture motionRT, bool clearColor, float rcpDepthThreshold)
  {
    this.m_renderCB.Clear();
    this.m_renderCB.SetGlobalFloat("_AM_MIN_VELOCITY", this.Instance.MinVelocity);
    this.m_renderCB.SetGlobalFloat("_AM_MAX_VELOCITY", this.Instance.MaxVelocity);
    this.m_renderCB.SetGlobalFloat("_AM_RCP_TOTAL_VELOCITY", (float) (1.0 / ((double) this.Instance.MaxVelocity - (double) this.Instance.MinVelocity)));
    this.m_renderCB.SetGlobalVector("_AM_DEPTH_THRESHOLD", (Vector4) new Vector2(this.Instance.DepthThreshold, rcpDepthThreshold));
    this.m_renderCB.SetRenderTarget((RenderTargetIdentifier) (Texture) motionRT);
    this.m_renderCB.ClearRenderTarget(true, clearColor, Color.black);
  }

  public void RenderVectors(float scale, float fixedScale, AmplifyMotion.Quality quality)
  {
    if (!this.m_initialized)
      this.Initialize();
    float nearClipPlane = this.m_camera.nearClipPlane;
    float farClipPlane = this.m_camera.farClipPlane;
    Vector4 vector4;
    if (AmplifyMotionEffectBase.IsD3D)
    {
      vector4.x = (float) (1.0 - (double) farClipPlane / (double) nearClipPlane);
      vector4.y = farClipPlane / nearClipPlane;
    }
    else
    {
      vector4.x = (float) ((1.0 - (double) farClipPlane / (double) nearClipPlane) / 2.0);
      vector4.y = (float) ((1.0 + (double) farClipPlane / (double) nearClipPlane) / 2.0);
    }
    vector4.z = vector4.x / farClipPlane;
    vector4.w = vector4.y / farClipPlane;
    this.m_renderCB.SetGlobalVector("_AM_ZBUFFER_PARAMS", vector4);
    if (this.m_affectedObjectsChanged)
      this.UpdateAffectedObjects();
    for (int index = 0; index < this.m_affectedObjects.Length; ++index)
    {
      if ((this.m_camera.cullingMask & 1 << this.m_affectedObjects[index].gameObject.layer) != 0)
        this.m_affectedObjects[index].OnRenderVectors(this.m_camera, this.m_renderCB, this.m_affectedObjects[index].FixedStep ? fixedScale : scale, quality);
    }
  }
}
