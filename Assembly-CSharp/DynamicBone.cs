using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000298 RID: 664
[AddComponentMenu("Dynamic Bone/Dynamic Bone")]
public class DynamicBone : MonoBehaviour
{
	// Token: 0x060013E0 RID: 5088 RVA: 0x000BCC08 File Offset: 0x000BAE08
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

	// Token: 0x060013E1 RID: 5089 RVA: 0x000BCCB3 File Offset: 0x000BAEB3
	private void FixedUpdate()
	{
		if (this.m_UpdateMode == DynamicBone.UpdateMode.AnimatePhysics)
		{
			this.PreUpdate();
		}
	}

	// Token: 0x060013E2 RID: 5090 RVA: 0x000BCCC4 File Offset: 0x000BAEC4
	private void Update()
	{
		if (this.m_UpdateMode != DynamicBone.UpdateMode.AnimatePhysics)
		{
			this.PreUpdate();
		}
	}

	// Token: 0x060013E3 RID: 5091 RVA: 0x000BCCD8 File Offset: 0x000BAED8
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

	// Token: 0x060013E4 RID: 5092 RVA: 0x000BCD47 File Offset: 0x000BAF47
	private void PreUpdate()
	{
		if (this.m_Weight > 0f && (!this.m_DistantDisable || !this.m_DistantDisabled))
		{
			this.InitTransforms();
		}
	}

	// Token: 0x060013E5 RID: 5093 RVA: 0x000BCD6C File Offset: 0x000BAF6C
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

	// Token: 0x060013E6 RID: 5094 RVA: 0x000BCDF3 File Offset: 0x000BAFF3
	private void OnEnable()
	{
		this.ResetParticlesPosition();
	}

	// Token: 0x060013E7 RID: 5095 RVA: 0x000BCDFB File Offset: 0x000BAFFB
	private void OnDisable()
	{
		this.InitTransforms();
	}

	// Token: 0x060013E8 RID: 5096 RVA: 0x000BCE04 File Offset: 0x000BB004
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

	// Token: 0x060013E9 RID: 5097 RVA: 0x000BCE9C File Offset: 0x000BB09C
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

	// Token: 0x060013EA RID: 5098 RVA: 0x000BCF65 File Offset: 0x000BB165
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

	// Token: 0x060013EB RID: 5099 RVA: 0x000BCF9A File Offset: 0x000BB19A
	public float GetWeight()
	{
		return this.m_Weight;
	}

	// Token: 0x060013EC RID: 5100 RVA: 0x000BCFA4 File Offset: 0x000BB1A4
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

	// Token: 0x060013ED RID: 5101 RVA: 0x000BD098 File Offset: 0x000BB298
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

	// Token: 0x060013EE RID: 5102 RVA: 0x000BD2F4 File Offset: 0x000BB4F4
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

	// Token: 0x060013EF RID: 5103 RVA: 0x000BD524 File Offset: 0x000BB724
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

	// Token: 0x060013F0 RID: 5104 RVA: 0x000BD584 File Offset: 0x000BB784
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

	// Token: 0x060013F1 RID: 5105 RVA: 0x000BD624 File Offset: 0x000BB824
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

	// Token: 0x060013F2 RID: 5106 RVA: 0x000BD75C File Offset: 0x000BB95C
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

	// Token: 0x060013F3 RID: 5107 RVA: 0x000BDA5C File Offset: 0x000BBC5C
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

	// Token: 0x060013F4 RID: 5108 RVA: 0x000BDC61 File Offset: 0x000BBE61
	private static Vector3 MirrorVector(Vector3 v, Vector3 axis)
	{
		return v - axis * (Vector3.Dot(v, axis) * 2f);
	}

	// Token: 0x060013F5 RID: 5109 RVA: 0x000BDC7C File Offset: 0x000BBE7C
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

	// Token: 0x04001DB4 RID: 7604
	public Transform m_Root;

	// Token: 0x04001DB5 RID: 7605
	public float m_UpdateRate = 60f;

	// Token: 0x04001DB6 RID: 7606
	public DynamicBone.UpdateMode m_UpdateMode;

	// Token: 0x04001DB7 RID: 7607
	[Range(0f, 1f)]
	public float m_Damping = 0.1f;

	// Token: 0x04001DB8 RID: 7608
	public AnimationCurve m_DampingDistrib;

	// Token: 0x04001DB9 RID: 7609
	[Range(0f, 1f)]
	public float m_Elasticity = 0.1f;

	// Token: 0x04001DBA RID: 7610
	public AnimationCurve m_ElasticityDistrib;

	// Token: 0x04001DBB RID: 7611
	[Range(0f, 1f)]
	public float m_Stiffness = 0.1f;

	// Token: 0x04001DBC RID: 7612
	public AnimationCurve m_StiffnessDistrib;

	// Token: 0x04001DBD RID: 7613
	[Range(0f, 1f)]
	public float m_Inert;

	// Token: 0x04001DBE RID: 7614
	public AnimationCurve m_InertDistrib;

	// Token: 0x04001DBF RID: 7615
	public float m_Radius;

	// Token: 0x04001DC0 RID: 7616
	public AnimationCurve m_RadiusDistrib;

	// Token: 0x04001DC1 RID: 7617
	public float m_EndLength;

	// Token: 0x04001DC2 RID: 7618
	public Vector3 m_EndOffset = Vector3.zero;

	// Token: 0x04001DC3 RID: 7619
	public Vector3 m_Gravity = Vector3.zero;

	// Token: 0x04001DC4 RID: 7620
	public Vector3 m_Force = Vector3.zero;

	// Token: 0x04001DC5 RID: 7621
	public List<DynamicBoneCollider> m_Colliders;

	// Token: 0x04001DC6 RID: 7622
	public List<Transform> m_Exclusions;

	// Token: 0x04001DC7 RID: 7623
	public DynamicBone.FreezeAxis m_FreezeAxis;

	// Token: 0x04001DC8 RID: 7624
	public bool m_DistantDisable;

	// Token: 0x04001DC9 RID: 7625
	public Transform m_ReferenceObject;

	// Token: 0x04001DCA RID: 7626
	public float m_DistanceToObject = 20f;

	// Token: 0x04001DCB RID: 7627
	private Vector3 m_LocalGravity = Vector3.zero;

	// Token: 0x04001DCC RID: 7628
	private Vector3 m_ObjectMove = Vector3.zero;

	// Token: 0x04001DCD RID: 7629
	private Vector3 m_ObjectPrevPosition = Vector3.zero;

	// Token: 0x04001DCE RID: 7630
	private float m_BoneTotalLength;

	// Token: 0x04001DCF RID: 7631
	private float m_ObjectScale = 1f;

	// Token: 0x04001DD0 RID: 7632
	private float m_Time;

	// Token: 0x04001DD1 RID: 7633
	private float m_Weight = 1f;

	// Token: 0x04001DD2 RID: 7634
	private bool m_DistantDisabled;

	// Token: 0x04001DD3 RID: 7635
	private Camera MainCamera;

	// Token: 0x04001DD4 RID: 7636
	private float CheckTimer;

	// Token: 0x04001DD5 RID: 7637
	private List<DynamicBone.Particle> m_Particles = new List<DynamicBone.Particle>();

	// Token: 0x0200065F RID: 1631
	public enum UpdateMode
	{
		// Token: 0x04004FDA RID: 20442
		Normal,
		// Token: 0x04004FDB RID: 20443
		AnimatePhysics,
		// Token: 0x04004FDC RID: 20444
		UnscaledTime
	}

	// Token: 0x02000660 RID: 1632
	public enum FreezeAxis
	{
		// Token: 0x04004FDE RID: 20446
		None,
		// Token: 0x04004FDF RID: 20447
		X,
		// Token: 0x04004FE0 RID: 20448
		Y,
		// Token: 0x04004FE1 RID: 20449
		Z
	}

	// Token: 0x02000661 RID: 1633
	private class Particle
	{
		// Token: 0x04004FE2 RID: 20450
		public Transform m_Transform;

		// Token: 0x04004FE3 RID: 20451
		public int m_ParentIndex = -1;

		// Token: 0x04004FE4 RID: 20452
		public float m_Damping;

		// Token: 0x04004FE5 RID: 20453
		public float m_Elasticity;

		// Token: 0x04004FE6 RID: 20454
		public float m_Stiffness;

		// Token: 0x04004FE7 RID: 20455
		public float m_Inert;

		// Token: 0x04004FE8 RID: 20456
		public float m_Radius;

		// Token: 0x04004FE9 RID: 20457
		public float m_BoneLength;

		// Token: 0x04004FEA RID: 20458
		public Vector3 m_Position = Vector3.zero;

		// Token: 0x04004FEB RID: 20459
		public Vector3 m_PrevPosition = Vector3.zero;

		// Token: 0x04004FEC RID: 20460
		public Vector3 m_EndOffset = Vector3.zero;

		// Token: 0x04004FED RID: 20461
		public Vector3 m_InitLocalPosition = Vector3.zero;

		// Token: 0x04004FEE RID: 20462
		public Quaternion m_InitLocalRotation = Quaternion.identity;
	}
}
