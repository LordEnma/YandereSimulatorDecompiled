using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054C RID: 1356
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x0600229A RID: 8858 RVA: 0x001EF2A8 File Offset: 0x001ED4A8
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

		// Token: 0x0600229B RID: 8859 RVA: 0x001EF380 File Offset: 0x001ED580
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

		// Token: 0x04004AAB RID: 19115
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004AAC RID: 19116
		public float minimumLocalRotationX;

		// Token: 0x04004AAD RID: 19117
		public float maximumFOV = 80f;

		// Token: 0x04004AAE RID: 19118
		public float minSpeed = 0.5f;

		// Token: 0x04004AAF RID: 19119
		public float maxSpeed = 1f;

		// Token: 0x04004AB0 RID: 19120
		private float _maxPositionY;

		// Token: 0x04004AB1 RID: 19121
		private float _maxRotationX;

		// Token: 0x04004AB2 RID: 19122
		private Vector3 _lastPosition;

		// Token: 0x04004AB3 RID: 19123
		private float _distance;

		// Token: 0x04004AB4 RID: 19124
		private Vector3 _localPosition;

		// Token: 0x04004AB5 RID: 19125
		private Vector2 _localRotationYZ;

		// Token: 0x04004AB6 RID: 19126
		private Camera _camera;

		// Token: 0x04004AB7 RID: 19127
		private float _minFOV;
	}
}
