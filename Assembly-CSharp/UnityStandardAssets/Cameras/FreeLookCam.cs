using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	public class FreeLookCam : PivotBasedCameraRig
	{
		[SerializeField]
		private float m_MoveSpeed = 1f;

		[Range(0f, 10f)]
		[SerializeField]
		private float m_TurnSpeed = 1.5f;

		[SerializeField]
		private float m_TurnSmoothing;

		[SerializeField]
		private float m_TiltMax = 75f;

		[SerializeField]
		private float m_TiltMin = 45f;

		[SerializeField]
		private bool m_LockCursor;

		[SerializeField]
		private bool m_VerticalAutoReturn;

		private float m_LookAngle;

		private float m_TiltAngle;

		private const float k_LookDistance = 100f;

		private Vector3 m_PivotEulers;

		private Quaternion m_PivotTargetRot;

		private Quaternion m_TransformTargetRot;

		protected override void Awake()
		{
			base.Awake();
			Cursor.lockState = (m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !m_LockCursor;
			m_PivotEulers = m_Pivot.rotation.eulerAngles;
			m_PivotTargetRot = m_Pivot.transform.localRotation;
			m_TransformTargetRot = base.transform.localRotation;
		}

		protected void Update()
		{
			HandleRotationMovement();
			if (m_LockCursor && Input.GetMouseButtonUp(0))
			{
				Cursor.lockState = (m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				Cursor.visible = !m_LockCursor;
			}
		}

		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		protected override void FollowTarget(float deltaTime)
		{
			if (!(m_Target == null))
			{
				base.transform.position = Vector3.Lerp(base.transform.position, m_Target.position, deltaTime * m_MoveSpeed);
			}
		}

		private void HandleRotationMovement()
		{
			if (!(Time.timeScale < float.Epsilon))
			{
				float axis = CrossPlatformInputManager.GetAxis("Mouse X");
				float axis2 = CrossPlatformInputManager.GetAxis("Mouse Y");
				m_LookAngle += axis * m_TurnSpeed;
				m_TransformTargetRot = Quaternion.Euler(0f, m_LookAngle, 0f);
				if (m_VerticalAutoReturn)
				{
					m_TiltAngle = ((axis2 > 0f) ? Mathf.Lerp(0f, 0f - m_TiltMin, axis2) : Mathf.Lerp(0f, m_TiltMax, 0f - axis2));
				}
				else
				{
					m_TiltAngle -= axis2 * m_TurnSpeed;
					m_TiltAngle = Mathf.Clamp(m_TiltAngle, 0f - m_TiltMin, m_TiltMax);
				}
				m_PivotTargetRot = Quaternion.Euler(m_TiltAngle, m_PivotEulers.y, m_PivotEulers.z);
				if (m_TurnSmoothing > 0f)
				{
					m_Pivot.localRotation = Quaternion.Slerp(m_Pivot.localRotation, m_PivotTargetRot, m_TurnSmoothing * Time.deltaTime);
					base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, m_TransformTargetRot, m_TurnSmoothing * Time.deltaTime);
				}
				else
				{
					m_Pivot.localRotation = m_PivotTargetRot;
					base.transform.localRotation = m_TransformTargetRot;
				}
			}
		}
	}
}
