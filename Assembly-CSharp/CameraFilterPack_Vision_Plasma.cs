using System;
using UnityEngine;

// Token: 0x0200022B RID: 555
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Plasma")]
public class CameraFilterPack_Vision_Plasma : MonoBehaviour
{
	// Token: 0x17000330 RID: 816
	// (get) Token: 0x060011E7 RID: 4583 RVA: 0x00089AC0 File Offset: 0x00087CC0
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

	// Token: 0x060011E8 RID: 4584 RVA: 0x00089AF4 File Offset: 0x00087CF4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Plasma");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011E9 RID: 4585 RVA: 0x00089B18 File Offset: 0x00087D18
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

	// Token: 0x060011EA RID: 4586 RVA: 0x00089C10 File Offset: 0x00087E10
	private void Update()
	{
	}

	// Token: 0x060011EB RID: 4587 RVA: 0x00089C12 File Offset: 0x00087E12
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400167C RID: 5756
	public Shader SCShader;

	// Token: 0x0400167D RID: 5757
	private float TimeX = 1f;

	// Token: 0x0400167E RID: 5758
	private Material SCMaterial;

	// Token: 0x0400167F RID: 5759
	[Range(-2f, 2f)]
	public float Value = 0.6f;

	// Token: 0x04001680 RID: 5760
	[Range(-2f, 2f)]
	public float Value2 = 0.2f;

	// Token: 0x04001681 RID: 5761
	[Range(0f, 60f)]
	public float Intensity = 15f;

	// Token: 0x04001682 RID: 5762
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
