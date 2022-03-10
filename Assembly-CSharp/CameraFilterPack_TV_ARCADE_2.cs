using System;
using UnityEngine;

// Token: 0x02000205 RID: 517
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/ARCADE_2")]
public class CameraFilterPack_TV_ARCADE_2 : MonoBehaviour
{
	// Token: 0x17000309 RID: 777
	// (get) Token: 0x06001101 RID: 4353 RVA: 0x00086270 File Offset: 0x00084470
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

	// Token: 0x06001102 RID: 4354 RVA: 0x000862A4 File Offset: 0x000844A4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_ARCADE_2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001103 RID: 4355 RVA: 0x000862C8 File Offset: 0x000844C8
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
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001104 RID: 4356 RVA: 0x000863C0 File Offset: 0x000845C0
	private void Update()
	{
	}

	// Token: 0x06001105 RID: 4357 RVA: 0x000863C2 File Offset: 0x000845C2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001594 RID: 5524
	public Shader SCShader;

	// Token: 0x04001595 RID: 5525
	private float TimeX = 1f;

	// Token: 0x04001596 RID: 5526
	private Material SCMaterial;

	// Token: 0x04001597 RID: 5527
	[Range(0f, 10f)]
	public float Interferance_Size = 1f;

	// Token: 0x04001598 RID: 5528
	[Range(0f, 10f)]
	public float Interferance_Speed = 0.5f;

	// Token: 0x04001599 RID: 5529
	[Range(0f, 10f)]
	public float Contrast = 1f;

	// Token: 0x0400159A RID: 5530
	[Range(0f, 1f)]
	public float Fade = 1f;
}
