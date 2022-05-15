using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000550 RID: 1360
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x060022D3 RID: 8915 RVA: 0x001F6CF0 File Offset: 0x001F4EF0
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x060022D4 RID: 8916 RVA: 0x001F6D62 File Offset: 0x001F4F62
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x060022D5 RID: 8917 RVA: 0x001F6D99 File Offset: 0x001F4F99
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x060022D6 RID: 8918 RVA: 0x001F6DA7 File Offset: 0x001F4FA7
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x060022D7 RID: 8919 RVA: 0x001F6DE8 File Offset: 0x001F4FE8
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

		// Token: 0x04004B6E RID: 19310
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004B6F RID: 19311
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004B70 RID: 19312
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004B71 RID: 19313
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004B72 RID: 19314
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004B73 RID: 19315
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004B74 RID: 19316
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004B75 RID: 19317
		private float m_LookAngle;

		// Token: 0x04004B76 RID: 19318
		private float m_TiltAngle;

		// Token: 0x04004B77 RID: 19319
		private const float k_LookDistance = 100f;

		// Token: 0x04004B78 RID: 19320
		private Vector3 m_PivotEulers;

		// Token: 0x04004B79 RID: 19321
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004B7A RID: 19322
		private Quaternion m_TransformTargetRot;
	}
}
