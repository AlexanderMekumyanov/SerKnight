﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Serialization;

public class DialogSystem
{
    static DialogSystem dialogSystem;

    private XmlDocument dialogsFile;
    private String XMLFileName;

    public DialogSystem ()
    {
        XMLFileName = "Assets/resources/files/text.xml";
    }

    public static DialogSystem GetDialogSystem()
    {
        if (dialogSystem == null)
        {
            dialogSystem = new DialogSystem();
            return dialogSystem;
        }
        else
        {
            return dialogSystem;
        }
    }

    public List<string> GetDialogById(string id)
    {
        // TODO Переписать Нахрен!
        XmlTextReader reader = new XmlTextReader(XMLFileName);
        List<string> texts   = new List<string>();

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == id)
            {
                int i = 0;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == ("text_" + i))
                    {
                        texts.Add(reader.ReadElementContentAsString());
                        i++;
                    }
                }
            }
        }
        return texts;
    }
}
