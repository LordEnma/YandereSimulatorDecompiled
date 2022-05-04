using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054F RID: 1359
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x060022C9 RID: 8905 RVA: 0x001F56A0 File Offset: 0x001F38A0
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x060022CA RID: 8906 RVA: 0x001F5712 File Offset: 0x001F3912
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x060022CB RID: 8907 RVA: 0x001F5749 File Offset: 0x001F3949
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x060022CC RID: 8908 RVA: 0x001F5757 File Offset: 0x001F3957
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x060022CD RID: 8909 RVA: 0x001F5798 File Offset: 0x001F3998
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

		// Token: 0x04004B47 RID: 19271
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004B48 RID: 19272
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004B49 RID: 19273
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004B4A RID: 19274
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004B4B RID: 19275
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004B4C RID: 19276
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004B4D RID: 19277
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004B4E RID: 19278
		private float m_LookAngle;

		// Token: 0x04004B4F RID: 19279
		private float m_TiltAngle;

		// Token: 0x04004B50 RID: 19280
		private const float k_LookDistance = 100f;

		// Token: 0x04004B51 RID: 19281
		private Vector3 m_PivotEulers;

		// Token: 0x04004B52 RID: 19282
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004B53 RID: 19283
		private Quaternion m_TransformTargetRot;
	}
}
