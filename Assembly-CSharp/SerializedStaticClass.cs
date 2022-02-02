using System;

// Token: 0x02000508 RID: 1288
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x040048DD RID: 18653
	public string TypePath;

	// Token: 0x040048DE RID: 18654
	public ValueDict PropertyValues;

	// Token: 0x040048DF RID: 18655
	public ValueDict FieldValues;

	// Token: 0x040048E0 RID: 18656
	public ReferenceDict PropertyReferences;

	// Token: 0x040048E1 RID: 18657
	public ReferenceDict FieldReferences;

	// Token: 0x040048E2 RID: 18658
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048E3 RID: 18659
	public ReferenceArrayDict FieldReferenceArrays;
}
