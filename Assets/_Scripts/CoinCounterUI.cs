using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;
    [SerializeField] private Ease animationCurve;

    private float containerInitPosition;
    private float moveAmount;

    private void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    public void UpdateScore(int score) {
        toUpdate.SetText($"{score}"); //set the needed update score to the according score
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration) //move the score number up
            .SetEase(animationCurve); //Sets what kind of animationCurve you want
        //using the container itself

        StartCoroutine(ResetContainerScore(score));
    }  

    IEnumerator ResetContainerScore(int score) {
        yield return new WaitForSeconds(duration); //wait for however long duration is
        //duration = duration of animation
        current.SetText($"{score}");
        Vector3 localPosition = coinTextContainer.localPosition;
        coinTextContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.z);
    }
}


