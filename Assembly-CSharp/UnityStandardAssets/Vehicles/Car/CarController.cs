using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200051F RID: 1311
	public class CarController : MonoBehaviour
	{
		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x0600214C RID: 8524 RVA: 0x001E6A13 File Offset: 0x001E4C13
		// (set) Token: 0x0600214D RID: 8525 RVA: 0x001E6A1B File Offset: 0x001E4C1B
		public bool Skidding { get; private set; }

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x0600214E RID: 8526 RVA: 0x001E6A24 File Offset: 0x001E4C24
		// (set) Token: 0x0600214F RID: 8527 RVA: 0x001E6A2C File Offset: 0x001E4C2C
		public float BrakeInput { get; private set; }

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06002150 RID: 8528 RVA: 0x001E6A35 File Offset: 0x001E4C35
		public float CurrentSteerAngle
		{
			get
			{
				return this.m_SteerAngle;
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06002151 RID: 8529 RVA: 0x001E6A40 File Offset: 0x001E4C40
		public float CurrentSpeed
		{
			get
			{
				return this.m_Rigidbody.velocity.magnitude * 2.2369363f;
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06002152 RID: 8530 RVA: 0x001E6A66 File Offset: 0x001E4C66
		public float MaxSpeed
		{
			get
			{
				return this.m_Topspeed;
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06002153 RID: 8531 RVA: 0x001E6A6E File Offset: 0x001E4C6E
		// (set) Token: 0x06002154 RID: 8532 RVA: 0x001E6A76 File Offset: 0x001E4C76
		public float Revs { get; private set; }

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06002155 RID: 8533 RVA: 0x001E6A7F File Offset: 0x001E4C7F
		// (set) Token: 0x06002156 RID: 8534 RVA: 0x001E6A87 File Offset: 0x001E4C87
		public float AccelInput { get; private set; }

		// Token: 0x06002157 RID: 8535 RVA: 0x001E6A90 File Offset: 0x001E4C90
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

		// Token: 0x06002158 RID: 8536 RVA: 0x001E6B1C File Offset: 0x001E4D1C
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

		// Token: 0x06002159 RID: 8537 RVA: 0x001E6BA4 File Offset: 0x001E4DA4
		private static float CurveFactor(float factor)
		{
			return 1f - (1f - factor) * (1f - factor);
		}

		// Token: 0x0600215A RID: 8538 RVA: 0x001E6BBB File Offset: 0x001E4DBB
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x0600215B RID: 8539 RVA: 0x001E6BCC File Offset: 0x001E4DCC
		private void CalculateGearFactor()
		{
			float num = 1f / (float)CarController.NoOfGears;
			float b = Mathf.InverseLerp(num * (float)this.m_GearNum, num * (float)(this.m_GearNum + 1), Mathf.Abs(this.CurrentSpeed / this.MaxSpeed));
			this.m_GearFactor = Mathf.Lerp(this.m_GearFactor, b, Time.deltaTime * 5f);
		}

		// Token: 0x0600215C RID: 8540 RVA: 0x001E6C30 File Offset: 0x001E4E30
		private void CalculateRevs()
		{
			this.CalculateGearFactor();
			float num = (float)this.m_GearNum / (float)CarController.NoOfGears;
			float from = CarController.ULerp(0f, this.m_RevRangeBoundary, CarController.CurveFactor(num));
			float to = CarController.ULerp(this.m_RevRangeBoundary, 1f, num);
			this.Revs = CarController.ULerp(from, to, this.m_GearFactor);
		}

		// Token: 0x0600215D RID: 8541 RVA: 0x001E6C90 File Offset: 0x001E4E90
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

		// Token: 0x0600215E RID: 8542 RVA: 0x001E6DD4 File Offset: 0x001E4FD4
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

		// Token: 0x0600215F RID: 8543 RVA: 0x001E6E88 File Offset: 0x001E5088
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

		// Token: 0x06002160 RID: 8544 RVA: 0x001E6FC8 File Offset: 0x001E51C8
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

		// Token: 0x06002161 RID: 8545 RVA: 0x001E7084 File Offset: 0x001E5284
		private void AddDownForce()
		{
			this.m_WheelColliders[0].attachedRigidbody.AddForce(-base.transform.up * this.m_Downforce * this.m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
		}

		// Token: 0x06002162 RID: 8546 RVA: 0x001E70E0 File Offset: 0x001E52E0
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

		// Token: 0x06002163 RID: 8547 RVA: 0x001E7184 File Offset: 0x001E5384
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

		// Token: 0x06002164 RID: 8548 RVA: 0x001E724C File Offset: 0x001E544C
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

		// Token: 0x06002165 RID: 8549 RVA: 0x001E72BC File Offset: 0x001E54BC
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

		// Token: 0x0400490F RID: 18703
		[SerializeField]
		private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;

		// Token: 0x04004910 RID: 18704
		[SerializeField]
		private WheelCollider[] m_WheelColliders = new WheelCollider[4];

		// Token: 0x04004911 RID: 18705
		[SerializeField]
		private GameObject[] m_WheelMeshes = new GameObject[4];

		// Token: 0x04004912 RID: 18706
		[SerializeField]
		private WheelEffects[] m_WheelEffects = new WheelEffects[4];

		// Token: 0x04004913 RID: 18707
		[SerializeField]
		private Vector3 m_CentreOfMassOffset;

		// Token: 0x04004914 RID: 18708
		[SerializeField]
		private float m_MaximumSteerAngle;

		// Token: 0x04004915 RID: 18709
		[Range(0f, 1f)]
		[SerializeField]
		private float m_SteerHelper;

		// Token: 0x04004916 RID: 18710
		[Range(0f, 1f)]
		[SerializeField]
		private float m_TractionControl;

		// Token: 0x04004917 RID: 18711
		[SerializeField]
		private float m_FullTorqueOverAllWheels;

		// Token: 0x04004918 RID: 18712
		[SerializeField]
		private float m_ReverseTorque;

		// Token: 0x04004919 RID: 18713
		[SerializeField]
		private float m_MaxHandbrakeTorque;

		// Token: 0x0400491A RID: 18714
		[SerializeField]
		private float m_Downforce = 100f;

		// Token: 0x0400491B RID: 18715
		[SerializeField]
		private SpeedType m_SpeedType;

		// Token: 0x0400491C RID: 18716
		[SerializeField]
		private float m_Topspeed = 200f;

		// Token: 0x0400491D RID: 18717
		[SerializeField]
		private static int NoOfGears = 5;

		// Token: 0x0400491E RID: 18718
		[SerializeField]
		private float m_RevRangeBoundary = 1f;

		// Token: 0x0400491F RID: 18719
		[SerializeField]
		private float m_SlipLimit;

		// Token: 0x04004920 RID: 18720
		[SerializeField]
		private float m_BrakeTorque;

		// Token: 0x04004921 RID: 18721
		private Quaternion[] m_WheelMeshLocalRotations;

		// Token: 0x04004922 RID: 18722
		private Vector3 m_Prevpos;

		// Token: 0x04004923 RID: 18723
		private Vector3 m_Pos;

		// Token: 0x04004924 RID: 18724
		private float m_SteerAngle;

		// Token: 0x04004925 RID: 18725
		private int m_GearNum;

		// Token: 0x04004926 RID: 18726
		private float m_GearFactor;

		// Token: 0x04004927 RID: 18727
		private float m_OldRotation;

		// Token: 0x04004928 RID: 18728
		private float m_CurrentTorque;

		// Token: 0x04004929 RID: 18729
		private Rigidbody m_Rigidbody;

		// Token: 0x0400492A RID: 18730
		private const float k_ReversingThreshold = 0.01f;
	}
}
