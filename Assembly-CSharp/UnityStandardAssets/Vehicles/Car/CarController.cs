using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000521 RID: 1313
	public class CarController : MonoBehaviour
	{
		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x0600215D RID: 8541 RVA: 0x001E8147 File Offset: 0x001E6347
		// (set) Token: 0x0600215E RID: 8542 RVA: 0x001E814F File Offset: 0x001E634F
		public bool Skidding { get; private set; }

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x0600215F RID: 8543 RVA: 0x001E8158 File Offset: 0x001E6358
		// (set) Token: 0x06002160 RID: 8544 RVA: 0x001E8160 File Offset: 0x001E6360
		public float BrakeInput { get; private set; }

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06002161 RID: 8545 RVA: 0x001E8169 File Offset: 0x001E6369
		public float CurrentSteerAngle
		{
			get
			{
				return this.m_SteerAngle;
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06002162 RID: 8546 RVA: 0x001E8174 File Offset: 0x001E6374
		public float CurrentSpeed
		{
			get
			{
				return this.m_Rigidbody.velocity.magnitude * 2.2369363f;
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06002163 RID: 8547 RVA: 0x001E819A File Offset: 0x001E639A
		public float MaxSpeed
		{
			get
			{
				return this.m_Topspeed;
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06002164 RID: 8548 RVA: 0x001E81A2 File Offset: 0x001E63A2
		// (set) Token: 0x06002165 RID: 8549 RVA: 0x001E81AA File Offset: 0x001E63AA
		public float Revs { get; private set; }

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06002166 RID: 8550 RVA: 0x001E81B3 File Offset: 0x001E63B3
		// (set) Token: 0x06002167 RID: 8551 RVA: 0x001E81BB File Offset: 0x001E63BB
		public float AccelInput { get; private set; }

		// Token: 0x06002168 RID: 8552 RVA: 0x001E81C4 File Offset: 0x001E63C4
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

		// Token: 0x06002169 RID: 8553 RVA: 0x001E8250 File Offset: 0x001E6450
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

		// Token: 0x0600216A RID: 8554 RVA: 0x001E82D8 File Offset: 0x001E64D8
		private static float CurveFactor(float factor)
		{
			return 1f - (1f - factor) * (1f - factor);
		}

		// Token: 0x0600216B RID: 8555 RVA: 0x001E82EF File Offset: 0x001E64EF
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x0600216C RID: 8556 RVA: 0x001E8300 File Offset: 0x001E6500
		private void CalculateGearFactor()
		{
			float num = 1f / (float)CarController.NoOfGears;
			float b = Mathf.InverseLerp(num * (float)this.m_GearNum, num * (float)(this.m_GearNum + 1), Mathf.Abs(this.CurrentSpeed / this.MaxSpeed));
			this.m_GearFactor = Mathf.Lerp(this.m_GearFactor, b, Time.deltaTime * 5f);
		}

		// Token: 0x0600216D RID: 8557 RVA: 0x001E8364 File Offset: 0x001E6564
		private void CalculateRevs()
		{
			this.CalculateGearFactor();
			float num = (float)this.m_GearNum / (float)CarController.NoOfGears;
			float from = CarController.ULerp(0f, this.m_RevRangeBoundary, CarController.CurveFactor(num));
			float to = CarController.ULerp(this.m_RevRangeBoundary, 1f, num);
			this.Revs = CarController.ULerp(from, to, this.m_GearFactor);
		}

		// Token: 0x0600216E RID: 8558 RVA: 0x001E83C4 File Offset: 0x001E65C4
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

		// Token: 0x0600216F RID: 8559 RVA: 0x001E8508 File Offset: 0x001E6708
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

		// Token: 0x06002170 RID: 8560 RVA: 0x001E85BC File Offset: 0x001E67BC
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

		// Token: 0x06002171 RID: 8561 RVA: 0x001E86FC File Offset: 0x001E68FC
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

		// Token: 0x06002172 RID: 8562 RVA: 0x001E87B8 File Offset: 0x001E69B8
		private void AddDownForce()
		{
			this.m_WheelColliders[0].attachedRigidbody.AddForce(-base.transform.up * this.m_Downforce * this.m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
		}

		// Token: 0x06002173 RID: 8563 RVA: 0x001E8814 File Offset: 0x001E6A14
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

		// Token: 0x06002174 RID: 8564 RVA: 0x001E88B8 File Offset: 0x001E6AB8
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

		// Token: 0x06002175 RID: 8565 RVA: 0x001E8980 File Offset: 0x001E6B80
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

		// Token: 0x06002176 RID: 8566 RVA: 0x001E89F0 File Offset: 0x001E6BF0
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

		// Token: 0x0400494E RID: 18766
		[SerializeField]
		private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;

		// Token: 0x0400494F RID: 18767
		[SerializeField]
		private WheelCollider[] m_WheelColliders = new WheelCollider[4];

		// Token: 0x04004950 RID: 18768
		[SerializeField]
		private GameObject[] m_WheelMeshes = new GameObject[4];

		// Token: 0x04004951 RID: 18769
		[SerializeField]
		private WheelEffects[] m_WheelEffects = new WheelEffects[4];

		// Token: 0x04004952 RID: 18770
		[SerializeField]
		private Vector3 m_CentreOfMassOffset;

		// Token: 0x04004953 RID: 18771
		[SerializeField]
		private float m_MaximumSteerAngle;

		// Token: 0x04004954 RID: 18772
		[Range(0f, 1f)]
		[SerializeField]
		private float m_SteerHelper;

		// Token: 0x04004955 RID: 18773
		[Range(0f, 1f)]
		[SerializeField]
		private float m_TractionControl;

		// Token: 0x04004956 RID: 18774
		[SerializeField]
		private float m_FullTorqueOverAllWheels;

		// Token: 0x04004957 RID: 18775
		[SerializeField]
		private float m_ReverseTorque;

		// Token: 0x04004958 RID: 18776
		[SerializeField]
		private float m_MaxHandbrakeTorque;

		// Token: 0x04004959 RID: 18777
		[SerializeField]
		private float m_Downforce = 100f;

		// Token: 0x0400495A RID: 18778
		[SerializeField]
		private SpeedType m_SpeedType;

		// Token: 0x0400495B RID: 18779
		[SerializeField]
		private float m_Topspeed = 200f;

		// Token: 0x0400495C RID: 18780
		[SerializeField]
		private static int NoOfGears = 5;

		// Token: 0x0400495D RID: 18781
		[SerializeField]
		private float m_RevRangeBoundary = 1f;

		// Token: 0x0400495E RID: 18782
		[SerializeField]
		private float m_SlipLimit;

		// Token: 0x0400495F RID: 18783
		[SerializeField]
		private float m_BrakeTorque;

		// Token: 0x04004960 RID: 18784
		private Quaternion[] m_WheelMeshLocalRotations;

		// Token: 0x04004961 RID: 18785
		private Vector3 m_Prevpos;

		// Token: 0x04004962 RID: 18786
		private Vector3 m_Pos;

		// Token: 0x04004963 RID: 18787
		private float m_SteerAngle;

		// Token: 0x04004964 RID: 18788
		private int m_GearNum;

		// Token: 0x04004965 RID: 18789
		private float m_GearFactor;

		// Token: 0x04004966 RID: 18790
		private float m_OldRotation;

		// Token: 0x04004967 RID: 18791
		private float m_CurrentTorque;

		// Token: 0x04004968 RID: 18792
		private Rigidbody m_Rigidbody;

		// Token: 0x04004969 RID: 18793
		private const float k_ReversingThreshold = 0.01f;
	}
}
