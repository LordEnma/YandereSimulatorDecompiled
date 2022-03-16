using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x020004F4 RID: 1268
public class GrassPlaneGenerator : MonoBehaviour
{
	// Token: 0x06002105 RID: 8453 RVA: 0x001E83D4 File Offset: 0x001E65D4
	private void OnDrawGizmosSelected()
	{
		this.quadSize = Mathf.Clamp(this.quadSize, 0.1f, 10f);
		Vector3 position = base.transform.position;
		Vector3 vector = new Vector3(this.Width, 0f, this.Height);
		Vector3 vector2 = new Vector3(this.quadSize, 0f, this.quadSize);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(position, vector);
		if (this.Intersect)
		{
			Gizmos.color = new Color(0.5f, 0.5f, 1f, 0.5f);
			Gizmos.DrawCube(position + Vector3.up * this.IntersectHeight / 2f, vector + Vector3.up * this.IntersectHeight);
		}
		Gizmos.color = Color.cyan;
		for (float num = 0f; num < this.Width + 0.09f - this.quadSize; num += this.quadSize)
		{
			for (float num2 = 0f; num2 < this.Height + 0.09f - this.quadSize; num2 += this.quadSize)
			{
				Gizmos.DrawWireCube(position - vector / 2f + vector2 / 2f + new Vector3(num, 0f, num2), vector2);
			}
		}
	}

	// Token: 0x06002106 RID: 8454 RVA: 0x001E8544 File Offset: 0x001E6744
	public void Bake()
	{
		List<Vector3> list = new List<Vector3>();
		List<int> list2 = new List<int>();
		Vector3 position = base.transform.position;
		new Vector3(this.Width, 0f, this.Height);
		new Vector3(this.quadSize, 0f, this.quadSize);
		int num = (int)(this.Width / this.quadSize);
		float num2 = (float)((int)(this.Height / this.quadSize));
		float num3 = (float)num * this.quadSize;
		float num4 = num2 * this.quadSize;
		float num5 = this.Width - num3;
		float num6 = this.Height - num4;
		Vector3 vector = new Vector3(this.Width / num3, 1f, this.Height / num4);
		Texture2D texture2D = null;
		if (this.Intersect)
		{
			RenderTexture active = RenderTexture.active;
			Camera camera = new GameObject("Temporary Camera").AddComponent<Camera>();
			camera.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
			camera.transform.position = position + Vector3.up * this.IntersectHeight;
			camera.orthographic = true;
			camera.aspect = this.Width / this.Height;
			camera.orthographicSize = this.Height / 2f;
			camera.nearClipPlane = 0.01f;
			camera.farClipPlane = this.IntersectHeight + 0.01f;
			camera.clearFlags = CameraClearFlags.Color;
			camera.backgroundColor = new Color(0f, 0f, 0f, 0f);
			camera.cullingMask = this.IntersectLayers;
			RenderTexture renderTexture = new RenderTexture((int)this.Width * 100, (int)this.Height * 100, 1);
			camera.targetTexture = renderTexture;
			camera.forceIntoRenderTexture = true;
			RenderTexture.active = renderTexture;
			camera.Render();
			texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);
			texture2D.ReadPixels(new Rect(0f, 0f, (float)renderTexture.width, (float)renderTexture.height), 0, 0);
			texture2D.filterMode = FilterMode.Trilinear;
			texture2D.Apply();
			RenderTexture.active = active;
			UnityEngine.Object.DestroyImmediate(camera.gameObject);
		}
		int num7 = 0;
		for (float num8 = 0f; num8 < this.Width + 0.09f - this.quadSize; num8 += this.quadSize)
		{
			float num9 = 0f;
			while (num9 < this.Height + 0.09f - this.quadSize)
			{
				if (!this.Intersect)
				{
					goto IL_2C5;
				}
				float num10 = this.OffsetCorrection ? this.quadSize : 0f;
				float num11 = 0f;
				for (int i = -1; i < 2; i++)
				{
					for (int j = -1; j < 2; j++)
					{
						num11 += texture2D.GetPixel((int)((num8 + num10) * 100f + (float)i), (int)((num9 + num10) * 100f + (float)j)).a;
					}
				}
				if (num11 == 0f)
				{
					goto IL_2C5;
				}
				IL_3B5:
				num9 += this.quadSize;
				continue;
				IL_2C5:
				Vector3 b = new Vector3(num8 - this.Width / 2f, 0f, num9 - this.Height / 2f);
				list.Add(new Vector3(0f, 0f, 0f) + b);
				list.Add(new Vector3(0f, 0f, this.quadSize) + b);
				list.Add(new Vector3(this.quadSize, 0f, this.quadSize) + b);
				list.Add(new Vector3(this.quadSize, 0f, 0f) + b);
				list2.Add(num7);
				list2.Add(num7 + 1);
				list2.Add(num7 + 2);
				list2.Add(num7);
				list2.Add(num7 + 2);
				list2.Add(num7 + 3);
				num7 += 4;
				goto IL_3B5;
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			Vector3 value = list[k];
			value.x *= vector.x;
			value.z *= vector.z;
			value.x += num5 * vector.x / 2f;
			value.z += num6 * vector.z / 2f;
			list[k] = value;
		}
		Mesh mesh = new Mesh();
		mesh.indexFormat = IndexFormat.UInt32;
		mesh.subMeshCount = 1;
		mesh.SetVertices(list);
		mesh.SetIndices(list2.ToArray(), MeshTopology.Triangles, 0);
		mesh.RecalculateNormals();
		new GameObject("GrassMesh")
		{
			transform = 
			{
				position = base.transform.position
			}
		}.AddComponent<MeshRenderer>().gameObject.AddComponent<MeshFilter>().mesh = mesh;
	}

	// Token: 0x04004912 RID: 18706
	public float Width = 10f;

	// Token: 0x04004913 RID: 18707
	public float Height = 10f;

	// Token: 0x04004914 RID: 18708
	public bool Intersect;

	// Token: 0x04004915 RID: 18709
	public float IntersectHeight = 1f;

	// Token: 0x04004916 RID: 18710
	public bool OffsetCorrection;

	// Token: 0x04004917 RID: 18711
	public LayerMask IntersectLayers;

	// Token: 0x04004918 RID: 18712
	[Range(0.1f, 10f)]
	public float quadSize = 0.1f;
}
