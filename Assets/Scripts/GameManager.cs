using UnityEngine;
using UnityEngine.SceneManagement;

namespace Garage
{
    public class GameManager : MonoBehaviour
    {
        private PlayerItemHandler _playerItemHandler;
        private PlayerController _playerController;
        private Crosshair _crosshair;
        private TaskManager _taskManager;
        private TaskUIManager _taskUIManager;

        //public void Initialize(InteractionSystem interactionSystem, PlayerController playerController)
        //{
        //    _interactionSystem = interactionSystem;
        //    _playerController = playerController;
        //}

        private void Start()
        {
            _crosshair = FindObjectOfType<Crosshair>();
            Camera mainCamera = Camera.main;

            _playerItemHandler = FindObjectOfType<PlayerItemHandler>();
            _playerItemHandler.Initialize(mainCamera, _crosshair, 3f);

            _taskManager = FindObjectOfType<TaskManager>();

            _taskUIManager = FindObjectOfType<TaskUIManager>();
            _taskUIManager.DisplayTask("Переместите все вещи с полки в машину", _taskManager);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.R))
                SceneManager.LoadScene(0);
        }
    }
}