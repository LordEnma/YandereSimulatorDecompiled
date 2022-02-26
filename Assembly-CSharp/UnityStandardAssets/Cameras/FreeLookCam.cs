using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000543 RID: 1347
	public class FreeLookCam : PivotBasedCameraRig
	{
		// Token: 0x06002282 RID: 8834 RVA: 0x001EEFDC File Offset: 0x001ED1DC
		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !this.m_LockCursor;
			this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
			this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
			this.m_TransformTargetRot = base.transform.localRotation;
		}

		// Token: 0x06002283 RID: 8835 RVA: 0x001EF04E File Offset: 0x001ED24E
		protected void Update()
		{
			this.HandleRotationMovement();
			if (this.m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !this.m_LockCursor;
			}
		}

		// Token: 0x06002284 RID: 8836 RVA: 0x001EF085 File Offset: 0x001ED285
		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		// Token: 0x06002285 RID: 8837 RVA: 0x001EF093 File Offset: 0x001ED293
		protected override void FollowTarget(float deltaTime)
		{
			if (this.m_Target == null)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
		}

		// Token: 0x06002286 RID: 8838 RVA: 0x001EF0D4 File Offset: 0x001ED2D4
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

		// Token: 0x04004A6D RID: 19053
		[SerializeField]
		private float m_MoveSpeed = 1f;

		// Token: 0x04004A6E RID: 19054
		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		// Token: 0x04004A6F RID: 19055
		[SerializeField]
		private float m_TurnSmoothing;

		// Token: 0x04004A70 RID: 19056
		[SerializeField]
		private float m_TiltMax = 75f;

		// Token: 0x04004A71 RID: 19057
		[SerializeField]
		private float m_TiltMin = 45f;

		// Token: 0x04004A72 RID: 19058
		[SerializeField]
		private bool m_LockCursor;

		// Token: 0x04004A73 RID: 19059
		[SerializeField]
		private bool m_VerticalAutoReturn;

		// Token: 0x04004A74 RID: 19060
		private float m_LookAngle;

		// Token: 0x04004A75 RID: 19061
		private float m_TiltAngle;

		// Token: 0x04004A76 RID: 19062
		private const float k_LookDistance = 100f;

		// Token: 0x04004A77 RID: 19063
		private Vector3 m_PivotEulers;

		// Token: 0x04004A78 RID: 19064
		private Quaternion m_PivotTargetRot;

		// Token: 0x04004A79 RID: 19065
		private Quaternion m_TransformTargetRot;
	}
}
