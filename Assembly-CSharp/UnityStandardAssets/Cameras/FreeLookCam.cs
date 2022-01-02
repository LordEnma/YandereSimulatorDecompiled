using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053E RID: 1342
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x0600225C RID: 8796 RVA: 0x001EBB1C File Offset: 0x001E9D1C
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x001EBB8E File Offset: 0x001E9D8E
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x001EBBC5 File Offset: 0x001E9DC5
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x001EBBD3 File Offset: 0x001E9DD3
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x001EBC14 File Offset: 0x001E9E14
		private void HandleRotationMovement()
		{
			if (Time.timeScale < 1E-45f)
			{
				return;
			}
			float axis = CrossPlatformInputManager.GetAxis("Mouse X");
			float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
			this.m_LookAngle += axis * this.m_TurnSpeed;
			this.m_TransformTargetRot = Quaternion.Euler(0f, this.m_LookAngle, 0f);
			if (this.m_VerticalAutoReturn)
			{
				this.m_TiltAngle = ((axis2 > 0f) ? Mathf.Lerp(0f, -this.m_TiltMin, axis2) : Mathf.Lerp(0f, this.m_TiltMax, -axis2));
			}
			else
			{
				this.m_TiltAngle -= axis2 * this.m_TurnSpeed;
				this.m_TiltAngle = Mathf.Clamp(this.m_TiltAngle, -this.m_TiltMin, this.m_TiltMax);
			}
			this.m_PivotTargetRot = Quaternion.Euler(this.m_TiltAngle, this.m_PivotEulers.y, this.m_PivotEulers.z);
			if (this.m_TurnSmoothing > 0f)
			{
				this.m_Pivot.localRotation = Quaternion.Slerp(this.m_Pivot.localRotation, this.m_PivotTargetRot, this.m_TurnSmoothing * Time.deltaTime);
				base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, this.m_TransformTargetRot, this.m_TurnSmoothing * Time.deltaTime);
				return;
			}
			this.m_Pivot.localRotation = this.m_PivotTargetRot;
			base.transform.localRotation = this.m_TransformTargetRot;
		}

		// Token: 0x04004A25 RID: 18981
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004A26 RID: 18982
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004A27 RID: 18983
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004A28 RID: 18984
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004A29 RID: 18985
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004A2A RID: 18986
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004A2B RID: 18987
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004A2C RID: 18988
		private float m_LookAngle;

		// Token: 0x04004A2D RID: 18989
		private float m_TiltAngle;

		// Token: 0x04004A2E RID: 18990
		private const float k_LookDistance = 100f;

		// Token: 0x04004A2F RID: 18991
		private Vector3 m_PivotEulers;

		// Token: 0x04004A30 RID: 18992
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004A31 RID: 18993
		private Quaternion m_TransformTargetRot;
	}
}
