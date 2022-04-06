using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053B RID: 1339
	[RequireComponent(typeof(Rigidbody))]
	public class AeroplaneController : MonoBehaviour
	{
		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x060021FE RID: 8702 RVA: 0x001F1661 File Offset: 0x001EF861
		// (set) Token: 0x060021FF RID: 8703 RVA: 0x001F1669 File Offset: 0x001EF869
		public float Altitude { get; private set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06002200 RID: 8704 RVA: 0x001F1672 File Offset: 0x001EF872
		// (set) Token: 0x06002201 RID: 8705 RVA: 0x001F167A File Offset: 0x001EF87A
		public float Throttle { get; private set; }

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06002202 RID: 8706 RVA: 0x001F1683 File Offset: 0x001EF883
		// (set) Token: 0x06002203 RID: 8707 RVA: 0x001F168B File Offset: 0x001EF88B
		public bool AirBrakes { get; private set; }

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06002204 RID: 8708 RVA: 0x001F1694 File Offset: 0x001EF894
		// (set) Token: 0x06002205 RID: 8709 RVA: 0x001F169C File Offset: 0x001EF89C
		public float ForwardSpeed { get; private set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06002206 RID: 8710 RVA: 0x001F16A5 File Offset: 0x001EF8A5
		// (set) Token: 0x06002207 RID: 8711 RVA: 0x001F16AD File Offset: 0x001EF8AD
		public float EnginePower { get; private set; }

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06002208 RID: 8712 RVA: 0x001F16B6 File Offset: 0x001EF8B6
		public float MaxEnginePower
		{
			get
			{
				return this.m_MaxEnginePower;
			}
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06002209 RID: 8713 RVA: 0x001F16BE File Offset: 0x001EF8BE
		// (set) Token: 0x0600220A RID: 8714 RVA: 0x001F16C6 File Offset: 0x001EF8C6
		public float RollAngle { get; private set; }

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x0600220B RID: 8715 RVA: 0x001F16CF File Offset: 0x001EF8CF
		// (set) Token: 0x0600220C RID: 8716 RVA: 0x001F16D7 File Offset: 0x001EF8D7
		public float PitchAngle { get; private set; }

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x0600220D RID: 8717 RVA: 0x001F16E0 File Offset: 0x001EF8E0
		// (set) Token: 0x0600220E RID: 8718 RVA: 0x001F16E8 File Offset: 0x001EF8E8
		public float RollInput { get; private set; }

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x0600220F RID: 8719 RVA: 0x001F16F1 File Offset: 0x001EF8F1
		// (set) Token: 0x06002210 RID: 8720 RVA: 0x001F16F9 File Offset: 0x001EF8F9
		public float PitchInput { get; private set; }

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06002211 RID: 8721 RVA: 0x001F1702 File Offset: 0x001EF902
		// (set) Token: 0x06002212 RID: 8722 RVA: 0x001F170A File Offset: 0x001EF90A
		public float YawInput { get; private set; }

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06002213 RID: 8723 RVA: 0x001F1713 File Offset: 0x001EF913
		// (set) Token: 0x06002214 RID: 8724 RVA: 0x001F171B File Offset: 0x001EF91B
		public float ThrottleInput { get; private set; }

		// Token: 0x06002215 RID: 8725 RVA: 0x001F1724 File Offset: 0x001EF924
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

		// Token: 0x06002216 RID: 8726 RVA: 0x001F17A4 File Offset: 0x001EF9A4
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

		// Token: 0x06002217 RID: 8727 RVA: 0x001F1814 File Offset: 0x001EFA14
		private void ClampInputs()
		{
			this.RollInput = Mathf.Clamp(this.RollInput, -1f, 1f);
			this.PitchInput = Mathf.Clamp(this.PitchInput, -1f, 1f);
			this.YawInput = Mathf.Clamp(this.YawInput, -1f, 1f);
			this.ThrottleInput = Mathf.Clamp(this.ThrottleInput, -1f, 1f);
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x001F1890 File Offset: 0x001EFA90
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

		// Token: 0x06002219 RID: 8729 RVA: 0x001F1920 File Offset: 0x001EFB20
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

		// Token: 0x0600221A RID: 8730 RVA: 0x001F19A8 File Offset: 0x001EFBA8
		private void CalculateForwardSpeed()
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.m_Rigidbody.velocity);
			this.ForwardSpeed = Mathf.Max(0f, vector.z);
		}

		// Token: 0x0600221B RID: 8731 RVA: 0x001F19E4 File Offset: 0x001EFBE4
		private void ControlThrottle()
		{
			if (this.m_Immobilized)
			{
				this.ThrottleInput = -0.5f;
			}
			this.Throttle = Mathf.Clamp01(this.Throttle + this.ThrottleInput * Time.deltaTime * this.m_ThrottleChangeSpeed);
			this.EnginePower = this.Throttle * this.m_MaxEnginePower;
		}

		// Token: 0x0600221C RID: 8732 RVA: 0x001F1A3C File Offset: 0x001EFC3C
		private void CalculateDrag()
		{
			float num = this.m_Rigidbody.velocity.magnitude * this.m_DragIncreaseFactor;
			this.m_Rigidbody.drag = (this.AirBrakes ? ((this.m_OriginalDrag + num) * this.m_AirBrakesEffect) : (this.m_OriginalDrag + num));
			this.m_Rigidbody.angularDrag = this.m_OriginalAngularDrag * this.ForwardSpeed;
		}

		// Token: 0x0600221D RID: 8733 RVA: 0x001F1AA8 File Offset: 0x001EFCA8
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

		// Token: 0x0600221E RID: 8734 RVA: 0x001F1BA0 File Offset: 0x001EFDA0
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

		// Token: 0x0600221F RID: 8735 RVA: 0x001F1C44 File Offset: 0x001EFE44
		private void CalculateTorque()
		{
			Vector3 a = Vector3.zero;
			a += this.PitchInput * this.m_PitchEffect * base.transform.right;
			a += this.YawInput * this.m_YawEffect * base.transform.up;
			a += -this.RollInput * this.m_RollEffect * base.transform.forward;
			a += this.m_BankedTurnAmount * this.m_BankedTurnEffect * base.transform.up;
			this.m_Rigidbody.AddTorque(a * this.ForwardSpeed * this.m_AeroFactor);
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001F1D0C File Offset: 0x001EFF0C
		private void CalculateAltitude()
		{
			Ray ray = new Ray(base.transform.position - Vector3.up * 10f, -Vector3.up);
			RaycastHit raycastHit;
			this.Altitude = (Physics.Raycast(ray, out raycastHit) ? (raycastHit.distance + 10f) : base.transform.position.y);
		}

		// Token: 0x06002221 RID: 8737 RVA: 0x001F1D78 File Offset: 0x001EFF78
		public void Immobilize()
		{
			this.m_Immobilized = true;
		}

		// Token: 0x06002222 RID: 8738 RVA: 0x001F1D81 File Offset: 0x001EFF81
		public void Reset()
		{
			this.m_Immobilized = false;
		}

		// Token: 0x04004AA0 RID: 19104
		[SerializeField]
		private float m_MaxEnginePower = 40f;

		// Token: 0x04004AA1 RID: 19105
		[SerializeField]
		private float m_Lift = 0.002f;

		// Token: 0x04004AA2 RID: 19106
		[SerializeField]
		private float m_ZeroLiftSpeed = 300f;

		// Token: 0x04004AA3 RID: 19107
		[SerializeField]
		private float m_RollEffect = 1f;

		// Token: 0x04004AA4 RID: 19108
		[SerializeField]
		private float m_PitchEffect = 1f;

		// Token: 0x04004AA5 RID: 19109
		[SerializeField]
		private float m_YawEffect = 0.2f;

		// Token: 0x04004AA6 RID: 19110
		[SerializeField]
		private float m_BankedTurnEffect = 0.5f;

		// Token: 0x04004AA7 RID: 19111
		[SerializeField]
		private float m_AerodynamicEffect = 0.02f;

		// Token: 0x04004AA8 RID: 19112
		[SerializeField]
		private float m_AutoTurnPitch = 0.5f;

		// Token: 0x04004AA9 RID: 19113
		[SerializeField]
		private float m_AutoRollLevel = 0.2f;

		// Token: 0x04004AAA RID: 19114
		[SerializeField]
		private float m_AutoPitchLevel = 0.2f;

		// Token: 0x04004AAB RID: 19115
		[SerializeField]
		private float m_AirBrakesEffect = 3f;

		// Token: 0x04004AAC RID: 19116
		[SerializeField]
		private float m_ThrottleChangeSpeed = 0.3f;

		// Token: 0x04004AAD RID: 19117
		[SerializeField]
		private float m_DragIncreaseFactor = 0.001f;

		// Token: 0x04004AB9 RID: 19129
		private float m_OriginalDrag;

		// Token: 0x04004ABA RID: 19130
		private float m_OriginalAngularDrag;

		// Token: 0x04004ABB RID: 19131
		private float m_AeroFactor;

		// Token: 0x04004ABC RID: 19132
		private bool m_Immobilized;

		// Token: 0x04004ABD RID: 19133
		private float m_BankedTurnAmount;

		// Token: 0x04004ABE RID: 19134
		private Rigidbody m_Rigidbody;

		// Token: 0x04004ABF RID: 19135
		private WheelCollider[] m_WheelColliders;
	}
}
