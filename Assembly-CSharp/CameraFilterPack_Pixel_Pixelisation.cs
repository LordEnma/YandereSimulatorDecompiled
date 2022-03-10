using System;
using UnityEngine;

// Token: 0x020001F7 RID: 503
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/Pixelisation")]
public class CameraFilterPack_Pixel_Pixelisation : MonoBehaviour
{
	// Token: 0x170002FB RID: 763
	// (get) Token: 0x060010AC RID: 4268 RVA: 0x00084B6D File Offset: 0x00082D6D
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

	// Token: 0x060010AD RID: 4269 RVA: 0x00084BA1 File Offset: 0x00082DA1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixel_Pixelisation");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010AE RID: 4270 RVA: 0x00084BC4 File Offset: 0x00082DC4
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.material.SetFloat("_Val", this._Pixelisation);
			this.material.SetFloat("_Val2", this._SizeX);
			this.material.SetFloat("_Val3", this._SizeY);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010AF RID: 4271 RVA: 0x00084C36 File Offset: 0x00082E36
	private void Update()
	{
	}

	// Token: 0x060010B0 RID: 4272 RVA: 0x00084C38 File Offset: 0x00082E38
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400153E RID: 5438
	public Shader SCShader;

	// Token: 0x0400153F RID: 5439
	[Range(0.6f, 120f)]
	public float _Pixelisation = 8f;

	// Token: 0x04001540 RID: 5440
	[Range(0.6f, 120f)]
	public float _SizeX = 1f;

	// Token: 0x04001541 RID: 5441
	[Range(0.6f, 120f)]
	public float _SizeY = 1f;

	// Token: 0x04001542 RID: 5442
	private Material SCMaterial;
}
