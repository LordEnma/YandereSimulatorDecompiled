using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004AA RID: 1194
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F79 RID: 8057 RVA: 0x001BAD04 File Offset: 0x001B8F04
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F7A RID: 8058 RVA: 0x001BAD18 File Offset: 0x001B8F18
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F7B RID: 8059 RVA: 0x001BAD78 File Offset: 0x001B8F78
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001F7C RID: 8060 RVA: 0x001BADB4 File Offset: 0x001B8FB4
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F7D RID: 8061 RVA: 0x001BADB8 File Offset: 0x001B8FB8
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("Element");
			T item = (T)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(item);
			reader.MoveToContent();
		}
	}

	// Token: 0x06001F7E RID: 8062 RVA: 0x001BAE1C File Offset: 0x001B901C
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		foreach (T t in this)
		{
			writer.WriteStartElement("Element");
			xmlSerializer.Serialize(writer, t);
			writer.WriteEndElement();
		}
	}

	// Token: 0x040041A8 RID: 16808
	[SerializeField]
	private List<T> elements;

	// Token: 0x040041A9 RID: 16809
	private const string XML_Element = "Element";
}
