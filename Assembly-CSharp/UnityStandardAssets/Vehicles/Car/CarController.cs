using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000531 RID: 1329
	public class CarController : MonoBehaviour
	{
		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x060021C3 RID: 8643 RVA: 0x001F0D33 File Offset: 0x001EEF33
		// (set) Token: 0x060021C4 RID: 8644 RVA: 0x001F0D3B File Offset: 0x001EEF3B
		public bool Skidding { get; private set; }

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x060021C5 RID: 8645 RVA: 0x001F0D44 File Offset: 0x001EEF44
		// (set) Token: 0x060021C6 RID: 8646 RVA: 0x001F0D4C File Offset: 0x001EEF4C
		public float BrakeInput { get; private set; }

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x060021C7 RID: 8647 RVA: 0x001F0D55 File Offset: 0x001EEF55
		public float CurrentSteerAngle
		{
			get
			{
				return this.m_SteerAngle;
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x060021C8 RID: 8648 RVA: 0x001F0D60 File Offset: 0x001EEF60
		public float CurrentSpeed
		{
			get
			{
				return this.m_Rigidbody.velocity.magnitude * 2.2369363f;
			}
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x060021C9 RID: 8649 RVA: 0x001F0D86 File Offset: 0x001EEF86
		public float MaxSpeed
		{
			get
			{
				return this.m_Topspeed;
			}
		}

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060021CA RID: 8650 RVA: 0x001F0D8E File Offset: 0x001EEF8E
		// (set) Token: 0x060021CB RID: 8651 RVA: 0x001F0D96 File Offset: 0x001EEF96
		public float Revs { get; private set; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060021CC RID: 8652 RVA: 0x001F0D9F File Offset: 0x001EEF9F
		// (set) Token: 0x060021CD RID: 8653 RVA: 0x001F0DA7 File Offset: 0x001EEFA7
		public float AccelInput { get; private set; }

		// Token: 0x060021CE RID: 8654 RVA: 0x001F0DB0 File Offset: 0x001EEFB0
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

		// Token: 0x060021CF RID: 8655 RVA: 0x001F0E3C File Offset: 0x001EF03C
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

		// Token: 0x060021D0 RID: 8656 RVA: 0x001F0EC4 File Offset: 0x001EF0C4
		private static float CurveFactor(float factor)
		{
			return 1f - (1f - factor) * (1f - factor);
		}

		// Token: 0x060021D1 RID: 8657 RVA: 0x001F0EDB File Offset: 0x001EF0DB
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x060021D2 RID: 8658 RVA: 0x001F0EEC File Offset: 0x001EF0EC
		private void CalculateGearFactor()
		{
			float num = 1f / (float)CarController.NoOfGears;
			float b = Mathf.InverseLerp(num * (float)this.m_GearNum, num * (float)(this.m_GearNum + 1), Mathf.Abs(this.CurrentSpeed / this.MaxSpeed));
			this.m_GearFactor = Mathf.Lerp(this.m_GearFactor, b, Time.deltaTime * 5f);
		}

		// Token: 0x060021D3 RID: 8659 RVA: 0x001F0F50 File Offset: 0x001EF150
		private void CalculateRevs()
		{
			this.CalculateGearFactor();
			float num = (float)this.m_GearNum / (float)CarController.NoOfGears;
			float from = CarController.ULerp(0f, this.m_RevRangeBoundary, CarController.CurveFactor(num));
			float to = CarController.ULerp(this.m_RevRangeBoundary, 1f, num);
			this.Revs = CarController.ULerp(from, to, this.m_GearFactor);
		}

		// Token: 0x060021D4 RID: 8660 RVA: 0x001F0FB0 File Offset: 0x001EF1B0
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

		// Token: 0x060021D5 RID: 8661 RVA: 0x001F10F4 File Offset: 0x001EF2F4
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

		// Token: 0x060021D6 RID: 8662 RVA: 0x001F11A8 File Offset: 0x001EF3A8
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

		// Token: 0x060021D7 RID: 8663 RVA: 0x001F12E8 File Offset: 0x001EF4E8
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

		// Token: 0x060021D8 RID: 8664 RVA: 0x001F13A4 File Offset: 0x001EF5A4
		private void AddDownForce()
		{
			this.m_WheelColliders[0].attachedRigidbody.AddForce(-base.transform.up * this.m_Downforce * this.m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
		}

		// Token: 0x060021D9 RID: 8665 RVA: 0x001F1400 File Offset: 0x001EF600
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

		// Token: 0x060021DA RID: 8666 RVA: 0x001F14A4 File Offset: 0x001EF6A4
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

		// Token: 0x060021DB RID: 8667 RVA: 0x001F156C File Offset: 0x001EF76C
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

		// Token: 0x060021DC RID: 8668 RVA: 0x001F15DC File Offset: 0x001EF7DC
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

		// Token: 0x04004A63 RID: 19043
		[SerializeField]
		private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;

		// Token: 0x04004A64 RID: 19044
		[SerializeField]
		private WheelCollider[] m_WheelColliders = new WheelCollider[4];

		// Token: 0x04004A65 RID: 19045
		[SerializeField]
		private GameObject[] m_WheelMeshes = new GameObject[4];

		// Token: 0x04004A66 RID: 19046
		[SerializeField]
		private WheelEffects[] m_WheelEffects = new WheelEffects[4];

		// Token: 0x04004A67 RID: 19047
		[SerializeField]
		private Vector3 m_CentreOfMassOffset;

		// Token: 0x04004A68 RID: 19048
		[SerializeField]
		private float m_MaximumSteerAngle;

		// Token: 0x04004A69 RID: 19049
		[Range(0f, 1f)]
		[SerializeField]
		private float m_SteerHelper;

		// Token: 0x04004A6A RID: 19050
		[Range(0f, 1f)]
		[SerializeField]
		private float m_TractionControl;

		// Token: 0x04004A6B RID: 19051
		[SerializeField]
		private float m_FullTorqueOverAllWheels;

		// Token: 0x04004A6C RID: 19052
		[SerializeField]
		private float m_ReverseTorque;

		// Token: 0x04004A6D RID: 19053
		[SerializeField]
		private float m_MaxHandbrakeTorque;

		// Token: 0x04004A6E RID: 19054
		[SerializeField]
		private float m_Downforce = 100f;

		// Token: 0x04004A6F RID: 19055
		[SerializeField]
		private SpeedType m_SpeedType;

		// Token: 0x04004A70 RID: 19056
		[SerializeField]
		private float m_Topspeed = 200f;

		// Token: 0x04004A71 RID: 19057
		[SerializeField]
		private static int NoOfGears = 5;

		// Token: 0x04004A72 RID: 19058
		[SerializeField]
		private float m_RevRangeBoundary = 1f;

		// Token: 0x04004A73 RID: 19059
		[SerializeField]
		private float m_SlipLimit;

		// Token: 0x04004A74 RID: 19060
		[SerializeField]
		private float m_BrakeTorque;

		// Token: 0x04004A75 RID: 19061
		private Quaternion[] m_WheelMeshLocalRotations;

		// Token: 0x04004A76 RID: 19062
		private Vector3 m_Prevpos;

		// Token: 0x04004A77 RID: 19063
		private Vector3 m_Pos;

		// Token: 0x04004A78 RID: 19064
		private float m_SteerAngle;

		// Token: 0x04004A79 RID: 19065
		private int m_GearNum;

		// Token: 0x04004A7A RID: 19066
		private float m_GearFactor;

		// Token: 0x04004A7B RID: 19067
		private float m_OldRotation;

		// Token: 0x04004A7C RID: 19068
		private float m_CurrentTorque;

		// Token: 0x04004A7D RID: 19069
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A7E RID: 19070
		private const float k_ReversingThreshold = 0.01f;
	}
}
