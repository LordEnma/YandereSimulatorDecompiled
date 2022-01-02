using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B4 RID: 1460
	public class LightFlicker : MonoBehaviour
	{
		// Token: 0x060024C2 RID: 9410 RVA: 0x001F98FB File Offset: 0x001F7AFB
		private void Start()
		{
			UnityEngine.Random.InitState((int)base.transform.position.x + (int)base.transform.position.y);
			this._initialFactor = base.GetComponent<Light>().intensity;
		}

		// Token: 0x060024C3 RID: 9411 RVA: 0x001F9936 File Offset: 0x001F7B36
		private void OnEnable()
		{
			this._initPos = base.transform.localPosition;
			this._currentPos = this._initPos;
		}

		// Token: 0x060024C4 RID: 9412 RVA: 0x001F9955 File Offset: 0x001F7B55
		private void OnDisable()
		{
			base.transform.localPosition = this._initPos;
		}

		// Token: 0x060024C5 RID: 9413 RVA: 0x001F9968 File Offset: 0x001F7B68
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

		// Token: 0x04004C6A RID: 19562
		public float maxFactor = 1.2f;

		// Token: 0x04004C6B RID: 19563
		public float minFactor = 1f;

		// Token: 0x04004C6C RID: 19564
		public float moveRange = 0.1f;

		// Token: 0x04004C6D RID: 19565
		public float speed = 0.1f;

		// Token: 0x04004C6E RID: 19566
		private float _currentFactor = 1f;

		// Token: 0x04004C6F RID: 19567
		private Vector3 _currentPos;

		// Token: 0x04004C70 RID: 19568
		private float _deltaTime;

		// Token: 0x04004C71 RID: 19569
		private Vector3 _initPos;

		// Token: 0x04004C72 RID: 19570
		private float _targetFactor;

		// Token: 0x04004C73 RID: 19571
		private Vector3 _targetPos;

		// Token: 0x04004C74 RID: 19572
		private float _initialFactor;

		// Token: 0x04004C75 RID: 19573
		private float _time;

		// Token: 0x04004C76 RID: 19574
		private float _timeLeft;
	}
}
