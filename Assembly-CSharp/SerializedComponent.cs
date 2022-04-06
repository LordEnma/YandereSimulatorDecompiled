using System;

// Token: 0x02000513 RID: 1299
[Serializable]
public struct SerializedComponent
{
	// Token: 0x0400499F RID: 18847
	public string OwnerID;

	// Token: 0x040049A0 RID: 18848
	public string TypePath;

	// Token: 0x040049A1 RID: 18849
	public ValueDict PropertyValues;

	// Token: 0x040049A2 RID: 18850
	public ReferenceDict PropertyReferences;

	// Token: 0x040049A3 RID: 18851
	public ValueDict FieldValues;

	// Token: 0x040049A4 RID: 18852
	public ReferenceDict FieldReferences;

	// Token: 0x040049A5 RID: 18853
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040049A6 RID: 18854
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040049A7 RID: 18855
	public bool IsEnabled;

	// Token: 0x040049A8 RID: 18856
	public bool IsMonoBehaviour;
}
