using System;

// Token: 0x02000508 RID: 1288
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x040048E3 RID: 18659
	public string TypePath;

	// Token: 0x040048E4 RID: 18660
	public ValueDict PropertyValues;

	// Token: 0x040048E5 RID: 18661
	public ValueDict FieldValues;

	// Token: 0x040048E6 RID: 18662
	public ReferenceDict PropertyReferences;

	// Token: 0x040048E7 RID: 18663
	public ReferenceDict FieldReferences;

	// Token: 0x040048E8 RID: 18664
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048E9 RID: 18665
	public ReferenceArrayDict FieldReferenceArrays;
}
