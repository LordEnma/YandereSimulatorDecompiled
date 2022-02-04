using System;
using UnityEngine;

// Token: 0x020001AB RID: 427
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/DarkMatter")]
public class CameraFilterPack_FX_DarkMatter : MonoBehaviour
{
	// Token: 0x170002AF RID: 687
	// (get) Token: 0x06000EC1 RID: 3777 RVA: 0x0007B4C1 File Offset: 0x000796C1
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

	// Token: 0x06000EC2 RID: 3778 RVA: 0x0007B4F5 File Offset: 0x000796F5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_DarkMatter");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EC3 RID: 3779 RVA: 0x0007B518 File Offset: 0x00079718
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
			this.material.SetFloat("_Value", this.Speed);
			this.material.SetFloat("_Value2", this.Intensity);
			this.material.SetFloat("_Value3", this.PosX);
			this.material.SetFloat("_Value4", this.PosY);
			this.material.SetFloat("_Value5", this.Zoom);
			this.material.SetFloat("_Value6", this.DarkIntensity);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EC4 RID: 3780 RVA: 0x0007B63C File Offset: 0x0007983C
	private void Update()
	{
	}

	// Token: 0x06000EC5 RID: 3781 RVA: 0x0007B63E File Offset: 0x0007983E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400130A RID: 4874
	public Shader SCShader;

	// Token: 0x0400130B RID: 4875
	private float TimeX = 1f;

	// Token: 0x0400130C RID: 4876
	private Material SCMaterial;

	// Token: 0x0400130D RID: 4877
	[Range(-10f, 10f)]
	public float Speed = 0.8f;

	// Token: 0x0400130E RID: 4878
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x0400130F RID: 4879
	[Range(-1f, 2f)]
	public float PosX = 0.5f;

	// Token: 0x04001310 RID: 4880
	[Range(-1f, 2f)]
	public float PosY = 0.5f;

	// Token: 0x04001311 RID: 4881
	[Range(-2f, 2f)]
	public float Zoom = 0.33f;

	// Token: 0x04001312 RID: 4882
	[Range(0f, 5f)]
	public float DarkIntensity = 2f;
}
