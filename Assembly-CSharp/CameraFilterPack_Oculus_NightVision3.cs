using System;
using UnityEngine;

// Token: 0x020001F1 RID: 497
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 3")]
public class CameraFilterPack_Oculus_NightVision3 : MonoBehaviour
{
	// Token: 0x170002F6 RID: 758
	// (get) Token: 0x06001088 RID: 4232 RVA: 0x00083C4A File Offset: 0x00081E4A
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

	// Token: 0x06001089 RID: 4233 RVA: 0x00083C7E File Offset: 0x00081E7E
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Oculus_NightVision3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600108A RID: 4234 RVA: 0x00083CA0 File Offset: 0x00081EA0
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
			this.material.SetFloat("_Greenness", this.Greenness);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600108B RID: 4235 RVA: 0x00083D4F File Offset: 0x00081F4F
	private void Update()
	{
	}

	// Token: 0x0600108C RID: 4236 RVA: 0x00083D51 File Offset: 0x00081F51
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001509 RID: 5385
	public Shader SCShader;

	// Token: 0x0400150A RID: 5386
	private float TimeX = 1f;

	// Token: 0x0400150B RID: 5387
	private Material SCMaterial;

	// Token: 0x0400150C RID: 5388
	[Range(0.2f, 2f)]
	public float Greenness = 1f;
}
