using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000548 RID: 1352
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x060022A0 RID: 8864 RVA: 0x001F191C File Offset: 0x001EFB1C
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x060022A1 RID: 8865 RVA: 0x001F198E File Offset: 0x001EFB8E
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x060022A2 RID: 8866 RVA: 0x001F19C5 File Offset: 0x001EFBC5
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x060022A3 RID: 8867 RVA: 0x001F19D3 File Offset: 0x001EFBD3
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x060022A4 RID: 8868 RVA: 0x001F1A14 File Offset: 0x001EFC14
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

		// Token: 0x04004AE9 RID: 19177
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004AEA RID: 19178
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004AEB RID: 19179
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004AEC RID: 19180
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004AED RID: 19181
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004AEE RID: 19182
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004AEF RID: 19183
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004AF0 RID: 19184
		private float m_LookAngle;

		// Token: 0x04004AF1 RID: 19185
		private float m_TiltAngle;

		// Token: 0x04004AF2 RID: 19186
		private const float k_LookDistance = 100f;

		// Token: 0x04004AF3 RID: 19187
		private Vector3 m_PivotEulers;

		// Token: 0x04004AF4 RID: 19188
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004AF5 RID: 19189
		private Quaternion m_TransformTargetRot;
	}
}
