using System;
using UnityEngine;

// Token: 0x020001E5 RID: 485
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch2")]
public class CameraFilterPack_NewGlitch2 : MonoBehaviour
{
	// Token: 0x170002E9 RID: 745
	// (get) Token: 0x0600103A RID: 4154 RVA: 0x000826F1 File Offset: 0x000808F1
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

	// Token: 0x0600103B RID: 4155 RVA: 0x00082725 File Offset: 0x00080925
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600103C RID: 4156 RVA: 0x00082748 File Offset: 0x00080948
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
			this.material.SetFloat("_Speed", this.__Speed);
			this.material.SetFloat("RedFade", this._RedFade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600103D RID: 4157 RVA: 0x00082814 File Offset: 0x00080A14
	private void Update()
	{
	}

	// Token: 0x0600103E RID: 4158 RVA: 0x00082816 File Offset: 0x00080A16
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014B6 RID: 5302
	public Shader SCShader;

	// Token: 0x040014B7 RID: 5303
	private float TimeX = 1f;

	// Token: 0x040014B8 RID: 5304
	private Material SCMaterial;

	// Token: 0x040014B9 RID: 5305
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014BA RID: 5306
	[Range(0f, 1f)]
	public float _RedFade = 1f;
}
