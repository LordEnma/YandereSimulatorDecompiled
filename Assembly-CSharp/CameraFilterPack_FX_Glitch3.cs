using System;
using UnityEngine;

// Token: 0x020001B4 RID: 436
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Glitch3")]
public class CameraFilterPack_FX_Glitch3 : MonoBehaviour
{
	// Token: 0x170002B9 RID: 697
	// (get) Token: 0x06000EFA RID: 3834 RVA: 0x0007C2C8 File Offset: 0x0007A4C8
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

	// Token: 0x06000EFB RID: 3835 RVA: 0x0007C2FC File Offset: 0x0007A4FC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Glitch3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EFC RID: 3836 RVA: 0x0007C320 File Offset: 0x0007A520
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
			this.material.SetFloat("_Glitch", this._Glitch);
			this.material.SetFloat("_Noise", this._Noise);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EFD RID: 3837 RVA: 0x0007C3EC File Offset: 0x0007A5EC
	private void Update()
	{
	}

	// Token: 0x06000EFE RID: 3838 RVA: 0x0007C3EE File Offset: 0x0007A5EE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001347 RID: 4935
	public Shader SCShader;

	// Token: 0x04001348 RID: 4936
	private float TimeX = 1f;

	// Token: 0x04001349 RID: 4937
	private Material SCMaterial;

	// Token: 0x0400134A RID: 4938
	[Range(0f, 1f)]
	public float _Glitch = 1f;

	// Token: 0x0400134B RID: 4939
	[Range(0f, 1f)]
	public float _Noise = 1f;
}
