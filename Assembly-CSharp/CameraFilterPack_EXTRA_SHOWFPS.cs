using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200019F RID: 415
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/EXTRA/SHOWFPS")]
public class CameraFilterPack_EXTRA_SHOWFPS : MonoBehaviour
{
	// Token: 0x170002A3 RID: 675
	// (get) Token: 0x06000E7B RID: 3707 RVA: 0x0007AC31 File Offset: 0x00078E31
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

	// Token: 0x06000E7C RID: 3708 RVA: 0x0007AC65 File Offset: 0x00078E65
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

	// Token: 0x06000E7D RID: 3709 RVA: 0x0007AC9C File Offset: 0x00078E9C
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

	// Token: 0x06000E7E RID: 3710 RVA: 0x0007AD95 File Offset: 0x00078F95
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

	// Token: 0x06000E7F RID: 3711 RVA: 0x0007ADA4 File Offset: 0x00078FA4
	private void Update()
	{
		this.accum += Time.timeScale / Time.deltaTime;
		this.frames++;
	}

	// Token: 0x06000E80 RID: 3712 RVA: 0x0007ADCC File Offset: 0x00078FCC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012DD RID: 4829
	public Shader SCShader;

	// Token: 0x040012DE RID: 4830
	private float TimeX = 1f;

	// Token: 0x040012DF RID: 4831
	private Material SCMaterial;

	// Token: 0x040012E0 RID: 4832
	[Range(8f, 42f)]
	public float Size = 12f;

	// Token: 0x040012E1 RID: 4833
	[Range(0f, 100f)]
	private int FPS = 1;

	// Token: 0x040012E2 RID: 4834
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x040012E3 RID: 4835
	[Range(0f, 10f)]
	private float Value4 = 1f;

	// Token: 0x040012E4 RID: 4836
	private float accum;

	// Token: 0x040012E5 RID: 4837
	private int frames;

	// Token: 0x040012E6 RID: 4838
	public float frequency = 0.5f;
}
