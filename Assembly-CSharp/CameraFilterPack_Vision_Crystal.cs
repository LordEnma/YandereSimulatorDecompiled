using System;
using UnityEngine;

// Token: 0x02000229 RID: 553
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Crystal")]
public class CameraFilterPack_Vision_Crystal : MonoBehaviour
{
	// Token: 0x1700032D RID: 813
	// (get) Token: 0x060011DB RID: 4571 RVA: 0x00089F53 File Offset: 0x00088153
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

	// Token: 0x060011DC RID: 4572 RVA: 0x00089F87 File Offset: 0x00088187
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Crystal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011DD RID: 4573 RVA: 0x00089FA8 File Offset: 0x000881A8
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

	// Token: 0x060011DE RID: 4574 RVA: 0x0008A0A0 File Offset: 0x000882A0
	private void Update()
	{
	}

	// Token: 0x060011DF RID: 4575 RVA: 0x0008A0A2 File Offset: 0x000882A2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400167B RID: 5755
	public Shader SCShader;

	// Token: 0x0400167C RID: 5756
	private float TimeX = 1f;

	// Token: 0x0400167D RID: 5757
	private Material SCMaterial;

	// Token: 0x0400167E RID: 5758
	[Range(-10f, 10f)]
	public float Value = 1f;

	// Token: 0x0400167F RID: 5759
	[Range(-1f, 1f)]
	public float X = 1f;

	// Token: 0x04001680 RID: 5760
	[Range(-1f, 1f)]
	public float Y = 1f;

	// Token: 0x04001681 RID: 5761
	[Range(-1f, 1f)]
	private float Value4 = 1f;
}
