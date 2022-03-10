using System;

// Token: 0x02000509 RID: 1289
[Serializable]
public struct SerializedComponent
{
	// Token: 0x0400490A RID: 18698
	public string OwnerID;

	// Token: 0x0400490B RID: 18699
	public string TypePath;

	// Token: 0x0400490C RID: 18700
	public ValueDict PropertyValues;

	// Token: 0x0400490D RID: 18701
	public ReferenceDict PropertyReferences;

	// Token: 0x0400490E RID: 18702
	public ValueDict FieldValues;

	// Token: 0x0400490F RID: 18703
	public ReferenceDict FieldReferences;

	// Token: 0x04004910 RID: 18704
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x04004911 RID: 18705
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x04004912 RID: 18706
	public bool IsEnabled;

	// Token: 0x04004913 RID: 18707
	public bool IsMonoBehaviour;
}
