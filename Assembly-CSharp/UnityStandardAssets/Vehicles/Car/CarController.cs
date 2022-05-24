using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000533 RID: 1331
	public class CarController : MonoBehaviour
	{
		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x060021D8 RID: 8664 RVA: 0x001F3E73 File Offset: 0x001F2073
		// (set) Token: 0x060021D9 RID: 8665 RVA: 0x001F3E7B File Offset: 0x001F207B
		public bool Skidding { get; private set; }

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x060021DA RID: 8666 RVA: 0x001F3E84 File Offset: 0x001F2084
		// (set) Token: 0x060021DB RID: 8667 RVA: 0x001F3E8C File Offset: 0x001F208C
		public float BrakeInput { get; private set; }

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x060021DC RID: 8668 RVA: 0x001F3E95 File Offset: 0x001F2095
		public float CurrentSteerAngle
		{
			get
			{
				return this.m_SteerAngle;
			}
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x060021DD RID: 8669 RVA: 0x001F3EA0 File Offset: 0x001F20A0
		public float CurrentSpeed
		{
			get
			{
				return this.m_Rigidbody.velocity.magnitude * 2.2369363f;
			}
		}

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060021DE RID: 8670 RVA: 0x001F3EC6 File Offset: 0x001F20C6
		public float MaxSpeed
		{
			get
			{
				return this.m_Topspeed;
			}
		}

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060021DF RID: 8671 RVA: 0x001F3ECE File Offset: 0x001F20CE
		// (set) Token: 0x060021E0 RID: 8672 RVA: 0x001F3ED6 File Offset: 0x001F20D6
		public float Revs { get; private set; }

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060021E1 RID: 8673 RVA: 0x001F3EDF File Offset: 0x001F20DF
		// (set) Token: 0x060021E2 RID: 8674 RVA: 0x001F3EE7 File Offset: 0x001F20E7
		public float AccelInput { get; private set; }

		// Token: 0x060021E3 RID: 8675 RVA: 0x001F3EF0 File Offset: 0x001F20F0
		private void Start()
		{
			this.m_WheelMeshLocalRotations = new Quaternion[4];
			for (int i = 0; i < 4; i++)
			{
				this.m_WheelMeshLocalRotations[i] = this.m_WheelMeshes[i].transform.localRotation;
			}
			this.m_WheelColliders[0].attachedRigidbody.centerOfMass = this.m_CentreOfMassOffset;
			this.m_MaxHandbrakeTorque = float.MaxValue;
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
			this.m_CurrentTorque = this.m_FullTorqueOverAllWheels - this.m_TractionControl * this.m_FullTorqueOverAllWheels;
		}

		// Token: 0x060021E4 RID: 8676 RVA: 0x001F3F7C File Offset: 0x001F217C
		private void GearChanging()
		{
			float num = Mathf.Abs(this.CurrentSpeed / this.MaxSpeed);
			float num2 = 1f / (float)CarController.NoOfGears * (float)(this.m_GearNum + 1);
			float num3 = 1f / (float)CarController.NoOfGears * (float)this.m_GearNum;
			if (this.m_GearNum > 0 && num < num3)
			{
				this.m_GearNum--;
			}
			if (num > num2 && this.m_GearNum < CarController.NoOfGears - 1)
			{
				this.m_GearNum++;
			}
		}

		// Token: 0x060021E5 RID: 8677 RVA: 0x001F4004 File Offset: 0x001F2204
		private static float CurveFactor(float factor)
		{
			return 1f - (1f - factor) * (1f - factor);
		}

		// Token: 0x060021E6 RID: 8678 RVA: 0x001F401B File Offset: 0x001F221B
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x060021E7 RID: 8679 RVA: 0x001F402C File Offset: 0x001F222C
		private void CalculateGearFactor()
		{
			float num = 1f / (float)CarController.NoOfGears;
			float b = Mathf.InverseLerp(num * (float)this.m_GearNum, num * (float)(this.m_GearNum + 1), Mathf.Abs(this.CurrentSpeed / this.MaxSpeed));
			this.m_GearFactor = Mathf.Lerp(this.m_GearFactor, b, Time.deltaTime * 5f);
		}

		// Token: 0x060021E8 RID: 8680 RVA: 0x001F4090 File Offset: 0x001F2290
		private void CalculateRevs()
		{
			this.CalculateGearFactor();
			float num = (float)this.m_GearNum / (float)CarController.NoOfGears;
			float from = CarController.ULerp(0f, this.m_RevRangeBoundary, CarController.CurveFactor(num));
			float to = CarController.ULerp(this.m_RevRangeBoundary, 1f, num);
			this.Revs = CarController.ULerp(from, to, this.m_GearFactor);
		}

		// Token: 0x060021E9 RID: 8681 RVA: 0x001F40F0 File Offset: 0x001F22F0
		public void Move(float steering, float accel, float footbrake, float handbrake)
		{
			for (int i = 0; i < 4; i++)
			{
				Vector3 position;
				Quaternion rotation;
				this.m_WheelColliders[i].GetWorldPose(out position, out rotation);
				this.m_WheelMeshes[i].transform.position = position;
				this.m_WheelMeshes[i].transform.rotation = rotation;
			}
			steering = Mathf.Clamp(steering, -1f, 1f);
			accel = (this.AccelInput = Mathf.Clamp(accel, 0f, 1f));
			footbrake = (this.BrakeInput = -1f * Mathf.Clamp(footbrake, -1f, 0f));
			handbrake = Mathf.Clamp(handbrake, 0f, 1f);
			this.m_SteerAngle = steering * this.m_MaximumSteerAngle;
			this.m_WheelColliders[0].steerAngle = this.m_SteerAngle;
			this.m_WheelColliders[1].steerAngle = this.m_SteerAngle;
			this.SteerHelper();
			this.ApplyDrive(accel, footbrake);
			this.CapSpeed();
			if (handbrake > 0f)
			{
				float brakeTorque = handbrake * this.m_MaxHandbrakeTorque;
				this.m_WheelColliders[2].brakeTorque = brakeTorque;
				this.m_WheelColliders[3].brakeTorque = brakeTorque;
			}
			this.CalculateRevs();
			this.GearChanging();
			this.AddDownForce();
			this.CheckForWheelSpin();
			this.TractionControl();
		}

		// Token: 0x060021EA RID: 8682 RVA: 0x001F4234 File Offset: 0x001F2434
		private void CapSpeed()
		{
			float num = this.m_Rigidbody.velocity.magnitude;
			SpeedType speedType = this.m_SpeedType;
			if (speedType != SpeedType.MPH)
			{
				if (speedType != SpeedType.KPH)
				{
					return;
				}
				num *= 3.6f;
				if (num > this.m_Topspeed)
				{
					this.m_Rigidbody.velocity = this.m_Topspeed / 3.6f * this.m_Rigidbody.velocity.normalized;
				}
			}
			else
			{
				num *= 2.2369363f;
				if (num > this.m_Topspeed)
				{
					this.m_Rigidbody.velocity = this.m_Topspeed / 2.2369363f * this.m_Rigidbody.velocity.normalized;
					return;
				}
			}
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x001F42E8 File Offset: 0x001F24E8
		private void ApplyDrive(float accel, float footbrake)
		{
			switch (this.m_CarDriveType)
			{
			case CarDriveType.FrontWheelDrive:
			{
				float motorTorque = accel * (this.m_CurrentTorque / 2f);
				this.m_WheelColliders[0].motorTorque = (this.m_WheelColliders[1].motorTorque = motorTorque);
				break;
			}
			case CarDriveType.RearWheelDrive:
			{
				float motorTorque = accel * (this.m_CurrentTorque / 2f);
				this.m_WheelColliders[2].motorTorque = (this.m_WheelColliders[3].motorTorque = motorTorque);
				break;
			}
			case CarDriveType.FourWheelDrive:
			{
				float motorTorque = accel * (this.m_CurrentTorque / 4f);
				for (int i = 0; i < 4; i++)
				{
					this.m_WheelColliders[i].motorTorque = motorTorque;
				}
				break;
			}
			}
			for (int j = 0; j < 4; j++)
			{
				if (this.CurrentSpeed > 5f && Vector3.Angle(base.transform.forward, this.m_Rigidbody.velocity) < 50f)
				{
					this.m_WheelColliders[j].brakeTorque = this.m_BrakeTorque * footbrake;
				}
				else if (footbrake > 0f)
				{
					this.m_WheelColliders[j].brakeTorque = 0f;
					this.m_WheelColliders[j].motorTorque = -this.m_ReverseTorque * footbrake;
				}
			}
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x001F4428 File Offset: 0x001F2628
		private void SteerHelper()
		{
			for (int i = 0; i < 4; i++)
			{
				WheelHit wheelHit;
				this.m_WheelColliders[i].GetGroundHit(out wheelHit);
				if (wheelHit.normal == Vector3.zero)
				{
					return;
				}
			}
			if (Mathf.Abs(this.m_OldRotation - base.transform.eulerAngles.y) < 10f)
			{
				Quaternion rotation = Quaternion.AngleAxis((base.transform.eulerAngles.y - this.m_OldRotation) * this.m_SteerHelper, Vector3.up);
				this.m_Rigidbody.velocity = rotation * this.m_Rigidbody.velocity;
			}
			this.m_OldRotation = base.transform.eulerAngles.y;
		}

		// Token: 0x060021ED RID: 8685 RVA: 0x001F44E4 File Offset: 0x001F26E4
		private void AddDownForce()
		{
			this.m_WheelColliders[0].attachedRigidbody.AddForce(-base.transform.up * this.m_Downforce * this.m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x001F4540 File Offset: 0x001F2740
		private void CheckForWheelSpin()
		{
			for (int i = 0; i < 4; i++)
			{
				WheelHit wheelHit;
				this.m_WheelColliders[i].GetGroundHit(out wheelHit);
				if (Mathf.Abs(wheelHit.forwardSlip) >= this.m_SlipLimit || Mathf.Abs(wheelHit.sidewaysSlip) >= this.m_SlipLimit)
				{
					this.m_WheelEffects[i].EmitTyreSmoke();
					if (!this.AnySkidSoundPlaying())
					{
						this.m_WheelEffects[i].PlayAudio();
					}
				}
				else
				{
					if (this.m_WheelEffects[i].PlayingAudio)
					{
						this.m_WheelEffects[i].StopAudio();
					}
					this.m_WheelEffects[i].EndSkidTrail();
				}
			}
		}

		// Token: 0x060021EF RID: 8687 RVA: 0x001F45E4 File Offset: 0x001F27E4
		private void TractionControl()
		{
			switch (this.m_CarDriveType)
			{
			case CarDriveType.FrontWheelDrive:
			{
				WheelHit wheelHit;
				this.m_WheelColliders[0].GetGroundHit(out wheelHit);
				this.AdjustTorque(wheelHit.forwardSlip);
				this.m_WheelColliders[1].GetGroundHit(out wheelHit);
				this.AdjustTorque(wheelHit.forwardSlip);
				return;
			}
			case CarDriveType.RearWheelDrive:
			{
				WheelHit wheelHit;
				this.m_WheelColliders[2].GetGroundHit(out wheelHit);
				this.AdjustTorque(wheelHit.forwardSlip);
				this.m_WheelColliders[3].GetGroundHit(out wheelHit);
				this.AdjustTorque(wheelHit.forwardSlip);
				return;
			}
			case CarDriveType.FourWheelDrive:
				for (int i = 0; i < 4; i++)
				{
					WheelHit wheelHit;
					this.m_WheelColliders[i].GetGroundHit(out wheelHit);
					this.AdjustTorque(wheelHit.forwardSlip);
				}
				return;
			default:
				return;
			}
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x001F46AC File Offset: 0x001F28AC
		private void AdjustTorque(float forwardSlip)
		{
			if (forwardSlip >= this.m_SlipLimit && this.m_CurrentTorque >= 0f)
			{
				this.m_CurrentTorque -= 10f * this.m_TractionControl;
				return;
			}
			this.m_CurrentTorque += 10f * this.m_TractionControl;
			if (this.m_CurrentTorque > this.m_FullTorqueOverAllWheels)
			{
				this.m_CurrentTorque = this.m_FullTorqueOverAllWheels;
			}
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x001F471C File Offset: 0x001F291C
		private bool AnySkidSoundPlaying()
		{
			for (int i = 0; i < 4; i++)
			{
				if (this.m_WheelEffects[i].PlayingAudio)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04004AA9 RID: 19113
		[SerializeField]
		private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;

		// Token: 0x04004AAA RID: 19114
		[SerializeField]
		private WheelCollider[] m_WheelColliders = new WheelCollider[4];

		// Token: 0x04004AAB RID: 19115
		[SerializeField]
		private GameObject[] m_WheelMeshes = new GameObject[4];

		// Token: 0x04004AAC RID: 19116
		[SerializeField]
		private WheelEffects[] m_WheelEffects = new WheelEffects[4];

		// Token: 0x04004AAD RID: 19117
		[SerializeField]
		private Vector3 m_CentreOfMassOffset;

		// Token: 0x04004AAE RID: 19118
		[SerializeField]
		private float m_MaximumSteerAngle;

		// Token: 0x04004AAF RID: 19119
		[Range(0f, 1f)]
		[SerializeField]
		private float m_SteerHelper;

		// Token: 0x04004AB0 RID: 19120
		[Range(0f, 1f)]
		[SerializeField]
		private float m_TractionControl;

		// Token: 0x04004AB1 RID: 19121
		[SerializeField]
		private float m_FullTorqueOverAllWheels;

		// Token: 0x04004AB2 RID: 19122
		[SerializeField]
		private float m_ReverseTorque;

		// Token: 0x04004AB3 RID: 19123
		[SerializeField]
		private float m_MaxHandbrakeTorque;

		// Token: 0x04004AB4 RID: 19124
		[SerializeField]
		private float m_Downforce = 100f;

		// Token: 0x04004AB5 RID: 19125
		[SerializeField]
		private SpeedType m_SpeedType;

		// Token: 0x04004AB6 RID: 19126
		[SerializeField]
		private float m_Topspeed = 200f;

		// Token: 0x04004AB7 RID: 19127
		[SerializeField]
		private static int NoOfGears = 5;

		// Token: 0x04004AB8 RID: 19128
		[SerializeField]
		private float m_RevRangeBoundary = 1f;

		// Token: 0x04004AB9 RID: 19129
		[SerializeField]
		private float m_SlipLimit;

		// Token: 0x04004ABA RID: 19130
		[SerializeField]
		private float m_BrakeTorque;

		// Token: 0x04004ABB RID: 19131
		private Quaternion[] m_WheelMeshLocalRotations;

		// Token: 0x04004ABC RID: 19132
		private Vector3 m_Prevpos;

		// Token: 0x04004ABD RID: 19133
		private Vector3 m_Pos;

		// Token: 0x04004ABE RID: 19134
		private float m_SteerAngle;

		// Token: 0x04004ABF RID: 19135
		private int m_GearNum;

		// Token: 0x04004AC0 RID: 19136
		private float m_GearFactor;

		// Token: 0x04004AC1 RID: 19137
		private float m_OldRotation;

		// Token: 0x04004AC2 RID: 19138
		private float m_CurrentTorque;

		// Token: 0x04004AC3 RID: 19139
		private Rigidbody m_Rigidbody;

		// Token: 0x04004AC4 RID: 19140
		private const float k_ReversingThreshold = 0.01f;
	}
}
