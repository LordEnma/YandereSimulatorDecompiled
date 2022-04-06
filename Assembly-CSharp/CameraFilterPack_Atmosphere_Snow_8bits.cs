using System;
using UnityEngine;

// Token: 0x02000125 RID: 293
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/Snow_8bits")]
public class CameraFilterPack_Atmosphere_Snow_8bits : MonoBehaviour
{
	// Token: 0x17000229 RID: 553
	// (get) Token: 0x06000B5E RID: 2910 RVA: 0x0006CDDD File Offset: 0x0006AFDD
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

	// Token: 0x06000B5F RID: 2911 RVA: 0x0006CE11 File Offset: 0x0006B011
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Atmosphere_Snow_8bits");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B60 RID: 2912 RVA: 0x0006CE34 File Offset: 0x0006B034
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
			this.material.SetFloat("_Value", this.Threshold);
			this.material.SetFloat("_Value2", this.Size);
			this.material.SetFloat("_Value3", this.DirectionX);
			this.material.SetFloat("_Value4", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B61 RID: 2913 RVA: 0x0006CF2C File Offset: 0x0006B12C
	private void Update()
	{
	}

	// Token: 0x06000B62 RID: 2914 RVA: 0x0006CF2E File Offset: 0x0006B12E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F8E RID: 3982
	public Shader SCShader;

	// Token: 0x04000F8F RID: 3983
	private float TimeX = 1f;

	// Token: 0x04000F90 RID: 3984
	private Material SCMaterial;

	// Token: 0x04000F91 RID: 3985
	[Range(0.9f, 2f)]
	public float Threshold = 1f;

	// Token: 0x04000F92 RID: 3986
	[Range(8f, 256f)]
	public float Size = 64f;

	// Token: 0x04000F93 RID: 3987
	[Range(-0.5f, 0.5f)]
	public float DirectionX;

	// Token: 0x04000F94 RID: 3988
	[Range(0f, 1f)]
	public float Fade = 1f;
}
