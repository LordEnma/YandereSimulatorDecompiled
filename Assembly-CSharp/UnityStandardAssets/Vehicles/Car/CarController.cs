using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000526 RID: 1318
	public class CarController : MonoBehaviour
	{
		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06002186 RID: 8582 RVA: 0x001EBBF7 File Offset: 0x001E9DF7
		// (set) Token: 0x06002187 RID: 8583 RVA: 0x001EBBFF File Offset: 0x001E9DFF
		public bool Skidding { get; private set; }

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06002188 RID: 8584 RVA: 0x001EBC08 File Offset: 0x001E9E08
		// (set) Token: 0x06002189 RID: 8585 RVA: 0x001EBC10 File Offset: 0x001E9E10
		public float BrakeInput { get; private set; }

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x0600218A RID: 8586 RVA: 0x001EBC19 File Offset: 0x001E9E19
		public float CurrentSteerAngle
		{
			get
			{
				return this.m_SteerAngle;
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x0600218B RID: 8587 RVA: 0x001EBC24 File Offset: 0x001E9E24
		public float CurrentSpeed
		{
			get
			{
				return this.m_Rigidbody.velocity.magnitude * 2.2369363f;
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x0600218C RID: 8588 RVA: 0x001EBC4A File Offset: 0x001E9E4A
		public float MaxSpeed
		{
			get
			{
				return this.m_Topspeed;
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x0600218D RID: 8589 RVA: 0x001EBC52 File Offset: 0x001E9E52
		// (set) Token: 0x0600218E RID: 8590 RVA: 0x001EBC5A File Offset: 0x001E9E5A
		public float Revs { get; private set; }

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x0600218F RID: 8591 RVA: 0x001EBC63 File Offset: 0x001E9E63
		// (set) Token: 0x06002190 RID: 8592 RVA: 0x001EBC6B File Offset: 0x001E9E6B
		public float AccelInput { get; private set; }

		// Token: 0x06002191 RID: 8593 RVA: 0x001EBC74 File Offset: 0x001E9E74
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

		// Token: 0x06002192 RID: 8594 RVA: 0x001EBD00 File Offset: 0x001E9F00
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

		// Token: 0x06002193 RID: 8595 RVA: 0x001EBD88 File Offset: 0x001E9F88
		private static float CurveFactor(float factor)
		{
			return 1f - (1f - factor) * (1f - factor);
		}

		// Token: 0x06002194 RID: 8596 RVA: 0x001EBD9F File Offset: 0x001E9F9F
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x06002195 RID: 8597 RVA: 0x001EBDB0 File Offset: 0x001E9FB0
		private void CalculateGearFactor()
		{
			float num = 1f / (float)CarController.NoOfGears;
			float b = Mathf.InverseLerp(num * (float)this.m_GearNum, num * (float)(this.m_GearNum + 1), Mathf.Abs(this.CurrentSpeed / this.MaxSpeed));
			this.m_GearFactor = Mathf.Lerp(this.m_GearFactor, b, Time.deltaTime * 5f);
		}

		// Token: 0x06002196 RID: 8598 RVA: 0x001EBE14 File Offset: 0x001EA014
		private void CalculateRevs()
		{
			this.CalculateGearFactor();
			float num = (float)this.m_GearNum / (float)CarController.NoOfGears;
			float from = CarController.ULerp(0f, this.m_RevRangeBoundary, CarController.CurveFactor(num));
			float to = CarController.ULerp(this.m_RevRangeBoundary, 1f, num);
			this.Revs = CarController.ULerp(from, to, this.m_GearFactor);
		}

		// Token: 0x06002197 RID: 8599 RVA: 0x001EBE74 File Offset: 0x001EA074
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

		// Token: 0x06002198 RID: 8600 RVA: 0x001EBFB8 File Offset: 0x001EA1B8
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

		// Token: 0x06002199 RID: 8601 RVA: 0x001EC06C File Offset: 0x001EA26C
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

		// Token: 0x0600219A RID: 8602 RVA: 0x001EC1AC File Offset: 0x001EA3AC
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

		// Token: 0x0600219B RID: 8603 RVA: 0x001EC268 File Offset: 0x001EA468
		private void AddDownForce()
		{
			this.m_WheelColliders[0].attachedRigidbody.AddForce(-base.transform.up * this.m_Downforce * this.m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
		}

		// Token: 0x0600219C RID: 8604 RVA: 0x001EC2C4 File Offset: 0x001EA4C4
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

		// Token: 0x0600219D RID: 8605 RVA: 0x001EC368 File Offset: 0x001EA568
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

		// Token: 0x0600219E RID: 8606 RVA: 0x001EC430 File Offset: 0x001EA630
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

		// Token: 0x0600219F RID: 8607 RVA: 0x001EC4A0 File Offset: 0x001EA6A0
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

		// Token: 0x0400499F RID: 18847
		[SerializeField]
		private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;

		// Token: 0x040049A0 RID: 18848
		[SerializeField]
		private WheelCollider[] m_WheelColliders = new WheelCollider[4];

		// Token: 0x040049A1 RID: 18849
		[SerializeField]
		private GameObject[] m_WheelMeshes = new GameObject[4];

		// Token: 0x040049A2 RID: 18850
		[SerializeField]
		private WheelEffects[] m_WheelEffects = new WheelEffects[4];

		// Token: 0x040049A3 RID: 18851
		[SerializeField]
		private Vector3 m_CentreOfMassOffset;

		// Token: 0x040049A4 RID: 18852
		[SerializeField]
		private float m_MaximumSteerAngle;

		// Token: 0x040049A5 RID: 18853
		[Range(0f, 1f)]
		[SerializeField]
		private float m_SteerHelper;

		// Token: 0x040049A6 RID: 18854
		[Range(0f, 1f)]
		[SerializeField]
		private float m_TractionControl;

		// Token: 0x040049A7 RID: 18855
		[SerializeField]
		private float m_FullTorqueOverAllWheels;

		// Token: 0x040049A8 RID: 18856
		[SerializeField]
		private float m_ReverseTorque;

		// Token: 0x040049A9 RID: 18857
		[SerializeField]
		private float m_MaxHandbrakeTorque;

		// Token: 0x040049AA RID: 18858
		[SerializeField]
		private float m_Downforce = 100f;

		// Token: 0x040049AB RID: 18859
		[SerializeField]
		private SpeedType m_SpeedType;

		// Token: 0x040049AC RID: 18860
		[SerializeField]
		private float m_Topspeed = 200f;

		// Token: 0x040049AD RID: 18861
		[SerializeField]
		private static int NoOfGears = 5;

		// Token: 0x040049AE RID: 18862
		[SerializeField]
		private float m_RevRangeBoundary = 1f;

		// Token: 0x040049AF RID: 18863
		[SerializeField]
		private float m_SlipLimit;

		// Token: 0x040049B0 RID: 18864
		[SerializeField]
		private float m_BrakeTorque;

		// Token: 0x040049B1 RID: 18865
		private Quaternion[] m_WheelMeshLocalRotations;

		// Token: 0x040049B2 RID: 18866
		private Vector3 m_Prevpos;

		// Token: 0x040049B3 RID: 18867
		private Vector3 m_Pos;

		// Token: 0x040049B4 RID: 18868
		private float m_SteerAngle;

		// Token: 0x040049B5 RID: 18869
		private int m_GearNum;

		// Token: 0x040049B6 RID: 18870
		private float m_GearFactor;

		// Token: 0x040049B7 RID: 18871
		private float m_OldRotation;

		// Token: 0x040049B8 RID: 18872
		private float m_CurrentTorque;

		// Token: 0x040049B9 RID: 18873
		private Rigidbody m_Rigidbody;

		// Token: 0x040049BA RID: 18874
		private const float k_ReversingThreshold = 0.01f;
	}
}
