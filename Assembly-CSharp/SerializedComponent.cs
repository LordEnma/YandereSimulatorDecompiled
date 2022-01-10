using System;

// Token: 0x02000505 RID: 1285
[Serializable]
public struct SerializedComponent
{
	// Token: 0x040048B9 RID: 18617
	public string OwnerID;

	// Token: 0x040048BA RID: 18618
	public string TypePath;

	// Token: 0x040048BB RID: 18619
	public ValueDict PropertyValues;

	// Token: 0x040048BC RID: 18620
	public ReferenceDict PropertyReferences;

	// Token: 0x040048BD RID: 18621
	public ValueDict FieldValues;

	// Token: 0x040048BE RID: 18622
	public ReferenceDict FieldReferences;

	// Token: 0x040048BF RID: 18623
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048C0 RID: 18624
	public ReferenceArrayDict FieldReferenceArrays;

	// Token: 0x040048C1 RID: 18625
	public bool IsEnabled;

	// Token: 0x040048C2 RID: 18626
	public bool IsMonoBehaviour;
}
