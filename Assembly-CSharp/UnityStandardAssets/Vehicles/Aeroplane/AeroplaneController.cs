using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052F RID: 1327
	[RequireComponent(typeof(Rigidbody))]
	public class AeroplaneController : MonoBehaviour
	{
		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060021BF RID: 8639 RVA: 0x001EC3A1 File Offset: 0x001EA5A1
		// (set) Token: 0x060021C0 RID: 8640 RVA: 0x001EC3A9 File Offset: 0x001EA5A9
		public float Altitude { get; private set; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x060021C1 RID: 8641 RVA: 0x001EC3B2 File Offset: 0x001EA5B2
		// (set) Token: 0x060021C2 RID: 8642 RVA: 0x001EC3BA File Offset: 0x001EA5BA
		public float Throttle { get; private set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x060021C3 RID: 8643 RVA: 0x001EC3C3 File Offset: 0x001EA5C3
		// (set) Token: 0x060021C4 RID: 8644 RVA: 0x001EC3CB File Offset: 0x001EA5CB
		public bool AirBrakes { get; private set; }

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x060021C5 RID: 8645 RVA: 0x001EC3D4 File Offset: 0x001EA5D4
		// (set) Token: 0x060021C6 RID: 8646 RVA: 0x001EC3DC File Offset: 0x001EA5DC
		public float ForwardSpeed { get; private set; }

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x060021C7 RID: 8647 RVA: 0x001EC3E5 File Offset: 0x001EA5E5
		// (set) Token: 0x060021C8 RID: 8648 RVA: 0x001EC3ED File Offset: 0x001EA5ED
		public float EnginePower { get; private set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x060021C9 RID: 8649 RVA: 0x001EC3F6 File Offset: 0x001EA5F6
		public float MaxEnginePower
		{
			get
			{
				return this.m_MaxEnginePower;
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x060021CA RID: 8650 RVA: 0x001EC3FE File Offset: 0x001EA5FE
		// (set) Token: 0x060021CB RID: 8651 RVA: 0x001EC406 File Offset: 0x001EA606
		public float RollAngle { get; private set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060021CC RID: 8652 RVA: 0x001EC40F File Offset: 0x001EA60F
		// (set) Token: 0x060021CD RID: 8653 RVA: 0x001EC417 File Offset: 0x001EA617
		public float PitchAngle { get; private set; }

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060021CE RID: 8654 RVA: 0x001EC420 File Offset: 0x001EA620
		// (set) Token: 0x060021CF RID: 8655 RVA: 0x001EC428 File Offset: 0x001EA628
		public float RollInput { get; private set; }

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x060021D0 RID: 8656 RVA: 0x001EC431 File Offset: 0x001EA631
		// (set) Token: 0x060021D1 RID: 8657 RVA: 0x001EC439 File Offset: 0x001EA639
		public float PitchInput { get; private set; }

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x060021D2 RID: 8658 RVA: 0x001EC442 File Offset: 0x001EA642
		// (set) Token: 0x060021D3 RID: 8659 RVA: 0x001EC44A File Offset: 0x001EA64A
		public float YawInput { get; private set; }

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x060021D4 RID: 8660 RVA: 0x001EC453 File Offset: 0x001EA653
		// (set) Token: 0x060021D5 RID: 8661 RVA: 0x001EC45B File Offset: 0x001EA65B
		public float ThrottleInput { get; private set; }

		// Token: 0x060021D6 RID: 8662 RVA: 0x001EC464 File Offset: 0x001EA664
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

		// Token: 0x060021D7 RID: 8663 RVA: 0x001EC4E4 File Offset: 0x001EA6E4
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

		// Token: 0x060021D8 RID: 8664 RVA: 0x001EC554 File Offset: 0x001EA754
		private void ClampInputs()
		{
			this.RollInput = Mathf.Clamp(this.RollInput, -1f, 1f);
			this.PitchInput = Mathf.Clamp(this.PitchInput, -1f, 1f);
			this.YawInput = Mathf.Clamp(this.YawInput, -1f, 1f);
			this.ThrottleInput = Mathf.Clamp(this.ThrottleInput, -1f, 1f);
		}

		// Token: 0x060021D9 RID: 8665 RVA: 0x001EC5D0 File Offset: 0x001EA7D0
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

		// Token: 0x060021DA RID: 8666 RVA: 0x001EC660 File Offset: 0x001EA860
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

		// Token: 0x060021DB RID: 8667 RVA: 0x001EC6E8 File Offset: 0x001EA8E8
		private void CalculateForwardSpeed()
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.m_Rigidbody.velocity);
			this.ForwardSpeed = Mathf.Max(0f, vector.z);
		}

		// Token: 0x060021DC RID: 8668 RVA: 0x001EC724 File Offset: 0x001EA924
		private void ControlThrottle()
		{
			if (this.m_Immobilized)
			{
				this.ThrottleInput = -0.5f;
			}
			this.Throttle = Mathf.Clamp01(this.Throttle + this.ThrottleInput * Time.deltaTime * this.m_ThrottleChangeSpeed);
			this.EnginePower = this.Throttle * this.m_MaxEnginePower;
		}

		// Token: 0x060021DD RID: 8669 RVA: 0x001EC77C File Offset: 0x001EA97C
		private void CalculateDrag()
		{
			float num = this.m_Rigidbody.velocity.magnitude * this.m_DragIncreaseFactor;
			this.m_Rigidbody.drag = (this.AirBrakes ? ((this.m_OriginalDrag + num) * this.m_AirBrakesEffect) : (this.m_OriginalDrag + num));
			this.m_Rigidbody.angularDrag = this.m_OriginalAngularDrag * this.ForwardSpeed;
		}

		// Token: 0x060021DE RID: 8670 RVA: 0x001EC7E8 File Offset: 0x001EA9E8
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

		// Token: 0x060021DF RID: 8671 RVA: 0x001EC8E0 File Offset: 0x001EAAE0
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

		// Token: 0x060021E0 RID: 8672 RVA: 0x001EC984 File Offset: 0x001EAB84
		private void CalculateTorque()
		{
			Vector3 a = Vector3.zero;
			a += this.PitchInput * this.m_PitchEffect * base.transform.right;
			a += this.YawInput * this.m_YawEffect * base.transform.up;
			a += -this.RollInput * this.m_RollEffect * base.transform.forward;
			a += this.m_BankedTurnAmount * this.m_BankedTurnEffect * base.transform.up;
			this.m_Rigidbody.AddTorque(a * this.ForwardSpeed * this.m_AeroFactor);
		}

		// Token: 0x060021E1 RID: 8673 RVA: 0x001ECA4C File Offset: 0x001EAC4C
		private void CalculateAltitude()
		{
			Ray ray = new Ray(base.transform.position - Vector3.up * 10f, -Vector3.up);
			RaycastHit raycastHit;
			this.Altitude = (Physics.Raycast(ray, out raycastHit) ? (raycastHit.distance + 10f) : base.transform.position.y);
		}

		// Token: 0x060021E2 RID: 8674 RVA: 0x001ECAB8 File Offset: 0x001EACB8
		public void Immobilize()
		{
			this.m_Immobilized = true;
		}

		// Token: 0x060021E3 RID: 8675 RVA: 0x001ECAC1 File Offset: 0x001EACC1
		public void Reset()
		{
			this.m_Immobilized = false;
		}

		// Token: 0x040049DE RID: 18910
		[SerializeField]
		private float m_MaxEnginePower = 40f;

		// Token: 0x040049DF RID: 18911
		[SerializeField]
		private float m_Lift = 0.002f;

		// Token: 0x040049E0 RID: 18912
		[SerializeField]
		private float m_ZeroLiftSpeed = 300f;

		// Token: 0x040049E1 RID: 18913
		[SerializeField]
		private float m_RollEffect = 1f;

		// Token: 0x040049E2 RID: 18914
		[SerializeField]
		private float m_PitchEffect = 1f;

		// Token: 0x040049E3 RID: 18915
		[SerializeField]
		private float m_YawEffect = 0.2f;

		// Token: 0x040049E4 RID: 18916
		[SerializeField]
		private float m_BankedTurnEffect = 0.5f;

		// Token: 0x040049E5 RID: 18917
		[SerializeField]
		private float m_AerodynamicEffect = 0.02f;

		// Token: 0x040049E6 RID: 18918
		[SerializeField]
		private float m_AutoTurnPitch = 0.5f;

		// Token: 0x040049E7 RID: 18919
		[SerializeField]
		private float m_AutoRollLevel = 0.2f;

		// Token: 0x040049E8 RID: 18920
		[SerializeField]
		private float m_AutoPitchLevel = 0.2f;

		// Token: 0x040049E9 RID: 18921
		[SerializeField]
		private float m_AirBrakesEffect = 3f;

		// Token: 0x040049EA RID: 18922
		[SerializeField]
		private float m_ThrottleChangeSpeed = 0.3f;

		// Token: 0x040049EB RID: 18923
		[SerializeField]
		private float m_DragIncreaseFactor = 0.001f;

		// Token: 0x040049F7 RID: 18935
		private float m_OriginalDrag;

		// Token: 0x040049F8 RID: 18936
		private float m_OriginalAngularDrag;

		// Token: 0x040049F9 RID: 18937
		private float m_AeroFactor;

		// Token: 0x040049FA RID: 18938
		private bool m_Immobilized;

		// Token: 0x040049FB RID: 18939
		private float m_BankedTurnAmount;

		// Token: 0x040049FC RID: 18940
		private Rigidbody m_Rigidbody;

		// Token: 0x040049FD RID: 18941
		private WheelCollider[] m_WheelColliders;
	}
}
