using System;

// Token: 0x02000514 RID: 1300
[Serializable]
public struct SerializedComponent
{
	// Token: 0x040049C7 RID: 18887
	public string OwnerID;

	// Token: 0x040049C8 RID: 18888
	public string TypePath;

	// Token: 0x040049C9 RID: 18889
	public ValueDict PropertyValues;

	// Token: 0x040049CA RID: 18890
	public ReferenceDict PropertyReferences;

	// Token: 0x040049CB RID: 18891
	public ValueDict FieldValues;

	// Token: 0x040049CC RID: 18892
	public ReferenceDict FieldReferences;

	// Token: 0x040049CD RID: 18893
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040049CE RID: 18894
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040049CF RID: 18895
	public bool IsEnabled;

	// Token: 0x040049D0 RID: 18896
	public bool IsMonoBehaviour;
}
