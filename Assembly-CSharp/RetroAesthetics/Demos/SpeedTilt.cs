using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054C RID: 1356
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x06002298 RID: 8856 RVA: 0x001EEF90 File Offset: 0x001ED190
		private void Start()
		{
			this._maxPositionY = base.transform.localPosition.y;
			this._lastPosition = base.transform.position;
			this._localPosition = base.transform.localPosition;
			this._localRotationYZ = new Vector2(base.transform.localRotation.eulerAngles.y, base.transform.localRotation.eulerAngles.z);
			this._maxRotationX = base.transform.localRotation.eulerAngles.x;
			this._camera = base.gameObject.GetComponentInChildren<Camera>();
			if (this._camera == null)
			{
				base.enabled = false;
				return;
			}
			this._minFOV = this._camera.fieldOfView;
		}

		// Token: 0x06002299 RID: 8857 RVA: 0x001EF068 File Offset: 0x001ED268
		private void FixedUpdate()
		{
			Vector3 vector = this._lastPosition - base.transform.position;
			if (Mathf.Abs(vector.y) < Mathf.Max(Mathf.Abs(vector.x), Mathf.Abs(vector.y)))
			{
				this._distance = vector.magnitude;
				if (this._distance > this.minSpeed && this._distance < this.maxSpeed)
				{
					float t = Mathf.Clamp01((this._distance - this.minSpeed) / (this.maxSpeed - this.minSpeed));
					this._localPosition.y = Mathf.SmoothStep(this._maxPositionY, this.minimumLocalPositionY, t);
					base.transform.localPosition = this._localPosition;
					float x = Mathf.SmoothStep(this._maxRotationX, this.minimumLocalRotationX, t);
					base.transform.localRotation = Quaternion.Euler(x, this._localRotationYZ.x, this._localRotationYZ.y);
					this._camera.fieldOfView = Mathf.SmoothStep(this._minFOV, this.maximumFOV, t);
				}
			}
			this._lastPosition = base.transform.position;
		}

		// Token: 0x04004AA5 RID: 19109
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004AA6 RID: 19110
		public float minimumLocalRotationX;

		// Token: 0x04004AA7 RID: 19111
		public float maximumFOV = 80f;

		// Token: 0x04004AA8 RID: 19112
		public float minSpeed = 0.5f;

		// Token: 0x04004AA9 RID: 19113
		public float maxSpeed = 1f;

		// Token: 0x04004AAA RID: 19114
		private float _maxPositionY;

		// Token: 0x04004AAB RID: 19115
		private float _maxRotationX;

		// Token: 0x04004AAC RID: 19116
		private Vector3 _lastPosition;

		// Token: 0x04004AAD RID: 19117
		private float _distance;

		// Token: 0x04004AAE RID: 19118
		private Vector3 _localPosition;

		// Token: 0x04004AAF RID: 19119
		private Vector2 _localRotationYZ;

		// Token: 0x04004AB0 RID: 19120
		private Camera _camera;

		// Token: 0x04004AB1 RID: 19121
		private float _minFOV;
	}
}
