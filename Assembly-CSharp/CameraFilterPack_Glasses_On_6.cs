using System;
using UnityEngine;

// Token: 0x020001CB RID: 459
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Spy")]
public class CameraFilterPack_Glasses_On_6 : MonoBehaviour
{
	// Token: 0x170002CF RID: 719
	// (get) Token: 0x06000F84 RID: 3972 RVA: 0x0007F1A9 File Offset: 0x0007D3A9
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

	// Token: 0x06000F85 RID: 3973 RVA: 0x0007F1DD File Offset: 0x0007D3DD
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Glasses_On7") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Glasses_On");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F86 RID: 3974 RVA: 0x0007F214 File Offset: 0x0007D414
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
			this.material.SetFloat("UseFinalGlassColor", this.UseFinalGlassColor);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("VisionBlur", this.VisionBlur);
			this.material.SetFloat("GlassDistortion", this.GlassDistortion);
			this.material.SetFloat("GlassAberration", this.GlassAberration);
			this.material.SetColor("GlassesColor", this.GlassesColor);
			this.material.SetColor("GlassesColor2", this.GlassesColor2);
			this.material.SetColor("GlassColor", this.GlassColor);
			this.material.SetFloat("UseScanLineSize", this.UseScanLineSize);
			this.material.SetFloat("UseScanLine", this.UseScanLine);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F87 RID: 3975 RVA: 0x0007F379 File Offset: 0x0007D579
	private void Update()
	{
	}

	// Token: 0x06000F88 RID: 3976 RVA: 0x0007F37B File Offset: 0x0007D57B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013F9 RID: 5113
	public Shader SCShader;

	// Token: 0x040013FA RID: 5114
	private float TimeX = 1f;

	// Token: 0x040013FB RID: 5115
	[Range(0f, 1f)]
	public float Fade = 0.2f;

	// Token: 0x040013FC RID: 5116
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.005f;

	// Token: 0x040013FD RID: 5117
	public Color GlassesColor = new Color(0f, 0f, 0f, 1f);

	// Token: 0x040013FE RID: 5118
	public Color GlassesColor2 = new Color(0.25f, 0.25f, 0.45f, 0.25f);

	// Token: 0x040013FF RID: 5119
	[Range(0f, 1f)]
	public float GlassDistortion = 0.6f;

	// Token: 0x04001400 RID: 5120
	[Range(0f, 1f)]
	public float GlassAberration = 0.3f;

	// Token: 0x04001401 RID: 5121
	[Range(0f, 1f)]
	public float UseFinalGlassColor;

	// Token: 0x04001402 RID: 5122
	[Range(0f, 1f)]
	public float UseScanLine = 0.4f;

	// Token: 0x04001403 RID: 5123
	[Range(1f, 512f)]
	public float UseScanLineSize = 358f;

	// Token: 0x04001404 RID: 5124
	public Color GlassColor = new Color(1f, 0.9f, 0f, 1f);

	// Token: 0x04001405 RID: 5125
	private Material SCMaterial;

	// Token: 0x04001406 RID: 5126
	private Texture2D Texture2;
}
