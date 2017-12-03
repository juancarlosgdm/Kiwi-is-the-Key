using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
    /* Singleton */
    public static AudioManager instance;

    [Header("Key Sounds")]
    public AudioClip ASound;
    public AudioClip BSound;
    public AudioClip CSound;
    public AudioClip DSound;
    public AudioClip ESound;
    public AudioClip FSound;
    public AudioClip GSound;
    public AudioClip HSound;
    public AudioClip ISound;
    public AudioClip JSound;
    public AudioClip KSound;
    public AudioClip LSound;
    public AudioClip MSound;
    public AudioClip NSound;
    public AudioClip OSound;
    public AudioClip PSound;
    public AudioClip QSound;
    public AudioClip RSound;
    public AudioClip SSound;
    public AudioClip TSound;
    public AudioClip USound;
    public AudioClip VSound;
    public AudioClip WSound;
    public AudioClip XSound;
    public AudioClip YSound;
    public AudioClip ZSound;
    public AudioClip SpaceSound;

    private List<AudioSource> freeAudioSources;
    private AudioSource audioSourceTemplate;
    private AudioSource menuAudioSource;
	private AudioSource ingameAudioSource;
    private AudioSource gameoverAudioSource;

    private void Awake() {
        // Singleton
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
        // Referencias
        audioSourceTemplate = transform.Find("AudioSourceTemplate").GetComponent<AudioSource>();
        menuAudioSource = transform.Find("MenuAudioSource").GetComponent<AudioSource>();
		ingameAudioSource = transform.Find("IngameAudioSource").GetComponent<AudioSource>();
        gameoverAudioSource = transform.Find("GameOverAudioSource").GetComponent<AudioSource>();
    }

    private void Start() {
        freeAudioSources = new List<AudioSource>();
        freeAudioSources.Add(audioSourceTemplate);
        GenerateAudioSourceFromTemplate();
    }

    public void PlayGameOverMusic() {
		ingameAudioSource.Stop();
        gameoverAudioSource.Play();
    }

    public void PlayKeySound(KeyCode keyCode) {
        switch (keyCode) {
            case KeyCode.A:
                GetFreeAudioSource().PlayOneShot(ASound);
                break;
            case KeyCode.B:
                GetFreeAudioSource().PlayOneShot(BSound);
                break;
            case KeyCode.C:
                GetFreeAudioSource().PlayOneShot(CSound);
                break;
            case KeyCode.D:
                GetFreeAudioSource().PlayOneShot(DSound);
                break;
            case KeyCode.E:
                GetFreeAudioSource().PlayOneShot(ESound);
                break;
            case KeyCode.F:
                GetFreeAudioSource().PlayOneShot(FSound);
                break;
            case KeyCode.G:
                GetFreeAudioSource().PlayOneShot(GSound);
                break;
            case KeyCode.H:
                GetFreeAudioSource().PlayOneShot(HSound);
                break;
            case KeyCode.I:
                GetFreeAudioSource().PlayOneShot(ISound);
                break;
            case KeyCode.J:
                GetFreeAudioSource().PlayOneShot(JSound);
                break;
            case KeyCode.K:
                GetFreeAudioSource().PlayOneShot(KSound);
                break;
            case KeyCode.L:
                GetFreeAudioSource().PlayOneShot(LSound);
                break;
            case KeyCode.M:
                GetFreeAudioSource().PlayOneShot(MSound);
                break;
            case KeyCode.N:
                GetFreeAudioSource().PlayOneShot(NSound);
                break;
            case KeyCode.O:
                GetFreeAudioSource().PlayOneShot(OSound);
                break;
            case KeyCode.P:
                GetFreeAudioSource().PlayOneShot(PSound);
                break;
            case KeyCode.Q:
                GetFreeAudioSource().PlayOneShot(QSound);
                break;
            case KeyCode.R:
                GetFreeAudioSource().PlayOneShot(RSound);
                break;
            case KeyCode.S:
                GetFreeAudioSource().PlayOneShot(SSound);
                break;
            case KeyCode.T:
                GetFreeAudioSource().PlayOneShot(TSound);
                break;
            case KeyCode.U:
                GetFreeAudioSource().PlayOneShot(USound);
                break;
            case KeyCode.V:
                GetFreeAudioSource().PlayOneShot(VSound);
                break;
            case KeyCode.W:
                GetFreeAudioSource().PlayOneShot(WSound);
                break;
            case KeyCode.X:
                GetFreeAudioSource().PlayOneShot(XSound);
                break;
            case KeyCode.Y:
                GetFreeAudioSource().PlayOneShot(YSound);
                break;
            case KeyCode.Z:
                GetFreeAudioSource().PlayOneShot(ZSound);
                break;
            case KeyCode.Space:
                GetFreeAudioSource().PlayOneShot(SpaceSound);
                break;
        }
    }

    public void StopMenuMusic() {
        menuAudioSource.Stop();
		ingameAudioSource.Play();
    }

    private AudioSource GenerateAudioSourceFromTemplate() {
        AudioSource source = GameObject.Instantiate(audioSourceTemplate, transform);
        //source.outputAudioMixerGroup = audioSourceTemplate.outputAudioMixerGroup;
        freeAudioSources.Add(source);

        return source;
    }

    private AudioSource GetFreeAudioSource() {
        int i = 0;
        while ((i < freeAudioSources.Count) && (freeAudioSources[i].isPlaying)) {
            ++i;
        }
        if (i == freeAudioSources.Count) {
            GenerateAudioSourceFromTemplate();
        }

        return freeAudioSources[i];
    }
}
