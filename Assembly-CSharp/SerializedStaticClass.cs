using System;

// Token: 0x02000505 RID: 1285
[Serializable]
public struct SerializedStaticClass
{
	// Token: 0x040048B7 RID: 18615
	public string TypePath;

	// Token: 0x040048B8 RID: 18616
	public ValueDict PropertyValues;

	// Token: 0x040048B9 RID: 18617
	public ValueDict FieldValues;

	// Token: 0x040048BA RID: 18618
	public ReferenceDict PropertyReferences;

	// Token: 0x040048BB RID: 18619
	public ReferenceDict FieldReferences;

	// Token: 0x040048BC RID: 18620
	public ReferenceArrayDict PropertyReferenceArrays;

	// Token: 0x040048BD RID: 18621
	public ReferenceArrayDict FieldReferenceArrays;
}
