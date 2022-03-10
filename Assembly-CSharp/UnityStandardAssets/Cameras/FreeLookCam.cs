using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000544 RID: 1348
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x06002288 RID: 8840 RVA: 0x001EF9B4 File Offset: 0x001EDBB4
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x06002289 RID: 8841 RVA: 0x001EFA26 File Offset: 0x001EDC26
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x0600228A RID: 8842 RVA: 0x001EFA5D File Offset: 0x001EDC5D
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x0600228B RID: 8843 RVA: 0x001EFA6B File Offset: 0x001EDC6B
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x0600228C RID: 8844 RVA: 0x001EFAAC File Offset: 0x001EDCAC
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

		// Token: 0x04004A8A RID: 19082
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004A8B RID: 19083
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004A8C RID: 19084
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004A8D RID: 19085
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004A8E RID: 19086
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004A8F RID: 19087
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004A90 RID: 19088
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004A91 RID: 19089
		private float m_LookAngle;

		// Token: 0x04004A92 RID: 19090
		private float m_TiltAngle;

		// Token: 0x04004A93 RID: 19091
		private const float k_LookDistance = 100f;

		// Token: 0x04004A94 RID: 19092
		private Vector3 m_PivotEulers;

		// Token: 0x04004A95 RID: 19093
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004A96 RID: 19094
		private Quaternion m_TransformTargetRot;
	}
}
