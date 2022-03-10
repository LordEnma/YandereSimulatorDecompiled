using System;
using UnityEngine;

// Token: 0x0200022F RID: 559
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/SniperScore")]
public class CameraFilterPack_Vision_SniperScore : MonoBehaviour
{
	// Token: 0x17000333 RID: 819
	// (get) Token: 0x060011FD RID: 4605 RVA: 0x0008A58D File Offset: 0x0008878D
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

	// Token: 0x060011FE RID: 4606 RVA: 0x0008A5C1 File Offset: 0x000887C1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_SniperScore");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011FF RID: 4607 RVA: 0x0008A5E4 File Offset: 0x000887E4
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_Fade", this.Fade);
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.Smooth);
			this.material.SetFloat("_Value3", this.StretchX);
			this.material.SetFloat("_Value4", this.StretchY);
			this.material.SetFloat("_Cible", this._Cible);
			this.material.SetFloat("_ExtraColor", this._ExtraColor);
			this.material.SetFloat("_Distortion", this._Distortion);
			this.material.SetFloat("_PosX", this._PosX);
			this.material.SetFloat("_PosY", this._PosY);
			this.material.SetColor("_Tint", this._Tint);
			this.material.SetFloat("_ExtraLight", this._ExtraLight);
			Vector2 vector = new Vector2((float)Screen.width, (float)Screen.height);
			this.material.SetVector("_ScreenResolution", new Vector4(vector.x, vector.y, vector.y / vector.x, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001200 RID: 4608 RVA: 0x0008A7A5 File Offset: 0x000889A5
	private void Update()
	{
	}

	// Token: 0x06001201 RID: 4609 RVA: 0x0008A7A7 File Offset: 0x000889A7
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040016A3 RID: 5795
	public Shader SCShader;

	// Token: 0x040016A4 RID: 5796
	private float TimeX = 1f;

	// Token: 0x040016A5 RID: 5797
	private Material SCMaterial;

	// Token: 0x040016A6 RID: 5798
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040016A7 RID: 5799
	[Range(0f, 1f)]
	public float Size = 0.45f;

	// Token: 0x040016A8 RID: 5800
	[Range(0.01f, 0.4f)]
	public float Smooth = 0.045f;

	// Token: 0x040016A9 RID: 5801
	[Range(0f, 1f)]
	public float _Cible = 0.5f;

	// Token: 0x040016AA RID: 5802
	[Range(0f, 1f)]
	public float _Distortion = 0.5f;

	// Token: 0x040016AB RID: 5803
	[Range(0f, 1f)]
	public float _ExtraColor = 0.5f;

	// Token: 0x040016AC RID: 5804
	[Range(0f, 1f)]
	public float _ExtraLight = 0.35f;

	// Token: 0x040016AD RID: 5805
	public Color _Tint = new Color(0f, 0.6f, 0f, 0.25f);

	// Token: 0x040016AE RID: 5806
	[Range(0f, 10f)]
	private float StretchX = 1f;

	// Token: 0x040016AF RID: 5807
	[Range(0f, 10f)]
	private float StretchY = 1f;

	// Token: 0x040016B0 RID: 5808
	[Range(-1f, 1f)]
	public float _PosX;

	// Token: 0x040016B1 RID: 5809
	[Range(-1f, 1f)]
	public float _PosY;
}
