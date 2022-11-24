using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class SceneReseterUI : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private int _resetSceneIndex = 1;

        public void OnPointerDown(PointerEventData eventData)
        {
            Load();
        }

        public void Load() 
        {
            SceneManager.LoadScene(_resetSceneIndex);
        }
    }
}