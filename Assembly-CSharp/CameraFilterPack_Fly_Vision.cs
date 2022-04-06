using System;
using UnityEngine;

// Token: 0x020001C5 RID: 453
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Fly_Vision")]
public class CameraFilterPack_Fly_Vision : MonoBehaviour
{
	// Token: 0x170002C9 RID: 713
	// (get) Token: 0x06000F60 RID: 3936 RVA: 0x0007E284 File Offset: 0x0007C484
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

	// Token: 0x06000F61 RID: 3937 RVA: 0x0007E2B8 File Offset: 0x0007C4B8
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Fly_VisionFX") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Fly_Vision");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F62 RID: 3938 RVA: 0x0007E2F0 File Offset: 0x0007C4F0
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
			this.material.SetFloat("_Value", this.Zoom);
			this.material.SetFloat("_Value2", this.Distortion);
			this.material.SetFloat("_Value3", this.Fade);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetTexture("Texture2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F63 RID: 3939 RVA: 0x0007E3FE File Offset: 0x0007C5FE
	private void Update()
	{
	}

	// Token: 0x06000F64 RID: 3940 RVA: 0x0007E400 File Offset: 0x0007C600
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013AB RID: 5035
	public Shader SCShader;

	// Token: 0x040013AC RID: 5036
	private float TimeX = 1f;

	// Token: 0x040013AD RID: 5037
	private Material SCMaterial;

	// Token: 0x040013AE RID: 5038
	[Range(0.04f, 1.5f)]
	public float Zoom = 0.25f;

	// Token: 0x040013AF RID: 5039
	[Range(0f, 1f)]
	public float Distortion = 0.4f;

	// Token: 0x040013B0 RID: 5040
	[Range(0f, 1f)]
	public float Fade = 0.4f;

	// Token: 0x040013B1 RID: 5041
	[Range(0f, 10f)]
	private float Value4 = 1f;

	// Token: 0x040013B2 RID: 5042
	private Texture2D Texture2;
}
