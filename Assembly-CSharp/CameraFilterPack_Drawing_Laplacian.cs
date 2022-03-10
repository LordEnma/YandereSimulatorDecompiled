using System;
using UnityEngine;

// Token: 0x0200018E RID: 398
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Laplacian")]
public class CameraFilterPack_Drawing_Laplacian : MonoBehaviour
{
	// Token: 0x17000292 RID: 658
	// (get) Token: 0x06000E13 RID: 3603 RVA: 0x00078D2D File Offset: 0x00076F2D
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

	// Token: 0x06000E14 RID: 3604 RVA: 0x00078D61 File Offset: 0x00076F61
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Laplacian");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E15 RID: 3605 RVA: 0x00078D84 File Offset: 0x00076F84
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E16 RID: 3606 RVA: 0x00078E21 File Offset: 0x00077021
	private void Update()
	{
		bool isPlaying = Application.isPlaying;
	}

	// Token: 0x06000E17 RID: 3607 RVA: 0x00078E29 File Offset: 0x00077029
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001263 RID: 4707
	public Shader SCShader;

	// Token: 0x04001264 RID: 4708
	private float TimeX = 1f;

	// Token: 0x04001265 RID: 4709
	private Material SCMaterial;
}
