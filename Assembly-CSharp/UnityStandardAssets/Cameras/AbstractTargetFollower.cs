using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054C RID: 1356
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x060022B4 RID: 8884 RVA: 0x001F3D20 File Offset: 0x001F1F20
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

		// Token: 0x060022B5 RID: 8885 RVA: 0x001F3D50 File Offset: 0x001F1F50
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

		// Token: 0x060022B6 RID: 8886 RVA: 0x001F3DA0 File Offset: 0x001F1FA0
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

		// Token: 0x060022B7 RID: 8887 RVA: 0x001F3DF0 File Offset: 0x001F1FF0
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

		// Token: 0x060022B8 RID: 8888
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x060022B9 RID: 8889 RVA: 0x001F3E40 File Offset: 0x001F2040
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x060022BA RID: 8890 RVA: 0x001F3E6C File Offset: 0x001F206C
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x060022BB RID: 8891 RVA: 0x001F3E75 File Offset: 0x001F2075
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004B21 RID: 19233
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004B22 RID: 19234
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004B23 RID: 19235
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004B24 RID: 19236
		protected Rigidbody targetRigidbody;

		// Token: 0x02000699 RID: 1689
		public enum UpdateType
		{
			// Token: 0x040050D0 RID: 20688
			FixedUpdate,
			// Token: 0x040050D1 RID: 20689
			LateUpdate,
			// Token: 0x040050D2 RID: 20690
			ManualUpdate
		}
	}
}
