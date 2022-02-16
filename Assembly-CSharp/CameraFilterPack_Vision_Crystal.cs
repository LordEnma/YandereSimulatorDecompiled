using System;
using UnityEngine;

// Token: 0x02000229 RID: 553
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Crystal")]
public class CameraFilterPack_Vision_Crystal : MonoBehaviour
{
	// Token: 0x1700032D RID: 813
	// (get) Token: 0x060011D9 RID: 4569 RVA: 0x0008987B File Offset: 0x00087A7B
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

	// Token: 0x060011DA RID: 4570 RVA: 0x000898AF File Offset: 0x00087AAF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Crystal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011DB RID: 4571 RVA: 0x000898D0 File Offset: 0x00087AD0
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
			this.material.SetFloat("_Value2", this.X);
			this.material.SetFloat("_Value3", this.Y);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011DC RID: 4572 RVA: 0x000899C8 File Offset: 0x00087BC8
	private void Update()
	{
	}

	// Token: 0x060011DD RID: 4573 RVA: 0x000899CA File Offset: 0x00087BCA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400166B RID: 5739
	public Shader SCShader;

	// Token: 0x0400166C RID: 5740
	private float TimeX = 1f;

	// Token: 0x0400166D RID: 5741
	private Material SCMaterial;

	// Token: 0x0400166E RID: 5742
	[Range(-10f, 10f)]
	public float Value = 1f;

	// Token: 0x0400166F RID: 5743
	[Range(-1f, 1f)]
	public float X = 1f;

	// Token: 0x04001670 RID: 5744
	[Range(-1f, 1f)]
	public float Y = 1f;

	// Token: 0x04001671 RID: 5745
	[Range(-1f, 1f)]
	private float Value4 = 1f;
}
