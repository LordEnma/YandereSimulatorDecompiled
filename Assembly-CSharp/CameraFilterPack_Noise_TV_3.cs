using System;
using UnityEngine;

// Token: 0x020001EF RID: 495
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Noise/TV_3")]
public class CameraFilterPack_Noise_TV_3 : MonoBehaviour
{
	// Token: 0x170002F3 RID: 755
	// (get) Token: 0x06001078 RID: 4216 RVA: 0x00083967 File Offset: 0x00081B67
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

	// Token: 0x06001079 RID: 4217 RVA: 0x0008399B File Offset: 0x00081B9B
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

	// Token: 0x0600107A RID: 4218 RVA: 0x000839D4 File Offset: 0x00081BD4
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

	// Token: 0x0600107B RID: 4219 RVA: 0x00083AE2 File Offset: 0x00081CE2
	private void Update()
	{
	}

	// Token: 0x0600107C RID: 4220 RVA: 0x00083AE4 File Offset: 0x00081CE4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014FD RID: 5373
	public Shader SCShader;

	// Token: 0x040014FE RID: 5374
	private float TimeX = 1f;

	// Token: 0x040014FF RID: 5375
	private Material SCMaterial;

	// Token: 0x04001500 RID: 5376
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001501 RID: 5377
	[Range(0f, 1f)]
	public float Fade_Additive;

	// Token: 0x04001502 RID: 5378
	[Range(0f, 1f)]
	public float Fade_Distortion;

	// Token: 0x04001503 RID: 5379
	[Range(0f, 10f)]
	private float Value4 = 1f;

	// Token: 0x04001504 RID: 5380
	private Texture2D Texture2;
}
