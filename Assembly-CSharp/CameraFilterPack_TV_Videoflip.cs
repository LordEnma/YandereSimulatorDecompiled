using System;
using UnityEngine;

// Token: 0x0200021D RID: 541
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Videoflip")]
public class CameraFilterPack_TV_Videoflip : MonoBehaviour
{
	// Token: 0x17000321 RID: 801
	// (get) Token: 0x06001191 RID: 4497 RVA: 0x00088838 File Offset: 0x00086A38
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

	// Token: 0x06001192 RID: 4498 RVA: 0x0008886C File Offset: 0x00086A6C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Videoflip");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001193 RID: 4499 RVA: 0x00088890 File Offset: 0x00086A90
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001194 RID: 4500 RVA: 0x0008892D File Offset: 0x00086B2D
	private void Update()
	{
	}

	// Token: 0x06001195 RID: 4501 RVA: 0x0008892F File Offset: 0x00086B2F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001628 RID: 5672
	public Shader SCShader;

	// Token: 0x04001629 RID: 5673
	private float TimeX = 1f;

	// Token: 0x0400162A RID: 5674
	private Material SCMaterial;
}
