using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053E RID: 1342
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x06002259 RID: 8793 RVA: 0x001EB52C File Offset: 0x001E972C
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x001EB59E File Offset: 0x001E979E
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x001EB5D5 File Offset: 0x001E97D5
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x001EB5E3 File Offset: 0x001E97E3
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x001EB624 File Offset: 0x001E9824
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

		// Token: 0x04004A1C RID: 18972
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004A1D RID: 18973
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004A1E RID: 18974
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004A1F RID: 18975
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004A20 RID: 18976
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004A21 RID: 18977
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004A22 RID: 18978
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004A23 RID: 18979
		private float m_LookAngle;

		// Token: 0x04004A24 RID: 18980
		private float m_TiltAngle;

		// Token: 0x04004A25 RID: 18981
		private const float k_LookDistance = 100f;

		// Token: 0x04004A26 RID: 18982
		private Vector3 m_PivotEulers;

		// Token: 0x04004A27 RID: 18983
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004A28 RID: 18984
		private Quaternion m_TransformTargetRot;
	}
}
