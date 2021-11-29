using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053C RID: 1340
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x06002248 RID: 8776 RVA: 0x001E9DF8 File Offset: 0x001E7FF8
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x06002249 RID: 8777 RVA: 0x001E9E6A File Offset: 0x001E806A
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x0600224A RID: 8778 RVA: 0x001E9EA1 File Offset: 0x001E80A1
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x0600224B RID: 8779 RVA: 0x001E9EAF File Offset: 0x001E80AF
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x001E9EF0 File Offset: 0x001E80F0
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

		// Token: 0x040049DD RID: 18909
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x040049DE RID: 18910
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x040049DF RID: 18911
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x040049E0 RID: 18912
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x040049E1 RID: 18913
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x040049E2 RID: 18914
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x040049E3 RID: 18915
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x040049E4 RID: 18916
		private float m_LookAngle;

		// Token: 0x040049E5 RID: 18917
		private float m_TiltAngle;

		// Token: 0x040049E6 RID: 18918
		private const float k_LookDistance = 100f;

		// Token: 0x040049E7 RID: 18919
		private Vector3 m_PivotEulers;

		// Token: 0x040049E8 RID: 18920
		private Quaternion m_PivotTargetRot;

		// Token: 0x040049E9 RID: 18921
		private Quaternion m_TransformTargetRot;
	}
}
