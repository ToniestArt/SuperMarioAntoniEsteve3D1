using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource _audioSource; //Añadimos el acceso al componente "AudioSource".
    
    public AudioClip gameMusic; //Creamos un parámetro "AudioClip" dentro del componente "AudioSource" a este componente le asignamos la variable "gameMusic".

   

    void Awake()
    {

        _audioSource = GetComponent<AudioSource>();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
     StartBGM();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartBGM() //Creamos una función la cual llamamos en VoidStart para no enguarrar ahí dentro.
    {
        _audioSource.loop = true; //El audio se repite en bucle.
        _audioSource.clip = gameMusic; //El clip es el que está asignado en el componente "gameMusic" que hemos creado arriba.
        _audioSource.Play(); //Ejecuta el clip de audio.
    }
}
