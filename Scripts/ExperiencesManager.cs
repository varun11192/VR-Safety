using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.VFX;

public class ExperiencesManager : MonoBehaviour
{
    public GameObject[] customPositions; // Array to store custom positions for each experience
    int _index = 0;
    bool _changing = false;
    float _changeDelay = 3f;
    float _timer = 0f;
    AudioSource[] _audioSources;
    private Animator anim;

    [SerializeField] private GameObject Exp6;
    [SerializeField] private GameObject playerObject;

    private void Awake()
    {
        _audioSources = new AudioSource[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _audioSources[i] = transform.GetChild(i).GetComponent<AudioSource>();
        }


        ChangeExperience(0);
    }



    public void ChangeExperience(int _change)
    {
        if (_changing)
            return;

        if (_index == transform.childCount - 1 && _change == 1)
            _index = 0;
        else if (_index == 0 && _change == -1)
            _index = transform.childCount - 1;
        else
            _index += _change;

        StartCoroutine(ChangeExperienceCoroutine());
    }

    public int GetCurrentExperienceIndex()
    {
        return _index;
    }

    private IEnumerator ChangeExperienceCoroutine()
    {
        _changing = true;
        _timer = 0f;

        // Disable all child objects and stop audio for the rest
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);

            // Stop audio for all experiences
            if (_audioSources[i] != null && _audioSources[i].isPlaying)
                _audioSources[i].Stop();
        }

        // Enable the desired child object and start audio for the current experience
        transform.GetChild(_index).gameObject.SetActive(true);

        
        if (_audioSources[_index] != null)
            _audioSources[_index].Play();

        // Update the player's position based on the custom position of the current experience
        if (_index < customPositions.Length)
        {
            playerObject.transform.position = customPositions[_index].transform.position;
            playerObject.transform.rotation = customPositions[_index].transform.rotation;
        }

        PlayButtonForAll play = transform.GetChild(_index).GetComponent<PlayButtonForAll>();
        anim = play.exp.GetComponent<Animator>();
        Debug.Log("passpass");

        for (int i = 0; i <= (_audioSources[_index].clip.length/ (anim.GetCurrentAnimatorStateInfo(0).length + 5)) + 1; i++)
        {

            anim.SetTrigger(play.trigger);

            // Wait for the animation to complete
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

            // Wait for an additional 20 seconds before triggering the reset animation
            yield return new WaitForSeconds(5f);

            anim.SetTrigger(play.resetTrigger);
        }

 
        // Wait for audio to end
        //yield return new WaitForSeconds(_audioSources[_index].clip.length);

        _changing = false;

        // Change to the next experience
        ChangeExperience(1);
        

    }

    public IEnumerator PlayAnimAndWait(string trigger, Animator anim, PlayButtonForAll play)
    {

        Debug.Log("message");
        anim.SetTrigger(trigger);

        // Wait for the animation to complete
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        // Wait for an additional 20 seconds before triggering the reset animation
        yield return new WaitForSeconds(5f);

        anim.SetTrigger(play.resetTrigger);

        PlayAnimAndWait(trigger, anim, play);

        
    }
}
