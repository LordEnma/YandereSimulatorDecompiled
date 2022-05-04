using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054D RID: 1357
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x060022BE RID: 8894 RVA: 0x001F52A8 File Offset: 0x001F34A8
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

		// Token: 0x060022BF RID: 8895 RVA: 0x001F52D8 File Offset: 0x001F34D8
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

		// Token: 0x060022C0 RID: 8896 RVA: 0x001F5328 File Offset: 0x001F3528
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

		// Token: 0x060022C1 RID: 8897 RVA: 0x001F5378 File Offset: 0x001F3578
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

		// Token: 0x060022C2 RID: 8898
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x060022C3 RID: 8899 RVA: 0x001F53C8 File Offset: 0x001F35C8
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x060022C4 RID: 8900 RVA: 0x001F53F4 File Offset: 0x001F35F4
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x060022C5 RID: 8901 RVA: 0x001F53FD File Offset: 0x001F35FD
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004B37 RID: 19255
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004B38 RID: 19256
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004B39 RID: 19257
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004B3A RID: 19258
		protected Rigidbody targetRigidbody;

		// Token: 0x0200069A RID: 1690
		public enum UpdateType
		{
			// Token: 0x040050EE RID: 20718
			FixedUpdate,
			// Token: 0x040050EF RID: 20719
			LateUpdate,
			// Token: 0x040050F0 RID: 20720
			ManualUpdate
		}
	}
}
