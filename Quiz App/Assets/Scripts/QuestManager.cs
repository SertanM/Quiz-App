using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuestManager : MonoBehaviour
{
    public Quest[] Quests;
    public int questIndex = -1;
    public TMP_Text  questText;
    public TMP_Text[] answers;
    public GameObject youWin;
    public GameObject questsParent;
    public ParticleSystem confetti;
    public AudioSource correctAnswerSFX, wrongAnswerSFX;

    public GameObject cam;
    void Start(){
        ReloadQuest();
    }

    void ReloadQuest()
    {
        questIndex++;

        
        if(questIndex < Quests.Length){
            questText.text = Quests[questIndex].quest;
            for(int i = 0; i<answers.Length; i++ ){
                answers[i].text = Quests[questIndex].answers[i];
                answers[i].GetComponentInParent<Image>().color = Color.white;
            }

        }
        else{
            youWin.gameObject.SetActive(true);
            questsParent.gameObject.SetActive(false);
            var confettiSettings = confetti.main;
            confettiSettings.loop ^= true;
        }
        
    }

    public void answerClick(TMP_Text text){
        if(text.text == answers[Quests[questIndex].correctAnswerIndex].text)
        {
            correctAnswer();
        }else{
            wrongAnswer(text);
        }
    }

    void correctAnswer(){
        correctAnswerSFX.Play();
        confetti.Play();
        ReloadQuest();
    }

    void wrongAnswer(TMP_Text wrongText){
        wrongAnswerSFX.Play();
        wrongText.GetComponentInParent<Image>().color = Color.red;
        cam.transform.DOShakePosition(0.5f, 10, 20, 90);
    }

    public void Reply(){
        
        questIndex=-1;
        confetti.Stop();
        var confettiSettings = confetti.main;
        confettiSettings.loop ^= false;
        correctAnswerSFX.Play();
        ReloadQuest();
        youWin.gameObject.SetActive(false);
        questsParent.gameObject.SetActive(true);
    }
}
