using System;
using UnityEngine;

// Token: 0x020001C6 RID: 454
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Classic Glasses")]
public class CameraFilterPack_Glasses_On : MonoBehaviour
{
	// Token: 0x170002CA RID: 714
	// (get) Token: 0x06000F64 RID: 3940 RVA: 0x0007DE95 File Offset: 0x0007C095
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

	// Token: 0x06000F65 RID: 3941 RVA: 0x0007DEC9 File Offset: 0x0007C0C9
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Glasses_On2") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Glasses_On");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F66 RID: 3942 RVA: 0x0007DF00 File Offset: 0x0007C100
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

	// Token: 0x06000F67 RID: 3943 RVA: 0x0007E065 File Offset: 0x0007C265
	private void Update()
	{
	}

	// Token: 0x06000F68 RID: 3944 RVA: 0x0007E067 File Offset: 0x0007C267
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013A3 RID: 5027
	public Shader SCShader;

	// Token: 0x040013A4 RID: 5028
	private float TimeX = 1f;

	// Token: 0x040013A5 RID: 5029
	[Range(0f, 1f)]
	public float Fade = 0.2f;

	// Token: 0x040013A6 RID: 5030
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.0095f;

	// Token: 0x040013A7 RID: 5031
	public Color GlassesColor = new Color(0f, 0f, 0f, 1f);

	// Token: 0x040013A8 RID: 5032
	public Color GlassesColor2 = new Color(0.25f, 0.25f, 0.25f, 0.25f);

	// Token: 0x040013A9 RID: 5033
	[Range(0f, 1f)]
	public float GlassDistortion = 0.45f;

	// Token: 0x040013AA RID: 5034
	[Range(0f, 1f)]
	public float GlassAberration = 0.5f;

	// Token: 0x040013AB RID: 5035
	[Range(0f, 1f)]
	public float UseFinalGlassColor;

	// Token: 0x040013AC RID: 5036
	[Range(0f, 1f)]
	public float UseScanLine;

	// Token: 0x040013AD RID: 5037
	[Range(1f, 512f)]
	public float UseScanLineSize = 1f;

	// Token: 0x040013AE RID: 5038
	public Color GlassColor = new Color(0f, 0f, 0f, 1f);

	// Token: 0x040013AF RID: 5039
	private Material SCMaterial;

	// Token: 0x040013B0 RID: 5040
	private Texture2D Texture2;
}
