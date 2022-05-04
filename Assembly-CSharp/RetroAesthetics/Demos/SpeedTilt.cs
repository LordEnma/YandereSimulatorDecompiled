using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200055A RID: 1370
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x060022F4 RID: 8948 RVA: 0x001F6C04 File Offset: 0x001F4E04
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

		// Token: 0x060022F5 RID: 8949 RVA: 0x001F6CDC File Offset: 0x001F4EDC
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

		// Token: 0x04004BA1 RID: 19361
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004BA2 RID: 19362
		public float minimumLocalRotationX;

		// Token: 0x04004BA3 RID: 19363
		public float maximumFOV = 80f;

		// Token: 0x04004BA4 RID: 19364
		public float minSpeed = 0.5f;

		// Token: 0x04004BA5 RID: 19365
		public float maxSpeed = 1f;

		// Token: 0x04004BA6 RID: 19366
		private float _maxPositionY;

		// Token: 0x04004BA7 RID: 19367
		private float _maxRotationX;

		// Token: 0x04004BA8 RID: 19368
		private Vector3 _lastPosition;

		// Token: 0x04004BA9 RID: 19369
		private float _distance;

		// Token: 0x04004BAA RID: 19370
		private Vector3 _localPosition;

		// Token: 0x04004BAB RID: 19371
		private Vector2 _localRotationYZ;

		// Token: 0x04004BAC RID: 19372
		private Camera _camera;

		// Token: 0x04004BAD RID: 19373
		private float _minFOV;
	}
}
