using System;
using UnityEngine;

// Token: 0x02000221 RID: 545
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/WideScreenHV")]
public class CameraFilterPack_TV_WideScreenHV : MonoBehaviour
{
	// Token: 0x17000325 RID: 805
	// (get) Token: 0x060011A9 RID: 4521 RVA: 0x00088D77 File Offset: 0x00086F77
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

	// Token: 0x060011AA RID: 4522 RVA: 0x00088DAB File Offset: 0x00086FAB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_WideScreenHV");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011AB RID: 4523 RVA: 0x00088DCC File Offset: 0x00086FCC
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
			this.material.SetFloat("_Value2", this.Smooth);
			this.material.SetFloat("_Value3", this.StretchX);
			this.material.SetFloat("_Value4", this.StretchY);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011AC RID: 4524 RVA: 0x00088EC4 File Offset: 0x000870C4
	private void Update()
	{
	}

	// Token: 0x060011AD RID: 4525 RVA: 0x00088EC6 File Offset: 0x000870C6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400163D RID: 5693
	public Shader SCShader;

	// Token: 0x0400163E RID: 5694
	private float TimeX = 1f;

	// Token: 0x0400163F RID: 5695
	private Material SCMaterial;

	// Token: 0x04001640 RID: 5696
	[Range(0f, 0.8f)]
	public float Size = 0.55f;

	// Token: 0x04001641 RID: 5697
	[Range(0.001f, 0.4f)]
	public float Smooth = 0.01f;

	// Token: 0x04001642 RID: 5698
	[Range(0f, 10f)]
	private float StretchX = 1f;

	// Token: 0x04001643 RID: 5699
	[Range(0f, 10f)]
	private float StretchY = 1f;
}
