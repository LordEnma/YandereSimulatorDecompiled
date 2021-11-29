using System;
using UnityEngine;

// Token: 0x02000124 RID: 292
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/Snow_8bits")]
public class CameraFilterPack_Atmosphere_Snow_8bits : MonoBehaviour
{
	// Token: 0x17000229 RID: 553
	// (get) Token: 0x06000B58 RID: 2904 RVA: 0x0006C3BD File Offset: 0x0006A5BD
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

	// Token: 0x06000B59 RID: 2905 RVA: 0x0006C3F1 File Offset: 0x0006A5F1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Atmosphere_Snow_8bits");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B5A RID: 2906 RVA: 0x0006C414 File Offset: 0x0006A614
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

	// Token: 0x06000B5B RID: 2907 RVA: 0x0006C50C File Offset: 0x0006A70C
	private void Update()
	{
	}

	// Token: 0x06000B5C RID: 2908 RVA: 0x0006C50E File Offset: 0x0006A70E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F76 RID: 3958
	public Shader SCShader;

	// Token: 0x04000F77 RID: 3959
	private float TimeX = 1f;

	// Token: 0x04000F78 RID: 3960
	private Material SCMaterial;

	// Token: 0x04000F79 RID: 3961
	[Range(0.9f, 2f)]
	public float Threshold = 1f;

	// Token: 0x04000F7A RID: 3962
	[Range(8f, 256f)]
	public float Size = 64f;

	// Token: 0x04000F7B RID: 3963
	[Range(-0.5f, 0.5f)]
	public float DirectionX;

	// Token: 0x04000F7C RID: 3964
	[Range(0f, 1f)]
	public float Fade = 1f;
}
