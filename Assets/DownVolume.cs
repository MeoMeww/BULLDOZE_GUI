using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VRStandardAssets.Utils
{
    public class DownVolume : MonoBehaviour
    {
        public UnityEngine.UI.Slider Slider;
        // Start is called before the first frame update
        private VRInteractiveItem m_CurrentInteractible;
        [SerializeField] private SelectionRadial m_SelectionRadial;
        private bool m_GazeOver;
        void Start()
        {
            m_CurrentInteractible = GetComponent<VRInteractiveItem>();
            m_CurrentInteractible.OnOver += HandleOver;
            m_CurrentInteractible.OnOut += HandleOut;
            m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
        }
        private void HandleSelectionComplete()
        {
            if (m_GazeOver)
            {
                Slider.value -= (float)0.25;
                if (Slider.value <= 0)
                    Slider.value = 0;
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

    }
}