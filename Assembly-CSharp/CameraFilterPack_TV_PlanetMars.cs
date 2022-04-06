using System;
using UnityEngine;

// Token: 0x02000215 RID: 533
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Planet Mars")]
public class CameraFilterPack_TV_PlanetMars : MonoBehaviour
{
	// Token: 0x17000319 RID: 793
	// (get) Token: 0x06001163 RID: 4451 RVA: 0x00088171 File Offset: 0x00086371
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

	// Token: 0x06001164 RID: 4452 RVA: 0x000881A5 File Offset: 0x000863A5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_PlanetMars");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001165 RID: 4453 RVA: 0x000881C8 File Offset: 0x000863C8
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
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001166 RID: 4454 RVA: 0x00088294 File Offset: 0x00086494
	private void Update()
	{
	}

	// Token: 0x06001167 RID: 4455 RVA: 0x00088296 File Offset: 0x00086496
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001604 RID: 5636
	public Shader SCShader;

	// Token: 0x04001605 RID: 5637
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001606 RID: 5638
	private float TimeX = 1f;

	// Token: 0x04001607 RID: 5639
	[Range(-10f, 10f)]
	public float Distortion = 1f;

	// Token: 0x04001608 RID: 5640
	private Material SCMaterial;
}
