using System;
using UnityEngine;

// Token: 0x02000227 RID: 551
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Blood")]
public class CameraFilterPack_Vision_Blood : MonoBehaviour
{
	// Token: 0x1700032B RID: 811
	// (get) Token: 0x060011CF RID: 4559 RVA: 0x00089C00 File Offset: 0x00087E00
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

	// Token: 0x060011D0 RID: 4560 RVA: 0x00089C34 File Offset: 0x00087E34
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Blood");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011D1 RID: 4561 RVA: 0x00089C58 File Offset: 0x00087E58
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
			this.material.SetFloat("_Value", this.HoleSize);
			this.material.SetFloat("_Value2", this.HoleSmooth);
			this.material.SetFloat("_Value3", this.Color1);
			this.material.SetFloat("_Value4", this.Color2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011D2 RID: 4562 RVA: 0x00089D50 File Offset: 0x00087F50
	private void Update()
	{
	}

	// Token: 0x060011D3 RID: 4563 RVA: 0x00089D52 File Offset: 0x00087F52
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400166D RID: 5741
	public Shader SCShader;

	// Token: 0x0400166E RID: 5742
	private float TimeX = 1f;

	// Token: 0x0400166F RID: 5743
	private Material SCMaterial;

	// Token: 0x04001670 RID: 5744
	[Range(0.01f, 1f)]
	public float HoleSize = 0.6f;

	// Token: 0x04001671 RID: 5745
	[Range(-1f, 1f)]
	public float HoleSmooth = 0.3f;

	// Token: 0x04001672 RID: 5746
	[Range(-2f, 2f)]
	public float Color1 = 0.2f;

	// Token: 0x04001673 RID: 5747
	[Range(-2f, 2f)]
	public float Color2 = 0.9f;
}
