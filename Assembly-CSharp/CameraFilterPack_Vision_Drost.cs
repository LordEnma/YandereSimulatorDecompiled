using System;
using UnityEngine;

// Token: 0x0200022A RID: 554
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Drost")]
public class CameraFilterPack_Vision_Drost : MonoBehaviour
{
	// Token: 0x1700032E RID: 814
	// (get) Token: 0x060011DE RID: 4574 RVA: 0x000898D3 File Offset: 0x00087AD3
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

	// Token: 0x060011DF RID: 4575 RVA: 0x00089907 File Offset: 0x00087B07
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Drost");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011E0 RID: 4576 RVA: 0x00089928 File Offset: 0x00087B28
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
			this.material.SetFloat("_Value2", this.Speed);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011E1 RID: 4577 RVA: 0x00089A20 File Offset: 0x00087C20
	private void Update()
	{
	}

	// Token: 0x060011E2 RID: 4578 RVA: 0x00089A22 File Offset: 0x00087C22
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400166F RID: 5743
	public Shader SCShader;

	// Token: 0x04001670 RID: 5744
	private float TimeX = 1f;

	// Token: 0x04001671 RID: 5745
	private Material SCMaterial;

	// Token: 0x04001672 RID: 5746
	[Range(0f, 0.4f)]
	public float Intensity = 0.4f;

	// Token: 0x04001673 RID: 5747
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04001674 RID: 5748
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x04001675 RID: 5749
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
