using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052B RID: 1323
	public class CarController : MonoBehaviour
	{
		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x060021A4 RID: 8612 RVA: 0x001EE537 File Offset: 0x001EC737
		// (set) Token: 0x060021A5 RID: 8613 RVA: 0x001EE53F File Offset: 0x001EC73F
		public bool Skidding { get; private set; }

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x060021A6 RID: 8614 RVA: 0x001EE548 File Offset: 0x001EC748
		// (set) Token: 0x060021A7 RID: 8615 RVA: 0x001EE550 File Offset: 0x001EC750
		public float BrakeInput { get; private set; }

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x060021A8 RID: 8616 RVA: 0x001EE559 File Offset: 0x001EC759
		public float CurrentSteerAngle
		{
			get
			{
				return this.m_SteerAngle;
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x060021A9 RID: 8617 RVA: 0x001EE564 File Offset: 0x001EC764
		public float CurrentSpeed
		{
			get
			{
				return this.m_Rigidbody.velocity.magnitude * 2.2369363f;
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x060021AA RID: 8618 RVA: 0x001EE58A File Offset: 0x001EC78A
		public float MaxSpeed
		{
			get
			{
				return this.m_Topspeed;
			}
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x060021AB RID: 8619 RVA: 0x001EE592 File Offset: 0x001EC792
		// (set) Token: 0x060021AC RID: 8620 RVA: 0x001EE59A File Offset: 0x001EC79A
		public float Revs { get; private set; }

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060021AD RID: 8621 RVA: 0x001EE5A3 File Offset: 0x001EC7A3
		// (set) Token: 0x060021AE RID: 8622 RVA: 0x001EE5AB File Offset: 0x001EC7AB
		public float AccelInput { get; private set; }

		// Token: 0x060021AF RID: 8623 RVA: 0x001EE5B4 File Offset: 0x001EC7B4
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

		// Token: 0x060021B0 RID: 8624 RVA: 0x001EE640 File Offset: 0x001EC840
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

		// Token: 0x060021B1 RID: 8625 RVA: 0x001EE6C8 File Offset: 0x001EC8C8
		private static float CurveFactor(float factor)
		{
			return 1f - (1f - factor) * (1f - factor);
		}

		// Token: 0x060021B2 RID: 8626 RVA: 0x001EE6DF File Offset: 0x001EC8DF
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x060021B3 RID: 8627 RVA: 0x001EE6F0 File Offset: 0x001EC8F0
		private void CalculateGearFactor()
		{
			float num = 1f / (float)CarController.NoOfGears;
			float b = Mathf.InverseLerp(num * (float)this.m_GearNum, num * (float)(this.m_GearNum + 1), Mathf.Abs(this.CurrentSpeed / this.MaxSpeed));
			this.m_GearFactor = Mathf.Lerp(this.m_GearFactor, b, Time.deltaTime * 5f);
		}

		// Token: 0x060021B4 RID: 8628 RVA: 0x001EE754 File Offset: 0x001EC954
		private void CalculateRevs()
		{
			this.CalculateGearFactor();
			float num = (float)this.m_GearNum / (float)CarController.NoOfGears;
			float from = CarController.ULerp(0f, this.m_RevRangeBoundary, CarController.CurveFactor(num));
			float to = CarController.ULerp(this.m_RevRangeBoundary, 1f, num);
			this.Revs = CarController.ULerp(from, to, this.m_GearFactor);
		}

		// Token: 0x060021B5 RID: 8629 RVA: 0x001EE7B4 File Offset: 0x001EC9B4
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

		// Token: 0x060021B6 RID: 8630 RVA: 0x001EE8F8 File Offset: 0x001ECAF8
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

		// Token: 0x060021B7 RID: 8631 RVA: 0x001EE9AC File Offset: 0x001ECBAC
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

		// Token: 0x060021B8 RID: 8632 RVA: 0x001EEAEC File Offset: 0x001ECCEC
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

		// Token: 0x060021B9 RID: 8633 RVA: 0x001EEBA8 File Offset: 0x001ECDA8
		private void AddDownForce()
		{
			this.m_WheelColliders[0].attachedRigidbody.AddForce(-base.transform.up * this.m_Downforce * this.m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
		}

		// Token: 0x060021BA RID: 8634 RVA: 0x001EEC04 File Offset: 0x001ECE04
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

		// Token: 0x060021BB RID: 8635 RVA: 0x001EECA8 File Offset: 0x001ECEA8
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

		// Token: 0x060021BC RID: 8636 RVA: 0x001EED70 File Offset: 0x001ECF70
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

		// Token: 0x060021BD RID: 8637 RVA: 0x001EEDE0 File Offset: 0x001ECFE0
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

		// Token: 0x04004A1B RID: 18971
		[SerializeField]
		private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;

		// Token: 0x04004A1C RID: 18972
		[SerializeField]
		private WheelCollider[] m_WheelColliders = new WheelCollider[4];

		// Token: 0x04004A1D RID: 18973
		[SerializeField]
		private GameObject[] m_WheelMeshes = new GameObject[4];

		// Token: 0x04004A1E RID: 18974
		[SerializeField]
		private WheelEffects[] m_WheelEffects = new WheelEffects[4];

		// Token: 0x04004A1F RID: 18975
		[SerializeField]
		private Vector3 m_CentreOfMassOffset;

		// Token: 0x04004A20 RID: 18976
		[SerializeField]
		private float m_MaximumSteerAngle;

		// Token: 0x04004A21 RID: 18977
		[Range(0f, 1f)]
		[SerializeField]
		private float m_SteerHelper;

		// Token: 0x04004A22 RID: 18978
		[Range(0f, 1f)]
		[SerializeField]
		private float m_TractionControl;

		// Token: 0x04004A23 RID: 18979
		[SerializeField]
		private float m_FullTorqueOverAllWheels;

		// Token: 0x04004A24 RID: 18980
		[SerializeField]
		private float m_ReverseTorque;

		// Token: 0x04004A25 RID: 18981
		[SerializeField]
		private float m_MaxHandbrakeTorque;

		// Token: 0x04004A26 RID: 18982
		[SerializeField]
		private float m_Downforce = 100f;

		// Token: 0x04004A27 RID: 18983
		[SerializeField]
		private SpeedType m_SpeedType;

		// Token: 0x04004A28 RID: 18984
		[SerializeField]
		private float m_Topspeed = 200f;

		// Token: 0x04004A29 RID: 18985
		[SerializeField]
		private static int NoOfGears = 5;

		// Token: 0x04004A2A RID: 18986
		[SerializeField]
		private float m_RevRangeBoundary = 1f;

		// Token: 0x04004A2B RID: 18987
		[SerializeField]
		private float m_SlipLimit;

		// Token: 0x04004A2C RID: 18988
		[SerializeField]
		private float m_BrakeTorque;

		// Token: 0x04004A2D RID: 18989
		private Quaternion[] m_WheelMeshLocalRotations;

		// Token: 0x04004A2E RID: 18990
		private Vector3 m_Prevpos;

		// Token: 0x04004A2F RID: 18991
		private Vector3 m_Pos;

		// Token: 0x04004A30 RID: 18992
		private float m_SteerAngle;

		// Token: 0x04004A31 RID: 18993
		private int m_GearNum;

		// Token: 0x04004A32 RID: 18994
		private float m_GearFactor;

		// Token: 0x04004A33 RID: 18995
		private float m_OldRotation;

		// Token: 0x04004A34 RID: 18996
		private float m_CurrentTorque;

		// Token: 0x04004A35 RID: 18997
		private Rigidbody m_Rigidbody;

		// Token: 0x04004A36 RID: 18998
		private const float k_ReversingThreshold = 0.01f;
	}
}
