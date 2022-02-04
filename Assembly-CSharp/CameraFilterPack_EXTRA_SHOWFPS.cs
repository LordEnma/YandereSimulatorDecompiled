using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200019F RID: 415
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/EXTRA/SHOWFPS")]
public class CameraFilterPack_EXTRA_SHOWFPS : MonoBehaviour
{
	// Token: 0x170002A3 RID: 675
	// (get) Token: 0x06000E78 RID: 3704 RVA: 0x0007A409 File Offset: 0x00078609
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

	// Token: 0x06000E79 RID: 3705 RVA: 0x0007A43D File Offset: 0x0007863D
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

	// Token: 0x06000E7A RID: 3706 RVA: 0x0007A474 File Offset: 0x00078674
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

	// Token: 0x06000E7B RID: 3707 RVA: 0x0007A56D File Offset: 0x0007876D
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

	// Token: 0x06000E7C RID: 3708 RVA: 0x0007A57C File Offset: 0x0007877C
	private void Update()
	{
		this.accum += Time.timeScale / Time.deltaTime;
		this.frames++;
	}

	// Token: 0x06000E7D RID: 3709 RVA: 0x0007A5A4 File Offset: 0x000787A4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012CA RID: 4810
	public Shader SCShader;

	// Token: 0x040012CB RID: 4811
	private float TimeX = 1f;

	// Token: 0x040012CC RID: 4812
	private Material SCMaterial;

	// Token: 0x040012CD RID: 4813
	[Range(8f, 42f)]
	public float Size = 12f;

	// Token: 0x040012CE RID: 4814
	[Range(0f, 100f)]
	private int FPS = 1;

	// Token: 0x040012CF RID: 4815
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x040012D0 RID: 4816
	[Range(0f, 10f)]
	private float Value4 = 1f;

	// Token: 0x040012D1 RID: 4817
	private float accum;

	// Token: 0x040012D2 RID: 4818
	private int frames;

	// Token: 0x040012D3 RID: 4819
	public float frequency = 0.5f;
}
