using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Garage
{
    public class TaskUIManager : MonoBehaviour
    {
        [SerializeField] private VerticalLayoutGroup taskPanel;
        [SerializeField] private ContentSizeFitter fitter;
        [SerializeField] private Task taskItemPrefab;

        public void DisplayTask(string text, TaskManager taskManager)
        {
            Task taskItem = Instantiate(taskItemPrefab, taskPanel.transform);
            taskItem.Initialize(text, taskManager);
            StartCoroutine(RebuildLayout());
        }

        IEnumerator RebuildLayout()
        {
            yield return new WaitForSeconds(0.1f);
            LayoutRebuilder.ForceRebuildLayoutImmediate(taskPanel.GetComponent<RectTransform>());
        }
    }
}