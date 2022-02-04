using System;
using UnityEngine;

// Token: 0x02000150 RID: 336
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Radial")]
public class CameraFilterPack_Blur_Radial : MonoBehaviour
{
	// Token: 0x17000254 RID: 596
	// (get) Token: 0x06000C9C RID: 3228 RVA: 0x00072641 File Offset: 0x00070841
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

	// Token: 0x06000C9D RID: 3229 RVA: 0x00072675 File Offset: 0x00070875
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Radial");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C9E RID: 3230 RVA: 0x00072698 File Offset: 0x00070898
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
			this.material.SetFloat("_Value", this.Intensity);
			this.material.SetFloat("_Value2", this.MovX);
			this.material.SetFloat("_Value3", this.MovY);
			this.material.SetFloat("_Value4", this.blurWidth);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C9F RID: 3231 RVA: 0x00072790 File Offset: 0x00070990
	private void Update()
	{
	}

	// Token: 0x06000CA0 RID: 3232 RVA: 0x00072792 File Offset: 0x00070992
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010E0 RID: 4320
	public Shader SCShader;

	// Token: 0x040010E1 RID: 4321
	private float TimeX = 1f;

	// Token: 0x040010E2 RID: 4322
	private Material SCMaterial;

	// Token: 0x040010E3 RID: 4323
	[Range(-0.5f, 0.5f)]
	public float Intensity = 0.125f;

	// Token: 0x040010E4 RID: 4324
	[Range(-2f, 2f)]
	public float MovX = 0.5f;

	// Token: 0x040010E5 RID: 4325
	[Range(-2f, 2f)]
	public float MovY = 0.5f;

	// Token: 0x040010E6 RID: 4326
	[Range(0f, 10f)]
	private float blurWidth = 1f;
}
