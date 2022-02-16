using System;
using UnityEngine;

// Token: 0x02000162 RID: 354
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Noise")]
public class CameraFilterPack_Color_Noise : MonoBehaviour
{
	// Token: 0x17000266 RID: 614
	// (get) Token: 0x06000D09 RID: 3337 RVA: 0x000745AC File Offset: 0x000727AC
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

	// Token: 0x06000D0A RID: 3338 RVA: 0x000745E0 File Offset: 0x000727E0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D0B RID: 3339 RVA: 0x00074604 File Offset: 0x00072804
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
			this.material.SetFloat("_Noise", this.Noise);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D0C RID: 3340 RVA: 0x000746BA File Offset: 0x000728BA
	private void Update()
	{
	}

	// Token: 0x06000D0D RID: 3341 RVA: 0x000746BC File Offset: 0x000728BC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001156 RID: 4438
	public Shader SCShader;

	// Token: 0x04001157 RID: 4439
	private float TimeX = 1f;

	// Token: 0x04001158 RID: 4440
	private Material SCMaterial;

	// Token: 0x04001159 RID: 4441
	[Range(0f, 1f)]
	public float Noise = 0.235f;
}
