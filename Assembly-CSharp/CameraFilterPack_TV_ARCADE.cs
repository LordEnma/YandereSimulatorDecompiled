using System;
using UnityEngine;

// Token: 0x02000204 RID: 516
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/ARCADE")]
public class CameraFilterPack_TV_ARCADE : MonoBehaviour
{
	// Token: 0x17000308 RID: 776
	// (get) Token: 0x060010FB RID: 4347 RVA: 0x00086128 File Offset: 0x00084328
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

	// Token: 0x060010FC RID: 4348 RVA: 0x0008615C File Offset: 0x0008435C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_ARCADE");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010FD RID: 4349 RVA: 0x00086180 File Offset: 0x00084380
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
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010FE RID: 4350 RVA: 0x00086236 File Offset: 0x00084436
	private void Update()
	{
	}

	// Token: 0x060010FF RID: 4351 RVA: 0x00086238 File Offset: 0x00084438
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001590 RID: 5520
	public Shader SCShader;

	// Token: 0x04001591 RID: 5521
	private float TimeX = 1f;

	// Token: 0x04001592 RID: 5522
	private Material SCMaterial;

	// Token: 0x04001593 RID: 5523
	[Range(0f, 1f)]
	public float Fade = 1f;
}
