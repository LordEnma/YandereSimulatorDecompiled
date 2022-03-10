using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054F RID: 1359
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x060022B3 RID: 8883 RVA: 0x001F0F18 File Offset: 0x001EF118
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

		// Token: 0x060022B4 RID: 8884 RVA: 0x001F0FF0 File Offset: 0x001EF1F0
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

		// Token: 0x04004AE4 RID: 19172
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004AE5 RID: 19173
		public float minimumLocalRotationX;

		// Token: 0x04004AE6 RID: 19174
		public float maximumFOV = 80f;

		// Token: 0x04004AE7 RID: 19175
		public float minSpeed = 0.5f;

		// Token: 0x04004AE8 RID: 19176
		public float maxSpeed = 1f;

		// Token: 0x04004AE9 RID: 19177
		private float _maxPositionY;

		// Token: 0x04004AEA RID: 19178
		private float _maxRotationX;

		// Token: 0x04004AEB RID: 19179
		private Vector3 _lastPosition;

		// Token: 0x04004AEC RID: 19180
		private float _distance;

		// Token: 0x04004AED RID: 19181
		private Vector3 _localPosition;

		// Token: 0x04004AEE RID: 19182
		private Vector2 _localRotationYZ;

		// Token: 0x04004AEF RID: 19183
		private Camera _camera;

		// Token: 0x04004AF0 RID: 19184
		private float _minFOV;
	}
}
