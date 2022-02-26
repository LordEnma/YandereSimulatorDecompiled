using System;

// Token: 0x0200050A RID: 1290
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x040048FF RID: 18687
	public string TypePath;

	// Token: 0x04004900 RID: 18688
	public ValueDict PropertyValues;

	// Token: 0x04004901 RID: 18689
	public ValueDict FieldValues;

	// Token: 0x04004902 RID: 18690
	public ReferenceDict PropertyReferences;

	// Token: 0x04004903 RID: 18691
	public ReferenceDict FieldReferences;

	// Token: 0x04004904 RID: 18692
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x04004905 RID: 18693
	public ReferenceArrayDict FieldReferenceArrays;
}
