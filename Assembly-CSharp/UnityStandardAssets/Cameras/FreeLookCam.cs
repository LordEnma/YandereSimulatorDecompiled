using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000541 RID: 1345
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x0600226F RID: 8815 RVA: 0x001EDD44 File Offset: 0x001EBF44
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x06002270 RID: 8816 RVA: 0x001EDDB6 File Offset: 0x001EBFB6
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x06002271 RID: 8817 RVA: 0x001EDDED File Offset: 0x001EBFED
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x06002272 RID: 8818 RVA: 0x001EDDFB File Offset: 0x001EBFFB
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x06002273 RID: 8819 RVA: 0x001EDE3C File Offset: 0x001EC03C
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

		// Token: 0x04004A51 RID: 19025
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004A52 RID: 19026
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004A53 RID: 19027
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004A54 RID: 19028
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004A55 RID: 19029
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004A56 RID: 19030
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004A57 RID: 19031
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004A58 RID: 19032
		private float m_LookAngle;

		// Token: 0x04004A59 RID: 19033
		private float m_TiltAngle;

		// Token: 0x04004A5A RID: 19034
		private const float k_LookDistance = 100f;

		// Token: 0x04004A5B RID: 19035
		private Vector3 m_PivotEulers;

		// Token: 0x04004A5C RID: 19036
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004A5D RID: 19037
		private Quaternion m_TransformTargetRot;
	}
}
