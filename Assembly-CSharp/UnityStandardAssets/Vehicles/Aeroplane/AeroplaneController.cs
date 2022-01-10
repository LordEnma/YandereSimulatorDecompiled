using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052D RID: 1325
	[RequireComponent(typeof(Rigidbody))]
	public class AeroplaneController : MonoBehaviour
	{
		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060021AD RID: 8621 RVA: 0x001EA461 File Offset: 0x001E8661
		// (set) Token: 0x060021AE RID: 8622 RVA: 0x001EA469 File Offset: 0x001E8669
		public float Altitude { get; private set; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060021AF RID: 8623 RVA: 0x001EA472 File Offset: 0x001E8672
		// (set) Token: 0x060021B0 RID: 8624 RVA: 0x001EA47A File Offset: 0x001E867A
		public float Throttle { get; private set; }

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060021B1 RID: 8625 RVA: 0x001EA483 File Offset: 0x001E8683
		// (set) Token: 0x060021B2 RID: 8626 RVA: 0x001EA48B File Offset: 0x001E868B
		public bool AirBrakes { get; private set; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x060021B3 RID: 8627 RVA: 0x001EA494 File Offset: 0x001E8694
		// (set) Token: 0x060021B4 RID: 8628 RVA: 0x001EA49C File Offset: 0x001E869C
		public float ForwardSpeed { get; private set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x060021B5 RID: 8629 RVA: 0x001EA4A5 File Offset: 0x001E86A5
		// (set) Token: 0x060021B6 RID: 8630 RVA: 0x001EA4AD File Offset: 0x001E86AD
		public float EnginePower { get; private set; }

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x060021B7 RID: 8631 RVA: 0x001EA4B6 File Offset: 0x001E86B6
		public float MaxEnginePower
		{
			get
			{
				return this.m_MaxEnginePower;
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x060021B8 RID: 8632 RVA: 0x001EA4BE File Offset: 0x001E86BE
		// (set) Token: 0x060021B9 RID: 8633 RVA: 0x001EA4C6 File Offset: 0x001E86C6
		public float RollAngle { get; private set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x060021BA RID: 8634 RVA: 0x001EA4CF File Offset: 0x001E86CF
		// (set) Token: 0x060021BB RID: 8635 RVA: 0x001EA4D7 File Offset: 0x001E86D7
		public float PitchAngle { get; private set; }

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x060021BC RID: 8636 RVA: 0x001EA4E0 File Offset: 0x001E86E0
		// (set) Token: 0x060021BD RID: 8637 RVA: 0x001EA4E8 File Offset: 0x001E86E8
		public float RollInput { get; private set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060021BE RID: 8638 RVA: 0x001EA4F1 File Offset: 0x001E86F1
		// (set) Token: 0x060021BF RID: 8639 RVA: 0x001EA4F9 File Offset: 0x001E86F9
		public float PitchInput { get; private set; }

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060021C0 RID: 8640 RVA: 0x001EA502 File Offset: 0x001E8702
		// (set) Token: 0x060021C1 RID: 8641 RVA: 0x001EA50A File Offset: 0x001E870A
		public float YawInput { get; private set; }

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x060021C2 RID: 8642 RVA: 0x001EA513 File Offset: 0x001E8713
		// (set) Token: 0x060021C3 RID: 8643 RVA: 0x001EA51B File Offset: 0x001E871B
		public float ThrottleInput { get; private set; }

		// Token: 0x060021C4 RID: 8644 RVA: 0x001EA524 File Offset: 0x001E8724
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

		// Token: 0x060021C5 RID: 8645 RVA: 0x001EA5A4 File Offset: 0x001E87A4
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

		// Token: 0x060021C6 RID: 8646 RVA: 0x001EA614 File Offset: 0x001E8814
		private void ClampInputs()
		{
			this.RollInput = Mathf.Clamp(this.RollInput, -1f, 1f);
			this.PitchInput = Mathf.Clamp(this.PitchInput, -1f, 1f);
			this.YawInput = Mathf.Clamp(this.YawInput, -1f, 1f);
			this.ThrottleInput = Mathf.Clamp(this.ThrottleInput, -1f, 1f);
		}

		// Token: 0x060021C7 RID: 8647 RVA: 0x001EA690 File Offset: 0x001E8890
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

		// Token: 0x060021C8 RID: 8648 RVA: 0x001EA720 File Offset: 0x001E8920
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

		// Token: 0x060021C9 RID: 8649 RVA: 0x001EA7A8 File Offset: 0x001E89A8
		private void CalculateForwardSpeed()
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.m_Rigidbody.velocity);
			this.ForwardSpeed = Mathf.Max(0f, vector.z);
		}

		// Token: 0x060021CA RID: 8650 RVA: 0x001EA7E4 File Offset: 0x001E89E4
		private void ControlThrottle()
		{
			if (this.m_Immobilized)
			{
				this.ThrottleInput = -0.5f;
			}
			this.Throttle = Mathf.Clamp01(this.Throttle + this.ThrottleInput * Time.deltaTime * this.m_ThrottleChangeSpeed);
			this.EnginePower = this.Throttle * this.m_MaxEnginePower;
		}

		// Token: 0x060021CB RID: 8651 RVA: 0x001EA83C File Offset: 0x001E8A3C
		private void CalculateDrag()
		{
			float num = this.m_Rigidbody.velocity.magnitude * this.m_DragIncreaseFactor;
			this.m_Rigidbody.drag = (this.AirBrakes ? ((this.m_OriginalDrag + num) * this.m_AirBrakesEffect) : (this.m_OriginalDrag + num));
			this.m_Rigidbody.angularDrag = this.m_OriginalAngularDrag * this.ForwardSpeed;
		}

		// Token: 0x060021CC RID: 8652 RVA: 0x001EA8A8 File Offset: 0x001E8AA8
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

		// Token: 0x060021CD RID: 8653 RVA: 0x001EA9A0 File Offset: 0x001E8BA0
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

		// Token: 0x060021CE RID: 8654 RVA: 0x001EAA44 File Offset: 0x001E8C44
		private void CalculateTorque()
		{
			Vector3 a = Vector3.zero;
			a += this.PitchInput * this.m_PitchEffect * base.transform.right;
			a += this.YawInput * this.m_YawEffect * base.transform.up;
			a += -this.RollInput * this.m_RollEffect * base.transform.forward;
			a += this.m_BankedTurnAmount * this.m_BankedTurnEffect * base.transform.up;
			this.m_Rigidbody.AddTorque(a * this.ForwardSpeed * this.m_AeroFactor);
		}

		// Token: 0x060021CF RID: 8655 RVA: 0x001EAB0C File Offset: 0x001E8D0C
		private void CalculateAltitude()
		{
			Ray ray = new Ray(base.transform.position - Vector3.up * 10f, -Vector3.up);
			RaycastHit raycastHit;
			this.Altitude = (Physics.Raycast(ray, out raycastHit) ? (raycastHit.distance + 10f) : base.transform.position.y);
		}

		// Token: 0x060021D0 RID: 8656 RVA: 0x001EAB78 File Offset: 0x001E8D78
		public void Immobilize()
		{
			this.m_Immobilized = true;
		}

		// Token: 0x060021D1 RID: 8657 RVA: 0x001EAB81 File Offset: 0x001E8D81
		public void Reset()
		{
			this.m_Immobilized = false;
		}

		// Token: 0x040049BA RID: 18874
		[SerializeField]
		private float m_MaxEnginePower = 40f;

		// Token: 0x040049BB RID: 18875
		[SerializeField]
		private float m_Lift = 0.002f;

		// Token: 0x040049BC RID: 18876
		[SerializeField]
		private float m_ZeroLiftSpeed = 300f;

		// Token: 0x040049BD RID: 18877
		[SerializeField]
		private float m_RollEffect = 1f;

		// Token: 0x040049BE RID: 18878
		[SerializeField]
		private float m_PitchEffect = 1f;

		// Token: 0x040049BF RID: 18879
		[SerializeField]
		private float m_YawEffect = 0.2f;

		// Token: 0x040049C0 RID: 18880
		[SerializeField]
		private float m_BankedTurnEffect = 0.5f;

		// Token: 0x040049C1 RID: 18881
		[SerializeField]
		private float m_AerodynamicEffect = 0.02f;

		// Token: 0x040049C2 RID: 18882
		[SerializeField]
		private float m_AutoTurnPitch = 0.5f;

		// Token: 0x040049C3 RID: 18883
		[SerializeField]
		private float m_AutoRollLevel = 0.2f;

		// Token: 0x040049C4 RID: 18884
		[SerializeField]
		private float m_AutoPitchLevel = 0.2f;

		// Token: 0x040049C5 RID: 18885
		[SerializeField]
		private float m_AirBrakesEffect = 3f;

		// Token: 0x040049C6 RID: 18886
		[SerializeField]
		private float m_ThrottleChangeSpeed = 0.3f;

		// Token: 0x040049C7 RID: 18887
		[SerializeField]
		private float m_DragIncreaseFactor = 0.001f;

		// Token: 0x040049D3 RID: 18899
		private float m_OriginalDrag;

		// Token: 0x040049D4 RID: 18900
		private float m_OriginalAngularDrag;

		// Token: 0x040049D5 RID: 18901
		private float m_AeroFactor;

		// Token: 0x040049D6 RID: 18902
		private bool m_Immobilized;

		// Token: 0x040049D7 RID: 18903
		private float m_BankedTurnAmount;

		// Token: 0x040049D8 RID: 18904
		private Rigidbody m_Rigidbody;

		// Token: 0x040049D9 RID: 18905
		private WheelCollider[] m_WheelColliders;
	}
}
