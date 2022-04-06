using System;
using UnityEngine;

// Token: 0x02000228 RID: 552
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Blood_Fast")]
public class CameraFilterPack_Vision_Blood_Fast : MonoBehaviour
{
	// Token: 0x1700032C RID: 812
	// (get) Token: 0x060011D5 RID: 4565 RVA: 0x00089DAB File Offset: 0x00087FAB
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

	// Token: 0x060011D6 RID: 4566 RVA: 0x00089DDF File Offset: 0x00087FDF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Blood_Fast");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011D7 RID: 4567 RVA: 0x00089E00 File Offset: 0x00088000
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

	// Token: 0x060011D8 RID: 4568 RVA: 0x00089EF8 File Offset: 0x000880F8
	private void Update()
	{
	}

	// Token: 0x060011D9 RID: 4569 RVA: 0x00089EFA File Offset: 0x000880FA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001674 RID: 5748
	public Shader SCShader;

	// Token: 0x04001675 RID: 5749
	private float TimeX = 1f;

	// Token: 0x04001676 RID: 5750
	private Material SCMaterial;

	// Token: 0x04001677 RID: 5751
	[Range(0.01f, 1f)]
	public float HoleSize = 0.6f;

	// Token: 0x04001678 RID: 5752
	[Range(-1f, 1f)]
	public float HoleSmooth = 0.3f;

	// Token: 0x04001679 RID: 5753
	[Range(-2f, 2f)]
	public float Color1 = 0.2f;

	// Token: 0x0400167A RID: 5754
	[Range(-2f, 2f)]
	public float Color2 = 0.9f;
}
