using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class GrassMaskGenerator : MonoBehaviour
{
	[SerializeField]
	private float aspectWidth;

	[SerializeField]
	private float aspectHeight;

	[SerializeField]
	private float mapScale;

	[SerializeField]
	private int mapUpscale;

	private Camera camera;

	private RenderTexture targetTexture;

	public void Start()
	{
		Object.Destroy(base.gameObject);
	}

	private void Update()
	{
		if (camera == null)
		{
			camera = GetComponent<Camera>();
		}
		aspectWidth = Mathf.Clamp(aspectWidth, 1f, 2.1474836E+09f);
		aspectHeight = Mathf.Clamp(aspectHeight, 1f, 2.1474836E+09f);
		mapUpscale = Mathf.Clamp(mapUpscale, 1, 1000);
		if (targetTexture == null || (float)targetTexture.width != aspectWidth * (float)mapUpscale || (float)targetTexture.height != aspectHeight * (float)mapUpscale)
		{
			if (targetTexture != null)
			{
				targetTexture.Release();
			}
			targetTexture = new RenderTexture(Mathf.RoundToInt(aspectWidth) * mapUpscale, Mathf.RoundToInt(aspectHeight) * mapUpscale, 1);
		}
		camera.enabled = false;
		camera.farClipPlane = 0.1f;
		camera.orthographic = true;
		camera.orthographicSize = mapScale;
		camera.targetTexture = targetTexture;
	}

	[ContextMenu("Generate and save the grass occlusion map")]
	public void GenerateMap()
	{
		GetComponent<Camera>().Render();
		if (targetTexture == null || (float)targetTexture.width != aspectWidth * (float)mapUpscale || (float)targetTexture.height != aspectHeight * (float)mapUpscale)
		{
			if (targetTexture != null)
			{
				targetTexture.Release();
			}
			targetTexture = new RenderTexture(Mathf.RoundToInt(aspectWidth) * mapUpscale, Mathf.RoundToInt(aspectHeight) * mapUpscale, 1);
		}
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = targetTexture;
		Texture2D texture2D = new Texture2D(targetTexture.width, targetTexture.height);
		texture2D.ReadPixels(new Rect(0f, 0f, targetTexture.width, targetTexture.height), 0, 0);
		RenderTexture.active = active;
		List<Vector3> list = new List<Vector3>();
		List<int> list2 = new List<int>();
		int num = 0;
		for (int i = 0; i < texture2D.width; i++)
		{
			for (int j = 0; j < texture2D.height; j++)
			{
				if (texture2D.GetPixel(i, j).a == 0f)
				{
					Vector3 vector = new Vector3(i, 0f, j) / 3f;
					list.Add(new Vector3(0f, 0f, 0f) + vector);
					list.Add(new Vector3(0f, 0f, 1f) + vector);
					list.Add(new Vector3(1f, 0f, 1f) + vector);
					list.Add(new Vector3(1f, 0f, 0f) + vector);
					list2.Add(num);
					list2.Add(num + 1);
					list2.Add(num + 2);
					list2.Add(num);
					list2.Add(num + 2);
					list2.Add(num + 3);
					num += 4;
				}
			}
		}
		Mesh mesh = new Mesh();
		mesh.subMeshCount = 1;
		mesh.SetVertices(list);
		mesh.SetIndices(list2.ToArray(), MeshTopology.Triangles, 0);
		mesh.RecalculateNormals();
		GameObject obj = new GameObject("GrassMesh");
		obj.transform.position = base.transform.position;
		obj.AddComponent<MeshRenderer>().gameObject.AddComponent<MeshFilter>().mesh = mesh;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Matrix4x4 matrix = Gizmos.matrix;
		Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one);
		float z = camera.farClipPlane - camera.nearClipPlane;
		float z2 = (camera.farClipPlane + camera.nearClipPlane) * 0.5f;
		Gizmos.DrawWireCube(new Vector3(0f, 0f, z2), new Vector3(camera.orthographicSize * 2f * camera.aspect, camera.orthographicSize * 2f, z));
	}
}
