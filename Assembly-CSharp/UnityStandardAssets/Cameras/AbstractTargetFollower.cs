using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054D RID: 1357
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x060022BD RID: 8893 RVA: 0x001F51AC File Offset: 0x001F33AC
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

		// Token: 0x060022BE RID: 8894 RVA: 0x001F51DC File Offset: 0x001F33DC
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

		// Token: 0x060022BF RID: 8895 RVA: 0x001F522C File Offset: 0x001F342C
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

		// Token: 0x060022C0 RID: 8896 RVA: 0x001F527C File Offset: 0x001F347C
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

		// Token: 0x060022C1 RID: 8897
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x060022C2 RID: 8898 RVA: 0x001F52CC File Offset: 0x001F34CC
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x060022C3 RID: 8899 RVA: 0x001F52F8 File Offset: 0x001F34F8
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x060022C4 RID: 8900 RVA: 0x001F5301 File Offset: 0x001F3501
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
