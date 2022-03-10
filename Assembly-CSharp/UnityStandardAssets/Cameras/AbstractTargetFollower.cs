using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000542 RID: 1346
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x0600227D RID: 8829 RVA: 0x001EF5BC File Offset: 0x001ED7BC
		protected virtual void Start()
		{
			if (this.m_AutoTargetPlayer)
			{
				this.FindAndTargetPlayer();
			}
			if (this.m_Target == null)
			{
				return;
			}
			this.targetRigidbody = this.m_Target.GetComponent<Rigidbody>();
		}

		// Token: 0x0600227E RID: 8830 RVA: 0x001EF5EC File Offset: 0x001ED7EC
		private void FixedUpdate()
		{
			if (this.m_AutoTargetPlayer && (this.m_Target == null || !this.m_Target.gameObject.activeSelf))
			{
				this.FindAndTargetPlayer();
			}
			if (this.m_UpdateType == AbstractTargetFollower.UpdateType.FixedUpdate)
			{
				this.FollowTarget(Time.deltaTime);
			}
		}

		// Token: 0x0600227F RID: 8831 RVA: 0x001EF63C File Offset: 0x001ED83C
		private void LateUpdate()
		{
			if (this.m_AutoTargetPlayer && (this.m_Target == null || !this.m_Target.gameObject.activeSelf))
			{
				this.FindAndTargetPlayer();
			}
			if (this.m_UpdateType == AbstractTargetFollower.UpdateType.LateUpdate)
			{
				this.FollowTarget(Time.deltaTime);
			}
		}

		// Token: 0x06002280 RID: 8832 RVA: 0x001EF68C File Offset: 0x001ED88C
		public void ManualUpdate()
		{
			if (this.m_AutoTargetPlayer && (this.m_Target == null || !this.m_Target.gameObject.activeSelf))
			{
				this.FindAndTargetPlayer();
			}
			if (this.m_UpdateType == AbstractTargetFollower.UpdateType.ManualUpdate)
			{
				this.FollowTarget(Time.deltaTime);
			}
		}

		// Token: 0x06002281 RID: 8833
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x06002282 RID: 8834 RVA: 0x001EF6DC File Offset: 0x001ED8DC
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x06002283 RID: 8835 RVA: 0x001EF708 File Offset: 0x001ED908
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06002284 RID: 8836 RVA: 0x001EF711 File Offset: 0x001ED911
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004A7A RID: 19066
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004A7B RID: 19067
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004A7C RID: 19068
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004A7D RID: 19069
		protected Rigidbody targetRigidbody;

		// Token: 0x0200068F RID: 1679
		public enum UpdateType
		{
			// Token: 0x04005029 RID: 20521
			FixedUpdate,
			// Token: 0x0400502A RID: 20522
			LateUpdate,
			// Token: 0x0400502B RID: 20523
			ManualUpdate
		}
	}
}
