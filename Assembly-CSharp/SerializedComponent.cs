using System;

// Token: 0x02000508 RID: 1288
[Serializable]
public struct SerializedComponent
{
	// Token: 0x040048ED RID: 18669
	public string OwnerID;

	// Token: 0x040048EE RID: 18670
	public string TypePath;

	// Token: 0x040048EF RID: 18671
	public ValueDict PropertyValues;

	// Token: 0x040048F0 RID: 18672
	public ReferenceDict PropertyReferences;

	// Token: 0x040048F1 RID: 18673
	public ValueDict FieldValues;

	// Token: 0x040048F2 RID: 18674
	public ReferenceDict FieldReferences;

	// Token: 0x040048F3 RID: 18675
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048F4 RID: 18676
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040048F5 RID: 18677
	public bool IsEnabled;

	// Token: 0x040048F6 RID: 18678
	public bool IsMonoBehaviour;
}
