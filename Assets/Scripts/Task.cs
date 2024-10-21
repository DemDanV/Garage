using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Garage
{
    public class Task : MonoBehaviour
    {
        [SerializeField] private Slider _progressBar;
        [SerializeField] private TMP_Text _text;

        private TaskManager _taskManager;

        public void Initialize(string text, TaskManager taskManager)
        {
            _progressBar.maxValue = 1;

            _text.text = text;
            _taskManager = taskManager;

            _taskManager.onProgressChanged += UpdateProgress;
            _taskManager.onComplete += CompleteTask;
        }

        private void UpdateProgress(float progress)
        {
            _progressBar.value = progress;
        }

        private void CompleteTask()
        {
            _text.text = "Задание выполнено!";
        }

        private void OnDestroy()
        {
            _taskManager.onProgressChanged -= UpdateProgress;
            _taskManager.onComplete -= CompleteTask;
        }
    }
}
