using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B4 RID: 1460
	public class LightFlicker : MonoBehaviour
	{
		// Token: 0x060024BF RID: 9407 RVA: 0x001F930B File Offset: 0x001F750B
		private void Start()
		{
			UnityEngine.Random.InitState((int)base.transform.position.x + (int)base.transform.position.y);
			this._initialFactor = base.GetComponent<Light>().intensity;
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x001F9346 File Offset: 0x001F7546
		private void OnEnable()
		{
			this._initPos = base.transform.localPosition;
			this._currentPos = this._initPos;
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x001F9365 File Offset: 0x001F7565
		private void OnDisable()
		{
			base.transform.localPosition = this._initPos;
		}

		// Token: 0x060024C2 RID: 9410 RVA: 0x001F9378 File Offset: 0x001F7578
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

		// Token: 0x04004C61 RID: 19553
		public float maxFactor = 1.2f;

		// Token: 0x04004C62 RID: 19554
		public float minFactor = 1f;

		// Token: 0x04004C63 RID: 19555
		public float moveRange = 0.1f;

		// Token: 0x04004C64 RID: 19556
		public float speed = 0.1f;

		// Token: 0x04004C65 RID: 19557
		private float _currentFactor = 1f;

		// Token: 0x04004C66 RID: 19558
		private Vector3 _currentPos;

		// Token: 0x04004C67 RID: 19559
		private float _deltaTime;

		// Token: 0x04004C68 RID: 19560
		private Vector3 _initPos;

		// Token: 0x04004C69 RID: 19561
		private float _targetFactor;

		// Token: 0x04004C6A RID: 19562
		private Vector3 _targetPos;

		// Token: 0x04004C6B RID: 19563
		private float _initialFactor;

		// Token: 0x04004C6C RID: 19564
		private float _time;

		// Token: 0x04004C6D RID: 19565
		private float _timeLeft;
	}
}
