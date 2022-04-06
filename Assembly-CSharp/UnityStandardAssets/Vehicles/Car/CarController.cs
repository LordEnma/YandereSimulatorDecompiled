using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000531 RID: 1329
	public class CarController : MonoBehaviour
	{
		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x060021BC RID: 8636 RVA: 0x001F02D7 File Offset: 0x001EE4D7
		// (set) Token: 0x060021BD RID: 8637 RVA: 0x001F02DF File Offset: 0x001EE4DF
		public bool Skidding { get; private set; }

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x060021BE RID: 8638 RVA: 0x001F02E8 File Offset: 0x001EE4E8
		// (set) Token: 0x060021BF RID: 8639 RVA: 0x001F02F0 File Offset: 0x001EE4F0
		public float BrakeInput { get; private set; }

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x060021C0 RID: 8640 RVA: 0x001F02F9 File Offset: 0x001EE4F9
		public float CurrentSteerAngle
		{
			get
			{
				return this.m_SteerAngle;
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x060021C1 RID: 8641 RVA: 0x001F0304 File Offset: 0x001EE504
		public float CurrentSpeed
		{
			get
			{
				return this.m_Rigidbody.velocity.magnitude * 2.2369363f;
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x060021C2 RID: 8642 RVA: 0x001F032A File Offset: 0x001EE52A
		public float MaxSpeed
		{
			get
			{
				return this.m_Topspeed;
			}
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x060021C3 RID: 8643 RVA: 0x001F0332 File Offset: 0x001EE532
		// (set) Token: 0x060021C4 RID: 8644 RVA: 0x001F033A File Offset: 0x001EE53A
		public float Revs { get; private set; }

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060021C5 RID: 8645 RVA: 0x001F0343 File Offset: 0x001EE543
		// (set) Token: 0x060021C6 RID: 8646 RVA: 0x001F034B File Offset: 0x001EE54B
		public float AccelInput { get; private set; }

		// Token: 0x060021C7 RID: 8647 RVA: 0x001F0354 File Offset: 0x001EE554
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

		// Token: 0x060021C8 RID: 8648 RVA: 0x001F03E0 File Offset: 0x001EE5E0
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

		// Token: 0x060021C9 RID: 8649 RVA: 0x001F0468 File Offset: 0x001EE668
		private static float CurveFactor(float factor)
		{
			return 1f - (1f - factor) * (1f - factor);
		}

		// Token: 0x060021CA RID: 8650 RVA: 0x001F047F File Offset: 0x001EE67F
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x060021CB RID: 8651 RVA: 0x001F0490 File Offset: 0x001EE690
		private void CalculateGearFactor()
		{
			float num = 1f / (float)CarController.NoOfGears;
			float b = Mathf.InverseLerp(num * (float)this.m_GearNum, num * (float)(this.m_GearNum + 1), Mathf.Abs(this.CurrentSpeed / this.MaxSpeed));
			this.m_GearFactor = Mathf.Lerp(this.m_GearFactor, b, Time.deltaTime * 5f);
		}

		// Token: 0x060021CC RID: 8652 RVA: 0x001F04F4 File Offset: 0x001EE6F4
		private void CalculateRevs()
		{
			this.CalculateGearFactor();
			float num = (float)this.m_GearNum / (float)CarController.NoOfGears;
			float from = CarController.ULerp(0f, this.m_RevRangeBoundary, CarController.CurveFactor(num));
			float to = CarController.ULerp(this.m_RevRangeBoundary, 1f, num);
			this.Revs = CarController.ULerp(from, to, this.m_GearFactor);
		}

		// Token: 0x060021CD RID: 8653 RVA: 0x001F0554 File Offset: 0x001EE754
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

		// Token: 0x060021CE RID: 8654 RVA: 0x001F0698 File Offset: 0x001EE898
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

		// Token: 0x060021CF RID: 8655 RVA: 0x001F074C File Offset: 0x001EE94C
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

		// Token: 0x060021D0 RID: 8656 RVA: 0x001F088C File Offset: 0x001EEA8C
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

		// Token: 0x060021D1 RID: 8657 RVA: 0x001F0948 File Offset: 0x001EEB48
		private void AddDownForce()
		{
			this.m_WheelColliders[0].attachedRigidbody.AddForce(-base.transform.up * this.m_Downforce * this.m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
		}

		// Token: 0x060021D2 RID: 8658 RVA: 0x001F09A4 File Offset: 0x001EEBA4
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

		// Token: 0x060021D3 RID: 8659 RVA: 0x001F0A48 File Offset: 0x001EEC48
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

		// Token: 0x060021D4 RID: 8660 RVA: 0x001F0B10 File Offset: 0x001EED10
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

		// Token: 0x060021D5 RID: 8661 RVA: 0x001F0B80 File Offset: 0x001EED80
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

		// Token: 0x04004A51 RID: 19025
		[SerializeField]
		private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;

		// Token: 0x04004A52 RID: 19026
		[SerializeField]
		private WheelCollider[] m_WheelColliders = new WheelCollider[4];

		// Token: 0x04004A53 RID: 19027
		[SerializeField]
		private GameObject[] m_WheelMeshes = new GameObject[4];

		// Token: 0x04004A54 RID: 19028
		[SerializeField]
		private WheelEffects[] m_WheelEffects = new WheelEffects[4];

		// Token: 0x04004A55 RID: 19029
		[SerializeField]
		private Vector3 m_CentreOfMassOffset;

		// Token: 0x04004A56 RID: 19030
		[SerializeField]
		private float m_MaximumSteerAngle;

		// Token: 0x04004A57 RID: 19031
		[Range(0f, 1f)]
		[SerializeField]
		private float m_SteerHelper;

		// Token: 0x04004A58 RID: 19032
		[Range(0f, 1f)]
		[SerializeField]
		private float m_TractionControl;

		// Token: 0x04004A59 RID: 19033
		[SerializeField]
		private float m_FullTorqueOverAllWheels;

		// Token: 0x04004A5A RID: 19034
		[SerializeField]
		private float m_ReverseTorque;

		// Token: 0x04004A5B RID: 19035
		[SerializeField]
		private float m_MaxHandbrakeTorque;

		// Token: 0x04004A5C RID: 19036
		[SerializeField]
		private float m_Downforce = 100f;

		// Token: 0x04004A5D RID: 19037
		[SerializeField]
		private SpeedType m_SpeedType;

		// Token: 0x04004A5E RID: 19038
		[SerializeField]
		private float m_Topspeed = 200f;

		// Token: 0x04004A5F RID: 19039
		[SerializeField]
		private static int NoOfGears = 5;

		// Token: 0x04004A60 RID: 19040
		[SerializeField]
		private float m_RevRangeBoundary = 1f;

		// Token: 0x04004A61 RID: 19041
		[SerializeField]
		private float m_SlipLimit;

		// Token: 0x04004A62 RID: 19042
		[SerializeField]
		private float m_BrakeTorque;

		// Token: 0x04004A63 RID: 19043
		private Quaternion[] m_WheelMeshLocalRotations;

		// Token: 0x04004A64 RID: 19044
		private Vector3 m_Prevpos;

		// Token: 0x04004A65 RID: 19045
		private Vector3 m_Pos;

		// Token: 0x04004A66 RID: 19046
		private float m_SteerAngle;

		// Token: 0x04004A67 RID: 19047
		private int m_GearNum;

		// Token: 0x04004A68 RID: 19048
		private float m_GearFactor;

		// Token: 0x04004A69 RID: 19049
		private float m_OldRotation;

		// Token: 0x04004A6A RID: 19050
		private float m_CurrentTorque;

		// Token: 0x04004A6B RID: 19051
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A6C RID: 19052
		private const float k_ReversingThreshold = 0.01f;
	}
}
