using System;
using UnityEngine;

// Token: 0x020001A3 RID: 419
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Neon")]
public class CameraFilterPack_Edge_Neon : MonoBehaviour
{
	// Token: 0x170002A7 RID: 679
	// (get) Token: 0x06000E92 RID: 3730 RVA: 0x0007AD61 File Offset: 0x00078F61
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x06000E93 RID: 3731 RVA: 0x0007AD95 File Offset: 0x00078F95
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Neon");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E94 RID: 3732 RVA: 0x0007ADB8 File Offset: 0x00078FB8
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_EdgeWeight", this.EdgeWeight);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E95 RID: 3733 RVA: 0x0007AE67 File Offset: 0x00079067
	private void Update()
	{
	}

	// Token: 0x06000E96 RID: 3734 RVA: 0x0007AE69 File Offset: 0x00079069
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012EC RID: 4844
	public Shader SCShader;

	// Token: 0x040012ED RID: 4845
	private float TimeX = 1f;

	// Token: 0x040012EE RID: 4846
	private Material SCMaterial;

	// Token: 0x040012EF RID: 4847
	[Range(1f, 10f)]
	public float EdgeWeight = 1f;
}
