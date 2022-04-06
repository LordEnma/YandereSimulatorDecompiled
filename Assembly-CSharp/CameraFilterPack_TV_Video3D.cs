using System;
using UnityEngine;

// Token: 0x0200021C RID: 540
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Video3D")]
public class CameraFilterPack_TV_Video3D : MonoBehaviour
{
	// Token: 0x17000320 RID: 800
	// (get) Token: 0x0600118D RID: 4493 RVA: 0x00088B90 File Offset: 0x00086D90
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

	// Token: 0x0600118E RID: 4494 RVA: 0x00088BC4 File Offset: 0x00086DC4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Video3D");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600118F RID: 4495 RVA: 0x00088BE8 File Offset: 0x00086DE8
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

	// Token: 0x06001190 RID: 4496 RVA: 0x00088C85 File Offset: 0x00086E85
	private void Update()
	{
	}

	// Token: 0x06001191 RID: 4497 RVA: 0x00088C87 File Offset: 0x00086E87
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400162C RID: 5676
	public Shader SCShader;

	// Token: 0x0400162D RID: 5677
	private float TimeX = 1f;

	// Token: 0x0400162E RID: 5678
	private Material SCMaterial;
}
