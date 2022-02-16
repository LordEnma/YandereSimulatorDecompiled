using System;

// Token: 0x02000509 RID: 1289
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x040048EF RID: 18671
	public string TypePath;

	// Token: 0x040048F0 RID: 18672
	public ValueDict PropertyValues;

	// Token: 0x040048F1 RID: 18673
	public ValueDict FieldValues;

	// Token: 0x040048F2 RID: 18674
	public ReferenceDict PropertyReferences;

	// Token: 0x040048F3 RID: 18675
	public ReferenceDict FieldReferences;

	// Token: 0x040048F4 RID: 18676
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048F5 RID: 18677
	public ReferenceArrayDict FieldReferenceArrays;
}
