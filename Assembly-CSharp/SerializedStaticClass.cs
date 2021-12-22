using System;

// Token: 0x02000505 RID: 1285
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x040048AE RID: 18606
	public string TypePath;

	// Token: 0x040048AF RID: 18607
	public ValueDict PropertyValues;

	// Token: 0x040048B0 RID: 18608
	public ValueDict FieldValues;

	// Token: 0x040048B1 RID: 18609
	public ReferenceDict PropertyReferences;

	// Token: 0x040048B2 RID: 18610
	public ReferenceDict FieldReferences;

	// Token: 0x040048B3 RID: 18611
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048B4 RID: 18612
	public ReferenceArrayDict FieldReferenceArrays;
}
