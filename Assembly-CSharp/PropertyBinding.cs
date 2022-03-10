using System;
using UnityEngine;

// Token: 0x0200007A RID: 122
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Internal/Property Binding")]
public class PropertyBinding : MonoBehaviour
{
	// Token: 0x06000448 RID: 1096 RVA: 0x0002C02E File Offset: 0x0002A22E
	private void Start()
	{
		this.UpdateTarget();
		if (this.update == PropertyBinding.UpdateCondition.OnStart)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x0002C045 File Offset: 0x0002A245
	private void Update()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x0002C056 File Offset: 0x0002A256
	private void LateUpdate()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnLateUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x0002C067 File Offset: 0x0002A267
	private void FixedUpdate()
	{
		if (this.update == PropertyBinding.UpdateCondition.OnFixedUpdate)
		{
			this.UpdateTarget();
		}
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x0002C078 File Offset: 0x0002A278
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

	// Token: 0x0600044D RID: 1101 RVA: 0x0002C0A0 File Offset: 0x0002A2A0
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

	// Token: 0x020005EE RID: 1518
	[DoNotObfuscateNGUI]
	public enum UpdateCondition
	{
		// Token: 0x04004DC5 RID: 19909
		OnStart,
		// Token: 0x04004DC6 RID: 19910
		OnUpdate,
		// Token: 0x04004DC7 RID: 19911
		OnLateUpdate,
		// Token: 0x04004DC8 RID: 19912
		OnFixedUpdate
	}

	// Token: 0x020005EF RID: 1519
	[DoNotObfuscateNGUI]
	public enum Direction
	{
		// Token: 0x04004DCA RID: 19914
		SourceUpdatesTarget,
		// Token: 0x04004DCB RID: 19915
		TargetUpdatesSource,
		// Token: 0x04004DCC RID: 19916
		BiDirectional
	}
}
