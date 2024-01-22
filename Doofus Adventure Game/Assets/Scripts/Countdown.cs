using UnityEngine;
using TMPro;

[System.Serializable]
public class PulpitData
{
    public float min_pulpit_destroy_time;
    public float max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}

public class Countdown : MonoBehaviour
{
    public GameObject pulpitObject;
    [SerializeField] TextMeshProUGUI _countDownText;
    [SerializeField] TextAsset jsonFile;
    [SerializeField] Animator disappearAnim;
    private float destoryTime;

    void Start()
    {
        GameData gameData = JsonUtility.FromJson<GameData>(jsonFile.text);
        destoryTime = Random.Range(gameData.pulpit_data.min_pulpit_destroy_time, gameData.pulpit_data.max_pulpit_destroy_time);
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isGameplay) Count();
        if(destoryTime <= 0)
        {
            disappearAnim.SetTrigger("Destroy");
            Destroy(pulpitObject,1);
        }
    }

    void Count()
    {
        destoryTime -= Time.deltaTime;
        destoryTime = Mathf.Clamp(destoryTime,0,destoryTime);
        _countDownText.text = destoryTime.ToString("F2");
    }
}
