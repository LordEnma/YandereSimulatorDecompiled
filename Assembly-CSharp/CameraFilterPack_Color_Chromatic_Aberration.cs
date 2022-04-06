using System;
using UnityEngine;

// Token: 0x0200015D RID: 349
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Chromatic_Aberration")]
public class CameraFilterPack_Color_Chromatic_Aberration : MonoBehaviour
{
	// Token: 0x17000261 RID: 609
	// (get) Token: 0x06000CED RID: 3309 RVA: 0x000745DE File Offset: 0x000727DE
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

	// Token: 0x06000CEE RID: 3310 RVA: 0x00074612 File Offset: 0x00072812
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Chromatic_Aberration");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CEF RID: 3311 RVA: 0x00074634 File Offset: 0x00072834
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
			this.material.SetFloat("_Distortion", this.Offset);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CF0 RID: 3312 RVA: 0x000746EA File Offset: 0x000728EA
	private void Update()
	{
	}

	// Token: 0x06000CF1 RID: 3313 RVA: 0x000746EC File Offset: 0x000728EC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001150 RID: 4432
	public Shader SCShader;

	// Token: 0x04001151 RID: 4433
	private float TimeX = 1f;

	// Token: 0x04001152 RID: 4434
	private Material SCMaterial;

	// Token: 0x04001153 RID: 4435
	[Range(-0.02f, 0.02f)]
	public float Offset = 0.02f;
}
