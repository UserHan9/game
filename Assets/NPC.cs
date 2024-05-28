using UnityEngine;
using TMPro;
using System.Collections;

public class NPC : MonoBehaviour
{
    // Referensi ke canvas dialogue
    public GameObject dialogueCanvas;

    // Referensi ke TextMeshProUGUI di dalam canvas dialogue
    public TextMeshProUGUI dialogueText;

    // Array untuk menyimpan berbagai dialog
    public string[] dialogues;

    // Kecepatan penulisan teks
    public float textSpeed = 0.05f;

    // Coroutine untuk menampilkan teks satu per satu
    private Coroutine typingCoroutine;

    private int currentDialogueIndex = 0; // Indeks dialog saat ini

    private bool isDialogActive = false; // Menyimpan apakah sedang berdialog atau tidak

    private void Start()
    {
        // Menyembunyikan canvas dan TextMesh Pro saat mulai
        if (dialogueCanvas != null)
        {
            dialogueCanvas.SetActive(false);
        }
        
        else
        {
            Debug.LogWarning("Dialogue Canvas reference is missing!");
        }
    }

    private void Update()
    {
        // Memeriksa jika teks telah selesai ditampilkan dan tombol kanan mouse ditekan
        if (isDialogActive && Input.GetMouseButtonDown(1) && !IsTyping())
        {
            ShowNextDialogue();
        }
    }

    // Method untuk menampilkan canvas dialogue beserta teksnya satu per satu
    public void ShowDialogueCanvas(int index)
    {
        if (dialogueCanvas != null && index >= 0 && index < dialogues.Length)
        {
            dialogueCanvas.SetActive(true);

            // Memulai coroutine untuk menampilkan teks satu per satu
            typingCoroutine = StartCoroutine(TypeText(dialogues[index]));
            isDialogActive = true; // Mengatur bahwa sedang berdialog
        }
        else
        {
            Debug.LogWarning("Dialogue Canvas reference is missing or invalid index!");
        }
    }

    // Coroutine untuk menampilkan teks satu per satu
    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";
        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        // Setelah selesai menampilkan teks, hentikan coroutine
        typingCoroutine = null;
    }

    // Method untuk menyembunyikan canvas dialogue
    public void HideDialogueCanvas()
    {
        if (dialogueCanvas != null)
        {
            dialogueCanvas.SetActive(false);
            isDialogActive = false; // Mengatur bahwa tidak sedang berdialog
        }
        else
        {
            Debug.LogWarning("Dialogue Canvas reference is missing!");
        }
    }

    // Method untuk menampilkan dialog berikutnya
    private void ShowNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length - 1)
        {
            currentDialogueIndex++;
            ShowDialogueCanvas(currentDialogueIndex);
        }
        else
        {
            HideDialogueCanvas();
        }
    }

    // Method untuk memeriksa apakah teks sedang ditampilkan
    public bool IsTyping()
    {
        return typingCoroutine != null;
    }

    // Method untuk menangani interaksi
    public void Interact()
    {
        // Lakukan aksi interaksi yang diinginkan di sini
        Debug.Log("Interacting with NPC: " + gameObject.name);

        // Menampilkan canvas dialogue dengan teks yang ditentukan
        ShowDialogueCanvas(currentDialogueIndex);
    }
}
