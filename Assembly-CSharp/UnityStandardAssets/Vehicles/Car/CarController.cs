using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000521 RID: 1313
	public class CarController : MonoBehaviour
	{
		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06002160 RID: 8544 RVA: 0x001E8737 File Offset: 0x001E6937
		// (set) Token: 0x06002161 RID: 8545 RVA: 0x001E873F File Offset: 0x001E693F
		public bool Skidding { get; private set; }

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06002162 RID: 8546 RVA: 0x001E8748 File Offset: 0x001E6948
		// (set) Token: 0x06002163 RID: 8547 RVA: 0x001E8750 File Offset: 0x001E6950
		public float BrakeInput { get; private set; }

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06002164 RID: 8548 RVA: 0x001E8759 File Offset: 0x001E6959
		public float CurrentSteerAngle
		{
			get
			{
				return this.m_SteerAngle;
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06002165 RID: 8549 RVA: 0x001E8764 File Offset: 0x001E6964
		public float CurrentSpeed
		{
			get
			{
				return this.m_Rigidbody.velocity.magnitude * 2.2369363f;
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06002166 RID: 8550 RVA: 0x001E878A File Offset: 0x001E698A
		public float MaxSpeed
		{
			get
			{
				return this.m_Topspeed;
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06002167 RID: 8551 RVA: 0x001E8792 File Offset: 0x001E6992
		// (set) Token: 0x06002168 RID: 8552 RVA: 0x001E879A File Offset: 0x001E699A
		public float Revs { get; private set; }

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06002169 RID: 8553 RVA: 0x001E87A3 File Offset: 0x001E69A3
		// (set) Token: 0x0600216A RID: 8554 RVA: 0x001E87AB File Offset: 0x001E69AB
		public float AccelInput { get; private set; }

		// Token: 0x0600216B RID: 8555 RVA: 0x001E87B4 File Offset: 0x001E69B4
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

		// Token: 0x0600216C RID: 8556 RVA: 0x001E8840 File Offset: 0x001E6A40
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

		// Token: 0x0600216D RID: 8557 RVA: 0x001E88C8 File Offset: 0x001E6AC8
		private static float CurveFactor(float factor)
		{
			return 1f - (1f - factor) * (1f - factor);
		}

		// Token: 0x0600216E RID: 8558 RVA: 0x001E88DF File Offset: 0x001E6ADF
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x0600216F RID: 8559 RVA: 0x001E88F0 File Offset: 0x001E6AF0
		private void CalculateGearFactor()
		{
			float num = 1f / (float)CarController.NoOfGears;
			float b = Mathf.InverseLerp(num * (float)this.m_GearNum, num * (float)(this.m_GearNum + 1), Mathf.Abs(this.CurrentSpeed / this.MaxSpeed));
			this.m_GearFactor = Mathf.Lerp(this.m_GearFactor, b, Time.deltaTime * 5f);
		}

		// Token: 0x06002170 RID: 8560 RVA: 0x001E8954 File Offset: 0x001E6B54
		private void CalculateRevs()
		{
			this.CalculateGearFactor();
			float num = (float)this.m_GearNum / (float)CarController.NoOfGears;
			float from = CarController.ULerp(0f, this.m_RevRangeBoundary, CarController.CurveFactor(num));
			float to = CarController.ULerp(this.m_RevRangeBoundary, 1f, num);
			this.Revs = CarController.ULerp(from, to, this.m_GearFactor);
		}

		// Token: 0x06002171 RID: 8561 RVA: 0x001E89B4 File Offset: 0x001E6BB4
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

		// Token: 0x06002172 RID: 8562 RVA: 0x001E8AF8 File Offset: 0x001E6CF8
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

		// Token: 0x06002173 RID: 8563 RVA: 0x001E8BAC File Offset: 0x001E6DAC
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

		// Token: 0x06002174 RID: 8564 RVA: 0x001E8CEC File Offset: 0x001E6EEC
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

		// Token: 0x06002175 RID: 8565 RVA: 0x001E8DA8 File Offset: 0x001E6FA8
		private void AddDownForce()
		{
			this.m_WheelColliders[0].attachedRigidbody.AddForce(-base.transform.up * this.m_Downforce * this.m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
		}

		// Token: 0x06002176 RID: 8566 RVA: 0x001E8E04 File Offset: 0x001E7004
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

		// Token: 0x06002177 RID: 8567 RVA: 0x001E8EA8 File Offset: 0x001E70A8
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

		// Token: 0x06002178 RID: 8568 RVA: 0x001E8F70 File Offset: 0x001E7170
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

		// Token: 0x06002179 RID: 8569 RVA: 0x001E8FE0 File Offset: 0x001E71E0
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

		// Token: 0x04004957 RID: 18775
		[SerializeField]
		private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;

		// Token: 0x04004958 RID: 18776
		[SerializeField]
		private WheelCollider[] m_WheelColliders = new WheelCollider[4];

		// Token: 0x04004959 RID: 18777
		[SerializeField]
		private GameObject[] m_WheelMeshes = new GameObject[4];

		// Token: 0x0400495A RID: 18778
		[SerializeField]
		private WheelEffects[] m_WheelEffects = new WheelEffects[4];

		// Token: 0x0400495B RID: 18779
		[SerializeField]
		private Vector3 m_CentreOfMassOffset;

		// Token: 0x0400495C RID: 18780
		[SerializeField]
		private float m_MaximumSteerAngle;

		// Token: 0x0400495D RID: 18781
		[Range(0f, 1f)]
		[SerializeField]
		private float m_SteerHelper;

		// Token: 0x0400495E RID: 18782
		[Range(0f, 1f)]
		[SerializeField]
		private float m_TractionControl;

		// Token: 0x0400495F RID: 18783
		[SerializeField]
		private float m_FullTorqueOverAllWheels;

		// Token: 0x04004960 RID: 18784
		[SerializeField]
		private float m_ReverseTorque;

		// Token: 0x04004961 RID: 18785
		[SerializeField]
		private float m_MaxHandbrakeTorque;

		// Token: 0x04004962 RID: 18786
		[SerializeField]
		private float m_Downforce = 100f;

		// Token: 0x04004963 RID: 18787
		[SerializeField]
		private SpeedType m_SpeedType;

		// Token: 0x04004964 RID: 18788
		[SerializeField]
		private float m_Topspeed = 200f;

		// Token: 0x04004965 RID: 18789
		[SerializeField]
		private static int NoOfGears = 5;

		// Token: 0x04004966 RID: 18790
		[SerializeField]
		private float m_RevRangeBoundary = 1f;

		// Token: 0x04004967 RID: 18791
		[SerializeField]
		private float m_SlipLimit;

		// Token: 0x04004968 RID: 18792
		[SerializeField]
		private float m_BrakeTorque;

		// Token: 0x04004969 RID: 18793
		private Quaternion[] m_WheelMeshLocalRotations;

		// Token: 0x0400496A RID: 18794
		private Vector3 m_Prevpos;

		// Token: 0x0400496B RID: 18795
		private Vector3 m_Pos;

		// Token: 0x0400496C RID: 18796
		private float m_SteerAngle;

		// Token: 0x0400496D RID: 18797
		private int m_GearNum;

		// Token: 0x0400496E RID: 18798
		private float m_GearFactor;

		// Token: 0x0400496F RID: 18799
		private float m_OldRotation;

		// Token: 0x04004970 RID: 18800
		private float m_CurrentTorque;

		// Token: 0x04004971 RID: 18801
		private Rigidbody m_Rigidbody;

		// Token: 0x04004972 RID: 18802
		private const float k_ReversingThreshold = 0.01f;
	}
}
