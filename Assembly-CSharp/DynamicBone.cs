using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000294 RID: 660
[AddComponentMenu("Dynamic Bone/Dynamic Bone")]
public class DynamicBone : MonoBehaviour
{
	// Token: 0x060013C5 RID: 5061 RVA: 0x000BB6CC File Offset: 0x000B98CC
	private void Start()
	{
		if (SceneManager.GetActiveScene().name == "PortraitScene")
		{
			base.enabled = false;
			return;
		}
		GameObject gameObject = GameObject.Find("YandereChan");
		if (gameObject == null)
		{
			this.m_ReferenceObject = base.transform;
		}
		else
		{
			StudentManagerScript studentManager = gameObject.GetComponent<YandereScript>().StudentManager;
			if (!studentManager.TakingPortraits)
			{
				studentManager.AllDynamicBones[studentManager.Bones] = this;
				studentManager.Bones++;
			}
			this.m_ReferenceObject = gameObject.transform;
			if (OptionGlobals.HairPhysics)
			{
				base.enabled = false;
			}
		}
		this.MainCamera = Camera.main;
		this.SetupParticles();
	}

	// Token: 0x060013C6 RID: 5062 RVA: 0x000BB777 File Offset: 0x000B9977
	private void FixedUpdate()
	{
		if (this.m_UpdateMode == DynamicBone.UpdateMode.AnimatePhysics)
		{
			this.PreUpdate();
		}
	}

	// Token: 0x060013C7 RID: 5063 RVA: 0x000BB788 File Offset: 0x000B9988
	private void Update()
	{
		if (this.m_UpdateMode != DynamicBone.UpdateMode.AnimatePhysics)
		{
			this.PreUpdate();
		}
	}

	// Token: 0x060013C8 RID: 5064 RVA: 0x000BB79C File Offset: 0x000B999C
	private void LateUpdate()
	{
		this.CheckTimer += Time.deltaTime;
		if (this.CheckTimer > 1f)
		{
			if (this.m_DistantDisable)
			{
				this.CheckDistance();
			}
			this.CheckTimer = 0f;
		}
		if (this.m_Weight > 0f && (!this.m_DistantDisable || !this.m_DistantDisabled))
		{
			float deltaTime = Time.deltaTime;
			this.UpdateDynamicBones(deltaTime);
		}
	}

	// Token: 0x060013C9 RID: 5065 RVA: 0x000BB80B File Offset: 0x000B9A0B
	private void PreUpdate()
	{
		if (this.m_Weight > 0f && (!this.m_DistantDisable || !this.m_DistantDisabled))
		{
			this.InitTransforms();
		}
	}

	// Token: 0x060013CA RID: 5066 RVA: 0x000BB830 File Offset: 0x000B9A30
	private void CheckDistance()
	{
		Transform transform = this.m_ReferenceObject;
		if (transform == null && this.MainCamera != null)
		{
			transform = this.MainCamera.transform;
		}
		if (transform != null)
		{
			bool flag = (transform.position - base.transform.position).sqrMagnitude > this.m_DistanceToObject * this.m_DistanceToObject;
			if (flag != this.m_DistantDisabled)
			{
				if (!flag)
				{
					this.ResetParticlesPosition();
				}
				this.m_DistantDisabled = flag;
			}
		}
	}

	// Token: 0x060013CB RID: 5067 RVA: 0x000BB8B7 File Offset: 0x000B9AB7
	private void OnEnable()
	{
		this.ResetParticlesPosition();
	}

	// Token: 0x060013CC RID: 5068 RVA: 0x000BB8BF File Offset: 0x000B9ABF
	private void OnDisable()
	{
		this.InitTransforms();
	}

	// Token: 0x060013CD RID: 5069 RVA: 0x000BB8C8 File Offset: 0x000B9AC8
	private void OnValidate()
	{
		this.m_UpdateRate = Mathf.Max(this.m_UpdateRate, 0f);
		this.m_Damping = Mathf.Clamp01(this.m_Damping);
		this.m_Elasticity = Mathf.Clamp01(this.m_Elasticity);
		this.m_Stiffness = Mathf.Clamp01(this.m_Stiffness);
		this.m_Inert = Mathf.Clamp01(this.m_Inert);
		this.m_Radius = Mathf.Max(this.m_Radius, 0f);
		if (Application.isEditor && Application.isPlaying)
		{
			this.InitTransforms();
			this.SetupParticles();
		}
	}

	// Token: 0x060013CE RID: 5070 RVA: 0x000BB960 File Offset: 0x000B9B60
	private void OnDrawGizmosSelected()
	{
		if (!base.enabled || this.m_Root == null)
		{
			return;
		}
		if (Application.isEditor && !Application.isPlaying && base.transform.hasChanged)
		{
			this.InitTransforms();
			this.SetupParticles();
		}
		Gizmos.color = Color.white;
		for (int i = 0; i < this.m_Particles.Count; i++)
		{
			DynamicBone.Particle particle = this.m_Particles[i];
			if (particle.m_ParentIndex >= 0)
			{
				DynamicBone.Particle particle2 = this.m_Particles[particle.m_ParentIndex];
				Gizmos.DrawLine(particle.m_Position, particle2.m_Position);
			}
			if (particle.m_Radius > 0f)
			{
				Gizmos.DrawWireSphere(particle.m_Position, particle.m_Radius * this.m_ObjectScale);
			}
		}
	}

	// Token: 0x060013CF RID: 5071 RVA: 0x000BBA29 File Offset: 0x000B9C29
	public void SetWeight(float w)
	{
		if (this.m_Weight != w)
		{
			if (w == 0f)
			{
				this.InitTransforms();
			}
			else if (this.m_Weight == 0f)
			{
				this.ResetParticlesPosition();
			}
			this.m_Weight = w;
		}
	}

	// Token: 0x060013D0 RID: 5072 RVA: 0x000BBA5E File Offset: 0x000B9C5E
	public float GetWeight()
	{
		return this.m_Weight;
	}

	// Token: 0x060013D1 RID: 5073 RVA: 0x000BBA68 File Offset: 0x000B9C68
	private void UpdateDynamicBones(float t)
	{
		if (this.m_Root == null)
		{
			return;
		}
		this.m_ObjectScale = Mathf.Abs(base.transform.lossyScale.x);
		this.m_ObjectMove = base.transform.position - this.m_ObjectPrevPosition;
		this.m_ObjectPrevPosition = base.transform.position;
		int num = 1;
		if (this.m_UpdateRate > 0f)
		{
			float num2 = 1f / this.m_UpdateRate;
			this.m_Time += t;
			num = 0;
			while (this.m_Time >= num2)
			{
				this.m_Time -= num2;
				if (++num >= 3)
				{
					this.m_Time = 0f;
					break;
				}
			}
		}
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				this.UpdateParticles1();
				this.UpdateParticles2();
				this.m_ObjectMove = Vector3.zero;
			}
		}
		else
		{
			this.SkipUpdateParticles();
		}
		this.ApplyParticlesToTransforms();
	}

	// Token: 0x060013D2 RID: 5074 RVA: 0x000BBB5C File Offset: 0x000B9D5C
	private void SetupParticles()
	{
		this.m_Particles.Clear();
		if (this.m_Root == null)
		{
			return;
		}
		this.m_LocalGravity = this.m_Root.InverseTransformDirection(this.m_Gravity);
		this.m_ObjectScale = Mathf.Abs(base.transform.lossyScale.x);
		this.m_ObjectPrevPosition = base.transform.position;
		this.m_ObjectMove = Vector3.zero;
		this.m_BoneTotalLength = 0f;
		this.AppendParticles(this.m_Root, -1, 0f);
		for (int i = 0; i < this.m_Particles.Count; i++)
		{
			DynamicBone.Particle particle = this.m_Particles[i];
			particle.m_Damping = this.m_Damping;
			particle.m_Elasticity = this.m_Elasticity;
			particle.m_Stiffness = this.m_Stiffness;
			particle.m_Inert = this.m_Inert;
			particle.m_Radius = this.m_Radius;
			if (this.m_BoneTotalLength > 0f)
			{
				float time = particle.m_BoneLength / this.m_BoneTotalLength;
				if (this.m_DampingDistrib != null && this.m_DampingDistrib.keys.Length != 0)
				{
					particle.m_Damping *= this.m_DampingDistrib.Evaluate(time);
				}
				if (this.m_ElasticityDistrib != null && this.m_ElasticityDistrib.keys.Length != 0)
				{
					particle.m_Elasticity *= this.m_ElasticityDistrib.Evaluate(time);
				}
				if (this.m_StiffnessDistrib != null && this.m_StiffnessDistrib.keys.Length != 0)
				{
					particle.m_Stiffness *= this.m_StiffnessDistrib.Evaluate(time);
				}
				if (this.m_InertDistrib != null && this.m_InertDistrib.keys.Length != 0)
				{
					particle.m_Inert *= this.m_InertDistrib.Evaluate(time);
				}
				if (this.m_RadiusDistrib != null && this.m_RadiusDistrib.keys.Length != 0)
				{
					particle.m_Radius *= this.m_RadiusDistrib.Evaluate(time);
				}
			}
			particle.m_Damping = Mathf.Clamp01(particle.m_Damping);
			particle.m_Elasticity = Mathf.Clamp01(particle.m_Elasticity);
			particle.m_Stiffness = Mathf.Clamp01(particle.m_Stiffness);
			particle.m_Inert = Mathf.Clamp01(particle.m_Inert);
			particle.m_Radius = Mathf.Max(particle.m_Radius, 0f);
		}
	}

	// Token: 0x060013D3 RID: 5075 RVA: 0x000BBDB8 File Offset: 0x000B9FB8
	private void AppendParticles(Transform b, int parentIndex, float boneLength)
	{
		DynamicBone.Particle particle = new DynamicBone.Particle();
		particle.m_Transform = b;
		particle.m_ParentIndex = parentIndex;
		if (b != null)
		{
			particle.m_Position = (particle.m_PrevPosition = b.position);
			particle.m_InitLocalPosition = b.localPosition;
			particle.m_InitLocalRotation = b.localRotation;
		}
		else
		{
			Transform transform = this.m_Particles[parentIndex].m_Transform;
			if (this.m_EndLength > 0f)
			{
				Transform parent = transform.parent;
				if (parent != null)
				{
					particle.m_EndOffset = transform.InverseTransformPoint(transform.position * 2f - parent.position) * this.m_EndLength;
				}
				else
				{
					particle.m_EndOffset = new Vector3(this.m_EndLength, 0f, 0f);
				}
			}
			else
			{
				particle.m_EndOffset = transform.InverseTransformPoint(base.transform.TransformDirection(this.m_EndOffset) + transform.position);
			}
			particle.m_Position = (particle.m_PrevPosition = transform.TransformPoint(particle.m_EndOffset));
		}
		if (parentIndex >= 0)
		{
			boneLength += (this.m_Particles[parentIndex].m_Transform.position - particle.m_Position).magnitude;
			particle.m_BoneLength = boneLength;
			this.m_BoneTotalLength = Mathf.Max(this.m_BoneTotalLength, boneLength);
		}
		int count = this.m_Particles.Count;
		this.m_Particles.Add(particle);
		if (b != null)
		{
			for (int i = 0; i < b.childCount; i++)
			{
				bool flag = false;
				if (this.m_Exclusions != null)
				{
					for (int j = 0; j < this.m_Exclusions.Count; j++)
					{
						if (this.m_Exclusions[j] == b.GetChild(i))
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					this.AppendParticles(b.GetChild(i), count, boneLength);
				}
			}
			if (b.childCount == 0 && (this.m_EndLength > 0f || this.m_EndOffset != Vector3.zero))
			{
				this.AppendParticles(null, count, boneLength);
			}
		}
	}

	// Token: 0x060013D4 RID: 5076 RVA: 0x000BBFE8 File Offset: 0x000BA1E8
	private void InitTransforms()
	{
		for (int i = 0; i < this.m_Particles.Count; i++)
		{
			DynamicBone.Particle particle = this.m_Particles[i];
			if (particle.m_Transform != null)
			{
				particle.m_Transform.localPosition = particle.m_InitLocalPosition;
				particle.m_Transform.localRotation = particle.m_InitLocalRotation;
			}
		}
	}

	// Token: 0x060013D5 RID: 5077 RVA: 0x000BC048 File Offset: 0x000BA248
	private void ResetParticlesPosition()
	{
		for (int i = 0; i < this.m_Particles.Count; i++)
		{
			DynamicBone.Particle particle = this.m_Particles[i];
			if (particle.m_Transform != null)
			{
				particle.m_Position = (particle.m_PrevPosition = particle.m_Transform.position);
			}
			else
			{
				Transform transform = this.m_Particles[particle.m_ParentIndex].m_Transform;
				particle.m_Position = (particle.m_PrevPosition = transform.TransformPoint(particle.m_EndOffset));
			}
		}
		this.m_ObjectPrevPosition = base.transform.position;
	}

	// Token: 0x060013D6 RID: 5078 RVA: 0x000BC0E8 File Offset: 0x000BA2E8
	private void UpdateParticles1()
	{
		Vector3 vector = this.m_Gravity;
		Vector3 normalized = this.m_Gravity.normalized;
		Vector3 lhs = this.m_Root.TransformDirection(this.m_LocalGravity);
		Vector3 b = normalized * Mathf.Max(Vector3.Dot(lhs, normalized), 0f);
		vector -= b;
		vector = (vector + this.m_Force) * this.m_ObjectScale;
		for (int i = 0; i < this.m_Particles.Count; i++)
		{
			DynamicBone.Particle particle = this.m_Particles[i];
			if (particle.m_ParentIndex >= 0)
			{
				Vector3 a = particle.m_Position - particle.m_PrevPosition;
				Vector3 b2 = this.m_ObjectMove * particle.m_Inert;
				particle.m_PrevPosition = particle.m_Position + b2;
				particle.m_Position += a * (1f - particle.m_Damping) + vector + b2;
			}
			else
			{
				particle.m_PrevPosition = particle.m_Position;
				particle.m_Position = particle.m_Transform.position;
			}
		}
	}

	// Token: 0x060013D7 RID: 5079 RVA: 0x000BC220 File Offset: 0x000BA420
	private void UpdateParticles2()
	{
		Plane plane = default(Plane);
		for (int i = 1; i < this.m_Particles.Count; i++)
		{
			DynamicBone.Particle particle = this.m_Particles[i];
			DynamicBone.Particle particle2 = this.m_Particles[particle.m_ParentIndex];
			float magnitude;
			if (particle.m_Transform != null)
			{
				magnitude = (particle2.m_Transform.position - particle.m_Transform.position).magnitude;
			}
			else
			{
				magnitude = particle2.m_Transform.localToWorldMatrix.MultiplyVector(particle.m_EndOffset).magnitude;
			}
			float num = Mathf.Lerp(1f, particle.m_Stiffness, this.m_Weight);
			if (num > 0f || particle.m_Elasticity > 0f)
			{
				Matrix4x4 localToWorldMatrix = particle2.m_Transform.localToWorldMatrix;
				localToWorldMatrix.SetColumn(3, particle2.m_Position);
				Vector3 a;
				if (particle.m_Transform != null)
				{
					a = localToWorldMatrix.MultiplyPoint3x4(particle.m_Transform.localPosition);
				}
				else
				{
					a = localToWorldMatrix.MultiplyPoint3x4(particle.m_EndOffset);
				}
				Vector3 a2 = a - particle.m_Position;
				particle.m_Position += a2 * particle.m_Elasticity;
				if (num > 0f)
				{
					a2 = a - particle.m_Position;
					float magnitude2 = a2.magnitude;
					float num2 = magnitude * (1f - num) * 2f;
					if (magnitude2 > num2)
					{
						particle.m_Position += a2 * ((magnitude2 - num2) / magnitude2);
					}
				}
			}
			if (this.m_Colliders != null)
			{
				float particleRadius = particle.m_Radius * this.m_ObjectScale;
				for (int j = 0; j < this.m_Colliders.Count; j++)
				{
					DynamicBoneCollider dynamicBoneCollider = this.m_Colliders[j];
					if (dynamicBoneCollider != null && dynamicBoneCollider.enabled)
					{
						dynamicBoneCollider.Collide(ref particle.m_Position, particleRadius);
					}
				}
			}
			if (this.m_FreezeAxis != DynamicBone.FreezeAxis.None)
			{
				switch (this.m_FreezeAxis)
				{
				case DynamicBone.FreezeAxis.X:
					plane.SetNormalAndPosition(particle2.m_Transform.right, particle2.m_Position);
					break;
				case DynamicBone.FreezeAxis.Y:
					plane.SetNormalAndPosition(particle2.m_Transform.up, particle2.m_Position);
					break;
				case DynamicBone.FreezeAxis.Z:
					plane.SetNormalAndPosition(particle2.m_Transform.forward, particle2.m_Position);
					break;
				}
				particle.m_Position -= plane.normal * plane.GetDistanceToPoint(particle.m_Position);
			}
			Vector3 a3 = particle2.m_Position - particle.m_Position;
			float magnitude3 = a3.magnitude;
			if (magnitude3 > 0f)
			{
				particle.m_Position += a3 * ((magnitude3 - magnitude) / magnitude3);
			}
		}
	}

	// Token: 0x060013D8 RID: 5080 RVA: 0x000BC520 File Offset: 0x000BA720
	private void SkipUpdateParticles()
	{
		for (int i = 0; i < this.m_Particles.Count; i++)
		{
			DynamicBone.Particle particle = this.m_Particles[i];
			if (particle.m_ParentIndex >= 0)
			{
				particle.m_PrevPosition += this.m_ObjectMove;
				particle.m_Position += this.m_ObjectMove;
				DynamicBone.Particle particle2 = this.m_Particles[particle.m_ParentIndex];
				float magnitude;
				if (particle.m_Transform != null)
				{
					magnitude = (particle2.m_Transform.position - particle.m_Transform.position).magnitude;
				}
				else
				{
					magnitude = particle2.m_Transform.localToWorldMatrix.MultiplyVector(particle.m_EndOffset).magnitude;
				}
				float num = Mathf.Lerp(1f, particle.m_Stiffness, this.m_Weight);
				if (num > 0f)
				{
					Matrix4x4 localToWorldMatrix = particle2.m_Transform.localToWorldMatrix;
					localToWorldMatrix.SetColumn(3, particle2.m_Position);
					Vector3 a;
					if (particle.m_Transform != null)
					{
						a = localToWorldMatrix.MultiplyPoint3x4(particle.m_Transform.localPosition);
					}
					else
					{
						a = localToWorldMatrix.MultiplyPoint3x4(particle.m_EndOffset);
					}
					Vector3 a2 = a - particle.m_Position;
					float magnitude2 = a2.magnitude;
					float num2 = magnitude * (1f - num) * 2f;
					if (magnitude2 > num2)
					{
						particle.m_Position += a2 * ((magnitude2 - num2) / magnitude2);
					}
				}
				Vector3 a3 = particle2.m_Position - particle.m_Position;
				float magnitude3 = a3.magnitude;
				if (magnitude3 > 0f)
				{
					particle.m_Position += a3 * ((magnitude3 - magnitude) / magnitude3);
				}
			}
			else
			{
				particle.m_PrevPosition = particle.m_Position;
				particle.m_Position = particle.m_Transform.position;
			}
		}
	}

	// Token: 0x060013D9 RID: 5081 RVA: 0x000BC725 File Offset: 0x000BA925
	private static Vector3 MirrorVector(Vector3 v, Vector3 axis)
	{
		return v - axis * (Vector3.Dot(v, axis) * 2f);
	}

	// Token: 0x060013DA RID: 5082 RVA: 0x000BC740 File Offset: 0x000BA940
	private void ApplyParticlesToTransforms()
	{
		for (int i = 1; i < this.m_Particles.Count; i++)
		{
			DynamicBone.Particle particle = this.m_Particles[i];
			DynamicBone.Particle particle2 = this.m_Particles[particle.m_ParentIndex];
			if (particle2.m_Transform.childCount <= 1)
			{
				Vector3 direction;
				if (particle.m_Transform != null)
				{
					direction = particle.m_Transform.localPosition;
				}
				else
				{
					direction = particle.m_EndOffset;
				}
				Vector3 toDirection = particle.m_Position - particle2.m_Position;
				Quaternion lhs = Quaternion.FromToRotation(particle2.m_Transform.TransformDirection(direction), toDirection);
				particle2.m_Transform.rotation = lhs * particle2.m_Transform.rotation;
			}
			if (particle.m_Transform != null)
			{
				particle.m_Transform.position = particle.m_Position;
			}
		}
	}

	// Token: 0x04001D7A RID: 7546
	public Transform m_Root;

	// Token: 0x04001D7B RID: 7547
	public float m_UpdateRate = 60f;

	// Token: 0x04001D7C RID: 7548
	public DynamicBone.UpdateMode m_UpdateMode;

	// Token: 0x04001D7D RID: 7549
	[Range(0f, 1f)]
	public float m_Damping = 0.1f;

	// Token: 0x04001D7E RID: 7550
	public AnimationCurve m_DampingDistrib;

	// Token: 0x04001D7F RID: 7551
	[Range(0f, 1f)]
	public float m_Elasticity = 0.1f;

	// Token: 0x04001D80 RID: 7552
	public AnimationCurve m_ElasticityDistrib;

	// Token: 0x04001D81 RID: 7553
	[Range(0f, 1f)]
	public float m_Stiffness = 0.1f;

	// Token: 0x04001D82 RID: 7554
	public AnimationCurve m_StiffnessDistrib;

	// Token: 0x04001D83 RID: 7555
	[Range(0f, 1f)]
	public float m_Inert;

	// Token: 0x04001D84 RID: 7556
	public AnimationCurve m_InertDistrib;

	// Token: 0x04001D85 RID: 7557
	public float m_Radius;

	// Token: 0x04001D86 RID: 7558
	public AnimationCurve m_RadiusDistrib;

	// Token: 0x04001D87 RID: 7559
	public float m_EndLength;

	// Token: 0x04001D88 RID: 7560
	public Vector3 m_EndOffset = Vector3.zero;

	// Token: 0x04001D89 RID: 7561
	public Vector3 m_Gravity = Vector3.zero;

	// Token: 0x04001D8A RID: 7562
	public Vector3 m_Force = Vector3.zero;

	// Token: 0x04001D8B RID: 7563
	public List<DynamicBoneCollider> m_Colliders;

	// Token: 0x04001D8C RID: 7564
	public List<Transform> m_Exclusions;

	// Token: 0x04001D8D RID: 7565
	public DynamicBone.FreezeAxis m_FreezeAxis;

	// Token: 0x04001D8E RID: 7566
	public bool m_DistantDisable;

	// Token: 0x04001D8F RID: 7567
	public Transform m_ReferenceObject;

	// Token: 0x04001D90 RID: 7568
	public float m_DistanceToObject = 20f;

	// Token: 0x04001D91 RID: 7569
	private Vector3 m_LocalGravity = Vector3.zero;

	// Token: 0x04001D92 RID: 7570
	private Vector3 m_ObjectMove = Vector3.zero;

	// Token: 0x04001D93 RID: 7571
	private Vector3 m_ObjectPrevPosition = Vector3.zero;

	// Token: 0x04001D94 RID: 7572
	private float m_BoneTotalLength;

	// Token: 0x04001D95 RID: 7573
	private float m_ObjectScale = 1f;

	// Token: 0x04001D96 RID: 7574
	private float m_Time;

	// Token: 0x04001D97 RID: 7575
	private float m_Weight = 1f;

	// Token: 0x04001D98 RID: 7576
	private bool m_DistantDisabled;

	// Token: 0x04001D99 RID: 7577
	private Camera MainCamera;

	// Token: 0x04001D9A RID: 7578
	private float CheckTimer;

	// Token: 0x04001D9B RID: 7579
	private List<DynamicBone.Particle> m_Particles = new List<DynamicBone.Particle>();

	// Token: 0x02000653 RID: 1619
	public enum UpdateMode
	{
		// Token: 0x04004EF7 RID: 20215
		Normal,
		// Token: 0x04004EF8 RID: 20216
		AnimatePhysics,
		// Token: 0x04004EF9 RID: 20217
		UnscaledTime
	}

	// Token: 0x02000654 RID: 1620
	public enum FreezeAxis
	{
		// Token: 0x04004EFB RID: 20219
		None,
		// Token: 0x04004EFC RID: 20220
		X,
		// Token: 0x04004EFD RID: 20221
		Y,
		// Token: 0x04004EFE RID: 20222
		Z
	}

	// Token: 0x02000655 RID: 1621
	private class Particle
	{
		// Token: 0x04004EFF RID: 20223
		public Transform m_Transform;

		// Token: 0x04004F00 RID: 20224
		public int m_ParentIndex = -1;

		// Token: 0x04004F01 RID: 20225
		public float m_Damping;

		// Token: 0x04004F02 RID: 20226
		public float m_Elasticity;

		// Token: 0x04004F03 RID: 20227
		public float m_Stiffness;

		// Token: 0x04004F04 RID: 20228
		public float m_Inert;

		// Token: 0x04004F05 RID: 20229
		public float m_Radius;

		// Token: 0x04004F06 RID: 20230
		public float m_BoneLength;

		// Token: 0x04004F07 RID: 20231
		public Vector3 m_Position = Vector3.zero;

		// Token: 0x04004F08 RID: 20232
		public Vector3 m_PrevPosition = Vector3.zero;

		// Token: 0x04004F09 RID: 20233
		public Vector3 m_EndOffset = Vector3.zero;

		// Token: 0x04004F0A RID: 20234
		public Vector3 m_InitLocalPosition = Vector3.zero;

		// Token: 0x04004F0B RID: 20235
		public Quaternion m_InitLocalRotation = Quaternion.identity;
	}
}
