using System;
using UnityEngine;

// Token: 0x020001AB RID: 427
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/DigitalMatrix")]
public class CameraFilterPack_FX_DigitalMatrix : MonoBehaviour
{
	// Token: 0x170002B0 RID: 688
	// (get) Token: 0x06000EC4 RID: 3780 RVA: 0x0007B4C0 File Offset: 0x000796C0
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

	// Token: 0x06000EC5 RID: 3781 RVA: 0x0007B4F4 File Offset: 0x000796F4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_DigitalMatrix");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EC6 RID: 3782 RVA: 0x0007B518 File Offset: 0x00079718
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.ColorR);
			this.material.SetFloat("_Value3", this.ColorG);
			this.material.SetFloat("_Value4", this.ColorB);
			this.material.SetFloat("_Value5", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EC7 RID: 3783 RVA: 0x0007B626 File Offset: 0x00079826
	private void Update()
	{
	}

	// Token: 0x06000EC8 RID: 3784 RVA: 0x0007B628 File Offset: 0x00079828
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400130E RID: 4878
	public Shader SCShader;

	// Token: 0x0400130F RID: 4879
	private float TimeX = 1f;

	// Token: 0x04001310 RID: 4880
	private Material SCMaterial;

	// Token: 0x04001311 RID: 4881
	[Range(0.4f, 5f)]
	public float Size = 1f;

	// Token: 0x04001312 RID: 4882
	[Range(-10f, 10f)]
	public float Speed = 1f;

	// Token: 0x04001313 RID: 4883
	[Range(-1f, 1f)]
	public float ColorR = -1f;

	// Token: 0x04001314 RID: 4884
	[Range(-1f, 1f)]
	public float ColorG = 1f;

	// Token: 0x04001315 RID: 4885
	[Range(-1f, 1f)]
	public float ColorB = -1f;
}
