using System;
using UnityEngine;

// Token: 0x02000179 RID: 377
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/FishEye")]
public class CameraFilterPack_Distortion_FishEye : MonoBehaviour
{
	// Token: 0x1700027D RID: 637
	// (get) Token: 0x06000D94 RID: 3476 RVA: 0x00076A75 File Offset: 0x00074C75
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

	// Token: 0x06000D95 RID: 3477 RVA: 0x00076AA9 File Offset: 0x00074CA9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_FishEye");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D96 RID: 3478 RVA: 0x00076ACC File Offset: 0x00074CCC
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D97 RID: 3479 RVA: 0x00076B82 File Offset: 0x00074D82
	private void Update()
	{
	}

	// Token: 0x06000D98 RID: 3480 RVA: 0x00076B84 File Offset: 0x00074D84
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011DA RID: 4570
	public Shader SCShader;

	// Token: 0x040011DB RID: 4571
	private float TimeX = 1f;

	// Token: 0x040011DC RID: 4572
	private Material SCMaterial;

	// Token: 0x040011DD RID: 4573
	[Range(0f, 1f)]
	public float Distortion = 0.35f;
}
