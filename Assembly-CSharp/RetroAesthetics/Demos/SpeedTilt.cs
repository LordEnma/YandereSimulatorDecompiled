using UnityEngine;

namespace RetroAesthetics.Demos
{
	public class SpeedTilt : MonoBehaviour
	{
		public float minimumLocalPositionY = 1f;

		public float minimumLocalRotationX;

		public float maximumFOV = 80f;

		public float minSpeed = 0.5f;

		public float maxSpeed = 1f;

		private float _maxPositionY;

		private float _maxRotationX;

		private Vector3 _lastPosition;

		private float _distance;

		private Vector3 _localPosition;

		private Vector2 _localRotationYZ;

		private Camera _camera;

		private float _minFOV;

		private void Start()
		{
			_maxPositionY = base.transform.localPosition.y;
			_lastPosition = base.transform.position;
			_localPosition = base.transform.localPosition;
			_localRotationYZ = new Vector2(base.transform.localRotation.eulerAngles.y, base.transform.localRotation.eulerAngles.z);
			_maxRotationX = base.transform.localRotation.eulerAngles.x;
			_camera = base.gameObject.GetComponentInChildren<Camera>();
			if (_camera == null)
			{
				base.enabled = false;
			}
			else
			{
				_minFOV = _camera.fieldOfView;
			}
		}

		private void FixedUpdate()
		{
			Vector3 vector = _lastPosition - base.transform.position;
			if (Mathf.Abs(vector.y) < Mathf.Max(Mathf.Abs(vector.x), Mathf.Abs(vector.y)))
			{
				_distance = vector.magnitude;
				if (_distance > minSpeed && _distance < maxSpeed)
				{
					float t = Mathf.Clamp01((_distance - minSpeed) / (maxSpeed - minSpeed));
					_localPosition.y = Mathf.SmoothStep(_maxPositionY, minimumLocalPositionY, t);
					base.transform.localPosition = _localPosition;
					float x = Mathf.SmoothStep(_maxRotationX, minimumLocalRotationX, t);
					base.transform.localRotation = Quaternion.Euler(x, _localRotationYZ.x, _localRotationYZ.y);
					_camera.fieldOfView = Mathf.SmoothStep(_minFOV, maximumFOV, t);
				}
			}
			_lastPosition = base.transform.position;
		}
	}
}
