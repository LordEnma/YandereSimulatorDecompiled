using System;
using UnityEngine;

// Token: 0x02000200 RID: 512
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Sharpen/Sharpen")]
public class CameraFilterPack_Sharpen_Sharpen : MonoBehaviour
{
	// Token: 0x17000304 RID: 772
	// (get) Token: 0x060010E2 RID: 4322 RVA: 0x000857DC File Offset: 0x000839DC
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

	// Token: 0x060010E3 RID: 4323 RVA: 0x00085810 File Offset: 0x00083A10
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Sharpen_Sharpen");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010E4 RID: 4324 RVA: 0x00085834 File Offset: 0x00083A34
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

	// Token: 0x060010E5 RID: 4325 RVA: 0x00085900 File Offset: 0x00083B00
	private void Update()
	{
	}

	// Token: 0x060010E6 RID: 4326 RVA: 0x00085902 File Offset: 0x00083B02
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001570 RID: 5488
	public Shader SCShader;

	// Token: 0x04001571 RID: 5489
	[Range(0.001f, 100f)]
	public float Value = 4f;

	// Token: 0x04001572 RID: 5490
	[Range(0.001f, 32f)]
	public float Value2 = 1f;

	// Token: 0x04001573 RID: 5491
	private float TimeX = 1f;

	// Token: 0x04001574 RID: 5492
	private Material SCMaterial;
}
