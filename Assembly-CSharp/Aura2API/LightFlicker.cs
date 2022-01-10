using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B6 RID: 1462
	public class LightFlicker : MonoBehaviour
	{
		// Token: 0x060024CD RID: 9421 RVA: 0x001FA29B File Offset: 0x001F849B
		private void Start()
		{
			UnityEngine.Random.InitState((int)base.transform.position.x + (int)base.transform.position.y);
			this._initialFactor = base.GetComponent<Light>().intensity;
		}

		// Token: 0x060024CE RID: 9422 RVA: 0x001FA2D6 File Offset: 0x001F84D6
		private void OnEnable()
		{
			this._initPos = base.transform.localPosition;
			this._currentPos = this._initPos;
		}

		// Token: 0x060024CF RID: 9423 RVA: 0x001FA2F5 File Offset: 0x001F84F5
		private void OnDisable()
		{
			base.transform.localPosition = this._initPos;
		}

		// Token: 0x060024D0 RID: 9424 RVA: 0x001FA308 File Offset: 0x001F8508
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

		// Token: 0x04004C7E RID: 19582
		public float maxFactor = 1.2f;

		// Token: 0x04004C7F RID: 19583
		public float minFactor = 1f;

		// Token: 0x04004C80 RID: 19584
		public float moveRange = 0.1f;

		// Token: 0x04004C81 RID: 19585
		public float speed = 0.1f;

		// Token: 0x04004C82 RID: 19586
		private float _currentFactor = 1f;

		// Token: 0x04004C83 RID: 19587
		private Vector3 _currentPos;

		// Token: 0x04004C84 RID: 19588
		private float _deltaTime;

		// Token: 0x04004C85 RID: 19589
		private Vector3 _initPos;

		// Token: 0x04004C86 RID: 19590
		private float _targetFactor;

		// Token: 0x04004C87 RID: 19591
		private Vector3 _targetPos;

		// Token: 0x04004C88 RID: 19592
		private float _initialFactor;

		// Token: 0x04004C89 RID: 19593
		private float _time;

		// Token: 0x04004C8A RID: 19594
		private float _timeLeft;
	}
}
