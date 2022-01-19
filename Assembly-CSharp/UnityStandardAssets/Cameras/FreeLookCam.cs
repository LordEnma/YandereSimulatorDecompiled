using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000541 RID: 1345
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x06002269 RID: 8809 RVA: 0x001ED18C File Offset: 0x001EB38C
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x0600226A RID: 8810 RVA: 0x001ED1FE File Offset: 0x001EB3FE
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x001ED235 File Offset: 0x001EB435
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x001ED243 File Offset: 0x001EB443
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x0600226D RID: 8813 RVA: 0x001ED284 File Offset: 0x001EB484
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

		// Token: 0x04004A40 RID: 19008
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004A41 RID: 19009
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004A42 RID: 19010
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004A43 RID: 19011
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004A44 RID: 19012
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004A45 RID: 19013
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004A46 RID: 19014
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004A47 RID: 19015
		private float m_LookAngle;

		// Token: 0x04004A48 RID: 19016
		private float m_TiltAngle;

		// Token: 0x04004A49 RID: 19017
		private const float k_LookDistance = 100f;

		// Token: 0x04004A4A RID: 19018
		private Vector3 m_PivotEulers;

		// Token: 0x04004A4B RID: 19019
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004A4C RID: 19020
		private Quaternion m_TransformTargetRot;
	}
}
