using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053C RID: 1340
	[RequireComponent(typeof(Rigidbody))]
	public class AeroplaneController : MonoBehaviour
	{
		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x0600220F RID: 8719 RVA: 0x001F3645 File Offset: 0x001F1845
		// (set) Token: 0x06002210 RID: 8720 RVA: 0x001F364D File Offset: 0x001F184D
		public float Altitude { get; private set; }

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06002211 RID: 8721 RVA: 0x001F3656 File Offset: 0x001F1856
		// (set) Token: 0x06002212 RID: 8722 RVA: 0x001F365E File Offset: 0x001F185E
		public float Throttle { get; private set; }

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06002213 RID: 8723 RVA: 0x001F3667 File Offset: 0x001F1867
		// (set) Token: 0x06002214 RID: 8724 RVA: 0x001F366F File Offset: 0x001F186F
		public bool AirBrakes { get; private set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06002215 RID: 8725 RVA: 0x001F3678 File Offset: 0x001F1878
		// (set) Token: 0x06002216 RID: 8726 RVA: 0x001F3680 File Offset: 0x001F1880
		public float ForwardSpeed { get; private set; }

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06002217 RID: 8727 RVA: 0x001F3689 File Offset: 0x001F1889
		// (set) Token: 0x06002218 RID: 8728 RVA: 0x001F3691 File Offset: 0x001F1891
		public float EnginePower { get; private set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06002219 RID: 8729 RVA: 0x001F369A File Offset: 0x001F189A
		public float MaxEnginePower
		{
			get
			{
				return this.m_MaxEnginePower;
			}
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x0600221A RID: 8730 RVA: 0x001F36A2 File Offset: 0x001F18A2
		// (set) Token: 0x0600221B RID: 8731 RVA: 0x001F36AA File Offset: 0x001F18AA
		public float RollAngle { get; private set; }

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x0600221C RID: 8732 RVA: 0x001F36B3 File Offset: 0x001F18B3
		// (set) Token: 0x0600221D RID: 8733 RVA: 0x001F36BB File Offset: 0x001F18BB
		public float PitchAngle { get; private set; }

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x0600221E RID: 8734 RVA: 0x001F36C4 File Offset: 0x001F18C4
		// (set) Token: 0x0600221F RID: 8735 RVA: 0x001F36CC File Offset: 0x001F18CC
		public float RollInput { get; private set; }

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06002220 RID: 8736 RVA: 0x001F36D5 File Offset: 0x001F18D5
		// (set) Token: 0x06002221 RID: 8737 RVA: 0x001F36DD File Offset: 0x001F18DD
		public float PitchInput { get; private set; }

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06002222 RID: 8738 RVA: 0x001F36E6 File Offset: 0x001F18E6
		// (set) Token: 0x06002223 RID: 8739 RVA: 0x001F36EE File Offset: 0x001F18EE
		public float YawInput { get; private set; }

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06002224 RID: 8740 RVA: 0x001F36F7 File Offset: 0x001F18F7
		// (set) Token: 0x06002225 RID: 8741 RVA: 0x001F36FF File Offset: 0x001F18FF
		public float ThrottleInput { get; private set; }

		// Token: 0x06002226 RID: 8742 RVA: 0x001F3708 File Offset: 0x001F1908
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

		// Token: 0x06002227 RID: 8743 RVA: 0x001F3788 File Offset: 0x001F1988
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

		// Token: 0x06002228 RID: 8744 RVA: 0x001F37F8 File Offset: 0x001F19F8
		private void ClampInputs()
		{
			this.RollInput = Mathf.Clamp(this.RollInput, -1f, 1f);
			this.PitchInput = Mathf.Clamp(this.PitchInput, -1f, 1f);
			this.YawInput = Mathf.Clamp(this.YawInput, -1f, 1f);
			this.ThrottleInput = Mathf.Clamp(this.ThrottleInput, -1f, 1f);
		}

		// Token: 0x06002229 RID: 8745 RVA: 0x001F3874 File Offset: 0x001F1A74
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

		// Token: 0x0600222A RID: 8746 RVA: 0x001F3904 File Offset: 0x001F1B04
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

		// Token: 0x0600222B RID: 8747 RVA: 0x001F398C File Offset: 0x001F1B8C
		private void CalculateForwardSpeed()
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.m_Rigidbody.velocity);
			this.ForwardSpeed = Mathf.Max(0f, vector.z);
		}

		// Token: 0x0600222C RID: 8748 RVA: 0x001F39C8 File Offset: 0x001F1BC8
		private void ControlThrottle()
		{
			if (this.m_Immobilized)
			{
				this.ThrottleInput = -0.5f;
			}
			this.Throttle = Mathf.Clamp01(this.Throttle + this.ThrottleInput * Time.deltaTime * this.m_ThrottleChangeSpeed);
			this.EnginePower = this.Throttle * this.m_MaxEnginePower;
		}

		// Token: 0x0600222D RID: 8749 RVA: 0x001F3A20 File Offset: 0x001F1C20
		private void CalculateDrag()
		{
			float num = this.m_Rigidbody.velocity.magnitude * this.m_DragIncreaseFactor;
			this.m_Rigidbody.drag = (this.AirBrakes ? ((this.m_OriginalDrag + num) * this.m_AirBrakesEffect) : (this.m_OriginalDrag + num));
			this.m_Rigidbody.angularDrag = this.m_OriginalAngularDrag * this.ForwardSpeed;
		}

		// Token: 0x0600222E RID: 8750 RVA: 0x001F3A8C File Offset: 0x001F1C8C
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

		// Token: 0x0600222F RID: 8751 RVA: 0x001F3B84 File Offset: 0x001F1D84
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

		// Token: 0x06002230 RID: 8752 RVA: 0x001F3C28 File Offset: 0x001F1E28
		private void CalculateTorque()
		{
			Vector3 a = Vector3.zero;
			a += this.PitchInput * this.m_PitchEffect * base.transform.right;
			a += this.YawInput * this.m_YawEffect * base.transform.up;
			a += -this.RollInput * this.m_RollEffect * base.transform.forward;
			a += this.m_BankedTurnAmount * this.m_BankedTurnEffect * base.transform.up;
			this.m_Rigidbody.AddTorque(a * this.ForwardSpeed * this.m_AeroFactor);
		}

		// Token: 0x06002231 RID: 8753 RVA: 0x001F3CF0 File Offset: 0x001F1EF0
		private void CalculateAltitude()
		{
			Ray ray = new Ray(base.transform.position - Vector3.up * 10f, -Vector3.up);
			RaycastHit raycastHit;
			this.Altitude = (Physics.Raycast(ray, out raycastHit) ? (raycastHit.distance + 10f) : base.transform.position.y);
		}

		// Token: 0x06002232 RID: 8754 RVA: 0x001F3D5C File Offset: 0x001F1F5C
		public void Immobilize()
		{
			this.m_Immobilized = true;
		}

		// Token: 0x06002233 RID: 8755 RVA: 0x001F3D65 File Offset: 0x001F1F65
		public void Reset()
		{
			this.m_Immobilized = false;
		}

		// Token: 0x04004AC8 RID: 19144
		[SerializeField]
		private float m_MaxEnginePower = 40f;

		// Token: 0x04004AC9 RID: 19145
		[SerializeField]
		private float m_Lift = 0.002f;

		// Token: 0x04004ACA RID: 19146
		[SerializeField]
		private float m_ZeroLiftSpeed = 300f;

		// Token: 0x04004ACB RID: 19147
		[SerializeField]
		private float m_RollEffect = 1f;

		// Token: 0x04004ACC RID: 19148
		[SerializeField]
		private float m_PitchEffect = 1f;

		// Token: 0x04004ACD RID: 19149
		[SerializeField]
		private float m_YawEffect = 0.2f;

		// Token: 0x04004ACE RID: 19150
		[SerializeField]
		private float m_BankedTurnEffect = 0.5f;

		// Token: 0x04004ACF RID: 19151
		[SerializeField]
		private float m_AerodynamicEffect = 0.02f;

		// Token: 0x04004AD0 RID: 19152
		[SerializeField]
		private float m_AutoTurnPitch = 0.5f;

		// Token: 0x04004AD1 RID: 19153
		[SerializeField]
		private float m_AutoRollLevel = 0.2f;

		// Token: 0x04004AD2 RID: 19154
		[SerializeField]
		private float m_AutoPitchLevel = 0.2f;

		// Token: 0x04004AD3 RID: 19155
		[SerializeField]
		private float m_AirBrakesEffect = 3f;

		// Token: 0x04004AD4 RID: 19156
		[SerializeField]
		private float m_ThrottleChangeSpeed = 0.3f;

		// Token: 0x04004AD5 RID: 19157
		[SerializeField]
		private float m_DragIncreaseFactor = 0.001f;

		// Token: 0x04004AE1 RID: 19169
		private float m_OriginalDrag;

		// Token: 0x04004AE2 RID: 19170
		private float m_OriginalAngularDrag;

		// Token: 0x04004AE3 RID: 19171
		private float m_AeroFactor;

		// Token: 0x04004AE4 RID: 19172
		private bool m_Immobilized;

		// Token: 0x04004AE5 RID: 19173
		private float m_BankedTurnAmount;

		// Token: 0x04004AE6 RID: 19174
		private Rigidbody m_Rigidbody;

		// Token: 0x04004AE7 RID: 19175
		private WheelCollider[] m_WheelColliders;
	}
}
