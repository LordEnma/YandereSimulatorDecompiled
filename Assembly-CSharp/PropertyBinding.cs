using System;
using UnityEngine;

// Token: 0x0200007A RID: 122
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Internal/Property Binding")]
public class PropertyBinding : MonoBehaviour
{
	// Token: 0x06000448 RID: 1096 RVA: 0x0002BF36 File Offset: 0x0002A136
	private void Start()
	{
		this.UpdateTarget();
		if (this.update == PropertyBinding.UpdateCondition.OnStart)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x0002BF4D File Offset: 0x0002A14D
	private void Update()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x0002BF5E File Offset: 0x0002A15E
	private void LateUpdate()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnLateUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x0002BF6F File Offset: 0x0002A16F
	private void FixedUpdate()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnFixedUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x0002BF80 File Offset: 0x0002A180
	private void OnValidate()
	{
		if (this.source != null)
		{
			this.source.Reset();
		}
		if (this.target != null)
		{
			this.target.Reset();
		}
	}

	// Token: 0x0600044D RID: 1101 RVA: 0x0002BFA8 File Offset: 0x0002A1A8
	[ContextMenu("Update Now")]
	public void UpdateTarget()
	{
		if (this.source != null && this.target != null && this.source.isValid && this.target.isValid)
		{
			if (this.direction == PropertyBinding.Direction.SourceUpdatesTarget)
			{
				this.target.Set(this.source.Get());
				return;
			}
			if (this.direction == PropertyBinding.Direction.TargetUpdatesSource)
			{
				this.source.Set(this.target.Get());
				return;
			}
			if (this.source.GetPropertyType() == this.target.GetPropertyType())
			{
				object obj = this.source.Get();
				if (this.mLastValue == null || !this.mLastValue.Equals(obj))
				{
					this.mLastValue = obj;
					this.target.Set(obj);
					return;
				}
				obj = this.target.Get();
				if (!this.mLastValue.Equals(obj))
				{
					this.mLastValue = obj;
					this.source.Set(obj);
				}
			}
		}
	}

	// Token: 0x040004EC RID: 1260
	public PropertyReference source;

	// Token: 0x040004ED RID: 1261
	public PropertyReference target;

	// Token: 0x040004EE RID: 1262
	public PropertyBinding.Direction direction;

	// Token: 0x040004EF RID: 1263
	public PropertyBinding.UpdateCondition update = PropertyBinding.UpdateCondition.OnUpdate;

	// Token: 0x040004F0 RID: 1264
	public bool editMode = true;

	// Token: 0x040004F1 RID: 1265
	private object mLastValue;

	// Token: 0x020005EC RID: 1516
	[DoNotObfuscateNGUI]
	public enum UpdateCondition
	{
		// Token: 0x04004D98 RID: 19864
		OnStart,
		// Token: 0x04004D99 RID: 19865
		OnUpdate,
		// Token: 0x04004D9A RID: 19866
		OnLateUpdate,
		// Token: 0x04004D9B RID: 19867
		OnFixedUpdate
	}

	// Token: 0x020005ED RID: 1517
	[DoNotObfuscateNGUI]
	public enum Direction
	{
		// Token: 0x04004D9D RID: 19869
		SourceUpdatesTarget,
		// Token: 0x04004D9E RID: 19870
		TargetUpdatesSource,
		// Token: 0x04004D9F RID: 19871
		BiDirectional
	}
}
