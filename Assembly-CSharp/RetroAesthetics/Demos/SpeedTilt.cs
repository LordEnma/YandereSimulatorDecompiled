using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000549 RID: 1353
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x06002284 RID: 8836 RVA: 0x001ECA90 File Offset: 0x001EAC90
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

		// Token: 0x06002285 RID: 8837 RVA: 0x001ECB68 File Offset: 0x001EAD68
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

		// Token: 0x04004A76 RID: 19062
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004A77 RID: 19063
		public float minimumLocalRotationX;

		// Token: 0x04004A78 RID: 19064
		public float maximumFOV = 80f;

		// Token: 0x04004A79 RID: 19065
		public float minSpeed = 0.5f;

		// Token: 0x04004A7A RID: 19066
		public float maxSpeed = 1f;

		// Token: 0x04004A7B RID: 19067
		private float _maxPositionY;

		// Token: 0x04004A7C RID: 19068
		private float _maxRotationX;

		// Token: 0x04004A7D RID: 19069
		private Vector3 _lastPosition;

		// Token: 0x04004A7E RID: 19070
		private float _distance;

		// Token: 0x04004A7F RID: 19071
		private Vector3 _localPosition;

		// Token: 0x04004A80 RID: 19072
		private Vector2 _localRotationYZ;

		// Token: 0x04004A81 RID: 19073
		private Camera _camera;

		// Token: 0x04004A82 RID: 19074
		private float _minFOV;
	}
}
