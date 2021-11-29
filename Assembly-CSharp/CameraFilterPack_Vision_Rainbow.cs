using System;
using UnityEngine;

// Token: 0x0200022D RID: 557
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Rainbow")]
public class CameraFilterPack_Vision_Rainbow : MonoBehaviour
{
	// Token: 0x17000332 RID: 818
	// (get) Token: 0x060011F3 RID: 4595 RVA: 0x00089E13 File Offset: 0x00088013
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

	// Token: 0x060011F4 RID: 4596 RVA: 0x00089E47 File Offset: 0x00088047
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Rainbow");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011F5 RID: 4597 RVA: 0x00089E68 File Offset: 0x00088068
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
			this.material.SetFloat("_Value2", this.PosX);
			this.material.SetFloat("_Value3", this.PosY);
			this.material.SetFloat("_Value4", this.Colors);
			this.material.SetFloat("_Value5", this.Vision);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011F6 RID: 4598 RVA: 0x00089F76 File Offset: 0x00088176
	private void Update()
	{
	}

	// Token: 0x060011F7 RID: 4599 RVA: 0x00089F78 File Offset: 0x00088178
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400168A RID: 5770
	public Shader SCShader;

	// Token: 0x0400168B RID: 5771
	private float TimeX = 1f;

	// Token: 0x0400168C RID: 5772
	private Material SCMaterial;

	// Token: 0x0400168D RID: 5773
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x0400168E RID: 5774
	[Range(0f, 1f)]
	public float PosX = 0.5f;

	// Token: 0x0400168F RID: 5775
	[Range(0f, 1f)]
	public float PosY = 0.5f;

	// Token: 0x04001690 RID: 5776
	[Range(0f, 5f)]
	public float Colors = 0.5f;

	// Token: 0x04001691 RID: 5777
	[Range(0f, 1f)]
	public float Vision = 0.5f;
}
