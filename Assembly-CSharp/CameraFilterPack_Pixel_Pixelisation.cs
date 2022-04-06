using System;
using UnityEngine;

// Token: 0x020001F7 RID: 503
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/Pixelisation")]
public class CameraFilterPack_Pixel_Pixelisation : MonoBehaviour
{
	// Token: 0x170002FB RID: 763
	// (get) Token: 0x060010AE RID: 4270 RVA: 0x00084FE9 File Offset: 0x000831E9
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

	// Token: 0x060010AF RID: 4271 RVA: 0x0008501D File Offset: 0x0008321D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixel_Pixelisation");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010B0 RID: 4272 RVA: 0x00085040 File Offset: 0x00083240
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

	// Token: 0x060010B1 RID: 4273 RVA: 0x000850B2 File Offset: 0x000832B2
	private void Update()
	{
	}

	// Token: 0x060010B2 RID: 4274 RVA: 0x000850B4 File Offset: 0x000832B4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001545 RID: 5445
	public Shader SCShader;

	// Token: 0x04001546 RID: 5446
	[Range(0.6f, 120f)]
	public float _Pixelisation = 8f;

	// Token: 0x04001547 RID: 5447
	[Range(0.6f, 120f)]
	public float _SizeX = 1f;

	// Token: 0x04001548 RID: 5448
	[Range(0.6f, 120f)]
	public float _SizeY = 1f;

	// Token: 0x04001549 RID: 5449
	private Material SCMaterial;
}
