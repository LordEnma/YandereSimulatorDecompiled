using System;
using UnityEngine;

// Token: 0x02000229 RID: 553
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Crystal")]
public class CameraFilterPack_Vision_Crystal : MonoBehaviour
{
	// Token: 0x1700032D RID: 813
	// (get) Token: 0x060011D8 RID: 4568 RVA: 0x0008972B File Offset: 0x0008792B
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

	// Token: 0x060011D9 RID: 4569 RVA: 0x0008975F File Offset: 0x0008795F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Crystal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011DA RID: 4570 RVA: 0x00089780 File Offset: 0x00087980
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

	// Token: 0x060011DB RID: 4571 RVA: 0x00089878 File Offset: 0x00087A78
	private void Update()
	{
	}

	// Token: 0x060011DC RID: 4572 RVA: 0x0008987A File Offset: 0x00087A7A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001668 RID: 5736
	public Shader SCShader;

	// Token: 0x04001669 RID: 5737
	private float TimeX = 1f;

	// Token: 0x0400166A RID: 5738
	private Material SCMaterial;

	// Token: 0x0400166B RID: 5739
	[Range(-10f, 10f)]
	public float Value = 1f;

	// Token: 0x0400166C RID: 5740
	[Range(-1f, 1f)]
	public float X = 1f;

	// Token: 0x0400166D RID: 5741
	[Range(-1f, 1f)]
	public float Y = 1f;

	// Token: 0x0400166E RID: 5742
	[Range(-1f, 1f)]
	private float Value4 = 1f;
}
