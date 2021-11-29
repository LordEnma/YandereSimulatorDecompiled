using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200019E RID: 414
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/EXTRA/SHOWFPS")]
public class CameraFilterPack_EXTRA_SHOWFPS : MonoBehaviour
{
	// Token: 0x170002A3 RID: 675
	// (get) Token: 0x06000E75 RID: 3701 RVA: 0x0007A211 File Offset: 0x00078411
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

	// Token: 0x06000E76 RID: 3702 RVA: 0x0007A245 File Offset: 0x00078445
	private void Start()
	{
		this.FPS = 0;
		base.StartCoroutine(this.FPSX());
		this.SCShader = Shader.Find("CameraFilterPack/EXTRA_SHOWFPS");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E77 RID: 3703 RVA: 0x0007A27C File Offset: 0x0007847C
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", (float)this.FPS);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E78 RID: 3704 RVA: 0x0007A375 File Offset: 0x00078575
	private IEnumerator FPSX()
	{
		for (;;)
		{
			float num = this.accum / (float)this.frames;
			this.FPS = (int)num;
			this.accum = 0f;
			this.frames = 0;
			yield return new WaitForSeconds(this.frequency);
		}
		yield break;
	}

	// Token: 0x06000E79 RID: 3705 RVA: 0x0007A384 File Offset: 0x00078584
	private void Update()
	{
		this.accum += Time.timeScale / Time.deltaTime;
		this.frames++;
	}

	// Token: 0x06000E7A RID: 3706 RVA: 0x0007A3AC File Offset: 0x000785AC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012C5 RID: 4805
	public Shader SCShader;

	// Token: 0x040012C6 RID: 4806
	private float TimeX = 1f;

	// Token: 0x040012C7 RID: 4807
	private Material SCMaterial;

	// Token: 0x040012C8 RID: 4808
	[Range(8f, 42f)]
	public float Size = 12f;

	// Token: 0x040012C9 RID: 4809
	[Range(0f, 100f)]
	private int FPS = 1;

	// Token: 0x040012CA RID: 4810
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x040012CB RID: 4811
	[Range(0f, 10f)]
	private float Value4 = 1f;

	// Token: 0x040012CC RID: 4812
	private float accum;

	// Token: 0x040012CD RID: 4813
	private int frames;

	// Token: 0x040012CE RID: 4814
	public float frequency = 0.5f;
}
