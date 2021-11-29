using System;
using UnityEngine;

// Token: 0x02000163 RID: 355
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Sepia")]
public class CameraFilterPack_Color_Sepia : MonoBehaviour
{
	// Token: 0x17000268 RID: 616
	// (get) Token: 0x06000D11 RID: 3345 RVA: 0x00074503 File Offset: 0x00072703
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

	// Token: 0x06000D12 RID: 3346 RVA: 0x00074537 File Offset: 0x00072737
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Sepia");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D13 RID: 3347 RVA: 0x00074558 File Offset: 0x00072758
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
			this.material.SetFloat("_Fade", this._Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D14 RID: 3348 RVA: 0x0007460E File Offset: 0x0007280E
	private void Update()
	{
	}

	// Token: 0x06000D15 RID: 3349 RVA: 0x00074610 File Offset: 0x00072810
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001156 RID: 4438
	public Shader SCShader;

	// Token: 0x04001157 RID: 4439
	private float TimeX = 1f;

	// Token: 0x04001158 RID: 4440
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x04001159 RID: 4441
	private Material SCMaterial;
}
