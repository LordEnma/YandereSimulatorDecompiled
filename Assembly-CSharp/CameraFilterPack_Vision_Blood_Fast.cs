using System;
using UnityEngine;

// Token: 0x02000228 RID: 552
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Blood_Fast")]
public class CameraFilterPack_Vision_Blood_Fast : MonoBehaviour
{
	// Token: 0x1700032C RID: 812
	// (get) Token: 0x060011D3 RID: 4563 RVA: 0x000897E7 File Offset: 0x000879E7
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

	// Token: 0x060011D4 RID: 4564 RVA: 0x0008981B File Offset: 0x00087A1B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Blood_Fast");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011D5 RID: 4565 RVA: 0x0008983C File Offset: 0x00087A3C
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

	// Token: 0x060011D6 RID: 4566 RVA: 0x00089934 File Offset: 0x00087B34
	private void Update()
	{
	}

	// Token: 0x060011D7 RID: 4567 RVA: 0x00089936 File Offset: 0x00087B36
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001664 RID: 5732
	public Shader SCShader;

	// Token: 0x04001665 RID: 5733
	private float TimeX = 1f;

	// Token: 0x04001666 RID: 5734
	private Material SCMaterial;

	// Token: 0x04001667 RID: 5735
	[Range(0.01f, 1f)]
	public float HoleSize = 0.6f;

	// Token: 0x04001668 RID: 5736
	[Range(-1f, 1f)]
	public float HoleSmooth = 0.3f;

	// Token: 0x04001669 RID: 5737
	[Range(-2f, 2f)]
	public float Color1 = 0.2f;

	// Token: 0x0400166A RID: 5738
	[Range(-2f, 2f)]
	public float Color2 = 0.9f;
}
