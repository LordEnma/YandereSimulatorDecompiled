using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053F RID: 1343
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x06002267 RID: 8807 RVA: 0x001EDB50 File Offset: 0x001EBD50
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

		// Token: 0x06002268 RID: 8808 RVA: 0x001EDB80 File Offset: 0x001EBD80
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

		// Token: 0x06002269 RID: 8809 RVA: 0x001EDBD0 File Offset: 0x001EBDD0
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

		// Token: 0x0600226A RID: 8810 RVA: 0x001EDC20 File Offset: 0x001EBE20
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

		// Token: 0x0600226B RID: 8811
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x0600226C RID: 8812 RVA: 0x001EDC70 File Offset: 0x001EBE70
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x0600226D RID: 8813 RVA: 0x001EDC9C File Offset: 0x001EBE9C
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x0600226E RID: 8814 RVA: 0x001EDCA5 File Offset: 0x001EBEA5
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004A44 RID: 19012
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004A45 RID: 19013
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004A46 RID: 19014
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004A47 RID: 19015
		protected Rigidbody targetRigidbody;

		// Token: 0x0200068A RID: 1674
		public enum UpdateType
		{
			// Token: 0x04004FEE RID: 20462
			FixedUpdate,
			// Token: 0x04004FEF RID: 20463
			LateUpdate,
			// Token: 0x04004FF0 RID: 20464
			ManualUpdate
		}
	}
}
