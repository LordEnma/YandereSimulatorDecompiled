using System;

// Token: 0x02000506 RID: 1286
[Serializable]
public struct SerializedComponent
{
	// Token: 0x040048CB RID: 18635
	public string OwnerID;

	// Token: 0x040048CC RID: 18636
	public string TypePath;

	// Token: 0x040048CD RID: 18637
	public ValueDict PropertyValues;

	// Token: 0x040048CE RID: 18638
	public ReferenceDict PropertyReferences;

	// Token: 0x040048CF RID: 18639
	public ValueDict FieldValues;

	// Token: 0x040048D0 RID: 18640
	public ReferenceDict FieldReferences;

	// Token: 0x040048D1 RID: 18641
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048D2 RID: 18642
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040048D3 RID: 18643
	public bool IsEnabled;

	// Token: 0x040048D4 RID: 18644
	public bool IsMonoBehaviour;
}
