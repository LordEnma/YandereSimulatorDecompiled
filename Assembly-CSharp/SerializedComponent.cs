using System;

// Token: 0x02000515 RID: 1301
[Serializable]
public struct SerializedComponent
{
	// Token: 0x040049F7 RID: 18935
	public string OwnerID;

	// Token: 0x040049F8 RID: 18936
	public string TypePath;

	// Token: 0x040049F9 RID: 18937
	public ValueDict PropertyValues;

	// Token: 0x040049FA RID: 18938
	public ReferenceDict PropertyReferences;

	// Token: 0x040049FB RID: 18939
	public ValueDict FieldValues;

	// Token: 0x040049FC RID: 18940
	public ReferenceDict FieldReferences;

	// Token: 0x040049FD RID: 18941
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040049FE RID: 18942
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040049FF RID: 18943
	public bool IsEnabled;

	// Token: 0x04004A00 RID: 18944
	public bool IsMonoBehaviour;
}
