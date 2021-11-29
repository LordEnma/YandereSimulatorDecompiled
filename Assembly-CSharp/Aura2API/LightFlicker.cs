using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B2 RID: 1458
	public class LightFlicker : MonoBehaviour
	{
		// Token: 0x060024AE RID: 9390 RVA: 0x001F7BD7 File Offset: 0x001F5DD7
		private void Start()
		{
			UnityEngine.Random.InitState((int)base.transform.position.x + (int)base.transform.position.y);
			this._initialFactor = base.GetComponent<Light>().intensity;
		}

		// Token: 0x060024AF RID: 9391 RVA: 0x001F7C12 File Offset: 0x001F5E12
		private void OnEnable()
		{
			this._initPos = base.transform.localPosition;
			this._currentPos = this._initPos;
		}

		// Token: 0x060024B0 RID: 9392 RVA: 0x001F7C31 File Offset: 0x001F5E31
		private void OnDisable()
		{
			base.transform.localPosition = this._initPos;
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x001F7C44 File Offset: 0x001F5E44
		private void Update()
		{
			this._deltaTime = Time.deltaTime;
			if (this._timeLeft <= this._deltaTime)
			{
				this._targetFactor = UnityEngine.Random.Range(this.minFactor, this.maxFactor);
				this._targetPos = this._initPos + UnityEngine.Random.insideUnitSphere * this.moveRange;
				this._timeLeft = this.speed;
				return;
			}
			float t = this._deltaTime / this._timeLeft;
			this._currentFactor = Mathf.Lerp(this._currentFactor, this._targetFactor, t);
			base.GetComponent<Light>().intensity = this._initialFactor * this._currentFactor;
			this._currentPos = Vector3.Lerp(this._currentPos, this._targetPos, t);
			base.transform.localPosition = this._currentPos;
			this._timeLeft -= this._deltaTime;
		}

		// Token: 0x04004C22 RID: 19490
		public float maxFactor = 1.2f;

		// Token: 0x04004C23 RID: 19491
		public float minFactor = 1f;

		// Token: 0x04004C24 RID: 19492
		public float moveRange = 0.1f;

		// Token: 0x04004C25 RID: 19493
		public float speed = 0.1f;

		// Token: 0x04004C26 RID: 19494
		private float _currentFactor = 1f;

		// Token: 0x04004C27 RID: 19495
		private Vector3 _currentPos;

		// Token: 0x04004C28 RID: 19496
		private float _deltaTime;

		// Token: 0x04004C29 RID: 19497
		private Vector3 _initPos;

		// Token: 0x04004C2A RID: 19498
		private float _targetFactor;

		// Token: 0x04004C2B RID: 19499
		private Vector3 _targetPos;

		// Token: 0x04004C2C RID: 19500
		private float _initialFactor;

		// Token: 0x04004C2D RID: 19501
		private float _time;

		// Token: 0x04004C2E RID: 19502
		private float _timeLeft;
	}
}
