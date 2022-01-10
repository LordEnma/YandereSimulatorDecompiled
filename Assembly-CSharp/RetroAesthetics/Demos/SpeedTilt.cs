using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054B RID: 1355
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x06002292 RID: 8850 RVA: 0x001EDA20 File Offset: 0x001EBC20
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

		// Token: 0x06002293 RID: 8851 RVA: 0x001EDAF8 File Offset: 0x001EBCF8
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

		// Token: 0x04004A93 RID: 19091
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004A94 RID: 19092
		public float minimumLocalRotationX;

		// Token: 0x04004A95 RID: 19093
		public float maximumFOV = 80f;

		// Token: 0x04004A96 RID: 19094
		public float minSpeed = 0.5f;

		// Token: 0x04004A97 RID: 19095
		public float maxSpeed = 1f;

		// Token: 0x04004A98 RID: 19096
		private float _maxPositionY;

		// Token: 0x04004A99 RID: 19097
		private float _maxRotationX;

		// Token: 0x04004A9A RID: 19098
		private Vector3 _lastPosition;

		// Token: 0x04004A9B RID: 19099
		private float _distance;

		// Token: 0x04004A9C RID: 19100
		private Vector3 _localPosition;

		// Token: 0x04004A9D RID: 19101
		private Vector2 _localRotationYZ;

		// Token: 0x04004A9E RID: 19102
		private Camera _camera;

		// Token: 0x04004A9F RID: 19103
		private float _minFOV;
	}
}
