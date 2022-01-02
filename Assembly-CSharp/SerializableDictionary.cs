using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x02000496 RID: 1174
public class SerializableDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F3E RID: 7998 RVA: 0x001B7253 File Offset: 0x001B5453
	public SerializableDictionary()
	{
		this.keys = new List<K>();
		this.values = new List<V>();
	}

	// Token: 0x06001F3F RID: 7999 RVA: 0x001B7274 File Offset: 0x001B5474
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

	// Token: 0x06001F40 RID: 8000 RVA: 0x001B72F8 File Offset: 0x001B54F8
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.keys.Count; i++)
		{
			base.Add(this.keys[i], this.values[i]);
		}
	}

	// Token: 0x06001F41 RID: 8001 RVA: 0x001B733F File Offset: 0x001B553F
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F42 RID: 8002 RVA: 0x001B7344 File Offset: 0x001B5544
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

	// Token: 0x06001F43 RID: 8003 RVA: 0x001B73F0 File Offset: 0x001B55F0
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

	// Token: 0x04004147 RID: 16711
	[SerializeField]
	private List<K> keys;

	// Token: 0x04004148 RID: 16712
	[SerializeField]
	private List<V> values;

	// Token: 0x04004149 RID: 16713
	private const string XML_Item = "Item";

	// Token: 0x0400414A RID: 16714
	private const string XML_Key = "Key";

	// Token: 0x0400414B RID: 16715
	private const string XML_Value = "Value";
}
