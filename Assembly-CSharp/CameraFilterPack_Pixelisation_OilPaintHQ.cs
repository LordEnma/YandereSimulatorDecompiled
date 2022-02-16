using System;
using UnityEngine;

// Token: 0x020001FB RID: 507
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/OilPaintHQ")]
public class CameraFilterPack_Pixelisation_OilPaintHQ : MonoBehaviour
{
	// Token: 0x170002FF RID: 767
	// (get) Token: 0x060010C4 RID: 4292 RVA: 0x00084F84 File Offset: 0x00083184
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

	// Token: 0x060010C5 RID: 4293 RVA: 0x00084FB8 File Offset: 0x000831B8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixelisation_OilPaintHQ");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010C6 RID: 4294 RVA: 0x00084FDC File Offset: 0x000831DC
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetFloat("_Value", this.Value);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010C7 RID: 4295 RVA: 0x00085092 File Offset: 0x00083292
	private void Update()
	{
	}

	// Token: 0x060010C8 RID: 4296 RVA: 0x00085094 File Offset: 0x00083294
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001550 RID: 5456
	public Shader SCShader;

	// Token: 0x04001551 RID: 5457
	private float TimeX = 1f;

	// Token: 0x04001552 RID: 5458
	private Material SCMaterial;

	// Token: 0x04001553 RID: 5459
	[Range(0f, 5f)]
	public float Value = 2f;
}
