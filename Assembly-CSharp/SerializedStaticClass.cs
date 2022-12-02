using System;

[Serializable]
public struct SerializedStaticClass
{
	public string TypePath;

	public ValueDict PropertyValues;

	public ValueDict FieldValues;

	public ReferenceDict PropertyReferences;

	public ReferenceDict FieldReferences;

	public ReferenceArrayDict PropertyReferenceArrays;

	public ReferenceArrayDict FieldReferenceArrays;
}
