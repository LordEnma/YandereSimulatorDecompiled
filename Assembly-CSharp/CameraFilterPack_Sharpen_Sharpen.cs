using System;
using UnityEngine;

// Token: 0x020001FF RID: 511
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Sharpen/Sharpen")]
public class CameraFilterPack_Sharpen_Sharpen : MonoBehaviour
{
	// Token: 0x17000304 RID: 772
	// (get) Token: 0x060010DF RID: 4319 RVA: 0x000855E4 File Offset: 0x000837E4
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

	// Token: 0x060010E0 RID: 4320 RVA: 0x00085618 File Offset: 0x00083818
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Sharpen_Sharpen");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010E1 RID: 4321 RVA: 0x0008563C File Offset: 0x0008383C
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
			this.material.SetFloat("_Value2", this.Value2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010E2 RID: 4322 RVA: 0x00085708 File Offset: 0x00083908
	private void Update()
	{
	}

	// Token: 0x060010E3 RID: 4323 RVA: 0x0008570A File Offset: 0x0008390A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400156B RID: 5483
	public Shader SCShader;

	// Token: 0x0400156C RID: 5484
	[Range(0.001f, 100f)]
	public float Value = 4f;

	// Token: 0x0400156D RID: 5485
	[Range(0.001f, 32f)]
	public float Value2 = 1f;

	// Token: 0x0400156E RID: 5486
	private float TimeX = 1f;

	// Token: 0x0400156F RID: 5487
	private Material SCMaterial;
}
