using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMnager : MonoBehaviour
{
    public Text talk;
    public Text Name;

    [System.Serializable]
    public class Dialogue
    {
        public string speaker;
        [TextArea(3, 10)]
        public string message;
        public string[] choices;
    }

    private int currentIndex;
    private Dialogue[] dialogues;

    void Start()
    {
        // 대화 데이터 초기화 (예시)
        dialogues = new Dialogue[]
        {
            new Dialogue { speaker = "???", message = "매일 매일 똑같은 하루를 보내는 어느 숲의 주인" },
            new Dialogue { speaker = "???", message = "평소와 달리 소란스러운 숲의 소리에 잠에서 깨어난다." },
            new Dialogue { speaker = "숲의 주인", message = "음...\n뭐지..?"},
            new Dialogue { speaker = "숲의 주인", message = "숲을 조금 돌아다녀볼까?" }
        };

        // 대화 시작
        StartDialogue();
    }

    void StartDialogue()
    {
        currentIndex = 0;
        StartCoroutine(DisplayNextMessage());
    }

    IEnumerator DisplayNextMessage()
    {
        if (currentIndex < dialogues.Length)
        {
            Dialogue currentDialogue = dialogues[currentIndex];
            
            Name.text = currentDialogue.speaker;
            talk.text = currentDialogue.message;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            currentIndex++;

            // 다음 대화 표시
            StartCoroutine(DisplayNextMessage());
        }
        else
        {
            yield return new WaitForSeconds(1.0f); // 2초 동안 대기
            SceneManager.LoadScene(2);
        }
    }
}
