using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200055B RID: 1371
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x060022FF RID: 8959 RVA: 0x001F87BC File Offset: 0x001F69BC
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

		// Token: 0x06002300 RID: 8960 RVA: 0x001F8894 File Offset: 0x001F6A94
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

		// Token: 0x04004BD1 RID: 19409
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004BD2 RID: 19410
		public float minimumLocalRotationX;

		// Token: 0x04004BD3 RID: 19411
		public float maximumFOV = 80f;

		// Token: 0x04004BD4 RID: 19412
		public float minSpeed = 0.5f;

		// Token: 0x04004BD5 RID: 19413
		public float maxSpeed = 1f;

		// Token: 0x04004BD6 RID: 19414
		private float _maxPositionY;

		// Token: 0x04004BD7 RID: 19415
		private float _maxRotationX;

		// Token: 0x04004BD8 RID: 19416
		private Vector3 _lastPosition;

		// Token: 0x04004BD9 RID: 19417
		private float _distance;

		// Token: 0x04004BDA RID: 19418
		private Vector3 _localPosition;

		// Token: 0x04004BDB RID: 19419
		private Vector2 _localRotationYZ;

		// Token: 0x04004BDC RID: 19420
		private Camera _camera;

		// Token: 0x04004BDD RID: 19421
		private float _minFOV;
	}
}
