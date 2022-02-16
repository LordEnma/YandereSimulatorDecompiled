using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000542 RID: 1346
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x06002279 RID: 8825 RVA: 0x001EE3FC File Offset: 0x001EC5FC
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x0600227A RID: 8826 RVA: 0x001EE46E File Offset: 0x001EC66E
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x0600227B RID: 8827 RVA: 0x001EE4A5 File Offset: 0x001EC6A5
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x0600227C RID: 8828 RVA: 0x001EE4B3 File Offset: 0x001EC6B3
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x0600227D RID: 8829 RVA: 0x001EE4F4 File Offset: 0x001EC6F4
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

		// Token: 0x04004A5D RID: 19037
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004A5E RID: 19038
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004A5F RID: 19039
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004A60 RID: 19040
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004A61 RID: 19041
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004A62 RID: 19042
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004A63 RID: 19043
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004A64 RID: 19044
		private float m_LookAngle;

		// Token: 0x04004A65 RID: 19045
		private float m_TiltAngle;

		// Token: 0x04004A66 RID: 19046
		private const float k_LookDistance = 100f;

		// Token: 0x04004A67 RID: 19047
		private Vector3 m_PivotEulers;

		// Token: 0x04004A68 RID: 19048
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004A69 RID: 19049
		private Quaternion m_TransformTargetRot;
	}
}
