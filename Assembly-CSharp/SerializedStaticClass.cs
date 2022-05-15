using System;

// Token: 0x02000517 RID: 1303
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x04004A00 RID: 18944
	public string TypePath;

	// Token: 0x04004A01 RID: 18945
	public ValueDict PropertyValues;

	// Token: 0x04004A02 RID: 18946
	public ValueDict FieldValues;

	// Token: 0x04004A03 RID: 18947
	public ReferenceDict PropertyReferences;

	// Token: 0x04004A04 RID: 18948
	public ReferenceDict FieldReferences;

	// Token: 0x04004A05 RID: 18949
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x04004A06 RID: 18950
	public ReferenceArrayDict FieldReferenceArrays;
}
