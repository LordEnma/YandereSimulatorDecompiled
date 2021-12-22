using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052B RID: 1323
	[RequireComponent(typeof(Rigidbody))]
	public class AeroplaneController : MonoBehaviour
	{
		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x0600219F RID: 8607 RVA: 0x001E94D1 File Offset: 0x001E76D1
		// (set) Token: 0x060021A0 RID: 8608 RVA: 0x001E94D9 File Offset: 0x001E76D9
		public float Altitude { get; private set; }

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060021A1 RID: 8609 RVA: 0x001E94E2 File Offset: 0x001E76E2
		// (set) Token: 0x060021A2 RID: 8610 RVA: 0x001E94EA File Offset: 0x001E76EA
		public float Throttle { get; private set; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060021A3 RID: 8611 RVA: 0x001E94F3 File Offset: 0x001E76F3
		// (set) Token: 0x060021A4 RID: 8612 RVA: 0x001E94FB File Offset: 0x001E76FB
		public bool AirBrakes { get; private set; }

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060021A5 RID: 8613 RVA: 0x001E9504 File Offset: 0x001E7704
		// (set) Token: 0x060021A6 RID: 8614 RVA: 0x001E950C File Offset: 0x001E770C
		public float ForwardSpeed { get; private set; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x060021A7 RID: 8615 RVA: 0x001E9515 File Offset: 0x001E7715
		// (set) Token: 0x060021A8 RID: 8616 RVA: 0x001E951D File Offset: 0x001E771D
		public float EnginePower { get; private set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x060021A9 RID: 8617 RVA: 0x001E9526 File Offset: 0x001E7726
		public float MaxEnginePower
		{
			get
			{
				return this.m_MaxEnginePower;
			}
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x060021AA RID: 8618 RVA: 0x001E952E File Offset: 0x001E772E
		// (set) Token: 0x060021AB RID: 8619 RVA: 0x001E9536 File Offset: 0x001E7736
		public float RollAngle { get; private set; }

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x060021AC RID: 8620 RVA: 0x001E953F File Offset: 0x001E773F
		// (set) Token: 0x060021AD RID: 8621 RVA: 0x001E9547 File Offset: 0x001E7747
		public float PitchAngle { get; private set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x060021AE RID: 8622 RVA: 0x001E9550 File Offset: 0x001E7750
		// (set) Token: 0x060021AF RID: 8623 RVA: 0x001E9558 File Offset: 0x001E7758
		public float RollInput { get; private set; }

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x060021B0 RID: 8624 RVA: 0x001E9561 File Offset: 0x001E7761
		// (set) Token: 0x060021B1 RID: 8625 RVA: 0x001E9569 File Offset: 0x001E7769
		public float PitchInput { get; private set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060021B2 RID: 8626 RVA: 0x001E9572 File Offset: 0x001E7772
		// (set) Token: 0x060021B3 RID: 8627 RVA: 0x001E957A File Offset: 0x001E777A
		public float YawInput { get; private set; }

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060021B4 RID: 8628 RVA: 0x001E9583 File Offset: 0x001E7783
		// (set) Token: 0x060021B5 RID: 8629 RVA: 0x001E958B File Offset: 0x001E778B
		public float ThrottleInput { get; private set; }

		// Token: 0x060021B6 RID: 8630 RVA: 0x001E9594 File Offset: 0x001E7794
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

		// Token: 0x060021B7 RID: 8631 RVA: 0x001E9614 File Offset: 0x001E7814
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

		// Token: 0x060021B8 RID: 8632 RVA: 0x001E9684 File Offset: 0x001E7884
		private void ClampInputs()
		{
			this.RollInput = Mathf.Clamp(this.RollInput, -1f, 1f);
			this.PitchInput = Mathf.Clamp(this.PitchInput, -1f, 1f);
			this.YawInput = Mathf.Clamp(this.YawInput, -1f, 1f);
			this.ThrottleInput = Mathf.Clamp(this.ThrottleInput, -1f, 1f);
		}

		// Token: 0x060021B9 RID: 8633 RVA: 0x001E9700 File Offset: 0x001E7900
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

		// Token: 0x060021BA RID: 8634 RVA: 0x001E9790 File Offset: 0x001E7990
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

		// Token: 0x060021BB RID: 8635 RVA: 0x001E9818 File Offset: 0x001E7A18
		private void CalculateForwardSpeed()
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.m_Rigidbody.velocity);
			this.ForwardSpeed = Mathf.Max(0f, vector.z);
		}

		// Token: 0x060021BC RID: 8636 RVA: 0x001E9854 File Offset: 0x001E7A54
		private void ControlThrottle()
		{
			if (this.m_Immobilized)
			{
				this.ThrottleInput = -0.5f;
			}
			this.Throttle = Mathf.Clamp01(this.Throttle + this.ThrottleInput * Time.deltaTime * this.m_ThrottleChangeSpeed);
			this.EnginePower = this.Throttle * this.m_MaxEnginePower;
		}

		// Token: 0x060021BD RID: 8637 RVA: 0x001E98AC File Offset: 0x001E7AAC
		private void CalculateDrag()
		{
			float num = this.m_Rigidbody.velocity.magnitude * this.m_DragIncreaseFactor;
			this.m_Rigidbody.drag = (this.AirBrakes ? ((this.m_OriginalDrag + num) * this.m_AirBrakesEffect) : (this.m_OriginalDrag + num));
			this.m_Rigidbody.angularDrag = this.m_OriginalAngularDrag * this.ForwardSpeed;
		}

		// Token: 0x060021BE RID: 8638 RVA: 0x001E9918 File Offset: 0x001E7B18
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

		// Token: 0x060021BF RID: 8639 RVA: 0x001E9A10 File Offset: 0x001E7C10
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

		// Token: 0x060021C0 RID: 8640 RVA: 0x001E9AB4 File Offset: 0x001E7CB4
		private void CalculateTorque()
		{
			Vector3 a = Vector3.zero;
			a += this.PitchInput * this.m_PitchEffect * base.transform.right;
			a += this.YawInput * this.m_YawEffect * base.transform.up;
			a += -this.RollInput * this.m_RollEffect * base.transform.forward;
			a += this.m_BankedTurnAmount * this.m_BankedTurnEffect * base.transform.up;
			this.m_Rigidbody.AddTorque(a * this.ForwardSpeed * this.m_AeroFactor);
		}

		// Token: 0x060021C1 RID: 8641 RVA: 0x001E9B7C File Offset: 0x001E7D7C
		private void CalculateAltitude()
		{
			Ray ray = new Ray(base.transform.position - Vector3.up * 10f, -Vector3.up);
			RaycastHit raycastHit;
			this.Altitude = (Physics.Raycast(ray, out raycastHit) ? (raycastHit.distance + 10f) : base.transform.position.y);
		}

		// Token: 0x060021C2 RID: 8642 RVA: 0x001E9BE8 File Offset: 0x001E7DE8
		public void Immobilize()
		{
			this.m_Immobilized = true;
		}

		// Token: 0x060021C3 RID: 8643 RVA: 0x001E9BF1 File Offset: 0x001E7DF1
		public void Reset()
		{
			this.m_Immobilized = false;
		}

		// Token: 0x0400499D RID: 18845
		[SerializeField]
		private float m_MaxEnginePower = 40f;

		// Token: 0x0400499E RID: 18846
		[SerializeField]
		private float m_Lift = 0.002f;

		// Token: 0x0400499F RID: 18847
		[SerializeField]
		private float m_ZeroLiftSpeed = 300f;

		// Token: 0x040049A0 RID: 18848
		[SerializeField]
		private float m_RollEffect = 1f;

		// Token: 0x040049A1 RID: 18849
		[SerializeField]
		private float m_PitchEffect = 1f;

		// Token: 0x040049A2 RID: 18850
		[SerializeField]
		private float m_YawEffect = 0.2f;

		// Token: 0x040049A3 RID: 18851
		[SerializeField]
		private float m_BankedTurnEffect = 0.5f;

		// Token: 0x040049A4 RID: 18852
		[SerializeField]
		private float m_AerodynamicEffect = 0.02f;

		// Token: 0x040049A5 RID: 18853
		[SerializeField]
		private float m_AutoTurnPitch = 0.5f;

		// Token: 0x040049A6 RID: 18854
		[SerializeField]
		private float m_AutoRollLevel = 0.2f;

		// Token: 0x040049A7 RID: 18855
		[SerializeField]
		private float m_AutoPitchLevel = 0.2f;

		// Token: 0x040049A8 RID: 18856
		[SerializeField]
		private float m_AirBrakesEffect = 3f;

		// Token: 0x040049A9 RID: 18857
		[SerializeField]
		private float m_ThrottleChangeSpeed = 0.3f;

		// Token: 0x040049AA RID: 18858
		[SerializeField]
		private float m_DragIncreaseFactor = 0.001f;

		// Token: 0x040049B6 RID: 18870
		private float m_OriginalDrag;

		// Token: 0x040049B7 RID: 18871
		private float m_OriginalAngularDrag;

		// Token: 0x040049B8 RID: 18872
		private float m_AeroFactor;

		// Token: 0x040049B9 RID: 18873
		private bool m_Immobilized;

		// Token: 0x040049BA RID: 18874
		private float m_BankedTurnAmount;

		// Token: 0x040049BB RID: 18875
		private Rigidbody m_Rigidbody;

		// Token: 0x040049BC RID: 18876
		private WheelCollider[] m_WheelColliders;
	}
}
