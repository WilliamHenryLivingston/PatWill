using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCutscene : MonoBehaviour
{
    [SerializeField] private GameObject outroCutscene;
    [SerializeField] private GameObject gameCompleteScreen;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInput.Instance.CursorEnable();
        outroCutscene.gameObject.SetActive(true);
        gameCompleteScreen.SetActive(true);
    }
}
