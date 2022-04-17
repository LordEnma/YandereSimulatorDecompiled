using System;

// Token: 0x02000515 RID: 1301
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x040049C3 RID: 18883
	public string TypePath;

	// Token: 0x040049C4 RID: 18884
	public ValueDict PropertyValues;

	// Token: 0x040049C5 RID: 18885
	public ValueDict FieldValues;

	// Token: 0x040049C6 RID: 18886
	public ReferenceDict PropertyReferences;

	// Token: 0x040049C7 RID: 18887
	public ReferenceDict FieldReferences;

	// Token: 0x040049C8 RID: 18888
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040049C9 RID: 18889
	public ReferenceArrayDict FieldReferenceArrays;
}
