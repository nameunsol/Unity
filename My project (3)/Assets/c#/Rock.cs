using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Rock : MonoBehaviour
{
    public Text talk;
    public Text Name;
    public GameObject uiObject;
    private int currentIndex;
    private Dialogue[] dialogues;
    private Dialogue[] dialogues10;
    private bool is10;

    [System.Serializable]
    public class Dialogue
    {
        public string speaker;
        [TextArea(3, 10)]
        public string message;
        public string[] choices;
    }

    void Count0()
    {
        dialogues = new Dialogue[]
        {
            new Dialogue { speaker = "말하는 봉인석", message = "당신이 이 숲의 주인인가..?" },
            new Dialogue { speaker = "숲의 주인", message = "말하는 비석..?\n비석이 말을하는 거야?" },
            new Dialogue { speaker = "말하는 봉인석", message = "나는 아주 오래전 이 숲을 관리하는 일을 했었지\n아주 오래 전에 말이야"},
            new Dialogue { speaker = "말하는 봉인석", message = "힘이 부족했던 예전의 난 숲의 위기를 막을 수 있었지만\n이런 몸이 되었어" },
            new Dialogue { speaker = "말하는 봉인석", message = "그 때 성공했다고 생각했는데\n나의 힘이 부족했던 탓인가\n다시 봉인이 풀려버렸어" },
            new Dialogue { speaker = "말하는 봉인석", message = "숲의 주인 당신이라면 이 숲을 지킬 수 있을 거야\n공격해오는 오염된 숲의 주민들을 정화시키고 보석 10개를 모아서 나에게 봉인해줘" }
        };

        // 대화 시작
        StartDialogue();
    }

    void Count10()
    {
        is10 = true;
        dialogues10 = new Dialogue[]
        {
            new Dialogue { speaker = "말하는 봉인석", message = "당신이 이 숲을 지켰어!" },
            new Dialogue { speaker = "말하는 봉인석", message = "고마워\n앞으로도 숲을 부탁할게"},
            new Dialogue { speaker = "금오 스토리", message = "게임 종료" },
        };

        // 대화 시작
        StartDialogue();
    }


    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 객체가 플레이어인지 확인
        if (other.CompareTag("Player"))
        {
            uiObject.SetActive(true);
            if (GameManager.Instance.gemCount == 0)
            {
                Count0();
            }
            else if (GameManager.Instance.gemCount == 10)
            {
                Count10();
            }
        }
    }

    void StartDialogue()
    {
        currentIndex = 0;
        StartCoroutine(DisplayNextMessage());
    }

    IEnumerator DisplayNextMessage()
    {
        if (currentIndex < (is10 ? dialogues10.Length : dialogues.Length))
        {
            Dialogue currentDialogue = is10 ? dialogues10[currentIndex] : dialogues[currentIndex];

            Name.text = currentDialogue.speaker;
            talk.text = currentDialogue.message;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));

            currentIndex++;

            // 다음 대화 표시
            StartCoroutine(DisplayNextMessage());
        }
        else
        {
            yield return new WaitForSeconds(2.0f); // 초 동안 대기
            uiObject.SetActive(false);
            if (is10) SceneManager.LoadScene(0);
        }
    }
}

