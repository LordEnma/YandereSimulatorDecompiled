using System;
using UnityEngine;

// Token: 0x020001C7 RID: 455
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Night Glasses")]
public class CameraFilterPack_Glasses_On_3 : MonoBehaviour
{
	// Token: 0x170002CC RID: 716
	// (get) Token: 0x06000F6C RID: 3948 RVA: 0x0007DF85 File Offset: 0x0007C185
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

	// Token: 0x06000F6D RID: 3949 RVA: 0x0007DFB9 File Offset: 0x0007C1B9
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Glasses_On4") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Glasses_On");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F6E RID: 3950 RVA: 0x0007DFF0 File Offset: 0x0007C1F0
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

	// Token: 0x06000F6F RID: 3951 RVA: 0x0007E155 File Offset: 0x0007C355
	private void Update()
	{
	}

	// Token: 0x06000F70 RID: 3952 RVA: 0x0007E157 File Offset: 0x0007C357
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013B7 RID: 5047
	public Shader SCShader;

	// Token: 0x040013B8 RID: 5048
	private float TimeX = 1f;

	// Token: 0x040013B9 RID: 5049
	[Range(0f, 1f)]
	public float Fade = 0.3f;

	// Token: 0x040013BA RID: 5050
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.005f;

	// Token: 0x040013BB RID: 5051
	public Color GlassesColor = new Color(0.7f, 0.7f, 0.7f, 1f);

	// Token: 0x040013BC RID: 5052
	public Color GlassesColor2 = new Color(1f, 1f, 1f, 1f);

	// Token: 0x040013BD RID: 5053
	[Range(0f, 1f)]
	public float GlassDistortion = 0.6f;

	// Token: 0x040013BE RID: 5054
	[Range(0f, 1f)]
	public float GlassAberration = 0.3f;

	// Token: 0x040013BF RID: 5055
	[Range(0f, 1f)]
	public float UseFinalGlassColor;

	// Token: 0x040013C0 RID: 5056
	[Range(0f, 1f)]
	public float UseScanLine = 0.4f;

	// Token: 0x040013C1 RID: 5057
	[Range(1f, 512f)]
	public float UseScanLineSize = 358f;

	// Token: 0x040013C2 RID: 5058
	public Color GlassColor = new Color(0f, 0.5f, 0f, 1f);

	// Token: 0x040013C3 RID: 5059
	private Material SCMaterial;

	// Token: 0x040013C4 RID: 5060
	private Texture2D Texture2;
}
