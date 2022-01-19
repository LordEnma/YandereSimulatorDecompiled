using System;

// Token: 0x02000506 RID: 1286
[Serializable]
public struct SerializedComponent
{
	// Token: 0x040048C0 RID: 18624
	public string OwnerID;

	// Token: 0x040048C1 RID: 18625
	public string TypePath;

	// Token: 0x040048C2 RID: 18626
	public ValueDict PropertyValues;

	// Token: 0x040048C3 RID: 18627
	public ReferenceDict PropertyReferences;

	// Token: 0x040048C4 RID: 18628
	public ValueDict FieldValues;

	// Token: 0x040048C5 RID: 18629
	public ReferenceDict FieldReferences;

	// Token: 0x040048C6 RID: 18630
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048C7 RID: 18631
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040048C8 RID: 18632
	public bool IsEnabled;

	// Token: 0x040048C9 RID: 18633
	public bool IsMonoBehaviour;
}
