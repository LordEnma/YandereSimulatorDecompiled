using System;
using UnityEngine;

// Token: 0x020001BC RID: 444
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Plasma")]
public class CameraFilterPack_FX_Plasma : MonoBehaviour
{
	// Token: 0x170002C0 RID: 704
	// (get) Token: 0x06000F27 RID: 3879 RVA: 0x0007CD94 File Offset: 0x0007AF94
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

	// Token: 0x06000F28 RID: 3880 RVA: 0x0007CDC8 File Offset: 0x0007AFC8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Plasma");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F29 RID: 3881 RVA: 0x0007CDEC File Offset: 0x0007AFEC
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F2A RID: 3882 RVA: 0x0007CEA2 File Offset: 0x0007B0A2
	private void Update()
	{
	}

	// Token: 0x06000F2B RID: 3883 RVA: 0x0007CEA4 File Offset: 0x0007B0A4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400136A RID: 4970
	public Shader SCShader;

	// Token: 0x0400136B RID: 4971
	private float TimeX = 1f;

	// Token: 0x0400136C RID: 4972
	private Material SCMaterial;

	// Token: 0x0400136D RID: 4973
	[Range(0f, 20f)]
	private float Value = 6f;
}
