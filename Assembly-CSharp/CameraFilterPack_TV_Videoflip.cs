using System;
using UnityEngine;

// Token: 0x0200021D RID: 541
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Videoflip")]
public class CameraFilterPack_TV_Videoflip : MonoBehaviour
{
	// Token: 0x17000321 RID: 801
	// (get) Token: 0x06001190 RID: 4496 RVA: 0x0008848C File Offset: 0x0008668C
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

	// Token: 0x06001191 RID: 4497 RVA: 0x000884C0 File Offset: 0x000866C0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Videoflip");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001192 RID: 4498 RVA: 0x000884E4 File Offset: 0x000866E4
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

	// Token: 0x06001193 RID: 4499 RVA: 0x00088581 File Offset: 0x00086781
	private void Update()
	{
	}

	// Token: 0x06001194 RID: 4500 RVA: 0x00088583 File Offset: 0x00086783
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400161C RID: 5660
	public Shader SCShader;

	// Token: 0x0400161D RID: 5661
	private float TimeX = 1f;

	// Token: 0x0400161E RID: 5662
	private Material SCMaterial;
}
