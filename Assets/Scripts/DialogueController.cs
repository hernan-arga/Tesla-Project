using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
	public Dialogue Dialogue;
	Queue<messageDialog> Sentences;
	IEnumerator CoroutineTypeText;
	public GameObject DialoguePanel;
	public TextMeshProUGUI DisplayText;
	public TextMeshProUGUI SpeakerName;
	messageDialog ActiveSentence;
	AudioSource MyAudio;
	//public GameController GameController;
	bool typingText;
	private bool inTag = false;
	private TextEffect activeEffect = TextEffect.None;
	private int countOfCharsOfTags = 0;
	public Gradient rainbow;

	Mesh mesh;
	Vector3[] vertices;

	Dictionary<int, TextEffect> effectsByChar;

	public float shaky_velocity = 10f;
	public float shaky_maxHeight = 5f;
	public float wobble_velocity = 5f;
	public float wobble_maxWidth = 1f;
	public float color_velocity = 0.001f;

	// Start is called before the first frame update
	void Start()
	{
		typingText = false;
		Sentences = new Queue<messageDialog>();
		MyAudio = GetComponent<AudioSource>();
		effectsByChar = new Dictionary<int, TextEffect>();
		StartDialogueSystem();

		DialoguePanel.SetActive(true);
		DisplayNextSentence();
		
	}

	void StartDialogueSystem()
	{
		Sentences.Clear();

		foreach (messageDialog sentence in Dialogue.SentenceList)
		{
			Sentences.Enqueue(sentence);
		}

	}

	void DisplayNextSentence()
	{
		if (Sentences.Count <= 0)
		{
			StopTypingText();
			//GameController.EstadoDeEscena = Dialogue.EstadoDeEscenaAlQueCambiar;
			DialoguePanel.SetActive(false);
			Destroy(gameObject);
			return;
		}

		ActiveSentence = Sentences.Dequeue();

		StopTypingText();
		//SpeakerName.text = ActiveSentence.speakerName;
		CoroutineTypeText = TypeTheSentence(ActiveSentence);
		StartCoroutine(CoroutineTypeText);
	}

	IEnumerator TypeTheSentence(messageDialog activeSentence)
	{
		DisplayText.text = "";        

		for (int i = 0; i < activeSentence.message.Length; i++)
		{
			CheckTag(activeSentence.message, activeSentence.message[i], i, ref inTag);

            if (inTag)
            {
				countOfCharsOfTags++;
			}

            else
            {
				effectsByChar.Add(i-countOfCharsOfTags, activeEffect);
				DisplayText.text += activeSentence.message[i];

				MyAudio.PlayOneShot(activeSentence.SpeakSound);
				yield return new WaitForSeconds(activeSentence.TypingSpeed);
				typingText = true;
			}
		}

		activeSentence.EventosADisparar.Invoke();

		typingText = false;
	}

	void FinishActiveSentence()
	{
		StopCoroutine(CoroutineTypeText);
		DisplayText.text = ActiveSentence.message;
		ActiveSentence.EventosADisparar.Invoke();
		typingText = false;
	}

	void StopTypingText()
	{
		if (CoroutineTypeText != null)
		{
			StopCoroutine(CoroutineTypeText);
		}
	}

	protected void CheckTag(string fullText, char c, int j, ref bool inTag)
    {
        if (c=='<')
        {
			inTag = true;
			char next = fullText[j + 1];
            if (next!='/')
            {
                //Entering a new tag
                switch (next)
                {
					case 'w': 
						activeEffect = TextEffect.Wobble; 
						break;
					case 's':
						activeEffect = TextEffect.Shaky;
						break;
					case 'c':
						activeEffect = TextEffect.Color;
						break;
					default:
                        break;
                }
            }
            else
            {
				//Exited an ending tag i.e. </w> and so we need to set the active effect back to none
				activeEffect = TextEffect.None;
			}
        }
        else if (j>0 && fullText[j-1]=='>')
        {
			// if previous tag was '>' meaning we just exited a tag
			inTag = false;
        }
    }

	void Update()
	{
		DisplayText.ForceMeshUpdate();
		mesh = DisplayText.mesh;
		vertices = mesh.vertices;

		Color[] colors = mesh.colors;

		foreach (var keyValuePair in effectsByChar)
		{
			TMP_CharacterInfo c = DisplayText.textInfo.characterInfo[keyValuePair.Key];

			int index = c.vertexIndex;

			if(keyValuePair.Value.Equals(TextEffect.Color))
            {
				colors[index] = rainbow.Evaluate(Mathf.Repeat(Time.time + vertices[index].x * color_velocity, 1f));
				colors[index + 1] = rainbow.Evaluate(Mathf.Repeat(Time.time + vertices[index + 1].x * color_velocity, 1f));
				colors[index + 2] = rainbow.Evaluate(Mathf.Repeat(Time.time + vertices[index + 2].x * color_velocity, 1f));
				colors[index + 3] = rainbow.Evaluate(Mathf.Repeat(Time.time + vertices[index + 3].x * color_velocity, 1f));
			}
			

			Vector3 offset = ApplyEffect(keyValuePair.Key, keyValuePair.Value);
			vertices[index] += offset;
			vertices[index + 1] += offset;
			vertices[index + 2] += offset;
			vertices[index + 3] += offset;
		

			mesh.vertices = vertices;
			mesh.colors = colors;
			DisplayText.canvasRenderer.SetMesh(mesh);
		}

		if (Input.GetKeyDown(KeyCode.J))
		{			

			if (typingText)
			{
				//FinishActiveSentence();
			}

			else
			{
				effectsByChar.Clear();
				countOfCharsOfTags = 0;
				DisplayNextSentence();
			}

		}

	}

	Vector2 ApplyEffect(int index, TextEffect effect)
    {
        switch (effect)
        {
            case TextEffect.None:				
                return new Vector2(0, 0);
			case TextEffect.Color:
				return new Vector2(0, 0);
			case TextEffect.Wobble:
				return Wobble(Time.time + index);
            case TextEffect.Shaky:
				return Shaky(Time.time + index);
        }

		return new Vector2(0, 0);
	}

	Vector2 Wobble(float time)
	{
		return new Vector2(Mathf.Sin(time * wobble_velocity) * wobble_maxWidth, Mathf.Cos(time * wobble_velocity) * wobble_maxWidth);
	}

	Vector2 Shaky(float time)
	{
		return new Vector2(0, Mathf.Cos(time * shaky_velocity) * shaky_maxHeight);
	}
}
