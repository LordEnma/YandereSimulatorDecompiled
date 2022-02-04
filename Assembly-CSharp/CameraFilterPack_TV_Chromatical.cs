using System;
using UnityEngine;

// Token: 0x0200020A RID: 522
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Chromatical")]
public class CameraFilterPack_TV_Chromatical : MonoBehaviour
{
	// Token: 0x1700030E RID: 782
	// (get) Token: 0x0600111E RID: 4382 RVA: 0x00086A0F File Offset: 0x00084C0F
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

	// Token: 0x0600111F RID: 4383 RVA: 0x00086A43 File Offset: 0x00084C43
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Chromatical");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001120 RID: 4384 RVA: 0x00086A64 File Offset: 0x00084C64
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime * 2f;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("Intensity", this.Intensity);
			this.material.SetFloat("Speed", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001121 RID: 4385 RVA: 0x00086B45 File Offset: 0x00084D45
	private void Update()
	{
	}

	// Token: 0x06001122 RID: 4386 RVA: 0x00086B47 File Offset: 0x00084D47
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015B7 RID: 5559
	public Shader SCShader;

	// Token: 0x040015B8 RID: 5560
	private float TimeX = 1f;

	// Token: 0x040015B9 RID: 5561
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015BA RID: 5562
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x040015BB RID: 5563
	[Range(0f, 3f)]
	public float Speed = 1f;

	// Token: 0x040015BC RID: 5564
	private Material SCMaterial;
}
