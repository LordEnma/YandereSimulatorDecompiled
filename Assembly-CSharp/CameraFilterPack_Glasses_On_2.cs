using System;
using UnityEngine;

// Token: 0x020001C7 RID: 455
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Vampire")]
public class CameraFilterPack_Glasses_On_2 : MonoBehaviour
{
	// Token: 0x170002CB RID: 715
	// (get) Token: 0x06000F6A RID: 3946 RVA: 0x0007E27E File Offset: 0x0007C47E
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

	// Token: 0x06000F6B RID: 3947 RVA: 0x0007E2B2 File Offset: 0x0007C4B2
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

	// Token: 0x06000F6C RID: 3948 RVA: 0x0007E2E8 File Offset: 0x0007C4E8
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

	// Token: 0x06000F6D RID: 3949 RVA: 0x0007E44D File Offset: 0x0007C64D
	private void Update()
	{
	}

	// Token: 0x06000F6E RID: 3950 RVA: 0x0007E44F File Offset: 0x0007C64F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013BA RID: 5050
	public Shader SCShader;

	// Token: 0x040013BB RID: 5051
	private float TimeX = 1f;

	// Token: 0x040013BC RID: 5052
	[Range(0f, 1f)]
	public float Fade = 0.2f;

	// Token: 0x040013BD RID: 5053
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.005f;

	// Token: 0x040013BE RID: 5054
	public Color GlassesColor = new Color(0f, 0f, 0f, 1f);

	// Token: 0x040013BF RID: 5055
	public Color GlassesColor2 = new Color(0.25f, 0.25f, 0.25f, 0.25f);

	// Token: 0x040013C0 RID: 5056
	[Range(0f, 1f)]
	public float GlassDistortion = 0.6f;

	// Token: 0x040013C1 RID: 5057
	[Range(0f, 1f)]
	public float GlassAberration = 0.5f;

	// Token: 0x040013C2 RID: 5058
	[Range(0f, 1f)]
	public float UseFinalGlassColor = 1f;

	// Token: 0x040013C3 RID: 5059
	[Range(0f, 1f)]
	public float UseScanLine;

	// Token: 0x040013C4 RID: 5060
	[Range(1f, 512f)]
	public float UseScanLineSize = 358f;

	// Token: 0x040013C5 RID: 5061
	public Color GlassColor = new Color(1f, 0f, 0f, 1f);

	// Token: 0x040013C6 RID: 5062
	private Material SCMaterial;

	// Token: 0x040013C7 RID: 5063
	private Texture2D Texture2;
}
