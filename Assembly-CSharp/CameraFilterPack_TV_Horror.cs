using System;
using UnityEngine;

// Token: 0x0200020D RID: 525
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Horror")]
public class CameraFilterPack_TV_Horror : MonoBehaviour
{
	// Token: 0x17000312 RID: 786
	// (get) Token: 0x06001133 RID: 4403 RVA: 0x00086DC5 File Offset: 0x00084FC5
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

	// Token: 0x06001134 RID: 4404 RVA: 0x00086DF9 File Offset: 0x00084FF9
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_TV_HorrorFX") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/TV_Horror");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001135 RID: 4405 RVA: 0x00086E30 File Offset: 0x00085030
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
			this.material.SetFloat("Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetTexture("Texture2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001136 RID: 4406 RVA: 0x00086F12 File Offset: 0x00085112
	private void Update()
	{
	}

	// Token: 0x06001137 RID: 4407 RVA: 0x00086F14 File Offset: 0x00085114
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015C8 RID: 5576
	public Shader SCShader;

	// Token: 0x040015C9 RID: 5577
	private float TimeX = 1f;

	// Token: 0x040015CA RID: 5578
	private Material SCMaterial;

	// Token: 0x040015CB RID: 5579
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015CC RID: 5580
	[Range(0f, 1f)]
	public float Distortion = 1f;

	// Token: 0x040015CD RID: 5581
	private Texture2D Texture2;
}
