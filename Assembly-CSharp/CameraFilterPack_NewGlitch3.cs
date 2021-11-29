using System;
using UnityEngine;

// Token: 0x020001E5 RID: 485
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch3")]
public class CameraFilterPack_NewGlitch3 : MonoBehaviour
{
	// Token: 0x170002EA RID: 746
	// (get) Token: 0x0600103C RID: 4156 RVA: 0x000822B5 File Offset: 0x000804B5
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

	// Token: 0x0600103D RID: 4157 RVA: 0x000822E9 File Offset: 0x000804E9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600103E RID: 4158 RVA: 0x0008230C File Offset: 0x0008050C
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

	// Token: 0x0600103F RID: 4159 RVA: 0x000823D8 File Offset: 0x000805D8
	private void Update()
	{
	}

	// Token: 0x06001040 RID: 4160 RVA: 0x000823DA File Offset: 0x000805DA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014AA RID: 5290
	public Shader SCShader;

	// Token: 0x040014AB RID: 5291
	private float TimeX = 1f;

	// Token: 0x040014AC RID: 5292
	private Material SCMaterial;

	// Token: 0x040014AD RID: 5293
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014AE RID: 5294
	[Range(0f, 1f)]
	public float _RedFade = 1f;
}
