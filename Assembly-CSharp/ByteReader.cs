using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

// Token: 0x02000071 RID: 113
public class ByteReader
{
	// Token: 0x0600032A RID: 810 RVA: 0x00020835 File Offset: 0x0001EA35
	public ByteReader(byte[] bytes)
	{
		this.mBuffer = bytes;
	}

	// Token: 0x0600032B RID: 811 RVA: 0x00020844 File Offset: 0x0001EA44
	public ByteReader(TextAsset asset)
	{
		this.mBuffer = asset.bytes;
	}

	// Token: 0x0600032C RID: 812 RVA: 0x00020858 File Offset: 0x0001EA58
	public static ByteReader Open(string path)
	{
		FileStream fileStream = File.OpenRead(path);
		if (fileStream != null)
		{
			fileStream.Seek(0L, SeekOrigin.End);
			byte[] array = new byte[fileStream.Position];
			fileStream.Seek(0L, SeekOrigin.Begin);
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			return new ByteReader(array);
		}
		return null;
	}

	// Token: 0x17000058 RID: 88
	// (get) Token: 0x0600032D RID: 813 RVA: 0x000208AA File Offset: 0x0001EAAA
	public bool canRead
	{
		get
		{
			return this.mBuffer != null && this.mOffset < this.mBuffer.Length;
		}
	}

	// Token: 0x0600032E RID: 814 RVA: 0x000208C6 File Offset: 0x0001EAC6
	private static string ReadLine(byte[] buffer, int start, int count)
	{
		return Encoding.UTF8.GetString(buffer, start, count);
	}

	// Token: 0x0600032F RID: 815 RVA: 0x000208D5 File Offset: 0x0001EAD5
	public string ReadLine()
	{
		return this.ReadLine(true);
	}

	// Token: 0x06000330 RID: 816 RVA: 0x000208E0 File Offset: 0x0001EAE0
	public string ReadLine(bool skipEmptyLines)
	{
		int num = this.mBuffer.Length;
		if (skipEmptyLines)
		{
			while (this.mOffset < num && this.mBuffer[this.mOffset] < 32)
			{
				this.mOffset++;
			}
		}
		int i = this.mOffset;
		if (i < num)
		{
			while (i < num)
			{
				int num2 = (int)this.mBuffer[i++];
				if (num2 == 10 || num2 == 13)
				{
					IL_62:
					string result = ByteReader.ReadLine(this.mBuffer, this.mOffset, i - this.mOffset - 1);
					this.mOffset = i;
					return result;
				}
			}
			i++;
			goto IL_62;
		}
		this.mOffset = num;
		return null;
	}

	// Token: 0x06000331 RID: 817 RVA: 0x0002097C File Offset: 0x0001EB7C
	public Dictionary<string, string> ReadDictionary()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		char[] separator = new char[]
		{
			'='
		};
		while (this.canRead)
		{
			string text = this.ReadLine();
			if (text == null)
			{
				break;
			}
			if (!text.StartsWith("//"))
			{
				string[] array = text.Split(separator, 2, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 2)
				{
					string key = array[0].Trim();
					string value = array[1].Trim().Replace("\\n", "\n");
					dictionary[key] = value;
				}
			}
		}
		return dictionary;
	}

	// Token: 0x06000332 RID: 818 RVA: 0x000209FC File Offset: 0x0001EBFC
	public BetterList<string> ReadCSV()
	{
		ByteReader.mTemp.Clear();
		string text = "";
		bool flag = false;
		int num = 0;
		while (this.canRead)
		{
			if (flag)
			{
				string text2 = this.ReadLine(false);
				if (text2 == null)
				{
					return null;
				}
				text2 = text2.Replace("\\n", "\n");
				text = text + "\n" + text2;
			}
			else
			{
				text = this.ReadLine(true);
				if (text == null)
				{
					return null;
				}
				text = text.Replace("\\n", "\n");
				num = 0;
			}
			int i = num;
			int length = text.Length;
			while (i < length)
			{
				char c = text[i];
				if (c == ',')
				{
					if (!flag)
					{
						ByteReader.mTemp.Add(text.Substring(num, i - num));
						num = i + 1;
					}
				}
				else if (c == '"')
				{
					if (flag)
					{
						if (i + 1 >= length)
						{
							ByteReader.mTemp.Add(text.Substring(num, i - num).Replace("\"\"", "\""));
							return ByteReader.mTemp;
						}
						if (text[i + 1] != '"')
						{
							ByteReader.mTemp.Add(text.Substring(num, i - num).Replace("\"\"", "\""));
							flag = false;
							if (text[i + 1] == ',')
							{
								i++;
								num = i + 1;
							}
						}
						else
						{
							i++;
						}
					}
					else
					{
						num = i + 1;
						flag = true;
					}
				}
				i++;
			}
			if (num < text.Length)
			{
				if (flag)
				{
					continue;
				}
				ByteReader.mTemp.Add(text.Substring(num, text.Length - num));
			}
			else
			{
				ByteReader.mTemp.Add("");
			}
			return ByteReader.mTemp;
		}
		return null;
	}

	// Token: 0x0400049C RID: 1180
	private byte[] mBuffer;

	// Token: 0x0400049D RID: 1181
	private int mOffset;

	// Token: 0x0400049E RID: 1182
	private static BetterList<string> mTemp = new BetterList<string>();
}
