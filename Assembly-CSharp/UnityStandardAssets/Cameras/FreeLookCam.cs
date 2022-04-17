using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054E RID: 1358
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x060022BF RID: 8895 RVA: 0x001F4118 File Offset: 0x001F2318
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x060022C0 RID: 8896 RVA: 0x001F418A File Offset: 0x001F238A
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x060022C1 RID: 8897 RVA: 0x001F41C1 File Offset: 0x001F23C1
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x060022C2 RID: 8898 RVA: 0x001F41CF File Offset: 0x001F23CF
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x060022C3 RID: 8899 RVA: 0x001F4210 File Offset: 0x001F2410
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

		// Token: 0x04004B31 RID: 19249
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004B32 RID: 19250
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004B33 RID: 19251
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004B34 RID: 19252
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004B35 RID: 19253
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004B36 RID: 19254
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004B37 RID: 19255
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004B38 RID: 19256
		private float m_LookAngle;

		// Token: 0x04004B39 RID: 19257
		private float m_TiltAngle;

		// Token: 0x04004B3A RID: 19258
		private const float k_LookDistance = 100f;

		// Token: 0x04004B3B RID: 19259
		private Vector3 m_PivotEulers;

		// Token: 0x04004B3C RID: 19260
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004B3D RID: 19261
		private Quaternion m_TransformTargetRot;
	}
}
