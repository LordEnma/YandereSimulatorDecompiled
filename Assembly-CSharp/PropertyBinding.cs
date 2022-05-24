using System;
using UnityEngine;

// Token: 0x0200007A RID: 122
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Internal/Property Binding")]
public class PropertyBinding : MonoBehaviour
{
	// Token: 0x06000448 RID: 1096 RVA: 0x0002C226 File Offset: 0x0002A426
	private void Start()
	{
		this.UpdateTarget();
		if (this.update == PropertyBinding.UpdateCondition.OnStart)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x0002C23D File Offset: 0x0002A43D
	private void Update()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x0002C24E File Offset: 0x0002A44E
	private void LateUpdate()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnLateUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x0002C25F File Offset: 0x0002A45F
	private void FixedUpdate()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnFixedUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x0002C270 File Offset: 0x0002A470
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

	// Token: 0x0600044D RID: 1101 RVA: 0x0002C298 File Offset: 0x0002A498
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

	// Token: 0x040004F7 RID: 1271
	public PropertyReference source;

	// Token: 0x040004F8 RID: 1272
	public PropertyReference target;

	// Token: 0x040004F9 RID: 1273
	public PropertyBinding.Direction direction;

	// Token: 0x040004FA RID: 1274
	public PropertyBinding.UpdateCondition update = PropertyBinding.UpdateCondition.OnUpdate;

	// Token: 0x040004FB RID: 1275
	public bool editMode = true;

	// Token: 0x040004FC RID: 1276
	private object mLastValue;

	// Token: 0x020005FA RID: 1530
	[DoNotObfuscateNGUI]
	public enum UpdateCondition
	{
		// Token: 0x04004EBA RID: 20154
		OnStart,
		// Token: 0x04004EBB RID: 20155
		OnUpdate,
		// Token: 0x04004EBC RID: 20156
		OnLateUpdate,
		// Token: 0x04004EBD RID: 20157
		OnFixedUpdate
	}

	// Token: 0x020005FB RID: 1531
	[DoNotObfuscateNGUI]
	public enum Direction
	{
		// Token: 0x04004EBF RID: 20159
		SourceUpdatesTarget,
		// Token: 0x04004EC0 RID: 20160
		TargetUpdatesSource,
		// Token: 0x04004EC1 RID: 20161
		BiDirectional
	}
}
