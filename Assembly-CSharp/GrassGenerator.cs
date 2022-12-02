using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshFilter))]
public class GrassGenerator : MonoBehaviour
{
	[Serializable]
	public class GrassPlane
	{
		public Vector3 LocalCenter;

		public Vector2 Size;

		public bool Intersect;
	}

	[Range(0.1f, 10f)]
	public float QuadSize = 0.1f;

	public float IntersectHeight = 1f;

	public LayerMask IntersectLayers;

	public bool IntersectOffsetCorrection;

	[HideInInspector]
	public List<GrassPlane> Planes = new List<GrassPlane>();

	[HideInInspector]
	public GrassPlane EditedPlane;

	private void OnDrawGizmosSelected()
	{
		if (Planes.Count == 0)
		{
			return;
		}
		foreach (GrassPlane plane in Planes)
		{
			Gizmos.color = Color.gray;
			if (plane == EditedPlane)
			{
				Gizmos.color = Color.cyan;
			}
			Gizmos.DrawWireCube(base.transform.position + plane.LocalCenter, new Vector3(plane.Size.x, 0.1f, plane.Size.y));
		}
	}
}
