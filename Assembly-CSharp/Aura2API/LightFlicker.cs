using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B7 RID: 1463
	public class LightFlicker : MonoBehaviour
	{
		// Token: 0x060024CF RID: 9423 RVA: 0x001FAF6B File Offset: 0x001F916B
		private void Start()
		{
			UnityEngine.Random.InitState((int)base.transform.position.x + (int)base.transform.position.y);
			this._initialFactor = base.GetComponent<Light>().intensity;
		}

		// Token: 0x060024D0 RID: 9424 RVA: 0x001FAFA6 File Offset: 0x001F91A6
		private void OnEnable()
		{
			this._initPos = base.transform.localPosition;
			this._currentPos = this._initPos;
		}

		// Token: 0x060024D1 RID: 9425 RVA: 0x001FAFC5 File Offset: 0x001F91C5
		private void OnDisable()
		{
			base.transform.localPosition = this._initPos;
		}

		// Token: 0x060024D2 RID: 9426 RVA: 0x001FAFD8 File Offset: 0x001F91D8
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

		// Token: 0x04004C85 RID: 19589
		public float maxFactor = 1.2f;

		// Token: 0x04004C86 RID: 19590
		public float minFactor = 1f;

		// Token: 0x04004C87 RID: 19591
		public float moveRange = 0.1f;

		// Token: 0x04004C88 RID: 19592
		public float speed = 0.1f;

		// Token: 0x04004C89 RID: 19593
		private float _currentFactor = 1f;

		// Token: 0x04004C8A RID: 19594
		private Vector3 _currentPos;

		// Token: 0x04004C8B RID: 19595
		private float _deltaTime;

		// Token: 0x04004C8C RID: 19596
		private Vector3 _initPos;

		// Token: 0x04004C8D RID: 19597
		private float _targetFactor;

		// Token: 0x04004C8E RID: 19598
		private Vector3 _targetPos;

		// Token: 0x04004C8F RID: 19599
		private float _initialFactor;

		// Token: 0x04004C90 RID: 19600
		private float _time;

		// Token: 0x04004C91 RID: 19601
		private float _timeLeft;
	}
}
