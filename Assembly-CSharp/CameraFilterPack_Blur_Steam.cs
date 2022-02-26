using System;
using UnityEngine;

// Token: 0x02000153 RID: 339
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Steam")]
public class CameraFilterPack_Blur_Steam : MonoBehaviour
{
	// Token: 0x17000257 RID: 599
	// (get) Token: 0x06000CAF RID: 3247 RVA: 0x00072D69 File Offset: 0x00070F69
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

	// Token: 0x06000CB0 RID: 3248 RVA: 0x00072D9D File Offset: 0x00070F9D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Steam");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CB1 RID: 3249 RVA: 0x00072DC0 File Offset: 0x00070FC0
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
			this.material.SetFloat("_Radius", this.Radius);
			this.material.SetFloat("_Quality", this.Quality);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CB2 RID: 3250 RVA: 0x00072E85 File Offset: 0x00071085
	private void Update()
	{
	}

	// Token: 0x06000CB3 RID: 3251 RVA: 0x00072E87 File Offset: 0x00071087
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010F6 RID: 4342
	public Shader SCShader;

	// Token: 0x040010F7 RID: 4343
	private float TimeX = 1f;

	// Token: 0x040010F8 RID: 4344
	private Material SCMaterial;

	// Token: 0x040010F9 RID: 4345
	[Range(0f, 1f)]
	public float Radius = 0.1f;

	// Token: 0x040010FA RID: 4346
	[Range(0f, 1f)]
	public float Quality = 0.75f;
}
