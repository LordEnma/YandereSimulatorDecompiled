using System;

// Token: 0x02000516 RID: 1302
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x040049D9 RID: 18905
	public string TypePath;

	// Token: 0x040049DA RID: 18906
	public ValueDict PropertyValues;

	// Token: 0x040049DB RID: 18907
	public ValueDict FieldValues;

	// Token: 0x040049DC RID: 18908
	public ReferenceDict PropertyReferences;

	// Token: 0x040049DD RID: 18909
	public ReferenceDict FieldReferences;

	// Token: 0x040049DE RID: 18910
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040049DF RID: 18911
	public ReferenceArrayDict FieldReferenceArrays;
}
