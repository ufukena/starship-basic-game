﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private MeshRenderer meshRenderer;
    private float xScroll;
    
    void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();        
    }

    
    void Update() {

        Scroll();

    }

    private void Scroll() {

        xScroll = Time.time * scrollSpeed;
        Vector2 offset = new Vector2(xScroll, 0);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

        //Resmin tekrarlanması için Sprite -> Inspector -> Wrap Mode = Repeat Olmalı

    }
}
