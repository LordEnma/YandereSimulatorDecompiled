using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000547 RID: 1351
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x06002273 RID: 8819 RVA: 0x001EB35C File Offset: 0x001E955C
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

		// Token: 0x06002274 RID: 8820 RVA: 0x001EB434 File Offset: 0x001E9634
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

		// Token: 0x04004A37 RID: 18999
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004A38 RID: 19000
		public float minimumLocalRotationX;

		// Token: 0x04004A39 RID: 19001
		public float maximumFOV = 80f;

		// Token: 0x04004A3A RID: 19002
		public float minSpeed = 0.5f;

		// Token: 0x04004A3B RID: 19003
		public float maxSpeed = 1f;

		// Token: 0x04004A3C RID: 19004
		private float _maxPositionY;

		// Token: 0x04004A3D RID: 19005
		private float _maxRotationX;

		// Token: 0x04004A3E RID: 19006
		private Vector3 _lastPosition;

		// Token: 0x04004A3F RID: 19007
		private float _distance;

		// Token: 0x04004A40 RID: 19008
		private Vector3 _localPosition;

		// Token: 0x04004A41 RID: 19009
		private Vector2 _localRotationYZ;

		// Token: 0x04004A42 RID: 19010
		private Camera _camera;

		// Token: 0x04004A43 RID: 19011
		private float _minFOV;
	}
}
