using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x02000499 RID: 1177
public class SerializableDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F4B RID: 8011 RVA: 0x001B88A3 File Offset: 0x001B6AA3
	public SerializableDictionary()
	{
		this.keys = new List<K>();
		this.values = new List<V>();
	}

	// Token: 0x06001F4C RID: 8012 RVA: 0x001B88C4 File Offset: 0x001B6AC4
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

	// Token: 0x06001F4D RID: 8013 RVA: 0x001B8948 File Offset: 0x001B6B48
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.keys.Count; i++)
		{
			base.Add(this.keys[i], this.values[i]);
		}
	}

	// Token: 0x06001F4E RID: 8014 RVA: 0x001B898F File Offset: 0x001B6B8F
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F4F RID: 8015 RVA: 0x001B8994 File Offset: 0x001B6B94
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

	// Token: 0x06001F50 RID: 8016 RVA: 0x001B8A40 File Offset: 0x001B6C40
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

	// Token: 0x04004162 RID: 16738
	[SerializeField]
	private List<K> keys;

	// Token: 0x04004163 RID: 16739
	[SerializeField]
	private List<V> values;

	// Token: 0x04004164 RID: 16740
	private const string XML_Item = "Item";

	// Token: 0x04004165 RID: 16741
	private const string XML_Key = "Key";

	// Token: 0x04004166 RID: 16742
	private const string XML_Value = "Value";
}
