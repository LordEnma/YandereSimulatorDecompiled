using System;
using UnityEngine;

// Token: 0x02000229 RID: 553
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Drost")]
public class CameraFilterPack_Vision_Drost : MonoBehaviour
{
	// Token: 0x1700032E RID: 814
	// (get) Token: 0x060011DB RID: 4571 RVA: 0x000896DB File Offset: 0x000878DB
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

	// Token: 0x060011DC RID: 4572 RVA: 0x0008970F File Offset: 0x0008790F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Drost");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011DD RID: 4573 RVA: 0x00089730 File Offset: 0x00087930
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

	// Token: 0x060011DE RID: 4574 RVA: 0x00089828 File Offset: 0x00087A28
	private void Update()
	{
	}

	// Token: 0x060011DF RID: 4575 RVA: 0x0008982A File Offset: 0x00087A2A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400166A RID: 5738
	public Shader SCShader;

	// Token: 0x0400166B RID: 5739
	private float TimeX = 1f;

	// Token: 0x0400166C RID: 5740
	private Material SCMaterial;

	// Token: 0x0400166D RID: 5741
	[Range(0f, 0.4f)]
	public float Intensity = 0.4f;

	// Token: 0x0400166E RID: 5742
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x0400166F RID: 5743
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x04001670 RID: 5744
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
