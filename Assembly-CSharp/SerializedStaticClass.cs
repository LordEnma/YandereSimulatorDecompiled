using System;

// Token: 0x02000508 RID: 1288
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x040048D2 RID: 18642
	public string TypePath;

	// Token: 0x040048D3 RID: 18643
	public ValueDict PropertyValues;

	// Token: 0x040048D4 RID: 18644
	public ValueDict FieldValues;

	// Token: 0x040048D5 RID: 18645
	public ReferenceDict PropertyReferences;

	// Token: 0x040048D6 RID: 18646
	public ReferenceDict FieldReferences;

	// Token: 0x040048D7 RID: 18647
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048D8 RID: 18648
	public ReferenceArrayDict FieldReferenceArrays;
}
