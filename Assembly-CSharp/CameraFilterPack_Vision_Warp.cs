using System;
using UnityEngine;

// Token: 0x02000231 RID: 561
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Warp")]
public class CameraFilterPack_Vision_Warp : MonoBehaviour
{
	// Token: 0x17000335 RID: 821
	// (get) Token: 0x0600120B RID: 4619 RVA: 0x0008AE8B File Offset: 0x0008908B
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

	// Token: 0x0600120C RID: 4620 RVA: 0x0008AEBF File Offset: 0x000890BF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Warp");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600120D RID: 4621 RVA: 0x0008AEE0 File Offset: 0x000890E0
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

	// Token: 0x0600120E RID: 4622 RVA: 0x0008AFD8 File Offset: 0x000891D8
	private void Update()
	{
	}

	// Token: 0x0600120F RID: 4623 RVA: 0x0008AFDA File Offset: 0x000891DA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040016C0 RID: 5824
	public Shader SCShader;

	// Token: 0x040016C1 RID: 5825
	private float TimeX = 1f;

	// Token: 0x040016C2 RID: 5826
	private Material SCMaterial;

	// Token: 0x040016C3 RID: 5827
	[Range(0f, 1f)]
	public float Value = 0.6f;

	// Token: 0x040016C4 RID: 5828
	[Range(0f, 1f)]
	public float Value2 = 0.6f;

	// Token: 0x040016C5 RID: 5829
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x040016C6 RID: 5830
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
