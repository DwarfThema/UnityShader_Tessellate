﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    public Shader _snowFallShader;
    private Material _snowFallMat;
    private MeshRenderer _meshRenderer;

    [Range(-0.001f, -1f)]
    public float _flakeAmount;
    [Range(-0, -10)]
    public float _flakeOpacity;
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _snowFallMat = new Material(_snowFallShader);
    }

    // Update is called once per frame
    void Update()
    {
        _snowFallMat.SetFloat("_FlakeAmout", _flakeAmount);
        _snowFallMat.SetFloat("_FlakeOpacity", _flakeOpacity);
        RenderTexture snow = (RenderTexture)_meshRenderer.material.GetTexture("_Splat");
        RenderTexture temp = RenderTexture.GetTemporary(snow.width, snow.height, 0, RenderTextureFormat.ARGBFloat);
        Graphics.Blit(snow, temp, _snowFallMat);
        Graphics.Blit(temp, snow);
        _meshRenderer.material.SetTexture("_Splat", snow);
        RenderTexture.ReleaseTemporary(temp);

    }
}
