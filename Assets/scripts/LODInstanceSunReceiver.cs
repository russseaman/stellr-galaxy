﻿// Copyright Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace GalaxyExplorer
{
    public class LODInstanceSunReceiver : MonoBehaviour
    {
        public Transform Sun;

        private MeshRenderer currentRenderer;
        private Vector4 originalSunPosition;

        private void Awake()
        {
            FindSunIfNeeded();

            currentRenderer = GetComponent<MeshRenderer>();
            originalSunPosition = currentRenderer.sharedMaterial.GetVector("_SunPosition");
        }

        private void Update()
        {
            if (Sun && currentRenderer)
            {
                currentRenderer.sharedMaterial.SetVector("_SunPosition", Sun.position);
            }
        }

        private void OnDestroy()
        {
            currentRenderer.sharedMaterial.SetVector("_SunPosition", originalSunPosition);
        }

        public bool FindSunIfNeeded()
        {
            if (!Sun)
            {
                var sunGo = GameObject.Find("Sun");
                if (sunGo)
                {
                    Sun = sunGo.transform;
                    return true;
                }
            }

            return Sun;
        }
    }
}