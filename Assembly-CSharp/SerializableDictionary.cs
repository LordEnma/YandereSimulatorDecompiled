using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x02000496 RID: 1174
public class SerializableDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F3B RID: 7995 RVA: 0x001B6D7B File Offset: 0x001B4F7B
	public SerializableDictionary()
	{
		this.keys = new List<K>();
		this.values = new List<V>();
	}

	// Token: 0x06001F3C RID: 7996 RVA: 0x001B6D9C File Offset: 0x001B4F9C
	public void OnBeforeSerialize()
	{
		this.keys.Clear();
		this.values.Clear();
		foreach (KeyValuePair<K, V> keyValuePair in this)
		{
			this.keys.Add(keyValuePair.Key);
			this.values.Add(keyValuePair.Value);
		}
	}

	// Token: 0x06001F3D RID: 7997 RVA: 0x001B6E20 File Offset: 0x001B5020
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.keys.Count; i++)
		{
			base.Add(this.keys[i], this.values[i]);
		}
	}

	// Token: 0x06001F3E RID: 7998 RVA: 0x001B6E67 File Offset: 0x001B5067
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F3F RID: 7999 RVA: 0x001B6E6C File Offset: 0x001B506C
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(K));
		XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(V));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("Item");
			reader.ReadStartElement("Key");
			K key = (K)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			reader.ReadStartElement("Value");
			V value = (V)((object)xmlSerializer2.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(key, value);
			reader.ReadEndElement();
			reader.MoveToContent();
		}
		reader.ReadEndElement();
	}

	// Token: 0x06001F40 RID: 8000 RVA: 0x001B6F18 File Offset: 0x001B5118
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(K));
		XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(V));
		foreach (KeyValuePair<K, V> keyValuePair in this)
		{
			writer.WriteStartElement("Item");
			writer.WriteStartElement("Key");
			xmlSerializer.Serialize(writer, keyValuePair.Key);
			writer.WriteEndElement();
			writer.WriteStartElement("Value");
			xmlSerializer2.Serialize(writer, keyValuePair.Value);
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}

	// Token: 0x04004140 RID: 16704
	[SerializeField]
	private List<K> keys;

	// Token: 0x04004141 RID: 16705
	[SerializeField]
	private List<V> values;

	// Token: 0x04004142 RID: 16706
	private const string XML_Item = "Item";

	// Token: 0x04004143 RID: 16707
	private const string XML_Key = "Key";

	// Token: 0x04004144 RID: 16708
	private const string XML_Value = "Value";
}
