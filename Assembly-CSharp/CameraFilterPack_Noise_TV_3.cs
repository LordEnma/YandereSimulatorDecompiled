using System;
using UnityEngine;

// Token: 0x020001EE RID: 494
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Noise/TV_3")]
public class CameraFilterPack_Noise_TV_3 : MonoBehaviour
{
	// Token: 0x170002F3 RID: 755
	// (get) Token: 0x06001074 RID: 4212 RVA: 0x0008361F File Offset: 0x0008181F
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

	// Token: 0x06001075 RID: 4213 RVA: 0x00083653 File Offset: 0x00081853
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

	// Token: 0x06001076 RID: 4214 RVA: 0x0008368C File Offset: 0x0008188C
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

	// Token: 0x06001077 RID: 4215 RVA: 0x0008379A File Offset: 0x0008199A
	private void Update()
	{
	}

	// Token: 0x06001078 RID: 4216 RVA: 0x0008379C File Offset: 0x0008199C
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
