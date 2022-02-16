using System;
using UnityEngine;

// Token: 0x020001EE RID: 494
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Noise/TV_2")]
public class CameraFilterPack_Noise_TV_2 : MonoBehaviour
{
	// Token: 0x170002F2 RID: 754
	// (get) Token: 0x06001072 RID: 4210 RVA: 0x000837A9 File Offset: 0x000819A9
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

	// Token: 0x06001073 RID: 4211 RVA: 0x000837DD File Offset: 0x000819DD
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_TV_Noise2") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Noise_TV_2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001074 RID: 4212 RVA: 0x00083814 File Offset: 0x00081A14
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

	// Token: 0x06001075 RID: 4213 RVA: 0x00083922 File Offset: 0x00081B22
	private void Update()
	{
	}

	// Token: 0x06001076 RID: 4214 RVA: 0x00083924 File Offset: 0x00081B24
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014F5 RID: 5365
	public Shader SCShader;

	// Token: 0x040014F6 RID: 5366
	private float TimeX = 1f;

	// Token: 0x040014F7 RID: 5367
	private Material SCMaterial;

	// Token: 0x040014F8 RID: 5368
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040014F9 RID: 5369
	[Range(0f, 1f)]
	public float Fade_Additive;

	// Token: 0x040014FA RID: 5370
	[Range(0f, 1f)]
	public float Fade_Distortion;

	// Token: 0x040014FB RID: 5371
	[Range(0f, 10f)]
	private float Value4 = 1f;

	// Token: 0x040014FC RID: 5372
	private Texture2D Texture2;
}
