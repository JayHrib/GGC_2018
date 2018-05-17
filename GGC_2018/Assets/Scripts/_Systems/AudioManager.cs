using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 0.7f;

    [Range(0.5f, 1.5f)]
    public float pitch = 1f;

    [Range(0.0f, 0.5f)]
    public float rndVolumeMod = 0.1f;

    [Range(0.0f, 0.5f)]
    public float rndPitchMod = 0.1f;

    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-rndVolumeMod / 2f, rndVolumeMod / 2f));
        source.pitch = pitch * (1 + Random.Range(-rndPitchMod / 2f, rndPitchMod / 2f));
        source.Play();
    }
}

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("AudioManager: More than one audiomanager in scene!");
        }
        else
        {
            instance = this;
        }
    }

	// Use this for initialization
	void Start () {
		for (int i = 0; i < sounds.Length; i++)
        {
            GameObject go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            go.transform.SetParent(this.transform);
            sounds[i].SetSource(go.AddComponent<AudioSource>());
        }
	}
	
	public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        Debug.LogWarning("AudioManager: Sound with the name: " + _name + " not found");
    }
}
