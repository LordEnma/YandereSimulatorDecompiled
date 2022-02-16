using System;
using System.Collections.Generic;
using AmplifyMotion;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x020000B6 RID: 182
[AddComponentMenu("")]
public class AmplifyMotionObjectBase : MonoBehaviour
{
	// Token: 0x170001EF RID: 495
	// (get) Token: 0x0600094C RID: 2380 RVA: 0x0004ADC8 File Offset: 0x00048FC8
	internal bool FixedStep
	{
		get
		{
			return this.m_fixedStep;
		}
	}

	// Token: 0x170001F0 RID: 496
	// (get) Token: 0x0600094D RID: 2381 RVA: 0x0004ADD0 File Offset: 0x00048FD0
	internal int ObjectId
	{
		get
		{
			return this.m_objectId;
		}
	}

	// Token: 0x170001F1 RID: 497
	// (get) Token: 0x0600094E RID: 2382 RVA: 0x0004ADD8 File Offset: 0x00048FD8
	public ObjectType Type
	{
		get
		{
			return this.m_type;
		}
	}

	// Token: 0x0600094F RID: 2383 RVA: 0x0004ADE0 File Offset: 0x00048FE0
	internal void RegisterCamera(AmplifyMotionCamera camera)
	{
		Camera component = camera.GetComponent<Camera>();
		if ((component.cullingMask & 1 << base.gameObject.layer) != 0 && !this.m_states.ContainsKey(component))
		{
			MotionState value;
			switch (this.m_type)
			{
			case ObjectType.Solid:
				value = new SolidState(camera, this);
				break;
			case ObjectType.Skinned:
				value = new SkinnedState(camera, this);
				break;
			case ObjectType.Cloth:
				value = new ClothState(camera, this);
				break;
			case ObjectType.Particle:
				value = new ParticleState(camera, this);
				break;
			default:
				throw new Exception("[AmplifyMotion] Invalid object type.");
			}
			camera.RegisterObject(this);
			this.m_states.Add(component, value);
		}
	}

	// Token: 0x06000950 RID: 2384 RVA: 0x0004AE88 File Offset: 0x00049088
	internal void UnregisterCamera(AmplifyMotionCamera camera)
	{
		Camera component = camera.GetComponent<Camera>();
		MotionState motionState;
		if (this.m_states.TryGetValue(component, out motionState))
		{
			camera.UnregisterObject(this);
			if (this.m_states.TryGetValue(component, out motionState))
			{
				motionState.Shutdown();
			}
			this.m_states.Remove(component);
		}
	}

	// Token: 0x06000951 RID: 2385 RVA: 0x0004AED8 File Offset: 0x000490D8
	private bool InitializeType()
	{
		Renderer component = base.GetComponent<Renderer>();
		if (AmplifyMotionEffectBase.CanRegister(base.gameObject, false))
		{
			if (base.GetComponent<ParticleSystem>() != null)
			{
				this.m_type = ObjectType.Particle;
				AmplifyMotionEffectBase.RegisterObject(this);
			}
			else if (component != null)
			{
				if (component.GetType() == typeof(MeshRenderer))
				{
					this.m_type = ObjectType.Solid;
				}
				else if (component.GetType() == typeof(SkinnedMeshRenderer))
				{
					if (base.GetComponent<Cloth>() != null)
					{
						this.m_type = ObjectType.Cloth;
					}
					else
					{
						this.m_type = ObjectType.Skinned;
					}
				}
				AmplifyMotionEffectBase.RegisterObject(this);
			}
		}
		return component != null;
	}

	// Token: 0x06000952 RID: 2386 RVA: 0x0004AF88 File Offset: 0x00049188
	private void OnEnable()
	{
		bool flag = this.InitializeType();
		if (flag)
		{
			if (this.m_type == ObjectType.Cloth)
			{
				this.m_fixedStep = false;
			}
			else if (this.m_type == ObjectType.Solid)
			{
				Rigidbody component = base.GetComponent<Rigidbody>();
				if (component != null && component.interpolation == RigidbodyInterpolation.None && !component.isKinematic)
				{
					this.m_fixedStep = true;
				}
			}
		}
		if (this.m_applyToChildren)
		{
			foreach (object obj in base.gameObject.transform)
			{
				AmplifyMotionEffectBase.RegisterRecursivelyS(((Transform)obj).gameObject);
			}
		}
		if (!flag)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000953 RID: 2387 RVA: 0x0004B048 File Offset: 0x00049248
	private void OnDisable()
	{
		AmplifyMotionEffectBase.UnregisterObject(this);
	}

	// Token: 0x06000954 RID: 2388 RVA: 0x0004B050 File Offset: 0x00049250
	private void TryInitializeStates()
	{
		foreach (KeyValuePair<Camera, MotionState> keyValuePair in this.m_states)
		{
			MotionState value = keyValuePair.Value;
			if (value.Owner.Initialized && !value.Error && !value.Initialized)
			{
				value.Initialize();
			}
		}
	}

	// Token: 0x06000955 RID: 2389 RVA: 0x0004B0A7 File Offset: 0x000492A7
	private void Start()
	{
		if (AmplifyMotionEffectBase.Instance != null)
		{
			this.TryInitializeStates();
		}
		this.m_lastPosition = base.transform.position;
	}

	// Token: 0x06000956 RID: 2390 RVA: 0x0004B0CD File Offset: 0x000492CD
	private void Update()
	{
		if (AmplifyMotionEffectBase.Instance != null)
		{
			this.TryInitializeStates();
		}
	}

	// Token: 0x06000957 RID: 2391 RVA: 0x0004B0E4 File Offset: 0x000492E4
	private static void RecursiveResetMotionAtFrame(Transform transform, AmplifyMotionObjectBase obj, int frame)
	{
		if (obj != null)
		{
			obj.m_resetAtFrame = frame;
		}
		foreach (object obj2 in transform)
		{
			Transform transform2 = (Transform)obj2;
			AmplifyMotionObjectBase.RecursiveResetMotionAtFrame(transform2, transform2.GetComponent<AmplifyMotionObjectBase>(), frame);
		}
	}

	// Token: 0x06000958 RID: 2392 RVA: 0x0004B14C File Offset: 0x0004934C
	public void ResetMotionNow()
	{
		AmplifyMotionObjectBase.RecursiveResetMotionAtFrame(base.transform, this, Time.frameCount);
	}

	// Token: 0x06000959 RID: 2393 RVA: 0x0004B15F File Offset: 0x0004935F
	public void ResetMotionAtFrame(int frame)
	{
		AmplifyMotionObjectBase.RecursiveResetMotionAtFrame(base.transform, this, frame);
	}

	// Token: 0x0600095A RID: 2394 RVA: 0x0004B16E File Offset: 0x0004936E
	private void CheckTeleportReset(AmplifyMotionEffectBase inst)
	{
		if (Vector3.SqrMagnitude(base.transform.position - this.m_lastPosition) > inst.MinResetDeltaDistSqr)
		{
			AmplifyMotionObjectBase.RecursiveResetMotionAtFrame(base.transform, this, Time.frameCount + inst.ResetFrameDelay);
		}
	}

	// Token: 0x0600095B RID: 2395 RVA: 0x0004B1AC File Offset: 0x000493AC
	internal void OnUpdateTransform(AmplifyMotionEffectBase inst, Camera camera, CommandBuffer updateCB, bool starting)
	{
		MotionState motionState;
		if (this.m_states.TryGetValue(camera, out motionState) && !motionState.Error)
		{
			this.CheckTeleportReset(inst);
			bool flag = this.m_resetAtFrame > 0 && Time.frameCount >= this.m_resetAtFrame;
			motionState.UpdateTransform(updateCB, starting || flag);
		}
		this.m_lastPosition = base.transform.position;
	}

	// Token: 0x0600095C RID: 2396 RVA: 0x0004B214 File Offset: 0x00049414
	internal void OnRenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
	{
		MotionState motionState;
		if (this.m_states.TryGetValue(camera, out motionState) && !motionState.Error)
		{
			motionState.RenderVectors(camera, renderCB, scale, quality);
			if (this.m_resetAtFrame > 0 && Time.frameCount >= this.m_resetAtFrame)
			{
				this.m_resetAtFrame = -1;
			}
		}
	}

	// Token: 0x040007F8 RID: 2040
	internal static bool ApplyToChildren = true;

	// Token: 0x040007F9 RID: 2041
	[SerializeField]
	private bool m_applyToChildren = AmplifyMotionObjectBase.ApplyToChildren;

	// Token: 0x040007FA RID: 2042
	private ObjectType m_type;

	// Token: 0x040007FB RID: 2043
	private Dictionary<Camera, MotionState> m_states = new Dictionary<Camera, MotionState>();

	// Token: 0x040007FC RID: 2044
	private bool m_fixedStep;

	// Token: 0x040007FD RID: 2045
	private int m_objectId;

	// Token: 0x040007FE RID: 2046
	private Vector3 m_lastPosition = Vector3.zero;

	// Token: 0x040007FF RID: 2047
	private int m_resetAtFrame = -1;

	// Token: 0x02000644 RID: 1604
	public enum MinMaxCurveState
	{
		// Token: 0x04004E8A RID: 20106
		Scalar,
		// Token: 0x04004E8B RID: 20107
		Curve,
		// Token: 0x04004E8C RID: 20108
		TwoCurves,
		// Token: 0x04004E8D RID: 20109
		TwoScalars
	}
}
