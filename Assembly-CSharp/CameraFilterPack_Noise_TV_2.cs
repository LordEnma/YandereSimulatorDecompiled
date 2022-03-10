using System;
using UnityEngine;

// Token: 0x020001EE RID: 494
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Noise/TV_2")]
public class CameraFilterPack_Noise_TV_2 : MonoBehaviour
{
	// Token: 0x170002F2 RID: 754
	// (get) Token: 0x06001072 RID: 4210 RVA: 0x00083A05 File Offset: 0x00081C05
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

	// Token: 0x06001073 RID: 4211 RVA: 0x00083A39 File Offset: 0x00081C39
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

	// Token: 0x06001074 RID: 4212 RVA: 0x00083A70 File Offset: 0x00081C70
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

	// Token: 0x06001075 RID: 4213 RVA: 0x00083B7E File Offset: 0x00081D7E
	private void Update()
	{
	}

	// Token: 0x06001076 RID: 4214 RVA: 0x00083B80 File Offset: 0x00081D80
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014FE RID: 5374
	public Shader SCShader;

	// Token: 0x040014FF RID: 5375
	private float TimeX = 1f;

	// Token: 0x04001500 RID: 5376
	private Material SCMaterial;

	// Token: 0x04001501 RID: 5377
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001502 RID: 5378
	[Range(0f, 1f)]
	public float Fade_Additive;

	// Token: 0x04001503 RID: 5379
	[Range(0f, 1f)]
	public float Fade_Distortion;

	// Token: 0x04001504 RID: 5380
	[Range(0f, 10f)]
	private float Value4 = 1f;

	// Token: 0x04001505 RID: 5381
	private Texture2D Texture2;
}
