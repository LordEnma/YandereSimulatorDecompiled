using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053D RID: 1341
	[RequireComponent(typeof(Rigidbody))]
	public class AeroplaneController : MonoBehaviour
	{
		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x0600221A RID: 8730 RVA: 0x001F51FD File Offset: 0x001F33FD
		// (set) Token: 0x0600221B RID: 8731 RVA: 0x001F5205 File Offset: 0x001F3405
		public float Altitude { get; private set; }

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x0600221C RID: 8732 RVA: 0x001F520E File Offset: 0x001F340E
		// (set) Token: 0x0600221D RID: 8733 RVA: 0x001F5216 File Offset: 0x001F3416
		public float Throttle { get; private set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x0600221E RID: 8734 RVA: 0x001F521F File Offset: 0x001F341F
		// (set) Token: 0x0600221F RID: 8735 RVA: 0x001F5227 File Offset: 0x001F3427
		public bool AirBrakes { get; private set; }

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06002220 RID: 8736 RVA: 0x001F5230 File Offset: 0x001F3430
		// (set) Token: 0x06002221 RID: 8737 RVA: 0x001F5238 File Offset: 0x001F3438
		public float ForwardSpeed { get; private set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06002222 RID: 8738 RVA: 0x001F5241 File Offset: 0x001F3441
		// (set) Token: 0x06002223 RID: 8739 RVA: 0x001F5249 File Offset: 0x001F3449
		public float EnginePower { get; private set; }

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06002224 RID: 8740 RVA: 0x001F5252 File Offset: 0x001F3452
		public float MaxEnginePower
		{
			get
			{
				return this.m_MaxEnginePower;
			}
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06002225 RID: 8741 RVA: 0x001F525A File Offset: 0x001F345A
		// (set) Token: 0x06002226 RID: 8742 RVA: 0x001F5262 File Offset: 0x001F3462
		public float RollAngle { get; private set; }

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06002227 RID: 8743 RVA: 0x001F526B File Offset: 0x001F346B
		// (set) Token: 0x06002228 RID: 8744 RVA: 0x001F5273 File Offset: 0x001F3473
		public float PitchAngle { get; private set; }

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06002229 RID: 8745 RVA: 0x001F527C File Offset: 0x001F347C
		// (set) Token: 0x0600222A RID: 8746 RVA: 0x001F5284 File Offset: 0x001F3484
		public float RollInput { get; private set; }

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x0600222B RID: 8747 RVA: 0x001F528D File Offset: 0x001F348D
		// (set) Token: 0x0600222C RID: 8748 RVA: 0x001F5295 File Offset: 0x001F3495
		public float PitchInput { get; private set; }

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x0600222D RID: 8749 RVA: 0x001F529E File Offset: 0x001F349E
		// (set) Token: 0x0600222E RID: 8750 RVA: 0x001F52A6 File Offset: 0x001F34A6
		public float YawInput { get; private set; }

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x0600222F RID: 8751 RVA: 0x001F52AF File Offset: 0x001F34AF
		// (set) Token: 0x06002230 RID: 8752 RVA: 0x001F52B7 File Offset: 0x001F34B7
		public float ThrottleInput { get; private set; }

		// Token: 0x06002231 RID: 8753 RVA: 0x001F52C0 File Offset: 0x001F34C0
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

		// Token: 0x06002232 RID: 8754 RVA: 0x001F5340 File Offset: 0x001F3540
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

		// Token: 0x06002233 RID: 8755 RVA: 0x001F53B0 File Offset: 0x001F35B0
		private void ClampInputs()
		{
			this.RollInput = Mathf.Clamp(this.RollInput, -1f, 1f);
			this.PitchInput = Mathf.Clamp(this.PitchInput, -1f, 1f);
			this.YawInput = Mathf.Clamp(this.YawInput, -1f, 1f);
			this.ThrottleInput = Mathf.Clamp(this.ThrottleInput, -1f, 1f);
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x001F542C File Offset: 0x001F362C
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

		// Token: 0x06002235 RID: 8757 RVA: 0x001F54BC File Offset: 0x001F36BC
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

		// Token: 0x06002236 RID: 8758 RVA: 0x001F5544 File Offset: 0x001F3744
		private void CalculateForwardSpeed()
		{
			Vector3 vector = base.transform.InverseTransformDirection(this.m_Rigidbody.velocity);
			this.ForwardSpeed = Mathf.Max(0f, vector.z);
		}

		// Token: 0x06002237 RID: 8759 RVA: 0x001F5580 File Offset: 0x001F3780
		private void ControlThrottle()
		{
			if (this.m_Immobilized)
			{
				this.ThrottleInput = -0.5f;
			}
			this.Throttle = Mathf.Clamp01(this.Throttle + this.ThrottleInput * Time.deltaTime * this.m_ThrottleChangeSpeed);
			this.EnginePower = this.Throttle * this.m_MaxEnginePower;
		}

		// Token: 0x06002238 RID: 8760 RVA: 0x001F55D8 File Offset: 0x001F37D8
		private void CalculateDrag()
		{
			float num = this.m_Rigidbody.velocity.magnitude * this.m_DragIncreaseFactor;
			this.m_Rigidbody.drag = (this.AirBrakes ? ((this.m_OriginalDrag + num) * this.m_AirBrakesEffect) : (this.m_OriginalDrag + num));
			this.m_Rigidbody.angularDrag = this.m_OriginalAngularDrag * this.ForwardSpeed;
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x001F5644 File Offset: 0x001F3844
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

		// Token: 0x0600223A RID: 8762 RVA: 0x001F573C File Offset: 0x001F393C
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

		// Token: 0x0600223B RID: 8763 RVA: 0x001F57E0 File Offset: 0x001F39E0
		private void CalculateTorque()
		{
			Vector3 a = Vector3.zero;
			a += this.PitchInput * this.m_PitchEffect * base.transform.right;
			a += this.YawInput * this.m_YawEffect * base.transform.up;
			a += -this.RollInput * this.m_RollEffect * base.transform.forward;
			a += this.m_BankedTurnAmount * this.m_BankedTurnEffect * base.transform.up;
			this.m_Rigidbody.AddTorque(a * this.ForwardSpeed * this.m_AeroFactor);
		}

		// Token: 0x0600223C RID: 8764 RVA: 0x001F58A8 File Offset: 0x001F3AA8
		private void CalculateAltitude()
		{
			Ray ray = new Ray(base.transform.position - Vector3.up * 10f, -Vector3.up);
			RaycastHit raycastHit;
			this.Altitude = (Physics.Raycast(ray, out raycastHit) ? (raycastHit.distance + 10f) : base.transform.position.y);
		}

		// Token: 0x0600223D RID: 8765 RVA: 0x001F5914 File Offset: 0x001F3B14
		public void Immobilize()
		{
			this.m_Immobilized = true;
		}

		// Token: 0x0600223E RID: 8766 RVA: 0x001F591D File Offset: 0x001F3B1D
		public void Reset()
		{
			this.m_Immobilized = false;
		}

		// Token: 0x04004AF8 RID: 19192
		[SerializeField]
		private float m_MaxEnginePower = 40f;

		// Token: 0x04004AF9 RID: 19193
		[SerializeField]
		private float m_Lift = 0.002f;

		// Token: 0x04004AFA RID: 19194
		[SerializeField]
		private float m_ZeroLiftSpeed = 300f;

		// Token: 0x04004AFB RID: 19195
		[SerializeField]
		private float m_RollEffect = 1f;

		// Token: 0x04004AFC RID: 19196
		[SerializeField]
		private float m_PitchEffect = 1f;

		// Token: 0x04004AFD RID: 19197
		[SerializeField]
		private float m_YawEffect = 0.2f;

		// Token: 0x04004AFE RID: 19198
		[SerializeField]
		private float m_BankedTurnEffect = 0.5f;

		// Token: 0x04004AFF RID: 19199
		[SerializeField]
		private float m_AerodynamicEffect = 0.02f;

		// Token: 0x04004B00 RID: 19200
		[SerializeField]
		private float m_AutoTurnPitch = 0.5f;

		// Token: 0x04004B01 RID: 19201
		[SerializeField]
		private float m_AutoRollLevel = 0.2f;

		// Token: 0x04004B02 RID: 19202
		[SerializeField]
		private float m_AutoPitchLevel = 0.2f;

		// Token: 0x04004B03 RID: 19203
		[SerializeField]
		private float m_AirBrakesEffect = 3f;

		// Token: 0x04004B04 RID: 19204
		[SerializeField]
		private float m_ThrottleChangeSpeed = 0.3f;

		// Token: 0x04004B05 RID: 19205
		[SerializeField]
		private float m_DragIncreaseFactor = 0.001f;

		// Token: 0x04004B11 RID: 19217
		private float m_OriginalDrag;

		// Token: 0x04004B12 RID: 19218
		private float m_OriginalAngularDrag;

		// Token: 0x04004B13 RID: 19219
		private float m_AeroFactor;

		// Token: 0x04004B14 RID: 19220
		private bool m_Immobilized;

		// Token: 0x04004B15 RID: 19221
		private float m_BankedTurnAmount;

		// Token: 0x04004B16 RID: 19222
		private Rigidbody m_Rigidbody;

		// Token: 0x04004B17 RID: 19223
		private WheelCollider[] m_WheelColliders;
	}
}
