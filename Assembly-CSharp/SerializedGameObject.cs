using System;

// Token: 0x02000502 RID: 1282
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x04004867 RID: 18535
	public bool ActiveInHierarchy;

	// Token: 0x04004868 RID: 18536
	public bool ActiveSelf;

	// Token: 0x04004869 RID: 18537
	public bool IsStatic;

	// Token: 0x0400486A RID: 18538
	public int Layer;

	// Token: 0x0400486B RID: 18539
	public string Tag;

	// Token: 0x0400486C RID: 18540
	public string Name;

	// Token: 0x0400486D RID: 18541
	public string ObjectID;

	// Token: 0x0400486E RID: 18542
	public SerializedComponent[] SerializedComponents;
}
