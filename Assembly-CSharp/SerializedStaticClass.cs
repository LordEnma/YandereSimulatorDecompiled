using System;

// Token: 0x02000503 RID: 1283
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x0400486F RID: 18543
	public string TypePath;

	// Token: 0x04004870 RID: 18544
	public ValueDict PropertyValues;

	// Token: 0x04004871 RID: 18545
	public ValueDict FieldValues;

	// Token: 0x04004872 RID: 18546
	public ReferenceDict PropertyReferences;

	// Token: 0x04004873 RID: 18547
	public ReferenceDict FieldReferences;

	// Token: 0x04004874 RID: 18548
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x04004875 RID: 18549
	public ReferenceArrayDict FieldReferenceArrays;
}
