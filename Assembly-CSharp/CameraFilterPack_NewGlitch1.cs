using System;
using UnityEngine;

// Token: 0x020001E4 RID: 484
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch1")]
public class CameraFilterPack_NewGlitch1 : MonoBehaviour
{
	// Token: 0x170002E8 RID: 744
	// (get) Token: 0x06001034 RID: 4148 RVA: 0x00082440 File Offset: 0x00080640
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

	// Token: 0x06001035 RID: 4149 RVA: 0x00082474 File Offset: 0x00080674
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch1");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001036 RID: 4150 RVA: 0x00082498 File Offset: 0x00080698
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
			this.material.SetFloat("Seed", this._Seed);
			this.material.SetFloat("Size", this._Size);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001037 RID: 4151 RVA: 0x00082564 File Offset: 0x00080764
	private void Update()
	{
	}

	// Token: 0x06001038 RID: 4152 RVA: 0x00082566 File Offset: 0x00080766
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014A8 RID: 5288
	public Shader SCShader;

	// Token: 0x040014A9 RID: 5289
	private float TimeX = 1f;

	// Token: 0x040014AA RID: 5290
	private Material SCMaterial;

	// Token: 0x040014AB RID: 5291
	[Range(0f, 1f)]
	public float _Seed = 1f;

	// Token: 0x040014AC RID: 5292
	[Range(0f, 1f)]
	public float _Size = 1f;
}
