﻿using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct messageDialog
{
	[TextArea(1, 2)]
	public string speakerName;
    public bool isADialogue;
	[TextArea(3, 10)]
	public string translationIndex;
	public AudioClip SpeakSound;
	public float TypingSpeed;
	public UnityEvent EventosADisparar;
	public Sprite Portrait;
}

[System.Serializable]
public class Dialogue
{
	public messageDialog[] SentenceList;
	// public EstadoDeEscena EstadoDeEscenaAlQueCambiar;
}
