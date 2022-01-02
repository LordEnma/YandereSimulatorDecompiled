using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052B RID: 1323
	[RequireComponent(typeof(Rigidbody))]
	public class AeroplaneController : MonoBehaviour
	{
		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060021A2 RID: 8610 RVA: 0x001E9AC1 File Offset: 0x001E7CC1
		// (set) Token: 0x060021A3 RID: 8611 RVA: 0x001E9AC9 File Offset: 0x001E7CC9
		public float Altitude { get; private set; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060021A4 RID: 8612 RVA: 0x001E9AD2 File Offset: 0x001E7CD2
		// (set) Token: 0x060021A5 RID: 8613 RVA: 0x001E9ADA File Offset: 0x001E7CDA
		public float Throttle { get; private set; }

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060021A6 RID: 8614 RVA: 0x001E9AE3 File Offset: 0x001E7CE3
		// (set) Token: 0x060021A7 RID: 8615 RVA: 0x001E9AEB File Offset: 0x001E7CEB
		public bool AirBrakes { get; private set; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x060021A8 RID: 8616 RVA: 0x001E9AF4 File Offset: 0x001E7CF4
		// (set) Token: 0x060021A9 RID: 8617 RVA: 0x001E9AFC File Offset: 0x001E7CFC
		public float ForwardSpeed { get; private set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x060021AA RID: 8618 RVA: 0x001E9B05 File Offset: 0x001E7D05
		// (set) Token: 0x060021AB RID: 8619 RVA: 0x001E9B0D File Offset: 0x001E7D0D
		public float EnginePower { get; private set; }

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x060021AC RID: 8620 RVA: 0x001E9B16 File Offset: 0x001E7D16
		public float MaxEnginePower
		{
			get
			{
				return this.m_MaxEnginePower;
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x060021AD RID: 8621 RVA: 0x001E9B1E File Offset: 0x001E7D1E
		// (set) Token: 0x060021AE RID: 8622 RVA: 0x001E9B26 File Offset: 0x001E7D26
		public float RollAngle { get; private set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x060021AF RID: 8623 RVA: 0x001E9B2F File Offset: 0x001E7D2F
		// (set) Token: 0x060021B0 RID: 8624 RVA: 0x001E9B37 File Offset: 0x001E7D37
		public float PitchAngle { get; private set; }

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x060021B1 RID: 8625 RVA: 0x001E9B40 File Offset: 0x001E7D40
		// (set) Token: 0x060021B2 RID: 8626 RVA: 0x001E9B48 File Offset: 0x001E7D48
		public float RollInput { get; private set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060021B3 RID: 8627 RVA: 0x001E9B51 File Offset: 0x001E7D51
		// (set) Token: 0x060021B4 RID: 8628 RVA: 0x001E9B59 File Offset: 0x001E7D59
		public float PitchInput { get; private set; }

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060021B5 RID: 8629 RVA: 0x001E9B62 File Offset: 0x001E7D62
		// (set) Token: 0x060021B6 RID: 8630 RVA: 0x001E9B6A File Offset: 0x001E7D6A
		public float YawInput { get; private set; }

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x060021B7 RID: 8631 RVA: 0x001E9B73 File Offset: 0x001E7D73
		// (set) Token: 0x060021B8 RID: 8632 RVA: 0x001E9B7B File Offset: 0x001E7D7B
		public float ThrottleInput { get; private set; }

		// Token: 0x060021B9 RID: 8633 RVA: 0x001E9B84 File Offset: 0x001E7D84
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
			this.m_OriginalDrag = this.m_Rigidbody.drag;
			this.m_OriginalAngularDrag = this.m_Rigidbody.angularDrag;
			for (int i = 0; i < base.transform.childCount; i++)
			{
				WheelCollider[] componentsInChildren = base.transform.GetChild(i).GetComponentsInChildren<WheelCollider>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					componentsInChildren[j].motorTorque = 0.18f;
				}
			}
		}

		// Token: 0x060021BA RID: 8634 RVA: 0x001E9C04 File Offset: 0x001E7E04
		public void Move(float rollInput, float pitchInput, float yawInput, float throttleInput, bool airBrakes)
		{
			this.RollInput = rollInput;
			this.PitchInput = pitchInput;
			this.YawInput = yawInput;
			this.ThrottleInput = throttleInput;
			this.AirBrakes = airBrakes;
			this.ClampInputs();
			this.CalculateRollAndPitchAngles();
			this.AutoLevel();
			this.CalculateForwardSpeed();
			this.ControlThrottle();
			this.CalculateDrag();
			this.CaluclateAerodynamicEffect();
			this.CalculateLinearForces();
			this.CalculateTorque();
			this.CalculateAltitude();
		}

		// Token: 0x060021BB RID: 8635 RVA: 0x001E9C74 File Offset: 0x001E7E74
		private void ClampInputs()
		{
			this.RollInput = Mathf.Clamp(this.RollInput, -1f, 1f);
			this.PitchInput = Mathf.Clamp(this.PitchInput, -1f, 1f);
			this.YawInput = Mathf.Clamp(this.YawInput, -1f, 1f);
			this.ThrottleInput = Mathf.Clamp(this.ThrottleInput, -1f, 1f);
		}

		// Token: 0x060021BC RID: 8636 RVA: 0x001E9CF0 File Offset: 0x001E7EF0
		private void CalculateRollAndPitchAngles()
		{
			Vector3 forward = base.transform.forward;
			forward.y = 0f;
			if (forward.sqrMagnitude > 0f)
			{
				forward.Normalize();
				Vector3 vector = base.transform.InverseTransformDirection(forward);
				this.PitchAngle = Mathf.Atan2(vector.y, vector.z);
				Vector3 direction = Vector3.Cross(Vector3.up, forward);
				Vector3 vector2 = base.transform.InverseTransformDirection(direction);
				this.RollAngle = Mathf.Atan2(vector2.y, vector2.x);
			}
		}

		// Token: 0x060021BD RID: 8637 RVA: 0x001E9D80 File Offset: 0x001E7F80
		private void AutoLevel()
		{
			this.m_BankedTurnAmount = Mathf.Sin(this.RollAngle);
			if (this.RollInput == 0f)
			{
				this.RollInput = -this.RollAngle * this.m_AutoRollLevel;
			}
			if (this.PitchInput == 0f)
			{
				this.PitchInput = -this.PitchAngle * this.m_AutoPitchLevel;
				this.PitchInput -= Mathf.Abs(this.m_BankedTurnAmount * this.m_BankedTurnAmount * this.m_AutoTurnPitch);
			}
		}

		// Token: 0x060021BE RID: 8638 RVA: 0x001E9E08 File Offset: 0x001E8008
		private void CalculateForwardSpeed()
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.m_Rigidbody.velocity);
			this.ForwardSpeed = Mathf.Max(0f, vector.z);
		}

		// Token: 0x060021BF RID: 8639 RVA: 0x001E9E44 File Offset: 0x001E8044
		private void ControlThrottle()
		{
			if (this.m_Immobilized)
			{
				this.ThrottleInput = -0.5f;
			}
			this.Throttle = Mathf.Clamp01(this.Throttle + this.ThrottleInput * Time.deltaTime * this.m_ThrottleChangeSpeed);
			this.EnginePower = this.Throttle * this.m_MaxEnginePower;
		}

		// Token: 0x060021C0 RID: 8640 RVA: 0x001E9E9C File Offset: 0x001E809C
		private void CalculateDrag()
		{
			float num = this.m_Rigidbody.velocity.magnitude * this.m_DragIncreaseFactor;
			this.m_Rigidbody.drag = (this.AirBrakes ? ((this.m_OriginalDrag + num) * this.m_AirBrakesEffect) : (this.m_OriginalDrag + num));
			this.m_Rigidbody.angularDrag = this.m_OriginalAngularDrag * this.ForwardSpeed;
		}

		// Token: 0x060021C1 RID: 8641 RVA: 0x001E9F08 File Offset: 0x001E8108
		private void CaluclateAerodynamicEffect()
		{
			if (this.m_Rigidbody.velocity.magnitude > 0f)
			{
				this.m_AeroFactor = Vector3.Dot(base.transform.forward, this.m_Rigidbody.velocity.normalized);
				this.m_AeroFactor *= this.m_AeroFactor;
				Vector3 velocity = Vector3.Lerp(this.m_Rigidbody.velocity, base.transform.forward * this.ForwardSpeed, this.m_AeroFactor * this.ForwardSpeed * this.m_AerodynamicEffect * Time.deltaTime);
				this.m_Rigidbody.velocity = velocity;
				this.m_Rigidbody.rotation = Quaternion.Slerp(this.m_Rigidbody.rotation, Quaternion.LookRotation(this.m_Rigidbody.velocity, base.transform.up), this.m_AerodynamicEffect * Time.deltaTime);
			}
		}

		// Token: 0x060021C2 RID: 8642 RVA: 0x001EA000 File Offset: 0x001E8200
		private void CalculateLinearForces()
		{
			Vector3 vector = Vector3.zero;
			vector += this.EnginePower * base.transform.forward;
			Vector3 normalized = Vector3.Cross(this.m_Rigidbody.velocity, base.transform.right).normalized;
			float num = Mathf.InverseLerp(this.m_ZeroLiftSpeed, 0f, this.ForwardSpeed);
			float d = this.ForwardSpeed * this.ForwardSpeed * this.m_Lift * num * this.m_AeroFactor;
			vector += d * normalized;
			this.m_Rigidbody.AddForce(vector);
		}

		// Token: 0x060021C3 RID: 8643 RVA: 0x001EA0A4 File Offset: 0x001E82A4
		private void CalculateTorque()
		{
			Vector3 a = Vector3.zero;
			a += this.PitchInput * this.m_PitchEffect * base.transform.right;
			a += this.YawInput * this.m_YawEffect * base.transform.up;
			a += -this.RollInput * this.m_RollEffect * base.transform.forward;
			a += this.m_BankedTurnAmount * this.m_BankedTurnEffect * base.transform.up;
			this.m_Rigidbody.AddTorque(a * this.ForwardSpeed * this.m_AeroFactor);
		}

		// Token: 0x060021C4 RID: 8644 RVA: 0x001EA16C File Offset: 0x001E836C
		private void CalculateAltitude()
		{
			Ray ray = new Ray(base.transform.position - Vector3.up * 10f, -Vector3.up);
			RaycastHit raycastHit;
			this.Altitude = (Physics.Raycast(ray, out raycastHit) ? (raycastHit.distance + 10f) : base.transform.position.y);
		}

		// Token: 0x060021C5 RID: 8645 RVA: 0x001EA1D8 File Offset: 0x001E83D8
		public void Immobilize()
		{
			this.m_Immobilized = true;
		}

		// Token: 0x060021C6 RID: 8646 RVA: 0x001EA1E1 File Offset: 0x001E83E1
		public void Reset()
		{
			this.m_Immobilized = false;
		}

		// Token: 0x040049A6 RID: 18854
		[SerializeField]
		private float m_MaxEnginePower = 40f;

		// Token: 0x040049A7 RID: 18855
		[SerializeField]
		private float m_Lift = 0.002f;

		// Token: 0x040049A8 RID: 18856
		[SerializeField]
		private float m_ZeroLiftSpeed = 300f;

		// Token: 0x040049A9 RID: 18857
		[SerializeField]
		private float m_RollEffect = 1f;

		// Token: 0x040049AA RID: 18858
		[SerializeField]
		private float m_PitchEffect = 1f;

		// Token: 0x040049AB RID: 18859
		[SerializeField]
		private float m_YawEffect = 0.2f;

		// Token: 0x040049AC RID: 18860
		[SerializeField]
		private float m_BankedTurnEffect = 0.5f;

		// Token: 0x040049AD RID: 18861
		[SerializeField]
		private float m_AerodynamicEffect = 0.02f;

		// Token: 0x040049AE RID: 18862
		[SerializeField]
		private float m_AutoTurnPitch = 0.5f;

		// Token: 0x040049AF RID: 18863
		[SerializeField]
		private float m_AutoRollLevel = 0.2f;

		// Token: 0x040049B0 RID: 18864
		[SerializeField]
		private float m_AutoPitchLevel = 0.2f;

		// Token: 0x040049B1 RID: 18865
		[SerializeField]
		private float m_AirBrakesEffect = 3f;

		// Token: 0x040049B2 RID: 18866
		[SerializeField]
		private float m_ThrottleChangeSpeed = 0.3f;

		// Token: 0x040049B3 RID: 18867
		[SerializeField]
		private float m_DragIncreaseFactor = 0.001f;

		// Token: 0x040049BF RID: 18879
		private float m_OriginalDrag;

		// Token: 0x040049C0 RID: 18880
		private float m_OriginalAngularDrag;

		// Token: 0x040049C1 RID: 18881
		private float m_AeroFactor;

		// Token: 0x040049C2 RID: 18882
		private bool m_Immobilized;

		// Token: 0x040049C3 RID: 18883
		private float m_BankedTurnAmount;

		// Token: 0x040049C4 RID: 18884
		private Rigidbody m_Rigidbody;

		// Token: 0x040049C5 RID: 18885
		private WheelCollider[] m_WheelColliders;
	}
}
