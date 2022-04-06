using System;
using UnityEngine;

// Token: 0x020001EE RID: 494
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Noise/TV_2")]
public class CameraFilterPack_Noise_TV_2 : MonoBehaviour
{
	// Token: 0x170002F2 RID: 754
	// (get) Token: 0x06001074 RID: 4212 RVA: 0x00083E81 File Offset: 0x00082081
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

	// Token: 0x06001075 RID: 4213 RVA: 0x00083EB5 File Offset: 0x000820B5
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

	// Token: 0x06001076 RID: 4214 RVA: 0x00083EEC File Offset: 0x000820EC
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

	// Token: 0x06001077 RID: 4215 RVA: 0x00083FFA File Offset: 0x000821FA
	private void Update()
	{
	}

	// Token: 0x06001078 RID: 4216 RVA: 0x00083FFC File Offset: 0x000821FC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001505 RID: 5381
	public Shader SCShader;

	// Token: 0x04001506 RID: 5382
	private float TimeX = 1f;

	// Token: 0x04001507 RID: 5383
	private Material SCMaterial;

	// Token: 0x04001508 RID: 5384
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001509 RID: 5385
	[Range(0f, 1f)]
	public float Fade_Additive;

	// Token: 0x0400150A RID: 5386
	[Range(0f, 1f)]
	public float Fade_Distortion;

	// Token: 0x0400150B RID: 5387
	[Range(0f, 10f)]
	private float Value4 = 1f;

	// Token: 0x0400150C RID: 5388
	private Texture2D Texture2;
}
