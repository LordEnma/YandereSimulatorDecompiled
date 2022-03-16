using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000553 RID: 1363
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x060022CB RID: 8907 RVA: 0x001F2E80 File Offset: 0x001F1080
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

		// Token: 0x060022CC RID: 8908 RVA: 0x001F2F58 File Offset: 0x001F1158
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

		// Token: 0x04004B43 RID: 19267
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004B44 RID: 19268
		public float minimumLocalRotationX;

		// Token: 0x04004B45 RID: 19269
		public float maximumFOV = 80f;

		// Token: 0x04004B46 RID: 19270
		public float minSpeed = 0.5f;

		// Token: 0x04004B47 RID: 19271
		public float maxSpeed = 1f;

		// Token: 0x04004B48 RID: 19272
		private float _maxPositionY;

		// Token: 0x04004B49 RID: 19273
		private float _maxRotationX;

		// Token: 0x04004B4A RID: 19274
		private Vector3 _lastPosition;

		// Token: 0x04004B4B RID: 19275
		private float _distance;

		// Token: 0x04004B4C RID: 19276
		private Vector3 _localPosition;

		// Token: 0x04004B4D RID: 19277
		private Vector2 _localRotationYZ;

		// Token: 0x04004B4E RID: 19278
		private Camera _camera;

		// Token: 0x04004B4F RID: 19279
		private float _minFOV;
	}
}
