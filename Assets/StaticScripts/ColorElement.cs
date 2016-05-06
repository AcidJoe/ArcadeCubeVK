﻿using UnityEngine;
using System.Collections;

public class ColorElement : MonoBehaviour
{
    public enum _Color { White, Blue, Green, Yellow, Orange, Red}

    Camera cam;
    SpriteRenderer _renderer;

    Color32 color;
    bool isPainted;

	void Start ()
    {
        isPainted = false;

        CheckDiff();

        if (name.Contains("Main Camera"))
        {
            cam = GetComponent<Camera>();
            cam.clearFlags = CameraClearFlags.SolidColor;
        }
        else
        {
            _renderer = GetComponent<SpriteRenderer>();
        }
	}

    void Update()
    {
        if (!isPainted)
        {
            Paint();
        }
    }

    void CheckDiff()
    {
        switch (GameInfo.difficulty)
        {
            case 1:
                SetColor(_Color.White);
                break;
            case 2:
                SetColor(_Color.Blue);
                break;
            case 3:
                SetColor(_Color.Green);
                break;
            case 4:
                SetColor(_Color.Yellow);
                break;
            case 5:
                SetColor(_Color.Orange);
                break;
            case 6:
                SetColor(_Color.Red);
                break;
        }
    }

    void SetColor(_Color col)
    {
        switch (col)
        {
            case _Color.White:
                color = new Color32(255, 255, 255, 255);
                break;
            case _Color.Blue:
                color = new Color32(155, 239, 255, 255);
                break;
            case _Color.Green:
                color = new Color32(145, 238, 165, 255);
                break;
            case _Color.Yellow:
                color = new Color32(244, 255, 155, 255);
                break;
            case _Color.Orange:
                color = new Color32(255, 213, 155, 255);
                break;
            case _Color.Red:
                color = new Color32(255, 155, 155, 255);
                break;
        }
    }

    void Paint()
    {
        if (name.Contains("Main Camera"))
        {
            cam.backgroundColor = color;
            isPainted = true;
        }
        else
        {
            _renderer.color = color;
            isPainted = true;
        }
    }
}
