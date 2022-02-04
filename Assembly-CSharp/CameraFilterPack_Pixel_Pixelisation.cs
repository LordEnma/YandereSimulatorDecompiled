using System;
using UnityEngine;

// Token: 0x020001F7 RID: 503
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/Pixelisation")]
public class CameraFilterPack_Pixel_Pixelisation : MonoBehaviour
{
	// Token: 0x170002FB RID: 763
	// (get) Token: 0x060010AB RID: 4267 RVA: 0x000847C1 File Offset: 0x000829C1
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

	// Token: 0x060010AC RID: 4268 RVA: 0x000847F5 File Offset: 0x000829F5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixel_Pixelisation");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010AD RID: 4269 RVA: 0x00084818 File Offset: 0x00082A18
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

	// Token: 0x060010AE RID: 4270 RVA: 0x0008488A File Offset: 0x00082A8A
	private void Update()
	{
	}

	// Token: 0x060010AF RID: 4271 RVA: 0x0008488C File Offset: 0x00082A8C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001532 RID: 5426
	public Shader SCShader;

	// Token: 0x04001533 RID: 5427
	[Range(0.6f, 120f)]
	public float _Pixelisation = 8f;

	// Token: 0x04001534 RID: 5428
	[Range(0.6f, 120f)]
	public float _SizeX = 1f;

	// Token: 0x04001535 RID: 5429
	[Range(0.6f, 120f)]
	public float _SizeY = 1f;

	// Token: 0x04001536 RID: 5430
	private Material SCMaterial;
}
