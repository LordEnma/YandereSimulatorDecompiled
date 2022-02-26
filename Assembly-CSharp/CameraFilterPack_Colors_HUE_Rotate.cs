using System;
using UnityEngine;

// Token: 0x0200016E RID: 366
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/HUE_Rotate")]
public class CameraFilterPack_Colors_HUE_Rotate : MonoBehaviour
{
	// Token: 0x17000272 RID: 626
	// (get) Token: 0x06000D53 RID: 3411 RVA: 0x00075D23 File Offset: 0x00073F23
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

	// Token: 0x06000D54 RID: 3412 RVA: 0x00075D57 File Offset: 0x00073F57
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_HUE_Rotate");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D55 RID: 3413 RVA: 0x00075D78 File Offset: 0x00073F78
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

	// Token: 0x06000D56 RID: 3414 RVA: 0x00075E27 File Offset: 0x00074027
	private void Update()
	{
	}

	// Token: 0x06000D57 RID: 3415 RVA: 0x00075E29 File Offset: 0x00074029
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400119C RID: 4508
	public Shader SCShader;

	// Token: 0x0400119D RID: 4509
	private float TimeX = 1f;

	// Token: 0x0400119E RID: 4510
	private Material SCMaterial;

	// Token: 0x0400119F RID: 4511
	[Range(1f, 20f)]
	public float Speed = 10f;
}
