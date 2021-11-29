using System;
using UnityEngine;

// Token: 0x02000184 RID: 388
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Wave_Horizontal")]
public class CameraFilterPack_Distortion_Wave_Horizontal : MonoBehaviour
{
	// Token: 0x17000289 RID: 649
	// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x000779EE File Offset: 0x00075BEE
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

	// Token: 0x06000DDA RID: 3546 RVA: 0x00077A22 File Offset: 0x00075C22
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Wave_Horizontal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DDB RID: 3547 RVA: 0x00077A44 File Offset: 0x00075C44
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

	// Token: 0x06000DDC RID: 3548 RVA: 0x00077AF3 File Offset: 0x00075CF3
	private void Update()
	{
	}

	// Token: 0x06000DDD RID: 3549 RVA: 0x00077AF5 File Offset: 0x00075CF5
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400121A RID: 4634
	public Shader SCShader;

	// Token: 0x0400121B RID: 4635
	private float TimeX = 1f;

	// Token: 0x0400121C RID: 4636
	private Material SCMaterial;

	// Token: 0x0400121D RID: 4637
	[Range(1f, 100f)]
	public float WaveIntensity = 32f;
}
