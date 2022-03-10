using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000531 RID: 1329
	[RequireComponent(typeof(Rigidbody))]
	public class AeroplaneController : MonoBehaviour
	{
		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060021CE RID: 8654 RVA: 0x001ED959 File Offset: 0x001EBB59
		// (set) Token: 0x060021CF RID: 8655 RVA: 0x001ED961 File Offset: 0x001EBB61
		public float Altitude { get; private set; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x060021D0 RID: 8656 RVA: 0x001ED96A File Offset: 0x001EBB6A
		// (set) Token: 0x060021D1 RID: 8657 RVA: 0x001ED972 File Offset: 0x001EBB72
		public float Throttle { get; private set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x060021D2 RID: 8658 RVA: 0x001ED97B File Offset: 0x001EBB7B
		// (set) Token: 0x060021D3 RID: 8659 RVA: 0x001ED983 File Offset: 0x001EBB83
		public bool AirBrakes { get; private set; }

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x060021D4 RID: 8660 RVA: 0x001ED98C File Offset: 0x001EBB8C
		// (set) Token: 0x060021D5 RID: 8661 RVA: 0x001ED994 File Offset: 0x001EBB94
		public float ForwardSpeed { get; private set; }

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x060021D6 RID: 8662 RVA: 0x001ED99D File Offset: 0x001EBB9D
		// (set) Token: 0x060021D7 RID: 8663 RVA: 0x001ED9A5 File Offset: 0x001EBBA5
		public float EnginePower { get; private set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x060021D8 RID: 8664 RVA: 0x001ED9AE File Offset: 0x001EBBAE
		public float MaxEnginePower
		{
			get
			{
				return this.m_MaxEnginePower;
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x060021D9 RID: 8665 RVA: 0x001ED9B6 File Offset: 0x001EBBB6
		// (set) Token: 0x060021DA RID: 8666 RVA: 0x001ED9BE File Offset: 0x001EBBBE
		public float RollAngle { get; private set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060021DB RID: 8667 RVA: 0x001ED9C7 File Offset: 0x001EBBC7
		// (set) Token: 0x060021DC RID: 8668 RVA: 0x001ED9CF File Offset: 0x001EBBCF
		public float PitchAngle { get; private set; }

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060021DD RID: 8669 RVA: 0x001ED9D8 File Offset: 0x001EBBD8
		// (set) Token: 0x060021DE RID: 8670 RVA: 0x001ED9E0 File Offset: 0x001EBBE0
		public float RollInput { get; private set; }

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x060021DF RID: 8671 RVA: 0x001ED9E9 File Offset: 0x001EBBE9
		// (set) Token: 0x060021E0 RID: 8672 RVA: 0x001ED9F1 File Offset: 0x001EBBF1
		public float PitchInput { get; private set; }

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x060021E1 RID: 8673 RVA: 0x001ED9FA File Offset: 0x001EBBFA
		// (set) Token: 0x060021E2 RID: 8674 RVA: 0x001EDA02 File Offset: 0x001EBC02
		public float YawInput { get; private set; }

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x060021E3 RID: 8675 RVA: 0x001EDA0B File Offset: 0x001EBC0B
		// (set) Token: 0x060021E4 RID: 8676 RVA: 0x001EDA13 File Offset: 0x001EBC13
		public float ThrottleInput { get; private set; }

		// Token: 0x060021E5 RID: 8677 RVA: 0x001EDA1C File Offset: 0x001EBC1C
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

		// Token: 0x060021E6 RID: 8678 RVA: 0x001EDA9C File Offset: 0x001EBC9C
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

		// Token: 0x060021E7 RID: 8679 RVA: 0x001EDB0C File Offset: 0x001EBD0C
		private void ClampInputs()
		{
			this.RollInput = Mathf.Clamp(this.RollInput, -1f, 1f);
			this.PitchInput = Mathf.Clamp(this.PitchInput, -1f, 1f);
			this.YawInput = Mathf.Clamp(this.YawInput, -1f, 1f);
			this.ThrottleInput = Mathf.Clamp(this.ThrottleInput, -1f, 1f);
		}

		// Token: 0x060021E8 RID: 8680 RVA: 0x001EDB88 File Offset: 0x001EBD88
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

		// Token: 0x060021E9 RID: 8681 RVA: 0x001EDC18 File Offset: 0x001EBE18
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

		// Token: 0x060021EA RID: 8682 RVA: 0x001EDCA0 File Offset: 0x001EBEA0
		private void CalculateForwardSpeed()
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.m_Rigidbody.velocity);
			this.ForwardSpeed = Mathf.Max(0f, vector.z);
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x001EDCDC File Offset: 0x001EBEDC
		private void ControlThrottle()
		{
			if (this.m_Immobilized)
			{
				this.ThrottleInput = -0.5f;
			}
			this.Throttle = Mathf.Clamp01(this.Throttle + this.ThrottleInput * Time.deltaTime * this.m_ThrottleChangeSpeed);
			this.EnginePower = this.Throttle * this.m_MaxEnginePower;
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x001EDD34 File Offset: 0x001EBF34
		private void CalculateDrag()
		{
			float num = this.m_Rigidbody.velocity.magnitude * this.m_DragIncreaseFactor;
			this.m_Rigidbody.drag = (this.AirBrakes ? ((this.m_OriginalDrag + num) * this.m_AirBrakesEffect) : (this.m_OriginalDrag + num));
			this.m_Rigidbody.angularDrag = this.m_OriginalAngularDrag * this.ForwardSpeed;
		}

		// Token: 0x060021ED RID: 8685 RVA: 0x001EDDA0 File Offset: 0x001EBFA0
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

		// Token: 0x060021EE RID: 8686 RVA: 0x001EDE98 File Offset: 0x001EC098
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

		// Token: 0x060021EF RID: 8687 RVA: 0x001EDF3C File Offset: 0x001EC13C
		private void CalculateTorque()
		{
			Vector3 a = Vector3.zero;
			a += this.PitchInput * this.m_PitchEffect * base.transform.right;
			a += this.YawInput * this.m_YawEffect * base.transform.up;
			a += -this.RollInput * this.m_RollEffect * base.transform.forward;
			a += this.m_BankedTurnAmount * this.m_BankedTurnEffect * base.transform.up;
			this.m_Rigidbody.AddTorque(a * this.ForwardSpeed * this.m_AeroFactor);
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x001EE004 File Offset: 0x001EC204
		private void CalculateAltitude()
		{
			Ray ray = new Ray(base.transform.position - Vector3.up * 10f, -Vector3.up);
			RaycastHit raycastHit;
			this.Altitude = (Physics.Raycast(ray, out raycastHit) ? (raycastHit.distance + 10f) : base.transform.position.y);
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x001EE070 File Offset: 0x001EC270
		public void Immobilize()
		{
			this.m_Immobilized = true;
		}

		// Token: 0x060021F2 RID: 8690 RVA: 0x001EE079 File Offset: 0x001EC279
		public void Reset()
		{
			this.m_Immobilized = false;
		}

		// Token: 0x04004A0B RID: 18955
		[SerializeField]
		private float m_MaxEnginePower = 40f;

		// Token: 0x04004A0C RID: 18956
		[SerializeField]
		private float m_Lift = 0.002f;

		// Token: 0x04004A0D RID: 18957
		[SerializeField]
		private float m_ZeroLiftSpeed = 300f;

		// Token: 0x04004A0E RID: 18958
		[SerializeField]
		private float m_RollEffect = 1f;

		// Token: 0x04004A0F RID: 18959
		[SerializeField]
		private float m_PitchEffect = 1f;

		// Token: 0x04004A10 RID: 18960
		[SerializeField]
		private float m_YawEffect = 0.2f;

		// Token: 0x04004A11 RID: 18961
		[SerializeField]
		private float m_BankedTurnEffect = 0.5f;

		// Token: 0x04004A12 RID: 18962
		[SerializeField]
		private float m_AerodynamicEffect = 0.02f;

		// Token: 0x04004A13 RID: 18963
		[SerializeField]
		private float m_AutoTurnPitch = 0.5f;

		// Token: 0x04004A14 RID: 18964
		[SerializeField]
		private float m_AutoRollLevel = 0.2f;

		// Token: 0x04004A15 RID: 18965
		[SerializeField]
		private float m_AutoPitchLevel = 0.2f;

		// Token: 0x04004A16 RID: 18966
		[SerializeField]
		private float m_AirBrakesEffect = 3f;

		// Token: 0x04004A17 RID: 18967
		[SerializeField]
		private float m_ThrottleChangeSpeed = 0.3f;

		// Token: 0x04004A18 RID: 18968
		[SerializeField]
		private float m_DragIncreaseFactor = 0.001f;

		// Token: 0x04004A24 RID: 18980
		private float m_OriginalDrag;

		// Token: 0x04004A25 RID: 18981
		private float m_OriginalAngularDrag;

		// Token: 0x04004A26 RID: 18982
		private float m_AeroFactor;

		// Token: 0x04004A27 RID: 18983
		private bool m_Immobilized;

		// Token: 0x04004A28 RID: 18984
		private float m_BankedTurnAmount;

		// Token: 0x04004A29 RID: 18985
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A2A RID: 18986
		private WheelCollider[] m_WheelColliders;
	}
}
