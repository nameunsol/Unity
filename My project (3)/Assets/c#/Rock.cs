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
            new Dialogue { speaker = "���ϴ� ���μ�", message = "����� �� ���� �����ΰ�..?" },
            new Dialogue { speaker = "���� ����", message = "���ϴ� ��..?\n���� �����ϴ� �ž�?" },
            new Dialogue { speaker = "���ϴ� ���μ�", message = "���� ���� ������ �� ���� �����ϴ� ���� �߾���\n���� ���� ���� ���̾�"},
            new Dialogue { speaker = "���ϴ� ���μ�", message = "���� �����ߴ� ������ �� ���� ���⸦ ���� �� �־�����\n�̷� ���� �Ǿ���" },
            new Dialogue { speaker = "���ϴ� ���μ�", message = "�� �� �����ߴٰ� �����ߴµ�\n���� ���� �����ߴ� ſ�ΰ�\n�ٽ� ������ Ǯ�����Ⱦ�" },
            new Dialogue { speaker = "���ϴ� ���μ�", message = "���� ���� ����̶�� �� ���� ��ų �� ���� �ž�\n�����ؿ��� ������ ���� �ֹε��� ��ȭ��Ű�� ���� 10���� ��Ƽ� ������ ��������" }
        };

        // ��ȭ ����
        StartDialogue();
    }

    void Count10()
    {
        is10 = true;
        dialogues10 = new Dialogue[]
        {
            new Dialogue { speaker = "���ϴ� ���μ�", message = "����� �� ���� ���׾�!" },
            new Dialogue { speaker = "���ϴ� ���μ�", message = "����\n�����ε� ���� ��Ź�Ұ�"},
            new Dialogue { speaker = "�ݿ� ���丮", message = "���� ����" },
        };

        // ��ȭ ����
        StartDialogue();
    }


    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ��ü�� �÷��̾����� Ȯ��
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

            // ���� ��ȭ ǥ��
            StartCoroutine(DisplayNextMessage());
        }
        else
        {
            yield return new WaitForSeconds(2.0f); // �� ���� ���
            uiObject.SetActive(false);
            if (is10) SceneManager.LoadScene(0);
        }
    }
}

