using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float speed;
}

[System.Serializable]
public class GameData
{
    public PlayerData player_data;
    public PulpitData pulpit_data;
}

public class Movement : MonoBehaviour
{
    [SerializeField] float _verticalInput;
    [SerializeField] float _horizontalInput;
    [SerializeField] float _speed;
    [SerializeField] TextAsset jsonFile;

    void Start()
    {
        if (jsonFile != null)
        {
            GameData gameData = JsonUtility.FromJson<GameData>(jsonFile.text);
            Debug.Log(gameData.player_data.speed);
            _speed = gameData.player_data.speed;
        }
        else
        {
            Debug.LogError("Failed to load JSON file");
        }
    }
    void Update()
    {
        GetInput();
        MoveDoofus(_verticalInput, _horizontalInput);
    }


    // Gets the input from the user, (W,A,S,D and up,down,left,right)
    void GetInput()
    {
        _verticalInput = Input.GetAxisRaw("Vertical");
        _horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    void MoveDoofus(float _verticalInput, float _horizontalInput)
    {   
        if(_verticalInput != 0)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime * _verticalInput);
        }
        if(_horizontalInput != 0)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime * _horizontalInput);
        }
    }

}
