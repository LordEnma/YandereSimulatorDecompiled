using System;
using UnityEngine;

// Token: 0x020001CA RID: 458
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Spy")]
public class CameraFilterPack_Glasses_On_6 : MonoBehaviour
{
	// Token: 0x170002CF RID: 719
	// (get) Token: 0x06000F7E RID: 3966 RVA: 0x0007E789 File Offset: 0x0007C989
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

	// Token: 0x06000F7F RID: 3967 RVA: 0x0007E7BD File Offset: 0x0007C9BD
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

	// Token: 0x06000F80 RID: 3968 RVA: 0x0007E7F4 File Offset: 0x0007C9F4
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

	// Token: 0x06000F81 RID: 3969 RVA: 0x0007E959 File Offset: 0x0007CB59
	private void Update()
	{
	}

	// Token: 0x06000F82 RID: 3970 RVA: 0x0007E95B File Offset: 0x0007CB5B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013E1 RID: 5089
	public Shader SCShader;

	// Token: 0x040013E2 RID: 5090
	private float TimeX = 1f;

	// Token: 0x040013E3 RID: 5091
	[Range(0f, 1f)]
	public float Fade = 0.2f;

	// Token: 0x040013E4 RID: 5092
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.005f;

	// Token: 0x040013E5 RID: 5093
	public Color GlassesColor = new Color(0f, 0f, 0f, 1f);

	// Token: 0x040013E6 RID: 5094
	public Color GlassesColor2 = new Color(0.25f, 0.25f, 0.45f, 0.25f);

	// Token: 0x040013E7 RID: 5095
	[Range(0f, 1f)]
	public float GlassDistortion = 0.6f;

	// Token: 0x040013E8 RID: 5096
	[Range(0f, 1f)]
	public float GlassAberration = 0.3f;

	// Token: 0x040013E9 RID: 5097
	[Range(0f, 1f)]
	public float UseFinalGlassColor;

	// Token: 0x040013EA RID: 5098
	[Range(0f, 1f)]
	public float UseScanLine = 0.4f;

	// Token: 0x040013EB RID: 5099
	[Range(1f, 512f)]
	public float UseScanLineSize = 358f;

	// Token: 0x040013EC RID: 5100
	public Color GlassColor = new Color(1f, 0.9f, 0f, 1f);

	// Token: 0x040013ED RID: 5101
	private Material SCMaterial;

	// Token: 0x040013EE RID: 5102
	private Texture2D Texture2;
}
