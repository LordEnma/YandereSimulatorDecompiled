using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000550 RID: 1360
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x060022D4 RID: 8916 RVA: 0x001F7258 File Offset: 0x001F5458
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x060022D5 RID: 8917 RVA: 0x001F72CA File Offset: 0x001F54CA
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x060022D6 RID: 8918 RVA: 0x001F7301 File Offset: 0x001F5501
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x060022D7 RID: 8919 RVA: 0x001F730F File Offset: 0x001F550F
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x060022D8 RID: 8920 RVA: 0x001F7350 File Offset: 0x001F5550
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

		// Token: 0x04004B77 RID: 19319
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004B78 RID: 19320
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004B79 RID: 19321
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004B7A RID: 19322
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004B7B RID: 19323
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004B7C RID: 19324
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004B7D RID: 19325
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004B7E RID: 19326
		private float m_LookAngle;

		// Token: 0x04004B7F RID: 19327
		private float m_TiltAngle;

		// Token: 0x04004B80 RID: 19328
		private const float k_LookDistance = 100f;

		// Token: 0x04004B81 RID: 19329
		private Vector3 m_PivotEulers;

		// Token: 0x04004B82 RID: 19330
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004B83 RID: 19331
		private Quaternion m_TransformTargetRot;
	}
}
