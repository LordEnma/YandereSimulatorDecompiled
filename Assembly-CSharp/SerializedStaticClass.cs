using System;

// Token: 0x02000507 RID: 1287
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x040048CB RID: 18635
	public string TypePath;

	// Token: 0x040048CC RID: 18636
	public ValueDict PropertyValues;

	// Token: 0x040048CD RID: 18637
	public ValueDict FieldValues;

	// Token: 0x040048CE RID: 18638
	public ReferenceDict PropertyReferences;

	// Token: 0x040048CF RID: 18639
	public ReferenceDict FieldReferences;

	// Token: 0x040048D0 RID: 18640
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048D1 RID: 18641
	public ReferenceArrayDict FieldReferenceArrays;
}
