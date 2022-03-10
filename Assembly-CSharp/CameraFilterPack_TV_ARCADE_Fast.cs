using System;
using UnityEngine;

// Token: 0x02000206 RID: 518
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/ARCADE_Fast")]
public class CameraFilterPack_TV_ARCADE_Fast : MonoBehaviour
{
	// Token: 0x1700030A RID: 778
	// (get) Token: 0x06001107 RID: 4359 RVA: 0x0008641B File Offset: 0x0008461B
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

	// Token: 0x06001108 RID: 4360 RVA: 0x0008644F File Offset: 0x0008464F
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_TV_Arcade1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/TV_ARCADE_Fast");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001109 RID: 4361 RVA: 0x00086488 File Offset: 0x00084688
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
			this.material.SetFloat("_Value", this.Interferance_Size);
			this.material.SetFloat("_Value2", this.Interferance_Speed);
			this.material.SetFloat("_Value3", this.Contrast);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600110A RID: 4362 RVA: 0x00086596 File Offset: 0x00084796
	private void Update()
	{
	}

	// Token: 0x0600110B RID: 4363 RVA: 0x00086598 File Offset: 0x00084798
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400159B RID: 5531
	public Shader SCShader;

	// Token: 0x0400159C RID: 5532
	private float TimeX = 1f;

	// Token: 0x0400159D RID: 5533
	private Material SCMaterial;

	// Token: 0x0400159E RID: 5534
	[Range(0f, 0.05f)]
	public float Interferance_Size = 0.02f;

	// Token: 0x0400159F RID: 5535
	[Range(0f, 4f)]
	public float Interferance_Speed = 0.5f;

	// Token: 0x040015A0 RID: 5536
	[Range(0f, 10f)]
	public float Contrast = 1f;

	// Token: 0x040015A1 RID: 5537
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015A2 RID: 5538
	private Texture2D Texture2;
}
