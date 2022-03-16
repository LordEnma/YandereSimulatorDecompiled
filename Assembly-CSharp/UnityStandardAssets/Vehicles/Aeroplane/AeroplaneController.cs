using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000535 RID: 1333
	[RequireComponent(typeof(Rigidbody))]
	public class AeroplaneController : MonoBehaviour
	{
		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x060021E6 RID: 8678 RVA: 0x001EF8C1 File Offset: 0x001EDAC1
		// (set) Token: 0x060021E7 RID: 8679 RVA: 0x001EF8C9 File Offset: 0x001EDAC9
		public float Altitude { get; private set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x060021E8 RID: 8680 RVA: 0x001EF8D2 File Offset: 0x001EDAD2
		// (set) Token: 0x060021E9 RID: 8681 RVA: 0x001EF8DA File Offset: 0x001EDADA
		public float Throttle { get; private set; }

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x060021EA RID: 8682 RVA: 0x001EF8E3 File Offset: 0x001EDAE3
		// (set) Token: 0x060021EB RID: 8683 RVA: 0x001EF8EB File Offset: 0x001EDAEB
		public bool AirBrakes { get; private set; }

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x060021EC RID: 8684 RVA: 0x001EF8F4 File Offset: 0x001EDAF4
		// (set) Token: 0x060021ED RID: 8685 RVA: 0x001EF8FC File Offset: 0x001EDAFC
		public float ForwardSpeed { get; private set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x060021EE RID: 8686 RVA: 0x001EF905 File Offset: 0x001EDB05
		// (set) Token: 0x060021EF RID: 8687 RVA: 0x001EF90D File Offset: 0x001EDB0D
		public float EnginePower { get; private set; }

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x060021F0 RID: 8688 RVA: 0x001EF916 File Offset: 0x001EDB16
		public float MaxEnginePower
		{
			get
			{
				return this.m_MaxEnginePower;
			}
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060021F1 RID: 8689 RVA: 0x001EF91E File Offset: 0x001EDB1E
		// (set) Token: 0x060021F2 RID: 8690 RVA: 0x001EF926 File Offset: 0x001EDB26
		public float RollAngle { get; private set; }

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060021F3 RID: 8691 RVA: 0x001EF92F File Offset: 0x001EDB2F
		// (set) Token: 0x060021F4 RID: 8692 RVA: 0x001EF937 File Offset: 0x001EDB37
		public float PitchAngle { get; private set; }

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x060021F5 RID: 8693 RVA: 0x001EF940 File Offset: 0x001EDB40
		// (set) Token: 0x060021F6 RID: 8694 RVA: 0x001EF948 File Offset: 0x001EDB48
		public float RollInput { get; private set; }

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x060021F7 RID: 8695 RVA: 0x001EF951 File Offset: 0x001EDB51
		// (set) Token: 0x060021F8 RID: 8696 RVA: 0x001EF959 File Offset: 0x001EDB59
		public float PitchInput { get; private set; }

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x060021F9 RID: 8697 RVA: 0x001EF962 File Offset: 0x001EDB62
		// (set) Token: 0x060021FA RID: 8698 RVA: 0x001EF96A File Offset: 0x001EDB6A
		public float YawInput { get; private set; }

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x060021FB RID: 8699 RVA: 0x001EF973 File Offset: 0x001EDB73
		// (set) Token: 0x060021FC RID: 8700 RVA: 0x001EF97B File Offset: 0x001EDB7B
		public float ThrottleInput { get; private set; }

		// Token: 0x060021FD RID: 8701 RVA: 0x001EF984 File Offset: 0x001EDB84
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

		// Token: 0x060021FE RID: 8702 RVA: 0x001EFA04 File Offset: 0x001EDC04
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

		// Token: 0x060021FF RID: 8703 RVA: 0x001EFA74 File Offset: 0x001EDC74
		private void ClampInputs()
		{
			this.RollInput = Mathf.Clamp(this.RollInput, -1f, 1f);
			this.PitchInput = Mathf.Clamp(this.PitchInput, -1f, 1f);
			this.YawInput = Mathf.Clamp(this.YawInput, -1f, 1f);
			this.ThrottleInput = Mathf.Clamp(this.ThrottleInput, -1f, 1f);
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x001EFAF0 File Offset: 0x001EDCF0
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

		// Token: 0x06002201 RID: 8705 RVA: 0x001EFB80 File Offset: 0x001EDD80
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

		// Token: 0x06002202 RID: 8706 RVA: 0x001EFC08 File Offset: 0x001EDE08
		private void CalculateForwardSpeed()
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.m_Rigidbody.velocity);
			this.ForwardSpeed = Mathf.Max(0f, vector.z);
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x001EFC44 File Offset: 0x001EDE44
		private void ControlThrottle()
		{
			if (this.m_Immobilized)
			{
				this.ThrottleInput = -0.5f;
			}
			this.Throttle = Mathf.Clamp01(this.Throttle + this.ThrottleInput * Time.deltaTime * this.m_ThrottleChangeSpeed);
			this.EnginePower = this.Throttle * this.m_MaxEnginePower;
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x001EFC9C File Offset: 0x001EDE9C
		private void CalculateDrag()
		{
			float num = this.m_Rigidbody.velocity.magnitude * this.m_DragIncreaseFactor;
			this.m_Rigidbody.drag = (this.AirBrakes ? ((this.m_OriginalDrag + num) * this.m_AirBrakesEffect) : (this.m_OriginalDrag + num));
			this.m_Rigidbody.angularDrag = this.m_OriginalAngularDrag * this.ForwardSpeed;
		}

		// Token: 0x06002205 RID: 8709 RVA: 0x001EFD08 File Offset: 0x001EDF08
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

		// Token: 0x06002206 RID: 8710 RVA: 0x001EFE00 File Offset: 0x001EE000
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

		// Token: 0x06002207 RID: 8711 RVA: 0x001EFEA4 File Offset: 0x001EE0A4
		private void CalculateTorque()
		{
			Vector3 a = Vector3.zero;
			a += this.PitchInput * this.m_PitchEffect * base.transform.right;
			a += this.YawInput * this.m_YawEffect * base.transform.up;
			a += -this.RollInput * this.m_RollEffect * base.transform.forward;
			a += this.m_BankedTurnAmount * this.m_BankedTurnEffect * base.transform.up;
			this.m_Rigidbody.AddTorque(a * this.ForwardSpeed * this.m_AeroFactor);
		}

		// Token: 0x06002208 RID: 8712 RVA: 0x001EFF6C File Offset: 0x001EE16C
		private void CalculateAltitude()
		{
			Ray ray = new Ray(base.transform.position - Vector3.up * 10f, -Vector3.up);
			RaycastHit raycastHit;
			this.Altitude = (Physics.Raycast(ray, out raycastHit) ? (raycastHit.distance + 10f) : base.transform.position.y);
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x001EFFD8 File Offset: 0x001EE1D8
		public void Immobilize()
		{
			this.m_Immobilized = true;
		}

		// Token: 0x0600220A RID: 8714 RVA: 0x001EFFE1 File Offset: 0x001EE1E1
		public void Reset()
		{
			this.m_Immobilized = false;
		}

		// Token: 0x04004A6A RID: 19050
		[SerializeField]
		private float m_MaxEnginePower = 40f;

		// Token: 0x04004A6B RID: 19051
		[SerializeField]
		private float m_Lift = 0.002f;

		// Token: 0x04004A6C RID: 19052
		[SerializeField]
		private float m_ZeroLiftSpeed = 300f;

		// Token: 0x04004A6D RID: 19053
		[SerializeField]
		private float m_RollEffect = 1f;

		// Token: 0x04004A6E RID: 19054
		[SerializeField]
		private float m_PitchEffect = 1f;

		// Token: 0x04004A6F RID: 19055
		[SerializeField]
		private float m_YawEffect = 0.2f;

		// Token: 0x04004A70 RID: 19056
		[SerializeField]
		private float m_BankedTurnEffect = 0.5f;

		// Token: 0x04004A71 RID: 19057
		[SerializeField]
		private float m_AerodynamicEffect = 0.02f;

		// Token: 0x04004A72 RID: 19058
		[SerializeField]
		private float m_AutoTurnPitch = 0.5f;

		// Token: 0x04004A73 RID: 19059
		[SerializeField]
		private float m_AutoRollLevel = 0.2f;

		// Token: 0x04004A74 RID: 19060
		[SerializeField]
		private float m_AutoPitchLevel = 0.2f;

		// Token: 0x04004A75 RID: 19061
		[SerializeField]
		private float m_AirBrakesEffect = 3f;

		// Token: 0x04004A76 RID: 19062
		[SerializeField]
		private float m_ThrottleChangeSpeed = 0.3f;

		// Token: 0x04004A77 RID: 19063
		[SerializeField]
		private float m_DragIncreaseFactor = 0.001f;

		// Token: 0x04004A83 RID: 19075
		private float m_OriginalDrag;

		// Token: 0x04004A84 RID: 19076
		private float m_OriginalAngularDrag;

		// Token: 0x04004A85 RID: 19077
		private float m_AeroFactor;

		// Token: 0x04004A86 RID: 19078
		private bool m_Immobilized;

		// Token: 0x04004A87 RID: 19079
		private float m_BankedTurnAmount;

		// Token: 0x04004A88 RID: 19080
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A89 RID: 19081
		private WheelCollider[] m_WheelColliders;
	}
}
