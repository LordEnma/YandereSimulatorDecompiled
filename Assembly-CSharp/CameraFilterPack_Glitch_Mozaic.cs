using System;
using UnityEngine;

// Token: 0x020001CC RID: 460
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Mozaic")]
public class CameraFilterPack_Glitch_Mozaic : MonoBehaviour
{
	// Token: 0x170002D0 RID: 720
	// (get) Token: 0x06000F87 RID: 3975 RVA: 0x0007EC2D File Offset: 0x0007CE2D
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

	// Token: 0x06000F88 RID: 3976 RVA: 0x0007EC61 File Offset: 0x0007CE61
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Glitch_Mozaic");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F89 RID: 3977 RVA: 0x0007EC84 File Offset: 0x0007CE84
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
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F8A RID: 3978 RVA: 0x0007ED7C File Offset: 0x0007CF7C
	private void Update()
	{
	}

	// Token: 0x06000F8B RID: 3979 RVA: 0x0007ED7E File Offset: 0x0007CF7E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013F4 RID: 5108
	public Shader SCShader;

	// Token: 0x040013F5 RID: 5109
	private float TimeX = 1f;

	// Token: 0x040013F6 RID: 5110
	private Material SCMaterial;

	// Token: 0x040013F7 RID: 5111
	[Range(0.001f, 10f)]
	public float Intensity = 1f;

	// Token: 0x040013F8 RID: 5112
	[Range(0f, 10f)]
	private float Value2 = 1f;

	// Token: 0x040013F9 RID: 5113
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x040013FA RID: 5114
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
