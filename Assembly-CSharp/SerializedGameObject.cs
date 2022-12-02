using System;

[Serializable]
public struct SerializedGameObject
{
	public bool ActiveInHierarchy;

	public bool ActiveSelf;

	public bool IsStatic;

	public int Layer;

	public string Tag;

	public string Name;

	public string ObjectID;

	public SerializedComponent[] SerializedComponents;
}
