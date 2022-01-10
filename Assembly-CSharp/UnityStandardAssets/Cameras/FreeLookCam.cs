using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000540 RID: 1344
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x06002267 RID: 8807 RVA: 0x001EC4BC File Offset: 0x001EA6BC
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x001EC52E File Offset: 0x001EA72E
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x06002269 RID: 8809 RVA: 0x001EC565 File Offset: 0x001EA765
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x0600226A RID: 8810 RVA: 0x001EC573 File Offset: 0x001EA773
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x001EC5B4 File Offset: 0x001EA7B4
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

		// Token: 0x04004A39 RID: 19001
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004A3A RID: 19002
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004A3B RID: 19003
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004A3C RID: 19004
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004A3D RID: 19005
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004A3E RID: 19006
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004A3F RID: 19007
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004A40 RID: 19008
		private float m_LookAngle;

		// Token: 0x04004A41 RID: 19009
		private float m_TiltAngle;

		// Token: 0x04004A42 RID: 19010
		private const float k_LookDistance = 100f;

		// Token: 0x04004A43 RID: 19011
		private Vector3 m_PivotEulers;

		// Token: 0x04004A44 RID: 19012
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004A45 RID: 19013
		private Quaternion m_TransformTargetRot;
	}
}
