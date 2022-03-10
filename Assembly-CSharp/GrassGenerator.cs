using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200000B RID: 11
[ExecuteAlways]
[RequireComponent(typeof(MeshFilter))]
public class GrassGenerator : MonoBehaviour
{
	// Token: 0x06000025 RID: 37 RVA: 0x0000343C File Offset: 0x0000163C
	private void OnDrawGizmosSelected()
	{
		if (this.Planes.Count == 0)
		{
			return;
		}
		foreach (GrassGenerator.GrassPlane grassPlane in this.Planes)
		{
			Gizmos.color = Color.gray;
			if (grassPlane == this.EditedPlane)
			{
				Gizmos.color = Color.cyan;
			}
			Gizmos.DrawWireCube(base.transform.position + grassPlane.LocalCenter, new Vector3(grassPlane.Size.x, 0.1f, grassPlane.Size.y));
		}
	}

	// Token: 0x0400005A RID: 90
	[Range(0.1f, 10f)]
	public float QuadSize = 0.1f;

	// Token: 0x0400005B RID: 91
	public float IntersectHeight = 1f;

	// Token: 0x0400005C RID: 92
	public LayerMask IntersectLayers;

	// Token: 0x0400005D RID: 93
	public bool IntersectOffsetCorrection;

	// Token: 0x0400005E RID: 94
	[HideInInspector]
	public List<GrassGenerator.GrassPlane> Planes = new List<GrassGenerator.GrassPlane>();

	// Token: 0x0400005F RID: 95
	[HideInInspector]
	public GrassGenerator.GrassPlane EditedPlane;

	// Token: 0x020005BD RID: 1469
	[Serializable]
	public class GrassPlane
	{
		// Token: 0x04004D07 RID: 19719
		public Vector3 LocalCenter;

		// Token: 0x04004D08 RID: 19720
		public Vector2 Size;

		// Token: 0x04004D09 RID: 19721
		public bool Intersect;
	}
}
