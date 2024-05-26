using UnityEngine;

public class UserData
{
    public int defaultCurrentLevel = 1;
    public int currentLevel = 1;
}
public class DataManager : Singleton<DataManager>
{
    public UserData userData;
    private void Start()
    {
        SaveUserData();
        LoadUserData();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Dữ liệu người dùng: {JsonUtility.ToJson(userData)}");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ResetData();
        }
    }
    public void LevelUp()
    {
        userData.currentLevel++;
        SaveUserData();
    }

    private void LoadUserData()
    {

        string json = PlayerPrefs.GetString("USER_DATA");
        if (string.IsNullOrEmpty(json))
        {
            userData = new UserData();
        }
        else
        {
            userData = JsonUtility.FromJson<UserData>(json);
        }
    }
    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData);
        PlayerPrefs.SetString("USER_DATA", json);
        PlayerPrefs.Save();
    }

    public void ResetData()
    {
        userData.currentLevel = userData.defaultCurrentLevel;
        SaveUserData();
    }
}