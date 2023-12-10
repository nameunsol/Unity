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
        // ��ȭ ������ �ʱ�ȭ (����)
        dialogues = new Dialogue[]
        {
            new Dialogue { speaker = "???", message = "���� ���� �Ȱ��� �Ϸ縦 ������ ��� ���� ����" },
            new Dialogue { speaker = "???", message = "��ҿ� �޸� �Ҷ������� ���� �Ҹ��� �ῡ�� �����." },
            new Dialogue { speaker = "���� ����", message = "��...\n����..?"},
            new Dialogue { speaker = "���� ����", message = "���� ���� ���ƴٳຼ��?" }
        };

        // ��ȭ ����
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

            // ���� ��ȭ ǥ��
            StartCoroutine(DisplayNextMessage());
        }
        else
        {
            yield return new WaitForSeconds(1.0f); // 2�� ���� ���
            SceneManager.LoadScene(2);
        }
    }
}
