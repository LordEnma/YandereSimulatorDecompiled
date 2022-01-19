using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054C RID: 1356
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x06002294 RID: 8852 RVA: 0x001EE6F0 File Offset: 0x001EC8F0
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

		// Token: 0x06002295 RID: 8853 RVA: 0x001EE7C8 File Offset: 0x001EC9C8
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

		// Token: 0x04004A9A RID: 19098
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004A9B RID: 19099
		public float minimumLocalRotationX;

		// Token: 0x04004A9C RID: 19100
		public float maximumFOV = 80f;

		// Token: 0x04004A9D RID: 19101
		public float minSpeed = 0.5f;

		// Token: 0x04004A9E RID: 19102
		public float maxSpeed = 1f;

		// Token: 0x04004A9F RID: 19103
		private float _maxPositionY;

		// Token: 0x04004AA0 RID: 19104
		private float _maxRotationX;

		// Token: 0x04004AA1 RID: 19105
		private Vector3 _lastPosition;

		// Token: 0x04004AA2 RID: 19106
		private float _distance;

		// Token: 0x04004AA3 RID: 19107
		private Vector3 _localPosition;

		// Token: 0x04004AA4 RID: 19108
		private Vector2 _localRotationYZ;

		// Token: 0x04004AA5 RID: 19109
		private Camera _camera;

		// Token: 0x04004AA6 RID: 19110
		private float _minFOV;
	}
}
