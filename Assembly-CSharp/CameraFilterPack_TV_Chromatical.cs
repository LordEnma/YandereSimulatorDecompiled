using System;
using UnityEngine;

// Token: 0x02000209 RID: 521
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Chromatical")]
public class CameraFilterPack_TV_Chromatical : MonoBehaviour
{
	// Token: 0x1700030E RID: 782
	// (get) Token: 0x0600111B RID: 4379 RVA: 0x00086817 File Offset: 0x00084A17
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

	// Token: 0x0600111C RID: 4380 RVA: 0x0008684B File Offset: 0x00084A4B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Chromatical");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600111D RID: 4381 RVA: 0x0008686C File Offset: 0x00084A6C
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime * 2f;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("Intensity", this.Intensity);
			this.material.SetFloat("Speed", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600111E RID: 4382 RVA: 0x0008694D File Offset: 0x00084B4D
	private void Update()
	{
	}

	// Token: 0x0600111F RID: 4383 RVA: 0x0008694F File Offset: 0x00084B4F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015B2 RID: 5554
	public Shader SCShader;

	// Token: 0x040015B3 RID: 5555
	private float TimeX = 1f;

	// Token: 0x040015B4 RID: 5556
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015B5 RID: 5557
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x040015B6 RID: 5558
	[Range(0f, 3f)]
	public float Speed = 1f;

	// Token: 0x040015B7 RID: 5559
	private Material SCMaterial;
}
