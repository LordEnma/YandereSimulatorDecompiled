using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053F RID: 1343
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x06002262 RID: 8802 RVA: 0x001ED634 File Offset: 0x001EB834
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

		// Token: 0x06002263 RID: 8803 RVA: 0x001ED664 File Offset: 0x001EB864
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

		// Token: 0x06002264 RID: 8804 RVA: 0x001ED6B4 File Offset: 0x001EB8B4
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

		// Token: 0x06002265 RID: 8805 RVA: 0x001ED704 File Offset: 0x001EB904
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

		// Token: 0x06002266 RID: 8806
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x06002267 RID: 8807 RVA: 0x001ED754 File Offset: 0x001EB954
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x001ED780 File Offset: 0x001EB980
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06002269 RID: 8809 RVA: 0x001ED789 File Offset: 0x001EB989
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004A3B RID: 19003
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004A3C RID: 19004
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004A3D RID: 19005
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004A3E RID: 19006
		protected Rigidbody targetRigidbody;

		// Token: 0x0200068A RID: 1674
		public enum UpdateType
		{
			// Token: 0x04004FE5 RID: 20453
			FixedUpdate,
			// Token: 0x04004FE6 RID: 20454
			LateUpdate,
			// Token: 0x04004FE7 RID: 20455
			ManualUpdate
		}
	}
}
