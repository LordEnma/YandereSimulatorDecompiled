using System;
using UnityEngine;

// Token: 0x020001CB RID: 459
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Spy")]
public class CameraFilterPack_Glasses_On_6 : MonoBehaviour
{
	// Token: 0x170002CF RID: 719
	// (get) Token: 0x06000F82 RID: 3970 RVA: 0x0007ED2D File Offset: 0x0007CF2D
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

	// Token: 0x06000F83 RID: 3971 RVA: 0x0007ED61 File Offset: 0x0007CF61
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

	// Token: 0x06000F84 RID: 3972 RVA: 0x0007ED98 File Offset: 0x0007CF98
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

	// Token: 0x06000F85 RID: 3973 RVA: 0x0007EEFD File Offset: 0x0007D0FD
	private void Update()
	{
	}

	// Token: 0x06000F86 RID: 3974 RVA: 0x0007EEFF File Offset: 0x0007D0FF
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013F2 RID: 5106
	public Shader SCShader;

	// Token: 0x040013F3 RID: 5107
	private float TimeX = 1f;

	// Token: 0x040013F4 RID: 5108
	[Range(0f, 1f)]
	public float Fade = 0.2f;

	// Token: 0x040013F5 RID: 5109
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.005f;

	// Token: 0x040013F6 RID: 5110
	public Color GlassesColor = new Color(0f, 0f, 0f, 1f);

	// Token: 0x040013F7 RID: 5111
	public Color GlassesColor2 = new Color(0.25f, 0.25f, 0.45f, 0.25f);

	// Token: 0x040013F8 RID: 5112
	[Range(0f, 1f)]
	public float GlassDistortion = 0.6f;

	// Token: 0x040013F9 RID: 5113
	[Range(0f, 1f)]
	public float GlassAberration = 0.3f;

	// Token: 0x040013FA RID: 5114
	[Range(0f, 1f)]
	public float UseFinalGlassColor;

	// Token: 0x040013FB RID: 5115
	[Range(0f, 1f)]
	public float UseScanLine = 0.4f;

	// Token: 0x040013FC RID: 5116
	[Range(1f, 512f)]
	public float UseScanLineSize = 358f;

	// Token: 0x040013FD RID: 5117
	public Color GlassColor = new Color(1f, 0.9f, 0f, 1f);

	// Token: 0x040013FE RID: 5118
	private Material SCMaterial;

	// Token: 0x040013FF RID: 5119
	private Texture2D Texture2;
}
