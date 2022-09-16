// Decompiled with JetBrains decompiler
// Type: AmplifyMotionObjectBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using AmplifyMotion;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[AddComponentMenu("")]
public class AmplifyMotionObjectBase : MonoBehaviour
{
  internal static bool ApplyToChildren = true;
  [SerializeField]
  private bool m_applyToChildren = AmplifyMotionObjectBase.ApplyToChildren;
  private ObjectType m_type;
  private Dictionary<Camera, MotionState> m_states = new Dictionary<Camera, MotionState>();
  private bool m_fixedStep;
  private int m_objectId;
  private Vector3 m_lastPosition = Vector3.zero;
  private int m_resetAtFrame = -1;

  internal bool FixedStep => this.m_fixedStep;

  internal int ObjectId => this.m_objectId;

  public ObjectType Type => this.m_type;

  internal void RegisterCamera(AmplifyMotionCamera camera)
  {
    Camera component = camera.GetComponent<Camera>();
    if ((component.cullingMask & 1 << this.gameObject.layer) == 0 || this.m_states.ContainsKey(component))
      return;
    MotionState motionState;
    switch (this.m_type)
    {
      case ObjectType.Solid:
        motionState = (MotionState) new SolidState(camera, this);
        break;
      case ObjectType.Skinned:
        motionState = (MotionState) new SkinnedState(camera, this);
        break;
      case ObjectType.Cloth:
        motionState = (MotionState) new ClothState(camera, this);
        break;
      case ObjectType.Particle:
        motionState = (MotionState) new ParticleState(camera, this);
        break;
      default:
        throw new Exception("[AmplifyMotion] Invalid object type.");
    }
    camera.RegisterObject(this);
    this.m_states.Add(component, motionState);
  }

  internal void UnregisterCamera(AmplifyMotionCamera camera)
  {
    Camera component = camera.GetComponent<Camera>();
    MotionState motionState;
    if (!this.m_states.TryGetValue(component, out motionState))
      return;
    camera.UnregisterObject(this);
    if (this.m_states.TryGetValue(component, out motionState))
      motionState.Shutdown();
    this.m_states.Remove(component);
  }

  private bool InitializeType()
  {
    Renderer component = this.GetComponent<Renderer>();
    if (AmplifyMotionEffectBase.CanRegister(this.gameObject, false))
    {
      if ((UnityEngine.Object) this.GetComponent<ParticleSystem>() != (UnityEngine.Object) null)
      {
        this.m_type = ObjectType.Particle;
        AmplifyMotionEffectBase.RegisterObject(this);
      }
      else if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      {
        if (((object) component).GetType() == typeof (MeshRenderer))
          this.m_type = ObjectType.Solid;
        else if (((object) component).GetType() == typeof (SkinnedMeshRenderer))
          this.m_type = !((UnityEngine.Object) this.GetComponent<Cloth>() != (UnityEngine.Object) null) ? ObjectType.Skinned : ObjectType.Cloth;
        AmplifyMotionEffectBase.RegisterObject(this);
      }
    }
    return (UnityEngine.Object) component != (UnityEngine.Object) null;
  }

  private void OnEnable()
  {
    bool flag = this.InitializeType();
    if (flag)
    {
      if (this.m_type == ObjectType.Cloth)
        this.m_fixedStep = false;
      else if (this.m_type == ObjectType.Solid)
      {
        Rigidbody component = this.GetComponent<Rigidbody>();
        if ((UnityEngine.Object) component != (UnityEngine.Object) null && component.interpolation == RigidbodyInterpolation.None && !component.isKinematic)
          this.m_fixedStep = true;
      }
    }
    if (this.m_applyToChildren)
    {
      foreach (Component component in this.gameObject.transform)
        AmplifyMotionEffectBase.RegisterRecursivelyS(component.gameObject);
    }
    if (flag)
      return;
    this.enabled = false;
  }

  private void OnDisable() => AmplifyMotionEffectBase.UnregisterObject(this);

  private void TryInitializeStates()
  {
    Dictionary<Camera, MotionState>.Enumerator enumerator = this.m_states.GetEnumerator();
    while (enumerator.MoveNext())
    {
      MotionState motionState = enumerator.Current.Value;
      if (motionState.Owner.Initialized && !motionState.Error && !motionState.Initialized)
        motionState.Initialize();
    }
  }

  private void Start()
  {
    if ((UnityEngine.Object) AmplifyMotionEffectBase.Instance != (UnityEngine.Object) null)
      this.TryInitializeStates();
    this.m_lastPosition = this.transform.position;
  }

  private void Update()
  {
    if (!((UnityEngine.Object) AmplifyMotionEffectBase.Instance != (UnityEngine.Object) null))
      return;
    this.TryInitializeStates();
  }

  private static void RecursiveResetMotionAtFrame(
    Transform transform,
    AmplifyMotionObjectBase obj,
    int frame)
  {
    if ((UnityEngine.Object) obj != (UnityEngine.Object) null)
      obj.m_resetAtFrame = frame;
    foreach (Transform transform1 in transform)
      AmplifyMotionObjectBase.RecursiveResetMotionAtFrame(transform1, transform1.GetComponent<AmplifyMotionObjectBase>(), frame);
  }

  public void ResetMotionNow() => AmplifyMotionObjectBase.RecursiveResetMotionAtFrame(this.transform, this, Time.frameCount);

  public void ResetMotionAtFrame(int frame) => AmplifyMotionObjectBase.RecursiveResetMotionAtFrame(this.transform, this, frame);

  private void CheckTeleportReset(AmplifyMotionEffectBase inst)
  {
    if ((double) Vector3.SqrMagnitude(this.transform.position - this.m_lastPosition) <= (double) inst.MinResetDeltaDistSqr)
      return;
    AmplifyMotionObjectBase.RecursiveResetMotionAtFrame(this.transform, this, Time.frameCount + inst.ResetFrameDelay);
  }

  internal void OnUpdateTransform(
    AmplifyMotionEffectBase inst,
    Camera camera,
    CommandBuffer updateCB,
    bool starting)
  {
    MotionState motionState;
    if (this.m_states.TryGetValue(camera, out motionState) && !motionState.Error)
    {
      this.CheckTeleportReset(inst);
      bool flag = this.m_resetAtFrame > 0 && Time.frameCount >= this.m_resetAtFrame;
      motionState.UpdateTransform(updateCB, starting | flag);
    }
    this.m_lastPosition = this.transform.position;
  }

  internal void OnRenderVectors(
    Camera camera,
    CommandBuffer renderCB,
    float scale,
    AmplifyMotion.Quality quality)
  {
    MotionState motionState;
    if (!this.m_states.TryGetValue(camera, out motionState) || motionState.Error)
      return;
    motionState.RenderVectors(camera, renderCB, scale, quality);
    if (this.m_resetAtFrame <= 0 || Time.frameCount < this.m_resetAtFrame)
      return;
    this.m_resetAtFrame = -1;
  }

  public enum MinMaxCurveState
  {
    Scalar,
    Curve,
    TwoCurves,
    TwoScalars,
  }
}
