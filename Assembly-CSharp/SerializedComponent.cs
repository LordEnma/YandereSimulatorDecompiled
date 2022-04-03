using System;

// Token: 0x02000512 RID: 1298
[Serializable]
public struct SerializedComponent
{
	// Token: 0x0400499B RID: 18843
	public string OwnerID;

	// Token: 0x0400499C RID: 18844
	public string TypePath;

	// Token: 0x0400499D RID: 18845
	public ValueDict PropertyValues;

	// Token: 0x0400499E RID: 18846
	public ReferenceDict PropertyReferences;

	// Token: 0x0400499F RID: 18847
	public ValueDict FieldValues;

	// Token: 0x040049A0 RID: 18848
	public ReferenceDict FieldReferences;

	// Token: 0x040049A1 RID: 18849
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040049A2 RID: 18850
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040049A3 RID: 18851
	public bool IsEnabled;

	// Token: 0x040049A4 RID: 18852
	public bool IsMonoBehaviour;
}
