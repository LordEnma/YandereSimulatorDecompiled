using UnityEngine;

public class CameraFilterScript : MonoBehaviour
{
	public UILabel Watermark;

	private CameraFilterPack_3D_Anomaly Anomaly;

	private CameraFilterPack_3D_Binary Binary;

	private CameraFilterPack_3D_BlackHole BlackHole3D;

	private CameraFilterPack_3D_Computer Computer;

	private CameraFilterPack_3D_Distortion Distortion;

	private CameraFilterPack_3D_Fog_Smoke FogSmoke;

	private CameraFilterPack_3D_Ghost Ghost;

	private CameraFilterPack_3D_Inverse Inverse;

	private CameraFilterPack_3D_Matrix Matrix;

	private CameraFilterPack_3D_Mirror Mirror3D;

	private CameraFilterPack_3D_Myst Myst;

	private CameraFilterPack_3D_Scan_Scene ScanScene;

	private CameraFilterPack_3D_Shield Shield;

	private CameraFilterPack_3D_Snow Snow;

	private CameraFilterPack_AAA_Blood AAABlood;

	private CameraFilterPack_AAA_BloodOnScreen AAABloodOnScreen;

	private CameraFilterPack_AAA_Blood_Hit AAABloodHit;

	private CameraFilterPack_AAA_Blood_Plus AAABloodPlus;

	private CameraFilterPack_AAA_SuperComputer SuperComputer;

	private CameraFilterPack_AAA_SuperHexagon SuperHexagon;

	private CameraFilterPack_AAA_WaterDrop WaterDrop;

	private CameraFilterPack_AAA_WaterDropPro WaterDropPro;

	private CameraFilterPack_Alien_Vision AlienVision;

	private CameraFilterPack_Antialiasing_FXAA FXAA;

	private CameraFilterPack_Atmosphere_Fog Fog;

	private CameraFilterPack_Atmosphere_Rain Rain;

	private CameraFilterPack_Atmosphere_Rain_Pro RainPro;

	private CameraFilterPack_Atmosphere_Rain_Pro_3D RainPro3D;

	private CameraFilterPack_Atmosphere_Snow_8bits Snow8bits;

	private CameraFilterPack_Blend2Camera_Blend Blend;

	private CameraFilterPack_Blend2Camera_BlueScreen BlueScreen;

	private CameraFilterPack_Blend2Camera_Color Color;

	private CameraFilterPack_Blend2Camera_ColorBurn ColorBurn;

	private CameraFilterPack_Blend2Camera_ColorDodge ColorDodge;

	private CameraFilterPack_Blend2Camera_ColorKey ColorKey;

	private CameraFilterPack_Blend2Camera_Darken Darken;

	private CameraFilterPack_Blend2Camera_DarkerColor DarkerColor;

	private CameraFilterPack_Blend2Camera_Difference Difference;

	private CameraFilterPack_Blend2Camera_Divide Divide;

	private CameraFilterPack_Blend2Camera_Exclusion Exclusion;

	private CameraFilterPack_Blend2Camera_GreenScreen GreenScreen;

	private CameraFilterPack_Blend2Camera_HardLight HardLight;

	private CameraFilterPack_Blend2Camera_HardMix HardMix;

	private CameraFilterPack_Blend2Camera_Hue Blend2CameraHue;

	private CameraFilterPack_Blend2Camera_Lighten Lighten;

	private CameraFilterPack_Blend2Camera_LighterColor LighterColor;

	private CameraFilterPack_Blend2Camera_LinearBurn LinearBurn;

	private CameraFilterPack_Blend2Camera_LinearDodge LinearDodge;

	private CameraFilterPack_Blend2Camera_LinearLight LinearLight;

	private CameraFilterPack_Blend2Camera_Luminosity Luminosity;

	private CameraFilterPack_Blend2Camera_Multiply Multiply;

	private CameraFilterPack_Blend2Camera_Overlay Overlay;

	private CameraFilterPack_Blend2Camera_PhotoshopFilters PhotoshopFilters;

	private CameraFilterPack_Blend2Camera_PinLight PinLight;

	private CameraFilterPack_Blend2Camera_Saturation Saturation;

	private CameraFilterPack_Blend2Camera_Screen Screen;

	private CameraFilterPack_Blend2Camera_SoftLight SoftLight;

	private CameraFilterPack_Blend2Camera_SplitScreen SplitScreen;

	private CameraFilterPack_Blend2Camera_SplitScreen3D SplitScreen3D;

	private CameraFilterPack_Blend2Camera_Subtract Subtract;

	private CameraFilterPack_Blend2Camera_VividLight VividLight;

	private CameraFilterPack_Blizzard Blizzard;

	private CameraFilterPack_Blur_Bloom Bloom;

	private CameraFilterPack_Blur_BlurHole BlurHole;

	private CameraFilterPack_Blur_Blurry Blurry;

	private CameraFilterPack_Blur_Dithering2x2 Dithering2x2;

	private CameraFilterPack_Blur_DitherOffset DitherOffset;

	private CameraFilterPack_Blur_Focus Focus;

	private CameraFilterPack_Blur_GaussianBlur GaussianBlur;

	private CameraFilterPack_Blur_Movie Movie;

	private CameraFilterPack_Blur_Noise BlurNoise;

	private CameraFilterPack_Blur_Radial Radial;

	private CameraFilterPack_Blur_Radial_Fast RadialFast;

	private CameraFilterPack_Blur_Regular Regular;

	private CameraFilterPack_Blur_Steam Steam;

	private CameraFilterPack_Blur_Tilt_Shift TiltShift;

	private CameraFilterPack_Blur_Tilt_Shift_Hole TiltShiftHole;

	private CameraFilterPack_Blur_Tilt_Shift_V TiltShiftV;

	private CameraFilterPack_Broken_Screen BrokenScreen;

	private CameraFilterPack_Broken_Simple BrokenSimple;

	private CameraFilterPack_Broken_Spliter Spliter;

	private CameraFilterPack_Classic_ThermalVision ThermalVision;

	private CameraFilterPack_Colors_Adjust_ColorRGB AdjustColorRGB;

	private CameraFilterPack_Colors_Adjust_FullColors AdjustFullColors;

	private CameraFilterPack_Colors_Adjust_PreFilters AdjustPreFilters;

	private CameraFilterPack_Colors_BleachBypass BleachBypass;

	private CameraFilterPack_Colors_Brightness Brightness;

	private CameraFilterPack_Colors_DarkColor DarkColor;

	private CameraFilterPack_Colors_HSV HSV;

	private CameraFilterPack_Colors_HUE_Rotate HUERotate;

	private CameraFilterPack_Colors_NewPosterize NewPosterize;

	private CameraFilterPack_Colors_RgbClamp RgbClamp;

	private CameraFilterPack_Colors_Threshold Threshold;

	private CameraFilterPack_Color_Adjust_Levels AdjustLevels;

	private CameraFilterPack_Color_BrightContrastSaturation BrightContrastSaturation;

	private CameraFilterPack_Color_Chromatic_Aberration ChromaticAberration;

	private CameraFilterPack_Color_Chromatic_Plus ChromaticPlus;

	private CameraFilterPack_Color_Contrast Contrast;

	private CameraFilterPack_Color_GrayScale GrayScale;

	private CameraFilterPack_Color_Invert Invert;

	private CameraFilterPack_Color_Noise ColorNoise;

	private CameraFilterPack_Color_RGB ColorRGB;

	private CameraFilterPack_Color_Sepia Sepia;

	private CameraFilterPack_Color_Switching Switching;

	private CameraFilterPack_Color_YUV YUV;

	private CameraFilterPack_Convert_Normal Normal;

	private CameraFilterPack_Distortion_Aspiration Aspiration;

	private CameraFilterPack_Distortion_BigFace BigFace;

	private CameraFilterPack_Distortion_BlackHole BlackHole;

	private CameraFilterPack_Distortion_Dissipation Dissipation;

	private CameraFilterPack_Distortion_Dream Dream;

	private CameraFilterPack_Distortion_Dream2 Dream2;

	private CameraFilterPack_Distortion_FishEye FishEye;

	private CameraFilterPack_Distortion_Flag Flag;

	private CameraFilterPack_Distortion_Flush Flush;

	private CameraFilterPack_Distortion_Half_Sphere HalfSphere;

	private CameraFilterPack_Distortion_Heat Heat;

	private CameraFilterPack_Distortion_Lens Lens;

	private CameraFilterPack_Distortion_Noise DistortionNoise;

	private CameraFilterPack_Distortion_ShockWave ShockWave;

	private CameraFilterPack_Distortion_ShockWaveManual ShockWaveManual;

	private CameraFilterPack_Distortion_Twist Twist;

	private CameraFilterPack_Distortion_Twist_Square TwistSquare;

	private CameraFilterPack_Distortion_Water_Drop DistortionWaterDrop;

	private CameraFilterPack_Distortion_Wave_Horizontal WaveHorizontal;

	private CameraFilterPack_Drawing_BluePrint BluePrint;

	private CameraFilterPack_Drawing_CellShading CellShading;

	private CameraFilterPack_Drawing_CellShading2 CellShading2;

	private CameraFilterPack_Drawing_Comics Comics;

	private CameraFilterPack_Drawing_Crosshatch Crosshatch;

	private CameraFilterPack_Drawing_Curve Curve;

	private CameraFilterPack_Drawing_EnhancedComics EnhancedComics;

	private CameraFilterPack_Drawing_Halftone Halftone;

	private CameraFilterPack_Drawing_Laplacian Laplacian;

	private CameraFilterPack_Drawing_Lines Lines;

	private CameraFilterPack_Drawing_Manga Manga;

	private CameraFilterPack_Drawing_Manga2 Manga2;

	private CameraFilterPack_Drawing_Manga3 Manga3;

	private CameraFilterPack_Drawing_Manga4 Manga4;

	private CameraFilterPack_Drawing_Manga5 Manga5;

	private CameraFilterPack_Drawing_Manga_Color MangaColor;

	private CameraFilterPack_Drawing_Manga_Flash MangaFlash;

	private CameraFilterPack_Drawing_Manga_FlashWhite MangaFlashWhite;

	private CameraFilterPack_Drawing_Manga_Flash_Color MangaFlashColor;

	private CameraFilterPack_Drawing_NewCellShading NewCellShading;

	private CameraFilterPack_Drawing_Paper Paper;

	private CameraFilterPack_Drawing_Paper2 Paper2;

	private CameraFilterPack_Drawing_Paper3 Paper3;

	private CameraFilterPack_Drawing_Toon Toon;

	private CameraFilterPack_Edge_BlackLine BlackLine;

	private CameraFilterPack_Edge_Edge_filter Edgefilter;

	private CameraFilterPack_Edge_Golden Golden;

	private CameraFilterPack_Edge_Neon Neon;

	private CameraFilterPack_Edge_Sigmoid Sigmoid;

	private CameraFilterPack_Edge_Sobel Sobel;

	private CameraFilterPack_EXTRA_Rotation Rotation;

	private CameraFilterPack_EXTRA_SHOWFPS SHOWFPS;

	private CameraFilterPack_EyesVision_1 EyesVision1;

	private CameraFilterPack_EyesVision_2 EyesVision2;

	private CameraFilterPack_Film_ColorPerfection ColorPerfection;

	private CameraFilterPack_Film_Grain Grain;

	private CameraFilterPack_Fly_Vision FlyVision;

	private CameraFilterPack_FX_8bits FX8bits;

	private CameraFilterPack_FX_8bits_gb FX8bitsgb;

	private CameraFilterPack_FX_Ascii Ascii;

	private CameraFilterPack_FX_DarkMatter DarkMatter;

	private CameraFilterPack_FX_DigitalMatrix DigitalMatrix;

	private CameraFilterPack_FX_DigitalMatrixDistortion DigitalMatrixDistortion;

	private CameraFilterPack_FX_Dot_Circle DotCircle;

	private CameraFilterPack_FX_Drunk Drunk;

	private CameraFilterPack_FX_Drunk2 Drunk2;

	private CameraFilterPack_FX_EarthQuake EarthQuake;

	private CameraFilterPack_FX_Funk Funk;

	private CameraFilterPack_FX_Glitch1 Glitch1;

	private CameraFilterPack_FX_Glitch2 Glitch2;

	private CameraFilterPack_FX_Glitch3 Glitch3;

	private CameraFilterPack_FX_Grid Grid;

	private CameraFilterPack_FX_Hexagon Hexagon;

	private CameraFilterPack_FX_Hexagon_Black HexagonBlack;

	private CameraFilterPack_FX_Hypno Hypno;

	private CameraFilterPack_FX_InverChromiLum InverChromiLum;

	private CameraFilterPack_FX_Mirror FXMirror;

	private CameraFilterPack_FX_Plasma FXPlasma;

	private CameraFilterPack_FX_Psycho FXPsycho;

	private CameraFilterPack_FX_Scan Scan;

	private CameraFilterPack_FX_Screens Screens;

	private CameraFilterPack_FX_Spot Spot;

	private CameraFilterPack_FX_superDot superDot;

	private CameraFilterPack_FX_ZebraColor ZebraColor;

	private CameraFilterPack_Glasses_On GlassesOn;

	private CameraFilterPack_Glasses_On_2 GlassesOn2;

	private CameraFilterPack_Glasses_On_3 GlassesOn3;

	private CameraFilterPack_Glasses_On_4 GlassesOn4;

	private CameraFilterPack_Glasses_On_5 GlassesOn5;

	private CameraFilterPack_Glasses_On_6 GlassesOn6;

	private CameraFilterPack_Glitch_Mozaic Mozaic;

	private CameraFilterPack_Glow_Glow Glow;

	private CameraFilterPack_Glow_Glow_Color GlowColor;

	private CameraFilterPack_Gradients_Ansi Ansi;

	private CameraFilterPack_Gradients_Desert Desert;

	private CameraFilterPack_Gradients_ElectricGradient ElectricGradient;

	private CameraFilterPack_Gradients_FireGradient FireGradient;

	private CameraFilterPack_Gradients_Hue GradientsHue;

	private CameraFilterPack_Gradients_NeonGradient NeonGradient;

	private CameraFilterPack_Gradients_Rainbow GradientsRainbow;

	private CameraFilterPack_Gradients_Stripe Stripe;

	private CameraFilterPack_Gradients_Tech Tech;

	private CameraFilterPack_Gradients_Therma Therma;

	private CameraFilterPack_Light_Rainbow LightRainbow;

	private CameraFilterPack_Light_Rainbow2 LightRainbow2;

	private CameraFilterPack_Light_Water Water;

	private CameraFilterPack_Light_Water2 Water2;

	private CameraFilterPack_Lut_2_Lut Lut;

	private CameraFilterPack_Lut_2_Lut_Extra LutExtra;

	private CameraFilterPack_Lut_Mask Mask;

	private CameraFilterPack_Lut_PlayWith PlayWith;

	private CameraFilterPack_Lut_Plus Plus;

	private CameraFilterPack_Lut_Simple LutSimple;

	private CameraFilterPack_Lut_TestMode TestMode;

	private CameraFilterPack_NewGlitch1 NewGlitch1;

	private CameraFilterPack_NewGlitch2 NewGlitch2;

	private CameraFilterPack_NewGlitch3 NewGlitch3;

	private CameraFilterPack_NewGlitch4 NewGlitch4;

	private CameraFilterPack_NewGlitch5 NewGlitch5;

	private CameraFilterPack_NewGlitch6 NewGlitch6;

	private CameraFilterPack_NewGlitch7 NewGlitch7;

	private CameraFilterPack_NightVisionFX NightVisionFX;

	private CameraFilterPack_NightVision_4 NightVision4;

	private CameraFilterPack_Noise_TV TV;

	private CameraFilterPack_Noise_TV_2 TV2;

	private CameraFilterPack_Noise_TV_3 TV3;

	private CameraFilterPack_Oculus_NightVision1 NightVision1;

	private CameraFilterPack_Oculus_NightVision2 NightVision2;

	private CameraFilterPack_Oculus_NightVision3 NightVision3;

	private CameraFilterPack_Oculus_NightVision5 NightVision5;

	private CameraFilterPack_Oculus_ThermaVision ThermaVision;

	private CameraFilterPack_OldFilm_Cutting1 Cutting1;

	private CameraFilterPack_OldFilm_Cutting2 Cutting2;

	private CameraFilterPack_Pixelisation_DeepOilPaintHQ DeepOilPaintHQ;

	private CameraFilterPack_Pixelisation_Dot Dot;

	private CameraFilterPack_Pixelisation_OilPaint OilPaint;

	private CameraFilterPack_Pixelisation_OilPaintHQ OilPaintHQ;

	private CameraFilterPack_Pixelisation_Sweater Sweater;

	private CameraFilterPack_Pixel_Pixelisation Pixelisation;

	private CameraFilterPack_Rain_RainFX RainFX;

	private CameraFilterPack_Real_VHS RealVHS;

	private CameraFilterPack_Retro_Loading Loading;

	private CameraFilterPack_Sharpen_Sharpen Sharpen;

	private CameraFilterPack_Special_Bubble Bubble;

	private CameraFilterPack_TV_50 TV50;

	private CameraFilterPack_TV_80 TV80;

	private CameraFilterPack_TV_ARCADE ARCADE;

	private CameraFilterPack_TV_ARCADE_2 ARCADE2;

	private CameraFilterPack_TV_ARCADE_Fast ARCADEFast;

	private CameraFilterPack_TV_Artefact Artefact;

	private CameraFilterPack_TV_BrokenGlass BrokenGlass;

	private CameraFilterPack_TV_BrokenGlass2 BrokenGlass2;

	private CameraFilterPack_TV_Chromatical Chromatical;

	private CameraFilterPack_TV_Chromatical2 Chromatical2;

	private CameraFilterPack_TV_CompressionFX CompressionFX;

	private CameraFilterPack_TV_Distorted Distorted;

	private CameraFilterPack_TV_Horror Horror;

	private CameraFilterPack_TV_LED LED;

	private CameraFilterPack_TV_MovieNoise MovieNoise;

	private CameraFilterPack_TV_Noise TVNoise;

	private CameraFilterPack_TV_Old Old;

	private CameraFilterPack_TV_Old_Movie OldMovie;

	private CameraFilterPack_TV_Old_Movie_2 OldMovie2;

	private CameraFilterPack_TV_PlanetMars PlanetMars;

	private CameraFilterPack_TV_Posterize Posterize;

	private CameraFilterPack_TV_Rgb TVRgb;

	private CameraFilterPack_TV_Tiles Tiles;

	private CameraFilterPack_TV_Vcr Vcr;

	private CameraFilterPack_TV_VHS TVVHS;

	private CameraFilterPack_TV_VHS_Rewind VHSRewind;

	private CameraFilterPack_TV_Video3D Video3D;

	private CameraFilterPack_TV_Videoflip Videoflip;

	private CameraFilterPack_TV_Vignetting Vignetting;

	private CameraFilterPack_TV_Vintage Vintage;

	private CameraFilterPack_TV_WideScreenCircle WideScreenCircle;

	private CameraFilterPack_TV_WideScreenHorizontal WideScreenHorizontal;

	private CameraFilterPack_TV_WideScreenHV WideScreenHV;

	private CameraFilterPack_TV_WideScreenVertical WideScreenVertical;

	private CameraFilterPack_VHS_Tracking Tracking;

	private CameraFilterPack_Vision_Aura Aura;

	private CameraFilterPack_Vision_AuraDistortion AuraDistortion;

	private CameraFilterPack_Vision_Blood VisionBlood;

	private CameraFilterPack_Vision_Blood_Fast VisionBloodFast;

	private CameraFilterPack_Vision_Crystal Crystal;

	private CameraFilterPack_Vision_Drost Drost;

	private CameraFilterPack_Vision_Hell_Blood VisionHellBlood;

	private CameraFilterPack_Vision_Plasma VisionPlasma;

	private CameraFilterPack_Vision_Psycho VisionPsycho;

	private CameraFilterPack_Vision_Rainbow VisionRainbow;

	private CameraFilterPack_Vision_SniperScore SniperScore;

	private CameraFilterPack_Vision_Tunnel Tunnel;

	private CameraFilterPack_Vision_Warp Warp;

	private CameraFilterPack_Vision_Warp2 Warp2;

	public UILabel NameLabel;

	public float DisplayTimer;

	public float Speed;

	public int FilterMax;

	private int FilterID;

	public string[] FilterNames;

	public bool[] FilterSkips;

	private void Start()
	{
		Anomaly = base.gameObject.AddComponent<CameraFilterPack_3D_Anomaly>();
		Anomaly.enabled = false;
		Binary = base.gameObject.AddComponent<CameraFilterPack_3D_Binary>();
		Binary.enabled = false;
		BlackHole3D = base.gameObject.AddComponent<CameraFilterPack_3D_BlackHole>();
		BlackHole3D.enabled = false;
		Computer = base.gameObject.AddComponent<CameraFilterPack_3D_Computer>();
		Computer.enabled = false;
		Distortion = base.gameObject.AddComponent<CameraFilterPack_3D_Distortion>();
		Distortion.enabled = false;
		FogSmoke = base.gameObject.AddComponent<CameraFilterPack_3D_Fog_Smoke>();
		FogSmoke.enabled = false;
		Ghost = base.gameObject.AddComponent<CameraFilterPack_3D_Ghost>();
		Ghost.enabled = false;
		Inverse = base.gameObject.AddComponent<CameraFilterPack_3D_Inverse>();
		Inverse.enabled = false;
		Matrix = base.gameObject.AddComponent<CameraFilterPack_3D_Matrix>();
		Matrix.enabled = false;
		Mirror3D = base.gameObject.AddComponent<CameraFilterPack_3D_Mirror>();
		Mirror3D.enabled = false;
		Myst = base.gameObject.AddComponent<CameraFilterPack_3D_Myst>();
		Myst.enabled = false;
		ScanScene = base.gameObject.AddComponent<CameraFilterPack_3D_Scan_Scene>();
		ScanScene.enabled = false;
		Shield = base.gameObject.AddComponent<CameraFilterPack_3D_Shield>();
		Shield.enabled = false;
		Snow = base.gameObject.AddComponent<CameraFilterPack_3D_Snow>();
		Snow.enabled = false;
		AAABlood = base.gameObject.AddComponent<CameraFilterPack_AAA_Blood>();
		AAABlood.enabled = false;
		AAABloodOnScreen = base.gameObject.AddComponent<CameraFilterPack_AAA_BloodOnScreen>();
		AAABloodOnScreen.enabled = false;
		AAABloodHit = base.gameObject.AddComponent<CameraFilterPack_AAA_Blood_Hit>();
		AAABloodHit.enabled = false;
		AAABloodPlus = base.gameObject.AddComponent<CameraFilterPack_AAA_Blood_Plus>();
		AAABloodPlus.enabled = false;
		SuperComputer = base.gameObject.AddComponent<CameraFilterPack_AAA_SuperComputer>();
		SuperComputer.enabled = false;
		SuperHexagon = base.gameObject.AddComponent<CameraFilterPack_AAA_SuperHexagon>();
		SuperHexagon.enabled = false;
		WaterDrop = base.gameObject.AddComponent<CameraFilterPack_AAA_WaterDrop>();
		WaterDrop.enabled = false;
		WaterDropPro = base.gameObject.AddComponent<CameraFilterPack_AAA_WaterDropPro>();
		WaterDropPro.enabled = false;
		AlienVision = base.gameObject.AddComponent<CameraFilterPack_Alien_Vision>();
		AlienVision.enabled = false;
		FXAA = base.gameObject.AddComponent<CameraFilterPack_Antialiasing_FXAA>();
		FXAA.enabled = false;
		Fog = base.gameObject.AddComponent<CameraFilterPack_Atmosphere_Fog>();
		Fog.enabled = false;
		Rain = base.gameObject.AddComponent<CameraFilterPack_Atmosphere_Rain>();
		Rain.enabled = false;
		RainPro = base.gameObject.AddComponent<CameraFilterPack_Atmosphere_Rain_Pro>();
		RainPro.enabled = false;
		RainPro3D = base.gameObject.AddComponent<CameraFilterPack_Atmosphere_Rain_Pro_3D>();
		RainPro3D.enabled = false;
		Snow8bits = base.gameObject.AddComponent<CameraFilterPack_Atmosphere_Snow_8bits>();
		Snow8bits.enabled = false;
		Blend = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Blend>();
		Blend.enabled = false;
		BlueScreen = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_BlueScreen>();
		BlueScreen.enabled = false;
		Color = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Color>();
		Color.enabled = false;
		ColorBurn = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_ColorBurn>();
		ColorBurn.enabled = false;
		ColorDodge = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_ColorDodge>();
		ColorDodge.enabled = false;
		ColorKey = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_ColorKey>();
		ColorKey.enabled = false;
		Darken = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Darken>();
		Darken.enabled = false;
		DarkerColor = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_DarkerColor>();
		DarkerColor.enabled = false;
		Difference = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Difference>();
		Difference.enabled = false;
		Divide = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Divide>();
		Divide.enabled = false;
		Exclusion = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Exclusion>();
		Exclusion.enabled = false;
		GreenScreen = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_GreenScreen>();
		GreenScreen.enabled = false;
		HardLight = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_HardLight>();
		HardLight.enabled = false;
		HardMix = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_HardMix>();
		HardMix.enabled = false;
		Blend2CameraHue = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Hue>();
		Blend2CameraHue.enabled = false;
		Lighten = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Lighten>();
		Lighten.enabled = false;
		LighterColor = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_LighterColor>();
		LighterColor.enabled = false;
		LinearBurn = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_LinearBurn>();
		LinearBurn.enabled = false;
		LinearDodge = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_LinearDodge>();
		LinearDodge.enabled = false;
		LinearLight = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_LinearLight>();
		LinearLight.enabled = false;
		Luminosity = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Luminosity>();
		Luminosity.enabled = false;
		Multiply = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Multiply>();
		Multiply.enabled = false;
		Overlay = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Overlay>();
		Overlay.enabled = false;
		PhotoshopFilters = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_PhotoshopFilters>();
		PhotoshopFilters.enabled = false;
		PinLight = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_PinLight>();
		PinLight.enabled = false;
		Saturation = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Saturation>();
		Saturation.enabled = false;
		Screen = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Screen>();
		Screen.enabled = false;
		SoftLight = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_SoftLight>();
		SoftLight.enabled = false;
		SplitScreen = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_SplitScreen>();
		SplitScreen.enabled = false;
		SplitScreen3D = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_SplitScreen3D>();
		SplitScreen3D.enabled = false;
		Subtract = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_Subtract>();
		Subtract.enabled = false;
		VividLight = base.gameObject.AddComponent<CameraFilterPack_Blend2Camera_VividLight>();
		VividLight.enabled = false;
		Blizzard = base.gameObject.AddComponent<CameraFilterPack_Blizzard>();
		Blizzard.enabled = false;
		Bloom = base.gameObject.AddComponent<CameraFilterPack_Blur_Bloom>();
		Bloom.enabled = false;
		BlurHole = base.gameObject.AddComponent<CameraFilterPack_Blur_BlurHole>();
		BlurHole.enabled = false;
		Blurry = base.gameObject.AddComponent<CameraFilterPack_Blur_Blurry>();
		Blurry.enabled = false;
		Dithering2x2 = base.gameObject.AddComponent<CameraFilterPack_Blur_Dithering2x2>();
		Dithering2x2.enabled = false;
		DitherOffset = base.gameObject.AddComponent<CameraFilterPack_Blur_DitherOffset>();
		DitherOffset.enabled = false;
		Focus = base.gameObject.AddComponent<CameraFilterPack_Blur_Focus>();
		Focus.enabled = false;
		GaussianBlur = base.gameObject.AddComponent<CameraFilterPack_Blur_GaussianBlur>();
		GaussianBlur.enabled = false;
		Movie = base.gameObject.AddComponent<CameraFilterPack_Blur_Movie>();
		Movie.enabled = false;
		BlurNoise = base.gameObject.AddComponent<CameraFilterPack_Blur_Noise>();
		BlurNoise.enabled = false;
		Radial = base.gameObject.AddComponent<CameraFilterPack_Blur_Radial>();
		Radial.enabled = false;
		RadialFast = base.gameObject.AddComponent<CameraFilterPack_Blur_Radial_Fast>();
		RadialFast.enabled = false;
		Regular = base.gameObject.AddComponent<CameraFilterPack_Blur_Regular>();
		Regular.enabled = false;
		Steam = base.gameObject.AddComponent<CameraFilterPack_Blur_Steam>();
		Steam.enabled = false;
		TiltShift = base.gameObject.AddComponent<CameraFilterPack_Blur_Tilt_Shift>();
		TiltShift.enabled = false;
		TiltShiftHole = base.gameObject.AddComponent<CameraFilterPack_Blur_Tilt_Shift_Hole>();
		TiltShiftHole.enabled = false;
		TiltShiftV = base.gameObject.AddComponent<CameraFilterPack_Blur_Tilt_Shift_V>();
		TiltShiftV.enabled = false;
		BrokenScreen = base.gameObject.AddComponent<CameraFilterPack_Broken_Screen>();
		BrokenScreen.enabled = false;
		BrokenSimple = base.gameObject.AddComponent<CameraFilterPack_Broken_Simple>();
		BrokenSimple.enabled = false;
		Spliter = base.gameObject.AddComponent<CameraFilterPack_Broken_Spliter>();
		Spliter.enabled = false;
		ThermalVision = base.gameObject.AddComponent<CameraFilterPack_Classic_ThermalVision>();
		ThermalVision.enabled = false;
		AdjustColorRGB = base.gameObject.AddComponent<CameraFilterPack_Colors_Adjust_ColorRGB>();
		AdjustColorRGB.enabled = false;
		AdjustFullColors = base.gameObject.AddComponent<CameraFilterPack_Colors_Adjust_FullColors>();
		AdjustFullColors.enabled = false;
		AdjustPreFilters = base.gameObject.AddComponent<CameraFilterPack_Colors_Adjust_PreFilters>();
		AdjustPreFilters.enabled = false;
		BleachBypass = base.gameObject.AddComponent<CameraFilterPack_Colors_BleachBypass>();
		BleachBypass.enabled = false;
		Brightness = base.gameObject.AddComponent<CameraFilterPack_Colors_Brightness>();
		Brightness.enabled = false;
		DarkColor = base.gameObject.AddComponent<CameraFilterPack_Colors_DarkColor>();
		DarkColor.enabled = false;
		HSV = base.gameObject.AddComponent<CameraFilterPack_Colors_HSV>();
		HSV.enabled = false;
		HUERotate = base.gameObject.AddComponent<CameraFilterPack_Colors_HUE_Rotate>();
		HUERotate.enabled = false;
		NewPosterize = base.gameObject.AddComponent<CameraFilterPack_Colors_NewPosterize>();
		NewPosterize.enabled = false;
		RgbClamp = base.gameObject.AddComponent<CameraFilterPack_Colors_RgbClamp>();
		RgbClamp.enabled = false;
		Threshold = base.gameObject.AddComponent<CameraFilterPack_Colors_Threshold>();
		Threshold.enabled = false;
		AdjustLevels = base.gameObject.AddComponent<CameraFilterPack_Color_Adjust_Levels>();
		AdjustLevels.enabled = false;
		BrightContrastSaturation = base.gameObject.AddComponent<CameraFilterPack_Color_BrightContrastSaturation>();
		BrightContrastSaturation.enabled = false;
		ChromaticAberration = base.gameObject.AddComponent<CameraFilterPack_Color_Chromatic_Aberration>();
		ChromaticAberration.enabled = false;
		ChromaticPlus = base.gameObject.AddComponent<CameraFilterPack_Color_Chromatic_Plus>();
		ChromaticPlus.enabled = false;
		Contrast = base.gameObject.AddComponent<CameraFilterPack_Color_Contrast>();
		Contrast.enabled = false;
		GrayScale = base.gameObject.AddComponent<CameraFilterPack_Color_GrayScale>();
		GrayScale.enabled = false;
		Invert = base.gameObject.AddComponent<CameraFilterPack_Color_Invert>();
		Invert.enabled = false;
		ColorNoise = base.gameObject.AddComponent<CameraFilterPack_Color_Noise>();
		ColorNoise.enabled = false;
		ColorRGB = base.gameObject.AddComponent<CameraFilterPack_Color_RGB>();
		ColorRGB.enabled = false;
		Sepia = base.gameObject.AddComponent<CameraFilterPack_Color_Sepia>();
		Sepia.enabled = false;
		Switching = base.gameObject.AddComponent<CameraFilterPack_Color_Switching>();
		Switching.enabled = false;
		YUV = base.gameObject.AddComponent<CameraFilterPack_Color_YUV>();
		YUV.enabled = false;
		Normal = base.gameObject.AddComponent<CameraFilterPack_Convert_Normal>();
		Normal.enabled = false;
		Aspiration = base.gameObject.AddComponent<CameraFilterPack_Distortion_Aspiration>();
		Aspiration.enabled = false;
		BigFace = base.gameObject.AddComponent<CameraFilterPack_Distortion_BigFace>();
		BigFace.enabled = false;
		BlackHole = base.gameObject.AddComponent<CameraFilterPack_Distortion_BlackHole>();
		BlackHole.enabled = false;
		Dissipation = base.gameObject.AddComponent<CameraFilterPack_Distortion_Dissipation>();
		Dissipation.enabled = false;
		Dream = base.gameObject.AddComponent<CameraFilterPack_Distortion_Dream>();
		Dream.enabled = false;
		Dream2 = base.gameObject.AddComponent<CameraFilterPack_Distortion_Dream2>();
		Dream2.enabled = false;
		FishEye = base.gameObject.AddComponent<CameraFilterPack_Distortion_FishEye>();
		FishEye.enabled = false;
		Flag = base.gameObject.AddComponent<CameraFilterPack_Distortion_Flag>();
		Flag.enabled = false;
		Flush = base.gameObject.AddComponent<CameraFilterPack_Distortion_Flush>();
		Flush.enabled = false;
		HalfSphere = base.gameObject.AddComponent<CameraFilterPack_Distortion_Half_Sphere>();
		HalfSphere.enabled = false;
		Heat = base.gameObject.AddComponent<CameraFilterPack_Distortion_Heat>();
		Heat.enabled = false;
		Lens = base.gameObject.AddComponent<CameraFilterPack_Distortion_Lens>();
		Lens.enabled = false;
		DistortionNoise = base.gameObject.AddComponent<CameraFilterPack_Distortion_Noise>();
		DistortionNoise.enabled = false;
		ShockWave = base.gameObject.AddComponent<CameraFilterPack_Distortion_ShockWave>();
		ShockWave.enabled = false;
		ShockWaveManual = base.gameObject.AddComponent<CameraFilterPack_Distortion_ShockWaveManual>();
		ShockWaveManual.enabled = false;
		Twist = base.gameObject.AddComponent<CameraFilterPack_Distortion_Twist>();
		Twist.enabled = false;
		TwistSquare = base.gameObject.AddComponent<CameraFilterPack_Distortion_Twist_Square>();
		TwistSquare.enabled = false;
		DistortionWaterDrop = base.gameObject.AddComponent<CameraFilterPack_Distortion_Water_Drop>();
		DistortionWaterDrop.enabled = false;
		WaveHorizontal = base.gameObject.AddComponent<CameraFilterPack_Distortion_Wave_Horizontal>();
		WaveHorizontal.enabled = false;
		BluePrint = base.gameObject.AddComponent<CameraFilterPack_Drawing_BluePrint>();
		BluePrint.enabled = false;
		CellShading = base.gameObject.AddComponent<CameraFilterPack_Drawing_CellShading>();
		CellShading.enabled = false;
		CellShading2 = base.gameObject.AddComponent<CameraFilterPack_Drawing_CellShading2>();
		CellShading2.enabled = false;
		Comics = base.gameObject.AddComponent<CameraFilterPack_Drawing_Comics>();
		Comics.enabled = false;
		Crosshatch = base.gameObject.AddComponent<CameraFilterPack_Drawing_Crosshatch>();
		Crosshatch.enabled = false;
		Curve = base.gameObject.AddComponent<CameraFilterPack_Drawing_Curve>();
		Curve.enabled = false;
		EnhancedComics = base.gameObject.AddComponent<CameraFilterPack_Drawing_EnhancedComics>();
		EnhancedComics.enabled = false;
		Halftone = base.gameObject.AddComponent<CameraFilterPack_Drawing_Halftone>();
		Halftone.enabled = false;
		Laplacian = base.gameObject.AddComponent<CameraFilterPack_Drawing_Laplacian>();
		Laplacian.enabled = false;
		Lines = base.gameObject.AddComponent<CameraFilterPack_Drawing_Lines>();
		Lines.enabled = false;
		Manga = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga>();
		Manga.enabled = false;
		Manga2 = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga2>();
		Manga2.enabled = false;
		Manga3 = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga3>();
		Manga3.enabled = false;
		Manga4 = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga4>();
		Manga4.enabled = false;
		Manga5 = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga5>();
		Manga5.enabled = false;
		MangaColor = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga_Color>();
		MangaColor.enabled = false;
		MangaFlash = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga_Flash>();
		MangaFlash.enabled = false;
		MangaFlashWhite = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga_FlashWhite>();
		MangaFlashWhite.enabled = false;
		MangaFlashColor = base.gameObject.AddComponent<CameraFilterPack_Drawing_Manga_Flash_Color>();
		MangaFlashColor.enabled = false;
		NewCellShading = base.gameObject.AddComponent<CameraFilterPack_Drawing_NewCellShading>();
		NewCellShading.enabled = false;
		Paper = base.gameObject.AddComponent<CameraFilterPack_Drawing_Paper>();
		Paper.enabled = false;
		Paper2 = base.gameObject.AddComponent<CameraFilterPack_Drawing_Paper2>();
		Paper2.enabled = false;
		Paper3 = base.gameObject.AddComponent<CameraFilterPack_Drawing_Paper3>();
		Paper3.enabled = false;
		Toon = base.gameObject.AddComponent<CameraFilterPack_Drawing_Toon>();
		Toon.enabled = false;
		BlackLine = base.gameObject.AddComponent<CameraFilterPack_Edge_BlackLine>();
		BlackLine.enabled = false;
		Edgefilter = base.gameObject.AddComponent<CameraFilterPack_Edge_Edge_filter>();
		Edgefilter.enabled = false;
		Golden = base.gameObject.AddComponent<CameraFilterPack_Edge_Golden>();
		Golden.enabled = false;
		Neon = base.gameObject.AddComponent<CameraFilterPack_Edge_Neon>();
		Neon.enabled = false;
		Sigmoid = base.gameObject.AddComponent<CameraFilterPack_Edge_Sigmoid>();
		Sigmoid.enabled = false;
		Sobel = base.gameObject.AddComponent<CameraFilterPack_Edge_Sobel>();
		Sobel.enabled = false;
		Rotation = base.gameObject.AddComponent<CameraFilterPack_EXTRA_Rotation>();
		Rotation.enabled = false;
		SHOWFPS = base.gameObject.AddComponent<CameraFilterPack_EXTRA_SHOWFPS>();
		SHOWFPS.enabled = false;
		EyesVision1 = base.gameObject.AddComponent<CameraFilterPack_EyesVision_1>();
		EyesVision1.enabled = false;
		EyesVision2 = base.gameObject.AddComponent<CameraFilterPack_EyesVision_2>();
		EyesVision2.enabled = false;
		ColorPerfection = base.gameObject.AddComponent<CameraFilterPack_Film_ColorPerfection>();
		ColorPerfection.enabled = false;
		Grain = base.gameObject.AddComponent<CameraFilterPack_Film_Grain>();
		Grain.enabled = false;
		FlyVision = base.gameObject.AddComponent<CameraFilterPack_Fly_Vision>();
		FlyVision.enabled = false;
		FX8bits = base.gameObject.AddComponent<CameraFilterPack_FX_8bits>();
		FX8bits.enabled = false;
		FX8bitsgb = base.gameObject.AddComponent<CameraFilterPack_FX_8bits_gb>();
		FX8bitsgb.enabled = false;
		Ascii = base.gameObject.AddComponent<CameraFilterPack_FX_Ascii>();
		Ascii.enabled = false;
		DarkMatter = base.gameObject.AddComponent<CameraFilterPack_FX_DarkMatter>();
		DarkMatter.enabled = false;
		DigitalMatrix = base.gameObject.AddComponent<CameraFilterPack_FX_DigitalMatrix>();
		DigitalMatrix.enabled = false;
		DigitalMatrixDistortion = base.gameObject.AddComponent<CameraFilterPack_FX_DigitalMatrixDistortion>();
		DigitalMatrixDistortion.enabled = false;
		DotCircle = base.gameObject.AddComponent<CameraFilterPack_FX_Dot_Circle>();
		DotCircle.enabled = false;
		Drunk = base.gameObject.AddComponent<CameraFilterPack_FX_Drunk>();
		Drunk.enabled = false;
		Drunk2 = base.gameObject.AddComponent<CameraFilterPack_FX_Drunk2>();
		Drunk2.enabled = false;
		EarthQuake = base.gameObject.AddComponent<CameraFilterPack_FX_EarthQuake>();
		EarthQuake.enabled = false;
		Funk = base.gameObject.AddComponent<CameraFilterPack_FX_Funk>();
		Funk.enabled = false;
		Glitch1 = base.gameObject.AddComponent<CameraFilterPack_FX_Glitch1>();
		Glitch1.enabled = false;
		Glitch2 = base.gameObject.AddComponent<CameraFilterPack_FX_Glitch2>();
		Glitch2.enabled = false;
		Glitch3 = base.gameObject.AddComponent<CameraFilterPack_FX_Glitch3>();
		Glitch3.enabled = false;
		Grid = base.gameObject.AddComponent<CameraFilterPack_FX_Grid>();
		Grid.enabled = false;
		Hexagon = base.gameObject.AddComponent<CameraFilterPack_FX_Hexagon>();
		Hexagon.enabled = false;
		HexagonBlack = base.gameObject.AddComponent<CameraFilterPack_FX_Hexagon_Black>();
		HexagonBlack.enabled = false;
		Hypno = base.gameObject.AddComponent<CameraFilterPack_FX_Hypno>();
		Hypno.enabled = false;
		InverChromiLum = base.gameObject.AddComponent<CameraFilterPack_FX_InverChromiLum>();
		InverChromiLum.enabled = false;
		FXMirror = base.gameObject.AddComponent<CameraFilterPack_FX_Mirror>();
		FXMirror.enabled = false;
		FXPlasma = base.gameObject.AddComponent<CameraFilterPack_FX_Plasma>();
		FXPlasma.enabled = false;
		FXPsycho = base.gameObject.AddComponent<CameraFilterPack_FX_Psycho>();
		FXPsycho.enabled = false;
		Scan = base.gameObject.AddComponent<CameraFilterPack_FX_Scan>();
		Scan.enabled = false;
		Screens = base.gameObject.AddComponent<CameraFilterPack_FX_Screens>();
		Screens.enabled = false;
		Spot = base.gameObject.AddComponent<CameraFilterPack_FX_Spot>();
		Spot.enabled = false;
		superDot = base.gameObject.AddComponent<CameraFilterPack_FX_superDot>();
		superDot.enabled = false;
		ZebraColor = base.gameObject.AddComponent<CameraFilterPack_FX_ZebraColor>();
		ZebraColor.enabled = false;
		GlassesOn = base.gameObject.AddComponent<CameraFilterPack_Glasses_On>();
		GlassesOn.enabled = false;
		GlassesOn2 = base.gameObject.AddComponent<CameraFilterPack_Glasses_On_2>();
		GlassesOn2.enabled = false;
		GlassesOn3 = base.gameObject.AddComponent<CameraFilterPack_Glasses_On_3>();
		GlassesOn3.enabled = false;
		GlassesOn4 = base.gameObject.AddComponent<CameraFilterPack_Glasses_On_4>();
		GlassesOn4.enabled = false;
		GlassesOn5 = base.gameObject.AddComponent<CameraFilterPack_Glasses_On_5>();
		GlassesOn5.enabled = false;
		GlassesOn6 = base.gameObject.AddComponent<CameraFilterPack_Glasses_On_6>();
		GlassesOn6.enabled = false;
		Mozaic = base.gameObject.AddComponent<CameraFilterPack_Glitch_Mozaic>();
		Mozaic.enabled = false;
		Glow = base.gameObject.AddComponent<CameraFilterPack_Glow_Glow>();
		Glow.enabled = false;
		GlowColor = base.gameObject.AddComponent<CameraFilterPack_Glow_Glow_Color>();
		GlowColor.enabled = false;
		Ansi = base.gameObject.AddComponent<CameraFilterPack_Gradients_Ansi>();
		Ansi.enabled = false;
		Desert = base.gameObject.AddComponent<CameraFilterPack_Gradients_Desert>();
		Desert.enabled = false;
		ElectricGradient = base.gameObject.AddComponent<CameraFilterPack_Gradients_ElectricGradient>();
		ElectricGradient.enabled = false;
		FireGradient = base.gameObject.AddComponent<CameraFilterPack_Gradients_FireGradient>();
		FireGradient.enabled = false;
		GradientsHue = base.gameObject.AddComponent<CameraFilterPack_Gradients_Hue>();
		GradientsHue.enabled = false;
		NeonGradient = base.gameObject.AddComponent<CameraFilterPack_Gradients_NeonGradient>();
		NeonGradient.enabled = false;
		GradientsRainbow = base.gameObject.AddComponent<CameraFilterPack_Gradients_Rainbow>();
		GradientsRainbow.enabled = false;
		Stripe = base.gameObject.AddComponent<CameraFilterPack_Gradients_Stripe>();
		Stripe.enabled = false;
		Tech = base.gameObject.AddComponent<CameraFilterPack_Gradients_Tech>();
		Tech.enabled = false;
		Therma = base.gameObject.AddComponent<CameraFilterPack_Gradients_Therma>();
		Therma.enabled = false;
		LightRainbow = base.gameObject.AddComponent<CameraFilterPack_Light_Rainbow>();
		LightRainbow.enabled = false;
		LightRainbow2 = base.gameObject.AddComponent<CameraFilterPack_Light_Rainbow2>();
		LightRainbow2.enabled = false;
		Water = base.gameObject.AddComponent<CameraFilterPack_Light_Water>();
		Water.enabled = false;
		Water2 = base.gameObject.AddComponent<CameraFilterPack_Light_Water2>();
		Water2.enabled = false;
		Lut = base.gameObject.AddComponent<CameraFilterPack_Lut_2_Lut>();
		Lut.enabled = false;
		LutExtra = base.gameObject.AddComponent<CameraFilterPack_Lut_2_Lut_Extra>();
		LutExtra.enabled = false;
		Mask = base.gameObject.AddComponent<CameraFilterPack_Lut_Mask>();
		Mask.enabled = false;
		PlayWith = base.gameObject.AddComponent<CameraFilterPack_Lut_PlayWith>();
		PlayWith.enabled = false;
		Plus = base.gameObject.AddComponent<CameraFilterPack_Lut_Plus>();
		Plus.enabled = false;
		LutSimple = base.gameObject.AddComponent<CameraFilterPack_Lut_Simple>();
		LutSimple.enabled = false;
		TestMode = base.gameObject.AddComponent<CameraFilterPack_Lut_TestMode>();
		TestMode.enabled = false;
		NewGlitch1 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch1>();
		NewGlitch1.enabled = false;
		NewGlitch2 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch2>();
		NewGlitch2.enabled = false;
		NewGlitch3 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch3>();
		NewGlitch3.enabled = false;
		NewGlitch4 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch4>();
		NewGlitch4.enabled = false;
		NewGlitch5 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch5>();
		NewGlitch5.enabled = false;
		NewGlitch6 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch6>();
		NewGlitch6.enabled = false;
		NewGlitch7 = base.gameObject.AddComponent<CameraFilterPack_NewGlitch7>();
		NewGlitch7.enabled = false;
		NightVisionFX = base.gameObject.AddComponent<CameraFilterPack_NightVisionFX>();
		NightVisionFX.enabled = false;
		NightVision4 = base.gameObject.AddComponent<CameraFilterPack_NightVision_4>();
		NightVision4.enabled = false;
		TV = base.gameObject.AddComponent<CameraFilterPack_Noise_TV>();
		TV.enabled = false;
		TV2 = base.gameObject.AddComponent<CameraFilterPack_Noise_TV_2>();
		TV2.enabled = false;
		TV3 = base.gameObject.AddComponent<CameraFilterPack_Noise_TV_3>();
		TV3.enabled = false;
		NightVision1 = base.gameObject.AddComponent<CameraFilterPack_Oculus_NightVision1>();
		NightVision1.enabled = false;
		NightVision2 = base.gameObject.AddComponent<CameraFilterPack_Oculus_NightVision2>();
		NightVision2.enabled = false;
		NightVision3 = base.gameObject.AddComponent<CameraFilterPack_Oculus_NightVision3>();
		NightVision3.enabled = false;
		NightVision5 = base.gameObject.AddComponent<CameraFilterPack_Oculus_NightVision5>();
		NightVision5.enabled = false;
		ThermaVision = base.gameObject.AddComponent<CameraFilterPack_Oculus_ThermaVision>();
		ThermaVision.enabled = false;
		Cutting1 = base.gameObject.AddComponent<CameraFilterPack_OldFilm_Cutting1>();
		Cutting1.enabled = false;
		Cutting2 = base.gameObject.AddComponent<CameraFilterPack_OldFilm_Cutting2>();
		Cutting2.enabled = false;
		DeepOilPaintHQ = base.gameObject.AddComponent<CameraFilterPack_Pixelisation_DeepOilPaintHQ>();
		DeepOilPaintHQ.enabled = false;
		Dot = base.gameObject.AddComponent<CameraFilterPack_Pixelisation_Dot>();
		Dot.enabled = false;
		OilPaint = base.gameObject.AddComponent<CameraFilterPack_Pixelisation_OilPaint>();
		OilPaint.enabled = false;
		OilPaintHQ = base.gameObject.AddComponent<CameraFilterPack_Pixelisation_OilPaintHQ>();
		OilPaintHQ.enabled = false;
		Sweater = base.gameObject.AddComponent<CameraFilterPack_Pixelisation_Sweater>();
		Sweater.enabled = false;
		Pixelisation = base.gameObject.AddComponent<CameraFilterPack_Pixel_Pixelisation>();
		Pixelisation.enabled = false;
		RainFX = base.gameObject.AddComponent<CameraFilterPack_Rain_RainFX>();
		RainFX.enabled = false;
		RealVHS = base.gameObject.AddComponent<CameraFilterPack_Real_VHS>();
		RealVHS.enabled = false;
		Loading = base.gameObject.AddComponent<CameraFilterPack_Retro_Loading>();
		Loading.enabled = false;
		Sharpen = base.gameObject.AddComponent<CameraFilterPack_Sharpen_Sharpen>();
		Sharpen.enabled = false;
		Bubble = base.gameObject.AddComponent<CameraFilterPack_Special_Bubble>();
		Bubble.enabled = false;
		TV50 = base.gameObject.AddComponent<CameraFilterPack_TV_50>();
		TV50.enabled = false;
		TV80 = base.gameObject.AddComponent<CameraFilterPack_TV_80>();
		TV80.enabled = false;
		ARCADE = base.gameObject.AddComponent<CameraFilterPack_TV_ARCADE>();
		ARCADE.enabled = false;
		ARCADE2 = base.gameObject.AddComponent<CameraFilterPack_TV_ARCADE_2>();
		ARCADE2.enabled = false;
		ARCADEFast = base.gameObject.AddComponent<CameraFilterPack_TV_ARCADE_Fast>();
		ARCADEFast.enabled = false;
		Artefact = base.gameObject.AddComponent<CameraFilterPack_TV_Artefact>();
		Artefact.enabled = false;
		BrokenGlass = base.gameObject.AddComponent<CameraFilterPack_TV_BrokenGlass>();
		BrokenGlass.enabled = false;
		BrokenGlass2 = base.gameObject.AddComponent<CameraFilterPack_TV_BrokenGlass2>();
		BrokenGlass2.enabled = false;
		Chromatical = base.gameObject.AddComponent<CameraFilterPack_TV_Chromatical>();
		Chromatical.enabled = false;
		Chromatical2 = base.gameObject.AddComponent<CameraFilterPack_TV_Chromatical2>();
		Chromatical2.enabled = false;
		CompressionFX = base.gameObject.AddComponent<CameraFilterPack_TV_CompressionFX>();
		CompressionFX.enabled = false;
		Distorted = base.gameObject.AddComponent<CameraFilterPack_TV_Distorted>();
		Distorted.enabled = false;
		Horror = base.gameObject.AddComponent<CameraFilterPack_TV_Horror>();
		Horror.enabled = false;
		LED = base.gameObject.AddComponent<CameraFilterPack_TV_LED>();
		LED.enabled = false;
		MovieNoise = base.gameObject.AddComponent<CameraFilterPack_TV_MovieNoise>();
		MovieNoise.enabled = false;
		TVNoise = base.gameObject.AddComponent<CameraFilterPack_TV_Noise>();
		TVNoise.enabled = false;
		Old = base.gameObject.AddComponent<CameraFilterPack_TV_Old>();
		Old.enabled = false;
		OldMovie = base.gameObject.AddComponent<CameraFilterPack_TV_Old_Movie>();
		OldMovie.enabled = false;
		OldMovie2 = base.gameObject.AddComponent<CameraFilterPack_TV_Old_Movie_2>();
		OldMovie2.enabled = false;
		PlanetMars = base.gameObject.AddComponent<CameraFilterPack_TV_PlanetMars>();
		PlanetMars.enabled = false;
		Posterize = base.gameObject.AddComponent<CameraFilterPack_TV_Posterize>();
		Posterize.enabled = false;
		TVRgb = base.gameObject.AddComponent<CameraFilterPack_TV_Rgb>();
		TVRgb.enabled = false;
		Tiles = base.gameObject.AddComponent<CameraFilterPack_TV_Tiles>();
		Tiles.enabled = false;
		Vcr = base.gameObject.AddComponent<CameraFilterPack_TV_Vcr>();
		Vcr.enabled = false;
		TVVHS = base.gameObject.AddComponent<CameraFilterPack_TV_VHS>();
		TVVHS.enabled = false;
		VHSRewind = base.gameObject.AddComponent<CameraFilterPack_TV_VHS_Rewind>();
		VHSRewind.enabled = false;
		Video3D = base.gameObject.AddComponent<CameraFilterPack_TV_Video3D>();
		Video3D.enabled = false;
		Videoflip = base.gameObject.AddComponent<CameraFilterPack_TV_Videoflip>();
		Videoflip.enabled = false;
		Vignetting = base.gameObject.AddComponent<CameraFilterPack_TV_Vignetting>();
		Vignetting.enabled = false;
		Vintage = base.gameObject.AddComponent<CameraFilterPack_TV_Vintage>();
		Vintage.enabled = false;
		WideScreenCircle = base.gameObject.AddComponent<CameraFilterPack_TV_WideScreenCircle>();
		WideScreenCircle.enabled = false;
		WideScreenHorizontal = base.gameObject.AddComponent<CameraFilterPack_TV_WideScreenHorizontal>();
		WideScreenHorizontal.enabled = false;
		WideScreenHV = base.gameObject.AddComponent<CameraFilterPack_TV_WideScreenHV>();
		WideScreenHV.enabled = false;
		WideScreenVertical = base.gameObject.AddComponent<CameraFilterPack_TV_WideScreenVertical>();
		WideScreenVertical.enabled = false;
		Tracking = base.gameObject.AddComponent<CameraFilterPack_VHS_Tracking>();
		Tracking.enabled = false;
		Aura = base.gameObject.AddComponent<CameraFilterPack_Vision_Aura>();
		Aura.enabled = false;
		AuraDistortion = base.gameObject.AddComponent<CameraFilterPack_Vision_AuraDistortion>();
		AuraDistortion.enabled = false;
		VisionBlood = base.gameObject.AddComponent<CameraFilterPack_Vision_Blood>();
		VisionBlood.enabled = false;
		VisionBloodFast = base.gameObject.AddComponent<CameraFilterPack_Vision_Blood_Fast>();
		VisionBloodFast.enabled = false;
		Crystal = base.gameObject.AddComponent<CameraFilterPack_Vision_Crystal>();
		Crystal.enabled = false;
		Drost = base.gameObject.AddComponent<CameraFilterPack_Vision_Drost>();
		Drost.enabled = false;
		VisionHellBlood = base.gameObject.AddComponent<CameraFilterPack_Vision_Hell_Blood>();
		VisionHellBlood.enabled = false;
		VisionPlasma = base.gameObject.AddComponent<CameraFilterPack_Vision_Plasma>();
		VisionPlasma.enabled = false;
		VisionPsycho = base.gameObject.AddComponent<CameraFilterPack_Vision_Psycho>();
		VisionPsycho.enabled = false;
		VisionRainbow = base.gameObject.AddComponent<CameraFilterPack_Vision_Rainbow>();
		VisionRainbow.enabled = false;
		SniperScore = base.gameObject.AddComponent<CameraFilterPack_Vision_SniperScore>();
		SniperScore.enabled = false;
		Tunnel = base.gameObject.AddComponent<CameraFilterPack_Vision_Tunnel>();
		Tunnel.enabled = false;
		Warp = base.gameObject.AddComponent<CameraFilterPack_Vision_Warp>();
		Warp.enabled = false;
		Warp2 = base.gameObject.AddComponent<CameraFilterPack_Vision_Warp2>();
		Warp2.enabled = false;
		ScanScene.AutoAnimatedNear = true;
		UpdateFilter();
		Watermark.text = "Use the 'z' and 'x' keys to change the current camera filter!";
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			if (Input.GetKeyDown("z"))
			{
				FilterID -= 10;
				UpdateFilter();
			}
			if (Input.GetKeyDown("x"))
			{
				FilterID += 10;
				UpdateFilter();
			}
		}
		else
		{
			if (Input.GetKeyDown("z"))
			{
				FilterID--;
				UpdateFilter();
			}
			if (Input.GetKeyDown("x"))
			{
				FilterID++;
				UpdateFilter();
			}
		}
		if (DisplayTimer < 2f)
		{
			DisplayTimer += Time.deltaTime;
			NameLabel.transform.localPosition = Vector3.Lerp(NameLabel.transform.localPosition, new Vector3(1245f, 0f, 0f), Time.deltaTime * 10f);
		}
		else
		{
			Speed += Time.deltaTime * 10f;
			NameLabel.transform.localPosition = Vector3.MoveTowards(NameLabel.transform.localPosition, Vector3.zero, Speed);
		}
	}

	private void UpdateFilter()
	{
		NameLabel.transform.localPosition = Vector3.zero;
		DisplayTimer = 0f;
		Speed = 0f;
		Anomaly.enabled = false;
		Binary.enabled = false;
		BlackHole3D.enabled = false;
		Computer.enabled = false;
		Distortion.enabled = false;
		FogSmoke.enabled = false;
		Ghost.enabled = false;
		Inverse.enabled = false;
		Matrix.enabled = false;
		Mirror3D.enabled = false;
		Myst.enabled = false;
		ScanScene.enabled = false;
		Shield.enabled = false;
		Snow.enabled = false;
		AAABlood.enabled = false;
		AAABloodOnScreen.enabled = false;
		AAABloodHit.enabled = false;
		AAABloodPlus.enabled = false;
		SuperComputer.enabled = false;
		SuperHexagon.enabled = false;
		WaterDrop.enabled = false;
		WaterDropPro.enabled = false;
		AlienVision.enabled = false;
		FXAA.enabled = false;
		Fog.enabled = false;
		Rain.enabled = false;
		RainPro.enabled = false;
		RainPro3D.enabled = false;
		Snow8bits.enabled = false;
		Blend.enabled = false;
		BlueScreen.enabled = false;
		Color.enabled = false;
		ColorBurn.enabled = false;
		ColorDodge.enabled = false;
		ColorKey.enabled = false;
		Darken.enabled = false;
		DarkerColor.enabled = false;
		Difference.enabled = false;
		Divide.enabled = false;
		Exclusion.enabled = false;
		GreenScreen.enabled = false;
		HardLight.enabled = false;
		HardMix.enabled = false;
		Blend2CameraHue.enabled = false;
		Lighten.enabled = false;
		LighterColor.enabled = false;
		LinearBurn.enabled = false;
		LinearDodge.enabled = false;
		LinearLight.enabled = false;
		Luminosity.enabled = false;
		Multiply.enabled = false;
		Overlay.enabled = false;
		PhotoshopFilters.enabled = false;
		PinLight.enabled = false;
		Saturation.enabled = false;
		Screen.enabled = false;
		SoftLight.enabled = false;
		SplitScreen.enabled = false;
		SplitScreen3D.enabled = false;
		Subtract.enabled = false;
		VividLight.enabled = false;
		Blizzard.enabled = false;
		Bloom.enabled = false;
		BlurHole.enabled = false;
		Blurry.enabled = false;
		Dithering2x2.enabled = false;
		DitherOffset.enabled = false;
		Focus.enabled = false;
		GaussianBlur.enabled = false;
		Movie.enabled = false;
		BlurNoise.enabled = false;
		Radial.enabled = false;
		RadialFast.enabled = false;
		Regular.enabled = false;
		Steam.enabled = false;
		TiltShift.enabled = false;
		TiltShiftHole.enabled = false;
		TiltShiftV.enabled = false;
		BrokenScreen.enabled = false;
		BrokenSimple.enabled = false;
		Spliter.enabled = false;
		ThermalVision.enabled = false;
		AdjustColorRGB.enabled = false;
		AdjustFullColors.enabled = false;
		AdjustPreFilters.enabled = false;
		BleachBypass.enabled = false;
		Brightness.enabled = false;
		DarkColor.enabled = false;
		HSV.enabled = false;
		HUERotate.enabled = false;
		NewPosterize.enabled = false;
		RgbClamp.enabled = false;
		Threshold.enabled = false;
		AdjustLevels.enabled = false;
		BrightContrastSaturation.enabled = false;
		ChromaticAberration.enabled = false;
		ChromaticPlus.enabled = false;
		Contrast.enabled = false;
		GrayScale.enabled = false;
		Invert.enabled = false;
		ColorNoise.enabled = false;
		ColorRGB.enabled = false;
		Sepia.enabled = false;
		Switching.enabled = false;
		YUV.enabled = false;
		Normal.enabled = false;
		Aspiration.enabled = false;
		BigFace.enabled = false;
		BlackHole.enabled = false;
		Dissipation.enabled = false;
		Dream.enabled = false;
		Dream2.enabled = false;
		FishEye.enabled = false;
		Flag.enabled = false;
		Flush.enabled = false;
		HalfSphere.enabled = false;
		Heat.enabled = false;
		Lens.enabled = false;
		DistortionNoise.enabled = false;
		ShockWave.enabled = false;
		ShockWaveManual.enabled = false;
		Twist.enabled = false;
		TwistSquare.enabled = false;
		DistortionWaterDrop.enabled = false;
		WaveHorizontal.enabled = false;
		BluePrint.enabled = false;
		CellShading.enabled = false;
		CellShading2.enabled = false;
		Comics.enabled = false;
		Crosshatch.enabled = false;
		Curve.enabled = false;
		EnhancedComics.enabled = false;
		Halftone.enabled = false;
		Laplacian.enabled = false;
		Lines.enabled = false;
		Manga.enabled = false;
		Manga2.enabled = false;
		Manga3.enabled = false;
		Manga4.enabled = false;
		Manga5.enabled = false;
		MangaColor.enabled = false;
		MangaFlash.enabled = false;
		MangaFlashWhite.enabled = false;
		MangaFlashColor.enabled = false;
		NewCellShading.enabled = false;
		Paper.enabled = false;
		Paper2.enabled = false;
		Paper3.enabled = false;
		Toon.enabled = false;
		BlackLine.enabled = false;
		Edgefilter.enabled = false;
		Golden.enabled = false;
		Neon.enabled = false;
		Sigmoid.enabled = false;
		Sobel.enabled = false;
		Rotation.enabled = false;
		SHOWFPS.enabled = false;
		EyesVision1.enabled = false;
		EyesVision2.enabled = false;
		ColorPerfection.enabled = false;
		Grain.enabled = false;
		FlyVision.enabled = false;
		FX8bits.enabled = false;
		FX8bitsgb.enabled = false;
		Ascii.enabled = false;
		DarkMatter.enabled = false;
		DigitalMatrix.enabled = false;
		DigitalMatrixDistortion.enabled = false;
		DotCircle.enabled = false;
		Drunk.enabled = false;
		Drunk2.enabled = false;
		EarthQuake.enabled = false;
		Funk.enabled = false;
		Glitch1.enabled = false;
		Glitch2.enabled = false;
		Glitch3.enabled = false;
		Grid.enabled = false;
		Hexagon.enabled = false;
		HexagonBlack.enabled = false;
		Hypno.enabled = false;
		InverChromiLum.enabled = false;
		FXMirror.enabled = false;
		FXPlasma.enabled = false;
		FXPsycho.enabled = false;
		Scan.enabled = false;
		Screens.enabled = false;
		Spot.enabled = false;
		superDot.enabled = false;
		ZebraColor.enabled = false;
		GlassesOn.enabled = false;
		GlassesOn2.enabled = false;
		GlassesOn3.enabled = false;
		GlassesOn4.enabled = false;
		GlassesOn5.enabled = false;
		GlassesOn6.enabled = false;
		Mozaic.enabled = false;
		Glow.enabled = false;
		GlowColor.enabled = false;
		Ansi.enabled = false;
		Desert.enabled = false;
		ElectricGradient.enabled = false;
		FireGradient.enabled = false;
		GradientsHue.enabled = false;
		NeonGradient.enabled = false;
		GradientsRainbow.enabled = false;
		Stripe.enabled = false;
		Tech.enabled = false;
		Therma.enabled = false;
		LightRainbow.enabled = false;
		LightRainbow2.enabled = false;
		Water.enabled = false;
		Water2.enabled = false;
		Lut.enabled = false;
		LutExtra.enabled = false;
		Mask.enabled = false;
		PlayWith.enabled = false;
		Plus.enabled = false;
		LutSimple.enabled = false;
		TestMode.enabled = false;
		NewGlitch1.enabled = false;
		NewGlitch2.enabled = false;
		NewGlitch3.enabled = false;
		NewGlitch4.enabled = false;
		NewGlitch5.enabled = false;
		NewGlitch6.enabled = false;
		NewGlitch7.enabled = false;
		NightVisionFX.enabled = false;
		NightVision4.enabled = false;
		TV.enabled = false;
		TV2.enabled = false;
		TV3.enabled = false;
		NightVision1.enabled = false;
		NightVision2.enabled = false;
		NightVision3.enabled = false;
		NightVision5.enabled = false;
		ThermaVision.enabled = false;
		Cutting1.enabled = false;
		Cutting2.enabled = false;
		DeepOilPaintHQ.enabled = false;
		Dot.enabled = false;
		OilPaint.enabled = false;
		OilPaintHQ.enabled = false;
		Sweater.enabled = false;
		Pixelisation.enabled = false;
		RainFX.enabled = false;
		RealVHS.enabled = false;
		Loading.enabled = false;
		Sharpen.enabled = false;
		Bubble.enabled = false;
		TV50.enabled = false;
		TV80.enabled = false;
		ARCADE.enabled = false;
		ARCADE2.enabled = false;
		ARCADEFast.enabled = false;
		Artefact.enabled = false;
		BrokenGlass.enabled = false;
		BrokenGlass2.enabled = false;
		Chromatical.enabled = false;
		Chromatical2.enabled = false;
		CompressionFX.enabled = false;
		Distorted.enabled = false;
		Horror.enabled = false;
		LED.enabled = false;
		MovieNoise.enabled = false;
		TVNoise.enabled = false;
		Old.enabled = false;
		OldMovie.enabled = false;
		OldMovie2.enabled = false;
		PlanetMars.enabled = false;
		Posterize.enabled = false;
		TVRgb.enabled = false;
		Tiles.enabled = false;
		Vcr.enabled = false;
		TVVHS.enabled = false;
		VHSRewind.enabled = false;
		Video3D.enabled = false;
		Videoflip.enabled = false;
		Vignetting.enabled = false;
		Vintage.enabled = false;
		WideScreenCircle.enabled = false;
		WideScreenHorizontal.enabled = false;
		WideScreenHV.enabled = false;
		WideScreenVertical.enabled = false;
		Tracking.enabled = false;
		Aura.enabled = false;
		AuraDistortion.enabled = false;
		VisionBlood.enabled = false;
		VisionBloodFast.enabled = false;
		Crystal.enabled = false;
		Drost.enabled = false;
		VisionHellBlood.enabled = false;
		VisionPlasma.enabled = false;
		VisionPsycho.enabled = false;
		VisionRainbow.enabled = false;
		SniperScore.enabled = false;
		Tunnel.enabled = false;
		Warp.enabled = false;
		Warp2.enabled = false;
		if (FilterID > FilterMax)
		{
			FilterID = 0;
		}
		if (FilterID < 0)
		{
			FilterID = FilterMax;
		}
		while (FilterSkips[FilterID])
		{
			if (Input.GetKeyDown("z"))
			{
				FilterID--;
			}
			else
			{
				FilterID++;
			}
		}
		NameLabel.text = "#" + FilterID + " - " + FilterNames[FilterID];
		switch (FilterID)
		{
		case 1:
			Anomaly.enabled = true;
			break;
		case 2:
			Binary.enabled = true;
			break;
		case 3:
			BlackHole3D.enabled = true;
			break;
		case 4:
			Computer.enabled = true;
			break;
		case 5:
			Distortion.enabled = true;
			break;
		case 6:
			FogSmoke.enabled = true;
			break;
		case 7:
			Ghost.enabled = true;
			break;
		case 8:
			Inverse.enabled = true;
			break;
		case 9:
			Matrix.enabled = true;
			break;
		case 10:
			Mirror3D.enabled = true;
			break;
		case 11:
			Myst.enabled = true;
			break;
		case 12:
			ScanScene.enabled = true;
			break;
		case 13:
			Shield.enabled = true;
			break;
		case 14:
			Snow.enabled = true;
			break;
		case 15:
			AAABlood.enabled = true;
			break;
		case 16:
			AAABloodOnScreen.enabled = true;
			break;
		case 17:
			AAABloodHit.enabled = true;
			break;
		case 18:
			AAABloodPlus.enabled = true;
			break;
		case 19:
			SuperComputer.enabled = true;
			break;
		case 20:
			SuperHexagon.enabled = true;
			break;
		case 21:
			WaterDrop.enabled = true;
			break;
		case 22:
			WaterDropPro.enabled = true;
			break;
		case 23:
			AlienVision.enabled = true;
			break;
		case 24:
			FXAA.enabled = true;
			break;
		case 25:
			Fog.enabled = true;
			break;
		case 26:
			Rain.enabled = true;
			break;
		case 27:
			RainPro.enabled = true;
			break;
		case 28:
			RainPro3D.enabled = true;
			break;
		case 29:
			Snow8bits.enabled = true;
			break;
		case 30:
			Blend.enabled = true;
			break;
		case 31:
			BlueScreen.enabled = true;
			break;
		case 32:
			Color.enabled = true;
			break;
		case 33:
			ColorBurn.enabled = true;
			break;
		case 34:
			ColorDodge.enabled = true;
			break;
		case 35:
			ColorKey.enabled = true;
			break;
		case 36:
			Darken.enabled = true;
			break;
		case 37:
			DarkerColor.enabled = true;
			break;
		case 38:
			Difference.enabled = true;
			break;
		case 39:
			Divide.enabled = true;
			break;
		case 40:
			Exclusion.enabled = true;
			break;
		case 41:
			GreenScreen.enabled = true;
			break;
		case 42:
			HardLight.enabled = true;
			break;
		case 43:
			HardMix.enabled = true;
			break;
		case 44:
			Blend2CameraHue.enabled = true;
			break;
		case 45:
			Lighten.enabled = true;
			break;
		case 46:
			LighterColor.enabled = true;
			break;
		case 47:
			LinearBurn.enabled = true;
			break;
		case 48:
			LinearDodge.enabled = true;
			break;
		case 49:
			LinearLight.enabled = true;
			break;
		case 50:
			Luminosity.enabled = true;
			break;
		case 51:
			Multiply.enabled = true;
			break;
		case 52:
			Overlay.enabled = true;
			break;
		case 53:
			PhotoshopFilters.enabled = true;
			break;
		case 54:
			PinLight.enabled = true;
			break;
		case 55:
			Saturation.enabled = true;
			break;
		case 56:
			Screen.enabled = true;
			break;
		case 57:
			SoftLight.enabled = true;
			break;
		case 58:
			SplitScreen.enabled = true;
			break;
		case 59:
			SplitScreen3D.enabled = true;
			break;
		case 60:
			Subtract.enabled = true;
			break;
		case 61:
			VividLight.enabled = true;
			break;
		case 62:
			Blizzard.enabled = true;
			break;
		case 63:
			Bloom.enabled = true;
			break;
		case 64:
			BlurHole.enabled = true;
			break;
		case 65:
			Blurry.enabled = true;
			break;
		case 66:
			Dithering2x2.enabled = true;
			break;
		case 67:
			DitherOffset.enabled = true;
			break;
		case 68:
			Focus.enabled = true;
			break;
		case 69:
			GaussianBlur.enabled = true;
			break;
		case 70:
			Movie.enabled = true;
			break;
		case 71:
			BlurNoise.enabled = true;
			break;
		case 72:
			Radial.enabled = true;
			break;
		case 73:
			RadialFast.enabled = true;
			break;
		case 74:
			Regular.enabled = true;
			break;
		case 75:
			Steam.enabled = true;
			break;
		case 76:
			TiltShift.enabled = true;
			break;
		case 77:
			TiltShiftHole.enabled = true;
			break;
		case 78:
			TiltShiftV.enabled = true;
			break;
		case 79:
			BrokenScreen.enabled = true;
			break;
		case 80:
			BrokenSimple.enabled = true;
			break;
		case 81:
			Spliter.enabled = true;
			break;
		case 82:
			ThermalVision.enabled = true;
			break;
		case 83:
			AdjustColorRGB.enabled = true;
			break;
		case 84:
			AdjustFullColors.enabled = true;
			break;
		case 85:
			AdjustPreFilters.enabled = true;
			break;
		case 86:
			BleachBypass.enabled = true;
			break;
		case 87:
			Brightness.enabled = true;
			break;
		case 88:
			DarkColor.enabled = true;
			break;
		case 89:
			HSV.enabled = true;
			break;
		case 90:
			HUERotate.enabled = true;
			break;
		case 91:
			NewPosterize.enabled = true;
			break;
		case 92:
			RgbClamp.enabled = true;
			break;
		case 93:
			Threshold.enabled = true;
			break;
		case 94:
			AdjustLevels.enabled = true;
			break;
		case 95:
			BrightContrastSaturation.enabled = true;
			break;
		case 96:
			ChromaticAberration.enabled = true;
			break;
		case 97:
			ChromaticPlus.enabled = true;
			break;
		case 98:
			Contrast.enabled = true;
			break;
		case 99:
			GrayScale.enabled = true;
			break;
		case 100:
			Invert.enabled = true;
			break;
		case 101:
			ColorNoise.enabled = true;
			break;
		case 102:
			ColorRGB.enabled = true;
			break;
		case 103:
			Sepia.enabled = true;
			break;
		case 104:
			Switching.enabled = true;
			break;
		case 105:
			YUV.enabled = true;
			break;
		case 106:
			Normal.enabled = true;
			break;
		case 107:
			Aspiration.enabled = true;
			break;
		case 108:
			BigFace.enabled = true;
			break;
		case 109:
			BlackHole.enabled = true;
			break;
		case 110:
			Dissipation.enabled = true;
			break;
		case 111:
			Dream.enabled = true;
			break;
		case 112:
			Dream2.enabled = true;
			break;
		case 113:
			FishEye.enabled = true;
			break;
		case 114:
			Flag.enabled = true;
			break;
		case 115:
			Flush.enabled = true;
			break;
		case 116:
			HalfSphere.enabled = true;
			break;
		case 117:
			Heat.enabled = true;
			break;
		case 118:
			Lens.enabled = true;
			break;
		case 119:
			DistortionNoise.enabled = true;
			break;
		case 120:
			ShockWave.enabled = true;
			break;
		case 121:
			ShockWaveManual.enabled = true;
			break;
		case 122:
			Twist.enabled = true;
			break;
		case 123:
			TwistSquare.enabled = true;
			break;
		case 124:
			DistortionWaterDrop.enabled = true;
			break;
		case 125:
			WaveHorizontal.enabled = true;
			break;
		case 126:
			BluePrint.enabled = true;
			break;
		case 127:
			CellShading.enabled = true;
			break;
		case 128:
			CellShading2.enabled = true;
			break;
		case 129:
			Comics.enabled = true;
			break;
		case 130:
			Crosshatch.enabled = true;
			break;
		case 131:
			Curve.enabled = true;
			break;
		case 132:
			EnhancedComics.enabled = true;
			break;
		case 133:
			Halftone.enabled = true;
			break;
		case 134:
			Laplacian.enabled = true;
			break;
		case 135:
			Lines.enabled = true;
			break;
		case 136:
			Manga.enabled = true;
			break;
		case 137:
			Manga2.enabled = true;
			break;
		case 138:
			Manga3.enabled = true;
			break;
		case 139:
			Manga4.enabled = true;
			break;
		case 140:
			Manga5.enabled = true;
			break;
		case 141:
			MangaColor.enabled = true;
			break;
		case 142:
			MangaFlash.enabled = true;
			break;
		case 143:
			MangaFlashWhite.enabled = true;
			break;
		case 144:
			MangaFlashColor.enabled = true;
			break;
		case 145:
			NewCellShading.enabled = true;
			break;
		case 146:
			Paper.enabled = true;
			break;
		case 147:
			Paper2.enabled = true;
			break;
		case 148:
			Paper3.enabled = true;
			break;
		case 149:
			Toon.enabled = true;
			break;
		case 150:
			BlackLine.enabled = true;
			break;
		case 151:
			Edgefilter.enabled = true;
			break;
		case 152:
			Golden.enabled = true;
			break;
		case 153:
			Neon.enabled = true;
			break;
		case 154:
			Sigmoid.enabled = true;
			break;
		case 155:
			Sobel.enabled = true;
			break;
		case 156:
			Rotation.enabled = true;
			break;
		case 157:
			SHOWFPS.enabled = true;
			break;
		case 158:
			EyesVision1.enabled = true;
			break;
		case 159:
			EyesVision2.enabled = true;
			break;
		case 160:
			ColorPerfection.enabled = true;
			break;
		case 161:
			Grain.enabled = true;
			break;
		case 162:
			FlyVision.enabled = true;
			break;
		case 163:
			FX8bits.enabled = true;
			break;
		case 164:
			FX8bitsgb.enabled = true;
			break;
		case 165:
			Ascii.enabled = true;
			break;
		case 166:
			DarkMatter.enabled = true;
			break;
		case 167:
			DigitalMatrix.enabled = true;
			break;
		case 168:
			DigitalMatrixDistortion.enabled = true;
			break;
		case 169:
			DotCircle.enabled = true;
			break;
		case 170:
			Drunk.enabled = true;
			break;
		case 171:
			Drunk2.enabled = true;
			break;
		case 172:
			EarthQuake.enabled = true;
			break;
		case 173:
			Funk.enabled = true;
			break;
		case 174:
			Glitch1.enabled = true;
			break;
		case 175:
			Glitch2.enabled = true;
			break;
		case 176:
			Glitch3.enabled = true;
			break;
		case 177:
			Grid.enabled = true;
			break;
		case 178:
			Hexagon.enabled = true;
			break;
		case 179:
			HexagonBlack.enabled = true;
			break;
		case 180:
			Hypno.enabled = true;
			break;
		case 181:
			InverChromiLum.enabled = true;
			break;
		case 182:
			FXMirror.enabled = true;
			break;
		case 183:
			FXPlasma.enabled = true;
			break;
		case 184:
			FXPsycho.enabled = true;
			break;
		case 185:
			Scan.enabled = true;
			break;
		case 186:
			Screens.enabled = true;
			break;
		case 187:
			Spot.enabled = true;
			break;
		case 188:
			superDot.enabled = true;
			break;
		case 189:
			ZebraColor.enabled = true;
			break;
		case 190:
			GlassesOn.enabled = true;
			break;
		case 191:
			GlassesOn2.enabled = true;
			break;
		case 192:
			GlassesOn3.enabled = true;
			break;
		case 193:
			GlassesOn4.enabled = true;
			break;
		case 194:
			GlassesOn5.enabled = true;
			break;
		case 195:
			GlassesOn6.enabled = true;
			break;
		case 196:
			Mozaic.enabled = true;
			break;
		case 197:
			Glow.enabled = true;
			break;
		case 198:
			GlowColor.enabled = true;
			break;
		case 199:
			Ansi.enabled = true;
			break;
		case 200:
			Desert.enabled = true;
			break;
		case 201:
			ElectricGradient.enabled = true;
			break;
		case 202:
			FireGradient.enabled = true;
			break;
		case 203:
			GradientsHue.enabled = true;
			break;
		case 204:
			NeonGradient.enabled = true;
			break;
		case 205:
			GradientsRainbow.enabled = true;
			break;
		case 206:
			Stripe.enabled = true;
			break;
		case 207:
			Tech.enabled = true;
			break;
		case 208:
			Therma.enabled = true;
			break;
		case 209:
			LightRainbow.enabled = true;
			break;
		case 210:
			LightRainbow2.enabled = true;
			break;
		case 211:
			Water.enabled = true;
			break;
		case 212:
			Water2.enabled = true;
			break;
		case 213:
			Lut.enabled = true;
			break;
		case 214:
			LutExtra.enabled = true;
			break;
		case 215:
			Mask.enabled = true;
			break;
		case 216:
			PlayWith.enabled = true;
			break;
		case 217:
			Plus.enabled = true;
			break;
		case 218:
			LutSimple.enabled = true;
			break;
		case 219:
			TestMode.enabled = true;
			break;
		case 220:
			NewGlitch1.enabled = true;
			break;
		case 221:
			NewGlitch2.enabled = true;
			break;
		case 222:
			NewGlitch3.enabled = true;
			break;
		case 223:
			NewGlitch4.enabled = true;
			break;
		case 224:
			NewGlitch5.enabled = true;
			break;
		case 225:
			NewGlitch6.enabled = true;
			break;
		case 226:
			NewGlitch7.enabled = true;
			break;
		case 227:
			NightVisionFX.enabled = true;
			break;
		case 228:
			NightVision4.enabled = true;
			break;
		case 229:
			TV.enabled = true;
			break;
		case 230:
			TV2.enabled = true;
			break;
		case 231:
			TV3.enabled = true;
			break;
		case 232:
			NightVision1.enabled = true;
			break;
		case 233:
			NightVision2.enabled = true;
			break;
		case 234:
			NightVision3.enabled = true;
			break;
		case 235:
			NightVision5.enabled = true;
			break;
		case 236:
			ThermaVision.enabled = true;
			break;
		case 237:
			Cutting1.enabled = true;
			break;
		case 238:
			Cutting2.enabled = true;
			break;
		case 239:
			DeepOilPaintHQ.enabled = true;
			break;
		case 240:
			Dot.enabled = true;
			break;
		case 241:
			OilPaint.enabled = true;
			break;
		case 242:
			OilPaintHQ.enabled = true;
			break;
		case 243:
			Sweater.enabled = true;
			break;
		case 244:
			Pixelisation.enabled = true;
			break;
		case 245:
			RainFX.enabled = true;
			break;
		case 246:
			RealVHS.enabled = true;
			break;
		case 247:
			Loading.enabled = true;
			break;
		case 248:
			Sharpen.enabled = true;
			break;
		case 249:
			Bubble.enabled = true;
			break;
		case 250:
			TV50.enabled = true;
			break;
		case 251:
			TV80.enabled = true;
			break;
		case 252:
			ARCADE.enabled = true;
			break;
		case 253:
			ARCADE2.enabled = true;
			break;
		case 254:
			ARCADEFast.enabled = true;
			break;
		case 255:
			Artefact.enabled = true;
			break;
		case 256:
			BrokenGlass.enabled = true;
			break;
		case 257:
			BrokenGlass2.enabled = true;
			break;
		case 258:
			Chromatical.enabled = true;
			break;
		case 259:
			Chromatical2.enabled = true;
			break;
		case 260:
			CompressionFX.enabled = true;
			break;
		case 261:
			Distorted.enabled = true;
			break;
		case 262:
			Horror.enabled = true;
			break;
		case 263:
			LED.enabled = true;
			break;
		case 264:
			MovieNoise.enabled = true;
			break;
		case 265:
			TVNoise.enabled = true;
			break;
		case 266:
			Old.enabled = true;
			break;
		case 267:
			OldMovie.enabled = true;
			break;
		case 268:
			OldMovie2.enabled = true;
			break;
		case 269:
			PlanetMars.enabled = true;
			break;
		case 270:
			Posterize.enabled = true;
			break;
		case 271:
			TVRgb.enabled = true;
			break;
		case 272:
			Tiles.enabled = true;
			break;
		case 273:
			Vcr.enabled = true;
			break;
		case 274:
			TVVHS.enabled = true;
			break;
		case 275:
			VHSRewind.enabled = true;
			break;
		case 276:
			Video3D.enabled = true;
			break;
		case 277:
			Videoflip.enabled = true;
			break;
		case 278:
			Vignetting.enabled = true;
			break;
		case 279:
			Vintage.enabled = true;
			break;
		case 280:
			WideScreenCircle.enabled = true;
			break;
		case 281:
			WideScreenHorizontal.enabled = true;
			break;
		case 282:
			WideScreenHV.enabled = true;
			break;
		case 283:
			WideScreenVertical.enabled = true;
			break;
		case 284:
			Tracking.enabled = true;
			break;
		case 285:
			Aura.enabled = true;
			break;
		case 286:
			AuraDistortion.enabled = true;
			break;
		case 287:
			VisionBlood.enabled = true;
			break;
		case 288:
			VisionBloodFast.enabled = true;
			break;
		case 289:
			Crystal.enabled = true;
			break;
		case 290:
			Drost.enabled = true;
			break;
		case 291:
			VisionHellBlood.enabled = true;
			break;
		case 292:
			VisionPlasma.enabled = true;
			break;
		case 293:
			VisionPsycho.enabled = true;
			break;
		case 294:
			VisionRainbow.enabled = true;
			break;
		case 295:
			SniperScore.enabled = true;
			break;
		case 296:
			Tunnel.enabled = true;
			break;
		case 297:
			Warp.enabled = true;
			break;
		case 298:
			Warp2.enabled = true;
			break;
		}
	}
}
