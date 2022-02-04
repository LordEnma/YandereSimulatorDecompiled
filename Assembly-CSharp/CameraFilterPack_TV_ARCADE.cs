using System;
using UnityEngine;

// Token: 0x02000204 RID: 516
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/ARCADE")]
public class CameraFilterPack_TV_ARCADE : MonoBehaviour
{
	// Token: 0x17000308 RID: 776
	// (get) Token: 0x060010FA RID: 4346 RVA: 0x00085D7C File Offset: 0x00083F7C
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

	// Token: 0x060010FB RID: 4347 RVA: 0x00085DB0 File Offset: 0x00083FB0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_ARCADE");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010FC RID: 4348 RVA: 0x00085DD4 File Offset: 0x00083FD4
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

	// Token: 0x060010FD RID: 4349 RVA: 0x00085E8A File Offset: 0x0008408A
	private void Update()
	{
	}

	// Token: 0x060010FE RID: 4350 RVA: 0x00085E8C File Offset: 0x0008408C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001584 RID: 5508
	public Shader SCShader;

	// Token: 0x04001585 RID: 5509
	private float TimeX = 1f;

	// Token: 0x04001586 RID: 5510
	private Material SCMaterial;

	// Token: 0x04001587 RID: 5511
	[Range(0f, 1f)]
	public float Fade = 1f;
}
