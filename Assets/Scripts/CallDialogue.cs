using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using UnityEngine.SceneManagement;

public class CallDialogue : MonoBehaviour {

    public AdvEngine engine;
    public string scenarioLabel;
    public string nextScene;

    // コリジョンにぶつかった
    public void Call()
    {
        StartCoroutine(StartDialogue());
    }

    IEnumerator StartDialogue()
    {
        //Utageのシナリオを呼び出す
        engine.JumpScenario(scenarioLabel);

        //Utageのシナリオ終了待ち
        while (!engine.IsEndScenario)
        {
            yield return 0;
        }

        if(engine.IsEndScenario)
            SceneManager.LoadScene(nextScene);

    }
}
