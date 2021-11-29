using System;

// Token: 0x02000501 RID: 1281
[Serializable]
public struct SerializedComponent
{
	// Token: 0x0400485D RID: 18525
	public string OwnerID;

	// Token: 0x0400485E RID: 18526
	public string TypePath;

	// Token: 0x0400485F RID: 18527
	public ValueDict PropertyValues;

	// Token: 0x04004860 RID: 18528
	public ReferenceDict PropertyReferences;

	// Token: 0x04004861 RID: 18529
	public ValueDict FieldValues;

	// Token: 0x04004862 RID: 18530
	public ReferenceDict FieldReferences;

	// Token: 0x04004863 RID: 18531
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x04004864 RID: 18532
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x04004865 RID: 18533
	public bool IsEnabled;

	// Token: 0x04004866 RID: 18534
	public bool IsMonoBehaviour;
}
