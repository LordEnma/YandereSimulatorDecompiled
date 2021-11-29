using System;
using UnityEngine;

// Token: 0x0200021B RID: 539
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Video3D")]
public class CameraFilterPack_TV_Video3D : MonoBehaviour
{
	// Token: 0x17000320 RID: 800
	// (get) Token: 0x06001187 RID: 4487 RVA: 0x00088170 File Offset: 0x00086370
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

	// Token: 0x06001188 RID: 4488 RVA: 0x000881A4 File Offset: 0x000863A4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Video3D");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001189 RID: 4489 RVA: 0x000881C8 File Offset: 0x000863C8
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

	// Token: 0x0600118A RID: 4490 RVA: 0x00088265 File Offset: 0x00086465
	private void Update()
	{
	}

	// Token: 0x0600118B RID: 4491 RVA: 0x00088267 File Offset: 0x00086467
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001614 RID: 5652
	public Shader SCShader;

	// Token: 0x04001615 RID: 5653
	private float TimeX = 1f;

	// Token: 0x04001616 RID: 5654
	private Material SCMaterial;
}
