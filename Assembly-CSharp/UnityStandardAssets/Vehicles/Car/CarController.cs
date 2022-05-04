using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000532 RID: 1330
	public class CarController : MonoBehaviour
	{
		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x060021CD RID: 8653 RVA: 0x001F22BB File Offset: 0x001F04BB
		// (set) Token: 0x060021CE RID: 8654 RVA: 0x001F22C3 File Offset: 0x001F04C3
		public bool Skidding { get; private set; }

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x060021CF RID: 8655 RVA: 0x001F22CC File Offset: 0x001F04CC
		// (set) Token: 0x060021D0 RID: 8656 RVA: 0x001F22D4 File Offset: 0x001F04D4
		public float BrakeInput { get; private set; }

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x060021D1 RID: 8657 RVA: 0x001F22DD File Offset: 0x001F04DD
		public float CurrentSteerAngle
		{
			get
			{
				return this.m_SteerAngle;
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x060021D2 RID: 8658 RVA: 0x001F22E8 File Offset: 0x001F04E8
		public float CurrentSpeed
		{
			get
			{
				return this.m_Rigidbody.velocity.magnitude * 2.2369363f;
			}
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x060021D3 RID: 8659 RVA: 0x001F230E File Offset: 0x001F050E
		public float MaxSpeed
		{
			get
			{
				return this.m_Topspeed;
			}
		}

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060021D4 RID: 8660 RVA: 0x001F2316 File Offset: 0x001F0516
		// (set) Token: 0x060021D5 RID: 8661 RVA: 0x001F231E File Offset: 0x001F051E
		public float Revs { get; private set; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060021D6 RID: 8662 RVA: 0x001F2327 File Offset: 0x001F0527
		// (set) Token: 0x060021D7 RID: 8663 RVA: 0x001F232F File Offset: 0x001F052F
		public float AccelInput { get; private set; }

		// Token: 0x060021D8 RID: 8664 RVA: 0x001F2338 File Offset: 0x001F0538
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

		// Token: 0x060021D9 RID: 8665 RVA: 0x001F23C4 File Offset: 0x001F05C4
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

		// Token: 0x060021DA RID: 8666 RVA: 0x001F244C File Offset: 0x001F064C
		private static float CurveFactor(float factor)
		{
			return 1f - (1f - factor) * (1f - factor);
		}

		// Token: 0x060021DB RID: 8667 RVA: 0x001F2463 File Offset: 0x001F0663
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x060021DC RID: 8668 RVA: 0x001F2474 File Offset: 0x001F0674
		private void CalculateGearFactor()
		{
			float num = 1f / (float)CarController.NoOfGears;
			float b = Mathf.InverseLerp(num * (float)this.m_GearNum, num * (float)(this.m_GearNum + 1), Mathf.Abs(this.CurrentSpeed / this.MaxSpeed));
			this.m_GearFactor = Mathf.Lerp(this.m_GearFactor, b, Time.deltaTime * 5f);
		}

		// Token: 0x060021DD RID: 8669 RVA: 0x001F24D8 File Offset: 0x001F06D8
		private void CalculateRevs()
		{
			this.CalculateGearFactor();
			float num = (float)this.m_GearNum / (float)CarController.NoOfGears;
			float from = CarController.ULerp(0f, this.m_RevRangeBoundary, CarController.CurveFactor(num));
			float to = CarController.ULerp(this.m_RevRangeBoundary, 1f, num);
			this.Revs = CarController.ULerp(from, to, this.m_GearFactor);
		}

		// Token: 0x060021DE RID: 8670 RVA: 0x001F2538 File Offset: 0x001F0738
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

		// Token: 0x060021DF RID: 8671 RVA: 0x001F267C File Offset: 0x001F087C
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

		// Token: 0x060021E0 RID: 8672 RVA: 0x001F2730 File Offset: 0x001F0930
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

		// Token: 0x060021E1 RID: 8673 RVA: 0x001F2870 File Offset: 0x001F0A70
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

		// Token: 0x060021E2 RID: 8674 RVA: 0x001F292C File Offset: 0x001F0B2C
		private void AddDownForce()
		{
			this.m_WheelColliders[0].attachedRigidbody.AddForce(-base.transform.up * this.m_Downforce * this.m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
		}

		// Token: 0x060021E3 RID: 8675 RVA: 0x001F2988 File Offset: 0x001F0B88
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

		// Token: 0x060021E4 RID: 8676 RVA: 0x001F2A2C File Offset: 0x001F0C2C
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

		// Token: 0x060021E5 RID: 8677 RVA: 0x001F2AF4 File Offset: 0x001F0CF4
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

		// Token: 0x060021E6 RID: 8678 RVA: 0x001F2B64 File Offset: 0x001F0D64
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

		// Token: 0x04004A79 RID: 19065
		[SerializeField]
		private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;

		// Token: 0x04004A7A RID: 19066
		[SerializeField]
		private WheelCollider[] m_WheelColliders = new WheelCollider[4];

		// Token: 0x04004A7B RID: 19067
		[SerializeField]
		private GameObject[] m_WheelMeshes = new GameObject[4];

		// Token: 0x04004A7C RID: 19068
		[SerializeField]
		private WheelEffects[] m_WheelEffects = new WheelEffects[4];

		// Token: 0x04004A7D RID: 19069
		[SerializeField]
		private Vector3 m_CentreOfMassOffset;

		// Token: 0x04004A7E RID: 19070
		[SerializeField]
		private float m_MaximumSteerAngle;

		// Token: 0x04004A7F RID: 19071
		[Range(0f, 1f)]
		[SerializeField]
		private float m_SteerHelper;

		// Token: 0x04004A80 RID: 19072
		[Range(0f, 1f)]
		[SerializeField]
		private float m_TractionControl;

		// Token: 0x04004A81 RID: 19073
		[SerializeField]
		private float m_FullTorqueOverAllWheels;

		// Token: 0x04004A82 RID: 19074
		[SerializeField]
		private float m_ReverseTorque;

		// Token: 0x04004A83 RID: 19075
		[SerializeField]
		private float m_MaxHandbrakeTorque;

		// Token: 0x04004A84 RID: 19076
		[SerializeField]
		private float m_Downforce = 100f;

		// Token: 0x04004A85 RID: 19077
		[SerializeField]
		private SpeedType m_SpeedType;

		// Token: 0x04004A86 RID: 19078
		[SerializeField]
		private float m_Topspeed = 200f;

		// Token: 0x04004A87 RID: 19079
		[SerializeField]
		private static int NoOfGears = 5;

		// Token: 0x04004A88 RID: 19080
		[SerializeField]
		private float m_RevRangeBoundary = 1f;

		// Token: 0x04004A89 RID: 19081
		[SerializeField]
		private float m_SlipLimit;

		// Token: 0x04004A8A RID: 19082
		[SerializeField]
		private float m_BrakeTorque;

		// Token: 0x04004A8B RID: 19083
		private Quaternion[] m_WheelMeshLocalRotations;

		// Token: 0x04004A8C RID: 19084
		private Vector3 m_Prevpos;

		// Token: 0x04004A8D RID: 19085
		private Vector3 m_Pos;

		// Token: 0x04004A8E RID: 19086
		private float m_SteerAngle;

		// Token: 0x04004A8F RID: 19087
		private int m_GearNum;

		// Token: 0x04004A90 RID: 19088
		private float m_GearFactor;

		// Token: 0x04004A91 RID: 19089
		private float m_OldRotation;

		// Token: 0x04004A92 RID: 19090
		private float m_CurrentTorque;

		// Token: 0x04004A93 RID: 19091
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A94 RID: 19092
		private const float k_ReversingThreshold = 0.01f;
	}
}
