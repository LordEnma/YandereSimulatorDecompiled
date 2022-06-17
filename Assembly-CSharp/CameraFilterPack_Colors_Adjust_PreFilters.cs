// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Colors_Adjust_PreFilters
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/ColorsAdjust/Photo Filters")]
public class CameraFilterPack_Colors_Adjust_PreFilters : MonoBehaviour
{
  private string ShaderName = "CameraFilterPack/Colors_Adjust_PreFilters";
  public Shader SCShader;
  public CameraFilterPack_Colors_Adjust_PreFilters.filters filterchoice;
  [Range(0.0f, 1f)]
  public float FadeFX = 1f;
  private float TimeX = 1f;
  private Material SCMaterial;
  private float[] Matrix9;

  private Material material
  {
    get
    {
      if ((Object) this.SCMaterial == (Object) null)
      {
        this.SCMaterial = new Material(this.SCShader);
        this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
      }
      return this.SCMaterial;
    }
  }

  private void ChangeFilters()
  {
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Normal)
      this.Matrix9 = new float[12]
      {
        100f,
        0.0f,
        0.0f,
        0.0f,
        100f,
        0.0f,
        0.0f,
        0.0f,
        100f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Deuteranomaly)
      this.Matrix9 = new float[12]
      {
        80f,
        20f,
        0.0f,
        25.833f,
        74.167f,
        0.0f,
        0.0f,
        14.167f,
        85.833f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Protanopia)
      this.Matrix9 = new float[12]
      {
        56.667f,
        43.333f,
        0.0f,
        55.833f,
        44.167f,
        0.0f,
        0.0f,
        24.167f,
        75.833f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Protanomaly)
      this.Matrix9 = new float[12]
      {
        81.667f,
        18.333f,
        0.0f,
        33.333f,
        66.667f,
        0.0f,
        0.0f,
        12.5f,
        87.5f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Deuteranopia)
      this.Matrix9 = new float[12]
      {
        62.5f,
        37.5f,
        0.0f,
        70f,
        30f,
        0.0f,
        0.0f,
        30f,
        70f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Tritanomaly)
      this.Matrix9 = new float[12]
      {
        96.667f,
        3.333f,
        0.0f,
        0.0f,
        73.333f,
        26.667f,
        0.0f,
        18.333f,
        81.667f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Achromatopsia)
      this.Matrix9 = new float[12]
      {
        29.9f,
        58.7f,
        11.4f,
        29.9f,
        58.7f,
        11.4f,
        29.9f,
        58.7f,
        11.4f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Achromatomaly)
      this.Matrix9 = new float[12]
      {
        61.8f,
        32f,
        6.2f,
        16.3f,
        77.5f,
        6.2f,
        16.3f,
        32f,
        51.6f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Blindness_Tritanopia)
      this.Matrix9 = new float[12]
      {
        95f,
        5f,
        0.0f,
        0.0f,
        43.333f,
        56.667f,
        0.0f,
        47.5f,
        52.5f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlueLagoon)
      this.Matrix9 = new float[12]
      {
        100f,
        102f,
        0.0f,
        18f,
        100f,
        4f,
        28f,
        -26f,
        100f,
        -64f,
        0.0f,
        12f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.GoldenPink)
      this.Matrix9 = new float[12]
      {
        70f,
        200f,
        0.0f,
        0.0f,
        100f,
        8f,
        6f,
        12f,
        110f,
        0.0f,
        0.0f,
        -6f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlueMoon)
      this.Matrix9 = new float[12]
      {
        200f,
        98f,
        -116f,
        24f,
        100f,
        2f,
        30f,
        52f,
        20f,
        -48f,
        -20f,
        12f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.DarkPink)
      this.Matrix9 = new float[12]
      {
        60f,
        112f,
        36f,
        24f,
        100f,
        2f,
        0.0f,
        -26f,
        100f,
        -56f,
        -20f,
        12f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.RedWhite)
      this.Matrix9 = new float[12]
      {
        -42f,
        68f,
        108f,
        -96f,
        100f,
        116f,
        -92f,
        104f,
        96f,
        0.0f,
        2f,
        4f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.VintageYellow)
      this.Matrix9 = new float[12]
      {
        200f,
        109f,
        -104f,
        42f,
        126f,
        -1f,
        -40f,
        121f,
        -31f,
        -48f,
        -20f,
        12f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.NashVille)
      this.Matrix9 = new float[12]
      {
        130f,
        8f,
        7f,
        19f,
        89f,
        3f,
        -1f,
        11f,
        57f,
        10f,
        19f,
        47f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.PopRocket)
      this.Matrix9 = new float[12]
      {
        100f,
        6f,
        -17f,
        0.0f,
        107f,
        0.0f,
        10f,
        21f,
        100f,
        40f,
        0.0f,
        8f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.RedSoftLight)
      this.Matrix9 = new float[12]
      {
        -4f,
        200f,
        -30f,
        -58f,
        200f,
        -30f,
        -58f,
        200f,
        -30f,
        -11f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlackAndWhite_Blue)
      this.Matrix9 = new float[12]
      {
        0.0f,
        0.0f,
        100f,
        0.0f,
        0.0f,
        100f,
        0.0f,
        0.0f,
        100f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlackAndWhite_Green)
      this.Matrix9 = new float[12]
      {
        0.0f,
        100f,
        0.0f,
        0.0f,
        100f,
        0.0f,
        0.0f,
        100f,
        0.0f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlackAndWhite_Orange)
      this.Matrix9 = new float[12]
      {
        50f,
        50f,
        0.0f,
        50f,
        50f,
        0.0f,
        50f,
        50f,
        0.0f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlackAndWhite_Red)
      this.Matrix9 = new float[12]
      {
        100f,
        0.0f,
        0.0f,
        100f,
        0.0f,
        0.0f,
        100f,
        0.0f,
        0.0f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlackAndWhite_Yellow)
      this.Matrix9 = new float[12]
      {
        34f,
        66f,
        0.0f,
        34f,
        66f,
        0.0f,
        34f,
        66f,
        0.0f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.YellowSunSet)
      this.Matrix9 = new float[12]
      {
        117f,
        -6f,
        53f,
        -68f,
        135f,
        19f,
        -146f,
        -61f,
        200f,
        0.0f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Walden)
      this.Matrix9 = new float[12]
      {
        99f,
        2f,
        13f,
        100f,
        1f,
        40f,
        50f,
        8f,
        71f,
        0.0f,
        2f,
        7f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.WhiteShine)
      this.Matrix9 = new float[12]
      {
        190f,
        24f,
        -33f,
        2f,
        200f,
        -6f,
        -10f,
        27f,
        200f,
        -6f,
        -13f,
        15f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Fluo)
      this.Matrix9 = new float[12]
      {
        100f,
        0.0f,
        0.0f,
        0.0f,
        113f,
        0.0f,
        200f,
        -200f,
        -200f,
        0.0f,
        0.0f,
        36f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.MarsSunRise)
      this.Matrix9 = new float[12]
      {
        50f,
        141f,
        -81f,
        -17f,
        62f,
        29f,
        -159f,
        -137f,
        -200f,
        7f,
        -34f,
        -6f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.Amelie)
      this.Matrix9 = new float[12]
      {
        100f,
        11f,
        39f,
        1f,
        63f,
        53f,
        -24f,
        71f,
        20f,
        -25f,
        -10f,
        -24f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.BlueJeans)
      this.Matrix9 = new float[12]
      {
        181f,
        11f,
        15f,
        40f,
        40f,
        20f,
        40f,
        40f,
        20f,
        -59f,
        0.0f,
        0.0f
      };
    if (this.filterchoice == CameraFilterPack_Colors_Adjust_PreFilters.filters.NightVision)
      this.Matrix9 = new float[12]
      {
        200f,
        -200f,
        -200f,
        195f,
        4f,
        -160f,
        200f,
        -200f,
        -200f,
        -200f,
        10f,
        -200f
      };
    if (this.filterchoice != CameraFilterPack_Colors_Adjust_PreFilters.filters.BlueParadise)
      return;
    this.Matrix9 = new float[12]
    {
      66f,
      200f,
      -200f,
      25f,
      38f,
      36f,
      30f,
      150f,
      114f,
      17f,
      0.0f,
      65f
    };
  }

  private void Start()
  {
    this.ChangeFilters();
    this.SCShader = Shader.Find(this.ShaderName);
    if (SystemInfo.supportsImageEffects)
      return;
    this.enabled = false;
  }

  private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
  {
    if ((Object) this.SCShader != (Object) null)
    {
      this.TimeX += Time.deltaTime;
      if ((double) this.TimeX > 100.0)
        this.TimeX = 0.0f;
      this.material.SetFloat("_TimeX", this.TimeX);
      this.material.SetFloat("_Red_R", this.Matrix9[0] / 100f);
      this.material.SetFloat("_Red_G", this.Matrix9[1] / 100f);
      this.material.SetFloat("_Red_B", this.Matrix9[2] / 100f);
      this.material.SetFloat("_Green_R", this.Matrix9[3] / 100f);
      this.material.SetFloat("_Green_G", this.Matrix9[4] / 100f);
      this.material.SetFloat("_Green_B", this.Matrix9[5] / 100f);
      this.material.SetFloat("_Blue_R", this.Matrix9[6] / 100f);
      this.material.SetFloat("_Blue_G", this.Matrix9[7] / 100f);
      this.material.SetFloat("_Blue_B", this.Matrix9[8] / 100f);
      this.material.SetFloat("_Red_C", this.Matrix9[9] / 100f);
      this.material.SetFloat("_Green_C", this.Matrix9[10] / 100f);
      this.material.SetFloat("_Blue_C", this.Matrix9[11] / 100f);
      this.material.SetFloat("_FadeFX", this.FadeFX);
      this.material.SetVector("_ScreenResolution", new Vector4((float) sourceTexture.width, (float) sourceTexture.height, 0.0f, 0.0f));
      Graphics.Blit((Texture) sourceTexture, destTexture, this.material);
    }
    else
      Graphics.Blit((Texture) sourceTexture, destTexture);
  }

  private void OnValidate() => this.ChangeFilters();

  private void Update()
  {
  }

  private void OnDisable()
  {
    if (!(bool) (Object) this.SCMaterial)
      return;
    Object.DestroyImmediate((Object) this.SCMaterial);
  }

  public enum filters
  {
    Normal,
    BlueLagoon,
    BlueMoon,
    RedWhite,
    NashVille,
    VintageYellow,
    GoldenPink,
    DarkPink,
    PopRocket,
    RedSoftLight,
    YellowSunSet,
    Walden,
    WhiteShine,
    Fluo,
    MarsSunRise,
    Amelie,
    BlueJeans,
    NightVision,
    BlueParadise,
    Blindness_Deuteranomaly,
    Blindness_Protanopia,
    Blindness_Protanomaly,
    Blindness_Deuteranopia,
    Blindness_Tritanomaly,
    Blindness_Achromatopsia,
    Blindness_Achromatomaly,
    Blindness_Tritanopia,
    BlackAndWhite_Blue,
    BlackAndWhite_Green,
    BlackAndWhite_Orange,
    BlackAndWhite_Red,
    BlackAndWhite_Yellow,
  }
}
