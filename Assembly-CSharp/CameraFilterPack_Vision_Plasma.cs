using System;
using UnityEngine;

// Token: 0x0200022C RID: 556
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Plasma")]
public class CameraFilterPack_Vision_Plasma : MonoBehaviour
{
	// Token: 0x17000330 RID: 816
	// (get) Token: 0x060011EB RID: 4587 RVA: 0x0008A064 File Offset: 0x00088264
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

	// Token: 0x060011EC RID: 4588 RVA: 0x0008A098 File Offset: 0x00088298
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Plasma");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011ED RID: 4589 RVA: 0x0008A0BC File Offset: 0x000882BC
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

	// Token: 0x060011EE RID: 4590 RVA: 0x0008A1B4 File Offset: 0x000883B4
	private void Update()
	{
	}

	// Token: 0x060011EF RID: 4591 RVA: 0x0008A1B6 File Offset: 0x000883B6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400168D RID: 5773
	public Shader SCShader;

	// Token: 0x0400168E RID: 5774
	private float TimeX = 1f;

	// Token: 0x0400168F RID: 5775
	private Material SCMaterial;

	// Token: 0x04001690 RID: 5776
	[Range(-2f, 2f)]
	public float Value = 0.6f;

	// Token: 0x04001691 RID: 5777
	[Range(-2f, 2f)]
	public float Value2 = 0.2f;

	// Token: 0x04001692 RID: 5778
	[Range(0f, 60f)]
	public float Intensity = 15f;

	// Token: 0x04001693 RID: 5779
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
