using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace VRStandardAssets.Utils
{
    public class HomeButton : MonoBehaviour
    {
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
                Application.Quit();
        }
        private void HandleOver()
        {
            m_SelectionRadial.Show();
            m_GazeOver = true;
        }
        private void HandleOut()
        {
            m_SelectionRadial.Hide();
            m_GazeOver = false;
        }
    }
}