using System;
using UnityEngine;

// Token: 0x020001A9 RID: 425
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Ascii")]
public class CameraFilterPack_FX_Ascii : MonoBehaviour
{
	// Token: 0x170002AE RID: 686
	// (get) Token: 0x06000EB8 RID: 3768 RVA: 0x0007B161 File Offset: 0x00079361
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

	// Token: 0x06000EB9 RID: 3769 RVA: 0x0007B195 File Offset: 0x00079395
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Ascii");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EBA RID: 3770 RVA: 0x0007B1B8 File Offset: 0x000793B8
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
			this.material.SetFloat("Value", this.Value);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EBB RID: 3771 RVA: 0x0007B284 File Offset: 0x00079484
	private void Update()
	{
	}

	// Token: 0x06000EBC RID: 3772 RVA: 0x0007B286 File Offset: 0x00079486
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001300 RID: 4864
	public Shader SCShader;

	// Token: 0x04001301 RID: 4865
	[Range(0f, 2f)]
	public float Value = 1f;

	// Token: 0x04001302 RID: 4866
	[Range(0.01f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001303 RID: 4867
	private float TimeX = 1f;

	// Token: 0x04001304 RID: 4868
	private Material SCMaterial;
}
