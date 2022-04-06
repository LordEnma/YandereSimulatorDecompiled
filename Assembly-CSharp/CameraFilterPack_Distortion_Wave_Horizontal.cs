using System;
using UnityEngine;

// Token: 0x02000185 RID: 389
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Wave_Horizontal")]
public class CameraFilterPack_Distortion_Wave_Horizontal : MonoBehaviour
{
	// Token: 0x17000289 RID: 649
	// (get) Token: 0x06000DDF RID: 3551 RVA: 0x0007840E File Offset: 0x0007660E
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

	// Token: 0x06000DE0 RID: 3552 RVA: 0x00078442 File Offset: 0x00076642
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Wave_Horizontal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DE1 RID: 3553 RVA: 0x00078464 File Offset: 0x00076664
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_WaveIntensity", this.WaveIntensity);
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DE2 RID: 3554 RVA: 0x00078513 File Offset: 0x00076713
	private void Update()
	{
	}

	// Token: 0x06000DE3 RID: 3555 RVA: 0x00078515 File Offset: 0x00076715
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001232 RID: 4658
	public Shader SCShader;

	// Token: 0x04001233 RID: 4659
	private float TimeX = 1f;

	// Token: 0x04001234 RID: 4660
	private Material SCMaterial;

	// Token: 0x04001235 RID: 4661
	[Range(1f, 100f)]
	public float WaveIntensity = 32f;
}
