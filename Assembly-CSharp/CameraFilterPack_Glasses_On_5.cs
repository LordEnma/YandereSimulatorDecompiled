using System;
using UnityEngine;

// Token: 0x020001CA RID: 458
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Futuristic Montain")]
public class CameraFilterPack_Glasses_On_5 : MonoBehaviour
{
	// Token: 0x170002CE RID: 718
	// (get) Token: 0x06000F7C RID: 3964 RVA: 0x0007E825 File Offset: 0x0007CA25
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

	// Token: 0x06000F7D RID: 3965 RVA: 0x0007E859 File Offset: 0x0007CA59
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Glasses_On6") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Glasses_On");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F7E RID: 3966 RVA: 0x0007E890 File Offset: 0x0007CA90
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

	// Token: 0x06000F7F RID: 3967 RVA: 0x0007E9F5 File Offset: 0x0007CBF5
	private void Update()
	{
	}

	// Token: 0x06000F80 RID: 3968 RVA: 0x0007E9F7 File Offset: 0x0007CBF7
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013DB RID: 5083
	public Shader SCShader;

	// Token: 0x040013DC RID: 5084
	private float TimeX = 1f;

	// Token: 0x040013DD RID: 5085
	[Range(0f, 1f)]
	public float Fade = 0.2f;

	// Token: 0x040013DE RID: 5086
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.005f;

	// Token: 0x040013DF RID: 5087
	public Color GlassesColor = new Color(0.1f, 0.1f, 0.1f, 1f);

	// Token: 0x040013E0 RID: 5088
	public Color GlassesColor2 = new Color(0.45f, 0.45f, 0.45f, 0.25f);

	// Token: 0x040013E1 RID: 5089
	[Range(0f, 1f)]
	public float GlassDistortion = 0.6f;

	// Token: 0x040013E2 RID: 5090
	[Range(0f, 1f)]
	public float GlassAberration = 0.3f;

	// Token: 0x040013E3 RID: 5091
	[Range(0f, 1f)]
	public float UseFinalGlassColor;

	// Token: 0x040013E4 RID: 5092
	[Range(0f, 1f)]
	public float UseScanLine = 0.4f;

	// Token: 0x040013E5 RID: 5093
	[Range(1f, 512f)]
	public float UseScanLineSize = 358f;

	// Token: 0x040013E6 RID: 5094
	public Color GlassColor = new Color(0.1f, 0.3f, 1f, 1f);

	// Token: 0x040013E7 RID: 5095
	private Material SCMaterial;

	// Token: 0x040013E8 RID: 5096
	private Texture2D Texture2;
}
