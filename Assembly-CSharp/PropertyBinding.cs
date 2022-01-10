using System;
using UnityEngine;

// Token: 0x0200007A RID: 122
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Internal/Property Binding")]
public class PropertyBinding : MonoBehaviour
{
	// Token: 0x06000448 RID: 1096 RVA: 0x0002BF3E File Offset: 0x0002A13E
	private void Start()
	{
		this.UpdateTarget();
		if (this.update == PropertyBinding.UpdateCondition.OnStart)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x0002BF55 File Offset: 0x0002A155
	private void Update()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x0002BF66 File Offset: 0x0002A166
	private void LateUpdate()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnLateUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x0002BF77 File Offset: 0x0002A177
	private void FixedUpdate()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnFixedUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x0002BF88 File Offset: 0x0002A188
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

	// Token: 0x0600044D RID: 1101 RVA: 0x0002BFB0 File Offset: 0x0002A1B0
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

	// Token: 0x040004EA RID: 1258
	public PropertyReference source;

	// Token: 0x040004EB RID: 1259
	public PropertyReference target;

	// Token: 0x040004EC RID: 1260
	public PropertyBinding.Direction direction;

	// Token: 0x040004ED RID: 1261
	public PropertyBinding.UpdateCondition update = PropertyBinding.UpdateCondition.OnUpdate;

	// Token: 0x040004EE RID: 1262
	public bool editMode = true;

	// Token: 0x040004EF RID: 1263
	private object mLastValue;

	// Token: 0x020005F0 RID: 1520
	[DoNotObfuscateNGUI]
	public enum UpdateCondition
	{
		// Token: 0x04004DA2 RID: 19874
		OnStart,
		// Token: 0x04004DA3 RID: 19875
		OnUpdate,
		// Token: 0x04004DA4 RID: 19876
		OnLateUpdate,
		// Token: 0x04004DA5 RID: 19877
		OnFixedUpdate
	}

	// Token: 0x020005F1 RID: 1521
	[DoNotObfuscateNGUI]
	public enum Direction
	{
		// Token: 0x04004DA7 RID: 19879
		SourceUpdatesTarget,
		// Token: 0x04004DA8 RID: 19880
		TargetUpdatesSource,
		// Token: 0x04004DA9 RID: 19881
		BiDirectional
	}
}
