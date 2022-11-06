// Decompiled with JetBrains decompiler
// Type: INGUIFont
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public interface INGUIFont
{
  BMFont bmFont { get; set; }

  int texWidth { get; set; }

  int texHeight { get; set; }

  bool hasSymbols { get; }

  List<BMSymbol> symbols { get; set; }

  INGUIAtlas atlas { get; set; }

  UISpriteData GetSprite(string spriteName);

  Material material { get; set; }

  bool premultipliedAlphaShader { get; }

  bool packedFontShader { get; }

  Texture2D texture { get; }

  Rect uvRect { get; set; }

  string spriteName { get; set; }

  bool isValid { get; }

  int defaultSize { get; set; }

  UISpriteData sprite { get; }

  INGUIFont replacement { get; set; }

  INGUIFont finalFont { get; }

  bool isDynamic { get; }

  Font dynamicFont { get; set; }

  FontStyle dynamicFontStyle { get; set; }

  bool References(INGUIFont font);

  void MarkAsChanged();

  void UpdateUVRect();

  BMSymbol MatchSymbol(string text, int offset, int textLength);

  void AddSymbol(string sequence, string spriteName);

  void RemoveSymbol(string sequence);

  void RenameSymbol(string before, string after);

  bool UsesSprite(string s);
}
