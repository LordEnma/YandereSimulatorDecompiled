using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000558 RID: 1368
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x060022DB RID: 8923 RVA: 0x001F46F0 File Offset: 0x001F28F0
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

		// Token: 0x060022DC RID: 8924 RVA: 0x001F47C8 File Offset: 0x001F29C8
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

		// Token: 0x04004B75 RID: 19317
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004B76 RID: 19318
		public float minimumLocalRotationX;

		// Token: 0x04004B77 RID: 19319
		public float maximumFOV = 80f;

		// Token: 0x04004B78 RID: 19320
		public float minSpeed = 0.5f;

		// Token: 0x04004B79 RID: 19321
		public float maxSpeed = 1f;

		// Token: 0x04004B7A RID: 19322
		private float _maxPositionY;

		// Token: 0x04004B7B RID: 19323
		private float _maxRotationX;

		// Token: 0x04004B7C RID: 19324
		private Vector3 _lastPosition;

		// Token: 0x04004B7D RID: 19325
		private float _distance;

		// Token: 0x04004B7E RID: 19326
		private Vector3 _localPosition;

		// Token: 0x04004B7F RID: 19327
		private Vector2 _localRotationYZ;

		// Token: 0x04004B80 RID: 19328
		private Camera _camera;

		// Token: 0x04004B81 RID: 19329
		private float _minFOV;
	}
}
