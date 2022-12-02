using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GrassPlaneGenerator : MonoBehaviour
{
	public float Width = 10f;

	public float Height = 10f;

	public bool Intersect;

	public float IntersectHeight = 1f;

	public bool OffsetCorrection;

	public LayerMask IntersectLayers;

	[Range(0.1f, 10f)]
	public float quadSize = 0.1f;

	private void OnDrawGizmosSelected()
	{
		quadSize = Mathf.Clamp(quadSize, 0.1f, 10f);
		Vector3 position = base.transform.position;
		Vector3 vector = new Vector3(Width, 0f, Height);
		Vector3 vector2 = new Vector3(quadSize, 0f, quadSize);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(position, vector);
		if (Intersect)
		{
			Gizmos.color = new Color(0.5f, 0.5f, 1f, 0.5f);
			Gizmos.DrawCube(position + Vector3.up * IntersectHeight / 2f, vector + Vector3.up * IntersectHeight);
		}
		Gizmos.color = Color.cyan;
		for (float num = 0f; num < Width + 0.09f - quadSize; num += quadSize)
		{
			for (float num2 = 0f; num2 < Height + 0.09f - quadSize; num2 += quadSize)
			{
				Gizmos.DrawWireCube(position - vector / 2f + vector2 / 2f + new Vector3(num, 0f, num2), vector2);
			}
		}
	}

	public void Bake()
	{
		List<Vector3> list = new List<Vector3>();
		List<int> list2 = new List<int>();
		Vector3 position = base.transform.position;
		new Vector3(Width, 0f, Height);
		new Vector3(quadSize, 0f, quadSize);
		int num = (int)(Width / quadSize);
		int num2 = (int)(Height / quadSize);
		float num3 = (float)num * quadSize;
		float num4 = (float)num2 * quadSize;
		float num5 = Width - num3;
		float num6 = Height - num4;
		Vector3 vector = new Vector3(Width / num3, 1f, Height / num4);
		Texture2D texture2D = null;
		if (Intersect)
		{
			RenderTexture active = RenderTexture.active;
			Camera camera = new GameObject("Temporary Camera").AddComponent<Camera>();
			camera.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
			camera.transform.position = position + Vector3.up * IntersectHeight;
			camera.orthographic = true;
			camera.aspect = Width / Height;
			camera.orthographicSize = Height / 2f;
			camera.nearClipPlane = 0.01f;
			camera.farClipPlane = IntersectHeight + 0.01f;
			camera.clearFlags = CameraClearFlags.Color;
			camera.backgroundColor = new Color(0f, 0f, 0f, 0f);
			camera.cullingMask = IntersectLayers;
			RenderTexture renderTexture2 = (camera.targetTexture = new RenderTexture((int)Width * 100, (int)Height * 100, 1));
			camera.forceIntoRenderTexture = true;
			RenderTexture.active = renderTexture2;
			camera.Render();
			texture2D = new Texture2D(renderTexture2.width, renderTexture2.height, TextureFormat.RGBA32, false);
			texture2D.ReadPixels(new Rect(0f, 0f, renderTexture2.width, renderTexture2.height), 0, 0);
			texture2D.filterMode = FilterMode.Trilinear;
			texture2D.Apply();
			RenderTexture.active = active;
			Object.DestroyImmediate(camera.gameObject);
		}
		int num7 = 0;
		for (float num8 = 0f; num8 < Width + 0.09f - quadSize; num8 += quadSize)
		{
			for (float num9 = 0f; num9 < Height + 0.09f - quadSize; num9 += quadSize)
			{
				if (Intersect)
				{
					float num10 = (OffsetCorrection ? quadSize : 0f);
					float num11 = 0f;
					for (int i = -1; i < 2; i++)
					{
						for (int j = -1; j < 2; j++)
						{
							num11 += texture2D.GetPixel((int)((num8 + num10) * 100f + (float)i), (int)((num9 + num10) * 100f + (float)j)).a;
						}
					}
					if (num11 != 0f)
					{
						continue;
					}
				}
				Vector3 vector2 = new Vector3(num8 - Width / 2f, 0f, num9 - Height / 2f);
				list.Add(new Vector3(0f, 0f, 0f) + vector2);
				list.Add(new Vector3(0f, 0f, quadSize) + vector2);
				list.Add(new Vector3(quadSize, 0f, quadSize) + vector2);
				list.Add(new Vector3(quadSize, 0f, 0f) + vector2);
				list2.Add(num7);
				list2.Add(num7 + 1);
				list2.Add(num7 + 2);
				list2.Add(num7);
				list2.Add(num7 + 2);
				list2.Add(num7 + 3);
				num7 += 4;
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
		GameObject obj = new GameObject("GrassMesh");
		obj.transform.position = base.transform.position;
		obj.AddComponent<MeshRenderer>().gameObject.AddComponent<MeshFilter>().mesh = mesh;
	}
}
