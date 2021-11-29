using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000529 RID: 1321
	[RequireComponent(typeof(Rigidbody))]
	public class AeroplaneController : MonoBehaviour
	{
		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x0600218E RID: 8590 RVA: 0x001E7D9D File Offset: 0x001E5F9D
		// (set) Token: 0x0600218F RID: 8591 RVA: 0x001E7DA5 File Offset: 0x001E5FA5
		public float Altitude { get; private set; }

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06002190 RID: 8592 RVA: 0x001E7DAE File Offset: 0x001E5FAE
		// (set) Token: 0x06002191 RID: 8593 RVA: 0x001E7DB6 File Offset: 0x001E5FB6
		public float Throttle { get; private set; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06002192 RID: 8594 RVA: 0x001E7DBF File Offset: 0x001E5FBF
		// (set) Token: 0x06002193 RID: 8595 RVA: 0x001E7DC7 File Offset: 0x001E5FC7
		public bool AirBrakes { get; private set; }

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06002194 RID: 8596 RVA: 0x001E7DD0 File Offset: 0x001E5FD0
		// (set) Token: 0x06002195 RID: 8597 RVA: 0x001E7DD8 File Offset: 0x001E5FD8
		public float ForwardSpeed { get; private set; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06002196 RID: 8598 RVA: 0x001E7DE1 File Offset: 0x001E5FE1
		// (set) Token: 0x06002197 RID: 8599 RVA: 0x001E7DE9 File Offset: 0x001E5FE9
		public float EnginePower { get; private set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06002198 RID: 8600 RVA: 0x001E7DF2 File Offset: 0x001E5FF2
		public float MaxEnginePower
		{
			get
			{
				return this.m_MaxEnginePower;
			}
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06002199 RID: 8601 RVA: 0x001E7DFA File Offset: 0x001E5FFA
		// (set) Token: 0x0600219A RID: 8602 RVA: 0x001E7E02 File Offset: 0x001E6002
		public float RollAngle { get; private set; }

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x0600219B RID: 8603 RVA: 0x001E7E0B File Offset: 0x001E600B
		// (set) Token: 0x0600219C RID: 8604 RVA: 0x001E7E13 File Offset: 0x001E6013
		public float PitchAngle { get; private set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x0600219D RID: 8605 RVA: 0x001E7E1C File Offset: 0x001E601C
		// (set) Token: 0x0600219E RID: 8606 RVA: 0x001E7E24 File Offset: 0x001E6024
		public float RollInput { get; private set; }

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x0600219F RID: 8607 RVA: 0x001E7E2D File Offset: 0x001E602D
		// (set) Token: 0x060021A0 RID: 8608 RVA: 0x001E7E35 File Offset: 0x001E6035
		public float PitchInput { get; private set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060021A1 RID: 8609 RVA: 0x001E7E3E File Offset: 0x001E603E
		// (set) Token: 0x060021A2 RID: 8610 RVA: 0x001E7E46 File Offset: 0x001E6046
		public float YawInput { get; private set; }

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060021A3 RID: 8611 RVA: 0x001E7E4F File Offset: 0x001E604F
		// (set) Token: 0x060021A4 RID: 8612 RVA: 0x001E7E57 File Offset: 0x001E6057
		public float ThrottleInput { get; private set; }

		// Token: 0x060021A5 RID: 8613 RVA: 0x001E7E60 File Offset: 0x001E6060
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

		// Token: 0x060021A6 RID: 8614 RVA: 0x001E7EE0 File Offset: 0x001E60E0
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

		// Token: 0x060021A7 RID: 8615 RVA: 0x001E7F50 File Offset: 0x001E6150
		private void ClampInputs()
		{
			this.RollInput = Mathf.Clamp(this.RollInput, -1f, 1f);
			this.PitchInput = Mathf.Clamp(this.PitchInput, -1f, 1f);
			this.YawInput = Mathf.Clamp(this.YawInput, -1f, 1f);
			this.ThrottleInput = Mathf.Clamp(this.ThrottleInput, -1f, 1f);
		}

		// Token: 0x060021A8 RID: 8616 RVA: 0x001E7FCC File Offset: 0x001E61CC
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

		// Token: 0x060021A9 RID: 8617 RVA: 0x001E805C File Offset: 0x001E625C
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

		// Token: 0x060021AA RID: 8618 RVA: 0x001E80E4 File Offset: 0x001E62E4
		private void CalculateForwardSpeed()
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.m_Rigidbody.velocity);
			this.ForwardSpeed = Mathf.Max(0f, vector.z);
		}

		// Token: 0x060021AB RID: 8619 RVA: 0x001E8120 File Offset: 0x001E6320
		private void ControlThrottle()
		{
			if (this.m_Immobilized)
			{
				this.ThrottleInput = -0.5f;
			}
			this.Throttle = Mathf.Clamp01(this.Throttle + this.ThrottleInput * Time.deltaTime * this.m_ThrottleChangeSpeed);
			this.EnginePower = this.Throttle * this.m_MaxEnginePower;
		}

		// Token: 0x060021AC RID: 8620 RVA: 0x001E8178 File Offset: 0x001E6378
		private void CalculateDrag()
		{
			float num = this.m_Rigidbody.velocity.magnitude * this.m_DragIncreaseFactor;
			this.m_Rigidbody.drag = (this.AirBrakes ? ((this.m_OriginalDrag + num) * this.m_AirBrakesEffect) : (this.m_OriginalDrag + num));
			this.m_Rigidbody.angularDrag = this.m_OriginalAngularDrag * this.ForwardSpeed;
		}

		// Token: 0x060021AD RID: 8621 RVA: 0x001E81E4 File Offset: 0x001E63E4
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

		// Token: 0x060021AE RID: 8622 RVA: 0x001E82DC File Offset: 0x001E64DC
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

		// Token: 0x060021AF RID: 8623 RVA: 0x001E8380 File Offset: 0x001E6580
		private void CalculateTorque()
		{
			Vector3 a = Vector3.zero;
			a += this.PitchInput * this.m_PitchEffect * base.transform.right;
			a += this.YawInput * this.m_YawEffect * base.transform.up;
			a += -this.RollInput * this.m_RollEffect * base.transform.forward;
			a += this.m_BankedTurnAmount * this.m_BankedTurnEffect * base.transform.up;
			this.m_Rigidbody.AddTorque(a * this.ForwardSpeed * this.m_AeroFactor);
		}

		// Token: 0x060021B0 RID: 8624 RVA: 0x001E8448 File Offset: 0x001E6648
		private void CalculateAltitude()
		{
			Ray ray = new Ray(base.transform.position - Vector3.up * 10f, -Vector3.up);
			RaycastHit raycastHit;
			this.Altitude = (Physics.Raycast(ray, out raycastHit) ? (raycastHit.distance + 10f) : base.transform.position.y);
		}

		// Token: 0x060021B1 RID: 8625 RVA: 0x001E84B4 File Offset: 0x001E66B4
		public void Immobilize()
		{
			this.m_Immobilized = true;
		}

		// Token: 0x060021B2 RID: 8626 RVA: 0x001E84BD File Offset: 0x001E66BD
		public void Reset()
		{
			this.m_Immobilized = false;
		}

		// Token: 0x0400495E RID: 18782
		[SerializeField]
		private float m_MaxEnginePower = 40f;

		// Token: 0x0400495F RID: 18783
		[SerializeField]
		private float m_Lift = 0.002f;

		// Token: 0x04004960 RID: 18784
		[SerializeField]
		private float m_ZeroLiftSpeed = 300f;

		// Token: 0x04004961 RID: 18785
		[SerializeField]
		private float m_RollEffect = 1f;

		// Token: 0x04004962 RID: 18786
		[SerializeField]
		private float m_PitchEffect = 1f;

		// Token: 0x04004963 RID: 18787
		[SerializeField]
		private float m_YawEffect = 0.2f;

		// Token: 0x04004964 RID: 18788
		[SerializeField]
		private float m_BankedTurnEffect = 0.5f;

		// Token: 0x04004965 RID: 18789
		[SerializeField]
		private float m_AerodynamicEffect = 0.02f;

		// Token: 0x04004966 RID: 18790
		[SerializeField]
		private float m_AutoTurnPitch = 0.5f;

		// Token: 0x04004967 RID: 18791
		[SerializeField]
		private float m_AutoRollLevel = 0.2f;

		// Token: 0x04004968 RID: 18792
		[SerializeField]
		private float m_AutoPitchLevel = 0.2f;

		// Token: 0x04004969 RID: 18793
		[SerializeField]
		private float m_AirBrakesEffect = 3f;

		// Token: 0x0400496A RID: 18794
		[SerializeField]
		private float m_ThrottleChangeSpeed = 0.3f;

		// Token: 0x0400496B RID: 18795
		[SerializeField]
		private float m_DragIncreaseFactor = 0.001f;

		// Token: 0x04004977 RID: 18807
		private float m_OriginalDrag;

		// Token: 0x04004978 RID: 18808
		private float m_OriginalAngularDrag;

		// Token: 0x04004979 RID: 18809
		private float m_AeroFactor;

		// Token: 0x0400497A RID: 18810
		private bool m_Immobilized;

		// Token: 0x0400497B RID: 18811
		private float m_BankedTurnAmount;

		// Token: 0x0400497C RID: 18812
		private Rigidbody m_Rigidbody;

		// Token: 0x0400497D RID: 18813
		private WheelCollider[] m_WheelColliders;
	}
}
