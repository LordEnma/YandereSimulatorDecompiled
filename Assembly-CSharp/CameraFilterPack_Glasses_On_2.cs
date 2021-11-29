using System;
using UnityEngine;

// Token: 0x020001C6 RID: 454
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Vampire")]
public class CameraFilterPack_Glasses_On_2 : MonoBehaviour
{
	// Token: 0x170002CB RID: 715
	// (get) Token: 0x06000F66 RID: 3942 RVA: 0x0007DCDA File Offset: 0x0007BEDA
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

	// Token: 0x06000F67 RID: 3943 RVA: 0x0007DD0E File Offset: 0x0007BF0E
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Glasses_On3") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Glasses_OnX");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F68 RID: 3944 RVA: 0x0007DD44 File Offset: 0x0007BF44
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

	// Token: 0x06000F69 RID: 3945 RVA: 0x0007DEA9 File Offset: 0x0007C0A9
	private void Update()
	{
	}

	// Token: 0x06000F6A RID: 3946 RVA: 0x0007DEAB File Offset: 0x0007C0AB
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013A9 RID: 5033
	public Shader SCShader;

	// Token: 0x040013AA RID: 5034
	private float TimeX = 1f;

	// Token: 0x040013AB RID: 5035
	[Range(0f, 1f)]
	public float Fade = 0.2f;

	// Token: 0x040013AC RID: 5036
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.005f;

	// Token: 0x040013AD RID: 5037
	public Color GlassesColor = new Color(0f, 0f, 0f, 1f);

	// Token: 0x040013AE RID: 5038
	public Color GlassesColor2 = new Color(0.25f, 0.25f, 0.25f, 0.25f);

	// Token: 0x040013AF RID: 5039
	[Range(0f, 1f)]
	public float GlassDistortion = 0.6f;

	// Token: 0x040013B0 RID: 5040
	[Range(0f, 1f)]
	public float GlassAberration = 0.5f;

	// Token: 0x040013B1 RID: 5041
	[Range(0f, 1f)]
	public float UseFinalGlassColor = 1f;

	// Token: 0x040013B2 RID: 5042
	[Range(0f, 1f)]
	public float UseScanLine;

	// Token: 0x040013B3 RID: 5043
	[Range(1f, 512f)]
	public float UseScanLineSize = 358f;

	// Token: 0x040013B4 RID: 5044
	public Color GlassColor = new Color(1f, 0f, 0f, 1f);

	// Token: 0x040013B5 RID: 5045
	private Material SCMaterial;

	// Token: 0x040013B6 RID: 5046
	private Texture2D Texture2;
}
