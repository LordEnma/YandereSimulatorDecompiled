using UnityEngine;

namespace UnityTemplateProjects
{
	public class SimpleCameraController : MonoBehaviour
	{
		private class CameraState
		{
			public float yaw;

			public float pitch;

			public float roll;

			public float x;

			public float y;

			public float z;

			public void SetFromTransform(Transform t)
			{
				pitch = t.eulerAngles.x;
				yaw = t.eulerAngles.y;
				roll = t.eulerAngles.z;
				x = t.position.x;
				y = t.position.y;
				z = t.position.z;
			}

			public void Translate(Vector3 translation)
			{
				Vector3 vector = Quaternion.Euler(pitch, yaw, roll) * translation;
				x += vector.x;
				y += vector.y;
				z += vector.z;
			}

			public void LerpTowards(CameraState target, float positionLerpPct, float rotationLerpPct)
			{
				yaw = Mathf.Lerp(yaw, target.yaw, rotationLerpPct);
				pitch = Mathf.Lerp(pitch, target.pitch, rotationLerpPct);
				roll = Mathf.Lerp(roll, target.roll, rotationLerpPct);
				x = Mathf.Lerp(x, target.x, positionLerpPct);
				y = Mathf.Lerp(y, target.y, positionLerpPct);
				z = Mathf.Lerp(z, target.z, positionLerpPct);
			}

			public void UpdateTransform(Transform t)
			{
				t.eulerAngles = new Vector3(pitch, yaw, roll);
				t.position = new Vector3(x, y, z);
			}
		}

		private CameraState m_TargetCameraState = new CameraState();

		private CameraState m_InterpolatingCameraState = new CameraState();

		[Header("Movement Settings")]
		[Tooltip("Exponential boost factor on translation, controllable by mouse wheel.")]
		public float boost = 3.5f;

		[Tooltip("Time it takes to interpolate camera position 99% of the way to the target.")]
		[Range(0.001f, 1f)]
		public float positionLerpTime = 0.2f;

		[Header("Rotation Settings")]
		[Tooltip("X = Change in mouse position.\nY = Multiplicative factor for camera rotation.")]
		public AnimationCurve mouseSensitivityCurve = new AnimationCurve(new Keyframe(0f, 0.5f, 0f, 5f), new Keyframe(1f, 2.5f, 0f, 0f));

		[Tooltip("Time it takes to interpolate camera rotation 99% of the way to the target.")]
		[Range(0.001f, 1f)]
		public float rotationLerpTime = 0.01f;

		[Tooltip("Whether or not to invert our Y axis for mouse input to rotation.")]
		public bool invertY;

		private void OnEnable()
		{
			m_TargetCameraState.SetFromTransform(base.transform);
			m_InterpolatingCameraState.SetFromTransform(base.transform);
		}

		private Vector3 GetInputTranslationDirection()
		{
			Vector3 result = default(Vector3);
			if (Input.GetKey(KeyCode.W))
			{
				result += Vector3.forward;
			}
			if (Input.GetKey(KeyCode.S))
			{
				result += Vector3.back;
			}
			if (Input.GetKey(KeyCode.A))
			{
				result += Vector3.left;
			}
			if (Input.GetKey(KeyCode.D))
			{
				result += Vector3.right;
			}
			if (Input.GetKey(KeyCode.Q))
			{
				result += Vector3.down;
			}
			if (Input.GetKey(KeyCode.E))
			{
				result += Vector3.up;
			}
			return result;
		}

		private void Update()
		{
			if (Input.GetKey(KeyCode.Escape))
			{
				Application.Quit();
			}
			if (Input.GetMouseButtonDown(1))
			{
				Cursor.lockState = CursorLockMode.Locked;
			}
			if (Input.GetMouseButtonUp(1))
			{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
			}
			if (Input.GetMouseButton(1))
			{
				Vector2 vector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y") * (float)(invertY ? 1 : (-1)));
				float num = mouseSensitivityCurve.Evaluate(vector.magnitude);
				m_TargetCameraState.yaw += vector.x * num;
				m_TargetCameraState.pitch += vector.y * num;
			}
			Vector3 translation = GetInputTranslationDirection() * Time.deltaTime;
			if (Input.GetKey(KeyCode.LeftShift))
			{
				translation *= 10f;
			}
			boost += Input.mouseScrollDelta.y * 0.2f;
			translation *= Mathf.Pow(2f, boost);
			m_TargetCameraState.Translate(translation);
			float positionLerpPct = 1f - Mathf.Exp(Mathf.Log(0.00999999f) / positionLerpTime * Time.deltaTime);
			float rotationLerpPct = 1f - Mathf.Exp(Mathf.Log(0.00999999f) / rotationLerpTime * Time.deltaTime);
			m_InterpolatingCameraState.LerpTowards(m_TargetCameraState, positionLerpPct, rotationLerpPct);
			m_InterpolatingCameraState.UpdateTransform(base.transform);
		}
	}
}
