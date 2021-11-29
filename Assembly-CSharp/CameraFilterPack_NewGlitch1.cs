using System;
using UnityEngine;

// Token: 0x020001E3 RID: 483
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch1")]
public class CameraFilterPack_NewGlitch1 : MonoBehaviour
{
	// Token: 0x170002E8 RID: 744
	// (get) Token: 0x06001030 RID: 4144 RVA: 0x00081FE4 File Offset: 0x000801E4
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

	// Token: 0x06001031 RID: 4145 RVA: 0x00082018 File Offset: 0x00080218
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch1");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001032 RID: 4146 RVA: 0x0008203C File Offset: 0x0008023C
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

	// Token: 0x06001033 RID: 4147 RVA: 0x00082108 File Offset: 0x00080308
	private void Update()
	{
	}

	// Token: 0x06001034 RID: 4148 RVA: 0x0008210A File Offset: 0x0008030A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014A0 RID: 5280
	public Shader SCShader;

	// Token: 0x040014A1 RID: 5281
	private float TimeX = 1f;

	// Token: 0x040014A2 RID: 5282
	private Material SCMaterial;

	// Token: 0x040014A3 RID: 5283
	[Range(0f, 1f)]
	public float _Seed = 1f;

	// Token: 0x040014A4 RID: 5284
	[Range(0f, 1f)]
	public float _Size = 1f;
}
