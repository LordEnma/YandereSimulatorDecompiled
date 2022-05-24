using System;

// Token: 0x02000517 RID: 1303
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x04004A09 RID: 18953
	public string TypePath;

	// Token: 0x04004A0A RID: 18954
	public ValueDict PropertyValues;

	// Token: 0x04004A0B RID: 18955
	public ValueDict FieldValues;

	// Token: 0x04004A0C RID: 18956
	public ReferenceDict PropertyReferences;

	// Token: 0x04004A0D RID: 18957
	public ReferenceDict FieldReferences;

	// Token: 0x04004A0E RID: 18958
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x04004A0F RID: 18959
	public ReferenceArrayDict FieldReferenceArrays;
}
