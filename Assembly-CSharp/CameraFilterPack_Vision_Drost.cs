using System;
using UnityEngine;

// Token: 0x0200022A RID: 554
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Drost")]
public class CameraFilterPack_Vision_Drost : MonoBehaviour
{
	// Token: 0x1700032E RID: 814
	// (get) Token: 0x060011DF RID: 4575 RVA: 0x00089C7F File Offset: 0x00087E7F
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

	// Token: 0x060011E0 RID: 4576 RVA: 0x00089CB3 File Offset: 0x00087EB3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Drost");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011E1 RID: 4577 RVA: 0x00089CD4 File Offset: 0x00087ED4
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

	// Token: 0x060011E2 RID: 4578 RVA: 0x00089DCC File Offset: 0x00087FCC
	private void Update()
	{
	}

	// Token: 0x060011E3 RID: 4579 RVA: 0x00089DCE File Offset: 0x00087FCE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400167B RID: 5755
	public Shader SCShader;

	// Token: 0x0400167C RID: 5756
	private float TimeX = 1f;

	// Token: 0x0400167D RID: 5757
	private Material SCMaterial;

	// Token: 0x0400167E RID: 5758
	[Range(0f, 0.4f)]
	public float Intensity = 0.4f;

	// Token: 0x0400167F RID: 5759
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04001680 RID: 5760
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x04001681 RID: 5761
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
