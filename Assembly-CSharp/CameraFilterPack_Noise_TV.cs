using System;
using UnityEngine;

// Token: 0x020001ED RID: 493
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Noise/TV")]
public class CameraFilterPack_Noise_TV : MonoBehaviour
{
	// Token: 0x170002F1 RID: 753
	// (get) Token: 0x0600106C RID: 4204 RVA: 0x000835D6 File Offset: 0x000817D6
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

	// Token: 0x0600106D RID: 4205 RVA: 0x0008360A File Offset: 0x0008180A
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_TV_Noise") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Noise_TV");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600106E RID: 4206 RVA: 0x00083640 File Offset: 0x00081840
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
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetTexture("Texture2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600106F RID: 4207 RVA: 0x0008374E File Offset: 0x0008194E
	private void Update()
	{
	}

	// Token: 0x06001070 RID: 4208 RVA: 0x00083750 File Offset: 0x00081950
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014ED RID: 5357
	public Shader SCShader;

	// Token: 0x040014EE RID: 5358
	private float TimeX = 1f;

	// Token: 0x040014EF RID: 5359
	private Material SCMaterial;

	// Token: 0x040014F0 RID: 5360
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040014F1 RID: 5361
	[Range(0f, 10f)]
	private float Value2 = 1f;

	// Token: 0x040014F2 RID: 5362
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x040014F3 RID: 5363
	[Range(0f, 10f)]
	private float Value4 = 1f;

	// Token: 0x040014F4 RID: 5364
	private Texture2D Texture2;
}
