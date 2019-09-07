using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class NGUICell : iCollectionViewCell {

    public int index;

    public void Update()
    {
        index = Index;
    }

    public override string NibName
    {
        get
        {
            return "NGUICell";
        }
    } 

    Material m_material;
    Renderer m_renderer;
    GameObject text = new GameObject();
    TextMesh m_sign;

    public override void SetData(object data)
    {
        base.SetData(data);

        if(m_renderer==null)
            m_renderer = GetComponent<Renderer>();

        if(m_renderer!=null && m_material==null)
        {
            m_material = m_renderer.material;
        }

        if(text==null)
            m_sign = text.AddComponent<TextMesh>();

        //Set Color
        if(m_material!=null)
        {
            QuadCell.QuadCellData quadData = data as QuadCell.QuadCellData;
            if(quadData!=null && quadData.MainColor != null)
            {
                m_material.color = quadData.MainColor;
                m_renderer.material = m_material;
            }
        }

        //Set Text
        if(m_sign!=null)
        {
            QuadCell.QuadCellData quadData = data as QuadCell.QuadCellData;
            if(quadData!=null && quadData.MainText != null)
            {
                m_sign.text = quadData.MainText;
                m_sign.font = Resources.Load<Font>("Fonts/TESLA");
                m_sign.color = Color.white;
            }
        }
    }
}
