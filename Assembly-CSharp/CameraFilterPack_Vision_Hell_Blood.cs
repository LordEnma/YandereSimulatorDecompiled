using System;
using UnityEngine;

// Token: 0x0200022B RID: 555
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Hell_Blood")]
public class CameraFilterPack_Vision_Hell_Blood : MonoBehaviour
{
	// Token: 0x1700032F RID: 815
	// (get) Token: 0x060011E5 RID: 4581 RVA: 0x00089CDF File Offset: 0x00087EDF
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

	// Token: 0x060011E6 RID: 4582 RVA: 0x00089D13 File Offset: 0x00087F13
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Hell_Blood");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011E7 RID: 4583 RVA: 0x00089D34 File Offset: 0x00087F34
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
			this.material.SetFloat("_Value", this.Hole_Size);
			this.material.SetFloat("_Value2", this.Hole_Smooth);
			this.material.SetFloat("_Value3", this.Hole_Speed * 15f);
			this.material.SetColor("ColorBlood", this.ColorBlood);
			this.material.SetFloat("_Value4", this.Intensity);
			this.material.SetFloat("BloodAlternative1", this.BloodAlternative1);
			this.material.SetFloat("BloodAlternative2", this.BloodAlternative2);
			this.material.SetFloat("BloodAlternative3", this.BloodAlternative3);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011E8 RID: 4584 RVA: 0x00089E8A File Offset: 0x0008808A
	private void Update()
	{
	}

	// Token: 0x060011E9 RID: 4585 RVA: 0x00089E8C File Offset: 0x0008808C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001679 RID: 5753
	public Shader SCShader;

	// Token: 0x0400167A RID: 5754
	private float TimeX = 1f;

	// Token: 0x0400167B RID: 5755
	private Material SCMaterial;

	// Token: 0x0400167C RID: 5756
	[Range(0f, 1f)]
	public float Hole_Size = 0.57f;

	// Token: 0x0400167D RID: 5757
	[Range(0f, 0.5f)]
	public float Hole_Smooth = 0.362f;

	// Token: 0x0400167E RID: 5758
	[Range(-2f, 2f)]
	public float Hole_Speed = 0.85f;

	// Token: 0x0400167F RID: 5759
	[Range(-10f, 10f)]
	public float Intensity = 0.24f;

	// Token: 0x04001680 RID: 5760
	public Color ColorBlood = new Color(1f, 0f, 0f, 1f);

	// Token: 0x04001681 RID: 5761
	[Range(-1f, 1f)]
	public float BloodAlternative1;

	// Token: 0x04001682 RID: 5762
	[Range(-1f, 1f)]
	public float BloodAlternative2;

	// Token: 0x04001683 RID: 5763
	[Range(-1f, 1f)]
	public float BloodAlternative3 = -1f;
}
