using System;

// Token: 0x02000503 RID: 1283
[Serializable]
public struct SerializedComponent
{
	// Token: 0x040048A5 RID: 18597
	public string OwnerID;

	// Token: 0x040048A6 RID: 18598
	public string TypePath;

	// Token: 0x040048A7 RID: 18599
	public ValueDict PropertyValues;

	// Token: 0x040048A8 RID: 18600
	public ReferenceDict PropertyReferences;

	// Token: 0x040048A9 RID: 18601
	public ValueDict FieldValues;

	// Token: 0x040048AA RID: 18602
	public ReferenceDict FieldReferences;

	// Token: 0x040048AB RID: 18603
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048AC RID: 18604
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040048AD RID: 18605
	public bool IsEnabled;

	// Token: 0x040048AE RID: 18606
	public bool IsMonoBehaviour;
}
