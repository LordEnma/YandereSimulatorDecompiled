using System;
using UnityEngine;

public class Readme : ScriptableObject
{
	[Serializable]
	public class Section
	{
		public string heading;

		public string text;

		public string linkText;

		public string url;
	}

	public Texture2D icon;

	public string title;

	public Section[] sections;

	public bool loadedLayout;
}
