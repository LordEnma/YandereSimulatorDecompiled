using System;

// Token: 0x02000506 RID: 1286
[Serializable]
public struct SerializedComponent
{
	// Token: 0x040048D4 RID: 18644
	public string OwnerID;

	// Token: 0x040048D5 RID: 18645
	public string TypePath;

	// Token: 0x040048D6 RID: 18646
	public ValueDict PropertyValues;

	// Token: 0x040048D7 RID: 18647
	public ReferenceDict PropertyReferences;

	// Token: 0x040048D8 RID: 18648
	public ValueDict FieldValues;

	// Token: 0x040048D9 RID: 18649
	public ReferenceDict FieldReferences;

	// Token: 0x040048DA RID: 18650
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048DB RID: 18651
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040048DC RID: 18652
	public bool IsEnabled;

	// Token: 0x040048DD RID: 18653
	public bool IsMonoBehaviour;
}
