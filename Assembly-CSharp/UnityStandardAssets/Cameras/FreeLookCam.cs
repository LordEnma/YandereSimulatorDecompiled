using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054D RID: 1357
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x060022B0 RID: 8880 RVA: 0x001F318C File Offset: 0x001F138C
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x060022B1 RID: 8881 RVA: 0x001F31FE File Offset: 0x001F13FE
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x060022B2 RID: 8882 RVA: 0x001F3235 File Offset: 0x001F1435
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x060022B3 RID: 8883 RVA: 0x001F3243 File Offset: 0x001F1443
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x060022B4 RID: 8884 RVA: 0x001F3284 File Offset: 0x001F1484
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

		// Token: 0x04004B1B RID: 19227
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004B1C RID: 19228
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004B1D RID: 19229
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004B1E RID: 19230
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004B1F RID: 19231
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004B20 RID: 19232
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004B21 RID: 19233
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004B22 RID: 19234
		private float m_LookAngle;

		// Token: 0x04004B23 RID: 19235
		private float m_TiltAngle;

		// Token: 0x04004B24 RID: 19236
		private const float k_LookDistance = 100f;

		// Token: 0x04004B25 RID: 19237
		private Vector3 m_PivotEulers;

		// Token: 0x04004B26 RID: 19238
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004B27 RID: 19239
		private Quaternion m_TransformTargetRot;
	}
}
