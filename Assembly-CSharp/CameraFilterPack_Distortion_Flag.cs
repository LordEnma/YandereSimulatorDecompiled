using System;
using UnityEngine;

// Token: 0x02000179 RID: 377
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Flag")]
public class CameraFilterPack_Distortion_Flag : MonoBehaviour
{
	// Token: 0x1700027E RID: 638
	// (get) Token: 0x06000D97 RID: 3479 RVA: 0x000769C4 File Offset: 0x00074BC4
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

	// Token: 0x06000D98 RID: 3480 RVA: 0x000769F8 File Offset: 0x00074BF8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Flag");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D99 RID: 3481 RVA: 0x00076A1C File Offset: 0x00074C1C
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D9A RID: 3482 RVA: 0x00076ACB File Offset: 0x00074CCB
	private void Update()
	{
	}

	// Token: 0x06000D9B RID: 3483 RVA: 0x00076ACD File Offset: 0x00074CCD
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011D9 RID: 4569
	public Shader SCShader;

	// Token: 0x040011DA RID: 4570
	private float TimeX = 1f;

	// Token: 0x040011DB RID: 4571
	[Range(0f, 2f)]
	public float Distortion = 1f;

	// Token: 0x040011DC RID: 4572
	private Material SCMaterial;

	// Token: 0x040011DD RID: 4573
	public static float ChangeDistortion;
}
