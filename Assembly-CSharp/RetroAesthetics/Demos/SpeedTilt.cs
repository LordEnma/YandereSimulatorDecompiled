using System;
using UnityEngine;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054D RID: 1357
	public class SpeedTilt : MonoBehaviour
	{
		// Token: 0x060022A4 RID: 8868 RVA: 0x001EF960 File Offset: 0x001EDB60
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

		// Token: 0x060022A5 RID: 8869 RVA: 0x001EFA38 File Offset: 0x001EDC38
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

		// Token: 0x04004AB7 RID: 19127
		public float minimumLocalPositionY = 1f;

		// Token: 0x04004AB8 RID: 19128
		public float minimumLocalRotationX;

		// Token: 0x04004AB9 RID: 19129
		public float maximumFOV = 80f;

		// Token: 0x04004ABA RID: 19130
		public float minSpeed = 0.5f;

		// Token: 0x04004ABB RID: 19131
		public float maxSpeed = 1f;

		// Token: 0x04004ABC RID: 19132
		private float _maxPositionY;

		// Token: 0x04004ABD RID: 19133
		private float _maxRotationX;

		// Token: 0x04004ABE RID: 19134
		private Vector3 _lastPosition;

		// Token: 0x04004ABF RID: 19135
		private float _distance;

		// Token: 0x04004AC0 RID: 19136
		private Vector3 _localPosition;

		// Token: 0x04004AC1 RID: 19137
		private Vector2 _localRotationYZ;

		// Token: 0x04004AC2 RID: 19138
		private Camera _camera;

		// Token: 0x04004AC3 RID: 19139
		private float _minFOV;
	}
}
