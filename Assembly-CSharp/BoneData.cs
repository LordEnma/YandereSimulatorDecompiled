using System;
using UnityEngine;

[Serializable]
public struct BoneData
{
	public string BoneName;

	public Quaternion LocalRotation;

	public Vector3 LocalPosition;

	public Vector3 LocalScale;
}
