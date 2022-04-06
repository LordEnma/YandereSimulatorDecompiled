using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054E RID: 1358
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x060022B8 RID: 8888 RVA: 0x001F36BC File Offset: 0x001F18BC
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x060022B9 RID: 8889 RVA: 0x001F372E File Offset: 0x001F192E
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x060022BA RID: 8890 RVA: 0x001F3765 File Offset: 0x001F1965
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x060022BB RID: 8891 RVA: 0x001F3773 File Offset: 0x001F1973
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x060022BC RID: 8892 RVA: 0x001F37B4 File Offset: 0x001F19B4
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

		// Token: 0x04004B1F RID: 19231
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004B20 RID: 19232
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004B21 RID: 19233
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004B22 RID: 19234
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004B23 RID: 19235
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004B24 RID: 19236
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004B25 RID: 19237
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004B26 RID: 19238
		private float m_LookAngle;

		// Token: 0x04004B27 RID: 19239
		private float m_TiltAngle;

		// Token: 0x04004B28 RID: 19240
		private const float k_LookDistance = 100f;

		// Token: 0x04004B29 RID: 19241
		private Vector3 m_PivotEulers;

		// Token: 0x04004B2A RID: 19242
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004B2B RID: 19243
		private Quaternion m_TransformTargetRot;
	}
}
