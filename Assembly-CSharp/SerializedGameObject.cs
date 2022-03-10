using System;

// Token: 0x0200050A RID: 1290
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x04004914 RID: 18708
	public bool ActiveInHierarchy;

	// Token: 0x04004915 RID: 18709
	public bool ActiveSelf;

	// Token: 0x04004916 RID: 18710
	public bool IsStatic;

	// Token: 0x04004917 RID: 18711
	public int Layer;

	// Token: 0x04004918 RID: 18712
	public string Tag;

	// Token: 0x04004919 RID: 18713
	public string Name;

	// Token: 0x0400491A RID: 18714
	public string ObjectID;

	// Token: 0x0400491B RID: 18715
	public SerializedComponent[] SerializedComponents;
}
