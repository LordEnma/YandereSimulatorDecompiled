using System;

// Token: 0x0200050D RID: 1293
[Serializable]
public struct SerializedComponent
{
	// Token: 0x04004969 RID: 18793
	public string OwnerID;

	// Token: 0x0400496A RID: 18794
	public string TypePath;

	// Token: 0x0400496B RID: 18795
	public ValueDict PropertyValues;

	// Token: 0x0400496C RID: 18796
	public ReferenceDict PropertyReferences;

	// Token: 0x0400496D RID: 18797
	public ValueDict FieldValues;

	// Token: 0x0400496E RID: 18798
	public ReferenceDict FieldReferences;

	// Token: 0x0400496F RID: 18799
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x04004970 RID: 18800
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x04004971 RID: 18801
	public bool IsEnabled;

	// Token: 0x04004972 RID: 18802
	public bool IsMonoBehaviour;
}
