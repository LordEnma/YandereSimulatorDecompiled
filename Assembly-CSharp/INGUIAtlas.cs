using System.Collections.Generic;
using UnityEngine;

public interface INGUIAtlas
{
	Material spriteMaterial { get; set; }

	List<UISpriteData> spriteList { get; set; }

	Texture texture { get; }

	float pixelSize { get; set; }

	bool premultipliedAlpha { get; }

	INGUIAtlas replacement { get; set; }

	UISpriteData GetSprite(string name);

	BetterList<string> GetListOfSprites();

	BetterList<string> GetListOfSprites(string match);

	bool References(INGUIAtlas atlas);

	void MarkAsChanged();

	void SortAlphabetically();
}
