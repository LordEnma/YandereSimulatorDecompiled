using System;
using UnityEngine;

// Token: 0x0200021C RID: 540
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Videoflip")]
public class CameraFilterPack_TV_Videoflip : MonoBehaviour
{
	// Token: 0x17000321 RID: 801
	// (get) Token: 0x0600118D RID: 4493 RVA: 0x00088294 File Offset: 0x00086494
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

	// Token: 0x0600118E RID: 4494 RVA: 0x000882C8 File Offset: 0x000864C8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Videoflip");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600118F RID: 4495 RVA: 0x000882EC File Offset: 0x000864EC
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

	// Token: 0x06001190 RID: 4496 RVA: 0x00088389 File Offset: 0x00086589
	private void Update()
	{
	}

	// Token: 0x06001191 RID: 4497 RVA: 0x0008838B File Offset: 0x0008658B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001617 RID: 5655
	public Shader SCShader;

	// Token: 0x04001618 RID: 5656
	private float TimeX = 1f;

	// Token: 0x04001619 RID: 5657
	private Material SCMaterial;
}
