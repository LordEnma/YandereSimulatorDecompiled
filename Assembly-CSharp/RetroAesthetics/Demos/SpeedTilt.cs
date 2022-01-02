using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000549 RID: 1353
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x06002287 RID: 8839 RVA: 0x001ED080 File Offset: 0x001EB280
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

		// Token: 0x06002288 RID: 8840 RVA: 0x001ED158 File Offset: 0x001EB358
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

		// Token: 0x04004A7F RID: 19071
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004A80 RID: 19072
		public float minimumLocalRotationX;

		// Token: 0x04004A81 RID: 19073
		public float maximumFOV = 80f;

		// Token: 0x04004A82 RID: 19074
		public float minSpeed = 0.5f;

		// Token: 0x04004A83 RID: 19075
		public float maxSpeed = 1f;

		// Token: 0x04004A84 RID: 19076
		private float _maxPositionY;

		// Token: 0x04004A85 RID: 19077
		private float _maxRotationX;

		// Token: 0x04004A86 RID: 19078
		private Vector3 _lastPosition;

		// Token: 0x04004A87 RID: 19079
		private float _distance;

		// Token: 0x04004A88 RID: 19080
		private Vector3 _localPosition;

		// Token: 0x04004A89 RID: 19081
		private Vector2 _localRotationYZ;

		// Token: 0x04004A8A RID: 19082
		private Camera _camera;

		// Token: 0x04004A8B RID: 19083
		private float _minFOV;
	}
}
