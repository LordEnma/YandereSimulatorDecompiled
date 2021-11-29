using System;
using UnityEngine;

// Token: 0x02000231 RID: 561
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Warp2")]
public class CameraFilterPack_Vision_Warp2 : MonoBehaviour
{
	// Token: 0x17000336 RID: 822
	// (get) Token: 0x0600120B RID: 4619 RVA: 0x0008A613 File Offset: 0x00088813
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

	// Token: 0x0600120C RID: 4620 RVA: 0x0008A647 File Offset: 0x00088847
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Warp2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600120D RID: 4621 RVA: 0x0008A668 File Offset: 0x00088868
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
			this.material.SetFloat("_Value3", this.Intensity);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600120E RID: 4622 RVA: 0x0008A760 File Offset: 0x00088960
	private void Update()
	{
	}

	// Token: 0x0600120F RID: 4623 RVA: 0x0008A762 File Offset: 0x00088962
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040016AF RID: 5807
	public Shader SCShader;

	// Token: 0x040016B0 RID: 5808
	private float TimeX = 1f;

	// Token: 0x040016B1 RID: 5809
	private Material SCMaterial;

	// Token: 0x040016B2 RID: 5810
	[Range(0f, 1f)]
	public float Value = 0.5f;

	// Token: 0x040016B3 RID: 5811
	[Range(0f, 1f)]
	public float Value2 = 0.2f;

	// Token: 0x040016B4 RID: 5812
	[Range(-1f, 2f)]
	public float Intensity = 1f;

	// Token: 0x040016B5 RID: 5813
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
