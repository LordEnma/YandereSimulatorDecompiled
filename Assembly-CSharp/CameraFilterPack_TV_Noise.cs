using System;
using UnityEngine;

// Token: 0x02000211 RID: 529
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Noise")]
public class CameraFilterPack_TV_Noise : MonoBehaviour
{
	// Token: 0x17000315 RID: 789
	// (get) Token: 0x06001148 RID: 4424 RVA: 0x00087410 File Offset: 0x00085610
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

	// Token: 0x06001149 RID: 4425 RVA: 0x00087444 File Offset: 0x00085644
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600114A RID: 4426 RVA: 0x00087468 File Offset: 0x00085668
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
			this.material.SetFloat("_Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600114B RID: 4427 RVA: 0x0008751E File Offset: 0x0008571E
	private void Update()
	{
	}

	// Token: 0x0600114C RID: 4428 RVA: 0x00087520 File Offset: 0x00085720
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015DD RID: 5597
	public Shader SCShader;

	// Token: 0x040015DE RID: 5598
	private float TimeX = 1f;

	// Token: 0x040015DF RID: 5599
	private Material SCMaterial;

	// Token: 0x040015E0 RID: 5600
	[Range(0.0001f, 1f)]
	public float Fade = 0.01f;
}
