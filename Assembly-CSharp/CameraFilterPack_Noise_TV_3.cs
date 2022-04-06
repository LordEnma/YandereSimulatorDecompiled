using System;
using UnityEngine;

// Token: 0x020001EF RID: 495
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Noise/TV_3")]
public class CameraFilterPack_Noise_TV_3 : MonoBehaviour
{
	// Token: 0x170002F3 RID: 755
	// (get) Token: 0x0600107A RID: 4218 RVA: 0x0008403F File Offset: 0x0008223F
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

	// Token: 0x0600107B RID: 4219 RVA: 0x00084073 File Offset: 0x00082273
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_TV_Noise3") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Noise_TV_3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600107C RID: 4220 RVA: 0x000840AC File Offset: 0x000822AC
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
			this.material.SetFloat("_Value", this.Fade);
			this.material.SetFloat("_Value2", this.Fade_Additive);
			this.material.SetFloat("_Value3", this.Fade_Distortion);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetTexture("Texture2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600107D RID: 4221 RVA: 0x000841BA File Offset: 0x000823BA
	private void Update()
	{
	}

	// Token: 0x0600107E RID: 4222 RVA: 0x000841BC File Offset: 0x000823BC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400150D RID: 5389
	public Shader SCShader;

	// Token: 0x0400150E RID: 5390
	private float TimeX = 1f;

	// Token: 0x0400150F RID: 5391
	private Material SCMaterial;

	// Token: 0x04001510 RID: 5392
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001511 RID: 5393
	[Range(0f, 1f)]
	public float Fade_Additive;

	// Token: 0x04001512 RID: 5394
	[Range(0f, 1f)]
	public float Fade_Distortion;

	// Token: 0x04001513 RID: 5395
	[Range(0f, 10f)]
	private float Value4 = 1f;

	// Token: 0x04001514 RID: 5396
	private Texture2D Texture2;
}
