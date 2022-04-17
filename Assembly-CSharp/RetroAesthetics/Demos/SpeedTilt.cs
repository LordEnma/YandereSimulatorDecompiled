using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000559 RID: 1369
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x060022EA RID: 8938 RVA: 0x001F567C File Offset: 0x001F387C
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

		// Token: 0x060022EB RID: 8939 RVA: 0x001F5754 File Offset: 0x001F3954
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

		// Token: 0x04004B8B RID: 19339
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004B8C RID: 19340
		public float minimumLocalRotationX;

		// Token: 0x04004B8D RID: 19341
		public float maximumFOV = 80f;

		// Token: 0x04004B8E RID: 19342
		public float minSpeed = 0.5f;

		// Token: 0x04004B8F RID: 19343
		public float maxSpeed = 1f;

		// Token: 0x04004B90 RID: 19344
		private float _maxPositionY;

		// Token: 0x04004B91 RID: 19345
		private float _maxRotationX;

		// Token: 0x04004B92 RID: 19346
		private Vector3 _lastPosition;

		// Token: 0x04004B93 RID: 19347
		private float _distance;

		// Token: 0x04004B94 RID: 19348
		private Vector3 _localPosition;

		// Token: 0x04004B95 RID: 19349
		private Vector2 _localRotationYZ;

		// Token: 0x04004B96 RID: 19350
		private Camera _camera;

		// Token: 0x04004B97 RID: 19351
		private float _minFOV;
	}
}
