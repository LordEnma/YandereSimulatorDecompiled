using System;

// Token: 0x02000507 RID: 1287
[Serializable]
public struct SerializedComponent
{
	// Token: 0x040048DD RID: 18653
	public string OwnerID;

	// Token: 0x040048DE RID: 18654
	public string TypePath;

	// Token: 0x040048DF RID: 18655
	public ValueDict PropertyValues;

	// Token: 0x040048E0 RID: 18656
	public ReferenceDict PropertyReferences;

	// Token: 0x040048E1 RID: 18657
	public ValueDict FieldValues;

	// Token: 0x040048E2 RID: 18658
	public ReferenceDict FieldReferences;

	// Token: 0x040048E3 RID: 18659
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048E4 RID: 18660
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040048E5 RID: 18661
	public bool IsEnabled;

	// Token: 0x040048E6 RID: 18662
	public bool IsMonoBehaviour;
}
