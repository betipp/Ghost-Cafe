using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPeeking : MonoBehaviour
{
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] float fadeSpeed;
    [SerializeField] float sphereCheckSize = .15f;

    private Material cameraFadeMat;
    private bool isCameraFadedOut = false;

    private void Awake()
    {
        cameraFadeMat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (Physics.CheckSphere(transform.position, sphereCheckSize, collisionLayer, QueryTriggerInteraction.Ignore))
        {
            CameraFade(1f);
            isCameraFadedOut = true;
        }
        else
        {
            if (!isCameraFadedOut)
            {
                return;
            }
            CameraFade(0f);
        }

    }

    public void CameraFade(float targetAlpha)
    {
        var fadeValue = Mathf.MoveTowards(cameraFadeMat.GetFloat("_AlphaValue"), targetAlpha, Time.deltaTime * fadeSpeed);
        cameraFadeMat.SetFloat("_AlphaValue", fadeValue);

        if (fadeValue <= 0.01f)
        {
            isCameraFadedOut = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1, 0, 0.75f);
        Gizmos.DrawSphere(transform.position, sphereCheckSize);
    }
}
