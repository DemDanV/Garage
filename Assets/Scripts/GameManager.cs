using UnityEngine;
using UnityEngine.SceneManagement;

namespace Garage
{
    public class GameManager : MonoBehaviour
    {
        private PlayerItemHandler _playerItemHandler;
        private Crosshair _crosshair;
        private TaskManager _taskManager;
        private TaskUIManager _taskUIManager;

        private void Start()
        {
            _crosshair = FindObjectOfType<Crosshair>();

            _playerItemHandler = FindObjectOfType<PlayerItemHandler>();
            _playerItemHandler.Initialize(Camera.main, _crosshair, 3f);

            _taskManager = FindObjectOfType<TaskManager>();

            _taskUIManager = FindObjectOfType<TaskUIManager>();
            _taskUIManager.DisplayTask("Переместите все вещи с полок в машину", _taskManager);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.R))
                SceneManager.LoadScene(0);
        }
    }
}