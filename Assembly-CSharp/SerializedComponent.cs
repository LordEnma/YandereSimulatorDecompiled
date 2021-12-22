using System;

// Token: 0x02000503 RID: 1283
[Serializable]
public struct SerializedComponent
{
	// Token: 0x0400489C RID: 18588
	public string OwnerID;

	// Token: 0x0400489D RID: 18589
	public string TypePath;

	// Token: 0x0400489E RID: 18590
	public ValueDict PropertyValues;

	// Token: 0x0400489F RID: 18591
	public ReferenceDict PropertyReferences;

	// Token: 0x040048A0 RID: 18592
	public ValueDict FieldValues;

	// Token: 0x040048A1 RID: 18593
	public ReferenceDict FieldReferences;

	// Token: 0x040048A2 RID: 18594
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048A3 RID: 18595
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040048A4 RID: 18596
	public bool IsEnabled;

	// Token: 0x040048A5 RID: 18597
	public bool IsMonoBehaviour;
}
