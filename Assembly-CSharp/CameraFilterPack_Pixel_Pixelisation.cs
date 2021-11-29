using System;
using UnityEngine;

// Token: 0x020001F6 RID: 502
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/Pixelisation")]
public class CameraFilterPack_Pixel_Pixelisation : MonoBehaviour
{
	// Token: 0x170002FB RID: 763
	// (get) Token: 0x060010A8 RID: 4264 RVA: 0x000845C9 File Offset: 0x000827C9
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

	// Token: 0x060010A9 RID: 4265 RVA: 0x000845FD File Offset: 0x000827FD
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixel_Pixelisation");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010AA RID: 4266 RVA: 0x00084620 File Offset: 0x00082820
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

	// Token: 0x060010AB RID: 4267 RVA: 0x00084692 File Offset: 0x00082892
	private void Update()
	{
	}

	// Token: 0x060010AC RID: 4268 RVA: 0x00084694 File Offset: 0x00082894
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400152D RID: 5421
	public Shader SCShader;

	// Token: 0x0400152E RID: 5422
	[Range(0.6f, 120f)]
	public float _Pixelisation = 8f;

	// Token: 0x0400152F RID: 5423
	[Range(0.6f, 120f)]
	public float _SizeX = 1f;

	// Token: 0x04001530 RID: 5424
	[Range(0.6f, 120f)]
	public float _SizeY = 1f;

	// Token: 0x04001531 RID: 5425
	private Material SCMaterial;
}
