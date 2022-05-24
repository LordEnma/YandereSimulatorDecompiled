using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054E RID: 1358
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x060022C9 RID: 8905 RVA: 0x001F6E60 File Offset: 0x001F5060
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

		// Token: 0x060022CA RID: 8906 RVA: 0x001F6E90 File Offset: 0x001F5090
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

		// Token: 0x060022CB RID: 8907 RVA: 0x001F6EE0 File Offset: 0x001F50E0
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

		// Token: 0x060022CC RID: 8908 RVA: 0x001F6F30 File Offset: 0x001F5130
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

		// Token: 0x060022CD RID: 8909
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x060022CE RID: 8910 RVA: 0x001F6F80 File Offset: 0x001F5180
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x060022CF RID: 8911 RVA: 0x001F6FAC File Offset: 0x001F51AC
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x060022D0 RID: 8912 RVA: 0x001F6FB5 File Offset: 0x001F51B5
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004B67 RID: 19303
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004B68 RID: 19304
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004B69 RID: 19305
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004B6A RID: 19306
		protected Rigidbody targetRigidbody;

		// Token: 0x0200069B RID: 1691
		public enum UpdateType
		{
			// Token: 0x0400511E RID: 20766
			FixedUpdate,
			// Token: 0x0400511F RID: 20767
			LateUpdate,
			// Token: 0x04005120 RID: 20768
			ManualUpdate
		}
	}
}
