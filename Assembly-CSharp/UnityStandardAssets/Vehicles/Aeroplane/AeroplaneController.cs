using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000530 RID: 1328
	[RequireComponent(typeof(Rigidbody))]
	public class AeroplaneController : MonoBehaviour
	{
		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060021C8 RID: 8648 RVA: 0x001ECF81 File Offset: 0x001EB181
		// (set) Token: 0x060021C9 RID: 8649 RVA: 0x001ECF89 File Offset: 0x001EB189
		public float Altitude { get; private set; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x060021CA RID: 8650 RVA: 0x001ECF92 File Offset: 0x001EB192
		// (set) Token: 0x060021CB RID: 8651 RVA: 0x001ECF9A File Offset: 0x001EB19A
		public float Throttle { get; private set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x060021CC RID: 8652 RVA: 0x001ECFA3 File Offset: 0x001EB1A3
		// (set) Token: 0x060021CD RID: 8653 RVA: 0x001ECFAB File Offset: 0x001EB1AB
		public bool AirBrakes { get; private set; }

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x060021CE RID: 8654 RVA: 0x001ECFB4 File Offset: 0x001EB1B4
		// (set) Token: 0x060021CF RID: 8655 RVA: 0x001ECFBC File Offset: 0x001EB1BC
		public float ForwardSpeed { get; private set; }

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x060021D0 RID: 8656 RVA: 0x001ECFC5 File Offset: 0x001EB1C5
		// (set) Token: 0x060021D1 RID: 8657 RVA: 0x001ECFCD File Offset: 0x001EB1CD
		public float EnginePower { get; private set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x060021D2 RID: 8658 RVA: 0x001ECFD6 File Offset: 0x001EB1D6
		public float MaxEnginePower
		{
			get
			{
				return this.m_MaxEnginePower;
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x060021D3 RID: 8659 RVA: 0x001ECFDE File Offset: 0x001EB1DE
		// (set) Token: 0x060021D4 RID: 8660 RVA: 0x001ECFE6 File Offset: 0x001EB1E6
		public float RollAngle { get; private set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060021D5 RID: 8661 RVA: 0x001ECFEF File Offset: 0x001EB1EF
		// (set) Token: 0x060021D6 RID: 8662 RVA: 0x001ECFF7 File Offset: 0x001EB1F7
		public float PitchAngle { get; private set; }

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060021D7 RID: 8663 RVA: 0x001ED000 File Offset: 0x001EB200
		// (set) Token: 0x060021D8 RID: 8664 RVA: 0x001ED008 File Offset: 0x001EB208
		public float RollInput { get; private set; }

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x060021D9 RID: 8665 RVA: 0x001ED011 File Offset: 0x001EB211
		// (set) Token: 0x060021DA RID: 8666 RVA: 0x001ED019 File Offset: 0x001EB219
		public float PitchInput { get; private set; }

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x060021DB RID: 8667 RVA: 0x001ED022 File Offset: 0x001EB222
		// (set) Token: 0x060021DC RID: 8668 RVA: 0x001ED02A File Offset: 0x001EB22A
		public float YawInput { get; private set; }

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x060021DD RID: 8669 RVA: 0x001ED033 File Offset: 0x001EB233
		// (set) Token: 0x060021DE RID: 8670 RVA: 0x001ED03B File Offset: 0x001EB23B
		public float ThrottleInput { get; private set; }

		// Token: 0x060021DF RID: 8671 RVA: 0x001ED044 File Offset: 0x001EB244
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

		// Token: 0x060021E0 RID: 8672 RVA: 0x001ED0C4 File Offset: 0x001EB2C4
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

		// Token: 0x060021E1 RID: 8673 RVA: 0x001ED134 File Offset: 0x001EB334
		private void ClampInputs()
		{
			this.RollInput = Mathf.Clamp(this.RollInput, -1f, 1f);
			this.PitchInput = Mathf.Clamp(this.PitchInput, -1f, 1f);
			this.YawInput = Mathf.Clamp(this.YawInput, -1f, 1f);
			this.ThrottleInput = Mathf.Clamp(this.ThrottleInput, -1f, 1f);
		}

		// Token: 0x060021E2 RID: 8674 RVA: 0x001ED1B0 File Offset: 0x001EB3B0
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

		// Token: 0x060021E3 RID: 8675 RVA: 0x001ED240 File Offset: 0x001EB440
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

		// Token: 0x060021E4 RID: 8676 RVA: 0x001ED2C8 File Offset: 0x001EB4C8
		private void CalculateForwardSpeed()
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.m_Rigidbody.velocity);
			this.ForwardSpeed = Mathf.Max(0f, vector.z);
		}

		// Token: 0x060021E5 RID: 8677 RVA: 0x001ED304 File Offset: 0x001EB504
		private void ControlThrottle()
		{
			if (this.m_Immobilized)
			{
				this.ThrottleInput = -0.5f;
			}
			this.Throttle = Mathf.Clamp01(this.Throttle + this.ThrottleInput * Time.deltaTime * this.m_ThrottleChangeSpeed);
			this.EnginePower = this.Throttle * this.m_MaxEnginePower;
		}

		// Token: 0x060021E6 RID: 8678 RVA: 0x001ED35C File Offset: 0x001EB55C
		private void CalculateDrag()
		{
			float num = this.m_Rigidbody.velocity.magnitude * this.m_DragIncreaseFactor;
			this.m_Rigidbody.drag = (this.AirBrakes ? ((this.m_OriginalDrag + num) * this.m_AirBrakesEffect) : (this.m_OriginalDrag + num));
			this.m_Rigidbody.angularDrag = this.m_OriginalAngularDrag * this.ForwardSpeed;
		}

		// Token: 0x060021E7 RID: 8679 RVA: 0x001ED3C8 File Offset: 0x001EB5C8
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

		// Token: 0x060021E8 RID: 8680 RVA: 0x001ED4C0 File Offset: 0x001EB6C0
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

		// Token: 0x060021E9 RID: 8681 RVA: 0x001ED564 File Offset: 0x001EB764
		private void CalculateTorque()
		{
			Vector3 a = Vector3.zero;
			a += this.PitchInput * this.m_PitchEffect * base.transform.right;
			a += this.YawInput * this.m_YawEffect * base.transform.up;
			a += -this.RollInput * this.m_RollEffect * base.transform.forward;
			a += this.m_BankedTurnAmount * this.m_BankedTurnEffect * base.transform.up;
			this.m_Rigidbody.AddTorque(a * this.ForwardSpeed * this.m_AeroFactor);
		}

		// Token: 0x060021EA RID: 8682 RVA: 0x001ED62C File Offset: 0x001EB82C
		private void CalculateAltitude()
		{
			Ray ray = new Ray(base.transform.position - Vector3.up * 10f, -Vector3.up);
			RaycastHit raycastHit;
			this.Altitude = (Physics.Raycast(ray, out raycastHit) ? (raycastHit.distance + 10f) : base.transform.position.y);
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x001ED698 File Offset: 0x001EB898
		public void Immobilize()
		{
			this.m_Immobilized = true;
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x001ED6A1 File Offset: 0x001EB8A1
		public void Reset()
		{
			this.m_Immobilized = false;
		}

		// Token: 0x040049EE RID: 18926
		[SerializeField]
		private float m_MaxEnginePower = 40f;

		// Token: 0x040049EF RID: 18927
		[SerializeField]
		private float m_Lift = 0.002f;

		// Token: 0x040049F0 RID: 18928
		[SerializeField]
		private float m_ZeroLiftSpeed = 300f;

		// Token: 0x040049F1 RID: 18929
		[SerializeField]
		private float m_RollEffect = 1f;

		// Token: 0x040049F2 RID: 18930
		[SerializeField]
		private float m_PitchEffect = 1f;

		// Token: 0x040049F3 RID: 18931
		[SerializeField]
		private float m_YawEffect = 0.2f;

		// Token: 0x040049F4 RID: 18932
		[SerializeField]
		private float m_BankedTurnEffect = 0.5f;

		// Token: 0x040049F5 RID: 18933
		[SerializeField]
		private float m_AerodynamicEffect = 0.02f;

		// Token: 0x040049F6 RID: 18934
		[SerializeField]
		private float m_AutoTurnPitch = 0.5f;

		// Token: 0x040049F7 RID: 18935
		[SerializeField]
		private float m_AutoRollLevel = 0.2f;

		// Token: 0x040049F8 RID: 18936
		[SerializeField]
		private float m_AutoPitchLevel = 0.2f;

		// Token: 0x040049F9 RID: 18937
		[SerializeField]
		private float m_AirBrakesEffect = 3f;

		// Token: 0x040049FA RID: 18938
		[SerializeField]
		private float m_ThrottleChangeSpeed = 0.3f;

		// Token: 0x040049FB RID: 18939
		[SerializeField]
		private float m_DragIncreaseFactor = 0.001f;

		// Token: 0x04004A07 RID: 18951
		private float m_OriginalDrag;

		// Token: 0x04004A08 RID: 18952
		private float m_OriginalAngularDrag;

		// Token: 0x04004A09 RID: 18953
		private float m_AeroFactor;

		// Token: 0x04004A0A RID: 18954
		private bool m_Immobilized;

		// Token: 0x04004A0B RID: 18955
		private float m_BankedTurnAmount;

		// Token: 0x04004A0C RID: 18956
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A0D RID: 18957
		private WheelCollider[] m_WheelColliders;
	}
}
