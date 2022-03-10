using System;
using UnityEngine;

// Token: 0x020001B0 RID: 432
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Drunk2")]
public class CameraFilterPack_FX_Drunk2 : MonoBehaviour
{
	// Token: 0x170002B4 RID: 692
	// (get) Token: 0x06000EE0 RID: 3808 RVA: 0x0007C169 File Offset: 0x0007A369
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

	// Token: 0x06000EE1 RID: 3809 RVA: 0x0007C19D File Offset: 0x0007A39D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Drunk2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EE2 RID: 3810 RVA: 0x0007C1C0 File Offset: 0x0007A3C0
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
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EE3 RID: 3811 RVA: 0x0007C2B8 File Offset: 0x0007A4B8
	private void Update()
	{
	}

	// Token: 0x06000EE4 RID: 3812 RVA: 0x0007C2BA File Offset: 0x0007A4BA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400133F RID: 4927
	public Shader SCShader;

	// Token: 0x04001340 RID: 4928
	private float TimeX = 1f;

	// Token: 0x04001341 RID: 4929
	private Material SCMaterial;

	// Token: 0x04001342 RID: 4930
	[Range(0f, 10f)]
	private float Value = 1f;

	// Token: 0x04001343 RID: 4931
	[Range(0f, 10f)]
	private float Value2 = 1f;

	// Token: 0x04001344 RID: 4932
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x04001345 RID: 4933
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
