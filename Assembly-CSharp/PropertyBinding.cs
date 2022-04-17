using System;
using UnityEngine;

// Token: 0x0200007A RID: 122
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Internal/Property Binding")]
public class PropertyBinding : MonoBehaviour
{
	// Token: 0x06000448 RID: 1096 RVA: 0x0002C0E6 File Offset: 0x0002A2E6
	private void Start()
	{
		this.UpdateTarget();
		if (this.update == PropertyBinding.UpdateCondition.OnStart)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x0002C0FD File Offset: 0x0002A2FD
	private void Update()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x0002C10E File Offset: 0x0002A30E
	private void LateUpdate()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnLateUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x0002C11F File Offset: 0x0002A31F
	private void FixedUpdate()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnFixedUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x0002C130 File Offset: 0x0002A330
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

	// Token: 0x0600044D RID: 1101 RVA: 0x0002C158 File Offset: 0x0002A358
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

	// Token: 0x040004F5 RID: 1269
	public PropertyReference source;

	// Token: 0x040004F6 RID: 1270
	public PropertyReference target;

	// Token: 0x040004F7 RID: 1271
	public PropertyBinding.Direction direction;

	// Token: 0x040004F8 RID: 1272
	public PropertyBinding.UpdateCondition update = PropertyBinding.UpdateCondition.OnUpdate;

	// Token: 0x040004F9 RID: 1273
	public bool editMode = true;

	// Token: 0x040004FA RID: 1274
	private object mLastValue;

	// Token: 0x020005F8 RID: 1528
	[DoNotObfuscateNGUI]
	public enum UpdateCondition
	{
		// Token: 0x04004E6C RID: 20076
		OnStart,
		// Token: 0x04004E6D RID: 20077
		OnUpdate,
		// Token: 0x04004E6E RID: 20078
		OnLateUpdate,
		// Token: 0x04004E6F RID: 20079
		OnFixedUpdate
	}

	// Token: 0x020005F9 RID: 1529
	[DoNotObfuscateNGUI]
	public enum Direction
	{
		// Token: 0x04004E71 RID: 20081
		SourceUpdatesTarget,
		// Token: 0x04004E72 RID: 20082
		TargetUpdatesSource,
		// Token: 0x04004E73 RID: 20083
		BiDirectional
	}
}
