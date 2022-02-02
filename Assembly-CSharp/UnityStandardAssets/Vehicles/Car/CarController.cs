using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000524 RID: 1316
	public class CarController : MonoBehaviour
	{
		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06002171 RID: 8561 RVA: 0x001EA647 File Offset: 0x001E8847
		// (set) Token: 0x06002172 RID: 8562 RVA: 0x001EA64F File Offset: 0x001E884F
		public bool Skidding { get; private set; }

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06002173 RID: 8563 RVA: 0x001EA658 File Offset: 0x001E8858
		// (set) Token: 0x06002174 RID: 8564 RVA: 0x001EA660 File Offset: 0x001E8860
		public float BrakeInput { get; private set; }

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06002175 RID: 8565 RVA: 0x001EA669 File Offset: 0x001E8869
		public float CurrentSteerAngle
		{
			get
			{
				return this.m_SteerAngle;
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06002176 RID: 8566 RVA: 0x001EA674 File Offset: 0x001E8874
		public float CurrentSpeed
		{
			get
			{
				return this.m_Rigidbody.velocity.magnitude * 2.2369363f;
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06002177 RID: 8567 RVA: 0x001EA69A File Offset: 0x001E889A
		public float MaxSpeed
		{
			get
			{
				return this.m_Topspeed;
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06002178 RID: 8568 RVA: 0x001EA6A2 File Offset: 0x001E88A2
		// (set) Token: 0x06002179 RID: 8569 RVA: 0x001EA6AA File Offset: 0x001E88AA
		public float Revs { get; private set; }

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x0600217A RID: 8570 RVA: 0x001EA6B3 File Offset: 0x001E88B3
		// (set) Token: 0x0600217B RID: 8571 RVA: 0x001EA6BB File Offset: 0x001E88BB
		public float AccelInput { get; private set; }

		// Token: 0x0600217C RID: 8572 RVA: 0x001EA6C4 File Offset: 0x001E88C4
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

		// Token: 0x0600217D RID: 8573 RVA: 0x001EA750 File Offset: 0x001E8950
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

		// Token: 0x0600217E RID: 8574 RVA: 0x001EA7D8 File Offset: 0x001E89D8
		private static float CurveFactor(float factor)
		{
			return 1f - (1f - factor) * (1f - factor);
		}

		// Token: 0x0600217F RID: 8575 RVA: 0x001EA7EF File Offset: 0x001E89EF
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x06002180 RID: 8576 RVA: 0x001EA800 File Offset: 0x001E8A00
		private void CalculateGearFactor()
		{
			float num = 1f / (float)CarController.NoOfGears;
			float b = Mathf.InverseLerp(num * (float)this.m_GearNum, num * (float)(this.m_GearNum + 1), Mathf.Abs(this.CurrentSpeed / this.MaxSpeed));
			this.m_GearFactor = Mathf.Lerp(this.m_GearFactor, b, Time.deltaTime * 5f);
		}

		// Token: 0x06002181 RID: 8577 RVA: 0x001EA864 File Offset: 0x001E8A64
		private void CalculateRevs()
		{
			this.CalculateGearFactor();
			float num = (float)this.m_GearNum / (float)CarController.NoOfGears;
			float from = CarController.ULerp(0f, this.m_RevRangeBoundary, CarController.CurveFactor(num));
			float to = CarController.ULerp(this.m_RevRangeBoundary, 1f, num);
			this.Revs = CarController.ULerp(from, to, this.m_GearFactor);
		}

		// Token: 0x06002182 RID: 8578 RVA: 0x001EA8C4 File Offset: 0x001E8AC4
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

		// Token: 0x06002183 RID: 8579 RVA: 0x001EAA08 File Offset: 0x001E8C08
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

		// Token: 0x06002184 RID: 8580 RVA: 0x001EAABC File Offset: 0x001E8CBC
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

		// Token: 0x06002185 RID: 8581 RVA: 0x001EABFC File Offset: 0x001E8DFC
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

		// Token: 0x06002186 RID: 8582 RVA: 0x001EACB8 File Offset: 0x001E8EB8
		private void AddDownForce()
		{
			this.m_WheelColliders[0].attachedRigidbody.AddForce(-base.transform.up * this.m_Downforce * this.m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
		}

		// Token: 0x06002187 RID: 8583 RVA: 0x001EAD14 File Offset: 0x001E8F14
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

		// Token: 0x06002188 RID: 8584 RVA: 0x001EADB8 File Offset: 0x001E8FB8
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

		// Token: 0x06002189 RID: 8585 RVA: 0x001EAE80 File Offset: 0x001E9080
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

		// Token: 0x0600218A RID: 8586 RVA: 0x001EAEF0 File Offset: 0x001E90F0
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

		// Token: 0x0400497D RID: 18813
		[SerializeField]
		private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;

		// Token: 0x0400497E RID: 18814
		[SerializeField]
		private WheelCollider[] m_WheelColliders = new WheelCollider[4];

		// Token: 0x0400497F RID: 18815
		[SerializeField]
		private GameObject[] m_WheelMeshes = new GameObject[4];

		// Token: 0x04004980 RID: 18816
		[SerializeField]
		private WheelEffects[] m_WheelEffects = new WheelEffects[4];

		// Token: 0x04004981 RID: 18817
		[SerializeField]
		private Vector3 m_CentreOfMassOffset;

		// Token: 0x04004982 RID: 18818
		[SerializeField]
		private float m_MaximumSteerAngle;

		// Token: 0x04004983 RID: 18819
		[Range(0f, 1f)]
		[SerializeField]
		private float m_SteerHelper;

		// Token: 0x04004984 RID: 18820
		[Range(0f, 1f)]
		[SerializeField]
		private float m_TractionControl;

		// Token: 0x04004985 RID: 18821
		[SerializeField]
		private float m_FullTorqueOverAllWheels;

		// Token: 0x04004986 RID: 18822
		[SerializeField]
		private float m_ReverseTorque;

		// Token: 0x04004987 RID: 18823
		[SerializeField]
		private float m_MaxHandbrakeTorque;

		// Token: 0x04004988 RID: 18824
		[SerializeField]
		private float m_Downforce = 100f;

		// Token: 0x04004989 RID: 18825
		[SerializeField]
		private SpeedType m_SpeedType;

		// Token: 0x0400498A RID: 18826
		[SerializeField]
		private float m_Topspeed = 200f;

		// Token: 0x0400498B RID: 18827
		[SerializeField]
		private static int NoOfGears = 5;

		// Token: 0x0400498C RID: 18828
		[SerializeField]
		private float m_RevRangeBoundary = 1f;

		// Token: 0x0400498D RID: 18829
		[SerializeField]
		private float m_SlipLimit;

		// Token: 0x0400498E RID: 18830
		[SerializeField]
		private float m_BrakeTorque;

		// Token: 0x0400498F RID: 18831
		private Quaternion[] m_WheelMeshLocalRotations;

		// Token: 0x04004990 RID: 18832
		private Vector3 m_Prevpos;

		// Token: 0x04004991 RID: 18833
		private Vector3 m_Pos;

		// Token: 0x04004992 RID: 18834
		private float m_SteerAngle;

		// Token: 0x04004993 RID: 18835
		private int m_GearNum;

		// Token: 0x04004994 RID: 18836
		private float m_GearFactor;

		// Token: 0x04004995 RID: 18837
		private float m_OldRotation;

		// Token: 0x04004996 RID: 18838
		private float m_CurrentTorque;

		// Token: 0x04004997 RID: 18839
		private Rigidbody m_Rigidbody;

		// Token: 0x04004998 RID: 18840
		private const float k_ReversingThreshold = 0.01f;
	}
}
