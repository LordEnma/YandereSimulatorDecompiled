using System;
using UnityEngine;

// Token: 0x0200021C RID: 540
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Video3D")]
public class CameraFilterPack_TV_Video3D : MonoBehaviour
{
	// Token: 0x17000320 RID: 800
	// (get) Token: 0x0600118B RID: 4491 RVA: 0x00088714 File Offset: 0x00086914
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

	// Token: 0x0600118C RID: 4492 RVA: 0x00088748 File Offset: 0x00086948
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Video3D");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600118D RID: 4493 RVA: 0x0008876C File Offset: 0x0008696C
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

	// Token: 0x0600118E RID: 4494 RVA: 0x00088809 File Offset: 0x00086A09
	private void Update()
	{
	}

	// Token: 0x0600118F RID: 4495 RVA: 0x0008880B File Offset: 0x00086A0B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001625 RID: 5669
	public Shader SCShader;

	// Token: 0x04001626 RID: 5670
	private float TimeX = 1f;

	// Token: 0x04001627 RID: 5671
	private Material SCMaterial;
}
