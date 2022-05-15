using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200055B RID: 1371
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x060022FE RID: 8958 RVA: 0x001F8254 File Offset: 0x001F6454
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

		// Token: 0x060022FF RID: 8959 RVA: 0x001F832C File Offset: 0x001F652C
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

		// Token: 0x04004BC8 RID: 19400
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004BC9 RID: 19401
		public float minimumLocalRotationX;

		// Token: 0x04004BCA RID: 19402
		public float maximumFOV = 80f;

		// Token: 0x04004BCB RID: 19403
		public float minSpeed = 0.5f;

		// Token: 0x04004BCC RID: 19404
		public float maxSpeed = 1f;

		// Token: 0x04004BCD RID: 19405
		private float _maxPositionY;

		// Token: 0x04004BCE RID: 19406
		private float _maxRotationX;

		// Token: 0x04004BCF RID: 19407
		private Vector3 _lastPosition;

		// Token: 0x04004BD0 RID: 19408
		private float _distance;

		// Token: 0x04004BD1 RID: 19409
		private Vector3 _localPosition;

		// Token: 0x04004BD2 RID: 19410
		private Vector2 _localRotationYZ;

		// Token: 0x04004BD3 RID: 19411
		private Camera _camera;

		// Token: 0x04004BD4 RID: 19412
		private float _minFOV;
	}
}
