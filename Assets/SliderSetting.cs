﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VRStandardAssets.Utils
{
    public class SliderSetting : MonoBehaviour
    {
        public GameObject Slider;
        // Start is called before the first frame update
        private VRInteractiveItem m_CurrentInteractible;
        [SerializeField] private SelectionRadial m_SelectionRadial;
        private bool m_GazeOver;
        private UnityEngine.UI.Button UpVollume;
        private UnityEngine.UI.Button DownVollume;
        void Start()
        {
            m_CurrentInteractible = GetComponent<VRInteractiveItem>();
            m_CurrentInteractible.OnOver += HandleOver;
            m_CurrentInteractible.OnOut += HandleOut;
            m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
            m_CurrentInteractible.OnDown += MouseOnDown;
            m_CurrentInteractible.OnUp += MouseOnUp;
        }
        private void HandleSelectionComplete()
        {
            if (m_GazeOver)
            {
                Debug.Log(("Slider Hidden"));
                Slider.gameObject.active = !Slider.gameObject.active;
            }
        }

        private void HandleOver()
        {
            // When the user looks at the rendering of the scene, show the radial.
            m_SelectionRadial.Show();

            m_GazeOver = true;
        }


        private void HandleOut()
        {
            // When the user looks away from the rendering of the scene, hide the radial.
            m_SelectionRadial.Hide();

            m_GazeOver = false;
        }
        private void MouseOnDown()
        {

        }
        private void MouseOnUp()
        {

        }
        private void Update()
        {
            Debug.Log(" Mouse :" + Input.mousePosition.x);
        }
    }
}