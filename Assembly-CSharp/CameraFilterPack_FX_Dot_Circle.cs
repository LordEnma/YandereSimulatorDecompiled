using System;
using UnityEngine;

// Token: 0x020001AD RID: 429
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Dot_Circle")]
public class CameraFilterPack_FX_Dot_Circle : MonoBehaviour
{
	// Token: 0x170002B2 RID: 690
	// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x0007B822 File Offset: 0x00079A22
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

	// Token: 0x06000ED1 RID: 3793 RVA: 0x0007B856 File Offset: 0x00079A56
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Dot_Circle");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000ED2 RID: 3794 RVA: 0x0007B878 File Offset: 0x00079A78
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

	// Token: 0x06000ED3 RID: 3795 RVA: 0x0007B92E File Offset: 0x00079B2E
	private void Update()
	{
	}

	// Token: 0x06000ED4 RID: 3796 RVA: 0x0007B930 File Offset: 0x00079B30
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400131C RID: 4892
	public Shader SCShader;

	// Token: 0x0400131D RID: 4893
	private float TimeX = 1f;

	// Token: 0x0400131E RID: 4894
	private Material SCMaterial;

	// Token: 0x0400131F RID: 4895
	[Range(4f, 32f)]
	public float Value = 7f;
}
