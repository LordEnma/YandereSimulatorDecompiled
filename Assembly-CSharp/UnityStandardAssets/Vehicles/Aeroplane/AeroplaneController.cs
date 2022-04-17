using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053B RID: 1339
	[RequireComponent(typeof(Rigidbody))]
	public class AeroplaneController : MonoBehaviour
	{
		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06002205 RID: 8709 RVA: 0x001F20BD File Offset: 0x001F02BD
		// (set) Token: 0x06002206 RID: 8710 RVA: 0x001F20C5 File Offset: 0x001F02C5
		public float Altitude { get; private set; }

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06002207 RID: 8711 RVA: 0x001F20CE File Offset: 0x001F02CE
		// (set) Token: 0x06002208 RID: 8712 RVA: 0x001F20D6 File Offset: 0x001F02D6
		public float Throttle { get; private set; }

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06002209 RID: 8713 RVA: 0x001F20DF File Offset: 0x001F02DF
		// (set) Token: 0x0600220A RID: 8714 RVA: 0x001F20E7 File Offset: 0x001F02E7
		public bool AirBrakes { get; private set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x0600220B RID: 8715 RVA: 0x001F20F0 File Offset: 0x001F02F0
		// (set) Token: 0x0600220C RID: 8716 RVA: 0x001F20F8 File Offset: 0x001F02F8
		public float ForwardSpeed { get; private set; }

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x0600220D RID: 8717 RVA: 0x001F2101 File Offset: 0x001F0301
		// (set) Token: 0x0600220E RID: 8718 RVA: 0x001F2109 File Offset: 0x001F0309
		public float EnginePower { get; private set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x0600220F RID: 8719 RVA: 0x001F2112 File Offset: 0x001F0312
		public float MaxEnginePower
		{
			get
			{
				return this.m_MaxEnginePower;
			}
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06002210 RID: 8720 RVA: 0x001F211A File Offset: 0x001F031A
		// (set) Token: 0x06002211 RID: 8721 RVA: 0x001F2122 File Offset: 0x001F0322
		public float RollAngle { get; private set; }

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06002212 RID: 8722 RVA: 0x001F212B File Offset: 0x001F032B
		// (set) Token: 0x06002213 RID: 8723 RVA: 0x001F2133 File Offset: 0x001F0333
		public float PitchAngle { get; private set; }

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06002214 RID: 8724 RVA: 0x001F213C File Offset: 0x001F033C
		// (set) Token: 0x06002215 RID: 8725 RVA: 0x001F2144 File Offset: 0x001F0344
		public float RollInput { get; private set; }

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06002216 RID: 8726 RVA: 0x001F214D File Offset: 0x001F034D
		// (set) Token: 0x06002217 RID: 8727 RVA: 0x001F2155 File Offset: 0x001F0355
		public float PitchInput { get; private set; }

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06002218 RID: 8728 RVA: 0x001F215E File Offset: 0x001F035E
		// (set) Token: 0x06002219 RID: 8729 RVA: 0x001F2166 File Offset: 0x001F0366
		public float YawInput { get; private set; }

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x0600221A RID: 8730 RVA: 0x001F216F File Offset: 0x001F036F
		// (set) Token: 0x0600221B RID: 8731 RVA: 0x001F2177 File Offset: 0x001F0377
		public float ThrottleInput { get; private set; }

		// Token: 0x0600221C RID: 8732 RVA: 0x001F2180 File Offset: 0x001F0380
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

		// Token: 0x0600221D RID: 8733 RVA: 0x001F2200 File Offset: 0x001F0400
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

		// Token: 0x0600221E RID: 8734 RVA: 0x001F2270 File Offset: 0x001F0470
		private void ClampInputs()
		{
			this.RollInput = Mathf.Clamp(this.RollInput, -1f, 1f);
			this.PitchInput = Mathf.Clamp(this.PitchInput, -1f, 1f);
			this.YawInput = Mathf.Clamp(this.YawInput, -1f, 1f);
			this.ThrottleInput = Mathf.Clamp(this.ThrottleInput, -1f, 1f);
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001F22EC File Offset: 0x001F04EC
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

		// Token: 0x06002220 RID: 8736 RVA: 0x001F237C File Offset: 0x001F057C
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

		// Token: 0x06002221 RID: 8737 RVA: 0x001F2404 File Offset: 0x001F0604
		private void CalculateForwardSpeed()
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.m_Rigidbody.velocity);
			this.ForwardSpeed = Mathf.Max(0f, vector.z);
		}

		// Token: 0x06002222 RID: 8738 RVA: 0x001F2440 File Offset: 0x001F0640
		private void ControlThrottle()
		{
			if (this.m_Immobilized)
			{
				this.ThrottleInput = -0.5f;
			}
			this.Throttle = Mathf.Clamp01(this.Throttle + this.ThrottleInput * Time.deltaTime * this.m_ThrottleChangeSpeed);
			this.EnginePower = this.Throttle * this.m_MaxEnginePower;
		}

		// Token: 0x06002223 RID: 8739 RVA: 0x001F2498 File Offset: 0x001F0698
		private void CalculateDrag()
		{
			float num = this.m_Rigidbody.velocity.magnitude * this.m_DragIncreaseFactor;
			this.m_Rigidbody.drag = (this.AirBrakes ? ((this.m_OriginalDrag + num) * this.m_AirBrakesEffect) : (this.m_OriginalDrag + num));
			this.m_Rigidbody.angularDrag = this.m_OriginalAngularDrag * this.ForwardSpeed;
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x001F2504 File Offset: 0x001F0704
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

		// Token: 0x06002225 RID: 8741 RVA: 0x001F25FC File Offset: 0x001F07FC
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

		// Token: 0x06002226 RID: 8742 RVA: 0x001F26A0 File Offset: 0x001F08A0
		private void CalculateTorque()
		{
			Vector3 a = Vector3.zero;
			a += this.PitchInput * this.m_PitchEffect * base.transform.right;
			a += this.YawInput * this.m_YawEffect * base.transform.up;
			a += -this.RollInput * this.m_RollEffect * base.transform.forward;
			a += this.m_BankedTurnAmount * this.m_BankedTurnEffect * base.transform.up;
			this.m_Rigidbody.AddTorque(a * this.ForwardSpeed * this.m_AeroFactor);
		}

		// Token: 0x06002227 RID: 8743 RVA: 0x001F2768 File Offset: 0x001F0968
		private void CalculateAltitude()
		{
			Ray ray = new Ray(base.transform.position - Vector3.up * 10f, -Vector3.up);
			RaycastHit raycastHit;
			this.Altitude = (Physics.Raycast(ray, out raycastHit) ? (raycastHit.distance + 10f) : base.transform.position.y);
		}

		// Token: 0x06002228 RID: 8744 RVA: 0x001F27D4 File Offset: 0x001F09D4
		public void Immobilize()
		{
			this.m_Immobilized = true;
		}

		// Token: 0x06002229 RID: 8745 RVA: 0x001F27DD File Offset: 0x001F09DD
		public void Reset()
		{
			this.m_Immobilized = false;
		}

		// Token: 0x04004AB2 RID: 19122
		[SerializeField]
		private float m_MaxEnginePower = 40f;

		// Token: 0x04004AB3 RID: 19123
		[SerializeField]
		private float m_Lift = 0.002f;

		// Token: 0x04004AB4 RID: 19124
		[SerializeField]
		private float m_ZeroLiftSpeed = 300f;

		// Token: 0x04004AB5 RID: 19125
		[SerializeField]
		private float m_RollEffect = 1f;

		// Token: 0x04004AB6 RID: 19126
		[SerializeField]
		private float m_PitchEffect = 1f;

		// Token: 0x04004AB7 RID: 19127
		[SerializeField]
		private float m_YawEffect = 0.2f;

		// Token: 0x04004AB8 RID: 19128
		[SerializeField]
		private float m_BankedTurnEffect = 0.5f;

		// Token: 0x04004AB9 RID: 19129
		[SerializeField]
		private float m_AerodynamicEffect = 0.02f;

		// Token: 0x04004ABA RID: 19130
		[SerializeField]
		private float m_AutoTurnPitch = 0.5f;

		// Token: 0x04004ABB RID: 19131
		[SerializeField]
		private float m_AutoRollLevel = 0.2f;

		// Token: 0x04004ABC RID: 19132
		[SerializeField]
		private float m_AutoPitchLevel = 0.2f;

		// Token: 0x04004ABD RID: 19133
		[SerializeField]
		private float m_AirBrakesEffect = 3f;

		// Token: 0x04004ABE RID: 19134
		[SerializeField]
		private float m_ThrottleChangeSpeed = 0.3f;

		// Token: 0x04004ABF RID: 19135
		[SerializeField]
		private float m_DragIncreaseFactor = 0.001f;

		// Token: 0x04004ACB RID: 19147
		private float m_OriginalDrag;

		// Token: 0x04004ACC RID: 19148
		private float m_OriginalAngularDrag;

		// Token: 0x04004ACD RID: 19149
		private float m_AeroFactor;

		// Token: 0x04004ACE RID: 19150
		private bool m_Immobilized;

		// Token: 0x04004ACF RID: 19151
		private float m_BankedTurnAmount;

		// Token: 0x04004AD0 RID: 19152
		private Rigidbody m_Rigidbody;

		// Token: 0x04004AD1 RID: 19153
		private WheelCollider[] m_WheelColliders;
	}
}
