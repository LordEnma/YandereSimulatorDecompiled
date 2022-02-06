using System;

// Token: 0x02000508 RID: 1288
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x040048E6 RID: 18662
	public string TypePath;

	// Token: 0x040048E7 RID: 18663
	public ValueDict PropertyValues;

	// Token: 0x040048E8 RID: 18664
	public ValueDict FieldValues;

	// Token: 0x040048E9 RID: 18665
	public ReferenceDict PropertyReferences;

	// Token: 0x040048EA RID: 18666
	public ReferenceDict FieldReferences;

	// Token: 0x040048EB RID: 18667
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048EC RID: 18668
	public ReferenceArrayDict FieldReferenceArrays;
}
