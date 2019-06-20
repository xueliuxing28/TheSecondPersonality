using UnityEngine.SceneManagement;

public class RestartGame : UIBase {
    private UIButton restartBtn;
    private void Awake()
    {
        Bind(UIEvent.RESTART_GAME);
        restartBtn = GetComponent<UIButton>();
        restartBtn.onClick.Add(new EventDelegate(OnRestartGame));
    }
    private void OnRestartGame()
    {
        //loading
        Dispatch(AreaCode.UI, UIEvent.LOADING_SCENE, true);
        //获取当前场景index
        int index = SceneManager.GetActiveScene().buildIndex;
        Dispatch(AreaCode.SCENE, index, index);
    }
}
