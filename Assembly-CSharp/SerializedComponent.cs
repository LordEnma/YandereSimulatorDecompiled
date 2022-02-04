using System;

// Token: 0x02000506 RID: 1286
[Serializable]
public struct SerializedComponent
{
	// Token: 0x040048D1 RID: 18641
	public string OwnerID;

	// Token: 0x040048D2 RID: 18642
	public string TypePath;

	// Token: 0x040048D3 RID: 18643
	public ValueDict PropertyValues;

	// Token: 0x040048D4 RID: 18644
	public ReferenceDict PropertyReferences;

	// Token: 0x040048D5 RID: 18645
	public ValueDict FieldValues;

	// Token: 0x040048D6 RID: 18646
	public ReferenceDict FieldReferences;

	// Token: 0x040048D7 RID: 18647
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048D8 RID: 18648
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040048D9 RID: 18649
	public bool IsEnabled;

	// Token: 0x040048DA RID: 18650
	public bool IsMonoBehaviour;
}
