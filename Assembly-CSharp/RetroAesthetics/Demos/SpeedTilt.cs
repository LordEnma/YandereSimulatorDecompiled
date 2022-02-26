using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054E RID: 1358
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x060022AD RID: 8877 RVA: 0x001F0540 File Offset: 0x001EE740
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

		// Token: 0x060022AE RID: 8878 RVA: 0x001F0618 File Offset: 0x001EE818
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

		// Token: 0x04004AC7 RID: 19143
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004AC8 RID: 19144
		public float minimumLocalRotationX;

		// Token: 0x04004AC9 RID: 19145
		public float maximumFOV = 80f;

		// Token: 0x04004ACA RID: 19146
		public float minSpeed = 0.5f;

		// Token: 0x04004ACB RID: 19147
		public float maxSpeed = 1f;

		// Token: 0x04004ACC RID: 19148
		private float _maxPositionY;

		// Token: 0x04004ACD RID: 19149
		private float _maxRotationX;

		// Token: 0x04004ACE RID: 19150
		private Vector3 _lastPosition;

		// Token: 0x04004ACF RID: 19151
		private float _distance;

		// Token: 0x04004AD0 RID: 19152
		private Vector3 _localPosition;

		// Token: 0x04004AD1 RID: 19153
		private Vector2 _localRotationYZ;

		// Token: 0x04004AD2 RID: 19154
		private Camera _camera;

		// Token: 0x04004AD3 RID: 19155
		private float _minFOV;
	}
}
