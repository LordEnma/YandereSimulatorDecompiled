using System;

// Token: 0x02000515 RID: 1301
[Serializable]
public struct SerializedComponent
{
	// Token: 0x040049EE RID: 18926
	public string OwnerID;

	// Token: 0x040049EF RID: 18927
	public string TypePath;

	// Token: 0x040049F0 RID: 18928
	public ValueDict PropertyValues;

	// Token: 0x040049F1 RID: 18929
	public ReferenceDict PropertyReferences;

	// Token: 0x040049F2 RID: 18930
	public ValueDict FieldValues;

	// Token: 0x040049F3 RID: 18931
	public ReferenceDict FieldReferences;

	// Token: 0x040049F4 RID: 18932
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040049F5 RID: 18933
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040049F6 RID: 18934
	public bool IsEnabled;

	// Token: 0x040049F7 RID: 18935
	public bool IsMonoBehaviour;
}
