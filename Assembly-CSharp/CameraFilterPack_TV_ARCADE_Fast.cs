using System;
using UnityEngine;

// Token: 0x02000205 RID: 517
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/ARCADE_Fast")]
public class CameraFilterPack_TV_ARCADE_Fast : MonoBehaviour
{
	// Token: 0x1700030A RID: 778
	// (get) Token: 0x06001103 RID: 4355 RVA: 0x00085E77 File Offset: 0x00084077
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

	// Token: 0x06001104 RID: 4356 RVA: 0x00085EAB File Offset: 0x000840AB
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

	// Token: 0x06001105 RID: 4357 RVA: 0x00085EE4 File Offset: 0x000840E4
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

	// Token: 0x06001106 RID: 4358 RVA: 0x00085FF2 File Offset: 0x000841F2
	private void Update()
	{
	}

	// Token: 0x06001107 RID: 4359 RVA: 0x00085FF4 File Offset: 0x000841F4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400158A RID: 5514
	public Shader SCShader;

	// Token: 0x0400158B RID: 5515
	private float TimeX = 1f;

	// Token: 0x0400158C RID: 5516
	private Material SCMaterial;

	// Token: 0x0400158D RID: 5517
	[Range(0f, 0.05f)]
	public float Interferance_Size = 0.02f;

	// Token: 0x0400158E RID: 5518
	[Range(0f, 4f)]
	public float Interferance_Speed = 0.5f;

	// Token: 0x0400158F RID: 5519
	[Range(0f, 10f)]
	public float Contrast = 1f;

	// Token: 0x04001590 RID: 5520
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001591 RID: 5521
	private Texture2D Texture2;
}
