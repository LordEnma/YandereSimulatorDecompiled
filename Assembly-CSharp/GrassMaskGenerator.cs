using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020004EF RID: 1263
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class GrassMaskGenerator : MonoBehaviour
{
	// Token: 0x060020E8 RID: 8424 RVA: 0x001E5FA0 File Offset: 0x001E41A0
	public void Start()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x060020E9 RID: 8425 RVA: 0x001E5FB0 File Offset: 0x001E41B0
	private void Update()
	{
		if (this.camera == null)
		{
			this.camera = base.GetComponent<Camera>();
		}
		this.aspectWidth = Mathf.Clamp(this.aspectWidth, 1f, 2.1474836E+09f);
		this.aspectHeight = Mathf.Clamp(this.aspectHeight, 1f, 2.1474836E+09f);
		this.mapUpscale = Mathf.Clamp(this.mapUpscale, 1, 1000);
		if (this.targetTexture == null || (float)this.targetTexture.width != this.aspectWidth * (float)this.mapUpscale || (float)this.targetTexture.height != this.aspectHeight * (float)this.mapUpscale)
		{
			if (this.targetTexture != null)
			{
				this.targetTexture.Release();
			}
			this.targetTexture = new RenderTexture(Mathf.RoundToInt(this.aspectWidth) * this.mapUpscale, Mathf.RoundToInt(this.aspectHeight) * this.mapUpscale, 1);
		}
		this.camera.enabled = false;
		this.camera.farClipPlane = 0.1f;
		this.camera.orthographic = true;
		this.camera.orthographicSize = this.mapScale;
		this.camera.targetTexture = this.targetTexture;
	}

	// Token: 0x060020EA RID: 8426 RVA: 0x001E6100 File Offset: 0x001E4300
	[ContextMenu("Generate and save the grass occlusion map")]
	public void GenerateMap()
	{
		base.GetComponent<Camera>().Render();
		if (this.targetTexture == null || (float)this.targetTexture.width != this.aspectWidth * (float)this.mapUpscale || (float)this.targetTexture.height != this.aspectHeight * (float)this.mapUpscale)
		{
			if (this.targetTexture != null)
			{
				this.targetTexture.Release();
			}
			this.targetTexture = new RenderTexture(Mathf.RoundToInt(this.aspectWidth) * this.mapUpscale, Mathf.RoundToInt(this.aspectHeight) * this.mapUpscale, 1);
		}
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = this.targetTexture;
		Texture2D texture2D = new Texture2D(this.targetTexture.width, this.targetTexture.height);
		texture2D.ReadPixels(new Rect(0f, 0f, (float)this.targetTexture.width, (float)this.targetTexture.height), 0, 0);
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
					Vector3 b = new Vector3((float)i, 0f, (float)j) / 3f;
					list.Add(new Vector3(0f, 0f, 0f) + b);
					list.Add(new Vector3(0f, 0f, 1f) + b);
					list.Add(new Vector3(1f, 0f, 1f) + b);
					list.Add(new Vector3(1f, 0f, 0f) + b);
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
		new GameObject("GrassMesh")
		{
			transform = 
			{
				position = base.transform.position
			}
		}.AddComponent<MeshRenderer>().gameObject.AddComponent<MeshFilter>().mesh = mesh;
	}

	// Token: 0x060020EB RID: 8427 RVA: 0x001E63A0 File Offset: 0x001E45A0
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Matrix4x4 matrix = Gizmos.matrix;
		Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one);
		float z = this.camera.farClipPlane - this.camera.nearClipPlane;
		float z2 = (this.camera.farClipPlane + this.camera.nearClipPlane) * 0.5f;
		Gizmos.DrawWireCube(new Vector3(0f, 0f, z2), new Vector3(this.camera.orthographicSize * 2f * this.camera.aspect, this.camera.orthographicSize * 2f, z));
	}

	// Token: 0x040048AD RID: 18605
	[SerializeField]
	private float aspectWidth;

	// Token: 0x040048AE RID: 18606
	[SerializeField]
	private float aspectHeight;

	// Token: 0x040048AF RID: 18607
	[SerializeField]
	private float mapScale;

	// Token: 0x040048B0 RID: 18608
	[SerializeField]
	private int mapUpscale;

	// Token: 0x040048B1 RID: 18609
	private Camera camera;

	// Token: 0x040048B2 RID: 18610
	private RenderTexture targetTexture;
}
