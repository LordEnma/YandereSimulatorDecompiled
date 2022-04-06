using System;
using UnityEngine;

// Token: 0x0200016E RID: 366
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/HUE_Rotate")]
public class CameraFilterPack_Colors_HUE_Rotate : MonoBehaviour
{
	// Token: 0x17000272 RID: 626
	// (get) Token: 0x06000D55 RID: 3413 RVA: 0x000762E7 File Offset: 0x000744E7
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

	// Token: 0x06000D56 RID: 3414 RVA: 0x0007631B File Offset: 0x0007451B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_HUE_Rotate");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D57 RID: 3415 RVA: 0x0007633C File Offset: 0x0007453C
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
			this.material.SetFloat("_Speed", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D58 RID: 3416 RVA: 0x000763EB File Offset: 0x000745EB
	private void Update()
	{
	}

	// Token: 0x06000D59 RID: 3417 RVA: 0x000763ED File Offset: 0x000745ED
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011AC RID: 4524
	public Shader SCShader;

	// Token: 0x040011AD RID: 4525
	private float TimeX = 1f;

	// Token: 0x040011AE RID: 4526
	private Material SCMaterial;

	// Token: 0x040011AF RID: 4527
	[Range(1f, 20f)]
	public float Speed = 10f;
}
